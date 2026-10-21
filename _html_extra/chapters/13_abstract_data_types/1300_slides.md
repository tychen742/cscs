---
marp: true
theme: thinkpress-lecture
paginate: true
title: "Abstract Data Types"
book: Computer Science in C#
section: "Chapter 13"
primary: "#2a6b37"
accent: "#b8860b"
---

<!-- _class: title -->

# Abstract Data Types

Chapter 13 · Computer Science in C#

Business models, worked traces, and verified C# examples.

<!--
Part 13.1: ADT Contracts, starts on slide 2.
Part 13.2: Representations and Costs, starts on slide 17.
Part 13.3: Generics for Reusable ADTs, starts on slide 32.
Part 13.4: Iterators, starts on slide 47.
Core reading parts share the chapter's existing three-meeting allocation, totaling 110 minutes. They are not separate fifty-minute meetings. Optional/reference parts add no required meeting. Speaker-note answers belong to the instructor output; publish student HTML with those notes stripped.
-->

---

<!-- _class: section -->

# ADT Contracts

Part 13.1 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 20 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. A text editor stores accepted edits and undoes the latest one. Its client cares about returned edits and Count, not whether storage is an array or linked chain. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Specify behavior without choosing storage.
- Read an observable operation history.
- Distinguish client promises from representation.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. Histories expose the contract: after Push(A), Push(B), a successful Pop returns B. A failed empty removal must preserve state. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

A text editor stores accepted edits and undoes the latest one. Its client cares about returned edits and Count, not whether storage is an array or linked chain.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. A text editor stores accepted edits and undoes the latest one. Its client cares about returned edits and Count, not whether storage is an array or linked chain. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

An abstract data type specifies values and operations. An interface can name those operations while an implementation supplies representation and algorithms.

<!--
An abstract data type specifies values and operations. An interface can name those operations while an implementation supplies representation and algorithms. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

Histories expose the contract: after Push(A), Push(B), a successful Pop returns B. A failed empty removal must preserve state.

<!--
Histories expose the contract: after Push(A), Push(B), a successful Pop returns B. A failed empty removal must preserve state. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 13.1

```csharp
using System;
using System.Collections.Generic;
var history = new Stack<string>();
history.Push("Rename"); history.Push("Move");
Console.WriteLine(history.Pop());
Console.WriteLine(history.Count);
```

