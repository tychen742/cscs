---
marp: true
theme: thinkpress-lecture
paginate: true
title: "Object Design and Composition"
book: Computer Science in C#
section: "Chapter 11"
primary: "#2a6b37"
accent: "#b8860b"
---

<!-- _class: title -->

# Object Design and Composition

Chapter 11 · Computer Science in C#

Business models, worked traces, and verified C# examples.

<!--
Part 11.1: References, Identity, and Copying, starts on slide 2.
Part 11.2: Structs, Records, and Data Models, starts on slide 17.
Part 11.3: Composition and Object Responsibilities, starts on slide 32.
Part 11.4: Testing and Refactoring Collaborating Objects, starts on slide 47.
Part 11.5: Nullability and Missing Data, starts on slide 62.
Core reading parts share the chapter's existing three-meeting allocation, totaling 110 minutes. They are not separate fifty-minute meetings. Optional/reference parts add no required meeting. Speaker-note answers belong to the instructor output; publish student HTML with those notes stripped.
-->

---

<!-- _class: section -->

# References, Identity, and Copying

Part 11.1 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 15 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. Two clerks refer to the same customer. A branch directory instead needs a customer whose later name changes are independent. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Draw aliases and independent copies.
- Distinguish identity from business equality.
- State how deep a copy goes.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. An outer collection copy protects its positions, but may still share mutable objects. Describe the complete sharing policy before claiming independence. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

Two clerks refer to the same customer. A branch directory instead needs a customer whose later name changes are independent.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. Two clerks refer to the same customer. A branch directory instead needs a customer whose later name changes are independent. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

Assignment of a class reference copies a reference. Constructing a new customer creates a new identity even when its starting name matches.

<!--
Assignment of a class reference copies a reference. Constructing a new customer creates a new identity even when its starting name matches. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

An outer collection copy protects its positions, but may still share mutable objects. Describe the complete sharing policy before claiming independence.

<!--
An outer collection copy protects its positions, but may still share mutable objects. Describe the complete sharing policy before claiming independence. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 11.1

```csharp
using System;
var first = new Customer("North"); var alias = first;
var copy = new Customer(first.Name); alias.Name = "South";
Console.WriteLine(first.Name); Console.WriteLine(copy.Name);
Console.WriteLine(ReferenceEquals(first, alias));
class Customer {
    public string Name { get; set; }
    public Customer(string name) { Name = name; }
}
```

