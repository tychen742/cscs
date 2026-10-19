---
orphan: true
---

# Chapter Materials: Search and Sort

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `2301_searching.ipynb` | Searching | Core content |
| `2302_sorting.ipynb` | Sorting | Core content |
| `2303_comparison_lab.ipynb` | Comparing Complete Search and Sort Workloads | Core content |
| `2304_advanced_sorts.ipynb` | Shell Sort and Gap Families | Supporting reading |
| `2305_quicksort.ipynb` | Quicksort and Partitioning | Supporting reading |

Retain all five readings and the recently developed duplicate-boundary and QuickSort instruction. Shell sort and QuickSort are explicitly supporting readings in the TOC. Remove only the obsolete Shell Sort and Quicksort wrapper heading from the Shell lesson, not its examples or comparison program.

No assessment identity, assignment notebook, worked code, output or exercise variant is removed. `authoring/integration_cleanup/` records the original cells, exact edits, moves and URL/fragment compatibility.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Current Priority-Section Coverage (2026-10-17)

This coverage update describes the current notebooks and supersedes older pre-reorganization filename summaries below. Historical plans and verification records are retained.

| Reading | Developed content-section coverage |
| --- | --- |
| `2301_searching.ipynb` | Step through lower/upper-bound intervals, connect equality choices to executable loop updates and scaffold duplicate-range transfer. |
| `2305_quicksort.ipynb` | Work an actual two-scan partition including swaps and recursive intervals, plus a focused standalone QuickSort and guided duplicates/subrange cases. |

Retain the current five readings. Develop duplicate boundaries in the search extension and two-scan partitioning in the optional QuickSort reading. Keep the combined Shell/QuickSort example as an additional comparison.

All original lesson cells remain, except the explicitly documented presentation/syntax/result corrections and stale chapter references in `authoring/priority_development/source_corrections.json`. Original assignment notebooks and exercise IDs remain untouched. Full standalone code is retained beside the new smaller teaching cores; newly added code verification is recorded separately from historical checks.


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

## Mistakes and Interpretation Pass (2026-10-18)

Pass 5 of the content-development audit (`authoring/content_development_audit/`), all five pages: mistakes beside the examples (stopping at equality in boundary search, mismatched sort and search comparers, insertion point read as a match, the naive swap, swapping during the selection scan, shifting on equality, full-width bubble passes, integer-only stability tests, unequal search tasks, reusing one input across algorithms, summing unlike operations, small-n conclusions from growth models, omitting preparation, recommendations by name, gap sequences without 1, non-advancing quicksort scans) and interpretation after the exercise solutions and the result-comparison cells. Every demonstration cell on these pages was rerun and the interpretations quote the actual output. No code cell, heading, cell ID, or exercise ID changed.

## Visual Support and Part I Shape (2026-10-18)

Pass 6 of the content-development audit (`authoring/content_development_audit/`): 23.4 gained the gap-3 and gap-1 subsequence table the guided trace asks for, with the array state after the gap-3 pass. New code cells compile and run standalone (.NET 10); tables and text diagrams are placed beside the example they explain. No heading, cell ID, or exercise ID changed.

## OpenDSA References (2026-10-19)

Added **Visualize it** pointer cells after the worked examples in 23.2 (selection, insertion, and bubble sort; CS3 Selection Sort, Insertion Sort, Bubble Sort), 23.4 (Shell sort; CS3 Shellsort), and 23.5 (partition and quicksort; CS3 Quicksort), each one sentence linking the matching OpenDSA JSAV slideshow on the `opendsa-server.cs.vt.edu` host (every URL checked with curl, HTTP 200, 2026-10-19). No OpenDSA text or code is copied; no existing cell, heading, cell ID, or exercise ID changed. Re-hosted the existing OpenDSA "Further reading" footnote links to `opendsa-server.cs.vt.edu` CS2/CS3 pages, because `opendsa.org`, `opendsa.cs.vt.edu`, and `opendsax.cs.vt.edu` either fail strict fetches or are not the host this book links to. The roles of the OpenDSA books are recorded in `authoring/toc_comparison/README.md` (OpenDSA mapping) and Appendix A. Chapter 23: the five footnotes keep the catalog Search in Sorted Arrays module on the new host.

## OpenDSA Gap List and Development (2026-10-19)

Pass 8 (`authoring/content_development_audit/pass8_cs2_opendsa_development.md`) compared the five sections with OpenDSA CS3 8.3-8.5 (insertion, bubble, selection sort analyses), 8.6 The Cost of Exchange Sorting, 8.8 Shellsort, 8.11 Quicksort (partition, analysis), 8.13 Binsort, 8.14 Radix Sort, 8.15 Empirical Comparison, 8.16 Lower Bounds for Sorting, and 8.17 Sorting Summary Exercises. Gaps found and where they are now developed:

| Gap | OpenDSA treatment | Where it is now developed |
| --- | --- | --- |
| Boundary-search proficiency (completion and trace) | 8.16 and search modules | 23.1 Code Completion: Upper Bound; Code Tracing: Both Bounds on a Tie Block |
| Cost of exchange sorting: comparisons and swaps per case; inversion-based average-case bound for adjacent-exchange sorts | 8.6 | 23.2 The Cost of Exchange Sorting (new, measured average inversions) |
| Selection sort proficiency trace | 8.5 practice | 23.2 Code Tracing: Selection Sort Pass by Pass |
| Lower bound for comparison sorting via decision trees | 8.16 | 23.3 Lower Bounds for Sorting (new, log₂(n!) against measured merge sort) |
| Ranking sorts per input shape | 8.15 | 23.3 Cost Ordering: Rank the Sorts on Each Input |
| Bin sort and radix sort as non-comparison sorts | 8.13, 8.14 | 23.4 Sorting Without Comparisons (new, runnable, supporting reading) |
| Shellsort gap-pass trace | 8.8.3 practice | 23.4 Code Tracing: One Gap Pass of Shell Sort |
| Quicksort analysis: best, worst, average; pivot choice; small-range cutoff; smaller-side recursion | 8.11.4 | 23.5 Quicksort Analysis and Pivot Choice (new, measured) |
| Partition proficiency | 8.11.2 practice | 23.5 Code Completion: Finish the Partition Step |
| Summary questions | 8.17 | Check Your Understanding on every page |

Exercises added: code tracing (23.1, 23.2, 23.4), code completion (23.1, 23.5), cost ordering (23.3), and Check Your Understanding on all five pages. Every new cell compiled and ran under .NET 10 with stored output; no existing cell, heading, exercise ID, or footnote was removed; no OpenDSA text, code, or figure was copied. Heapsort lives in 18.3; code tuning (8.7) is out of scope.
