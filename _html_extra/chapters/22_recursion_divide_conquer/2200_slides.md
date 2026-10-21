---
marp: true
theme: thinkpress-lecture
paginate: true
title: "Chapter 22: Recursion and Divide-and-Conquer"
book: "Computer Science in C#"
section: "Chapter 22"
primary: "#2a6b37"
accent: "#b8860b"
---

<!-- _class: title -->

# 22. Recursion and Divide-and-Conquer

Computer Science in C#

Contracts, worked traces, practice, and verified examples.

<!--
Chapter 22: Recursion and Divide-and-Conquer.
Existing 110-minute chapter allocation: 35 minutes recursive contracts;40 minutes stable merge development;35 minutes verification across the two readings.
Part 22.1: Recursive Contracts and Divide-and-Conquer, starting slide 2.
Part 22.2: Stable Merge Sort and Verification, starting slide 17.
Each core part is a reading unit; follow the current three-meeting allocation rather than add one meeting per part. Supporting parts are explicitly optional. Quick-check and Your turn answers remain in these instructor notes; the student HTML omits them. All complete C# examples are standalone and recorded in the code verification manifest.
-->

---

<!-- _class: section -->

# 22.1. Recursive Contracts and Divide-and-Conquer

Computer Science in C#

<!--
This part addresses specify domain, base case, and progress, trace suspended work and returned results, keep recursive search intervals complete. Read 2201_recursion.html with the worked examples. Use the selected trace and nearby practice within the chapter's existing meeting allocation; this part is a reading unit, not an extra required meeting.
-->

---

## Goals for this part

- Specify domain, base case, and progress
- Trace suspended work and returned results
- Keep recursive search intervals complete

<!--
Connect these goals to the chapter objectives before starting. The running case is: A factorial helper must reject impossible inputs rather than confuse termination with safe arithmetic. Ask learners to predict one result before execution. Revisit the same contract at the recap rather than introducing an unrelated API tour.
-->

---

## State the business question

A factorial helper must reject impossible inputs rather than confuse termination with safe arithmetic.

<!--
Ask which result the stakeholder actually needs. Factorial accepts integers zero through 20 for long results. A faster program is useful only when it still answers that question. Ask students to name one input or policy that would change the answer, then introduce the contract.
-->

---

## Make the contract explicit

- Factorial accepts integers zero through 20 for long results.
- The base case returns one for zero.
- Each recursive call receives n-1; multiplication is checked.

<!--
Explain each obligation in the running case. Mathematical progress does not prevent C# overflow. The legal domain and checked arithmetic are part of the executable contract. Separate what clients can rely on from representation details. Ask what a missing, empty, tied, or invalid input means before moving to the trace.
-->

---

## Trace one small instance

| Event for factorial(3) | Waiting work |
| --- | --- |
| Call 3 then 2 then 1 then 0 | 3 times (2 times (1 times result)) |
| Return from 0 | 1 |
| Return from 1,2,3 | 1,2,6 |

<!--
Walk the rows in order and pause before revealing the next state on screen. Zero is a valid base input, while 21 is rejected before an overflowing multiplication. The recursive structure alone does not establish a safe numeric domain. The table records a logical trace; distinguish any sorted presentation view from physical storage layout. Ask a learner to justify one transition using the stated contract.
-->

---

## Follow the mechanism

- Give the helper one smaller problem with an exact contract.
- Keep each frame's local input distinct.
- Prove the decrease and check result-type limits separately.

<!--
Tie every step to a state change in the preceding trace. Mathematical progress does not prevent C# overflow. The legal domain and checked arithmetic are part of the executable contract. Ask which step would fail if omitted or moved. The complete implementation stays in the lesson so the slide can focus on the algorithm's own progress rather than long support classes.
-->

---

## Keep the invariant in view

Mathematical progress does not prevent C# overflow. The legal domain and checked arithmetic are part of the executable contract.

