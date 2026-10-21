---
orphan: true
---

# Chapter Materials — Advanced Algorithms

## Assignment Alignment Revision (2026-10-21)

Preview now has native radio controls, hints, specific explanations, and varied display positions under unchanged numbered slots/cell IDs. Homework True/False choices have native controls and a balanced applied character-policy case. Visible submission guidance distinguishes page choices from a recorded course submission.

## Assignment Alignment Follow-up (2026-10-21)

The landing adds an explicit prior-graph synthesis objective and identifies Chapter 20 BFS/path and DFS/component review readings for the service-network assignments. Graph client-check starters now include visible GraphWalk support, with no dependence on a hidden answer. Preview questions one through five now sample direct matching, ordinal text units, prepared-prefix reuse, witness validity, and unknown resource-limited results; existing cell/question positions remain. The new matching/limits core remains three readings, with graph work explicitly identified as prerequisite synthesis.

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `2601_shortest_paths_strings.ipynb` | Direct String Matching and Result Contracts | Core content |
| `2602_prefix_matching.ipynb` | Prefix Reuse and KMP | Core content |
| `2603_limits_project.ipynb` | Algorithms and Computational Limits | Core content |

Three core readings remain: direct matching, prepared-prefix/KMP matching, then computational limits. The complete graph objective block is in 2404; traversal verification is the closing section of 2004 and the former page redirects there. Landing framing, objectives, glossary and Chapter Flow now match strings/limits. The existing graph video is retained and clearly captioned as prerequisite review for service-network assignments. All newly developed direct/KMP examples remain.

No assessment identity, assignment notebook, worked code, output or exercise variant is removed. `authoring/integration_cleanup/` records the original cells, exact edits, moves and URL/fragment compatibility.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Current Priority-Section Coverage (2026-10-17)

This coverage update describes the current notebooks and supersedes older pre-reorganization filename summaries below. Historical plans and verification records are retained.

| Reading | Developed content-section coverage |
| --- | --- |
| `2601_shortest_paths_strings.ipynb` | Trace candidate/character indexes in a complete direct matcher and guide overlap, empty and missing-result variations. |
| `2602_prefix_matching.ipynb` | Derive prefix fallback links and annotate KMP scanning/overlap with a compact executable matcher and guided repeated-symbol trace. |

Keep direct matching, prefix/KMP matching and computational limits. Traversal verification is now in Chapter 20. Develop direct candidate/offset reasoning before prefix construction, fallback and overlapping scan events. Retain graph objective reminders as a cross-chapter comparison.

All original lesson cells remain, except the explicitly documented presentation/syntax/result corrections and stale chapter references in `authoring/priority_development/source_corrections.json`. Original assignment notebooks and exercise IDs remain untouched. Full standalone code is retained beside the new smaller teaching cores; newly added code verification is recorded separately from historical checks.


## Sequence and Coverage

- `2600_advanced_graphs_strings_limits.ipynb`: objectives, glossary, navigation, and deferred slides.
- `2601_graph_traversal.ipynb`: BFS/DFS verification contracts, weighted versus hop-count paths, and direction/component boundaries; complete traversal instruction and implementations are in Chapter 20.
- `2601_shortest_paths_strings.ipynb`: hop/cost counterexample, complete ordinal direct and KMP matching, overlapping/empty patterns, proper-border proof, reusable owned prefix tables, actual comparison counts, UTF-16 offsets, and complete workload costs.
- `2603_limits_project.ipynb`: exact BigInteger growth models, verified greedy-cover counterexample and exhaustive optimum, feasibility versus quality guarantees, safe count pruning, boundary witnesses, and final comparison guidance using the existing capstone track.
- Assignments: ten-question preview; five connected service-network/message/coverage lab tasks; five applied true/false and five transfer coding homework tasks. Starters and hidden solutions are independent; solutions retain verified stdout.
- `demos/26_advanced_graphs_strings_limits/AdvancedChecks.cs` and README: complete implementations and independent reference checks.

## Contracts and Scope

Graphs use ordinal labels, explicit isolates, preserved neighbor order, normalized duplicate neighbors, and allowed self-loops/cycles. Constructor validation rejects unknown endpoints and owns cloned adjacency. BFS/DFS reject unknown sources; unreachable paths are empty and source paths singleton. Undirected components reject asymmetric adjacency. Directed strongly connected components are outside this pass.

Matchers compare exact UTF-16 code units and return all overlapping starts; empty patterns match every boundary. Null arguments are rejected; prefix arrays are owned and exposed as copies. Counts include equality tests, mismatches, and separate preparation. Library behavior and comparison guidance were checked against official Microsoft documentation, linked in lesson footnotes.

Team coverage uses up to 20 requirement bits, positional teams, deterministic greedy gain ties, and an exact teaching search capped at 20 teams. Incomplete coverage is reported separately from minimum count; an input-limit exception is not infeasibility. No general approximation ratio or complexity-class theorem is asserted. The final comparison remains guidance for the existing VS Code/GitHub project track. Slides are deferred to Press: student HTML/PDF and instructor-only PPTX.

## Verification — 2026-10-05

