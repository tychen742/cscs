# Subject index cleanup

Numbered exercise titles are excluded from the generated subject index; their source directives, anchors, content, and navigation are preserved. One-dimensional arrays are filed under array, and the combined .NET SDK/runtime/command entry is separated.

Implementation: `_ext/subject_index.py`, registered in `_config.yml`.

Verification: full book build passed with the existing Chapter 2 character-literal highlighting warning; all 2,039 local index links resolve, and all 277 notebook files remain byte-identical to the pre-cleanup snapshot. See `verification.json`. Recheck the preview build with `.venv/bin/python scripts/verify_subject_index.py`.

Local preview: http://127.0.0.1:8800/genindex.html

Not deployed. This addresses the malformed Symbols entries; it is not a complete editorial curation of every subject term.
