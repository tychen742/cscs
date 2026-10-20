# Object design

**Inventory role:** Demo. Order collaboration model with 21 object-design checks.

Reference project for Part III. Requires .NET 10; no package dependency or database.

```sh
dotnet run --project demos/11_object_design/object_design
dotnet run --project demos/11_object_design/object_design -- --check
```

The normal run prints a business example. Check mode verifies valid and invalid boundaries and throws on failure. Model classes are separated from console output; each notebook cell includes its own complete setup. The reference supports the lesson and is not a substitute for completing the student lab.
