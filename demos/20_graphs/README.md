# Chapter 20: Graph representations

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

`graph_traversal/` contains the core plain-class implementation and its checks:

```sh
dotnet run --project demos/20_graphs/graph_traversal/GraphChecks.csproj
```

The former callback/record implementation is retained as optional material in `demos/_extras/advanced_graph_walk/`. `RouteGraph.cs` remains the representation-check program.

## Automated Verification

From the repository root, run `python3 scripts/verify_demos.py`. The verifier copies this source unchanged into a temporary .NET 10 project and checks its output. The manual commands above remain available for exploration.
