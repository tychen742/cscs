#!/usr/bin/env python3
"""Verify all active demo projects, starters, lab solutions, and standalone sources."""
from pathlib import Path
import argparse
import concurrent.futures
import json
import re
import shutil
import subprocess
import tempfile
import xml.etree.ElementTree as ET

ROOT = Path(__file__).resolve().parents[1] / "demos"

# Input is supplied only to demos that read from the console. Expectations check
# results rather than merely accepting exit code zero.
CASES = {
    '01_context/hello_world': ('', [], ['Hello, World!']),
    '02_var_data/input': ('20\nAlex\nAlex\n101\n90\n-11\n5\n', [], ['Your score is 90.', 'Your number is 5.']),
    '02_var_data/output': ('Alex\n9:00\n', [], ['Alex has an interview at 9:00.']),
    '05_methods/loop_methods_demo': ('', [], ['edcba', 'OrderReady', '5! = 120']),
    '05_methods/methods_demo': ('2\n3\n', [], ['2 + 3 = 5', 'Old MacDonald had a farm']),
    '03_decision/conditional_demo': ('75\n', [], ['Wear shorts.']),
    '04_iteration/for_loop_demo': ('', [], ['edcba', 'OrderReady', '5! = 120']),
    '04_iteration/while_loop_demo': ('\n'.join(str(i) for i in range(1, 101)) + '\n', [], ['Correct!']),
    '06_exceptions_testing/exceptions_demo': ('', [], ['Access denied']),
    '06_exceptions_testing/math_lab/math_app': ('', [], ['10 * 10 = 100']),
    '07_arrays/arrays_demo': ('', ['1', '2', '3'], ['There are 3 command line parameters.', 'ints.Length: 12']),
    '07_arrays/array_lab': ('', [], ['Even count: 3', 'Pairwise sums: 9 3 14', 'Ascending: True']),
    '08_collections/collections_demo': ('', [], ['1\n2\n3\n4\n5']),
    '08_collections/help_responses': ('crash\nbye\n', [], ['Well, it never crashes on our system.']),
    '09_files_text/file_demo': ('', [], ['1\n2\n3', '5']),
    '10_classes/classes_demo': ('', [], ['has an existing ID!']),
    '10_classes/classes_lab': ('', [], ['Employee: John 100000']),
    '10_classes/enum_demo': ('', [], ['Medium\n3']),
    '11_object_design/object_design': ('', ['--check'], ['21 object-design checks passed.']),
    '12_oop/policy_design': ('', ['--check'], ['13 policy checks passed.']),
    '12_oop/oop_demo': ('', [], ['Balance: 1300', 'Area: 12.00', 'Area: 6.00', 'IA.M']),
    '12_oop/oop_lab': ('', [], ['Final balance: 125']),
    '16_searching_sorting/search_sort': ('', [], ['1051 search/sort checks passed.']),
    '18_priority_queues/priority_queue': ('', [], ['1036 heap checks passed.']),
    '19_hash_collections/hash_collections': ('', [], ['23292 hash/set checks passed.']),
    '20_graphs/graph_traversal': ('', [], ['12 graph checks passed.']),
    '23_searching_sorting/search_sort_demo': ('1, 2, 3\n2\n0\n\n', [], ['Item 2 found at position 1']),
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
    if entry.get('allowed_warnings'):
        command.append('-p:WarningsNotAsErrors=' + ','.join(entry['allowed_warnings']))
    if no_restore:
        command.append('--no-restore')
    run(command)
    note = f" (intentional starter warnings: {', '.join(entry['allowed_warnings'])})" if entry.get('allowed_warnings') else ''
    return f"Build passed [{entry.get('category', 'reference_checks')}]: {entry['project']}{note}"


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


def check_verification(project, spec, cwd):
    """Check saved output, explicit behavior, or one documented unfinished task."""
    result = subprocess.run(['dotnet', str(dll_for(project)), *spec.get('args', [])],
                            cwd=cwd, input=spec.get('stdin', ''), text=True,
                            capture_output=True, timeout=30)
    output = result.stdout.replace('\r\n', '\n')
    if 'expected_failure' in spec:
        if result.returncode == 0 or spec['expected_failure'] not in result.stderr:
            raise AssertionError(f'{project}: expected unfinished starter failure\n{output}\n{result.stderr}')
        return
    if result.returncode:
        raise AssertionError(f'{project}: unexpected failure\n{output}\n{result.stderr}')
    if 'expected_file' in spec:
        expected = (ROOT.parent / spec['expected_file']).read_text()
        if [s.rstrip() for s in output.splitlines()] != [s.rstrip() for s in expected.splitlines()]:
            raise AssertionError(f"{project}: output differs from {spec['expected_file']}")
    if 'stdout' in spec and output != spec['stdout']:
        raise AssertionError(f"{project}: expected {spec['stdout']!r}, got {output!r}")
    for expected in spec.get('contains', []):
        if expected not in output:
            raise AssertionError(f'{project}: missing {expected!r}\n{output}')
    for forbidden in spec.get('absent', []):
        if forbidden in output:
            raise AssertionError(f'{project}: unfinished starter unexpectedly includes {forbidden!r}')


def active_files(root, suffix):
    return {p.resolve() for p in root.rglob('*' + suffix)
            if not {'bin', 'obj', '_archived'} & set(p.relative_to(root).parts)}


def verify_inventory(entries, standalone):
    """Fail on new unlisted projects/sources rather than silently skipping them."""
    projects = [ROOT / e['project'] for e in entries]
    sources = [ROOT / e['source'] for e in standalone]
    if len(projects) != len(set(projects)) or len(sources) != len(set(sources)):
        raise AssertionError('Duplicate manifest entry')
    found = active_files(ROOT, '.csproj')
    listed = {p.resolve() for p in projects}
    if found != listed:
        raise AssertionError(f'Project inventory mismatch: unlisted={found-listed}; missing={listed-found}')
    covered = {p.resolve() for p in sources}
    categories = {'demo', 'supplementary_practice', 'test_suite', 'helper_library',
                  'starter', 'lab_solution', 'verification_harness'}
    for entry, project in zip(entries, projects):
        if entry.get('category') not in categories or not entry.get('purpose'):
            raise AssertionError(f'{project}: missing role/purpose')
        if entry['kind'] == 'console' and 'verification' not in entry and str(project.parent.relative_to(ROOT)) not in CASES:
            raise AssertionError(f'{project}: missing run expectations')
        xml = ET.parse(project).getroot()
        if xml.findtext('./PropertyGroup/EnableDefaultCompileItems') != 'false':
            covered |= active_files(project.parent, '.cs')
        for include in xml.findall('./ItemGroup/Compile'):
            if include.get('Include'):
                covered |= {p.resolve() for p in project.parent.glob(include.get('Include'))}
    found = active_files(ROOT, '.cs')
    if found != covered:
        raise AssertionError(f'Source inventory mismatch: unlisted={found-covered}; missing={covered-found}')
    for entry in standalone:
        if not entry.get('verification') or not entry.get('purpose'):
            raise AssertionError(f'{entry}: missing standalone verification')
    for readme in ROOT.rglob('README.md'):
        if '_archived' in readme.parts:
            continue
        for link in re.findall(r'\]\(([^)]+)\)', readme.read_text()):
            if not re.match(r'https?://|#', link) and not (readme.parent / link.split('#')[0]).exists():
                raise AssertionError(f'{readme}: broken link {link}')
    print(f'Inventory passed: {len(entries)} projects and {len(standalone)} standalone sources; active README links resolve.', flush=True)


def verify_standalone(entry, parent):
    folder = parent / Path(entry['source']).stem
    folder.mkdir()
    # Copy the original bytes into an isolated project; never edit teaching code.
    shutil.copyfile(ROOT / entry['source'], folder / 'Program.cs')
    project = folder / 'standalone.csproj'
    project.write_text('<Project Sdk="Microsoft.NET.Sdk"><PropertyGroup>'
                       '<OutputType>Exe</OutputType><TargetFramework>net10.0</TargetFramework>'
                       '<ImplicitUsings>enable</ImplicitUsings><Nullable>enable</Nullable>'
                       '</PropertyGroup></Project>')
    run(['dotnet', 'build', str(project), '--nologo', '-v:q', '-warnaserror', '-p:NuGetAudit=false'])
    check_verification(project, entry['verification'], parent)
    print(f"Standalone passed: {entry['source']}", flush=True)


def main():
    parser = argparse.ArgumentParser(description=__doc__)
    parser.add_argument('--no-restore', action='store_true',
                        help='Skip restore for existing projects; temporary standalone projects still restore.')
    parser.add_argument('--inventory-only', action='store_true', help='Check complete coverage and README links without building.')
    args = parser.parse_args()
    entries = json.loads((ROOT / 'demo_projects.json').read_text())
    standalone = json.loads((ROOT / 'standalone_sources.json').read_text())
    verify_inventory(entries, standalone)
    if args.inventory_only:
        return
    sdk = run(['dotnet', '--version']).strip()
    if not sdk.startswith('10.'):
        raise RuntimeError(f'.NET 10 SDK required; found {sdk}.')
    with concurrent.futures.ThreadPoolExecutor(max_workers=2) as pool:
        for message in pool.map(lambda e: verify_build(e, args.no_restore), entries):
            print(message, flush=True)
    with tempfile.TemporaryDirectory(prefix='cscs-demo-runs-') as temporary:
        # File/database writes stay isolated from the checkout.
        cwd = Path(temporary)
        count = suites = 0
        for entry in entries:
            project = ROOT / entry['project']
            if entry['kind'] == 'console':
                if 'verification' in entry:
                    check_verification(project, entry['verification'], cwd)
                else:
                    check_run(project, CASES[str(project.parent.relative_to(ROOT))], cwd)
                count += 1
                print(f"Run passed [{entry['category']}]: {entry['project']}", flush=True)
            elif entry['kind'] == 'test':
                output = run(['dotnet', 'test', str(project), '--no-build', '--no-restore', '--nologo'])
                if 'Failed:     0' not in output or 'Passed:     4' not in output:
                    raise AssertionError(output)
                suites += 1
                print(output.strip(), flush=True)
        extras = [
            ('03_decision/conditional_demo/conditional_demo.csproj', ('60\n', [], ['Wear long pants.'])),
            ('10_classes/classes_lab/classes_lab.csproj', ('1\n0\n', ['guess'], ['You won on guess 1!'])),
            ('10_classes/classes_lab/classes_lab.csproj', ('1\n0\n', ['static-guess'], ['You won on guess 1!'])),
            ('23_searching_sorting/search_sort_demo/search_sort_demo.csproj', ('', ['sort', '20', '42'], ['Bubble Sort:', 'Quick Sort:'])),
            ('_extras/bookstore_inventory/BookstoreInventory.csproj', ('', ['--check-core'], ['core inventory checks passed.'])),
        ]
        for project, case in extras:
            check_run(ROOT / project, case, cwd)
        for entry in standalone:
            verify_standalone(entry, cwd)
        print(f'Verified {len(entries)} projects, {count + len(extras)} project runs, '
              f'{suites} MSTest suites, and {len(standalone)} standalone source programs.', flush=True)


if __name__ == '__main__':
    main()
