---
orphan: true
---

# Chapter Materials — Greedy Algorithms

## Sequence and Coverage

- `2300-greedy-graph-optimization.ipynb`: objectives, chapter navigation, glossary, and deferred slides.
- `2301-greedy-choice.ipynb`: half-open interval contracts, accepted/rejected traces, exchange proof, weighted-value and coin-count counterexamples, boundary exercise.
- `2302-spanning-trees-shortest-paths.ipynb`: explicit graph contracts, balanced union-find and Kruskal forests, cut exchange argument, Dijkstra settling and stale priorities, nullable wide distances, and guarded path reconstruction.
- `2303-optimization-lab.ipynb`: exhaustive scheduling reference, forest invariants, independently checked path costs, boundary cases, and objective selection.
- Assignments: ten-question preview; five connected facilities lab tasks; five applied true/false and five transfer coding homework tasks. Coding questions have independent starter cells and hidden runnable solutions with verified stdout.
- `materials/23/GreedyChecks.cs`: downloadable complete implementations and independent reference checks; accompanying README gives console commands.

## Contracts and Scope

Meetings have unique IDs and positive duration; touching endpoints are compatible. Scheduling maximizes count, not value. Graphs declare all vertices, including isolates; parallel edges are allowed and loops rejected. Kruskal accepts signed weights and returns a minimum spanning forest with an explicit component count. Dijkstra uses directed nonnegative arcs, rejects negative arcs even in unreachable components, and uses nullable `long` distances with checked addition. An unreachable path is empty; the source path contains the source. Returned distance and predecessor maps are read-only.

The chapter builds on graph representations (19), priority queues (18), analysis (20), and recursion (21). Dynamic programming belongs to 24; broader graph traversal belongs to 25. Slides remain deferred to Press: student HTML/PDF and instructor-only PPTX.

## Verification — 2026-10-05

All 26 completed notebook code cells compiled and ran independently. Downloadable checks passed 300 exhaustive schedule cases, 300 exhaustive minimum-forest cases, and 300 independent distance/path cases, plus explicit boundary and invalid-input checks. Every embedded implementation matches the verified source. Full-book HTML build passed with five existing warnings outside Chapter 23. Browser checks cover both greedy counterexamples, stale priorities, wide distances and negative-arc rejection, signed parallel-edge forests, and the final facilities lab. The browser also exposed a task-ID length defect; `_static/execution.js` now preserves short IDs and bounds long IDs to the runner’s 64-character contract with a stable suffix. Actual long paths, shared prefixes, length boundaries, and Unicode paths passed contract checks.
