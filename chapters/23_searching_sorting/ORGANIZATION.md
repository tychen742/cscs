---
orphan: true
---

# Chapter Organization: Search and Sort

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

Teach the section conceptual framework before detailed application; place syntax prerequisites before reasoning that requires them. Keep the new worked traces and guided checkpoints, followed by existing lab/homework transfer. Reading count does not set a meeting or word quota.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Current B-A Teaching Progression (2026-10-17)

This is the current progression within the existing section order; earlier meeting outlines below are historical where they conflict. Readings are not additional required meetings.

Retain the current five readings. Develop duplicate boundaries in the search extension and two-scan partitioning in the optional QuickSort reading. Keep the combined Shell/QuickSort example as an additional comparison.

| Reading | Developed content-section coverage |
| --- | --- |
| `2301_searching.ipynb` | Step through lower/upper-bound intervals, connect equality choices to executable loop updates and scaffold duplicate-range transfer. |
| `2305_quicksort.ipynb` | Work an actual two-scan partition including swaps and recursive intervals, plus a focused standalone QuickSort and guided duplicates/subrange cases. |

**Conceptual framework:** motivate the result contract and connect the new operation to prior control flow, state, representation or algorithm ideas.

**Subsection development:** use the new small trace and standalone worked example before the complete retained implementation. Interpret the saved output, vary an assumption and diagnose a plausible mistake. Syntax scaffolds are patterns, not hidden executable prerequisites.

**Practice progression:** Complete low/high/mid updates; derive duplicate intervals; trace equal-pivot progress and recursive endpoints. Transfer to the existing duplicate-report and workload assignments; QuickSort remains optional depth.

Keep prerequisite explanations in these content sections. Labs apply the explained ideas and may scaffold the task; homework increases transfer. No existing explanation, exercise variation, assignment identity or independent-work requirement is removed to fit a time or word quota.


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

## Mistakes and Interpretation Pass (2026-10-18)

Pass 5 of the content-development audit (`authoring/content_development_audit/`), all five pages: mistakes beside the examples (stopping at equality in boundary search, mismatched sort and search comparers, insertion point read as a match, the naive swap, swapping during the selection scan, shifting on equality, full-width bubble passes, integer-only stability tests, unequal search tasks, reusing one input across algorithms, summing unlike operations, small-n conclusions from growth models, omitting preparation, recommendations by name, gap sequences without 1, non-advancing quicksort scans) and interpretation after the exercise solutions and the result-comparison cells. Every demonstration cell on these pages was rerun and the interpretations quote the actual output. No code cell, heading, cell ID, or exercise ID changed.
