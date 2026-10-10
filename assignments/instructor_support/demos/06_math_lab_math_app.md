# Instructor Walkthrough: 06/math_lab/math_app

**Role:** Supplementary console/test example; not a current lab solution.

**Supports:** [0603-testing](../../../chapters/06-exceptions-testing/0603-testing.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../../materials/06/math_lab/math_app/README.md); [project file](../../../materials/06/math_lab/math_app/math_app.csproj).

## Run Before Class

From the repository root:

```bash
dotnet run --project materials/06/math_lab/math_app/math_app.csproj
```

Verified output:

```text
10 + 10 = 20
10 - 10 = 0
10 / 5 = 2
10 * 10 = 100
```

## Explain the Code

The console calls BasicMath and displays four results. A separate sibling project tests those same methods.

## Teaching Sequence

Contrast checking printed results manually with executing assertions in dotnet test.

## Common Mistakes and Boundaries

The folder name math_lab comes from an older collection, not a verified current assignment relationship.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
