---
orphan: true
---

# Materials: Searching and Basic Sorting

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `1601_searching.ipynb` | Search Contracts and Repeated Queries | Core content |
| `1602_basic_sorting.ipynb` | Sorting and Safe Reporting Workloads | Core content |

Two core readings remain. 1601 develops search contracts and repeated queries, with a short preparation bridge. 1602 first teaches sorting, then retains the entire reporting snapshot, preparation/update-cost and workload comparison material. All sort-a-copy code and exercises now follow sorting instruction. Legacy workload URLs/fragments point to the retained destinations.

No assessment identity, assignment notebook, worked code, output or exercise variant is removed. `authoring/integration_cleanup/` records the original cells, exact edits, moves and URL/fragment compatibility.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Core Materials

- `1601_searching.ipynb`: Searching Ordered and Unordered Data
- `1602_basic_sorting.ipynb`: Insertion Sort and Ordering
- `1603_workloads.ipynb`: Search and Sort Workloads
- `assignments/`: preview, connected lab, homework, and assignment index.

## Verification and Remaining Work

Standalone C# cells and reference console projects are checked during this revision. Updated slides and recordings are pending. Advanced sorting, tree rotations, weighted graph optimization, and further algorithm analysis are optional depth, not additional requirements for this unit.

## Section-Boundary Coverage Disposition (2026-10-17)

**Reviewed plan, now implemented:** Combine workload material into two developed lessons. The disposition below records the preimplementation baseline and rationale. See Implemented Reading Organization for the current reading files. Counts in this baseline exclude fenced code from prose; the refreshed inventory is in authoring/content_size/. They flag review needs, not quality scores.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `1601_searching.ipynb`: Searching Ordered and Unordered Data | Core content | 706 | 16 | 5 |
| `1602_basic_sorting.ipynb`: Basic Sorting with Insertion Sort | Core content | 549 | 14 | 5 |
| `1603_workloads.ipynb`: Search and Sort Workloads | Core content | 513 | 14 | 4 |

### Source-to-Destination Plan

| Existing source | Proposed treatment and coverage to preserve |
| --- | --- |
| `1601` | Retain linear/binary search; incorporate repeated-query preparation/update comparisons from 1603 after developing result contracts and ordered-input requirements. |
| `1602` | Retain insertion sort and ordering; incorporate reporting snapshots, comparer consistency, boundary matrices and guided report task from 1603. |
| `1603` | Distribute its explanations and exercises into the preceding lessons, preserving the cross-cutting end-to-end report comparison as the closing case. Preserve the published URL. |

### Development Needed Before Moving Material

Expand successful/missing/duplicate search traces, insertion movement, sorted-prefix reasoning and independent order/preservation checks before consolidation. These are core CS2 lessons, not optional advanced prerequisites.

Before a later move, create a cell-level preservation map for these sources, including citations, figures, original code forms, worked traces, guided questions and independent exercise variants. Relocate prerequisite explanations from assignments into content when needed while retaining application requirements and IDs. A consolidated page must still teach its concepts; a split must not create two unsupported outlines. Existing runnable verification records describe earlier work, not verification of this proposal.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `1601_searching.ipynb`: Search Contracts and Repeated Queries.
- `1602_basic_sorting.ipynb`: Sorting and Safe Reporting Workloads.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.

## Landing Page Development (2026-10-17)

`1600_searching_sorting.ipynb` was rewritten from a generic template (about 200 words, three generic objectives, six glossary rows) to a full chapter landing page. It now has a chapter introduction grounded in the two sections (search contracts and repeated queries; sorting and safe reporting workloads) and the chapter's service-desk and reporting examples, seven numbered objectives tied to search contracts, linear/binary traces, the half-open interval, library result contracts, stable insertion sort, comparison counts, and order/preservation checks with snapshot and workload reasoning, the Chapter Flow in TOC order without the assignments link, a numbered glossary of 30 terms drawn from 1601 and 1602, and a Lecture Slides section marked pending. No Chapter Video is embedded yet; the slot stays open for author selection. The landing page carries no content sections or index entries; content notebooks, `_toc.yml`, and assignments were not changed.


## Outcome Gap Repair (2026-10-17)

Preserve the current chapter notebooks, reading order, existing explanations, exercise variants, and assessment identifiers. The additions below close the outcome audit gaps within that organization. Explanations belong in content before independent application; earlier scaffolded tasks remain available.

| Location | Development or assessment |
| --- | --- |
| `homework.ipynb` | Independent Search, Stable Sort, and Workload Choice |

Progression: read the relevant lesson and worked example, complete its guided practice, then attempt the added independent homework without copying the solution. Require contract-derived expected results, boundary evidence, and reasoning about the chosen representation or design. Assess process and explanation as well as output. Existing labs remain scaffolded applications rather than the sole evidence of independent mastery.

Lecture decks remain a separately tracked task. No additional chapter, meeting, or required optional-topic track is introduced.

### Verified Topic-to-Assessment Progression

| Topic/outcome | Explanation and worked example | Guided preparation | Independent evidence |
| --- | --- | --- | --- |
| Independent search/sort and workload decision | 1601_searching and 1602_basic_sorting existing algorithms, invariant/stability/cost examples | Existing scaffolded first-match and insertion-sort exercises retained | New algorithm bodies, independently derived boundary checks, visible stability labels, original snapshot, comparison convention, and Q-query/U-update workload justification. |

