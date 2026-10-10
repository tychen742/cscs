# Instructor Walkthrough: 08/arrays_demo

**Role:** Concept companion with jagged-array extension.

**Supports:** [0802-twodim](../../../chapters/08-arrays/0802-twodim.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../../materials/08/arrays_demo/README.md); [project file](../../../materials/08/arrays_demo/arrays_demo.csproj).

## Run Before Class

From the repository root:

```bash
dotnet run --project materials/08/arrays_demo/arrays_demo.csproj -- 1 2 3
```

Verified output:

```text
There are 3 command line parameters.
1
2
3
6

ints.Length: 12
    9    4    7    2
    4    6    6    1
    0    8    4    1
    9    4    7    2
    4    6    6    1
    0    8    4    1
55
Element [0] Array: 2 3 7 55
Element [1] Array: 3 1 8 10
Element [2] Array: 6 0
    0
    0    1
    0    2    4
    0    3    6    9
```

## Explain the Code

Main sums numeric command-line arguments, then demonstrates rectangular and jagged arrays. Each jagged row must be allocated before indexing it.

## Teaching Sequence

Show command-line arguments first, then contrast GetLength on a rectangular array with Length on each jagged row.

## Common Mistakes and Boundaries

Program arguments follow -- in dotnet run. Random rectangular values vary. Jagged arrays are extension material, not the current lab answer.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
