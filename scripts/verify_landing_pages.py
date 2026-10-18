#!/usr/bin/env python3
"""Check source/rendered landing-page contracts and preserve teaching notebooks."""
import argparse
import hashlib
import json
import re
from pathlib import Path
from urllib.parse import unquote, urlsplit
from bs4 import BeautifulSoup

ROOT = Path(__file__).resolve().parents[1]
OUT = ROOT / 'authoring/landing_page_revision'
parser = argparse.ArgumentParser()
parser.add_argument('--html', type=Path, default=Path('/tmp/cscs-section-revision/_build/html'))
args = parser.parse_args()
manifest = json.loads((OUT / 'manifest.json').read_text())
originals = json.loads((ROOT / 'authoring/landing_page_audit/inventory.json').read_text())
baseline = json.loads((OUT / 'preserved_notebooks.json').read_text())
expected_headers = ['Chapter Video', 'Learning Objectives', 'Chapter Flow', 'Glossary', 'Lecture Slides']
results = []
checked_links = 0
cache = {}
for entry, original in zip(manifest, originals):
    path = ROOT / entry['path']
    notebook = json.loads(path.read_text())
    assert all(cell['cell_type'] == 'markdown' for cell in notebook['cells']), path
    text = '\n\n'.join(''.join(cell['source']) for cell in notebook['cells'])
    assert '{index}' not in text, path
    assert re.findall(r'<h2>(.*?)</h2>', text) == expected_headers, path
    assert not re.search(r'^#{2,6} ', text, re.M), path
    intro = text.split('<h2>Chapter Video</h2>')[0]
    assert len(re.findall(r'^- \*\*.+?\*\*:', intro, re.M)) in range(3, 6), path
    assert re.search(r'^# .+\n\n[^\n#-]', intro, re.M), path
    for label in re.findall(r'^\([\w-]+\)=', original['source'], re.M):
        assert label in text, (path, label)
    assert 'By the end of this chapter, you will be able to:' in text, path
    html_path = args.html / (entry['path'].replace('.ipynb', '.html'))
    doc = BeautifulSoup(html_path.read_text(), 'html.parser')
    article = doc.select_one('article')
    assert article is not None, html_path
    assert len(article.select('h1')) == 1, html_path
    if entry.get('legacy_heading_anchor'):
        assert article.find(id=entry['legacy_heading_anchor']), html_path
    headers = article.find_all('h2')
    assert [h.get_text(strip=True) for h in headers] == expected_headers, html_path
    objectives = headers[1].find_next_sibling('ol')
    assert objectives and len(objectives.find_all('li', recursive=False)) == entry['objectives'], html_path
    flow = article.select_one('.chapter-flow')
    assert flow, html_path
    actual = []
    for link in flow.select('a[href]'):
        target = (html_path.parent / unquote(urlsplit(link['href']).path)).resolve()
        actual.append(str(target.relative_to(args.html.resolve())).removesuffix('.html'))
        assert '/assignments/' not in link['href'], (html_path, link['href'])
    assert actual == original['expected_content'], (entry['chapter'], actual)
    glossary_elements = []
    for sibling in headers[3].next_siblings:
        if getattr(sibling, 'name', None) == 'h2':
            break
        glossary_elements.append(sibling)
    tables = [e for e in glossary_elements if getattr(e, 'name', None) == 'table']
    tables += [t for e in glossary_elements if getattr(e, 'name', None) != 'table' and hasattr(e, 'find_all') for t in e.find_all('table')]
    assert len(tables) == 1, html_path
    table = tables[0]
    assert [h.get_text(strip=True) for h in table.select('thead th')] == ['#', 'Term', 'Explanation'], html_path
    rows = table.select('tbody tr')
    assert len(rows) == entry['glossary_terms'], (html_path, len(rows))
    terms = []
    for number, row in enumerate(rows, 1):
        cells = row.find_all('td', recursive=False)
        assert len(cells) == 3, (html_path, row)
        assert cells[0].get_text(strip=True) == str(number), (html_path, row)
        assert cells[1].get_text(strip=True) and cells[2].get_text(strip=True), html_path
        terms.append(cells[1].get_text(strip=True).casefold())
    assert len(terms) == len(set(terms)), html_path
    assert not any(getattr(e, 'name', None) == 'p' and e.get_text(strip=True).startswith('|') for e in glossary_elements), html_path
    frames = article.find_all('iframe')
    ids = []
    for frame in frames:
        assert frame.get('title') and frame.get('referrerpolicy') and frame.has_attr('allowfullscreen'), html_path
        assert frame['src'].startswith('https://www.youtube-nocookie.com/embed/'), html_path
        ids.append(frame['src'].split('/')[-1].split('?')[0])
    assert ids == entry['video_ids'], html_path
    assert set(original['youtube_ids']) <= set(ids), 'Existing video changed'
    assert 'Hosted on YouTube; property of its original creator' in article.get_text(), html_path
    for link in article.select('a[href]'):
        url = urlsplit(link['href'])
        if url.scheme or url.netloc:
            continue
        target = ((html_path.parent / unquote(url.path)).resolve() if url.path else html_path)
        assert target.is_file(), (html_path, link['href'])
        if url.fragment and target.suffix == '.html':
            if target not in cache:
                cache[target] = BeautifulSoup(target.read_text(), 'html.parser')
            assert cache[target].find(id=unquote(url.fragment)), (html_path, link['href'])
        checked_links += 1
    results.append({'chapter': entry['chapter'], 'glossary_rows': len(rows), 'objectives': entry['objectives'], 'status': 'pass; lecture deck separately deferred'})
for path, digest in baseline.items():
    assert hashlib.sha256((ROOT / path).read_bytes()).hexdigest() == digest, path
report = {'chapters_checked': len(results), 'non_landing_notebooks_byte_identical': len(baseline), 'local_links_checked': checked_links, 'chapters': results, 'deferred': '26 lecture decks, per explicit author instruction'}
(OUT / 'verification.json').write_text(json.dumps(report, indent=2) + '\n')
print(json.dumps({k: v for k, v in report.items() if k != 'chapters'}, indent=2))
