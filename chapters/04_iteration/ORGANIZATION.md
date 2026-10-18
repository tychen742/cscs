# Chapter Organization — Iteration

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `0401_iteration.ipynb` | Iteration | Core content |
| `0402_for_statements.ipynb` | The `for` Statement | Core content |
| `0403_while_statement.ipynb` | While-Statements | Core content |
| `0404_gcd.ipynb` | Greatest Common Divisor | Supporting reading |

0402 now includes every loop-generated output/table example formerly in Chapter 2, after the for/foreach foundations. Field widths, headings, power-table output and all code variants are retained. Chapter 2 links forward rather than requiring loops early. The infinite-loop discussion is before final Footnotes, and do-while headings distinguish overview from syntax/tracing.

Teach the section conceptual framework before detailed application; place syntax prerequisites before reasoning that requires them. Keep the new worked traces and guided checkpoints, followed by existing lab/homework transfer. Reading count does not set a meeting or word quota.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Learning Objectives

<!-- List 3–5 measurable student outcomes -->

## Sequence

- Introduction to iteration
- for loops
- while loops

## Notes

<!-- Dependency constraints, pacing notes, or known issues -->

## Reliability Progression (2026-10-16)

Test zero, one, and many iterations, termination, and off-by-one boundaries. Carry failing examples forward as regression checks. The revised lessons and lab now apply this progression directly; legacy assessment-format modernization remains separate.

## Prerequisite Alignment (2026-10-16)

Now Chapter 4, after Decisions and before Methods. Active examples use top-level loops; return-based exercises now use loop variables and printed results. Introduce string Length, zero-based indexing, empty-string bounds, and foreach locally in 4.2 before 4.3 uses them. No arrays or later string methods are required for those examples.

The order-entry lab keeps five connected tasks but uses inline validation loops instead of a UI class. Explain TryParse/out as a built-in call, handle exhausted input, and accept exact lowercase y/n without Trim/ToLower. Required homework uses top-level programs and break/continue rather than method returns. The first Grade Calculation stays here; the function-based second assignment moves to Chapter 5. Library calls remain allowed; defining methods and classes is deferred. Existing assessment/cell IDs are preserved.

## Restored CS1 Material (2026-10-17)

- `assignments/additional_practice.ipynb`: restored explanations and exercises; retains current lessons and assignment IDs.
- `0404_gcd.ipynb`: restored explanations and exercises; retains current lessons and assignment IDs.

GCD remains supporting reading; required loop programs use top-level statements. Returning/string-cleaning and multi-method extensions are in Methods practice.

## CS1 Preservation Follow-up (2026-10-17)

Original ABCabc character-code indexed/foreach illustration restored. The incomplete final Additional Iteration Homework question now includes the standalone review’s decrementing-loop program and zero-start follow-up.

## Section-Boundary Review (2026-10-17)

**Status: implemented.** The following records the reviewed recommendation and its baseline. See Implemented Reading Organization below for the final current filenames and order; earlier meeting allocations are historical where they conflict.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `0401_iteration.ipynb`: Iteration | Core content | 963 | 10 | 5 |
| `0402_for_statements.ipynb`: The `for` Statement | Core content | 1,427 | 30 | 9 |
| `0403_while_statement.ipynb`: While-Statements | Core content | 1,581 | 36 | 8 |
| `0404_gcd.ipynb`: Greatest Common Divisor | Supporting reading | 2,166 | 19 | 1 |

**Recommendation:** Retain three core lessons and GCD support.

Planning repetition, counted traversal, and condition-controlled repetition have different instructional roles. The complete GCD lesson is a supporting case, not a fourth required meeting.

### Proposed Reading Sequence

1. Iteration models and loop planning.
2. Counted loops, traversal, and nested repetition.
3. Condition-controlled loops, input, and termination.

### Adequacy Before Reorganization

Develop loop selection and invariant/state traces; distinguish required fundamentals from optional mathematical cases. No new page is needed simply to meet a three-meeting template.

Retain the supporting readings identified above outside the required core. Reading sections and class meetings are different units; allocate discussion and practice after developing adequate explanations. Do not reduce distinct material to meet a section or word quota.

Preserve every existing explanation, exercise variation and assessment identity. The source-to-destination dispositions in MATERIALS.md govern any later move. Update TOC, links and redirects only in an authorized implementation pass.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `0401_iteration.ipynb`: Iteration.
- `0402_for_statements.ipynb`: The `for` Statement.
- `0403_while_statement.ipynb`: While-Statements.
- `0404_gcd.ipynb`: Greatest Common Divisor.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.


## Outcome Gap Repair (2026-10-17)

Preserve the current chapter notebooks, reading order, existing explanations, exercise variants, and assessment identifiers. The additions below close the outcome audit gaps within that organization. Explanations belong in content before independent application; earlier scaffolded tasks remain available.

| Location | Development or assessment |
| --- | --- |
| `0403_while_statement.ipynb` | Validate a Number Before Using It |
| `0402_for_statements.ipynb` | Repeated Trials and Random Values |

Progression: read the relevant lesson and worked example, complete its guided practice, then attempt the added independent homework without copying the solution. Require contract-derived expected results, boundary evidence, and reasoning about the chosen representation or design. Assess process and explanation as well as output. Existing labs remain scaffolded applications rather than the sole evidence of independent mastery.

Lecture decks remain a separately tracked task. No additional chapter, meeting, or required optional-topic track is introduced.

### Verified Topic-to-Assessment Progression

| Topic/outcome | Explanation and worked example | Guided preparation | Independent evidence |
| --- | --- | --- | --- |
| Conversion versus business validation | 0403_while_statement: validation table, TryParse pattern, interactive retry loop | Predict text/range/end-of-input cases before running | Existing Lab 2 and extra-practice guessing tasks apply conversion without first introducing it. |
| Random bounds and repeated trials | 0402_for_statements: generator lifecycle, bounds table, invariant example | Die-trial variation and count invariant | Retained coin, Group Flips, and guessing tasks; original encoding explanation moved into content. |

Keep the original five-question coding tracks and smaller historical variations. Added transfer tasks complement them. Grade implementation, independently derived expected results, and the requested reasoning separately; correct output from a supplied class does not establish algorithm construction.


## Subsection Integration (2026-10-17)

This is the current internal teaching order for the repaired pages. Earlier outlines remain historical where they differ. Chapter/section notebook order is unchanged. All original explanations, examples, exercises, code outputs, assessment identifiers, and link destinations are retained.

### `0402_for_statements.ipynb`

- For Statement Syntax
  - Execution sequence
- `break` and `continue` Statements
- Nested `for` Loop
- Additional Loop Step Patterns
  - Step in loop header
- `foreach` Essentials
  - `foreach` Statement
    - Numeric Character Codes with Two Loop Forms
  - `break` in `foreach`
- Apply Loops to Formatted Tables
  - Format Output: Console.Write()
  - Formatting Tables
- Repeated Trials and Random Values

### `0403_while_statement.ipynb`

- Infinite loops
- While Examples
  - String Operations
  - Long Term Investment
  - Strange Sequence Exercise
  - Roundoff Exercise II
  - GCD Example with a `while` Loop
- Do-While Loops
  - Read and Trace the Do-While Syntax
  - `do-while` Example: Right Triangle
- Validate a Number Before Using It

Treat syntax, examples, and meaningful variations as children of their conceptual topic. Place prerequisite explanations before application, and distinguish a local checkpoint from later synthesis. Preserve distinct older/newer treatments by grouping them rather than deleting them. Keep the final Footnotes group after instructional content.
