# Instructor Walkthrough: 03/methods_demo

**Role:** Concept companion.

**Supports:** [0303-parameter](../../../chapters/03-methods/0303-parameter.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../../materials/03/methods_demo/README.md); [project file](../../../materials/03/methods_demo/methods_demo.csproj).

## Run Before Class

From the repository root:

```bash
dotnet run --project materials/03/methods_demo/methods_demo.csproj
```

Verification input, one response per line:

```text
2
3
```

Verified output:

```text
Hi, Benjamin Franklin!
Hi, Andrew Harrington!
2 + 3 = 5
12345 + 53579 = 65924
Enter an integer: Enter another integer: 2 + 3 = 5
aaaaa
bbbbb
ccccc
ddddd
16
32
25
Old MacDonald had a farm
E-I-E-I-O
And on that farm he had a chicken
E-I-E-I-O
With a buk-buk here
And a buk-buk there
Here a buk, there a buk
Everywhere a buk-buk
Old MacDonald had a farm
E-I-E-I-O
```

## Explain the Code

Each call supplies arguments; returning a string differs from printing it. Verse composes a longer output from two parameters.

## Teaching Sequence

Trace one SumProblemString call, then SquareTheNumber(4), before showing the longer Verse method.

## Common Mistakes and Boundaries

A method declaration does not execute its body. void methods cannot be used as returned values.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
