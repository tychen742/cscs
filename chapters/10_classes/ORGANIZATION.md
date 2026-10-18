# Organization: Classes and Objects

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `1001_class_syntax.ipynb` | Class Syntax | Core content |
| `1002_properties.ipynb` | Properties | Core content |
| `1003_class_instance.ipynb` | Instances, State, and Useful Behavior | Core content |
| `1004_averager.ipynb` | Averager and Mutable State | Supporting reading |

Keep the current section boundaries and recently developed content. Consolidate repeated in-page navigation, distinguish repeated practice headings, retain all substantive explanations/examples and finish the instructional material before the final Footnotes group.

Teach the section conceptual framework before detailed application; place syntax prerequisites before reasoning that requires them. Keep the new worked traces and guided checkpoints, followed by existing lab/homework transfer. Reading count does not set a meeting or word quota.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Objectives

Define classes and instances; initialize valid state with constructors; distinguish instance and static members; protect state with fields, properties, and methods; and use objects through a controlled public surface.

## Class Meetings

1. Class syntax and construction (35 minutes): create products/accounts, initialize state, and distinguish per-instance from shared members.
2. Properties and methods (40 minutes): getters/setters, this, validation, and useful ToString representations.
3. Instances and state (35 minutes): trace independent objects, maintain invariants, and practice the coffee-register lab.

Total: 110 minutes including examples, traces, and practice. Preview, connected register lab, and homework accompany the chapter. Existing assignment cells and IDs are preserved.

## Boundaries

Object collaboration, copy depth, and composition move into Chapter 11. Inheritance, interfaces, and polymorphism follow in Chapter 12. Operator overloading is an optional appendix extension, not a required fourth section. Existing demonstrations stay in `demos/10/`.


## Instance Lesson Refresh

The third lesson now uses a single runnable CashRegister model: independent state, properties, validation, calculated average, and reset behavior. Homework follows five true/false and five standalone coding tasks. The existing connected coffee-register lab is retained.

## Assignment Alignment (2026-10-15)

- Preview checks ten core terms before class without requiring code tracing.
- Lab connects five coffee-register stages; complete cell-local setup avoids hidden execution state. Students distinguish local, instance, and static storage and protect cashier state.
- Homework transfers constructor, property, validation, static-member, and reporting skills to new business tasks. Five concept cases precede five coding questions.
- Book List is optional after Chapter 11 because its collection-owning class crosses this chapter's collaboration boundary. Its existing URL and TOC placement are retained.

The three core lessons and 110-minute teaching plan are unchanged. This pass completes the standard Chapter 10 assignment revision; slides remain pending.

## Reliability Progression (2026-10-16)

Connect constructors and methods to observable state and repeatable tests. Check required inputs; Chapter 11 develops deeper nullable contracts and optional references. This is the current teaching plan; this structural pass does not claim a new practice or assessment implementation.

## Restored CS1 Material (2026-10-17)

- `assignments/additional_practice.ipynb`: restored explanations and exercises; retains current lessons and assignment IDs.

## CS1 Preservation Follow-up (2026-10-17)

Supporting `1004_averager.ipynb` retains the complete original Example getter/setter/alias client and contract-first Averager explanation, algebra, client output, and implementation. Current CashRegister/Statistics remain. Extra Practice retains all ten original Classes review prompts and complete overloaded Sum/SumManyArgs/params tasks. This is supporting reading, not an added required meeting.

## Section-Boundary Review (2026-10-17)

**Status: implemented.** The following records the reviewed recommendation and its baseline. See Implemented Reading Organization below for the final current filenames and order; earlier meeting allocations are historical where they conflict.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `1001_class_syntax.ipynb`: Class Syntax | Core content | 1,620 | 20 | 4 |
| `1002_properties.ipynb`: Properties | Core content | 1,959 | 14 | 2 |
| `1003_class_instance.ipynb`: Instances, State, and Useful Behavior | Core content | 958 | 22 | 6 |
| `1004_averager.ipynb`: Averager and Mutable State | Supporting reading | 908 | 13 | 3 |

**Recommendation:** Retain core progression and Averager support.

Class construction, encapsulation, and tracing state through clients have distinct purposes. The retained Averager is supporting development of the same ideas, not an additional required introductory lesson.

### Proposed Reading Sequence

1. Classes, objects, and construction.
2. Controlled state through properties and behavior.
3. Independent instances, state traces, and model checks.

### Adequacy Before Reorganization

Use identity/reference and constructor state traces consistently. Preserve the full old development alongside the newer business examples.

Retain the supporting readings identified above outside the required core. Reading sections and class meetings are different units; allocate discussion and practice after developing adequate explanations. Do not reduce distinct material to meet a section or word quota.

Preserve every existing explanation, exercise variation and assessment identity. The source-to-destination dispositions in MATERIALS.md govern any later move. Update TOC, links and redirects only in an authorized implementation pass.

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

10.1 and 10.2 now follow the section pattern: explanation, labeled syntax pattern, runnable worked example, output interpretation, a common mistake, and guided practice. The getter and setter subsections of 10.2 are kept as the explanation of what accessors do and are followed by the property form students should write. No headings, cell IDs, or exercise IDs were removed.
