---
orphan: true
---

# Chapter Materials — Stacks, Queues, and Deques

## Sequence

- `1500-stacks-queues.ipynb` — landing page with overview, objectives, Chapter Flow, and glossary
- `1501-stack.ipynb` — stack ADT behavior, safe access, delimiter matching, and array-backed stack implementation
- `1502-queue-deque.ipynb` — queue ADT behavior, worklists, ring buffers, and deque operations using `LinkedList<T>`
- `1503-applications-lab.ipynb` — choosing between stacks, queues, and deques for undo, scheduling, backtracking, and breadth-first processing
- `assignments/preview.ipynb` — Preview
- `assignments/lab.ipynb` — Lab
- `assignments/homework.ipynb` — Homework

## Coverage Notes

- Core coverage now includes stack, queue, deque, LIFO/FIFO access rules, empty-structure checks, ring-buffer motivation, and practical C# library usage.
- The chapter intentionally uses `LinkedList<T>` to demonstrate deque behavior because .NET does not provide a dedicated general-purpose `Deque<T>` in the base class library.
- Later graph chapters should revisit queue-based breadth-first traversal in more depth.
