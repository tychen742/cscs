# Instructor Walkthrough: 12/classes_demo

**Role:** Concept companion.

**Supports:** [1203_class_instance](../../chapters/12_classes/1203_class_instance.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../demos/12/classes_demo/README.md); [project file](../../demos/12/classes_demo/classes_demo.csproj).

## Run Before Class

From the repository root:

```bash
dotnet run --project demos/12/classes_demo/classes_demo.csproj
```

Verified output:

```text
taylor swift has an existing ID!
```

## Explain the Code

new CheckID creates an object whose name field is initialized by the constructor; PrintResult uses that instance data.

## Teaching Sequence

Change the constructor argument and trace which object stores the name. Compare the supplied static and instance arithmetic helpers separately.

## Common Mistakes and Boundaries

The ID message is illustrative; this program does not query a database or verify a real ID.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
