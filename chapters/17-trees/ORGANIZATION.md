---
orphan: true
---

# Chapter Organization: Trees

## Learning Objectives

Students trace recursive algorithms, preserve the BST ordering invariant across complete updates, analyze costs using height, and verify ordered-set behavior against an independent model.

## Class Meetings

1. **Tree structure and traversal, 35 minutes.** Draw the catalog tree; identify depths, leaves, and edges; trace Count returns and traversal timing; predict empty, singleton, and chain results. Separate total traversal work from active call-stack space.
2. **Binary search trees, 40 minutes.** Trace narrowing ancestor bounds, successful/failed search, and insertion returns. Explain duplicate handling and shape-dependent costs. Draw all deletion cases, including root replacement and a successor's right child.
3. **Applied tree operations, 35 minutes.** Use the service-ticket index for lookup and reporting. Trace range pruning and level-order queue contents. Compare updates against `SortedSet<int>` and introduce mutation checking before connected lab work.

The planned lecture total is 110 minutes, including predictions, hand traces, discussion, and code inspection. Assignments provide additional guided and independent work.

## Assignment Roles

- Preview checks vocabulary, ordering, traversal, and the successor rule before class.
- Lab builds one service-ticket index through registration, search, simple deletion, successor deletion, and lifecycle tests. Every cell contains its own setup; students carry completed methods forward explicitly.
- Homework transfers the algorithms to budgets, boundary-safe validation, an explicit traversal stack, interval reports, and greatest-eligible-key lookup.

## Scope and Conventions

- Keep general-tree structure separate from BST ordering. Use unique integer IDs as the implemented set contract.
- Keep balancing rotations outside this chapter. Explain why an unbalanced tree cannot guarantee logarithmic path costs.
- Retain legacy `thebe-interactive` exercise metadata until the coordinated Press/UI convention migration.
- Slides remain pending; later Press work will provide HTML/PDF to students and restrict PPTX downloads to instructors.
