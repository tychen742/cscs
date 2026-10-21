---
marp: true
theme: thinkpress-lecture
paginate: true
title: "Trees and Binary Search Trees"
book: Computer Science in C#
section: "Chapter 17"
primary: "#2a6b37"
accent: "#b8860b"
---

<!-- _class: title -->

# Trees and Binary Search Trees

Chapter 17 · Computer Science in C#

Business models, worked traces, and verified C# examples.

<!--
Part 17.1: Tree Structure and Recursive Models, starts on slide 2.
Part 17.2: Tree Traversal, Returned Values, and Costs, starts on slide 17.
Part 17.3: Binary Search Trees, starts on slide 32.
Part 17.4: Tree Queries and Verification, starts on slide 47.
Core reading parts share the chapter's existing three-meeting allocation, totaling 110 minutes. They are not separate fifty-minute meetings. Optional/reference parts add no required meeting. Speaker-note answers belong to the instructor output; publish student HTML with those notes stripped.
-->

---

<!-- _class: section -->

# Tree Structure and Recursive Models

Part 17.1 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 15 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. A department hierarchy stores one local budget per node. The total must include each node exactly once, regardless of whether keys happen to be ordered. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Identify base cases and smaller subproblems.
- Distinguish general, binary, and ordered trees.
- Compute returned summaries recursively.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. A null subtree contributes the operation's base answer. Recursive calls must move into smaller subtrees, and a returned summary combines their results. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

A department hierarchy stores one local budget per node. The total must include each node exactly once, regardless of whether keys happen to be ordered.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. A department hierarchy stores one local budget per node. The total must include each node exactly once, regardless of whether keys happen to be ordered. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

A binary tree has at most two children per node. Its recursive structure consists of a root plus left and right subtrees; a BST adds a separate ordering invariant.

<!--
A binary tree has at most two children per node. Its recursive structure consists of a root plus left and right subtrees; a BST adds a separate ordering invariant. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

A null subtree contributes the operation's base answer. Recursive calls must move into smaller subtrees, and a returned summary combines their results.

<!--
A null subtree contributes the operation's base answer. Recursive calls must move into smaller subtrees, and a returned summary combines their results. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 17.1

```csharp
using System;
var root = new Node(8, new Node(3, new Node(1), new Node(6)), new Node(10));
Console.WriteLine(Count(root));
static int Count(Node? n) => n is null ? 0 : 1 + Count(n.Left) + Count(n.Right);
record Node(int Id, Node? Left = null, Node? Right = null);
```

