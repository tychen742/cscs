"""Check the reviewed index mapping, passage coverage, links, and preservation."""
import hashlib
import json
import pickle
import re
import subprocess
from collections import Counter
from pathlib import Path
from urllib.parse import unquote, urlsplit
from bs4 import BeautifulSoup

ROOT = Path(__file__).resolve().parents[1]
OUT = ROOT / 'authoring/index_revision'
BUILD = Path('/tmp/cscs-section-revision/_build/html')
rows = json.loads((OUT / 'mapping.json').read_text())
manifest = json.loads((ROOT / '_ext/subject_index_entries.json').read_text())
additions = json.loads((ROOT / '_ext/subject_index_additions.json').read_text())['entries']
baseline = json.loads((OUT / 'before_entries.json').read_text())
assert len(rows) == len(manifest) == len(baseline) == 1435
assert {row['original'] for row in rows} == set(baseline)
assert all(manifest[row['original'].casefold()] == row['subjects'] for row in rows)
assert all(not row['subjects'] for row in rows if row['audit_decision'] == 'remove')
assert all(row['subjects'] for row in rows if row['audit_decision'] != 'remove')
assert not any(re.match(r'^(?:and\s|\d+[.)]\s|A |Guide |Verify |Practice:)', value)
               for values in manifest.values() for value in values)

cache = {}
def page(document):
    path = BUILD / (document + '.html')
    if path not in cache:
        assert path.is_file(), path
        cache[path] = BeautifulSoup(path.read_text(), 'html.parser')
    return cache[path]

def section(document, target):
    node = page(document).find(id=target)
    assert node is not None, (document, target)
    enclosing = node if node.name == 'section' else node.find_parent('section')
    return enclosing.get('id') if enclosing else target

expected = set()
for row in rows:
    for location in row['locations']:
        document, target = location['document'], location['target']
        passage = section(document, target)
        expected.update((document, 'single', subject, passage) for subject in row['subjects'])
for entry in additions:
    expected.add((entry['document'], entry.get('kind','single'), entry['value'],
                  section(entry['document'], entry['target'])))
env = pickle.load((BUILD.parent / '.doctrees/environment.pickle').open('rb'))
actual = set()
raw_actual = []
for document, entries in env.domaindata['index']['entries'].items():
    for kind, value, target, main, category in entries:
        actual.add((document, kind, value, section(document,target)))
        raw_actual.append((document,kind,value,target))
assert expected == actual, {'missing': sorted(expected-actual)[:20],
                            'unexpected':sorted(actual-expected)[:20]}
assert len(raw_actual) == len(actual), 'Duplicate pointers in the same lesson passage'
roots = {value.split(';')[0].strip() for _,kind,value,_ in actual if kind == 'single'}
case_groups = {}
for root in roots:
    case_groups.setdefault(root.casefold(),set()).add(root)
assert not {k:v for k,v in case_groups.items() if len(v)>1}, 'Capitalization duplicate main terms'
for _,kind,value,_ in actual:
    if kind in {'see','seealso'}:
        destinations = value.split(';',1)[1].split(',')
        assert all(d.strip() in roots for d in destinations), value
        assert value.split(';',1)[0].strip() not in [d.strip() for d in destinations], value
for term in ['recursion','dynamic programming','debugging','exceptions','structs',
             'records','inheritance','polymorphism','binary search','linear search',
             'insertion sort','selection sort','bubble sort',"Dijkstra's algorithm",
             "Kruskal's algorithm",'KMP string matching','breadth-first search','depth-first search']:
    assert any(kind=='single' and value==term for _,kind,value,_ in actual), term
# Semantic regressions from the audit: these relationships must not recur.
for _,kind,value,_ in actual:
    if kind != 'single':
        continue
    assert not value.startswith('last in first out;'), value
    assert value != 'string; Parse', value
    assert value != 'namespace; entry point', value
    assert value != 'tree height; tree depth', value
    assert 'Keys Keys' not in value and 'parameter parameter' not in value, value

