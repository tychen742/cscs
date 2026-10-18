# Chapter Organization: Testing, Debugging, and Error Handling

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `0601_error_handling.ipynb` | Error Handling and Validation | Core content |
| `0602_debugging_workflow.ipynb` | Debugging Workflow | Core content |
| `0603_testing.ipynb` | Unit Testing | Core content |
| `0605_software_responsibility.ipynb` | Computing and Society | Supporting reading |

Keep the newly developed validation/debugger lessons and all original unit-testing material. The framework-setup/test-attribute discussion is now content before Footnotes. Historical commented reference banks remain preserved as source; they are not newly certified current setup instructions.

Teach the section conceptual framework before detailed application; place syntax prerequisites before reasoning that requires them. Keep the new worked traces and guided checkpoints, followed by existing lab/homework transfer. Reading count does not set a meeting or word quota.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Current B-A Teaching Progression (2026-10-17)

This is the current progression within the existing section order; earlier meeting outlines below are historical where they conflict. Readings are not additional required meetings.

Use the existing three meetings: validation/control flow, debugging with methods and loops, then unit testing. Arrays and CSV are explicitly retained as later applications after Chapters 7 and 9.

| Reading | Developed content-section coverage |
| --- | --- |
| `0601_error_handling.ipynb` | Trace normal and exceptional control, specific catches, finally, throw contracts and guided boundary checks. |
| `0602_debugging_workflow.ipynb` | Use a prerequisite-safe methods/loop debugger case with commands, watch observations, repair and regression evidence. |

**Conceptual framework:** motivate the result contract and connect the new operation to prior control flow, state, representation or algorithm ideas.

**Subsection development:** use the new small trace and standalone worked example before the complete retained implementation. Interpret the saved output, vary an assumption and diagnose a plausible mistake. Syntax scaffolds are patterns, not hidden executable prerequisites.

**Practice progression:** Predict normal/throw/catch/finally output; trace the credit loop in a debugger; repair one cause and retain independently expected regression cases. Apply the established testing workflow in the current lab and homework.

Keep prerequisite explanations in these content sections. Labs apply the explained ideas and may scaffold the task; homework increases transfer. No existing explanation, exercise variation, assignment identity or independent-work requirement is removed to fit a time or word quota.


## Learning Objectives

1. Design ordinary, boundary, and invalid-input tests with independently derived expected results.
2. Reproduce a failure and inspect execution using breakpoints, stepping, and watches.
3. Distinguish routine validation, exceptions, and logic defects; handle a specific recoverable failure.
4. Preserve a regression check after repairing a defect.
5. Check for missing input before using it.

## Three Class Meetings

1. Error Handling and Validation (35 minutes): expected versus actual behavior, routine validation, TryParse, basic null checks, reading exception messages, and basic try/catch/throw. Keep the existing section path and order.
2. Debugging Workflow (35 minutes): reproduce, minimize, hypothesize, inspect state, repair, and retain a regression test. Use methods, decisions, and loops already taught.
3. Unit Testing (40 minutes): independent expected results, arrange/act/assert, boundary tables, repeatable method checks, and a small C# unit-test project. Distinguish manual checks, automated tests, and debugging. Include the prepared AI-review boundary exercise within practice time.

Total: 110 minutes. Testing is introduced in Chapters 1-5; this chapter consolidates it rather than introducing verification for the first time.

## Scope and Later Reinforcement

Keep basic missing-input checks here. Deeper nullable value/reference types, compiler flow warnings, null operators, optional relationships, and constructor contracts now belong to Chapter 11's supporting reading, `1104_nullability.ipynb`. Do not require records, LINQ, or advanced property patterns in Chapter 6. Files and resource cleanup return in Chapter 9; object-state, collaboration, and failure-contract tests return in Chapters 10-12.

Optional `0605_software_responsibility.ipynb` retains software-failure cases and boundary-test demonstrations without adding a required meeting. The prepared AI-review activity needs no paid AI access.

## Alignment Work Remaining

The title, TOC, orientation, and nullable lesson location are updated. Align the existing Preview, Lab, and Homework with the reduced scope in a later assessment pass: basic null checks may remain, but deeper nullable operator/type questions should move to OOP with their identifiers preserved. Strengthen the repeatable test-project workflow and early-chapter practice before claiming the full progression is implemented. Retain the existing chapter URL, video, and assessment IDs.

## Restored CS1 Material (2026-10-17)

- `assignments/unit_testing_walkthrough.ipynb`: restored explanations and exercises; retains current lessons and assignment IDs.

## Section-Boundary Review (2026-10-17)

**Status: implemented.** The following records the reviewed recommendation and its baseline. See Implemented Reading Organization below for the final current filenames and order; earlier meeting allocations are historical where they conflict.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `0601_error_handling.ipynb`: Error Handling and Validation | Core content | 280 | 14 | 4 |
| `0602_debugging_workflow.ipynb`: Debugging Workflow | Core content | 313 | 13 | 3 |
| `0603_testing.ipynb`: Unit Testing | Core content | 2,984 | 13 | 5 |
| `0605_software_responsibility.ipynb`: Computing and Society | Supporting reading | 942 | 17 | 2 |

**Recommendation:** Retain distinct lessons; expand two thin ones.

Validation/recovery, diagnosing a defect, and testing a contract are different skills. The 280-word and 313-word pages need teaching development, not consolidation that hides missing instruction.

### Proposed Reading Sequence

1. Validation and recoverable exceptions.
2. Systematic debugging.
3. Repeatable tests and a unit-test workflow.

### Adequacy Before Reorganization

Add interpreted error examples, validation/failure-policy comparisons and an actual debugging walkthrough. The large testing page is not evidence that the other two lessons are adequate.

Retain the supporting readings identified above outside the required core. Reading sections and class meetings are different units; allocate discussion and practice after developing adequate explanations. Do not reduce distinct material to meet a section or word quota.

Preserve every existing explanation, exercise variation and assessment identity. The source-to-destination dispositions in MATERIALS.md govern any later move. Update TOC, links and redirects only in an authorized implementation pass.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `0601_error_handling.ipynb`: Error Handling and Validation.
- `0602_debugging_workflow.ipynb`: Debugging Workflow.
- `0603_testing.ipynb`: Unit Testing.
- `0605_software_responsibility.ipynb`: Computing and Society.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.
