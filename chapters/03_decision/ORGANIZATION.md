# Chapter Organization — Decision Structures

## Current Lecture Deck (2026-10-21)

The revised chapter deck is `_html_extra/chapters/03_decision/0300_slides.md`. It follows the current reading order with a named part per reading, worked examples and state traces, quick checks, existing exercise links, and instructor notes. Meeting 1: Boolean rules in 3.1, 35 minutes; meeting 2: if/else and ordered tiers in 3.2, 40 minutes; meeting 3: switch/default and transfer practice in 3.2, 35 minutes. Total 110 minutes. Reading pages do not add meetings. Optional supporting parts remain unassessed. The chapter landing links the student HTML deck; the former overview remains unchanged for compatibility. Code verification is recorded with `authoring/slide_revision/code_01_08.json`; final render/build evidence is recorded by the shared slide workflow. Assessment identities and assignment notebooks are unchanged.

## Assignment Alignment Repair (2026-10-21)

Standard Homework now has five applied true/false checks and five standalone top-level coding tasks assessing compound approval, fee boundaries, ordered classification, switch/default including a valid free service, and a discount-boundary repair. The legacy Boolean/branch review remains explicitly ungraded reference. The preview no longer claims arbitrary nested branches can always be flattened; the supplemental Boolean prediction starter now shows the actual sequence before reveal.

All existing notebook cell IDs, assessment/exercise IDs, radio names/values, and chapter order are preserved. New practice uses distinct semantic identities. Slides remain deferred. Completed new or changed solutions are compiled and executed independently under .NET 10; verification evidence is consolidated in the assignment-revision report.

## Tabs 3 and 4 Output Checks (2026-10-19)

Tab 3 supplies its own five-row score/output table; Tab 4 lists seven delivery cases, including express at 50 and a second unknown code. Explicit input scope and temporary declaration substitution keep the checks bounded. Check-all controls execute the reader's current editor code through the existing C# runner transport, compare successful stdout to fixed expected output, and show each actual result. They preserve editor state and distinguish runner/compile failures from incorrect output. Starter saved outputs are labeled historical, not targets. Explanations are revealable. Existing exercise IDs, code cells and outputs remain unchanged. Assignments and optional readings are unchanged.

## Tab 2 Repair and Evidence Revision (2026-10-19)

Tab 2 shows a deliberately faulty standalone service program, asks students to complete its missing default branch, and provides explicit P/X expected-output tests. The hidden verified answer rejects all unsupported services with a diagnostic and return; it does not add an X case or assign an invalid service a charge. A checked multiple-choice explanation distinguishes numeric price from recognition evidence and connects the different zero-price policy in Tab 4. Existing executable cells and other tabs are preserved. Assignments and optional readings are unchanged.

## End-of-Section Practice Pilot (2026-10-19)

Section 3.2 ends with a four-question practice area before Footnotes: predict branches, explain invalid input, repair first-match ordering, then apply delivery rules. The repair cells retain their identities and source. The Predict tab now presents two side-by-side score examples with multiple-choice predictions and checked feedback; the unrelated service-table instruction and uncheckable trace field were removed. The branch explanation and boundary checks remain available after the choices. Short guided checks elsewhere stay beside their concepts. Desktop-style tabs progressively enhance the four question sections; without JavaScript, every question remains readable in order. Existing Edit/Run controls and code state are retained. This is one-section pilot only; assignments and optional readings are unchanged.

## Core Depth Revision (2026-10-19)

C03: retain the service-code problem as framing, develop if/else-if/nesting/switch first, then return to the preserved cross-form comparison. Add a standalone, top-level branch-order repair and an inclusive-boundary/invalid-case trace. No methods or loops are prerequisites.

This current arrangement supersedes conflicting historical outlines below. Assignments and optional/supporting readings are unchanged. Existing explanations, examples, exercise identities and published paths are preserved. Verification and cell-preservation evidence are recorded in `authoring/core_depth_revision/`.

## B-A Development Follow-up (2026-10-18)

| Reading | Audit findings | Developed coverage |
| --- | --- | --- |
| `0301_intro_decision.ipynb` | B11 | Retain and verify the newly present free-shipping exercise; add inclusive-threshold truth table and counterexamples distinguishing || from && and > from >=. |

Keep the current reading order and chapter boundaries. Develop explanation and relevant general syntax before the worked application; interpret output/state and a meaningful variation, then provide a local learner attempt with feedback. Existing labs and homework remain the independent transfer stage; do not move new prerequisite explanations into labs. Optional readings remain optional. The report in `authoring/ba_development_revision/` maps all 18 findings to current evidence and verification.


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


## Subsection Integration (2026-10-17)

This is the current internal teaching order for the repaired pages. Earlier outlines remain historical where they differ. Chapter/section notebook order is unchanged. All original explanations, examples, exercises, code outputs, assessment identifiers, and link destinations are retained.

### `0301_intro_decision.ipynb`

- Selection Statements
- Boolean Data Type
- Boolean Expressions
- Compound Boolean Expressions
  - Logical Operators
  - Compound test conditions

### `0302_ifstatement.ipynb`

- Compare Ways to Express the Same Decision
- Reason About the Unselected Branches
- Simple `if` Statements
- `if-else` Statements: Two-Way Selection
- `else-if` Statements: Multi-Selection
  - else-if Statements
  - `else-if` Statements for Cases
- Nested Conditionals
  - Nested `if` Statements
  - Nested `if-else` Statements
- Switch Statement
  - Switch Syntax and Case Behavior
  - The `default` Keyword
  - The `break` Keyword

Treat syntax, examples, and meaningful variations as children of their conceptual topic. Place prerequisite explanations before application, and distinguish a local checkpoint from later synthesis. Preserve distinct older/newer treatments by grouping them rather than deleting them. Keep the final Footnotes group after instructional content.

## Guided Practice Pass (2026-10-18)

Pass 4 of the content-development audit (`authoring/content_development_audit/`): added a mid-page guided practice with solution to 3.1 (decide free shipping with a Boolean expression), previously a page with no practice. Every new starter and solution compiles and runs standalone (.NET 10); starters that are meant to fail say so in their task text. No existing cell, heading, or exercise ID was removed.

## Visual Support and Part I Shape (2026-10-18)

Pass 6 of the content-development audit (`authoring/content_development_audit/`): 3.1 gained a runnable `if` example right after the syntax pattern and before the list of statement forms, and a runnable Boolean example in which a comparison produces the stored `bool`. New code cells compile and run standalone (.NET 10); tables and text diagrams are placed beside the example they explain. No heading, cell ID, or exercise ID changed.
