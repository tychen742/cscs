#!/usr/bin/env python3
"""Rename a notebook cell tag across the book's chapters.

Rewrites ``metadata.tags`` of every cell in ``chapters/**/*.ipynb`` so that
OLD becomes NEW. Cell ids, order, sources, outputs, and every other field are
left untouched. Files are written with the same JSON formatting the book uses
(indent=1, ensure_ascii=False, trailing newline), so a notebook with no
matching cells is byte-identical before and after.

Usage (from the repository root):

    python3 scripts/rename_cell_tag.py thebe-interactive exercise
    python3 scripts/rename_cell_tag.py --dry-run OLD NEW
"""

from __future__ import annotations

import argparse
import json
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
CHAPTERS = ROOT / "chapters"


def rename_tags(nb: dict, old: str, new: str) -> int:
    """Replace OLD with NEW in each cell's tag list; return cells changed."""
    changed = 0
    for cell in nb.get("cells", []):
        tags = cell.get("metadata", {}).get("tags")
        if not tags or old not in tags:
            continue
        cell["metadata"]["tags"] = [new if t == old else t for t in tags]
        changed += 1
    return changed


def main(argv: list[str] | None = None) -> int:
    parser = argparse.ArgumentParser(description=__doc__.splitlines()[0])
    parser.add_argument("old", help="tag to rename")
    parser.add_argument("new", help="replacement tag")
    parser.add_argument(
        "--dry-run", action="store_true", help="report counts without writing"
    )
    args = parser.parse_args(argv)

    files_changed = 0
    cells_changed = 0
    for path in sorted(CHAPTERS.rglob("*.ipynb")):
        if ".ipynb_checkpoints" in path.parts:
            continue
        raw = path.read_text(encoding="utf-8")
        nb = json.loads(raw)
        n = rename_tags(nb, args.old, args.new)
        if n == 0:
            continue
        files_changed += 1
        cells_changed += n
        if not args.dry_run:
            out = json.dumps(nb, indent=1, ensure_ascii=False) + "\n"
            path.write_text(out, encoding="utf-8")
        print(f"{n:3d}  {path.relative_to(ROOT)}")

    verb = "would change" if args.dry_run else "changed"
    print(f"{verb} {cells_changed} cells in {files_changed} notebooks")
    return 0


if __name__ == "__main__":
    sys.exit(main())
