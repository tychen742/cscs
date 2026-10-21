---
marp: true
theme: thinkpress-lecture
paginate: true
title: "Inheritance, Interfaces, and Polymorphism"
book: Computer Science in C#
section: "Chapter 12"
primary: "#2a6b37"
accent: "#b8860b"
---

<!-- _class: title -->

# Inheritance, Interfaces, and Polymorphism

Chapter 12 · Computer Science in C#

Business models, worked traces, and verified C# examples.

<!--
Part 12.1: Inheritance and Substitution, starts on slide 2.
Part 12.2: Runtime Polymorphism and Abstract Classes, starts on slide 17.
Part 12.3: Interfaces and Interchangeable Components, starts on slide 32.
Part 12.4: OOP Examples and Variations, starts on slide 47.
Core reading parts share the chapter's existing three-meeting allocation, totaling 110 minutes. They are not separate fifty-minute meetings. Optional/reference parts add no required meeting. Speaker-note answers belong to the instructor output; publish student HTML with those notes stripped.
-->

---

<!-- _class: section -->

# Inheritance and Substitution

Part 12.1 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 35 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. A checkout expects a nonnegative final amount no larger than its subtotal. A discount subtype must honor that expectation for every valid input. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Use inheritance as a behavioral promise.
- Preserve base validation.
- Implement a bounded override.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. Validate configuration at construction and subtotal at the operation boundary. A fixed discount larger than the subtotal must stop at zero. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

A checkout expects a nonnegative final amount no larger than its subtotal. A discount subtype must honor that expectation for every valid input.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. A checkout expects a nonnegative final amount no larger than its subtotal. A discount subtype must honor that expectation for every valid input. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

An is-a relationship promises usable substitution. Shared field names or the desire to reuse code do not establish that promise.

<!--
An is-a relationship promises usable substitution. Shared field names or the desire to reuse code do not establish that promise. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

Validate configuration at construction and subtotal at the operation boundary. A fixed discount larger than the subtotal must stop at zero.

<!--
Validate configuration at construction and subtotal at the operation boundary. A fixed discount larger than the subtotal must stop at zero. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 12.1

```csharp
using System;
Discount policy = new FixedDiscount();
Console.WriteLine(policy.Apply(3m));
class Discount {
    public virtual decimal Apply(decimal x) {
        if (x < 0) throw new ArgumentOutOfRangeException();
        return x;
    }
}
class FixedDiscount : Discount {
    public override decimal Apply(decimal x) { return Math.Max(0m, base.Apply(x) - 5m); }
}
```

