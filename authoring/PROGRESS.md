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

## Active TOC Snapshot (2026-10-16, seven parts)

- Root: `index.ipynb`.
- CS1: Parts I-III, Chapters 1-12. CS2 foundation: Parts IV-V, Chapters 13-20. Selectable algorithms: Parts VI-VII, Chapters 21-26.
- Chapter 1 teaches computing, responsibility, and a first program. Setup is in Appendix B; Git/professional reference stays in Appendix C.
- Former ethics content recurs as optional cases in Chapter 6 and privacy practice in Chapter 9. Legacy assessments remain available with their original identifiers.
- Databases and operator overloading remain optional appendices.

| TOC order | Folder | Title | Assignments | Status | Notes |
| --- | --- | --- | --- | --- | --- |
| 01 | `chapters/01_context` | Computing, Programs, and Responsibility | preview, lab, homework | Needs Review | Revised three-section progression; 1.3 adds basic syntax and connected order-desk exercises; assignments aligned; video/slides pending. |
| 02 | `chapters/02_var_data` | Variables, Data Types, and Operators | preview, lab, homework | In Progress | Assessments aligned with the three sections and built-in methods; lessons retain their existing review status |
| 03 | `chapters/03_decision` | Decisions | preview, lab, homework | In Progress | `0409-recursion.ipynb` is retained source material, not in TOC |
| 04 | `chapters/04_iteration` | Iteration | preview, lab, homework | In Progress | Legacy homework pages are still listed in TOC |
| 05 | `chapters/05_methods` | Methods | preview, lab, homework | In Progress |  |
| 06 | `chapters/06_exceptions_testing` | Testing, Debugging, and Error Handling | preview, lab, homework | In Progress | Renamed; three core lessons retained. Deeper nullability relocated to Chapter 11; teaching/assessment alignment remains pending. Optional software-failure cases retained. |
| 07 | `chapters/07_arrays` | Arrays | preview, lab, homework | In Progress | Renumbered from old Ch06 path |
| 08 | `chapters/08_collections` | Data Collections | preview, lab, homework | In Progress | Stale `0802-list-dictionary`, `1101`, `1102` source notebooks removed 2026-10-04 |
| 09 | `chapters/09_files_text` | Files and Text | preview, lab, homework | In Progress | Legacy `hw-gradefiles.ipynb` remains in TOC Optional privacy/security section and retained privacy assessments. |
| 10 | `chapters/10_classes` | Classes and Objects | preview, lab, homework | Needs Review | Standard assignments revised and solutions verified; Book List optional after Chapter 12; slides pending |
| 11 | `chapters/11_object_design` | Object Design and Composition | preview, lab, homework | Needs Review | Three lessons, connected order lab, transfer homework, and standalone reference checks; video/slides pending |
| 12 | `chapters/12_oop` | Inheritance, Interfaces, and Polymorphism | preview, lab, homework | Needs Review | Three revised sections, connected policy lab, transfer homework, and reference checks; original video retained; slides pending |
| 13 | `chapters/13_abstract_data_types` | Abstract Data Types | preview, lab, homework | In Progress | Landing filename normalized to `1400-abstract-data-types.ipynb` |
| 14 | `chapters/14_arrays_linked_lists` | Arrays and Linked Lists | preview, lab, homework | In Progress | Depth pass 2026-10-05: complete generic sequences, traces, amortized reasoning, boundary tests, and expanded practice; follow-up connects work-order lab, strengthens homework, and retains verified solution outputs; slides pending |
| 15 | `chapters/15_stacks_queues` | Stacks and Queues | preview, lab, homework | In Progress | Depth pass 2026-10-05: complete generic stack/ring/linked queues, invariant traces, qualified costs, undo/redo, connected lab, independent homework, and verified outputs; slides pending |
| 16 | `chapters/16_searching_sorting` | Searching and Basic Sorting | preview, lab, homework | Needs Review | Three lessons: linear/binary search, stable insertion sort, and report workloads; reference checks; slides/video pending |
| 17 | `chapters/17_trees` | Trees and Binary Search Trees | preview, lab, homework | In Progress | Depth pass 2026-10-05: recursive/traversal traces, boundary-safe ancestor validation, complete BST removal, height-based costs, range/level-order operations, connected lab, transfer homework, and verified outputs; slides pending |
| 18 | `chapters/18_priority_queues` | Priority Queues and Heaps | preview, lab, homework | Needs Review | Three lessons; heap repair, stable ties, top-k; executed examples and solutions; slides pending |
| 19 | `chapters/19_hash_collections` | Hash Collections and Sets | preview, lab, homework | Needs Review | Three lessons: collisions, dictionaries/set algebra, collection selection; executed solutions; slides/video pending |
| 20 | `chapters/20_graphs` | Graphs and Traversal | preview, lab, homework | Needs Review | Three meetings; representation workshop moved to appendix; BFS, DFS, paths, components directly assessed; slides pending |
| 21 | `chapters/21_algorithm_analysis` | Algorithm Analysis | preview, lab, homework | In Progress | Depth pass 2026-10-05: exact counts and tight bounds, input-dependent/expected/amortized costs, precise contracts and termination variants, rounded recurrences and call/stack distinctions, connected expense-report lab, transfer homework, and verified outputs; slides pending |
| 22 | `chapters/22_recursion_divide_conquer` | Recursion and Divide and Conquer | preview, lab, homework | In Progress | Depth pass 2026-10-05: guarded recursive contracts, call/return and merge traces, complete stable range-buffer sort, occurrence/copy/stability checks, actual operation counts, connected invoice lab, transfer homework, and verified outputs; slides pending |
| 23 | `chapters/23_searching_sorting` | Advanced Searching and Sorting | preview, lab, homework | In Progress | Depth pass 2026-10-05: first/any/all-match contracts and bounds, equality/order policies, complete generic elementary sorts and invariants, inversions/stability/permutation checks, workload preparation costs, connected report lab, transfer homework, and verified outputs; slides pending |
| 24 | `chapters/24_greedy_graph_optimization` | Greedy Algorithms and Graph Optimization | preview, lab, homework | In Progress | Depth pass 2026-10-05: verified greedy counterexamples and exchange proofs, complete Kruskal forests with balanced union-find, guarded Dijkstra and path reconstruction, independent optimization checks, connected facilities lab, transfer homework, and verified outputs; slides pending |
| 25 | `chapters/25_dynamic_programming_backtracking` | Dynamic Programming and Backtracking | preview, lab, homework | In Progress | Depth pass 2026-10-05: complete states and recurrences, measured memoization/tabulation/rolling costs, minimum-coin witnesses and unreachable states, signed one-use search with safe bounds and failed-state caching, undo/snapshot invariants, independent references, connected purchasing lab, transfer homework, and verified outputs; slides pending |
| 26 | `chapters/26_advanced_graphs_strings_limits` | Advanced Graphs, Strings, and Computational Limits | preview, lab, homework | In Progress | Depth pass 2026-10-05: guarded BFS layers/paths, recursive-order frame DFS, symmetric components, complete ordinal overlapping KMP with empty-pattern policy and comparison counts, exact growth/coverage checks, heuristic-quality distinctions, connected service-network lab, transfer homework, and verified outputs; slides pending |

