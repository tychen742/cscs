#!/usr/bin/env python3
"""Check preservation and new execution evidence for the outcome gap revision."""
import json,hashlib,re
from pathlib import Path
ROOT=Path(__file__).resolve().parents[1]
D=ROOT/'authoring/outcome_gap_revision'
def text(c):return ''.join(c.get('source',[]))
def main():
 before=json.loads((D/'before.json').read_text())
 current={str(p.relative_to(ROOT)):json.loads(p.read_text()) for p in (ROOT/'chapters').glob('**/*.ipynb')}
 global_cells={}
 for file,n in current.items():
  ids=[c.get('id') for c in n['cells']]
  old_ids=[c.get('id') for c in before.get(file,{}).get('cells',[])]
  assert len(ids)-len(set(ids)) <= len(old_ids)-len(set(old_ids)),f'New duplicate cell IDs: {file}'
  for c in n['cells']:global_cells.setdefault(c.get('id'),[]).append((file,c))
 missing=[];changed=[];moved=[];same=0
 for file,n in before.items():
  if [text(c) for c in n['cells']] == [text(c) for c in current[file]['cells']]:
   same += len(n['cells']); continue
  byid={c.get('id'):c for c in current[file]['cells']}
  for c in n['cells']:
   ident=c.get('id')
   if ident in byid:
    if text(c)==text(byid[ident]):same+=1
    else:changed.append({'file':file,'cell_id':ident})
   elif ident in global_cells:moved.append({'from':file,'cell_id':ident,'to':global_cells[ident][0][0]})
   else:missing.append({'file':file,'cell_id':ident,'source':text(c)})
 # One binary-search cell is moved intact. Its chapter-14 slot receives a new question.
 assert not missing,missing
 def exercise_ids(notebooks):
  return {c['metadata']['exercise_id'] for n in notebooks.values() for c in n['cells'] if 'exercise_id' in c.get('metadata',{})}
 assert not (exercise_ids(before)-exercise_ids(current)), 'Lost exercise identifiers'
 results=json.loads((D/'code_results.json').read_text());cases=json.loads((D/'code_cases.json').read_text())
 assert len(results)==len(cases)
 for r in results:
  assert r['exit_code']==0,r
  c=next(c for c in current[r['file']]['cells'] if c.get('id')==r['cell_id'])
  assert ''.join(c['outputs'][0]['text'])==r['stdout'],r['cell_id']
  if 'source_sha256' in r:assert hashlib.sha256(text(c).encode()).hexdigest()==r['source_sha256']
 suite=json.loads((D/'mstest_results.json').read_text())
 assert suite[0]['exit_code']!=0 and 'Test_MultiplyMethod' in suite[0]['stdout']+suite[0]['stderr']
 assert suite[1]['exit_code']==0,suite
 report={'unchanged_original_cells':same,'modified_original_cells':changed,'relocated_original_cells':moved,'missing_original_cells':missing,'original_exercise_ids_preserved':len(exercise_ids(before)),'verified_code_cells':len(results),'mstest_expected_failure_and_repair':True}
 (D/'preservation_results.json').write_text(json.dumps(report,indent=2))
 print(json.dumps(report,indent=2))
if __name__=='__main__':main()
