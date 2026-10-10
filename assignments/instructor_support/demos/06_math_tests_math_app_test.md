# Instructor Walkthrough: 06/math_tests/math_app_test

**Role:** Concept companion test suite.

**Supports:** [0603-testing](../../../chapters/06-exceptions-testing/0603-testing.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../../materials/06/math_tests/math_app_test/README.md); [project file](../../../materials/06/math_tests/math_app_test/math_app_test.csproj).

## Run Before Class

From the repository root:

```bash
dotnet test materials/06/math_tests/math_app_test/math_app_test.csproj
```

This resource is a test. It is verified by the build/test commands in the materials README, rather than a console-output transcript.

## Explain the Code

Four tests construct BasicMath and compare expected results with actual results.

## Teaching Sequence

Explain arrangement, method invocation, and assertion for one test; use a deliberate multiplication defect to show test failure.

## Common Mistakes and Boundaries

Passing four tests covers four cases; it does not establish complete arithmetic behavior or application correctness.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
