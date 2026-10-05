---
orphan: true
---

# Chapter Materials: Hashing and Heaps

## Sequence

- `1800-heaps-hash-tables.ipynb`: Orientation, measurable objectives, glossary, and content flow.
- `1801-priority-queues.ipynb`: Priority/tie contracts, binary array indexing, repair traces, complete generic heap, correctness, and qualified costs.
- `1802-hashing.ipynb`: Equality/hash agreement, safe bucket mapping, complete chained map, collision updates, rehashing, tombstones, and case-insensitive collections.
- `1803-performance-lab.ipynb`: Workload costs, controlled comparison counts, top-k prefix invariants, and cancellation across two indexes.
- `assignments/preview.ipynb`: Ten multiple-choice concept questions, including chaining load factor greater than one.
- `assignments/lab.ipynb`: Five connected tasks building a service desk dispatcher from the heap and map.
- `assignments/homework.ipynb`: Five applied true/false questions and five independent coding tasks.
- `../../materials/18/HeapHashStructures.cs`: Downloadable complete structures and reference-model verification program.

## Depth Coverage

- Distinguish the priority-queue ADT from a binary heap representation and from .NET's library layout. Define tie behavior explicitly.
- Trace bubble-up/sink-down and explain why the smaller child and singleton boundary matter. Qualify array growth versus heap repair cost.
- Separate equality from hash collisions. Use unsigned bit interpretation for negative hash codes, including int.MinValue.
- Implement chaining lookup, replacement, removal, Count, and geometric rehashing. Explain expected costs, pathological chains, and the teaching resize policy.
- Trace linear-probing deletion with tombstones and bounded probes; full open-addressed implementation remains an extension.
- Compare relevant work before noisy timings; state top-k prefix invariants, duplicate/boundary policies, and lazy-deletion cleanup costs.
- Extend practice to full heap validation, safe reversed comparison, ordered category reports, deliberate collisions, and top-k boundaries.

## Verification and Deferred Work

- All 28 completed examples/answers compile and run independently with dotnet. Ten assignment answers and three lesson answers retain verified stdout.
- Reference-model source checks 600 mixed heap operations and 600 map operations plus explicit boundaries. Transfer checks compare top-k with a sorted reference across 600 cases.
- Notebook schema, indexed-heading, source-consistency, and saved-output checks pass. The full book build succeeds with five pre-existing warnings outside Chapter 18. Narrow/desktop inspection and six browser Run checks pass: complete heap, stable priority ties, chained rehashing, tombstone lookup, integrated dispatcher, and top-k boundaries.
- Lecture slides remain deferred. Later Press work provides HTML/PDF for students and instructor-only PPTX downloads; legacy exercise metadata remains until the coordinated UI migration.
