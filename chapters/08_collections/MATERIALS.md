---
orphan: true
---

# Chapter Materials — Data Collections

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

- [`demos/08/collections_demo/`](../../demos/08/collections_demo/README.md): List construction and sorting.
- [`demos/08/help_responses/`](../../demos/08/help_responses/README.md): Dictionary-based help response simulation.

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

Preserved the three-section order, prior explanations, original exercise purposes, and existing lab assessment IDs. 0801 now has an explicit reading path, access-pattern visual, and guided selection reasoning. 0802 introduces the basket problem, construction/operation syntax, list-position visual and trace, integer removal variation, actual content displays, guided score filtering, and a called null-safe ReadLines example. 0803 adds key/value mapping, local syntax and update traces, guided safe lookup/update, and a runnable traced word counter alongside the original functions. Sources live in demos/08/word_count/ and are downloadable.

All completed lesson code cells have required imports and independently verified saved output. Existing type-name printing pitfalls remain explicitly illustrated. Homework retains the original review and adds five concept checks and five transfer coding tasks; the malformed Clear/reassignment prompt is repaired as two separate reading alternatives. Preview's append question is disambiguated; the lab's five connected tasks are retained with boundary checks and collection-choice reflection. The three new SVG diagrams have alt text and prose interpretation; tables supply traces and comparison. No lecture deck was added; aligned slides remain pending. The recognition-level family scope and current organization are unchanged.
