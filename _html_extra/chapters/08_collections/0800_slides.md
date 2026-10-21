---
marp: true
theme: thinkpress-lecture
paginate: true
title: "Collections"
book: "Computer Science in C#"
section: "Chapter 8"
primary: "#2a6b37"
accent: "#b8860b"
---

<!-- _class: title -->

# Collections

Chapter 8 · Computer Science in C#

<!--
Part map (1-based slide numbers): 8.1 Collection Families and Selection: slide 2; 8.2 Collection Operations and Behavior: slide 18; 8.3 Lists: slide 34; 8.4 Dictionaries: slide 50; 8.5 Optional Reading: Lambdas and LINQ: slide 66. Meeting 1: 8.1 and shared operation syntax in 8.2, 35 minutes; meeting 2: lists in 8.3 and shared references in 8.2, 40 minutes; meeting 3: dictionaries in 8.4, 35 minutes. Total 110 minutes. Query reading 8.5 is optional. Use selected examples and checks inside the existing allocation. Additional source detail remains preparation/reference reading. Every example is standalone; instructor answers remain in notes.
-->

---

<!-- _class: section -->

## Collection Families and Selection

8.1 · [8.1 reading](0801_collections.html)

Read, predict, trace, then apply.

<!--
Meeting 1: 8.1 and shared operation syntax in 8.2, 35 minutes; meeting 2: lists in 8.3 and shared references in 8.2, 40 minutes; meeting 3: dictionaries in 8.4, 35 minutes. Total 110 minutes. Query reading 8.5 is optional. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. A shop has an ordered basket, stock by product code, unique customer codes and waiting orders. These are different access questions even when every stored value is text.
-->

---

## Goals and preparation

- Choose a collection from its access question
- Compare sequence, association, uniqueness and processing-order policies
- Separate recognizing a family from implementing it

