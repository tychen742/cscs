# Section reorganization and teaching development

Implemented locally on October 17, 2026. Not deployed.

The 26-chapter sequence remains. The reviewed combine/split/retain decisions
are implemented in `_toc.yml`, the chapter planning files, landing flows,
Chapter Topics and navigation labels. Published content readings change from
88 to 93: 83 core reading groups and ten supporting readings. Reading pages
are independent of class-meeting counts.

## Teaching changes

Fifty-four readings receive original topic-specific development: conceptual
connections, worked decision/state tables, execution/proof reasoning, boundary
cases, common mistakes, and guided variations. Examples include conversion
order, selection alternatives, method contracts, array processing, validation
versus exceptions, debugger evidence, ADT histories, heap repairs, set
reconciliation, graph frontiers, correctness arguments, recurrence models,
greedy exchanges, complete DP states, backtracking and KMP fallback.

The size inventory records approximately 21,000 additional prose words. Counts
are screening evidence, not an adequacy score. Some cell-count growth comes
from placing headings in separate indexed cells. The two readings still below
500 prose words are supporting nullability and traversal-verification references;
their core concepts are developed in the relevant primary lessons.

## Preservation

`baseline.json` records the original working-tree cell sources, outputs and
metadata, including the already authorized Chapter 5 work. `toc_before.yml`
records its reading order. `scripts/verify_section_revision.py` checks:

- All 2,425 original nonempty active lesson cells remain accounted for across
  the revised readings, including all 554 original lesson code cells.
- Original executable source text is retained. The full numbered-chapter tree
  still contains all 1,082 original code-cell sources, including assignments
  and source/support banks; this is a preservation count, not a compile claim.
- Four content titles named Lab are renamed; their bodies remain.
- Footnote definitions may move away from narrative in the same original cell.
  The check normalizes heading/index/rubric markup, footnote names and updated
  section references, and verifies original paragraph fragments where needed.
- Assignment cells, metadata, IDs, code and outputs are retained. Only Methods
  lab section-number references need correction; question content is unchanged.
- All 26 landing pages retain their original non-flow orientation, including
  titles, introductions, videos, objectives and glossary. Only the reading-flow
  region is regenerated, with supporting readings identified.

The full GCD lesson, unit-testing walkthrough, Averager and original OOP
variations remain available. The thinkcscs.org reference repository is untouched.

## Verification

- All 93 active content notebooks validate against nbformat. C# rendering/kernel
  metadata is aligned; invalid code-only fields on legacy Markdown cells are
  removed without removing their source text.
- All six new runnable examples compile/run independently under .NET 10 with
  implicit usings disabled, nullable analysis enabled and warnings treated as
  errors. Independently expected output matches; saved outputs remain.
- Existing retained code is checked for preservation. This pass does not claim
  a fresh compile/run of every retained code cell or certify the live hosted
  runner. Earlier verification records remain historical evidence.
- Local links/assets in all 93 article pages resolve. All 120 moved-heading and
  explicit-label routes have rendered destinations. Five merged-page redirects
  preserve fragments; split/merged routes preserve query parameters.
- JavaScript syntax checks and isolated redirect-generation/routing checks pass.
  Browser navigation verifies an old Types link reaches the new Types reading,
  and an old workload-fragment link reaches the retained report explanation.
- Browser inspection checks the developed debugging trace and existing styled,
  concise sidebar navigation. Each content section ends with a Footnotes group.
- Jupyter Book builds successfully. A full read reports the two existing C#
  highlighting warnings involving the character example and `#nullable`;
  subsequent incremental builds need not repeat cached warnings. No new
  duplicate-label or missing-document warning remains.
- Whitespace checks pass.

Lecture-slide alignment and live runner certification remain outside this pass.
No deployment or public-site change is performed.

## Review and reproduction

- Preview: `http://127.0.0.1:8800/section_revision_review.html`.
- Online comparisons: `SOURCES.md`, also linked in the preview.
- Current counts: `authoring/content_size/`.
- Source verification: `.venv/bin/python scripts/verify_section_revision.py`.
- Counts: `.venv/bin/python scripts/audit_content_size.py`.
- Local review: `.venv/bin/python scripts/build_section_revision_review.py`.
- Build: `.venv/bin/jupyter-book build . --path-output /tmp/cscs-section-revision`.

Review generation expects that build location. Recount and regenerate the review
after future changes. The baseline and audit records intentionally describe the
preimplementation version rather than being overwritten with the final source.
