---
orphan: true
---

# Chapter Organization: Priority Queues and Heaps

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `1801_priority_queues.ipynb` | Priority Queue Contracts and Heap Shape | Core content |
| `1802_heap_implementation.ipynb` | Implementing and Checking a Binary Heap | Core content |
| `1803_priority_applications.ipynb` | Priority Workloads and Top-K Selection | Core content |

Keep the current section boundaries and recently developed content. Consolidate repeated in-page navigation, distinguish repeated practice headings, retain all substantive explanations/examples and finish the instructional material before the final Footnotes group.

Teach the section conceptual framework before detailed application; place syntax prerequisites before reasoning that requires them. Keep the new worked traces and guided checkpoints, followed by existing lab/homework transfer. Reading count does not set a meeting or word quota.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Class Meetings

1. **Priority Contracts, 35 minutes.** Predict a result, trace a small example, inspect the runnable model, and complete a nearby exercise.
2. **Heap Implementation, 40 minutes.** Predict a result, trace a small example, inspect the runnable model, and complete a nearby exercise.
3. **Priority Applications, 35 minutes.** Predict a result, trace a small example, inspect the runnable model, and complete a nearby exercise.

Total: 110 minutes. Lab and homework add guided and independent practice.

## Assignment Roles

Preview checks vocabulary and contracts. Lab contains five connected coding tasks. Homework contains five workplace true/false questions and five standalone coding tasks. Priority policy, heap invariants, top-K selection, and fairness are the direct assessment scope. Graph traversal follows in Chapter 20.

## Section-Boundary Review (2026-10-17)

**Status: implemented.** The following records the reviewed recommendation and its baseline. See Implemented Reading Organization below for the final current filenames and order; earlier meeting allocations are historical where they conflict.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `1801_priority_queues.ipynb`: Priority Queue Contracts and Heap Shape | Core content | 545 | 15 | 5 |
| `1802_heap_implementation.ipynb`: Implementing and Checking a Binary Heap | Core content | 636 | 14 | 5 |
| `1803_priority_applications.ipynb`: Priority Workloads and Top-K Selection | Core content | 412 | 11 | 5 |

**Recommendation:** Retain contract, implementation, and application roles.

The application page is short but top-K and fairness are genuine transfers, not duplicate heap syntax. All three pages need expansion rather than automatic merging.

### Proposed Reading Sequence

1. Priority contracts and heap representation.
2. Heap operations and invariants.
3. Priority workloads, top-K, and fairness.

### Adequacy Before Reorganization

Add index/parent reasoning, empty/singleton/tied-priority traces, heap versus sorted-order distinctions and top-K justification. Correct generic planning text that claims graph traversal is this chapter's direct assessment target.

Reading sections and class meetings are different units; allocate discussion and practice after developing adequate explanations. Do not reduce distinct material to meet a section or word quota.

Preserve every existing explanation, exercise variation and assessment identity. The source-to-destination dispositions in MATERIALS.md govern any later move. Update TOC, links and redirects only in an authorized implementation pass.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `1801_priority_queues.ipynb`: Priority Queue Contracts and Heap Shape.
- `1802_heap_implementation.ipynb`: Implementing and Checking a Binary Heap.
- `1803_priority_applications.ipynb`: Priority Workloads and Top-K Selection.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.

## Landing Page Alignment (2026-10-17)

The landing page `1800_priority_queues.ipynb` now orients students to the three sections (contracts and heap shape; implementing and checking a binary heap; priority workloads and top-k) with a grounded introduction, measurable objectives, and a glossary built from the content notebooks (see MATERIALS.md, Landing Page Development). Preview quizzes should draw vocabulary from that glossary. Class meeting allocations above are unchanged.
