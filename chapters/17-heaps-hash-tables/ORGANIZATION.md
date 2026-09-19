---
orphan: true
---

# Chapter Organization — Hashing & Heaps

## Learning Objectives

Students should be able to explain priority-queue and dictionary interfaces,
implement basic heap operations, and compare collision-handling strategies in
hash tables.

## Sequence

1. Landing page: chapter purpose, essential terms, learning objectives, Chapter Flow, video, and glossary.
2. `1701-priority-queues.ipynb`: Priority-queue ADT, C# library usage, heap representation, bubble-up, and sink-down.
3. `1702-hashing.ipynb`: Dictionary lookup, hash functions, bucket mapping, collisions, sets, and load factor.
4. `1703-performance-lab.ipynb`: Compare workload fit across priority queues, dictionaries, sets, and lists; include top-k and triage examples.
5. Assignments: Preview for vocabulary, Lab for guided heap/hash-table coding, Homework for concept checks and coding reinforcement.

## Implementation Notes

- Treat a priority queue as the ADT and a heap as one representation.
- Emphasize that C# `PriorityQueue<TElement,TPriority>` is a min-priority queue by default.
- Keep hashing examples stable and small; do not promise permanent string hash-code values across processes or platforms.
