"""Reconstruct the prior audit view only after checking exact integration lineage.

Older audit baselines intentionally describe the earlier section arrangement.
This helper checks current cells against the integration ledger and restores
that earlier arrangement in memory so those historical checks remain usable.
The current integration audit separately checks current content and rendering.
"""
import copy,json
from pathlib import Path

def preintegration_view(root, current):
    folder=Path(root)/'authoring/integration_cleanup'
    if not (folder/'baseline.json').exists():return current
    baseline=json.loads((folder/'baseline.json').read_text())
    moves={(m['from_path'],m['from_id']):m for m in json.loads((folder/'cell_moves.json').read_text())}
    edits={(m['from_path'],m['from_id']):m for m in json.loads((folder/'source_changes.json').read_text())}
    removed={tuple(m['origin']):m for m in json.loads((folder/'removed_structure.json').read_text()) if m['origin']}
    result=copy.deepcopy(current)
    for path,old in baseline.items():
        restored=[]
        for cell in old['cells']:
            key=(path,cell['id']);move=moves.get(key)
            if not move:
                assert key in removed,key
                # Removed cells must be navigation/rubric scaffolding, not lessons.
                from verify_integration_cleanup import canonical
                assert not canonical(''.join(cell['source'])),key
                restored.append(copy.deepcopy(cell));continue
            actual=next(c for c in current[move['to_path']]['cells'] if c['id']==move['to_id'])
            changed=copy.deepcopy(actual)
            changed['id']=cell['id']
            if ''.join(cell['source'])!=''.join(actual['source']):
                edit=edits[key]
                assert edit['before']==''.join(cell['source']) and edit['after']==''.join(actual['source']),key
            if cell['cell_type']=='code':assert changed==cell,key
            else:
                assert {k:v for k,v in changed.items() if k!='source'}=={k:v for k,v in cell.items() if k!='source'},key
                changed['source']=copy.deepcopy(cell['source'])
            restored.append(changed)
        result[path]={**copy.deepcopy(old),'cells':restored}
    return result
