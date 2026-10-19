# Organization: Inheritance, Interfaces, and Polymorphism

## Core Depth Revision (2026-10-19)

C11: add a learner prediction and declared-type/actual-object/override/base-call/result trace beside the existing policy example. Preserve current interface/test-double progression and the optional OOP examples.

This current arrangement supersedes conflicting historical outlines below. Assignments and optional/supporting readings are unchanged. Existing explanations, examples, exercise identities and published paths are preserved. Verification and cell-preservation evidence are recorded in `authoring/core_depth_revision/`.

## Objectives and Prerequisites

Build on Chapters 10-11: class construction, validated state, references, composition, and model tests. Explain inheritance and substitution, virtual dispatch, abstract classes, interfaces, and constructor-supplied collaborators.

## Class Meetings

1. Inheritance and substitution (35 minutes): is-a versus has-a, access, constructor chaining, base validation, and result contracts.
2. Runtime polymorphism (35 minutes): base references, virtual/override, overloading distinction, abstract members, and shared checks.
3. Interfaces and interchangeable components (40 minutes): small capability contracts, constructor injection, test doubles, and design selection.

Total: 110 minutes, including traces, predictions, design discussion, and examples.

## Assessment

Ten vocabulary MC preview questions; five connected discount/checkout lab tasks; five workplace true/false cases and five independent coding transfers for homework. Solutions retain executed outputs. Existing assignment notebook metadata and cell IDs are preserved where possible; new question IDs are semantic and stable.

## Boundaries

Keep interfaces as small capabilities, avoid deep hierarchies, and distinguish compile-time overload selection from runtime override dispatch. Generic ADTs follow in Chapter 13. Modern interface extensions and equality/operator overloading are optional. Retain the existing video; slides remain pending.

## Reliability Progression (2026-10-16)

Revisit failure and nullability contracts through interfaces and polymorphic callers; preserve promised behavior for every implementation. This is the current teaching plan; this structural pass does not claim a new practice or assessment implementation.

## CS1 Preservation Follow-up (2026-10-17)

Supporting `1204_oop_examples.ipynb` retains original paradigm/pillar/separation-of-concerns context and Vehicle/Car, hiding/override, numeric/string/arity overloads, base/sealed and abstract-animal variations, plus a corrected abstract-class/interface table. Extra Practice retains all original Student/property and Shape/GetArea review tasks. Current policy/payment/checkout examples, assessments and three meetings remain.

The final source-list check also retains the original named array, reversal, and small abstract/interface variations in the corresponding supporting practice; see the preservation matrix for exact locations.

## Section-Boundary Review (2026-10-17)

**Status: implemented.** The following records the reviewed recommendation and its baseline. See Implemented Reading Organization below for the final current filenames and order; earlier meeting allocations are historical where they conflict.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `1201_inheritance.ipynb`: Inheritance and Substitution | Core content | 757 | 17 | 4 |
| `1202_polymorphism.ipynb`: Runtime Polymorphism and Abstract Classes | Core content | 732 | 17 | 4 |
| `1203_interfaces.ipynb`: Interfaces and Interchangeable Components | Core content | 753 | 17 | 5 |
| `1204_oop_examples.ipynb`: OOP Examples and Variations | Supporting reading | 1,724 | 22 | 6 |

**Recommendation:** Retain the three conceptual boundaries.

The three core pages are short but represent different reasoning tasks. Combining them would obscure substitution, dynamic dispatch and capability contracts rather than solve underdevelopment.

### Proposed Reading Sequence

1. Inheritance and substitution.
2. Runtime dispatch and abstract classes.
3. Interfaces and interchangeable collaborators.

### Adequacy Before Reorganization

Add slower worked client-call reasoning, common failures and guided design comparisons. Supporting examples do not replace core explanation.

Retain the supporting readings identified above outside the required core. Reading sections and class meetings are different units; allocate discussion and practice after developing adequate explanations. Do not reduce distinct material to meet a section or word quota.

Preserve every existing explanation, exercise variation and assessment identity. The source-to-destination dispositions in MATERIALS.md govern any later move. Update TOC, links and redirects only in an authorized implementation pass.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `1201_inheritance.ipynb`: Inheritance and Substitution.
- `1202_polymorphism.ipynb`: Runtime Polymorphism and Abstract Classes.
- `1203_interfaces.ipynb`: Interfaces and Interchangeable Components.
- `1204_oop_examples.ipynb`: OOP Examples and Variations.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.


## Outcome Gap Repair (2026-10-17)

Preserve the current chapter notebooks, reading order, existing explanations, exercise variants, and assessment identifiers. The additions below close the outcome audit gaps within that organization. Explanations belong in content before independent application; earlier scaffolded tasks remain available.

| Location | Development or assessment |
| --- | --- |
| `homework.ipynb` | Justify a Substitution and Composition Decision |

Progression: read the relevant lesson and worked example, complete its guided practice, then attempt the added independent homework without copying the solution. Require contract-derived expected results, boundary evidence, and reasoning about the chosen representation or design. Assess process and explanation as well as output. Existing labs remain scaffolded applications rather than the sole evidence of independent mastery.

Lecture decks remain a separately tracked task. No additional chapter, meeting, or required optional-topic track is introduced.

### Verified Topic-to-Assessment Progression

| Topic/outcome | Explanation and worked example | Guided preparation | Independent evidence |
| --- | --- | --- | --- |
| Substitution and composition judgment | 1202_polymorphism and 1203_interfaces existing contracts and examples | Existing interface implementation practice | New exporter/destination design requires independently chosen contracts, two implementations, a recording collaborator, and failure-policy reasoning. |

Keep the original five-question coding tracks and smaller historical variations. Added transfer tasks complement them. Grade implementation, independently derived expected results, and the requested reasoning separately; correct output from a supplied class does not establish algorithm construction.

## Guided Practice Pass (2026-10-18)

Pass 4 of the content-development audit (`authoring/content_development_audit/`): added a mid-page guided practice with solution to the supporting 12.4 (add a Truck subclass). Every new starter and solution compiles and runs standalone (.NET 10); starters that are meant to fail say so in their task text. No existing cell, heading, or exercise ID was removed.