```output
5
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is 5. Connect each observation to the contract: A null subtree contributes the operation's base answer. Recursive calls must move into smaller subtrees, and a returned summary combines their results. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Subtree|Count returned |
| --- | --- |
| Null|0 |
| Leaf 1|1 |
| Leaf 6|1 |
| Node 3 with leaves 1,6|3 |
| Root 8 with subtree 3 and leaf 10|5 |

<!--
Walk through the rows before executing another example. Subtree: Count returned. Null: 0. Leaf 1: 1. Leaf 6: 1. Node 3 with leaves 1,6: 3. Root 8 with subtree 3 and leaf 10: 5. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## What ensures this recursion makes progress?

1. The method has a short name
2. Each call receives a smaller child subtree
3. The root happens to have key eight

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: B. Child subtrees are structurally smaller in an acyclic tree, and null supplies the base case. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Tree concept|Additional rule |
| --- | --- |
| General tree|A hierarchy may have many children |
| Binary tree|At most two children |
| Binary search tree|All descendants obey key ordering |
| Leaf|No children |

<!--
Tree concept: Additional rule. General tree: A hierarchy may have many children. Binary tree: At most two children. Binary search tree: All descendants obey key ordering. Leaf: No children. A null subtree contributes the operation's base answer. Recursive calls must move into smaller subtrees, and a returned summary combines their results. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

Counting only non-null child references misses the current node. Returning one plus both child counts states the node-count contract directly.

<!--
Counting only non-null child references misses the current node. Returning one plus both child counts states the node-count contract directly. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## Which condition recognizes a leaf?

1. Left is null OR right is null
2. Left is null AND right is null
3. The node has the smallest key

<!--
Poll again after the contrasting case. Answer: B. A one-child node is not a leaf. Key order is unrelated to the leaf definition. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

Change keys while preserving shape. Does Count change?

<!--
Pause for a prediction before changing the input or model. Answer: No. Node count depends on structure, not the numeric labels or a BST ordering rule. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Complete the lesson's leaf-condition and returned-combination checkpoint. Trace the base and recursive cases before running.

[Open the lesson exercise](1701_tree_structure.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: Return zero for null; return one when both children are null; otherwise add the two recursive leaf counts. A one-child parent is not itself an extra leaf. Watch for this defect: Counting only non-null child references misses the current node. Returning one plus both child counts states the node-count contract directly.
-->

---

## Verify more than one example

Use empty, singleton, one-sided, and branching trees. Explain which value flows down and which summary returns to the caller.

<!--
Use independently predicted results. Use empty, singleton, one-sided, and branching trees. Explain which value flows down and which summary returns to the caller. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Identify base cases and smaller subproblems.
- Distinguish general, binary, and ordered trees.
- Compute returned summaries recursively.

<!--
A null subtree contributes the operation's base answer. Recursive calls must move into smaller subtrees, and a returned summary combines their results. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->

---

<!-- _class: section -->

# Tree Traversal, Returned Values, and Costs

Part 17.2 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 20 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. A hierarchy report prints each department's depth. Depth travels from parent to child; a total or height returns from children to parent. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Trace preorder, inorder, and postorder.
- Pass depth down and combine results up.
- Separate path height from full-traversal work.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. Preorder visits node-left-right; inorder visits left-node-right; postorder visits left-right-node. An uncached height computation visits all nodes even in a shallow tree. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

A hierarchy report prints each department's depth. Depth travels from parent to child; a total or height returns from children to parent.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. A hierarchy report prints each department's depth. Depth travels from parent to child; a total or height returns from children to parent. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

Visiting a node and returning a summary are different events. The placement of the visit around child calls defines traversal order.

<!--
Visiting a node and returning a summary are different events. The placement of the visit around child calls defines traversal order. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

Preorder visits node-left-right; inorder visits left-node-right; postorder visits left-right-node. An uncached height computation visits all nodes even in a shallow tree.

<!--
Preorder visits node-left-right; inorder visits left-node-right; postorder visits left-right-node. An uncached height computation visits all nodes even in a shallow tree. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 17.2

```csharp
using System;
var root = new Node(8, new Node(3, new Node(1), new Node(6)), new Node(10));
Print(root, 0); Console.WriteLine();
static void Print(Node? n, int depth) {
    if (n is null) return;
    Console.Write($"{n.Id}:{depth} ");
    Print(n.Left, depth + 1); Print(n.Right, depth + 1);
}
record Node(int Id, Node? Left = null, Node? Right = null);
```

```output
8:0 3:1 1:2 6:2 10:1 
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is 8:0 3:1 1:2 6:2 10:1. Connect each observation to the contract: Preorder visits node-left-right; inorder visits left-node-right; postorder visits left-right-node. An uncached height computation visits all nodes even in a shallow tree. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Node|Depth passed down|Preorder position |
| --- | --- | --- |
| 8|0|1 |
| 3|1|2 |
| 1|2|3 |
| 6|2|4 |
| 10|1|5 |

<!--
Walk through the rows before executing another example. Node: Depth passed down: Preorder position. 8: 0: 1. 3: 1: 2. 1: 2: 3. 6: 2: 4. 10: 1: 5. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## Which traversal fits the worked depth listing?

1. Preorder
2. Inorder
3. Postorder

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: A. Each node is printed before either child call. The parameter carries depth down the call tree. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Quantity|Source of cost |
| --- | --- |
| Path lookup|One root-to-leaf path: height |
| Full traversal|Every visited node: n |
| Recursive auxiliary stack|Active call path: height |
| Level-order queue|Pending breadth: tree width |

