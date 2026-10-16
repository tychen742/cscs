# Chapter Materials — Iteration

## Landing Page

- `0400_iteration.ipynb` — Chapter landing page

## Section Notebooks

- `0401_iteration.ipynb` — Introduction to iteration
- `0402_for_statements.ipynb` — for loops
- `0403_while_statement.ipynb` — while loops

## Assignments

- `assignments/homework_gradecalculation.ipynb` — Homework Gradecalculation
- `assignments/index.ipynb` — Index
- `assignments/lab.ipynb` — Lab
- `assignments/preview.ipynb` — Preview
- `assignments/homework.ipynb` — Homework

## Notes

- Source examples live in `demos/` at the project root.

## Runnable Demo Projects

- [`demos/04/for_loop_demo/`](../../demos/04/for_loop_demo/README.md): For loops and string helpers.
- [`demos/04/while_loop_demo/`](../../demos/04/while_loop_demo/README.md): While loops and a number guessing game.

All demo projects target .NET 10. Run commands and verification are documented
in `demos/README.md` and each project README.

## Prerequisite Alignment (2026-10-16)

Now Chapter 4, after Decisions and before Methods. Active examples use top-level loops; return-based exercises now use loop variables and printed results. Introduce string Length, zero-based indexing, empty-string bounds, and foreach locally in 4.2 before 4.3 uses them. No arrays or later string methods are required for those examples.

The order-entry lab keeps five connected tasks but uses inline validation loops instead of a UI class. Explain TryParse/out as a built-in call, handle exhausted input, and accept exact lowercase y/n without Trim/ToLower. Required homework uses top-level programs and break/continue rather than method returns. The first Grade Calculation stays here; the function-based second assignment moves to Chapter 5. Library calls remain allowed; defining methods and classes is deferred. Existing assessment/cell IDs are preserved.
