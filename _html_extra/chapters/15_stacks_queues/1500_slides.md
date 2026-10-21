---
marp: true
theme: thinkpress-lecture
paginate: true
title: "Stacks, Queues, and Deques"
book: Computer Science in C#
section: "Chapter 15"
primary: "#2a6b37"
accent: "#b8860b"
---

<!-- _class: title -->

# Stacks, Queues, and Deques

Chapter 15 · Computer Science in C#

Business models, worked traces, and verified C# examples.

<!--
Part 15.1: Stacks, starts on slide 2.
Part 15.2: Queues and Deques, starts on slide 17.
Part 15.3: Access Policies and Applications, starts on slide 32.
Core reading parts share the chapter's existing three-meeting allocation, totaling 110 minutes. They are not separate fifty-minute meetings. Optional/reference parts add no required meeting. Speaker-note answers belong to the instructor output; publish student HTML with those notes stripped.
-->

---

<!-- _class: section -->

# Stacks

Part 15.1 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 35 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. A deployment history records Build, Test, and Deploy. Undo must remove Deploy first because it is the latest accepted action. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Specify LIFO and empty behavior.
- Trace stack top and count.
- Use a stack for nested or reversed work.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. An empty operation needs an explicit exception or Try-style failure policy. A stored zero is not the same as an unsuccessful removal. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

A deployment history records Build, Test, and Deploy. Undo must remove Deploy first because it is the latest accepted action.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. A deployment history records Build, Test, and Deploy. Undo must remove Deploy first because it is the latest accepted action. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

A stack restricts access to its top. Push adds, Pop removes and returns, and Peek observes without removal.

<!--
A stack restricts access to its top. Push adds, Pop removes and returns, and Peek observes without removal. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

An empty operation needs an explicit exception or Try-style failure policy. A stored zero is not the same as an unsuccessful removal.

<!--
An empty operation needs an explicit exception or Try-style failure policy. A stored zero is not the same as an unsuccessful removal. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 15.1

```csharp
using System;
using System.Collections.Generic;
var tasks = new Stack<string>();
tasks.Push("Build"); tasks.Push("Test"); tasks.Push("Deploy");
while (tasks.Count > 0) Console.WriteLine(tasks.Pop());
```

```output
Deploy
Test
Build
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is Deploy; Test; Build. Connect each observation to the contract: An empty operation needs an explicit exception or Try-style failure policy. A stored zero is not the same as an unsuccessful removal. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Operation|Top|Count |
| --- | --- | --- |
| Push Build|Build|1 |
| Push Test|Test|2 |
| Push Deploy|Deploy|3 |
| Pop|Test remains|2 |

<!--
Walk through the rows before executing another example. Operation: Top: Count. Push Build: Build: 1. Push Test: Test: 2. Push Deploy: Deploy: 3. Pop: Test remains: 2. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## Why does this output reverse the input?

1. Stack sorts alphabetically
2. The latest item is removed first
3. Strings are immutable

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: B. LIFO determines the removal order. There is no key comparison or alphabetical sorting in these operations. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Operation|Observable effect |
| --- | --- |
| Push|Increase count and install a new top |
| Peek|Return top with unchanged count |
| Pop|Return and remove top |
| TryPop failure|Preserve empty state |

<!--
Operation: Observable effect. Push: Increase count and install a new top. Peek: Return top with unchanged count. Pop: Return and remove top. TryPop failure: Preserve empty state. An empty operation needs an explicit exception or Try-style failure policy. A stored zero is not the same as an unsuccessful removal. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

A delimiter checker that only counts openings cannot detect ([)]. Preserve the kinds and nesting order of unmatched openings on a stack.

<!--
A delimiter checker that only counts openings cannot detect ([)]. Preserve the kinds and nesting order of unmatched openings on a stack. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## TryPeek returns true with value zero. What happened?

1. Failure
2. A successful observation of a stored zero
3. A value was removed

<!--
Poll again after the contrasting case. Answer: B. Read the success flag separately from the returned value. Peek also preserves Count. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

A stack becomes empty and later receives one item. Must it still work?

<!--
Pause for a prediction before changing the input or model. Answer: Yes. Reuse after emptying is part of the same contract; clearing an old slot must not prevent a later push. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Complete Reverse the Order: push Build, Test, Deploy and pop until empty; explain the reversal.

[Open the lesson exercise](1501_stack.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: Push in the specified order, then loop while Count is positive and print each Pop. The result is Deploy, Test, Build. An empty input prints nothing. Watch for this defect: A delimiter checker that only counts openings cannot detect ([)]. Preserve the kinds and nesting order of unmatched openings on a stack.
-->

---

## Verify more than one example

Test empty access, one item, duplicates, stored zero, and empty-then-reuse. Distinguish individual growth cost from amortized push cost.

<!--
Use independently predicted results. Test empty access, one item, duplicates, stored zero, and empty-then-reuse. Distinguish individual growth cost from amortized push cost. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Specify LIFO and empty behavior.
- Trace stack top and count.
- Use a stack for nested or reversed work.

<!--
An empty operation needs an explicit exception or Try-style failure policy. A stored zero is not the same as an unsuccessful removal. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->

---

<!-- _class: section -->

# Queues and Deques

Part 15.2 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 40 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. A service desk has three physical slots. After serving A, a new D can reuse A's old slot while B remains the next ticket. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Distinguish logical from physical queue order.
- Trace ring wraparound and bounded failure.
- Explain linked queue endpoint rules.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. Use (front + Count) % Capacity for insertion and advance front modulo capacity for removal. Count distinguishes full and empty when positions coincide. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

A service desk has three physical slots. After serving A, a new D can reuse A's old slot while B remains the next ticket.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. A service desk has three physical slots. After serving A, a new D can reuse A's old slot while B remains the next ticket. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

A ring queue stores a logical FIFO sequence across an array boundary. Front and Count define which physical positions are live.

<!--
A ring queue stores a logical FIFO sequence across an array boundary. Front and Count define which physical positions are live. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

Use (front + Count) % Capacity for insertion and advance front modulo capacity for removal. Count distinguishes full and empty when positions coincide.

<!--
Use (front + Count) % Capacity for insertion and advance front modulo capacity for removal. Count distinguishes full and empty when positions coincide. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 15.2

```csharp
using System;
using System.Collections.Generic;
string[] slots = { "A", "B", "C" }; int front = 0, count = 3;
Console.WriteLine(slots[front]); slots[front] = "";
front = (front + 1) % slots.Length; count--;
slots[(front + count) % slots.Length] = "D"; count++;
var logical = new List<string>();
for (int i = 0; i < count; i++) logical.Add(slots[(front + i) % slots.Length]);
Console.WriteLine(string.Join(",", logical));
Console.WriteLine($"front={front}, count={count}");
```

```output
A
B,C,D
front=1, count=3
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is A; B,C,D; front=1, count=3. Connect each observation to the contract: Use (front + Count) % Capacity for insertion and advance front modulo capacity for removal. Count distinguishes full and empty when positions coincide. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Event|Physical slots|Logical order |
| --- | --- | --- |
| Initial full|A, B, C|A, B, C |
| Serve A|empty, B, C|B, C |
| Enqueue D|D, B, C|B, C, D |
| Full again|front 1, count 3|B remains first |

