---
marp: true
theme: thinkpress-lecture
paginate: true
title: "Arrays and Linked Lists"
book: Computer Science in C#
section: "Chapter 14"
primary: "#2a6b37"
accent: "#b8860b"
---

<!-- _class: title -->

# Arrays and Linked Lists

Chapter 14 · Computer Science in C#

Business models, worked traces, and verified C# examples.

<!--
Part 14.1: Dynamic Arrays, starts on slide 2.
Part 14.2: Linked Nodes, starts on slide 17.
Part 14.3: Representation Tradeoffs and Verification, starts on slide 32.
Core reading parts share the chapter's existing three-meeting allocation, totaling 110 minutes. They are not separate fifty-minute meetings. Optional/reference parts add no required meeting. Speaker-note answers belong to the instructor output; publish student HTML with those notes stripped.
-->

---

<!-- _class: section -->

# Dynamic Arrays

Part 14.1 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 35 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. A work-order sequence begins with two slots but grows to nine orders. Resizing must preserve logical order before appending the new value. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Trace Count separately from Capacity.
- Implement growth and shifts without loss.
- Explain repeated-append copy cost.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. When full, allocate larger storage and copy existing entries in order. For middle insertion, shift right from the end so unread values are not overwritten. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

A work-order sequence begins with two slots but grows to nine orders. Resizing must preserve logical order before appending the new value.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. A work-order sequence begins with two slots but grows to nine orders. Resizing must preserve logical order before appending the new value. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

A dynamic array owns physical capacity and a logical prefix. Only positions before Count are current sequence elements.

<!--
A dynamic array owns physical capacity and a logical prefix. Only positions before Count are current sequence elements. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

When full, allocate larger storage and copy existing entries in order. For middle insertion, shift right from the end so unread values are not overwritten.

<!--
When full, allocate larger storage and copy existing entries in order. For middle insertion, shift right from the end so unread values are not overwritten. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 14.1

```csharp
using System;
int[] items = new int[2]; int count = 0, copied = 0;
for (int value = 1; value <= 9; value++) {
    if (count == items.Length) { copied += count; Array.Resize(ref items, items.Length * 2); }
    items[count++] = value;
}
Console.WriteLine($"count={count}, capacity={items.Length}, copied={copied}");
```

```output
count=9, capacity=16, copied=14
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is count=9, capacity=16, copied=14. Connect each observation to the contract: When full, allocate larger storage and copy existing entries in order. For middle insertion, shift right from the end so unread values are not overwritten. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Appends completed|Capacity|Total old entries copied |
| --- | --- | --- |
| 2|2|0 |
| 3|4|2 |
| 5|8|6 |
| 9|16|14 |

<!--
Walk through the rows before executing another example. Appends completed: Capacity: Total old entries copied. 2: 2: 0. 3: 4: 2. 5: 8: 6. 9: 16: 14. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## Count is three and capacity is eight. How many live values are copied during growth?

1. Three
2. Eight meaningful values
3. Zero for every resize

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: A. Count describes the active prefix. Capacity includes spare slots that are not current sequence values. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Operation|Work beyond the new value |
| --- | --- |
| Append with room|No old entries copied |
| Grow and append|Copy current prefix |
| Insert at front|Shift every live entry |
| Read by index|One indexed access |

<!--
Operation: Work beyond the new value. Append with room: No old entries copied. Grow and append: Copy current prefix. Insert at front: Shift every live entry. Read by index: One indexed access. When full, allocate larger storage and copy existing entries in order. For middle insertion, shift right from the end so unread values are not overwritten. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

Shifting from left to right during insertion overwrites values before they can be moved. Save the inserted item and copy the tail from high indexes downward.

<!--
Shifting from left to right during insertion overwrites values before they can be moved. Save the inserted item and copy the tail from high indexes downward. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## Why is doubling useful?

1. It makes every append constant work
2. It spreads occasional copies over many appends
3. It removes the need for Count

<!--
Poll again after the contrasting case. Answer: B. The sum of geometric growth copies is linear over the append sequence, although one resizing append is still expensive. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

Insert 30 between 20 and 40 in a three-value prefix. Which value moves first?

<!--
Pause for a prediction before changing the input or model. Answer: Move 40 into the free slot first, then store 30 in the gap. Increment Count after the new logical sequence is established. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Use Append with Growth and the work-order sequence exercise: complete growth and preserve the prefix, then test insertion at both ends.

[Open the lesson exercise](1401_dynamic_arrays.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: Allocate a larger backing array when Count equals capacity; copy indexes zero through Count minus one; write the appended value at Count; increase Count once. Watch for this defect: Shifting from left to right during insertion overwrites values before they can be moved. Save the inserted item and copy the tail from high indexes downward.
-->

---

## Verify more than one example

Check exact capacity, the first growing append, repeated growth, zero logical elements, and invalid insertion indexes with unchanged state.

<!--
Use independently predicted results. Check exact capacity, the first growing append, repeated growth, zero logical elements, and invalid insertion indexes with unchanged state. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Trace Count separately from Capacity.
- Implement growth and shifts without loss.
- Explain repeated-append copy cost.

<!--
When full, allocate larger storage and copy existing entries in order. For middle insertion, shift right from the end so unread values are not overwritten. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->

---

<!-- _class: section -->

# Linked Nodes

Part 14.2 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 40 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. An urgent work order joins the front of a linked sequence. Its new node must point to the old head before the wrapper replaces the head reference. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Follow node references without copying nodes.
- Preserve reachability when inserting.
- Update head and tail at empty boundaries.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. Preserve the intended reachable sequence and keep Count, head, and tail consistent. A singleton removal changes both endpoints. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

An urgent work order joins the front of a linked sequence. Its new node must point to the old head before the wrapper replaces the head reference.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. An urgent work order joins the front of a linked sequence. Its new node must point to the old head before the wrapper replaces the head reference. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

A node stores a value and a link. Traversal follows those links; assignment of a node reference does not duplicate the chain.

<!--
A node stores a value and a link. Traversal follows those links; assignment of a node reference does not duplicate the chain. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

Preserve the intended reachable sequence and keep Count, head, and tail consistent. A singleton removal changes both endpoints.

<!--
Preserve the intended reachable sequence and keep Count, head, and tail consistent. A singleton removal changes both endpoints. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 14.2

```csharp
using System;
Node? head = new Node(20, new Node(30));
head = new Node(10, head);
for (Node? current = head; current is not null; current = current.Next)
    Console.WriteLine(current.Value);
