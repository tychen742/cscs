---
orphan: true
---

# Chapter Materials: Recursion

## Sequence

- `2101-recursion.ipynb`: Hidden suffix helpers and progress measures, recursion versus iteration, and stack/arithmetic limits.
- `2102-divide-conquer.ipynb`: Half-open ranges, complete odd splits, guarded recursive maximum, any-match binary search, merge invariants, stable ties, and readable slice-based sorting.
- `2103-merge-sort-lab.ipynb`: Merge-front trace, complete generic range/buffer sorting, labeled-record stability, order/preservation/copy checks, and actual comparison/write/call/depth counts.
- Preview: Ten multiple-choice questions.
- Lab: Five connected invoice-report tasks from recursive totals through merging, sorting, stability, and boundary verification.
- Homework: Five applied true/false questions and five independent coding tasks.
- `../../materials/21/StableSort.cs`: Complete structures, counters, and reference-model verification.

## Verification and Scope

All 27 completed notebook cells passed independently; hidden answers retain verified stdout. The revised countdown guard was also recompiled and checked at both rejected boundaries. The downloadable source passed 600 stable-sort cases and 600 merge cases plus count/copy boundaries. All 12 notebook copies of the generic implementation match the verified source. The full-book build passed with five existing warnings outside this chapter. Six browser Runs passed: factorial, countdown, labeled stability, sort boundary checks, descending homework, and final lab contract checks.

Searching/sorting comparisons remain in Chapter 22; recursion and divide-and-conquer design are the focus here. Slides remain deferred to Press (student HTML/PDF, instructor-only PPTX). Keep legacy exercise tags until the coordinated UI migration.

## Foundation Placement (2026-10-07)

Basic recursive cases and call/return traces now belong to Chapter 17. This optional chapter begins with progress measures and helper contracts before divide-and-conquer design.
