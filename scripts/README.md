# Repository Utilities

Run these commands from the repository root:

| Script | Purpose | Command |
| --- | --- | --- |
| `verify_demos.py` | Build and exercise the runnable demos and behavior checks. | `python3 scripts/verify_demos.py` |
| `verify_lab_solutions.py` | Verify mapped lab references and current notebook answers. | `python3 scripts/verify_lab_solutions.py` |
| `make_cover_art.py` | Regenerate the seeded SVG cover artwork. | `python3 scripts/make_cover_art.py` |
| `rename_cell_tag.py` | Rename a cell metadata tag in every chapter notebook, preserving formatting. | `python3 scripts/rename_cell_tag.py OLD NEW` |
| `verify_slide_examples.py` | Compile and run all recorded standalone slide examples. | `.venv/bin/python scripts/verify_slide_examples.py` |
| `verify_lecture_slides.py` | Check deck outputs, notes, verified examples, and assessment preservation. | `.venv/bin/python scripts/verify_lecture_slides.py` |
| `stage_lecture_slides.py` | Copy student slide assets into a built book without instructor sources. | `.venv/bin/python scripts/stage_lecture_slides.py` |
| `build_lecture_slides.py` | Build all chapter HTML decks and editable instructor PowerPoints. | `.venv/bin/python scripts/build_lecture_slides.py` |
| `render_lecture_slides.py` | Render all slides and contact sheets for visual inspection. | `.venv/bin/python scripts/render_lecture_slides.py` |

Verification requires the .NET 10 SDK. Demo verification can use `--no-restore`
after packages have been restored. The cover script writes `figures/cover-art.svg`;
run it only when you intend to regenerate that artwork.

Archived scripts and historical Sphinx configuration remain under
`demos/_archived/`; they are not part of the active utility workflow.
