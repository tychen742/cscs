# Integration cleanup and prerequisite placement

Local work, not deployed. This pass implements the mechanical integration
cleanup and the Chapter 2, 16 and 26 moves, retaining the recent teaching
improvements and all explanation/exercise variants.

## Current arrangement

- Chapter 2 keeps four readings. Types and conversion precede the developed
  conversion/display applications. All input-casting examples are with that
  foundation. Single-value input/output stays in Chapter 2; the complete
  loop-generated table/formatting sequence is in Chapter 4 after loop syntax.
- Chapter 16 keeps two readings. Searching has a short preparation bridge;
  sorting owns reporting snapshots, sort-a-copy code and preparation/update
  workload explanations after teaching the required sorting operation.
- Chapter 26 keeps three core readings: direct matching, prefix/KMP matching
  and computational limits. The entire minimum-hop/minimum-cost block and
  executable graph counterexample are in Chapter 24. Traversal verification
  closes Chapter 20's DFS/components reading. Its old page redirects there.
- The Chapter 26 landing framing, objectives, glossary, Chapter Flow and
  Chapter Topics match the new role. The existing video remains, identified
  as graph-prerequisite review. Graph verification objectives/definitions
  remain in Chapter 20 orientation.
- Supporting roles for regex, privacy, nullability and advanced sorts are
  explicit in the TOC. Developed pages are not recombined based on word count.

## Merge cleanup

Every active content page has one local contents directive and one final
Footnotes group. Obsolete wrapper headings are replaced by local anchors;
explicit named references attach to titled sections. Duplicate practice
headings receive task-specific titles. Move-provenance notices become useful
instructional transitions. Body material, including the full retained testing
walkthrough and infinite-loop discussion, precedes Footnotes. The BST summary
follows its library-choice discussion. Historical commented source banks remain
preserved rather than silently deleted or presented as newly verified tooling.

The current arrangements appear first in 42 MATERIALS.md/ORGANIZATION.md files
across 21 affected chapters. Historical plans remain labeled as historical.

## Preservation and verification

The baseline records 3,917 cells across content, landing and Chapter Topics
notebooks. The current cell map accounts for them all: 3,849 retained cells
and 68 consolidated empty/navigation/rubric cells. All 582 original executable
cells retain source, metadata and saved output, with only destination ID
collision handling permitted. All 124 assignment notebooks are byte-identical.
Paragraph-fragment checks find no missing instructional explanations. Exact
source/heading edits and every relocation are recorded, with full source diffs.

All 10 moved executable cells compile/run independently and pass expected-result
checks. The original input example retains nullable-flow warnings; code is not
silently repaired during relocation. All 22 recently developed examples remain.
Earlier preservation checks reconstruct their prior arrangement only after
checking exact current cell/source lineage; the current arrangement is checked
separately by verify_integration_cleanup.py.

All 92 rendered content articles resolve their local links/assets. All 162
fragment-route destinations exist; five runtime route checks preserve queries.
The old traversal page redirects to Chapter 20. Full-book build verification
found a named-reference title issue after wrapper removal; its labels now attach
to real titles, and the final build passes. The existing Chapter 2 character
highlighting warning remains on a full read. No new missing-reference or
integration warning remains.

This pass does not freshly run every retained example, certify the hosted runner,
real debugger interaction or slides, or claim a complete content adequacy audit.

## Review and reproduction

- Review: http://127.0.0.1:8800/integration_cleanup_review.html
- Preservation: `.venv/bin/python scripts/verify_integration_cleanup.py`
- Relocated code: `.venv/bin/python scripts/verify_integration_moved_code.py`
- Earlier lineage: `.venv/bin/python scripts/verify_priority_development.py`
  and `.venv/bin/python scripts/verify_section_revision.py`
- Counts: `.venv/bin/python scripts/audit_content_size.py`
- Source review: `.venv/bin/python scripts/build_integration_review.py`
- Build: `.venv/bin/jupyter-book build . --path-output /tmp/cscs-section-revision`
