---
orphan: true
---

# Materials: Searching and Basic Sorting

## Core Materials

- `1601_searching.ipynb`: Searching Ordered and Unordered Data
- `1602_basic_sorting.ipynb`: Insertion Sort and Ordering
- `1603_workloads.ipynb`: Search and Sort Workloads
- `assignments/`: preview, connected lab, homework, and assignment index.

## Verification and Remaining Work

Standalone C# cells and reference console projects are checked during this revision. Updated slides and recordings are pending. Advanced sorting, tree rotations, weighted graph optimization, and further algorithm analysis are optional depth, not additional requirements for this unit.

## Section-Boundary Coverage Disposition (2026-10-17)

**Reviewed plan, now implemented:** Combine workload material into two developed lessons. The disposition below records the preimplementation baseline and rationale. See Implemented Reading Organization for the current reading files. Counts in this baseline exclude fenced code from prose; the refreshed inventory is in authoring/content_size/. They flag review needs, not quality scores.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `1601_searching.ipynb`: Searching Ordered and Unordered Data | Core content | 706 | 16 | 5 |
| `1602_basic_sorting.ipynb`: Basic Sorting with Insertion Sort | Core content | 549 | 14 | 5 |
| `1603_workloads.ipynb`: Search and Sort Workloads | Core content | 513 | 14 | 4 |

### Source-to-Destination Plan

| Existing source | Proposed treatment and coverage to preserve |
| --- | --- |
| `1601` | Retain linear/binary search; incorporate repeated-query preparation/update comparisons from 1603 after developing result contracts and ordered-input requirements. |
| `1602` | Retain insertion sort and ordering; incorporate reporting snapshots, comparer consistency, boundary matrices and guided report task from 1603. |
| `1603` | Distribute its explanations and exercises into the preceding lessons, preserving the cross-cutting end-to-end report comparison as the closing case. Preserve the published URL. |

### Development Needed Before Moving Material

Expand successful/missing/duplicate search traces, insertion movement, sorted-prefix reasoning and independent order/preservation checks before consolidation. These are core CS2 lessons, not optional advanced prerequisites.

Before a later move, create a cell-level preservation map for these sources, including citations, figures, original code forms, worked traces, guided questions and independent exercise variants. Relocate prerequisite explanations from assignments into content when needed while retaining application requirements and IDs. A consolidated page must still teach its concepts; a split must not create two unsupported outlines. Existing runnable verification records describe earlier work, not verification of this proposal.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `1601_searching.ipynb`: Search Contracts and Repeated Queries.
- `1602_basic_sorting.ipynb`: Sorting and Safe Reporting Workloads.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.
