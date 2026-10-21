---
marp: true
theme: thinkpress-lecture
paginate: true
title: "Classes and Objects"
book: Computer Science in C#
section: "Chapter 10"
primary: "#2a6b37"
accent: "#b8860b"
---

<!-- _class: title -->

# Classes and Objects

Chapter 10 · Computer Science in C#

Business models, worked traces, and verified C# examples.

<!--
Part 10.1: Class Syntax, starts on slide 2.
Part 10.2: Properties, starts on slide 17.
Part 10.3: Instances, State, and Useful Behavior, starts on slide 32.
Part 10.4: Averager and Mutable State, starts on slide 47.
Core reading parts share the chapter's existing three-meeting allocation, totaling 110 minutes. They are not separate fifty-minute meetings. Optional/reference parts add no required meeting. Speaker-note answers belong to the instructor output; publish student HTML with those notes stripped.
-->

---

<!-- _class: section -->

# Class Syntax

Part 10.1 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 35 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. A product code and price should travel together. A line calculation uses that product state rather than parallel variables scattered across a client. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Define a class around one responsibility.
- Initialize per-object fields through a constructor.
- Distinguish fields from local calculations.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. Each product has its own stored price. Quantity belongs to a line calculation, so it can remain a method parameter rather than stale object state. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

A product code and price should travel together. A line calculation uses that product state rather than parallel variables scattered across a client.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. A product code and price should travel together. A line calculation uses that product state rather than parallel variables scattered across a client. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

A class defines a type; new constructs an instance. A constructor establishes initial state; an instance method uses that state.

<!--
A class defines a type; new constructs an instance. A constructor establishes initial state; an instance method uses that state. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

Each product has its own stored price. Quantity belongs to a line calculation, so it can remain a method parameter rather than stale object state.

<!--
Each product has its own stored price. Quantity belongs to a line calculation, so it can remain a method parameter rather than stale object state. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 10.1

```csharp
using System;
var pen = new Product("PEN", 2.50m);
Console.WriteLine(pen.LineTotal(4).ToString("F2"));
class Product {
    private readonly string code;
    private readonly decimal price;
    public Product(string code, decimal price) { this.code = code; this.price = price; }
    public decimal LineTotal(int quantity) { return price * quantity; }
}
```

