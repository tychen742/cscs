# Chapter Materials — Variables and Data Types

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `0201_variables_types.ipynb` | Variables, Assignment, and State | Core content |
| `0204_types_conversion.ipynb` | Types and Conversion | Core content |
| `0202_operators_built_in_methods.ipynb` | Operators and Built-In Methods | Core content |
| `0203_input_output.ipynb` | Input and Output | Core content |

Four readings remain: variables/state, types/conversion, operators/library calls, then console I/O. Teach types and conversion before the developed division/display cases. All input-casting examples now reside with conversion. Chapter 2 retains single-value output/composite/interpolation explanations; loop-generated report tables and their exercise variants are in 0402, after loop syntax.

No assessment identity, assignment notebook, worked code, output or exercise variant is removed. `authoring/integration_cleanup/` records the original cells, exact edits, moves and URL/fragment compatibility.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Landing Page

- `0200_variables_types.ipynb` — Chapter landing page

## Section Notebooks

- `0201_variables_types.ipynb` — Variables, assignment, state and identifiers
- `0204_types_conversion.ipynb` — Type foundations, conversion, input-casting examples and worked conversion/display reasoning
- `0202_operators_built_in_methods.ipynb` — Operators and expressions, then built-in methods: method calls, `Math`, `Parse`, a first look at string methods (full treatment in 5.4)
- `0203_input_output.ipynb` — Console input and output (renamed from 0206)

## Assignments

- `assignments/index.ipynb` — Index
- `assignments/lab.ipynb` — Lab
- `assignments/preview.ipynb` — Preview
- `assignments/homework.ipynb` — Homework

## Notes

- Source examples live in `demos/` at the project root.

## Runnable Demo Projects

- [`demos/02/input/`](../../demos/02/input/README.md): Console input, parsing, and range validation.
- [`demos/02/output/`](../../demos/02/output/README.md): Interview appointment output.

All demo projects target .NET 10. Run commands and verification are documented
in `demos/README.md` and each project README.

## Assessment Alignment (2026-10-15)

- Preview: ten core vocabulary MCQs covering variables, initialization, literals, Boolean values, expressions, arguments, return values, parsing, casts, and formatted output.
- Lab: five connected office-supply stages, preserving the existing cells and IDs. Adds Math.Round return values, Math.Ceiling with conversion before division, and a final three-line input invoice using Trim and Parse. Monetary rounding policies and valid-input assumptions are explicit.
- Homework: five workplace true/false cases and five standalone coding tasks. Tasks assess Math.Max with logical expressions, fractional versus integer division, string return values and Length, three parsed expenses, and Math.Round/Math.Abs in a budget report.
- VS Code starter: `demos/02/order_invoice_starter/`, matching lab stage five. Canonical solutions remain in notebook hide-input cells with executed stdout retained.
- Instructor guidance: `instructor_support/labs/02_assessment_alignment.md`.

These assessments require only sequential code and library calls. User-defined methods, classes, loops, and exception handling are not required. Existing published paths and Lab cell IDs remain unchanged. New Homework exercise IDs use the semantic `cscs-variables-types-homework-coding-*` prefix; existing notebook metadata is retained.

## Keyword Placement (2026-10-15)

The basic reserved-keyword explanation and collapsed list live in Section 1.3. Section 2.1 retains a linked optional note on escaped identifiers and contextual keywords, with a standalone shipment example using meaningful `itemCount` instead of `var var`. The existing `keywords-section` anchor remains in 2.1.


## Restored CS1 Teaching Content (2026-10-17)

Author-requested additive merge from the standalone restored CS1 reference. Existing lessons, responsibility/AI material, assignments, and assessment IDs remain. Setup and Git stay in Appendices B and C. Restored concepts are reading and practice within the current three-section sequence, not extra required meetings.

Section 2.1 adds the original step-by-step variable state table and independently runnable trace. assignments/additional_practice.ipynb restores UpdateVars/MathFun prediction and state tracing, MathDivision mixed-fraction output, the composite-formatting follow-up, format-reading puzzles, Mad Lib, and live/fixed Unix-time operator practice. This page is linked from the current Lab; it supplements the five-stage office-supply lab rather than replacing its submission requirements. Valid-input assumptions are explicit. The live-clock demonstration is distinguished from reproducible fixed-timestamp predictions. Existing lab/preview/homework questions and identifiers are preserved.

Verification: all 13 restored code cells compiled independently as .NET 10 console programs with nullable checks and warnings treated as errors; completed cells retain executed output. Checked alternative trace inputs, zero/exact/proper-fraction division cases, and timestamp second/parity boundaries against independent arithmetic/date calculations. The eight template/solution/project commands were verified in a temporary workspace. Full Jupyter Book build passes with existing lexer warnings in the unchanged character/nullability examples. All original Chapter 1–2 cells, code, outputs, and standard-assignment IDs remain.

## CS1 Preservation Follow-up (2026-10-17)

Original mixed-expression legality, necessary/redundant casts, one-call multiline output, add3 and quotient-sentence review variations restored in Extra Practice. The UI helper source-import workflow is restored in 2.3 with namespaced client and downloadable demonstration (`demos/02/ui_helper.zip`). Setup and Git remain in appendices.

## Section-Boundary Coverage Disposition (2026-10-17)

**Reviewed plan, now implemented:** Split Variables and Types. The disposition below records the preimplementation baseline and rationale. See Implemented Reading Organization for the current reading files. Counts in this baseline exclude fenced code from prose; the refreshed inventory is in authoring/content_size/. They flag review needs, not quality scores.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `0201_variables_types.ipynb`: Variables and Types | Core content | 3,753 | 58 | 30 |
| `0202_operators_built_in_methods.ipynb`: Operators and Built-In Methods | Core content | 1,858 | 40 | 18 |
| `0203_input_output.ipynb`: Input and Output | Core content | 2,021 | 40 | 24 |

### Source-to-Destination Plan

| Existing source | Proposed treatment and coverage to preserve |
| --- | --- |
| `0201` | Split at Types: declarations, var, assignment/state trace, identifiers and literals form the first page; types, concrete type examples and conversion form the second. Keep contextual-keyword, hierarchy and unmanaged-type passages as labeled reference material. |
| `0202` | Retain operators and built-in calls; use type/conversion prerequisites from the preceding page. Keep bitwise detail as a bounded extension. |
| `0203` | Retain input/output; consolidate repeated formatting headings internally and label the supplied UI-class workflow and loop-based table output as later supporting applications. |

### Development Needed Before Moving Material

Develop type selection and numeric conversion through worked decisions, not only a hierarchy/table. Each resulting page needs a coherent problem and guided application before any physical split.

Before a later move, create a cell-level preservation map for these sources, including citations, figures, original code forms, worked traces, guided questions and independent exercise variants. Relocate prerequisite explanations from assignments into content when needed while retaining application requirements and IDs. A consolidated page must still teach its concepts; a split must not create two unsupported outlines. Existing runnable verification records describe earlier work, not verification of this proposal.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `0201_variables_types.ipynb`: Variables, Assignment, and State.
- `0204_types_conversion.ipynb`: Types and Conversion.
- `0202_operators_built_in_methods.ipynb`: Operators and Built-In Methods.
- `0203_input_output.ipynb`: Input and Output.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.
