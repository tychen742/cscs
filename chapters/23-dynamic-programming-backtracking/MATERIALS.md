---
orphan: true
---

# Chapter Materials — Dynamic Programming

## Sequence

- `2300-dynamic-programming-backtracking.ipynb`: landing page, essential concepts, learning objectives, chapter flow, glossary, slides placeholder
- `2301-memoization-tabulation.ipynb`: repeated recursive work, memoized Fibonacci, tabulated Fibonacci, minimum-coin table, memoization versus tabulation
- `2302-backtracking.ipynb`: choose/explore/undo, subset sum, pruning, permutations, backtracking cost
- `2303-optimization-lab.ipynb`: call-count comparison, memoization, tabulation, subset search, DP/backtracking trade-off
- `assignments/preview.ipynb`: glossary and concept preview
- `assignments/lab.ipynb`: required technical lab for Fibonacci, coin change, subset sum, and pruning
- `assignments/homework.ipynb`: true/false and coding practice

## Coverage Notes

- This chapter follows recursion, recurrence analysis, and greedy algorithms. It should emphasize when local greedy choices are not enough and when repeated subproblems or constraint search appear.
- Keep DP state representations small and explicit. Fibonacci, stairs, and coin change are enough for the first pass.
- Keep backtracking focused on subset generation, subset sum, permutations, and pruning. Larger puzzles can be extensions.

## Maintenance Notes

- C# examples should remain standalone because students may run any cell directly in Live Code.
- Use small inputs so call counts and output stay readable.
- When adding new DP examples, state the recurrence and table meaning before writing code.
