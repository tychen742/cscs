# Progress — CSCS in C#

Status values: `Draft` · `In Progress` · `Needs Review` · `Complete`

This file tracks the active book sequence in `_toc.yml`. Retired or staging
folders may still exist in `chapters/`, but they are not part of the student
book unless they are listed in the TOC.

## Press snake_case migration (2026-10-11)

Renamed 124 chapter, front-matter, appendix, and `_html_extra` folders and
notebooks to Press `snake_case` (for example `01-context/0100-getting-started`
is now `01_context/0100_getting_started`; `front-matter` is now `front_matter`).
Updated `_toc.yml`, links, and tooling paths, and added redirects for every old
URL in `_ext/chapter_redirects.json`. Reading-progress data stored by old page
path (browser `localStorage` or server records) is not migrated.

## Active TOC Snapshot

- Root: `chapters/preface.ipynb`
- Regular technical-chapter assignments: `preview.ipynb`, `lab.ipynb`, and
  `homework.ipynb`
- Appendices: Resources, Command Line, Project, and CS Index

## Part I — Fundamentals

| TOC order | Folder | Title | Assignments | Status | Notes |
| --------- | ------ | ----- | ----------- | ------ | ----- |
| 01 | `chapters/01-context` | Getting Started with C# | preview, lab, homework | In Progress | 1.2 teaches tools; 1.3 introduces the first console app, terminal `dotnet run`, namespaces, and explicit `Main` |
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
| 11 | `chapters/11_databases` | Databases | none in TOC | Needs Review | Core database sections exist; assignments remain pending |

## Part III — Object-Oriented Programming

| TOC order | Folder | Title | Assignments | Status | Notes |
| --------- | ------ | ----- | ----------- | ------ | ----- |
| 12 | `chapters/12_classes` | Classes | preview, lab, homework plus legacy book-list page | In Progress | Operator overloading is still in main TOC; may become extension material |
| 13 | `chapters/13_oop` | Object-Oriented Programming | preview, lab, homework | In Progress | Renumbered from old Ch10 path |

## Part IV — Data Structures

| TOC order | Folder | Title | Assignments | Status | Notes |
| --------- | ------ | ----- | ----------- | ------ | ----- |
| 14 | `chapters/14-abstract-data-types` | ADTs | preview, lab, homework | In Progress | Landing filename normalized to `1400-abstract-data-types.ipynb` |
| 15 | `chapters/15-arrays-linked-lists` | Linear Lists | preview, lab, homework | In Progress | Depth pass 2026-10-05: complete generic sequences, traces, amortized reasoning, boundary tests, and expanded practice; follow-up connects work-order lab, strengthens homework, and retains verified solution outputs; slides pending |
| 16 | `chapters/16-stacks-queues` | Stacks & Queues | preview, lab, homework | In Progress | Depth pass 2026-10-05: complete generic stack/ring/linked queues, invariant traces, qualified costs, undo/redo, connected lab, independent homework, and verified outputs; slides pending |
| 17 | `chapters/17-trees` | Trees | preview, lab, homework | In Progress | Depth pass 2026-10-05: recursive/traversal traces, boundary-safe ancestor validation, complete BST removal, height-based costs, range/level-order operations, connected lab, transfer homework, and verified outputs; slides pending |
| 18 | `chapters/18-heaps-hash-tables` | Hashing & Heaps | preview, lab, homework | In Progress | Depth pass 2026-10-05: complete generic heap and chained map, repair/collision/rehash traces, equality and tie policies, qualified costs, top-k and lazy cancellation, connected lab, transfer homework, and verified outputs; slides pending |
| 19 | `chapters/19-graphs` | Graphs | preview, lab, homework | In Progress | Depth pass 2026-10-05: complete weighted graph operations and invariants, explicit isolates and zero weights, protected snapshots, matrix conversion, supplied-walk checks, connected lab, transfer homework, and verified outputs; slides pending |

## Part V — Algorithms

