# Progress — CSCS in C#

Status values: `Draft` · `In Progress` · `Needs Review` · `Complete`

This file tracks the active book sequence in `_toc.yml`. Retired or staging
folders may still exist in `chapters/`, but they are not part of the student
book unless they are listed in the TOC.

## Active TOC Snapshot

- Root: `chapters/preface.ipynb`
- Regular technical-chapter assignments: `preview.ipynb`, `lab.ipynb`, and
  `homework.ipynb`
- Appendices: Resources, Command Line, Project, and CS Index

## Part I — Fundamentals

| TOC order | Folder | Title | Assignments | Status | Notes |
| --------- | ------ | ----- | ----------- | ------ | ----- |
| 01 | `chapters/01-context` | Getting Started with C# | preview, lab, homework | In Progress | Tooling should eventually move to appendices |
| 02 | `chapters/02-var_data` | Variables, Data Types, and Operators | preview, lab, homework | In Progress | |
| 03 | `chapters/03-methods` | Methods | preview, lab, homework | In Progress | |
| 04 | `chapters/04-decision` | Decisions | preview, lab, homework | In Progress | `0409-recursion.ipynb` is retained source material, not in TOC |
| 05 | `chapters/05-iteration` | Iteration | preview, lab, homework plus legacy grade-calculation pages | In Progress | Legacy homework pages are still listed in TOC |
| 06 | `chapters/06-exceptions-testing` | Exceptions, Debugging, Testing, and Nullability | preview, lab, homework | In Progress | Folder is Ch06, but notebook filenames still use `13xx` |

## Part II — Data and I/O

| TOC order | Folder | Title | Assignments | Status | Notes |
| --------- | ------ | ----- | ----------- | ------ | ----- |
| 06 | `chapters/06-arrays` | Arrays | preview, lab, homework | In Progress | Shares the `06` chapter number with exceptions/testing |
| 07 | `chapters/07-collections` | Collections | preview, lab, homework | In Progress | `0702-list-dictionary.ipynb` is a stale merge source, not in TOC |
| 08 | `chapters/08-files-text` | Files and Text | preview, lab, homework plus legacy grade-files page | In Progress | Legacy `hw-gradefiles.ipynb` remains in TOC |

## Part III — Object-Oriented Information Systems

| TOC order | Folder | Title | Assignments | Status | Notes |
| --------- | ------ | ----- | ----------- | ------ | ----- |
| 09 | `chapters/09-classes` | Classes | preview, lab, homework plus legacy book-list page | In Progress | Operator overloading is still in main TOC; may become extension material |
| 10 | `chapters/10-oop` | Object-Oriented Programming | preview, lab, homework | In Progress | |
| 12 | `chapters/12-databases` | Databases | none in TOC | Needs Review | Core database sections exist; assignments and Ch11 sequencing remain unresolved |

## Part IV — Data Structures

| TOC order | Folder | Title | Assignments | Status | Notes |
| --------- | ------ | ----- | ----------- | ------ | ----- |
| 13 | `chapters/13-abstract-data-types` | Abstract Data Types | preview, lab, homework | In Progress | Landing filename still uses stale `1100` prefix |
| 14 | `chapters/14-arrays-linked-lists` | Arrays and Linked Lists | preview, lab, homework | In Progress | First content and assignment pass added |
| 15 | `chapters/15-stacks-queues` | Stacks and Queues | preview, lab, homework | In Progress | First content and assignment pass added |
| 16 | `chapters/16-trees` | Trees and Binary Search Trees | preview, lab, homework | In Progress | First content and assignment pass added |
| 17 | `chapters/17-heaps-hash-tables` | Heaps and Hash Tables | preview, lab, homework | In Progress | First content and assignment pass added |
| 18 | `chapters/18-graphs` | Graph Data Structures | preview, lab, homework | In Progress | First content and assignment pass added |

## Part V — Algorithms

| TOC order | Folder | Title | Assignments | Status | Notes |
| --------- | ------ | ----- | ----------- | ------ | ----- |
| 19 | `chapters/19-algorithm-analysis` | Algorithm Analysis | preview, lab, homework | In Progress | First content and assignment pass added |
| 20 | `chapters/20-recursion-divide-conquer` | Recursion and Divide-and-Conquer | preview, lab, homework | In Progress | First content and assignment pass added |
| 21 | `chapters/21-searching-sorting` | Searching and Sorting | preview, lab, homework | In Progress | First content and assignment pass added |
| 22 | `chapters/22-greedy-graph-optimization` | Greedy Graph Optimization | preview, lab, homework | In Progress | First content and assignment pass added |
| 23 | `chapters/23-dynamic-programming-backtracking` | Dynamic Programming and Backtracking | preview, lab, homework | In Progress | First content and assignment pass added |
| 24 | `chapters/24-advanced-graphs-strings-limits` | Advanced Graphs, Strings, and Limits | preview, lab, homework | In Progress | First content and assignment pass added |

## Non-TOC and Staging Tracks

These folders/files are present in the repository but not active in `_toc.yml`.

| Path | Role | Next action |
| ---- | ---- | ----------- |
| `chapters/13-exceptions-testing` | Retired/stale exceptions-testing track | Remove after confirming no unique content remains |
| `chapters/14-functional-patterns` | Staging track for lambdas/LINQ/recursion-related material | Keep out of TOC or relabel as extension material |
| `chapters/15-pattern-records` | Staging track for pattern matching and records | Keep out of TOC or relabel as extension material |
| `chapters/16-generics-async` | Staging track for generics/nullability/async | Keep out of TOC or relabel as extension material |
| `chapters/12-databases/1201`–`1205` | Former modern-C# material inside the databases folder | Move, archive, or relabel before final Ch12 cleanup |
| `chapters/appendices/appendix-intro.ipynb` | Appendix landing draft | Add to TOC or remove if unused |

## Consistency Notes

- `_toc.yml` now uses the 24-chapter sequence, but there is no active Chapter 11.
- Two active folders use chapter number 06: `06-exceptions-testing` and `06-arrays`.
- Chapter 12 has database content now, but no assignment section in the active TOC.
- Chapter 13's landing file is still named `1100-datastructure-intro.ipynb`.
- Older planning docs in Chapters 01–10 and the non-TOC staging tracks still need
  `orphan: true` front matter.
- Legacy assignment pages remain in the TOC for Chapters 05, 08, and 09. Decide
  whether these should stay as extra homework, move under instructor materials, or
  be retired.

## Pending Actions

1. Decide and normalize the Chapter 06 / Chapter 11 numbering sequence.
2. Finish Chapter 12 assignments after the database chapter pass.
3. Rename or alias Chapter 13 landing material so filenames match the active chapter number.
4. Add `orphan: true` front matter to older `MATERIALS.md` and `ORGANIZATION.md` files.
5. Remove, archive, or clearly label non-TOC staging tracks.
6. Revisit legacy extra homework pages in Chapters 05, 08, and 09.
7. Run a clean full-book build after structural renames are complete.
