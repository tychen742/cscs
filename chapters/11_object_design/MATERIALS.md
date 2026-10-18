# Materials: Object Design and Composition

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

No assessment identity, assignment notebook, worked code, output or exercise variant is removed. `authoring/integration_cleanup/` records the original cells, exact edits, moves and URL/fragment compatibility.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Current Priority-Section Coverage (2026-10-17)

This coverage update describes the current notebooks and supersedes older pre-reorganization filename summaries below. Historical plans and verification records are retained.

| Reading | Developed content-section coverage |
| --- | --- |
| `1104_nullability.ipynb` | Distinguish missing/zero/empty, value/reference nullable semantics, annotation/runtime checks, null operators and guided optional-data output. |

Keep the four current core readings and integrate nullability as supporting reading beside references and composition, without adding another required meeting. Struct/record instruction still precedes record use.

All original lesson cells remain, except the explicitly documented presentation/syntax/result corrections and stale chapter references in `authoring/priority_development/source_corrections.json`. Original assignment notebooks and exercise IDs remain untouched. Full standalone code is retained beside the new smaller teaching cores; newly added code verification is recorded separately from historical checks.


Active notebooks: `1100_object_design`, `1101_objects_references`, `1102_composition`, and `1103_testing_collaboration`.

Assignments: `assignments/index.ipynb`, `preview.ipynb`, `lab.ipynb`, and `homework.ipynb`. The lab builds one order model; homework transfers the ideas to other business models. Source and runnable checks live in `demos/11/object_design/`. All code cells provide their own imports, setup, and complete type definitions.

No database, inheritance, interfaces, LINQ, or custom equality operators are prerequisites. Lecture slides and a chapter video are pending.

## Nullability Supporting Reading (2026-10-16)

`1104_nullability.ipynb` moved from Chapter 6 with code/cell metadata intact. It covers nullable value/reference types, compiler warnings, null operators, and optional object relationships. Integrate the reading within the existing three meetings. 1101 now introduces struct and record syntax before the supporting reading uses records. Property-pattern and LINQ examples remain extension material. Add missing-data tests and align relocated assessment items in the next content/assessment pass. Old nullable-lesson URLs redirect to this page.

## Struct and Record Introduction (2026-10-17)

1101 adds three independent runnable examples for readonly struct copying/default values, record-class equality/with, and readonly record structs. Microsoft language-reference citations appear in the section footnotes. Existing notebook order and assignments remain unchanged.

## Section-Boundary Coverage Disposition (2026-10-17)

**Reviewed plan, now implemented:** Split reference semantics from struct/record design. The disposition below records the preimplementation baseline and rationale. See Implemented Reading Organization for the current reading files. Counts in this baseline exclude fenced code from prose; the refreshed inventory is in authoring/content_size/. They flag review needs, not quality scores.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `1101_objects_references.ipynb`: Objects, References, and State | Core content | 1,638 | 26 | 8 |
| `1102_composition.ipynb`: Composition and Object Responsibilities | Core content | 892 | 18 | 5 |
| `1103_testing_collaboration.ipynb`: Testing and Refactoring Collaborating Objects | Core content | 928 | 18 | 4 |
| `1104_nullability.ipynb`: Nullability and Missing Data | Supporting reading | 325 | 10 | 4 |

### Source-to-Destination Plan

| Existing source | Proposed treatment and coverage to preserve |
| --- | --- |
| `1101` | Split references/identity/mutation/copy-depth from struct/record/record-struct syntax, defaults, equality and with; teach the first before the second. Keep type-specific shallow-copy cautions beside the corresponding examples. |
| `1102` | Retain composition and collection ownership; incorporate required/optional reference and constructor-guard explanations from 1104 where they are used. |
| `1103` | Retain collaboration checks, rejected mutation and refactoring; add missing-data checks tied to the taught contracts. |
| `1104` | Distribute core nullable value/reference and flow-warning explanation into references and composition. Retain null-operator, pattern and advanced query variants as supporting reading; do not discard any original example. |

### Development Needed Before Moving Material

Expand structs/records beyond a quick syntax comparison and develop null versus empty/zero, annotations versus runtime guards, and shallow-copy consequences before exercises.

Before a later move, create a cell-level preservation map for these sources, including citations, figures, original code forms, worked traces, guided questions and independent exercise variants. Relocate prerequisite explanations from assignments into content when needed while retaining application requirements and IDs. A consolidated page must still teach its concepts; a split must not create two unsupported outlines. Existing runnable verification records describe earlier work, not verification of this proposal.

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

Pass 3 of the content-development audit: in 11.5 Nullability the nullable value, nullable reference, and null-operator sections gained output interpretation and the mistakes of reading `.Value` when empty, silencing warnings with `!`, and expecting a non-nullable result from `?.`; Pattern Matching and Null gained a runnable switch-expression example over three samples (compiles and runs standalone, .NET 10).
