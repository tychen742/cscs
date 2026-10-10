---
orphan: true
---

# Chapter Materials: Search and Sort

## Sequence

- `2201-searching.ipynb`: Equality/order policies, duplicate lower/upper bounds, and whole-workload costs; basic search and library return values are in Chapter 15.
- `2202-sorting.ipynb`: Preservation and swaps, complete generic elementary sorts, prefix/suffix invariants, insertion inversions and shifts, adaptive bubble boundaries, record stability, and comparisons with Chapter 15 library contracts.
- `2203-comparison-lab.ipynb`: Equivalent-result queries, sorted-permutation verification, varied input orders, comparable operation counters, exact counts versus growth models, preparation costs, and requirement-based recommendations.
- Preview: Ten multiple-choice questions.
- Lab: Five connected purchasing-report tasks preserving invoice identity through searches and stable report sorting.
- Homework: Five applied true/false questions and five independent coding tasks.
- `../../materials/22/SearchSortChecks.cs`: Complete algorithms and independent reference checks.

## Verification and Scope

All 31 completed notebook cells passed independently and hidden answers retain verified stdout. The final workload recommendation was recompiled after adding its explicit count-based conclusion. Reference checks passed 1,800 elementary sorts and 3,000 search targets, plus stable tie, exact count, inversion, adaptive boundary, and extreme-value cases. Notebook structure checks passed and all 23 notebook implementation copies match the verified source. The full-book build passed with five existing warnings outside this chapter. Six browser Runs passed duplicate bounds, library search decoding, labeled stability, optimized bubble counts, inversion/shift checks, and the complete lab workload.

Chapter 21 owns merge-sort implementation. Shell sort, quicksort, and production timing benchmarks remain extensions. Slides remain deferred to Press (student HTML/PDF, instructor-only PPTX); retain legacy exercise metadata until coordinated UI migration.

## Foundation Placement (2026-10-07)

First-match linear search, iterative binary search, missing-target traces, and library sorting/searching now belong to Chapter 15. This optional chapter retains equality policies, duplicate bounds, detailed elementary sorts, and workload analysis.

## Runnable Demo Projects

- [`materials/22/search_sort_demo/`](../../materials/22/search_sort_demo/README.md): Linear/binary search and sort timing extensions.

All demo projects target .NET 10. Run commands and verification are documented
in `materials/README.md` and each project README.
