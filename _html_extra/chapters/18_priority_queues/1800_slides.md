---
marp: true
theme: thinkpress-lecture
paginate: true
title: "Chapter 18: Priority Queues and Heaps"
book: "Computer Science in C#"
section: "Chapter 18"
primary: "#2a6b37"
accent: "#b8860b"
---

<!-- _class: title -->

# 18. Priority Queues and Heaps

Computer Science in C#

Contracts, worked traces, practice, and verified examples.

<!--
Chapter 18: Priority Queues and Heaps.
Existing 110-minute chapter allocation: 35 minutes contracts/shape;40 minutes repairs;35 minutes top-k/fairness.
Part 18.1: Priority Queue Contracts and Heap Shape, starting slide 2.
Part 18.2: Implementing and Checking a Binary Heap, starting slide 17.
Part 18.3: Priority Workloads and Top-K Selection, starting slide 32.
Each core part is a reading unit; follow the current three-meeting allocation rather than add one meeting per part. Supporting parts are explicitly optional. Quick-check and Your turn answers remain in these instructor notes; the student HTML omits them. All complete C# examples are standalone and recorded in the code verification manifest.
-->

---

<!-- _class: section -->

# 18.1. Priority Queue Contracts and Heap Shape

Computer Science in C#

<!--
This part addresses state minimum-priority removal, make equal-urgency arrival order explicit, translate heap positions into a complete tree. Read 1801_priority_queues.html with the worked examples. Use the selected trace and nearby practice within the chapter's existing meeting allocation; this part is a reading unit, not an extra required meeting.
-->

---

## Goals for this part

- State minimum-priority removal
- Make equal-urgency arrival order explicit
- Translate heap positions into a complete tree

<!--
Connect these goals to the chapter objectives before starting. The running case is: A service desk must select urgency one before urgency five. Arrival order matters only after urgency ties. Ask learners to predict one result before execution. Revisit the same contract at the recap rather than introducing an unrelated API tour.
-->

---

## State the business question

A service desk must select urgency one before urgency five. Arrival order matters only after urgency ties.

<!--
Ask which result the stakeholder actually needs. Smaller numeric priority leaves first. A faster program is useful only when it still answers that question. Ask students to name one input or policy that would change the answer, then introduce the contract.
-->

---

## Make the contract explicit

- Smaller numeric priority leaves first.
- Equal priorities have no implicit FIFO promise.
- An empty removal needs a declared failure policy.

<!--
Explain each obligation in the running case. A min-heap requires each parent to be no greater than its children. Siblings need not be ordered. Separate what clients can rely on from representation details. Ask what a missing, empty, tied, or invalid input means before moving to the trace.
-->

---

## Trace one small instance

| Request | Urgency | Arrival |
| --- | ---: | ---: |
| Routine | 5 | 0 |
| First urgent | 1 | 1 |
| Second urgent | 1 | 2 |

<!--
Walk the rows in order and pause before revealing the next state on screen. Both urgent requests beat Routine; their increasing arrival numbers resolve the tie without assuming library stability. The table records a logical trace; distinguish any sorted presentation view from physical storage layout. Ask a learner to justify one transition using the stated contract.
-->

---

## Follow the mechanism

- Give each arrival an increasing sequence number.
- Compare urgency first, then arrival.
- Treat removal order as a contract, not a fully sorted array.

<!--
Tie every step to a state change in the preceding trace. A min-heap requires each parent to be no greater than its children. Siblings need not be ordered. Ask which step would fail if omitted or moved. The complete implementation stays in the lesson so the slide can focus on the algorithm's own progress rather than long support classes.
-->

---

## Keep the invariant in view

A min-heap requires each parent to be no greater than its children. Siblings need not be ordered.

<!--
Name the exact program point where this statement applies. Contrast initialization, one update, and the exit condition. Do not call a printed success message a proof. Use the verification slide later to distinguish a check on a few examples from the general argument.
-->

---

## Run the small model

```csharp
using System; using System.Collections.Generic;
var queue = new PriorityQueue<string, (int, int)>();
queue.Enqueue("Routine", (5, 0));
queue.Enqueue("First urgent", (1, 1));
queue.Enqueue("Second urgent", (1, 2));
while (queue.Count > 0) Console.WriteLine(queue.Dequeue());
```

```output
First urgent
Second urgent
Routine
```

