#!/usr/bin/env python3
"""Find all REPL-style fenced code blocks with > prompts in markdown cells.
Also find blockquoted code blocks (> ```{code-block} ...) that contain code.
"""
import json, re, glob

def find_repl_blocks(src):
    """Find fenced code blocks that contain > prompt lines."""
    blocks = []
    lines = src.split('\n')
    i = 0
    while i < len(lines):
        line = lines[i]
        stripped = line.strip()
        # Check for fenced code block start
        m = re.match(r'^(`{3,})(\w*)$', stripped)
        if m:
            fence = m.group(1)
            lang = m.group(2)
            block_lines = []
            i += 1
            while i < len(lines):
                if lines[i].strip() == fence:
                    break
                block_lines.append(lines[i])
                i += 1
            # Check if any line starts with > (REPL prompt)
            has_prompt = any(bl.startswith('> ') or bl == '>' for bl in block_lines)
            if has_prompt:
                blocks.append(('fenced', lang, block_lines))
        # Check for blockquoted code-block directives
        elif stripped.startswith('> ```{code-block}') or stripped.startswith('> ```{code-cell}'):
            lang_m = re.search(r'code-block\}\s*(\w+)', stripped) or re.search(r'code-cell\}\s*(\w+)', stripped)
            lang = lang_m.group(1) if lang_m else ''
            block_lines = []
            i += 1
            while i < len(lines):
                stripped2 = lines[i].strip()
                if stripped2 == '> ```' or stripped2 == '>```':
                    break
                # strip leading > 
                bl = lines[i]
                if bl.startswith('> '):
                    bl = bl[2:]
                elif bl.startswith('>'):
                    bl = bl[1:]
                block_lines.append(bl)
                i += 1
            blocks.append(('blockquoted', lang, block_lines))
        # Check for blockquoted code inside > markers (multi-line code in blockquotes)
        elif stripped.startswith('> ') and not stripped.startswith('> -') and not stripped.startswith('> *') and not stripped.startswith('> :::{'):
            # Could be inline blockquoted code - check if multiple consecutive > lines with code
            pass
        i += 1
    return blocks

total = 0
by_file = {}
for f in sorted(glob.glob('chapters/**/*.ipynb', recursive=True)):
    if '.ipynb_checkpoints' in f or '_build' in f:
        continue
    with open(f) as fh:
        nb = json.load(fh)
    file_blocks = []
    for i, cell in enumerate(nb['cells']):
        if cell['cell_type'] != 'markdown':
            continue
        src = ''.join(cell['source'])
        blocks = find_repl_blocks(src)
        for btype, lang, blines in blocks:
            file_blocks.append((i, btype, lang, blines))
    if file_blocks:
        by_file[f] = file_blocks
        total += len(file_blocks)

for fname in sorted(by_file):
    print(f'\n{fname}: {len(by_file[fname])} blocks')
    for cell_idx, btype, lang, blines in by_file[fname]:
        code_lines = [l for l in blines if l.startswith('> ') or l == '>']
        preview = code_lines[0][:80] if code_lines else blines[0][:80] if blines else '(empty)'
        print(f'  cell {cell_idx} [{btype}/{lang}] ({len(blines)} lines): {preview}')

print(f'\nTotal: {total} REPL/blockquoted code blocks')
