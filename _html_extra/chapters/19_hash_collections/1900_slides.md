---
marp: true
theme: thinkpress-lecture
paginate: true
title: "Chapter 19: Hash Collections and Sets"
book: "Computer Science in C#"
section: "Chapter 19"
primary: "#2a6b37"
accent: "#b8860b"
---

<!-- _class: title -->

# 19. Hash Collections and Sets

Computer Science in C#

Contracts, worked traces, practice, and verified examples.

<!--
Chapter 19: Hash Collections and Sets.
Existing 110-minute chapter allocation: 35 minutes hashing;40 minutes reconciliation;35 minutes coordinated workloads.
Part 19.1: Hash Tables, Equality, and Collisions, starting slide 2.
Part 19.2: Dictionaries, Sets, and Reconciliation, starting slide 17.
Part 19.3: Choosing and Coordinating Collections, starting slide 32.
Each core part is a reading unit; follow the current three-meeting allocation rather than add one meeting per part. Supporting parts are explicitly optional. Quick-check and Your turn answers remain in these instructor notes; the student HTML omits them. All complete C# examples are standalone and recorded in the code verification manifest.
-->

---

<!-- _class: section -->

# 19.1. Hash Tables, Equality, and Collisions

Computer Science in C#

<!--
This part addresses separate hashing from key equality, trace rehashing before a load limit, keep tombstones distinct from empty slots. Read 1901_hashing.html with the worked examples. Use the selected trace and nearby practice within the chapter's existing meeting allocation; this part is a reading unit, not an extra required meeting.
-->

---

## Goals for this part

- Separate hashing from key equality
- Trace rehashing before a load limit
- Keep tombstones distinct from empty slots

<!--
Connect these goals to the chapter objectives before starting. The running case is: An inventory map receives integer keys 1,5,9,13. Capacity four sends the first three keys to the same bucket. Ask learners to predict one result before execution. Revisit the same contract at the recap rather than introducing an unrelated API tour.
-->

---

## State the business question

An inventory map receives integer keys 1,5,9,13. Capacity four sends the first three keys to the same bucket.

<!--
Ask which result the stakeholder actually needs. Equal keys must have equal hash codes. A faster program is useful only when it still answers that question. Ask students to name one input or policy that would change the answer, then introduce the contract.
-->

---

## Make the contract explicit

- Equal keys must have equal hash codes.
- A shared bucket does not establish equal keys.
- Replacing a key changes its value, not Count.

<!--
Explain each obligation in the running case. At capacity eight, keys 1 and 9 share bucket one, while 5 and 13 share bucket five. Copying the old bucket index would lose lookup consistency. Separate what clients can rely on from representation details. Ask what a missing, empty, tied, or invalid input means before moving to the trace.
-->

---

## Trace one small instance

| Key | key % 4 | key % 8 |
| ---: | ---: | ---: |
| 1 | 1 | 1 |
| 5 | 1 | 5 |
| 9 | 1 | 1 |
| 13 | 1 | 5 |

<!--
Walk the rows in order and pause before revealing the next state on screen. All four records occupy half the new table capacity. Hashing chooses candidates; equality still decides which record matches. The table records a logical trace; distinguish any sorted presentation view from physical storage layout. Ask a learner to justify one transition using the stated contract.
-->

---

## Follow the mechanism

- Find the bucket, then compare keys within its collision policy.
- Before insertion exceeds load 0.75, allocate double capacity.
- Recompute every key location under the new capacity.

<!--
Tie every step to a state change in the preceding trace. At capacity eight, keys 1 and 9 share bucket one, while 5 and 13 share bucket five. Copying the old bucket index would lose lookup consistency. Ask which step would fail if omitted or moved. The complete implementation stays in the lesson so the slide can focus on the algorithm's own progress rather than long support classes.
-->

---

## Keep the invariant in view

At capacity eight, keys 1 and 9 share bucket one, while 5 and 13 share bucket five. Copying the old bucket index would lose lookup consistency.

<!--
Name the exact program point where this statement applies. Contrast initialization, one update, and the exit condition. Do not call a printed success message a proof. Use the verification slide later to distinguish a check on a few examples from the general argument.
-->

---

## Run the small model

```csharp
using System;
foreach (int key in new[] { 1, 5, 9, 13 })
    Console.WriteLine($"{key}: {key % 4} -> {key % 8}");
Console.WriteLine(4.0 / 8);
```

```output
1: 1 -> 1
5: 1 -> 5
9: 1 -> 1
13: 1 -> 5
0.5
```

