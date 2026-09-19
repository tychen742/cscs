---
orphan: true
---

# Chapter Organization — Stacks & Queues

## Learning Objectives

Students should be able to specify stack, queue, and deque operations, choose
an implementation, and apply these structures to practical problems.

## Sequence

1. Landing page: chapter purpose, core vocabulary, learning objectives, Chapter Flow, and glossary.
2. `1501-stack.ipynb`: Stack interface, LIFO behavior, safe access, delimiter matching, and small array-backed implementation.
3. `1502-queue-deque.ipynb`: Queue interface, FIFO behavior, worklists, ring-buffer logic, and deque operations.
4. `1503-applications-lab.ipynb`: Application patterns for undo, service lines, urgent work, backtracking, and breadth-first processing.
5. Assignments: Preview for vocabulary, Lab for guided stack/queue/deque practice, Homework for concept checks and coding reinforcement.

## Implementation Notes

- Keep stacks and queues framed as ADTs first; C# library types are examples of the contract, not the definition.
- Emphasize access policy: last saved, first served, both ends, or arbitrary access.
- Use small standalone cells so browser execution does not depend on hidden state from earlier examples.
