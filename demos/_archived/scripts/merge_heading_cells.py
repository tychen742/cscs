#!/usr/bin/env python3
"""Merge heading-only markdown cells with the following markdown cell.

Scans all .ipynb files under chapters/ for markdown cells whose content
is only a heading (##, ###, or ####) optionally surrounded by blank lines.
If the next cell is also a markdown cell, the heading is prepended to it
and the heading-only cell is removed.

Does NOT touch # (h1) headings — only ## and below.
"""

import json
import re
import sys
from pathlib import Path

HEADING_ONLY_RE = re.compile(
    r"^\s*(#{2,4}\s+.+?)\s*$",   # captures ## / ### / #### headings
    re.DOTALL,
)


def is_heading_only(source_lines: list[str]) -> str | None:
    """Return the heading line if the cell is heading-only, else None."""
    text = "".join(source_lines).strip()
    m = HEADING_ONLY_RE.match(text)
    return m.group(1) if m else None


def merge_headings(nb: dict) -> int:
    """Merge heading-only markdown cells into the next markdown cell. Returns merge count."""
    cells = nb.get("cells", [])
    merged = 0
    i = 0
    while i < len(cells) - 1:
        cell = cells[i]
        next_cell = cells[i + 1]

        if cell.get("cell_type") != "markdown":
            i += 1
            continue

        heading = is_heading_only(cell.get("source", []))
        if heading is None:
            i += 1
            continue

        if next_cell.get("cell_type") != "markdown":
            i += 1
            continue

        # Prepend heading to next cell
        next_source = next_cell.get("source", [])
        next_text = "".join(next_source)
        combined = heading + "\n\n" + next_text
        next_cell["source"] = combined.split("\n")
        # Re-add newlines (JSON notebook format stores lines with trailing \n except last)
        next_cell["source"] = [
            line + "\n" for line in next_cell["source"][:-1]
        ] + [next_cell["source"][-1]]

        # Remove the heading-only cell
        cells.pop(i)
        merged += 1
        # Don't increment i — check the merged cell again in case it's now a heading-only too

    return merged


def process_file(path: Path, dry_run: bool = False) -> int:
    with open(path, "r", encoding="utf-8") as f:
        nb = json.load(f)

    count = merge_headings(nb)
    if count > 0 and not dry_run:
        with open(path, "w", encoding="utf-8") as f:
            json.dump(nb, f, indent=1, ensure_ascii=False)
            f.write("\n")
    return count


def main():
    dry_run = "--dry-run" in sys.argv
    chapters_dir = Path(__file__).resolve().parent.parent / "chapters"
    notebooks = sorted(chapters_dir.rglob("*.ipynb"))
    # Skip checkpoint files
    notebooks = [p for p in notebooks if ".ipynb_checkpoints" not in str(p)]

    total_merges = 0
    for nb_path in notebooks:
        count = process_file(nb_path, dry_run=dry_run)
        if count > 0:
            rel = nb_path.relative_to(chapters_dir.parent)
            label = " (dry-run)" if dry_run else ""
            print(f"  {rel}: merged {count} heading cell(s){label}")
            total_merges += count

    print(f"\nTotal: {total_merges} merges across {len(notebooks)} notebooks")
    if dry_run:
        print("(dry-run mode — no files were modified)")


if __name__ == "__main__":
    main()