<!--
Before running, ask learners to predict the complete output. Run this standalone cell in a fresh C# application; it requires no previous cell. All four records occupy half the new table capacity. Hashing chooses candidates; equality still decides which record matches. If the demo environment fails, read the verified output and continue with the trace rather than spending the meeting on tool setup.
-->

---

## Explain the observed result

All four records occupy half the new table capacity. Hashing chooses candidates; equality still decides which record matches.

<!--
Ask learners to connect the output to the contract, not just read the numbers aloud. At capacity eight, keys 1 and 9 share bucket one, while 5 and 13 share bucket five. Copying the old bucket index would lose lookup consistency. Invite one controlled input change and predict its effect first. The worked output is evidence for this instance; the invariant and assumptions explain the broader claim.
-->

---

<!-- _class: check -->

## Quick check 1

What does a collision prove?

1. The keys are equal
2. Different keys may share a candidate location
3. The table has lost a record

<!--
Give 30 seconds individually, then compare with a neighbor. Answer: B. A collision is normal. The implementation must compare keys and preserve every distinct entry. Ask for the reason, not only the letter. If a common wrong choice dominates, replay the contract or trace before proceeding.
-->

---

## Boundaries are part of the model

- Chaining removes an entry from its bucket list.
- Linear probing marks a deleted slot as a tombstone.
- An absent probe stops at an empty slot or after a full bounded scan.

<!--
Choose one boundary and ask for an independently expected result. Check Count after insert, replacement, and removal. Distinguish a legal empty result from an invalid input. Do not silently change the contract to make a failing test disappear.
-->

---

<!-- _class: check -->

## Quick check 2

After placing 1,8,15 at slots 1,2,3, what happens if deleting 8 makes slot 2 empty?

1. Lookup of 15 can stop too early
2. Rehashing is unnecessary forever
3. All keys become equal

<!--
Poll for a prediction before revealing any explanation. Answer: A. Lookup starts at slot one and would interpret empty slot two as the end of the probe chain. A tombstone preserves the path to slot three. Link the distinction to the business case. Use a brief counterexample when a learner treats an assumption as a universal guarantee.
-->

---

<!-- _class: yourturn -->

## Your turn: Practice: Find a Colliding Key

- Choose another key with bucket index one at capacity four.
- Predict its new bucket at capacity eight.
- Distinguish a bucket collision from key equality.

[Open the section practice](1901_hashing.html)

<!--
Allow three to five minutes in pairs. This practice is drawn from the section's actual exercise; it does not create a new assessment ID. Answer and debrief: Key 17 maps to one under both capacities. It still differs from keys 1 and 9; equality checks must distinguish them. Ask learners to show their trace or checks before consulting the lesson solution. Assess reasoning as well as printed output.
-->

---

## Verify before recommending

- Check Count after insert, replacement, and removal.
- Trace present and missing lookups through collisions.
- Qualify expected O(1+load) with hashing assumptions; worst case is linear.

<!--
Ask learners to separate implementation checks, model assumptions, and performance claims. A. Lookup starts at slot one and would interpret empty slot two as the end of the probe chain. A tombstone preserves the path to slot three. Relate the requested evidence to the chapter lab/homework without changing their stable identities or making supporting readings silently compulsory.
-->

---

<!-- _class: recap -->

## Recap

- Separate hashing from key equality
- Trace rehashing before a load limit
- Keep tombstones distinct from empty slots

[Continue with the lesson and exercises](1901_hashing.html)

<!--
Invite a learner to explain one goal using the worked case. All four records occupy half the new table capacity. Hashing chooses candidates; equality still decides which record matches. Exit question: what input, representation, or contract change would require a new argument? Use the current assignment route and chapter schedule to select follow-up practice.
-->

---

<!-- _class: section -->

# 19.2. Dictionaries, Sets, and Reconciliation

Computer Science in C#

<!--
This part addresses choose one equality policy, distinguish membership from multiplicity, preserve inputs for multiple set reports. Read 1902_dictionaries_sets.html with the worked examples. Use the selected trace and nearby practice within the chapter's existing meeting allocation; this part is a reading unit, not an extra required meeting.
-->

---

## Goals for this part

- Choose one equality policy
- Distinguish membership from multiplicity
- Preserve inputs for multiple set reports

<!--
Connect these goals to the chapter objectives before starting. The running case is: Two branches record department IDs with inconsistent capitalization. A reconciliation result needs one declared identity policy. Ask learners to predict one result before execution. Revisit the same contract at the recap rather than introducing an unrelated API tour.
-->

---

## State the business question

