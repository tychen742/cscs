---
orphan: true
---

# Chapter Materials: Linear Lists

## Active Notebooks

- `1400_arrays_linked_lists.ipynb`: orientation, objectives, flow, video, and glossary.
- `1401_dynamic_arrays.ipynb`: count/capacity invariants, growth traces, insertion/removal shifts, complete generic array sequence, and amortized-copy derivation.
- `1402_linked_nodes.ipynb`: aliases and traversal, insertion order, head/tail removal cases, complete generic singly linked sequence, repeated-indexing costs, and doubly linked tradeoffs.
- `1403_comparison_lab.ipynb`: workload assumptions, operation-count tables, contract test matrix, locality, and evidence-based representation choice.
- `assignments/index.ipynb`: assignment navigation.
- `assignments/preview.ipynb`: ten vocabulary and concept checks.
- `assignments/lab.ipynb`: five connected work-order tasks: growth, insertion, removal, linked endpoints, and shared contract checks with workload reasoning.
- `assignments/homework.ipynb`: concept checks, five true/false items, five coding tasks including copy/write accounting and safe singleton removal, and an independent design challenge.

## Runnable Materials

- `demos/14/WorkOrderLists.cs`: standalone generic implementations with matching contract checks, reference-model comparisons, and copy-cost checks.
- `demos/14/README.md`: local console-project instructions and expected verification output.

## Coverage Boundary

The array intentionally does not shrink. The linked wrapper keeps nodes private and exposes index-based operations; earlier node examples teach updates after known nodes. Doubly linked lists are explained but not implemented. Very large capacity overflow, concurrent mutation, and production iterator invalidation are extensions. Existing video retained.

## Follow-up Verification (2026-10-05)

All 22 completed notebook cells compiled and ran independently with `dotnet run --no-restore`; the ten assignment solutions retain expected output. The source material passed its 600 seeded mixed operations and endpoint checks. Full HTML build succeeded with five warnings; the subsequent incremental build succeeded without warnings. Browser checks use a temporary localhost preview and the hosted runner. Public instructional classes omit `sealed` because the current runner's loose-member detector does not recognize that modifier combination. Lecture slides remain pending.

## Historical Foundation Placement (2026-10-07, superseded)

The following records an earlier placement. Searching and sorting now belong to Chapter 16; do not use this historical allocation as the current teaching sequence.

Added `1601_searching.ipynb`: first-match linear search, iterative binary search, missing-target traces, library search results, stable reports, and a standalone report exercise. Detailed custom sorting, duplicate bounds, and workload analysis remain in Chapter 23.

## Move Verification (2026-10-07)

The four receiving sections contain 21 completed cells. Each compiled and ran in an isolated namespace with its own setup under .NET 10; completed exercise answers retain captured stdout. Intentional student starters were excluded. The full Jupyter Book build passed with the five previously recorded warnings outside these chapters. New content pages and prerequisite links are included in the TOC and rendered output. Slides remain pending.


## 2026-10-15 Scope

Searching and sorting now form Chapter 16, following stacks and queues. This chapter focuses on linear storage and its contracts.

## Section-Boundary Coverage Disposition (2026-10-17)

**Reviewed plan, now implemented:** Retain representation-to-comparison sequence. The disposition below records the preimplementation baseline and rationale. See Implemented Reading Organization for the current reading files. Counts in this baseline exclude fenced code from prose; the refreshed inventory is in authoring/content_size/. They flag review needs, not quality scores.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `1401_dynamic_arrays.ipynb`: Dynamic Arrays | Core content | 1,294 | 25 | 4 |
| `1402_linked_nodes.ipynb`: Linked Nodes | Core content | 1,122 | 27 | 5 |
| `1403_comparison_lab.ipynb`: Representation Comparison Lab | Core content | 1,102 | 22 | 3 |

### Source-to-Destination Plan

| Existing source | Proposed treatment and coverage to preserve |
| --- | --- |
| `1401` | Retain dynamic-array invariants, growth/shifts and amortized derivation. |
| `1402` | Retain linked updates/endpoints, lost-link/cycle reasoning and doubly linked contrast. |
| `1403` | Keep cost/workload/contract-testing explanations in content; treat its tasks as guided practice and use a future navigation title such as Representation Tradeoffs. Keep the separate assignments lab. |

### Development Needed Before Moving Material

Preserve the workload comparison and all implementation variants; clarify navigation/lesson-versus-assignment roles. Remove stale planning claims that search remains in Chapter 14; the core search lesson is Chapter 16.

Before a later move, create a cell-level preservation map for these sources, including citations, figures, original code forms, worked traces, guided questions and independent exercise variants. Relocate prerequisite explanations from assignments into content when needed while retaining application requirements and IDs. A consolidated page must still teach its concepts; a split must not create two unsupported outlines. Existing runnable verification records describe earlier work, not verification of this proposal.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `1401_dynamic_arrays.ipynb`: Dynamic Arrays.
- `1402_linked_nodes.ipynb`: Linked Nodes.
- `1403_comparison_lab.ipynb`: Representation Tradeoffs and Verification.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.
