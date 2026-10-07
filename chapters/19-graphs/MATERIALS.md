---
orphan: true
---

# Chapter Materials: Graphs

The three content sections develop vocabulary, adjacency representations, and complete graph updates using campus routes and business workflows. The landing page includes objectives and a glossary. Preview has ten multiple-choice questions; the connected five-task lab builds a route graph, and homework has five true/false and five coding questions. Completed coding answers retain verified stdout.

## Depth Coverage

- Directed and undirected edges, weights, degrees, isolates, walks, paths, cycles, and connectivity.
- Boolean and nullable weighted matrices; zero weight versus absent edge; adjacency collections and workload-sensitive costs.
- Complete RouteGraph with explicit vertices, replacement, reciprocal removal, vertex removal, edge counts, protected snapshots, and invariant checks.
- Matrix export/import and validation, pairwise equivalence, and supplied-walk cost checks.
- Downloadable implementation and reference-model checks in `../../materials/19/RouteGraph.cs`.

## Verification and Deferred Work

25 completed notebook cells compile and run independently. Reference checks cover 600 mixed graph updates and explicit boundaries; transfer checks cover 1,080 conversion pairs, supplied walks, and invalid matrix imports. Slides remain deferred to Press, with student HTML/PDF and instructor-only PPTX. Traversal is now included here; weighted shortest-path algorithms remain in Part V.

## Foundation Placement (2026-10-07)

Moved BFS, predecessor paths, frame DFS, and undirected components into `1904_graph_traversal.ipynb`. The original Chapter 25 URL now provides advanced verification and direction contracts.

`../../materials/19/GraphWalk.cs` provides the standalone traversal demonstration and complete GraphWalk implementation.

## Move Verification (2026-10-07)

The four receiving sections contain 21 completed cells. Each compiled and ran in an isolated namespace with its own setup under .NET 10; completed exercise answers retain captured stdout. Intentional student starters were excluded. The full Jupyter Book build passed with the five previously recorded warnings outside these chapters. New content pages and prerequisite links are included in the TOC and rendered output. Slides remain pending.
