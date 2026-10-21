---
orphan: true
---

# Chapter Materials — Dynamic Programming

## Assignment Alignment Revision (2026-10-21)

Preview retains the ten numbered question slots and original cells, adds native radio response controls and specific answer explanations, varies option display order while keeping canonical a-d values, and replaces calculation/tracing preparation with glossary recognition where needed. Homework True/False questions now have native controls, hidden explanatory answers, and visible course-submission guidance. Chapters24-25 include balanced applied cases. Static page choices do not claim to record course attempts; authenticated submission remains the existing course workflow.

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `2501_memoization_tabulation.ipynb` | Memoization, Tabulation, and Repeated Work | Core content |
| `2502_optimization_models.ipynb` | Optimization States and Reconstructed Solutions | Core content |
| `2503_backtracking.ipynb` | Backtracking, Pruning, and Search States | Core content |

Keep the current section boundaries and recently developed content. Consolidate repeated in-page navigation, distinguish repeated practice headings, retain all substantive explanations/examples and finish the instructional material before the final Footnotes group.

No assessment identity, assignment notebook, worked code, output or exercise variant is removed. `authoring/integration_cleanup/` records the original cells, exact edits, moves and URL/fragment compatibility.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Current Priority-Section Coverage (2026-10-17)

This coverage update describes the current notebooks and supersedes older pre-reorganization filename summaries below. Historical plans and verification records are retained.

| Reading | Developed content-section coverage |
| --- | --- |
| `2501_memoization_tabulation.ipynb` | Derive Fibonacci recursion calls and cache hits, compare a fully traced memo with tabulation and guide a recurrence variation. |
| `2502_optimization_models.ipynb` | Fill minimum-pack count/predecessor tables, reconstruct a witness and distinguish zero, unreachable and one-use inventory. |

Keep repeated-work strategies, optimization states and backtracking. Teach cache misses/hits and table dependencies before exact-count claims, then derive minimum-pack updates and predecessor reconstruction before inventory transfer.

All original lesson cells remain, except the explicitly documented presentation/syntax/result corrections and stale chapter references in `authoring/priority_development/source_corrections.json`. Original assignment notebooks and exercise IDs remain untouched. Full standalone code is retained beside the new smaller teaching cores; newly added code verification is recorded separately from historical checks.


## Sequence and Coverage

- `2500_dynamic_programming_backtracking.ipynb`: objectives, glossary, navigation, and deferred slides.
- `2501_memoization_tabulation.ipynb`: complete states, Fibonacci call/cache counts and induction, dependency-order invariants, rolling storage, minimum-coin recurrence and optimal substructure, unreachable markers, predecessor reconstruction, and pseudo-polynomial costs.
- `2503_backtracking.ipynb`: include/exclude completeness, undo and snapshots, signed one-use subset witnesses, safe suffix bounds, failed-state memoization, resource limits, and positional permutations with duplicate labels.
- `2503_optimization_lab.ipynb`: purchasing quantities versus one-use invoices; independent amount-level and exhaustive-position references; validated witnesses; boundary contracts and evidence-based method selection.
- Assignments: ten-question preview; five connected purchasing/reconciliation lab tasks; five applied true/false and five transfer coding homework tasks. Coding starters and hidden solutions are independent; solutions retain verified stdout.
- `demos/25_dynamic_programming_backtracking/PlanningChecks.cs` and README: complete implementations with independent executable reference checks.

## Contracts and Scope

Fibonacci accepts 0..92 and uses checked long arithmetic; naive recursion is capped at 25. Minimum coins accepts unlimited positive denominations (duplicates normalized), targets 0..1,000,000, and null count for unreachable targets. Zero uses an empty valid witness. One-use subset search preserves distinct positions, supports signed int values and long targets, and returns null only for proven infeasibility. It accepts up to 128 positions and an explicit call budget, default one million; exhausting it throws with feasibility unknown. Bounds sum suffix negatives and positives. Enumeration snapshots position arrays; materialized subsets are capped at 16 positions and permutations at eight. Empty input has one empty subset and one empty permutation.

The chapter follows recursion/analysis and greedy counterexamples. Amount-level exploration is used only as a small reference here; systematic BFS/DFS is taught in Chapter 20; broader algorithm limits belong to Chapter 26. Slides remain a deferred Press task: student HTML/PDF and instructor-only PPTX.

## Verification — 2026-10-05

All 26 completed notebook cells compiled and ran independently; 13 hidden answers retain verified stdout. All 30 implementation copies match the downloadable verified classes. Reference checks passed 600 coin instances, 600 signed subset instances (each compared with three search variants), all 93 supported Fibonacci values, positional enumeration cardinality/uniqueness, snapshot independence, and boundary/input/resource guards. The full-book HTML build passed with five existing warnings outside Chapter 25. Six browser Runs passed: naive/memo counts, zero and upper Fibonacci boundary, minimum-coin reconstruction/unreachable quantity, signed wide-sum search with an honest budget limit, duplicate-label positional permutations, and the final lab comparison. The last instance measured 8,191 raw calls, 3,431 with safe bounds, and 85 with memoization; these are instance-specific measurements.

## Section-Boundary Coverage Disposition (2026-10-17)

