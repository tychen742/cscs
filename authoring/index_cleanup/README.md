# Subject index cleanup

The index directive preserves literal commas in headings and generic type names. Explicit Sphinx entry types retain their normal meaning. Generated subject entries exclude numbered task titles and generic navigation labels, expand malformed lists of subentries, merge capitalization variants, and repair specific repeated words, escaped markup and a replacement placeholder. All source notebook directives, teaching text and anchors remain intact.

Implementation: `_ext/subject_index.py`, registered in `_config.yml`. Full editorial before/after term lists are in `editorial_changes.json`; examples and scope are in `editorial_review.html`.

Verification: `.venv/bin/python scripts/verify_subject_index.py` checks the local build, every local index target/fragment and the pre-cleanup notebook hashes. See `verification.json` for current results. The full build passes with the existing Chapter 2 character-literal highlighting warning.

Local preview: http://127.0.0.1:8800/genindex.html
Review: http://127.0.0.1:8800/index_cleanup_review.html

Not deployed. Descriptive teaching headings remain indexed; this pass repairs malformed entries rather than replacing the entire index with a new controlled subject vocabulary.