<!--
Quantity: Source of cost. Path lookup: One root-to-leaf path: height. Full traversal: Every visited node: n. Recursive auxiliary stack: Active call path: height. Level-order queue: Pending breadth: tree width. Preorder visits node-left-right; inorder visits left-node-right; postorder visits left-right-node. An uncached height computation visits all nodes even in a shallow tree. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

Calling a full height traversal O(log n) because the tree has logarithmic height confuses active stack depth with the number of visited nodes.

<!--
Calling a full height traversal O(log n) because the tree has logarithmic height confuses active stack depth with the number of visited nodes. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## How much work does an uncached full height calculation do?

1. Only one path
2. Θ(n) node visits
3. Constant work for every balanced tree

<!--
Poll again after the contrasting case. Answer: B. It must inspect both child subtrees. A balanced shape limits stack depth but does not remove nodes from the computation. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

Move the print after both child calls. What order results?

<!--
Pause for a prediction before changing the input or model. Answer: Postorder: children are processed before the parent. The same shape gives a different report order because the observation point moved. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Complete Label Each Node with Its Depth in preorder. Keep the root at depth zero and increment on each child call.

[Open the lesson exercise](1702_tree_traversal.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: Pass depth + 1 to both children after printing the current node. The sample prints 8:0, 3:1, 1:2, 6:2, 10:1; null produces no line. Watch for this defect: Calling a full height traversal O(log n) because the tree has logarithmic height confuses active stack depth with the number of visited nodes.
-->

---

## Verify more than one example

Trace all three visit orders on one tree. Check empty and one-sided cases; count active frames separately from total visits.

<!--
Use independently predicted results. Trace all three visit orders on one tree. Check empty and one-sided cases; count active frames separately from total visits. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Trace preorder, inorder, and postorder.
- Pass depth down and combine results up.
- Separate path height from full-traversal work.

<!--
Preorder visits node-left-right; inorder visits left-node-right; postorder visits left-right-node. An uncached height computation visits all nodes even in a shallow tree. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->

---

<!-- _class: section -->

# Binary Search Trees

Part 17.3 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 40 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. An active-ticket index must locate and close IDs. A two-child removal must preserve the successor's possible right subtree, not merely keep output sorted. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Maintain the ancestor-wide BST invariant.
- Choose one search branch by comparison.
- Preserve all keys during insertion and deletion.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. Search returns at equality, goes left for a smaller target, and right for a larger target. Updates must reattach returned subtrees and change Count once. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

An active-ticket index must locate and close IDs. A two-child removal must preserve the successor's possible right subtree, not merely keep output sorted.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. An active-ticket index must locate and close IDs. A two-child removal must preserve the successor's possible right subtree, not merely keep output sorted. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

The BST invariant applies to every descendant: all keys in a left subtree are smaller and all in a right subtree are larger under the unique-key policy.

<!--
The BST invariant applies to every descendant: all keys in a left subtree are smaller and all in a right subtree are larger under the unique-key policy. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

Search returns at equality, goes left for a smaller target, and right for a larger target. Updates must reattach returned subtrees and change Count once.

<!--
Search returns at equality, goes left for a smaller target, and right for a larger target. Updates must reattach returned subtrees and change Count once. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 17.3

```csharp
using System;
var left = new Node(3, new Node(1), new Node(6, null, new Node(7)));
var root = new Node(8, left, new Node(10));
Console.WriteLine(Contains(root, 7)); Console.WriteLine(Contains(root, 2));
static bool Contains(Node? n, int target) {
    while (n is not null) { if (target == n.Id) return true;
        n = target < n.Id ? n.Left : n.Right; }
    return false;
}
record Node(int Id, Node? Left = null, Node? Right = null);
```

```output
True
False
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is True; False. Connect each observation to the contract: Search returns at equality, goes left for a smaller target, and right for a larger target. Updates must reattach returned subtrees and change Count once. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Search target seven|Comparison|Next subtree |
| --- | --- | --- |
| At 8|7 < 8|Left |
| At 3|7 > 3|Right |
| At 6|7 > 6|Right |
| At 7|Equal|Found |

<!--
Walk through the rows before executing another example. Search target seven: Comparison: Next subtree. At 8: 7 < 8: Left. At 3: 7 > 3: Right. At 6: 7 > 6: Right. At 7: Equal: Found. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## A node nine is inside root eight's left subtree. Can direct-child checks prove validity?

1. Yes, if nine exceeds its immediate parent
2. No; the ancestor bound still applies
3. Yes, if inorder visits it last

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: B. Every node in that left subtree must be below eight. Validation must carry inherited bounds. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Deletion case|Replacement |
| --- | --- |
| Leaf|Null subtree |
| One child|That child subtree |
| Two children|Successor key plus repaired right subtree |
| Missing key|Unchanged state and failure signal |

<!--
Deletion case: Replacement. Leaf: Null subtree. One child: That child subtree. Two children: Successor key plus repaired right subtree. Missing key: Unchanged state and failure signal. Search returns at equality, goes left for a smaller target, and right for a larger target. Updates must reattach returned subtrees and change Count once. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

The inorder successor has no left child but may have a right child. Returning that child preserves keys when removing the successor's old location.

<!--
The inorder successor has no left child but may have a right child. Returning that child preserves keys when removing the successor's old location. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## What must the public wrapper do with a returned root?

1. Ignore it
2. Assign it back to the root field
3. Always create an empty tree

<!--
Poll again after the contrasting case. Answer: B. Inserting into an empty tree or removing the root changes the entry reference. Ignoring it can lose the update. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

Insert increasing IDs into an unbalanced BST. What happens to path costs?

<!--
Pause for a prediction before changing the input or model. Answer: The tree can become a one-sided chain, so height and worst-case search approach n. A simple BST does not promise balanced height. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Complete the lesson's Contains loop. Return true for seven and false for two, without scanning both branches.

[Open the lesson exercise](1703_binary_search_trees.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: Compare target and current key. Return on equality; otherwise replace the current reference with the selected child. Return false when it becomes null. Watch for this defect: The inorder successor has no left child but may have a right child. Returning that child preserves keys when removing the successor's old location.
-->

---

## Verify more than one example

Test duplicates, absent keys, all deletion cases, integer extremes, emptying, and reuse. Compare expected membership and Count as well as sorted order.

<!--
Use independently predicted results. Test duplicates, absent keys, all deletion cases, integer extremes, emptying, and reuse. Compare expected membership and Count as well as sorted order. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Maintain the ancestor-wide BST invariant.
- Choose one search branch by comparison.
- Preserve all keys during insertion and deletion.

<!--
Search returns at equality, goes left for a smaller target, and right for a larger target. Updates must reattach returned subtrees and change Count once. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->

---

<!-- _class: section -->

# Tree Queries and Verification

Part 17.4 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 35 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. A service report lists active IDs in an inclusive interval. It should keep sorted order and avoid subtrees whose keys cannot satisfy that interval. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Prune only after proving exclusion.
- Return useful range and floor results.
- Verify updates against an independent set model.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. For inclusive bounds, include an equal endpoint but do not visit the excluded side. A floor query keeps the greatest eligible candidate while descending one path. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

A service report lists active IDs in an inclusive interval. It should keep sorted order and avoid subtrees whose keys cannot satisfy that interval.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. A service report lists active IDs in an inclusive interval. It should keep sorted order and avoid subtrees whose keys cannot satisfy that interval. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

Pruning is a proof about the invariant, not a guess about likely data. A query contract specifies endpoints, ordering, and the meaning of reversed bounds.

<!--
Pruning is a proof about the invariant, not a guess about likely data. A query contract specifies endpoints, ordering, and the meaning of reversed bounds. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

For inclusive bounds, include an equal endpoint but do not visit the excluded side. A floor query keeps the greatest eligible candidate while descending one path.

<!--
For inclusive bounds, include an equal endpoint but do not visit the excluded side. A floor query keeps the greatest eligible candidate while descending one path. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 17.4

```csharp
using System; using System.Collections.Generic;
var left = new Node(20, null, new Node(30));
var right = new Node(60, new Node(50), new Node(70));
var root = new Node(40, left, right);
Console.WriteLine(string.Join(",", Range(root, 30, 60)));
static IEnumerable<int> Range(Node? n, int low, int high) {
    if (n is null || low > high) yield break;
    if (n.Id > low) foreach (int x in Range(n.Left, low, high)) yield return x;
    if (n.Id >= low && n.Id <= high) yield return n.Id;
    if (n.Id < high) foreach (int x in Range(n.Right, low, high)) yield return x;
}
record Node(int Id, Node? Left = null, Node? Right = null);
```

```output
30,40,50,60
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is 30,40,50,60. Connect each observation to the contract: For inclusive bounds, include an equal endpoint but do not visit the excluded side. A floor query keeps the greatest eligible candidate while descending one path. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| At node forty for range thirty..sixty|Action |
| --- | --- |
| Left subtree may contain thirty|Visit left |
| Forty is in range|Emit forty |
| Right subtree may contain fifty, sixty|Visit right |
| At sixty|Include sixty; prune larger right keys |

<!--
Walk through the rows before executing another example. At node forty for range thirty..sixty: Action. Left subtree may contain thirty: Visit left. Forty is in range: Emit forty. Right subtree may contain fifty, sixty: Visit right. At sixty: Include sixty; prune larger right keys. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## The current key equals the lower bound. Which side can be skipped?

1. Left, under strict unique-key BST order
2. Both children always
3. Right, even when it contains valid larger keys

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: A. Every left key is smaller and therefore excluded; the current node is included and right keys may still qualify. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Query|Expected result / storage |
| --- | --- |
| Inclusive range|Sorted matching IDs |
| Floor|Greatest key at most target, or failure |
| Level order|Queue of pending nodes |
| SameShape|Compare structure, ignoring key equality |

<!--
Query: Expected result / storage. Inclusive range: Sorted matching IDs. Floor: Greatest key at most target, or failure. Level order: Queue of pending nodes. SameShape: Compare structure, ignoring key equality. For inclusive bounds, include an equal endpoint but do not visit the excluded side. A floor query keeps the greatest eligible candidate while descending one path. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

Only checking sorted inorder output can miss lost keys. Use a reference set and compare operation results, Count, full membership, and ancestor bounds.

<!--
Only checking sorted inorder output can miss lost keys. Use a reference set and compare operation results, Count, full membership, and ancestor bounds. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## Two differently labeled trees have the same child structure. SameShape should return?

1. False because keys differ
2. True
3. True only for BSTs

<!--
Poll again after the contrasting case. Answer: B. Shape compares null/non-null structure recursively, not the stored key values or BST order. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

A target is below every stored key. What does TryFloor report?

<!--
Pause for a prediction before changing the input or model. Answer: Failure. Do not treat the default output zero as an eligible key; interpret the success signal separately. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Complete Same Shape in the lesson. Cover both-empty, one-empty, and recursively matching child positions.

[Open the lesson exercise](1704_tree_lab.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: If either node is null, return whether both are null. Otherwise compare left shapes and right shapes. Do not compare keys; the sample results are true, false, true. Watch for this defect: Only checking sorted inorder output can miss lost keys. Use a reference set and compare operation results, Count, full membership, and ancestor bounds.
-->

---

## Verify more than one example

Use inclusive endpoints, reversed bounds, empty trees, a missing floor, equal-shape/different-key trees, and a model check after every mutation.

<!--
Use independently predicted results. Use inclusive endpoints, reversed bounds, empty trees, a missing floor, equal-shape/different-key trees, and a model check after every mutation. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Prune only after proving exclusion.
- Return useful range and floor results.
- Verify updates against an independent set model.

<!--
For inclusive bounds, include an equal endpoint but do not visit the excluded side. A floor query keeps the greatest eligible candidate while descending one path. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->
