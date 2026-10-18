# Reviewed subject-index revision

The full audit's 1,435 entries and 1,920 indexed locations are resolved through an explicit subject mapping. Teaching headings remain descriptive in their lessons; the generated index uses concise subject terms, qualified APIs, genuine subtopics, and aliases/cross-references. All 276 remaining notebook files in the preservation baseline are byte-identical; all 341 tracked notebooks are unchanged from HEAD. Teaching prose, exercises, code, outputs, metadata and source anchors are preserved. One absent ignored checkpoint from the old baseline is recorded separately.

## Maintained files

- `_ext/subject_index_entries.json`: every audited source term maps explicitly to canonical subjects, or to an empty list for administrative labels removed from the index.
- `_ext/subject_index_additions.json`: 41 direct lookup entries and 42 `see`/`seealso` references, each with a reviewed teaching destination.
- `_ext/subject_index.py`: constructs the index from unchanged parsed source nodes, applies the reviewed map, validates destinations and cross-references, and collapses repeated pointers within the same actual section. Cached and clean builds use the same source inventory. New unreviewed source entries fail the build with their document and wording instead of being silently guessed.
- `mapping.json`: complete old-to-new review ledger with original lesson headings, excerpts, and dispositions. A conservative audit flag may resolve to retaining a confirmed genuine subtopic.
- `before_entries.json` and `subject_index_before.py`: the reviewed baseline and extension before revision.
- `verification.json`: current preservation, coverage and link checks.

No teaching content was removed. Removing an administrative index entry does not remove its assignment or navigation. Subject mapping and display wording are separate from notebook headings. Some retained historical-tool entries explicitly identify their historical context.

## Verification

Build: `.venv/bin/jupyter-book build . --all --path-output /tmp/cscs-section-revision`.

Verify: `.venv/bin/python scripts/verify_index_revision.py` (also available through the compatibility entry point `scripts/verify_subject_index.py`). The verifier compares every mapped teaching passage and every added entry against the generated index, checks the cross-reference vocabulary, rejects the audit's semantic regressions, checks every local index link/fragment, and compares all notebook hashes. It does not equate working links with semantic correctness; the explicit editorial mapping records the concept decisions.

The full build passes with the pre-existing Chapter 2 character-literal highlighting warning. No new warnings were introduced. No C# examples changed, so code execution is outside this index-only verification.

Review: `.venv/bin/python scripts/build_index_revision_review.py`.

- Revised index: http://127.0.0.1:8800/genindex.html
- Complete mapping and extension diff: http://127.0.0.1:8800/index_revision_review.html

Local changes, not deployed.
