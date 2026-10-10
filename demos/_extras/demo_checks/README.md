# Demo Behavior Checks

Requires the .NET 10 SDK. From this folder:

```bash
dotnet run
```

The project compiles selected demo sources with an explicit test entry point.
It compares six sorts with `Array.Sort`, linear search with `Array.IndexOf`,
and binary search with membership results over empty, short, and duplicate-rich
arrays. It also checks array operations, factorials, letter filtering,
EOF-safe file parsing, console-input retries, and shape areas. A failed check
throws an exception and returns a nonzero exit code.

Run `python3 scripts/verify_demos.py` from the repository root to check
all migrated projects, console interactions, and MSTest suites together.
