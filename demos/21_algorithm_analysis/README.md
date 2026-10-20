# Chapter 21: Analysis checks

`AnalysisChecks.cs` checks loop counts, maximum and first-match contracts, halving call counts, and balanced recurrence work/depth against independent formulas or library references.

```sh
dotnet new console -n AnalysisCheck
cp AnalysisChecks.cs AnalysisCheck/Program.cs
dotnet run --project AnalysisCheck
```

Expected output:

```text
600 count/contract cases and 128 recurrence cases plus boundaries passed.
```

The program calculates modeled work; it does not perform that many combine operations. It counts active frames including the base call. Its small inputs keep recursive checks practical.

## Automated Verification

From the repository root, run `python3 scripts/verify_demos.py`. The verifier copies this source unchanged into a temporary .NET 10 project and checks its output. The manual commands above remain available for exploration.
