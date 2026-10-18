# Organization: Classes and Objects

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