```output
10.00
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is 10.00. Connect each observation to the contract: Each product has its own stored price. Quantity belongs to a line calculation, so it can remain a method parameter rather than stale object state. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Action|Object state / result |
| --- | --- |
| Construct PEN at 2.50|Code PEN, price 2.50 |
| LineTotal(4)|10.00 |
| Construct BOOK at 8.00|Independent fields |
| Change local quantity|Does not rename a product |

<!--
Walk through the rows before executing another example. Action: Object state / result. Construct PEN at 2.50: Code PEN, price 2.50. LineTotal(4): 10.00. Construct BOOK at 8.00: Independent fields. Change local quantity: Does not rename a product. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## Which value must persist between calls?

1. Product price
2. A temporary multiplication result
3. The loop index printing the report

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: A. Price is product state. A calculation result and client loop index need not become fields. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Element|Role |
| --- | --- |
| Class|Definition of a kind of object |
| Instance|One constructed object |
| Constructor|Establish initial state |
| Method|Perform a responsibility |

<!--
Element: Role. Class: Definition of a kind of object. Instance: One constructed object. Constructor: Establish initial state. Method: Perform a responsibility. Each product has its own stored price. Quantity belongs to a line calculation, so it can remain a method parameter rather than stale object state. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

Making all state static merges independent products into one shared store. Use instance fields for per-product data.

<!--
Making all state static merges independent products into one shared store. Use instance fields for per-product data. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## Two new Product calls create what?

1. One object automatically shared
2. Two independent instances
3. Two copies of the class definition

<!--
Poll again after the contrasting case. Answer: B. Both objects share a type definition, but their instance fields belong to distinct constructed objects. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

A product reports four pens at 2.50. Where should the line amount be calculated?

<!--
Pause for a prediction before changing the input or model. Answer: In behavior that receives quantity and uses the product's stored price, rather than a report that reaches into private fields. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Complete Build a Product Class: store both constructor parameters and implement LineTotal and Describe.

[Open the lesson exercise](1001_class_syntax.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: The constructor assigns code and unit price to instance fields. LineTotal returns stored price times quantity; Describe uses those values to report PEN-01 x 4 = 10.00. Watch for this defect: Making all state static merges independent products into one shared store. Use instance fields for per-product data.
-->

---

## Verify more than one example

Create two products with different codes/prices; repeat a call with a new quantity and confirm the first object's identity is unchanged.

<!--
Use independently predicted results. Create two products with different codes/prices; repeat a call with a new quantity and confirm the first object's identity is unchanged. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Define a class around one responsibility.
- Initialize per-object fields through a constructor.
- Distinguish fields from local calculations.

<!--
Each product has its own stored price. Quantity belongs to a line calculation, so it can remain a method parameter rather than stale object state. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->

---

<!-- _class: section -->

# Properties

Part 10.2 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 40 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. A contact changes an email address during a shift. A rejected update must leave the last valid address intact. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Use getters and setters as a public surface.
- Validate before changing stored state.
- Recognize computed properties.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. Check the proposed value first, then store its normalized form. Throwing does not reverse an assignment already made. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

A contact changes an email address during a shift. A rejected update must leave the last valid address intact.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. A contact changes an email address during a shift. A rejected update must leave the last valid address intact. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

A property is an operation-shaped interface to state. A backing field stores a value; a calculated getter derives a result when read.

<!--
A property is an operation-shaped interface to state. A backing field stores a value; a calculated getter derives a result when read. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

Check the proposed value first, then store its normalized form. Throwing does not reverse an assignment already made.

<!--
Check the proposed value first, then store its normalized form. Throwing does not reverse an assignment already made. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 10.2

```csharp
using System;
var c = new Contact(); c.Email = "TEAM@EXAMPLE.EDU";
try { c.Email = "bad"; } catch (ArgumentException) { Console.WriteLine("rejected"); }
Console.WriteLine(c.Email);
class Contact {
    private string email = "";
    public string Email { get => email; set {
        if (!value.Contains('@')) throw new ArgumentException();
        email = value.ToLowerInvariant(); } }
}
```

```output
rejected
team@example.edu
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is rejected; team@example.edu. Connect each observation to the contract: Check the proposed value first, then store its normalized form. Throwing does not reverse an assignment already made. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Attempt|Stored address |
| --- | --- |
| Construct MOrtiz2@example.edu|mortiz2@example.edu |
| Set not-an-address|Rejected |
| Read after rejection|mortiz2@example.edu |
| Set TEAM@example.edu|team@example.edu |

<!--
Walk through the rows before executing another example. Attempt: Stored address. Construct MOrtiz2@example.edu: mortiz2@example.edu. Set not-an-address: Rejected. Read after rejection: mortiz2@example.edu. Set TEAM@example.edu: team@example.edu. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## When must validation happen?

1. Before storing the proposed value
2. Only when printing
3. After every field has changed

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: A. Validate before mutation so an exception cannot leave an invalid value behind. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Property style|Meaning |
| --- | --- |
| Read-only getter|Client can observe but not assign |
| Validated setter|Client requests a checked change |
| Computed getter|Result derives from current fields |

<!--
Property style: Meaning. Read-only getter: Client can observe but not assign. Validated setter: Client requests a checked change. Computed getter: Result derives from current fields. Check the proposed value first, then store its normalized form. Throwing does not reverse an assignment already made. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

Exposing the backing field lets callers bypass the rule. Keep storage private and make every accepted update use the same boundary.

