---
orphan: true
---

# Chapter Organization — Data Collections

## Learning Objectives

Students should be able to choose between arrays, lists, and dictionaries for
common storage tasks; write basic `List<T>` code for growing ordered data; and
write basic `Dictionary<TKey,TValue>` code for key/value lookup. Students should
also recognize eight collection families, explain their access contracts, and
distinguish sharing a collection reference from copying its elements.

## Sequence

- Data collections (40 minutes): operations and contracts; a cited eight-family table; access patterns; generic types and namespaces; worked bookstore choices; family demonstrations; traversal and shared references.
  Small, standalone demonstrations introduce behavior before the detailed APIs.
  Sets, linked lists, stacks, queues, and priority queues are recognition-level
  orientation here, not new implementation or required advanced API exercises.
- Lists (`List<T>`, 35 minutes): indexed sequences and practical list operations.
- Dictionaries (`Dictionary<TKey,TValue>`, 35 minutes): key-based storage and lookup.

The three meetings total 110 minutes. Section 8.1 ends with a standalone list/dictionary summary exercise and includes conceptual checks on representation and processing order.

## Notes

- The former source notebooks `0802-list-dictionary`, `1101-intro-ds`, and `1102-collection-examples` were removed 2026-10-04 after review: their list, dictionary, and collection-overview material was already in `0801`–`0803`, stacks and queues live in Chapter 15, `HashSet<T>` in Chapter 19, and the tuples material moved to `10_classes/1001_class_syntax.ipynb`.
- `HashSet<T>` receives a brief behavioral demonstration in 8.1. Its detailed API, hashing, equality, and set operations remain in Chapter 19.
- Recognize LIFO, FIFO, and priority-based access in 8.1; detailed stack/queue work stays in Chapter 15 and heaps/priority queues in Chapter 18. Linked-list implementations stay in Chapter 14.

## Source History

The September 2026 history includes broader `1101-intro-ds` and `1102-collection-examples` notebooks. Their removal during consolidation left 0801 at roughly 740 Markdown words. The 2026-10-16 expansion restores the conceptual introduction with original business examples; it does not restore outdated APIs, tuple material, or implementation lessons. Existing section paths, assessment identifiers, and the three-section chapter sequence are preserved.

The opening develops the whole collection idea before the family examples: shared operations and contracts, the source-cited family map, generic types and library organization, and representation choices. Individual families then illustrate that framework. The table is explicitly adapted from Microsoft Learn, with the source references in the independent Footnotes block.