```output
0
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is 0. Connect each observation to the contract: Validate configuration at construction and subtotal at the operation boundary. A fixed discount larger than the subtotal must stop at zero. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Subtotal|Reduction|Valid result |
| --- | --- | --- |
| 20|5|15 |
| 3|5|0 |
| 0|5|0 |
| Negative|Any|Reject before computing |

<!--
Walk through the rows before executing another example. Subtotal: Reduction: Valid result. 20: 5: 15. 3: 5: 0. 0: 5: 0. Negative: Any: Reject before computing. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## An override returns -2 for a valid subtotal. Is it a good substitute?

1. Yes, because it compiles
2. No, it breaks the result range
3. Yes, if its field names match

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: B. Compile-time type compatibility does not prove that the operation preserves the client's promised behavior. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Relationship|Decision question |
| --- | --- |
| Inheritance|Can every subtype preserve this client contract? |
| Composition|Does the client have a replaceable collaborator? |
| Coincidental fields|Insufficient evidence for either design |

<!--
Relationship: Decision question. Inheritance: Can every subtype preserve this client contract?. Composition: Does the client have a replaceable collaborator?. Coincidental fields: Insufficient evidence for either design. Validate configuration at construction and subtotal at the operation boundary. A fixed discount larger than the subtotal must stop at zero. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

Bypassing base validation lets a derived method accept inputs the shared contract rejects. Calling base can preserve the check when that behavior is intended.

<!--
Bypassing base validation lets a derived method accept inputs the shared contract rejects. Calling base can preserve the check when that behavior is intended. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## Where does constructor validation belong?

1. Only in the final report
2. At construction of invalid configuration
3. After storing an invalid amount

<!--
Poll again after the contrasting case. Answer: B. A configured policy should begin valid. Per-call subtotal checks still belong at the operation boundary. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

A reduction of five applies to zero. What should the client observe?

<!--
Pause for a prediction before changing the input or model. Answer: Zero, not negative five. The fixed policy's result stays in the documented range even at the boundary. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Complete Preserve the Discount Contract: configure a valid fixed reduction, retain the base input check, and cap the result at zero.

[Open the lesson exercise](1201_inheritance.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: Reject a negative configured reduction; call the base validation for subtotal; subtract the configured amount and return Math.Max(0m, result). Test a larger-than-subtotal reduction. Watch for this defect: Bypassing base validation lets a derived method accept inputs the shared contract rejects. Calling base can preserve the check when that behavior is intended.
-->

---

## Verify more than one example

Use zero, an ordinary subtotal, a full reduction, an oversized reduction, and negative subtotal/configuration cases.

<!--
Use independently predicted results. Use zero, an ordinary subtotal, a full reduction, an oversized reduction, and negative subtotal/configuration cases. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Use inheritance as a behavioral promise.
- Preserve base validation.
- Implement a bounded override.

<!--
Validate configuration at construction and subtotal at the operation boundary. A fixed discount larger than the subtotal must stop at zero. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->

---

<!-- _class: section -->

# Runtime Polymorphism and Abstract Classes

Part 12.2 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 40 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. A manager prints a list of reports through one general Report variable. Each concrete report supplies its own title without a client type test. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Trace dispatch through a base reference.
- Distinguish overload from override.
- Implement an abstract operation.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. An abstract class cannot be constructed directly. Concrete derived classes must supply the required abstract behavior while preserving the shared contract. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

A manager prints a list of reports through one general Report variable. Each concrete report supplies its own title without a client type test.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. A manager prints a list of reports through one general Report variable. Each concrete report supplies its own title without a client type test. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

Runtime dispatch selects an override from the actual object. Overloading instead selects among parameter lists; it is not the same mechanism.

<!--
Runtime dispatch selects an override from the actual object. Overloading instead selects among parameter lists; it is not the same mechanism. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

An abstract class cannot be constructed directly. Concrete derived classes must supply the required abstract behavior while preserving the shared contract.

<!--
An abstract class cannot be constructed directly. Concrete derived classes must supply the required abstract behavior while preserving the shared contract. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 12.2

```csharp
using System;
Report[] reports = { new SalesReport(), new StockReport() };
foreach (Report report in reports) Console.WriteLine(report.Title());
abstract class Report { public abstract string Title(); }
class SalesReport : Report { public override string Title() => "Sales"; }
class StockReport : Report { public override string Title() => "Stock"; }
```

```output
Sales
Stock
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is Sales; Stock. Connect each observation to the contract: An abstract class cannot be constructed directly. Concrete derived classes must supply the required abstract behavior while preserving the shared contract. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Variable type|Actual object|Title call |
| --- | --- | --- |
| Report|SalesReport|Sales |
| Report|StockReport|Stock |
| Report|SalesReport again|Sales |
| Client loop|Unchanged|No typeof branch needed |

<!--
Walk through the rows before executing another example. Variable type: Actual object: Title call. Report: SalesReport: Sales. Report: StockReport: Stock. Report: SalesReport again: Sales. Client loop: Unchanged: No typeof branch needed. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## What selects the Title override?

1. The report object's actual type
2. The local variable's spelling
3. Its index in the array

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: A. The same base-type call dispatches to the concrete object's override. The variable name and position are irrelevant. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Mechanism|Distinguishing feature |
| --- | --- |
| Override|Replace inherited virtual/abstract behavior |
| Overload|Same name, different parameter list |
| Abstract member|Concrete derived type supplies implementation |

<!--
Mechanism: Distinguishing feature. Override: Replace inherited virtual/abstract behavior. Overload: Same name, different parameter list. Abstract member: Concrete derived type supplies implementation. An abstract class cannot be constructed directly. Concrete derived classes must supply the required abstract behavior while preserving the shared contract. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

A client that switches on every concrete type defeats the replaceable behavior the base contract was meant to provide.

