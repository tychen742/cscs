# Chapter Organization — Methods

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

Teach the section conceptual framework before detailed application; place syntax prerequisites before reasoning that requires them. Keep the new worked traces and guided checkpoints, followed by existing lab/homework transfer. Reading count does not set a meeting or word quota.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Learning Objectives

See the five measurable objectives in the Current Five-Section Teaching Plan below.

## Sequence

- Introduction to methods
- Method signatures and calls
- Parameters and return values
- Strings and their methods
- Methods summary and practice

## Notes

See Prerequisite Alignment and the Current Five-Section Teaching Plan below for dependencies, section roles, preservation, and acceptance criteria.

## AI Literacy Integration (2026-10-15)

The method-signature lesson adds a prepared AI-review activity about a packing-charge contract. Students identify a missing fixed amount, trace two calls, and repair the return expression. It requires no decisions/loops and can replace similar method practice.

## Reliability Progression (2026-10-16)

Introduce repeatable method tests with independently derived expected return values, ordinary inputs, and boundary cases. This prepares for Chapter 6 rather than requiring a framework immediately. The 2026-10-17 development implements this progression in worked examples and guided practice.

## Prerequisite Alignment (2026-10-16)

Now Chapter 5, after Decisions and Iteration. Students already call built-in methods (Chapter 2), choose branches (3), and repeat work (4). Use that experience to motivate naming tasks, parameters, return values, decomposition, and repeatable tests before Chapter 6. Full string cleaning/search/extraction/chaining remains in 5.4; minimal equality/length/indexing is already introduced where needed earlier.

The optional Grade Calculation 2 assignment now lives here because its FindAverage and reusable category-input requirements need method definitions. Its identifiers and published old URL are retained through migration/redirects. The method-based loop demo is supplementary practice after this chapter; it is not an Iteration prerequisite.

## Restored CS1 Material (2026-10-17)

- `assignments/additional_practice.ipynb`: restored explanations and exercises; retains current lessons and assignment IDs.

## CS1 Preservation Follow-up (2026-10-17)

Complete original returning-method equivalence/side-effect/unreachable/semicolon/nested-else fragments restored after method prerequisites. Strange Sequence now also has the original separate Jump, PrintStrangeSequence and CountStrangeSequence contracts, alongside the earlier combined variant. Term versus transition counting is explicit.

The final source-list check also retains the original named array, reversal, and small abstract/interface variations in the corresponding supporting practice; see the preservation matrix for exact locations.

## Current Five-Section Teaching Plan (2026-10-17)

This plan supersedes the incomplete sequence above without renaming, removing,
or reordering any current section. The coverage map and relocation inventory in
`MATERIALS.md` record the audit baseline and development targets. The lessons and
assignments now implement the plan; see `authoring/CH05_FRAMEWORK_REVIEW.md` for
verification and preservation details.

### Learning Objectives

Students should be able to:

1. Decompose a familiar problem into named methods with clear responsibilities,
   inputs, return types, and stated contracts.
2. Define and call methods, distinguish arguments from parameters, and trace
   returned values through expressions and composed calls.
3. Explain local/block scope and ordinary value-parameter copying, distinguishing
   computation from console interaction and shared static state.
4. Reuse decisions, loops, and string operations inside methods, including
   immutability and the safe use of indexes and extraction assumptions.
5. Refactor repeated code while preserving behavior and check methods against
   independently derived ordinary and boundary expectations.

### Section Roles

| Existing section | Instructional role | Connections and practice |
| --- | --- | --- |
| 5.1 Introduction | Establish the problem of repetition/complexity and the big idea of naming a reusable task. | Connect earlier built-in calls to writing helpers; demonstrate a before/after decomposition and provide guided method construction. |
| 5.2 Designing Methods | Develop contracts, definition/call syntax, void versus returned values, expression substitution, and call/return flow. | Teach the explanations relocated from the lab here before application. Retain the packing-charge review and add ordinary guided practice. |
| 5.3 Method Parameters | Develop argument binding, ordinary value copying, local/block scope, parameterized decisions/loops, and separation of computation from interaction. | Retain Verse; add traces and guided variations. Introduce static state only far enough to distinguish it from locals and constants. |
| 5.4 Strings and Their Methods | Apply the method-call/result model to cleaning, searching, extracting, and composing string operations. | Retain current examples/tables; add interpreted output, purposeful visuals, assumptions and boundary checks, and guided work before the SKU task. |
| 5.5 Static Methods | Consolidate the syntax reference through method design, composition, refactoring, and repeatable result checks. | Retain existing summary material; add an integrated worked example and guided synthesis preparing students for independent assignments and Chapter 6. |

