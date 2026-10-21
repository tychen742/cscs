---
marp: true
theme: thinkpress-lecture
paginate: true
title: "Searching and Basic Sorting"
book: Computer Science in C#
section: "Chapter 16"
primary: "#2a6b37"
accent: "#b8860b"
---

<!-- _class: title -->

# Searching and Basic Sorting

Chapter 16 · Computer Science in C#

Business models, worked traces, and verified C# examples.

<!--
Part 16.1: Search Contracts and Repeated Queries, starts on slide 2.
Part 16.2: Sorting and Safe Reporting Workloads, starts on slide 17.
Part 16.3: Merge Sort for Reporting Workloads, starts on slide 32.
Core reading parts share the chapter's existing three-meeting allocation, totaling 110 minutes. They are not separate fifty-minute meetings. Optional/reference parts add no required meeting. Speaker-note answers belong to the instructor output; publish student HTML with those notes stripped.
-->

---

<!-- _class: section -->

# Search Contracts and Repeated Queries

Part 16.1 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 35 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. A ticket report is sorted under one ordering policy. A lookup may return any matching ticket position, while an arrival scan promises the first occurrence. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Specify first, any, or missing results.
- Maintain a shrinking half-open interval.
- Interpret library failure results before indexing.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. Sort and search must agree on ordering. Teaching methods return -1 for absence; Array.BinarySearch instead encodes an insertion position in a negative result. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

A ticket report is sorted under one ordering policy. A lookup may return any matching ticket position, while an arrival scan promises the first occurrence.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. A ticket report is sorted under one ordering policy. A lookup may return any matching ticket position, while an arrival scan promises the first occurrence. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

Binary search keeps candidates in [low, high). The high endpoint is excluded, and each unsuccessful comparison must remove the inspected middle.

<!--
Binary search keeps candidates in [low, high). The high endpoint is excluded, and each unsuccessful comparison must remove the inspected middle. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

Sort and search must agree on ordering. Teaching methods return -1 for absence; Array.BinarySearch instead encodes an insertion position in a negative result.

<!--
Sort and search must agree on ordering. Teaching methods return -1 for absence; Array.BinarySearch instead encodes an insertion position in a negative result. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 16.1

```csharp
using System;
int[] values = { 5, 9, 12, 20, 31, 44 };
Console.WriteLine(Find(values, 20)); Console.WriteLine(Find(values, 21));
static int Find(int[] a, int target) {
    int low = 0, high = a.Length;
    while (low < high) { int mid = low + (high - low) / 2;
        if (a[mid] == target) return mid;
        if (a[mid] < target) low = mid + 1; else high = mid; }
    return -1;
}
```

