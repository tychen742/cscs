---
orphan: true
---

# Chapter Organization — Greedy Algorithms

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
