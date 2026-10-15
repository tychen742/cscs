# Chapter Materials — Exceptions and Testing

## Landing Page

- `0600_exceptions_testing.ipynb` — Chapter landing page

## Section Notebooks

- `0601_error_handling.ipynb` — Exception handling
- `0602_debugging_workflow.ipynb` — Debugging workflow
- `0603_testing.ipynb` — Unit testing
- `0604_nullable.ipynb` — Nullable types and null operators

## Assignments

- `assignments/index.ipynb` — Index
- `assignments/lab.ipynb` — Lab
- `assignments/preview.ipynb` — Preview
- `assignments/homework.ipynb` — Homework

## Notes

- Source examples live in `demos/` at the project root.
- Nullable value and reference types are integrated here because missing data and invalid state connect naturally to validation, exceptions, debugging, and testing.

## Runnable Demo Projects

- [`demos/06/exceptions_demo/`](../../demos/06/exceptions_demo/README.md): Caught exception demonstration.
- [`demos/06/math_lab/math_app/`](../../demos/06/math_lab/math_app/README.md): Arithmetic console demonstration.
- [`demos/06/math_lab/math_app_test/`](../../demos/06/math_lab/math_app_test/README.md): Unit tests for the arithmetic lab.
- [`demos/06/math_tests/math_app/`](../../demos/06/math_tests/math_app/README.md): Basic arithmetic library.
- [`demos/06/math_tests/math_app_test/`](../../demos/06/math_tests/math_app_test/README.md): Unit tests for the arithmetic library.

All demo projects target .NET 10. Run commands and verification are documented
in `demos/README.md` and each project README.

## Integrated Responsibility Practice (2026-10-15)

Optional `0605_software_responsibility.ipynb` retains software-failure cases and boundary-test demonstrations from the former ethics chapter. It extends core testing without adding a required meeting.

## AI Literacy Integration (2026-10-15)

The testing lesson adds a prepared AI-review activity in which ordinary tests pass while the boundary and invalid cases expose defects. Students derive expected outcomes independently, repair the implementation, and retain the same checks. Use it within the existing practice time.
