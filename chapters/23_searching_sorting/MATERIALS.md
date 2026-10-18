---
orphan: true
---

# Chapter Materials: Search and Sort

## Sequence

- `2301_searching.ipynb`: Equality/order policies, duplicate lower/upper bounds, and whole-workload costs; basic search and library return values are in Chapter 16.
- `2302_sorting.ipynb`: Preservation and swaps, complete generic elementary sorts, prefix/suffix invariants, insertion inversions and shifts, adaptive bubble boundaries, record stability, and comparisons with Chapter 16 library contracts.
- `2303_comparison_lab.ipynb`: Equivalent-result queries, sorted-permutation verification, varied input orders, comparable operation counters, exact counts versus growth models, preparation costs, and requirement-based recommendations.
- Preview: Ten multiple-choice questions.
- Lab: Five connected purchasing-report tasks preserving invoice identity through searches and stable report sorting.
- Homework: Five applied true/false questions and five independent coding tasks.
- `../../demos/23/SearchSortChecks.cs`: Complete algorithms and independent reference checks.

## Verification and Scope

All 31 completed notebook cells passed independently and hidden answers retain verified stdout. The final workload recommendation was recompiled after adding its explicit count-based conclusion. Reference checks passed 1,800 elementary sorts and 3,000 search targets, plus stable tie, exact count, inversion, adaptive boundary, and extreme-value cases. Notebook structure checks passed and all 23 notebook implementation copies match the verified source. The full-book build passed with five existing warnings outside this chapter. Six browser Runs passed duplicate bounds, library search decoding, labeled stability, optimized bubble counts, inversion/shift checks, and the complete lab workload.

Chapter 22 owns merge-sort implementation. Shell sort, quicksort, and production timing benchmarks remain extensions. Slides remain deferred to Press (student HTML/PDF, instructor-only PPTX); retain legacy exercise metadata until coordinated UI migration.

## Foundation Placement (2026-10-07)

First-match linear search, iterative binary search, missing-target traces, and library sorting/searching now belong to Chapter 16. This optional chapter retains equality policies, duplicate bounds, detailed elementary sorts, and workload analysis.

## Runnable Demo Projects

- [`demos/23/search_sort_demo/`](../../demos/23/search_sort_demo/README.md): Linear/binary search and sort timing extensions.

All demo projects target .NET 10. Run commands and verification are documented
in `demos/README.md` and each project README.

## Restored CS1 Material (2026-10-17)

- `2304_advanced_sorts.ipynb`: restored explanations and exercises; retains current lessons and assignment IDs.
- `assignments/search_performance.ipynb`: restored explanations and exercises; retains current lessons and assignment IDs.

Advanced sorting and empirical timing are restored supporting extensions, not an added required meeting. They supplement operation counts and workload analysis.

## CS1 Preservation Follow-up (2026-10-17)

The original additional 2h+1 Shell gap family is restored alongside powers-of-two and 3h+1, with a standalone three-family comparison. Existing advanced sorts, timing and workload analysis remain.

## Section-Boundary Coverage Disposition (2026-10-17)

**Reviewed plan, now implemented:** Retain advanced core; separate optional sort families. The disposition below records the preimplementation baseline and rationale. See Implemented Reading Organization for the current reading files. Counts in this baseline exclude fenced code from prose; the refreshed inventory is in authoring/content_size/. They flag review needs, not quality scores.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `2301_searching.ipynb`: Searching | Core content | 345 | 14 | 4 |
| `2302_sorting.ipynb`: Sorting | Core content | 688 | 24 | 7 |
| `2303_comparison_lab.ipynb`: Searching and Sorting Comparison Lab | Core content | 635 | 23 | 8 |
| `2304_advanced_sorts.ipynb`: Shell Sort and Quicksort | Supporting reading | 830 | 16 | 2 |

### Source-to-Destination Plan

| Existing source | Proposed treatment and coverage to preserve |
| --- | --- |
| `2301` | Retain and expand lower/upper bounds and equality/order policies; use Chapter 16 as the basic-search prerequisite. |
| `2302` | Retain elementary-sort contrasts, including original insertion variants; explain what is new relative to Chapter 16. |
| `2303` | Retain comparative workload reasoning as instructional content; use assignments for independent comparison. |
| `2304` | Plan two optional supporting readings: Shell sort with all three gap families, and quicksort with partition/recursion reasoning. Retain all existing variants and the old URL through a future redirect/overview. |

### Development Needed Before Moving Material

Expand duplicate-bound traces and comparison-count interpretation. Develop each optional algorithm before separating the pages; short pages are not the goal.

Before a later move, create a cell-level preservation map for these sources, including citations, figures, original code forms, worked traces, guided questions and independent exercise variants. Relocate prerequisite explanations from assignments into content when needed while retaining application requirements and IDs. A consolidated page must still teach its concepts; a split must not create two unsupported outlines. Existing runnable verification records describe earlier work, not verification of this proposal.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `2301_searching.ipynb`: Searching.
- `2302_sorting.ipynb`: Sorting.
- `2303_comparison_lab.ipynb`: Comparing Complete Search and Sort Workloads.
- `2304_advanced_sorts.ipynb`: Shell Sort and Gap Families.
- `2305_quicksort.ipynb`: Quicksort and Partitioning.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.
