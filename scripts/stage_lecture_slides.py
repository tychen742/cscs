#!/usr/bin/env python3
"""Stage student slide assets without publishing instructor sources or answers."""
import argparse
import shutil
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
PUBLIC_SUFFIXES = {'.html', '.svg', '.png', '.jpg', '.jpeg', '.gif', '.webp', '.css', '.js', '.woff', '.woff2'}

def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--html-dir', type=Path, default=ROOT / '_build/html')
    args = parser.parse_args()
    source = ROOT / '_html_extra/chapters'
    destination = args.html_dir / 'chapters'
    copied = 0
    for path in source.rglob('*'):
        if not path.is_file():
            continue
        target = destination / path.relative_to(source)
        if path.suffix.lower() not in PUBLIC_SUFFIXES:
            # Remove copies left by the former recursive-copy deployment step.
            if target.is_file():
                target.unlink()
            continue
        target.parent.mkdir(parents=True, exist_ok=True)
        shutil.copy2(path, target)
        copied += 1
    print(f'Staged {copied} student slide assets; Markdown and PowerPoint sources excluded.')

if __name__ == '__main__':
    main()
