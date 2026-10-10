# Chapter 20: Analysis checks

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
