# Chapter 22: Search and sort checks

`SearchSortChecks.cs` contains first-match linear search, any-match iterative binary search, lower/upper bounds, and generic selection/insertion/optimized bubble sorts. Searches count probes; sorts count comparer calls, swaps, and insertion shifts. Sorts mutate their input arrays.

```sh
dotnet new console -n SearchSortCheck
cp SearchSortChecks.cs SearchSortCheck/Program.cs
dotnet run --project SearchSortCheck
```

Expected output:

```text
1800 elementary sorts, 3000 search targets, and stable/count boundaries passed.
```

Checks compare sorted permutations and bounds against independent references, verify exact selection counts and inversion-based moves, and verify stable insertion/bubble order on labeled records. Explicit cases include empty/singleton, sorted adaptive behavior, extreme integers, and string equality policies. Binary search and bounds require an array sorted under the same consistent comparer; they do not scan to validate this precondition.