## Non-TOC and Archived Tracks

Retired or unpublished tracks live under `materials/stale_chapters/`, including functional patterns, pattern/record drafts, generics/async drafts, former database language extensions, and the pre-integration ethics landing/planning files. They are not required chapters. Published historical extension URLs lead to the resources page explaining their archival location.

## Consistency Notes

- Active numbered chapter folders run 01-26.
- Databases remains an optional appendix with a connected inventory lab.
- Privacy practice is optional in Chapter 9 and retains its assessment identifiers.
- Legacy extra homework remains in Chapters 5, 9, and 10. The Book List assignment is optional after Chapter 11 (Object Design).
- Earlier dated progress entries below describe prior structures and retain their historical chapter numbers.

## Pending Actions

1. Review the revised Chapter 1, Chapter 2, and Classes assessments; modernize the optional Book List separately if needed.
2. Finish videos and slides for revised/new units, including Chapter 1.
3. Revisit optional legacy extra homework in Chapters 5, 9, and 10.
4. Strengthen optional Parts VI-VII in a later dedicated pass.
5. Align early testing practice and Chapter 6 assessments with the staged reliability progression; integrate Chapter 11 nullability examples and missing-data tests within its three meetings.

## Curriculum Appendix Update (2026-10-07)

Added a separate IS2020 mapping to the existing curriculum-alignment appendix. The ten required areas distinguish direct introductory contributions, partial coverage, supporting project activities, and material outside scope. Object-oriented elective support and Chapter 11 assessment limitations are explicit. The CS2023 chapter mapping remains in place; the Contents label includes both frameworks.

## Part IV Foundations Move (2026-10-07)