index = BeautifulSoup((BUILD/'genindex.html').read_text(),'html.parser')
article = index.select_one('article') or index
broken = []
checked = 0
for link in article.select('a[href]'):
    url = urlsplit(link['href'])
    if url.scheme or url.netloc:
        continue
    path = (BUILD/unquote(url.path)).resolve() if url.path else BUILD/'genindex.html'
    if not path.exists():
        broken.append(link['href']);continue
    if url.fragment:
        if path not in cache:cache[path]=BeautifulSoup(path.read_text(),'html.parser')
        if not cache[path].find(id=unquote(url.fragment)):broken.append(link['href'])
    checked += 1
assert not broken, broken[:20]
# Verify the rendered term/pointer pairs, not just the build-domain data.
rendered_pointers = set()
def first_label(item):
    for child in item.children:
        if isinstance(child, str) and child.strip():
            return child.strip().rstrip(',')
        if getattr(child, 'name', None) == 'a':
            return child.get_text(' ',strip=True)
    return ''
def record_links(item, value):
    for link in item.find_all('a',recursive=False):
        url = urlsplit(link.get('href',''))
        if not url.scheme and url.path.endswith('.html'):
            rendered_pointers.add((unquote(url.path[:-5]),'single',value,unquote(url.fragment)))
for item in article.select('.indextable td > ul > li'):
    root = first_label(item)
    record_links(item,root)
    nested = item.find('ul',recursive=False)
    if nested:
        for child in nested.find_all('li',recursive=False):
            if child.find('em',recursive=False):
                continue
            subentry = first_label(child)
            record_links(child,root+'; '+subentry)
expected_pointers = {row for row in raw_actual if row[1]=='single'}
assert expected_pointers <= rendered_pointers, sorted(expected_pointers-rendered_pointers)[:20]
rendered = article.get_text(' ',strip=True)
for alias in ['BFS','DFS','GCD','KMP','ADT','MST','OOP']:
    assert alias in rendered, alias
hashes = json.loads((ROOT/'authoring/index_cleanup/notebook_hashes.json').read_text())
missing_ignored_checkpoints = []
for file, before in hashes.items():
    path = ROOT/file
    if not path.exists() and '/.ipynb_checkpoints/' in file:
        ignored = subprocess.run(['git','check-ignore','--quiet',file],cwd=ROOT)
        assert ignored.returncode == 0, file
        missing_ignored_checkpoints.append(file)
        continue
    assert hashlib.sha256(path.read_bytes()).hexdigest() == before, file
tracked_notebooks = subprocess.check_output(['git','ls-files','*.ipynb'],cwd=ROOT,text=True).splitlines()
subprocess.run(['git','diff','HEAD','--exit-code','--','*.ipynb'],cwd=ROOT,check=True,capture_output=True)
report = {'audited_entries_resolved':len(rows), 'original_locations_accounted_for':sum(map(len,baseline.values())),
          'canonical_subject_terms':len({v for _,k,v,_ in actual if k=='single'}),
          'generated_lookup_pointers':len(actual),
          'cross_references':sum(1 for _,k,_,_ in actual if k in {'see','seealso'}),
          'added_direct_entries':sum(1 for e in additions if e.get('kind','single')=='single'),
          'administrative_entries_removed':sum(1 for r in rows if not r['subjects']),
          'local_index_links_checked':checked,'broken_index_links':broken,
          'notebooks_byte_identical':len(hashes)-len(missing_ignored_checkpoints),'tracked_notebooks_unchanged':len(tracked_notebooks),'absent_ignored_checkpoint_files':missing_ignored_checkpoints, 'unresolved_mapping_entries':0,
          'coverage_matches_reviewed_mapping':True,'rendered_term_pointer_pairs_verified':len(expected_pointers),'deployment':'not deployed'}
(OUT/'verification.json').write_text(json.dumps(report,indent=2)+'\n')
print(json.dumps(report,indent=2))
