---
orphan: true
---

# Pass 8: CS2 chapter development on the OpenDSA model (2026-10-19)

Branch `claude/practical-bohr-50efc8` (worktree), one commit per chapter, not pushed. Method: for each chapter, read our sections and the matching OpenDSA CS2/CS3 sections (host opendsa-server.cs.vt.edu), list the gaps in the chapter's MATERIALS.md under a dated heading, develop the gaps as `###` subsections placed where the concept is taught, add borrowed exercise types (code tracing, code completion, growth-rate or cost ordering, concept recall, Check Your Understanding with dropdown answers), compile and run every new code cell with .NET 10 and store its output, add index-map keys, build with `jupyter-book build . --all` (only the two pre-existing lexer warnings), and commit. Everything is written in our own words and in C#; no OpenDSA text, code, or figure was copied. Word counts use the method of `authoring/word_count_report.md` (prose words outside fenced code, directives, and HTML), computed by the same script before and after.

## Status

Chapters 13-21 are developed and committed (commits 7fa63d51, 30978502, e59119a8, dc0757e4, 4a2895af, 003f8a0d, 6fd6f121, 2bb7aca0, d2aa731b). Chapters 22-26 were not reached: the session's usage limit was hit after Chapter 21. Their sections were read (dumps of 22.1 and 22.2 are in the session scratchpad) but no notebook, MATERIALS.md, or ORGANIZATION.md in Chapters 22-26 was changed. The index map `_ext/subject_index_entries.json` carries keys only for headings that exist.

## Prose words per chapter, before and after

| Ch | Before | After | Added | Code cells before | Code cells after |
| ---: | ---: | ---: | ---: | ---: | ---: |
| 13 | 4,709 | 9,988 | +5,279 | 13 | 27 |
| 14 | 5,395 | 7,827 | +2,432 | 18 | 24 |
| 15 | 3,527 | 6,181 | +2,654 | 26 | 33 |
| 16 | 4,048 | 6,590 | +2,542 | 22 | 29 |
| 17 | 6,283 | 9,242 | +2,959 | 28 | 39 |
| 18 | 3,264 | 5,914 | +2,650 | 15 | 23 |
| 19 | 4,146 | 6,357 | +2,211 | 16 | 23 |
| 20 | 6,314 | 8,925 | +2,611 | 25 | 33 |
| 21 | 4,009 | 7,107 | +3,098 | 22 | 30 |
| 22 | 3,023 | 3,023 | +0 | 18 | 18 |
| 23 | 6,109 | 6,109 | +0 | 23 | 23 |
| 24 | 4,611 | 4,611 | +0 | 21 | 21 |
| 25 | 5,060 | 5,060 | +0 | 22 | 22 |
| 26 | 4,176 | 4,176 | +0 | 14 | 14 |
| Total | 64,674 | 91,110 | +26,436 | | |

## Prose words per section (developed chapters)

| Section | Before | After |
| --- | ---: | ---: |
| 1301_adt_contracts | 925 | 2,692 |
| 1302_representations_costs | 1,222 | 2,921 |
| 1303_generics | 1,511 | 2,458 |
| 1304_iterators | 1,051 | 1,917 |
| 1401_dynamic_arrays | 2,024 | 2,749 |
| 1402_linked_nodes | 1,706 | 2,712 |
| 1403_comparison_lab | 1,665 | 2,366 |
| 1501_stack | 1,049 | 1,625 |
| 1502_queue_deque | 1,378 | 2,699 |
| 1503_applications_lab | 1,100 | 1,857 |
| 1601_searching | 1,196 | 1,949 |
| 1602_basic_sorting | 1,534 | 2,967 |
| 1604_merge_sort | 1,318 | 1,674 |
| 1701_tree_structure | 1,494 | 2,502 |
| 1704_tree_traversal | 1,229 | 2,042 |
| 1702_binary_search_trees | 2,141 | 2,721 |
| 1703_tree_lab | 1,419 | 1,977 |
| 1801_priority_queues | 1,030 | 1,904 |
| 1802_heap_implementation | 1,218 | 2,337 |
| 1803_priority_applications | 1,016 | 1,673 |
| 1901_hashing | 1,586 | 2,719 |
| 1902_dictionaries_sets | 1,180 | 1,749 |
| 1903_collection_selection | 1,380 | 1,889 |
| 2001_graph_vocabulary | 1,460 | 2,449 |
| 2002_adjacency_representations | 1,557 | 1,981 |
| 2003_graph_traversal | 1,489 | 2,337 |
| 2004_depth_first_components | 1,808 | 2,158 |
| 2101_big_o | 1,446 | 2,505 |
| 2102_correctness | 1,260 | 2,102 |
| 2103_recurrences | 1,303 | 2,500 |

