---
marp: true
theme: thinkpress-lecture
paginate: true
title: "Arrays"
book: "Computer Science in C#"
section: "Chapter 7"
primary: "#2a6b37"
accent: "#b8860b"
---

<!-- _class: title -->

# Arrays

Chapter 7 · Computer Science in C#

<!--
Part map (1-based slide numbers): 7.1 Creating and Accessing Arrays: slide 2; 7.2 Processing and Sharing Arrays: slide 18; 7.3 Searching and Sorting Arrays: slide 34; 7.4 Rectangular Arrays and Table Summaries: slide 52. Meeting 1: 7.1 and traversal/aliases in 7.2, 35 minutes; meeting 2: searches and one insertion-sort pass in 7.3, 40 minutes; meeting 3: 7.4 and parameter behavior in 7.2, 35 minutes. Total 110 minutes. Use selected examples and checks inside the existing allocation. Additional source detail remains preparation/reference reading. Every example is standalone; instructor answers remain in notes.
-->

---

<!-- _class: section -->

## Creating and Accessing Arrays

7.1 · [7.1 reading](0701_onedim.html)

Read, predict, trace, then apply.

<!--
Meeting 1: 7.1 and traversal/aliases in 7.2, 35 minutes; meeting 2: searches and one insertion-sort pass in 7.3, 40 minutes; meeting 3: 7.4 and parameter behavior in 7.2, 35 minutes. Total 110 minutes. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. A desk keeps four daily delivery quantities. One array gives the related values a single name while preserving each day’s position.
-->

---

## Goals and preparation

- Create and initialize a fixed-size array
- Use zero-based indexes and Length safely
- Trace element updates and empty-array behavior