<!--
Before running, ask learners to predict the complete output. Run this standalone cell in a fresh C# application; it requires no previous cell. Both urgent requests beat Routine; their increasing arrival numbers resolve the tie without assuming library stability. If the demo environment fails, read the verified output and continue with the trace rather than spending the meeting on tool setup.
-->

---

## Explain the observed result

Both urgent requests beat Routine; their increasing arrival numbers resolve the tie without assuming library stability.

<!--
Ask learners to connect the output to the contract, not just read the numbers aloud. A min-heap requires each parent to be no greater than its children. Siblings need not be ordered. Invite one controlled input change and predict its effect first. The worked output is evidence for this instance; the invariant and assumptions explain the broader claim.
-->

---

<!-- _class: check -->

## Quick check 1

Which priority makes a later urgency-one request follow an earlier urgency-one request?

1. (1, later arrival number)
2. (later arrival number, 1)
3. Unspecified equal integers

<!--
Give 30 seconds individually, then compare with a neighbor. Answer: A. Urgency must be the first key; arrival is the secondary key. Reversing the keys makes arrival the primary policy. Ask for the reason, not only the letter. If a common wrong choice dominates, replay the contract or trace before proceeding.
-->

---

## Boundaries are part of the model

- Empty: use TryDequeue or handle the declared exception.
- Singleton: root is both first and last.
- Ties: test an explicit arrival policy.

<!--
Choose one boundary and ask for an independently expected result. Check the minimum element after each change. Distinguish a legal empty result from an invalid input. Do not silently change the contract to make a failing test disappear.
-->

---

<!-- _class: check -->

## Quick check 2

Is the heap array [1,4,2,7,5] fully sorted?

1. Yes, because the root is minimum
2. No, but it satisfies the min-heap rule
3. No, so it cannot represent a heap

<!--
Poll for a prediction before revealing any explanation. Answer: B. The 4 precedes 2 in the array, but parent 1 is below neither child, and parent 4 is no greater than 7 and 5. Link the distinction to the business case. Use a brief counterexample when a learner treats an assumption as a universal guarantee.
-->

---

<!-- _class: yourturn -->

## Your turn: Practice: Service the Minimum Priority

- Enqueue three service requests with explicit urgency.
- Predict every removal before running.
- Change one urgency and explain the new order.

[Open the section practice](1801_priority_queues.html)

<!--
Allow three to five minutes in pairs. This practice is drawn from the section's actual exercise; it does not create a new assessment ID. Answer and debrief: A request at minimum urgency leaves first. Use arrival numbers only to resolve equal urgencies; do not promise FIFO between different priorities. Ask learners to show their trace or checks before consulting the lesson solution. Assess reasoning as well as printed output.
-->

---

## Verify before recommending

- Check the minimum element after each change.
- Drain a copy to check order and occurrence counts.
- Compare parent-child pairs rather than adjacent positions.

<!--
Ask learners to separate implementation checks, model assumptions, and performance claims. B. The 4 precedes 2 in the array, but parent 1 is below neither child, and parent 4 is no greater than 7 and 5. Relate the requested evidence to the chapter lab/homework without changing their stable identities or making supporting readings silently compulsory.
-->

---

<!-- _class: recap -->

## Recap

- State minimum-priority removal
- Make equal-urgency arrival order explicit
- Translate heap positions into a complete tree

[Continue with the lesson and exercises](1801_priority_queues.html)

<!--
Invite a learner to explain one goal using the worked case. Both urgent requests beat Routine; their increasing arrival numbers resolve the tie without assuming library stability. Exit question: what input, representation, or contract change would require a new argument? Use the current assignment route and chapter schedule to select follow-up practice.
-->

---

<!-- _class: section -->

# 18.2. Implementing and Checking a Binary Heap

Computer Science in C#

<!--
This part addresses trace sift-up after insertion, trace sift-down after root removal, check parent-child order independently. Read 1802_heap_implementation.html with the worked examples. Use the selected trace and nearby practice within the chapter's existing meeting allocation; this part is a reading unit, not an extra required meeting.
-->

---

## Goals for this part

- Trace sift-up after insertion
- Trace sift-down after root removal
- Check parent-child order independently

<!--
Connect these goals to the chapter objectives before starting. The running case is: Insert urgency two into the desk heap [3,7,5,9]. Repair the path disturbed by the new leaf. Ask learners to predict one result before execution. Revisit the same contract at the recap rather than introducing an unrelated API tour.
-->

