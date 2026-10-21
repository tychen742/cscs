---
marp: true
theme: thinkpress-lecture
paginate: true
title: "Chapter 23: Advanced Searching and Sorting"
book: "Computer Science in C#"
section: "Chapter 23"
primary: "#2a6b37"
accent: "#b8860b"
---

<!-- _class: title -->

# 23. Advanced Searching and Sorting

Computer Science in C#

Contracts, worked traces, practice, and verified examples.

<!--
Chapter 23: Advanced Searching and Sorting.
Existing 110-minute chapter allocation: 40 minutes search boundaries;40 minutes sort invariants;30 minutes workload comparison. Supporting parts are selected separately.
Part 23.1: Duplicate-Aware Search Contracts, starting slide 2.
Part 23.2: Elementary Sort Invariants, starting slide 17.
Part 23.3: Comparing Complete Search and Sort Workloads, starting slide 32.
Part 23.4: Shell Sort and Gap Families, starting slide 47.
Part 23.5: Quicksort and Partitioning, starting slide 57.
Each core part is a reading unit; follow the current three-meeting allocation rather than add one meeting per part. Supporting parts are explicitly optional. Quick-check and Your turn answers remain in these instructor notes; the student HTML omits them. All complete C# examples are standalone and recorded in the code verification manifest.
-->

---

<!-- _class: section -->

# 23.1. Duplicate-Aware Search Contracts

Computer Science in C#

<!--
This part addresses specify first, any, and all-match results, trace half-open lower and upper bounds, make ordering and equality compatible. Read 2301_searching.html with the worked examples. Use the selected trace and nearby practice within the chapter's existing meeting allocation; this part is a reading unit, not an extra required meeting.
-->

---

## Goals for this part

- Specify first, any, and all-match results
- Trace half-open lower and upper bounds
- Make ordering and equality compatible

<!--
Connect these goals to the chapter objectives before starting. The running case is: A supplier report contains several equal totals. Any-match search cannot identify the whole group by itself. Ask learners to predict one result before execution. Revisit the same contract at the recap rather than introducing an unrelated API tour.
-->

---

## State the business question

A supplier report contains several equal totals. Any-match search cannot identify the whole group by itself.

<!--
Ask which result the stakeholder actually needs. Lower bound is the first key at least the target. A faster program is useful only when it still answers that question. Ask students to name one input or policy that would change the answer, then introduce the contract.
-->

---

## Make the contract explicit

- Lower bound is the first key at least the target.
- Upper bound is the first key greater than the target.
- The matching group occupies [lower,upper).

<!--
Explain each obligation in the running case. The interval always shrinks. Returning Length is a valid boundary result, but it is not a valid element index. Separate what clients can rely on from representation details. Ask what a missing, empty, tied, or invalid input means before moving to the trace.
-->

---

## Trace one small instance

| Sorted keys [1,2,2,4] | Lower | Upper |
| --- | ---: | ---: |
| Target 2 | 1 | 3 |
| Target 3 | 3 | 3 |
| Target 9 | 4 | 4 |

<!--
Walk the rows in order and pause before revealing the next state on screen. Target two occupies [1,3). In the table, target three has equal insertion boundaries but no occurrences; a zero-length matching interval represents absence without inventing an array element. The table records a logical trace; distinguish any sorted presentation view from physical storage layout. Ask a learner to justify one transition using the stated contract.
-->

---

## Follow the mechanism

- Maintain candidates in [low,high).
- Move low past a proved excluded midpoint.
- Keep high at midpoint when that position may be the first boundary.

<!--
Tie every step to a state change in the preceding trace. The interval always shrinks. Returning Length is a valid boundary result, but it is not a valid element index. Ask which step would fail if omitted or moved. The complete implementation stays in the lesson so the slide can focus on the algorithm's own progress rather than long support classes.
-->

---

## Keep the invariant in view

The interval always shrinks. Returning Length is a valid boundary result, but it is not a valid element index.

