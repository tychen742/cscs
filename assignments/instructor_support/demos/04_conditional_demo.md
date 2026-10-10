# Instructor Walkthrough: 04/conditional_demo

**Role:** Concept companion.

**Supports:** [0402-ifstatement](../../../chapters/04-decision/0402-ifstatement.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../../materials/04/conditional_demo/README.md); [project file](../../../materials/04/conditional_demo/conditional_demo.csproj).

## Run Before Class

From the repository root:

```bash
dotnet run --project materials/04/conditional_demo/conditional_demo.csproj
```

Verification input, one response per line:

```text
75
```

Verified output:

```text
What is the temperature? Wear shorts.
Get some exercise outside.
```

## Explain the Code

The default Main calls Clothes; the comparison selects shorts above 70 and long pants otherwise. Other methods are available but are not called by default.

## Teaching Sequence

Run temperatures 75, 60, and exactly 70; ask which branch runs at the boundary.

## Common Mistakes and Boundaries

Greater-than excludes equality. The final exercise message runs after either branch.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
