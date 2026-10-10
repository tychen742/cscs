# Chapter 24: Planning checks

`PlanningChecks.cs` includes guarded Fibonacci methods, minimum reusable-coin plans with reconstruction, signed one-use subset search with safe bounds and failed-state memoization, and positional subset/permutation enumeration.

```sh
dotnet new console -n PlanningCheck
cp PlanningChecks.cs PlanningCheck/Program.cs
dotnet run --project PlanningCheck
```

Expected output:

```text
600 coin references, 600 signed subset references, 93 Fibonacci states, enumeration checks, and boundaries passed.
```

Coin checks use independent breadth-first amount exploration and validate all table entries and witnesses. Subset checks enumerate bit masks independently and compare unpruned, bound-pruned, and memoized variants, validating returned positions and long sums. Fibonacci methods are checked against arbitrary-precision reference values with exact call/cache counts. Enumeration checks validate cardinality, unique positions, independent snapshots, and empty inputs.

Fibonacci accepts 0..92 (naive capped at 25). Minimum coins requires positive denominations and targets 0..1,000,000. Subset search accepts up to 128 signed positions; its default million-call limit throws with feasibility unknown if exhausted. Materialized subsets/permutations are limited to 16/eight positions. These are explicit teaching resource policies; complexity discussions still account for state ranges, recursion, and output volume.