```output
3
-1
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is 3; -1. Connect each observation to the contract: Sort and search must agree on ordering. Teaching methods return -1 for absence; Array.BinarySearch instead encodes an insertion position in a negative result. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Search 21 in 5,9,12,20,31,44|[low, high)|Decision |
| --- | --- | --- |
| Start|[0,6)|middle 3 gives 20 |
| 21 greater than 20|[4,6)|middle 5 gives 44 |
| 21 smaller than 44|[4,5)|middle 4 gives 31 |
| 21 smaller than 31|[4,4)|Empty: missing |

<!--
Walk through the rows before executing another example. Search 21 in 5,9,12,20,31,44: [low, high): Decision. Start: [0,6): middle 3 gives 20. 21 greater than 20: [4,6): middle 5 gives 44. 21 smaller than 44: [4,5): middle 4 gives 31. 21 smaller than 31: [4,4): Empty: missing. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## The middle value is below target. Which update guarantees progress?

1. low = mid
2. low = mid + 1
3. high = mid + 1

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: B. The inspected middle cannot match, so remove it from the lower end. low = mid can leave a one-element interval unchanged. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Search contract|Duplicate result |
| --- | --- |
| First-match linear scan|Earliest matching arrival position |
| Any-match binary search|One matching sorted position |
| All matches|A collection or interval, not one arbitrary index |

<!--
Search contract: Duplicate result. First-match linear scan: Earliest matching arrival position. Any-match binary search: One matching sorted position. All matches: A collection or interval, not one arbitrary index. Sort and search must agree on ordering. Teaching methods return -1 for absence; Array.BinarySearch instead encodes an insertion position in a negative result. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

Using a negative library result as an index is invalid. Check its sign; decode the insertion position with bitwise complement only when the library contract requires it.

<!--
Using a negative library result as an index is invalid. Check its sign; decode the insertion position with bitwise complement only when the library contract requires it. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## Array.BinarySearch returns -2. Is the target found?

1. Yes, at index two
2. No; the insertion position is one
3. It always means index zero

<!--
Poll again after the contrasting case. Answer: B. A negative result signals absence. Complementing -2 gives one; do not confuse the encoded position with a found index. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

The sorted report contains duplicates. Must this binary search return the earliest duplicate?

<!--
Pause for a prediction before changing the input or model. Answer: No. This implementation stops at equality and promises any match. A first-match requirement needs a different boundary policy. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Complete Finish the Boundary Updates: use a half-open interval and test first, missing, ordinary, and empty cases.

[Open the lesson exercise](1601_searching.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: When comparison is negative, assign low = middle + 1; otherwise, after excluding equality, assign high = middle. Initialize high to Length, not Length minus one. Watch for this defect: Using a negative library result as an index is invalid. Check its sign; decode the insertion position with bitwise complement only when the library contract requires it.
-->

---

## Verify more than one example

Test empty, singleton, first/last, absent below/inside/above, and duplicates. Count probes separately from copying or sorting preparation.

<!--
Use independently predicted results. Test empty, singleton, first/last, absent below/inside/above, and duplicates. Count probes separately from copying or sorting preparation. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Specify first, any, or missing results.
- Maintain a shrinking half-open interval.
- Interpret library failure results before indexing.

<!--
Sort and search must agree on ordering. Teaching methods return -1 for absence; Array.BinarySearch instead encodes an insertion position in a negative result. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->

---

<!-- _class: section -->

# Sorting and Safe Reporting Workloads

Part 16.2 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 75 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. An invoice report needs sorted amounts without changing arrival order in the original data. Correctness requires order, occurrence preservation, and an explicit mutation policy. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Maintain a sorted prefix and preserve occurrences.
- Keep tied records in arrival order.
- Compare complete reporting workloads.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. Use strict greater-than shifting to preserve ties. Sorting a clone protects the original outer sequence; it does not deep-clone referenced objects. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

An invoice report needs sorted amounts without changing arrival order in the original data. Correctness requires order, occurrence preservation, and an explicit mutation policy.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. An invoice report needs sorted amounts without changing arrival order in the original data. Correctness requires order, occurrence preservation, and an explicit mutation policy. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

Insertion sort saves the next item, shifts strictly greater predecessors right, and installs the saved item in the gap.

<!--
Insertion sort saves the next item, shifts strictly greater predecessors right, and installs the saved item in the gap. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

Use strict greater-than shifting to preserve ties. Sorting a clone protects the original outer sequence; it does not deep-clone referenced objects.

<!--
Use strict greater-than shifting to preserve ties. Sorting a clone protects the original outer sequence; it does not deep-clone referenced objects. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 16.2

```csharp
using System;
int[] values = { 30, 10, 20 };
for (int i = 1; i < values.Length; i++) {
    int saved = values[i], j = i;
    while (j > 0 && values[j - 1] > saved) { values[j] = values[j - 1]; j--; }
    values[j] = saved;
}
Console.WriteLine(string.Join(",", values));
```

```output
10,20,30
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is 10,20,30. Connect each observation to the contract: Use strict greater-than shifting to preserve ties. Sorting a clone protects the original outer sequence; it does not deep-clone referenced objects. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Pass|Saved item|Sequence after insertion |
| --- | --- | --- |
| Start|None|30,10,20 |
| Insert index one|10|10,30,20 |
| Insert index two|20|10,20,30 |
| Finish|None|Same three occurrences |

<!--
Walk through the rows before executing another example. Pass: Saved item: Sequence after insertion. Start: None: 30,10,20. Insert index one: 10: 10,30,20. Insert index two: 20: 10,20,30. Finish: None: Same three occurrences. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## Why save the current item before shifting?

1. So a shift cannot overwrite the value still being inserted
2. To remove duplicates
3. To avoid comparing keys

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: A. The shifts overwrite array positions. Saving the item preserves it until its final position is known. Use the trace to distinguish the relevant alternatives.
-->

---

## Check the complete contract 16.2

```csharp
using System;
int[] original = { 30, 10, 20 }, arrivals = { 30, 10, 20 }, report = { 10, 20, 30 };
bool same = arrivals.Length == original.Length, ordered = true;
for (int i = 0; i < arrivals.Length; i++) same &= arrivals[i] == original[i];
for (int i = 1; i < report.Length; i++) ordered &= report[i - 1] <= report[i];
bool kept = report.Length == original.Length;
foreach (int value in original) { int before = 0, after = 0;
    foreach (int x in original) if (x == value) before++;
    foreach (int x in report) if (x == value) after++; kept &= before == after; }
Console.WriteLine(same && ordered && kept);
```

```output
True
```

