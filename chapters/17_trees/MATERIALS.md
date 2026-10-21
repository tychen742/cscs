---
orphan: true
---

# Chapter Materials: Trees

## Aligned Lecture Deck (2026-10-21)

Source: `_html_extra/chapters/17_trees/1700_slides.md`, using the shared thinkpress-lecture theme. One part follows each current core content notebook with explicit goals, business examples, state traces, two quick checks, an existing exercise, verification cases, and a recap. Supporting/optional readings have short labeled reference parts and add no required meetings. The chapter title notes list one-based part start slides and the existing 110-minute allocation. Every slide has instructor notes with answers; student HTML excludes them. Code examples are standalone and listed in `authoring/slide_revision/code_09_17.json` for central execution verification. Existing assessment IDs, chapter order, and lesson content are unchanged. The landing page links one student deck; instructor PPTX is generated outside published assets.

## Assignment Alignment Revision (2026-10-21)

The existing Foundation Check is explicitly optional, ungraded practice after the ten scored Preview questions. Its cell IDs and index location are retained; required concepts and assignments are unchanged.

## Current Teaching Allocation (2026-10-21)

The current three-meeting, 110-minute preparation/class/reference allocation is recorded at the start of [ORGANIZATION.md](ORGANIZATION.md). It supersedes conflicting earlier estimates without removing readings, examples, or assessment identities.

Keep complete recursive/removal implementation variants, detailed height derivations, and additional tree queries as reference examples after the selected trace. Chapter 17 supplies its own recursion preparation; 5.6 is useful review, not a hidden prerequisite.

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `1701_tree_structure.ipynb` | Tree Structure and Recursive Models | Core content |
| `1702_tree_traversal.ipynb` | Tree Traversal, Returned Values, and Costs | Core content |
| `1703_binary_search_trees.ipynb` | Binary Search Trees | Core content |
| `1704_tree_lab.ipynb` | Tree Queries and Verification | Core content |

Keep the current section boundaries and recently developed content. Consolidate repeated in-page navigation, distinguish repeated practice headings, retain all substantive explanations/examples and finish the instructional material before the final Footnotes group.

No assessment identity, assignment notebook, worked code, output or exercise variant is removed. `authoring/integration_cleanup/` records the original cells, exact edits, moves and URL/fragment compatibility.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Current Priority-Section Coverage (2026-10-17)

This coverage update describes the current notebooks and supersedes older pre-reorganization filename summaries below. Historical plans and verification records are retained.

| Reading | Developed content-section coverage |
| --- | --- |
| `1701_tree_structure.ipynb` | Add guided node/leaf recursion with completed return table and standalone checkpoint before independent tree-query design. |

Retain structure/recursive models, traversal, BST updates and tree queries in the current reading order. Add leaf-query completion before students design a new recursive summary.

All original lesson cells remain, except the explicitly documented presentation/syntax/result corrections and stale chapter references in `authoring/priority_development/source_corrections.json`. Original assignment notebooks and exercise IDs remain untouched. Full standalone code is retained beside the new smaller teaching cores; newly added code verification is recorded separately from historical checks.


## Sequence

- `1700_trees_bst.ipynb`: Orientation, measurable objectives, glossary, and content flow.
- `1701_tree_structure.ipynb`: General and binary trees, recursive return traces, traversal sequences, height conventions, termination, and storage costs.
- `1703_binary_search_trees.ipynb`: Ancestor bounds, search and insertion traces, duplicate policy, height-based costs, and complete subtree-return deletion.
- `1704_tree_lab.ipynb`: Service-ticket index, range pruning, queue-based level order, and ordered-set model verification.
- `assignments/preview.ipynb`: Ten multiple-choice concept questions.
- `assignments/lab.ipynb`: Five connected service-ticket tasks from insertion through lifecycle verification.
- `assignments/homework.ipynb`: Five applied true/false questions and five independent coding tasks.
- `../../demos/17_trees/TicketTree.cs`: Downloadable complete implementation and verification program.

## Depth Coverage

- Distinguish a general hierarchy, binary tree, and BST. Explain tree ownership and acyclic assumptions before recursion.
- Trace returned subtree counts and preorder/inorder/postorder visits; connect recursive stack space to height and level-order queue space to width.
- Validate exclusive inherited bounds with `long` sentinels so all integer keys remain legal.
- Treat the BST as a unique-key ordered set, with Boolean update results and Count maintained once per logical change.
- Implement leaf, one-child, and two-child deletion, including root replacement and a successor with a right child.
- Qualify O(h + 1) path costs, Θ(n) full traversals, and Θ(n²) sorted-input construction. Balancing is motivation, with rotations deferred.
- Practice budget aggregation, inherited bounds, iterative inorder, range reporting, and floor lookup.

