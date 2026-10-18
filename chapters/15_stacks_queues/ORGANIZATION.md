---
orphan: true
---

# Chapter Organization: Stacks & Queues

## Learning Objectives

Specify restricted-access contracts; trace stack and ring state; implement generic array stacks, bounded ring queues, and linked queues; reason from invariants; distinguish worst-case and amortized work; test boundary behavior; apply access policies to editing and service workflows.

## Instructional Sequence and Pacing

1. Stacks (about 35 minutes): LIFO and safe access, delimiter invariant, push/pop traces, generic implementation, correctness, and amortized growth.
2. Queues and deques (about 40 minutes): FIFO, wraparound, full versus empty, bounded-ring implementation, linked endpoints, logical-order growth, and both-end formulas.
3. Applications (about 35 minutes): access-policy choice, worklist discovery, undo/redo snapshots, fairness, costs, and contract verification.

The 110-minute plan includes student predictions and worked traces rather than reading every implementation line aloud. Existing exercises remain near the concepts they reinforce. Every completed cell is standalone; assignment stubs explicitly require completion.

## Assignments

Preview checks vocabulary and state distinctions. Lab builds one service-desk design through completed history, bounded arrivals, wrapped service, reference-model tests, and front restoration. Homework transfers the concepts to safe peek, ring growth, delimiter rejection, branch invalidation, and fair urgent scheduling. Five coding tasks accompany five true/false questions; answer cells retain verified output.

## Implementation and Verification

Use count rather than element values to determine emptiness. Validate before mutation, clear unused references, update linked endpoints after singleton removal, and copy logical order when growing a wrapped ring. Qualify allocation/growth costs instead of claiming every growable operation is O(1). The local source compares both queue representations with `Queue<int>` and the array stack with `Stack<int>` over reproducible mixed operations.

Lecture slide decks remain pending. Preserve the existing chapter video. The legacy `thebe-interactive` metadata remains until the shared Press UI and book-authoring tag migration is implemented.

## Section-Boundary Review (2026-10-17)

**Status: implemented.** The following records the reviewed recommendation and its baseline. See Implemented Reading Organization below for the final current filenames and order; earlier meeting allocations are historical where they conflict.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `1501_stack.ipynb`: Stacks | Core content | 889 | 23 | 7 |
| `1502_queue_deque.ipynb`: Queues and Deques | Core content | 995 | 25 | 8 |
| `1503_applications_lab.ipynb`: Applications Lab | Core content | 889 | 23 | 7 |

**Recommendation:** Retain; organize queue complexity internally.

LIFO, FIFO and applied policy selection form a coherent sequence. Queue/ring/deque details need layered development, but the current short page should be developed before considering another notebook.

### Proposed Reading Sequence

1. Stack behavior and implementation.
2. Queues, ring buffers, and deque tradeoffs.
3. Access policies, undo/redo, and worklist applications.

### Adequacy Before Reorganization

Develop ring-state traces and the relationship between logical and physical order. Do not combine stacks and queues merely because both restrict access.

Reading sections and class meetings are different units; allocate discussion and practice after developing adequate explanations. Do not reduce distinct material to meet a section or word quota.

Preserve every existing explanation, exercise variation and assessment identity. The source-to-destination dispositions in MATERIALS.md govern any later move. Update TOC, links and redirects only in an authorized implementation pass.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `1501_stack.ipynb`: Stacks.
- `1502_queue_deque.ipynb`: Queues and Deques.
- `1503_applications_lab.ipynb`: Access Policies and Applications.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.