Keep the original five-question coding tracks and smaller historical variations. Added transfer tasks complement them. Grade implementation, independently derived expected results, and the requested reasoning separately; correct output from a supplied class does not establish algorithm construction.

## Merge Sort Supporting Reading (2026-10-18)

Added `1603_merge_sort.ipynb` as supporting reading 16.3, following the textbook comparison in `authoring/toc_comparison/README.md`: comparable CS2 texts teach an O(n log n) sort in the core, and a Parts IV and V route previously saw only insertion sort. The reading motivates with a comparison-count table, teaches merge on two sorted runs with a trace and the `<= 0` stability rule, builds the recursive `MergeSort` with range slices and a copy-returning contract, counts comparisons on reversed input against n log2 n and insertion sort's worst case, verifies stability with the 16.2 invoice comparer, compares insertion sort, merge sort, and `Array.Sort` for workloads, and ends with a merge-two-files practice. Six code cells compile and run standalone (.NET 10). The file is numbered 1604 because `1603_workloads.ipynb` is a retained redirect stub. Chapter 22 keeps the buffered implementation, proofs, and verification lab.

## Guided Practice Pass (2026-10-18)

Pass 4 of the content-development audit (`authoring/content_development_audit/`): added a mid-page guided practice with solution to the supporting 16.3 (merge descending runs) and an expected-output sentence to the 16.2 snapshot practice. Every new starter and solution compiles and runs standalone (.NET 10); starters that are meant to fail say so in their task text. No existing cell, heading, or exercise ID was removed.

## OpenDSA References (2026-10-19)

Added **Visualize it** pointer cells after the worked examples in 16.2 (insertion sort, after the first `InsertionSort` cell; CS2 Insertion Sort) and 16.3 (merge sort, after the split trace; CS3 Mergesort Concepts and Implementing Mergesort), each one sentence linking the matching OpenDSA JSAV slideshow on the `opendsa-server.cs.vt.edu` host (every URL checked with curl, HTTP 200, 2026-10-19). No OpenDSA text or code is copied; no existing cell, heading, cell ID, or exercise ID changed. Re-hosted the existing OpenDSA "Further reading" footnote links to `opendsa-server.cs.vt.edu` CS2/CS3 pages, because `opendsa.org`, `opendsa.cs.vt.edu`, and `opendsax.cs.vt.edu` either fail strict fetches or are not the host this book links to. The roles of the OpenDSA books are recorded in `authoring/toc_comparison/README.md` (OpenDSA mapping) and Appendix A. Chapter 16: 16.1 and 16.2 keep the catalog Search in Sorted Arrays module; 16.3 now points to CS3 8.9 Mergesort Concepts.

## OpenDSA Gap List and Development (2026-10-19)

Pass 8 (`authoring/content_development_audit/pass8_cs2_opendsa_development.md`) compared the three sections with OpenDSA CS2 4.6 Calculating Program Running Time (two search algorithms, analyzing binary search), 8.2 Sorting Terminology and Notation, 8.3 Comparing Records, 8.4 Insertion Sort and its analysis, and CS3 8.9-8.10 Mergesort. Concepts, explanations, and exercise types OpenDSA has that this chapter lacked or treated in under 100 words:

| Gap | OpenDSA treatment | Where it is now developed |
| --- | --- | --- |
| Why binary search costs floor(log2 n) + 1 comparisons; growth under doubling; best versus missing-key cases | 4.6.1.3 Analyzing Binary Search | 16.1 Count the Comparisons of Binary Search (new, runnable counts against the bound) |
| Binary search practice (interval trace, boundary updates) | 4.6.1.2 Binary Search Practice Exercise | 16.1 Code Tracing: Narrow the Interval; Code Completion: Finish the Boundary Updates |
| The sorting problem defined over records and keys; comparisons versus moves versus memory as cost measures; limits of empirical timing | 8.2 | 16.2 The Sorting Problem and Its Cost Measures (new) |
| Comparer consistency rules and two-key comparers | 8.3 Comparing Records | 16.2 Sorting Objects Uses an Ordering Policy (was 93 words) |
| Inversions as the exact cost of insertion sort; nearly sorted input | 8.4.2 Insertion Sort Analysis | 16.2 Inversions Measure How Unsorted the Input Is (new, runnable inversion and shift counts) |
| Reading the comparison counter output; verification as a reusable check; workload questions | 8.4, 8.2 | 16.2 Count Work for Different Inputs, Verify Order and Preservation, Compare Reporting and Query Workloads (each under 100 words before) |
| Recursion tree of merge sort shown in program order | CS3 8.9 Mergesort Concepts | 16.4 Code Tracing: Follow the Recursion |
| Exercise types: insertion sort proficiency trace, cost ordering, summary questions | 8.4 practice, 8.17 summary | Listed below |

Exercises added: code tracing (16.1 Narrow the Interval, 16.2 The Prefix After Each Pass, 16.4 Follow the Recursion), code completion (16.1 Finish the Boundary Updates), cost ordering with a dropdown answer (16.2 Which Input Costs Insertion Sort Most?), and a Check Your Understanding block of four questions on each page, including the supporting reading. Every new code cell was compiled and run standalone under .NET 10 and carries its stored output. No existing cell, heading, exercise ID, or footnote was removed; no OpenDSA text, code, or figure was copied. Lower bounds for sorting (CS3 8.16) are left for Chapter 23, where the comparison-sort model is developed.
