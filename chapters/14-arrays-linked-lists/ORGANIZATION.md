---
orphan: true
---

# Chapter Organization — Linear Lists

## Learning Objectives

Students should be able to implement and compare array-based and linked
sequences, trace references during insertion and deletion, and justify a
representation choice for a workload.

## Sequence

- Dynamic arrays: contiguous storage, count/capacity, resizing, indexing, and amortized append
- Linked nodes: node structure, traversal, insertion after a known node, deletion after a known node, and operation costs
- Comparison lab: visit counts, shift counts, workload-based representation choice

## Implementation Notes

The chapter should follow Chapter 13's ADT framing: students first see the
sequence behavior, then compare two representations. The examples intentionally
use small custom implementations rather than only `List<T>` and
`LinkedList<T>`, because the goal is to make memory representation and
operation cost visible.

## Remaining Work

- Add simple visual figures for array resizing and linked insertion/deletion.
- Consider a generic `SimpleList<T>` implementation if a future pass needs a
  fuller bridge into Chapter 15.

## Assignments

- Preview: vocabulary and concept checks for contiguous storage, capacity,
  resizing, nodes, traversal, and workload-based representation choice.
- Lab: connected implementation practice for dynamic-array growth, linked-node
  traversal, insertion after a known node, and workload recommendations.
- Homework: concept questions, true/false checks, and coding practice for
  capacity tracing, node counting, and array middle insertion. The file is now named `homework.ipynb`.
