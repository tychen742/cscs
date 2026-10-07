# Chapter 19: Graph representations

`RouteGraph.cs` contains the complete weighted undirected graph and reference-model checks. Vertices are explicit, labels are case-sensitive, zero weights are valid, and loops and negative weights are rejected. Neighbor and vertex snapshots protect internal state.

```sh
dotnet new console -n GraphCheck
cp RouteGraph.cs GraphCheck/Program.cs
dotnet run --project GraphCheck
```

Expected output:

```text
600 graph updates and explicit boundary/snapshot checks passed.
```

## Traversal Foundations

`GraphWalk.cs` is a standalone BFS demonstration with the complete traversal implementation moved from Chapter 25. Copy it to `Program.cs` in a .NET console project and run `dotnet run`. It includes DFS and undirected-component operations used in Chapter 19. `RouteGraph.cs` remains a separate standalone program.