### Apply the B-A Framework Flexibly

- **The section's conceptual framework:** begin with the problem, explain the
  big idea, and make substantive connections to earlier or related ideas.
- **Subsection development:** provide explanation, relevant general syntax,
  worked examples, interpreted output, variations, and corrected mistakes as
  needed. Explain prerequisites before using them.
- **Purposeful visual support:** use diagrams/tables/traces where they clarify
  relationships, structure, behavior, or change. Explain how to read them and
  connect them to the code; do not impose a visual quota.
- **Practice progression:** guided exercises belong in content sections;
  assignments progressively apply and transfer what students have learned.
  Labs may supply scaffolding, but do not introduce the teaching explanations
  needed to complete the work.

These are teaching supports, not a mandatory sequence of headings. Preserve the
current section titles and order. Set meeting-level pacing after developing the
coverage; meeting counts must not be used to remove distinct explanations or
exercise variations. Not every supporting example needs full class discussion.

### Lab Explanation Relocation and Preservation

Follow the source-to-destination table in `MATERIALS.md`. Relocate the lab's
return-substitution, returned-string/formatting, parameter-binding/execution,
and computation-versus-interaction explanations into 5.2–5.4, with synthesis in
5.5. Keep the original lab problems, variants, and deliverables. Use brief
reminders and links from the lab back to lessons instead of duplicating a first
explanation there. Retain the full restored practice bank and the optional Grade
Calculation 2 application.

### Boundaries and Acceptance

Decisions and loops are prerequisites from Chapters 3–4. Arrays, collections,
class/object design, and a testing framework are not prerequisites for the core
method lessons. Overloading/recursion questions must be explicitly bounded as
extensions or deferred until taught. Deeper class state, reference contracts,
and instance-method design stay in the later OOP sequence.

Before calling the chapter adequate, confirm the topic map is satisfied in the
content sections, each application task has its prerequisite instruction, all
relocated explanations have a retained destination, examples and outputs are
verified, and ordinary/boundary checks support the Chapter 6 transition. Review
planning, assignments, demos, instructor guidance, and built output together.

## Teaching Pace

Retain the five-section reading organization. Across three meetings, emphasize
5.1–5.2 (35–40 minutes), 5.3 (35–40 minutes), and 5.4–5.5
(30–40 minutes). Class-based references, the full LastFirst trace, additional
practice variants, and recognition-only extensions support review outside class.
Adjust discussion time to student needs; preserve the complete reading and
exercise material rather than cutting it to fit a meeting.

## Section-Boundary Review (2026-10-17)

**Status: implemented.** The following records the reviewed recommendation and its baseline. See Implemented Reading Organization below for the final current filenames and order; earlier meeting allocations are historical where they conflict.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `0501_intro_methods.ipynb`: Introduction | Core content | 1,293 | 16 | 4 |
| `0502_signature_call.ipynb`: Designing Methods | Core content | 2,823 | 52 | 11 |
| `0503_parameter.ipynb`: Method Parameters | Core content | 1,778 | 34 | 9 |
| `0504_strings.ipynb`: Strings and Their Methods | Core content | 1,025 | 33 | 10 |
| `0505_summary.ipynb`: Static Methods | Core content | 1,193 | 24 | 4 |

**Recommendation:** Redistribute the overloaded design lesson.

0502 mixes initial definition/call mechanics with returned-value reasoning and contract checks. Meanwhile 0505 repeats syntax/scope reference material. Redistributing those topics yields five focused lessons without adding a sixth.

### Proposed Reading Sequence

1. Decomposition, definitions, and calls.
2. Parameters, scope, and local state.
3. Returned results, contracts, and return paths.
4. String methods and composed transformations.
5. Method composition, refactoring, and checks.

### Adequacy Before Reorganization

Add fuller method-boundary design reasoning, Boolean-returning helpers, argument-expression/type variations, and multi-step string reasoning. This plan does not declare the recent revision fully adequate.

Reading sections and class meetings are different units; allocate discussion and practice after developing adequate explanations. Do not reduce distinct material to meet a section or word quota.

Preserve every existing explanation, exercise variation and assessment identity. The source-to-destination dispositions in MATERIALS.md govern any later move. Update TOC, links and redirects only in an authorized implementation pass.

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

5.6 Recursive Methods is optional reading after the five core sections. Do not assess it in the Chapter 5 preview, lab, or homework; Chapter 17 recalls it before tree recursion. The landing page lists it in Chapter Flow and adds four glossary terms (recursion, base case, recursive case, call stack).


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