## Exercises added by type (Chapters 13-21)

| Type | Count | Where |
| --- | ---: | --- |
| Code tracing (answer in a hide-input solution cell with stored output) | 25 | 13.1, 13.2, 13.4, 14.1, 14.2, 15.1, 15.2, 15.3, 16.1, 16.2, 16.4, 17.1, 17.2, 17.4, 18.1, 18.2, 19.1, 19.3, 20.2, 20.3, 20.4, 21.1, 21.2, 21.3 |
| Code completion (starter tagged `exercise` plus hide-input solution) | 13 | 13.3, 13.4, 14.2, 15.2, 16.1, 17.3, 17.4, 18.2, 19.2, 20.2, 20.3, 21.2 |
| Growth-rate or cost ordering (dropdown answer) | 6 | 13.2, 14.3, 16.2, 18.3, 21.1, 21.3 (recurrence matching) |
| Concept recall (dropdown answer) | 7 | 13.1, 13.3, 19.2, 19.3, 20.1, 21.3 |
| Check Your Understanding (three to five questions with dropdown answers) | 30 | every content section of Chapters 13-21, including the supporting reading 16.4 |

New explanatory subsections include: ADT vocabulary chain and dictionary example, selecting a data structure, best/worst/average cases, array-versus-linked space break-even, records and keys, hand-written enumerator (13); index-versus-cursor list designs, header node, reference-model harness (14); linked stack comparison, pigeonhole full-versus-empty argument, explicit stack replacing recursion (15); binary search comparison count, sorting problem and cost measures, inversions (16); full and complete trees, Full Binary Tree Theorem, information flow, random-insertion BST height, two-tree comparison (17); priority-queue representation comparison, complete-tree index arithmetic, bottom-up heap build, priority update, heapsort (18); hash function principles, cost versus load, probe sequences, mutated-key hazard (19); what graphs model, DAGs and free trees, topological sort (20); simplifying rules, faster computer versus faster algorithm, proof shapes, summations, recurrence expansion (21).

## Left undone

- Chapters 22-26: gap lists, development, exercises, notes, and commits. Candidate OpenDSA sources were identified: CS2 7.1-7.9 recursion (writing, tracing, code completion sets) and CS3 8.9-8.10 mergesort for Chapter 22; CS3 8.6 cost of exchange sorting, 8.8 Shellsort, 8.11 Quicksort analysis, 8.12-8.14 heapsort and binsort/radix, 8.15 empirical comparison, 8.16 lower bounds for sorting for Chapter 23; CS3 14.5-14.8 shortest paths, MCST (Prim), Kruskal, all-pairs, and 13.2 union/find for Chapter 24; dynamic programming and backtracking have no direct OpenDSA CS2/CS3 module, so Chapter 25 (whose 25.1 and 25.2 subsections are under 60 words) would borrow exercise types only; CS3 "Limits to Computation" and string matching for Chapter 26.
- `authoring/PROGRESS.md` is untouched by design; the main session updates it after merge.
- The summary's per-section table covers Chapters 13-21 only; Chapters 22-26 appear in the chapter table with unchanged counts.

