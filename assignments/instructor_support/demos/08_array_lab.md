# Instructor Walkthrough: 08/array_lab

**Role:** Completed legacy exercise; not a current lab solution.

**Supports:** [0801-onedim](../../../chapters/08-arrays/0801-onedim.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../../materials/08/array_lab/README.md); [project file](../../../materials/08/array_lab/array_lab.csproj).

## Run Before Class

From the repository root:

```bash
dotnet run --project materials/08/array_lab/array_lab.csproj
```

Verified output:

```text
Values: -4 7 6 12 9
Minimum: -4
Even count: 3
Pairwise sums: 9 3 14
Ascending: True
5 8 8 11
2 5 8
3 9 9
8
```

## Explain the Code

The completed helpers count even values, add pairs, recognize ascending sequences, and print runs. These illustrate traversal and comparisons.

## Teaching Sequence

Use the examples for extra practice; use the separate current sales-lab walkthrough when teaching the assigned lab.

## Common Mistakes and Boundaries

CountEven is not CountAtLeast. Minimum returns a value; the current lab LowestDay returns an index. Do not treat this project as the current assignment answer.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
