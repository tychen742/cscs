---
orphan: true
---

# Chapter Materials: Trees

## Sequence

- `1700_trees_bst.ipynb`: Orientation, measurable objectives, glossary, and content flow.
- `1701_tree_structure.ipynb`: General and binary trees, recursive return traces, traversal sequences, height conventions, termination, and storage costs.
- `1702_binary_search_trees.ipynb`: Ancestor bounds, search and insertion traces, duplicate policy, height-based costs, and complete subtree-return deletion.
- `1703_tree_lab.ipynb`: Service-ticket index, range pruning, queue-based level order, and ordered-set model verification.
- `assignments/preview.ipynb`: Ten multiple-choice concept questions.
- `assignments/lab.ipynb`: Five connected service-ticket tasks from insertion through lifecycle verification.
- `assignments/homework.ipynb`: Five applied true/false questions and five independent coding tasks.
- `../../demos/17/TicketTree.cs`: Downloadable complete implementation and verification program.

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
| `1702_binary_search_trees.ipynb`: Binary Search Trees | Core content | 1,686 | 29 | 9 |
| `1703_tree_lab.ipynb`: Tree Implementation Lab | Core content | 864 | 17 | 6 |

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
- `1704_tree_traversal.ipynb`: Tree Traversal, Returned Values, and Costs.
- `1702_binary_search_trees.ipynb`: Binary Search Trees.
- `1703_tree_lab.ipynb`: Tree Queries and Verification.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.
