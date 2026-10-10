# Linear/binary search and sort timing extensions

**Teaching role:** Concept companion with timing extensions. See the [instructor walkthrough](../../../assignments/instructor_support/demos/22_search_sort_demo.md).

Requires the .NET 10 SDK. Open this folder in VS Code.

Run the console application:

```bash
dotnet run --project search_sort_demo.csproj
```

Example console input, one response per line:

```text
1, 2, 3
2
0

```

The verification run checks for these results:

- `Item 2 found at position 1`.

The default run searches the integers you enter; a blank search ends the run.
Run the sorting timing extension with a size and random seed:

```bash
dotnet run -- sort 20 42
```

The timing values vary by machine. The behavior-check project verifies all six
sorting implementations against `Array.Sort`; timing alone is not correctness evidence.
