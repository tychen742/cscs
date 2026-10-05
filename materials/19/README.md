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
