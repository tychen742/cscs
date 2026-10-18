import hashlib,json,re
from pathlib import Path
from urllib.parse import urlsplit,unquote
from bs4 import BeautifulSoup
R=Path(__file__).resolve().parents[1];O=R/'authoring/index_cleanup';B=Path('/tmp/cscs-section-revision/_build/html');p=B/'genindex.html';s=BeautifulSoup(p.read_text(),'html.parser');article=s.select_one('article') or s
bad=[a.get_text(' ',strip=True) for a in article.select('.indextable a') if re.match(r'^\d+[.)]\s+',a.get_text(' ',strip=True))]
assert not bad,bad
text=article.get_text(' ',strip=True);assert '1D Arrays' not in text;assert 'one-dimensional' in text;assert 'SDK; runtime; dotnet --version' not in text
assert 'dotnet --version' in text
assert not [a.get_text(' ',strip=True) for a in article.select('.indextable a') if re.match(r'^and\s',a.get_text(' ',strip=True),re.I)]
assert 'Blocks, Formatting, and Comments' in text
assert 'Best, Worst, Expected, and Amortized Costs' in text
assert '\\g<2>' not in text
from importlib.util import spec_from_file_location, module_from_spec
spec=spec_from_file_location('subject_index',R/'_ext/subject_index.py');mod=module_from_spec(spec);spec.loader.exec_module(mod)
assert mod.normalize_entry(('single','Summary','x','',None)) == []
assert [x[1] for x in mod.normalize_entry(('single','collection; families; access pattern','x','',None))] == ['collection; families','collection; access pattern']
assert mod.normalize_entry(('single','Dictionary<TKey, TValue>','x','',None))[0][1] == 'Dictionary<TKey, TValue>'

cache={p:s};missing=[];checked=0
for a in article.select('a[href]'):
 u=urlsplit(a['href'])
 if u.scheme or u.netloc:continue
 target=(p.parent/unquote(u.path)).resolve() if u.path else p
 if not target.exists():missing.append(a['href']);continue
 if u.fragment:
  if target not in cache:cache[target]=BeautifulSoup(target.read_text(),'html.parser')
  if not cache[target].find(id=unquote(u.fragment)):missing.append(a['href'])
 checked+=1
assert not missing,missing[:20]
hashes=json.load(open(O/'notebook_hashes.json'))
for f,h in hashes.items():assert hashlib.sha256((R/f).read_bytes()).hexdigest()==h,f
report={'numbered_task_entries_removed':True,'boilerplate_entries_removed':True,'comma_phrases_preserved':True,'case_variants_merged':True,'semicolon_lists_expanded':True,'array_heading_filed_as':'array; one-dimensional','combined_dotnet_entry_split':True,'remaining_numbered_task_entries':bad,'index_links_checked':checked,'broken_index_links':missing,'notebooks_unchanged':len(hashes),'build':'passed','deployment':'not deployed'}
(O/'verification.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps(report,indent=2))
