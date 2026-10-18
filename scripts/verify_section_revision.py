#!/usr/bin/env python3
"""Check preserved lesson text/code against the pre-reorganization working tree."""
from pathlib import Path
import json,re,hashlib,yaml
R=Path(__file__).resolve().parents[1];F=R/'authoring/section_revision'
base=json.loads((F/'baseline.json').read_text())
current={str(p.relative_to(R))[:-6]:json.loads(p.read_text()) for p in (R/'chapters').rglob('*.ipynb')}
from integration_preservation import preintegration_view
current={p[:-6]:n for p,n in preintegration_view(R,{p+'.ipynb':n for p,n in current.items()}).items()}
# Follow exact, documented later repairs when checking the older preservation
# baseline. Both sides are checked; this is not a blanket text exclusion.
corrections_file=R/'authoring/priority_development/source_corrections.json'
later_corrections=json.loads(corrections_file.read_text()) if corrections_file.exists() else []
for repair in later_corrections:
 notebook=current[repair['path'][:-6]]
 cell=next(c for c in notebook['cells'] if c['id']==repair['cell_id'])
 assert cell['cell_type']=='markdown'
 assert ''.join(cell['source'])==repair['after'], repair['path']
 cell['source']=repair['before'].splitlines(keepends=True)
def canon(s):
 s=re.sub(r'(?i)\b(sections?|lessons?)\s+(\d{1,2}\.\d{1,2}(?:\s*(?:[–—,-]|and|to)\s*\d{1,2}\.\d{1,2})*)',r'\1 <section reference>',s)
 s=re.sub(r'```\{rubric\} Footnotes\s*\n```\s*','',s);s=re.sub(r'```\{index\}[^\n]*\n```\s*','',s);s=re.sub(r'^#{1,6}\s+','',s,flags=re.M);s=re.sub(r'\[\^[^]]+\]','[^note]',s)
 return re.sub(r'\s+',' ',s).strip()
def keys(toc):
 result=[]
 def walk(n):
  if 'file' in n:result.append(n['file'])
  for s in n.get('sections',[]):walk(s)
 for p in toc['parts']:
  for ch in p['chapters']:walk(ch)
 return result
audit_toc=R/'authoring/integration_cleanup/toc_before.yml'
newkeys=set(keys(yaml.safe_load((audit_toc if audit_toc.exists() else R/'_toc.yml').read_text())))
oldkeys=set(keys(yaml.safe_load((F/'toc_before.yml').read_text())))
newlessons={k:n for k,n in current.items() if k in newkeys and re.match(r'chapters/\d\d_',k) and '/assignments/' not in k and not re.search(r'/\d\d00_',k)}
mds=[(k,canon(''.join(c['source']))) for k,n in newlessons.items() for c in n['cells'] if c['cell_type']=='markdown'];blob=' '.join(t for k,t in mds)
allcode={''.join(c['source']) for n in current.values() for c in n['cells'] if c['cell_type']=='code'}
activecode={''.join(c['source']) for n in newlessons.values() for c in n['cells'] if c['cell_type']=='code'}
missing=[];checked=0;oldcode=0;renamed=[];globalcode=0;redistributed=[]
for p,n in base.items():
 for i,c in enumerate(n['cells']):
  s=''.join(c['source'])
  if c['cell_type']=='code' and s.strip():
   globalcode+=1
   if s not in allcode:missing.append({'path':p,'cell':c.get('id'),'kind':'original code missing from tree'})
 if p not in oldkeys or '/assignments/' in p or re.search(r'/\d\d00_',p):continue
 for c in n['cells']:
  s=''.join(c['source'])
  if not s.strip():continue
  checked+=1
  if c['cell_type']=='code':oldcode+=1;ok=s in activecode
  else:
   ok=canon(s) in blob
   if not ok and re.match(r'^# ',s):
    # Two content pages named Lab received explanatory lesson titles.
    body='\n'.join(s.splitlines()[1:]);ok=bool(body.strip()) and canon(body) in blob
    renamed_titles={'chapters/23_searching_sorting/2303_comparison_lab':'Comparing Complete Search and Sort Workloads','chapters/17_trees/1703_tree_lab':'Tree Queries and Verification'}
    if not body.strip() and p in renamed_titles:ok=any(renamed_titles[p] in t for k,t in mds if k==p)
    if ok:renamed.append({'path':p,'cell':c.get('id'),'change':'first heading renamed; body retained'})
  if not ok and c['cell_type']=='markdown':
   fragments=[canon(x) for x in re.split(r'\n\s*\n',s) if canon(x)]
   # Footnote definitions may move away from the narrative in the same original cell.
   ok=bool(fragments) and all(fragment in blob for fragment in fragments)
   if ok:redistributed.append({'path':p,'cell':c.get('id'),'check':'all original paragraph/control fragments retained; footnotes relocated'})
  if not ok:missing.append({'path':p,'cell':c.get('id'),'kind':'active lesson source missing','sample':s[:100]})
# Assignments retain their full cell source, identities, outputs and metadata.
changed_assignments=[]
reference_only_assignments=[]
for p,n in base.items():
 if '/assignments/' not in p or n['cells']==current[p]['cells']:continue
 oldcells=n['cells'];newcells=current[p]['cells']
 safe=len(oldcells)==len(newcells) and all({k:v for k,v in a.items() if k!='source'}=={k:v for k,v in b.items() if k!='source'} and (a['source']==b['source'] or (a['cell_type']=='markdown' and canon(''.join(a['source']))==canon(''.join(b['source'])))) for a,b in zip(oldcells,newcells))
 (reference_only_assignments if safe else changed_assignments).append(p)
result={'active_original_nonempty_cells':checked,'active_original_code_cells':oldcode,'all_original_code_cells':globalcode,'active_current_readings':len(newlessons),'missing':missing,'heading_only_changes':renamed,'redistributed_footnote_cells':redistributed,'changed_assignment_cells':changed_assignments,'assignment_reference_corrections_only':reference_only_assignments}
result['documented_later_markdown_repairs']=len(later_corrections)
if audit_toc.exists():result['audit_view']='Pre-integration arrangement reconstructed through checked cell lineage; current arrangement checked by verify_integration_cleanup.py.'
(F/'preservation_check.json').write_text(json.dumps(result,indent=2)+'\n')
print(json.dumps(result,indent=2));assert not missing and not changed_assignments
