# Instructor Walkthrough: _extras/contact_demo

**Role:** Supplementary instance-method example.

**Supports:** [1203_class_instance](../../chapters/12_classes/1203_class_instance.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../demos/_extras/contact_demo/README.md); [project file](../../demos/_extras/contact_demo/contact_demo.csproj).

## Run Before Class

From the repository root:

```bash
dotnet run --project demos/_extras/contact_demo/contact_demo.csproj
```

Verified output:

```text
Name is TY
Phone is 333
```

## Explain the Code

Program.Main constructs a Program object and calls its void User method, which prints a name and phone.

## Teaching Sequence

Contrast calling an instance method with trying to call it directly from a static method.

## Common Mistakes and Boundaries

A void result cannot be passed to Console.Write as a value. The supplied contact data is illustrative.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