```output
South
North
True
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is South; North; True. Connect each observation to the contract: An outer collection copy protects its positions, but may still share mutable objects. Describe the complete sharing policy before claiming independence. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Action|first.Name|copy.Name |
| --- | --- | --- |
| Construct both|North|North |
| Alias first|North|North |
| Rename alias|South|North |
| ReferenceEquals(first, alias)|True|Separate copy remains independent |

<!--
Walk through the rows before executing another example. Action: first.Name: copy.Name. Construct both: North: North. Alias first: North: North. Rename alias: South: North. ReferenceEquals(first, alias): True: Separate copy remains independent. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## What did alias = first copy?

1. The complete object graph
2. A reference to the same object
3. Only the Name string

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: B. Both references identify one customer. A separate constructor call is needed for a distinct customer object. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Question|Test |
| --- | --- |
| Same runtime object?|ReferenceEquals |
| Same business identifier?|Explicit SKU/customer-ID rule |
| Independent nested state?|A documented copy-depth policy |

<!--
Question: Test. Same runtime object?: ReferenceEquals. Same business identifier?: Explicit SKU/customer-ID rule. Independent nested state?: A documented copy-depth policy. An outer collection copy protects its positions, but may still share mutable objects. Describe the complete sharing policy before claiming independence. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

Readonly prevents replacing a field reference; it does not freeze the object reached through it. Draw both arrows and the mutable target.

<!--
Readonly prevents replacing a field reference; it does not freeze the object reached through it. Draw both arrows and the mutable target. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## An array of mutable customers is cloned. What is independent?

1. Every customer recursively
2. Nothing at all
3. Array positions; customer objects may remain shared

<!--
Poll again after the contrasting case. Answer: C. A shallow array copy duplicates its element references, not the reachable customer objects. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

A shared product is immutable. Must every order clone it?

<!--
Pause for a prediction before changing the input or model. Answer: No. Shared fixed data can be intentional and safe. Copying policy follows the model rather than an automatic demand for deep cloning. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Complete Draw the Arrows: create an alias and an independent customer, rename through the alias, and print the observations.

[Open the lesson exercise](1101_objects_references.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: Construct the independent customer before mutation. The original and alias observe the renamed customer; the independent copy keeps its original name. ReferenceEquals is true only for the aliases. Watch for this defect: Readonly prevents replacing a field reference; it does not freeze the object reached through it. Draw both arrows and the mutable target.
-->

---

## Verify more than one example

Check shared mutation, independent mutation, and two distinct objects with the same business identifier. Name equality alone is not identity.

<!--
Use independently predicted results. Check shared mutation, independent mutation, and two distinct objects with the same business identifier. Name equality alone is not identity. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Draw aliases and independent copies.
- Distinguish identity from business equality.
- State how deep a copy goes.

<!--
An outer collection copy protects its positions, but may still share mutable objects. Describe the complete sharing policy before claiming independence. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->

---

<!-- _class: section -->

# Structs, Records, and Data Models

Part 11.2 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 20 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. A parcel measurement behaves like a value. A delivery address may be represented as a record class with data equality but a distinct runtime identity. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Choose value or reference semantics.
- Distinguish record-class equality from identity.
- Predict with and default behavior.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. With makes a modified copy of immediate record data. A nested mutable list reference may still be shared. A struct default exists even when a constructor has validation. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

A parcel measurement behaves like a value. A delivery address may be represented as a record class with data equality but a distinct runtime identity.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. A parcel measurement behaves like a value. A delivery address may be represented as a record class with data equality but a distinct runtime identity. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

Struct assignment copies a value. Record classes remain reference types even though their generated equality compares data.

<!--
Struct assignment copies a value. Record classes remain reference types even though their generated equality compares data. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

With makes a modified copy of immediate record data. A nested mutable list reference may still be shared. A struct default exists even when a constructor has validation.

<!--
With makes a modified copy of immediate record data. A nested mutable list reference may still be shared. A struct default exists even when a constructor has validation. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 11.2

```csharp
using System;
var size = new Size(2, 3); var wider = size with { Width = 7 };
Console.WriteLine($"{size.Width},{wider.Width}");
var a = new Address("North"); var b = new Address("North");
Console.WriteLine(a == b); Console.WriteLine(ReferenceEquals(a, b));
readonly record struct Size(int Width, int Height);
record Address(string City);
```

```output
2,7
True
False
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is 2,7; True; False. Connect each observation to the contract: With makes a modified copy of immediate record data. A nested mutable list reference may still be shared. A struct default exists even when a constructor has validation. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Expression|Observation |
| --- | --- |
| Copy record struct then change Width|Original width stays two |
| Two Address("North") records|Data equality true |
| ReferenceEquals on those addresses|False |
| Copy a record holding a List|List reference remains shared |

<!--
Walk through the rows before executing another example. Expression: Observation. Copy record struct then change Width: Original width stays two. Two Address("North") records: Data equality true. ReferenceEquals on those addresses: False. Copy a record holding a List: List reference remains shared. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## Does record class mean value type?

1. Yes
2. No: it is a reference type with data equality
3. It has no identity

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: B. Equality generation does not change class storage or identity. Record struct is the value-type form. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Model choice|Reason to choose it |
| --- | --- |
| Struct / record struct|Independent value copying |
| Record class|Data equality with reference semantics |
| Enum|One value from a named fixed set |

<!--
Model choice: Reason to choose it. Struct / record struct: Independent value copying. Record class: Data equality with reference semantics. Enum: One value from a named fixed set. With makes a modified copy of immediate record data. A nested mutable list reference may still be shared. A struct default exists even when a constructor has validation. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

A constructor cannot stop default(T) from producing zeroed struct fields. Validate at the boundary where the value becomes meaningful.

<!--
A constructor cannot stop default(T) from producing zeroed struct fields. Validate at the boundary where the value becomes meaningful. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## With copies a record containing List<string>. Which operation can affect both?

1. Reassign the copied record variable
2. Change the shared list contents
3. Read an integer field

