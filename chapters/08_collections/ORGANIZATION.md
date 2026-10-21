---
orphan: true
---

# Chapter Organization — Collections

## Current Lecture Deck (2026-10-21)

The revised chapter deck is `_html_extra/chapters/08_collections/0800_slides.md`. It follows the current reading order with a named part per reading, worked examples and state traces, quick checks, existing exercise links, and instructor notes. Meeting 1: 8.1 and shared operation syntax in 8.2, 35 minutes; meeting 2: lists in 8.3 and shared references in 8.2, 40 minutes; meeting 3: dictionaries in 8.4, 35 minutes. Total 110 minutes. Query reading 8.5 is optional. Reading pages do not add meetings. Optional supporting parts remain unassessed. The chapter landing links the student HTML deck; the former overview remains unchanged for compatibility. Code verification is recorded with `authoring/slide_revision/code_01_08.json`; final render/build evidence is recorded by the shared slide workflow. Assessment identities and assignment notebooks are unchanged.

## Optional Query Reading (2026-10-21)

`0805_querying_collections.ipynb` introduces named predicates, lambdas, Where/OrderBy/Select, materialization, and deferred source reads using primitive decimal lists. It requires no custom classes or database. Original standalone demonstrations and a dispatch-report exercise follow prediction, execution, and boundary checks. No standard assessment or required meeting changes. Chapter 13 retains the delegate/generic-policy treatment.

## Current Teaching Allocation (2026-10-21)

This allocation supersedes earlier meeting estimates where they differ. Core readings remain assigned; a reading page is not a separate meeting. Preparation means reading the relevant explanations and predicting the named example before class.

| Meeting | Minutes | Preparation | Guided class work |
| --- | ---: | --- | --- |
| 1 | 35 | 8.1 and shared operation syntax in 8.2. | Choose positions or keys for a business task and trace creation, lookup, and update behavior. |
| 2 | 40 | 8.3 and traversal/reference passages in 8.2. | Build and update a list, distinguish Count from capacity, and repair mutation during traversal. |
| 3 | 35 | 8.4. | Update stock with a dictionary, handle a missing key, and compare a scan with keyed lookup. |

Total: 110 minutes including predictions, selected code runs, and nearby checks. Lab and homework provide subsequent guided and independent transfer. No additional assessment questions are introduced by this allocation.

The full collection-family/API tables and namespaces are reference material. Later-family implementations remain in their own chapters. Querying Collections with Lambdas and LINQ (8.5) is optional applied reading and adds no required meeting or assessment prerequisite.

## Core Depth Revision (2026-10-19)

C07: follow the compact operation model and generic-type exposure with concrete array/list and dictionary examples, then connect the full retained operation tables to the other family examples. Namespace reference follows the behavior it supports. Later-family examples remain early policy recognition, not new implementation requirements.

This current arrangement supersedes conflicting historical outlines below. Assignments and optional/supporting readings are unchanged. Existing explanations, examples, exercise identities and published paths are preserved. Verification and cell-preservation evidence are recorded in `authoring/core_depth_revision/`.

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `0801_collections.ipynb` | Collection Families and Selection | Core content |
| `0802_collection_operations.ipynb` | Collection Operations and Behavior | Core content |
| `0803_list.ipynb` | Lists | Core content |
| `0804_dictionary.ipynb` | Dictionaries | Core content |
| `0805_querying_collections.ipynb` | Querying Collections with Lambdas and LINQ | Optional applied reading |

Keep the current section boundaries and recently developed content. Consolidate repeated in-page navigation, distinguish repeated practice headings, retain all substantive explanations/examples and finish the instructional material before the final Footnotes group.

Teach the section conceptual framework before detailed application; place syntax prerequisites before reasoning that requires them. Keep the new worked traces and guided checkpoints, followed by existing lab/homework transfer. Reading count does not set a meeting or word quota.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Learning Objectives

Students should be able to choose between arrays, lists, and dictionaries for
common storage tasks; write basic `List<T>` code for growing ordered data; and
write basic `Dictionary<TKey,TValue>` code for key/value lookup. Students should
also recognize eight collection families, explain their access contracts, and
distinguish sharing a collection reference from copying its elements.

## Sequence

- Collections (40 minutes): operations and contracts; a cited eight-family table; access patterns; generic types and namespaces; worked bookstore choices; family demonstrations; traversal and shared references.
  Small, standalone demonstrations introduce behavior before the detailed APIs.
  Sets, linked lists, stacks, queues, and priority queues are recognition-level
  orientation here, not new implementation or required advanced API exercises.
- Lists (`List<T>`, 35 minutes): indexed sequences and practical list operations.
- Dictionaries (`Dictionary<TKey,TValue>`, 35 minutes): key-based storage and lookup.

The three meetings total 110 minutes. Section 8.1 ends with a standalone list/dictionary summary exercise and includes conceptual checks on representation and processing order.

## Notes

- The former source notebooks `0802-list-dictionary`, `1101-intro-ds`, and `1102-collection-examples` were removed 2026-10-04 after review: their list, dictionary, and collection-overview material was already in `0801`–`0803`, stacks and queues live in Chapter 15, `HashSet<T>` in Chapter 19, and the tuples material moved to `10_classes/1001_class_syntax.ipynb`.
- `HashSet<T>` receives a brief behavioral demonstration in 8.1. Its detailed API, hashing, equality, and set operations remain in Chapter 19.
- Recognize LIFO, FIFO, and priority-based access in 8.1; detailed stack/queue work stays in Chapter 15 and heaps/priority queues in Chapter 18. Linked-list implementations stay in Chapter 14.

## Source History