**Reviewed plan, now implemented:** Split DP foundations from optimization modeling; integrate verification. The disposition below records the preimplementation baseline and rationale. See Implemented Reading Organization for the current reading files. Counts in this baseline exclude fenced code from prose; the refreshed inventory is in authoring/content_size/. They flag review needs, not quality scores.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `2501_memoization_tabulation.ipynb`: Memoization and Tabulation | Core content | 779 | 21 | 6 |
| `2503_backtracking.ipynb`: Backtracking and Search Spaces | Core content | 793 | 21 | 7 |
| `2503_optimization_lab.ipynb`: Dynamic Programming and Backtracking Lab | Core content | 476 | 21 | 6 |

### Source-to-Destination Plan

| Existing source | Proposed treatment and coverage to preserve |
| --- | --- |
| `2501` | Split before Minimum Coins: Fibonacci/cache/table/rolling-state reasoning forms foundations; coin-state recurrence, unreachable states, reconstruction and state-size costs form optimization modeling. |
| `2502` | Retain backtracking/undo/snapshots and signed one-use subset state, safe pruning and memoization; keep positional permutations as a developed application or labeled extension. |
| `2503` | Distribute optimum/witness checks into the corresponding DP/backtracking lessons and preserve inventory comparisons, exhaustive references and final recommendation as synthesis. |

### Development Needed Before Moving Material

Develop tables and decision/reconstruction traces, explain state sufficiency and optimal substructure, and contrast unlimited packs with one-use positions. Preserve every boundary and resource-limit policy.

Before a later move, create a cell-level preservation map for these sources, including citations, figures, original code forms, worked traces, guided questions and independent exercise variants. Relocate prerequisite explanations from assignments into content when needed while retaining application requirements and IDs. A consolidated page must still teach its concepts; a split must not create two unsupported outlines. Existing runnable verification records describe earlier work, not verification of this proposal.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `2501_memoization_tabulation.ipynb`: Memoization, Tabulation, and Repeated Work.
- `2502_optimization_models.ipynb`: Optimization States and Reconstructed Solutions.
- `2503_backtracking.ipynb`: Backtracking, Pruning, and Search States.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.

## Mistakes and Interpretation Pass (2026-10-18)

Pass 5 of the content-development audit (`authoring/content_development_audit/`), all three pages: 15 mistakes beside the examples (incomplete cache keys, backward table fills, comparing counts at different n, the unguarded table[1], storing the shared list, reusing a position, pruning signed values on remaining < 0, caching r alone, not resetting used, reference sharing the search's pruning rule, zero for unreachable, largest-first packs, witness as proof of optimality, deduplicating inventory, re-enqueueing discovered amounts) and interpretation after the exercise and practice solutions. Every demonstration cell on these pages was rerun and the interpretations quote the actual output. No code cell, heading, cell ID, or exercise ID changed.

## OpenDSA References (2026-10-19)

Re-hosted the existing OpenDSA "Further reading" footnote links to `opendsa-server.cs.vt.edu` CS2/CS3 pages, because `opendsa.org`, `opendsa.cs.vt.edu`, and `opendsax.cs.vt.edu` either fail strict fetches or are not the host this book links to. The roles of the OpenDSA books are recorded in `authoring/toc_comparison/README.md` (OpenDSA mapping) and Appendix A. Chapter 25: the three footnotes keep the CS4104 Dynamic Programming module on the new host.

## OpenDSA Gap List and Development (2026-10-19)

Pass 8 (`authoring/content_development_audit/pass8_cs2_opendsa_development.md`): OpenDSA CS2 and CS3 have no dynamic programming or backtracking module (the topic lives in the CS4104 book), so this chapter borrowed exercise types and the explanation habits of the CS3 analysis and recursion chapters rather than specific sections. The two subsections the word-count report flagged under 60 words, 25.1 Memoization and Tabulation and 25.3 Backtracking and Search Spaces, were rewritten as full explanations. Gaps found and where they are now developed:

| Gap | Model | Where it is now developed |
| --- | --- | --- |
| The state, base case, transition, order, result recipe; memoization versus tabulation compared | CS3 3.6 recurrence habits | 25.1 Memoization and Tabulation (was 53 words) |
| Overlapping subproblems and optimal substructure as the test for applicability; contrast with divide-and-conquer and greedy | CS3 4.9 problem analysis | 25.1 Recognize a Dynamic Programming Problem (new) |
| Memoization trace; memoized completion | CS2 7.8 tracing families | 25.1 Code Tracing: Hits and Misses for F(6); Code Completion: Count the Ways to Pay |
| Table trace with unreachable states; witness reconstruction completion | (exercise types) | 25.2 Code Tracing: Fill a Table with Unreachable Amounts; Code Completion: Reconstruct the Witness |
| Backtracking template, search-tree size, pruning kinds, comparison with DP and greedy | CS2 7.4 writing recursive functions | 25.3 Backtracking and Search Spaces (was 47 words) |
| Pruning shown on an assignment search with node counts | (ours) | 25.3 Prune a Search Tree: Assign Staff to Shifts (new, runnable) |
| State-visit trace; undo-step completion | CS2 7.8 | 25.3 Code Tracing: States Visited in Subset Sum; Code Completion: Restore the Shared State |
| Summary questions | CS3 chapter summaries | Check Your Understanding on every page |

Every new cell compiled and ran under .NET 10 with stored output; no existing cell, heading, exercise ID, or footnote was removed; no OpenDSA text, code, or figure was copied.

## Demo folder rename (2026-10-19)

The chapter's demo source moved from the former two-digit folder `25/` to `demos/25_dynamic_programming_backtracking/`, the same folder name as this chapter, so a cloned repository opened in VS Code shows the book's chapter names. The notebook download and link paths in this chapter were updated to the new folder; no cell content, heading, cell id, or exercise ID changed.
