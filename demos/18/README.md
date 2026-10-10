# Chapter 18: Hashing and Heaps

`HeapHashStructures.cs` contains a complete generic binary min-heap, an integer-key chained ticket-owner map, and a verification program. The heap has enqueue, peek, dequeue, safe dequeue, and invariant checking. The map has replacement, lookup, removal, and bucket rehashing under geometric growth.

```sh
dotnet new console -n HeapHashCheck
cp HeapHashStructures.cs HeapHashCheck/Program.cs
dotnet run --project HeapHashCheck
```

Expected output:

```text
600 heap operations and 600 map operations plus boundary checks passed.
```

Heap checks compare the full multiset, minimum, Count, and parent-child invariant against a list model. Map checks compare results, Count, and known-key values against Dictionary<int, string>. Explicit cases cover empty/singleton reuse, duplicates, negative and extreme integers, custom ordering, stable tuple priorities, collision removal, replacement without growth, rehashing, and draining. These are teaching representations; the map is not the internal implementation of .NET Dictionary.