<!--
Name the exact program point where this statement applies. Contrast initialization, one update, and the exit condition. Do not call a printed success message a proof. Use the verification slide later to distinguish a check on a few examples from the general argument.
-->

---

## Run the small model

```csharp
using System;
static long Fact(int n) {
    if (n < 0 || n > 20) throw new ArgumentOutOfRangeException(nameof(n));
    return n == 0 ? 1 : checked(n * Fact(n - 1));
}
Console.WriteLine(Fact(3));
Console.WriteLine(Fact(0));
try { Fact(21); } catch (ArgumentOutOfRangeException) {
    Console.WriteLine("rejected");
}
```

```output
6
1
rejected
```

<!--
Before running, ask learners to predict the complete output. Run this standalone cell in a fresh C# application; it requires no previous cell. Zero is a valid base input, while 21 is rejected before an overflowing multiplication. The recursive structure alone does not establish a safe numeric domain. If the demo environment fails, read the verified output and continue with the trace rather than spending the meeting on tool setup.
-->

---

## Explain the observed result

Zero is a valid base input, while 21 is rejected before an overflowing multiplication. The recursive structure alone does not establish a safe numeric domain.

<!--
Ask learners to connect the output to the contract, not just read the numbers aloud. Mathematical progress does not prevent C# overflow. The legal domain and checked arithmetic are part of the executable contract. Invite one controlled input change and predict its effect first. The worked output is evidence for this instance; the invariant and assumptions explain the broader claim.
-->

---

<!-- _class: check -->

## Quick check 1

Does the presence of a base case prove termination?

1. Yes, whatever the recursive argument
2. No; every path must make well-founded progress
3. Only when the method prints output

<!--
Give 30 seconds individually, then compare with a neighbor. Answer: B. A recursive call can miss or move away from its base. State the measure and prove it decreases on every recursive path. Ask for the reason, not only the letter. If a common wrong choice dominates, replay the contract or trace before proceeding.
-->

---

## Boundaries are part of the model

- Empty maximum input needs rejection or another explicit contract.
- A binary-search empty interval ends the search.
- A divided nonempty range must preserve all positions without overlap.

<!--
Choose one boundary and ask for an independently expected result. Check zero/base, singleton, odd-size, and invalid cases. Distinguish a legal empty result from an invalid input. Do not silently change the contract to make a failing test disappear.
-->

---

<!-- _class: check -->

## Quick check 2

Why is a divide-and-conquer maximum different from binary search?

1. Maximum generally needs both child results
2. Maximum always uses only the left child
3. Binary search inspects every item

<!--
Poll for a prediction before revealing any explanation. Answer: A. Both parts may contain the maximum. Binary search uses ordering evidence to discard one part. Link the distinction to the business case. Use a brief counterexample when a learner treats an assumption as a universal guarantee.
-->

---

<!-- _class: yourturn -->

## Your turn: Exercise: Count Positive Adjustments

- Write a recursive count for a suffix.
- Exclude zero from positive values.
- State the helper postcondition and test empty input.

[Open the section practice](2201_recursion.html)

<!--
Allow three to five minutes in pairs. This practice is drawn from the section's actual exercise; it does not create a new assessment ID. Answer and debrief: The helper returns the positive count from start through Length. Empty suffix returns zero; each call advances start by one. Add one exactly when the current value is greater than zero, not greater than or equal. Ask learners to show their trace or checks before consulting the lesson solution. Assess reasoning as well as printed output.
-->

---

## Verify before recommending

- Check zero/base, singleton, odd-size, and invalid cases.
- Separate total calls from active depth.
- Choose a loop when sequential repetition is clearer or recursion risks stack exhaustion.

<!--
Ask learners to separate implementation checks, model assumptions, and performance claims. A. Both parts may contain the maximum. Binary search uses ordering evidence to discard one part. Relate the requested evidence to the chapter lab/homework without changing their stable identities or making supporting readings silently compulsory.
-->

---

<!-- _class: recap -->

## Recap

- Specify domain, base case, and progress
- Trace suspended work and returned results
- Keep recursive search intervals complete

