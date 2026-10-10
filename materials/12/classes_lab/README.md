# Animal/employee objects and instance versus static guessing games

Requires the .NET 10 SDK. Open this folder in VS Code.

Run the console application:

```bash
dotnet run --project classes_lab.csproj
```

The verification run checks for these results:

- `Employee: John 100000`.

The default run demonstrates the animal/employee classes. Other modes:

```bash
dotnet run -- guess
dotnet run -- static-guess
```

Both games ask for a positive upper bound and guess values in `[0, bound)`.
For a deterministic quick check, enter a bound of `1` and a guess of `0`.