The September 2026 history includes broader `1101-intro-ds` and `1102-collection-examples` notebooks. Their removal during consolidation left 0801 at roughly 740 Markdown words. The 2026-10-16 expansion restores the conceptual introduction with original business examples; it does not restore outdated APIs, tuple material, or implementation lessons. Existing section paths, assessment identifiers, and the three-section chapter sequence are preserved.

The opening develops the whole collection idea before the family examples: shared operations and contracts, the source-cited family map, generic types and library organization, and representation choices. Individual families then illustrate that framework. The table is explicitly adapted from Microsoft Learn, with the source references in the independent Footnotes block.

## Restored Collections Integration (2026-10-17)

The current lab links to `../09_files_text/assignments/help_responses.ipynb` for the full file-driven response lab after Files. List/dictionary loading, random fallback, and separation of data from logic are restored without moving Files earlier.

## Original Lookup Review (2026-10-17)

The original list-search versus dictionary-key lookup review question is explicit in Homework, with expected/worst-case and setup-cost assumptions. Current list/dictionary exercises and file integration remain.

## Arrays and Collection Families (2026-10-17)

Landing pages and opening explanations explicitly classify arrays as collections and connect fixed-length indexed storage to lists, dictionaries, sets, and processing-order families. Chapter 7 develops array operations; Chapter 8 compares the broader families. Existing section order, examples, and assessments are unchanged.

## Connecting Collection Operations (2026-10-17)

0801 now introduces general method-call, property, indexer, and checked-lookup syntax alongside two comparison tables covering the eight families. Contrasts Add/Push/Enqueue, removal by value/index/processing order, inspection versus mutation, size, membership, duplicate policies, and empty cases. Existing examples and chapter sequence remain; the comparison is an orientation aid, not an extra required API unit.

## B-A Framework Improvement (2026-10-17)

Preserved the three-section order, prior explanations, original exercise purposes, and existing lab assessment IDs. 0801 now has an explicit reading path, access-pattern visual, and guided selection reasoning. 0802 introduces the basket problem, construction/operation syntax, list-position visual and trace, integer removal variation, actual content displays, guided score filtering, and a called null-safe ReadLines example. 0803 adds key/value mapping, local syntax and update traces, guided safe lookup/update, and a runnable traced word counter alongside the original functions. Sources live in demos/08_collections/word_count/ and are downloadable.

All completed lesson code cells have required imports and independently verified saved output. Existing type-name printing pitfalls remain explicitly illustrated. Homework retains the original review and adds five concept checks and five transfer coding tasks; the malformed Clear/reassignment prompt is repaired as two separate reading alternatives. Preview's append question is disambiguated; the lab's five connected tasks are retained with boundary checks and collection-choice reflection. The three new SVG diagrams have alt text and prose interpretation; tables supply traces and comparison. No lecture deck was added; aligned slides remain pending. The recognition-level family scope and current organization are unchanged.

## Section-Boundary Review (2026-10-17)

**Status: implemented.** The following records the reviewed recommendation and its baseline. See Implemented Reading Organization below for the final current filenames and order; earlier meeting allocations are historical where they conflict.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `0801_collections.ipynb`: Data Collections | Core content | 5,337 | 54 | 11 |
| `0803_list.ipynb`: Lists | Core content | 1,594 | 40 | 23 |
| `0804_dictionary.ipynb`: Dictionaries | Core content | 1,874 | 36 | 16 |

**Recommendation:** Split the collection overview by instructional role.

0801 contains 5,337 prose words, family orientation, generic notation, operation tables, behavioral demonstrations and reference sharing. The big-idea map should remain first, but the operational development can have its own focused reading.

### Proposed Reading Sequence

1. Collection big ideas, families, and selection.
2. Shared operations, syntax, traversal, and behavioral comparisons.
3. Lists.
4. Dictionaries.

### Adequacy Before Reorganization

The new operations lesson must connect the tables to interpreted behavior. Keep linked lists/sets/stacks/queues/priority queues at recognition level; detailed implementations remain in Chapters 14, 15, 18 and 19.

Reading sections and class meetings are different units; allocate discussion and practice after developing adequate explanations. Do not reduce distinct material to meet a section or word quota.

Preserve every existing explanation, exercise variation and assessment identity. The source-to-destination dispositions in MATERIALS.md govern any later move. Update TOC, links and redirects only in an authorized implementation pass.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `0801_collections.ipynb`: Collection Families and Selection.
- `0802_collection_operations.ipynb`: Collection Operations and Behavior.
- `0803_list.ipynb`: Lists.
- `0804_dictionary.ipynb`: Dictionaries.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.


## Subsection Integration (2026-10-17)

This is the current internal teaching order for the repaired pages. Earlier outlines remain historical where they differ. Chapter/section notebook order is unchanged. All original explanations, examples, exercises, code outputs, assessment identifiers, and link destinations are retained.

### `0804_dictionary.ipynb`

- Creating a Dictionary
- Accessing Data in Dictionary
- Properties and Methods in Dictionary
- Guided Practice: Update Stock Safely
- Word Count Example
  - Trace and Run the Word Counter
- Dictionary Efficiency

Treat syntax, examples, and meaningful variations as children of their conceptual topic. Place prerequisite explanations before application, and distinguish a local checkpoint from later synthesis. Preserve distinct older/newer treatments by grouping them rather than deleting them. Keep the final Footnotes group after instructional content.

## Guided Practice Pass (2026-10-18)

Pass 4 of the content-development audit (`authoring/content_development_audit/`): added a mid-page guided practice with solution to 8.3 Lists (insert and remove by position). Every new starter and solution compiles and runs standalone (.NET 10); starters that are meant to fail say so in their task text. No existing cell, heading, or exercise ID was removed.
