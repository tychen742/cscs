#!/usr/bin/env python3
"""Scan all notebooks for REPL-style code blocks with > prompts."""
import json, re, glob, os

results = {}
for f in sorted(glob.glob('chapters/**/*.ipynb', recursive=True)):
    if '.ipynb_checkpoints' in f or '_build' in f:
        continue
    with open(f) as fh:
        nb = json.load(fh)
    for i, cell in enumerate(nb['cells']):
        if cell['cell_type'] != 'markdown':
            continue
        src = ''.join(cell['source'])
        lines = src.split('\n')
        for j, line in enumerate(lines):
            stripped = line.strip()
            keywords = [';', '(', ')', '{', '}', '=', 'Console', 'string ',
                        'int ', 'double ', 'bool ', 'var ', 'List<',
                        'Dictionary<', 'new ', '.Add', '.Count', '.Remove',
                        'class ', 'public ', 'private ', 'static ', 'void ',
                        'foreach', 'using ', 'char ', 'float ']
            if stripped.startswith('> ') and any(kw in stripped for kw in keywords):
                key = f'{f}:cell{i}'
                if key not in results:
                    results[key] = []
                results[key].append((j, line.rstrip()))
                break

print(f'Found {len(results)} cells with REPL-like > code across files:\n')
by_file = {}
for key in results:
    fname = key.split(':')[0]
    if fname not in by_file:
        by_file[fname] = []
    by_file[fname].append(key)

for fname in sorted(by_file):
    print(f'  {fname}: {len(by_file[fname])} cells')
    for key in by_file[fname]:
        cell_idx = key.split(':cell')[1]
        sample = results[key][0][1][:100]
        print(f'    cell {cell_idx}: {sample}')
print(f'\nTotal: {len(results)} cells')
