---
orphan: true
---

# Chapter Organization — Databases and SQL

## Learning Objectives

By the end of this chapter, students should be able to:

- explain why relational databases are useful for persistent structured data;
- identify tables, rows, columns, keys, and relationships in a data model;
- write SQL queries using filtering, sorting, grouping, and joins;
- distinguish unsafe string-built SQL from parameterized commands; and
- connect a small C# program to a database and handle query results.

## Sequence

- relational model: tables, rows, columns, primary keys, foreign keys, and relationships
- SQL queries: `SELECT`, `WHERE`, `ORDER BY`, grouping, aggregation, and joins
- SQL change commands: `INSERT`, `UPDATE`, `DELETE`, and parameters
- C# database workflow: connection, command, parameters, execution, and reading column values

## Notes

This chapter closes Part II after files and text, introducing persistent
structured data before custom classes and object-oriented design. Read query
results into ordinary variables; revisit object mapping in the later project. It should teach the concepts and a small working workflow, not attempt
to become a full database-administration course. The former lambda, LINQ,
record, pattern-matching, and async notebooks remain source material, but the
active Chapter 11 sequence now teaches databases and SQL directly.

## Coverage Gaps

This first database pass covers the promised topics. Later passes should add a
complete SQLite project, more worked examples, preview/lab/homework notebooks,
and a semester-project persistence milestone.
