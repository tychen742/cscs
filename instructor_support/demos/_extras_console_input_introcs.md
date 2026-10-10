# Instructor Walkthrough: _extras/console_input_introcs

**Role:** Reusable helper library.

**Supports:** [0604_nullable](../../chapters/06_exceptions_testing/0604_nullable.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../demos/_extras/console_input_introcs/README.md); [project file](../../demos/_extras/console_input_introcs/console_input_introcs.csproj).

## Run Before Class

From the repository root:

```bash
dotnet build demos/_extras/console_input_introcs/console_input_introcs.csproj
```

This resource is a library. It is verified by the build/test commands in the materials README, rather than a console-output transcript.

## Explain the Code

PromptLine throws on EOF; numeric helpers retry malformed or out-of-range values instead of dereferencing null.

## Teaching Sequence

Use with a calling program to demonstrate malformed input, successful retry, and end of redirected input.

## Common Mistakes and Boundaries

This library has no Main. It is supporting code, not a lesson or lab solution by itself.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
