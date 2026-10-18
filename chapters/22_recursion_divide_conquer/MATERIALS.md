---
orphan: true
---

# Chapter Materials: Recursion

## Sequence

- `2201_recursion.ipynb`: Hidden suffix helpers and progress measures, recursion versus iteration, and stack/arithmetic limits.
- `2202_divide_conquer.ipynb`: Half-open ranges, complete odd splits, guarded recursive maximum, any-match binary search, merge invariants, stable ties, and readable slice-based sorting.
- `2203_merge_sort_lab.ipynb`: Merge-front trace, complete generic range/buffer sorting, labeled-record stability, order/preservation/copy checks, and actual comparison/write/call/depth counts.
- Preview: Ten multiple-choice questions.
- Lab: Five connected invoice-report tasks from recursive totals through merging, sorting, stability, and boundary verification.
- Homework: Five applied true/false questions and five independent coding tasks.
- `../../demos/22/StableSort.cs`: Complete structures, counters, and reference-model verification.

## Verification and Scope

All 27 completed notebook cells passed independently; hidden answers retain verified stdout. The revised countdown guard was also recompiled and checked at both rejected boundaries. The downloadable source passed 600 stable-sort cases and 600 merge cases plus count/copy boundaries. All 12 notebook copies of the generic implementation match the verified source. The full-book build passed with five existing warnings outside this chapter. Six browser Runs passed: factorial, countdown, labeled stability, sort boundary checks, descending homework, and final lab contract checks.

Searching/sorting comparisons remain in Chapter 23; recursion and divide-and-conquer design are the focus here. Slides remain deferred to Press (student HTML/PDF, instructor-only PPTX). Keep legacy exercise tags until the coordinated UI migration.

## Foundation Placement (2026-10-07)

Basic recursive cases and call/return traces now belong to Chapter 17. This optional chapter begins with progress measures and helper contracts before divide-and-conquer design.

## Section-Boundary Coverage Disposition (2026-10-17)

**Reviewed plan, now implemented:** Combine recursive design; retain merge sort as a full lesson. The disposition below records the preimplementation baseline and rationale. See Implemented Reading Organization for the current reading files. Counts in this baseline exclude fenced code from prose; the refreshed inventory is in authoring/content_size/. They flag review needs, not quality scores.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `2201_recursion.ipynb`: Recursive Problem Solving | Core content | 405 | 15 | 5 |
| `2202_divide_conquer.ipynb`: Divide-and-Conquer Design | Core content | 661 | 20 | 6 |
| `2203_merge_sort_lab.ipynb`: Merge Sort Lab | Core content | 558 | 20 | 7 |

### Source-to-Destination Plan

| Existing source | Proposed treatment and coverage to preserve |
| --- | --- |
| `2201` | Combine helper contracts/progress/iteration tradeoffs with the opening design material in 2202. |
| `2202` | Split internally at Combining Sorted Parts: general pattern/halving/ranges joins recursive design; merge invariant and introductory merge sort join 2203. |
| `2203` | Develop merging, range/buffer implementation, stable ties and independent checks as content, not a lab-only source of explanation. Preserve all exercises and the existing assignments lab. |

### Development Needed Before Moving Material

Expand call/return and half-open/odd-split traces plus the combining step. Two reading sections do not require reducing the original example set or squeezing all teaching into two meetings.

Before a later move, create a cell-level preservation map for these sources, including citations, figures, original code forms, worked traces, guided questions and independent exercise variants. Relocate prerequisite explanations from assignments into content when needed while retaining application requirements and IDs. A consolidated page must still teach its concepts; a split must not create two unsupported outlines. Existing runnable verification records describe earlier work, not verification of this proposal.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `2201_recursion.ipynb`: Recursive Contracts and Divide-and-Conquer.
- `2203_merge_sort_lab.ipynb`: Stable Merge Sort and Verification.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.
