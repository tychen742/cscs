"""
fix_headings.py
---------------
For every notebook under chapters/:
  1. Split markdown cells so each ## or ### heading gets its own cell.
  2. Keep any immediately-preceding (anchor)= lines and ```{index}...``` blocks
     together with the heading they belong to.
  3. Reduce 2+ blank lines after a ## / ### heading to exactly one blank line.
"""

import json, re, glob, uuid, copy

HEADING_RE    = re.compile(r'^#{2,3}(?:[^#]|$)')
ANCHOR_RE     = re.compile(r'^\([^)]+\)=$')
INDEX_OPEN_RE = re.compile(r'^```\{index\}')
INDEX_CLOSE   = '```'


# ---------------------------------------------------------------------------
# helpers
# ---------------------------------------------------------------------------

def _skip_blanks_back(lines, j):
    """Return the index of the first non-blank line walking back from j."""
    while j >= 0 and lines[j].strip() == '':
        j -= 1
    return j


def find_heading_block_start(lines, hi):
    """
    Walk backwards from heading line `hi` to claim any immediately-preceding
    anchor  (xxx)=  or  ```{index}...```  block (and both together).

    Pattern handled (top-to-bottom before heading):
      (a)  (anchor)=  [blanks]  ## Heading
      (b)  ```{index} term\n```  [blanks]  ## Heading
      (c)  ```{index} term\n```  [blanks]  (anchor)=  [blanks]  ## Heading
      (d)  (anchor)=  [blanks]  ```{index} term\n```  [blanks]  ## Heading  (unusual)

    Note: {index} blocks are always exactly 2 lines:
          ```{index} term
          ```
    We do NOT scan arbitrarily far back to avoid crossing heading boundaries.
    """
    start = hi

    # --- step 1: look at what's immediately before heading (skip blanks) ---
    j = _skip_blanks_back(lines, hi - 1)
    if j < 0:
        return start

    # ---- case (a) / (c) / (d): anchor immediately before heading ----
    if ANCHOR_RE.match(lines[j].strip()):
        start = j
        # look one step further back for an index block before anchor
        k = _skip_blanks_back(lines, j - 1)
        if k >= 0 and lines[k].strip() == INDEX_CLOSE:
            # {index} block is exactly 2 lines: opening must be at k-1
            m = k - 1
            if m >= 0 and INDEX_OPEN_RE.match(lines[m].strip()):
                start = m
        return start

    # ---- case (b) / (c): index closing ``` immediately before heading ----
    if lines[j].strip() == INDEX_CLOSE:
        # {index} block is exactly 2 lines: opening must be at j-1
        k = j - 1
        if k >= 0 and INDEX_OPEN_RE.match(lines[k].strip()):
            start = k
            # look further back for anchor before index block
            m = _skip_blanks_back(lines, k - 1)
            if m >= 0 and ANCHOR_RE.match(lines[m].strip()):
                start = m
        return start

    return start


def get_heading_positions(lines):
    """
    Return line indices of ## / ### headings, ignoring lines inside code fences.
    """
    in_fence = False
    result = []
    for i, line in enumerate(lines):
        stripped = line.strip()
        if in_fence:
            if stripped == '```' or stripped == '~~~':
                in_fence = False
        else:
            if stripped.startswith('```') or stripped.startswith('~~~'):
                in_fence = True
            elif HEADING_RE.match(line):
                result.append(i)
    return result


def fix_blank_after_heading(src):
    """Collapse 2+ blank lines after ## / ### to exactly one blank line."""
    return re.sub(r'(^#{2,3}[^\n]*\n)\n{2,}', r'\1\n', src, flags=re.MULTILINE)


def make_md_cell(source, template):
    return {
        "cell_type": "markdown",
        "id": uuid.uuid4().hex[:8],
        "metadata": copy.deepcopy(template.get("metadata", {})),
        "source": source,
    }


# ---------------------------------------------------------------------------
# main splitting logic
# ---------------------------------------------------------------------------

def process_cell(cell):
    """
    Return a list of replacement cells, or None if the cell is unchanged.
    """
    if cell['cell_type'] != 'markdown':
        return None

    src = ''.join(cell['source']) if isinstance(cell['source'], list) else cell['source']
    lines = src.split('\n')

    heading_idxs = get_heading_positions(lines)

    if not heading_idxs:
        return None  # no ## / ### headings

    chunk_starts = [find_heading_block_start(lines, hi) for hi in heading_idxs]
    first_cs = chunk_starts[0]
    needs_split = (len(heading_idxs) > 1) or (first_cs > 0)

    if not needs_split:
        # Single heading already at top of cell – only fix blank lines
        fixed = fix_blank_after_heading(src)
        if fixed == src:
            return None
        return [make_md_cell(fixed, cell)]

    # --- build chunks ---
    n = len(lines)
    chunks = []

    # Preamble before the first heading block
    if first_cs > 0:
        preamble = '\n'.join(lines[:first_cs]).rstrip('\n')
        if preamble.strip():
            chunks.append(preamble)

    # One chunk per heading
    for i, cs in enumerate(chunk_starts):
        end = chunk_starts[i + 1] if i + 1 < len(chunk_starts) else n
        chunk = '\n'.join(lines[cs:end]).rstrip('\n')
        if chunk.strip():
            chunks.append(fix_blank_after_heading(chunk))

    if not chunks:
        return None

    # If nothing actually changed (shouldn't happen, but guard)
    if len(chunks) == 1 and chunks[0] == src:
        return None

    return [make_md_cell(c, cell) for c in chunks]


# ---------------------------------------------------------------------------
# notebook processing
# ---------------------------------------------------------------------------

def process_notebook(path):
    with open(path, encoding='utf-8') as f:
        nb = json.load(f)

    new_cells = []
    modified = False

    for cell in nb['cells']:
        result = process_cell(cell)
        if result is None:
            new_cells.append(cell)
        else:
            new_cells.extend(result)
            modified = True

    if modified:
        nb['cells'] = new_cells
        with open(path, 'w', encoding='utf-8') as f:
            json.dump(nb, f, indent=1, ensure_ascii=False)
        print(f"  modified: {path}")

    return modified


# ---------------------------------------------------------------------------
# entry point
# ---------------------------------------------------------------------------

if __name__ == '__main__':
    import os
    os.chdir(os.path.dirname(os.path.abspath(__file__)))

    count = 0
    for path in sorted(glob.glob('chapters/**/*.ipynb', recursive=True)):
        if process_notebook(path):
            count += 1

    print(f"\nDone. {count} notebook(s) modified.")
