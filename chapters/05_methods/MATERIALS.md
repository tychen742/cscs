# Chapter Materials — Methods

## Core Depth Revision (2026-10-19)

C04: follow definition, call, and execution using the top-level helper path before the complete class-based project comparisons. Preserve all former prose, project listings, method traces, guided practice and anchors; add explicit transitions between the learner path and retained program-form references.

This current arrangement supersedes conflicting historical outlines below. Assignments and optional/supporting readings are unchanged. Existing explanations, examples, exercise identities and published paths are preserved. Verification and cell-preservation evidence are recorded in `authoring/core_depth_revision/`.

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `0501_intro_methods.ipynb` | Designing and Calling Methods | Core content |
| `0503_parameter.ipynb` | Method Parameters | Core content |
| `0502_signature_call.ipynb` | Returned Results and Method Contracts | Core content |
| `0504_strings.ipynb` | Strings and Their Methods | Core content |
| `0505_summary.ipynb` | Composition, Refactoring, and Method Checks | Core content |

Keep all five readings and their recently developed teaching content. Remove redundant page-level contents boxes and the obsolete Introduction wrapper; keep every syntax, scope, static-storage, call/return and exercise variation. The second static-storage heading is a reference heading, not a duplicate first introduction.

No assessment identity, assignment notebook, worked code, output or exercise variant is removed. `authoring/integration_cleanup/` records the original cells, exact edits, moves and URL/fragment compatibility.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Landing Page

- `0500_methods.ipynb` — Chapter landing page

## Section Notebooks

