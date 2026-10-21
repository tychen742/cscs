#!/usr/bin/env python3
"""Check lecture outputs, source examples, and unchanged assessment identities."""
import argparse
from collections import Counter
import hashlib
import json
from pathlib import Path
import re
import subprocess
import xml.etree.ElementTree as ET
import zipfile

ROOT = Path(__file__).resolve().parents[1]
REPORT = ROOT / 'authoring/slide_revision'

def digest(source):
    return hashlib.sha256(source.encode()).hexdigest()

def slides(source):
    body = re.sub(r'^---\n.*?\n---\n', '', source, count=1, flags=re.S)
    return [s for s in re.split(r'^---\s*$', body, flags=re.M) if s.strip()]

def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--html-dir', type=Path)
    args = parser.parse_args()
    manifest = json.loads((REPORT/'manifest.json').read_text())
    baseline = manifest['baseline_commit']
    old_files = subprocess.check_output(['git', 'ls-tree', '-r', '--name-only', baseline], cwd=ROOT, text=True).splitlines()
    notebooks = 0
    for file in old_files:
        if not file.endswith('.ipynb'):
            continue
        before = json.loads(subprocess.check_output(['git', 'show', f'{baseline}:{file}'], cwd=ROOT))
        after = json.loads((ROOT/file).read_text())
        assert [c.get('id') for c in before['cells']] == [c.get('id') for c in after['cells']], f'Cell identity/order changed: {file}'
        for old, new in zip(before['cells'], after['cells']):
            assert old.get('metadata') == new.get('metadata'), f'Metadata changed: {file}'
            if old != new:
                old_text = ''.join(old.get('source', []))
                assert 'chapter lecture deck is in preparation' in old_text, f'Non-slide cell changed: {file}'
                assert new['cell_type'] == 'markdown' and '_slides.html' in ''.join(new['source']), file
        notebooks += 1
    assert (ROOT/'_toc.yml').read_bytes() == subprocess.check_output(['git', 'show', f'{baseline}:_toc.yml'], cwd=ROOT), 'TOC changed'
    for file in ['_html_extra/chapters/01_context/overview.md', '_html_extra/chapters/01_context/overview.html']:
        assert (ROOT/file).read_bytes() == subprocess.check_output(['git', 'show', f'{baseline}:{file}'], cwd=ROOT), 'Compatibility deck changed'

    records = json.loads((REPORT/'code_results.json').read_text())
    builds = json.loads((REPORT/'build_results.json').read_text())
    assert len(builds) == 26 and all(r['exit_code'] == 0 and not r['warnings'] for r in builds), 'Deck build failed or reported overflow'
    for record in builds:
        assert hashlib.sha256((ROOT/record['source']).read_bytes()).hexdigest() == record['source_sha256'], 'Deck source changed after build'
    validations = json.loads((REPORT/'pptx_validation.json').read_text())
    assert len(validations) == 26 and all(r['exit_code'] == 0 for r in validations), 'PowerPoint validation failed'
    for record in validations:
        assert hashlib.sha256((ROOT/record['file']).read_bytes()).hexdigest() == record['sha256'], 'PowerPoint changed after validation'
    passed = Counter((r['source_sha256'], r['expected_stdout']) for r in records if r['passed'])
    decks = sorted((ROOT/'_html_extra/chapters').glob('*/*_slides.md'))
    assert len(decks) == 26, f'Expected 26 decks, found {len(decks)}'
    total_slides = total_notes = examples = 0
    for deck in decks:
        source = deck.read_text()
        landing = next((ROOT/'chapters'/deck.parent.name).glob(deck.stem[:4]+'*.ipynb'))
        landing_text = '\n'.join(''.join(c['source']) for c in json.loads(landing.read_text())['cells'])
        chapter_title = re.search(r'^# (.+)', landing_text, re.M).group(1)
        deck_title = re.search(r'^title: "(.+)"', source, re.M).group(1)
        assert re.sub(r'^Chapter \d+: ', '', deck_title) == chapter_title, f'Chapter title drift: {deck}'
        parts = slides(source)
        starts = [i+1 for i, part in enumerate(parts) if re.search(r'_class:\s*section', part)]
        mapped = [int(n) for n in re.findall(r'(?:starting slide|slide) (\d+)', parts[0])]
        assert starts == mapped, f'Part-start map mismatch: {deck}'
        total_slides += len(parts)
        for part in parts:
            notes = [n.strip() for n in re.findall(r'<!--(.*?)-->', part, re.S) if not re.match(r'\s*_?(class|paginate|header|footer|backgroundColor|color)\s*:', n)]
            assert notes and all(len(n) > 35 for n in notes), f'Missing teaching notes: {deck}'
            total_notes += 1
        html = deck.with_suffix('.html')
        assert html.exists(), f'Missing student HTML: {deck}'
        for part in parts:
            for note in re.findall(r'<!--(.*?)-->', part, re.S):
                if len(note.strip()) > 80 and not re.match(r'\s*_?class\s*:', note):
                    assert note.strip() not in html.read_text(), f'Instructor note leaked: {html}'
        for code, stdout in re.findall(r'```csharp\n(.*?)```\s*```output\n(.*?)```', source, re.S):
            assert passed[(digest(code), stdout)], f'Unverified example: {deck}\n{code}'
            examples += 1
        assert len(re.findall(r'```csharp\n', source)) == len(re.findall(r'```csharp\n(.*?)```\s*```output\n(.*?)```', source, re.S)), f'Code lacks adjacent verified output: {deck}'
        pptx = ROOT/'assignments/slides'/deck.with_suffix('.pptx').name
        with zipfile.ZipFile(pptx) as archive:
            slide_xml = [n for n in archive.namelist() if re.fullmatch(r'ppt/slides/slide\d+\.xml', n)]
            note_xml = [n for n in archive.namelist() if re.fullmatch(r'ppt/notesSlides/notesSlide\d+\.xml', n)]
            assert len(slide_xml) == len(note_xml) == len(parts), f'PPTX count mismatch: {pptx}'
            for name in slide_xml:
                root = ET.fromstring(archive.read(name))
                assert root.findall('.//{http://schemas.openxmlformats.org/drawingml/2006/main}t'), f'No editable text: {pptx}:{name}'
        if args.html_dir:
            staged = args.html_dir/'chapters'/deck.parent.name/html.name
            assert staged.exists() and staged.read_bytes() == html.read_bytes(), f'Staged deck mismatch: {staged}'
            assert not staged.with_suffix('.md').exists(), 'Instructor source published'
            assert not staged.with_suffix('.pptx').exists(), 'Instructor PowerPoint published'
    result = dict(decks=len(decks), slides=total_slides, slides_with_notes=total_notes,
                  verified_examples=examples, original_notebooks_preserved=notebooks,
                  assessment_metadata_and_order_preserved=True, chapter_order_preserved=True,
                  legacy_deck_preserved=True, staged_html_checked=bool(args.html_dir))
    (REPORT/'preservation_checks.json').write_text(json.dumps(result, indent=2)+'\n')
    print(json.dumps(result, indent=2))

if __name__ == '__main__':
    main()
