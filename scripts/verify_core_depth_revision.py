"""Verify the bounded core-depth revision without touching excluded readings."""
import concurrent.futures
import hashlib
import json
import re
import subprocess
from pathlib import Path

ROOT = Path(__file__).resolve().parents[1]
OUT = ROOT / 'authoring/core_depth_revision'
BASE = json.loads((OUT / 'baseline.json').read_text())
CHANGED = set(BASE)

def text(cell):
    return ''.join(cell.get('source', []))

def preservation():
    hashes = json.loads((OUT / 'all_notebook_hashes.json').read_text())
    excluded = [p for p in hashes if p not in CHANGED]
    assert all(hashlib.sha256((ROOT / p).read_bytes()).hexdigest() == hashes[p] for p in excluded)
    corrections = {'9b215d33', 'ba_26ba7b7ad9c881b771', 'p3_9c35dc0dfc', 'p8_8e0120fb', 'p8_19013efd', 'fc6bc11b'}
    records = []
    for path, old in BASE.items():
        new = json.loads((ROOT / path).read_text())
        by_id = {c['id']: c for c in new['cells']}
        assert len(by_id) == len(new['cells']), path
        for cell in old['cells']:
            assert cell['id'] in by_id, (path, cell['id'])
            current = by_id[cell['id']]
            if text(cell) != text(current):
                normalize = lambda s: re.sub(r'^#{2,6}(?=\s)', '#', s, flags=re.M)
                assert normalize(text(cell)) == normalize(text(current)) or cell['id'] in corrections, (path, cell['id'])
            if cell['cell_type'] == 'code':
                assert cell['outputs'] == current['outputs'], (path, cell['id'], 'existing output changed')
                assert cell.get('execution_count') == current.get('execution_count')
        records.append({'path': path, 'original_cells': len(old['cells']), 'retained_original_cells': len(old['cells']), 'added_cells': len(new['cells']) - len(old['cells'])})
    report = {'excluded_notebooks_unchanged': len(excluded), 'assignments_unchanged': sum('/assignments/' in p for p in excluded), 'all_original_cell_ids_preserved': True, 'existing_outputs_preserved': True, 'notebooks': records}
    (OUT / 'preservation.json').write_text(json.dumps(report, indent=2) + '\n')
    return report

def code_cases():
    new = {c['id']: c for c in json.loads((OUT / 'new_code.json').read_text())}
    cases = []
    for path in BASE:
        nb = json.loads((ROOT / path).read_text())
        for cell in nb['cells']:
            if cell['cell_type'] != 'code':
                continue
            source = text(cell)
            is_new = cell['id'] in new
            tags = cell.get('metadata', {}).get('tags', [])
            # Incomplete learner attempts are not demonstration correctness claims.
            if not is_new and 'hide-input' not in tags and ('exercise' in tags or 'Your code starts here' in source or 'TODO' in source):
                continue
            expected = new[cell['id']]['expected_stdout'] if is_new else None
            cases.append({'path': path, 'cell_id': cell['id'], 'source': source, 'expected_stdout': expected, 'new': is_new})
    return cases

def run_case(case):
    folder = Path('/tmp/cscs_core_depth_verify') / case['cell_id']
    folder.mkdir(parents=True, exist_ok=True)
    (folder / 'Program.cs').write_text(case['source'])
    (folder / 'NuGet.Config').write_text('<configuration><packageSources><clear /></packageSources></configuration>')
    (folder / 'Check.csproj').write_text('<Project Sdk="Microsoft.NET.Sdk"><PropertyGroup><OutputType>Exe</OutputType><TargetFramework>net10.0</TargetFramework><ImplicitUsings>enable</ImplicitUsings><Nullable>enable</Nullable><NuGetAudit>false</NuGetAudit><UseSharedCompilation>false</UseSharedCompilation></PropertyGroup></Project>')
    build = subprocess.run(['dotnet', 'build', '--nologo', '-v:q', '--configfile', 'NuGet.Config'], cwd=folder, capture_output=True, text=True, timeout=60)
    result = {k: v for k, v in case.items() if k != 'source'}
    result['compiled'] = build.returncode == 0
    result['build'] = build.stdout + build.stderr
    if build.returncode:
        result['passed'] = False
        return result
    run = subprocess.run(['dotnet', str(folder / 'bin/Debug/net10.0/Check.dll')], input='', cwd=folder, capture_output=True, text=True, timeout=15)
    result.update(stdout=run.stdout.replace('\r\n', '\n'), stderr=run.stderr, exit_code=run.returncode)
    result['passed'] = run.returncode == 0 and (case['expected_stdout'] is None or result['stdout'] == case['expected_stdout'])
    return result

if __name__ == '__main__':
    report = preservation()
    print('Preservation:', report['excluded_notebooks_unchanged'], 'excluded notebooks unchanged;', report['assignments_unchanged'], 'assignment notebooks unchanged.', flush=True)
    cases = code_cases()
    print('Verifying', len(cases), 'complete/new cells independently.', flush=True)
    results = []
    with concurrent.futures.ThreadPoolExecutor(max_workers=2) as pool:
        for result in pool.map(run_case, cases):
            results.append(result)
            print(('PASS' if result['passed'] else 'FAIL'), result['cell_id'], flush=True)
    (OUT / 'code_verification.json').write_text(json.dumps(results, indent=2) + '\n')
    # Attach output only to the newly introduced cells, preserving every original output.
    for path in BASE:
        nb = json.loads((ROOT / path).read_text())
        changed = False
        for cell in nb['cells']:
            match = next((r for r in results if r['path'] == path and r['cell_id'] == cell['id'] and r['new'] and r['passed']), None)
            if match:
                cell['outputs'] = [{'output_type': 'stream', 'name': 'stdout', 'text': match['stdout'].splitlines(True)}] if match['stdout'] else []
                cell['execution_count'] = 1
                changed = True
        if changed:
            (ROOT / path).write_text(json.dumps(nb, ensure_ascii=False, indent=1) + '\n')
    failures = [r for r in results if not r['passed']]
    assert not failures, [(r['cell_id'], r.get('stderr', r['build'])) for r in failures]
    print('All selected cells passed.', flush=True)
