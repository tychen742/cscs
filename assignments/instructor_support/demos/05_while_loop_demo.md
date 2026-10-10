# Instructor Walkthrough: 05/while_loop_demo

**Role:** Concept companion.

**Supports:** [0503-while-statement](../../../chapters/05-iteration/0503-while-statement.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../../materials/05/while_loop_demo/README.md); [project file](../../../materials/05/while_loop_demo/while_loop_demo.csproj).

## Run Before Class

From the repository root:

```bash
dotnet run --project materials/05/while_loop_demo/while_loop_demo.csproj
```

Enter guesses from one through 100 until the winning message appears. The captured verification run tried them in order.

Verified output:

```text
Please choose 1 to 100
Higher
Please choose 1 to 100
Higher
Please choose 1 to 100
Higher
Please choose 1 to 100
Higher
Please choose 1 to 100
Higher
Please choose 1 to 100
Higher
Please choose 1 to 100
Higher
Please choose 1 to 100
Higher
Please choose 1 to 100
Higher
Please choose 1 to 100
Correct!
```

## Explain the Code

The do/while body runs at least once. A random secret in 1 through 100 controls termination; the winning guess prints Correct!.

## Teaching Sequence

Trace too-low, too-high, and equal guesses. Emphasize the update of guess on every iteration.

## Common Mistakes and Boundaries

Random secrets vary; validate the range and termination logic rather than expecting a fixed number of guesses. Malformed input is not handled by the default int.Parse call.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
