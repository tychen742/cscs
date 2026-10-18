---
orphan: true
---

# Materials: Priority Queues and Heaps

## Core Materials

- `1801_priority_queues.ipynb`: Priority Contracts
- `1802_heap_implementation.ipynb`: Heap Implementation
- `1803_priority_applications.ipynb`: Priority Applications
- `assignments/`: preview, connected lab, homework, and assignment index.

## Verification and Remaining Work

Standalone C# cells and reference console projects are checked during this revision. Updated slides and recordings are pending. Advanced sorting, tree rotations, weighted graph optimization, and further algorithm analysis are optional depth, not additional requirements for this unit.

## Section-Boundary Coverage Disposition (2026-10-17)

**Reviewed plan, now implemented:** Retain contract, implementation, and application roles. The disposition below records the preimplementation baseline and rationale. See Implemented Reading Organization for the current reading files. Counts in this baseline exclude fenced code from prose; the refreshed inventory is in authoring/content_size/. They flag review needs, not quality scores.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `1801_priority_queues.ipynb`: Priority Queue Contracts and Heap Shape | Core content | 545 | 15 | 5 |
| `1802_heap_implementation.ipynb`: Implementing and Checking a Binary Heap | Core content | 636 | 14 | 5 |
| `1803_priority_applications.ipynb`: Priority Workloads and Top-K Selection | Core content | 412 | 11 | 5 |

### Source-to-Destination Plan

| Existing source | Proposed treatment and coverage to preserve |
| --- | --- |
| `1801` | Retain priority policy, ties and array/tree shape relation. |
| `1802` | Develop bubble-up and sink-down through individual state changes and complete operation contracts. |
| `1803` | Retain top-K as a new problem with an explicit invariant and explain why priority differs from fairness. Develop the example before assigning independent variants. |

### Development Needed Before Moving Material

Add index/parent reasoning, empty/singleton/tied-priority traces, heap versus sorted-order distinctions and top-K justification. Correct generic planning text that claims graph traversal is this chapter's direct assessment target.

Before a later move, create a cell-level preservation map for these sources, including citations, figures, original code forms, worked traces, guided questions and independent exercise variants. Relocate prerequisite explanations from assignments into content when needed while retaining application requirements and IDs. A consolidated page must still teach its concepts; a split must not create two unsupported outlines. Existing runnable verification records describe earlier work, not verification of this proposal.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `1801_priority_queues.ipynb`: Priority Queue Contracts and Heap Shape.
- `1802_heap_implementation.ipynb`: Implementing and Checking a Binary Heap.
- `1803_priority_applications.ipynb`: Priority Workloads and Top-K Selection.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.