class Node {
    public int Value; public Node? Next;
    public Node(int value, Node? next = null) { Value = value; Next = next; }
}
```

```output
10
20
30
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is 10; 20; 30. Connect each observation to the contract: Preserve the intended reachable sequence and keep Count, head, and tail consistent. A singleton removal changes both endpoints. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Action|Reachable order |
| --- | --- |
| Initial chain|20 → 30 |
| New node points to old head|10 → 20 → 30 |
| Head replaced|Same complete chain |
| Old head discarded too early|20 and 30 can be lost |

<!--
Walk through the rows before executing another example. Action: Reachable order. Initial chain: 20 → 30. New node points to old head: 10 → 20 → 30. Head replaced: Same complete chain. Old head discarded too early: 20 and 30 can be lost. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## Which order preserves the chain?

1. Replace head, then guess its former target
2. Link new node to old head, then replace head
3. Clear all Next references first

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: B. The new link must retain the old reachable chain before the entry reference changes. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Update location|Required knowledge |
| --- | --- |
| At head|Wrapper's head reference |
| After known node|That node and its next link |
| At numeric position|Traversal to the location first |
| At singleton removal|Head and tail must both become empty |

<!--
Update location: Required knowledge. At head: Wrapper's head reference. After known node: That node and its next link. At numeric position: Traversal to the location first. At singleton removal: Head and tail must both become empty. Preserve the intended reachable sequence and keep Count, head, and tail consistent. A singleton removal changes both endpoints. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

An O(1) link update does not include the time spent locating its predecessor. Include traversal when the caller supplies only an index.

<!--
An O(1) link update does not include the time spent locating its predecessor. Include traversal when the caller supplies only an index. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## Removing the only node leaves which endpoints?

1. Both null
2. Old tail only
3. A fresh unrelated node

<!--
Poll again after the contrasting case. Answer: A. Leaving tail pointing at the removed node breaks the empty invariant and later reuse. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

The caller passes a head by value and the helper assigns a new head locally. Did the caller's head change?

<!--
Pause for a prediction before changing the input or model. Answer: No. Return the new head or pass the variable by ref, according to the stated interface. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Complete Insert at the Front: PushFront returns a new head and works on an empty chain.

