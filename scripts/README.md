# Repository Utilities

Run these commands from the repository root:

| Script | Purpose | Command |
| --- | --- | --- |
| `verify_demos.py` | Build and exercise the runnable demos and behavior checks. | `python3 scripts/verify_demos.py` |
| `verify_lab_solutions.py` | Verify mapped lab references and current notebook answers. | `python3 scripts/verify_lab_solutions.py` |
| `make_cover_art.py` | Regenerate the seeded SVG cover artwork. | `python3 scripts/make_cover_art.py` |
| `rename_cell_tag.py` | Rename a cell metadata tag in every chapter notebook, preserving formatting. | `python3 scripts/rename_cell_tag.py OLD NEW` |

Verification requires the .NET 10 SDK. Demo verification can use `--no-restore`
after packages have been restored. The cover script writes `figures/cover-art.svg`;
run it only when you intend to regenerate that artwork.

Archived scripts and historical Sphinx configuration remain under
`demos/_archived/`; they are not part of the active utility workflow.