---

## State the business question

Insert urgency two into the desk heap [3,7,5,9]. Repair the path disturbed by the new leaf.

<!--
Ask which result the stakeholder actually needs. Parent index is (child-1)/2. A faster program is useful only when it still answers that question. Ask students to name one input or policy that would change the answer, then introduce the contract.
-->

---

## Make the contract explicit

- Parent index is (child-1)/2.
- Child indexes are 2p+1 and 2p+2.
- Count determines which array positions are active.

<!--
Explain each obligation in the running case. All edges outside the repair path retain their order. Checking the entire heap after a repair is independent verification, not part of the repair itself. Separate what clients can rely on from representation details. Ask what a missing, empty, tied, or invalid input means before moving to the trace.
-->

---

## Trace one small instance

| Event | Heap array |
| --- | --- |
| Append 2 | [3,7,5,9,2] |
| Swap with 7 | [3,2,5,9,7] |
| Swap with 3 | [2,3,5,9,7] |

<!--
Walk the rows in order and pause before revealing the next state on screen. Position four has parent one. The scan checks every active parent-child relation and accepts this heap even though the array is not globally sorted. The table records a logical trace; distinguish any sorted presentation view from physical storage layout. Ask a learner to justify one transition using the stated contract.
-->

---

## Follow the mechanism

- Insertion appends at the complete-tree boundary.
- Swap upward only while child is smaller than parent.
- Removal moves the last value to the root and follows the smaller child downward.

<!--
Tie every step to a state change in the preceding trace. All edges outside the repair path retain their order. Checking the entire heap after a repair is independent verification, not part of the repair itself. Ask which step would fail if omitted or moved. The complete implementation stays in the lesson so the slide can focus on the algorithm's own progress rather than long support classes.
-->

---

## Keep the invariant in view

All edges outside the repair path retain their order. Checking the entire heap after a repair is independent verification, not part of the repair itself.

<!--
Name the exact program point where this statement applies. Contrast initialization, one update, and the exit condition. Do not call a printed success message a proof. Use the verification slide later to distinguish a check on a few examples from the general argument.
-->

---

## Run the small model

```csharp
using System;
int[] heap = { 2, 3, 5, 9, 7 };
bool valid = true;
for (int child = 1; child < heap.Length; child++)
    valid &= heap[(child - 1) / 2] <= heap[child];
Console.WriteLine(valid);
Console.WriteLine((4 - 1) / 2);
```

```output
True
1
```

<!--
Before running, ask learners to predict the complete output. Run this standalone cell in a fresh C# application; it requires no previous cell. Position four has parent one. The scan checks every active parent-child relation and accepts this heap even though the array is not globally sorted. If the demo environment fails, read the verified output and continue with the trace rather than spending the meeting on tool setup.
-->

---

## Explain the observed result

Position four has parent one. The scan checks every active parent-child relation and accepts this heap even though the array is not globally sorted.

<!--
Ask learners to connect the output to the contract, not just read the numbers aloud. All edges outside the repair path retain their order. Checking the entire heap after a repair is independent verification, not part of the repair itself. Invite one controlled input change and predict its effect first. The worked output is evidence for this instance; the invariant and assumptions explain the broader claim.
-->

---

<!-- _class: check -->

## Quick check 1

During sift-down, which child must be compared with the parent?

1. Always the left child
2. The smaller existing child
3. The child with the larger index

<!--
Give 30 seconds individually, then compare with a neighbor. Answer: B. Swapping with the larger child can leave the other child smaller than its new parent. Check that the right child exists before comparing children. Ask for the reason, not only the letter. If a common wrong choice dominates, replay the contract or trace before proceeding.
-->

---

## Boundaries are part of the model

- Empty PopMin must reject removal.
- A singleton removes without reading a new root.
- A parent may have a left child but no right child.

<!--
Choose one boundary and ask for an independently expected result. Run ascending, reverse, duplicate, and singleton cases. Distinguish a legal empty result from an invalid input. Do not silently change the contract to make a failing test disappear.
-->

---

<!-- _class: check -->

## Quick check 2

An append causes the backing array to grow. What cost belongs in the explanation?

1. Every insertion has strict constant cost
2. Only the sift comparisons matter
3. Growth may copy many values; amortized and single-operation costs differ

