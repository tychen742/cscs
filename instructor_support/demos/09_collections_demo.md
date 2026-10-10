# Instructor Walkthrough: 09/collections_demo

**Role:** Concept companion.

**Supports:** [0902_list](../../chapters/09_collections/0902_list.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../demos/09/collections_demo/README.md); [project file](../../demos/09/collections_demo/collections_demo.csproj).

## Run Before Class

From the repository root:

```bash
dotnet run --project demos/09/collections_demo/collections_demo.csproj
```

Verified output:

```text
System.String[]
System.Collections.Generic.List`1[System.String]
apple
banana
cherry
```

## Explain the Code

A List<string> is constructed from an array, then Sort changes the list order; the printed type names show the distinct representations.

## Teaching Sequence

Predict alphabetical order and ask whether converting the array into a list changes the original array.

## Common Mistakes and Boundaries

Creating a new list copies its elements; it does not turn the original array into a List.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