<!--
Obligation: Independent evidence. Original preserved: Compare every original position. Report ordered: Check every adjacent pair. Occurrences preserved: Compare length and per-value counts. Stability: Label distinct records sharing one key. Use strict greater-than shifting to preserve ties. Sorting a clone protects the original outer sequence; it does not deep-clone referenced objects. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

Checking endpoints can certify a corrupt middle. A sorted-looking result can still lose or duplicate values, so order and preservation need separate checks.

<!--
Checking endpoints can certify a corrupt middle. A sorted-looking result can still lose or duplicate values, so order and preservation need separate checks. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## The report is 8,8,42 instead of 8,17,42. Which check exposes the loss?

1. Only its first and last values
2. Occurrence counts and length together
3. Only checking ascending order

<!--
Poll again after the contrasting case. Answer: B. Ascending order and endpoints both pass; the multiplicity of eight and seventeen changed. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

One sorted snapshot supports Q queries but U updates arrive. Which costs belong in the comparison?

<!--
Pause for a prediction before changing the input or model. Answer: Include copy/sort preparation, all query probes, and maintenance or rebuilding after updates. O(log n) per query alone is not the workload cost. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Complete Preserve the Saved Item, then use Lab Question 5's complete verification checks on a cloned report.

[Open the lesson exercise](1602_basic_sorting.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: After shifting, assign values[position] = current. Check every original position, each adjacent report pair, and every input value's occurrence count. A changed middle arrival, unsorted middle report, and sorted duplicate replacement must each be detected. Watch for this defect: Checking endpoints can certify a corrupt middle. A sorted-looking result can still lose or duplicate values, so order and preservation need separate checks.
-->

---

## Verify more than one example

Use empty, singleton, duplicates, all equal, sorted, and reverse inputs. Label ties for stability and count key comparisons independently of assignments.

<!--
Use independently predicted results. Use empty, singleton, duplicates, all equal, sorted, and reverse inputs. Label ties for stability and count key comparisons independently of assignments. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Maintain a sorted prefix and preserve occurrences.
- Keep tied records in arrival order.
- Compare complete reporting workloads.

<!--
Use strict greater-than shifting to preserve ties. Sorting a clone protects the original outer sequence; it does not deep-clone referenced objects. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->

---

<!-- _class: section -->

# Merge Sort for Reporting Workloads

Part 16.3 · Supporting / optional reference

Selected depth; no additional required meeting.

<!--
This is supporting material, not an extra required meeting or an automatic assessment prerequisite. Goal: Merge sort for the selected CS2 route. The instructor selects its depth according to course policy and available time. Two branch offices send sorted daily files. A merge repeatedly copies the smaller front item, then copies the unexhausted remainder.
-->

---

## Merge sort for the selected CS2 route

Two branch offices send sorted daily files. A merge repeatedly copies the smaller front item, then copies the unexhausted remainder.

Select Recursive Methods (5.6) before this supporting reading. Splitting, recursively sorting, and merging give about n log n work with additional storage. Equal keys come from the left run first for stability.

<!--
Two branch offices send sorted daily files. A merge repeatedly copies the smaller front item, then copies the unexhausted remainder. Select Recursive Methods (5.6) before this supporting reading. Splitting, recursively sorting, and merging give about n log n work with additional storage. Equal keys come from the left run first for stability. Connect this extension to the core contract rather than introducing it as a prerequisite for the standard lab.
-->

---

<!-- _class: check -->

## Two quick checks

A: Does one empty run imply an empty merge?

B: Why prefer the left item on equality?

<!--
Answers: A: No, copy the other run. B: Earlier arrival order lies in the left run, so choosing it first preserves ties. Ask students to justify each answer using the stated contract. These checks are optional review, not a change to existing assessment IDs.
-->

---

<!-- _class: yourturn -->

## Your turn: selected practice

Complete Merge Two Daily Files and check both remainder-copy loops.

[Open the supporting reading](1603_merge_sort.html)

<!--
Use the existing exercise only if this supporting reading was selected. Answer: Expected merged values are 1, 2, 5, 5, 7, 9 and 3, 4, 8. A missing remainder loop loses values or leaves default zeros even if length is correct. Retain the original exercise identity and do not require unsupported syntax in a core assignment.
-->

---

<!-- _class: recap -->

## Reference recap

- Select Recursive Methods (5.6) before this supporting reading. Splitting, recursively sorting, and merging give about n log n work with additional storage. Equal keys come from the left run first for stability.
- Return to the core sequence when this reference question is resolved.

<!--
Expected merged values are 1, 2, 5, 5, 7, 9 and 3, 4, 8. A missing remainder loop loses values or leaves default zeros even if length is correct. The core chapter remains complete without an extra meeting. Keep these notes available for students taking the recommended extension route.
-->
