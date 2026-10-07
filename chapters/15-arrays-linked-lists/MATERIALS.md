---
orphan: true
---

# Chapter Materials: Linear Lists

## Active Notebooks

- `1500-arrays-linked-lists.ipynb`: orientation, objectives, flow, video, and glossary.
- `1501-dynamic-arrays.ipynb`: count/capacity invariants, growth traces, insertion/removal shifts, complete generic array sequence, and amortized-copy derivation.
- `1502-linked-nodes.ipynb`: aliases and traversal, insertion order, head/tail removal cases, complete generic singly linked sequence, repeated-indexing costs, and doubly linked tradeoffs.
- `1503-comparison-lab.ipynb`: workload assumptions, operation-count tables, contract test matrix, locality, and evidence-based representation choice.
- `assignments/index.ipynb`: assignment navigation.
- `assignments/preview.ipynb`: ten vocabulary and concept checks.
- `assignments/lab.ipynb`: five connected work-order tasks: growth, insertion, removal, linked endpoints, and shared contract checks with workload reasoning.
- `assignments/homework.ipynb`: concept checks, five true/false items, five coding tasks including copy/write accounting and safe singleton removal, and an independent design challenge.

## Runnable Materials

- `materials/15/WorkOrderLists.cs`: standalone generic implementations with matching contract checks, reference-model comparisons, and copy-cost checks.
- `materials/15/README.md`: local console-project instructions and expected verification output.

## Coverage Boundary

The array intentionally does not shrink. The linked wrapper keeps nodes private and exposes index-based operations; earlier node examples teach updates after known nodes. Doubly linked lists are explained but not implemented. Very large capacity overflow, concurrent mutation, and production iterator invalidation are extensions. Existing video retained.

## Follow-up Verification (2026-10-05)

All 22 completed notebook cells compiled and ran independently with `dotnet run --no-restore`; the ten assignment solutions retain expected output. The source material passed its 600 seeded mixed operations and endpoint checks. Full HTML build succeeded with five warnings; the subsequent incremental build succeeded without warnings. Browser checks use a temporary localhost preview and the hosted runner. Public instructional classes omit `sealed` because the current runner's loose-member detector does not recognize that modifier combination. Lecture slides remain pending.

## Foundation Placement (2026-10-07)

Added `1504_searching_sorting.ipynb`: first-match linear search, iterative binary search, missing-target traces, library search results, stable reports, and a standalone report exercise. Detailed custom sorting, duplicate bounds, and workload analysis remain in Chapter 22.

## Move Verification (2026-10-07)

The four receiving sections contain 21 completed cells. Each compiled and ran in an isolated namespace with its own setup under .NET 10; completed exercise answers retain captured stdout. Intentional student starters were excluded. The full Jupyter Book build passed with the five previously recorded warnings outside these chapters. New content pages and prerequisite links are included in the TOC and rendered output. Slides remain pending.
