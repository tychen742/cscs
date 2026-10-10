---
orphan: true
---

# Chapter Organization: Recursion

## Class Meetings

1. **Recursive contracts and calls, 35 minutes.** State valid domains and base answers, trace factorial frames and returns, prove progress and inductive results, hide helper indexes, and contrast stack cost with iteration.
2. **Divide-and-conquer design, 35 minutes.** Use half-open ranges, preserve odd splits, distinguish one-child search from two-child maximum, derive merge invariants, and inspect stable slice-based merge sort.
3. **Complete stable sorting, 40 minutes.** Hand-trace merge fronts, inspect range/buffer implementation, verify labeled tie order and occurrence preservation, measure actual operations, and connect the invoice-report lab.

The 110-minute plan includes predictions, traces, discussion, and code inspection.

## Assignment Roles

Preview checks contracts and recursive structure. Lab builds a connected invoice-report workflow: recursive sum, merge, sort, identity-preserving stable output, and contract tests. Homework transfers factorial limits, odd maximum ranges, binary-search boundaries, merge extremes, and descending stable comparison.

## Conventions and Scope

Wrappers validate public inputs and hide internal ranges. Sort returns a fresh shallow array copy even for zero/one items, while comparison callbacks must define a consistent ordering. Merge requires sorted inputs. Count active frames including the base frame. Distinguish peak memory from cumulative allocation/write volume, and operation counts from growth estimates. Full searching/sorting comparison belongs in Chapter 22. Slides and exercise-tag migration remain deferred.

## Foundation Placement (2026-10-07)

Basic recursive cases and call/return traces now belong to Chapter 17. This optional chapter begins with progress measures and helper contracts before divide-and-conquer design.

The earlier lecture allocation is superseded where it repeats relocated introductory topics. Use that time for contract counterexamples, verification traces, and the chapter’s optional advanced applications. Students complete Chapters 15, 17, and 19 foundations first as relevant.
