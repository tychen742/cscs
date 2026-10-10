# Instructor Walkthrough: _extras/one_hour_of_code

**Role:** Optional multi-chapter overview.

**Supports:** [0100-getting-started](../../../chapters/01-context/0100-getting-started.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../../materials/_extras/one_hour_of_code/README.md); [project file](../../../materials/_extras/one_hour_of_code/one_hour_of_code.csproj).

## Run Before Class

From the repository root:

```bash
dotnet run --project materials/_extras/one_hour_of_code/one_hour_of_code.csproj
```

Verification input, one response per line:

```text
Alex Chen
7
2
60
```

See [verified output](_extras_one_hour_of_code_output.txt) for the complete captured run. Random values can change between runs.

## Explain the Code

The walkthrough combines expressions, strings, input, order totals, selection, loops, arrays, and lists.

## Teaching Sequence

Use selected segments after their concepts are introduced; a beginner should not be expected to absorb the whole file in one first lesson.

## Common Mistakes and Boundaries

It is not the first-program lesson or an assignment answer. Do not present all constructs as Chapter 1 prerequisites.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
