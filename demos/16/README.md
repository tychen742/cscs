# Stack and queue verification

`ServiceDeskStructures.cs` contains the complete generic array stack, bounded ring queue, and linked queue used in Chapter 16, plus a standalone verification program.

Create a temporary console project with the installed .NET SDK, copy this file to its `Program.cs`, and run `dotnet run`. Expected output:

```text
All stack and queue checks passed.
```

The checks compare 600 seeded mixed operations against `Stack<int>` and `Queue<int>`, then test empty access, default values, duplicates, singleton reuse, capacity-one wraparound, full rejection without mutation, and invalid capacities. The array stack grows by doubling; the ring queue is deliberately bounded. This is correctness verification, not a benchmark.
