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
| 07 | `chapters/07-society-ethics` | Society, Ethics, and the Profession | preview, lab, homework | Draft | Added 2026-10-04 for CS2023 SEP coverage; chapters after it renumbered 08–25; needs a chapter video |

## Part II — Data and I/O

| TOC order | Folder | Title | Assignments | Status | Notes |
| --------- | ------ | ----- | ----------- | ------ | ----- |
| 08 | `chapters/08-arrays` | Arrays | preview, lab, homework | In Progress | Renumbered from old Ch06 path |
| 09 | `chapters/09-collections` | Data Collections | preview, lab, homework | In Progress | Stale `0802-list-dictionary`, `1101`, `1102` source notebooks removed 2026-10-04 |
| 10 | `chapters/10-files-text` | Files and Text | preview, lab, homework plus legacy grade-files page | In Progress | Legacy `hw-gradefiles.ipynb` remains in TOC |

## Part III — Object-Oriented Information Systems

| TOC order | Folder | Title | Assignments | Status | Notes |
| --------- | ------ | ----- | ----------- | ------ | ----- |
| 11 | `chapters/11-classes` | Classes | preview, lab, homework plus legacy book-list page | In Progress | Operator overloading is still in main TOC; may become extension material |
| 12 | `chapters/12-oop` | Object-Oriented Programming | preview, lab, homework | In Progress | Renumbered from old Ch10 path |
| 13 | `chapters/13-databases` | Databases | none in TOC | Needs Review | Core database sections exist; assignments remain pending |

## Part IV — Data Structures

| TOC order | Folder | Title | Assignments | Status | Notes |
| --------- | ------ | ----- | ----------- | ------ | ----- |
| 14 | `chapters/14-abstract-data-types` | ADTs | preview, lab, homework | In Progress | Landing filename normalized to `1400-abstract-data-types.ipynb` |
| 15 | `chapters/15-arrays-linked-lists` | Linear Lists | preview, lab, homework | In Progress | First content and assignment pass added |
| 16 | `chapters/16-stacks-queues` | Stacks & Queues | preview, lab, homework | In Progress | First content and assignment pass added |
| 17 | `chapters/17-trees` | Trees | preview, lab, homework | In Progress | First content and assignment pass added |
| 18 | `chapters/18-heaps-hash-tables` | Hashing & Heaps | preview, lab, homework | In Progress | First content and assignment pass added |
| 19 | `chapters/19-graphs` | Graphs | preview, lab, homework | In Progress | First content and assignment pass added |

## Part V — Algorithms

| TOC order | Folder | Title | Assignments | Status | Notes |
| --------- | ------ | ----- | ----------- | ------ | ----- |
| 20 | `chapters/20-algorithm-analysis` | Analysis | preview, lab, homework | In Progress | First content and assignment pass added |
| 21 | `chapters/21-recursion-divide-conquer` | Recursion | preview, lab, homework | In Progress | First content and assignment pass added |
| 22 | `chapters/22-searching-sorting` | Search & Sort | preview, lab, homework | In Progress | First content and assignment pass added |
| 23 | `chapters/23-greedy-graph-optimization` | Greedy Algorithms | preview, lab, homework | In Progress | First content and assignment pass added |
| 24 | `chapters/24-dynamic-programming-backtracking` | Dynamic Programming | preview, lab, homework | In Progress | First content and assignment pass added |
| 25 | `chapters/25-advanced-graphs-strings-limits` | Advanced Algorithms | preview, lab, homework | In Progress | First content and assignment pass added |

## Non-TOC and Staging Tracks

These folders/files are present in the repository but not active in `_toc.yml`.

| Path | Role | Next action |
| ---- | ---- | ----------- |
| `chapters/13-exceptions-testing` | Retired/stale exceptions-testing track | Remove after confirming no unique content remains |
| `chapters/14-functional-patterns` | Staging track for lambdas/LINQ/recursion-related material | Keep out of TOC or relabel as extension material |
| `chapters/15-pattern-records` | Staging track for pattern matching and records | Keep out of TOC or relabel as extension material |
| `chapters/16-generics-async` | Staging track for generics/nullability/async | Keep out of TOC or relabel as extension material |
| `chapters/13-databases/1201`–`1205` | Former modern-C# material inside the databases folder | Move, archive, or relabel before final Ch12 cleanup |
| `chapters/appendices/appendix-intro.ipynb` | Appendix landing draft | Add to TOC or remove if unused |

## Consistency Notes

- Chapter 13 has database content now, but no assignment section in the active TOC.
- Active chapter folders now run Ch01-Ch24 without the former duplicate Ch06 or missing Ch11.
- Older planning docs in Chapters 01–11 and the non-TOC staging tracks still need
  `orphan: true` front matter.
- Legacy assignment pages remain in the TOC for Chapters 05, 10, and 11. Decide
  whether these should stay as extra homework, move under instructor materials, or
  be retired.

## Pending Actions

1. Finish Chapter 13 assignments after the database chapter pass.
2. Add `orphan: true` front matter to older `MATERIALS.md` and `ORGANIZATION.md` files.
3. Remove, archive, or clearly label non-TOC staging tracks.
4. Revisit legacy extra homework pages in Chapters 05, 10, and 11.
5. Run a clean full-book build after structural renames are complete.
