#!/usr/bin/env python3
"""Compile and run every recorded standalone lecture example with .NET 10."""
import argparse
from concurrent.futures import ThreadPoolExecutor
import hashlib
import json
from pathlib import Path
import subprocess
import tempfile

ROOT = Path(__file__).resolve().parents[1]
EVIDENCE = ROOT/'authoring/slide_revision'

def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--jobs', type=int, default=4)
    parser.add_argument('--records', type=Path, nargs='*')
    parser.add_argument('--fresh', action='store_true', help='Rerun previously verified unchanged examples.')
    args = parser.parse_args()
    records = []
    for path in args.records or sorted(EVIDENCE.glob('code_[0-9]*.json')):
        records.extend(json.loads(path.read_text()))
    if not records:
        raise SystemExit('No code records found.')
    previous = [] if args.fresh or not (EVIDENCE/'code_results.json').exists() else json.loads((EVIDENCE/'code_results.json').read_text())
    cache = {(r['source_sha256'], r['expected_stdout'], r.get('stdin', '') or ''): r for r in previous if r['passed']}
    with tempfile.TemporaryDirectory(prefix='cscs_slide_examples_') as tmp:
        work = Path(tmp)
        def execute(item):
            number, record = item
            key = (hashlib.sha256(record['source'].encode()).hexdigest(), record['expected_stdout'], record.get('stdin', '') or '')
            if key in cache:
                return {**cache[key], **record}
            directory = work/str(number)
            directory.mkdir()
            source = record['source']
            (directory/'Program.cs').write_text(source)
            (directory/'Example.csproj').write_text('<Project Sdk="Microsoft.NET.Sdk"><PropertyGroup><OutputType>Exe</OutputType><TargetFramework>net10.0</TargetFramework><ImplicitUsings>enable</ImplicitUsings><Nullable>enable</Nullable><TreatWarningsAsErrors>true</TreatWarningsAsErrors><NuGetAudit>false</NuGetAudit></PropertyGroup></Project>')
            (directory/'NuGet.Config').write_text('<configuration><packageSources><clear /></packageSources></configuration>')
            build = subprocess.run(['dotnet', 'build', '--nologo', '--verbosity', 'quiet'], cwd=directory, capture_output=True, text=True, timeout=90)
            run = None
            if build.returncode == 0:
                run = subprocess.run(['dotnet', str(directory/'bin/Debug/net10.0/Example.dll')], cwd=directory, input=record.get('stdin', '') or '', capture_output=True, text=True, timeout=30)
            stdout = run.stdout if run else ''
            expected = record['expected_stdout']
            result = {**record, 'source_sha256': hashlib.sha256(source.encode()).hexdigest(),
                      'build_exit_code': build.returncode, 'build_output': build.stdout+build.stderr,
                      'run_exit_code': run.returncode if run else None, 'actual_stdout': stdout,
                      'stderr': run.stderr if run else '',
                      'passed': build.returncode == 0 and run.returncode == 0 and stdout == expected}
            print(f'{number+1}/{len(records)} Ch{record["chapter"]} {record["slide_title"]}: {"PASS" if result["passed"] else "FAIL"}', flush=True)
            return result
        with ThreadPoolExecutor(max_workers=args.jobs) as pool:
            results = list(pool.map(execute, enumerate(records)))
    (EVIDENCE/'code_results.json').write_text(json.dumps(results, indent=2)+'\n')
    failed = [r for r in results if not r['passed']]
    print(f'{len(results)-len(failed)}/{len(results)} examples passed.')
    raise SystemExit(bool(failed))

if __name__ == '__main__':
    main()