| TOC order | Folder | Title | Assignments | Status | Notes |
| --------- | ------ | ----- | ----------- | ------ | ----- |
| 20 | `chapters/20-algorithm-analysis` | Analysis | preview, lab, homework | In Progress | Depth pass 2026-10-05: exact counts and tight bounds, input-dependent/expected/amortized costs, precise contracts and termination variants, rounded recurrences and call/stack distinctions, connected expense-report lab, transfer homework, and verified outputs; slides pending |
| 21 | `chapters/21-recursion-divide-conquer` | Recursion | preview, lab, homework | In Progress | Depth pass 2026-10-05: guarded recursive contracts, call/return and merge traces, complete stable range-buffer sort, occurrence/copy/stability checks, actual operation counts, connected invoice lab, transfer homework, and verified outputs; slides pending |
| 22 | `chapters/22-searching-sorting` | Search & Sort | preview, lab, homework | In Progress | Depth pass 2026-10-05: first/any/all-match contracts and bounds, equality/order policies, complete generic elementary sorts and invariants, inversions/stability/permutation checks, workload preparation costs, connected report lab, transfer homework, and verified outputs; slides pending |
| 23 | `chapters/23-greedy-graph-optimization` | Greedy Algorithms | preview, lab, homework | In Progress | Depth pass 2026-10-05: verified greedy counterexamples and exchange proofs, complete Kruskal forests with balanced union-find, guarded Dijkstra and path reconstruction, independent optimization checks, connected facilities lab, transfer homework, and verified outputs; slides pending |
| 24 | `chapters/24-dynamic-programming-backtracking` | Dynamic Programming | preview, lab, homework | In Progress | Depth pass 2026-10-05: complete states and recurrences, measured memoization/tabulation/rolling costs, minimum-coin witnesses and unreachable states, signed one-use search with safe bounds and failed-state caching, undo/snapshot invariants, independent references, connected purchasing lab, transfer homework, and verified outputs; slides pending |
| 25 | `chapters/25-advanced-graphs-strings-limits` | Advanced Algorithms | preview, lab, homework | In Progress | Depth pass 2026-10-05: guarded BFS layers/paths, recursive-order frame DFS, symmetric components, complete ordinal overlapping KMP with empty-pattern policy and comparison counts, exact growth/coverage checks, heuristic-quality distinctions, connected service-network lab, transfer homework, and verified outputs; slides pending |

## Non-TOC and Staging Tracks

These folders/files are present in the repository but not active in `_toc.yml`.

| Path | Role | Next action |
| ---- | ---- | ----------- |
| `chapters/13-exceptions-testing` | Retired/stale exceptions-testing track | Remove after confirming no unique content remains |
| `chapters/14-functional-patterns` | Staging track for lambdas/LINQ/recursion-related material | Keep out of TOC or relabel as extension material |
| `chapters/15-pattern-records` | Staging track for pattern matching and records | Keep out of TOC or relabel as extension material |
| `chapters/16-generics-async` | Staging track for generics/nullability/async | Keep out of TOC or relabel as extension material |
| `chapters/11_databases/1201`–`1205` | Former modern-C# material inside the databases folder | Move, archive, or relabel before final Ch12 cleanup |
| `chapters/appendices/appendix_overview.ipynb` | Appendix landing draft | Add to TOC or remove if unused |

## Consistency Notes

- Chapter 11 has database content now, but no assignment section in the active TOC.
- Active chapter folders now run Ch01-Ch24 without the former duplicate Ch06 or missing Ch11.
- Older planning docs in Chapters 01–11 and the non-TOC staging tracks still need
  `orphan: true` front matter.
- Legacy assignment pages remain in the TOC for Chapters 05, 10, and 11. Decide
  whether these should stay as extra homework, move under instructor materials, or
  be retired.

## Pending Actions

1. Finish Chapter 11 assignments after the database chapter pass.
2. Add `orphan: true` front matter to older `MATERIALS.md` and `ORGANIZATION.md` files.
3. Remove, archive, or clearly label non-TOC staging tracks.
4. Revisit legacy extra homework pages in Chapters 05, 10, and 11.
5. Run a clean full-book build after structural renames are complete.

## Curriculum Appendix Update (2026-10-07)

Added a separate IS2020 mapping to the existing curriculum-alignment appendix. The ten required areas distinguish direct introductory contributions, partial coverage, supporting project activities, and material outside scope. Object-oriented elective support and Chapter 11 assessment limitations are explicit. The CS2023 chapter mapping remains in place; the Contents label includes both frameworks.

## Part IV Foundations Move (2026-10-07)

Moved basic recursive calls and sequence search/library sorting from Part V into Chapters 17 and 15, respectively; introduced Big-O foundations in Chapter 14; moved graph traversal into Chapter 19. Existing Chapter 21/22/25 URLs introduce the optional extensions and link to the new prerequisite locations. Part V is optional for the College of Business pathway. Planning and curriculum mapping reflect this distinction. Slides remain pending.

Verification: 21 completed cells in the receiving sections compiled and ran with isolated setup under .NET 10. Answer output is retained. Full HTML build passed with five pre-existing warnings outside the changed chapters; notebook JSON and diffs were checked.

