---
orphan: true
---

# Chapter Materials — Greedy Algorithms and Graph Optimization

## Sequence

- `2200-greedy-graph-optimization.ipynb`: landing page, essential concepts, learning objectives, chapter flow, glossary, slides placeholder
- `2201-greedy-choice.ipynb`: greedy choice rules, counterexamples, invariants, exchange arguments, design checklist
- `2202-spanning-trees-shortest-paths.ipynb`: minimum spanning trees, Kruskal's algorithm, Dijkstra's algorithm, path reconstruction, MST versus shortest-path selection
- `2203-optimization-lab.ipynb`: worked optimization lab for interval scheduling, low-cost networks, delivery distances, and reasoning about the greedy choice
- `assignments/preview.ipynb`: glossary and concept preview
- `assignments/lab.ipynb`: required technical lab for greedy choices and graph optimization
- `assignments/homework.ipynb`: true/false and coding practice

## Coverage Notes

- This chapter applies weighted graph representations from Chapter 18, priority queues from Chapter 17, and complexity/correctness language from Chapter 19.
- Dijkstra's algorithm appears here for nonnegative edge weights. Negative-weight shortest paths are out of scope for this introductory pass.
- Keep proof work as proof sketches: local choice rule, invariant, counterexample search, and exchange/stay-ahead intuition.
- Chapter 24 can revisit graph traversal and more advanced path topics.

## Maintenance Notes

- C# examples should remain standalone because students may run any cell directly in Live Code.
- Keep graphs small enough to verify by hand.
- The union-find examples are intentionally simple; path compression can be added later as an extension.
