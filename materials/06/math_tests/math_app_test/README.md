# Unit tests for the arithmetic library

Requires the .NET 10 SDK. Open this folder in VS Code.

Run the four MSTest tests (first run restores packages from NuGet):

```bash
dotnet test math_app_test.csproj
```

The sibling `math_app` project supplies the arithmetic methods. All tests
should pass. To practice debugging, temporarily replace multiplication with
addition in `Multiply`, observe the failing test, and restore the correct code.
