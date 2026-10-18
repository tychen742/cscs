# Subsection Organization Audit

Scope: every TOC-listed content notebook in Chapters 1-26 (92 pages), including supporting readings, plus 17 book-owned appendix/reference/project pages. The scan covers 962 headings in total (including 109 page titles). Front matter and chapter landing pages are orientation, not lesson subsections; assignment organization, source-code correctness, and all shared Commons pages are separate audit scopes.

The full outline was reviewed, not only automatically flagged short passages. Direct-body word counts are triage aids: they exclude fenced code and child topics, so they are not content-adequacy scores. Short parent headings and staged practice can be appropriate. Do not flatten all headings or send all exercises to the end.

Confirmed findings are in findings.json and the readable review.html. Every finding records its source cell ID, one-based cell position, current heading level, observation, and proposed change. chapter_dispositions.json records every chapter, including chapters with no definite structural issue found. inventory.json contains every reviewed heading and its nearby source body. Source fingerprints establish that this audit did not reorganize the teaching material.

The main pattern is incomplete integration: parent topics and their syntax/examples are peers, some related older/newer passages remain separated, and a few examples are nested beneath the wrong parent. Highest priority: Chapters 3-6 and the core 2D-array bridge in Chapter 7. The latter was appended after optional jagged arrays in the preceding gap repair and should precede that extension.

Repair order: establish semantic parents; place syntax and worked variants under them; reunite misplaced explanations; stage guided practice before independent application; preserve all cell/exercise identities, content variants, and published anchors; align planning maps; rebuild and inspect numbered headings and fragment links. Do not rename or reorder chapter notebooks.

The authorized Chapter 7 search/sort additions remain pending during this scan. They belong in the existing processing lesson, after basic array traversal and method/reference explanation, before the command-line application. Its internal organization can be corrected as part of that already authorized Chapter 7 pass; findings elsewhere are reported before edits.

## Authorized Chapter 7 Follow-up

The core-before-extension finding in 0702 is fixed. The requested CS1 linear search, binary search, and insertion sort additions are implemented in 0703 with guided and independent practice. See ../ch07_search_sort/. The initial scan has 962 headings; the current inventory has 966 after those additions. baseline_inventory.json preserves the original outline; source_hashes.json retains the audit baseline. Other 19 recommendations remain unimplemented.

## Remaining Findings Implemented

All 19 remaining findings are now repaired within the existing chapter notebooks. The original audit observations and baseline outlines remain historical evidence. See ../subsection_organization_revision/ for every repair, complete source differences, updated planning maps, preservation checks, and rendered-link verification.