<!--
Name the exact program point where this statement applies. Contrast initialization, one update, and the exit condition. Do not call a printed success message a proof. Use the verification slide later to distinguish a check on a few examples from the general argument.
-->

---

## Run the small model

```csharp
using System;
int[] a = { 1, 2, 2, 4 };
int Bound(bool upper) { int low = 0, high = a.Length;
    while (low < high) {
        int mid = low + (high - low) / 2;
        if (a[mid] < 2 || (upper && a[mid] == 2)) low = mid + 1;
        else high = mid;
    } return low;
}
Console.WriteLine($"{Bound(false)},{Bound(true)}");
```

```output
1,3
```

<!--
Before running, ask learners to predict the complete output. Run this standalone cell in a fresh C# application; it requires no previous cell. Target two occupies [1,3). In the table, target three has equal insertion boundaries but no occurrences; a zero-length matching interval represents absence without inventing an array element. If the demo environment fails, read the verified output and continue with the trace rather than spending the meeting on tool setup.
-->

---

## Explain the observed result

Target two occupies [1,3). In the table, target three has equal insertion boundaries but no occurrences; a zero-length matching interval represents absence without inventing an array element.

<!--
Ask learners to connect the output to the contract, not just read the numbers aloud. The interval always shrinks. Returning Length is a valid boundary result, but it is not a valid element index. Invite one controlled input change and predict its effect first. The worked output is evidence for this instance; the invariant and assumptions explain the broader claim.
-->

---

<!-- _class: check -->

## Quick check 1

What does [lower,upper) contain when the target is absent?

1. One arbitrary neighbor
2. No elements because lower equals upper
3. Every larger element

<!--
Give 30 seconds individually, then compare with a neighbor. Answer: B. Boundary positions still exist even when no key matches. Never index at Length without a separate range check. Ask for the reason, not only the letter. If a common wrong choice dominates, replay the contract or trace before proceeding.
-->

---

## Boundaries are part of the model

- Empty input returns both boundaries zero.
- Below-range and above-range targets test endpoint logic.
- Case-sensitive and case-insensitive policies can produce different groups.

<!--
Choose one boundary and ask for an independently expected result. Use a scan with the identical equality policy as the oracle. Distinguish a legal empty result from an invalid input. Do not silently change the contract to make a failing test disappear.
-->

---

<!-- _class: check -->

## Quick check 2

Does a negative Array.BinarySearch result mean exactly minus one?

1. Yes
2. No; it encodes an insertion position
3. Only for string arrays

<!--
Poll for a prediction before revealing any explanation. Answer: B. Decode the complement under the library contract. A custom first-match scan may separately use minus one as its sentinel. Link the distinction to the business case. Use a brief counterexample when a learner treats an assumption as a universal guarantee.
-->

---

<!-- _class: yourturn -->

## Your turn: Exercise: Complete the Upper Bound

- Trace low/high/mid for a duplicate-heavy array.
- Change the equality branch for upper bound.
- Check the interval against a separate scan.

[Open the section practice](2301_searching.html)

<!--
Allow three to five minutes in pairs. This practice is drawn from the section's actual exercise; it does not create a new assessment ID. Answer and debrief: Upper bound excludes equal midpoints by advancing low. Lower bound keeps an equal midpoint as a candidate by reducing high. Reference counts of less-than and less-than-or-equal items verify both positions. Ask learners to show their trace or checks before consulting the lesson solution. Assess reasoning as well as printed output.
-->

---

## Verify before recommending

- Use a scan with the identical equality policy as the oracle.
- Include absent interior keys and tied groups.
- Count returned group output in addition to logarithmic boundary work.

<!--
Ask learners to separate implementation checks, model assumptions, and performance claims. B. Decode the complement under the library contract. A custom first-match scan may separately use minus one as its sentinel. Relate the requested evidence to the chapter lab/homework without changing their stable identities or making supporting readings silently compulsory.
-->