Moved basic recursive calls and sequence search/library sorting from Part V into Chapters 18 and 15, respectively; introduced Big-O foundations in Chapter 14; moved graph traversal into Chapter 21. Existing Chapter 23/22/25 URLs introduce the optional extensions and link to the new prerequisite locations. Part V is optional for the College of Business pathway. Planning and curriculum mapping reflect this distinction. Slides remain pending.

Verification: 21 completed cells in the receiving sections compiled and ran with isolated setup under .NET 10. Answer output is retained. Full HTML build passed with five pre-existing warnings outside the changed chapters; notebook JSON and diffs were checked.

## Preface Organization Update (2026-10-07)

The Preface now explains the five parts, the first-course foundation and second-course prerequisites, and the College of Business pathway with optional Part V. Its curriculum-appendix reference names both IS2020 and CS2023; detailed mappings remain in the appendix.

## Curriculum Mapping Priority (2026-10-07)

IS2020 mapping and course-use evidence now precede the CS2023 mapping, reflecting the primary College of Business audience. Appendix title and Contents label use IS2020 first. Existing appendix path and cross-reference anchors are preserved.

## Database Chapter Move (2026-10-07)

Databases now closes Part II as Chapter 11. Classes and OOP Principles are Chapters 11 and 13 in Part III, Object-Oriented Programming. The database workflow reads results into ordinary variables before custom classes are introduced. Existing assignment IDs are preserved; old chapter URLs redirect to the new paths. Database assignments remain pending.

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

## Chapter 2 Restructured Around Built-In Methods (2026-10-10)

Chapter 2 now has three sections: `0201_variables_types` (merged from the
former variables and types sections), `0202_operators_built_in_methods`
(operators plus a new Built-In Methods section: method calls, `Math`, `Parse`,
a brief string methods intro, reading signatures, one practice exercise), and
`0203_input_output` (renamed from `0206`). The full string methods section
stays in chapter 3 (3.4). Updated the TOC, landing page, Chapter Topics,
planning docs, instructor mappings, and redirects (old section URLs redirect
to the merged pages). Ch 2 assessment alignment was completed on 2026-10-15 (see below).

## Database Appendix Verification (2026-10-15)

The inventory reference passes 19 full checks and 11 core checks, including isolated state, input boundaries, and transaction rollback. The student starter compiles; ten SQL examples and the standalone connection walkthrough execute successfully. File persistence and repeat-run seeding were checked. A full book build succeeds with two existing C# syntax-highlighting warnings in Chapters 2 and 6. Chapter/assignment URL redirects and the 24-chapter sequence were validated.

## Part III Expanded (2026-10-15)

Added Object Design and Composition between Classes and Objects and the revised Inheritance, Interfaces, and Polymorphism chapter. There are now 25 weekly chapters; Semester 1 covers 1-13 and Semester 2 covers 14-25. Operator overloading is an optional appendix. Databases remains an optional three-section appendix. The new chapter and revised OOP chapter include Preview, Lab, and Homework; their three teaching meetings total 110 minutes each. Lecture slides remain pending, and the new composition chapter also needs a video. The former OOP lessons and assignment sources are archived under `materials/stale_chapters/oop_before_design_split/`.

## Part III Verification (2026-10-15)

All 67 new/revised Chapter 12-13 code cells compile independently. Demonstrations and hidden solution cells were executed and their outputs retained. Reference checks pass: 21 for object design and 13 for policy design. The active TOC has 25 sequential numbered chapters, with three core content sections in each Part III chapter. Local document links and demo manifests resolve. Existing cell IDs/metadata were retained in 48 other migrated assessment notebooks. The full build has only the two existing C# highlighting warnings in Chapters 2 and 6; the removed instance-methods anchor is preserved in the composition lesson.

## Teaching Scope Clarification (2026-10-15)

Parts I–III (Chapters 1–13) form a complete CS1 route. Part IV (Chapters 14–21) supplies the CS2 data-structures foundation. Instructors can select Part V (Chapters 22–27) for additional algorithmic depth according to course goals and available time. The book supports COB, IST, IT, IS, and LIS programs as well as other programming-foundations courses; a standalone CS1 course needs no commitment to a second semester. The 27-chapter book structure is broader than required teaching coverage. Prior references to Chapters 14-27 as a second-semester sequence describe available book material, not a requirement to teach Part V.


## 2026-10-15: Flexible Adoption and Expanded Part IV

