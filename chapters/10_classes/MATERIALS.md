# Chapter Materials: Classes and Objects

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `1001_class_syntax.ipynb` | Class Syntax | Core content |
| `1002_properties.ipynb` | Properties | Core content |
| `1003_class_instance.ipynb` | Instances, State, and Useful Behavior | Core content |
| `1004_averager.ipynb` | Averager and Mutable State | Supporting reading |

Keep the current section boundaries and recently developed content. Consolidate repeated in-page navigation, distinguish repeated practice headings, retain all substantive explanations/examples and finish the instructional material before the final Footnotes group.

No assessment identity, assignment notebook, worked code, output or exercise variant is removed. `authoring/integration_cleanup/` records the original cells, exact edits, moves and URL/fragment compatibility.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Landing Page

- `1000_classes.ipynb` — Chapter landing page

## Section Notebooks

- `1001_class_syntax.ipynb` — Class syntax, plus tuples as the lightweight alternative to a class (added 2026-10-04 from the former Chapter 8 source notebook `1101-intro-ds`)
- `1002_properties.ipynb` — Properties and fields
- `1003_class_instance.ipynb` — Creating and using instances
- Optional extension: `../appendices/operator_overloading.ipynb`, outside the core chapter flow.

## Assignments

- `assignments/hw_booklist.ipynb` — Hw Booklist
- `assignments/index.ipynb` — Index
- `assignments/lab.ipynb` — Lab
- `assignments/preview.ipynb` — Preview
- `assignments/homework.ipynb` — Homework

## Notes

- Source examples live in `demos/` at the project root.
- Operator overloading should be treated as applied extension material. Core class coverage should emphasize object identity, references, constructors, fields/properties, encapsulation, and class design.

## Runnable Demo Projects

- [`demos/10/classes_demo/`](../../demos/10/classes_demo/README.md): Class instances and methods.
- [`demos/10/classes_lab/`](../../demos/10/classes_lab/README.md): Animal/employee objects and instance versus static guessing games.
- [`demos/10/enum_demo/`](../../demos/10/enum_demo/README.md): Enum values and their integer representation.

All demo projects target .NET 10. Run commands and verification are documented
in `demos/README.md` and each project README.


## Instance Lesson Refresh

The third lesson now uses a single runnable CashRegister model: independent state, properties, validation, calculated average, and reset behavior. Homework follows five true/false and five standalone coding tasks. The existing connected coffee-register lab is retained.

## Assignment Revision (2026-10-15)

Preview now has ten vocabulary multiple-choice questions with radio controls and explanations. The five-stage coffee-register lab retains its progression from static calculations to independent objects, validated properties, shared members, and ToString reports. Input assumptions and receipt-rounding policy are explicit.

Homework has five workplace true/false cases (three true, two false) and five standalone coding tasks: supplier construction, stock withdrawal guards, calculated invoices, shared ticket numbering, and independent purchase-order reports. Existing Homework exercise IDs and assignment ID are preserved. Hidden coding answers retain verified output.

The stage-five VS Code starter lives in `demos/10/coffee_register_starter/`. Canonical lab and homework solutions remain in the notebook answer cells. See `instructor_support/labs/10_classes_assignments.md` for checks and teaching guidance. The legacy Book List page remains optional practice after Chapter 11; its full solution is outside this revision.

## Restored CS1 Material (2026-10-17)

- `assignments/additional_practice.ipynb`: restored explanations and exercises; retains current lessons and assignment IDs.

## CS1 Preservation Follow-up (2026-10-17)

Supporting `1004_averager.ipynb` retains the complete original Example getter/setter/alias client and contract-first Averager explanation, algebra, client output, and implementation. Current CashRegister/Statistics remain. Extra Practice retains all ten original Classes review prompts and complete overloaded Sum/SumManyArgs/params tasks. This is supporting reading, not an added required meeting.

## Section-Boundary Coverage Disposition (2026-10-17)

**Reviewed plan, now implemented:** Retain core progression and Averager support. The disposition below records the preimplementation baseline and rationale. See Implemented Reading Organization for the current reading files. Counts in this baseline exclude fenced code from prose; the refreshed inventory is in authoring/content_size/. They flag review needs, not quality scores.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `1001_class_syntax.ipynb`: Class Syntax | Core content | 1,620 | 20 | 4 |
| `1002_properties.ipynb`: Properties | Core content | 1,959 | 14 | 2 |
| `1003_class_instance.ipynb`: Instances, State, and Useful Behavior | Core content | 958 | 22 | 6 |
| `1004_averager.ipynb`: Averager and Mutable State | Supporting reading | 908 | 13 | 3 |

### Source-to-Destination Plan

