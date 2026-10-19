---
orphan: true
---

# Chapter Materials — ADTs

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `1301_adt_contracts.ipynb` | ADT Contracts | Core content |
| `1302_representations_costs.ipynb` | Representations and Costs | Core content |
| `1303_generics.ipynb` | Generics for Reusable ADTs | Core content |
| `1304_iterators.ipynb` | Iterators | Core content |

Keep the current section boundaries and recently developed content. Consolidate repeated in-page navigation, distinguish repeated practice headings, retain all substantive explanations/examples and finish the instructional material before the final Footnotes group.

No assessment identity, assignment notebook, worked code, output or exercise variant is removed. `authoring/integration_cleanup/` records the original cells, exact edits, moves and URL/fragment compatibility.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Active Notebooks

- `1300_abstract_data_types.ipynb` — Chapter landing page
- `1301_adt_contracts.ipynb` — ADT contracts, interfaces, and invariants
- `1302_representations_costs.ipynb` — representations, references, and operation costs
- `1303_generics.ipynb` — Generics
- `1304_iterators.ipynb` — IEnumerable/IEnumerator, `yield return`, and custom foreach-able types

## Non-TOC Source Material

- The older `1101-intro-ds.ipynb` and `1102-collection-examples.ipynb` source notebooks were removed on 2026-10-04 after their material was placed in Chapters 8, 10, and 16.

## Sequence

- abstract data types as behavior contracts
- interfaces, invariants, and client-code boundaries
- representations, references, and memory diagrams
- operation-cost comparisons
- generic types and reusable ADT code
- iterators: `IEnumerable<T>`/`IEnumerator<T>`, `yield return`, custom foreach-able types

## Sources

Expand this chapter into a true ADT and implementation foundation for the DSA
course.

## Coverage Gaps

The active notebooks and assignment set now provide first-pass ADT framing.
Later passes should add more worked examples and improve any browser grading
metadata.

## Foundation Placement (2026-10-07)

Chapter 13 now teaches input size, Big-O growth, tight-bound vocabulary, amortized costs, and auxiliary space before collection-cost notation. Formal inequalities and recurrences remain in Chapter 21.

## Move Verification (2026-10-07)

The four receiving sections contain 21 completed cells. Each compiled and ran in an isolated namespace with its own setup under .NET 10; completed exercise answers retain captured stdout. Intentional student starters were excluded. The full Jupyter Book build passed with the five previously recorded warnings outside these chapters. New content pages and prerequisite links are included in the TOC and rendered output. Slides remain pending.


## Prerequisite Bridge

The generics lesson distinguishes IComparer<T> ordering from IEqualityComparer<T> identity, explains consistent hashing, and introduces the small lambda/LINQ forms read later. Group this bridge with the iterator lesson within the existing 110-minute plan.

## Section-Boundary Coverage Disposition (2026-10-17)

**Reviewed plan, now implemented:** Retain four roles; develop the foundations. The disposition below records the preimplementation baseline and rationale. See Implemented Reading Organization for the current reading files. Counts in this baseline exclude fenced code from prose; the refreshed inventory is in authoring/content_size/. They flag review needs, not quality scores.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `1301_adt_contracts.ipynb`: ADT Contracts | Core content | 382 | 14 | 1 |
| `1302_representations_costs.ipynb`: Representations and Costs | Core content | 683 | 17 | 3 |
| `1303_generics.ipynb`: Generics for Reusable ADTs | Core content | 556 | 14 | 6 |
| `1304_iterators.ipynb`: Iterators | Core content | 541 | 9 | 2 |

### Source-to-Destination Plan

| Existing source | Proposed treatment and coverage to preserve |
| --- | --- |
| `1301` | Expand the contract/client boundary before implementation is shown. |
| `1302` | Retain representation diagrams, array/linked alternatives and basic counts/Big-O; do not shift all cost explanation to Chapter 21. |
| `1303` | Retain authoring generic types and constraints. Develop comparer/equality policy carefully and label lambda/LINQ syntax as a prerequisite bridge, not an unexplained prerequisite to the first generic class. |
| `1304` | Retain a dedicated iterator lesson with construction, MoveNext/yield trace and laziness; connect it to the same ADT. |

### Development Needed Before Moving Material

