---
orphan: true
---

# Chapter Organization: Searching and Basic Sorting

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `1601_searching.ipynb` | Search Contracts and Repeated Queries | Core content |
| `1602_basic_sorting.ipynb` | Sorting and Safe Reporting Workloads | Core content |

Two core readings remain. 1601 develops search contracts and repeated queries, with a short preparation bridge. 1602 first teaches sorting, then retains the entire reporting snapshot, preparation/update-cost and workload comparison material. All sort-a-copy code and exercises now follow sorting instruction. Legacy workload URLs/fragments point to the retained destinations.

Teach the section conceptual framework before detailed application; place syntax prerequisites before reasoning that requires them. Keep the new worked traces and guided checkpoints, followed by existing lab/homework transfer. Reading count does not set a meeting or word quota.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Class Meetings

1. **Searching Ordered and Unordered Data, 35 minutes.** Predict a result, trace a small example, inspect the runnable model, and complete a nearby exercise.
2. **Insertion Sort and Ordering, 40 minutes.** Predict a result, trace a small example, inspect the runnable model, and complete a nearby exercise.
3. **Search and Sort Workloads, 35 minutes.** Predict a result, trace a small example, inspect the runnable model, and complete a nearby exercise.

Total: 110 minutes. Lab and homework add guided and independent practice.

## Assignment Roles

Preview checks vocabulary and contracts. Lab contains five connected coding tasks. Homework contains five workplace true/false questions and five standalone coding tasks. Search contracts, ordering, preserved input, and search/sort workloads are the direct assessment scope. Graph traversal is in Chapter 20; weighted route optimization is in Chapter 24.

## Section-Boundary Review (2026-10-17)

**Status: implemented.** The following records the reviewed recommendation and its baseline. See Implemented Reading Organization below for the final current filenames and order; earlier meeting allocations are historical where they conflict.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `1601_searching.ipynb`: Searching Ordered and Unordered Data | Core content | 706 | 16 | 5 |
| `1602_basic_sorting.ipynb`: Basic Sorting with Insertion Sort | Core content | 549 | 14 | 5 |
| `1603_workloads.ipynb`: Search and Sort Workloads | Core content | 513 | 14 | 4 |

**Recommendation:** Combine workload material into two developed lessons.

1603 applies the searches and sorting already introduced; its 513 words work as synthesis within those two lessons. The result should be two full lessons, not a thin chapter compressed into fewer pages.

### Proposed Reading Sequence

1. Search contracts, traces, and repeated queries.
2. Ordering, insertion sort, and safe reporting workloads.

### Adequacy Before Reorganization

Expand successful/missing/duplicate search traces, insertion movement, sorted-prefix reasoning and independent order/preservation checks before consolidation. These are core CS2 lessons, not optional advanced prerequisites.

Reading sections and class meetings are different units; allocate discussion and practice after developing adequate explanations. Do not reduce distinct material to meet a section or word quota.

Preserve every existing explanation, exercise variation and assessment identity. The source-to-destination dispositions in MATERIALS.md govern any later move. Update TOC, links and redirects only in an authorized implementation pass.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `1601_searching.ipynb`: Search Contracts and Repeated Queries.
- `1602_basic_sorting.ipynb`: Sorting and Safe Reporting Workloads.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.

## Landing Page Alignment (2026-10-17)

The landing page `1600_searching_sorting.ipynb` now orients students to the two sections (search contracts and repeated queries; sorting and safe reporting workloads) with a grounded introduction, measurable objectives, and a glossary built from the content notebooks (see MATERIALS.md, Landing Page Development). Preview quizzes should draw vocabulary from that glossary. Class meeting allocations above are unchanged.