<!--
Exposing the backing field lets callers bypass the rule. Keep storage private and make every accepted update use the same boundary. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## Hours changes on an invoice. What should a computed AmountDue do?

1. Keep a stale cached value
2. Derive a result from current Hours and Rate
3. Become static

<!--
Poll again after the contrasting case. Answer: B. A calculated getter reads current state. Adding a second stored total would create a consistency obligation. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

A rejected email must be logged. Should the setter first store the invalid text?

<!--
Pause for a prediction before changing the input or model. Answer: No. Keep the last valid address and report failure separately. Validation is not a rollback mechanism. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Complete Validate an Email Property in the lesson. Reject missing @, normalize accepted text, and reread after rejection.

[Open the lesson exercise](1002_properties.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: Check the proposed value before assigning email. Store accepted values in lowercase. The three observations are normalized initial text, a rejection message, and that same initial text again. Watch for this defect: Exposing the backing field lets callers bypass the rule. Keep storage private and make every accepted update use the same boundary.
-->

---

## Verify more than one example

Check a valid update, invalid update, and reread after failure. This small @ rule is a teaching contract, not proof that mail can be delivered.

<!--
Use independently predicted results. Check a valid update, invalid update, and reread after failure. This small @ rule is a teaching contract, not proof that mail can be delivered. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Use getters and setters as a public surface.
- Validate before changing stored state.
- Recognize computed properties.

<!--
Check the proposed value first, then store its normalized form. Throwing does not reverse an assignment already made. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->

---

<!-- _class: section -->

# Instances, State, and Useful Behavior

Part 10.3 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 35 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. Front and patio registers accumulate separate sales. A shift reset must clear both the total and the item count. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Trace independent instance totals.
- Calculate behavior from current state.
- Reset an object and reuse it safely.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. Clear must restore the whole public invariant: total zero, count zero, and an empty average policy. A new sale then starts a new shift. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

Front and patio registers accumulate separate sales. A shift reset must clear both the total and the item count.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. Front and patio registers accumulate separate sales. A shift reset must clear both the total and the item count. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

Object state persists between calls. Local values disappear when a call returns; static members instead belong to the type.

<!--
Object state persists between calls. Local values disappear when a call returns; static members instead belong to the type. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

Clear must restore the whole public invariant: total zero, count zero, and an empty average policy. A new sale then starts a new shift.

<!--
Clear must restore the whole public invariant: total zero, count zero, and an empty average policy. A new sale then starts a new shift. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 10.3

```csharp
using System;
var r = new Register(); r.Add(4m); r.Add(6m); r.Clear(); r.Add(3m);
Console.WriteLine($"{r.Count} item, {r.Total:F2}");
class Register {
    public decimal Total { get; private set; }
    public int Count { get; private set; }
    public void Add(decimal amount) { Total += amount; Count++; }
    public void Clear() { Total = 0m; Count = 0; }
}
```

```output
1 item, 3.00
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is 1 item, 3.00. Connect each observation to the contract: Clear must restore the whole public invariant: total zero, count zero, and an empty average policy. A new sale then starts a new shift. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Call|Total|Count |
| --- | --- | --- |
| Add 4|4|1 |
| Add 6|10|2 |
| Clear|0|0 |
| Add 3|3|1 |

<!--
Walk through the rows before executing another example. Call: Total: Count. Add 4: 4: 1. Add 6: 10: 2. Clear: 0: 0. Add 3: 3: 1. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## Clear resets Total but leaves Count at two. What failed?

1. The compiler
2. The object's reset contract
3. String interpolation

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: B. The code may compile, but its observable count and average no longer describe the reset register. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Variable lifetime|Example |
| --- | --- |
| Instance field|One register's running total |
| Local variable|One line amount |
| Static field|One store-wide receipt sequence |

<!--
Variable lifetime: Example. Instance field: One register's running total. Local variable: One line amount. Static field: One store-wide receipt sequence. Clear must restore the whole public invariant: total zero, count zero, and an empty average policy. A new sale then starts a new shift. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

A remembered average can become inconsistent with total and count. Derive it or update all related state under one clear invariant.

<!--
A remembered average can become inconsistent with total and count. Derive it or update all related state under one clear invariant. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## Two registers need separate totals. Which storage fits?

1. Instance field
2. One shared static total
3. A local recreated on every call

<!--
Poll again after the contrasting case. Answer: A. Instance storage persists separately for each register; a static total merges stores, and a fresh local loses history. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

After reset, add one sale of three. What should the report show?

<!--
Pause for a prediction before changing the input or model. Answer: Count one, total three, and average three under the nonempty average rule. The old shift must not affect any result. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Complete Clear in Reset and Reuse a Register, then run the supplied assertions and add the new sale.

[Open the lesson exercise](1003_class_instance.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: Assign zero to total and itemCount. The empty average returns zero under this register contract; after Add(3m), expect one item and 3.00. Watch for this defect: A remembered average can become inconsistent with total and count. Derive it or update all related state under one clear invariant.
-->

---

## Verify more than one example

Check empty reset, repeated reset, two independent registers, and reuse. Do not solve reset by creating hidden replacement objects in the client.

<!--
Use independently predicted results. Check empty reset, repeated reset, two independent registers, and reuse. Do not solve reset by creating hidden replacement objects in the client. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Trace independent instance totals.
- Calculate behavior from current state.
- Reset an object and reuse it safely.

<!--
Clear must restore the whole public invariant: total zero, count zero, and an empty average policy. A new sale then starts a new shift. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->

---

<!-- _class: section -->

# Averager and Mutable State

Part 10.4 · Supporting / optional reference

Selected depth; no additional required meeting.

<!--
This is supporting material, not an extra required meeting or an automatic assessment prerequisite. Goal: Mutable averagers as a reference study. The instructor selects its depth according to course policy and available time. An averager can keep sum/count or average/count while promising the same observable average. Representation is private; the empty-state policy is public.
-->

---

## Mutable averagers as a reference study

An averager can keep sum/count or average/count while promising the same observable average. Representation is private; the empty-state policy is public.

A variable assignment can alias an averager rather than duplicate its accumulated observations. A reset must restore all state defining the average.

<!--
An averager can keep sum/count or average/count while promising the same observable average. Representation is private; the empty-state policy is public. A variable assignment can alias an averager rather than duplicate its accumulated observations. A reset must restore all state defining the average. Connect this extension to the core contract rather than introducing it as a prerequisite for the standard lab.
-->

---

<!-- _class: check -->

## Two quick checks

A: Does copying a class variable duplicate accumulated values?

B: Is an empty average automatically zero?

<!--
Answers: A: No, it copies a reference. B: No; the type must specify its empty-state policy, such as NaN or zero. Ask students to justify each answer using the stated contract. These checks are optional review, not a change to existing assessment IDs.
-->

---

<!-- _class: yourturn -->

## Your turn: selected practice

Use Build and Test Example: create two instances, then assign e = e2 and mutate through e2.

[Open the supporting reading](1004_averager.html)

<!--
Use the existing exercise only if this supporting reading was selected. Answer: The assignment makes e and e2 refer to one object; both observe the mutation. The previous target may become unreachable if no other references remain. Retain the original exercise identity and do not require unsupported syntax in a core assignment.
-->

---

<!-- _class: recap -->

## Reference recap

- A variable assignment can alias an averager rather than duplicate its accumulated observations. A reset must restore all state defining the average.
- Return to the core sequence when this reference question is resolved.

<!--
The assignment makes e and e2 refer to one object; both observe the mutation. The previous target may become unreachable if no other references remain. The core chapter remains complete without an extra meeting. Keep these notes available for students taking the recommended extension route.
-->
