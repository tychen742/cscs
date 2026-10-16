# AGENTS.md — Introduction to CS in C\#

## Base

Skill: `book-authoring` (from ai_shared)
Style: `guidelines/STYLE_GUIDE.md` in ai_shared

Read `~/ai_shared/skills/book-authoring/SKILL.md` for all pedagogy, structure, and Jupyter Book conventions. This file records only overrides and project-specific context.

## Project Context

- College-level introductory to intermediat C# programming and computer science textbook (CSCS course)
- Audience: students new to or early in programming; no prior experience assumed
- Inspired by introcs.cs.luc.edu — aims to be a better-structured open alternative
- This book is about CS and IT, not just programming syntax — conceptual parts are important
- As a context, use management and business examples.
- Published as a Jupyter Book
- All code cells are runnable through Docker instance.
- 

## Memory

Read `~/workspace/ai_shared/memory/MEMORY.md` for persistent context about this project and the user. Write all new memories there — not here, not in `.claude/`.

## Read First

1. `~/workspace/ai_shared/memory/MEMORY.md` for prior decisions and context
2. `authoring/BOOK_PLAN.md` for audience, scope, and chapter sequence
3. `authoring/PROGRESS.md` for chapter status before touching any chapter
3. `_toc.yml` for the current notebook order
5. The target chapter's `MATERIALS.md` and `ORGANIZATION.md` before editing that chapter

## Structure Decisions (as of 2026-06-06)

- Notebooks use the `csharp` kernel; named `XXYY_slug.ipynb` (`XX00` = landing, `XX01`–`XX03` = content sections)
- Preferred 3 content section notebooks per chapter (one per class meeting)
- Source `.cs` files and projects live in `demos/NN/` at project root — not in `chapters/`
- Each chapter has an `assignments/` subfolder. The standard student-facing
  assignments are `index`, `preview`, `lab`, and `homework`; projects are added
  when the chapter needs a durable VS Code deliverable.
- Chapter sequence is ch01-ch26. Ethics is integrated into Chapter 1; tooling setup lives in Appendix B. Project instructions live in `chapters/appendices/`.
- Front matter (2026-10-04): `index.ipynb` at the project root is the cover and TOC root (served at `/`; moved from `chapters/cover.ipynb` 2026-10-05) (cover art at `figures/cover-art.svg`, placeholder until supplied), then the front matter in `chapters/front_matter/` (2026-10-05): Title Page (`title_page.ipynb`), Contents (`contents.ipynb`, formerly `chapters/home.ipynb`), Chapter Topics (`chapter_topics.ipynb`, its own page since 2026-10-05), and Preface (`preface.ipynb`)
- Appendices: `resources.ipynb`, `command_line.ipynb`, `project.ipynb`, `cs2023_alignment.ipynb`
- Root `figures/` for images (never `images/`); root `assignments/` for assessment materials; root `instructor_support/` for instructor walkthroughs, solution guidance, resource mappings, and future teaching support
- Use `scripts/scaffold-book.py` in `ai_shared` to generate chapter scaffolding

## Chapter Organization

- Each chapter covers one week's worth of student work and lecture
- Content sections should total 100–120 minutes of lecturing at regular speed
- `NN01-*.ipynb` covers the major and overall concepts of the chapter
- `NN02+` files are sections each with their own focused topic
- Every content section should include code examples where possible

## Notebook Formatting

- Each `##` and `###` heading must be in its own separate markdown cell with one blank line after the heading
- Every `##` and `###` header should include a Sphinx index entry
- Use index and label anchors liberally — they aid navigation and cross-referencing

### Footnotes

Every content section (not preview, lab, homework, or project assignments) must end with a Footnotes block:

````markdown
```{rubric} Footnotes
```
[^1]: …
[^2]: …
````

Footnote cells must be independent markdown cells.

## Assignments

Each chapter should normally include these student-facing assignments in this order:

| Type         | File pattern      | Specs                                                                           |
| ------------ | ----------------- | ------------------------------------------------------------------------------- |
| Preview quiz | `NN0X-preview`  | Multiple-choice questions from the content sections                             |
| Lab          | `NN0X-lab`      | Connected coding practice on one theme; each question builds on previous output |
| Homework     | `NN0X-homework` | Five true/false questions and five coding questions                             |

Projects are separate optional assignment tracks, not required for every
chapter:

| Type    | File pattern     | Specs                                                                             |
| ------- | ---------------- | --------------------------------------------------------------------------------- |
| Project | `NN0X-project` | A cumulative deliverable that applies the chapter's concepts in a VS Code project |

The project notebook should connect the chapter to the semester project or a
standalone project milestone. It should include the goal, starter-project
link, expected files, run/test commands, deliverable, and submission method.
Projects should be submitted from VS Code/GitHub rather than as browser drafts.

Post-class reinforcement uses `homework.ipynb`.

## Working Rules

- Verify C# examples compile and run
- Every browser-runnable code cell must be executable from the beginning of the cell. Include required variable declarations, collection setup, and imports in the cell itself; do not require students to run a previous cell to create hidden state.
- If a lesson intentionally teaches state across multiple cells, label the cells as a sequence and provide a standalone reset/setup cell.
- Always show diffs when proposing changes to existing content
- When evaluating a chapter: are essential topics covered? Are sections organized soundly?

## Deployment

- Deploy by committing changes and pushing to `main`; `.github/workflows/deploy.yml` builds and publishes through GitHub Actions.
- Check the workflow result before considering a fallback. A queued or running workflow is not a failure.
- Keep `./deploy` as a backup route only. Use direct upload only when the GitHub Actions deployment fails or is unavailable, after investigating the problem. Do not use it for routine deployment or alongside a working workflow.

