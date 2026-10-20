#!/usr/bin/env python3
"""Regression checks for demo inventory omissions and unfinished starter failures."""
from pathlib import Path
import contextlib
import io
import subprocess
import tempfile
import unittest
from unittest.mock import patch

import verify_demos as verifier


class DemoVerificationTests(unittest.TestCase):
    def setUp(self):
        self.temporary = tempfile.TemporaryDirectory()
        self.addCleanup(self.temporary.cleanup)
        self.root = Path(self.temporary.name)
        self.project = self.root / 'helper.csproj'
        self.project.write_text('<Project><PropertyGroup><EnableDefaultCompileItems>false</EnableDefaultCompileItems></PropertyGroup><ItemGroup><Compile Include="helper.cs" /></ItemGroup></Project>')
        (self.root / 'helper.cs').write_text('public class Helper {}')
        self.entries = [dict(project='helper.csproj', kind='library', category='helper_library', purpose='Test helper')]
        self.root_patch = patch.object(verifier, 'ROOT', self.root)
        self.root_patch.start()
        self.addCleanup(self.root_patch.stop)

    def inventory(self, standalone=None):
        with contextlib.redirect_stdout(io.StringIO()):
            verifier.verify_inventory(self.entries, standalone or [])

    def test_complete_inventory(self):
        self.inventory()

    def test_new_project_is_not_silently_skipped(self):
        (self.root / 'new.csproj').write_text('<Project />')
        with self.assertRaisesRegex(AssertionError, 'Project inventory mismatch'):
            self.inventory()

    def test_uncompiled_source_is_not_silently_skipped(self):
        (self.root / 'forgotten.cs').write_text('// standalone')
        with self.assertRaisesRegex(AssertionError, 'Source inventory mismatch'):
            self.inventory()
        self.inventory([dict(source='forgotten.cs', purpose='Standalone', verification={'stdout': ''})])

    def test_broken_readme_link(self):
        (self.root / 'README.md').write_text('[Missing](missing.md)')
        with self.assertRaisesRegex(AssertionError, 'broken link'):
            self.inventory()

    def test_duplicate_project(self):
        self.entries.append(self.entries[0].copy())
        with self.assertRaisesRegex(AssertionError, 'Duplicate'):
            self.inventory()

    def test_starter_requires_specific_failure(self):
        spec = {'expected_failure': 'System.NotImplementedException: Task 1'}
        for status, error, accepted in [(1, 'System.NotImplementedException: Task 1', True),
                                        (1, 'System.IO.FileNotFoundException', False),
                                        (0, 'System.NotImplementedException: Task 1', False)]:
            with self.subTest(status=status, error=error):
                with patch.object(verifier.subprocess, 'run', return_value=subprocess.CompletedProcess([], status, '', error)):
                    if accepted:
                        verifier.check_verification(self.project, spec, self.root)
                    else:
                        with self.assertRaisesRegex(AssertionError, 'expected unfinished starter failure'):
                            verifier.check_verification(self.project, spec, self.root)


if __name__ == '__main__':
    unittest.main()