<!--
Poll for a prediction before revealing any explanation. Answer: C. Sifting follows logarithmic height, but storage growth may be linear for that operation. Count copies separately from comparisons. Link the distinction to the business case. Use a brief counterexample when a learner treats an assumption as a universal guarantee.
-->

---

<!-- _class: yourturn -->

## Your turn: Practice: Check Every Parent

- Write an independent min-heap predicate.
- Reject [2,7,5,9,3] and accept [2,3,5,9,7].
- Explain which parent-child pair exposes the defect.

[Open the section practice](1802_heap_implementation.html)

<!--
Allow three to five minutes in pairs. This practice is drawn from the section's actual exercise; it does not create a new assessment ID. Answer and debrief: The last value 3 is below parent 7 in the faulty heap. Do not compare only the root or only neighboring array positions. Ask learners to show their trace or checks before consulting the lesson solution. Assess reasoning as well as printed output.
-->

---

## Verify before recommending

- Run ascending, reverse, duplicate, and singleton cases.
- Check invariant after each insertion and removal.
- Separate comparison counters from verification scans.

<!--
Ask learners to separate implementation checks, model assumptions, and performance claims. C. Sifting follows logarithmic height, but storage growth may be linear for that operation. Count copies separately from comparisons. Relate the requested evidence to the chapter lab/homework without changing their stable identities or making supporting readings silently compulsory.
-->

---

<!-- _class: recap -->

## Recap

- Trace sift-up after insertion
- Trace sift-down after root removal
- Check parent-child order independently

[Continue with the lesson and exercises](1802_heap_implementation.html)

<!--
Invite a learner to explain one goal using the worked case. Position four has parent one. The scan checks every active parent-child relation and accepts this heap even though the array is not globally sorted. Exit question: what input, representation, or contract change would require a new argument? Use the current assignment route and chapter schedule to select follow-up practice.
-->

---

<!-- _class: section -->

# 18.3. Priority Workloads and Top-K Selection

Computer Science in C#

<!--
This part addresses justify a bounded heap for top-k, include all retained and removed occurrences, distinguish priority order from fairness. Read 1803_priority_applications.html with the worked examples. Use the selected trace and nearby practice within the chapter's existing meeting allocation; this part is a reading unit, not an extra required meeting.
-->

---

## Goals for this part

- Justify a bounded heap for top-k
- Include all retained and removed occurrences
- Distinguish priority order from fairness

<!--
Connect these goals to the chapter objectives before starting. The running case is: A workload dashboard needs the three largest estimates from 8,2,10,5,12 without sorting every discarded estimate. Ask learners to predict one result before execution. Revisit the same contract at the recap rather than introducing an unrelated API tour.
-->

---

## State the business question

A workload dashboard needs the three largest estimates from 8,2,10,5,12 without sorting every discarded estimate.

<!--
Ask which result the stakeholder actually needs. Keep at most k retained candidates. A faster program is useful only when it still answers that question. Ask students to name one input or policy that would change the answer, then introduce the contract.
-->

---

## Make the contract explicit

- Keep at most k retained candidates.
- The root is the smallest retained value.
- Replace the weakest candidate when a larger one arrives.

<!--
Explain each obligation in the running case. After each input prefix, retained candidates are its k largest values, or all values if fewer than k have arrived. Separate what clients can rely on from representation details. Ask what a missing, empty, tied, or invalid input means before moving to the trace.
-->

---

## Trace one small instance

| Next estimate | Retained values in sorted view |
| ---: | --- |
| 8,2,10 | 2,8,10 |
| 5 | 5,8,10 |
| 12 | 8,10,12 |

<!--
Walk the rows in order and pause before revealing the next state on screen. Draining returns the retained top three in ascending order. The goal was selection, so discarding smaller values is intentional, while tied occurrences still count. The table records a logical trace; distinguish any sorted presentation view from physical storage layout. Ask a learner to justify one transition using the stated contract.
-->

---

## Follow the mechanism

- Use a minimum heap, not a maximum heap.
- Insert the new value, then remove minimum if Count exceeds k.
- A sorted view in this trace does not describe the heap layout.

<!--
Tie every step to a state change in the preceding trace. After each input prefix, retained candidates are its k largest values, or all values if fewer than k have arrived. Ask which step would fail if omitted or moved. The complete implementation stays in the lesson so the slide can focus on the algorithm's own progress rather than long support classes.
-->

---

## Keep the invariant in view

After each input prefix, retained candidates are its k largest values, or all values if fewer than k have arrived.

