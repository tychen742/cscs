---
orphan: true
---

# Materials: Priority Queues and Heaps

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `1801_priority_queues.ipynb` | Priority Queue Contracts and Heap Shape | Core content |
| `1802_heap_implementation.ipynb` | Implementing and Checking a Binary Heap | Core content |
| `1803_priority_applications.ipynb` | Priority Workloads and Top-K Selection | Core content |

Keep the current section boundaries and recently developed content. Consolidate repeated in-page navigation, distinguish repeated practice headings, retain all substantive explanations/examples and finish the instructional material before the final Footnotes group.

No assessment identity, assignment notebook, worked code, output or exercise variant is removed. `authoring/integration_cleanup/` records the original cells, exact edits, moves and URL/fragment compatibility.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


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

## Landing Page Development (2026-10-17)

`1800_priority_queues.ipynb` was rewritten from a generic template (about 200 words, three generic objectives, six glossary rows) to a full chapter landing page. It now has a chapter introduction grounded in the three sections (contracts and heap shape; implementing and checking a binary heap; priority workloads and top-k) and the chapter's service-desk and reporting examples, seven numbered objectives tied to the removal contract and tie policy, the library queue, array index arithmetic, bubble-up/sink-down traces, the generic BinaryMinHeap with costs, top-k with its invariant, and priority versus fairness, the Chapter Flow in TOC order without the assignments link, a numbered glossary of 30 terms drawn from 1801 through 1803, and a Lecture Slides section marked pending. The existing Chapter Video (Tech With Tim) was kept unchanged and moved to its standard position after the overview. The landing page carries no content sections or index entries; content notebooks, `_toc.yml`, and assignments were not changed.


## Outcome Gap Repair (2026-10-17)

Preserve the current chapter notebooks, reading order, existing explanations, exercise variants, and assessment identifiers. The additions below close the outcome audit gaps within that organization. Explanations belong in content before independent application; earlier scaffolded tasks remain available.

| Location | Development or assessment |
| --- | --- |
| `homework.ipynb` | Implement Heap Repairs Without a Supplied Heap |

Progression: read the relevant lesson and worked example, complete its guided practice, then attempt the added independent homework without copying the solution. Require contract-derived expected results, boundary evidence, and reasoning about the chosen representation or design. Assess process and explanation as well as output. Existing labs remain scaffolded applications rather than the sole evidence of independent mastery.

Lecture decks remain a separately tracked task. No additional chapter, meeting, or required optional-topic track is introduced.

### Verified Topic-to-Assessment Progression

| Topic/outcome | Explanation and worked example | Guided preparation | Independent evidence |
| --- | --- | --- | --- |
| Heap repair and service policy | 1802_heap_implementation and 1803_priority_applications existing repair traces and top-k/fairness development | Existing invariant checker and scaffolded API tasks retained | New independent Push/PopMin bodies, invariant scan after each operation, boundary/duplicate checks, repair trace, fairness/aging scenario, and top-k orientation justification. |

Keep the original five-question coding tracks and smaller historical variations. Added transfer tasks complement them. Grade implementation, independently derived expected results, and the requested reasoning separately; correct output from a supplied class does not establish algorithm construction.