| Existing source | Proposed treatment and coverage to preserve |
| --- | --- |
| `1001` | Retain class/object/construction foundations; label tuple alternatives as a bounded comparison after students understand the class contract. |
| `1002` | Retain getters/setters/this/ToString and develop their connection to valid state rather than merging with syntax. |
| `1003` | Retain the CashRegister progression and original Statistics/constructor/state variations. |
| `1004` | Keep the complete Example and Averager development as supporting reading; cross-link its getter/setter/alias explanations at the relevant core concepts without deleting the source lesson. |

### Development Needed Before Moving Material

Use identity/reference and constructor state traces consistently. Preserve the full old development alongside the newer business examples.

Before a later move, create a cell-level preservation map for these sources, including citations, figures, original code forms, worked traces, guided questions and independent exercise variants. Relocate prerequisite explanations from assignments into content when needed while retaining application requirements and IDs. A consolidated page must still teach its concepts; a split must not create two unsupported outlines. Existing runnable verification records describe earlier work, not verification of this proposal.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `1001_class_syntax.ipynb`: Class Syntax.
- `1002_properties.ipynb`: Properties.
- `1003_class_instance.ipynb`: Instances, State, and Useful Behavior.
- `1004_averager.ipynb`: Averager and Mutable State.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.


## Outcome Gap Repair (2026-10-17)

Preserve the current chapter notebooks, reading order, existing explanations, exercise variants, and assessment identifiers. The additions below close the outcome audit gaps within that organization. Explanations belong in content before independent application; earlier scaffolded tasks remain available.

| Location | Development or assessment |
| --- | --- |
| `1001_class_syntax.ipynb` | A Variable Number of Arguments |

Progression: read the relevant lesson and worked example, complete its guided practice, then attempt the added independent homework without copying the solution. Require contract-derived expected results, boundary evidence, and reasoning about the chosen representation or design. Assess process and explanation as well as output. Existing labs remain scaffolded applications rather than the sole evidence of independent mastery.

Lecture decks remain a separately tracked task. No additional chapter, meeting, or required optional-topic track is introduced.

### Verified Topic-to-Assessment Progression

| Topic/outcome | Explanation and worked example | Guided preparation | Independent evidence |
| --- | --- | --- | --- |
| Parameter arrays and overload contrast | 1001_class_syntax: params-array syntax, empty/existing-array examples, overload distinction | Threshold-count method with final parameter array | Original SumManyArgs and two/three-argument overload tasks retained; their first explanation now lives in content. |

Keep the original five-question coding tracks and smaller historical variations. Added transfer tasks complement them. Grade implementation, independently derived expected results, and the requested reasoning separately; correct output from a supplied class does not establish algorithm construction.


## Subsection Integration (2026-10-17)

This is the current internal teaching order for the repaired pages. Earlier outlines remain historical where they differ. Chapter/section notebook order is unchanged. All original explanations, examples, exercises, code outputs, assessment identifiers, and link destinations are retained.

### `1001_class_syntax.ipynb`

- Overview
- Declaring Classes
- Using a Class
- Constructors
- Static Classes & Methods
- A Variable Number of Arguments
- Tuples: When a Class Is Too Much
  - Creating Tuples
  - Returning Multiple Values
  - Destructuring
  - Tuples in Collections
  - Tuples or Classes?

Treat syntax, examples, and meaningful variations as children of their conceptual topic. Place prerequisite explanations before application, and distinguish a local checkpoint from later synthesis. Preserve distinct older/newer treatments by grouping them rather than deleting them. Keep the final Footnotes group after instructional content.

## Legacy Page Development (2026-10-18)

`1001_class_syntax.ipynb` and `1002_properties.ipynb` were developed in place from the content-development audit (`authoring/content_development_audit/`). 10.1 gained runnable worked examples with output interpretation for Declaring Classes (`Customer`), Using a Class (`DoMath` as top-level statements beside the project-form pattern), Constructors (`Contact` with a redeclared-field mistake), and Static Classes (`SomeMath` beside `Math`), plus a guided Product-class practice with solution; its three bracketed citations became footnotes. 10.2 lost its stale "will be updated later" note and gained a syntax-first introduction to auto-implemented, read-only, computed, and full properties with a runnable example, runnable versions of Contact v1 (getters), `this`, and Contact v2 (setters and ToString), a new subsection Properties Replace Getters and Setters with a validating setter, and a guided email-validation practice; the indented prose and the unterminated output fence in the ToString section were repaired and the stray footnote text removed. Legacy indented code is now labeled ```csharp or ```text fences. All 13 new code cells compile and run standalone (.NET 10).

## Caption-Only Section Development (2026-10-18)

Pass 3 of the content-development audit: the three CashRegister sections of 10.3 gained output interpretation after each cell with a variation to try (static fields, assigning a private-set property, storing the average). No code changed; cells were rerun to confirm the outputs.
