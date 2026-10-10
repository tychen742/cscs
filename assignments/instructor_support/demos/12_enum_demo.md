# Instructor Walkthrough: 12/enum_demo

**Role:** Supplementary type example.

**Supports:** [1201_class_syntax](../../../chapters/12_classes/1201_class_syntax.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../../materials/12/enum_demo/README.md); [project file](../../../materials/12/enum_demo/enum_demo.csproj).

## Run Before Class

From the repository root:

```bash
dotnet run --project materials/12/enum_demo/enum_demo.csproj
```

Verified output:

```text
Medium
3
```

## Explain the Code

An enum assigns names to integral values. Level.Medium prints its name; casting Months.April prints 3 because the declaration starts at zero.

## Teaching Sequence

Ask whether the displayed 3 is a human calendar month number or an enum value.

## Common Mistakes and Boundaries

This is supplemental: no matching enum assignment is established. Implicit enum numbering begins at zero unless explicitly assigned.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
