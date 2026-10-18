"""Compatibility entry point for the current reviewed subject-index checks.

Earlier parser-only verification is superseded by the full editorial mapping.
Historical results remain under authoring/index_cleanup/.
"""
from pathlib import Path
import runpy

runpy.run_path(str(Path(__file__).with_name('verify_index_revision.py')), run_name='__main__')