Part IV now has eight units (14–21), with separate basic searching/sorting, priority queue/heap, and hash/set chapters. Graph traversal has a full meeting and direct assignments. Part V is renumbered 22–27 and remains selectable depth; substantive strengthening is deferred. Instructor routes are recorded in `instructor_support/adoption_routes.md`. Slides and recordings for new/revised units remain pending.

### Verification of the Expanded Foundation

Compiled 175 standalone cells in Chapters 14, 17, 19, 20, and 21; executed demonstrations and hidden solutions with outputs retained. Additional verification covered 103 cells in Classes, Object Design, and Trees; seven unchanged tree exercise starters remain intentionally incomplete. The active TOC lists 27 sequential chapters. Current notebook doc/download links resolve. Full book build passes with the two pre-existing C# lexer warnings in Chapters 2 and 6. Protected runtime/UI work remains untouched. Earlier 25-chapter snapshots above describe the preceding structure and are superseded.

Demo regression also passes: all 33 mapped projects build with warnings treated as errors; 32 console run cases, both four-test MSTest suites, and 3,073 independent demo behavior checks pass. Corrected the linked-source behavior checker from the former `22/search_sort_demo` directory to `24/search_sort_demo`. New search/sort reference checks also verify equal-key stability and a consistent descending comparer.

## Chapter 11 Assignments (2026-10-15)

Replaced the mixed-format Preview with ten vocabulary MCQs. Retained the connected coffee-register lab, clarified its input and rounding contracts, and added a stage-five VS Code starter. Homework now has five applied true/false cases and five transfer coding tasks covering constructors, validation before mutation, calculated properties, static numbering, and object reports. Existing Homework IDs and cell IDs are retained. Book List remains at its published URL as optional collaboration practice after Chapter 12; its legacy solution was not audited.

Verification: all 20 standard assignment code cells compile independently under .NET 10; all ten completed solutions pass with warnings treated as errors and match independently specified expected stdout. Outputs are retained. The stage-five starter builds without warnings. Full book build passes with three existing lexer warnings outside Chapter 11 (Chapters 2 and 6, and the database appendix). Notebook JSON, preserved Lab/Homework cell IDs, radio groups, and starter download links were checked.

## Chapter 2 Assessment Alignment (2026-10-15)

Replaced the mixed Preview with ten vocabulary MCQs and rebuilt Homework as five applied true/false cases plus five standalone coding tasks. The connected office-supply Lab now assesses stored Math.Round results, Math.Ceiling after fractional division, string Trim, numeric Parse, and formatted reports. Rounding, input, and culture assumptions are explicit. Added a stage-five VS Code starter and instructor assessment mapping. Lab IDs, original Homework cell IDs, notebook metadata, and published paths are retained; new Homework exercises use semantic IDs. Core section content is unchanged.

Verification: all 20 Chapter 2 Lab/Homework code cells compile independently under .NET 10. All ten completed solutions pass with warnings treated as errors, match expected stdout, and retain their outputs. Eleven additional boundary/transfer cases pass. The VS Code starter builds with expected unused-variable warnings while unfinished. The full book and final incremental builds succeed; the full build reports three existing C# lexer warnings in unchanged content (Chapters 2 and 6 and the database appendix). All ten outputs are present in built HTML; Preview/Homework radio groups and both starter downloads resolve. JSON, original cell IDs/metadata, and whitespace diffs were checked.

## Ethics Integration and 26-Chapter Structure (2026-10-15)

Implemented the approved Chapter 1 progression and moved setup to Appendix B. Removed the standalone numbered ethics chapter. Former Chapters 8-27 are now 7-26, including chapter folders, notebook prefixes, demo directories, and active links. Earlier dated snapshots below/above describe historical structures and are superseded by the active snapshot. Original assessment/cell metadata and radio identifiers remain stable; optional privacy assessments retain the old ethics work. Published redirects point to the redistributed content, including old setup and ethics pages. Recent Chapter 2 and Classes assignment changes are carried forward.

### Verification of the 26-Chapter Structure

Verified 26 sequential chapter entries and their rendered heading numbers, 250 unique TOC pages, resolving local doc/download links, and all 572 redirect pages and built destinations. The old overview slide deck is copied with the same step used by deployment. The appendix overview is unnumbered, preserving Resources as A, Development Tools as B, and Git as C.

Across 112 pre-existing assessment notebooks, original cell IDs, explicit assignment/exercise identifiers, and radio names are preserved. Chapter 1 Lab/Homework language metadata was corrected to C# for the new runnable cells. Recent Chapter 2 and Classes assignment revisions and outputs remain intact.

