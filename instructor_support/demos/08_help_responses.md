# Instructor Walkthrough: 08_collections/help_responses

**Role:** Supplementary integrated example.

**Supports:** [0803_dictionary](../../chapters/08_collections/0803_dictionary.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../demos/08_collections/help_responses/README.md); [project file](../../demos/08_collections/help_responses/help_responses.csproj).

## Run Before Class

From the repository root:

```bash
dotnet run --project demos/08_collections/help_responses/help_responses.csproj
```

Verification input, one response per line:

```text
crash
bye
```

See [verified output](08_help_responses_output.txt) for the complete captured run. Random values can change between runs.

## Explain the Code

FileUtil loads paragraphs and key/value responses. Response tokenizes input, uses dictionary matches, and otherwise selects a random fallback. bye ends the loop.

## Teaching Sequence

Use crash to trigger a known response, then bye to stop; trace how a token becomes a dictionary lookup.

## Common Mistakes and Boundaries

Unknown input has random output. This combines Chapter 8 collections with Chapter 9 files; it is not a current lab answer. Data is loaded relative to the executable.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