Use one contract across client, alternate representations, generic implementation and enumeration. Add worked transitions and counterexamples before independent implementation.

Before a later move, create a cell-level preservation map for these sources, including citations, figures, original code forms, worked traces, guided questions and independent exercise variants. Relocate prerequisite explanations from assignments into content when needed while retaining application requirements and IDs. A consolidated page must still teach its concepts; a split must not create two unsupported outlines. Existing runnable verification records describe earlier work, not verification of this proposal.

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

## Caption-Only Section Development (2026-10-18)

Pass 3 of the content-development audit. Generic Methods and Generic Classes in 13.3, previously bare code cells, gained the generic-method and generic-class declaration patterns, explanations of type inference and explicit type arguments, output interpretation, and the mistakes of mixed-type calls and omitting the class type argument; Type Constraints gained interpretation of why the `where` clause is required; Generic Interfaces gained a runnable `ArrayStack<T> : IStack<T>` example (compiles and runs standalone, .NET 10).

## OpenDSA Gap List and Development (2026-10-19)

Pass 8 (`authoring/content_development_audit/pass8_cs2_opendsa_development.md`) compared the four sections with OpenDSA CS2 1.1 Data Structures and Algorithms, 1.2 Abstract Data Types, 3.1 A List ADT, 4.3 Best, Worst, and Average Cases, 10.2 Comparison of List Implementations, and the CS3 Comparing Records and List Element Implementations pages. Concepts, explanations, and exercise types OpenDSA has that this chapter lacked or treated in under 100 words:

| Gap | OpenDSA treatment | Where it is now developed |
| --- | --- | --- |
| Type, data item, data type, ADT, data structure as a vocabulary chain; "array" as both type and implementation | 1.2 definitions | 13.1 What an ADT Specifies (table and dictionary example) |
| ADT versus implementation with a dictionary example (sorted array, hash table, BST behind one contract) | 1.2 Example 1.2.2 | 13.1 What an ADT Specifies |
| Interface syntax as a pattern; output interpretation of the interface example | 3.1 List interface | 13.1 Interfaces as Contracts (was 28 words) |
| Client code against two implementations | 3.1, 3.2 | 13.1 Client Code Depends on Behavior (runnable `CountUndoable`) |
| Precondition, postcondition, invariant distinction | 1.2 "behavior determined by inputs and outputs" | 13.1 Contracts Include Rules (table) |
| Selecting a data structure: operations, resource constraints, choice; the three workload questions | 1.1.3 | 13.1 Selecting a Data Structure (new) |
| Array-backed and linked representations explained before the code, with output read | 6.1, 6.2 stacks | 13.2 Array-Backed Stack (was 38 words), Linked Nodes and References (was 54 words) |
| Best, worst, and average cases with linear search | 4.3 | 13.2 Best, Worst, and Average Cases (new, runnable comparison counts) |
| Space comparison and break-even point between array and linked storage | 10.2.1 | 13.2 Operation Costs (formula and runnable table) |
| Runtime versus compile-time failure of untyped storage | CS3 List Element Implementations | 13.3 Why Generics Exist (was 53 words, runnable) |
| Records found by key; homogeneity; key-value pairs | CS3 Comparing Records, List Element Implementations | 13.3 Records, Keys, and Homogeneity (new, `KeyedList<TKey, TValue>`) |
| Enumerator as a position object; laziness shown with output | 3.1 iterator design note | 13.4 Writing the Enumerator by Hand (new), Iterators Are Lazy (runnable) |
| Exercise types: code tracing, code completion, growth-rate ordering, concept recall, summary questions | 1.2.2, 4.2.2, 7.3, 7.8, review questions | Listed below |

Exercises added, in our own words and C#: code tracing (13.1 Follow a Stack History, 13.2 Array Stack State, 13.4 Predict the Interleaving), code completion (13.3 A Generic Last Element, 13.4 Count Down), growth-rate ordering (13.2), concept recall with dropdown answers (13.1 ADT or data structure, 13.3 Which Constraint Does the Body Need?), and a Check Your Understanding block of four questions with dropdown answers at the end of every section. Every new code cell was compiled and run standalone under .NET 10 and carries its stored output; starters are tagged `exercise`, solutions `hide-input`. No existing cell, heading, exercise ID, or footnote was removed. No OpenDSA text, code, or figure was copied.
