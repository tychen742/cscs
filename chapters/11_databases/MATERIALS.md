---
orphan: true
---

# Chapter Materials — Databases and SQL

## Purpose

Chapter 11 completes Part II by
connecting C# values and collections to persistent relational data.

## Planned Examples

- A small business dataset such as customers, products, or orders
- Relational tables, keys, and relationships
- SQL queries for filtering, sorting, grouping, and joining
- Parameterized commands from a C# application
- A small procedural program that reads and writes database rows

## Technical Direction

Use a lightweight relational database for student practice where possible. The
book should explain that the concepts transfer to PostgreSQL, SQL Server, and
other relational systems. Avoid making the student-facing chapter depend on
the book's production PostgreSQL service or its authentication database.

## Source Material

The repository's `execution/` project uses PostgreSQL and Entity Framework
Core. It may provide instructor-facing reference material, but examples for
students should remain smaller and explicit enough to show the SQL and data
model directly.

## Current Active Notebooks

- `1100_databases.ipynb` — Chapter landing page
- `1106_relational_model.ipynb` — relational model, tables, keys, and relationships
- `1107_sql_queries.ipynb` — `SELECT`, filtering, sorting, aggregation, and joins
- `1108_sql_changes.ipynb` — `INSERT`, `UPDATE`, `DELETE`, and parameterized commands
- `1109_csharp_database_workflow.ipynb` — a small C# database workflow

## Non-TOC Source Material

- `1101_lambdas.ipynb` — Lambda expressions
- `1102_linq.ipynb` — LINQ
- `1103_pattern_matching.ipynb` — Pattern matching
- `1104_records.ipynb` — Record types
- `1105_async.ipynb` — Async and await

## Coverage Gaps

The current active notebooks now establish first-pass database coverage. Later
passes should deepen the worked examples and add assignments for:

- a full setup-and-run SQLite project
- a semester-project persistence milestone
- more join and aggregation practice
- testable database methods, with repository-style design revisited after classes

## Planned Assignments

- Preview: relational terms and SQL reading
- Lab: design and query a small business database
- Homework: write and explain SQL queries and data-model decisions
- Project milestone: persist one feature from the semester application

## Verification (2026-10-07)

The C# workflow now uses ordinary variables before Chapter 12 classes. Provider examples still require compile/run verification with Microsoft.Data.Sqlite; the package is unavailable locally, so the edited examples are marked UNVERIFIED.
