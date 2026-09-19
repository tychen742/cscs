# AGENTS.md — Introduction to CS in C\#

## Base

Skill: `book-authoring` (from ai_shared)
Style: `guidelines/STYLE_GUIDE.md` in ai_shared

Read `~/ai_shared/skills/book-authoring/SKILL.md` for all pedagogy, structure, and Jupyter Book conventions. This file records only overrides and project-specific context.

## Project Context

- College-level introductory C# programming and computer science textbook (CSCS course)
- Audience: students new to or early in programming; no prior experience assumed
- Inspired by introcs.cs.luc.edu — aims to be a better-structured open alternative
- This book is about CS and IT, not just programming syntax — conceptual parts are important
- Published as a Jupyter Book

## Memory

Read `~/workspace/ai_shared/memory/MEMORY.md` for persistent context about this project and the user. Write all new memories there — not here, not in `.claude/`.

## Read First

1. `~/workspace/ai_shared/memory/MEMORY.md` for prior decisions and context
2. `authoring/BOOK_PLAN.md` for audience, scope, and chapter sequence
3. `authoring/PROGRESS.md` for chapter status before touching any chapter
4. `_toc.yml` for the current notebook order
5. The target chapter's `MATERIALS.md` and `ORGANIZATION.md` before editing that chapter

## Structure Decisions (as of 2026-06-06)

- Notebooks use the `csharp` kernel; named `XXYY-slug.ipynb` (`XX00` = landing, `XX01`–`XX03` = content sections)
- Preferred 3 content section notebooks per chapter (one per class meeting)
- Source `.cs` files and projects live in `materials/NN/` at project root — not in `chapters/`
- Each chapter has an `assignments/` subfolder. The standard student-facing
  assignments are `index`, `preview`, `lab`, and `homework`; projects are added
  when the chapter needs a durable VS Code deliverable.
- Chapter sequence is ch01–ch16; project instructions live in `chapters/appendices/`
- Appendices: `resources.ipynb`, `command-line.ipynb`, `project.ipynb`, `cs-index.ipynb`
- Root `figures/` for images (never `images/`); root `assignments/` for instructor-facing materials
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

| Type | File pattern | Specs |
| ---- | ----------- | ----- |
| Preview quiz | `NN0X-preview` | Multiple-choice questions from the content sections |
| Lab | `NN0X-lab` | Connected coding practice on one theme; each question builds on previous output |
| Homework | `NN0X-homework` | Five true/false questions and five coding questions |

Projects are separate optional assignment tracks, not required for every
chapter:

| Type | File pattern | Specs |
| ---- | ----------- | ----- |
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

## Audit Workflow

When auditing the book or a chapter, follow the `book-authoring` skill's
"Auditing a Book" section. Start with `AGENTS.md`, `authoring/BOOK_PLAN.md`,
`authoring/PROGRESS.md`, and `_toc.yml`, then compare the target chapter's
`MATERIALS.md`, `ORGANIZATION.md`, landing page, content notebooks, assignments,
slides, runnable code, and build output. Report findings before editing unless
the user explicitly asks for a fix pass.

## Semester Constraints

<!-- Update each semester: list what is and is not in scope for modification -->
