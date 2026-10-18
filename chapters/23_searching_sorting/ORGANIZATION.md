---
orphan: true
---

# Chapter Organization: Search and Sort

## Class Meetings

1. **Search contracts, 40 minutes.** Distinguish first, any, and all matches; choose equality/order policies; trace half-open binary search and missing targets; derive lower/upper bounds, count probes, and decode library return values.
2. **Elementary sort invariants, 40 minutes.** Trace swaps and sorted prefixes/suffixes; prove selection, strict-shift insertion, and shrinking-end bubble behavior; derive exact counts/inversion relationships; inspect record stability and library contracts.
3. **Compare complete workloads, 30 minutes.** Verify sorted permutations and equivalent query results; vary input order; interpret comparisons versus moves; include preparation, query, update, and storage costs in recommendations; connect the purchasing-report lab.

The 110-minute plan includes predictions, traces, discussion, and code inspection.

## Assignment Roles

The lab progresses from first-arrival scans through selection counts, stable invoice reports, full duplicate groups, and complete membership workloads. Homework transfers case-sensitive policies, independently checked boundaries, inversion counts, optimized bubble tests, and library failure encoding.

## Conventions and Scope

Count comparer calls once, excluding loop-bound checks. Separate swaps from shifts. All elementary sorts mutate arrays and use constant auxiliary state. Clone starting arrays for fair comparisons. Stable algorithms compare only the business key and preserve identity within ties. Searching requires matching order policies and retains IDs rather than confusing sorted positions with arrival indexes. Use workload evidence, not universal size cutoffs. Merge sort remains in Chapter 22; slides remain deferred; advanced sorting/timing are restored as supporting extensions.

## Foundation Placement (2026-10-07)

First-match linear search, iterative binary search, missing-target traces, and library sorting/searching now belong to Chapter 16. This optional chapter retains equality policies, duplicate bounds, detailed elementary sorts, and workload analysis.

The earlier lecture allocation is superseded where it repeats relocated introductory topics. Use that time for contract counterexamples, verification traces, and the chapter’s optional advanced applications. Students complete Chapters 14, 16, and 19 foundations first as relevant.

## Restored CS1 Material (2026-10-17)

- `2304_advanced_sorts.ipynb`: restored explanations and exercises; retains current lessons and assignment IDs.
- `assignments/search_performance.ipynb`: restored explanations and exercises; retains current lessons and assignment IDs.

Advanced sorting and empirical timing are restored supporting extensions, not an added required meeting. They supplement operation counts and workload analysis.

## CS1 Preservation Follow-up (2026-10-17)

The original additional 2h+1 Shell gap family is restored alongside powers-of-two and 3h+1, with a standalone three-family comparison. Existing advanced sorts, timing and workload analysis remain.

## Section-Boundary Review (2026-10-17)

**Status: implemented.** The following records the reviewed recommendation and its baseline. See Implemented Reading Organization below for the final current filenames and order; earlier meeting allocations are historical where they conflict.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `2301_searching.ipynb`: Searching | Core content | 345 | 14 | 4 |
| `2302_sorting.ipynb`: Sorting | Core content | 688 | 24 | 7 |
| `2303_comparison_lab.ipynb`: Searching and Sorting Comparison Lab | Core content | 635 | 23 | 8 |
| `2304_advanced_sorts.ipynb`: Shell Sort and Quicksort | Supporting reading | 830 | 16 | 2 |

**Recommendation:** Retain advanced core; separate optional sort families.

Search-result policies, sort invariants and fair comparisons remain distinct even after basics moved to Chapter 16. Optional Shell sort and quicksort are different algorithms and should not be rushed in one reference tour.

### Proposed Reading Sequence

1. Duplicate-aware search contracts.
2. Elementary sort behavior, invariants, and stability.
3. Equivalent-workload comparison.

### Adequacy Before Reorganization

Expand duplicate-bound traces and comparison-count interpretation. Develop each optional algorithm before separating the pages; short pages are not the goal.

Retain the supporting readings identified above outside the required core. Reading sections and class meetings are different units; allocate discussion and practice after developing adequate explanations. Do not reduce distinct material to meet a section or word quota.

Preserve every existing explanation, exercise variation and assessment identity. The source-to-destination dispositions in MATERIALS.md govern any later move. Update TOC, links and redirects only in an authorized implementation pass.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `2301_searching.ipynb`: Searching.
- `2302_sorting.ipynb`: Sorting.
- `2303_comparison_lab.ipynb`: Comparing Complete Search and Sort Workloads.
- `2304_advanced_sorts.ipynb`: Shell Sort and Gap Families.
- `2305_quicksort.ipynb`: Quicksort and Partitioning.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.
