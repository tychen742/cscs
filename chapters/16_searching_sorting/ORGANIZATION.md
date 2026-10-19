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


## Outcome Gap Repair (2026-10-17)

Preserve the current chapter notebooks, reading order, existing explanations, exercise variants, and assessment identifiers. The additions below close the outcome audit gaps within that organization. Explanations belong in content before independent application; earlier scaffolded tasks remain available.

| Location | Development or assessment |
| --- | --- |
| `homework.ipynb` | Independent Search, Stable Sort, and Workload Choice |

Progression: read the relevant lesson and worked example, complete its guided practice, then attempt the added independent homework without copying the solution. Require contract-derived expected results, boundary evidence, and reasoning about the chosen representation or design. Assess process and explanation as well as output. Existing labs remain scaffolded applications rather than the sole evidence of independent mastery.

Lecture decks remain a separately tracked task. No additional chapter, meeting, or required optional-topic track is introduced.

### Verified Topic-to-Assessment Progression

| Topic/outcome | Explanation and worked example | Guided preparation | Independent evidence |
| --- | --- | --- | --- |
| Independent search/sort and workload decision | 1601_searching and 1602_basic_sorting existing algorithms, invariant/stability/cost examples | Existing scaffolded first-match and insertion-sort exercises retained | New algorithm bodies, independently derived boundary checks, visible stability labels, original snapshot, comparison convention, and Q-query/U-update workload justification. |

Keep the original five-question coding tracks and smaller historical variations. Added transfer tasks complement them. Grade implementation, independently derived expected results, and the requested reasoning separately; correct output from a supplied class does not establish algorithm construction.

## Merge Sort Supporting Reading (2026-10-18)

16.3 Merge Sort is optional reading after the two core sections and depends on Chapter 5's Recursive Methods reading. It is not in the direct assessment scope. The landing page introduction, Chapter Flow, and glossary (run, merge, merge sort, divide and conquer) were updated.

## Guided Practice Pass (2026-10-18)

Pass 4 of the content-development audit (`authoring/content_development_audit/`): added a mid-page guided practice with solution to the supporting 16.3 (merge descending runs) and an expected-output sentence to the 16.2 snapshot practice. Every new starter and solution compiles and runs standalone (.NET 10); starters that are meant to fail say so in their task text. No existing cell, heading, or exercise ID was removed.

## OpenDSA-Modeled Development (2026-10-19)

Pass 8 placed the binary search analysis, trace, and completion directly after Binary Search Requires the Right Order, with the self-check before the existing practice. In 16.2 the sorting-problem definition precedes Insert into a Sorted Prefix, the inversion analysis and pass trace follow Count Work for Different Inputs, the cost-ordering exercise precedes Include Preparation and Updates, and the self-check closes the page before Footnotes. The supporting reading 16.4 gained one recursion trace and a self-check. 16.2 is the longest page of the chapter; its additions are about 700 prose words and three cells, which keeps it within one class segment with the merge sort reading left as homework reading. See MATERIALS.md for the gap list.
