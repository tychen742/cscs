#!/usr/bin/env python3
"""Convert REPL-style code blocks in markdown cells to executable code cells.

Finds fenced code blocks with > prompt lines in markdown cells and converts
them to executable code cells. Also handles bare blockquote REPL cells.

Usage:
    python3 bin/convert_repl.py --dry-run     # Preview changes
    python3 bin/convert_repl.py               # Apply changes
"""
import json, re, glob, sys, uuid, os

DRY_RUN = '--dry-run' in sys.argv

def cell_id():
    return uuid.uuid4().hex[:8]

def make_code_cell(lines):
    src = []
    for j, l in enumerate(lines):
        src.append(l + '\n' if j < len(lines) - 1 else l)
    return {
        "cell_type": "code",
        "execution_count": None,
        "id": cell_id(),
        "metadata": {"vscode": {"languageId": "csharp"}},
        "outputs": [],
        "source": src
    }

def make_md_cell(lines):
    src = []
    for j, l in enumerate(lines):
        src.append(l + '\n' if j < len(lines) - 1 else l)
    return {
        "cell_type": "markdown",
        "id": cell_id(),
        "metadata": {},
        "source": src
    }

def extract_code(block_lines):
    """Extract code from REPL block lines. Returns list of code strings."""
    code = []
    brace_depth = 0

    for line in block_lines:
        if line.startswith('> '):
            c = line[2:]
            code.append(c)
            brace_depth += c.count('{') - c.count('}')
        elif line.strip() == '>' or line == '>':
            continue  # empty prompt
        elif brace_depth > 0:
            # inside multi-line braced block
            code.append(line)
            brace_depth += line.count('{') - line.count('}')
        elif _looks_like_code(line) and not _looks_like_output(line):
            # continuation line
            code.append(line)
            brace_depth += line.count('{') - line.count('}')
        else:
            # output line, skip
            pass

    # trim trailing blanks
    while code and code[-1].strip() == '':
        code.pop()
    return code

_CODE_KEYWORDS = [
    'for ', 'for(', 'while ', 'while(', 'if ', 'if(',
    'foreach ', 'foreach(', 'else', 'return ', 'var ',
    'int ', 'string ', 'double ', 'bool ', 'char ', 'float ',
    'Console.', 'new ', 'using ', 'class ', 'public ', 'private ',
    'static ', 'void ', 'switch', 'case ', 'break;', 'try', 'catch',
]

def _looks_like_code(line):
    s = line.strip()
    if not s:
        return False
    if s in ('{', '}', '};', '{;'):
        return True
    if s.endswith(';'):
        return True
    for kw in _CODE_KEYWORDS:
        if s.startswith(kw):
            return True
    if '{' in s or '}' in s:
        return True
    return False

def _looks_like_output(line):
    s = line.strip()
    if not s:
        return True
    # box-drawing chars
    if any(c in s for c in '┌┐└┘│─├┤┼'):
        return True
    # just a number
    if re.match(r'^-?\d+(\.\d+)?$', s):
        return True
    # boolean
    if s in ('true', 'false'):
        return True
    # REPL type display like List<string>(3)
    if re.match(r'^[A-Z]\w+(<[^>]+>)?\(\d+\)$', s):
        return True
    # quoted string
    if s.startswith('"') and s.endswith('"'):
        return True
    # error display
    if 'Exception' in s or 'error CS' in s:
        return True
    return False

def is_repl_block(lang, lines):
    """Check if a fenced block is a REPL transcript worth converting."""
    # skip terminal/shell blocks and MyST directive blocks
    if lang in ('powershell', 'bash', 'shell', 'sh'):
        return False
    if lang.startswith('{'):
        return False  # MyST directive like {eval-rst}, {code-block}, {index}
    prompt_lines = [l for l in lines if l.startswith('> ')]
    if not prompt_lines:
        return False
    # skip if contains escaped blockquote markers
    all_text = '\n'.join(lines)
    if '\\>' in all_text:
        return False
    # skip if prompt lines contain markdown formatting (bold, italic)
    for l in prompt_lines:
        if re.search(r'\*\*\w|\*\w[^;]*\*', l):
            return False
    # skip if non-prompt lines contain markdown formatting
    non_prompt = [l for l in lines if not l.startswith('> ') and l.strip() and l.strip() != '>']
    for l in non_prompt:
        if re.search(r'\*\*\w|\*\w.*\*|`\w.*`', l):
            return False
    # skip if contains MyST directives
    if any(':::{' in l or '```{' in l for l in lines):
        return False
    # accept if any prompt line has code-like content
    for l in prompt_lines:
        if any(c in l for c in [';', '(', ')', '{', '}', '=', '.', '[', ']', '"']):
            return True
    # accept any non-empty prompt (variable inspection, expression eval)
    for l in prompt_lines:
        if l[2:].strip():
            return True
    return False

