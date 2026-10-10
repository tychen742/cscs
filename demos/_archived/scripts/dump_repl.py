#!/usr/bin/env python3
"""Dump full REPL blocks with surrounding context to understand patterns."""
import json, re, glob

files_to_check = [
    ('chapters/01_context/0102_dev_tools.ipynb', [1]),
    ('chapters/02_var_data/0203_operators.ipynb', [1]),
    ('chapters/02_var_data/0204-arithmetic.ipynb', [1]),
    ('chapters/02_var_data/0206_input_output.ipynb', [12]),
    ('chapters/04_decision/0405-compound_boolean.ipynb', [3]),
    ('chapters/05-for/0501-intro.ipynb', [5, 7]),
    ('chapters/05-for/0502_for_statements.ipynb', [1]),
    ('chapters/05-for/0503-for-examples.ipynb', [1, 5, 15, 20]),
    ('chapters/07-files/0703-file-read.ipynb', [7]),
    ('chapters/07-files/0705-lab-file.ipynb', [3]),
    ('chapters/08_arrays/0801_onedim.ipynb', [1]),
    ('chapters/08_arrays/0802_twodim.ipynb', [0]),
    ('chapters/09_collections/0904-lab-collections.ipynb', [1]),
    ('chapters/10-datastructure/1002-collection-examples.ipynb', [17, 19, 21, 29, 30]),
    ('chapters/13_oop/1206-review-oop.ipynb', [0]),
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
