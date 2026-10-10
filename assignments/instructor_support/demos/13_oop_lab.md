# Instructor Walkthrough: 13/oop_lab

**Role:** Supplementary example; not a current lab solution.

**Supports:** [1302_encapsulation](../../../chapters/13_oop/1302_encapsulation.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../../materials/13/oop_lab/README.md); [project file](../../../materials/13/oop_lab/oop_lab.csproj).

## Run Before Class

From the repository root:

```bash
dotnet run --project materials/13/oop_lab/oop_lab.csproj
```

Verified output:

```text
Final balance: 125
```

## Explain the Code

A BankAccount stores its balance privately. Starting at 100, depositing 50, and withdrawing 25 yields 125.

## Teaching Sequence

Trace the balance changes and identify which operations are available to the caller.

## Common Mistakes and Boundaries

The project links bank_account.cs from oop_demo; both folders must remain together. The folder name lab does not establish a match to a current assignment.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