Two branches record department IDs with inconsistent capitalization. A reconciliation result needs one declared identity policy.

<!--
Ask which result the stakeholder actually needs. Use the same comparer in every related collection. A faster program is useful only when it still answers that question. Ask students to name one input or policy that would change the answer, then introduce the contract.
-->

---

## Make the contract explicit

- Use the same comparer in every related collection.
- A set records membership once.
- A frequency dictionary records how many times a value occurs.

<!--
Explain each obligation in the running case. One equality policy must govern storage, lookup, and every set operation in the report. Case folding is a business assumption, not a universal correction. Separate what clients can rely on from representation details. Ask what a missing, empty, tied, or invalid input means before moving to the trace.
-->

---

## Trace one small instance

| Source | Raw IDs | Case-insensitive membership |
| --- | --- | --- |
| Expected | IT, HR, IT | IT, HR |
| Actual | it, SALES | IT, SALES |
| Expected minus actual | | HR |

<!--
Walk the rows in order and pause before revealing the next state on screen. HR is absent under the chosen policy. Copying preserved both expected IDs for a later report; modifying expected directly would have destroyed that input. The table records a logical trace; distinguish any sorted presentation view from physical storage layout. Ask a learner to justify one transition using the stated contract.
-->

---

## Follow the mechanism

- Construct a copy before a destructive set operation.
- Union combines membership; intersection retains shared membership.
- Expected.ExceptWith(actual) answers a directional missing-items question.

<!--
Tie every step to a state change in the preceding trace. One equality policy must govern storage, lookup, and every set operation in the report. Case folding is a business assumption, not a universal correction. Ask which step would fail if omitted or moved. The complete implementation stays in the lesson so the slide can focus on the algorithm's own progress rather than long support classes.
-->

---

## Keep the invariant in view

One equality policy must govern storage, lookup, and every set operation in the report. Case folding is a business assumption, not a universal correction.

<!--
Name the exact program point where this statement applies. Contrast initialization, one update, and the exit condition. Do not call a printed success message a proof. Use the verification slide later to distinguish a check on a few examples from the general argument.
-->

---

## Run the small model

```csharp
using System; using System.Collections.Generic;
var comparer = StringComparer.OrdinalIgnoreCase;
var expected = new HashSet<string>(comparer) { "IT", "HR" };
var actual = new HashSet<string>(comparer) { "it", "SALES" };
var missing = new HashSet<string>(expected, expected.Comparer);
missing.ExceptWith(actual);
Console.WriteLine(string.Join(",", missing));
Console.WriteLine(expected.Count);
```

```output
HR
2
```

<!--
Before running, ask learners to predict the complete output. Run this standalone cell in a fresh C# application; it requires no previous cell. HR is absent under the chosen policy. Copying preserved both expected IDs for a later report; modifying expected directly would have destroyed that input. If the demo environment fails, read the verified output and continue with the trace rather than spending the meeting on tool setup.
-->

---

## Explain the observed result

HR is absent under the chosen policy. Copying preserved both expected IDs for a later report; modifying expected directly would have destroyed that input.

<!--
Ask learners to connect the output to the contract, not just read the numbers aloud. One equality policy must govern storage, lookup, and every set operation in the report. Case folding is a business assumption, not a universal correction. Invite one controlled input change and predict its effect first. The worked output is evidence for this instance; the invariant and assumptions explain the broader claim.
-->

---

<!-- _class: check -->

## Quick check 1

Which representation preserves the number of repeated invoices per supplier?

1. HashSet only
2. A frequency dictionary
3. An arbitrary hash code

<!--
Give 30 seconds individually, then compare with a neighbor. Answer: B. A set collapses repeated membership. Use a dictionary from supplier identity to a count when multiplicity matters. Ask for the reason, not only the letter. If a common wrong choice dominates, replay the contract or trace before proceeding.
-->

---

## Boundaries are part of the model

- A recorded zero is different from a missing key.
- An empty difference is a valid result.
- Mutable key fields must not change equality/hash meaning while stored.

<!--
Choose one boundary and ask for an independently expected result. Assert source sets are unchanged after each report. Distinguish a legal empty result from an invalid input. Do not silently change the contract to make a failing test disappear.
-->

---

<!-- _class: check -->

## Quick check 2

Expected={A,B}, actual={B,C}. What is actual minus expected?

1. A
2. B
3. C

<!--
Poll for a prediction before revealing any explanation. Answer: C. Difference is directional. Reversing the operands answers a different reconciliation question. Link the distinction to the business case. Use a brief counterexample when a learner treats an assumption as a universal guarantee.
-->

---