<!--
A client that switches on every concrete type defeats the replaceable behavior the base contract was meant to provide. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## Can new Report() succeed for this abstract type?

1. Yes, if Title is never called
2. No
3. Only in a loop

<!--
Poll again after the contrasting case. Answer: B. The abstract declaration prevents direct construction. A concrete derived report supplies the missing operation. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

Add a weekly report implementation. Which client line must change?

<!--
Pause for a prediction before changing the input or model. Answer: Add the new object to the input collection; the existing base-type loop and Title call remain unchanged. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Complete Test Through the Base Type: run the same result-range check through all supplied discount policies.

[Open the lesson exercise](1202_polymorphism.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: Use a base-type collection and one assertion function. Include a percentage discount that removes everything and a fixed discount exceeding the subtotal; both must return zero rather than a negative amount. Watch for this defect: A client that switches on every concrete type defeats the replaceable behavior the base contract was meant to provide.
-->

---

## Verify more than one example

Check all implementations with the same valid-input and result-range expectations. Do not weaken the test to accommodate a bad subtype.

<!--
Use independently predicted results. Check all implementations with the same valid-input and result-range expectations. Do not weaken the test to accommodate a bad subtype. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Trace dispatch through a base reference.
- Distinguish overload from override.
- Implement an abstract operation.

<!--
An abstract class cannot be constructed directly. Concrete derived classes must supply the required abstract behavior while preserving the shared contract. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->

---

<!-- _class: section -->

# Interfaces and Interchangeable Components

Part 12.3 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 35 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. Checkout needs a discount capability, not one particular discount class. A controlled replacement can record whether Checkout delegated the correct subtotal. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Express a small capability with an interface.
- Supply a collaborator through a constructor.
- Observe delegation with a test double.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. The client delegates to the supplied policy once and returns its result. Interchangeable implementations must agree on success and failure behavior. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

Checkout needs a discount capability, not one particular discount class. A controlled replacement can record whether Checkout delegated the correct subtotal.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. Checkout needs a discount capability, not one particular discount class. A controlled replacement can record whether Checkout delegated the correct subtotal. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

An interface names a capability contract. Constructor injection supplies the collaborator; it does not require a framework.

<!--
An interface names a capability contract. Constructor injection supplies the collaborator; it does not require a framework. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

The client delegates to the supplied policy once and returns its result. Interchangeable implementations must agree on success and failure behavior.

<!--
The client delegates to the supplied policy once and returns its result. Interchangeable implementations must agree on success and failure behavior. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 12.3

```csharp
var checkout = new Checkout(new NoDiscount());
Console.WriteLine(checkout.Quote(20m));
interface IDiscount { decimal Apply(decimal amount); }
class NoDiscount : IDiscount { public decimal Apply(decimal x) {
        if (x < 0) throw new ArgumentOutOfRangeException();
        return x; } }
class Checkout {
    private readonly IDiscount policy;
    public Checkout(IDiscount policy) { this.policy = policy; }
    public decimal Quote(decimal amount) => policy.Apply(amount);
}
```

```output
20
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is 20. Connect each observation to the contract: The client delegates to the supplied policy once and returns its result. Interchangeable implementations must agree on success and failure behavior. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Call|Expected collaboration |
| --- | --- |
| Construct checkout|Retain supplied policy |
| Quote 20|Call Apply with 20 |
| Recording policy returns 17|Quote returns 17 |
| Replace policy|Client source remains unchanged |

<!--
Walk through the rows before executing another example. Call: Expected collaboration. Construct checkout: Retain supplied policy. Quote 20: Call Apply with 20. Recording policy returns 17: Quote returns 17. Replace policy: Client source remains unchanged. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## What should Checkout depend on?

1. Every concrete policy class
2. The required IDiscount capability
3. The policy's private fields

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: B. The interface exposes the behavior the client needs without naming every implementation or its storage. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Collaborator|Purpose |
| --- | --- |
| Production policy|Calculate an approved rule |
| Recording double|Observe call count and argument |
| Client|Delegate and preserve the promised result |

<!--
Collaborator: Purpose. Production policy: Calculate an approved rule. Recording double: Observe call count and argument. Client: Delegate and preserve the promised result. The client delegates to the supplied policy once and returns its result. Interchangeable implementations must agree on success and failure behavior. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

Hard-coding a new policy inside Quote ignores the constructor-supplied collaborator and makes the recording test fail.

<!--
Hard-coding a new policy inside Quote ignores the constructor-supplied collaborator and makes the recording test fail. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## A double returns 17 but Quote returns 20. What should the test detect?

1. Correct delegation
2. An unrelated formatting error
3. The client ignored or altered the collaborator result

<!--
Poll again after the contrasting case. Answer: C. Verify call count, argument, and returned value. A call occurring somewhere is not enough. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

Two exporters each need a replaceable destination. Inherit every combination?

<!--
Pause for a prediction before changing the input or model. Answer: No. Compose an exporter with a destination capability, so changes to one dimension do not multiply subclasses. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Complete Replace a Component Without Changing Its Client: implement NoDiscount under the existing checkout contract.

[Open the lesson exercise](1203_interfaces.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: NoDiscount returns a valid subtotal unchanged and rejects negative input. The client continues to use the supplied interface without concrete type tests. Watch for this defect: Hard-coding a new policy inside Quote ignores the constructor-supplied collaborator and makes the recording test fail.
-->

---

## Verify more than one example

Use a recording implementation with a distinctive return value, and verify one call with the exact subtotal and the same returned result.

<!--
Use independently predicted results. Use a recording implementation with a distinctive return value, and verify one call with the exact subtotal and the same returned result. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Express a small capability with an interface.
- Supply a collaborator through a constructor.
- Observe delegation with a test double.

<!--
The client delegates to the supplied policy once and returns its result. Interchangeable implementations must agree on success and failure behavior. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->

---

<!-- _class: section -->

# OOP Examples and Variations

Part 12.4 · Supporting / optional reference

Selected depth; no additional required meeting.

<!--
This is supporting material, not an extra required meeting or an automatic assessment prerequisite. Goal: OOP variations without another meeting. The instructor selects its depth according to course policy and available time. A variable can select a hidden nonvirtual member by its declared type, while a virtual call dispatches through the runtime object. Keep these mechanisms distinct.
-->

---

## OOP variations without another meeting

A variable can select a hidden nonvirtual member by its declared type, while a virtual call dispatches through the runtime object. Keep these mechanisms distinct.

An overload changes the parameter list; an override replaces virtual/abstract inherited behavior. Sealing an override prevents another derived replacement.

<!--
A variable can select a hidden nonvirtual member by its declared type, while a virtual call dispatches through the runtime object. Keep these mechanisms distinct. An overload changes the parameter list; an override replaces virtual/abstract inherited behavior. Sealing an override prevents another derived replacement. Connect this extension to the core contract rather than introducing it as a prerequisite for the standard lab.
-->

---

<!-- _class: check -->

## Two quick checks

A: Is a same-name method always an override?

B: Can a class implement more than one interface?

<!--
Answers: A: No; hiding and overloading differ. B: Yes; implementing multiple capabilities does not imply multiple class inheritance. Ask students to justify each answer using the stated contract. These checks are optional review, not a change to existing assessment IDs.
-->

---

<!-- _class: yourturn -->

## Your turn: selected practice

Use Add a Truck and Diagnose the Forbidden Override in the supporting examples.

[Open the supporting reading](1204_oop_examples.html)

<!--
Use the existing exercise only if this supporting reading was selected. Answer: Extend the vehicle behavior only through its intended contract. For a sealed override, the attempted further override is a compile-time diagnostic; retain the valid hierarchy rather than removing validation. Retain the original exercise identity and do not require unsupported syntax in a core assignment.
-->

---

<!-- _class: recap -->

## Reference recap

- An overload changes the parameter list; an override replaces virtual/abstract inherited behavior. Sealing an override prevents another derived replacement.
- Return to the core sequence when this reference question is resolved.

<!--
Extend the vehicle behavior only through its intended contract. For a sealed override, the attempted further override is a compile-time diagnostic; retain the valid hierarchy rather than removing validation. The core chapter remains complete without an extra meeting. Keep these notes available for students taking the recommended extension route.
-->
