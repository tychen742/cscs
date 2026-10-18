---
orphan: true
---

# Chapter Organization — Advanced Algorithms

## Teaching Plan — 110 Minutes

1. Graph traversal (40 minutes): define graph contracts, prove discovery layers, reconstruct guarded paths, trace suspended DFS frames, and distinguish directed reachability from symmetric undirected components.
2. Paths and string matching (40 minutes): distinguish hop and weight objectives, establish matching policies, derive proper borders and fallback invariants, prove linear comparison work, and include preparation and result storage.
3. Computational limits and synthesis (30 minutes): compare exact growth models, validate a greedy quality counterexample against an exact optimum, distinguish feasibility and guarantees, and develop a reviewable final comparison.

## Assignment Progression

Preview introduces discovery, frames, matching policies, borders, and quality guarantees. The lab follows one service review through BFS layers, DFS reachability and BFS paths, message matching, repeated-pattern workload counts, and team coverage quality. Homework transfers cycle/snapshot boundaries, component preconditions, empty/overlapping/ordinal matches, exact comparison counts, and impossible/oversized coverage inputs with exact growth arithmetic.

## Coverage Boundary

This final chapter synthesizes earlier graph representations, queues/stacks, analysis, greedy correctness, and state-based search. Keep weighted shortest-path implementation in Chapter 24; use a concrete objective counterexample here. KMP supplies a complete algorithm rather than a catalog of text methods. Limits distinguish model estimates from benchmarks and implementation costs from problem lower bounds. Durable final project submissions remain in the established appendix/project track; slides remain a deferred Press task.

## Foundation Placement (2026-10-07)

Basic graph traversal now belongs to Chapter 20. `2601_graph_traversal.ipynb` retains its published URL and develops verification contracts; string algorithms, limits, and the network integration lab remain here.

The earlier lecture allocation is superseded where it repeats relocated introductory topics. Use that time for contract counterexamples, verification traces, and the chapter’s optional advanced applications. Students complete Chapters 14, 16, and 19 foundations first as relevant.

## Section-Boundary Review (2026-10-17)

**Status: implemented.** The following records the reviewed recommendation and its baseline. See Implemented Reading Organization below for the final current filenames and order; earlier meeting allocations are historical where they conflict.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `2601_graph_traversal.ipynb`: Traversal Verification | Supporting reading | 224 | 8 | 0 |
| `2602_shortest_paths_strings.ipynb`: Shortest Paths and String Matching | Core content | 687 | 21 | 7 |
| `2603_limits_project.ipynb`: Algorithms and Computational Limits | Core content | 718 | 21 | 5 |

**Recommendation:** Reframe around string algorithms and limits.

The 224-word traversal page is already a verification extension of Chapter 20. The other page combines a graph-objective reminder with direct matching and KMP, whose prefix/fallback reasoning warrants its own development.

### Proposed Reading Sequence

1. Direct string matching and result contracts.
2. Prefix reuse, KMP, and complete workload costs.
3. Computational limits, guarantees, and synthesis.

### Adequacy Before Reorganization

Develop character-by-character direct/prefix/fallback traces, explain text units and full preparation/output costs, and expand feasibility versus guarantee reasoning. Retain the exact cover counterexample and all boundary witnesses.

Retain the supporting readings identified above outside the required core. Reading sections and class meetings are different units; allocate discussion and practice after developing adequate explanations. Do not reduce distinct material to meet a section or word quota.

Preserve every existing explanation, exercise variation and assessment identity. The source-to-destination dispositions in MATERIALS.md govern any later move. Update TOC, links and redirects only in an authorized implementation pass.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `2602_shortest_paths_strings.ipynb`: Direct String Matching and Result Contracts.
- `2604_prefix_matching.ipynb`: Prefix Reuse and KMP.
- `2603_limits_project.ipynb`: Algorithms and Computational Limits.
- `2601_graph_traversal.ipynb`: Traversal Verification.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.
