# Organization: Databases and Bookstore Inventory

## B-A Development Follow-up (2026-10-18)

| Reading | Audit findings | Developed coverage |
| --- | --- | --- |
| `relational_data_sql.ipynb` | B16 | Known three-book/three-sale dataset; query syntax; actual filtering, aggregate, grouping and join results; guided threshold/query feedback and event-count versus copies distinction. Both explicit schema variants retained. |
| `csharp_sqlite.ipynb` | B17 | Project-only mapping/affected-row example and transaction state table; complete forced-failure listing with rollback; guided valid-commit, omitted-commit, missing-ID and affected-row variations. Existing reference project/checks and optional lab retained. |

Keep the current reading order and chapter boundaries. Develop explanation and relevant general syntax before the worked application; interpret output/state and a meaningful variation, then provide a local learner attempt with feedback. Existing labs and homework remain the independent transfer stage; do not move new prerequisite explanations into labs. Optional readings remain optional. The report in `authoring/ba_development_revision/` maps all 18 findings to current evidence and verification.


## Role and Prerequisites

Optional persistence track after core files/text, collections, classes, and OOP. No required weekly chapter or new semester prerequisite. Can support a project milestone.

## Sequence

1. Relational data and SQL: tables, keys, queries, safe changes, constraints, and integer-cent prices.
2. C# and SQLite: project setup, connection/command/reader lifecycle, object mapping, parameters, outcomes, and transactions.
3. Bookstore inventory lab: list, find, add, update stock, and optionally record a sale atomically.

## Assessment

One connected durable lab with core checkpoints and an optional transaction extension. Stable assignment ID: `cscs-appendix-bookstore-inventory-lab`. Submit source, project configuration, explanations, and verification output through VS Code/GitHub. The ordinary weekly Preview/Lab/Homework pattern does not apply to this optional appendix.

## Boundaries

No server administration or object-relational framework. Preserve old database URLs through redirects. Keep database state local and use fresh in-memory databases for automated checks.


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