Compiled 36 standalone cells across Chapter 1 and the redistributed responsibility/privacy/professional examples, including the SQL string-building demonstration. Executed 25 completed cells and retained stdout; all new Chapter 1 sample outputs match their expected lines. All 33 mapped demo projects plus the behavior-check project build with warnings treated as errors. All 32 console scenarios, both four-test MSTest suites, and 3,073 independent behavior checks pass. The privacy reference and all five renumbered array lab answers pass their saved-output comparisons. MSTest needed local loopback-socket access outside the sandbox.

The clean full-book build passes with the same three C# lexer warnings in unchanged Chapter 2, nullable, and SQLite examples. The final numbering build adds no warnings. Chapter 1's revised recording and slides remain pending; the existing setup video is retained in Appendix B and its prior overview deck URL remains available. Database/AI expansion discussed afterward remains a proposal, not an additional content change.

## Optional Database Capstone and Integrated AI Literacy (2026-10-15)

Confirmed the database appendix as an optional business application capstone after OOP, with existing bookstore assignment ID and workflow unchanged. Chapter 1 now introduces generative AI, LLMs, prompts, limitations, privacy, attribution, and a verification workflow. Methods, testing, and text processing include three prepared AI-review activities with standalone question/solution cells. These supplement or replace comparable practice; no additional numbered chapter is introduced.

Added an optional AI application extension under the Project appendix, with semantic ID `cscs-ai-project-extension`, recorded synthetic responses, isolated components, validation, tests, and review evidence. A live service is optional. No API client or credentials are created. Core projects remain complete without DB or AI extensions, and all review activities are usable without an AI account. Updated project links, planning notes, and adoption guidance. The book remains 26 numbered chapters; the TOC now has 251 pages.

Verification: all seven new AI-review code cells compile independently under .NET 10 with warnings treated as errors. Three hidden solutions and the prepared ordinary-test demonstration retain executed stdout. Independently running the added tests against the original shipping candidate exposes all three intended failures; the repaired reference passes the same checks. All pre-existing assessment identifiers remain intact. Local links resolve for 251 TOC pages, with 26 numbered chapters and the same 572 redirects. Full build succeeds with three existing C# lexer warnings; the final build includes the new outputs and top-level review headings. The optional project extension is a specification with recorded-response requirements, not a live API integration.


## 2026-10-15: Develop the Responsibility Lesson

Expanded 0102 into six explained conceptual topics, approximately 2,900 words including notes and tables, within the existing 35-minute teaching plan. Removed the premature reminder coding task, associated code demonstration, and dependent AI prompt exercise. Added distinctions among implementation correctness, data quality, requirements, fairness, privacy/security, and professional accountability. Retained two conceptual understanding checks with collapsed suggested answers; source notes are referenced inline. No C# examples or submitted tasks are introduced before Section 1.3.

## Seven-Part Organization and Reliability Scope (2026-10-16)

Kept all 26 chapters and their order. Split the former Part IV into Part IV, Data Abstraction and Linear Structures (13-16), and Part V, Trees, Hashing, and Graphs (17-20). Split the former Part V into Part VI, Algorithm Analysis and Design (21-23), and Part VII, Optimization and Computational Limits (24-26). Updated TOC, overviews, front matter, curriculum mappings, adoption routes, and book planning. Earlier dated entries retain historical part names.

Renamed Chapter 6 to Testing, Debugging, and Error Handling while retaining its landing path. Moved the deeper nullability notebook to Chapter 11 as supporting reading, preserving code/cell metadata and redirecting historical URLs. Basic missing-input checks stay early. The plans now sequence diagnostic/output checks (1-2), method tests (3), boundaries/loops (4-5), systematic testing/debugging/error handling (6), file failures/cleanup (9), and object-state/nullability contracts (10-12).

This pass changes structure, orientation, and teaching plans. It does not claim that the planned early practice, Chapter 6 assessment cleanup, or fuller Chapter 11 missing-data exercises have been authored. Existing nullability-specific Chapter 6 assessment items require alignment before the reduced chapter scope is used for teaching. Videos/slides remain pending where previously recorded.

Verification: notebook JSON, seven part sizes, unchanged 1-26 chapter order, TOC targets, redirect destinations/HTML, rendered chapter numbering, and `git diff --check` pass. `.venv/bin/jupyter-book build .` succeeds; the final incremental build retains one C# syntax-highlighting warning for the unchanged `#nullable enable` example. Executable cells in the relocated lesson are byte-for-byte equivalent as JSON objects to their prior versions.

