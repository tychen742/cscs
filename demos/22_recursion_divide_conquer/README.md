# Chapter 22: Stable merge sort

`StableSort.cs` contains generic stable merge and range/buffer merge sort, operation counters, and independent reference checks. Sort returns a fresh array, preserves input order, resets counters per call, and retains arrival order for equal keys. Array copies are shallow: referenced objects are not cloned.

```sh
dotnet new console -n StableSortCheck
cp StableSort.cs StableSortCheck/Program.cs
dotnet run --project StableSortCheck
```

Expected output:

```text
600 stable sort cases, 600 merge cases, and count/copy boundaries passed.
```

Merge requires both inputs to be sorted under the same consistent comparison. Sort uses a copied result and one shared buffer, taking linear auxiliary space and logarithmic active stack depth. Counted writes exclude the initial clone and buffer allocation.

## Automated Verification

From the repository root, run `python3 scripts/verify_demos.py`. The verifier copies this source unchanged into a temporary .NET 10 project and checks its output. The manual commands above remain available for exploration.
