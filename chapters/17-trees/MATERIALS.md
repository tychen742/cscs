---
orphan: true
---

# Chapter Materials: Trees

## Sequence

- `1700-trees-bst.ipynb`: Orientation, measurable objectives, glossary, and content flow.
- `1701-tree-structure.ipynb`: General and binary trees, recursive return traces, traversal sequences, height conventions, termination, and storage costs.
- `1702-binary-search-trees.ipynb`: Ancestor bounds, search and insertion traces, duplicate policy, height-based costs, and complete subtree-return deletion.
- `1703-tree-lab.ipynb`: Service-ticket index, range pruning, queue-based level order, and ordered-set model verification.
- `assignments/preview.ipynb`: Ten multiple-choice concept questions.
- `assignments/lab.ipynb`: Five connected service-ticket tasks from insertion through lifecycle verification.
- `assignments/homework.ipynb`: Five applied true/false questions and five independent coding tasks.
- `../../materials/17/TicketTree.cs`: Downloadable complete implementation and verification program.

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

Moved base/recursive cases and call-stack traces from Chapter 21 into `1701-tree-structure.ipynb`, before recursive tree operations. Helper contracts and divide-and-conquer remain in Chapter 21.

## Move Verification (2026-10-07)

The four receiving sections contain 21 completed cells. Each compiled and ran in an isolated namespace with its own setup under .NET 10; completed exercise answers retain captured stdout. Intentional student starters were excluded. The full Jupyter Book build passed with the five previously recorded warnings outside these chapters. New content pages and prerequisite links are included in the TOC and rendered output. Slides remain pending.