All four relocated nullability code cells also compile and run independently with `dotnet run --project <temporary net10.0 project> -p:NuGetAudit=false`.

## Decisions and Iteration Before Methods (2026-10-16)

Part I now orders Decisions (3), Iteration (4), and Methods (5), with all later chapters unchanged. Chapter folders, notebook prefixes, demo roots, instructor mappings, active references, part/front-matter lists, and TOC order move together. Historical URLs redirect directly to new pages and assessment/cell identifiers remain stable.

The prerequisite audit found helper methods in Decisions lessons/payroll lab, a UI-class Iteration lab, return-based homework, and a function-based grade extension. Revised required lessons/labs/homework to top-level statements, introduced minimal string equality/length/indexing before use, and moved Grade Calculation 2 to Methods. Deeper string operations remain in 5.4. The Iteration lab explains TryParse/out locally and handles input exhaustion without helper methods or string normalization. Corrected the preview loop-variable scope question. Existing legacy assessment formats are retained; full assessment modernization remains separate.

Verification of the control-flow reorder: 53 active Decisions/Iteration code cells compile independently, with completed examples/solutions run and verified outputs retained. The syntax-repair homework starter remains intentionally invalid and labeled. Another 24 runs cover demos, malformed input, EOF, quantity limits, partial-order cancellation, and payroll boundaries; the retained demo behavior harness passes 3,073 checks. Migration checks confirm unchanged notebook/cell metadata and IDs, 26 sequential chapters in seven parts, valid TOC/document targets, and flattened redirects. Chapter 2's void preview now explains a built-in call rather than defining a helper. Existing brief string-member examples in Chapter 2 remain explicit local instruction, so its assignments do not depend on 5.4.

The full HTML build passes after the reorder. Rendered chapter numbers and all migrated redirect pages were checked; the only reported diagnostics are existing C# syntax-highlighting warnings. No deployment or commit was performed.


## Part Heading Color Consistency (2026-10-16)

Part overview titles retain normal heading colors in the sidebar and Contents. Shared navigation supports colon and period caption formats. All seven overviews and 26 chapter numbers pass the navigation HTML build and link checks. This cross-book pass added 28 overviews to the other seven books with named parts; DBS has no named part divisions. No commit or deployment was performed.


## Front Matter Sidebar (2026-10-16)

Simplified sidebar presentation: hide the Front Matter caption, Title Page, and Chapter Topics; preserve existing Contents, Preface, and other introductory links. All source TOCs and front matter content remain unchanged, including Previous/Next reading order and cover/Contents links. Shared assets support underscore and hyphen paths. Part caption links also have a source-TOC fallback for sidebar renderings that omit overview rows.

Verification: browser checks pass across all nine books; all nine navigation HTML builds pass with notebook execution disabled. Front matter destinations and Previous/Next links resolve. No commit or deployment was performed.


## Expanded Collection Foundations (2026-10-16)

Expanded Chapter 8's 0801 from roughly 740 to 4,200 Markdown words, retaining the big-ideas-first sequence before the detailed Lists and Dictionaries sections. It now explains collection operations and contracts, eight introductory families, access patterns, generics and namespaces, traversal, reference sharing, and worked bookstore choices. Added three conceptual checks and a standalone order-summary exercise. Later implementation lessons remain in Chapters 14, 15, 18, and 19. Updated the landing objectives, glossary, Chapter Flow numbering, and chapter planning; the chapter remains three meetings totaling 110 planned minutes.

Verification: all eleven code cells compile independently as .NET 10 console programs with warnings treated as errors. Nine demonstrations and the completed solution match independently specified stdout and retain outputs. Empty, single-item, and repeated-quantity summary cases pass; enabling the commented generic mismatch produces the expected CS0029 diagnostic. Notebook JSON, heading cells/index entries, and footnotes were checked. Rendered layout and exercise reveal were reviewed. The book build passes without warnings for this change. Existing assessment identifiers and the chapter video are unchanged; no aligned Chapter 8 slide deck was found.


## 2026-10-17: Restore Chapter 1–2 explanations and practice

Additively merge the author’s restored CS1 material into the current Press book. Chapter 1 restores conceptual diagrams, number representation, compilation/runtime depth, and program organization; setup and Git remain in the appendices. Chapter 2 restores variable tracing and a linked original-practice page covering division/mixed fractions, format reading, Mad Lib, and Unix timestamps. Keep all newer lessons and current standard assignments. Verification and build results are recorded in chapter MATERIALS.md.

