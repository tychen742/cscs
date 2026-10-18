# Chapter Organization — Decision Structures

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `0301_intro_decision.ipynb` | Boolean Expressions & Logical Operators | Core content |
| `0302_ifstatement.ipynb` | Conditional Selection with if and switch | Core content |

Keep the current section boundaries and recently developed content. Consolidate repeated in-page navigation, distinguish repeated practice headings, retain all substantive explanations/examples and finish the instructional material before the final Footnotes group.

Teach the section conceptual framework before detailed application; place syntax prerequisites before reasoning that requires them. Keep the new worked traces and guided checkpoints, followed by existing lab/homework transfer. Reading count does not set a meeting or word quota.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Learning Objectives

<!-- List 3–5 measurable student outcomes -->

## Sequence

- Introduction to decisions
- if / else statements
- switch statements

## Notes

- Recursion is no longer part of the active Chapter 3 TOC. Keep Chapter 3 focused on selection syntax, Boolean reasoning, and decision examples.
- Recursion is introduced with trees in Chapter 17; deeper recursive design follows in Chapter 22.

## Reliability Progression (2026-10-16)

Use decision tables and values below, at, and above each business-rule boundary. Check invalid values with the decisions already taught. The revised lessons and lab now apply this progression directly; legacy assessment-format modernization remains separate.

## Prerequisite Alignment (2026-10-16)

Now Chapter 3, before Iteration and Methods. Active lessons and the connected payroll lab use top-level statements and directly assigned results. Removed custom method/class wrappers, return-based homework, and the custom-object equality preview. String equality is introduced here as case-sensitive content comparison. Chapter 2's variables, operators, built-in calls, numeric parsing, and output are sufficient. No loops or later string-cleaning/search tools are required. Retained source-only recursion is not a prerequisite or active lesson. Assessment and cell IDs are unchanged.

## Restored CS1 Material (2026-10-17)

- `assignments/additional_practice.ipynb`: restored explanations and exercises; retains current lessons and assignment IDs.

## CS1 Preservation Follow-up (2026-10-17)

Original Congress three-way conclusion added alongside the independent eligibility booleans. The original return-fragment variants are fully retained in Methods Extra Practice because user-defined methods follow this chapter.

## Section-Boundary Review (2026-10-17)

**Status: implemented.** The following records the reviewed recommendation and its baseline. See Implemented Reading Organization below for the final current filenames and order; earlier meeting allocations are historical where they conflict.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `0301_intro_decision.ipynb`: Boolean Expressions & Logical Operators | Core content | 1,045 | 16 | 4 |
| `0302_ifstatement.ipynb`: Conditional (`if`) Statements | Core content | 1,336 | 25 | 6 |
| `0306_switch.ipynb`: Switch Statement | Core content | 249 | 9 | 2 |

**Recommendation:** Combine Switch with selection forms.

The 249-word switch page describes a related selection form but does not develop an independent problem. Combining it with conditional selection supports direct comparison. Boolean reasoning remains a separate prerequisite.

### Proposed Reading Sequence

1. Boolean expressions and decision reasoning.
2. Selection with if, else-if, nested conditions, and switch.

### Adequacy Before Reorganization

Expand switch explanation and decision-table practice before merging; combining three short descriptions is not adequate instruction by itself.

Reading sections and class meetings are different units; allocate discussion and practice after developing adequate explanations. Do not reduce distinct material to meet a section or word quota.

Preserve every existing explanation, exercise variation and assessment identity. The source-to-destination dispositions in MATERIALS.md govern any later move. Update TOC, links and redirects only in an authorized implementation pass.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `0301_intro_decision.ipynb`: Boolean Expressions & Logical Operators.
- `0302_ifstatement.ipynb`: Conditional Selection with if and switch.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.
