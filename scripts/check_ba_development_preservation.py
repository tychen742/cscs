#!/usr/bin/env python3
"""Check the B-A revision against its starting cells, documented edits and TOC."""
import hashlib
import json
import re
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
OUT = ROOT / 'authoring/ba_development_revision'

def main():
    baseline = json.loads((OUT / 'baseline.json').read_text())
    corrections = {(x['file'], x['cell_id']): x for x in json.loads((OUT / 'corrections.json').read_text())}
    metadata = {(x['file'], x['cell_id']): x for x in json.loads((OUT / 'metadata_changes.json').read_text())}
    retained = code = outputs = added = 0
    for filename, original in baseline.items():
        current = json.loads((ROOT / filename).read_text())
        by_id = {c['id']: c for c in current['cells']}
        assert len(by_id) == len(current['cells']), ('Duplicate cell ID', filename)
        added += len(current['cells']) - len(original['cells'])
        old_ids = [c['id'] for c in original['cells']]
        assert [c['id'] for c in current['cells'] if c['id'] in old_ids] == old_ids, ('Original cell order changed', filename)
        for old in original['cells']:
            new = by_id[old['id']]
            key = filename, old['id']
            assert old['cell_type'] == new['cell_type']
            if old['source'] != new['source']:
                edit = corrections[key]
                assert ''.join(old['source']) == edit['before'] and ''.join(new['source']) == edit['after'], key
            if old['metadata'] != new['metadata']:
                edit = metadata[key]
                assert old['metadata'] == edit['before'] and new['metadata'] == edit['after'], key
            if old['cell_type'] == 'code':
                assert old.get('outputs', []) == new.get('outputs', []), key
                assert old.get('execution_count') == new.get('execution_count'), key
                code += 1
                outputs += len(old.get('outputs', []))
            retained += 1
        # Existing explicit labels/HTML anchors remain at their original source locations.
        for old in original['cells']:
            text = ''.join(old['source'])
            now = ''.join(by_id[old['id']]['source'])
            for anchor in re.findall(r'^\([^)]+\)=|<span id="[^"]+"', text, flags=re.M):
                assert anchor in now, (filename, anchor)
    hashes = json.loads((OUT / 'original_hashes.json').read_text())
    untouched = assignments = 0
    for filename, expected in hashes.items():
        if filename in baseline:
            continue
        assert hashlib.sha256((ROOT / filename).read_bytes()).hexdigest() == expected, filename
        untouched += 1
        assignments += '/assignments/' in filename
    plans = json.loads((OUT / 'planning_baseline.json').read_text())
    for filename, old in plans.items():
        text = (ROOT / filename).read_text()
        assert 'B-A Development Follow-up (2026-10-18)' in text
        if old:
            # Historical plan sections are retained; additions sit below the existing H1.
            old_heading = next(line for line in old.splitlines() if line.startswith('# '))
            tail = old.split(old_heading, 1)[1].lstrip()
            assert text.rstrip().endswith(tail.rstrip()), filename
    result = dict(original_cells_retained_in_order=retained, original_code_cells_retained=code,
                  original_output_records_unchanged=outputs, added_cells=added,
                  documented_source_corrections=len(corrections), exercise_metadata_repairs=len(metadata),
                  unchanged_other_notebooks_and_toc=untouched, unchanged_assignment_notebooks=assignments,
                  planning_files_updated=len(plans))
    (OUT / 'preservation_check.json').write_text(json.dumps(result, indent=2) + '\n')
    print(json.dumps(result, indent=2))

if __name__ == '__main__':
    main()
