---
orphan: true
---

# Chapter Materials: Stacks & Queues

## Active Notebooks

- `1500_stacks_queues.ipynb`: orientation, measurable objectives, flow, video, and glossary.
- `1501_stack.ipynb`: LIFO contract, safe access, delimiter validation, state traces, generic array stack, invariants, and amortized growth cost.
- `1502_queue_deque.ipynb`: FIFO contract, ring wraparound/full/empty traces, bounded generic ring queue, linked endpoints, logical-order growth, and deque tradeoffs.
- `1503_applications_lab.ipynb`: access policies, backtracking, queue discovery, actual undo/redo snapshots, starvation, qualified costs, and contract tests.
- `assignments/preview.ipynb`: ten concept checks, including full/empty ring-buffer state.
- `assignments/lab.ipynb`: five connected service-desk tasks with independent starters, traces, boundary checks, and restoration-policy reasoning.
- `assignments/homework.ipynb`: five true/false questions and five independent coding tasks for safe peek, ring growth, nesting, redo invalidation, and urgent-service limits.

## Runnable Materials

- `demos/15/ServiceDeskStructures.cs`: implementations and 600 seeded reference-model operation checks, with boundary/reuse tests.
- `demos/15/README.md`: local console-project instructions and expected output.

## Verification and Remaining Work

All 29 completed notebook code cells compiled and ran independently. The ten assignment solutions and three content-exercise solutions retain verified output. The source-material checks passed. The full HTML build succeeded with five pre-existing warnings outside Chapter 15. Six browser Run checks passed through the hosted runner: stack growth, ring wraparound, linked singleton reuse, undo/redo, lab contract tests, and bounded urgent scheduling. The downloadable source link resolves. Lecture decks are pending; the missing overview link has been replaced with an explicit pending notice. Existing video retained.

## Coverage Boundary

The stack is growable and does not shrink; the ring queue has a fixed positive capacity and rejects overflow. Ring growth and deque formulas are taught with traces; production iterator invalidation, concurrency, blocking producers, and priority queues are outside this implementation pass. Delimiter validation examines characters only, without parsing source-language strings or comments. Graph traversal correctness receives fuller treatment in later graph chapters.

## Section-Boundary Coverage Disposition (2026-10-17)

**Reviewed plan, now implemented:** Retain; organize queue complexity internally. The disposition below records the preimplementation baseline and rationale. See Implemented Reading Organization for the current reading files. Counts in this baseline exclude fenced code from prose; the refreshed inventory is in authoring/content_size/. They flag review needs, not quality scores.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `1501_stack.ipynb`: Stacks | Core content | 889 | 23 | 7 |
| `1502_queue_deque.ipynb`: Queues and Deques | Core content | 995 | 25 | 8 |
| `1503_applications_lab.ipynb`: Applications Lab | Core content | 889 | 23 | 7 |

### Source-to-Destination Plan

| Existing source | Proposed treatment and coverage to preserve |
| --- | --- |
| `1501` | Retain stack contracts, implementation and delimiter reasoning. |
| `1502` | Use internal subsections to distinguish queue contract, ring representation, wraparound/growth and deque contrast. If future full deque implementation becomes required, reassess a separate page then. |
| `1503` | Retain undo/redo, discovery/fairness and verification instruction as content; a future title such as Access Policies and Applications avoids confusing it with assignments/lab. |

### Development Needed Before Moving Material

Develop ring-state traces and the relationship between logical and physical order. Do not combine stacks and queues merely because both restrict access.

Before a later move, create a cell-level preservation map for these sources, including citations, figures, original code forms, worked traces, guided questions and independent exercise variants. Relocate prerequisite explanations from assignments into content when needed while retaining application requirements and IDs. A consolidated page must still teach its concepts; a split must not create two unsupported outlines. Existing runnable verification records describe earlier work, not verification of this proposal.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `1501_stack.ipynb`: Stacks.
- `1502_queue_deque.ipynb`: Queues and Deques.
- `1503_applications_lab.ipynb`: Access Policies and Applications.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.