---

<!-- _class: recap -->

## Recap

- Specify first, any, and all-match results
- Trace half-open lower and upper bounds
- Make ordering and equality compatible

[Continue with the lesson and exercises](2301_searching.html)

<!--
Invite a learner to explain one goal using the worked case. Target two occupies [1,3). In the table, target three has equal insertion boundaries but no occurrences; a zero-length matching interval represents absence without inventing an array element. Exit question: what input, representation, or contract change would require a new argument? Use the current assignment route and chapter schedule to select follow-up practice.
-->

---

<!-- _class: section -->

# 23.2. Elementary Sort Invariants

Computer Science in C#

<!--
This part addresses explain selection, insertion, and bubble progress, relate strict inversions to insertion shifts, test stability and every retained occurrence. Read 2302_sorting.html with the worked examples. Use the selected trace and nearby practice within the chapter's existing meeting allocation; this part is a reading unit, not an extra required meeting.
-->

---

## Goals for this part

- Explain selection, insertion, and bubble progress
- Relate strict inversions to insertion shifts
- Test stability and every retained occurrence

<!--
Connect these goals to the chapter objectives before starting. The running case is: A nightly invoice report may already be nearly ordered. Compare what each elementary sort actually does instead of labeling them all identically slow. Ask learners to predict one result before execution. Revisit the same contract at the recap rather than introducing an unrelated API tour.
-->

---

## State the business question

A nightly invoice report may already be nearly ordered. Compare what each elementary sort actually does instead of labeling them all identically slow.

<!--
Ask which result the stakeholder actually needs. Selection fixes the next smallest prefix position. A faster program is useful only when it still answers that question. Ask students to name one input or policy that would change the answer, then introduce the contract.
-->

---

## Make the contract explicit

- Selection fixes the next smallest prefix position.
- Insertion shifts strictly greater predecessors.
- Optimized bubble settles a suffix and stops on a no-swap pass.

<!--
Explain each obligation in the running case. Every sorting step preserves the occurrence multiset. The ordered prefix or settled suffix grows under the algorithm's own invariant. Separate what clients can rely on from representation details. Ask what a missing, empty, tied, or invalid input means before moving to the trace.
-->

---

## Trace one small instance

| Insert next value in [3,1,2,1] | Sorted prefix | Added shifts |
| --- | --- | ---: |
| First 1 | [1,3] | 1 |
| 2 | [1,2,3] | 1 |
| Last 1 | [1,1,2,3] | 2 |

<!--
Walk the rows in order and pause before revealing the next state on screen. The original arrival array is unchanged. Four shifts correspond to four strict inversions in the original sequence. The table records a logical trace; distinguish any sorted presentation view from physical storage layout. Ask a learner to justify one transition using the stated contract.
-->

---

## Follow the mechanism

- Save the item before shifting its predecessors.
- Use strict greater-than to preserve equal-key arrival order.
- Clone the input before mutating a report copy.

<!--
Tie every step to a state change in the preceding trace. Every sorting step preserves the occurrence multiset. The ordered prefix or settled suffix grows under the algorithm's own invariant. Ask which step would fail if omitted or moved. The complete implementation stays in the lesson so the slide can focus on the algorithm's own progress rather than long support classes.
-->

---

## Keep the invariant in view

Every sorting step preserves the occurrence multiset. The ordered prefix or settled suffix grows under the algorithm's own invariant.

<!--
Name the exact program point where this statement applies. Contrast initialization, one update, and the exit condition. Do not call a printed success message a proof. Use the verification slide later to distinguish a check on a few examples from the general argument.
-->

---

## Run the small model

