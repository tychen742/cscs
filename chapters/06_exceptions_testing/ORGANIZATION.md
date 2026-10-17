# Chapter Organization: Testing, Debugging, and Error Handling

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
