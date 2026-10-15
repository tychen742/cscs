# Bookstore inventory reference

Optional database appendix project. Requires the .NET 10 SDK; the first restore needs NuGet access. No database server is needed.

```sh
cd demos/_extras/bookstore_inventory
dotnet restore
dotnet run
dotnet run -- --check-core
dotnet run -- --check
```

The starter compiles but intentionally throws `NotImplementedException` until you complete the lab methods. The reference implements all tasks. Normal runs create `bookstore.db` in the current directory. Remove that local file to reset practice data. Checks use an isolated in-memory database. Core mode checks list/find/add/update; full mode also checks sales, rejected inputs, and row counts. Seed records use fixed IDs and are not duplicated on later runs.

Submit `Program.cs`, `BookstoreInventory.csproj`, and your own README with explanations and check output. Exclude generated databases and build folders. Assignment: `cscs-appendix-bookstore-inventory-lab`.
