# Instructor Walkthrough: 02/output

**Role:** Concept companion.

**Supports:** [0206_input_output](../../chapters/02_var_data/0206_input_output.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../demos/02/output/README.md); [project file](../../demos/02/output/output.csproj).

## Run Before Class

From the repository root:

```bash
dotnet run --project demos/02/output/output.csproj
```

Verification input, one response per line:

```text
Alex
9:00
```

Verified output:

```text
35
Enter the interviewee's name: Enter the appointment time: Alex has an interview at 9:00.
```

## Explain the Code

InterviewSentence returns formatted text; Main reads values and prints that returned text.

## Teaching Sequence

Identify the two prompts and match each input to its place in the sentence.

## Common Mistakes and Boundaries

Do not confuse an object instance method with a static method. The demo uses classes and methods beyond introductory output.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