<!--
Name the exact program point where this statement applies. Contrast initialization, one update, and the exit condition. Do not call a printed success message a proof. Use the verification slide later to distinguish a check on a few examples from the general argument.
-->

---

## Run the small model

```csharp
using System; using System.Collections.Generic;
var best = new PriorityQueue<int, int>();
foreach (int value in new[] { 8, 2, 10, 5, 12 })
{
    best.Enqueue(value, value);
    if (best.Count > 3) best.Dequeue();
}
while (best.Count > 0) Console.WriteLine(best.Dequeue());
```

```output
8
10
12
```

<!--
Before running, ask learners to predict the complete output. Run this standalone cell in a fresh C# application; it requires no previous cell. Draining returns the retained top three in ascending order. The goal was selection, so discarding smaller values is intentional, while tied occurrences still count. If the demo environment fails, read the verified output and continue with the trace rather than spending the meeting on tool setup.
-->

---

## Explain the observed result

Draining returns the retained top three in ascending order. The goal was selection, so discarding smaller values is intentional, while tied occurrences still count.

<!--
Ask learners to connect the output to the contract, not just read the numbers aloud. After each input prefix, retained candidates are its k largest values, or all values if fewer than k have arrived. Invite one controlled input change and predict its effect first. The worked output is evidence for this instance; the invariant and assumptions explain the broader claim.
-->

---

<!-- _class: check -->

## Quick check 1

Why is the top-k root a minimum?

1. It exposes the weakest retained candidate
2. It proves all inputs are sorted
3. It removes duplicate values automatically

<!--
Give 30 seconds individually, then compare with a neighbor. Answer: A. The weakest retained item is exactly the one to evict. A maximum root hides that boundary. Ask for the reason, not only the letter. If a common wrong choice dominates, replay the contract or trace before proceeding.
-->

---

## Boundaries are part of the model

- k=1 reduces to retaining the maximum.
- Reject nonpositive k under the teaching contract.
- Equal priorities need an explicit tie rule if identity matters.

<!--
Choose one boundary and ask for an independently expected result. Compare against a reference sort on small streams. Distinguish a legal empty result from an invalid input. Do not silently change the contract to make a failing test disappear.
-->

---

<!-- _class: check -->

## Quick check 2

Arrival numbers resolve ties. Do they prevent starvation?

1. Yes, for all urgency levels
2. Only if all priorities differ
3. No, lower-priority requests can still wait forever

<!--
Poll for a prediction before revealing any explanation. Answer: C. A continual stream of more urgent work can postpone a less urgent request. Aging changes the priority policy rather than merely resolving equal priorities. Link the distinction to the business case. Use a brief counterexample when a learner treats an assumption as a universal guarantee.
-->

---

<!-- _class: yourturn -->

## Your turn: Practice: Explain Priority and Fairness

- Construct a strict-priority starvation scenario.
- Specify a simulated aging rule.
- Explain when priorities must be recomputed.

[Open the section practice](1803_priority_applications.html)

<!--
Allow three to five minutes in pairs. This practice is drawn from the section's actual exercise; it does not create a new assessment ID. Answer and debrief: Repeated urgency-zero arrivals can starve an urgency-five ticket. For effective urgency base-waitTicks, that ticket reaches zero after five ticks; update queued priorities or rebuild them at defined times. Ask learners to show their trace or checks before consulting the lesson solution. Assess reasoning as well as printed output.
-->

---

## Verify before recommending

- Compare against a reference sort on small streams.
- Bound selection by O(n log k) with O(k) retained storage.
- Count output work separately when draining or sorting the result.

<!--
Ask learners to separate implementation checks, model assumptions, and performance claims. C. A continual stream of more urgent work can postpone a less urgent request. Aging changes the priority policy rather than merely resolving equal priorities. Relate the requested evidence to the chapter lab/homework without changing their stable identities or making supporting readings silently compulsory.
-->

---

<!-- _class: recap -->

## Recap

- Justify a bounded heap for top-k
- Include all retained and removed occurrences
- Distinguish priority order from fairness

[Continue with the lesson and exercises](1803_priority_applications.html)

<!--
Invite a learner to explain one goal using the worked case. Draining returns the retained top three in ascending order. The goal was selection, so discarding smaller values is intentional, while tied occurrences still count. Exit question: what input, representation, or contract change would require a new argument? Use the current assignment route and chapter schedule to select follow-up practice.
-->