All 25 completed notebook cells compiled and ran independently without compiler warnings; 13 hidden answers retain verified stdout. All 24 embedded implementation copies match the verified downloadable classes. Independent checks passed 500 directed traversal cases, 500 undirected component cases, 2,000 ordinal matching cases, and 500 coverage optima, plus ownership/input/boundary checks. The full-book HTML build passed with five existing warnings outside Chapter 26. Six browser Runs passed: source/reachable/unreachable BFS paths with unknown-target rejection, frame DFS entry/exit, overlapping/empty KMP matches, preparation-plus-scan counts and UTF-16 offsets, the exact/greedy cover counterexample, and the final connected lab recommendation. The lab validates full coverage before comparing three greedy teams with two exact teams.

## Foundation Placement (2026-10-07)

Basic graph traversal now belongs to Chapter 20. `2601_graph_traversal.ipynb` retains its published URL and develops verification contracts; string algorithms, limits, and the network integration lab remain here.

## Section-Boundary Coverage Disposition (2026-10-17)

**Reviewed plan, now implemented:** Reframe around string algorithms and limits. The disposition below records the preimplementation baseline and rationale. See Implemented Reading Organization for the current reading files. Counts in this baseline exclude fenced code from prose; the refreshed inventory is in authoring/content_size/. They flag review needs, not quality scores.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `2601_graph_traversal.ipynb`: Traversal Verification | Supporting reading | 224 | 8 | 0 |
| `2601_shortest_paths_strings.ipynb`: Shortest Paths and String Matching | Core content | 687 | 21 | 7 |
| `2603_limits_project.ipynb`: Algorithms and Computational Limits | Core content | 718 | 21 | 5 |

### Source-to-Destination Plan

| Existing source | Proposed treatment and coverage to preserve |
| --- | --- |
| `2601` | Keep traversal verification as supporting reading and incorporate its distinct checks in Chapter 20. Preserve the published page and final network-lab connections. |
| `2602` | Split direct ordinal matching/overlap/empty-pattern contracts from proper borders, prefix preparation, fallback and KMP work counts. Retain the hop/cost contrast as a linked reminder to Chapters 20 and 24, not a separate required algorithm lesson. |
| `2603` | Retain limits/heuristics/exact-witness verification and final comparison guidance. Project requirements remain in the established appendix/project track. |

### Development Needed Before Moving Material

Develop character-by-character direct/prefix/fallback traces, explain text units and full preparation/output costs, and expand feasibility versus guarantee reasoning. Retain the exact cover counterexample and all boundary witnesses.

Before a later move, create a cell-level preservation map for these sources, including citations, figures, original code forms, worked traces, guided questions and independent exercise variants. Relocate prerequisite explanations from assignments into content when needed while retaining application requirements and IDs. A consolidated page must still teach its concepts; a split must not create two unsupported outlines. Existing runnable verification records describe earlier work, not verification of this proposal.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `2601_shortest_paths_strings.ipynb`: Direct String Matching and Result Contracts.
- `2602_prefix_matching.ipynb`: Prefix Reuse and KMP.
- `2603_limits_project.ipynb`: Algorithms and Computational Limits.
- `2601_graph_traversal.ipynb`: Traversal Verification.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.

## Mistakes and Interpretation Pass (2026-10-18)

Pass 5 of the content-development audit (`authoring/content_development_audit/`), all three pages: mistakes beside the examples (skipping overlapping matches, int shifts for 2^40, feasible read as optimal, timing before validating, improper borders, resetting q after a match, the off-by-one fallback index, moving the text backward, scan counts without preparation) and interpretation after the exercise solutions. Every demonstration cell on these pages was rerun and the interpretations quote the actual output. No code cell, heading, cell ID, or exercise ID changed.

## OpenDSA Gap List and Development (2026-10-19)

Pass 8 (`authoring/content_development_audit/pass8_cs2_opendsa_development.md`): OpenDSA CS2 and CS3 contain no string-matching or computational-limits module (both live in the CS4104 book), so this chapter borrowed exercise types and the CS3 analysis habits (best and worst case inputs, problem versus algorithm bounds from 4.9 Analyzing Problems and 8.16 Lower Bounds) rather than specific sections. Gaps found and where they are now developed:

| Gap | Model | Where it is now developed |
| --- | --- | --- |
| Which inputs reach the O(nm) worst case and how typical text behaves | CS3 4.4 Best, Worst, and Average Cases | 26.1 Count the Work of Direct Matching (new, measured on three text kinds) |
| Per-start comparison trace; inner-loop completion | CS2 7.8 tracing families | 26.1 Code Tracing: Comparisons per Start; Code Completion: The Inner Comparison Loop |
| Prefix-table construction trace with fallbacks; fallback completion | (exercise types) | 26.2 Code Tracing: Build the Prefix Table; Code Completion: Fall Back Without Rereading Text |
| Tractable, NP-complete, and undecidable problems as classes; quick verification; pseudo-polynomial tables | CS3 4.9 problem bounds, 8.16 lower bounds | 26.3 Classes of Difficulty (new table) and Concept Check: Place Each Request |
| Summary questions | CS3 chapter summaries | Check Your Understanding on every page |

Every new cell compiled and ran under .NET 10 with stored output; no existing cell, heading, exercise ID, or footnote was removed; no OpenDSA text, code, or figure was copied.

## Demo folder rename (2026-10-19)

The chapter's demo source moved from the former two-digit folder `26/` to `demos/26_advanced_graphs_strings_limits/`, the same folder name as this chapter, so a cloned repository opened in VS Code shows the book's chapter names. The notebook download and link paths in this chapter were updated to the new folder; no cell content, heading, cell id, or exercise ID changed.
