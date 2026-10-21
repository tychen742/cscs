# Organization: Object Design and Composition

## Core Depth Revision (2026-10-19)

C10: add one order/line/shared-product graph and a before/after table for outer copies, nested mutation and deliberate immutable sharing. Reuse that graph from the core records and composition lessons. Preserve every existing example and the optional nullability reading.

This current arrangement supersedes conflicting historical outlines below. Assignments and optional/supporting readings are unchanged. Existing explanations, examples, exercise identities and published paths are preserved. Verification and cell-preservation evidence are recorded in `authoring/core_depth_revision/`.

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `1101_objects_references.ipynb` | References, Identity, and Copying | Core content |
| `1105_value_record_types.ipynb` | Structs, Records, and Data Models | Core content |
| `1102_composition.ipynb` | Composition and Object Responsibilities | Core content |
| `1103_testing_collaboration.ipynb` | Testing and Refactoring Collaborating Objects | Core content |
| `1104_nullability.ipynb` | Nullability and Missing Data | Supporting reading |

Keep the current section boundaries and recently developed content. Consolidate repeated in-page navigation, distinguish repeated practice headings, retain all substantive explanations/examples and finish the instructional material before the final Footnotes group.

Teach the section conceptual framework before detailed application; place syntax prerequisites before reasoning that requires them. Keep the new worked traces and guided checkpoints, followed by existing lab/homework transfer. Reading count does not set a meeting or word quota.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Current B-A Teaching Progression (2026-10-17)

This is the current progression within the existing section order; earlier meeting outlines below are historical where they conflict. Readings are not additional required meetings.

Keep the four current core readings and integrate nullability as supporting reading beside references and composition, without adding another required meeting. Struct/record instruction still precedes record use.

| Reading | Developed content-section coverage |
| --- | --- |
| `1104_nullability.ipynb` | Distinguish missing/zero/empty, value/reference nullable semantics, annotation/runtime checks, null operators and guided optional-data output. |

**Conceptual framework:** motivate the result contract and connect the new operation to prior control flow, state, representation or algorithm ideas.

**Subsection development:** use the new small trace and standalone worked example before the complete retained implementation. Interpret the saved output, vary an assumption and diagnose a plausible mistake. Syntax scaffolds are patterns, not hidden executable prerequisites.

**Practice progression:** Predict missing versus zero/empty values; interpret conditional access and fallbacks; replace warning suppression with a runtime boundary guard. Apply required/optional relationship rules in the existing object-design assignments; LINQ/pattern tasks remain extensions.

Keep prerequisite explanations in these content sections. Labs apply the explained ideas and may scaffold the task; homework increases transfer. No existing explanation, exercise variation, assignment identity or independent-work requirement is removed to fit a time or word quota.


## Objectives

Trace aliases; distinguish identity from business equality; select mutability and sharing policies; compose collaborating classes; preserve collection ownership; and test contracts independently of console input.

## Class Meetings

1. Objects, references, and state (40 minutes): reference diagrams, parameter passing, identity and SKU equality, mutability, immutability, copy depth, and nullable value/reference distinctions and flow warnings.
2. Composition and responsibilities (35 minutes): products, lines, orders, validation boundaries, computed totals, safe snapshots, required versus optional references, and constructor null guards.
3. Testing collaboration (35 minutes): arrange/act/assert, boundary tables, rejected changes, independent orders, refactoring a parallel-list design, and tests of rejected nulls and absent optional data.

Total: 110 minutes including prediction, traces, discussion, and code inspection. Assignments add guided and independent practice.

## Assessment

Preview: ten vocabulary multiple-choice items. Lab: five connected order-model tasks. Homework: five workplace true/false cases and five transfer coding tasks. Coding question cells are followed by hidden solutions with executed output. IDs use `cscs-object-design-*` and do not depend on future chapter numbering.

## Boundaries

Products and lines are immutable; each order owns its list. Repeated products create separate lines; SKU matching is case-sensitive. Snapshots copy the outer collection and share fixed line/product objects. Keep inheritance and interfaces in Chapter 12 and persistence in the optional database appendix. Video and slides remain pending.

## Nullability Supporting Reading (2026-10-16)

`1104_nullability.ipynb` relocates the deeper discussion from Chapter 6. Use its value/reference distinction and compiler warnings in meeting one, then conditional access and optional relationships in meeting two; integrate missing-data checks in meeting three. It is supporting reading, not a fourth required meeting. Keep basic null checks in earlier chapters. Explain that nullable annotations do not enforce runtime validity, null differs from empty/zero, and `!` suppresses warnings without validating data.

The relocated page retains existing code and cell metadata. Struct and record introductions now precede the relocated record example in 1101; retain its record syntax and link back to that introduction. Advanced LINQ/pattern exercises remain extension material, not prerequisites. Add missing-data examples/tests and transfer appropriate assessment items with their original IDs before claiming complete assessment alignment. Core generics remain in Chapter 13; library generic collections can be read using the Chapter 8 foundation.