```csharp
using System;
int[] arrival = { 3, 1, 2, 1 }; int[] a = (int[])arrival.Clone(); int shifts = 0;
for (int i = 1; i < a.Length; i++) {
    int saved = a[i], j = i;
    while (j > 0 && a[j - 1] > saved) { a[j] = a[j - 1]; j--; shifts++; }
    a[j] = saved;
}
Console.WriteLine(string.Join(",", a));
Console.WriteLine(string.Join(",", arrival));
Console.WriteLine(shifts);
```

```output
1,1,2,3
3,1,2,1
4
```

<!--
Before running, ask learners to predict the complete output. Run this standalone cell in a fresh C# application; it requires no previous cell. The original arrival array is unchanged. Four shifts correspond to four strict inversions in the original sequence. If the demo environment fails, read the verified output and continue with the trace rather than spending the meeting on tool setup.
-->

---

## Explain the observed result

The original arrival array is unchanged. Four shifts correspond to four strict inversions in the original sequence.

<!--
Ask learners to connect the output to the contract, not just read the numbers aloud. Every sorting step preserves the occurrence multiset. The ordered prefix or settled suffix grows under the algorithm's own invariant. Invite one controlled input change and predict its effect first. The worked output is evidence for this instance; the invariant and assumptions explain the broader claim.
-->

---

<!-- _class: check -->

## Quick check 1

What happens if insertion shifts predecessors greater than or equal to the saved item?

1. It can reverse equal-key arrival order
2. It becomes a binary search
3. It proves stable selection sort

<!--
Give 30 seconds individually, then compare with a neighbor. Answer: A. Equal elements should not be shifted past one another under the stable insertion contract. Ask for the reason, not only the letter. If a common wrong choice dominates, replay the contract or trace before proceeding.
-->

---

## Boundaries are part of the model

- Empty and singleton inputs need no repair.
- Selection still compares all remaining candidates on sorted data.
- A no-swap bubble pass allows early exit.

<!--
Choose one boundary and ask for an independently expected result. Check full sorted permutations, not sets alone. Distinguish a legal empty result from an invalid input. Do not silently change the contract to make a failing test disappear.
-->

---

<!-- _class: check -->

## Quick check 2

How many key comparisons does ordinary selection sort make on n items?

1. n-1 for every input
2. n(n-1)/2
3. Exactly the inversion count

<!--
Poll for a prediction before revealing any explanation. Answer: B. Each pass scans all remaining candidates regardless of initial order. Actual swaps may be fewer and should be counted separately. Link the distinction to the business case. Use a brief counterexample when a learner treats an assumption as a universal guarantee.
-->

---

<!-- _class: yourturn -->

## Your turn: Exercise: Shifts and Inversions

- Run insertion sort on sorted and reversed length-four arrays.
- Print key comparisons and shifts separately.
- Relate shifts to strict inversions.

[Open the section practice](2302_sorting.html)

<!--
Allow three to five minutes in pairs. This practice is drawn from the section's actual exercise; it does not create a new assessment ID. Answer and debrief: A sorted four-item input has zero shifts. A reversed distinct four-item input has six strict inversions and six shifts. Comparison counts depend on whether failed key tests are counted; state the convention consistently. Ask learners to show their trace or checks before consulting the lesson solution. Assess reasoning as well as printed output.
-->

---

## Verify before recommending

- Check full sorted permutations, not sets alone.
- Run sorted, reverse, and duplicate-heavy inputs.
- Count comparisons, swaps, and shifts as separate operations.

<!--
Ask learners to separate implementation checks, model assumptions, and performance claims. B. Each pass scans all remaining candidates regardless of initial order. Actual swaps may be fewer and should be counted separately. Relate the requested evidence to the chapter lab/homework without changing their stable identities or making supporting readings silently compulsory.
-->

---

<!-- _class: recap -->

## Recap

- Explain selection, insertion, and bubble progress
- Relate strict inversions to insertion shifts
- Test stability and every retained occurrence

[Continue with the lesson and exercises](2302_sorting.html)