def split_md_cell(cell):
    """Split a markdown cell around fenced REPL blocks.
    Returns list of cells (markdown + code)."""
    source = ''.join(cell['source'])
    lines = source.split('\n')
    segments = []  # (type, lines)
    md_buf = []
    i = 0

    while i < len(lines):
        line = lines[i]
        stripped = line.strip()
        m = re.match(r'^(`{3,})(.*)$', stripped)
        if m:
            fence = m.group(1)
            lang = m.group(2).strip()
            block = []
            i += 1
            found_end = False
            while i < len(lines):
                if lines[i].strip() == fence:
                    found_end = True
                    break
                block.append(lines[i])
                i += 1

            if found_end and is_repl_block(lang, block):
                # save accumulated markdown
                while md_buf and md_buf[-1].strip() == '':
                    md_buf.pop()
                if md_buf:
                    segments.append(('md', list(md_buf)))
                md_buf = []
                # extract code
                code = extract_code(block)
                if code:
                    segments.append(('code', code))
                # skip trailing blanks after closing fence
                i += 1
                while i < len(lines) and lines[i].strip() == '':
                    i += 1
                continue
            else:
                # not REPL, keep as markdown
                md_buf.append(f'{fence}{lang}')
                md_buf.extend(block)
                if found_end:
                    md_buf.append(fence)
        else:
            md_buf.append(line)
        i += 1

    while md_buf and md_buf[-1].strip() == '':
        md_buf.pop()
    if md_buf:
        segments.append(('md', list(md_buf)))

    if len(segments) <= 1 and (not segments or segments[0][0] == 'md'):
        return None  # no changes

    result = []
    for stype, slines in segments:
        if stype == 'code':
            result.append(make_code_cell(slines))
        else:
            result.append(make_md_cell(slines))
    return result

def is_bare_repl_cell(cell):
    """Check if a markdown cell is entirely bare REPL content (blockquoted)."""
    src = ''.join(cell['source']).strip()
    lines = src.split('\n')
    if not lines:
        return False
    # Cell should start with > prompt (purely REPL content)
    if not lines[0].startswith('> '):
        return False
    # skip if cell contains MyST directives or fenced blocks
    if any('```{' in l or ':::{' in l or l.strip().startswith('```') for l in lines):
        return False
    # count lines starting with > that have any non-empty content
    prompt_count = sum(1 for l in lines if l.startswith('> ') and l[2:].strip())
    non_empty = [l for l in lines if l.strip()]
    if not non_empty or prompt_count < 2:
        return False
    ratio = prompt_count / len(non_empty)
    # check there's no regular prose (long text lines that aren't code/tables)
    has_prose = any(len(l) > 60 and not l.startswith('> ') and
                    not l.startswith('  ') and
                    not any(c in l for c in '\u250c\u2510\u2514\u2518\u2502\u2500\u251c\u2524\u253c')
                    for l in lines)
    return ratio >= 0.1 and not has_prose

def convert_bare_repl(cell):
    """Convert a bare blockquote REPL cell to a code cell."""
    src = ''.join(cell['source']).strip()
    lines = src.split('\n')
    code = extract_code(lines)
    if code:
        return make_code_cell(code)
    return None

def process_notebook(filepath):
    with open(filepath) as f:
        nb = json.load(f)

    new_cells = []
    total_converted = 0
    details = []

    for ci, cell in enumerate(nb['cells']):
        if cell['cell_type'] != 'markdown':
            new_cells.append(cell)
            continue

        src = ''.join(cell['source'])

        # Check for fenced REPL blocks
        has_fenced_repl = False
        for m in re.finditer(r'(`{3,})(\w*)\n', src):
            fence = m.group(1)
            lang = m.group(2)
            start = m.end()
            end_m = re.search(re.escape(fence) + r'\s*$', src[start:], re.MULTILINE)
            if end_m:
                block_text = src[start:start + end_m.start()]
                block_lines = block_text.split('\n')
                if is_repl_block(lang, block_lines):
                    has_fenced_repl = True
                    break

        if has_fenced_repl:
            result = split_md_cell(cell)
            if result:
                new_cells.extend(result)
                code_count = sum(1 for c in result if c['cell_type'] == 'code')
                total_converted += code_count
                for c in result:
                    if c['cell_type'] == 'code':
                        preview = ''.join(c['source'])[:80].replace('\n', ' | ')
                        details.append(f'    cell {ci} -> code: {preview}')
                continue

        # Check for bare blockquote REPL
        if is_bare_repl_cell(cell):
            result = convert_bare_repl(cell)
            if result:
                new_cells.append(result)
                total_converted += 1
                preview = ''.join(result['source'])[:80].replace('\n', ' | ')
                details.append(f'    cell {ci} -> code (bare): {preview}')
                continue

        new_cells.append(cell)

    if total_converted > 0:
        print(f'  {filepath}: {total_converted} REPL blocks -> code cells')
        for d in details:
            print(d)
        if not DRY_RUN:
            nb['cells'] = new_cells
            with open(filepath, 'w') as f:
                json.dump(nb, f, indent=1, ensure_ascii=False)
                f.write('\n')

    return total_converted

# Main
total = 0
for f in sorted(glob.glob('chapters/**/*.ipynb', recursive=True)):
    if '.ipynb_checkpoints' in f or '_build' in f:
        continue
    total += process_notebook(f)

mode = "DRY RUN" if DRY_RUN else "APPLIED"
print(f'\n{mode}: {total} total REPL blocks converted')
