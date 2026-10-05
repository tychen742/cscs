---
orphan: true
---

# Chapter Materials — Hashing & Heaps

## Sequence

- `1800-heaps-hash-tables.ipynb` — landing page with overview, objectives, Chapter Flow, video, and glossary
- `1801-priority-queues.ipynb` — priority-queue ADT, C# `PriorityQueue`, heap shape/order rules, bubble-up, and sink-down
- `1802-hashing.ipynb` — hash functions, buckets, collisions, dictionaries, sets, and load factor
- `1803-performance-lab.ipynb` — workload choice, dictionary lookup timing, top-k with a min-heap, and integrated triage example
- `assignments/preview.ipynb` — Preview
- `assignments/lab.ipynb` — Lab
- `assignments/homework.ipynb` — Homework

## Coverage Notes

- Core coverage includes priority queues, min-heaps, array-backed heap indexing, heap repair operations, hash functions, collisions, load factor, `Dictionary<TKey,TValue>`, and `HashSet<T>`.
- The chapter uses C#'s built-in `PriorityQueue<TElement,TPriority>` for application examples and small array/list examples to expose heap mechanics.
- Hash-table internals are kept conceptual; production `Dictionary` implementation details are not required for this chapter.
