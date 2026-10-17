# Chapter Materials — Testing, Debugging, and Error Handling

## Landing Page

- `0600_exceptions_testing.ipynb` — Chapter landing page

## Section Notebooks

- `0601_error_handling.ipynb` — Exception handling
- `0602_debugging_workflow.ipynb` — Debugging workflow
- `0603_testing.ipynb` — Unit testing
- Deeper nullability supporting reading moved to `../11_object_design/1104_nullability.ipynb`; historical URLs redirect there.

## Assignments

- `assignments/index.ipynb` — Index
- `assignments/lab.ipynb` — Lab
- `assignments/preview.ipynb` — Preview
- `assignments/homework.ipynb` — Homework

## Notes

- Source examples live in `demos/` at the project root.
- Retain basic missing-input/null checks here. Deeper nullable value/reference types, compiler warnings, and object contracts belong to Chapter 11.
- Align Chapter 6 assessments with this reduced scope in the next assessment pass; preserve existing IDs. Early diagnostic/test practice is specified in the book plan, not claimed as newly authored here.

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

## Restored CS1 Material (2026-10-17)

- `assignments/unit_testing_walkthrough.ipynb`: restored explanations and exercises; retains current lessons and assignment IDs.
