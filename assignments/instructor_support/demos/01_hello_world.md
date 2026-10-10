# Instructor Walkthrough: 01/hello_world

**Role:** Exact first-program example.

**Supports:** [0103-program_structure](../../../chapters/01-context/0103-program_structure.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../../materials/01/hello_world/README.md); [project file](../../../materials/01/hello_world/HelloWorld.csproj).

## Run Before Class

From the repository root:

```bash
dotnet run --project materials/01/hello_world/HelloWorld.csproj
```

Verified output:

```text
Hello, World!
```

## Explain the Code

Trace namespace, Program, Main, then WriteLine; .NET calls Main when the application starts.

## Teaching Sequence

Ask learners to predict the output before running, then change just the greeting and save.

## Common Mistakes and Boundaries

An unsaved edit or running from the wrong folder can make students think their code was ignored.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
