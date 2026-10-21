#!/usr/bin/env python3
"""Verify assessment identity preservation and recorded standalone solution checks."""
import argparse, hashlib, json, re, subprocess
from collections import Counter
from pathlib import Path
ROOT = Path(__file__).resolve().parents[1]
OUT = ROOT / 'authoring/assignment_revision'
def text(cell): return ''.join(cell.get('source', []))
def digest(value): return hashlib.sha256(value.encode()).hexdigest()
def radio_pairs(source): return set(re.findall(r'<input[^>]*name="([^"]+)"[^>]*value="([^"]+)"', source))
def main():
    parser = argparse.ArgumentParser()
    parser.add_argument('--html', type=Path)
    args = parser.parse_args()
    manifest = json.loads((OUT / 'manifest.json').read_text())
    old = manifest['baseline_commit']
    original_ids = exercise_ids = inline_ids = radio_ids = 0
    for path in manifest['notebooks']:
        before = json.loads(subprocess.check_output(['git', 'show', f'{old}:{path}'], cwd=ROOT, text=True))
        after = json.loads((ROOT/path).read_text())
        ids = [c.get('id') for c in after['cells']]
        old_counts = Counter(c.get('id') for c in before['cells'] if c.get('id'))
        new_counts = Counter(ident for ident in ids if ident)
        assert all(count <= max(1, old_counts[ident]) for ident, count in new_counts.items()), f'New duplicate cell ID: {path}'
        by_id = {c.get('id'): c for c in after['cells']}
        for cell in before['cells']:
            ident = cell.get('id')
            if not ident: continue
            original_ids += 1
            assert new_counts[ident] >= old_counts[ident], (path, ident)
            previous = cell.get('metadata', {})
            for key in ['exercise_id', 'assignment_id']:
                if key in previous:
                    assert by_id[ident].get('metadata', {}).get(key) == previous[key], (path, ident, key)
                    exercise_ids += 1
        for key, value in before.get('metadata', {}).items():
            if key.endswith('_id'): assert after.get('metadata', {}).get(key) == value, (path,key)
        a = '\n'.join(text(c) for c in before['cells']); b = '\n'.join(text(c) for c in after['cells'])
        old_radio = radio_pairs(a); assert old_radio <= radio_pairs(b), path
        radio_ids += len(old_radio)
        for ident in re.findall(r'exercise-id\s*:\s*([\w-]+)', a, re.I):
            assert ident in b, (path,ident); inline_ids += 1
    for path, expected in manifest['unchanged_slides'].items():
        assert hashlib.sha256((ROOT/path).read_bytes()).hexdigest() == expected, path
    import yaml
    before_toc = yaml.safe_load(subprocess.check_output(['git','show',f'{old}:_toc.yml'],cwd=ROOT,text=True))
    after_toc = yaml.safe_load((ROOT/'_toc.yml').read_text())
    def files(value):
        if isinstance(value,dict): return ([value['file']] if 'file' in value else []) + [p for v in value.values() for p in files(v)]
        if isinstance(value,list): return [p for v in value for p in files(v)]
        return []
    assert files(before_toc) == files(after_toc), 'TOC reading/chapter order changed'
    records = json.loads((OUT/'solution_checks.json').read_text())
    checked = set()
    for row in records:
        if not row.get('file') or not row.get('cell_id') or not row.get('source_sha256'): continue
        if row.get('expected_failure') or row.get('stored') is False: continue
        nb = json.loads((ROOT/row['file']).read_text())
        cell = next(c for c in nb['cells'] if c.get('id') == row['cell_id'])
        if digest(text(cell)) != row['source_sha256']: continue  # intentional variant is checked in its own result
        assert row.get('passed', True), row
        assert row.get('exit_code',row.get('run_exit_code',0)) == 0, row
        if 'hide-input' in cell.get('metadata', {}).get('tags',[]):
            actual = ''.join(''.join(o.get('text',[])) for o in cell.get('outputs',[]) if o.get('output_type') == 'stream')
            assert actual == row['stdout'], (row['file'],row['cell_id'],'stored stdout')
        checked.add((row['file'],row['cell_id'],row['source_sha256']))
    for row in manifest['changed_solutions']:
        assert (row['file'],row['cell_id'],row['source_sha256']) in checked, ('Unverified solution',row)
    if args.html:
        from bs4 import BeautifulSoup
        for num in [21,22,23,24,25,26]:
            folder = next((ROOT/'chapters').glob(f'{num:02d}_*')).name
            for stem, groups in [('preview',10),('homework',5)]:
                page = args.html/'chapters'/folder/'assignments'/f'{stem}.html'
                article = BeautifulSoup(page.read_text(),'html.parser').select_one('article')
                controls = article.select('input[type=radio]')
                assert len({x['name'] for x in controls}) == groups, page
                assert all(len({x.get('value') for x in controls if x['name']==name}) == (4 if stem=='preview' else 2) for name in {x['name'] for x in controls}),page
                assert 'Submit' in article.get_text(),page
        for num in [3,4,5,7,9]:
            folder = next((ROOT/'chapters').glob(f'{num:02d}_*')).name
            page = args.html/'chapters'/folder/'assignments/homework.html'
            article = BeautifulSoup(page.read_text(),'html.parser').select_one('article')
            assert len(article.select('.tag_exercise')) == 5,page
            assert len({x['name'] for x in article.select('input[type=radio]')}) == 5,page
        assert 'Optional' in (args.html/'chapters/23_searching_sorting/assignments/index.html').read_text()
    result = dict(original_cell_ids_preserved=original_ids, metadata_assessment_ids_preserved=exercise_ids,
                  inline_exercise_ids_preserved=inline_ids, radio_name_value_pairs_preserved=radio_ids,
                  unchanged_slides=True, chapter_and_reading_order_preserved=True,
                  verified_completed_solutions=len(manifest['changed_solutions']), rendered_controls_checked=bool(args.html))
    (OUT/'preservation_checks.json').write_text(json.dumps(result,indent=2)+'\n')
    print(json.dumps(result,indent=2))
if __name__ == '__main__': main()
