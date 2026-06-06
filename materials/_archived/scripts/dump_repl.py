#!/usr/bin/env python3
"""Dump full REPL blocks with surrounding context to understand patterns."""
import json, re, glob

files_to_check = [
    ('chapters/01-context/0102-dev_tools.ipynb', [1]),
    ('chapters/02-var_data/0203-operators.ipynb', [1]),
    ('chapters/02-var_data/0204-arithmetic.ipynb', [1]),
    ('chapters/02-var_data/0206-input_output.ipynb', [12]),
    ('chapters/04-decision/0405-compound_boolean.ipynb', [3]),
    ('chapters/05-for/0501-intro.ipynb', [5, 7]),
    ('chapters/05-for/0502-for-statements.ipynb', [1]),
    ('chapters/05-for/0503-for-examples.ipynb', [1, 5, 15, 20]),
    ('chapters/07-files/0703-file-read.ipynb', [7]),
    ('chapters/07-files/0705-lab-file.ipynb', [3]),
    ('chapters/08-arrays/0801-onedim.ipynb', [1]),
    ('chapters/08-arrays/0802-twodim.ipynb', [0]),
    ('chapters/09-collections/0904-lab-collections.ipynb', [1]),
    ('chapters/10-datastructure/1002-collection-examples.ipynb', [17, 19, 21, 29, 30]),
    ('chapters/12-oop/1206-review-oop.ipynb', [0]),
]

for fname, cells in files_to_check:
    with open(fname) as fh:
        nb = json.load(fh)
    print(f'\n{"="*80}')
    print(f'FILE: {fname}')
    for ci in cells:
        cell = nb['cells'][ci]
        src = ''.join(cell['source'])
        print(f'\n--- Cell {ci} (type={cell["cell_type"]}) ---')
        for i, line in enumerate(src.split('\n')):
            print(f'  {i:3d}: {line}')
        print('--- END ---')
