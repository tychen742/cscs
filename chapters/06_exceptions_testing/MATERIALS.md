# Chapter Materials — Testing, Debugging, and Error Handling

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `0601_error_handling.ipynb` | Error Handling and Validation | Core content |
| `0602_debugging_workflow.ipynb` | Debugging Workflow | Core content |
| `0603_testing.ipynb` | Unit Testing | Core content |
| `0605_software_responsibility.ipynb` | Computing and Society | Supporting reading |

Keep the newly developed validation/debugger lessons and all original unit-testing material. The framework-setup/test-attribute discussion is now content before Footnotes. Historical commented reference banks remain preserved as source; they are not newly certified current setup instructions.

No assessment identity, assignment notebook, worked code, output or exercise variant is removed. `authoring/integration_cleanup/` records the original cells, exact edits, moves and URL/fragment compatibility.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Current Priority-Section Coverage (2026-10-17)

This coverage update describes the current notebooks and supersedes older pre-reorganization filename summaries below. Historical plans and verification records are retained.

| Reading | Developed content-section coverage |
| --- | --- |
| `0601_error_handling.ipynb` | Trace normal and exceptional control, specific catches, finally, throw contracts and guided boundary checks. |
| `0602_debugging_workflow.ipynb` | Use a prerequisite-safe methods/loop debugger case with commands, watch observations, repair and regression evidence. |

Use the existing three meetings: validation/control flow, debugging with methods and loops, then unit testing. Arrays and CSV are explicitly retained as later applications after Chapters 7 and 9.

All original lesson cells remain, except the explicitly documented presentation/syntax/result corrections and stale chapter references in `authoring/priority_development/source_corrections.json`. Original assignment notebooks and exercise IDs remain untouched. Full standalone code is retained beside the new smaller teaching cores; newly added code verification is recorded separately from historical checks.


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

- [`demos/06_exceptions_testing/exceptions_demo/`](../../demos/06_exceptions_testing/exceptions_demo/README.md): Caught exception demonstration.
- [`demos/06_exceptions_testing/math_lab/math_app/`](../../demos/06_exceptions_testing/math_lab/math_app/README.md): Arithmetic console demonstration.
- [`demos/06_exceptions_testing/math_lab/math_app_test/`](../../demos/06_exceptions_testing/math_lab/math_app_test/README.md): Unit tests for the arithmetic lab.
- [`demos/06_exceptions_testing/math_tests/math_app/`](../../demos/06_exceptions_testing/math_tests/math_app/README.md): Basic arithmetic library.
- [`demos/06_exceptions_testing/math_tests/math_app_test/`](../../demos/06_exceptions_testing/math_tests/math_app_test/README.md): Unit tests for the arithmetic library.

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


## Outcome Gap Repair (2026-10-17)

Preserve the current chapter notebooks, reading order, existing explanations, exercise variants, and assessment identifiers. The additions below close the outcome audit gaps within that organization. Explanations belong in content before independent application; earlier scaffolded tasks remain available.

| Location | Development or assessment |
| --- | --- |
| `0601_error_handling.ipynb` | Rethrow Without Losing the Failure Origin |
| `0603_testing.ipynb` | Correct mixed framework, namespace, and assertion-order instructions; preserve reference bank. |
| `unit_testing_walkthrough.ipynb` | Move full historical explanation and listings before assignment; retain application and deliverables. |
| `0603_testing.ipynb` | Design Tests Independently of the Implementation |
| `homework.ipynb` | A Debugging Investigation with Regression Evidence |

Progression: read the relevant lesson and worked example, complete its guided practice, then attempt the added independent homework without copying the solution. Require contract-derived expected results, boundary evidence, and reasoning about the chosen representation or design. Assess process and explanation as well as output. Existing labs remain scaffolded applications rather than the sole evidence of independent mastery.

Lecture decks remain a separately tracked task. No additional chapter, meeting, or required optional-topic track is introduced.

### Verified Topic-to-Assessment Progression

| Topic/outcome | Explanation and worked example | Guided preparation | Independent evidence |
| --- | --- | --- | --- |
| Test-project architecture and framework | 0603_testing: complete historical two-project MSTest workflow, corrected expected/actual order | Existing worked four-test failure/repair and new test-design table | Testing Walkthrough applies the content; independent permit homework requires a new suite and failure/pass transcripts. |
| Rethrow and debugging evidence | 0601_error_handling: propagation syntax/table/demo; 0602_debugging_workflow existing diagnostic process | Trace caller catch; inspect stack; derive threshold cases | Independent permit investigation requires hypothesis, breakpoint/watch evidence, invalid-input exception, and unchanged regression checks. |

Keep the original five-question coding tracks and smaller historical variations. Added transfer tasks complement them. Grade implementation, independently derived expected results, and the requested reasoning separately; correct output from a supplied class does not establish algorithm construction.


## Subsection Integration (2026-10-17)

This is the current internal teaching order for the repaired pages. Earlier outlines remain historical where they differ. Chapter/section notebook order is unchanged. All original explanations, examples, exercises, code outputs, assessment identifiers, and link destinations are retained.

### `0602_debugging_workflow.ipynb`

- Turn a Symptom into a Reproducible Question
- The Workflow
  - Step 1: Reproduce Reliably
  - Step 2: Minimize the Failing Case
  - Step 3: Breakpoints and Stepping in VS Code
  - Step 4: Watch and Call Stack
    - Test a Hypothesis Against Execution
  - Step 5: Typical Bug Patterns
  - Step 6: Validate the Fix
    - Keep Evidence After the Repair
- Debug One Familiar Loop from Symptom to Evidence
  - Use a Different Symptom to Challenge the Hypothesis
- Practice

### `0603_testing.ipynb`

- Introduction
- Simple Testing
- The Unit Testing Process
- Design Tests Independently of the Implementation
- Framework Setup and Test Attributes
  - Prepare the Solution
  - Prepare Application Code
  - Prepare Tests
  - Run, Read, and Repair
  - Run in VS Code
- AI Review: Challenge Suggested Tests

Treat syntax, examples, and meaningful variations as children of their conceptual topic. Place prerequisite explanations before application, and distinguish a local checkpoint from later synthesis. Preserve distinct older/newer treatments by grouping them rather than deleting them. Keep the final Footnotes group after instructional content.

## Caption-Only Section Development (2026-10-18)

Pass 3 of the content-development audit. In 6.1 the four construct sections (try/catch/finally, TryParse, file I/O, throwing) gained general-syntax patterns, explanations of control flow and catch ordering, output interpretation, and named mistakes. Three code cells were made browser-safe so their catch branches actually run: the parse example falls back to the sample `12x` when there is no keyboard, the TryParse example to `41`, and the intentional `Divide(10, 0)` throw is caught by the caller. Validation vs. Exceptions gained a comparison table and Common Mistakes gained a sentence of reasoning per item plus an anti-pattern. The three modified cells compile and run with the outputs the prose states (.NET 10).

## Guided Practice Pass (2026-10-18)

Pass 4 of the content-development audit (`authoring/content_development_audit/`): added mid-page reflection questions to 6.5 (apply the ethical questions to a small defect), the first practice prompt on that page. Every new starter and solution compiles and runs standalone (.NET 10); starters that are meant to fail say so in their task text. No existing cell, heading, or exercise ID was removed.
