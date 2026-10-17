# Chapter Materials: Classes and Objects

## Landing Page

- `1000_classes.ipynb` — Chapter landing page

## Section Notebooks

- `1001_class_syntax.ipynb` — Class syntax, plus tuples as the lightweight alternative to a class (added 2026-10-04 from the former Chapter 8 source notebook `1101-intro-ds`)
- `1002_properties.ipynb` — Properties and fields
- `1003_class_instance.ipynb` — Creating and using instances
- Optional extension: `../appendices/operator_overloading.ipynb`, outside the core chapter flow.

## Assignments

- `assignments/hw_booklist.ipynb` — Hw Booklist
- `assignments/index.ipynb` — Index
- `assignments/lab.ipynb` — Lab
- `assignments/preview.ipynb` — Preview
- `assignments/homework.ipynb` — Homework

## Notes

- Source examples live in `demos/` at the project root.
- Operator overloading should be treated as applied extension material. Core class coverage should emphasize object identity, references, constructors, fields/properties, encapsulation, and class design.

## Runnable Demo Projects

- [`demos/10/classes_demo/`](../../demos/10/classes_demo/README.md): Class instances and methods.
- [`demos/10/classes_lab/`](../../demos/10/classes_lab/README.md): Animal/employee objects and instance versus static guessing games.
- [`demos/10/enum_demo/`](../../demos/10/enum_demo/README.md): Enum values and their integer representation.

All demo projects target .NET 10. Run commands and verification are documented
in `demos/README.md` and each project README.


## Instance Lesson Refresh

The third lesson now uses a single runnable CashRegister model: independent state, properties, validation, calculated average, and reset behavior. Homework follows five true/false and five standalone coding tasks. The existing connected coffee-register lab is retained.

## Assignment Revision (2026-10-15)

Preview now has ten vocabulary multiple-choice questions with radio controls and explanations. The five-stage coffee-register lab retains its progression from static calculations to independent objects, validated properties, shared members, and ToString reports. Input assumptions and receipt-rounding policy are explicit.

Homework has five workplace true/false cases (three true, two false) and five standalone coding tasks: supplier construction, stock withdrawal guards, calculated invoices, shared ticket numbering, and independent purchase-order reports. Existing Homework exercise IDs and assignment ID are preserved. Hidden coding answers retain verified output.

The stage-five VS Code starter lives in `demos/10/coffee_register_starter/`. Canonical lab and homework solutions remain in the notebook answer cells. See `instructor_support/labs/10_classes_assignments.md` for checks and teaching guidance. The legacy Book List page remains optional practice after Chapter 11; its full solution is outside this revision.

## Restored CS1 Material (2026-10-17)

- `assignments/additional_practice.ipynb`: restored explanations and exercises; retains current lessons and assignment IDs.