<!--
Poll again after the contrasting case. Answer: B. The list reference is copied shallowly. A variable reassignment is different from a mutation of the shared object. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

A zero-by-zero parcel is forbidden. Is a validated constructor sufficient?

<!--
Pause for a prediction before changing the input or model. Answer: No. Default of a value type can bypass that path. The consuming operation must enforce the domain boundary. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Use the lesson's record/struct comparison and the homework value-semantics task: predict assignment, with, equality, identity, and a shared nested list.

[Open the lesson exercise](1102_value_record_types.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: Assignment of the struct is independent. With creates a modified record value or object, but nested references are shallow copies. Equal separately created address records compare equal and have distinct identities. Watch for this defect: A constructor cannot stop default(T) from producing zeroed struct fields. Validate at the boundary where the value becomes meaningful.
-->

---

## Verify more than one example

Compare default, assignment, with, two equal constructions, and nested mutation. Explain each result in terms of copying and equality rather than the type name alone.

<!--
Use independently predicted results. Compare default, assignment, with, two equal constructions, and nested mutation. Explain each result in terms of copying and equality rather than the type name alone. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Choose value or reference semantics.
- Distinguish record-class equality from identity.
- Predict with and default behavior.

<!--
With makes a modified copy of immediate record data. A nested mutable list reference may still be shared. A struct default exists even when a constructor has validation. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->

---

<!-- _class: section -->

# Composition and Object Responsibilities

Part 11.3 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 40 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. An order owns its line collection; a line knows a product and a quantity. The report asks collaborators for results rather than duplicating their formulas. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Assign behavior to a coherent collaborator.
- Protect an order's private collection.
- Calculate results from line data.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. Validate a complete line before storing it. A snapshot may copy the outer collection while intentionally sharing immutable line/product objects. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

An order owns its line collection; a line knows a product and a quantity. The report asks collaborators for results rather than duplicating their formulas.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. An order owns its line collection; a line knows a product and a quantity. The report asks collaborators for results rather than duplicating their formulas. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

Composition is a has-a relationship. Product supplies unit price; line supplies quantity; order coordinates lines and totals.

<!--
Composition is a has-a relationship. Product supplies unit price; line supplies quantity; order coordinates lines and totals. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

Validate a complete line before storing it. A snapshot may copy the outer collection while intentionally sharing immutable line/product objects.

<!--
Validate a complete line before storing it. A snapshot may copy the outer collection while intentionally sharing immutable line/product objects. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 11.3

```csharp
using System;
var pen = new Product("PEN", 2.50m);
var line = new Line(pen, 4);
Console.WriteLine(line.Amount.ToString("F2"));
record Product(string Sku, decimal Price);
record Line(Product Product, int Quantity) {
    public decimal Amount => Product.Price * Quantity;
}
```

```output
10.00
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is 10.00. This compact calculation example assumes a valid product and positive quantity. Use the lesson’s guarded constructors and order boundary for the complete validation contract; these positional records alone do not enforce it. Connect each observation to the contract: Validate a complete line before storing it. A snapshot may copy the outer collection while intentionally sharing immutable line/product objects. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Collaborator|Responsibility |
| --- | --- |
| Product|SKU and fixed unit price |
| OrderLine|Positive quantity and line amount |
| Order|Own lines; compute aggregate |
| Report|Present public results |

<!--
Walk through the rows before executing another example. Collaborator: Responsibility. Product: SKU and fixed unit price. OrderLine: Positive quantity and line amount. Order: Own lines; compute aggregate. Report: Present public results. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## Where should line amount be calculated?

1. In every report independently
2. In the line that owns quantity and product
3. In a static global total

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: B. This keeps the formula with the data it needs and avoids competing report implementations. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Public result|Ownership consequence |
| --- | --- |
| Internal List returned|Caller may change order storage |
| New outer array returned|Caller may replace only snapshot positions |
| Shared immutable product|Fixed data can be reused safely |

<!--
Public result: Ownership consequence. Internal List returned: Caller may change order storage. New outer array returned: Caller may replace only snapshot positions. Shared immutable product: Fixed data can be reused safely. Validate a complete line before storing it. A snapshot may copy the outer collection while intentionally sharing immutable line/product objects. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

Marking the list field private is insufficient if a public method returns that same mutable List. Protect the boundary, not only the field declaration.

<!--
Marking the list field private is insufficient if a public method returns that same mutable List. Protect the boundary, not only the field declaration. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## Two lines have SKU PEN and quantities two and three. CountUnits("PEN") returns?

1. One
2. Two
3. Five

<!--
Poll again after the contrasting case. Answer: C. The task counts requested units across matching lines, not distinct products or line count. Matching remains case-sensitive. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

A caller replaces snapshot[0]. Should the order change?

<!--
Pause for a prediction before changing the input or model. Answer: No, because the outer array is separate. Mutating a nested shared mutable element would be a different contract and requires separate protection. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Complete Count Requested Units: inspect every line and sum quantities for the chapter's case-sensitive SKU match.

[Open the lesson exercise](1103_composition.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: Initialize a total to zero, traverse owned lines, add each matching quantity, and return zero when no line matches. Do not stop at the first match. Watch for this defect: Marking the list field private is insufficient if a public method returns that same mutable List. Protect the boundary, not only the field declaration.
-->

---

## Verify more than one example

Check repeated matching lines, unknown SKU, different case, and empty orders. Test rejected additions before mutation and snapshots after updates.

<!--
Use independently predicted results. Check repeated matching lines, unknown SKU, different case, and empty orders. Test rejected additions before mutation and snapshots after updates. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Assign behavior to a coherent collaborator.
- Protect an order's private collection.
- Calculate results from line data.

<!--
Validate a complete line before storing it. A snapshot may copy the outer collection while intentionally sharing immutable line/product objects. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->

---

<!-- _class: section -->

# Testing and Refactoring Collaborating Objects

Part 11.4 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 35 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. An order rejects a line but its total has already changed. The exception is visible, yet the real contract failure is the unwanted state change. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Test through the public surface.
- Detect rejected changes that corrupt state.
- Refactor while preserving behavior.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. Tests should distinguish plausible defects: two orders sharing fixed products, outer snapshot replacement, and rejection before storage mutation. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

An order rejects a line but its total has already changed. The exception is visible, yet the real contract failure is the unwanted state change.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. An order rejects a line but its total has already changed. The exception is visible, yet the real contract failure is the unwanted state change. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

A contract test observes public results before and after an action. Arrange known state, act once, and assert an independently predicted result.

<!--
A contract test observes public results before and after an action. Arrange known state, act once, and assert an independently predicted result. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

Tests should distinguish plausible defects: two orders sharing fixed products, outer snapshot replacement, and rejection before storage mutation.

<!--
Tests should distinguish plausible defects: two orders sharing fixed products, outer snapshot replacement, and rejection before storage mutation. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 11.4

```csharp
var stock = new Stock(3); int before = stock.Units;
try { stock.Take(4); } catch (InvalidOperationException) { }
Console.WriteLine(stock.Units == before);
stock.Take(3); Console.WriteLine(stock.Units);
class Stock {
    public int Units { get; private set; }
    public Stock(int units) { Units = units; }
    public void Take(int n) {
        if (n <= 0 || n > Units) throw new InvalidOperationException();
        Units -= n; } }
```

```output
True
0
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is True; 0. Connect each observation to the contract: Tests should distinguish plausible defects: two orders sharing fixed products, outer snapshot replacement, and rejection before storage mutation. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Action|Expected observation |
| --- | --- |
| Arrange stock three|Units three |
| Request four|Exception; units still three |
| Request three|Units zero |
| Inspect private field layout|Unnecessary for this contract |

<!--
Walk through the rows before executing another example. Action: Expected observation. Arrange stock three: Units three. Request four: Exception; units still three. Request three: Units zero. Inspect private field layout: Unnecessary for this contract. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## Which assertion proves rejection preserved state?

1. An exception occurred
2. The public total and count equal their prior values
3. The source code contains private

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: B. An exception alone does not undo earlier mutation. Check observable state as well as the failure signal. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Refactoring change|What stays fixed? |
| --- | --- |
| Parallel lists to line objects|Accepted inputs and public results |
| New private storage|Client contract |
| Different validation order|Rejection must still preserve state |

<!--
Refactoring change: What stays fixed?. Parallel lists to line objects: Accepted inputs and public results. New private storage: Client contract. Different validation order: Rejection must still preserve state. Tests should distinguish plausible defects: two orders sharing fixed products, outer snapshot replacement, and rejection before storage mutation. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

A test that repeats the implementation's own formula can reproduce its bug. Derive a small expected total by hand first.

<!--
A test that repeats the implementation's own formula can reproduce its bug. Derive a small expected total by hand first. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## What makes a snapshot test discriminating?

1. Read its first element only
2. Replace an element and then reread the original order
3. Count constructor calls

<!--
Poll again after the contrasting case. Answer: B. The attempted client mutation tests whether the internal collection was exposed. Reading alone cannot detect that alias. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

Two orders share one immutable product. Adding to one order changes the other total. What should you inspect?

<!--
Pause for a prediction before changing the input or model. Answer: Inspect whether the orders accidentally share their mutable line collection. Shared fixed product data does not explain shared membership. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Complete Challenge the Ownership Rules: check two orders, then replace an element in one returned snapshot.

[Open the lesson exercise](1104_testing_collaboration.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: Predict each total independently; mutate only the first order, verify the second, replace a snapshot entry, and verify the originating order still has its original lines. Watch for this defect: A test that repeats the implementation's own formula can reproduce its bug. Derive a small expected total by hand first.
-->

---

## Verify more than one example

Keep ordinary, empty, rejection, repeated-product, and snapshot checks while refactoring. Do not assert private representation details.

<!--
Use independently predicted results. Keep ordinary, empty, rejection, repeated-product, and snapshot checks while refactoring. Do not assert private representation details. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Test through the public surface.
- Detect rejected changes that corrupt state.
- Refactor while preserving behavior.

<!--
Tests should distinguish plausible defects: two orders sharing fixed products, outer snapshot replacement, and rejection before storage mutation. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->

---

<!-- _class: section -->

# Nullability and Missing Data

Part 11.5 · Supporting / optional reference

Selected depth; no additional required meeting.

<!--
This is supporting material, not an extra required meeting or an automatic assessment prerequisite. Goal: Missing data as an explicit contract. The instructor selects its depth according to course policy and available time. A customer can have an optional contact while its required account identifier must be present. Model absence instead of inventing a misleading empty value.
-->

---

## Missing data as an explicit contract

A customer can have an optional contact while its required account identifier must be present. Model absence instead of inventing a misleading empty value.

Nullable annotations guide compiler flow analysis; runtime guards still enforce required inputs. Use ?. and ?? for a documented absence response, not to hide an invalid required state.

<!--
A customer can have an optional contact while its required account identifier must be present. Model absence instead of inventing a misleading empty value. Nullable annotations guide compiler flow analysis; runtime guards still enforce required inputs. Use ?. and ?? for a documented absence response, not to hide an invalid required state. Connect this extension to the core contract rather than introducing it as a prerequisite for the standard lab.
-->

---

<!-- _class: check -->

## Two quick checks

A: Does string? automatically validate runtime input?

B: Does ! repair a missing required value?

<!--
Answers: Both no. An annotation documents a possibility; the null-forgiving operator only suppresses a warning and does not create a value. Ask students to justify each answer using the stated contract. These checks are optional review, not a change to existing assessment IDs.
-->

---

<!-- _class: yourturn -->

## Your turn: selected practice

Use the required-value guard and optional-label practice from the supporting reading.

[Open the supporting reading](1105_nullability.html)

<!--
Use the existing exercise only if this supporting reading was selected. Answer: Reject a missing required identifier at its boundary. For optional contact data, check absence or use safe navigation/coalescing to return the documented label. Test null, empty, and an actual contact separately. Retain the original exercise identity and do not require unsupported syntax in a core assignment.
-->

---

<!-- _class: recap -->

## Reference recap

- Nullable annotations guide compiler flow analysis; runtime guards still enforce required inputs. Use ?. and ?? for a documented absence response, not to hide an invalid required state.
- Return to the core sequence when this reference question is resolved.

<!--
Reject a missing required identifier at its boundary. For optional contact data, check absence or use safe navigation/coalescing to return the documented label. Test null, empty, and an actual contact separately. The core chapter remains complete without an extra meeting. Keep these notes available for students taking the recommended extension route.
-->