[Open the lesson exercise](1402_linked_nodes.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: Create a node whose Next is the old head and return it. The client assigns the returned reference. Three pushes yield WO-30, WO-20, WO-10 and count three. Watch for this defect: An O(1) link update does not include the time spent locating its predecessor. Include traversal when the caller supplies only an index.
-->

---

## Verify more than one example

Test empty insertion, singleton removal, last-node removal, repeated labels, and reuse. Draw the links before coding each update.

<!--
Use independently predicted results. Test empty insertion, singleton removal, last-node removal, repeated labels, and reuse. Draw the links before coding each update. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Follow node references without copying nodes.
- Preserve reachability when inserting.
- Update head and tail at empty boundaries.

<!--
Preserve the intended reachable sequence and keep Count, head, and tail consistent. A singleton removal changes both endpoints. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->

---

<!-- _class: section -->

# Representation Tradeoffs and Verification

Part 14.3 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 35 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. A dispatcher alternates urgent front updates with indexed report reads. The best representation depends on that operation mix, not its name. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Count locating separately from updating.
- Test both representations against one contract.
- Justify a workload-based choice.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. Correctness comes before timing. Compare expected sequence, Count, failures, and unchanged state under invalid operations. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

A dispatcher alternates urgent front updates with indexed report reads. The best representation depends on that operation mix, not its name.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. A dispatcher alternates urgent front updates with indexed report reads. The best representation depends on that operation mix, not its name. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

Array indexing and linked traversal answer the same sequence question with different physical work. Count primitives under a stated starting position.

<!--
Array indexing and linked traversal answer the same sequence question with different physical work. Count primitives under a stated starting position. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

Correctness comes before timing. Compare expected sequence, Count, failures, and unchanged state under invalid operations.

<!--
Correctness comes before timing. Compare expected sequence, Count, failures, and unchanged state under invalid operations. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 14.3

```csharp
using System;
using System.Collections.Generic;
int[] values = { 1, 2, 3, 4, 5, 6, 7, 8 };
var chain = new LinkedList<int>(values);
var current = chain.First!; int links = 0;
while (current.Next is not null) { current = current.Next; links++; }
Console.WriteLine($"array={values[7]}, reads=1");
Console.WriteLine($"linked={current.Value}, links={links}");
```

```output
array=8, reads=1
linked=8, links=7
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is array=8, reads=1; linked=8, links=7. Connect each observation to the contract: Correctness comes before timing. Compare expected sequence, Count, failures, and unchanged state under invalid operations. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Operation on eight values|Array work|Linked work |
| --- | --- | --- |
| Read last index|1 indexed read|7 Next advances from head |
| Front insertion|8 shifts|Fixed link updates |
| Front removal after insertion|8 shifts|Fixed link updates |
| 100 last reads|100 indexed reads|700 Next advances |

<!--
Walk through the rows before executing another example. Operation on eight values: Array work: Linked work. Read last index: 1 indexed read: 7 Next advances from head. Front insertion: 8 shifts: Fixed link updates. Front removal after insertion: 8 shifts: Fixed link updates. 100 last reads: 100 indexed reads: 700 Next advances. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## A caller already holds the predecessor node. What does link insertion exclude?

1. Locating that predecessor
2. Assigning Next
3. Creating the new link relationship

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: A. The constant update claim assumes the location is already known. Numeric-position access generally requires traversal first. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Evidence|What it can establish |
| --- | --- |
| Expected sequence checks|Observable correctness |
| Primitive counts|Work under an explicit model |
| Elapsed time|Runtime behavior on one system |
| Memory layout|Locality and per-node overhead tradeoffs |

<!--
Evidence: What it can establish. Expected sequence checks: Observable correctness. Primitive counts: Work under an explicit model. Elapsed time: Runtime behavior on one system. Memory layout: Locality and per-node overhead tradeoffs. Correctness comes before timing. Compare expected sequence, Count, failures, and unchanged state under invalid operations. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

A benchmark with different answers or unequal starting data is not a fair comparison. Reset both implementations to the same sequence before each scenario.

<!--
A benchmark with different answers or unequal starting data is not a fair comparison. Reset both implementations to the same sequence before each scenario. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## Which workload tends to favor an array-backed sequence?

1. Mostly random indexed reads
2. Only head updates with known head
3. A requirement to avoid all allocation

<!--
Poll again after the contrasting case. Answer: A. Direct indexing avoids repeated traversal. Actual runtime still depends on sizes, allocation, locality, and implementation. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

Ten front updates per indexed read become ten reads per update. Must the recommendation stay the same?

<!--
Pause for a prediction before changing the input or model. Answer: No. Recompute the operation mix and include both locating and changing costs; a single slogan about cheap insertion is insufficient. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Complete the section's Lab Tasks: implement an update and justify representation choices for contrasting workloads.

[Open the lesson exercise](1403_comparison_lab.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: Use the same expected sequence and boundary tests for both implementations. Count shifts and link advances separately; explain why repeated indexed reads can dominate cheap linked updates. Watch for this defect: A benchmark with different answers or unequal starting data is not a fair comparison. Reset both implementations to the same sequence before each scenario.
-->

---

## Verify more than one example

Include empty, singleton, duplicates, invalid indexes, and reuse. State whether traversal starts at head; this demo counts seven Next advances to the eighth node.

<!--
Use independently predicted results. Include empty, singleton, duplicates, invalid indexes, and reuse. State whether traversal starts at head; this demo counts seven Next advances to the eighth node. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Count locating separately from updating.
- Test both representations against one contract.
- Justify a workload-based choice.

<!--
Correctness comes before timing. Compare expected sequence, Count, failures, and unchanged state under invalid operations. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->
