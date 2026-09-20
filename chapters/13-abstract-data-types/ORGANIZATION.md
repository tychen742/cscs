---
orphan: true
---

# Chapter Organization — ADTs

## Learning Objectives

Students should be able to define an abstract data type, distinguish an
interface from an implementation, trace references and object state, use
generics to write reusable data-structure code, and implement `IEnumerable<T>`
with `yield return` so a custom type supports `foreach`.

## Sequence

- ADT contracts, interfaces, client code, and invariants
- Representations, linked references, and operation-cost comparisons
- Generics, type constraints, and reusable ADT implementations
- Iterators: why `foreach` works, `yield return`, custom `IEnumerable<T>` types, lazy evaluation

## Book Scope Note

Added 2026-09-20: this book now spans two semesters in one volume, so this
chapter is not limited to "intro course" depth. Iterators (`yield return`,
custom `IEnumerable<T>`) were added as a full section rather than a passing
mention, since they are the natural extension of this chapter's ADT/interface
framing and Chapter 8 (`0801-collections.ipynb`) now forward-references them
here explicitly.

## Integrated Content

The former Generics notebook is now part of this chapter. It should be
connected to the ADT examples by showing how one implementation can support
multiple element types without sacrificing compile-time type checking.

The older `1101-intro-ds.ipynb` and `1102-collection-examples.ipynb` notebooks
have been moved to Chapter 8 as non-TOC source material for later reuse. Their
reusable collection overview and `List<T>` basics have already been migrated
into active Chapter 8 sections. Any remaining stack, queue, or tuple material
should stay out of this ADT chapter unless a later revision uses it to support
contracts or representation tradeoffs.

## Coverage Gaps

The active chapter now moves from ADT contract to representation tradeoffs to
generic implementation. The preview, lab, and homework assignments now align
with this flow. Remaining work: add more worked examples, tune assignment
metadata for any grader integration, and keep the ADT chapter focused on
contracts, representations, operation costs, and generic implementations.
