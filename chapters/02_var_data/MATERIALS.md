# Chapter Materials — Variables and Data Types

## Landing Page

- `0200_variables_types.ipynb` — Chapter landing page

## Section Notebooks

- `0201_variables_types.ipynb` — Variables, assignment, identifiers, and primitive data types (merged from the former 0201 and 0202, 2026-10-10)
- `0202_operators_built_in_methods.ipynb` — Operators and expressions, then built-in methods: method calls, `Math`, `Parse`, a first look at string methods (full treatment in 3.4)
- `0203_input_output.ipynb` — Console input and output (renamed from 0206)

## Assignments

- `assignments/index.ipynb` — Index
- `assignments/lab.ipynb` — Lab
- `assignments/preview.ipynb` — Preview
- `assignments/homework.ipynb` — Homework

## Notes

- Source examples live in `demos/` at the project root.

## Runnable Demo Projects

- [`demos/02/input/`](../../demos/02/input/README.md): Console input, parsing, and range validation.
- [`demos/02/output/`](../../demos/02/output/README.md): Interview appointment output.

All demo projects target .NET 10. Run commands and verification are documented
in `demos/README.md` and each project README.

## Assessment Alignment (2026-10-15)

- Preview: ten core vocabulary MCQs covering variables, initialization, literals, Boolean values, expressions, arguments, return values, parsing, casts, and formatted output.
- Lab: five connected office-supply stages, preserving the existing cells and IDs. Adds Math.Round return values, Math.Ceiling with conversion before division, and a final three-line input invoice using Trim and Parse. Monetary rounding policies and valid-input assumptions are explicit.
- Homework: five workplace true/false cases and five standalone coding tasks. Tasks assess Math.Max with logical expressions, fractional versus integer division, string return values and Length, three parsed expenses, and Math.Round/Math.Abs in a budget report.
- VS Code starter: `demos/02/order_invoice_starter/`, matching lab stage five. Canonical solutions remain in notebook hide-input cells with executed stdout retained.
- Instructor guidance: `instructor_support/labs/02_assessment_alignment.md`.

These assessments require only sequential code and library calls. User-defined methods, classes, loops, and exception handling are not required. Existing published paths and Lab cell IDs remain unchanged. New Homework exercise IDs use the semantic `cscs-variables-types-homework-coding-*` prefix; existing notebook metadata is retained.

## Keyword Placement (2026-10-15)

The basic reserved-keyword explanation and collapsed list live in Section 1.3. Section 2.1 retains a linked optional note on escaped identifiers and contextual keywords, with a standalone shipment example using meaningful `itemCount` instead of `var var`. The existing `keywords-section` anchor remains in 2.1.
