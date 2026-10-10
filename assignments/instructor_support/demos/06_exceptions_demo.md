# Instructor Walkthrough: 06/exceptions_demo

**Role:** Concept companion.

**Supports:** [0601-error-handling](../../../chapters/06-exceptions-testing/0601-error-handling.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../../materials/06/exceptions_demo/README.md); [project file](../../../materials/06/exceptions_demo/exceptions_demo.csproj).

## Run Before Class

From the repository root:

```bash
dotnet run --project materials/06/exceptions_demo/exceptions_demo.csproj
```

Verified output:

```text
System.ArithmeticException: Access denied: you must be at least 18 years old to play this game.
   at Excepts.Except1.checkAge(Int32 age) in /Users/tychen/workspace/cscs/materials/06/exceptions_demo/exceptions.cs:line 11
```

## Explain the Code

The age check throws inside try and catch handles the exception by printing it. The process can exit successfully after handling an exception.

## Teaching Sequence

Predict whether the code after the throw in the try block executes, then distinguish the printed exception from an unhandled crash.

## Common Mistakes and Boundaries

ArithmeticException is the existing illustrative choice, not a recommendation for production age-validation errors. Stack paths and line numbers vary.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
