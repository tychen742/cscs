---
orphan: true
---

# Chapter Materials: Stacks & Queues

## Active Notebooks

- `1600-stacks-queues.ipynb`: orientation, measurable objectives, flow, video, and glossary.
- `1601-stack.ipynb`: LIFO contract, safe access, delimiter validation, state traces, generic array stack, invariants, and amortized growth cost.
- `1602-queue-deque.ipynb`: FIFO contract, ring wraparound/full/empty traces, bounded generic ring queue, linked endpoints, logical-order growth, and deque tradeoffs.
- `1603-applications-lab.ipynb`: access policies, backtracking, queue discovery, actual undo/redo snapshots, starvation, qualified costs, and contract tests.
- `assignments/preview.ipynb`: ten concept checks, including full/empty ring-buffer state.
- `assignments/lab.ipynb`: five connected service-desk tasks with independent starters, traces, boundary checks, and restoration-policy reasoning.
- `assignments/homework.ipynb`: five true/false questions and five independent coding tasks for safe peek, ring growth, nesting, redo invalidation, and urgent-service limits.

## Runnable Materials

- `materials/16/ServiceDeskStructures.cs`: implementations and 600 seeded reference-model operation checks, with boundary/reuse tests.
- `materials/16/README.md`: local console-project instructions and expected output.

## Verification and Remaining Work

All 29 completed notebook code cells compiled and ran independently. The ten assignment solutions and three content-exercise solutions retain verified output. The source-material checks passed. The full HTML build succeeded with five pre-existing warnings outside Chapter 16. Six browser Run checks passed through the hosted runner: stack growth, ring wraparound, linked singleton reuse, undo/redo, lab contract tests, and bounded urgent scheduling. The downloadable source link resolves. Lecture decks are pending; the missing overview link has been replaced with an explicit pending notice. Existing video retained.

## Coverage Boundary

The stack is growable and does not shrink; the ring queue has a fixed positive capacity and rejects overflow. Ring growth and deque formulas are taught with traces; production iterator invalidation, concurrency, blocking producers, and priority queues are outside this implementation pass. Delimiter validation examines characters only, without parsing source-language strings or comments. Graph traversal correctness receives fuller treatment in later graph chapters.
