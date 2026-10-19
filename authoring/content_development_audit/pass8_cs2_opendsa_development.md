---
orphan: true
---

# Pass 8: CS2 chapter development on the OpenDSA model (2026-10-19)

Branch `claude/practical-bohr-50efc8` (worktree), one commit per chapter, not pushed or deployed. Method: for each of Chapters 13-26, read our sections and the matching OpenDSA CS2/CS3 sections (host opendsa-server.cs.vt.edu); list the gaps in the chapter's MATERIALS.md under a dated heading; develop the gaps as `###` subsections placed where the concept is taught (expanded explanations for subsections under 100 words, runnable worked examples with stored output and an interpretation, comparison tables where OpenDSA uses them); add borrowed exercise types; add an index-map key for every new heading; compile and run every new code cell with .NET 10 and store its output; build with `jupyter-book build . --all` (every build finished with only the two pre-existing lexer warnings in 0204 and 1001); and commit. Everything is written in our own words and in C#; no OpenDSA text, code, or figure was copied. Word counts use the method of `authoring/word_count_report.md` (prose words outside fenced code, directives, and HTML), computed by one script before and after.

## Commits

- `7fa63d51 Develop Chapter 13 explanations and practice on the OpenDSA model`
- `30978502 Develop Chapter 14 practice and the OpenDSA header-node idea`
- `e59119a8 Develop Chapter 15 on the OpenDSA stack and queue model`
- `dc0757e4 Develop Chapter 16 search and sort analysis on the OpenDSA model`
- `4a2895af Develop Chapter 17 on the OpenDSA binary tree model`
- `003f8a0d Develop Chapter 18 on the OpenDSA heap model`
- `6fd6f121 Develop Chapter 19 on the OpenDSA hashing model`
- `2bb7aca0 Develop Chapter 20 on the OpenDSA graph model`
- `d2aa731b Develop Chapter 21 on the OpenDSA analysis model`
- `02ef03fc Record pass 8 summary: Chapters 13-21 developed, 22-26 pending`
- `b9620f36 Develop Chapter 22 on the OpenDSA recursion model`
- `f76eeafb Develop Chapter 23 on the OpenDSA sorting model`
- `f7fbe16d Develop Chapter 24 on the OpenDSA graph optimization model`
- `08808b34 Develop Chapter 25 with full framing subsections and search practice`
- `3d3dc1f9 Develop Chapter 26 string matching and limits practice`

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
| 22 | 3,023 | 4,647 | +1,624 | 18 | 26 |
| 23 | 6,109 | 9,228 | +3,119 | 23 | 34 |
| 24 | 4,611 | 7,065 | +2,454 | 21 | 29 |
| 25 | 5,060 | 7,689 | +2,629 | 22 | 32 |
| 26 | 4,176 | 6,199 | +2,023 | 14 | 21 |
| Total | 64,674 | 102,959 | +38,285 | 283 | 403 |

For comparison, the word-count report's Chapters 1-9 average 1,700-2,600 prose words per section; the CS2 sections now average 2,238 words against 1,406 before.

## Prose words per section

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
| 2201_recursion | 1,274 | 2,582 |
| 2203_merge_sort_lab | 1,749 | 2,065 |
| 2301_searching | 1,331 | 1,787 |
| 2302_sorting | 1,165 | 1,763 |
| 2303_comparison_lab | 1,345 | 2,020 |
| 2304_advanced_sorts | 1,081 | 1,750 |
| 2305_quicksort | 1,187 | 1,908 |
| 2401_greedy_choice | 1,234 | 1,979 |
| 2402_spanning_trees_shortest_paths | 1,484 | 2,370 |
| 2404_shortest_paths | 1,893 | 2,716 |
| 2501_memoization_tabulation | 1,410 | 2,524 |
| 2504_optimization_models | 1,890 | 2,339 |
| 2502_backtracking | 1,760 | 2,826 |
| 2602_shortest_paths_strings | 1,041 | 1,754 |
| 2604_prefix_matching | 1,897 | 2,440 |
| 2603_limits_project | 1,238 | 2,005 |

## Exercises added by type

Counted from the new `###` headings in the content notebooks of Chapters 13-26. Every tracing exercise shows code in the task and runs it in a hide-input solution cell with stored output; every completion exercise has a starter tagged `exercise` and a hide-input solution with stored output; ordering and recall exercises answer in a dropdown; every Check Your Understanding block holds four questions with dropdown answers.

