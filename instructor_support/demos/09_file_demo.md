# Instructor Walkthrough: 09_files_text/file_demo

**Role:** Concept companion.

**Supports:** [0901_stream_file](../../chapters/09_files_text/0901_stream_file.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../demos/09_files_text/file_demo/README.md); [project file](../../demos/09_files_text/file_demo/file_demo.csproj).

## Run Before Class

From the repository root:

```bash
dotnet run --project demos/09_files_text/file_demo/file_demo.csproj
```

Verified output:

```text
1
2
3

5
```

## Explain the Code

A using declaration closes the StreamReader. Main reads the bundled integers file line by line, including its blank line.

## Teaching Sequence

Run from the repository root to show why executable-relative paths differ from the shell working directory.

## Common Mistakes and Boundaries

The default run prints file contents; it does not invoke the separate CalcSum method. Do not claim it prints a sum.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
