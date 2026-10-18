# Priority-section teaching development

Local revision following the October 17 count/development review. Not deployed.
The current chapter and section order remains unchanged.

## Scope

Developed all 10 first-priority readings and five secondary-priority readings
across Chapters 6, 7, 9, 11, 17, 20, 23, 24, 25 and 26. The coverage map is
`coverage.json`. This pass does not change Chapter 8's pacing or turn optional
readings into required meetings.

Each revised lesson develops its topic through conceptual connections, small
worked examples, interpreted output, state/decision traces, meaningful
variations, mistake diagnosis and guided checkpoints. Complete original
implementations remain alongside smaller teaching cores. Explanations stay in
content sections; lab and homework remain application/transfer tracks.

Highlights include methods/loops before array/CSV debugging applications;
executable array creation/indexing and repaired defaults/LINQ presentation;
owned temporary file lifetimes; missing versus empty/zero values; recursive
leaf-count completion; BFS discovery/path and DFS frame/component traces;
duplicate boundaries and two-scan partitioning; union-find and cut reasoning;
cache/table execution, minimum-pack predecessors and reconstruction; and
direct/KMP overlap and fallback behavior.

Both MATERIALS.md and ORGANIZATION.md are updated in all 10 affected chapters.
Current coverage and pedagogy precede retained historical planning records.

## Preservation and review

- All 414 original cells in these readings remain identified by their original
  IDs. All 45 original executable cells, including metadata and outputs, remain
  unchanged.
- All 124 assignment notebooks are byte-identical to the task baseline.
- Eight existing Markdown cells receive documented corrections: array syntax,
  malformed figure/default/LINQ markup and an incorrect numerical result,
  an inaccurate foreach limitation, or stale chapter references. Their exact
  before/after sources are recorded in `source_corrections.json`. All original
  example and exercise topics/variants remain; corrected source is not claimed
  to be byte-identical prose.
- The earlier section-reorganization preservation check follows this exact
  correction ledger and still accounts for 2,425 original nonempty lesson
  cells and all 554 original lesson code cells. This is preservation evidence,
  not a fresh execution claim for retained code.
- The review page includes all 15 full source diffs in readable full-width
  panels, with before/after counts. `baseline.json` preserves the task baseline.

## Verification

All 22 added code examples independently compile/run under .NET 10 with
nullable analysis enabled, implicit usings disabled and warnings as errors.
Their stdout matches independently specified expectations, and the verified
output is saved in each notebook. Fixed valid-input teaching cores state their
limited contract; complete validated APIs are retained in the original examples.

The local C# lexer now recognizes nullable directives, without changing the
examples or compiler behavior. All 22 new sources lex without error tokens.
Notebook, preservation, local-link/render and build results are recorded in
`verification_summary.json`, `preservation_check.json`, `code_verification.json`
and `render_verification.json`.

This pass does not freshly run every retained code cell, certify the hosted
runner, real VS Code debugger interaction or slide alignment, or claim a
complete eight-pass audit and assignment coverage certification.

## Reproduce

- `.venv/bin/python scripts/verify_priority_development.py`
- `.venv/bin/python scripts/verify_priority_development.py --code`
- `.venv/bin/python scripts/verify_section_revision.py`
- `.venv/bin/python scripts/audit_content_size.py`
- `.venv/bin/python scripts/build_priority_development_review.py`
- `.venv/bin/jupyter-book build . --all --path-output /tmp/cscs-section-revision`

The local review is served at
http://127.0.0.1:8800/priority_development_review.html.
The earlier count/development review remains an audit snapshot, rather than
being presented as a post-repair adequacy judgment.
