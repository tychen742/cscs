import json,re,hashlib,os
from pathlib import Path
from bs4 import BeautifulSoup
os.chdir(Path(__file__).resolve().parents[1])
D=Path('authoring/subsection_organization_revision');before=json.loads((D/'before.json').read_text());report=[];anchor={};count=0
for file,n in before.items():
 now=json.loads(Path(file).read_text());byid={c.get('id'):c for c in now['cells']}
 assert len(byid)==len(now['cells']),file
 for old in n['cells']:
  assert old.get('id') in byid,(file,old.get('id'))
  new=byid[old.get('id')]
  if old['cell_type']=='code':assert old==new,(file,old['id']);count+=1
  else:
   def normalize(c):return re.sub(r'^#{2,4} ', '## ',''.join(c['source']),flags=re.M)
   if old['id']!='b6d9f75f':
    expected=normalize(old)
    for item in json.loads((D/'changes.json').read_text()):
     if item.get('action')=='reference correction' and item.get('file')==file and item.get('cell_id')==old['id']:expected=expected.replace(item['old'],item['new'])
    assert expected==normalize(new),(file,old['id'])
   else:assert '## Checkpoint: Apply the Basic Merge Sort' in ''.join(new['source']) and '(exercise)=' in ''.join(new['source'])
  assert old.get('metadata',{})==new.get('metadata',{}),(file,old['id'])
 html=Path('/tmp/cscs-section-revision/_build/html')/(file[:-6]+'.html')
 if html.exists():
  soup=BeautifulSoup(html.read_text(),'html.parser');anchor[file]=[x['id'] for x in soup.select('section[id]')]
 report.append({'file':file,'original_cells':len(n['cells']),'current_cells':len(now['cells']),'all_original_cells_preserved':True,'code_and_outputs_unchanged':True})
assert hashlib.sha256(Path('_toc.yml').read_bytes()).hexdigest()==(D/'toc_sha256.txt').read_text()
(D/'preservation_results.json').write_text(json.dumps({'pages':report,'unchanged_code_cells':count,'toc_unchanged':True},indent=2));((D/'original_section_anchors.json').write_text(json.dumps(anchor,indent=2)) if not (D/'original_section_anchors.json').exists() else None);print('Preserved',sum(x['original_cells'] for x in report),'original cells, including',count,'unchanged code cells and outputs')

import urllib.parse
D=Path('authoring/subsection_organization_revision');root=Path('/tmp/cscs-section-revision/_build/html');anchors=json.loads((D/'original_section_anchors.json').read_text());broken=[];oldmissing=[];seen={};checked=0
anchors['genindex.ipynb']=[]
def page(p):
 p=p.resolve()
 if p not in seen:seen[p]=BeautifulSoup(p.read_text(),'html.parser')
 return seen[p]
for file,old in anchors.items():
 p=root/(file[:-6]+'.html');doc=page(p)
 for a in old:
  if not doc.find(id=a):oldmissing.append({'file':file,'anchor':a})
 for a in doc.select('a[href]'):
  u=urllib.parse.urlsplit(a['href'])
  if u.scheme or u.netloc or not (u.path or u.fragment):continue
  dest=(root/u.path.lstrip('/')) if u.path.startswith('/') else p.parent/u.path if u.path else p
  if dest.is_dir():dest=dest/'index.html'
  if not dest.exists():broken.append({'file':file,'href':a['href'],'kind':'missing file'});continue
  if u.fragment and dest.suffix=='.html' and not page(dest).find(id=urllib.parse.unquote(u.fragment)):
   broken.append({'file':file,'href':a['href'],'kind':'missing fragment'})
  checked+=1
result={'old_heading_anchors_checked':sum(map(len,anchors.values())),'old_heading_anchors_missing':oldmissing,'rendered_links_checked':checked,'broken_links':broken}
(D/'link_results.json').write_text(json.dumps(result,indent=2));print(json.dumps(result,indent=2));assert not oldmissing

assert not broken,broken

# Confirm the recorded semantic relationships still match the current hierarchy.
for check in json.loads((D/'hierarchy_results.json').read_text()):
 n=json.loads(Path(check['file']).read_text());stack=[];found=False
 for c in n['cells']:
  if c['cell_type']!='markdown':continue
  m=re.search(r'^(#{1,4}) (.+)$',''.join(c['source']),re.M)
  if not m:continue
  lev=len(m[1]);title=m[2]
  while stack and stack[-1][0]>=lev:stack.pop()
  if title==check['child']:
   assert stack and stack[-1][1]==check['parent'],check
   found=True
  stack.append((lev,title))
 assert found,check
print('Semantic heading relationships verified.')