## Preface Organization Update (2026-10-07)

The Preface now explains the five parts, the first-course foundation and second-course prerequisites, and the College of Business pathway with optional Part V. Its curriculum-appendix reference names both IS2020 and CS2023; detailed mappings remain in the appendix.

## Curriculum Mapping Priority (2026-10-07)

IS2020 mapping and course-use evidence now precede the CS2023 mapping, reflecting the primary College of Business audience. Appendix title and Contents label use IS2020 first. Existing appendix path and cross-reference anchors are preserved.

## Database Chapter Move (2026-10-07)

Databases now closes Part II as Chapter 11. Classes and OOP Principles are Chapters 12 and 13 in Part III, Object-Oriented Programming. The database workflow reads results into ordinary variables before custom classes are introduced. Existing assignment IDs are preserved; old chapter URLs redirect to the new paths. Database assignments remain pending.

## Demo Materials Cleanup (2026-10-09)

Migrated the former `demos/demos/` collection to current numbered chapter
folders and `_extras/`. All 27 migrated projects target .NET 10. Removed empty
container/wrapper files, completed broken array/loop examples, corrected
arithmetic and shape results, fixed entry-point and input/EOF issues, and made
bundled data independent of the working directory. `scripts/verify_demos.py`
builds the projects, runs console scenarios, executes both MSTest suites, and
runs independent algorithm/input/file behavior checks. See `demos/README.md`
for the full project and migration index.

## Git Appendix Placement (2026-10-09)

Moved Git workflow instruction out of Section 1.2 into the existing third
appendix, Git and GitHub (Appendix C). Integrated recurring commit habits and
conflict resolution with its existing branch/pull-request instructions. Updated
the Chapter Topics summary and Chapter 1 planning notes. Appendix order and
published notebook paths are unchanged.

## Commons Development Fundamentals (2026-10-10)

Added Commons command-line, editing, and REPL references under Appendix B,
retaining the existing appendix URL and Git's Appendix C position. Section 1.2
now guides .NET 10 SDK verification, workspace preparation, C# Dev Kit setup,
and CSharpRepl installation/experiments. The first console app stays in 1.3.
Canonical shared sources live in thinkpress-commons; sync via commons.yml.

## Setup Guidance and Ecosystem Overview (2026-10-10)

Section 1.2 now opens with the Microsoft language and .NET ecosystem (languages,
app stacks, editors) and orders setup as .NET 10 SDK, VS Code, then C# Dev Kit
with verification of the C# and .NET Install Tool extensions. Chapter 1 learning
objectives, glossary, and Chapter Topics were updated. The Group Project appendix
gained a platform-compatibility note: .NET MAUI has no official Linux support.

## Project Appendix Restructure (2026-10-10)

The Project appendix is now a landing page with two sections: an Individual
Project (midterm, solo) and a Group Project (final, team of 3-4), per the Press
rule that every book has one of each. The former single Group Project page moved
to `chapters/appendices/project/group_project.ipynb`; the individual guidelines
are new drafts. Milestone pages are not yet written. Contents was updated.

## Instructor Resource Correspondence (2026-10-10)

Added `instructor_support/` with 27 role-labeled project walkthroughs,
verified console output captures, and an inventory of 88 assignment notebooks.
Current assignment guides cover the Chapter 3 Product Code Report task, Chapter 7
Privacy Pass tasks/reflections, and all five Chapter 8 sales-lab answers.
Standalone Chapter 3/7 references now have explicit .NET 10 project files.
Legacy array/classes/math/OOP projects are marked supplementary rather than
claimed as current lab solutions. Remaining assignment explanations and source-bank
walkthroughs are identified as gaps; a complete instructor manual is not claimed.

## Version Control Lab Merged into Git Appendix (2026-10-10)

The legacy Mercurial/Bitbucket `lab-versioncontrol` notebook was archived to
`demos/_archived/01/`. Its motivation (why version control, local versus
remote, the track/commit/push/ignore/pull steps) and the lab-and-home workflow
were rewritten for Git and GitHub in the Git and GitHub appendix.

## Instructor Support Location (2026-10-10)

Instructor support now lives at the repository root, `instructor_support/`,
for future teaching resources beyond assignment answers. Guide links, resource
mappings, and verification root discovery were updated together.

## Demo and Script Locations (2026-10-10)

Renamed root `materials/` to `demos/` and moved active demo/lab verification
and cover generation utilities to `scripts/`. Updated active notebook links,
instructor mappings, run commands, project instructions, and deployment path
filters. Historical utilities remain in the archive. Student notebook URLs
are unchanged.
