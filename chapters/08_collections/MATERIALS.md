---
orphan: true
---

# Chapter Materials — Data Collections

## Core Depth Revision (2026-10-19)

C07: follow the compact operation model and generic-type exposure with concrete array/list and dictionary examples, then connect the full retained operation tables to the other family examples. Namespace reference follows the behavior it supports. Later-family examples remain early policy recognition, not new implementation requirements.

This current arrangement supersedes conflicting historical outlines below. Assignments and optional/supporting readings are unchanged. Existing explanations, examples, exercise identities and published paths are preserved. Verification and cell-preservation evidence are recorded in `authoring/core_depth_revision/`.

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `0801_collections.ipynb` | Collection Families and Selection | Core content |
| `0804_collection_operations.ipynb` | Collection Operations and Behavior | Core content |
| `0802_list.ipynb` | Lists | Core content |
| `0803_dictionary.ipynb` | Dictionaries | Core content |

Keep the current section boundaries and recently developed content. Consolidate repeated in-page navigation, distinguish repeated practice headings, retain all substantive explanations/examples and finish the instructional material before the final Footnotes group.

No assessment identity, assignment notebook, worked code, output or exercise variant is removed. `authoring/integration_cleanup/` records the original cells, exact edits, moves and URL/fragment compatibility.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Landing Page

- `0800_data_collections.ipynb` — Chapter landing page

## Section Notebooks

- `0801_collections.ipynb` — Collection contracts, access patterns, eight families, generic types, traversal, references, and collection selection; independently runnable demonstrations and a list/dictionary summary exercise.
- `0802_list.ipynb` — Lists (`List<T>`)
- `0803_dictionary.ipynb` — Dictionaries (`Dictionary<TKey,TValue>`)

## Non-TOC Source Material

- None. The former source notebooks (`0802-list-dictionary`, `1101-intro-ds`, `1102-collection-examples`) were removed 2026-10-04 after review: their list, dictionary, and collection-overview material was already in `0801`–`0803`, stacks and queues live in Chapter 15, `HashSet<T>` in Chapter 19, and the tuples material moved to `10_classes/1001_class_syntax.ipynb`.

## Assignments

- `assignments/index.ipynb` — Index
- `assignments/lab.ipynb` — Lab
- `assignments/preview.ipynb` — Preview
- `assignments/homework.ipynb` — Homework

## Notes

- Source examples live in `demos/` at the project root.
- `HashSet<T>` is introduced behaviorally in 0801; detailed set operations, hashing, and equality remain in Chapter 19. Linked lists, stacks/queues, and priority queues receive analogous recognition-level introductions, with detailed lessons retained in Chapters 14, 15, and 18.

## Runnable Demo Projects

- [`demos/08_collections/collections_demo/`](../../demos/08_collections/collections_demo/README.md): List construction and sorting.
- [`demos/08_collections/help_responses/`](../../demos/08_collections/help_responses/README.md): Dictionary-based help response simulation.

All demo projects target .NET 10. Run commands and verification are documented
in `demos/README.md` and each project README.

## Expanded 0801 Sources and Scope (2026-10-16)

- Microsoft: [Collections and Data Structures](https://learn.microsoft.com/en-us/dotnet/standard/collections/), [Selecting a Collection Class](https://learn.microsoft.com/en-us/dotnet/standard/collections/selecting-a-collection-class), and .NET 10 reference pages for `LinkedList<T>` and `PriorityQueue<TElement,TPriority>` (linked in notebook footnotes).
- Original bookstore examples distinguish positions, keys, uniqueness, and processing order; the eight-family table is an introductory map, not an exhaustive library inventory.
- Priority examples use unique values and explain that lower numbers are removed first and equal priorities have no FIFO guarantee. List aliases are contrasted with explicit element copies.
- Eleven standalone code cells include nine demonstrations and a question/solution pair. Advanced collection examples provide orientation; existing required assignment identifiers and scope are unchanged.
- The existing namespace diagram is retained as a selection of three namespaces, with text explaining that it is not exhaustive.
- Chapter video is retained. No aligned Chapter 8 lecture deck was found in `_html_extra`; slides remain a teaching-support gap.

### Verification

Compiled each of the eleven code cells independently with `dotnet run --project <temporary net10.0 project> -p:NuGetAudit=false -p:UseSharedCompilation=false`, with warnings treated as errors. All ten completed cells have verified stdout retained. Checked empty, single, and repeated-quantity variants of the summary solution, plus the expected CS0029 compile failure for the commented type mismatch. `jupyter-book build .` succeeds; notebook JSON, source heading/index structure, and rendered content were checked.

The collection-family table has an explicit adaptation note and inline footnote citations. Its footnote gives Microsoft Learn references, access date, and the distinction between Microsoft's guidance and the author's eight-family teaching map. The conceptual framework now precedes the individual-family demonstrations. All code cells and saved outputs are unchanged by this reordering.

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

## Section-Boundary Coverage Disposition (2026-10-17)

**Reviewed plan, now implemented:** Split the collection overview by instructional role. The disposition below records the preimplementation baseline and rationale. See Implemented Reading Organization for the current reading files. Counts in this baseline exclude fenced code from prose; the refreshed inventory is in authoring/content_size/. They flag review needs, not quality scores.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `0801_collections.ipynb`: Data Collections | Core content | 5,337 | 54 | 11 |
| `0802_list.ipynb`: Lists | Core content | 1,594 | 40 | 23 |
| `0803_dictionary.ipynb`: Dictionaries | Core content | 1,874 | 36 | 16 |

### Source-to-Destination Plan

| Existing source | Proposed treatment and coverage to preserve |
| --- | --- |
| `0801` | Split conceptual orientation (purpose, family map, access patterns and choosing a collection) from operations/typed construction, worked family comparisons, traversal and shared references. Retain the cited family table and the cross-family operation tables, not merely links to later chapters. |
| `0802` | Retain List<T> development and its original variations; use the preceding operation lesson as a bridge. |
| `0803` | Retain Dictionary<TKey,TValue>, safe access/update and word-counter development. Keep word counting here as an applied composition case. |

### Development Needed Before Moving Material

The new operations lesson must connect the tables to interpreted behavior. Keep linked lists/sets/stacks/queues/priority queues at recognition level; detailed implementations remain in Chapters 14, 15, 18 and 19.

Before a later move, create a cell-level preservation map for these sources, including citations, figures, original code forms, worked traces, guided questions and independent exercise variants. Relocate prerequisite explanations from assignments into content when needed while retaining application requirements and IDs. A consolidated page must still teach its concepts; a split must not create two unsupported outlines. Existing runnable verification records describe earlier work, not verification of this proposal.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `0801_collections.ipynb`: Collection Families and Selection.
- `0804_collection_operations.ipynb`: Collection Operations and Behavior.
- `0802_list.ipynb`: Lists.
- `0803_dictionary.ipynb`: Dictionaries.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.


## Subsection Integration (2026-10-17)

This is the current internal teaching order for the repaired pages. Earlier outlines remain historical where they differ. Chapter/section notebook order is unchanged. All original explanations, examples, exercises, code outputs, assessment identifiers, and link destinations are retained.

### `0803_dictionary.ipynb`

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

## Demo folder rename (2026-10-19)

The chapter's demo source moved from the former two-digit folder `08/` to `demos/08_collections/`, the same folder name as this chapter, so a cloned repository opened in VS Code shows the book's chapter names. The notebook download and link paths in this chapter were updated to the new folder; no cell content, heading, cell id, or exercise ID changed.
