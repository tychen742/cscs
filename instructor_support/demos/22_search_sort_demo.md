# Instructor Walkthrough: 22/search_sort_demo

**Role:** Concept companion with timing extensions.

**Supports:** [2203_comparison_lab](../../chapters/22_searching_sorting/2203_comparison_lab.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../demos/22/search_sort_demo/README.md); [project file](../../demos/22/search_sort_demo/search_sort_demo.csproj).

## Run Before Class

From the repository root:

```bash
dotnet run --project demos/22/search_sort_demo/search_sort_demo.csproj
```

Verification input, one response per line:

```text
1, 2, 3
2
0

```

Verified output:

```text
Your int array: 1 2 3 4 5 6 7 8 5
5
Please enter integers, separated by spaces and/or comma: data[0]=1
data[1]=2
data[2]=3
Please enter a number to find (blank line to end): At what position should the search start?  (0 through 3) Item 2 found at position 1
Please enter a number to find (blank line to end):
```

## Explain the Code

The default run demonstrates linear/binary search and prompts for a start index. sort runs six algorithms on generated data with a shared seed.

## Teaching Sequence

Trace found and missing searches; distinguish finding any duplicate from finding the first. Use size 20 and seed 42 for a short timing demonstration.

## Common Mistakes and Boundaries

Timing is not correctness evidence; small runs can report zero seconds. Basic search foundations are taught in Chapter 15; Shell/quick sort are extensions.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