<!--
Invite a learner to explain one goal using the worked case. The original arrival array is unchanged. Four shifts correspond to four strict inversions in the original sequence. Exit question: what input, representation, or contract change would require a new argument? Use the current assignment route and chapter schedule to select follow-up practice.
-->

---

<!-- _class: section -->

# 23.3. Comparing Complete Search and Sort Workloads

Computer Science in C#

<!--
This part addresses compare identical result contracts, include preparation, queries, updates, and storage, keep measured counts separate from lower-bound proofs. Read 2303_comparison_lab.html with the worked examples. Use the selected trace and nearby practice within the chapter's existing meeting allocation; this part is a reading unit, not an extra required meeting.
-->

---

## Goals for this part

- Compare identical result contracts
- Include preparation, queries, updates, and storage
- Keep measured counts separate from lower-bound proofs

<!--
Connect these goals to the chapter objectives before starting. The running case is: An analyst compares repeated scans with sorting once and binary-searching each query. The recommendation changes when query frequency changes. Ask learners to predict one result before execution. Revisit the same contract at the recap rather than introducing an unrelated API tour.
-->

---

## State the business question

An analyst compares repeated scans with sorting once and binary-searching each query. The recommendation changes when query frequency changes.

<!--
Ask which result the stakeholder actually needs. Both methods must answer the same membership question. A faster program is useful only when it still answers that question. Ask students to name one input or policy that would change the answer, then introduce the contract.
-->

---

## Make the contract explicit

- Both methods must answer the same membership question.
- Preparation is paid before sorted queries.
- A data update may invalidate a sorted snapshot.

<!--
Explain each obligation in the running case. The small arithmetic model illustrates a decision under stated counts. It is not a universal item-count threshold or elapsed-time measurement. Separate what clients can rely on from representation details. Ask what a missing, empty, tied, or invalid input means before moving to the trace.
-->

---

## Trace one small instance

| Illustrative counted model | One query | Twenty queries |
| --- | ---: | ---: |
| Scan: 8 per query | 8 | 160 |
| Prepare 28 + query 3 each | 31 | 88 |
| Meaning | Scan cheaper here | Preparation amortized here |

<!--
Walk the rows in order and pause before revealing the next state on screen. Twenty queries justify preparation in this model, while one query does not. Changing update frequency or actual input shape can change the recommendation. The table records a logical trace; distinguish any sorted presentation view from physical storage layout. Ask a learner to justify one transition using the stated contract.
-->

---

## Follow the mechanism

- Check every answer before comparing work.
- Separate preparation and query counters.
- Describe input order, updates, storage, and output requirements.

<!--
Tie every step to a state change in the preceding trace. The small arithmetic model illustrates a decision under stated counts. It is not a universal item-count threshold or elapsed-time measurement. Ask which step would fail if omitted or moved. The complete implementation stays in the lesson so the slide can focus on the algorithm's own progress rather than long support classes.
-->

---

## Keep the invariant in view

The small arithmetic model illustrates a decision under stated counts. It is not a universal item-count threshold or elapsed-time measurement.

<!--
Name the exact program point where this statement applies. Contrast initialization, one update, and the exit condition. Do not call a printed success message a proof. Use the verification slide later to distinguish a check on a few examples from the general argument.
-->

---

## Run the small model

```csharp
using System;
int preparation = 28, scanPerQuery = 8, binaryPerQuery = 3;
foreach (int queries in new[] { 1, 20 }) {
    int scan = queries * scanPerQuery;
    int prepared = preparation + queries * binaryPerQuery;
    Console.WriteLine($"{queries}: scan={scan}, prepared={prepared}");
}
```

```output
1: scan=8, prepared=31
20: scan=160, prepared=88
```

<!--
Before running, ask learners to predict the complete output. Run this standalone cell in a fresh C# application; it requires no previous cell. Twenty queries justify preparation in this model, while one query does not. Changing update frequency or actual input shape can change the recommendation. If the demo environment fails, read the verified output and continue with the trace rather than spending the meeting on tool setup.
-->

