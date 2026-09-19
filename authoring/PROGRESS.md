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
| 06 | `chapters/06-exceptions-testing` | Exceptions, Debugging, Testing, and Nullability | preview, lab, homework | In Progress | Filenames normalized to `06xx` |

## Part II — Data and I/O

| TOC order | Folder | Title | Assignments | Status | Notes |
| --------- | ------ | ----- | ----------- | ------ | ----- |
| 07 | `chapters/07-arrays` | Arrays | preview, lab, homework | In Progress | Renumbered from old Ch06 path |
| 08 | `chapters/08-collections` | Data Collections | preview, lab, homework | In Progress | `0802-list-dictionary.ipynb` is a stale merge source, not in TOC |
| 09 | `chapters/09-files-text` | Files and Text | preview, lab, homework plus legacy grade-files page | In Progress | Legacy `hw-gradefiles.ipynb` remains in TOC |

## Part III — Object-Oriented Information Systems

| TOC order | Folder | Title | Assignments | Status | Notes |
| --------- | ------ | ----- | ----------- | ------ | ----- |
| 10 | `chapters/10-classes` | Classes | preview, lab, homework plus legacy book-list page | In Progress | Operator overloading is still in main TOC; may become extension material |
| 11 | `chapters/11-oop` | Object-Oriented Programming | preview, lab, homework | In Progress | Renumbered from old Ch10 path |
| 12 | `chapters/12-databases` | Databases | none in TOC | Needs Review | Core database sections exist; assignments remain pending |

## Part IV — Data Structures

| TOC order | Folder | Title | Assignments | Status | Notes |
| --------- | ------ | ----- | ----------- | ------ | ----- |
| 13 | `chapters/13-abstract-data-types` | ADTs | preview, lab, homework | In Progress | Landing filename normalized to `1300-abstract-data-types.ipynb` |
| 14 | `chapters/14-arrays-linked-lists` | Linear Lists | preview, lab, homework | In Progress | First content and assignment pass added |
| 15 | `chapters/15-stacks-queues` | Stacks & Queues | preview, lab, homework | In Progress | First content and assignment pass added |
| 16 | `chapters/16-trees` | Trees | preview, lab, homework | In Progress | First content and assignment pass added |
| 17 | `chapters/17-heaps-hash-tables` | Hashing & Heaps | preview, lab, homework | In Progress | First content and assignment pass added |
| 18 | `chapters/18-graphs` | Graphs | preview, lab, homework | In Progress | First content and assignment pass added |

## Part V — Algorithms

| TOC order | Folder | Title | Assignments | Status | Notes |
| --------- | ------ | ----- | ----------- | ------ | ----- |
| 19 | `chapters/19-algorithm-analysis` | Analysis | preview, lab, homework | In Progress | First content and assignment pass added |
| 20 | `chapters/20-recursion-divide-conquer` | Recursion | preview, lab, homework | In Progress | First content and assignment pass added |
| 21 | `chapters/21-searching-sorting` | Search & Sort | preview, lab, homework | In Progress | First content and assignment pass added |
| 22 | `chapters/22-greedy-graph-optimization` | Greedy Algorithms | preview, lab, homework | In Progress | First content and assignment pass added |
| 23 | `chapters/23-dynamic-programming-backtracking` | Dynamic Programming | preview, lab, homework | In Progress | First content and assignment pass added |
| 24 | `chapters/24-advanced-graphs-strings-limits` | Advanced Algorithms | preview, lab, homework | In Progress | First content and assignment pass added |

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

- Chapter 12 has database content now, but no assignment section in the active TOC.
- Active chapter folders now run Ch01-Ch24 without the former duplicate Ch06 or missing Ch11.
- Older planning docs in Chapters 01–10 and the non-TOC staging tracks still need
  `orphan: true` front matter.
- Legacy assignment pages remain in the TOC for Chapters 05, 08, and 09. Decide
  whether these should stay as extra homework, move under instructor materials, or
  be retired.

## Pending Actions

1. Finish Chapter 12 assignments after the database chapter pass.
2. Add `orphan: true` front matter to older `MATERIALS.md` and `ORGANIZATION.md` files.
3. Remove, archive, or clearly label non-TOC staging tracks.
4. Revisit legacy extra homework pages in Chapters 05, 09, and 10.
5. Run a clean full-book build after structural renames are complete.
