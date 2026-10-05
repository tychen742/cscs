# Chapter 25: Advanced algorithm checks

`AdvancedChecks.cs` contains owned graph traversal with guarded BFS paths, frame-based DFS, symmetry-checked components, ordinal overlapping direct/KMP matchers with comparison counts, and exact/greedy team coverage.

```sh
dotnet new console -n AdvancedCheck
cp AdvancedChecks.cs AdvancedCheck/Program.cs
dotnet run --project AdvancedCheck
```

Expected output:

```text
500 directed traversals, 500 component graphs, 2000 ordinal matches, 500 cover optima, and boundaries passed.
```

Directed traversal checks compare BFS distances with an all-pairs relaxation reference, validate paths and discovery counts, and compare DFS frame entry/exit with a recursive reference. Component checks compare membership with independently merged labels. Matching checks use ordinal library occurrences and brute-force border lengths, including empty patterns, overlap, embedded nulls, and surrogate code units; they verify linear comparison bounds and owned prefix snapshots. Coverage checks compare exact enumeration with independent coverage-state DP, verify witnesses, and establish the greedy three-versus-two counterexample.

Graphs declare all endpoints, preserve neighbor order, normalize duplicates, and accept loops/cycles. Components require symmetric adjacency. Matching offsets are UTF-16 code units, with no case folding, culture rules, or normalization. Empty patterns match every boundary. Team masks allow up to 20 requirements and exact enumeration up to 20 teams; exceeding a teaching limit does not establish infeasibility.