[8.1 reading](0801_collections.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: 8.1 and shared operation syntax in 8.2, 35 minutes; meeting 2: lists in 8.3 and shared references in 8.2, 40 minutes; meeting 3: dictionaries in 8.4, 35 minutes. Total 110 minutes. Query reading 8.5 is optional. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The business question

A shop has an ordered basket, stock by product code, unique customer codes and waiting orders. These are different access questions even when every stored value is text.

> What information, rule and observable result do we need?

<!--
A shop has an ordered basket, stock by product code, unique customer codes and waiting orders. These are different access questions even when every stored value is text. Ask pairs to name the input, required result and a possible wrong answer. Expected discussion: distinguish the stated business requirement from an implementation that merely runs. Use the trace in this part to make that distinction concrete.
-->

---

## Choose the question before the container

- Position: what is the next item in this sequence?
- Key: what quantity belongs to this product code?
- Membership: have we already seen this customer?

<!--
A bookstore handles many groups of values: the quantities sold during a week, the items in a customer's basket, stock quantities indexed by product code, and orders waiting for collection. Each group contains several values, but the program does different work with each one. Finding Tuesday's sales, looking up a product code, and selecting the next order are different questions. The way you organize the values should support the question you need to answer. A **collection** groups values and provides operations for working with them. Arrays are the first collection type we studied: {doc}`Chapter 7 ` introduced fixed-length, indexed sequences. Keeping that chapter separate gave us time to practice indexing, traversal, and multidimensional data. It did not put arrays outside the collection category. This chapter broadens our choices to other ready-made collection types in the .NET standard library. These classes are often called **built-in collections** because they come with .NET, although they are library types used by C#, rather than separate C# language features. Arrays have direct C# language syntax, such as `int[]`; collection classes such as `List` are library types. Both belong in our collection-family comparison. The runtime agrees. A one-dimensional array implements the same collection interfaces as `List`, including `IEnumerable`, `ICollection`, and `IList`, which is why `foreach` works on an array and why a method that accepts a collection accepts an array.[^0801_collections-array-interfaces] What an array cannot do is change its length; {ref}`a run-time check ` in the Collection Operations section shows the difference. This section introduces the big ideas before the detailed syntax: what a collection promises, how values can be accessed, and how to choose among collection families. You will see eight useful families and small demonstrations of their behavior. The next two sections develop `List` and `Dictionary` in depth. For the other families, your goal here is to recognize the need they address and predict their basic behavior, not to memorize every method or implement a data structure.  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. Do not choose a family only because its name sounds familiar. Ask what information is used for access and what order or uniqueness rule must hold. Linked-list, set, stack, queue and priority-queue implementations are developed later.
-->

---

## A policy constrains observable behavior

- A list keeps sequence order while its size can change
- A dictionary associates unique keys with values
- A set represents distinct membership

<!--
**Reading path:** First explain the access question, compare the families, and connect their operations. Work through arrays/lists, dictionaries, and shared references before the order-summary exercise. Use the linked-list, set, stack/queue, and priority-queue demonstrations to recognize their policies; their implementations and detailed APIs belong to later chapters. The operation tables are references to revisit, not a list of signatures to memorize in one sitting.  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. Do not choose a family only because its name sounds familiar. Ask what information is used for access and what order or uniqueness rule must hold. Linked-list, set, stack, queue and priority-queue implementations are developed later.
-->

---

## Match a business question to a family

| Business requirement | Family | Why |
| --- | --- | --- |
| Fixed five-day counts | Array | Known indexed length |
| Growing basket | List | Resizable ordered sequence |
| Stock by SKU | Dictionary | Key-to-value lookup |
| Unique customers | Set | Membership without duplicates |
| Oldest waiting order | Queue | FIFO |

<!--
Do not choose a family only because its name sounds familiar. Ask what information is used for access and what order or uniqueness rule must hold. Linked-list, set, stack, queue and priority-queue implementations are developed later. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
using System.Collections.Generic;
var basket = new List<string> { "PEN", "PEN" };
var stock = new Dictionary<string, int> { ["PEN"] = 12 };
Console.WriteLine($"Basket entries: {basket.Count}");
Console.WriteLine($"Product codes: {stock.Count}");
Console.WriteLine($"PEN stock: {stock["PEN"]}");
```

```output
Basket entries: 2
Product codes: 1
PEN stock: 12
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is 'Basket entries: 2\nProduct codes: 1\nPEN stock: 12\n'. Do not choose a family only because its name sounds familiar. Ask what information is used for access and what order or uniqueness rule must hold. Linked-list, set, stack, queue and priority-queue implementations are developed later. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

You know a product code and need its stock quantity. Which access model fits directly?

1. A key-to-value association
2. A stack of unrelated counts
3. A random position

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer A. The meaningful key identifies the associated quantity; an index is only a sequence position. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

## Processing order is another policy

- A stack is last in, first out
- A queue is first in, first out
- A priority queue selects by priority, not necessarily arrival

<!--
An **element** is one item stored in a collection. An array of sales quantities has numbers as its elements; a list of product codes has strings. A dictionary stores entries that associate a key with a value. The surrounding collection gives these items an organization and a set of supported actions. Several operations recur across collection families: | Operation | Question it answers | Bookstore example | | --- | --- | --- | | Add or insert | How does a new item enter the group? | Add a product code to the current basket. | | Retrieve | How do you obtain a particular item? | Find the stock quantity associated with a product code. | | Update | How does stored information change? | Replace a recorded quantity after a stock check. | | Remove | How does an item leave the group? | Remove a canceled item from a basket. | | Membership test | Is this item or key present? | Check whether a customer has already used a promotion. | | Traverse | How do you visit the stored items? | Print every item on an order. | | Inspect size | How many items are stored? | Count the orders waiting for collection. | Not every collection offers every operation, and the method names differ. A stack deliberately limits which item you retrieve next. An array lets you replace an element but does not let you add a new position to that same array. The operations and their rules form a collection's **contract**: the behavior a programmer can rely on. A **data structure** is an organization of stored information that supports operations. A library collection gives you an already implemented data structure through a public interface of methods and properties. You can use a list before you know how its storage grows, just as you can call `Math.Round` before implementing a rounding algorithm. Later chapters examine the implementation choices behind these operations. Keep the question of behavior separate from the question of storage. A queue promises a first-in, first-out processing rule. That rule does not require you to know whether a particular implementation uses an array or linked nodes. Conversely, the fact that two collections both store strings does not mean that their access rules are interchangeable.  Do not choose a family only because its name sounds familiar. Ask what information is used for access and what order or uniqueness rule must hold. Linked-list, set, stack, queue and priority-queue implementations are developed later. Ask students to explain the difference this concept makes to the caller or to the person using the result.
-->

---

## Different ordering policies answer different service questions

- A stack returns the newest unfinished action; a queue returns the oldest waiting request.
- A priority queue chooses by priority; equal-priority order needs a separate contract.

<!--
For arrivals A then B, a stack removes B while a queue removes A. A lower numeric priority is selected first by .NET PriorityQueue’s default comparer. These are recognition examples; implementation and full API details belong to later data-structure chapters.
-->

---

## Challenge a plausible wrong result

Check whether duplicates, changing size, missing keys and processing order are meaningful. An operation table is a reference, not a requirement to memorize every API.

> Name one changed input that would expose a wrong boundary, missing case or unintended state change.

<!--
Ask for a counterexample before modifying the program. Answer B. A queue’s first-in-first-out rule preserves arrival processing; a stack would process the newest first. The trace provides an independent explanation of the ordinary case. Do not choose a family only because its name sounds familiar. Ask what information is used for access and what order or uniqueness rule must hold. Linked-list, set, stack, queue and priority-queue implementations are developed later.
-->

---

<!-- _class: check -->

## Quick check 2

Orders must be handled in arrival order. Which policy matches?

1. LIFO
2. FIFO
3. Distinct membership

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. A queue’s first-in-first-out rule preserves arrival processing; a stack would process the newest first. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Homework: Collection Choice and Transfer**

Use the existing concept and transfer cases to justify a collection choice. State the access question and an operation whose behavior matters.

[Open the existing practice](assignments/homework.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Retain all existing cscs-collections-transfer assessment IDs. Strong reasoning distinguishes position from key, duplicate entries from uniqueness, and FIFO from LIFO. Do not require later implementation details or the optional LINQ reading. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- Check whether duplicates, changing size, missing keys and processing order are meaningful. An operation table is a reference, not a requirement to memorize every API.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. Do not choose a family only because its name sounds familiar. Ask what information is used for access and what order or uniqueness rule must hold. Linked-list, set, stack, queue and priority-queue implementations are developed later. For the Your Turn activity, the instructor answer is: Retain all existing cscs-collections-transfer assessment IDs. Strong reasoning distinguishes position from key, duplicate entries from uniqueness, and FIFO from LIFO. Do not require later implementation details or the optional LINQ reading.
-->

---

## Vocabulary to explain, not memorize

- Collection: group with operations
- access model: how an item is located
- policy: promised ordering/uniqueness behavior

[Chapter objectives and glossary](0800_data_collections.html)

<!--
Ask students to use each term in an explanation of this part’s case. Tie the vocabulary to the actions in the goals: Choose a collection from its access question; Compare sequence, association, uniqueness and processing-order policies; Separate recognizing a family from implementing it. A correct definition without a correct trace is not yet sufficient evidence of application.
-->

---

<!-- _class: recap -->

## Recap and next step

- Choose a collection from its access question
- Compare sequence, association, uniqueness and processing-order policies
- Separate recognizing a family from implementing it

[8.1 reading](0801_collections.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. Do not choose a family only because its name sounds familiar. Ask what information is used for access and what order or uniqueness rule must hold. Linked-list, set, stack, queue and priority-queue implementations are developed later. Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: 8.1 and shared operation syntax in 8.2, 35 minutes; meeting 2: lists in 8.3 and shared references in 8.2, 40 minutes; meeting 3: dictionaries in 8.4, 35 minutes. Total 110 minutes. Query reading 8.5 is optional.
-->

---

<!-- _class: section -->

## Collection Operations and Behavior

8.2 · [8.2 reading](0802_collection_operations.html)

Read, predict, trace, then apply.

<!--
Meeting 1: 8.1 and shared operation syntax in 8.2, 35 minutes; meeting 2: lists in 8.3 and shared references in 8.2, 40 minutes; meeting 3: dictionaries in 8.4, 35 minutes. Total 110 minutes. Query reading 8.5 is optional. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. An order stores quantities 2,1 and 3 in  a list and saves the total under order code ORD-101. The sequence and the keyed summary serve different roles.
-->

---

## Goals and preparation

- Read an operation as a result and a state change
- Use generic list/dictionary operations
- Explain shared references and explicit outer copies

[8.2 reading](0802_collection_operations.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: 8.1 and shared operation syntax in 8.2, 35 minutes; meeting 2: lists in 8.3 and shared references in 8.2, 40 minutes; meeting 3: dictionaries in 8.4, 35 minutes. Total 110 minutes. Query reading 8.5 is optional. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The business question

An order stores quantities 2,1 and 3 in  a list and saves the total under order code ORD-101. The sequence and the keyed summary serve different roles.

> What information, rule and observable result do we need?

<!--
An order stores quantities 2,1 and 3 in  a list and saves the total under order code ORD-101. The sequence and the keyed summary serve different roles. Ask pairs to name the input, required result and a possible wrong answer. Expected discussion: distinguish the stated business requirement from an implementation that merely runs. Use the trace in this part to make that distinction concrete.
-->

---

## Every operation has a before and after

- Some operations return an item without removing it
- Some remove and also return an item
- Some mutate state while returning a success flag

<!--
The family map tells you which question a collection can answer. Now describe an operation with three parts: what must already be true, what changes, and what result the caller receives. This makes the cross-family tables below more useful than a list of names to memorize. Consider the sequence of product codes PEN, PAD, PEN. Removing by value selects an occurrence matching a value; removing by index selects a position. Popping a stack or dequeuing a queue selects according to processing order instead. Even when each operation reduces a count by one, it need not select the same element. Compare the selection rule before comparing the method spelling. | Intended action | Information supplied | Question to ask before calling | | --- | --- | --- | | Remove a known product code from a list | Value | Which matching occurrence is removed? | | Remove the third list position | Index 2 | Does that position exist now? | | Take the next queued request | No identifying key | Is the queue nonempty? | | Find stock for a product code | Key | What happens when that key is absent? | Returning a value and mutating a collection are independent possibilities. A lookup can return a result without removing anything. A removal can both change storage and report success. A Try-style operation supplies a Boolean success signal so that an absent result can be distinguished from a legitimate default value. Read both the success flag and the output value under the documented contract. Traversal is also an operation with a contract. Foreach provides a shared language form, but it does not make the collection families share one universal order. A sequence has positional order; a work queue has a service policy; a keyed collection has its own enumeration guarantees. If a report requires sorted product codes, request or construct that order explicitly instead of assuming that lookup storage supplies it. Guided comparison: there are two PEN entries. Explain how Remove("PEN"), RemoveAt(2), and a queue Dequeue could affect a three-item group differently. Draw the before/after contents and identify the selected item. Then explain why the original array cannot shrink merely because an element has been set to an empty string. Replacing a value is not changing the length of the same array. For related explanation, see the further reading below.[^development-reading]  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The list count is three but its sum is six; they answer different questions. The dictionary has one entry for one saved order. Keep those three counts distinct when reading output.
-->

---

## Generic types state the stored types

- `List<int>` stores integer elements
- `Dictionary<string,int>` maps string keys to integer values
- The namespace is System.Collections.Generic

<!--
Start with the concrete list and dictionary comparison next: a list selects a position, while a dictionary selects a key. Read each operation as a state change plus a result. Then use the shared tables to recognize the corresponding rules in other families. Their detailed implementations are developed in later chapters; the current examples give an early exposure to those policies.  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The list count is three but its sum is six; they answer different questions. The dictionary has one entry for one saved order. Keep those three counts distinct when reading output.
-->

---

## Accumulate then associate a summary

| Quantity visited | Running total | Saved order total |
| ---: | ---: | --- |
| 2 | 2 | Not saved yet |
| 1 | 3 | Not saved yet |
| 3 | 6 | Not saved yet |
| Store ORD-101 | 6 | ORD-101 → 6 |

<!--
The list count is three but its sum is six; they answer different questions. The dictionary has one entry for one saved order. Keep those three counts distinct when reading output. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
using System.Collections.Generic;
var quantities = new List<int> { 2, 1, 3 };
int total = 0;
foreach (int quantity in quantities) total += quantity;
var saved = new Dictionary<string, int>();
saved["ORD-101"] = total;
Console.WriteLine($"Line items: {quantities.Count}");
Console.WriteLine($"Saved total: {saved["ORD-101"]}");
```

```output
Line items: 3
Saved total: 6
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is 'Line items: 3\nSaved total: 6\n'. The list count is three but its sum is six; they answer different questions. The dictionary has one entry for one saved order. Keep those three counts distinct when reading output. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

The order has quantities 2,1 and 3. Which pair is correct?

1. Count 6,total 3
2. Count 3,total 6
3. Count 1,total 3

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. Count measures elements, while the accumulator sums their values. The saved dictionary has one order entry. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

## Shared references remain shared

- Assigning another variable does not copy the list
- A new List built from the old one copies the outer sequence
- Changing list structure is different from changing a local reference

<!--
A collection's **family** tells you how it organizes access. Its **element type** tells you what values it stores. These are separate choices: a list of integers and a list of strings use the same sequence operations, but they store different kinds of values. A **generic type** is defined using one or more **type parameters**, which are placeholders for types. In documentation, `List` means a list whose element type is represented by `T`. When you write `List`, `string` is the **type argument** you have supplied for that parameter. The library provides the reusable class; you choose its type arguments when declaring the collection. | Library notation | Example in a program | Meaning of the type arguments | | --- | --- | --- | | `List` | `List` | Each element is a string. | | `HashSet` | `HashSet` | Each distinct element is an integer. | | `Dictionary` | `Dictionary` | Keys are strings; values are integers. | | `PriorityQueue` | `PriorityQueue` | Elements are strings; priorities are integers. | Generic collections provide **type safety**: the compiler checks whether supplied values can be used as the declared types. A `List` accepts integers; it will not accept the string `"twelve"`. This catches a mismatch before the program runs. It does not establish that every integer is appropriate: a negative stock quantity is still an integer, so business validation remains your responsibility.  The list count is three but its sum is six; they answer different questions. The dictionary has one entry for one saved order. Keep those three counts distinct when reading output. Ask students to explain the difference this concept makes to the caller or to the person using the result.
-->

---

## Trace alias and outer-copy behavior

- An alias to a one-item basket sees a later Add; its Count becomes 2.
- A new List copied before the Add still has Count 1.

<!--
Let basket initially contain NOTEBOOK; sameBasket=basket and snapshot=new List(basket). Adding PEN through sameBasket changes basket and sameBasket to two entries, while snapshot remains one. That is a copy of the outer sequence; future mutable-object elements require the Chapter11reference model.
-->

---

## Challenge a plausible wrong result

Check empty input, repeated values and a list alias versus an explicit copy. Verify both returned information and mutated state.

> Name one changed input that would expose a wrong boundary, missing case or unintended state change.

<!--
Ask for a counterexample before modifying the program. Answer B. Assignment shares the list reference. Constructing a new outer List is a different operation. The trace provides an independent explanation of the ordinary case. The list count is three but its sum is six; they answer different questions. The dictionary has one entry for one saved order. Keep those three counts distinct when reading output.
-->

---

<!-- _class: check -->

## Quick check 2

With alias = basket, alias.Add("PEN") changes what?

1. Only an independent copy
2. The same list reached through basket
3. Neither variable

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. Assignment shares the list reference. Constructing a new outer List is a different operation. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Interactive Exercise: An Order Summary**

Complete the existing summary exercise. Sum with foreach, save under ORD-101 and print the requested count and stored result. Then predict an empty list.

[Open the existing practice](0802_collection_operations.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Existing exercise cell collection-summary-question. Expected original lines: Line items: 3 and Saved total: 6. Empty input gives line-item count 0 and  saved total 0; one order-summary entry can still be stored. Do not confuse the dictionary entry count with the list count. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- Check empty input, repeated values and a list alias versus an explicit copy. Verify both returned information and mutated state.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. The list count is three but its sum is six; they answer different questions. The dictionary has one entry for one saved order. Keep those three counts distinct when reading output. For the Your Turn activity, the instructor answer is: Existing exercise cell collection-summary-question. Expected original lines: Line items: 3 and Saved total: 6. Empty input gives line-item count 0 and  saved total 0; one order-summary entry can still be stored. Do not confuse the dictionary entry count with the list count.
-->

---

## Vocabulary to explain, not memorize

- Generic: type-parameterized container
- traversal: visit entries
- outer copy: separate sequence storage

[Chapter objectives and glossary](0800_data_collections.html)

<!--
Ask students to use each term in an explanation of this part’s case. Tie the vocabulary to the actions in the goals: Read an operation as a result and a state change; Use generic list/dictionary operations; Explain shared references and explicit outer copies. A correct definition without a correct trace is not yet sufficient evidence of application.
-->

---

<!-- _class: recap -->

## Recap and next step

- Read an operation as a result and a state change
- Use generic list/dictionary operations
- Explain shared references and explicit outer copies

[8.2 reading](0802_collection_operations.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. The list count is three but its sum is six; they answer different questions. The dictionary has one entry for one saved order. Keep those three counts distinct when reading output. Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: 8.1 and shared operation syntax in 8.2, 35 minutes; meeting 2: lists in 8.3 and shared references in 8.2, 40 minutes; meeting 3: dictionaries in 8.4, 35 minutes. Total 110 minutes. Query reading 8.5 is optional.
-->

---

<!-- _class: section -->

## Lists

8.3 · [8.3 reading](0803_list.html)

Read, predict, trace, then apply.

<!--
Meeting 1: 8.1 and shared operation syntax in 8.2, 35 minutes; meeting 2: lists in 8.3 and shared references in 8.2, 40 minutes; meeting 3: dictionaries in 8.4, 35 minutes. Total 110 minutes. Query reading 8.5 is optional. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. A desk stores request codes in a growing sequence. Removing one request closes the gap, so positions later in the list change.
-->

---

## Goals and preparation

- Use list insertion, removal, indexing and Count
- Distinguish removal by value from removal by position
- Traverse safely when structure may change

[8.3 reading](0803_list.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: 8.1 and shared operation syntax in 8.2, 35 minutes; meeting 2: lists in 8.3 and shared references in 8.2, 40 minutes; meeting 3: dictionaries in 8.4, 35 minutes. Total 110 minutes. Query reading 8.5 is optional. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The business question

A desk stores request codes in a growing sequence. Removing one request closes the gap, so positions later in the list change.

> What information, rule and observable result do we need?

<!--
A desk stores request codes in a growing sequence. Removing one request closes the gap, so positions later in the list change. Ask pairs to name the input, required result and a possible wrong answer. Expected discussion: distinguish the stated business requirement from an implementation that merely runs. Use the trace in this part to make that distinction concrete.
-->

---

## Count defines the valid element positions

- Read indexes 0 through  Count - 1
- Insert also permits the append position Count
- Capacity is reserved internal space, not stored item count

<!--
Arrays are fine if you know ahead of time how long your sequence of items is. Then you create your array with that length, and you are all set. If you want a variable sized container, you are likely to want a `List`. List is a type of collection that is used when the number of elements is unknown. As with arrays, you might want a collection of any particular type. Unfortunately, you cannot use the simple notation of arrays to specify the type of element in a `List`. Array syntax is *built into* the language. Lists are handled in the *library* of types provided by C# from .NET. There are many situations where one general operation should work with different element types.  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The first insertion shifts the suffix right; removal closes the gap and shifts later elements left. Removing a missing value returns false and leaves the list unchanged. No element at index Count is available to read.
-->

---

## Value and position removal have different contracts

- Remove(value) removes the first matching value
- Remove returns whether a change occurred
- RemoveAt(index) removes a known position

<!--
A bookstore basket starts empty and changes as a customer selects or cancels items. We need the indexed access and traversal learned with arrays, but we cannot predict the final number of items. The big idea is a **resizable ordered sequence**: `List` provides indexed positions while managing changes in size. Follow one distinction throughout this lesson: changing a value at an existing position is an update; inserting or removing an item changes the sequence and can change later positions. Use the operation comparison in {ref}`collection-operation-syntax` as a map while learning these calls. The library operation contracts are documented in the .NET API reference.[^0802_list-list-api]  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The first insertion shifts the suffix right; removal closes the gap and shifts later elements left. Removing a missing value returns false and leaves the list unchanged. No element at index Count is available to read.
-->

---

## Trace insertion and gap closure

| Operation | List contents | Count |
| --- | --- | ---: |
| Start | 10,20,30 | 3 |
| Insert 15 at  position 1 | 10,15,20,30 | 4 |
| RemoveAt(0) | 15,20,30 | 3 |
| Remove missing 99 | 15,20,30 | 3 |

<!--
The first insertion shifts the suffix right; removal closes the gap and shifts later elements left. Removing a missing value returns false and leaves the list unchanged. No element at index Count is available to read. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
using System.Collections.Generic;
var byValue = new List<int> { 2, 7, 2, 9 };
var byPosition = new List<int>(byValue);
Console.WriteLine(byValue.Remove(2));
byPosition.RemoveAt(2);
Console.WriteLine(string.Join(", ", byValue));
Console.WriteLine(string.Join(", ", byPosition));
```

```output
True
7, 2, 9
2, 7, 9
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is 'True\n7, 2, 9\n2, 7, 9\n'. The first insertion shifts the suffix right; removal closes the gap and shifts later elements left. Removing a missing value returns false and leaves the list unchanged. No element at index Count is available to read. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

For 2,7,2,9, Remove(2) removes which element?

1. The first value 2
2. The element at index 2
3. Every value 2

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer A. Value removal selects the first match. RemoveAt(2) instead selects the third element, which happens also to hold2 in  this example. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

## Structural mutation can invalidate traversal

- Do not add/remove through the same list during foreach
- A backward index loop can safely remove selected positions
- Filtering displayed output need not mutate the list

<!--
C# collection types use *generics*: a type in angle brackets after a class name tells the compiler what element type the collection holds. The generic collection types live in the `System.Collections.Generic` namespace, which some project templates import through implicit usings. Include `using System.Collections.Generic;` when those imports are not enabled. The generic list syntax is: To create a list, supply a type argument for the elements it will store: The first insertion shifts the suffix right; removal closes the gap and shifts later elements left. Removing a missing value returns false and leaves the list unchanged. No element at index Count is available to read. Ask students to explain the difference this concept makes to the caller or to the person using the result.
-->

---

## Remove safely when positions shift

- A forward removal can move the next unvisited item into the current position.
- A backward index scan keeps not-yet-visited lower positions stable.

<!--
For1,2,4,5, a naive forward index loop can remove2and then skip the4that shifts left. A reverse scan checks from the last index down and removes even entries without invalidating future lower indexes. A foreach over the same list must not be structurally mutated.
-->

---

## Challenge a plausible wrong result

Check repeated values, missing removal, first/last positions and empty input. For removal during a scan, explain why the remaining positions stay valid.

> Name one changed input that would expose a wrong boundary, missing case or unintended state change.

<!--
Ask for a counterexample before modifying the program. Answer C. Reserved capacity does not create eight stored elements; only indexes 0,1,2 are  currently valid. The trace provides an independent explanation of the ordinary case. The first insertion shifts the suffix right; removal closes the gap and shifts later elements left. Removing a missing value returns false and leaves the list unchanged. No element at index Count is available to read.
-->

---

<!-- _class: check -->

## Quick check 2

A list has Count 3 and  Capacity 8. Which index can be read?

1. 7
2. 3
3. 2

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer C. Reserved capacity does not create eight stored elements; only indexes 0,1,2 are  currently valid. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Exercise: Generic List**

Complete the existing qualifying-scores exercise. Print values at least 80 without removing lower scores, then test an empty list and the exact cutoff.

[Open the existing practice](0803_list.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Code-comment assessment ID ch08-list-generics and cell ch8-e76194c4 remain unchanged. Original qualifying values are 85,91,100 in  order. Filtering output does not mutate the source list. Include80 exactly ; no qualifying values should produce no score lines. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- Check repeated values, missing removal, first/last positions and empty input. For removal during a scan, explain why the remaining positions stay valid.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. The first insertion shifts the suffix right; removal closes the gap and shifts later elements left. Removing a missing value returns false and leaves the list unchanged. No element at index Count is available to read. For the Your Turn activity, the instructor answer is: Code-comment assessment ID ch08-list-generics and cell ch8-e76194c4 remain unchanged. Original qualifying values are 85,91,100 in  order. Filtering output does not mutate the source list. Include80 exactly ; no qualifying values should produce no score lines.
-->

---

## Vocabulary to explain, not memorize

- Count: stored items
- Capacity: reserved slots
- structural change: insertion/removal shifts positions

[Chapter objectives and glossary](0800_data_collections.html)

<!--
Ask students to use each term in an explanation of this part’s case. Tie the vocabulary to the actions in the goals: Use list insertion, removal, indexing and Count; Distinguish removal by value from removal by position; Traverse safely when structure may change. A correct definition without a correct trace is not yet sufficient evidence of application.
-->

---

<!-- _class: recap -->

## Recap and next step

- Use list insertion, removal, indexing and Count
- Distinguish removal by value from removal by position
- Traverse safely when structure may change

[8.3 reading](0803_list.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. The first insertion shifts the suffix right; removal closes the gap and shifts later elements left. Removing a missing value returns false and leaves the list unchanged. No element at index Count is available to read. Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: 8.1 and shared operation syntax in 8.2, 35 minutes; meeting 2: lists in 8.3 and shared references in 8.2, 40 minutes; meeting 3: dictionaries in 8.4, 35 minutes. Total 110 minutes. Query reading 8.5 is optional.
-->

---

<!-- _class: section -->

## Dictionaries

8.4 · [8.4 reading](0804_dictionary.html)

Read, predict, trace, then apply.

<!--
Meeting 1: 8.1 and shared operation syntax in 8.2, 35 minutes; meeting 2: lists in 8.3 and shared references in 8.2, 40 minutes; meeting 3: dictionaries in 8.4, 35 minutes. Total 110 minutes. Query reading 8.5 is optional. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. The stock desk contains PEN→12 and  BOOK→0. BOOK is present but sold out; BAG is absent. A lookup must preserve that distinction.
-->

---

## Goals and preparation

- Create and update key-to-value associations
- Distinguish a missing key from a valid zero value
- Count words using an explicit normalization and report-order policy

[8.4 reading](0804_dictionary.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: 8.1 and shared operation syntax in 8.2, 35 minutes; meeting 2: lists in 8.3 and shared references in 8.2, 40 minutes; meeting 3: dictionaries in 8.4, 35 minutes. Total 110 minutes. Query reading 8.5 is optional. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The business question

The stock desk contains PEN→12 and  BOOK→0. BOOK is present but sold out; BAG is absent. A lookup must preserve that distinction.

> What information, rule and observable result do we need?

<!--
The stock desk contains PEN→12 and  BOOK→0. BOOK is present but sold out; BAG is absent. A lookup must preserve that distinction. Ask pairs to name the input, required result and a possible wrong answer. Expected discussion: distinguish the stated business requirement from an implementation that merely runs. Use the trace in this part to make that distinction concrete.
-->

---

## Keys identify entries rather than sequence positions

- The key type and value type may differ
- An indexer assignment inserts or updates
- Add rejects a duplicate key instead of updating it

<!--
We have explored several ways of storing a collection of the same type of data: - arrays: built-in syntax, unchanging size of the collection - List: generic class type, allows the size of the collection to grow Both approaches allow reference to data elements using a numerical index between square brackets, as in `words[i]`. The index provides an order for the elements, but there is no meaning to the index beyond the sequence order. Sometimes, we want to look up data based on a more meaningful key, as in a dictionary: given a word, you can look up the definition. C# uses the type name [Dictionary](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2?view=net-8.0), but with greater generality than in nontechnical use. In a regular dictionary, you start with a word, and look up the definition. The generalization is to have some piece of data that leads you to (or *maps* to) another piece of data. The computer science jargon is that a **key** leads you to a **value**. In a normal dictionary, these are both likely to be strings, but in the C# generalization, the possible types of key and value are much more extensive. Hence the generic `Dictionary` type requires you to specify *both a type for the key and a type for the value*.  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. A dictionary miss still assigns the default integer to the out variable. Branch on found, not quantity !=0. Updating PEN from12 to 15keeps the dictionary entry count unchanged; assigning BAG would insert a new key, which the exercise forbids.
-->

---

## Use the lookup’s success result

- TryGetValue returns whether the key exists
- Its out value supplies the associated value on success
- A default zero on failure is not proof of a real zero-stock entry

<!--
A stock clerk knows a product code, not its position in a list. Searching for that code and coordinating a separate quantity list is unnecessary work when the program can directly associate the code with its quantity. The big idea is a **key-to-value association**. Retrieval, updating stock, and counting repeated requests all reuse that association. Keep three questions separate: Is the key present? What value belongs to it? Does this operation insert a new entry or update an existing one? Keys identify entries; they are not sequence positions. The examples below retain the translation dictionary, then transfer the same pattern to counting. Follow the arrow from key to value. The diagram does not promise enumeration order or any physical storage layout. The library operation contracts are documented in the .NET API reference.[^0803_dictionary-dictionary-api]  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. A dictionary miss still assigns the default integer to the out variable. Branch on found, not quantity !=0. Updating PEN from12 to 15keeps the dictionary entry count unchanged; assigning BAG would insert a new key, which the exercise forbids.
-->

---

## Trace presence separately from quantity

| Requested code | Found? | Quantity | Meaning |
| --- | --- | ---: | --- |
| PEN | true | 12 | Known with stock |
| BOOK | true | 0 | Known, zero stock |
| BAG | false | 0 from failed lookup | Unknown product |

<!--
A dictionary miss still assigns the default integer to the out variable. Branch on found, not quantity !=0. Updating PEN from12 to 15keeps the dictionary entry count unchanged; assigning BAG would insert a new key, which the exercise forbids. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
using System.Collections.Generic;
var stock = new Dictionary<string, int> { ["PEN"] = 12, ["BOOK"] = 0 };
Console.WriteLine(stock.TryGetValue("BOOK", out int known));
Console.WriteLine(known);
Console.WriteLine(stock.TryGetValue("BAG", out int missing));
Console.WriteLine(missing);
```

```output
True
0
False
0
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is 'True\n0\nFalse\n0\n'. A dictionary miss still assigns the default integer to the out variable. Branch on found, not quantity !=0. Updating PEN from12 to 15keeps the dictionary entry count unchanged; assigning BAG would insert a new key, which the exercise forbids. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

TryGetValue returns true and quantity 0. What does that mean?

1. Missing product
2. Present product with zero stock
3. Invalid dictionary

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. Presence comes from the Boolean result, not whether the associated integer happens to be zero. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

## A report needs explicit text and order policies

- Normalize before using words as keys
- Increment an existing count or initialize a new one
- Sort a copied key list when the output requires an order

<!--
 That is quite a mouthful! The C# `var` keyword (implicitly-typed local variable) syntax is handy to shorten it as you do not have to repeat the type name:  A dictionary miss still assigns the default integer to the out variable. Branch on found, not quantity !=0. Updating PEN from12 to 15keeps the dictionary entry count unchanged; assigning BAG would insert a new key, which the exercise forbids. Ask students to explain the difference this concept makes to the caller or to the person using the result.
-->

---

## A word counter combines four explicit policies

- Choose token separators, case normalization and ignored words before counting.
- Sort copied keys under the report comparer before printing.

<!--
The lesson normalizes The pen, pen and book!, ignores articles/conjunctions/empty tokens and reports book1then pen2. Hash lookup is expected constant time under suitable assumptions, not an unconditional guarantee independent of key/hash behavior. Dictionary traversal is not the report ordering policy.
-->

---

## Challenge a plausible wrong result

Check known positive stock, known zero stock, missing key, duplicate insertion and update. Use sorted copied keys for reproducible ordered reports.

> Name one changed input that would expose a wrong boundary, missing case or unintended state change.

<!--
Ask for a counterexample before modifying the program. Answer B. Make report ordering explicit. Dictionary lookup is keyed; its enumeration is not an alphabetical-order contract. The trace provides an independent explanation of the ordinary case. A dictionary miss still assigns the default integer to the out variable. Branch on found, not quantity !=0. Updating PEN from12 to 15keeps the dictionary entry count unchanged; assigning BAG would insert a new key, which the exercise forbids.
-->

---

<!-- _class: check -->

## Quick check 2

A report must print product codes alphabetically. What should the program do?

1. Assume dictionary traversal is always sorted
2. Copy the keys and sort under a chosen comparer
3. Use numeric indexes into the dictionary

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. Make report ordering explicit. Dictionary lookup is keyed; its enumeration is not an alphabetical-order contract. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Guided Practice: Update Stock Safely**

Complete the existing safe stock update. Add delivery only to a known requested product; preserve an unknown code as unknown.

[Open the existing practice](0804_dictionary.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Existing exercise cell ch8-a21164ba. PEN 12 plus 3 must  print PEN: 15; BAGmust print Unknown product without insertion; BOOK 0 plus 3 is  a valid update to 3. Branch on TryGetValue success rather than a nonzero quantity test. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- Check known positive stock, known zero stock, missing key, duplicate insertion and update. Use sorted copied keys for reproducible ordered reports.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. A dictionary miss still assigns the default integer to the out variable. Branch on found, not quantity !=0. Updating PEN from12 to 15keeps the dictionary entry count unchanged; assigning BAG would insert a new key, which the exercise forbids. For the Your Turn activity, the instructor answer is: Existing exercise cell ch8-a21164ba. PEN 12 plus 3 must  print PEN: 15; BAGmust print Unknown product without insertion; BOOK 0 plus 3 is  a valid update to 3. Branch on TryGetValue success rather than a nonzero quantity test.
-->

---

## Vocabulary to explain, not memorize

- Key: entry identity
- value: associated data
- hashing: lookup strategy with expected rather than unconditional constant cost

[Chapter objectives and glossary](0800_data_collections.html)

<!--
Ask students to use each term in an explanation of this part’s case. Tie the vocabulary to the actions in the goals: Create and update key-to-value associations; Distinguish a missing key from a valid zero value; Count words using an explicit normalization and report-order policy. A correct definition without a correct trace is not yet sufficient evidence of application.
-->

---

<!-- _class: recap -->

## Recap and next step

- Create and update key-to-value associations
- Distinguish a missing key from a valid zero value
- Count words using an explicit normalization and report-order policy

[8.4 reading](0804_dictionary.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. A dictionary miss still assigns the default integer to the out variable. Branch on found, not quantity !=0. Updating PEN from12 to 15keeps the dictionary entry count unchanged; assigning BAG would insert a new key, which the exercise forbids. Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: 8.1 and shared operation syntax in 8.2, 35 minutes; meeting 2: lists in 8.3 and shared references in 8.2, 40 minutes; meeting 3: dictionaries in 8.4, 35 minutes. Total 110 minutes. Query reading 8.5 is optional.
-->

---

<!-- _class: section -->

## Optional Reading: Lambdas and LINQ

8.5 · [8.5 reading](0805_querying_collections.html)

Optional supporting reading. No added meeting or required assessment.

<!--
Meeting 1: 8.1 and shared operation syntax in 8.2, 35 minutes; meeting 2: lists in 8.3 and shared references in 8.2, 40 minutes; meeting 3: dictionaries in 8.4, 35 minutes. Total 110 minutes. Query reading 8.5 is optional. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. A dispatch desk wants valid amounts in ascending order with a charge added, while retaining duplicates and preserving the recorded source.
-->

---

## Goals and preparation

- Read a predicate and a transformation
- Compose filtering, ordering and projection
- Distinguish a deferred query from a materialized snapshot

[8.5 reading](0805_querying_collections.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: 8.1 and shared operation syntax in 8.2, 35 minutes; meeting 2: lists in 8.3 and shared references in 8.2, 40 minutes; meeting 3: dictionaries in 8.4, 35 minutes. Total 110 minutes. Query reading 8.5 is optional. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## A lambda supplies an operation to a library method

- The parameter names each candidate value
- Where uses a Boolean result to retain values
- Select returns transformed values

<!--
A **lambda expression** writes a short operation where a method expects one. Its parameter appears before `=>`, and the returned expression appears after it: Read this as “given an amount, return whether it is at least 30.” The name `amount` is local to that expression. It receives each candidate value; it does not refer to an undeclared variable from an earlier cell. C# infers its type from the collection and library method. The `m` suffix makes 30 a decimal literal. Compare the familiar named method with the lambda below. Both answer the same yes/no question. `Where` calls the supplied test for each amount and keeps values for which it returns `true`; the final `ToList` collects those values in a new list. `using System.Linq;` makes these query methods available.  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. Materialization stores this sequence of primitive values. It does not make the original deferred query permanently remember its old result. With mutable objects, an outer list copy would still share those objects; that deeper case belongs to Chapter 11.
-->

---

## Trace a deferred query and snapshot

| Event | Source | Snapshot | Query when traversed |
| --- | --- | --- | --- |
| Select amounts ≥30 | 45,10,30 | not stored | Work described |
| ToList | 45,10,30 | 45,30 | 45,30 |
| Change source[0]to 15 | 15,10,30 | 45,30 | 30 |

<!--
Materialization stores this sequence of primitive values. It does not make the original deferred query permanently remember its old result. With mutable objects, an outer list copy would still share those objects; that deeper case belongs to Chapter 11. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
var amounts = new List<int> { 45, 10, 30 };
var query = amounts.Where(amount => amount >= 30);
var snapshot = query.ToList();
amounts[0] = 15;
Console.WriteLine(string.Join(", ", query));
Console.WriteLine(string.Join(", ", snapshot));
```

```output
30
45, 30
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is '30\n45, 30\n'. Materialization stores this sequence of primitive values. It does not make the original deferred query permanently remember its old result. With mutable objects, an outer list copy would still share those objects; that deeper case belongs to Chapter 11. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

After source changes, which result can see the new values?

1. A later traversal of the deferred query
2. The already materialized primitive-value snapshot
3. Neither

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer A. ToList captured the earlier results, but the query still describes work to perform on the current source. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Practice: Prepare a Dispatch Report**

Complete the existing optional dispatch report. Exclude negative amounts, add 5, sort ascending, retain duplicates and preserve the source.

[Open the existing practice](0805_querying_collections.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Existing assessment comment cscs-collections-linq-dispatch and cell query-practice remain unchanged. For 25,-1,40,25,10the report is 15,30,30,45 with  count 4 and  total 120. Zero is valid and becomes5. Empty/all-invalid input yields an empty report and sum zero. The standard Chapter 8assessments do not require LINQ. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

<!-- _class: recap -->

## Recap and next step

- Read a predicate and a transformation
- Compose filtering, ordering and projection
- Distinguish a deferred query from a materialized snapshot

[8.5 reading](0805_querying_collections.html) · Optional reading; no required assessment.

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. Materialization stores this sequence of primitive values. It does not make the original deferred query permanently remember its old result. With mutable objects, an outer list copy would still share those objects; that deeper case belongs to Chapter 11. This supporting part is optional and does not add a core assessment prerequisite. Meeting 1: 8.1 and shared operation syntax in 8.2, 35 minutes; meeting 2: lists in 8.3 and shared references in 8.2, 40 minutes; meeting 3: dictionaries in 8.4, 35 minutes. Total 110 minutes. Query reading 8.5 is optional.
-->