---

## Explain the observed result

Twenty queries justify preparation in this model, while one query does not. Changing update frequency or actual input shape can change the recommendation.

<!--
Ask learners to connect the output to the contract, not just read the numbers aloud. The small arithmetic model illustrates a decision under stated counts. It is not a universal item-count threshold or elapsed-time measurement. Invite one controlled input change and predict its effect first. The worked output is evidence for this instance; the invariant and assumptions explain the broader claim.
-->

---

<!-- _class: check -->

## Quick check 1

Can a first-match scan be compared directly with an any-match search when first arrival matters?

1. Yes, because both return an index
2. No; their result guarantees differ
3. Only if the timer reports equal times

<!--
Give 30 seconds individually, then compare with a neighbor. Answer: B. A faster answer to a weaker question does not meet the requested contract. Preserve invoice identity and original arrival policy. Ask for the reason, not only the letter. If a common wrong choice dominates, replay the contract or trace before proceeding.
-->

---

## Boundaries are part of the model

- Include missing targets, not only successful lookups.
- A stable report may need a copied array.
- Timing repeated delegates includes call overhead and machine effects.

<!--
Choose one boundary and ask for an independently expected result. Consume and verify search results before timing. Distinguish a legal empty result from an invalid input. Do not silently change the contract to make a failing test disappear.
-->

---

<!-- _class: check -->

## Quick check 2

What does a comparison-sorting lower bound concern?

1. One slow observed execution
2. All algorithms in the stated comparison model
3. Every program using integers

<!--
Poll for a prediction before revealing any explanation. Answer: B. The proof counts distinguishable orderings under a model. Non-comparison algorithms or additional key assumptions require separate reasoning. Link the distinction to the business case. Use a brief counterexample when a learner treats an assumption as a universal guarantee.
-->

---

<!-- _class: yourturn -->

## Your turn: Exercise: Check Selection Counts

- Check sizes zero through six.
- Compare sorted and reversed inputs.
- Verify n(n-1)/2 without confusing counts with timings.

[Open the section practice](2303_comparison_lab.html)

<!--
Allow three to five minutes in pairs. This practice is drawn from the section's actual exercise; it does not create a new assessment ID. Answer and debrief: The expected counts are 0,0,1,3,6,10,15. Ordinary selection scans the remaining suffix even when input is already sorted, so sorted and reversed arrays have the same key-comparison count. Ask learners to show their trace or checks before consulting the lesson solution. Assess reasoning as well as printed output.
-->

---

## Verify before recommending

- Consume and verify search results before timing.
- Keep raw durations, units, sizes, and seeds in optional experiments.
- Include construction and updates in a production recommendation.

<!--
Ask learners to separate implementation checks, model assumptions, and performance claims. B. The proof counts distinguishable orderings under a model. Non-comparison algorithms or additional key assumptions require separate reasoning. Relate the requested evidence to the chapter lab/homework without changing their stable identities or making supporting readings silently compulsory.
-->

---

<!-- _class: recap -->

## Recap

- Compare identical result contracts
- Include preparation, queries, updates, and storage
- Keep measured counts separate from lower-bound proofs

[Continue with the lesson and exercises](2303_comparison_lab.html)

<!--
Invite a learner to explain one goal using the worked case. Twenty queries justify preparation in this model, while one query does not. Changing update frequency or actual input shape can change the recommendation. Exit question: what input, representation, or contract change would require a new argument? Use the current assignment route and chapter schedule to select follow-up practice.
-->

---

<!-- _class: section -->

# 23.4. Shell Sort and Gap Families

Supporting reading: selected depth, not an extra required meeting.

<!--
This optional part complements the core contract/invariant/workload sequence. Select when gap-based and non-comparison alternatives fit course goals. Keep the standard assessments unchanged.
-->

---

## Goals for the supporting reading

- Trace the algorithm's own progress.
- Preserve all input occurrences.
- Qualify cost and memory claims.

