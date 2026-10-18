---
orphan: true
---

# Chapter Organization — Greedy Algorithms

## B-A Development Follow-up (2026-10-18)

| Reading | Audit findings | Developed coverage |
| --- | --- | --- |
| `2401_greedy_choice.ipynb` | B06 | Embed MeetingSchedule support in its visible client-check starter; preserve the intended boundary/exchange task and existing answer. |
| `2404_shortest_paths.ipynb` | B06 | Embed GreedyGraph support in both visible starters; distinguish client checks from reimplementing algorithms; preserve wide-distance, invalid-arc and separate facilities-model tasks. |

Keep the current reading order and chapter boundaries. Develop explanation and relevant general syntax before the worked application; interpret output/state and a meaningful variation, then provide a local learner attempt with feedback. Existing labs and homework remain the independent transfer stage; do not move new prerequisite explanations into labs. Optional readings remain optional. The report in `authoring/ba_development_revision/` maps all 18 findings to current evidence and verification.


## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `2401_greedy_choice.ipynb` | Greedy Choices and Exchange Reasoning | Core content |
| `2402_spanning_trees_shortest_paths.ipynb` | Minimum Spanning Forests and Kruskal | Core content |
| `2404_shortest_paths.ipynb` | Shortest Paths and Dijkstra | Core content |

The complete minimum-hops/minimum-cost graph counterexample from 2602 now appears with Dijkstra and the network-versus-route comparison in 2404. Preserve its original executable program, output and objective explanation. Kruskal and the newly developed union-find walkthrough remain in 2402.

Teach the section conceptual framework before detailed application; place syntax prerequisites before reasoning that requires them. Keep the new worked traces and guided checkpoints, followed by existing lab/homework transfer. Reading count does not set a meeting or word quota.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Current B-A Teaching Progression (2026-10-17)

This is the current progression within the existing section order; earlier meeting outlines below are historical where they conflict. Readings are not additional required meetings.

Keep greedy choices, minimum spanning forests and Dijkstra as the three current content readings. Introduce union-find roots/size separately from chosen graph edges before the complete Kruskal program.

| Reading | Developed content-section coverage |
| --- | --- |
| `2402_spanning_trees_shortest_paths.ipynb` | Teach union-find roots and size policy with a concrete Kruskal edge table, cut exchange and guided disconnected forest. |

**Conceptual framework:** motivate the result contract and connect the new operation to prior control flow, state, representation or algorithm ideas.

**Subsection development:** use the new small trace and standalone worked example before the complete retained implementation. Interpret the saved output, vary an assumption and diagnose a plausible mistake. Syntax scaffolds are patterns, not hidden executable prerequisites.

**Practice progression:** Fill the edge/root/budget table; test an isolate, a newly connecting edge and changed costs; justify a cut exchange. Apply forest validity and objective checks in the current facilities lab and homework.

Keep prerequisite explanations in these content sections. Labs apply the explained ideas and may scaffold the task; homework increases transfer. No existing explanation, exercise variation, assignment identity or independent-work requirement is removed to fit a time or word quota.


## Teaching Plan — 110 Minutes

1. Greedy choice and correctness (35 minutes): specify objective and feasibility, trace interval scheduling, exchange the first choice, and disprove inappropriate greedy rules with feasible alternatives.
2. Spanning forests and shortest paths (45 minutes): distinguish global connection cost from route distance; trace union-find and the cut argument; prove settling under nonnegative weights; inspect stale queue entries and reconstruct paths safely.
3. Optimization verification (30 minutes): compare tiny instances with independent references, check forest and path invariants, exercise empty/disconnected/zero/negative/wide-cost boundaries, and choose a model from units and constraints.

## Assignment Progression

Preview establishes objectives and algorithm assumptions. The five-task lab follows one facilities-planning scenario: schedule meetings, change their value objective, connect buildings, route deliveries, and add a zero-cost directed route without changing the cable network. Homework transfers these ideas to touching intervals, parallel and negative cable edges, stale priorities with zero cycles, wide distances and invalid inputs, and a triangle where minimum network cost differs from shortest route cost.

## Coverage Boundary

Keep representations in Chapter 20 and priority-queue mechanics in Chapter 18. This chapter explains why particular greedy choices are safe and how complete implementations honor their contracts. Weighted scheduling and noncanonical coin systems motivate Chapter 25. Chapter 26 extends traversal and algorithm limits. Slides are a deferred Press task.

## Section-Boundary Review (2026-10-17)

**Status: implemented.** The following records the reviewed recommendation and its baseline. See Implemented Reading Organization below for the final current filenames and order; earlier meeting allocations are historical where they conflict.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `2401_greedy_choice.ipynb`: Greedy Choice and Correctness | Core content | 546 | 21 | 6 |
| `2402_spanning_trees_shortest_paths.ipynb`: Spanning Trees and Shortest Paths | Core content | 853 | 24 | 7 |
| `2403_optimization_lab.ipynb`: Greedy Optimization Lab | Core content | 389 | 19 | 6 |

**Recommendation:** Split spanning forests from shortest paths; distribute verification.

2402 combines different optimization objectives, graph contracts, invariants and proofs. The 389-word verification page is better used beside each relevant algorithm plus a final comparison than as an underspecified third meeting.

### Proposed Reading Sequence

1. Greedy choices, objectives, and exchange reasoning.
2. Minimum spanning forests and Kruskal.
3. Single-source shortest paths and Dijkstra.

### Adequacy Before Reorganization

Develop stepwise union/find and relaxation/queue traces, why each greedy choice is safe, and independent witness checks. Word count is low even though topic load is high.

Reading sections and class meetings are different units; allocate discussion and practice after developing adequate explanations. Do not reduce distinct material to meet a section or word quota.

Preserve every existing explanation, exercise variation and assessment identity. The source-to-destination dispositions in MATERIALS.md govern any later move. Update TOC, links and redirects only in an authorized implementation pass.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `2401_greedy_choice.ipynb`: Greedy Choices and Exchange Reasoning.
- `2402_spanning_trees_shortest_paths.ipynb`: Minimum Spanning Forests and Kruskal.
- `2404_shortest_paths.ipynb`: Shortest Paths and Dijkstra.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.

## Mistakes and Interpretation Pass (2026-10-18)

Pass 5 of the content-development audit (`authoring/content_development_audit/`), all three pages: mistakes beside the examples (sorting by start or duration, treating back-to-back as a conflict, keeping earliest-finish for weighted values, exhaustive checks at scale, reading parent links as cables, V-1 as the success test, forest cost as travel cost, one arc per two-way road, relaxing with <=, fabricated one-vertex routes, Kruskal for routing, endpoint-only path checks, rejecting negative weights everywhere) and interpretation after the forest trace, the boundary cells, and the practice solutions. Every demonstration cell on these pages was rerun and the interpretations quote the actual output. No code cell, heading, cell ID, or exercise ID changed.