```output
Move
1
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is Move; 1. Connect each observation to the contract: Histories expose the contract: after Push(A), Push(B), a successful Pop returns B. A failed empty removal must preserve state. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Operation|Returned value|Count |
| --- | --- | --- |
| Push Rename|None|1 |
| Push Move|None|2 |
| Pop|Move|1 |
| Pop|Rename|0 |

<!--
Walk through the rows before executing another example. Operation: Returned value: Count. Push Rename: None: 1. Push Move: None: 2. Pop: Move: 1. Pop: Rename: 0. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## What belongs in an ADT contract?

1. The private array capacity only
2. Operations and their observable results
3. The compiler's temporary filenames

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: B. Representation details may explain costs but do not replace the promised behavior that a client relies on. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Layer|What it states |
| --- | --- |
| Contract|Accepted operations, results, failures |
| Representation|Stored fields and links |
| Implementation|Code preserving the representation invariant |

<!--
Layer: What it states. Contract: Accepted operations, results, failures. Representation: Stored fields and links. Implementation: Code preserving the representation invariant. Histories expose the contract: after Push(A), Push(B), a successful Pop returns B. A failed empty removal must preserve state. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

A queue-like implementation can keep Count correct and still violate a stack contract by returning the oldest edit. State-only tests miss result-order defects.

<!--
A queue-like implementation can keep Count correct and still violate a stack contract by returning the oldest edit. State-only tests miss result-order defects. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## Two implementations pass every observable history. May clients use either?

1. Yes, under the same contract
2. No, all fields must match
3. Only if their arrays have equal capacity

<!--
Poll again after the contrasting case. Answer: A. Representation independence permits different private storage while preserving client expectations. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

The history is empty and TryPop fails. What should the next Count be?

<!--
Pause for a prediction before changing the input or model. Answer: Zero. Failure must not fabricate an edit or change state; the returned success flag is part of the contract. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Extend the lesson's stack history with a failed removal. Find the first row where returning A before B breaks the contract.

[Open the lesson exercise](1301_adt_contracts.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: The first Pop after Push(A), Push(B) must return B. Returning A is the first observable divergence even though Count becomes one in both implementations. Watch for this defect: A queue-like implementation can keep Count correct and still violate a stack contract by returning the oldest edit. State-only tests miss result-order defects.
-->

---

## Verify more than one example

Test returned values, success/failure, and Count after every operation. Include zero or an empty string as real stored data rather than treating a default value as failure.

<!--
Use independently predicted results. Test returned values, success/failure, and Count after every operation. Include zero or an empty string as real stored data rather than treating a default value as failure. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Specify behavior without choosing storage.
- Read an observable operation history.
- Distinguish client promises from representation.

<!--
Histories expose the contract: after Push(A), Push(B), a successful Pop returns B. A failed empty removal must preserve state. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->

---

<!-- _class: section -->

# Representations and Costs

Part 13.2 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 15 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. A report list grows over many appends. Most appends write one value, but a resize copies existing values; both behaviors belong to the workload cost. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Choose input size and a primitive operation.
- Read growth bounds under a stated case.
- Explain amortized append and auxiliary space.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. Amortized cost describes an operation sequence. It does not promise that each operation is cheap or average over random input. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

A report list grows over many appends. Most appends write one value, but a resize copies existing values; both behaviors belong to the workload cost.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. A report list grows over many appends. Most appends write one value, but a resize copies existing values; both behaviors belong to the workload cost. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

Count work before naming a growth class. Big-O bounds growth under an input size and cost model; it is not a stopwatch reading.

<!--
Count work before naming a growth class. Big-O bounds growth under an input size and cost model; it is not a stopwatch reading. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

Amortized cost describes an operation sequence. It does not promise that each operation is cheap or average over random input.

<!--
Amortized cost describes an operation sequence. It does not promise that each operation is cheap or average over random input. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 13.2

```csharp
using System;
int count = 0, capacity = 1, copied = 0;
for (int value = 0; value < 8; value++) {
    if (count == capacity) { copied += count; capacity *= 2; }
    count++;
}
Console.WriteLine($"count={count}, capacity={capacity}, copied={copied}");
```

```output
count=8, capacity=8, copied=7
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is count=8, capacity=8, copied=7. Connect each observation to the contract: Amortized cost describes an operation sequence. It does not promise that each operation is cheap or average over random input. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Before append|Capacity|Existing entries copied |
| --- | --- | --- |
| First value|1|0 |
| Second value|2|1 |
| Third value|4|2 |
| Fifth value|8|4 |

<!--
Walk through the rows before executing another example. Before append: Capacity: Existing entries copied. First value: 1: 0. Second value: 2: 1. Third value: 4: 2. Fifth value: 8: 4. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## One append copies n existing values. Does that disprove amortized O(1)?

1. Always
2. No: analyze the complete growth sequence
3. Only for strings

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: B. Occasional linear copies can be spread over geometrically many appends. The individual operation still has a linear worst case. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Growth class|Representative work |
| --- | --- |
| O(1)|One indexed read |
| O(n)|One full scan |
| O(log n)|Repeatedly halve candidates |
| O(n²)|A full nested pair scan |

<!--
Growth class: Representative work. O(1): One indexed read. O(n): One full scan. O(log n): Repeatedly halve candidates. O(n²): A full nested pair scan. Amortized cost describes an operation sequence. It does not promise that each operation is cheap or average over random input. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

Calling an append API once hides the copying it triggers. The useful primitive may be element copies, comparisons, or reference updates, not API-call count.

<!--
Calling an append API once hides the copying it triggers. The useful primitive may be element copies, comparisons, or reference updates, not API-call count. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## A scan uses one accumulator. Its auxiliary space is?

1. O(n) because input has n values
2. O(1) beyond the input
3. Equal to elapsed milliseconds

<!--
Poll again after the contrasting case. Answer: B. Distinguish additional working storage from the storage occupied by the source itself. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

Begin at capacity two and append nine values. How many existing entries are copied?

<!--
Pause for a prediction before changing the input or model. Answer: Copy 2, then 4, then 8: fourteen copies. There are also nine new-entry writes, which should be reported separately. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Complete the lesson's array-stack growth trace: identify which push crosses capacity and count the copied prefix.

