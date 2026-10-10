# Instructor Walkthrough: 09/help_responses

**Role:** Supplementary integrated example.

**Supports:** [0903-dictionary](../../../chapters/09-collections/0903-dictionary.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../../materials/09/help_responses/README.md); [project file](../../../materials/09/help_responses/help_responses.csproj).

## Run Before Class

From the repository root:

```bash
dotnet run --project materials/09/help_responses/help_responses.csproj
```

Verification input, one response per line:

```text
crash
bye
```

See [verified output](09_help_responses_output.txt) for the complete captured run. Random values can change between runs.

## Explain the Code

FileUtil loads paragraphs and key/value responses. Response tokenizes input, uses dictionary matches, and otherwise selects a random fallback. bye ends the loop.

## Teaching Sequence

Use crash to trigger a known response, then bye to stop; trace how a token becomes a dictionary lookup.

## Common Mistakes and Boundaries

Unknown input has random output. This combines Chapter 9 collections with Chapter 10 files; it is not a current lab answer. Data is loaded relative to the executable.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
