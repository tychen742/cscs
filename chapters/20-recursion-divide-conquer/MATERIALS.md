---
orphan: true
---

# Chapter Materials — Recursion

## Sequence

- `2000-recursion-divide-conquer.ipynb`: landing page, essential concepts, learning objectives, chapter flow, glossary, slides placeholder
- `2001-recursion.ipynb`: base cases, recursive cases, call-stack tracing, progress measures, recursion versus iteration, recursive risks
- `2002-divide-conquer.ipynb`: divide-and-conquer pattern, recursive maximum, binary search, merge operation, merge sort, design checklist
- `2003-merge-sort-lab.ipynb`: worked merge-sort lab with merge, recursive sort, tests, split tracing, and count comparison
- `assignments/preview.ipynb`: glossary and concept preview
- `assignments/lab.ipynb`: required technical lab for recursive methods and merge sort
- `assignments/homework.ipynb`: true/false and coding practice

## Coverage Notes

- This chapter makes recursion concrete after Chapter 19's recurrence introduction.
- Binary search appears here only as a halving/divide-and-conquer example. The broader search-and-sort comparison belongs in Chapter 21.
- Merge sort is the main worked example because it clearly shows base case, divide, recursive solve, combine, and `O(n log n)` cost.
- Keep code examples small enough to trace by hand.

## Maintenance Notes

- C# examples should remain standalone because students may run any cell directly in Live Code.
- Avoid relying on deep recursion for large linear examples; use small inputs and discuss stack depth honestly.
- If a future implementation optimizes merge sort with buffers and index ranges, keep this first version readable before optimizing.
