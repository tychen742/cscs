---
orphan: true
---

# Chapter Materials — Advanced Algorithms

## Sequence and Coverage

- `2500-advanced-graphs-strings-limits.ipynb`: objectives, glossary, navigation, and deferred slides.
- `2501-graph-traversal.ipynb`: owned adjacency snapshots, discovery-time BFS layers and minimum-hop proof, guarded source/unreachable paths, recursive-order DFS frames and entry/exit traces, symmetry-checked undirected components, and qualified adjacency/matrix costs.
- `2502-shortest-paths-strings.ipynb`: hop/cost counterexample, complete ordinal direct and KMP matching, overlapping/empty patterns, proper-border proof, reusable owned prefix tables, actual comparison counts, UTF-16 offsets, and complete workload costs.
- `2503-limits-project.ipynb`: exact BigInteger growth models, verified greedy-cover counterexample and exhaustive optimum, feasibility versus quality guarantees, safe count pruning, boundary witnesses, and final comparison guidance using the existing capstone track.
- Assignments: ten-question preview; five connected service-network/message/coverage lab tasks; five applied true/false and five transfer coding homework tasks. Starters and hidden solutions are independent; solutions retain verified stdout.
- `materials/25/AdvancedChecks.cs` and README: complete implementations and independent reference checks.

## Contracts and Scope

Graphs use ordinal labels, explicit isolates, preserved neighbor order, normalized duplicate neighbors, and allowed self-loops/cycles. Constructor validation rejects unknown endpoints and owns cloned adjacency. BFS/DFS reject unknown sources; unreachable paths are empty and source paths singleton. Undirected components reject asymmetric adjacency. Directed strongly connected components are outside this pass.

Matchers compare exact UTF-16 code units and return all overlapping starts; empty patterns match every boundary. Null arguments are rejected; prefix arrays are owned and exposed as copies. Counts include equality tests, mismatches, and separate preparation. Library behavior and comparison guidance were checked against official Microsoft documentation, linked in lesson footnotes.

Team coverage uses up to 20 requirement bits, positional teams, deterministic greedy gain ties, and an exact teaching search capped at 20 teams. Incomplete coverage is reported separately from minimum count; an input-limit exception is not infeasibility. No general approximation ratio or complexity-class theorem is asserted. The final comparison remains guidance for the existing VS Code/GitHub project track. Slides are deferred to Press: student HTML/PDF and instructor-only PPTX.

## Verification — 2026-10-05

All 25 completed notebook cells compiled and ran independently without compiler warnings; 13 hidden answers retain verified stdout. All 24 embedded implementation copies match the verified downloadable classes. Independent checks passed 500 directed traversal cases, 500 undirected component cases, 2,000 ordinal matching cases, and 500 coverage optima, plus ownership/input/boundary checks. The full-book HTML build passed with five existing warnings outside Chapter 25. Six browser Runs passed: source/reachable/unreachable BFS paths with unknown-target rejection, frame DFS entry/exit, overlapping/empty KMP matches, preparation-plus-scan counts and UTF-16 offsets, the exact/greedy cover counterexample, and the final connected lab recommendation. The lab validates full coverage before comparing three greedy teams with two exact teams.