<!--
Explain how this algorithm differs from elementary sorting before asking students to run it. A gap pass insertion-sorts interleaved subsequences. The final gap must be one; different gaps change work, not the required sorted-permutation contract. The complete standalone implementation is in the linked lesson.
-->

---

## The algorithmic idea

A gap pass insertion-sorts interleaved subsequences. The final gap must be one; different gaps change work, not the required sorted-permutation contract.

<!--
Use the small instance next rather than presenting a long recursive implementation at classroom font sizes. Contrast this mechanism with insertion sort and merge sort already taught.
-->

---

## Work the transformation

| Gap on [8,5,3,7,6,2] | Interleaved positions |
| --- | --- |
| 3 | (0,3), (1,4), (2,5) |
| After gap 3 | [7,5,2,8,6,3] |
| Final gap 1 | [2,3,5,6,7,8] |

<!--
Ask students to predict each intermediate state. Gap three swaps 8 with 7 and 3 with 2, giving [7,5,2,8,6,3]. Gap one completes ordinary insertion sorting. Counts depend on actual inputs and gaps. Distinguish local progress from the final postcondition.
-->

---

<!-- _class: check -->

## Quick check 1

Why must a sorting gap sequence end with one?

1. To establish complete neighboring order
2. To remove all duplicates
3. To make every gap prime

<!--
Answer: A. Earlier passes order only interleaved subsequences; they do not by themselves establish global order. Ask for a concrete boundary or duplicate counterexample, then reconnect to the progress measure.
-->

---

## Keep the experiment fair

- Use a fresh identical input for each algorithm.
- Check order and every occurrence before counting.
- Include nearly sorted, reversed, and tied inputs.

<!--
Sorting a mutated input twice can make the second algorithm appear better. Correctness and result identity are preconditions for a comparison. Use the lesson's complete code and preserved labels when stability matters.
-->

---

<!-- _class: check -->

## Quick check 2

Does one fast trial prove a gap family always best?

1. Yes
2. No; input shape and counting policy matter
3. Only with a larger stopwatch

<!--
Answer: B. Compare identical copies, correctness, several input shapes, and the same counted operations. Connect the response to the explicit algorithm and workload assumptions.
-->

---

<!-- _class: yourturn -->

## Your turn

Trace the gap-three pairs, then a gap-one insertion pass. Compare the retained 2h+1 and 3h+1 gap families in the lesson.

[Open the supporting reading](2304_advanced_sorts.html)

<!--
Allow a short trace first, then use the complete lesson program for execution. Answer: Gap three swaps 8 with 7 and 3 with 2, giving [7,5,2,8,6,3]. Gap one completes ordinary insertion sorting. Counts depend on actual inputs and gaps. This is supporting practice; any selected course assessment must retain its existing identity and declared scope.
-->

---

## What would change the recommendation?

- Different input shapes or key representations.
- Required stability or memory limits.
- Preparation, updates, and repeated queries.

<!--
For quicksort, discuss pivot choice, worst-case recursion, and smaller-side recursion as taught in the lesson. For Shell sort, discuss gap-family dependence; the additional bin/radix material requires suitable key assumptions. Timing belongs to the separately labeled optional empirical lab.
-->

---

<!-- _class: recap -->

## Supporting-reading recap

A gap pass insertion-sorts interleaved subsequences. The final gap must be one; different gaps change work, not the required sorted-permutation contract.

[Return to the complete-workload comparison](2303_comparison_lab.html)

<!--
Ask learners to compare this algorithm's progress argument with the core elementary sorts. The point is a justified representation/algorithm choice, not extending the required chapter into another week.
-->

---

<!-- _class: section -->

# 23.5. Quicksort and Partitioning

Supporting reading: selected depth, not an extra required meeting.

<!--
This optional part complements the core contract/invariant/workload sequence. Recommended for an algorithms route alongside Chapter 22 merge sort. Keep the standard assessments unchanged.
-->