<!--
Walk through the rows before executing another example. Event: Physical slots: Logical order. Initial full: A, B, C: A, B, C. Serve A: empty, B, C: B, C. Enqueue D: D, B, C: B, C, D. Full again: front 1, count 3: B remains first. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## Front equals back. Is the queue definitely empty?

1. Yes
2. No: Count or another agreed invariant is needed
3. It must contain one item

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: B. A bounded ring can have coincident positions when empty or full. The implementation must distinguish those states explicitly. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Representation|Important boundary |
| --- | --- |
| Bounded ring|Reject full input without mutation |
| Growing ring|Copy logical order, then reset front |
| Linked queue|Clear both endpoints after singleton removal |
| Deque|Define operations at both ends |

<!--
Representation: Important boundary. Bounded ring: Reject full input without mutation. Growing ring: Copy logical order, then reset front. Linked queue: Clear both endpoints after singleton removal. Deque: Define operations at both ends. Use (front + Count) % Capacity for insertion and advance front modulo capacity for removal. Count distinguishes full and empty when positions coincide. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

Copying wrapped physical slots from index zero changes FIFO order during growth. Copy logical positions starting at front, then reset the new front.

<!--
Copying wrapped physical slots from index zero changes FIFO order during growth. Copy logical positions starting at front, then reset the new front. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## A growing ring copies its live values into a new array. New front should be?

1. Zero after a logical-order copy
2. The old physical front regardless of layout
3. Always capacity minus one

<!--
Poll again after the contrasting case. Answer: A. The live sequence begins at the new array's index zero after that copy. Count stays the number of live values. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

Capacity is one. What must a second enqueue do under a rejection policy?

<!--
Pause for a prediction before changing the input or model. Answer: Reject it without replacing the waiting item or changing Count. A capacity-one case exposes assumptions hidden by larger buffers. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Complete Dequeue from a Ring: remove front, clear its slot, advance with wraparound, and reject empty removal.

