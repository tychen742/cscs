#!/usr/bin/env python3
"""Verify original content/cell identity, executable preservation and integration seams."""
import hashlib,json,re
from pathlib import Path
import nbformat,yaml
ROOT=Path(__file__).resolve().parents[1]; OUT=ROOT/'authoring/integration_cleanup'
def source(c):return ''.join(c['source'])
def canonical(text):
 text=re.sub(r'```\{(?:index|contents)\}[^\n]*\n.*?```','',text,flags=re.S)
 text=re.sub(r'```\{rubric\} Footnotes\s*\n```','',text).replace('`{rubric} Footnotes`','')
 text=re.sub(r'^#{1,6} .*$', '',text,flags=re.M)
 text=re.sub(r'^\([^\n]+\)=\s*$', '',text,flags=re.M)
 text=re.sub(r'<span id="[^"]+"></span>','',text)
 return re.sub(r'\s+',' ',text).strip()
def main():
 baseline=json.loads((OUT/'baseline.json').read_text());mapping=json.loads((OUT/'cell_moves.json').read_text());lookup={(r['from_path'],r['from_id']):r for r in mapping}
 current={p:json.loads((ROOT/p).read_text()) for p in baseline}
 for p,n in current.items():nbformat.validate(n)
 removed={tuple(r['origin']):r for r in json.loads((OUT/'removed_structure.json').read_text()) if r['origin']}
 blob=' '.join(canonical(source(c)) for n in current.values() for c in n['cells'] if c['cell_type']=='markdown')
 edits=[];missing=[];code=0;retained=0
 for p,n in baseline.items():
  for old in n['cells']:
   key=(p,old['id']);m=lookup.get(key)
   if not m:
    assert key in removed,key
    # Only empty navigation/rubric scaffolding may disappear as cells.
    assert not canonical(source(old)),key
    continue
   now=next(c for c in current[m['to_path']]['cells'] if c['id']==m['to_id'])
   retained+=1
   if old['cell_type']=='code':
    assert {k:v for k,v in old.items() if k!='id'}=={k:v for k,v in now.items() if k!='id'},key
    code+=1
   elif source(old)!=source(now):
    edits.append({**m,'before':source(old),'after':source(now)})
    if re.search(r'/\d\d00_',p) or '/front_matter/' in p:continue
    fragments=[canonical(s) for s in re.split(r'\n\s*\n',source(old)) if canonical(s)]
    for f in fragments:
     if f not in blob:missing.append({'path':p,'cell':old['id'],'fragment':f[:250]})
 # Narrative wording updates are explicitly reviewed; the complete exact source diff is retained.
 wording={
  'The following examples were moved from iteration worked examples to keep formatting topics centralized in Input/Output.',
  'The following examples were moved from `0503-for-examples` to keep all `for` step patterns in one section.',
  'This short section was consolidated from the previous standalone `foreach` page.',
  'The following examples were consolidated from `0602-while-examples`.',
  'The following content was consolidated from `0603-do-while`.',
  'Breadth-first search, predecessor paths, depth-first search, and connected components are taught in {doc}`Chapter 20 <../20_graphs/2003_graph_traversal>`. This optional section extends their use to verification and algorithm design.'}
 missing=[m for m in missing if not any(canonical(s).startswith(m['fragment']) for s in wording)]
 (OUT/'source_changes.json').write_text(json.dumps(edits,ensure_ascii=False,indent=2)+'\n')
 toc=yaml.safe_load((ROOT/'_toc.yml').read_text());paths=[]
 def walk(n):
  if 'file' in n:paths.append(n['file']+'.ipynb')
  for ch in n.get('sections',[]):walk(ch)
 for part in toc['parts']:
  for ch in part['chapters']:walk(ch)
 seams=[];readings=0
 for p in paths:
  if not re.match(r'chapters/\d\d_',p) or '/assignments/' in p or re.search(r'/\d\d00_',p):continue
  readings+=1;n=current[p];text='\n'.join(source(c) for c in n['cells']);heads=re.findall(r'^## (.+)',text,re.M)
  if text.count('```{contents}')!=1:seams.append((p,'contents count'))
  if len(heads)!=len(set(heads)):seams.append((p,'duplicate headings'))
  rub=[i for i,c in enumerate(n['cells']) if re.fullmatch(r'\s*```\{rubric\} Footnotes\s*\n```\s*',source(c))]
  if len(rub)!=1:seams.append((p,'rubric count'))
  elif any(c['cell_type']=='code' or not re.match(r'^\s*\[\^',source(c)) for c in n['cells'][rub[0]+1:]):seams.append((p,'body after Footnotes'))
 hashes=json.loads((ROOT/'authoring/priority_development/assignment_hashes.json').read_text())
 for p,h in hashes.items():assert hashlib.sha256((ROOT/p).read_bytes()).hexdigest()==h,p
 report={'active_content_readings':readings,'original_cells_accounted_for':retained+len(removed),'retained_original_cells':retained,'consolidated_structure_cells':len(removed),'original_code_cells_unchanged':code,'assignment_notebooks_unchanged':len(hashes),'exact_source_edits_recorded':len(edits),'missing_explanation_fragments':missing,'remaining_mechanical_seams':seams}
 (OUT/'preservation_check.json').write_text(json.dumps(report,indent=2)+'\n');print(json.dumps(report,indent=2));assert not missing and not seams
if __name__=='__main__':main()