## Verification

- All 27 completed notebook examples and answer cells compile and run independently with `dotnet run`; all 10 assignment answers and three lesson answers retain verified stdout.
- Downloadable source compares 600 seeded mixed operations against `SortedSet<int>` and checks explicit boundary cases after each update.
- Transfer verification passes 600 range/floor cases and 30 iterative traversals against sorted-key reference results. The lab sequence detects a deliberately omitted root assignment.
- Full Jupyter Book build succeeds with five pre-existing warnings outside Chapter 17. Browser Run checks include boundary validation, complete removal, range pruning, model verification, lab lifecycle checks, and floor lookup.
- Lecture slide creation and HTML/PDF delivery with instructor-only PPTX access remain deferred to Press work.

## Foundation Placement (2026-10-07)

Moved base/recursive cases and call-stack traces from Chapter 22 into `1701_tree_structure.ipynb`, before recursive tree operations. Helper contracts and divide-and-conquer remain in Chapter 22.

## Move Verification (2026-10-07)

The four receiving sections contain 21 completed cells. Each compiled and ran in an isolated namespace with its own setup under .NET 10; completed exercise answers retain captured stdout. Intentional student starters were excluded. The full Jupyter Book build passed with the five previously recorded warnings outside these chapters. New content pages and prerequisite links are included in the TOC and rendered output. Slides remain pending.

## Section-Boundary Coverage Disposition (2026-10-17)

**Reviewed plan, now implemented:** Split the initial tree/recursion/traversal lesson. The disposition below records the preimplementation baseline and rationale. See Implemented Reading Organization for the current reading files. Counts in this baseline exclude fenced code from prose; the refreshed inventory is in authoring/content_size/. They flag review needs, not quality scores.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `1701_tree_structure.ipynb`: Tree Structure and Traversal | Core content | 1,380 | 29 | 8 |
| `1703_binary_search_trees.ipynb`: Binary Search Trees | Core content | 1,686 | 29 | 9 |
| `1704_tree_lab.ipynb`: Tree Implementation Lab | Core content | 864 | 17 | 6 |

### Source-to-Destination Plan

| Existing source | Proposed treatment and coverage to preserve |
| --- | --- |
| `1701` | Split vocabulary/recursive shape/base and recursive cases from traversal orders/returned aggregation/height and work-space traces; keep recursion before recursive BST operations. |
| `1702` | Retain BST search/insertion/removal and duplicate policies; treat deletion as a substantial developed subsection with all root/successor cases. |
| `1703` | Retain range pruning, level order and model verification as content, with applied guided work separate from the assignments lab. |

### Development Needed Before Moving Material

Expand stack-frame traces and connect visits versus returned values. Four reading pages can support three meetings; do not cut deletion cases to fit the meeting count.

Before a later move, create a cell-level preservation map for these sources, including citations, figures, original code forms, worked traces, guided questions and independent exercise variants. Relocate prerequisite explanations from assignments into content when needed while retaining application requirements and IDs. A consolidated page must still teach its concepts; a split must not create two unsupported outlines. Existing runnable verification records describe earlier work, not verification of this proposal.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `1701_tree_structure.ipynb`: Tree Structure and Recursive Models.
- `1702_tree_traversal.ipynb`: Tree Traversal, Returned Values, and Costs.
- `1703_binary_search_trees.ipynb`: Binary Search Trees.
- `1704_tree_lab.ipynb`: Tree Queries and Verification.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.

## Guided Practice Pass (2026-10-18)

Pass 4 of the content-development audit (`authoring/content_development_audit/`): added mid-page guided practices with solutions to 17.1 (sum the values) and 17.4 (find the largest ID), and task text with expected output above the code-only Exercise cells of 17.2, 17.3, and 17.4. Every new starter and solution compiles and runs standalone (.NET 10); starters that are meant to fail say so in their task text. No existing cell, heading, or exercise ID was removed.

## Mistakes and Interpretation Pass (2026-10-18)

Pass 5 of the content-development audit (`authoring/content_development_audit/`), all four pages: 16 common-mistake paragraphs beside the examples (building below a missing node, non-shrinking recursion, reading a trace top-down, pruning the wrong side, a stack in place of the level-order queue, successor left in place after removal) and interpretation after the exercise solutions, the SortedSet example, the TicketTree opener, and the range-count solution. Every demonstration cell on these pages was rerun and the interpretations quote the actual output. No code cell, heading, cell ID, or exercise ID changed.

## Visual Support and Part I Shape (2026-10-18)

