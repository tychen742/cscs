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

## Section-Boundary Coverage Disposition (2026-10-17)

**Reviewed plan, now implemented:** Retain distinct lessons; expand two thin ones. The disposition below records the preimplementation baseline and rationale. See Implemented Reading Organization for the current reading files. Counts in this baseline exclude fenced code from prose; the refreshed inventory is in authoring/content_size/. They flag review needs, not quality scores.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `0601_error_handling.ipynb`: Error Handling and Validation | Core content | 280 | 14 | 4 |
| `0602_debugging_workflow.ipynb`: Debugging Workflow | Core content | 313 | 13 | 3 |
| `0603_testing.ipynb`: Unit Testing | Core content | 2,984 | 13 | 5 |
| `0605_software_responsibility.ipynb`: Computing and Society | Supporting reading | 942 | 17 | 2 |

### Source-to-Destination Plan

| Existing source | Proposed treatment and coverage to preserve |
| --- | --- |
| `0601` | Keep validation versus exceptions, TryParse/null checks, specific try/catch and throwing; treat file I/O as a forward-linked preview until Chapter 9, not an unexplained prerequisite. |
| `0602` | Retain a complete reproducible debugging case with hypotheses, breakpoint/step/watch observations, repair and regression check. |
| `0603` | Retain unit testing; develop the project workflow from content before the lab. Use the preserved unit_testing_walkthrough assignment as a source for prerequisite explanations, while retaining all lab tasks. |
| `0605` | Keep software-failure/responsibility cases optional and linked to the relevant testing principles. |

### Development Needed Before Moving Material

Add interpreted error examples, validation/failure-policy comparisons and an actual debugging walkthrough. The large testing page is not evidence that the other two lessons are adequate.

Before a later move, create a cell-level preservation map for these sources, including citations, figures, original code forms, worked traces, guided questions and independent exercise variants. Relocate prerequisite explanations from assignments into content when needed while retaining application requirements and IDs. A consolidated page must still teach its concepts; a split must not create two unsupported outlines. Existing runnable verification records describe earlier work, not verification of this proposal.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `0601_error_handling.ipynb`: Error Handling and Validation.
- `0602_debugging_workflow.ipynb`: Debugging Workflow.
- `0603_testing.ipynb`: Unit Testing.
- `0605_software_responsibility.ipynb`: Computing and Society.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.
