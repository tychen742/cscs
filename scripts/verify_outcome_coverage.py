#!/usr/bin/env python3
"""Validate outcome-map references and ensure the audit changed no book sources."""
import hashlib
import json
import re
from collections import Counter
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
OUT = ROOT / 'authoring/outcome_coverage_audit'
rows = json.loads((OUT / 'mapping.json').read_text())
supplemental = json.loads((OUT / 'supplemental_mapping.json').read_text())
findings = json.loads((OUT / 'findings.json').read_text())
inventory = json.loads((OUT / 'source_inventory.json').read_text())
baseline = json.loads((OUT / 'preservation.json').read_text())
cache = {}

def notebook(file):
    if file not in cache:
        cache[file] = json.loads((ROOT / file).read_text())
    return cache[file]

def check_reference(ref):
    cells = notebook(ref['file'])['cells']
    start, end = ref['cells']
    assert 1 <= start <= end <= len(cells), ref
    selected = cells[start - 1:end]
    assert [cell.get('id') for cell in selected] == ref['cell_ids'], ref
    source = '\n\n'.join(''.join(cell['source']) for cell in selected)
    assert source.startswith(ref['excerpt']), ref

assert len(inventory) == 20
assert {row['chapter'] for row in rows} == set(range(1, 21))
assert len({row['id'] for row in rows}) == len(rows) == 108
references = 0
for row in rows + supplemental:
    for stage in ['explanation', 'worked_example', 'section_practice', 'assessment']:
        for ref in row[stage]:
            check_reference(ref)
            references += 1
    if row in rows:
        assert all('/assignments/' not in ref['file'] for ref in row['section_practice']), row['id']
for finding in findings:
    for ref in finding['evidence']:
        check_reference(ref)
        references += 1
for chapter in inventory:
    assert len(chapter['planning_files']) == 2
    assert all((ROOT / file).is_file() for file in chapter['planning_files'])
    landing = chapter['notebooks'][0]['file']
    source = '\n\n'.join(''.join(cell['source']) for cell in notebook(landing)['cells'])
    objective_block = source.split('<h2>Learning Objectives</h2>')[1].split('<h2>Chapter Flow</h2>')[0]
    objectives = re.findall(r'^\d+\. (.+)', objective_block, re.M)
    assert [row['outcome'] for row in rows if row['chapter'] == chapter['chapter']] == objectives
for file, digest in baseline.items():
    assert hashlib.sha256((ROOT / file).read_bytes()).hexdigest() == digest, file
result = {
    'core_chapters': len(inventory),
    'planning_documents': sum(len(chapter['planning_files']) for chapter in inventory),
    'toc_linked_notebooks': sum(len(chapter['notebooks']) for chapter in inventory),
    'core_outcomes': len(rows),
    'additional_topic_tracks': len(supplemental),
    'source_references_verified': references,
    'alignment_statuses': dict(Counter(row['status'] for row in rows)),
    'unchanged_source_and_planning_files': len(baseline),
    'findings': len(findings),
    'scope_limit': 'Source alignment audit; not execution, grading, or learner-attainment certification.'
}
(OUT / 'verification.json').write_text(json.dumps(result, indent=2) + '\n')
print(json.dumps(result, indent=2))
