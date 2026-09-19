---
orphan: true
---

# Chapter Organization — Algorithm Analysis

## Learning Objectives

Students should be able to state an algorithm's preconditions and
postconditions, use invariants to reason about correctness, classify common
time and space growth rates, and describe the cost of recursive algorithms
with recurrence relations.

## Sequence

- `1900-algorithm-analysis.ipynb`: chapter landing page with essential concepts, learning objectives, chapter flow, glossary, and slides placeholder
- `1901-big-o.ipynb`: operation counting, common growth rates, loop patterns, Big-O/Big-Theta, and space complexity
- `1902-correctness.ipynb`: specifications, preconditions, postconditions, loop invariants, invariant arguments, and the relationship between tests and reasoning
- `1903-recurrences.ipynb`: recursive cost, halving recurrences, divide-and-conquer recurrences, recursion stack space, and overlapping subproblems
- `assignments/index.ipynb`: assignment TOC parent
- `assignments/preview.ipynb`: pre-class concept quiz
- `assignments/lab.ipynb`: required technical lab for counting, precondition checks, invariant tracing, and recursive-depth estimation
- `assignments/homework.ipynb`: post-class true/false and coding practice

## Coverage Boundary

This chapter should teach analysis tools, not the full catalog of algorithms.
Searching and sorting appear later in Chapter 21, graph optimization appears in
Chapter 22, and dynamic programming appears in Chapter 23. Use brief examples
only when they clarify growth or correctness reasoning.

## Assignment Plan

- Preview: vocabulary and recognition of complexity, preconditions, invariants, and recurrences.
- Lab: count loop operations, compare nested-loop counts, guard preconditions, trace an invariant, and estimate recursive depth.
- Homework: reinforce Big-O limits, method guards, search reasoning, and simple recursive cost.

## Notes

Searching and sorting are retained as source material for Chapter 21. They are
not part of this analysis chapter's weekly scope.
