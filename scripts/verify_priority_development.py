#!/usr/bin/env python3
"""Check preservation and independently run the priority-section teaching examples."""
import argparse, concurrent.futures, hashlib, json, subprocess, tempfile
from pathlib import Path
ROOT = Path(__file__).resolve().parents[1]
OUT = ROOT / 'authoring/priority_development'

def preserve():
    baseline = json.loads((OUT / 'baseline.json').read_text())
    from integration_preservation import preintegration_view
    prior = preintegration_view(ROOT, {str(p.relative_to(ROOT)): json.loads(p.read_text()) for p in (ROOT / 'chapters').rglob('*.ipynb')})
    edits = {(r['path'], r['cell_id']): r for r in json.loads((OUT / 'source_corrections.json').read_text())}
    retained = code = 0
    for path, old in baseline.items():
        current = prior[path]
        by_id = {c['id']: c for c in current['cells']}
        assert len(by_id) == len(current['cells']), path
        for original in old['cells']:
            now = by_id[original['id']]
            if original['source'] != now['source']:
                correction = edits[path, original['id']]
                assert ''.join(original['source']) == correction['before']
                assert ''.join(now['source']) == correction['after']
                assert original['cell_type'] == 'markdown'
            if original['cell_type'] == 'code':
                assert original == now, (path, original['id'])
                code += 1
            retained += 1
    hashes = json.loads((OUT / 'assignment_hashes.json').read_text())
    for path, expected in hashes.items():
        assert hashlib.sha256((ROOT / path).read_bytes()).hexdigest() == expected, path
    report = {'original_cells_retained': retained, 'original_code_cells_unchanged': code,
              'documented_markdown_corrections': len(edits), 'assignment_notebooks_unchanged': len(hashes)}
    (OUT / 'preservation_check.json').write_text(json.dumps(report, indent=2) + '\n')
    print(json.dumps(report), flush=True)

def code_checks():
    cases = json.loads((OUT / 'new_code.json').read_text())
    with tempfile.TemporaryDirectory(prefix='cscs_priority_code_') as directory:
        workspace = Path(directory)
        def verify(case):
            notebook = json.loads((ROOT / case['path']).read_text())
            cell = next(c for c in notebook['cells'] if c['id'] == case['cell_id'])
            assert ''.join(cell['source']) == case['source']
            target = workspace / case['cell_id']; target.mkdir()
            (target / 'Program.cs').write_text(case['source'])
            (target / 'Check.csproj').write_text('<Project Sdk="Microsoft.NET.Sdk"><PropertyGroup><OutputType>Exe</OutputType><TargetFramework>net10.0</TargetFramework><Nullable>enable</Nullable><ImplicitUsings>disable</ImplicitUsings><TreatWarningsAsErrors>true</TreatWarningsAsErrors><NuGetAudit>false</NuGetAudit></PropertyGroup></Project>')
            built = subprocess.run(['dotnet', 'build', '--nologo', '-v:q', '--ignore-failed-sources'], cwd=target, text=True, capture_output=True, timeout=90)
            assert built.returncode == 0, built.stdout + built.stderr
            ran = subprocess.run(['dotnet', str(target / 'bin/Debug/net10.0/Check.dll')], cwd=target, text=True, capture_output=True, timeout=20)
            actual = ran.stdout.replace('\r\n', '\n')
            assert ran.returncode == 0 and actual == case['expected_stdout'], (case['path'], actual, ran.stderr)
            saved = ''.join(''.join(o.get('text', [])) for o in cell.get('outputs', []) if o.get('output_type') == 'stream' and o.get('name') == 'stdout')
            assert saved == actual, (case['path'], 'saved output differs')
            return {'path': case['path'], 'cell_id': case['cell_id'], 'passed': True, 'actual_stdout': actual, 'source_sha256': hashlib.sha256(case['source'].encode()).hexdigest()}
        with concurrent.futures.ThreadPoolExecutor(max_workers=2) as pool:
            results = list(pool.map(verify, cases))
    (OUT / 'code_verification.json').write_text(json.dumps(results, indent=2) + '\n')
    print(f'{len(results)} standalone examples compile and match expected/saved stdout.', flush=True)

if __name__ == '__main__':
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--code', action='store_true', help='Also compile and run all new examples under .NET 10.')
    args = parser.parse_args()
    preserve()
    if args.code: code_checks()
