#!/usr/bin/env python3
"""Build chapter lecture HTML and instructor PowerPoints from the same source."""
import argparse
from concurrent.futures import ThreadPoolExecutor
import json
import hashlib
from pathlib import Path
import subprocess

ROOT = Path(__file__).resolve().parents[1]

def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--chapters', type=int, nargs='*')
    parser.add_argument('--jobs', type=int, default=2)
    parser.add_argument('--log-dir', type=Path, default=Path('/tmp/cscs_slide_build'))
    args = parser.parse_args()
    args.log_dir.mkdir(parents=True, exist_ok=True)
    sources = sorted((ROOT/'_html_extra/chapters').glob('*/*_slides.md'))
    if args.chapters:
        sources = [p for p in sources if int(p.name[:2]) in args.chapters]
    if not sources:
        raise SystemExit('No matching slide sources.')
    def build(source):
        source_hash = hashlib.sha256(source.read_bytes()).hexdigest()
        command = ['node', 'scripts/slides/build.mjs', str(source.relative_to(ROOT)), '--pptx-dir', 'assignments/slides']
        result = subprocess.run(command, cwd=ROOT, capture_output=True, text=True, timeout=120)
        log = result.stdout + result.stderr
        (args.log_dir/(source.stem+'.log')).write_text(log)
        print(f'{source.stem}: {"PASS" if result.returncode == 0 else "FAIL"}', flush=True)
        return {'source': str(source.relative_to(ROOT)), 'source_sha256': source_hash,
                'command': command, 'exit_code': result.returncode,
                'warnings': [s for s in log.splitlines() if 'warning:' in s.lower()]}
    with ThreadPoolExecutor(max_workers=args.jobs) as pool:
        results = list(pool.map(build, sources))
    (args.log_dir/'build_results.json').write_text(json.dumps(results, indent=2)+'\n')
    raise SystemExit(any(r['exit_code'] for r in results))

if __name__ == '__main__':
    main()
