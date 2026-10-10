# Instructor Walkthrough: _extras/console_input_intro_cscs

**Role:** Reusable helper library.

**Supports:** [0604_nullable](../../chapters/06_exceptions_testing/0604_nullable.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../demos/_extras/console_input_intro_cscs/README.md); [project file](../../demos/_extras/console_input_intro_cscs/console_input_intro_cscs.csproj).

## Run Before Class

From the repository root:

```bash
dotnet build demos/_extras/console_input_intro_cscs/console_input_intro_cscs.csproj
```

This resource is a library. It is verified by the build/test commands in the materials README, rather than a console-output transcript.

## Explain the Code

The IntroCSCS namespace variant supplies the same family of prompting helpers to calling programs.

## Teaching Sequence

Compare the namespace-qualified type with the IntroCS version and show why namespace names matter.

## Common Mistakes and Boundaries

This library has no Main. EOF is a distinct condition from malformed input; repeatedly retrying EOF would not obtain another answer.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