---

## Goals for the supporting reading

- Trace the algorithm's own progress.
- Preserve all input occurrences.
- Qualify cost and memory claims.

<!--
Explain how this algorithm differs from elementary sorting before asking students to run it. Two scans seek values on the wrong side of a chosen pivot. Partition establishes a boundary, then recursive calls process strictly smaller ranges. Equal-pivot values still need progress. The complete standalone implementation is in the linked lesson.
-->

---

## The algorithmic idea

Two scans seek values on the wrong side of a chosen pivot. Partition establishes a boundary, then recursive calls process strictly smaller ranges. Equal-pivot values still need progress.

<!--
Use the small instance next rather than presenting a long recursive implementation at classroom font sizes. Contrast this mechanism with insertion sort and merge sort already taught.
-->

---

## Work the transformation

| Values [3,1,4,2], pivot 3 | State |
| --- | --- |
| Left stops at 4; right at 2 | Swap those misplaced values |
| After swap | [3,1,2,4] |
| Scans cross; place pivot | [2,1,3,4] |
| Recursive subranges | [2,1] and [4] |

<!--
Ask students to predict each intermediate state. Advance the scans under the stated equality policy, preserve the pivot value, and recurse only on the resulting smaller intervals. Verify the full sorted permutation; a boundary alone is not a complete sort. Distinguish local progress from the final postcondition.
-->

---

<!-- _class: check -->

## Quick check 1

What must move after swapping equal-pivot values?

1. The scans must still make progress
2. Only the printed label
3. The pivot must be discarded

<!--
Answer: A. A partition that repeats unchanged scan positions can fail to terminate on duplicates. Ask for a concrete boundary or duplicate counterexample, then reconnect to the progress measure.
-->

---

## Keep the experiment fair

- Use a fresh identical input for each algorithm.
- Check order and every occurrence before counting.
- Include nearly sorted, reversed, and tied inputs.

<!--
Sorting a mutated input twice can make the second algorithm appear better. Correctness and result identity are preconditions for a comparison. Use the lesson's complete code and preserved labels when stability matters.
-->

---

<!-- _class: check -->

## Quick check 2

What does a partition guarantee?

1. The whole array is fully sorted
2. The pivot boundary separates the requested ordering regions
3. Every partition is balanced

<!--
Answer: B. The subranges still need sorting. Poor pivot balance can produce quadratic time and deep recursion. Connect the response to the explicit algorithm and workload assumptions.
-->

---

<!-- _class: yourturn -->

## Your turn

Use the section partition trace and repair the incomplete two-scan partition. Test duplicates and a small interior subrange before running the complete sort.

[Open the supporting reading](2305_quicksort.html)

<!--
Allow a short trace first, then use the complete lesson program for execution. Answer: Advance the scans under the stated equality policy, preserve the pivot value, and recurse only on the resulting smaller intervals. Verify the full sorted permutation; a boundary alone is not a complete sort. This is supporting practice; any selected course assessment must retain its existing identity and declared scope.
-->

---

## What would change the recommendation?

- Different input shapes or key representations.
- Required stability or memory limits.
- Preparation, updates, and repeated queries.

<!--
For quicksort, discuss pivot choice, worst-case recursion, and smaller-side recursion as taught in the lesson. For Shell sort, discuss gap-family dependence; the additional bin/radix material requires suitable key assumptions. Timing belongs to the separately labeled optional empirical lab.
-->

---

<!-- _class: recap -->

## Supporting-reading recap

Two scans seek values on the wrong side of a chosen pivot. Partition establishes a boundary, then recursive calls process strictly smaller ranges. Equal-pivot values still need progress.

[Return to the complete-workload comparison](2303_comparison_lab.html)

<!--
Ask learners to compare this algorithm's progress argument with the core elementary sorts. The point is a justified representation/algorithm choice, not extending the required chapter into another week.
-->
