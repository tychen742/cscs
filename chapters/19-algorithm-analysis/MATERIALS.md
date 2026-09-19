---
orphan: true
---

# Chapter Materials — Algorithm Analysis

## Landing Page

- `1900-algorithm-analysis.ipynb` — landing page, essential concepts, learning objectives, chapter flow, glossary, slides placeholder

## Section Notebooks

- `1901-big-o.ipynb` — operation counting, common growth rates, loop patterns, Big-O/Big-Theta, space complexity
- `1902-correctness.ipynb` — specifications, preconditions, postconditions, loop invariants, testing versus reasoning
- `1903-recurrences.ipynb` — recursive cost, halving recurrences, divide-and-conquer recurrences, recursion stack space, overlapping subproblems

## Assignments

- `assignments/index.ipynb` — Index
- `assignments/preview.ipynb` — Preview
- `assignments/lab.ipynb` — Lab
- `assignments/homework.ipynb` — Homework

## Coverage Notes

- This chapter introduces analysis skills before students study recursion, divide-and-conquer, searching, sorting, and graph optimization in later chapters.
- Keep searching and sorting examples brief and generic here. Detailed searching and sorting belong in Chapter 21.
- Keep recurrence work concrete: expand simple recurrences, estimate recursion depth, and connect divide-and-conquer to `O(n log n)` without requiring a full Master Theorem treatment.

## Maintenance Notes

- Source examples live in `materials/` at the project root.
- Browser-runnable code cells should remain standalone.
- Prefer small values of `n` in printed demonstrations so students can compare counts by hand.
