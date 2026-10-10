#!/usr/bin/env python3
"""Build and exercise the migrated demo projects with the .NET 10 SDK."""
from pathlib import Path
import argparse
import concurrent.futures
import json
import subprocess
import tempfile
import xml.etree.ElementTree as ET

ROOT = Path(__file__).resolve().parents[1] / "demos"

# Input is supplied only to demos that read from the console. Expectations check
# results rather than merely accepting exit code zero.
CASES = {
    '01/hello_world': ('', [], ['Hello, World!']),
    '02/input': ('20\nAlex\nAlex\n101\n90\n-11\n5\n', [], ['Your score is 90.', 'Your number is 5.']),
    '02/output': ('Alex\n9:00\n', [], ['Alex has an interview at 9:00.']),
    '03/methods_demo': ('2\n3\n', [], ['2 + 3 = 5', 'Old MacDonald had a farm']),
    '04/conditional_demo': ('75\n', [], ['Wear shorts.']),
    '05/for_loop_demo': ('', [], ['edcba', 'OrderReady', '5! = 120']),
    '05/while_loop_demo': ('\n'.join(str(i) for i in range(1, 101)) + '\n', [], ['Correct!']),
    '06/exceptions_demo': ('', [], ['Access denied']),
    '06/math_lab/math_app': ('', [], ['10 * 10 = 100']),
    '08/arrays_demo': ('', ['1', '2', '3'], ['There are 3 command line parameters.', 'ints.Length: 12']),
    '08/array_lab': ('', [], ['Even count: 3', 'Pairwise sums: 9 3 14', 'Ascending: True']),
    '09/collections_demo': ('', [], ['apple\nbanana\ncherry']),
    '09/help_responses': ('crash\nbye\n', [], ['Well, it never crashes on our system.']),
    '10/file_demo': ('', [], ['1\n2\n3', '5']),
    '12/classes_demo': ('', [], ['has an existing ID!']),
    '12/classes_lab': ('', [], ['Employee: John 100000']),
    '12/enum_demo': ('', [], ['Medium\n3']),
    '13/oop_demo': ('', [], ['Balance: 1300', 'Area: 12.00', 'Area: 6.00', 'IA.M']),
    '13/oop_lab': ('', [], ['Final balance: 125']),
    '22/search_sort_demo': ('1, 2, 3\n2\n0\n\n', [], ['Item 2 found at position 1']),
    '_extras/contact_demo': ('', [], ['Name is TY', 'Phone is 333']),
    '_extras/one_hour_of_code': ('Alex Chen\n7\n2\n60\n', [], ['Order total: 120.00. Eligible for free shipping.']),
}


def run(command, *, cwd=ROOT, stdin=None, timeout=120):
    result = subprocess.run(command, cwd=cwd, input=stdin, text=True,
                            capture_output=True, timeout=timeout)
    if result.returncode:
        raise RuntimeError(f"{' '.join(map(str, command))}\n{result.stdout}\n{result.stderr}")
    return (result.stdout + result.stderr).replace('\r\n', '\n')


def verify_build(entry, no_restore):
    project = ROOT / entry['project']
    command = ['dotnet', 'build', str(project), '--nologo', '-v:q',
               '-warnaserror', '-p:NuGetAudit=false']
    if no_restore:
        command.append('--no-restore')
    run(command)
    return f"Build passed: {entry['project']}"


def dll_for(project):
    settings = ET.parse(project).getroot()
    assembly = settings.findtext('./PropertyGroup/AssemblyName') or project.stem
    return project.parent / 'bin' / 'Debug' / 'net10.0' / (assembly + '.dll')


def check_run(project, case, cwd):
    stdin, args, expected = case
    output = run(['dotnet', str(dll_for(project)), *args], cwd=cwd, stdin=stdin, timeout=30)
    for snippet in expected:
        if snippet not in output:
            raise AssertionError(f"{project}: missing expected output {snippet!r}\n{output}")


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--no-restore', action='store_true', help='Use already restored dependencies.')
    args = parser.parse_args()
    sdk = run(['dotnet', '--version']).strip()
    if not sdk.startswith('10.'):
        raise RuntimeError(f'.NET 10 SDK required; found {sdk}.')
    entries = json.loads((ROOT / 'demo_projects.json').read_text())
    checks = {'project': '_extras/demo_checks/demo_checks.csproj', 'kind': 'console'}
    with concurrent.futures.ThreadPoolExecutor(max_workers=2) as pool:
        for message in pool.map(lambda e: verify_build(e, args.no_restore), [*entries, checks]):
            print(message, flush=True)
    with tempfile.TemporaryDirectory(prefix='cscs-demo-runs-') as temporary:
        # Running from a different folder catches dependence on the shell's cwd.
        cwd = Path(temporary)
        count = 0
        for entry in entries:
            project = ROOT / entry['project']
            if entry['kind'] == 'console':
                case = CASES[str(project.parent.relative_to(ROOT))]
                check_run(project, case, cwd)
                count += 1
                print(f"Run passed: {entry['project']}", flush=True)
            elif entry['kind'] == 'test':
                output = run(['dotnet', 'test', str(project), '--no-build', '--no-restore', '--nologo'])
                if 'Failed:     0' not in output or 'Passed:     4' not in output:
                    raise AssertionError(output)
                print(output.strip(), flush=True)
        # Additional run modes and decision branches.
        extras = [
            ('04/conditional_demo/conditional_demo.csproj', ('60\n', [], ['Wear long pants.'])),
            ('12/classes_lab/classes_lab.csproj', ('1\n0\n', ['guess'], ['You won on guess 1!'])),
            ('12/classes_lab/classes_lab.csproj', ('1\n0\n', ['static-guess'], ['You won on guess 1!'])),
            ('22/search_sort_demo/search_sort_demo.csproj', ('', ['sort', '20', '42'], ['Bubble Sort:', 'Quick Sort:'])),
        ]
        for project, case in extras:
            check_run(ROOT / project, case, cwd)
        print(run(['dotnet', str(dll_for(ROOT / checks['project']))], cwd=cwd).strip(), flush=True)
        print(f'Verified {len(entries)} migrated projects, {count + len(extras)} console runs, '
              'two MSTest suites, and the behavior-check project.', flush=True)


if __name__ == '__main__':
    main()
