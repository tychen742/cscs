---
orphan: true
---

# Chapter Materials: Recursion

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `2201_recursion.ipynb` | Recursive Contracts and Divide-and-Conquer | Core content |
| `2202_merge_sort_lab.ipynb` | Stable Merge Sort and Verification | Core content |

Keep the current section boundaries and recently developed content. Consolidate repeated in-page navigation, distinguish repeated practice headings, retain all substantive explanations/examples and finish the instructional material before the final Footnotes group.

No assessment identity, assignment notebook, worked code, output or exercise variant is removed. `authoring/integration_cleanup/` records the original cells, exact edits, moves and URL/fragment compatibility.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Sequence

- `2201_recursion.ipynb`: Hidden suffix helpers and progress measures, recursion versus iteration, and stack/arithmetic limits.
- `2202_divide_conquer.ipynb`: Half-open ranges, complete odd splits, guarded recursive maximum, any-match binary search, merge invariants, stable ties, and readable slice-based sorting.
- `2202_merge_sort_lab.ipynb`: Merge-front trace, complete generic range/buffer sorting, labeled-record stability, order/preservation/copy checks, and actual comparison/write/call/depth counts.
- Preview: Ten multiple-choice questions.
- Lab: Five connected invoice-report tasks from recursive totals through merging, sorting, stability, and boundary verification.
- Homework: Five applied true/false questions and five independent coding tasks.
- `../../demos/22_recursion_divide_conquer/StableSort.cs`: Complete structures, counters, and reference-model verification.

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
| `2202_merge_sort_lab.ipynb`: Merge Sort Lab | Core content | 558 | 20 | 7 |

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
- `2202_merge_sort_lab.ipynb`: Stable Merge Sort and Verification.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.


## Subsection Integration (2026-10-17)

This is the current internal teaching order for the repaired pages. Earlier outlines remain historical where they differ. Chapter/section notebook order is unchanged. All original explanations, examples, exercises, code outputs, assessment identifiers, and link destinations are retained.

### `2202_merge_sort_lab.ipynb`

- Prove the Combining Step Before Hiding It in Recursion
- Combining Sorted Parts
- Merge Sort
- Design Checklist
- Checkpoint: Apply the Basic Merge Sort
- Trace Merge Fronts
- Sort Ranges with One Buffer
- Verify Stability with Labeled Invoices
- Check Order, Preservation, and Copying
- Compare Measured Operations
- Practice: Verify Merge Results

Treat syntax, examples, and meaningful variations as children of their conceptual topic. Place prerequisite explanations before application, and distinguish a local checkpoint from later synthesis. Preserve distinct older/newer treatments by grouping them rather than deleting them. Keep the final Footnotes group after instructional content.

## Mistakes and Interpretation Pass (2026-10-18)

Pass 5 of the content-development audit (`authoring/content_development_audit/`), both pages: mistakes beside the examples (copying suffixes instead of indexing, recursion for flat reports, catching stack overflow, dropping the middle element, non-shrinking binary search, truncated merges, returning the input from the base case, advancing both merge indexes, in-place merging, re-sorting to fix ties, self-referential reference checks, reading n log n as an exact count) and interpretation after the checkpoint, verification, and practice solutions. Every demonstration cell on these pages was rerun and the interpretations quote the actual output. No code cell, heading, cell ID, or exercise ID changed.

## OpenDSA References (2026-10-19)

Added **Visualize it** pointer cells after the worked examples in 22.2 (merge sort, after the copy-returning contract paragraph; CS3 Mergesort Concepts and Implementing Mergesort), each one sentence linking the matching OpenDSA JSAV slideshow on the `opendsa-server.cs.vt.edu` host (every URL checked with curl, HTTP 200, 2026-10-19). No OpenDSA text or code is copied; no existing cell, heading, cell ID, or exercise ID changed.

## OpenDSA Gap List and Development (2026-10-19)

Pass 8 (`authoring/content_development_audit/pass8_cs2_opendsa_development.md`) compared the two sections with OpenDSA CS2 7.1-7.9 (Introduction to Recursion, Writing a Recursive Function, Code Completion Practice, Writing More Sophisticated Recursive Functions, Tracing Recursive Code with the domino analogy and Towers of Hanoi, the tracing exercise families, and Recursion Summary Questions) and CS3 8.9-8.10 Mergesort Concepts and Implementing Mergesort. Gaps found and where they are now developed:

| Gap | OpenDSA treatment | Where it is now developed |
| --- | --- | --- |
| Forward versus backward flow (work before or after the recursive call); domino picture; decimal-to-binary as backward flow | 7.7 Tracing, 7.5 Decimal to Binary | 22.1 Forward and Backward Flow (new, runnable) |
| Code completion family (sum of digits, largest, power) | 7.3, 7.5 | 22.1 Code Completion: Sum of the Digits |
| Find-the-error and how-many-times tracing families | 7.8.3, 7.8.5 | 22.1 Code Tracing: Find the Error; Code Tracing: How Many Calls? |
| Two recursive calls on a problem smaller by one; Towers of Hanoi and its 2ⁿ - 1 recurrence | 7.7.1.2 | 22.1 Two Recursive Calls: Towers of Hanoi (new, runnable) |
| Range-based merge sort completion | CS3 8.10 | 22.2 Code Completion: Split and Recurse on a Range |
| Summary questions | 7.9 | Check Your Understanding on both pages |

Exercises added: code tracing (22.1, two), code completion (22.1, 22.2), and Check Your Understanding on both pages. Every new cell compiled and ran under .NET 10 with stored output; no existing cell, heading, exercise ID, or footnote was removed; no OpenDSA text, code, or figure was copied. Palindrome, subset-sum, and Pascal-triangle writing exercises were left for the chapter assignments.

## Demo folder rename (2026-10-19)

The chapter's demo source moved from the former two-digit folder `22/` to `demos/22_recursion_divide_conquer/`, the same folder name as this chapter, so a cloned repository opened in VS Code shows the book's chapter names. The notebook download and link paths in this chapter were updated to the new folder; no cell content, heading, cell id, or exercise ID changed.