- `0501_intro_methods.ipynb` — Introduction to methods
- `0502_signature_call.ipynb` — Method signatures and calls
- `0503_parameter.ipynb` — Parameters, scope, static variables, and tracing; return-value development is shared with 5.2.
- `0504_strings.ipynb` — Strings and their methods (moved early from Chapter 9's text operations, 2026-10-04): length, indexing, cleaning, immutability, searching, `Substring`, `Replace`, chaining
- `0505_summary.ipynb` — Static-method syntax and scope reference; worked synthesis and guided practice.

## Assignments

- `assignments/index.ipynb` — Index
- `assignments/lab.ipynb` — Lab
- `assignments/preview.ipynb` — Preview
- `assignments/homework.ipynb` — Homework

## Notes

- Source examples live in `demos/` at the project root.

## Runnable Demo Projects

- [`demos/05_methods/methods_demo/`](../../demos/05_methods/methods_demo/README.md): Method calls, parameters, and return values.

All demo projects target .NET 10. Run commands and verification are documented
in `demos/README.md` and each project README.

Instructor support: [current lab walkthrough](../../instructor_support/labs/05_lab_solution.md). See its scope before treating a demo as an assignment answer.

## AI Literacy Integration (2026-10-15)

The method-signature lesson adds a prepared AI-review activity about a packing-charge contract. Students identify a missing fixed amount, trace two calls, and repair the return expression. It requires no decisions/loops and can replace similar method practice.

- `assignments/homework_gradecalculation2.ipynb`: optional grade-average application using methods, moved from Iteration.

## Prerequisite Alignment (2026-10-16)

Now Chapter 5, after Decisions and Iteration. Students already call built-in methods (Chapter 2), choose branches (3), and repeat work (4). Use that experience to motivate naming tasks, parameters, return values, decomposition, and repeatable tests before Chapter 6. Full string cleaning/search/extraction/chaining remains in 5.4; minimal equality/length/indexing is already introduced where needed earlier.

The optional Grade Calculation 2 assignment now lives here because its FindAverage and reusable category-input requirements need method definitions. Its identifiers and published old URL are retained through migration/redirects. The method-based loop demo is supplementary practice after this chapter; it is not an Iteration prerequisite.

## Restored CS1 Material (2026-10-17)

- `assignments/additional_practice.ipynb`: restored explanations and exercises; retains current lessons and assignment IDs.

## CS1 Preservation Follow-up (2026-10-17)

Complete original returning-method equivalence/side-effect/unreachable/semicolon/nested-else fragments restored after method prerequisites. Strange Sequence now also has the original separate Jump, PrintStrangeSequence and CountStrangeSequence contracts, alongside the earlier combined variant. Term versus transition counting is explicit.

The final source-list check also retains the original named array, reversal, and small abstract/interface variations in the corresponding supporting practice; see the preservation matrix for exact locations.

## Topic-to-Section Coverage Map (2026-10-17)

This map distinguishes material that exists from material that adequately teaches
its purpose. It is a revision plan, not a claim that the improvements below are
implemented. Keep all five current content sections, existing explanations,
examples, exercise variations, assessment IDs, and published paths. Correct
inaccuracies explicitly rather than removing the surrounding teaching material.

| Topic | Content-section home | Current evidence | Required development |
| --- | --- | --- | --- |
| Purpose: abstraction, reuse, decomposition, single responsibility | 5.1 Introduction | Benefits and terminology are listed; executable example is Hello World. | Develop one concrete repeated business task, then show a helper removing repetition. Explain what the name hides and what remains visible to callers. |
| Definition, header, signature, and call syntax | 5.2 Designing Methods; reference in 5.5 | Syntax template, component table, and examples exist. Terminology and Main/top-level explanations conflict. | Correct required return-type syntax and distinguish full header from C# signature. Explain each component and one consistent primary program form; connect other forms explicitly. |
| Parameters, arguments, matching types and positions | 5.3 Method Parameters | Verse comparison and parameter explanation exist. | Show argument evaluation and binding in a table; vary names and values without changing the contract. Explain that arguments are expressions and parameter names need not match caller variables. |
| Returning versus printing; void versus value-returning methods | 5.2, reinforced in 5.3 and 5.5 | Brief lesson discussion; fuller Return Statement, Return Strings, and Return Formatted String explanation in lab. | Relocate instructional explanation to the lesson. Compare two related methods that print or return; show storage, composition, and intentional or accidental discarded results. |
| Returned calls as expressions | 5.2 Designing Methods | Square example exists; explanatory bullets disagree with its code. Lab contains the fuller substitution walkthrough. | Correct the trace; teach F(3), F(3) + F(4), and replacement by returned values before students perform lab tasks. |
| Call/return execution flow and method composition | 5.2, applied in 5.3 and 5.5 | Prose descriptions, parameter tracing fragment, and lab LastFirst trace. | Add a correct complete caller/helper example, call/return diagram, and trace returning to the exact calling expression. Show helpers calling helpers. |
| Local and block scope; ordinary parameter value copying | 5.3 Method Parameters | Scope rules and name independence are stated; homework asks about separate x variables. | Demonstrate distinct caller/parameter/local variables and block boundaries. Trace reassignment of a value parameter without changing the caller. Distinguish scope from lifetime without promising a physical memory layout. |
| Static members, constants, and instance-call orientation | 5.3, concise reference in 5.5; connect string calls in 5.4 | Static variables and static/instance terminology are present. | Clarify static methods versus mutable static fields and constants. Explain only the call distinction needed now; defer class/object design depth to Chapters 10–12. |
| Familiar decisions and loops inside methods | 5.2–5.3; synthesis in 5.5 | Many examples are in Extra Practice and optional Grade Calculation 2. | Develop ordinary examples connecting Chapters 3–4 to reusable method contracts before assigning the larger variations. |
| Return paths, early returns, unreachable statements, semicolon mistakes | 5.2–5.3; reference in 5.5 | Restored return-equivalence and nested-decision variations are in Extra Practice. | Teach return-path reasoning and labeled mistakes in content, then retain all original fragment sets as practice. |
| Contracts, input assumptions, and separation of computation from interaction | 5.2 and 5.3; synthesis in 5.5 | Packing-charge review is useful. Lab InterviewSentence and formatted-return tasks separate computation from Main. | Use contracts consistently; teach the separation in content before the lab asks students to apply it. State assumptions and failure policies. |
| Refactoring repeated code without changing behavior | 5.1 motivation; 5.5 synthesis | Stated objective; optional grade assignment and restored exercises offer applications. | Show an actual before/after transformation, explain parameter choices, and compare results before and after. |
| Repeatable tests with independently derived expected results | 5.2 onward; consolidate in 5.5 | Packing-charge activity has ordinary/zero cases; broader progression remains a planning intention. | Develop expected/actual tables and ordinary/boundary checks for returned values, preparing for Chapter 6 without requiring a testing framework. |
| String methods, properties, indexing, immutability, extraction, and chaining | 5.4 Strings and Their Methods | Seven examples and useful tables; no saved outputs or guided section exercise. | Retain APIs and business context; add verified output interpretation, indexed-string/chain visuals, input assumptions, meaningful variations, and guided practice before the SKU lab. |
| Guided practice to independent application | Guided work in each content section; application in assignments | Main lessons have one tagged guided activity, the AI review. Original lab/review and restored practice provide substantial material. | Add scaffolding and feedback in content. Keep labs focused on applying taught ideas; retain original review and exercise purposes while strengthening independent transfer and checking. |
| Overloading and recursion | Explicitly bounded extension; later chapters for developed treatment | Preview/homework mention them without developed core instruction here. | Label extension questions or defer required assessment until instruction exists. Do not silently make them prerequisites for core Methods work. |

## Explanations to Relocate from Lab to Content

Content sections teach; labs apply what has already been taught. Relocate the
following instructional passages while retaining their original examples and
exercise purposes. A lab may retain requirements, starter code, brief reminders,
lesson links, expected behavior, checks, and deliverables, but must not be the
first place students learn a concept required to complete its work.

| Current lab material | Content destination | What remains in the lab |
| --- | --- | --- |
| Return Statement: mathematical F(x), returned-value substitution, and F(3) + F(4) evaluation | 5.2, beside the value-returning example and flow trace | Returns task, code to inspect/run/annotate, and application questions. |
| Return Strings: generality of returned types, local intermediate values, and the LastFirst execution walkthrough | 5.2 for returned strings and flow; 5.3 for argument binding and local variables | LastFirst tracing/application task, with a link to the taught walkthrough. |
| Return Formatted String: distinction between constructing a string and printing it, string.Format behavior, and newline discussion | 5.2 for returning versus printing; 5.4 for the formatting API reminder | SumProblemString application, renaming variation, and execution checks. |
| Interview String Return: why input/output stays in Main while InterviewSentence computes a reusable result | 5.3, consolidated in 5.5 | Refactor the interview program using the taught separation; retain its requirements. |
| Birthday Method: any explanation needed to distinguish a new call from a new definition or to choose where blank-line output belongs | 5.2 calls/void methods; 5.3 parameterization | Add Maria, compare the two blank-line placements, and explain observed behavior. |
| Product Code Report: explanations of normalization, extraction, and helper composition required to implement the TODO methods | 5.4 for string operations; 5.5 for helper composition | The SKU problem context, method requirements, starter, expected report, new-input variation, and design reflection. |

Do not replace the original exercises with generic drills. Preserve their distinct
learning purposes and the full restored Extra Practice bank. When relocating a
passage, record its source and destination and verify that it remains available
in the content sequence. The completed lesson must precede its application task.

## Implementation Checklist (Completed 2026-10-17)

- Completed: repaired the contradictory top-level/Main prose, incorrect square-example trace,
  invalid standalone parameter-tracing cell, and inconsistent signature rules.
- Completed: gave complete runnable examples their own imports, caller/setup, verified
  outputs, and nearby interpretation; label schematic fragments and intentional
  errors explicitly.
- Completed: added purposeful visuals: decomposition before/after, call/return flow,
  argument-to-parameter binding, scope/value-copying, and string-index/chain
  traces. Select by teaching need, not by quota.
- Completed: reviewed assignment alignment, including extension-only preview questions and
  screenshot/document instructions; preserve existing assessment identities.
- Verification and preservation evidence: `authoring/CH05_FRAMEWORK_REVIEW.md`.
- An aligned chapter slide deck remains a teaching-support gap. Keep the current
  video until the author requests a replacement.

## Coverage Implementation (2026-10-17)

The coverage table above retains the audit baseline and the required development
so the reason for each addition remains visible. The five existing sections now
implement that plan: conceptual framing, syntax scaffolds, worked traces, four
editable SVG diagrams, guided starters with revealed verified solutions, and
repeatable expected/actual checks. Full original class-based examples remain as
labeled reading references beside the standalone runnable forms. Lab explanations
now precede application; tasks, variants, and the Extra Practice bank remain.
The slide-deck gap remains open.

## Section-Boundary Coverage Disposition (2026-10-17)

**Reviewed plan, now implemented:** Redistribute the overloaded design lesson. The disposition below records the preimplementation baseline and rationale. See Implemented Reading Organization for the current reading files. Counts in this baseline exclude fenced code from prose; the refreshed inventory is in authoring/content_size/. They flag review needs, not quality scores.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `0501_intro_methods.ipynb`: Introduction | Core content | 1,293 | 16 | 4 |
| `0502_signature_call.ipynb`: Designing Methods | Core content | 2,823 | 52 | 11 |
| `0503_parameter.ipynb`: Method Parameters | Core content | 1,778 | 34 | 9 |
| `0504_strings.ipynb`: Strings and Their Methods | Core content | 1,025 | 33 | 10 |
| `0505_summary.ipynb`: Static Methods | Core content | 1,193 | 24 | 4 |

### Source-to-Destination Plan

| Existing source | Proposed treatment and coverage to preserve |
| --- | --- |
| `0501` | Combine the definition/header and first-call material from 0502 with the existing decomposition problem. |
| `0502` | Split its conceptual jobs: send definition/call basics to the first lesson; retain returned expressions, LastFirst, formatted results, print-versus-return, decisions and AI review in the returned-result lesson. Teach parameters before this in the proposed reading order. |
| `0503` | Retain parameter binding, scope/value-copy, loop helpers, and interaction separation as the parameter/state lesson. |
| `0504` | Retain a dedicated string lesson; strengthen its sustained transformation problem. |
| `0505` | Distribute repeated definition/call/scope/static reference explanations next to their teaching points, preserving their distinct examples. Keep the checkout refactoring and tests as the final synthesis lesson. |

### Development Needed Before Moving Material

Add fuller method-boundary design reasoning, Boolean-returning helpers, argument-expression/type variations, and multi-step string reasoning. This plan does not declare the recent revision fully adequate.

Before a later move, create a cell-level preservation map for these sources, including citations, figures, original code forms, worked traces, guided questions and independent exercise variants. Relocate prerequisite explanations from assignments into content when needed while retaining application requirements and IDs. A consolidated page must still teach its concepts; a split must not create two unsupported outlines. Existing runnable verification records describe earlier work, not verification of this proposal.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `0501_intro_methods.ipynb`: Designing and Calling Methods.
- `0503_parameter.ipynb`: Method Parameters.
- `0502_signature_call.ipynb`: Returned Results and Method Contracts.
- `0504_strings.ipynb`: Strings and Their Methods.
- `0505_summary.ipynb`: Composition, Refactoring, and Method Checks.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.


## Outcome Gap Repair (2026-10-17)

Preserve the current chapter notebooks, reading order, existing explanations, exercise variants, and assessment identifiers. The additions below close the outcome audit gaps within that organization. Explanations belong in content before independent application; earlier scaffolded tasks remain available.

| Location | Development or assessment |
| --- | --- |
| `0503_parameter.ipynb` | Return Values, out, and ref |
| `homework.ipynb` | Independent Method Contracts and Refactoring |

Progression: read the relevant lesson and worked example, complete its guided practice, then attempt the added independent homework without copying the solution. Require contract-derived expected results, boundary evidence, and reasoning about the chosen representation or design. Assess process and explanation as well as output. Existing labs remain scaffolded applications rather than the sole evidence of independent mastery.

Lecture decks remain a separately tracked task. No additional chapter, meeting, or required optional-topic track is introduced.

### Verified Topic-to-Assessment Progression

| Topic/outcome | Explanation and worked example | Guided preparation | Independent evidence |
| --- | --- | --- | --- |
| Output and reference parameters | 0503_parameter: syntax/obligation comparison and TryQuantity/AddOne trace | TryPercentage with valid, invalid, and boundary inputs | Independent Method Contracts and Refactoring; later parsers and linked-head replacement refer here. |
| Independent method tests and refactoring | 0505_summary existing contract/refactoring progression | Existing method checks and regression practice | New packing contract requires independently derived expectations, separate calculation/display, and regression evidence. |

Keep the original five-question coding tracks and smaller historical variations. Added transfer tasks complement them. Grade implementation, independently derived expected results, and the requested reasoning separately; correct output from a supplied class does not establish algorithm construction.

## Recursive Methods Supporting Reading (2026-10-18)

Added `0506_recursive_methods.ipynb` as a supporting reading after 5.5, following the textbook comparison in `authoring/toc_comparison/README.md`: comparable CS1 texts teach recursion in the first semester, and this book previously first taught it in 17.1. The reading gives the general shape (base case, recursive case, progress), a deadline countdown trace, `SumTo` recursive versus loop, an indented call-stack trace, the GCD example from 4.4 in both forms, a loop-versus-recursion table, and a guided digit-count practice with solution. Six code cells compile and run standalone (.NET 10). 5.5's Bounded Extensions paragraph and 17.1 link to it. It adds no meeting and no assessment.


## Subsection Integration (2026-10-17)

This is the current internal teaching order for the repaired pages. Earlier outlines remain historical where they differ. Chapter/section notebook order is unchanged. All original explanations, examples, exercises, code outputs, assessment identifiers, and link destinations are retained.

### `0501_intro_methods.ipynb`

- Discover a Task Before Naming a Method
- A Repeated Task Needs a Name
  - Designing Methods
    - Design Checklist and Chapter Connections
- Connect Calls, Definitions, and Program Forms
  - Method definition
  - Method Signature
  - Static Methods
  - Method Calls & Returns
    - Method Calls
    - Flow of execution
- Guided Practice: Reuse a Notice

### `0503_parameter.ipynb`

- Map Arguments to Parameters
- Return Values, out, and ref
- Variable Scopes
  - Scope
- Static Variables
  - Static Storage Reference
- Method Tracing
- Reuse a Loop Through a Method Contract
- Keep Interaction in the Caller
- Guided Practice: Use a Returned Value

Treat syntax, examples, and meaningful variations as children of their conceptual topic. Place prerequisite explanations before application, and distinguish a local checkpoint from later synthesis. Preserve distinct older/newer treatments by grouping them rather than deleting them. Keep the final Footnotes group after instructional content.

## Caption-Only Section Development (2026-10-18)

Pass 3 of the content-development audit: in 5.4 Searching, Extracting Part of a String, and Replacing Text gained output interpretation and a named mistake each (treating IndexOf as a Boolean, position-dependent Substring arguments, case-sensitive Replace), and Extracting gained the two Substring forms as a labeled pattern. No code changed; cells were rerun to confirm outputs.

## Guided Practice Pass (2026-10-18)

Pass 4 of the content-development audit (`authoring/content_development_audit/`): added mid-page guided practices with solutions to 5.4 (normalize a product code) and 5.6 (count up instead of down), so each page has a checkpoint before its final practice. Every new starter and solution compiles and runs standalone (.NET 10); starters that are meant to fail say so in their task text. No existing cell, heading, or exercise ID was removed.
