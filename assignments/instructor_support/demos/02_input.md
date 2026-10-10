# Instructor Walkthrough: 02/input

**Role:** Concept companion.

**Supports:** [0206-input_output](../../../chapters/02-var_data/0206-input_output.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../../materials/02/input/README.md); [project file](../../../materials/02/input/input.csproj).

## Run Before Class

From the repository root:

```bash
dotnet run --project materials/02/input/input.csproj
```

Verification input, one response per line:

```text
20
Alex
Alex
101
90
-11
5
```

Verified output:

```text
"To be, or not to be" is a speech given by Prince Hamlet.
Enter your age:
System.String
20
System.Int32
20
34.5
Enter your name:
Hello, Alex
Enter you first name: Hiya, Alex!
Hiya, Alex!
My first name is Alex and my last name is Chen.
Enter a score (0 through 100): 101 is out of range!
Enter a score (0 through 100): Your score is 90.
Try another test.
Enter a number (-10 through 10): -11 is out of range!
Enter a number (-10 through 10): Your number is 5.
```

## Explain the Code

ReadLine returns text; parsing produces numbers. InputRange delegates prompting and retries values outside its limits.

## Teaching Sequence

Trace the difference between ageInput and age using their printed types; then trace one rejected score followed by an accepted score.

## Common Mistakes and Boundaries

Parsing malformed numeric text throws; range checking is not the same as format checking. This demo uses helper methods/loops from later chapters.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
