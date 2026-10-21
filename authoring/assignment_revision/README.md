# Assignment alignment revision — 2026-10-21

Changes are uncommitted for review. Chapter order and existing assessment identities are preserved; slides are deferred.

## Repairs

1. Corrected executable lab instructions and solution checks: Chapter 6 solution paths, Chapter 16 full report preservation, Chapter 7 half-open binary search, and Chapter 9 owned workspaces and cleanup.
2. Repaired prerequisites and objective coverage: connected Chapter 5 lab, independent five-question coding homework sets in Chapters 3–5, 7, and 9, versioned priority dispatch in Chapter 19, explicit graph preparation and standalone support in Chapter 26. Later-topic and legacy practice is explicitly optional.
3. Reworked preview readiness, duplicate questions, applied true/false feedback, and Chapters 21–26 answer controls. Existing radio names and values remain intact. Canonical answer values are independent of displayed option order.
4. Updated the project track to console workflows, GitHub delivery, persistence and test evidence, with explicit prerequisite gates. Updated chapter planning records.

## Review

[Readable content and planning diffs](review.diff) flatten notebook cells into text, avoiding notebook JSON noise. The final section includes the new verification utility. Use the application’s unstaged review for the original notebook JSON changes.

## Verification

- All 34 changed or new completed solution cells have current-source hashes and matching compiled output, represented in 54 execution and variant records in `solution_checks.json`.
- Fourteen additional early-chapter boundary cases passed, including EOF, retry, loop endpoints, and discount thresholds (`early_boundary_results.json`).
- Mutation checks reject corrupted report contents, stale priority versions, and broken tombstone deletion.
- Chapter 6 restore/build and MSTest workflow demonstrated the expected multiplication failure, then passed four repaired tests and five tests with an added method. The existing MSTEST0001 parallelization warning remains; see `early_ch06_full_results.json`.
- Full HTML build succeeded. The initial build reported three pre-existing code-highlighting warnings; the final incremental build succeeded without warnings. Rendered HTML controls were checked automatically and the Chapter 21 preview was visually inspected.
- Preservation checks cover 7,541 original cell IDs, 213 assessment metadata IDs, 15 inline exercise IDs, 481 existing radio name/value pairs, unchanged slides, and unchanged TOC file order. See `preservation_checks.json`.

Recheck the saved evidence against current source:

```sh
.venv/bin/python scripts/verify_assignment_revision.py
```

Build and check rendered controls:

```sh
.venv/bin/jupyter-book build . --builder html --path-output /tmp/cscs_assignment_revision_build
.venv/bin/python scripts/verify_assignment_revision.py --html /tmp/cscs_assignment_revision_build/_build/html
```

The verification utility checks recorded execution evidence against current source; it does not rerun C# itself. The execution records retain inputs, expected/actual outputs, and source hashes. Browser quiz controls provide local answer selection and explanations; authenticated course submission and grading were not exercised.
