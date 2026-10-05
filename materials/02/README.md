# Chapter 2 standalone examples

Run each file independently with the .NET 10 SDK:

```console
dotnet run Invoice.cs
dotnet run ReadInvoice.cs
```

Invoice prints the discounted 12-case invoice. ReadInvoice reads one whole-number quantity from zero to 100, assuming valid input, and prints an undiscounted total. Sample input 20 gives 823.90 USD. Invalid input recovery is deliberately deferred to Chapters 4 and 6. Rates and rounding are classroom assumptions.