## Value and Record Types (2026-10-17)

Within meeting one, 1101 introduces readonly structs, default values, positional record classes, init-only properties, with expressions, record structs, and the distinction between copying and equality. Integrate the prediction examples into the existing references/mutability discussion; no section notebook or meeting is added. Keep ordinary classes in composition and collaboration examples.

## Section-Boundary Review (2026-10-17)

**Status: implemented.** The following records the reviewed recommendation and its baseline. See Implemented Reading Organization below for the final current filenames and order; earlier meeting allocations are historical where they conflict.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `1101_objects_references.ipynb`: Objects, References, and State | Core content | 1,638 | 26 | 8 |
| `1102_composition.ipynb`: Composition and Object Responsibilities | Core content | 892 | 18 | 5 |
| `1103_testing_collaboration.ipynb`: Testing and Refactoring Collaborating Objects | Core content | 928 | 18 | 4 |
| `1104_nullability.ipynb`: Nullability and Missing Data | Supporting reading | 325 | 10 | 4 |

**Recommendation:** Split reference semantics from struct/record design.

1101 now teaches both reference/alias semantics and several new type forms. A proper struct/record introduction has its own syntax, copy/equality reasoning and selection decisions. The short nullability page should support relevant object contracts rather than stand alone as another required meeting.

### Proposed Reading Sequence

1. References, identity, mutation, and copying.
2. Structs, records, and selecting a data model.
3. Composition, ownership, and optional relationships.
4. Testing collaborating objects.

### Adequacy Before Reorganization

Expand structs/records beyond a quick syntax comparison and develop null versus empty/zero, annotations versus runtime guards, and shallow-copy consequences before exercises.

Retain the supporting readings identified above outside the required core. Reading sections and class meetings are different units; allocate discussion and practice after developing adequate explanations. Do not reduce distinct material to meet a section or word quota.

Preserve every existing explanation, exercise variation and assessment identity. The source-to-destination dispositions in MATERIALS.md govern any later move. Update TOC, links and redirects only in an authorized implementation pass.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `1101_objects_references.ipynb`: References, Identity, and Copying.
- `1105_value_record_types.ipynb`: Structs, Records, and Data Models.
- `1102_composition.ipynb`: Composition and Object Responsibilities.
- `1103_testing_collaboration.ipynb`: Testing and Refactoring Collaborating Objects.
- `1104_nullability.ipynb`: Nullability and Missing Data.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.


## Outcome Gap Repair (2026-10-17)

Preserve the current chapter notebooks, reading order, existing explanations, exercise variants, and assessment identifiers. The additions below close the outcome audit gaps within that organization. Explanations belong in content before independent application; earlier scaffolded tasks remain available.

| Location | Development or assessment |
| --- | --- |
| `homework.ipynb` | Choose and Verify Value and Record Semantics |

Progression: read the relevant lesson and worked example, complete its guided practice, then attempt the added independent homework without copying the solution. Require contract-derived expected results, boundary evidence, and reasoning about the chosen representation or design. Assess process and explanation as well as output. Existing labs remain scaffolded applications rather than the sole evidence of independent mastery.

Lecture decks remain a separately tracked task. No additional chapter, meeting, or required optional-topic track is introduced.

### Verified Topic-to-Assessment Progression

| Topic/outcome | Explanation and worked example | Guided preparation | Independent evidence |
| --- | --- | --- | --- |
| Plain struct, record class, record struct | 1105_value_record_types existing syntax, copy/equality/with examples and comparison | Existing semantic predictions and type-choice practice | New independent fee/parcel/address task verifies ordinary struct copy, record equality versus identity, shallow with, and default values. |
| Composition/refactoring judgment | 1102_composition and 1103_testing_collaboration existing object contracts | Existing order model and collaboration checks | New assessment requires refactoring duplicated address fields while retaining public-behavior regression checks. |

Keep the original five-question coding tracks and smaller historical variations. Added transfer tasks complement them. Grade implementation, independently derived expected results, and the requested reasoning separately; correct output from a supplied class does not establish algorithm construction.

## Caption-Only Section Development (2026-10-18)

11.5 remains a supporting reading; its construct sections now interpret their outputs and the pattern-matching section has a runnable example.

## Visual Support and Part I Shape (2026-10-18)

Pass 6 of the content-development audit (`authoring/content_development_audit/`): 11.1 gained the reference diagrams its prose asks students to draw (alias versus independent objects, before and after the assignment) and a summary table. New code cells compile and run standalone (.NET 10); tables and text diagrams are placed beside the example they explain. No heading, cell ID, or exercise ID changed.

## Enumerations Added (2026-10-21)

`1105_value_record_types.ipynb` ends with Enumerations: A Fixed Set of Named Values, the book's first treatment of `enum` as a value type: an `OrderStatus` example with underlying values, ordering comparison, `switch`, parsing and validation, and value copying. It adds no meeting; the section remains Structs, Records, and Data Models.
