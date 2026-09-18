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

## Planned Assignments

- Preview: relational terms and SQL reading
- Lab: design and query a small business database
- Homework: write and explain SQL queries and data-model decisions
- Project milestone: persist one feature from the semester application
