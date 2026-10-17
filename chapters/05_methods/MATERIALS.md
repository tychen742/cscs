# Chapter Materials — Methods

## Landing Page

- `0500_methods.ipynb` — Chapter landing page

## Section Notebooks

- `0501_intro_methods.ipynb` — Introduction to methods
- `0502_signature_call.ipynb` — Method signatures and calls
- `0503_parameter.ipynb` — Parameters and return values
- `0504_strings.ipynb` — Strings and their methods (moved early from Chapter 9's text operations, 2026-10-04): length, indexing, cleaning, immutability, searching, `Substring`, `Replace`, chaining
- `0505_summary.ipynb` — Methods summary and practice

## Assignments

- `assignments/index.ipynb` — Index
- `assignments/lab.ipynb` — Lab
- `assignments/preview.ipynb` — Preview
- `assignments/homework.ipynb` — Homework

## Notes

- Source examples live in `demos/` at the project root.

## Runnable Demo Projects

- [`demos/05/methods_demo/`](../../demos/05/methods_demo/README.md): Method calls, parameters, and return values.

All demo projects target .NET 10. Run commands and verification are documented
in `demos/README.md` and each project README.

Instructor support: [current lab walkthrough](../../instructor_support/labs/05_lab_solution.md). See its scope before treating a demo as an assignment answer.

## AI Literacy Integration (2026-10-15)

The method-signature lesson adds a prepared AI-review activity about a packing-charge contract. Students identify a missing fixed amount, trace two calls, and repair the return expression. It requires no decisions/loops and can replace similar method practice.

- `assignments/homework_gradecalculation2.ipynb`: optional grade-average application using methods, moved from Iteration.

## Prerequisite Alignment (2026-10-16)

Now Chapter 5, after Decisions and Iteration. Students already call built-in methods (Chapter 2), choose branches (3), and repeat work (4). Use that experience to motivate naming tasks, parameters, return values, decomposition, and repeatable tests before Chapter 6. Full string cleaning/search/extraction/chaining remains in 5.4; minimal equality/length/indexing is already introduced where needed earlier.

The optional Grade Calculation 2 assignment now lives here because its FindAverage and reusable category-input requirements need method definitions. Its identifiers and published old URL are retained through migration/redirects. The method-based loop demo is supplementary practice after this chapter; it is not an Iteration prerequisite.

## Restored CS1 Material (2026-10-17)

- `assignments/additional_practice.ipynb`: restored explanations and exercises; retains current lessons and assignment IDs.

## CS1 Preservation Follow-up (2026-10-17)

Complete original returning-method equivalence/side-effect/unreachable/semicolon/nested-else fragments restored after method prerequisites. Strange Sequence now also has the original separate Jump, PrintStrangeSequence and CountStrangeSequence contracts, alongside the earlier combined variant. Term versus transition counting is explicit.

The final source-list check also retains the original named array, reversal, and small abstract/interface variations in the corresponding supporting practice; see the preservation matrix for exact locations.
