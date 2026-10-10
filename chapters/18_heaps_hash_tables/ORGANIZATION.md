---
orphan: true
---

# Chapter Organization: Hashing and Heaps

## Learning Objectives

Students preserve heap and hash-table invariants during complete operations, define comparison/equality policies, qualify cost claims, and coordinate collections for service desk dispatch.

## Class Meetings

1. **Priority queues and heaps, 35 minutes.** Define urgency and stable ties; distinguish binary teaching layout from library internals; hand-trace array indexes, bubble-up, and smaller-child sink-down; inspect complete generic operations and boundary tests.
2. **Hashing and collisions, 40 minutes.** Trace equality-aware dictionary updates, signed hash mapping, chained lookup/replacement/removal, and rehashing. Explain load factor and expected costs. Contrast tombstone-based probing with chaining.
3. **Workload comparison, 35 minutes.** Compare operation counts and cost assumptions; trace the top-k retained-prefix invariant; coordinate dictionary/heap state under cancellation; discuss individual-call cleanup costs and the connected dispatcher lab.

The lecture plan totals 110 minutes, including predictions, hand traces, discussion, and code inspection. Assignments provide additional guided and independent work.

## Assignment Roles

- Preview checks core concepts and the distinction between chaining load and table-slot occupancy.
- Lab completes heap repair, collision-aware owner storage, removal/rehashing, and registration/cancellation/dispatch in one service desk theme. Each cell is standalone; students explicitly carry methods forward.
- Homework transfers invariant checks, custom ordering, equality-aware counts, forced collisions, and top-k boundaries to independent tasks.

## Scope and Conventions

- Keep complete binary-heap and chained-map teaching implementations. Treat bottom-up heap construction, full open addressing, and indexed/versioned priority updates as extensions.
- Reject ID reuse during the simple dispatch batch so presence-based lazy deletion is correct; explain why reprioritization/reuse needs version checks or an indexed heap.
- Do not infer complexity from one stopwatch result or promise worst-case constant hashing. Use deterministic examples and stated assumptions.
- Slides and exercise-tag/UI migration remain deferred to the shared Press work.
