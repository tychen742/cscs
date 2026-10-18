# Materials: Databases and Bookstore Inventory

## B-A Development Follow-up (2026-10-18)

| Reading | Audit findings | Developed coverage |
| --- | --- | --- |
| `relational_data_sql.ipynb` | B16 | Known three-book/three-sale dataset; query syntax; actual filtering, aggregate, grouping and join results; guided threshold/query feedback and event-count versus copies distinction. Both explicit schema variants retained. |
| `csharp_sqlite.ipynb` | B17 | Project-only mapping/affected-row example and transaction state table; complete forced-failure listing with rollback; guided valid-commit, omitted-commit, missing-ID and affected-row variations. Existing reference project/checks and optional lab retained. |

Preserve all prior explanations, examples and exercise variants. Factual corrections retain the instructional purpose and are recorded by stable cell ID in `authoring/ba_development_revision/corrections.json`. New runnable cells and project listings have independent .NET verification; SQL results are checked against a disposable SQLite fixture. Existing assessment notebooks and the TOC are unchanged.


Optional appendix after classes and OOP. Active notebooks: `index.ipynb`, `relational_data_sql.ipynb`, `csharp_sqlite.ipynb`, and `bookstore_inventory_lab.ipynb`.

Source and runnable instructor reference: `demos/_extras/bookstore_inventory/`.
Student starter: `demos/_extras/bookstore_inventory_starter/`.
The lab is a durable VS Code submission, not a browser cell activity.
Former lambda, LINQ, records, pattern, and async notebooks are retained non-TOC source material; they are not database prerequisites.

Verification: restore and run the reference's `--check` mode; compile the starter; validate the appendix SQL with a disposable SQLite database. See the project README for commands.


## Subsection Integration (2026-10-17)

This is the current internal teaching order for the repaired pages. Earlier outlines remain historical where they differ. Chapter/section notebook order is unchanged. All original explanations, examples, exercises, code outputs, assessment identifiers, and link destinations are retained.

### `csharp_sqlite.ipynb`

- Set Up and Run
- Connections, Commands, and Disposal
- Map Rows to Objects
- Injection
- Supply Parameters and Check Outcomes
- Transactions for Related Changes
- Verify Before Extending

Treat syntax, examples, and meaningful variations as children of their conceptual topic. Place prerequisite explanations before application, and distinguish a local checkpoint from later synthesis. Preserve distinct older/newer treatments by grouping them rather than deleting them. Keep the final Footnotes group after instructional content.
