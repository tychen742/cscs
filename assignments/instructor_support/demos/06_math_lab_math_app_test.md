# Instructor Walkthrough: 06/math_lab/math_app_test

**Role:** Supplementary test suite; not a current lab solution.

**Supports:** [0603-testing](../../../chapters/06-exceptions-testing/0603-testing.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../../materials/06/math_lab/math_app_test/README.md); [project file](../../../materials/06/math_lab/math_app_test/math_app_test.csproj).

## Run Before Class

From the repository root:

```bash
dotnet test materials/06/math_lab/math_app_test/math_app_test.csproj
```

This resource is a test. It is verified by the build/test commands in the materials README, rather than a console-output transcript.

## Explain the Code

The four assertions test the sibling console project arithmetic type independently of its displayed output.

## Teaching Sequence

Make one small defect, rerun tests, and restore the source before presenting the reference version.

## Common Mistakes and Boundaries

Tests should pass in the supplied reference version. Do not distribute the deliberately broken variant without labeling it.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
