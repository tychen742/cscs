# Instructor Walkthrough: 05/for_loop_demo

**Role:** Concept companion.

**Supports:** [0502_for_statements](../../chapters/05_iteration/0502_for_statements.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../demos/05/for_loop_demo/README.md); [project file](../../demos/05/for_loop_demo/for_loop_demo.csproj).

## Run Before Class

From the repository root:

```bash
dotnet run --project demos/05/for_loop_demo/for_loop_demo.csproj
```

Verified output:

```text
edcba
OrderReady
5! = 120
OkOkOk
```

## Explain the Code

Repeated statements update accumulators; factorial multiplies rather than adds. OnlyLetters filters characters and ReverseString prints reversed characters.

## Teaching Sequence

Trace factorial for 0 and 5; distinguish a helper returning a string from one printing it.

## Common Mistakes and Boundaries

The factorial result is an int and checked multiplication can overflow. Random flip output varies; do not grade an exact flip sequence.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