## CS1 Content Restoration (2026-10-17)

Restored the audited missing Decisions/Iteration/Methods/Arrays/Files/Classes exercises, full GCD development, file-driven response lab with downloadable starter, full unit-testing walkthrough, and Shell-sort/Quicksort/search-timing extensions. Current lessons, labs, additions, chapter sequence, assessment IDs, and appendix setup/Git placement are retained. Method/string extensions follow Methods; collections/file integration follows Files; advanced algorithms follow their current prerequisites. The independent thinkcscs.org While Loop Review recovery is maintained in its own repository. Verification details are recorded in `authoring/RESTORATION_2026_10_17.md`.

## CS1 Preservation Follow-up (2026-10-17)

Closed all 15 items from the second audit, including small variants. Added original conceptual reviews, expression/cast drills, full return-fragment sets, the three-function Strange Sequence decomposition, complete Example/Averager development, old Classes/OOP review tasks, params, sealed override and original OOP variations, Congress classification, Unicode traversal, alternate Shell gaps and the UI helper import workflow. Repaired the incomplete Press while-review prompt. Current notebook cells, assignment IDs, additions and chapter order are retained. Supporting reading adds no required meetings. See `authoring/CS1_PRESERVATION_MATRIX.json` and `authoring/CS1_PRESERVATION_CHECK.md` for source mappings and verification.

### 2026-10-17: Chapter 11 struct and record introduction

Added value-copying and record-equality instruction within 1101 before the supporting nullability record example. Covers default structs, readonly, positional properties/init, with, record structs, shallow sharing cautions, and type selection. Preserves the current chapter organization and existing examples.

### 2026-10-17: One-line primary navigation

Added navigation-only short labels for long chapter, section, assignment, and appendix entries. Full page titles remain unchanged; full navigation titles are retained in tooltips and accessible names. Primary links use a one-line ellipsis fallback and no hover underline. Verified desktop and 390px mobile drawer rendering. Shared book-authoring rule now explicitly covers all nested navigation entries.

### 2026-10-17: Appendix C Git quick reference

Redrew the supplied @PythonPr Git reference as figures/git_cheat_sheet.svg, with all eight command groups, corrected restore/unstage and pull descriptions, history-rewrite and destructive-command markers, and an accessible searchable text version in Appendix C. Official Git documentation is cited in the footnote. Checked artwork rendering and verified restore/unstage, commit -am, and clean preview behavior in an isolated temporary repository. Existing appendix content is retained.

### 2026-10-17: Arrays belong to the collection families

Made the array/collection relationship explicit in Chapters 7 and 8 landing pages and opening lessons, with reciprocal links. Preserved chapter organization and all code/assignments. Corrected the Chapter 7 flow labels from 8.1/8.2 to 7.1/7.2.

### 2026-10-17: Collection operation connections and general syntax

Added an operations comparison in 0801 before selection/examples, with general syntax and explicit semantic differences. Preserved existing runnable examples and assignments. Shared authoring guidance now calls for syntax scaffolds and cross-concept connections.

### 2026-10-17: Book-wide link decoration

Removed remaining hover/focus underlines from body links, Previous/Next title elements, part links, and account text controls. Preserved keyboard focus with outlines and added subtle text-link hover backgrounds. Browser verification on the Arrays page found no underlined links or Previous/Next titles; hover rules explicitly suppress underline. Shared B-A and Press UI specification updated for all books; this local CSCS styling has not yet been deployed.

### 2026-10-17: Chapter 8 framework improvement

Improved conceptual framing, syntax scaffolds, worked output/interpretation, variations, guided practice, and independent transfer while retaining the section order and original material. Added three purposeful SVG diagrams, list/dictionary traces, repaired preview/homework defects, and retained five connected lab tasks with boundary checks. Added executable word-counter source/downloads. Full verification and preservation details are recorded in the chapter's authoring review.

### 2026-10-17: Chapter 5 coverage and teaching development

Implemented the five-section coverage plan with contracts, call/return flow,
parameter copying and scope, decisions/loops in helpers, strings, refactoring,
and repeatable checks. Relocated lab explanations into lessons while preserving
application tasks and all original exercise variants. Added four SVG diagrams,
comparison/trace tables, guided starters and revealed solutions. Preserved the
original class-based programs as reading references and repaired runnable forms.
See `authoring/CH05_FRAMEWORK_REVIEW.md` for validation and remaining limits.

