# Instructor Walkthrough: 06/math_tests/math_app

**Role:** Testing demonstration library.

**Supports:** [0603-testing](../../../chapters/06-exceptions-testing/0603-testing.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../../materials/06/math_tests/math_app/README.md); [project file](../../../materials/06/math_tests/math_app/math_app.csproj).

## Run Before Class

From the repository root:

```bash
dotnet build materials/06/math_tests/math_app/math_app.csproj
```

This resource is a library. It is verified by the build/test commands in the materials README, rather than a console-output transcript.

## Explain the Code

BasicMath exposes addition, subtraction, division, and multiplication; the sibling MSTest project exercises those operations.

## Teaching Sequence

Run the sibling tests, deliberately substitute addition for multiplication, observe the failure, then restore the correct operator.

## Common Mistakes and Boundaries

A class library has no application entry point. Use dotnet test on math_app_test, not dotnet run on this library.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
