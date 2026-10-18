---
orphan: true
---

# Chapter Organization — ADTs

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `1301_adt_contracts.ipynb` | ADT Contracts | Core content |
| `1302_representations_costs.ipynb` | Representations and Costs | Core content |
| `1303_generics.ipynb` | Generics for Reusable ADTs | Core content |
| `1304_iterators.ipynb` | Iterators | Core content |

Keep the current section boundaries and recently developed content. Consolidate repeated in-page navigation, distinguish repeated practice headings, retain all substantive explanations/examples and finish the instructional material before the final Footnotes group.

Teach the section conceptual framework before detailed application; place syntax prerequisites before reasoning that requires them. Keep the new worked traces and guided checkpoints, followed by existing lab/homework transfer. Reading count does not set a meeting or word quota.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Learning Objectives

Students should be able to define an abstract data type, distinguish an
interface from an implementation, trace references and object state, use
generics to write reusable data-structure code, and implement `IEnumerable<T>`
with `yield return` so a custom type supports `foreach`.

## Sequence

- ADT contracts, interfaces, client code, and invariants
- Representations, linked references, and operation-cost comparisons
- Generics, type constraints, and reusable ADT implementations
- Iterators: why `foreach` works, `yield return`, custom `IEnumerable<T>` types, lazy evaluation

## Book Scope Note

Added 2026-09-20: this book now spans two semesters in one volume, so this
chapter is not limited to "intro course" depth. Iterators (`yield return`,
custom `IEnumerable<T>`) were added as a full section rather than a passing
mention, since they are the natural extension of this chapter's ADT/interface
framing and Chapter 8 (`0801_collections.ipynb`) now forward-references them
here explicitly.

## Integrated Content

The former Generics notebook is now part of this chapter. It should be
connected to the ADT examples by showing how one implementation can support
multiple element types without sacrificing compile-time type checking.

The older `1101-intro-ds.ipynb` and `1102-collection-examples.ipynb` notebooks
were removed on 2026-10-04: their collection overview and `List<T>` basics are in
Chapter 8, stacks and queues in Chapter 15, and tuples in
`10_classes/1001_class_syntax.ipynb`.

## Coverage Gaps

The active chapter now moves from ADT contract to representation tradeoffs to
generic implementation. The preview, lab, and homework assignments now align
with this flow. Remaining work: add more worked examples, tune assignment
metadata for any grader integration, and keep the ADT chapter focused on
contracts, representations, operation costs, and generic implementations.

## Foundation Placement (2026-10-07)

Chapter 13 now teaches input size, Big-O growth, tight-bound vocabulary, amortized costs, and auxiliary space before collection-cost notation. Formal inequalities and recurrences remain in Chapter 21.


## Prerequisite Bridge

The generics lesson distinguishes IComparer<T> ordering from IEqualityComparer<T> identity, explains consistent hashing, and introduces the small lambda/LINQ forms read later. Group this bridge with the iterator lesson within the existing 110-minute plan.


## Assignment Refresh

The lab implements one generic undo-history contract. Each coding task supplies all setup and types. Homework transfers empty, value-type, snapshot, and success-signal contracts; hidden solutions retain verified outputs.

## Section-Boundary Review (2026-10-17)

**Status: implemented.** The following records the reviewed recommendation and its baseline. See Implemented Reading Organization below for the final current filenames and order; earlier meeting allocations are historical where they conflict.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `1301_adt_contracts.ipynb`: ADT Contracts | Core content | 382 | 14 | 1 |
| `1302_representations_costs.ipynb`: Representations and Costs | Core content | 683 | 17 | 3 |
| `1303_generics.ipynb`: Generics for Reusable ADTs | Core content | 556 | 14 | 6 |
| `1304_iterators.ipynb`: Iterators | Core content | 541 | 9 | 2 |

**Recommendation:** Retain four roles; develop the foundations.

Contracts, representations, generics and iterators are distinct foundations for CS2. Their low counts do not make them redundant; merging them now would conceal missing development.

### Proposed Reading Sequence

1. ADT behavior and contracts.
2. Representations, invariants, and elementary costs.
3. Defining reusable generic types and policies.
4. Iteration contracts and lazy traversal.

### Adequacy Before Reorganization

Use one contract across client, alternate representations, generic implementation and enumeration. Add worked transitions and counterexamples before independent implementation.

Reading sections and class meetings are different units; allocate discussion and practice after developing adequate explanations. Do not reduce distinct material to meet a section or word quota.

Preserve every existing explanation, exercise variation and assessment identity. The source-to-destination dispositions in MATERIALS.md govern any later move. Update TOC, links and redirects only in an authorized implementation pass.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `1301_adt_contracts.ipynb`: ADT Contracts.
- `1302_representations_costs.ipynb`: Representations and Costs.
- `1303_generics.ipynb`: Generics for Reusable ADTs.
- `1304_iterators.ipynb`: Iterators.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.


## Outcome Gap Repair (2026-10-17)

Preserve the current chapter notebooks, reading order, existing explanations, exercise variants, and assessment identifiers. The additions below close the outcome audit gaps within that organization. Explanations belong in content before independent application; earlier scaffolded tasks remain available.

| Location | Development or assessment |
| --- | --- |
| `homework.ipynb` | Implement a Generic Iterator and Explain Its Costs |

Progression: read the relevant lesson and worked example, complete its guided practice, then attempt the added independent homework without copying the solution. Require contract-derived expected results, boundary evidence, and reasoning about the chosen representation or design. Assess process and explanation as well as output. Existing labs remain scaffolded applications rather than the sole evidence of independent mastery.

Lecture decks remain a separately tracked task. No additional chapter, meeting, or required optional-topic track is introduced.

### Verified Topic-to-Assessment Progression

| Topic/outcome | Explanation and worked example | Guided preparation | Independent evidence |
| --- | --- | --- | --- |
| Generic iterator implementation and laziness | 1303_generics and 1304_iterators existing worked examples; ref prerequisite linked | Existing CountDown, Pair<T>, First<T>, and Swap<T> practice | New EveryOther<T> homework implements yield logic, tests empty/singleton/odd/even/repeated enumeration, and instruments partial consumption. |
| Growth cost and storage evidence | 1302_representations_costs existing growth/amortized tables | Existing representation comparisons | New independent capacity-one doubling trace derives copy total rather than only naming amortized complexity. |

Keep the original five-question coding tracks and smaller historical variations. Added transfer tasks complement them. Grade implementation, independently derived expected results, and the requested reasoning separately; correct output from a supplied class does not establish algorithm construction.