| Type | Count | Sections |
| --- | ---: | --- |
| Code tracing | 37 | 13.1, 13.2, 13.4, 14.1, 14.2, 15.1, 15.2, 15.3, 16.1, 16.2, 16.4, 17.1, 17.4, 17.2, 18.1, 18.2, 19.1, 19.3, 20.2, 20.3, 20.4, 21.1, 21.2, 21.3, 22.1 (2), 23.1, 23.2, 23.4, 24.1, 24.2, 24.4, 25.1, 25.4, 25.2, 26.2, 26.4 |
| Code completion | 22 | 13.3, 13.4, 14.2, 15.2, 16.1, 17.4, 17.3, 18.2, 19.2, 20.2, 20.3, 21.2, 22.1, 22.3, 23.1, 23.5, 24.4, 25.1, 25.4, 25.2, 26.2, 26.4 |
| Growth-rate or cost ordering | 6 | 13.2, 14.3, 16.2, 18.3, 21.1, 23.3 |
| Concept recall | 6 | 13.3, 19.2, 19.3, 20.1, 21.3, 26.3 |
| Check Your Understanding | 46 | 13.1, 13.2, 13.3, 13.4, 14.1, 14.2, 14.3, 15.1, 15.2, 15.3, 16.1, 16.2, 16.4, 17.1, 17.4, 17.2, 17.3, 18.1, 18.2, 18.3, 19.1, 19.2, 19.3, 20.1, 20.2, 20.3, 20.4, 21.1, 21.2, 21.3, 22.1, 22.3, 23.1, 23.2, 23.3, 23.4, 23.5, 24.1, 24.2, 24.4, 25.1, 25.4, 25.2, 26.2, 26.4, 26.3 |

## Explanatory subsections added

13: ADT vocabulary chain and dictionary example; interfaces as a pattern with interpretation; client code against two implementations; precondition, postcondition, invariant; selecting a data structure; best/worst/average cases; array-versus-linked space break-even; runtime-versus-compile-time failure; records, keys, and homogeneity; hand-written enumerator; laziness demonstration. 14: index-versus-cursor designs; header node; reference-model harness. 15: linked stack and comparison; drifting queue and the pigeonhole full-versus-empty argument; deque pairs; explicit stack replacing recursion. 16: binary search comparison count; sorting problem and cost measures; comparer consistency; inversions. 17: path, ancestor, level; full and complete trees; Full Binary Tree Theorem; information flow; random-insertion BST height; comparing two trees. 18: priority-queue representation comparison; index arithmetic and the leaf boundary; bottom-up heap build; priority update; heapsort. 19: hash function principles; cost versus load and probe sequences; mutated-key hazard. 20: what graphs model; DAGs and free trees; topological sort (queue-based, plus DFS exit order). 21: simplifying rules; faster computer versus faster algorithm; proof shapes; summations; recurrence expansion. 22: forward and backward flow; Towers of Hanoi. 23: cost of exchange sorting; sorting lower bound; bin and radix sort; quicksort analysis and pivot choice. 24: greedy success-and-failure catalogue; path compression; Prim's algorithm; array-scan versus heap Dijkstra. 25: the DP recipe and applicability test (two framing subsections rewritten from under 60 words); backtracking template and pruning with node counts. 26: worst-case versus typical direct matching; classes of difficulty.

## Left undone or out of scope

- `authoring/PROGRESS.md` is untouched by design; the main session updates it after merge.
- OpenDSA material deliberately not borrowed: Huffman coding trees, separate leaf-node classes, bucket hashing and mid-square hashing, code tuning, Floyd's all-pairs shortest paths (positioned in 24.3's self-check only), general trees and sequential tree representations, spatial structures, and the CS2 software-process and UML modules. Chapters 25 and 26 have no CS2/CS3 counterpart, so they borrowed exercise types and the CS3 analysis habits only.
- The OpenDSA reference entries and "Visualize it" links on these pages belong to the concurrent reference pass; this pass added none and touched no existing footnote.
- Section timing was kept to one 35-40 minute segment per page by using `###` headings and short cells; no page was split into a supporting reading. The longest pages after this pass (13.1, 14.1, 17.2, 20.4, 24.3) should be checked in class before the next audit decides whether a split is warranted.

