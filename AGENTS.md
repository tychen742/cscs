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
- Each chapter has `assignments/` subfolder with `index`, `preview`, `lab`, `review` notebooks
- Chapter sequence is ch01–ch15; project instructions live in `chapters/appendices/`
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

Every content section (not preview, lab, or review) must end with a Footnotes block:

````markdown
```{rubric} Footnotes
```
[^1]: …
[^2]: …
````

Footnote cells must be independent markdown cells.

## Assignments (per chapter)

Each chapter must have three assignment notebooks in this order:

| Type | File pattern | Specs |
| ---- | ----------- | ----- |
| Preview quiz | `NN0X-preview` | 5–10 conceptual questions from the content sections |
| Lab | `NN0X-lab` | ~5 connected technical questions on one theme; each question builds on previous output |
| Review (homework) | `NN0X-review` | 5–10 questions; majority are coding practice directly on the chapter's topics |

Labs should eventually evolve into full project solutions that students can demonstrate on GitHub.

## Working Rules

- Verify C# examples compile and run
- Always show diffs when proposing changes to existing content
- When evaluating a chapter: are essential topics covered? Are sections organized soundly?

## Semester Constraints

<!-- Update each semester: list what is and is not in scope for modification -->
