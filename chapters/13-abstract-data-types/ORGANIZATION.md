---
orphan: true
---

# Chapter Organization — Abstract Data Types

## Learning Objectives

Students should be able to define an abstract data type, distinguish an
interface from an implementation, trace references and object state, and use
generics to write reusable data-structure code.

## Sequence

- ADT contracts, interfaces, client code, and invariants
- Representations, linked references, and operation-cost comparisons
- Generics, type constraints, and reusable ADT implementations

## Integrated Content

The former Generics notebook is now part of this chapter. It should be
connected to the ADT examples by showing how one implementation can support
multiple element types without sacrificing compile-time type checking.

The older `1101-intro-ds.ipynb` and `1102-collection-examples.ipynb` notebooks
are source material, not active sections. They repeat earlier collection
coverage and should be mined later for examples only where they support ADT
contracts or representation tradeoffs.

## Coverage Gaps

The active chapter now moves from ADT contract to representation tradeoffs to
generic implementation. The preview, lab, and homework assignments now align
with this flow. Remaining work: add more worked examples, tune assignment
metadata for any grader integration, and decide whether to remove or archive
the old survey notebooks after useful material is migrated.
