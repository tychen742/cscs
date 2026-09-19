---
orphan: true
---

# Chapter Materials — Searching and Sorting

## Sequence

- `2100-searching-sorting.ipynb`: landing page, essential concepts, learning objectives, chapter flow, glossary, slides placeholder
- `2101-searching.ipynb`: linear search, search contracts, comparison counts, binary search, binary-search trace, search selection
- `2102-sorting.ipynb`: swap operation, selection sort, insertion sort, bubble sort, comparison counts, library sorting
- `2103-comparison-lab.ipynb`: search-count comparison, sorting correctness tests, elementary-sort counts, merge-sort growth comparison, recommendation writing
- `assignments/preview.ipynb`: glossary and concept preview
- `assignments/lab.ipynb`: required technical lab for searching, sorting, counting, and recommendations
- `assignments/homework.ipynb`: true/false and coding practice

## Coverage Notes

- This chapter applies Chapter 19's analysis tools to searching and sorting.
- Chapter 20 already introduced merge sort. Here, merge sort is used mostly as an `O(n log n)` comparison point.
- Keep Shell sort, quicksort, and implementation-level benchmarking out of the first pass; they can become extensions after students master tracing and comparison counts.
- Emphasize data conditions: binary search requires sorted data, and sorting first only pays off when the later workload justifies it.

## Maintenance Notes

- C# examples should remain standalone because students may run any cell directly in Live Code.
- Use comparison counts before wall-clock benchmarks. Timing belongs in a later performance-focused extension.
- Prefer library sorting in recommendations for production C# code; hand-written sorts are for learning algorithm mechanics.
