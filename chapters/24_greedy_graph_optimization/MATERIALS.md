---
orphan: true
---

# Chapter Materials — Greedy Algorithms

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `2401_greedy_choice.ipynb` | Greedy Choices and Exchange Reasoning | Core content |
| `2402_spanning_trees_shortest_paths.ipynb` | Minimum Spanning Forests and Kruskal | Core content |
| `2404_shortest_paths.ipynb` | Shortest Paths and Dijkstra | Core content |

The complete minimum-hops/minimum-cost graph counterexample from 2602 now appears with Dijkstra and the network-versus-route comparison in 2404. Preserve its original executable program, output and objective explanation. Kruskal and the newly developed union-find walkthrough remain in 2402.

No assessment identity, assignment notebook, worked code, output or exercise variant is removed. `authoring/integration_cleanup/` records the original cells, exact edits, moves and URL/fragment compatibility.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Current Priority-Section Coverage (2026-10-17)

This coverage update describes the current notebooks and supersedes older pre-reorganization filename summaries below. Historical plans and verification records are retained.

| Reading | Developed content-section coverage |
| --- | --- |
| `2402_spanning_trees_shortest_paths.ipynb` | Teach union-find roots and size policy with a concrete Kruskal edge table, cut exchange and guided disconnected forest. |

Keep greedy choices, minimum spanning forests and Dijkstra as the three current content readings. Introduce union-find roots/size separately from chosen graph edges before the complete Kruskal program.

All original lesson cells remain, except the explicitly documented presentation/syntax/result corrections and stale chapter references in `authoring/priority_development/source_corrections.json`. Original assignment notebooks and exercise IDs remain untouched. Full standalone code is retained beside the new smaller teaching cores; newly added code verification is recorded separately from historical checks.


## Sequence and Coverage

- `2400_greedy_graph_optimization.ipynb`: objectives, chapter navigation, glossary, and deferred slides.
- `2401_greedy_choice.ipynb`: half-open interval contracts, accepted/rejected traces, exchange proof, weighted-value and coin-count counterexamples, boundary exercise.
- `2402_spanning_trees_shortest_paths.ipynb`: explicit graph contracts, balanced union-find and Kruskal forests, cut exchange argument, Dijkstra settling and stale priorities, nullable wide distances, and guarded path reconstruction.
- `2403_optimization_lab.ipynb`: exhaustive scheduling reference, forest invariants, independently checked path costs, boundary cases, and objective selection.
- Assignments: ten-question preview; five connected facilities lab tasks; five applied true/false and five transfer coding homework tasks. Coding questions have independent starter cells and hidden runnable solutions with verified stdout.
- `demos/24/GreedyChecks.cs`: downloadable complete implementations and independent reference checks; accompanying README gives console commands.

## Contracts and Scope

Meetings have unique IDs and positive duration; touching endpoints are compatible. Scheduling maximizes count, not value. Graphs declare all vertices, including isolates; parallel edges are allowed and loops rejected. Kruskal accepts signed weights and returns a minimum spanning forest with an explicit component count. Dijkstra uses directed nonnegative arcs, rejects negative arcs even in unreachable components, and uses nullable `long` distances with checked addition. An unreachable path is empty; the source path contains the source. Returned distance and predecessor maps are read-only.

The chapter builds on graph representations and traversal (20), priority queues (18), elementary costs (13), and recursive foundations (17). Formal analysis is optional depth in Chapter 21. Dynamic programming follows in Chapter 25. Slides remain deferred to Press: student HTML/PDF and instructor-only PPTX.

## Verification — 2026-10-05

All 26 completed notebook code cells compiled and ran independently. Downloadable checks passed 300 exhaustive schedule cases, 300 exhaustive minimum-forest cases, and 300 independent distance/path cases, plus explicit boundary and invalid-input checks. Every embedded implementation matches the verified source. Full-book HTML build passed with five existing warnings outside Chapter 24. Browser checks cover both greedy counterexamples, stale priorities, wide distances and negative-arc rejection, signed parallel-edge forests, and the final facilities lab. The browser also exposed a task-ID length defect; `_static/execution.js` now preserves short IDs and bounds long IDs to the runner’s 64-character contract with a stable suffix. Actual long paths, shared prefixes, length boundaries, and Unicode paths passed contract checks.

## Section-Boundary Coverage Disposition (2026-10-17)

**Reviewed plan, now implemented:** Split spanning forests from shortest paths; distribute verification. The disposition below records the preimplementation baseline and rationale. See Implemented Reading Organization for the current reading files. Counts in this baseline exclude fenced code from prose; the refreshed inventory is in authoring/content_size/. They flag review needs, not quality scores.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `2401_greedy_choice.ipynb`: Greedy Choice and Correctness | Core content | 546 | 21 | 6 |
| `2402_spanning_trees_shortest_paths.ipynb`: Spanning Trees and Shortest Paths | Core content | 853 | 24 | 7 |
| `2403_optimization_lab.ipynb`: Greedy Optimization Lab | Core content | 389 | 19 | 6 |

### Source-to-Destination Plan

| Existing source | Proposed treatment and coverage to preserve |
| --- | --- |
| `2401` | Retain scheduling/exchange argument and greedy counterexamples; incorporate objective checks from 2403. |
| `2402` | Split before Dijkstra: MST/forest, union-find and cut reasoning form one lesson; relaxation, settling, stale priorities, paths and costs form another. Retain the network-versus-route counterexample as the bridge/closing comparison. |
| `2403` | Distribute schedule/forest/path verification and boundary cases into their content lessons; preserve the full facilities comparison and exercise as final synthesis, not removal. |

### Development Needed Before Moving Material

Develop stepwise union/find and relaxation/queue traces, why each greedy choice is safe, and independent witness checks. Word count is low even though topic load is high.

Before a later move, create a cell-level preservation map for these sources, including citations, figures, original code forms, worked traces, guided questions and independent exercise variants. Relocate prerequisite explanations from assignments into content when needed while retaining application requirements and IDs. A consolidated page must still teach its concepts; a split must not create two unsupported outlines. Existing runnable verification records describe earlier work, not verification of this proposal.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `2401_greedy_choice.ipynb`: Greedy Choices and Exchange Reasoning.
- `2402_spanning_trees_shortest_paths.ipynb`: Minimum Spanning Forests and Kruskal.
- `2404_shortest_paths.ipynb`: Shortest Paths and Dijkstra.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.