[7.1 reading](0701_onedim.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: 7.1 and traversal/aliases in 7.2, 35 minutes; meeting 2: searches and one insertion-sort pass in 7.3, 40 minutes; meeting 3: 7.4 and parameter behavior in 7.2, 35 minutes. Total 110 minutes. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The business question

A desk keeps four daily delivery quantities. One array gives the related values a single name while preserving each day’s position.

> What information, rule and observable result do we need?

<!--
A desk keeps four daily delivery quantities. One array gives the related values a single name while preserving each day’s position. Ask pairs to name the input, required result and a possible wrong answer. Expected discussion: distinguish the stated business requirement from an implementation that merely runs. Use the trace in this part to make that distinction concrete.
-->

---

## An array has fixed length and indexed elements

- The element type applies to every slot
- new int[4] creates four initialized integer elements
- An initializer supplies values at creation

<!--
A store records quantities for four delivery slots. Four unrelated variables would require four separate names and repeated processing code. An array gives the values one name and a position-based organization. Its length is fixed when the array object is created; its elements can still change. This connects the collection idea to variables: assignment changes a value in a particular slot, while a loop chooses which slot to visit. Use these schematic forms to distinguish three actions: `[]` after the type describes the array type. Brackets after a variable name select an element. Length counts elements; an index identifies a position. For four slots, the valid indexes are zero through three. Index four is already outside the array.  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The expression for slot2 reads slot1 and  slot3. Updating one element does not resize the array or change unrelated positions. For the double-every-slot exercise, an indexed assignment must store each computed result.
-->

---

## A valid index is smaller than Length

- The first position is zero
- The last position is Length - 1 only when nonempty
- Length is a count, not a valid final index

<!--
The first line shows default values after allocation. The later assignment reads indexes one and three, computes `4 * 5 - 6`, and stores 14 at index two. It does not insert a fifth quantity or change the array's length. | Index | After allocation | After four assignments | After the calculation | | --- | ---: | ---: | ---: | | 0 | 0 | 7 | 7 | | 1 | 0 | 5 | 5 | | 2 | 0 | 9 | 14 | | 3 | 0 | 6 | 6 | Read the table by column to see a whole array state, or by row to follow one element. The loop's condition checks `index < quantities.Length` before each read. The semicolons in a for header separate initialization, condition and update. A comma between condition and update is not the syntax for this loop. An initializer such as `int[] quantities = { 7, 5, 9, 6 };` creates the same four initial values more compactly. Use `foreach` when only the values matter; use an index when the task selects or changes positions. A foreach loop can stop early with `break`, but it does not directly provide the current position for an indexed update.  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The expression for slot2 reads slot1 and  slot3. Updating one element does not resize the array or change unrelated positions. For the double-every-slot exercise, an indexed assignment must store each computed result.
-->

---

## Trace an indexed update

| Operation | Slots 0, 1, 2, 3 |
| --- | --- |
| Initialize | 7, 5, 9, 6 |
| quantities[2] = 4 × quantities[1] - quantities[3] | 7, 5, 14, 6 |
| Double each element | 14, 10, 28, 12 |

<!--
The expression for slot2 reads slot1 and  slot3. Updating one element does not resize the array or change unrelated positions. For the double-every-slot exercise, an indexed assignment must store each computed result. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
int[] quantities = { 7, 5, 9, 6 };
quantities[2] = 4 * quantities[1] - quantities[3];
Console.WriteLine(string.Join(", ", quantities));
Console.WriteLine($"Length={quantities.Length}, last={quantities[quantities.Length - 1]}");
```

```output
7, 5, 14, 6
Length=4, last=6
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is '7, 5, 14, 6\nLength=4, last=6\n'. The expression for slot2 reads slot1 and  slot3. Updating one element does not resize the array or change unrelated positions. For the double-every-slot exercise, an indexed assignment must store each computed result. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

For a four-element array, which is the final valid index?

1. 3
2. 4
3. Length

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer A. Valid indexes are 0 through 3. Length is 4, the count and the exclusive upper bound. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

## An element update changes one stored position

- Read the old value before assigning the new one
- Use a loop to apply the same update to every slot
- A foreach value is useful for reading, not replacing slots

<!--
An empty array has a real object and Length zero, but it has no last element. A variable containing null has no array object at all. First practice the empty-array distinction; Chapter 11 develops missing references further. Guided task: complete this schematic condition before reading the final element. Explain why `Length - 1` belongs in the index expression, not in the loop's upper bound when all elements are required. Predict both calls in the completed example, then change the ordinary input to a one-element array.  The expression for slot2 reads slot1 and  slot3. Updating one element does not resize the array or change unrelated positions. For the double-every-slot exercise, an indexed assignment must store each computed result. Ask students to explain the difference this concept makes to the caller or to the person using the result.
-->

---

## Defaults belong to newly created elements

- An int array begins with zero values; a bool array begins with false values.
- A new string array initially holds null references, so fill it before reading string properties.

<!--
Declaration alone does not create an array. After creating storage, every element has the type’s default value. A newly created string array therefore needs initialized entries or null-aware handling. Keep optional LINQ aggregate references distinct from the core indexed traversal lesson.
-->

---

## Challenge a plausible wrong result

Check empty, single-element and multi-element arrays. Guard a last-element lookup before calculating Length - 1.

> Name one changed input that would expose a wrong boundary, missing case or unintended state change.

<!--
Ask for a counterexample before modifying the program. Answer B. Empty traversal can perform zero iterations; trying to access any element is invalid. The trace provides an independent explanation of the ordinary case. The expression for slot2 reads slot1 and  slot3. Updating one element does not resize the array or change unrelated positions. For the double-every-slot exercise, an indexed assignment must store each computed result.
-->

---

<!-- _class: check -->

## Quick check 2

Can an empty array be created and traversed safely?

1. No
2. Yes, but there is no last element to access
3. Yes, and index 0 contains zero

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. Empty traversal can perform zero iterations; trying to access any element is invalid. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Guided Practice: Double Every Slot**

Complete the existing indexed update exercise so each quantity becomes twice its old value. Explain why reading a foreach value alone does not replace a slot.

[Open the existing practice](0701_onedim.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Existing starter cell p2_ccda6e301c and solution p2_65958f5503 remain unchanged. The source values7,5,9,6 should become14,10,18,12. The slide’s separate worked update changes slot2first; do not accidentally substitute that changed starting state into the exercise. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- Check empty, single-element and multi-element arrays. Guard a last-element lookup before calculating Length - 1.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. The expression for slot2 reads slot1 and  slot3. Updating one element does not resize the array or change unrelated positions. For the double-every-slot exercise, an indexed assignment must store each computed result. For the Your Turn activity, the instructor answer is: Existing starter cell p2_ccda6e301c and solution p2_65958f5503 remain unchanged. The source values7,5,9,6 should become14,10,18,12. The slide’s separate worked update changes slot2first; do not accidentally substitute that changed starting state into the exercise.
-->

---

## Vocabulary to explain, not memorize

- Array: fixed indexed sequence
- element: one slot
- Length: total number of slots

[Chapter objectives and glossary](0700_arrays.html)

<!--
Ask students to use each term in an explanation of this part’s case. Tie the vocabulary to the actions in the goals: Create and initialize a fixed-size array; Use zero-based indexes and Length safely; Trace element updates and empty-array behavior. A correct definition without a correct trace is not yet sufficient evidence of application.
-->

---

<!-- _class: recap -->

## Recap and next step

- Create and initialize a fixed-size array
- Use zero-based indexes and Length safely
- Trace element updates and empty-array behavior

[7.1 reading](0701_onedim.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. The expression for slot2 reads slot1 and  slot3. Updating one element does not resize the array or change unrelated positions. For the double-every-slot exercise, an indexed assignment must store each computed result. Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: 7.1 and traversal/aliases in 7.2, 35 minutes; meeting 2: searches and one insertion-sort pass in 7.3, 40 minutes; meeting 3: 7.4 and parameter behavior in 7.2, 35 minutes. Total 110 minutes.
-->

---

<!-- _class: section -->

## Processing and Sharing Arrays

7.2 · [7.2 reading](0702_array_processing.html)

Read, predict, trace, then apply.

<!--
Meeting 1: 7.1 and traversal/aliases in 7.2, 35 minutes; meeting 2: searches and one insertion-sort pass in 7.3, 40 minutes; meeting 3: 7.4 and parameter behavior in 7.2, 35 minutes. Total 110 minutes. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. A helper receives the day’s quantities. Assigning another variable to the array shares the same object; copying its elements into a new array gives them different storage.
-->

---

## Goals and preparation

- Traverse positions with a clear accumulator
- Explain aliasing and method-parameter behavior
- Distinguish element mutation from rebinding a local reference

[7.2 reading](0702_array_processing.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: 7.1 and traversal/aliases in 7.2, 35 minutes; meeting 2: searches and one insertion-sort pass in 7.3, 40 minutes; meeting 3: 7.4 and parameter behavior in 7.2, 35 minutes. Total 110 minutes. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The business question

A helper receives the day’s quantities. Assigning another variable to the array shares the same object; copying its elements into a new array gives them different storage.

> What information, rule and observable result do we need?

<!--
A helper receives the day’s quantities. Assigning another variable to the array shares the same object; copying its elements into a new array gives them different storage. Ask pairs to name the input, required result and a possible wrong answer. Expected discussion: distinguish the stated business requirement from an implementation that merely runs. Use the trace in this part to make that distinction concrete.
-->

---

## Processing combines a traversal and a result rule

- Initialize a total to the neutral value zero
- Visit every valid index once
- State the total after each visited position

<!--
An array gives many values one shared organization. To calculate a total, the program still needs a rule for visiting those values and combining them. The accumulator pattern connects arrays to Chapter 4: initialize a running result, visit each relevant element, and update the result exactly once for that element. The array changes where input values come from; it does not change the meaning of a loop or an assignment. Suppose daily quantities are 4, 0 and 7. Before the first iteration the total is zero because no entries have been processed. After each iteration, total should equal the sum of the processed prefix. This claim explains both the initialization and the update. It also provides a way to find a defect before the final result is printed. | Processed positions | Next position | Total | | --- | --- | --- | | None | 0 | 0 | | 0 | 1 | 4 | | 0 and 1 | 2 | 4 | | 0 through 2 | End | 11 | A for loop exposes positions and is useful when you must report an index or replace elements. A foreach loop exposes each element value directly and is useful when only those values matter. Do not assume that changing a foreach iteration variable updates an array element. Use explicit indexing when the operation is defined in terms of changing positions. For related explanation, see the further reading below.[^development-reading]  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. Ordinary parameter passing has not changed to ref. A copy of a reference still permits reaching the same array. The local reassignment does not replace the caller’s array variable, which explains the final output.
-->

---

## An array variable stores a reference

- Assignment copies the reference value
- Two variables can reach the same array
- Mutation through either alias is visible through both

<!--
A method parameter of type int[] receives a copy of the reference value. Caller and helper can therefore refer to the same array. Replacing an element through the helper is visible through the caller's reference. Reassigning the helper's parameter to a different array changes that local parameter, not the caller's variable. This connects ordinary parameter passing from Chapter 5 with reference aliasing, without requiring pass-by-reference parameter syntax. State whether a processing helper may mutate its input. A Total helper normally only reads values. An ApplyAdjustment helper might intentionally replace them. If a reporting task must preserve original values, computing into another array or returning a separate result is a different contract from modifying the original and restoring it afterward. An empty array is a real collection with Length zero. A total over no quantities naturally returns zero under the sum contract. A request for the first element has no valid result on that same input. Handle the operation's domain rather than giving every array helper the same empty-case behavior. A null reference is different again: there is no array object whose Length can be read. Guided exercise: replace the quantities with 0, 0 and 7. Predict the accumulator trace. Then predict the result for an empty array. Finally, explain whether the read-only total should change if another variable is assigned the array reference. An alias alone changes no element, but a later mutation through either alias can change what a subsequent total reads.  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. Ordinary parameter passing has not changed to ref. A copy of a reference still permits reaching the same array. The local reassignment does not replace the caller’s array variable, which explains the final output.
-->

---

## Trace mutation and rebinding

| Event | Caller values | Helper reference |
| --- | --- | --- |
| Call Adjust(values) | 4, 0, 7 | Same array |
| helper[0] = 9 | 9, 0, 7 | Same array |
| helper = new array {100} | 9, 0, 7 | Different local array |
| Return | 9, 0, 7 | Local reference ends |

<!--
Ordinary parameter passing has not changed to ref. A copy of a reference still permits reaching the same array. The local reassignment does not replace the caller’s array variable, which explains the final output. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
int[] quantities = { 4, 0, 7 };
Adjust(quantities);
Console.WriteLine(string.Join(", ", quantities));
void Adjust(int[] values)
{
    values[0] = 9;
    values = new int[] { 100 };
}
```

```output
9, 0, 7
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is '9, 0, 7\n'. Ordinary parameter passing has not changed to ref. A copy of a reference still permits reaching the same array. The local reassignment does not replace the caller’s array variable, which explains the final output. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

After alias = original, alias[0] = 9 changes which array?

1. Only a hidden copy
2. The array also reached through original
3. Neither

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. Assignment copied the reference, so both variables reach the same object. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

## A parameter receives a copy of the reference

- Changing an element reaches the shared object
- Reassigning the parameter changes only that local reference
- Clone or explicit element copying creates a new outer array

<!--
 Object variables, like arrays, are references, and this has important implications for assignment. With a primitive type like an `int`, an assignment copies the data: In the diagram, the contents of the memory box labeled `b` is copied to the memory box labeled `d`. The value of `d` starts off equal to the value of `b`, but can later be changed independently. Contrast an assignment with arrays. The value that is copied is the *reference*, not the array data itself, so both end up pointing at the *same* actual array: Hereafter, array assignments like: would both change the *same* array. Now `b` and `d` are essentially names for the same thing (the actual array). The technical term matches English: The names are *aliases*. This may seem like a pretty silly discussion. Why bother to give two different names to the same object? Isn’t one enough? In fact it is very important in function/method calls. An array reference can be passed as an actual value, and it is the array *reference* that is copied to the formal parameter, so the formal parameter name is an **alias** for the actual parameter name. If an array passed as a parameter to a method has elements changed in the method, then the change affects the actual parameter array. The change *remains* in the actual parameter array *after* the method has terminated. For example, consider the following function: The fragment: would *change* nums, so it ends up containing elements 10, 20, and 5. Ordinary parameter passing has not changed to ref. A copy of a reference still permits reaching the same array. The local reassignment does not replace the caller’s array variable, which explains the final output. Ask students to explain the difference this concept makes to the caller or to the person using the result.
-->

---

## Command-line arguments are a separate input channel

- Main receives command-line tokens as a string array.
- Parse only under the declared input contract; arguments are not already numeric values.

<!--
The lesson’s tokens2,5and22sum to29after parsing. args.Length counts supplied tokens. A browser demonstration can initialize an equivalent string array to show the same traversal without implying those tokens came from Console.ReadLine.
-->

---

## Challenge a plausible wrong result

Check empty plus empty, empty plus nonempty and two nonempty arrays. Verify contents and preservation, not only the resulting length.

> Name one changed input that would expose a wrong boundary, missing case or unintended state change.

<!--
Ask for a counterexample before modifying the program. Answer B. The helper changed its local copy of the reference. Element mutation and parameter reassignment are different operations. The trace provides an independent explanation of the ordinary case. Ordinary parameter passing has not changed to ref. A copy of a reference still permits reaching the same array. The local reassignment does not replace the caller’s array variable, which explains the final output.
-->

---

<!-- _class: check -->

## Quick check 2

A helper reassigns its ordinary int[] parameter to a new array. What happens to the caller variable?

1. It is automatically rebound
2. It still refers to the original array
3. It becomes null

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. The helper changed its local copy of the reference. Element mutation and parameter reassignment are different operations. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Coffee Sales Lab: CombineSales**

Use the existing connected lab’s combining stage. Return a new combined array and verify that the two supplied arrays retain their original values.

[Open the existing practice](assignments/lab.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Existing lab exercise identities remain unchanged. Allocate new storage of the combined length, copy the first array then the second, and return it. Merely assigning one input to the result aliases it and cannot represent the required independent combined output. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- Check empty plus empty, empty plus nonempty and two nonempty arrays. Verify contents and preservation, not only the resulting length.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. Ordinary parameter passing has not changed to ref. A copy of a reference still permits reaching the same array. The local reassignment does not replace the caller’s array variable, which explains the final output. For the Your Turn activity, the instructor answer is: Existing lab exercise identities remain unchanged. Allocate new storage of the combined length, copy the first array then the second, and return it. Merely assigning one input to the result aliases it and cannot represent the required independent combined output.
-->

---

## Vocabulary to explain, not memorize

- Reference: route to an object
- alias: another route to the same object
- copy: separate outer storage

[Chapter objectives and glossary](0700_arrays.html)

<!--
Ask students to use each term in an explanation of this part’s case. Tie the vocabulary to the actions in the goals: Traverse positions with a clear accumulator; Explain aliasing and method-parameter behavior; Distinguish element mutation from rebinding a local reference. A correct definition without a correct trace is not yet sufficient evidence of application.
-->

---

<!-- _class: recap -->

## Recap and next step

- Traverse positions with a clear accumulator
- Explain aliasing and method-parameter behavior
- Distinguish element mutation from rebinding a local reference

[7.2 reading](0702_array_processing.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. Ordinary parameter passing has not changed to ref. A copy of a reference still permits reaching the same array. The local reassignment does not replace the caller’s array variable, which explains the final output. Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: 7.1 and traversal/aliases in 7.2, 35 minutes; meeting 2: searches and one insertion-sort pass in 7.3, 40 minutes; meeting 3: 7.4 and parameter behavior in 7.2, 35 minutes. Total 110 minutes.
-->

---

<!-- _class: section -->

## Searching and Sorting Arrays

7.3 · [7.3 reading](0703_searching_sorting_arrays.html)

Read, predict, trace, then apply.

<!--
Meeting 1: 7.1 and traversal/aliases in 7.2, 35 minutes; meeting 2: searches and one insertion-sort pass in 7.3, 40 minutes; meeting 3: 7.4 and parameter behavior in 7.2, 35 minutes. Total 110 minutes. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. A warehouse asks whether invoice 42 is present. Arrival order may matter to the report, so sorting for faster repeated lookup may require a separate copy.
-->

---

## Goals and preparation

- Choose a search contract and missing-result policy
- Trace half-open binary search on sorted input
- Explain library sorting and an insertion-sort pass

[7.3 reading](0703_searching_sorting_arrays.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: 7.1 and traversal/aliases in 7.2, 35 minutes; meeting 2: searches and one insertion-sort pass in 7.3, 40 minutes; meeting 3: 7.4 and parameter behavior in 7.2, 35 minutes. Total 110 minutes. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The business question

A warehouse asks whether invoice 42 is present. Arrival order may matter to the report, so sorting for faster repeated lookup may require a separate copy.

> What information, rule and observable result do we need?

<!--
A warehouse asks whether invoice 42 is present. Arrival order may matter to the report, so sorting for faster repeated lookup may require a separate copy. Ask pairs to name the input, required result and a possible wrong answer. Expected discussion: distinguish the stated business requirement from an implementation that merely runs. Use the trace in this part to make that distinction concrete.
-->

---

## State what the search result means

- First match, last match and any match are different contracts
- A valid index may be zero
- Use an explicit missing result such as -1 for a hand-written index search

<!--
A service desk stores the ticket IDs waiting for review in an array. Three common questions sound similar but need different answers: *Is ticket 42 waiting at all?*, *Where is the first ticket 42?*, and *How many tickets have ID 42?* Before writing a loop, decide which question the caller is asking, because the loop's result and its stopping rule depend on it. | Question | Result type | Loop stops | | --- | --- | --- | | Is the value present? | `bool` | At the first match, or at the end | | Where is the first match? | An index, or `-1` for missing | At the first match, or at the end | | How many matches? | A count | Only at the end | Returning `-1` for a missing value is a convention called a *sentinel*: it is a value that cannot be a real index, so the caller can test for it. Index zero is a real position, so never treat zero as "not found". A search result is an index, not the stored value; the caller reads the value through that index only after checking that the index is not `-1`. This section introduces three small algorithms and the library methods that do the same jobs. **Searching** finds a matching position; **sorting** rearranges values into an order. | Tool | Input requirement | Result | Changes the array? | | --- | --- | --- | --- | | Linear search | None | First matching index, or `-1` | No | | Binary search | Sorted in ascending order | A matching index, or `-1` | No | | Insertion sort | None | The same values in ascending order | Yes, in place | The traversal and accumulator patterns from the previous section supply the loops; this section adds the stopping rules, the result contracts, and the one precondition that binary search cannot do without. Chapter 16 returns to these algorithms with costs, stability, comparers, and complete query workloads. The methods below assume the array reference is not `null`; an empty array is a valid input. For related explanation, see the further reading below.[^development-reading]  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. Use sorted values8,17,42,42,60. The first row demonstrates that an any-match search may stop at either duplicate, not necessarily the first. The high bound is excluded; a one-element array starts at[0,1), not[0,0).
-->

---

## Binary search preserves a half-open candidate interval

- Candidates are indexes in [low, high)
- Start low at 0 and  high at Length
- Use high = middle or low = middle + 1 to shrink the region

<!--
A **linear search** checks each element in index order and returns as soon as it finds a match. It works on any array, sorted or not. The pattern is a `for` loop with an early `return`:[^ch07-linear] `int[] values` receives the array reference, so no elements are copied; `target` receives the value to find. Reaching the `return -1` line proves something: the loop examined every index from `0` through `Length - 1` and none matched. For an empty array the loop body never runs, so the method returns `-1` immediately, which is the correct answer for "no first match". Trace the search on the ticket IDs `42, 17, 42, 8`: | Target | Index i | Value | Equal? | Action | | --- | ---: | ---: | --- | --- | | 8 | 0 | 42 | No | Advance | | 8 | 1 | 17 | No | Advance | | 8 | 2 | 42 | No | Advance | | 8 | 3 | 8 | Yes | Return 3 and stop | | 99 | 0 to 3 | all four | No | Loop ends; return -1 | A match near the front costs one comparison; a missing value costs one comparison per element. Two mistakes are common. Placing `return -1` inside the loop reports "missing" after the first non-matching element, before the rest have been checked. Reading `values[position]` before testing `position >= 0` throws an exception when the value was missing. The library method `Array.IndexOf` implements the same first-match contract, so the example prints both results for comparison.  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. Use sorted values8,17,42,42,60. The first row demonstrates that an any-match search may stop at either duplicate, not necessarily the first. The high bound is excluded; a one-element array starts at[0,1), not[0,0).
-->

---

## Narrow the candidate interval for target 42

| low | high | middle | Value | Next interval |
| ---: | ---: | ---: | ---: | --- |
| 0 | 5 | 2 | 42 | Found at index 2 |
| 0 | 5 | 2 | 42 | For target 60: [3,5) |
| 3 | 5 | 4 | 60 | Target 60 found  |
| Empty interval | low = high | none | none | Missing |

<!--
Use sorted values8,17,42,42,60. The first row demonstrates that an any-match search may stop at either duplicate, not necessarily the first. The high bound is excluded; a one-element array starts at[0,1), not[0,0). Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
Console.WriteLine(Find(new[] { 8, 17, 42, 42, 60 }, 60));
Console.WriteLine(Find(Array.Empty<int>(), 42));
int Find(int[] a, int target) {
    int low = 0, high = a.Length;
    while (low < high) {
        int middle = low + (high - low) / 2;
        if (a[middle] == target) return middle;
        if (a[middle] < target) low = middle + 1; else high = middle;
    } return -1;
}
```

```output
4
-1
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is '4\n-1\n'. Use sorted values8,17,42,42,60. The first row demonstrates that an any-match search may stop at either duplicate, not necessarily the first. The high bound is excluded; a one-element array starts at[0,1), not[0,0). Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

## Insertion sort: save, shift, restore

| Prefix before pass | Saved item | Shifted items | After insertion |
| --- | ---: | --- | --- |
| 8,17 / 42,12 | 42 | none | 8,17,42 / 12 |
| 8,17,42 / 12 | 12 | 42 then 17 | 8,12,17,42 |

<!--
The slash separates the ordered prefix from the unprocessed suffix. Save12before shifting42and17right; otherwise overwriting its slot destroys the value to insert. The inner scan stops after8because8<=12. Growing a correct sorted prefix is the invariant, not a claim that the entire array is sorted before the final pass.
-->

---

## Library workflow: preserve arrivals, sort a copy

```csharp
using System;
int[] arrivals = { 60, 17, 42, 8, 42 };
int[] sorted = (int[])arrivals.Clone();
Array.Sort(sorted);
Console.WriteLine(string.Join(", ", arrivals));
Console.WriteLine(string.Join(", ", sorted));
Console.WriteLine(Array.BinarySearch(sorted, 17) >= 0);
Console.WriteLine(Array.BinarySearch(sorted, 20) >= 0);
```

```output
60, 17, 42, 8, 42
8, 17, 42, 42, 60
True
False
```

<!--
Clone creates separate outer storage for these integer elements. Sort mutates only the copy. Compare a library result with zero to distinguish found from missing; a negative missing value is not always-1. For strings, sort and search with the same explicit comparer. The independent homework library task preserves its existing exercise identity.
-->

---

<!-- _class: check -->

## Quick check 1

Which initial high matches [low, high) for an array of length 5?

1. 4
2. 5
3. 6

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. The interval includes0 through 4 and  excludes5. Using4would discard the final candidate from the outset. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

## Sorting changes order and may change the task

- Array.Sort mutates the supplied array
- Clone when arrival order must survive
- Sort and binary-search with the same comparison policy

<!--
The second `42` at index 2 is never reported, because the contract asks for the first match. If the caller needs every matching position, the loop must not return early; it collects indexes or counts them instead, as a later example shows.  Use sorted values8,17,42,42,60. The first row demonstrates that an any-match search may stop at either duplicate, not necessarily the first. The high bound is excluded; a one-element array starts at[0,1), not[0,0). Ask students to explain the difference this concept makes to the caller or to the person using the result.
-->

---

## Compare contracts before choosing an algorithm

- Linear search works without sorted input and can implement a specific first/last-match rule.
- Binary search needs sorted input; insertion sort teaches how an ordered prefix grows.

<!--
A faster lookup is useful only if sorting cost and mutation policy fit the workload. A one-off lookup may be best served by a linear pass. Search results refer to the current array order; an index into a sorted copy is not the arrival position. The extra worked slides trace insertion and a library-copy workflow.
-->

---

## Challenge a plausible wrong result

Check empty, one matching element, first/last match, missing below/above/between values and duplicates under the declared any-match contract.

> Name one changed input that would expose a wrong boundary, missing case or unintended state change.

<!--
Ask for a counterexample before modifying the program. Answer B. Library missing results encode information and need not equal-1. Also maintain the sorted-input and comparer preconditions. The trace provides an independent explanation of the ordinary case. Use sorted values8,17,42,42,60. The first row demonstrates that an any-match search may stop at either duplicate, not necessarily the first. The high bound is excluded; a one-element array starts at[0,1), not[0,0).
-->

---

<!-- _class: check -->

## Quick check 2

Array.BinarySearch returns a negative result for a missing item. Can it always be treated as exactly -1?

1. Yes
2. No, check result >= 0 for found
3. Only when sorted

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. Library missing results encode information and need not equal-1. Also maintain the sorted-input and comparer preconditions. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Guided Practice: Repair the Boundary**

Repair the existing half-open search starter. Explain what goes wrong for a one-element array and for a match at the final position.

[Open the existing practice](0703_searching_sorting_arrays.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. The existing source exercise and all IDs remain unchanged. Set high to values.Length, loop while low<high, and use high=middle for the left region. Expected source checks include0,0,2 and  missing results. A correct any-match binary search does not promise a first duplicate. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- Check empty, one matching element, first/last match, missing below/above/between values and duplicates under the declared any-match contract.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. Use sorted values8,17,42,42,60. The first row demonstrates that an any-match search may stop at either duplicate, not necessarily the first. The high bound is excluded; a one-element array starts at[0,1), not[0,0). For the Your Turn activity, the instructor answer is: The existing source exercise and all IDs remain unchanged. Set high to values.Length, loop while low<high, and use high=middle for the left region. Expected source checks include0,0,2 and  missing results. A correct any-match binary search does not promise a first duplicate.
-->

---

## Vocabulary to explain, not memorize

- Linear search: visit positions
- binary search: halve sorted candidates
- insertion sort: grow an ordered prefix

[Chapter objectives and glossary](0700_arrays.html)

<!--
Ask students to use each term in an explanation of this part’s case. Tie the vocabulary to the actions in the goals: Choose a search contract and missing-result policy; Trace half-open binary search on sorted input; Explain library sorting and an insertion-sort pass. A correct definition without a correct trace is not yet sufficient evidence of application.
-->

---

<!-- _class: recap -->

## Recap and next step

- Choose a search contract and missing-result policy
- Trace half-open binary search on sorted input
- Explain library sorting and an insertion-sort pass

[7.3 reading](0703_searching_sorting_arrays.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. Use sorted values8,17,42,42,60. The first row demonstrates that an any-match search may stop at either duplicate, not necessarily the first. The high bound is excluded; a one-element array starts at[0,1), not[0,0). Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: 7.1 and traversal/aliases in 7.2, 35 minutes; meeting 2: searches and one insertion-sort pass in 7.3, 40 minutes; meeting 3: 7.4 and parameter behavior in 7.2, 35 minutes. Total 110 minutes.
-->

---

<!-- _class: section -->

## Rectangular Arrays and Table Summaries

7.4 · [7.4 reading](0704_twodim.html)

Read, predict, trace, then apply.

<!--
Meeting 1: 7.1 and traversal/aliases in 7.2, 35 minutes; meeting 2: searches and one insertion-sort pass in 7.3, 40 minutes; meeting 3: 7.4 and parameter behavior in 7.2, 35 minutes. Total 110 minutes. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. A branch report has two rows of three day counts. A total number of six cells does not tell the program how many rows or columns it should visit.
-->

---

## Goals and preparation

- Distinguish total Length from dimension sizes
- Traverse rows and columns using GetLength
- Compute row, column and grand totals without assuming a square table

[7.4 reading](0704_twodim.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: 7.1 and traversal/aliases in 7.2, 35 minutes; meeting 2: searches and one insertion-sort pass in 7.3, 40 minutes; meeting 3: 7.4 and parameter behavior in 7.2, 35 minutes. Total 110 minutes. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The business question

A branch report has two rows of three day counts. A total number of six cells does not tell the program how many rows or columns it should visit.

> What information, rule and observable result do we need?

<!--
A branch report has two rows of three day counts. A total number of six cells does not tell the program how many rows or columns it should visit. Ask pairs to name the input, required result and a possible wrong answer. Expected discussion: distinguish the stated business requirement from an implementation that merely runs. Use the trace in this part to make that distinction concrete.
-->

---

## A rectangular array has one size per dimension

- int[,] uses two indexes for one element
- GetLength(0) returns the row count
- GetLength(1) returns the column count

<!--
 An array can have any number of dimensions. For example, one-dimension (1D), 2-dimension (2D), 3-dimension (3D) as shown below [^0702_twodim-multi-d-arrays]. > Since arrays use indices to access the elements, you must specify the indexing position within the array for data manipulation. In a 1d array you specify just the index, in a 2d array, you specify row and column, and in a 3d array you specify plane, row, and column. You can have higher dimension arrays, but they are just difficult to imagine. (d-arrays)=  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. A square-only loop bound would hide a defect on2 by 2data. The row loop uses the first dimension, the column loop the second. Independently add the rows and columns: both routes must agree on grand total 16.
-->

---

## Length counts every cell

- For r rows and c columns, Length is r × c
- A row traversal holds the row fixed
- A column traversal holds the column fixed

<!--
 While a one-dimensional array works for a sequence of data, you need something more for a two dimensional table, where data values vary over both row and column. If we have a table of integers, for instance with three rows and four columns: We could declare an array variable of the right size as  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. A square-only loop bound would hide a defect on2 by 2data. The row loop uses the first dimension, the column loop the second. Independently add the rows and columns: both routes must agree on grand total 16.
-->

---

## Trace a 2 by 3 branch table

| Branch | Day 1 | Day 2 | Day 3 | Row total |
| --- | ---: | ---: | ---: | ---: |
| North | 2 | 5 | 1 | 8 |
| South | 4 | 1 | 3 | 8 |
| Column totals | 6 | 6 | 4 | Grand 16 |

<!--
A square-only loop bound would hide a defect on2 by 2data. The row loop uses the first dimension, the column loop the second. Independently add the rows and columns: both routes must agree on grand total 16. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
int[,] orders = { { 2, 5, 1 }, { 4, 1, 3 } };
int grand = 0;
for (int r = 0; r < orders.GetLength(0); r++) {
    int rowTotal = 0;
    for (int c = 0; c < orders.GetLength(1); c++) rowTotal += orders[r, c];
    grand += rowTotal;
    Console.WriteLine($"Row {r}: {rowTotal}");
}
Console.WriteLine($"Grand: {grand}");
```

```output
Row 0: 8
Row 1: 8
Grand: 16
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is 'Row 0: 8\nRow 1: 8\nGrand: 16\n'. A square-only loop bound would hide a defect on2 by 2data. The row loop uses the first dimension, the column loop the second. Independently add the rows and columns: both routes must agree on grand total 16. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

For new int[2,3], what is Length?

1. 2
2. 3
3. 6

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer C. Length counts all six elements; GetLength(0) is 2 and  GetLength(1) is 3. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

## Reset an accumulator at the level it summarizes

- Reset row total at the start of each row
- Keep grand total across all rows
- An array of arrays is a distinct advanced representation

<!--
 Multiple indices are separated by commas inside the square brackets. In declaring an array type, no indices are included so the `[,]` indicates a two dimensional array. Where the `new` object is being created, the values inside the square brackets give each dimension. In general the notation for a two dimensional array declaration is: > **type** `[, ]` **variableName** and to create a new array with default values: > new **type** `[` *intExpression1*`,` *intExpression2* `]` where the expressions evaluate to integers for the dimensions. To assign the 8 in the table above, consider that it is in the second row in normal counting, but we start array indices at 0, so there are rows 0, 1, and 2, and the 8 has row index 1. Again starting with index 0 for columns, the 8 is at index 1\. We can assign a value to that position with  A square-only loop bound would hide a defect on2 by 2data. The row loop uses the first dimension, the column loop the second. Independently add the rows and columns: both routes must agree on grand total 16. Ask students to explain the difference this concept makes to the caller or to the person using the result.
-->

---

## Rectangular and jagged arrays are different models

- A rectangular int[,] has a single row count and column count.
- A jagged int[][] contains row arrays that may have different lengths.

<!--
Keep jagged arrays as the source’s advanced reference. Creating only the outer jagged array leaves its row references null until each row is initialized. The standard summary homework uses a rectangular table and GetLength, so do not silently replace it with a jagged representation.
-->

---

## Challenge a plausible wrong result

Check a nonsquare table, zero rows, zero columns and one-row/one-column shapes. Verify grand total independently from both row and column totals.

> Name one changed input that would expose a wrong boundary, missing case or unintended state change.

<!--
Ask for a counterexample before modifying the program. Answer A. Equal dimensions can conceal a loop using the wrong dimension. Empty and single-dimension cases still matter. The trace provides an independent explanation of the ordinary case. A square-only loop bound would hide a defect on2 by 2data. The row loop uses the first dimension, the column loop the second. Independently add the rows and columns: both routes must agree on grand total 16.
-->

---

<!-- _class: check -->

## Quick check 2

Why test a rectangular 2 by 3 table rather than only 2 by 2?

1. It exposes confusion between row and column bounds
2. Square arrays cannot store integers
3. It removes the need for empty cases

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer A. Equal dimensions can conceal a loop using the wrong dimension. Empty and single-dimension cases still matter. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Homework: Rectangular Array Summary**

Complete the existing independent summary task. Produce row totals, column totals and a grand total, then test 0 by 3,1 by 2 and 2 by 1 shapes.

[Open the existing practice](assignments/homework.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Keep the existing rectangular-summary exercise identity and all older homework IDs unchanged. Initialize one accumulator per row/column and use the corresponding dimension. For0 by 3there are no row entries, three zero column totals and grand zero. The worked slide prints rows only; the homework additionally requires columns. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- Check a nonsquare table, zero rows, zero columns and one-row/one-column shapes. Verify grand total independently from both row and column totals.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. A square-only loop bound would hide a defect on2 by 2data. The row loop uses the first dimension, the column loop the second. Independently add the rows and columns: both routes must agree on grand total 16. For the Your Turn activity, the instructor answer is: Keep the existing rectangular-summary exercise identity and all older homework IDs unchanged. Initialize one accumulator per row/column and use the corresponding dimension. For0 by 3there are no row entries, three zero column totals and grand zero. The worked slide prints rows only; the homework additionally requires columns.
-->

---

## Vocabulary to explain, not memorize

- Rectangular: fixed dimension grid
- GetLength: size of one dimension
- nested traversal: row/column combinations

[Chapter objectives and glossary](0700_arrays.html)

<!--
Ask students to use each term in an explanation of this part’s case. Tie the vocabulary to the actions in the goals: Distinguish total Length from dimension sizes; Traverse rows and columns using GetLength; Compute row, column and grand totals without assuming a square table. A correct definition without a correct trace is not yet sufficient evidence of application.
-->

---

<!-- _class: recap -->

## Recap and next step

- Distinguish total Length from dimension sizes
- Traverse rows and columns using GetLength
- Compute row, column and grand totals without assuming a square table

[7.4 reading](0704_twodim.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. A square-only loop bound would hide a defect on2 by 2data. The row loop uses the first dimension, the column loop the second. Independently add the rows and columns: both routes must agree on grand total 16. Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: 7.1 and traversal/aliases in 7.2, 35 minutes; meeting 2: searches and one insertion-sort pass in 7.3, 40 minutes; meeting 3: 7.4 and parameter behavior in 7.2, 35 minutes. Total 110 minutes.
-->
