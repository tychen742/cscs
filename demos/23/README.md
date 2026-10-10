# Chapter 23: Greedy optimization checks

`GreedyChecks.cs` contains interval scheduling, Kruskal minimum spanning forests with union by size and path halving, and Dijkstra shortest paths with stale-priority rejection and guarded path reconstruction.

```sh
dotnet new console -n GreedyCheck
cp GreedyChecks.cs GreedyCheck/Program.cs
dotnet run --project GreedyCheck
```

Expected output:

```text
300 exhaustive schedules, 300 exhaustive forests, 300 distance/path references, and boundaries passed.
```

Scheduling maximizes count for positive-duration half-open intervals with unique IDs. Kruskal accepts signed edge costs and reports disconnected components. Dijkstra requires nonnegative directed arcs, uses nullable checked `long` distances, and returns an empty path for unreachable vertices. Graph inputs declare every vertex, permit parallel edges, and reject loops. Distance and predecessor maps are read-only.

The checks enumerate feasible meeting subsets and acyclic forest subsets, then compare route distances with repeated edge relaxation and validate reconstructed path costs. They also cover empty inputs, isolated vertices, ties, negative cable costs, zero-cost arcs, wide distances, invalid graph inputs, and read-only results.