<!-- _class: yourturn -->

## Your turn: Practice: Report Missing IDs

- Create a nonmutating missing-ID report.
- Test an empty expected set and case variants.
- Explain the selected equality policy.

[Open the section practice](1902_dictionaries_sets.html)

<!--
Allow three to five minutes in pairs. This practice is drawn from the section's actual exercise; it does not create a new assessment ID. Answer and debrief: Copy expected with its comparer, then subtract actual. Empty expected yields no missing IDs. Under OrdinalIgnoreCase, IT and it identify the same department; under Ordinal they do not. Ask learners to show their trace or checks before consulting the lesson solution. Assess reasoning as well as printed output.
-->

---

## Verify before recommending

- Assert source sets are unchanged after each report.
- Check directional difference separately from intersection.
- Test duplicate input labels before choosing a set instead of counts.

<!--
Ask learners to separate implementation checks, model assumptions, and performance claims. C. Difference is directional. Reversing the operands answers a different reconciliation question. Relate the requested evidence to the chapter lab/homework without changing their stable identities or making supporting readings silently compulsory.
-->

---

<!-- _class: recap -->

## Recap

- Choose one equality policy
- Distinguish membership from multiplicity
- Preserve inputs for multiple set reports

[Continue with the lesson and exercises](1902_dictionaries_sets.html)

<!--
Invite a learner to explain one goal using the worked case. HR is absent under the chosen policy. Copying preserved both expected IDs for a later report; modifying expected directly would have destroyed that input. Exit question: what input, representation, or contract change would require a new argument? Use the current assignment route and chapter schedule to select follow-up practice.
-->

---

<!-- _class: section -->

# 19.3. Choosing and Coordinating Collections

Computer Science in C#

<!--
This part addresses match each operation to its representation, skip cancelled and superseded queue entries, explain a versioned dispatch invariant. Read 1903_collection_selection.html with the worked examples. Use the selected trace and nearby practice within the chapter's existing meeting allocation; this part is a reading unit, not an extra required meeting.
-->

---

## Goals for this part

- Match each operation to its representation
- Skip cancelled and superseded queue entries
- Explain a versioned dispatch invariant

<!--
Connect these goals to the chapter objectives before starting. The running case is: A ticket dictionary stores current state while a priority queue may retain old physical entries after reprioritization or cancellation. Ask learners to predict one result before execution. Revisit the same contract at the recap rather than introducing an unrelated API tour.
-->

---

## State the business question

A ticket dictionary stores current state while a priority queue may retain old physical entries after reprioritization or cancellation.

<!--
Ask which result the stakeholder actually needs. The dictionary is the current logical active set. A faster program is useful only when it still answers that question. Ask students to name one input or policy that would change the answer, then introduce the contract.
-->

---

## Make the contract explicit

- The dictionary is the current logical active set.
- A queued entry contains ID plus version.
- Dispatch requires both active membership and the current version.

<!--
Explain each obligation in the running case. A stale entry can still name an active ID. Presence alone would serve ticket 10 at its obsolete urgency before ticket 20. Separate what clients can rely on from representation details. Ask what a missing, empty, tied, or invalid input means before moving to the trace.
-->

---

## Trace one small instance

| Event | Current dictionary | Queued entry |
| --- | --- | --- |
| Open ticket 10 | version 1, urgency 0 | (10,1) at 0 |
| Reprioritize 10 | version 2, urgency 5 | (10,2) at 5 |
| Open ticket 20 | version 1, urgency 2 | (20,1) at 2 |

<!--
Walk the rows in order and pause before revealing the next state on screen. Ticket 10 version one is superseded, and ticket 30 is absent. Ticket 20 therefore leaves before the current urgency-five version of ticket 10. The table records a logical trace; distinguish any sorted presentation view from physical storage layout. Ask a learner to justify one transition using the stated contract.
-->

---

## Follow the mechanism

- Update the active record and enqueue its new version.
- Skip entries with missing IDs or obsolete versions.
- Remove the current active record exactly when serving it.

<!--
Tie every step to a state change in the preceding trace. A stale entry can still name an active ID. Presence alone would serve ticket 10 at its obsolete urgency before ticket 20. Ask which step would fail if omitted or moved. The complete implementation stays in the lesson so the slide can focus on the algorithm's own progress rather than long support classes.
-->

---

## Keep the invariant in view

A stale entry can still name an active ID. Presence alone would serve ticket 10 at its obsolete urgency before ticket 20.

<!--
Name the exact program point where this statement applies. Contrast initialization, one update, and the exit condition. Do not call a printed success message a proof. Use the verification slide later to distinguish a check on a few examples from the general argument.
-->