Pass 6 of the content-development audit (`authoring/content_development_audit/`): 17.4 gained a pruning diagram marking visited and skipped nodes for the 25 to 60 range query and a step-by-step queue table for level order. New code cells compile and run standalone (.NET 10); tables and text diagrams are placed beside the example they explain. No heading, cell ID, or exercise ID changed.

## OpenDSA References (2026-10-19)

Added **Visualize it** pointer cells after the worked examples in 17.2 (BST search, insertion, and removal; CS2 Binary Search Trees anchors) and 17.3 (traversal orders; CS2 Binary Tree Traversals), each one sentence linking the matching OpenDSA JSAV slideshow on the `opendsa-server.cs.vt.edu` host (every URL checked with curl, HTTP 200, 2026-10-19). No OpenDSA text or code is copied; no existing cell, heading, cell ID, or exercise ID changed. Re-hosted the existing OpenDSA "Further reading" footnote links to `opendsa-server.cs.vt.edu` CS2/CS3 pages, because `opendsa.org`, `opendsa.cs.vt.edu`, and `opendsax.cs.vt.edu` either fail strict fetches or are not the host this book links to. The roles of the OpenDSA books are recorded in `authoring/toc_comparison/README.md` (OpenDSA mapping) and Appendix A. Chapter 17: the 17.3 footnote now points to CS2 11.1 Binary Trees Chapter Introduction.

## OpenDSA Gap List and Development (2026-10-19)

Pass 8 (`authoring/content_development_audit/pass8_cs2_opendsa_development.md`) compared the four sections with OpenDSA CS2 11.2 Binary Trees (definitions and properties), 11.3 Traversals, 11.4 Binary Search Trees, and CS3 7.3 Binary Tree as a Recursive Data Structure, 7.4 The Full Binary Tree Theorem, 7.6 Implementing Tree Traversals, 7.7 Information Flow in Recursive Functions, 7.10 Space Requirements, 7.11.4 BST Analysis, 7.13 Guided Information Flow, and 7.14 Multiple Binary Trees. Concepts, explanations, and exercise types OpenDSA has that this chapter lacked or treated in under 100 words:

| Gap | OpenDSA treatment | Where it is now developed |
| --- | --- | --- |
| Path, ancestor, descendant, level, internal node; left child versus right child as distinct structures | 11.2.1 Definitions | 17.1 Tree Vocabulary (expanded) |
| Full and complete binary trees | 11.2.1 | 17.1 Full and Complete Binary Trees (new, with diagrams) |
| Full Binary Tree Theorem and the count of empty subtrees; consequence for node space | CS3 7.4, 7.10 | 17.1 The Full Binary Tree Theorem (new, edge-counting argument, runnable verification) |
| Return-table reasoning for several summaries at once | CS3 7.6, 7.13 | 17.1 Code Tracing: Fill the Return Table |
| Information flow: local, passing down, collect-and-return, combined | CS3 7.7 | 17.4 Information Flow in Recursive Methods (new, three-method example) |
| Set-depth exercise (passing down) | CS3 7.7.2 | 17.4 Code Completion: Label Each Node with Its Depth |
| Traversal practice on a changed tree | 11.3.2-11.3.3 | 17.4 Code Tracing: Three Orders for a Changed Tree |
| BST average-case analysis under random insertion | 11.4.4 BST Analysis | 17.2 Average Height Under Random Insertion (new, runnable experiment) |
| BST insert-then-remove trace | 11.4 practice | 17.2 Code Tracing: Build, Then Remove |
| Comparing two trees: same tree, same shape, mirror image | CS3 7.14 Multiple Binary Trees | 17.3 Comparing Two Trees (new) and Code Completion: Same Shape |
| Summary questions | 11.3.4, CS3 7.21 | Check Your Understanding on every page |

Exercises added: code tracing (17.1 Fill the Return Table, 17.4 Three Orders for a Changed Tree, 17.2 Build Then Remove), code completion (17.4 Label Each Node with Its Depth, 17.3 Same Shape), and a Check Your Understanding block of four questions on each page. Every new code cell was compiled and run standalone under .NET 10 and carries its stored output. No existing cell, heading, exercise ID, or footnote was removed; no OpenDSA text, code, or figure was copied. Node implementations with separate leaf classes (CS3 7.8) and Huffman trees (7.18) remain out of scope.

## Demo folder rename (2026-10-19)

The chapter's demo source moved from the former two-digit folder `17/` to `demos/17_trees/`, the same folder name as this chapter, so a cloned repository opened in VS Code shows the book's chapter names. The notebook download and link paths in this chapter were updated to the new folder; no cell content, heading, cell id, or exercise ID changed.
