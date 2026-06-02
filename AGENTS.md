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

## Read First

1. `authoring/BOOK_PLAN.md` for audience, scope, and chapter sequence
2. `authoring/PROGRESS.md` for chapter status before touching any chapter
3. `_toc.yml` for the current notebook order
4. The target chapter's `MATERIALS.md` and `ORGANIZATION.md` before editing that chapter

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
|------|-------------|-------|
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
