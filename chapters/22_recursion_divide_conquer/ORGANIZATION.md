---
orphan: true
---

# Chapter Organization: Recursion

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `2201_recursion.ipynb` | Recursive Contracts and Divide-and-Conquer | Core content |
| `2203_merge_sort_lab.ipynb` | Stable Merge Sort and Verification | Core content |

Keep the current section boundaries and recently developed content. Consolidate repeated in-page navigation, distinguish repeated practice headings, retain all substantive explanations/examples and finish the instructional material before the final Footnotes group.

Teach the section conceptual framework before detailed application; place syntax prerequisites before reasoning that requires them. Keep the new worked traces and guided checkpoints, followed by existing lab/homework transfer. Reading count does not set a meeting or word quota.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Class Meetings

1. **Recursive contracts and calls, 35 minutes.** State valid domains and base answers, trace factorial frames and returns, prove progress and inductive results, hide helper indexes, and contrast stack cost with iteration.
2. **Divide-and-conquer design, 35 minutes.** Use half-open ranges, preserve odd splits, distinguish one-child search from two-child maximum, derive merge invariants, and inspect stable slice-based merge sort.
3. **Complete stable sorting, 40 minutes.** Hand-trace merge fronts, inspect range/buffer implementation, verify labeled tie order and occurrence preservation, measure actual operations, and connect the invoice-report lab.

The 110-minute plan includes predictions, traces, discussion, and code inspection.

## Assignment Roles

Preview checks contracts and recursive structure. Lab builds a connected invoice-report workflow: recursive sum, merge, sort, identity-preserving stable output, and contract tests. Homework transfers factorial limits, odd maximum ranges, binary-search boundaries, merge extremes, and descending stable comparison.

## Conventions and Scope

Wrappers validate public inputs and hide internal ranges. Sort returns a fresh shallow array copy even for zero/one items, while comparison callbacks must define a consistent ordering. Merge requires sorted inputs. Count active frames including the base frame. Distinguish peak memory from cumulative allocation/write volume, and operation counts from growth estimates. Full searching/sorting comparison belongs in Chapter 23. Slides and exercise-tag migration remain deferred.

## Foundation Placement (2026-10-07)

Basic recursive cases and call/return traces now belong to Chapter 17. This optional chapter begins with progress measures and helper contracts before divide-and-conquer design.

The earlier lecture allocation is superseded where it repeats relocated introductory topics. Use that time for contract counterexamples, verification traces, and the chapter’s optional advanced applications. Students complete Chapters 14, 16, and 19 foundations first as relevant.

## Section-Boundary Review (2026-10-17)

**Status: implemented.** The following records the reviewed recommendation and its baseline. See Implemented Reading Organization below for the final current filenames and order; earlier meeting allocations are historical where they conflict.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `2201_recursion.ipynb`: Recursive Problem Solving | Core content | 405 | 15 | 5 |
| `2202_divide_conquer.ipynb`: Divide-and-Conquer Design | Core content | 661 | 20 | 6 |
| `2203_merge_sort_lab.ipynb`: Merge Sort Lab | Core content | 558 | 20 | 7 |

**Recommendation:** Combine recursive design; retain merge sort as a full lesson.

2201 is a 405-word bridge after introductory recursion moved to Chapter 17. It naturally precedes the decomposition/range reasoning in 2202. The merge implementation has a separate substantial combining-and-verification role.

### Proposed Reading Sequence

1. Recursive contracts and divide-and-conquer design.
2. Stable merge sort, verification, and measured work.

### Adequacy Before Reorganization

Expand call/return and half-open/odd-split traces plus the combining step. Two reading sections do not require reducing the original example set or squeezing all teaching into two meetings.

Reading sections and class meetings are different units; allocate discussion and practice after developing adequate explanations. Do not reduce distinct material to meet a section or word quota.

Preserve every existing explanation, exercise variation and assessment identity. The source-to-destination dispositions in MATERIALS.md govern any later move. Update TOC, links and redirects only in an authorized implementation pass.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `2201_recursion.ipynb`: Recursive Contracts and Divide-and-Conquer.
- `2203_merge_sort_lab.ipynb`: Stable Merge Sort and Verification.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.


## Subsection Integration (2026-10-17)

This is the current internal teaching order for the repaired pages. Earlier outlines remain historical where they differ. Chapter/section notebook order is unchanged. All original explanations, examples, exercises, code outputs, assessment identifiers, and link destinations are retained.

### `2203_merge_sort_lab.ipynb`

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

## OpenDSA-Modeled Development (2026-10-19)

Pass 8 placed forward and backward flow, the digit-sum completion, and the find-the-error trace after the Progress Measures mistake in 22.1, the Towers of Hanoi subsection and the call-count trace after The Pattern, and the self-check before Halving Strategies. 22.2 gained one range-recursion completion before Compare Measured Operations and a self-check before its closing practice, since the page was already the chapter's longest. New headings are `###`; both pages stay within one class segment. See MATERIALS.md for the gap list.
