# Optional bookstore inventory lab

Assignment: `cscs-appendix-bookstore-inventory-lab`. Use after classes/OOP; no required numbered week. Student instructions are in `chapters/appendices/databases/bookstore_inventory_lab.ipynb`.

The starter at `demos/_extras/bookstore_inventory_starter/` compiles but intentionally throws until methods are implemented. The matching ZIP contains source and configuration only. The reference at `demos/_extras/bookstore_inventory/` completes all tasks.

```sh
dotnet run --project demos/_extras/bookstore_inventory -- --check-core
dotnet run --project demos/_extras/bookstore_inventory -- --check
```

Core checks cover mapping, missing IDs, a quoted title, stock changes, unrelated rows, and invalid inputs. Full checks add sale success, insufficient stock, missing books, row counts, and rollback after an injected insert failure. Check mode uses an in-memory database. Normal runs persist `bookstore.db` relative to the working directory and preserve existing seed records.

Students complete list/find/add/update in one durable console project. Sales and transactions are an extension. Assess the checkpoint explanations and reproducibility as well as output. The database schema uses integer cents and constraints; every input-bearing command uses parameters. Do not treat a successful update alone as proof of atomic sale behavior.