---

## Run the small model

```csharp
using System; using System.Collections.Generic;
var current = new Dictionary<int, int> { [10] = 2, [20] = 1 };
var queue = new PriorityQueue<(int Id, int Version), int>();
queue.Enqueue((10, 1), 0); queue.Enqueue((30, 1), 1);
queue.Enqueue((20, 1), 2); queue.Enqueue((10, 2), 5);
while (queue.TryDequeue(out var item, out _))
    if (current.TryGetValue(item.Id, out int v) && v == item.Version)
    { current.Remove(item.Id); Console.WriteLine(item.Id); }
```

```output
20
10
```

<!--
Before running, ask learners to predict the complete output. Run this standalone cell in a fresh C# application; it requires no previous cell. Ticket 10 version one is superseded, and ticket 30 is absent. Ticket 20 therefore leaves before the current urgency-five version of ticket 10. If the demo environment fails, read the verified output and continue with the trace rather than spending the meeting on tool setup.
-->

---

## Explain the observed result

Ticket 10 version one is superseded, and ticket 30 is absent. Ticket 20 therefore leaves before the current urgency-five version of ticket 10.

<!--
Ask learners to connect the output to the contract, not just read the numbers aloud. A stale entry can still name an active ID. Presence alone would serve ticket 10 at its obsolete urgency before ticket 20. Invite one controlled input change and predict its effect first. The worked output is evidence for this instance; the invariant and assumptions explain the broader claim.
-->

---

<!-- _class: check -->

## Quick check 1

An ID exists in the active dictionary. Is every queue entry for it valid?

1. Yes
2. Only when the queued version also matches
3. Only when the ID is a string

<!--
Give 30 seconds individually, then compare with a neighbor. Answer: B. The ID may have an old urgency. Version equality detects superseded physical entries. Ask for the reason, not only the letter. If a common wrong choice dominates, replay the contract or trace before proceeding.
-->

---

## Boundaries are part of the model

- Never-reused IDs simplify a cancellation-only FIFO queue.
- Priority changes still require versions while an ID remains active.
- Cancel-all may leave many physical entries that must be skipped.

<!--
Choose one boundary and ask for an independently expected result. Check duplicate issue and ID-reuse contracts. Distinguish a legal empty result from an invalid input. Do not silently change the contract to make a failing test disappear.
-->

---

<!-- _class: check -->

## Quick check 2

Which structure directly supports ordered key-range queries?

1. A hash bucket number
2. An ordered tree or sorted representation
3. A FIFO queue alone

<!--
Poll for a prediction before revealing any explanation. Answer: B. Hash lookup addresses equality, not range order. Choose a representation for the requested operation rather than a favorite API. Link the distinction to the business case. Use a brief counterexample when a learner treats an assumption as a universal guarantee.
-->

---

<!-- _class: yourturn -->

## Your turn: Practice: Skip a Cancelled Entry

- Dispatch only IDs still in the active dictionary.
- Keep never-reused IDs explicit.
- Explain what extra check a priority update needs.

[Open the section practice](1903_collection_selection.html)

<!--
Allow three to five minutes in pairs. This practice is drawn from the section's actual exercise; it does not create a new assessment ID. Answer and debrief: Skip a cancelled ID and serve the first still-active FIFO ID. Never-reused IDs make membership sufficient for this exercise; priority updates additionally require the version comparison demonstrated earlier. Ask learners to show their trace or checks before consulting the lesson solution. Assess reasoning as well as printed output.
-->

---

## Verify before recommending

- Check duplicate issue and ID-reuse contracts.
- Test two updates before service and equal-priority arrival order.
- Measure lookup, enqueue, stale removal, and output work separately.

<!--
Ask learners to separate implementation checks, model assumptions, and performance claims. B. Hash lookup addresses equality, not range order. Choose a representation for the requested operation rather than a favorite API. Relate the requested evidence to the chapter lab/homework without changing their stable identities or making supporting readings silently compulsory.
-->

---

<!-- _class: recap -->

## Recap

- Match each operation to its representation
- Skip cancelled and superseded queue entries
- Explain a versioned dispatch invariant

[Continue with the lesson and exercises](1903_collection_selection.html)

<!--
Invite a learner to explain one goal using the worked case. Ticket 10 version one is superseded, and ticket 30 is absent. Ticket 20 therefore leaves before the current urgency-five version of ticket 10. Exit question: what input, representation, or contract change would require a new argument? Use the current assignment route and chapter schedule to select follow-up practice.
-->