### 2026-10-17: Section reorganization and content development

Implemented the 26-chapter section-boundary plan. Published content readings
change from 88 to 93, including supporting readings; the chapter sequence is
unchanged. Added topic-specific explanations, worked traces/tables, common
mistakes and guided variations in 54 readings. Preserved all 2,425 original
nonempty lesson cells and 554 original lesson code cells under the documented
heading, reference and footnote normalization. Assignment content, code, IDs and
outputs remain, with corrected section references in the Methods lab.

Updated planning inventories, landing flows, Chapter Topics, concise sidebar
labels, five combined-page redirects and 120 moved-heading/label routes. Six
new runnable examples compile/run independently with expected output. The
verification report distinguishes these checks from historical checks on
retained examples. See `authoring/section_revision/README.md`. No deployment.

### 2026-10-17: Priority-section B-A development

Developed 15 priority readings across 10 chapters following the count review:
small worked algorithm cores, output interpretation, purposeful state/decision
traces, guided completion and boundary variations before independent transfer.
Retained the section order and every assignment notebook. Updated both chapter
planning files with current coverage and teaching progression. Preserved 414
original cells and all 45 original code cells; eight documented Markdown repairs
correct array presentation/syntax/results or stale references. Added 22 examples
that independently compile/run with expected output. See
`authoring/priority_development/README.md` and its full source differences.
Local development, not deployed.

### 2026-10-17: Integration cleanup and prerequisite placement

Consolidated duplicate local contents directives, removed obsolete wrapper
headings while preserving anchors, distinguished repeated practice headings,
replaced move-provenance notices with instructional transitions, and placed
instructional text before final Footnotes. Preserved all recent development.

Chapter 2 now develops type foundations before conversion applications; the
input-casting examples are with conversion, and the complete loop-generated
formatting/table examples are in Chapter 4 after loop instruction. Chapter 16
keeps search preparation as a short bridge and teaches every reporting snapshot
and preparation/update workload beside sorting. The Chapter 26 graph objective
counterexample is in Chapter 24; traversal-verification contracts close Chapter
20's DFS/components reading. Chapter 26 now has three core string/limits
readings, with matching landing objectives, glossary and Chapter Flow. Its
existing video is retained as graph-prerequisite review.

Updated 42 chapter planning files, the book plan, supporting-reading TOC labels,
Chapter Topics and compatibility routes. Current active readings: 92. The
integration preservation ledger accounts for 3,917 original cells, consolidating
68 empty/navigation/rubric cells while retaining all 582 executable cells and
124 assignment notebooks. Earlier baselines remain available and are checked
through exact cell/source lineage. See `authoring/integration_cleanup/` for
current verification and complete source differences. Local work, not deployed.

## Subject index cleanup (2026-10-17)

Excluded 80 numbered task titles from generated subject entries without changing
notebooks or anchors. Filed one-dimensional arrays under array and separated
the combined .NET entry. Full build passed with the existing Chapter 2 lexing
warning; all 2,039 local index links resolve and all 277 notebooks are unchanged.
Evidence: `authoring/index_cleanup/`. Local work, not deployed.

## Whole-index parser and editorial cleanup (2026-10-17)

Reviewed all alphabetical groups. Preserve commas within index phrases rather
than splitting headings into fragments such as “and Comments.” Exclude generic
navigation entries, merge case variants, expand long subentry lists and repair
repeated words/markup/placeholders. Notebook text and anchors remain intact.
See `authoring/index_cleanup/editorial_review.html` and verification evidence.
Local work, not deployed.

## Full subject-index revision (2026-10-17)

Resolved the complete 1,435-entry audit using a reviewed source-to-subject map.
Replaced teaching-heading entries with concept names; corrected API ownership,
LIFO/FIFO groupings and unrelated keyword hierarchies; consolidated variants;
added 41 direct entries and 42 explicit cross-references. Conservative grouping
flags were checked against their passages and retained where appropriate.

All 1,920 original indexed locations are accounted for in the mapping. The
rendered index matches every retained mapped passage and addition; duplicate
pointers within a passage are collapsed. All 341 tracked notebooks are unchanged;
276 existing baseline notebooks are byte-identical, with one absent ignored checkpoint recorded separately.
Full build passes with the existing Chapter 2 character-literal lexing warning.
See `authoring/index_revision/` and the local `index_revision_review.html` for
complete evidence and before/after mappings. Local changes, not deployed.