[Continue with the lesson and exercises](2201_recursion.html)

<!--
Invite a learner to explain one goal using the worked case. Zero is a valid base input, while 21 is rejected before an overflowing multiplication. The recursive structure alone does not establish a safe numeric domain. Exit question: what input, representation, or contract change would require a new argument? Use the current assignment route and chapter schedule to select follow-up practice.
-->

---

<!-- _class: section -->

# 22.2. Stable Merge Sort and Verification

Computer Science in C#

<!--
This part addresses merge sorted runs with a tie policy, prove split coverage and preservation, count comparisons, copies, and storage separately. Read 2202_merge_sort_lab.html with the worked examples. Use the selected trace and nearby practice within the chapter's existing meeting allocation; this part is a reading unit, not an extra required meeting.
-->

---

## Goals for this part

- Merge sorted runs with a tie policy
- Prove split coverage and preservation
- Count comparisons, copies, and storage separately

<!--
Connect these goals to the chapter objectives before starting. The running case is: Two branches send sorted invoice runs. Equal amounts must keep arrival order when the report combines them. Ask learners to predict one result before execution. Revisit the same contract at the recap rather than introducing an unrelated API tour.
-->

---

## State the business question

Two branches send sorted invoice runs. Equal amounts must keep arrival order when the report combines them.

<!--
Ask which result the stakeholder actually needs. Both input runs use the same ordering. A faster program is useful only when it still answers that question. Ask students to name one input or policy that would change the answer, then introduce the contract.
-->

---

## Make the contract explicit

- Both input runs use the same ordering.
- Choose the left item on equal keys for stability.
- Copy every unconsumed item after one run is exhausted.

<!--
Explain each obligation in the running case. The output prefix contains exactly the smallest consumed occurrences in stable order. Sortedness alone cannot prove occurrence preservation. Separate what clients can rely on from representation details. Ask what a missing, empty, tied, or invalid input means before moving to the trace.
-->

---

## Trace one small instance

| Compare | Choice | Output so far |
| --- | --- | --- |
| A:2 versus C:2 | Left on tie | A |
| B:4 versus C:2 | Right | A,C |
| B:4 versus D:3 | Right | A,C,D |
| Right exhausted | Copy B | A,C,D,B |

<!--
Walk the rows in order and pause before revealing the next state on screen. A precedes C even though their keys tie. Once the right run is exhausted, copying B preserves the final occurrence without another key comparison. The table records a logical trace; distinguish any sorted presentation view from physical storage layout. Ask a learner to justify one transition using the stated contract.
-->

---

## Follow the mechanism

- Split a range into two covering, smaller child ranges.
- Sort each child, then merge their sorted results.
- Use one reusable buffer to avoid fresh full arrays at every merge.

<!--
Tie every step to a state change in the preceding trace. The output prefix contains exactly the smallest consumed occurrences in stable order. Sortedness alone cannot prove occurrence preservation. Ask which step would fail if omitted or moved. The complete implementation stays in the lesson so the slide can focus on the algorithm's own progress rather than long support classes.
-->

---

## Keep the invariant in view

The output prefix contains exactly the smallest consumed occurrences in stable order. Sortedness alone cannot prove occurrence preservation.

<!--
Name the exact program point where this statement applies. Contrast initialization, one update, and the exit condition. Do not call a printed success message a proof. Use the verification slide later to distinguish a check on a few examples from the general argument.
-->

---

## Run the small model

```csharp
using System; using System.Collections.Generic; using System.Linq;
var left = new[] { (Key: 2, Id: "A"), (Key: 4, Id: "B") };
var right = new[] { (Key: 2, Id: "C"), (Key: 3, Id: "D") };
var report = new List<(int Key, string Id)>(); int i = 0, j = 0;
while (i < left.Length && j < right.Length)
    report.Add(left[i].Key <= right[j].Key ? left[i++] : right[j++]);
while (i < left.Length) report.Add(left[i++]);
while (j < right.Length) report.Add(right[j++]);
Console.WriteLine(string.Join(",", report.Select(item => item.Id)));
```

