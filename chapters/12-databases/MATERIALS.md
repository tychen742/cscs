---
orphan: true
---

# Chapter Materials — Databases and SQL

## Purpose

Chapter 12 completes the introductory information-systems sequence by
connecting C# objects and collections to persistent relational data.

## Planned Examples

- A small business dataset such as customers, products, or orders
- Relational tables, keys, and relationships
- SQL queries for filtering, sorting, grouping, and joining
- Parameterized commands from a C# application
- A small repository-style program that reads and writes database records

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

- `1200-databases.ipynb` — Chapter landing page
- `1206-relational-model.ipynb` — relational model, tables, keys, and relationships
- `1207-sql-queries.ipynb` — `SELECT`, filtering, sorting, aggregation, and joins
- `1208-sql-changes.ipynb` — `INSERT`, `UPDATE`, `DELETE`, and parameterized commands
- `1209-csharp-database-workflow.ipynb` — a small C# database workflow

## Non-TOC Source Material

- `1201-lambdas.ipynb` — Lambda expressions
- `1202-linq.ipynb` — LINQ
- `1203-pattern-matching.ipynb` — Pattern matching
- `1204-records.ipynb` — Record types
- `1205-async.ipynb` — Async and await

## Coverage Gaps

The current active notebooks now establish first-pass database coverage. Later
passes should deepen the worked examples and add assignments for:

- a full setup-and-run SQLite project
- a semester-project persistence milestone
- more join and aggregation practice
- testable repository-style methods

## Planned Assignments

- Preview: relational terms and SQL reading
- Lab: design and query a small business database
- Homework: write and explain SQL queries and data-model decisions
- Project milestone: persist one feature from the semester application