## Audit Workflow

When auditing the book or a chapter, follow the `book-authoring` skill's
"Auditing a Book" section. Start with `AGENTS.md`, `authoring/BOOK_PLAN.md`,
`authoring/PROGRESS.md`, and `_toc.yml`, then compare the target chapter's
`MATERIALS.md`, `ORGANIZATION.md`, landing page, content notebooks, assignments,
slides, runnable code, and build output. Report findings before editing unless
the user explicitly asks for a fix pass.

## Semester Constraints

<!-- Update each semester: list what is and is not in scope for modification -->

## Universal Press Naming

Follow the shared `book-authoring` skill for all book-owned file and folder names: lowercase `snake_case`, chapter folders `NN_chapter_name`, notebooks `NNSS_section_name.ipynb`, `front_matter`, and descriptive appendix paths without letter prefixes (letters are assigned for display from TOC order). Existing paths require coordinated migration with TOC/link updates and published-URL redirects; retain semester constraints.

## Part Overview Pages (2026-10-10)

Each part in `_toc.yml` begins with an unnumbered overview page in `chapters/parts/part_NN_slug.ipynb`. The `appendix_numbering` extension skips these so chapter numbers do not shift. Update them when a part's chapters change.

## Resource Directory Override (2026-10-10)

At the user's request, CSCS uses root `demos/NN/` for C# examples and supporting
source, root `instructor_support/` for teaching guides and solution guidance,
and root `scripts/` for active Python utilities. This overrides the shared
book-authoring `materials/NN/` directory name for this book. Root `materials/` holds
retired or unpublished chapter drafts (`materials/stale_chapters/`), not runnable examples. Keep exercise
projects labeled by their mapped role; a demo is not automatically a lab key.

## Current Structure (2026-10-15)

Chapter 1 is Computing, Programs, and Responsibility, with three sections: Computing and Problem Solving, Computing and Professional Responsibility, and Your First C# Program. SDK/editor installation, terminal/workspace setup, CSharpRepl, and ecosystem reference live in Appendix B. Keep the first edit/build/run workflow in Chapter 1. Git and detailed professional practice live in Appendix C.

The appendix overview is unnumbered, so Resources remains Appendix A, Development Tools Appendix B, and Git Appendix C.

The standalone ethics chapter is removed. Former Chapters 8-27 are Chapters 7-26. Preserve assessment IDs independently of numbering. Optional software-failure cases are in Chapter 6; optional privacy/security coding and retained legacy privacy assessments are in Chapter 9. Do not turn those optional pages into additional required meetings.

Part III contains Chapter 10 Classes and Objects, Chapter 11 Object Design and Composition, and Chapter 12 Inheritance, Interfaces, and Polymorphism. Databases and operator overloading remain optional appendices after OOP.

Parts I-III (Chapters 1-12) form a complete CS1 route. Parts IV-V (Chapters 13-20) supply the CS2 foundation. Parts VI-VII (Chapters 21-26) supply selectable algorithmic depth. The text supports COB, IST, IT, IS, and LIS programs and other programming-foundations courses. Do not present all 26 chapters as required teaching weeks. Preserve existing assignment/exercise IDs and published URL redirects through all path migrations.

## Database and AI Teaching Scope (2026-10-15)

Keep the database appendix as an optional post-OOP business application capstone, not a required numbered chapter. The existing bookstore core and transaction extension remain available. Do not make every business example database-backed.

Teach AI literacy within Chapter 1 and selected AI-review activities in methods, testing, and text processing. Prepared candidates allow all students to participate without paid AI access; live use follows course policy. Require independent understanding and verification evidence. AI-powered applications belong to a separate optional project extension after OOP, with recorded synthetic responses for reproducible offline demonstrations. Core exercises and projects must not require a live AI service.

## Seven-Part Organization and Reliability Progression (2026-10-16)

Keep the existing 26-chapter order. Part IV is Data Abstraction and Linear Structures (13-16); Part V is Trees, Hashing, and Graphs (17-20); Part VI is Algorithm Analysis and Design (21-23); Part VII is Optimization and Computational Limits (24-26). Introductory analysis stays in Chapter 13 and introductory recursion in Chapter 17.

Chapter 6 is Testing, Debugging, and Error Handling. Introduce expected-result checks and diagnostics in Chapters 1-2, repeatable method tests in Chapter 5, and boundary/iteration checks in Chapters 3-4. Chapter 6 consolidates these habits and basic exception handling. Revisit file failures and cleanup in Chapter 9. Keep basic null checks early, but teach deeper nullable types, flow warnings, object contracts, and null operators with Chapter 11's object references/composition. The relocated nullability page is supporting reading within three meetings. Preserve Chapter 6's landing URL and all assessment IDs.

## Part Overview Navigation (2026-10-16)

The Part title itself links to its overview in the sidebar and Contents page. Do not display a separate Part Overview row or Part overview link beside that title. Keep overview pages in `_toc.yml` for reading order and numbering; `_static/part_overview_links.js` moves each sidebar overview link into its caption.

## Part I Order (2026-10-16)

Chapters 3-5 are Decisions, Iteration, then Methods. Keep built-in calls in Chapter 2. Use top-level statements in Decisions/Iteration and their required assignments; do not require user-defined methods before Chapter 5. Teach minimal string equality/length/indexing locally, with full string methods in 5.4. The optional function-based Grade Calculation 2 assignment belongs in Chapter 5. Preserve assessment IDs and old-URL redirects.
