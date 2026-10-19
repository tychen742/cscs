#!/usr/bin/env python3
"""Verify standalone lab references and current Chapter 7 notebook answers."""
from pathlib import Path
import json
import subprocess
import tempfile

ROOT = Path(__file__).resolve().parents[1]
OUTPUTS = ROOT / 'instructor_support' / 'labs'


def run(project):
    result = subprocess.run(['dotnet', 'run', '--project', str(project), '-p:NuGetAudit=false'],
                            cwd=ROOT, capture_output=True, text=True, timeout=120)
    if result.returncode:
        raise RuntimeError(result.stdout + result.stderr)
    return result.stdout.replace('\r\n', '\n')


def compare(actual, expected_file):
    expected = expected_file.read_text()
    if '\n'.join(line.rstrip() for line in actual.splitlines()) != '\n'.join(line.rstrip() for line in expected.splitlines()):
        raise AssertionError(f'Output changed: {expected_file}. Review the source and instructor guide.')


def main():
    for number, folder, stem in [('05', '05_methods', 'sku_report_lab_solution'),
                                 ('09', '09_files_text', 'privacy_pass_lab_solution')]:
        compare(run(ROOT / 'demos' / folder / (stem + '.csproj')),
                OUTPUTS / (('09_privacy' if number == '09' else number) + '_reference_output.txt'))
        print(f'Chapter {number} reference passed.', flush=True)
    notebook = json.loads((ROOT / 'chapters/07_arrays/assignments/lab.ipynb').read_text())
    answers = [c for c in notebook['cells'] if 'hide-input' in c.get('metadata', {}).get('tags', [])]
    if len(answers) != 5:
        raise AssertionError('Chapter 7 answer count changed; review the instructor mapping.')
    with tempfile.TemporaryDirectory(prefix='cscs-instructor-sales-') as directory:
        folder = Path(directory)
        project = folder / 'sales.csproj'
        project.write_text('<Project Sdk="Microsoft.NET.Sdk"><PropertyGroup>'
                           '<OutputType>Exe</OutputType><TargetFramework>net10.0</TargetFramework>'
                           '<ImplicitUsings>enable</ImplicitUsings><Nullable>enable</Nullable>'
                           '</PropertyGroup></Project>')
        for task, cell in enumerate(answers, 1):
            (folder / 'Program.cs').write_text(''.join(cell['source']))
            compare(run(project), OUTPUTS / f'07_task_{task}_output.txt')
            print(f'Chapter 7 Task {task} answer passed independently.', flush=True)


if __name__ == '__main__':
    main()