[Open the lesson exercise](1502_queue_deque.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: Save the front value before clearing it. Advance front modulo the array length and decrement Count once. The supplied sequence yields A, B, a remaining count of two before C, then E and an empty rejection. Watch for this defect: Copying wrapped physical slots from index zero changes FIFO order during growth. Copy logical positions starting at front, then reset the new front.
-->

---

## Verify more than one example

Test full rejection, empty removal, capacity one, wraparound, drain/reuse, and a partially occupied growing ring.

<!--
Use independently predicted results. Test full rejection, empty removal, capacity one, wraparound, drain/reuse, and a partially occupied growing ring. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Distinguish logical from physical queue order.
- Trace ring wraparound and bounded failure.
- Explain linked queue endpoint rules.

<!--
Use (front + Count) % Capacity for insertion and advance front modulo capacity for removal. Count distinguishes full and empty when positions coincide. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->

---

<!-- _class: section -->

# Access Policies and Applications

Part 15.3 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 35 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. An urgent stack serves the newest urgent ticket; a normal queue serves ordinary arrivals FIFO. That choice is a business policy, not a universal fairness guarantee. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Choose a worklist from its policy.
- Keep undo and redo as separate histories.
- State a fairness bound precisely.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. Document whether urgent restoration happens at the front and whether normal work can starve. A completion-count bound is not a wall-clock bound. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

An urgent stack serves the newest urgent ticket; a normal queue serves ordinary arrivals FIFO. That choice is a business policy, not a universal fairness guarantee.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. An urgent stack serves the newest urgent ticket; a normal queue serves ordinary arrivals FIFO. That choice is a business policy, not a universal fairness guarantee. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

The access rule determines which pending item becomes next. Undo/redo requires two histories; a new edit invalidates an abandoned redo branch.

<!--
The access rule determines which pending item becomes next. Undo/redo requires two histories; a new edit invalidates an abandoned redo branch. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

Document whether urgent restoration happens at the front and whether normal work can starve. A completion-count bound is not a wall-clock bound.

<!--
Document whether urgent restoration happens at the front and whether normal work can starve. A completion-count bound is not a wall-clock bound. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 15.3

```csharp
using System;
using System.Collections.Generic;
var urgent = new Stack<string>(); var normal = new Queue<string>();
urgent.Push("U-1"); urgent.Push("U-2");
normal.Enqueue("N-1"); normal.Enqueue("N-2");
if (urgent.Count > 0) Console.WriteLine(urgent.Pop());
else if (normal.Count > 0) Console.WriteLine(normal.Dequeue());
else Console.WriteLine("No tickets waiting.");
```

```output
U-2
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is U-2. Connect each observation to the contract: Document whether urgent restoration happens at the front and whether normal work can starve. A completion-count bound is not a wall-clock bound. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Action|Undo|Redo|Current |
| --- | --- | --- | --- |
| Edit Reviewed|Draft|empty|Reviewed |
| Edit Approved|Draft, Reviewed|empty|Approved |
| Undo|Draft|Approved|Reviewed |
| Edit Revised|Draft, Reviewed|empty|Revised |

<!--
Walk through the rows before executing another example. Action: Undo: Redo: Current. Edit Reviewed: Draft: empty: Reviewed. Edit Approved: Draft, Reviewed: empty: Approved. Undo: Draft: Approved: Reviewed. Edit Revised: Draft, Reviewed: empty: Revised. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## After undo, a new edit occurs. What happens to redo?

1. Keep the abandoned branch
2. Clear it
3. Move every undo state into it

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: B. The new edit creates a different future. Replaying the abandoned branch would violate the current history. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Work rule|Useful structure |
| --- | --- |
| Latest completed action first|Stack |
| Earliest waiting request first|Queue |
| Restore at either boundary|Deque |
| Nearest discovered layer first|Queue with discovery tracking |

<!--
Work rule: Useful structure. Latest completed action first: Stack. Earliest waiting request first: Queue. Restore at either boundary: Deque. Nearest discovered layer first: Queue with discovery tracking. Document whether urgent restoration happens at the front and whether normal work can starve. A completion-count bound is not a wall-clock bound. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

An endless supply of urgent work can postpone normal work indefinitely. The data structure expresses a policy; it does not make that policy fair by itself.

<!--
An endless supply of urgent work can postpone normal work indefinitely. The data structure expresses a policy; it does not make that policy fair by itself. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## Serve at most two urgent items between normal services. What is bounded?

1. Elapsed waiting time in seconds
2. All ticket service durations
3. Urgent completions between normal services

<!--
Poll again after the contrasting case. Answer: C. Durations may vary or never finish. The stated sequential policy bounds a count of completions, not elapsed time. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

Remove both urgent Push calls. What prints from the worked example?

<!--
Pause for a prediction before changing the input or model. Answer: N-1 prints, because the normal queue supplies its earliest arrival when urgent work is absent. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Complete Split Urgent and Normal Tickets in the lesson. Print one urgent item, otherwise one normal item, otherwise the empty message.

[Open the lesson exercise](1503_applications_lab.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: Use the urgent Count guard first, then the normal guard. With both urgent pushes present, Pop returns U-2. With no urgent values, Dequeue returns N-1; with neither group, print No tickets waiting. Watch for this defect: An endless supply of urgent work can postpone normal work indefinitely. The data structure expresses a policy; it does not make that policy fair by itself.
-->

---

## Verify more than one example

Check urgent-only, normal-only, both-empty, repeated serve/restore, and a new edit after undo. Explain how the policy affects a waiting normal ticket.

<!--
Use independently predicted results. Check urgent-only, normal-only, both-empty, repeated serve/restore, and a new edit after undo. Explain how the policy affects a waiting normal ticket. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Choose a worklist from its policy.
- Keep undo and redo as separate histories.
- State a fairness bound precisely.

<!--
Document whether urgent restoration happens at the front and whether normal work can starve. A completion-count bound is not a wall-clock bound. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->