```output
A,C,D,B
```

<!--
Before running, ask learners to predict the complete output. Run this standalone cell in a fresh C# application; it requires no previous cell. A precedes C even though their keys tie. Once the right run is exhausted, copying B preserves the final occurrence without another key comparison. If the demo environment fails, read the verified output and continue with the trace rather than spending the meeting on tool setup.
-->

---

## Explain the observed result

A precedes C even though their keys tie. Once the right run is exhausted, copying B preserves the final occurrence without another key comparison.

<!--
Ask learners to connect the output to the contract, not just read the numbers aloud. The output prefix contains exactly the smallest consumed occurrences in stable order. Sortedness alone cannot prove occurrence preservation. Invite one controlled input change and predict its effect first. The worked output is evidence for this instance; the invariant and assumptions explain the broader claim.
-->

---

<!-- _class: check -->

## Quick check 1

A merge has zero key comparisons. Can it still copy many items?

1. No
2. Yes, if one input run is empty
3. Only if the result is invalid

<!--
Give 30 seconds individually, then compare with a neighbor. Answer: B. Comparisons occur only while both runs have candidates. The remaining run still has to be copied. Ask for the reason, not only the letter. If a common wrong choice dominates, replay the contract or trace before proceeding.
-->

---

## Boundaries are part of the model

- Empty/empty produces empty output.
- Repeated keys require occurrence checks, not sets.
- A stable descending report reverses the comparer, not the tied record order.

<!--
Choose one boundary and ask for an independently expected result. Compare empty, singleton, reverse, and duplicate-heavy inputs. Distinguish a legal empty result from an invalid input. Do not silently change the contract to make a failing test disappear.
-->

---

<!-- _class: check -->

## Quick check 2

What auxiliary storage does range-buffer merge sort use?

1. Constant in every implementation
2. Linear buffer plus logarithmic active frames
3. Only the total number of comparisons

<!--
Poll for a prediction before revealing any explanation. Answer: B. Reusing the buffer prevents per-call full-array allocations, but the buffer itself still occupies linear space. Link the distinction to the business case. Use a brief counterexample when a learner treats an assumption as a universal guarantee.
-->

---

<!-- _class: yourturn -->

## Your turn: Practice: Stable Descending Reports

- Sort labeled invoices by descending amount.
- Preserve arrival order within ties.
- Test int.MinValue and int.MaxValue without subtraction.

[Open the section practice](2202_merge_sort_lab.html)

<!--
Allow three to five minutes in pairs. This practice is drawn from the section's actual exercise; it does not create a new assessment ID. Answer and debrief: Reverse comparer operands to get descending order, rather than subtracting keys or reversing the finished stable result. Continue choosing the left item on equality so tied arrival labels stay ordered. Ask learners to show their trace or checks before consulting the lesson solution. Assess reasoning as well as printed output.
-->

---

## Verify before recommending

- Compare empty, singleton, reverse, and duplicate-heavy inputs.
- Count actual comparisons and writes under a declared convention.
- Relate balanced linear-per-level work to n log n; include buffer and stack costs.

<!--
Ask learners to separate implementation checks, model assumptions, and performance claims. B. Reusing the buffer prevents per-call full-array allocations, but the buffer itself still occupies linear space. Relate the requested evidence to the chapter lab/homework without changing their stable identities or making supporting readings silently compulsory.
-->

---

<!-- _class: recap -->

## Recap

- Merge sorted runs with a tie policy
- Prove split coverage and preservation
- Count comparisons, copies, and storage separately

[Continue with the lesson and exercises](2202_merge_sort_lab.html)

<!--
Invite a learner to explain one goal using the worked case. A precedes C even though their keys tie. Once the right run is exhausted, copying B preserves the final occurrence without another key comparison. Exit question: what input, representation, or contract change would require a new argument? Use the current assignment route and chapter schedule to select follow-up practice.
-->
