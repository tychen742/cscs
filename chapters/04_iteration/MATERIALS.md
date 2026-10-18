# Chapter Materials — Iteration

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `0401_iteration.ipynb` | Iteration | Core content |
| `0402_for_statements.ipynb` | The `for` Statement | Core content |
| `0403_while_statement.ipynb` | While-Statements | Core content |
| `0404_gcd.ipynb` | Greatest Common Divisor | Supporting reading |

0402 now includes every loop-generated output/table example formerly in Chapter 2, after the for/foreach foundations. Field widths, headings, power-table output and all code variants are retained. Chapter 2 links forward rather than requiring loops early. The infinite-loop discussion is before final Footnotes, and do-while headings distinguish overview from syntax/tracing.

No assessment identity, assignment notebook, worked code, output or exercise variant is removed. `authoring/integration_cleanup/` records the original cells, exact edits, moves and URL/fragment compatibility.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Landing Page

- `0400_iteration.ipynb` — Chapter landing page

## Section Notebooks

- `0401_iteration.ipynb` — Introduction to iteration
- `0402_for_statements.ipynb` — for loops
- `0403_while_statement.ipynb` — while loops

## Assignments

- `assignments/homework_gradecalculation.ipynb` — Homework Gradecalculation
- `assignments/index.ipynb` — Index
- `assignments/lab.ipynb` — Lab
- `assignments/preview.ipynb` — Preview
- `assignments/homework.ipynb` — Homework

## Notes

- Source examples live in `demos/` at the project root.

## Runnable Demo Projects

- [`demos/04/for_loop_demo/`](../../demos/04/for_loop_demo/README.md): For loops and string helpers.
- [`demos/04/while_loop_demo/`](../../demos/04/while_loop_demo/README.md): While loops and a number guessing game.

All demo projects target .NET 10. Run commands and verification are documented
in `demos/README.md` and each project README.

## Prerequisite Alignment (2026-10-16)

Now Chapter 4, after Decisions and before Methods. Active examples use top-level loops; return-based exercises now use loop variables and printed results. Introduce string Length, zero-based indexing, empty-string bounds, and foreach locally in 4.2 before 4.3 uses them. No arrays or later string methods are required for those examples.

The order-entry lab keeps five connected tasks but uses inline validation loops instead of a UI class. Explain TryParse/out as a built-in call, handle exhausted input, and accept exact lowercase y/n without Trim/ToLower. Required homework uses top-level programs and break/continue rather than method returns. The first Grade Calculation stays here; the function-based second assignment moves to Chapter 5. Library calls remain allowed; defining methods and classes is deferred. Existing assessment/cell IDs are preserved.

## Restored CS1 Material (2026-10-17)

- `assignments/additional_practice.ipynb`: restored explanations and exercises; retains current lessons and assignment IDs.
- `0404_gcd.ipynb`: restored explanations and exercises; retains current lessons and assignment IDs.

GCD remains supporting reading; required loop programs use top-level statements. Returning/string-cleaning and multi-method extensions are in Methods practice.

## CS1 Preservation Follow-up (2026-10-17)

Original ABCabc character-code indexed/foreach illustration restored. The incomplete final Additional Iteration Homework question now includes the standalone review’s decrementing-loop program and zero-start follow-up.

## Section-Boundary Coverage Disposition (2026-10-17)

**Reviewed plan, now implemented:** Retain three core lessons and GCD support. The disposition below records the preimplementation baseline and rationale. See Implemented Reading Organization for the current reading files. Counts in this baseline exclude fenced code from prose; the refreshed inventory is in authoring/content_size/. They flag review needs, not quality scores.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `0401_iteration.ipynb`: Iteration | Core content | 963 | 10 | 5 |
| `0402_for_statements.ipynb`: The `for` Statement | Core content | 1,427 | 30 | 9 |
| `0403_while_statement.ipynb`: While-Statements | Core content | 1,581 | 36 | 8 |
| `0404_gcd.ipynb`: Greatest Common Divisor | Supporting reading | 2,166 | 19 | 1 |

### Source-to-Destination Plan

| Existing source | Proposed treatment and coverage to preserve |
| --- | --- |
| `0401` | Retain a conceptual first section; introduce termination and zero/one/many iteration reasoning before syntax comparisons. |
| `0402` | Retain for/nested-for/foreach comparison with locally introduced string indexing. |
| `0403` | Keep while/do-while and input/termination together; organize duplicated do-while titles and label the investment/Strange Sequence/roundoff examples as applied cases. |
| `0404` | Keep the full GCD lesson, all algorithm variants and recursive preview as supporting reading. Do not use the shorter GCD example as a replacement. |

### Development Needed Before Moving Material

Develop loop selection and invariant/state traces; distinguish required fundamentals from optional mathematical cases. No new page is needed simply to meet a three-meeting template.

Before a later move, create a cell-level preservation map for these sources, including citations, figures, original code forms, worked traces, guided questions and independent exercise variants. Relocate prerequisite explanations from assignments into content when needed while retaining application requirements and IDs. A consolidated page must still teach its concepts; a split must not create two unsupported outlines. Existing runnable verification records describe earlier work, not verification of this proposal.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `0401_iteration.ipynb`: Iteration.
- `0402_for_statements.ipynb`: The `for` Statement.
- `0403_while_statement.ipynb`: While-Statements.
- `0404_gcd.ipynb`: Greatest Common Divisor.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.