[Open the lesson exercise](1302_representations_costs.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: Count logical entries, not all possible future slots. The push crossing capacity triggers allocation and copying; a later non-growing push only writes its new entry. Watch for this defect: Calling an append API once hides the copying it triggers. The useful primitive may be element copies, comparisons, or reference updates, not API-call count.
-->

---

## Verify more than one example

Check zero, one, capacity-boundary, and just-after-boundary sizes. State the case and primitive whenever comparing two bounds.

<!--
Use independently predicted results. Check zero, one, capacity-boundary, and just-after-boundary sizes. State the case and primitive whenever comparing two bounds. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Choose input size and a primitive operation.
- Read growth bounds under a stated case.
- Explain amortized append and auxiliary space.

<!--
Amortized cost describes an operation sequence. It does not promise that each operation is cheap or average over random input. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->

---

<!-- _class: section -->

# Generics for Reusable ADTs

Part 13.3 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 40 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. A count rule should work for integer IDs and decimal totals. The caller supplies the element type and the test rather than erasing all values to object. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Write reusable type-parameter code.
- Add constraints only when operations need them.
- Pass equality or ordering policies explicitly.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. Unconstrained T can be stored and returned. Ordering requires a suitable constraint or supplied comparer; equality and ordering are different business policies. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

A count rule should work for integer IDs and decimal totals. The caller supplies the element type and the test rather than erasing all values to object.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. A count rule should work for integer IDs and decimal totals. The caller supplies the element type and the test rather than erasing all values to object. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

Generics preserve a relationship between input and output types. A constraint promises a capability; a delegate passes an operation that may vary per call.

<!--
Generics preserve a relationship between input and output types. A constraint promises a capability; a delegate passes an operation that may vary per call. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

Unconstrained T can be stored and returned. Ordering requires a suitable constraint or supplied comparer; equality and ordering are different business policies.

<!--
Unconstrained T can be stored and returned. Ordering requires a suitable constraint or supplied comparer; equality and ordering are different business policies. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 13.3

```csharp
using System;
int[] ids = { 2, 7, 10 };
Console.WriteLine(Count(ids, value => value >= 7));
Console.WriteLine(Count(ids, value => value % 2 == 0));
static int Count<T>(T[] values, Func<T, bool> test) {
    int count = 0;
    foreach (T value in values) if (test(value)) count++;
    return count;
}
```

```output
2
2
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is 2; 2. Connect each observation to the contract: Unconstrained T can be stored and returned. Ordering requires a suitable constraint or supplied comparer; equality and ordering are different business policies. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Input|Supplied rule|Result |
| --- | --- | --- |
| 2, 7, 10|At least seven|2 |
| 2, 7, 10|Even|2 |
| Empty source|Any rule|0 |
| Same values|New rule|No generic algorithm rewrite |

<!--
Walk through the rows before executing another example. Input: Supplied rule: Result. 2, 7, 10: At least seven: 2. 2, 7, 10: Even: 2. Empty source: Any rule: 0. Same values: New rule: No generic algorithm rewrite. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## LastOr<T> only indexes and returns an array value. What ordering constraint is needed?

1. IComparable<T>
2. None
3. Every type must be a class

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: B. No comparison occurs. Adding an ordering constraint would reject useful element types without helping the operation. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Policy|Business meaning |
| --- | --- |
| Ordering comparer|Which report key comes first? |
| Equality comparer|Do these identifiers match? |
| Func<T,bool>|Should this element be counted? |

<!--
Policy: Business meaning. Ordering comparer: Which report key comes first?. Equality comparer: Do these identifiers match?. Func<T,bool>: Should this element be counted?. Unconstrained T can be stored and returned. Ordering requires a suitable constraint or supplied comparer; equality and ordering are different business policies. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

Converting everything to text can change numeric order and lose domain meaning. Preserve types and state the required capability instead.

<!--
Converting everything to text can change numeric order and lose domain meaning. Preserve types and state the required capability instead. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## Does generic List<Invoice> choose invoice equality for you?

1. Yes, all invoices become identical
2. No, type safety does not choose business identity
3. Yes, it always uses price

<!--
Poll again after the contrasting case. Answer: B. Homogeneous storage constrains types; the application still decides which fields define a key or ordering. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

A method compares values with CompareTo. What must its definition establish?

<!--
Pause for a prediction before changing the input or model. Answer: Either a constraint that guarantees the comparison capability or a supplied comparer that owns that policy. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Complete A Generic Last Element: return the final array element or the supplied fallback without adding a constraint.

[Open the lesson exercise](1303_generics.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: If Length is zero, return fallback; otherwise return values[Length - 1]. No arithmetic, comparison, or conversion on T is needed. Watch for this defect: Converting everything to text can change numeric order and lose domain meaning. Preserve types and state the required capability instead.
-->

---

## Verify more than one example

Use integer and string arrays, empty input, and singleton input. Check compile-time type relationships separately from runtime business validation.

<!--
Use independently predicted results. Use integer and string arrays, empty input, and singleton input. Check compile-time type relationships separately from runtime business validation. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Write reusable type-parameter code.
- Add constraints only when operations need them.
- Pass equality or ordering policies explicitly.

<!--
Unconstrained T can be stored and returned. Ordering requires a suitable constraint or supplied comparer; equality and ordering are different business policies. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->

---

<!-- _class: section -->

# Iterators

Part 13.4 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 35 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. A report may request only the first matching item. A lazy sequence should not visit the remaining data before that request needs it. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Separate a sequence from a stored collection.
- Trace yield suspension and resumption.
- Keep enumerations independent.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. Each enumeration has its own position. A sequence can be iterable without permitting indexing, and deferred work may see later source changes. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

A report may request only the first matching item. A lazy sequence should not visit the remaining data before that request needs it.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. A report may request only the first matching item. A lazy sequence should not visit the remaining data before that request needs it. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

An iterator produces values as traversal requests them. Yield return suspends a frame; it does not finish the entire sequence.

<!--
An iterator produces values as traversal requests them. Yield return suspends a frame; it does not finish the entire sequence. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

Each enumeration has its own position. A sequence can be iterable without permitting indexing, and deferred work may see later source changes.

<!--
Each enumeration has its own position. A sequence can be iterable without permitting indexing, and deferred work may see later source changes. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 13.4

```csharp
using System;
using System.Collections.Generic;
int visits = 0;
IEnumerable<int> Source() {
    for (int i = 0; i < 3; i++) { visits++; yield return i; }
}
using (var it = Source().GetEnumerator()) {
    Console.WriteLine(visits); it.MoveNext(); Console.WriteLine($"{it.Current}:{visits}");
}
```

```output
0
0:1
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is 0; 0:1. Connect each observation to the contract: Each enumeration has its own position. A sequence can be iterable without permitting indexing, and deferred work may see later source changes. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Action|Source visits |
| --- | --- |
| Construct iterator|0 |
| Obtain enumerator|0 |
| First MoveNext|1 |
| Stop and dispose|Remaining values not visited |

<!--
Walk through the rows before executing another example. Action: Source visits. Construct iterator: 0. Obtain enumerator: 0. First MoveNext: 1. Stop and dispose: Remaining values not visited. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## What happens when yield return supplies one value?

1. The method permanently exits
2. Its progress is suspended until another request
3. All remaining values are stored in an array

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: B. The iterator remembers state and resumes on the next MoveNext. Materialization is a separate operation. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Abstraction|What is guaranteed |
| --- | --- |
| IEnumerable<T>|A traversal can be requested |
| IEnumerator<T>|One traversal has a current position |
| Array / List|Additional indexing operations |
| ToArray / ToList|A stored result of enumeration |

<!--
Abstraction: What is guaranteed. IEnumerable<T>: A traversal can be requested. IEnumerator<T>: One traversal has a current position. Array / List: Additional indexing operations. ToArray / ToList: A stored result of enumeration. Each enumeration has its own position. A sequence can be iterable without permitting indexing, and deferred work may see later source changes. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

Using a single shared position for all loops makes nested enumerations interfere. Separate the collection from each enumerator's progress.

<!--
Using a single shared position for all loops makes nested enumerations interfere. Separate the collection from each enumerator's progress. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## Can an iterable be indexed at position ten?

1. Always
2. Only if the type supplies indexing too
3. Never for any collection

<!--
Poll again after the contrasting case. Answer: B. IEnumerable promises enumeration, not random access. Counting or finding an element may require traversing. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

An iterator reads a list after it changes. Must it reproduce the earlier contents?

<!--
Pause for a prediction before changing the input or model. Answer: No snapshot was promised. Materialize explicitly when a report needs a stored result independent of later source membership changes. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Complete Count Down in the lesson: yield from through one; CountDown(0) yields nothing.

[Open the lesson exercise](1304_iterators.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: Use a loop that yields the current positive value and then decrements it. Completing the body ends enumeration; do not yield an extra zero. Watch for this defect: Using a single shared position for all loops makes nested enumerations interfere. Separate the collection from each enumerator's progress.
-->

---

## Verify more than one example

Check zero, one, several values, early stopping, and two separate enumerations. Instrument visits to distinguish constructing a sequence from consuming it.

<!--
Use independently predicted results. Check zero, one, several values, early stopping, and two separate enumerations. Instrument visits to distinguish constructing a sequence from consuming it. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Separate a sequence from a stored collection.
- Trace yield suspension and resumption.
- Keep enumerations independent.

<!--
Each enumeration has its own position. A sequence can be iterable without permitting indexing, and deferred work may see later source changes. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->
