---
marp: true
theme: thinkpress-lecture
paginate: true
title: "Chapter 21: Algorithm Analysis"
book: "Computer Science in C#"
section: "Chapter 21"
primary: "#2a6b37"
accent: "#b8860b"
---

<!-- _class: title -->

# 21. Algorithm Analysis

Computer Science in C#

Contracts, worked traces, practice, and verified examples.

<!--
Chapter 21: Algorithm Analysis.
Existing 110-minute chapter allocation: 40 minutes counted work;35 minutes correctness;35 minutes recurrence models.
Part 21.1: Big-O and Complexity, starting slide 2.
Part 21.2: Correctness and Invariants, starting slide 17.
Part 21.3: Recurrences and Recursive Cost, starting slide 32.
Each core part is a reading unit; follow the current three-meeting allocation rather than add one meeting per part. Supporting parts are explicitly optional. Quick-check and Your turn answers remain in these instructor notes; the student HTML omits them. All complete C# examples are standalone and recorded in the code verification manifest.
-->

---

<!-- _class: section -->

# 21.1. Big-O and Complexity

Computer Science in C#

<!--
This part addresses choose input sizes and counted work, derive exact counts before growth classes, separate worst, expected, and amortized claims. Read 2101_big_o.html with the worked examples. Use the selected trace and nearby practice within the chapter's existing meeting allocation; this part is a reading unit, not an extra required meeting.
-->

---

## Goals for this part

- Choose input sizes and counted work
- Derive exact counts before growth classes
- Separate worst, expected, and amortized claims

<!--
Connect these goals to the chapter objectives before starting. The running case is: A finance report compares each unordered pair of expense records once. Doubling the report changes pair count faster than a simple scan. Ask learners to predict one result before execution. Revisit the same contract at the recap rather than introducing an unrelated API tour.
-->

---

## State the business question

A finance report compares each unordered pair of expense records once. Doubling the report changes pair count faster than a simple scan.

<!--
Ask which result the stakeholder actually needs. Name the operation being counted. A faster program is useful only when it still answers that question. Ask students to name one input or policy that would change the answer, then introduce the contract.
-->

---

## Make the contract explicit

- Name the operation being counted.
- Keep independent input sizes independent.
- A bound describes growth under assumptions, not elapsed seconds.

<!--
Explain each obligation in the running case. The pair loop excludes self-pairs and avoids comparing both (i,j) and (j,i). A rectangular n-by-m loop answers a different counting question. Separate what clients can rely on from representation details. Ask what a missing, empty, tied, or invalid input means before moving to the trace.
-->

---

## Trace one small instance

| n records | Unordered distinct pairs |
| ---: | ---: |
| 0 | 0 |
| 1 | 0 |
| 5 | 10 |
| 10 | 45 |

<!--
Walk the rows in order and pause before revealing the next state on screen. The measured counter agrees with the exact formula for this input. Agreement at n=5 is evidence, not a proof for every n. The table records a logical trace; distinguish any sorted presentation view from physical storage layout. Ask a learner to justify one transition using the stated contract.
-->

---

## Follow the mechanism

- For each i, compare j values strictly greater than i.
- Sum row lengths n-1 through zero.
- Simplify n(n-1)/2 to a tight quadratic growth class.

<!--
Tie every step to a state change in the preceding trace. The pair loop excludes self-pairs and avoids comparing both (i,j) and (j,i). A rectangular n-by-m loop answers a different counting question. Ask which step would fail if omitted or moved. The complete implementation stays in the lesson so the slide can focus on the algorithm's own progress rather than long support classes.
-->

---

## Keep the invariant in view

The pair loop excludes self-pairs and avoids comparing both (i,j) and (j,i). A rectangular n-by-m loop answers a different counting question.

<!--
Name the exact program point where this statement applies. Contrast initialization, one update, and the exit condition. Do not call a printed success message a proof. Use the verification slide later to distinguish a check on a few examples from the general argument.
-->

---

## Run the small model

```csharp
using System;
int n = 5, comparisons = 0;
for (int i = 0; i < n; i++)
    for (int j = i + 1; j < n; j++) comparisons++;
Console.WriteLine(comparisons);
Console.WriteLine(n * (n - 1) / 2);
```

```output
10
10
```

<!--
Before running, ask learners to predict the complete output. Run this standalone cell in a fresh C# application; it requires no previous cell. The measured counter agrees with the exact formula for this input. Agreement at n=5 is evidence, not a proof for every n. If the demo environment fails, read the verified output and continue with the trace rather than spending the meeting on tool setup.
-->

---

## Explain the observed result

The measured counter agrees with the exact formula for this input. Agreement at n=5 is evidence, not a proof for every n.

<!--
Ask learners to connect the output to the contract, not just read the numbers aloud. The pair loop excludes self-pairs and avoids comparing both (i,j) and (j,i). A rectangular n-by-m loop answers a different counting question. Invite one controlled input change and predict its effect first. The worked output is evidence for this instance; the invariant and assumptions explain the broader claim.
-->

---

<!-- _class: check -->

## Quick check 1

What is the tight growth of 3n squared + 5n + 20?

1. Theta(n)
2. Theta(n squared)
3. Theta(log n)

<!--
Give 30 seconds individually, then compare with a neighbor. Answer: B. The quadratic term eventually dominates. It is also a valid looser cubic upper bound, but that loses information. Ask for the reason, not only the letter. If a common wrong choice dominates, replay the contract or trace before proceeding.
-->

---

## Boundaries are part of the model

- Zero-size inputs can remove all loop work.
- Two inputs n,m give n*m unless related explicitly.
- Count auxiliary storage separately from input storage.

<!--
Choose one boundary and ask for an independently expected result. Use exact integer arithmetic when checking formulas. Distinguish a legal empty result from an invalid input. Do not silently change the contract to make a failing test disappear.
-->

---

<!-- _class: check -->

## Quick check 2

Which claim needs a probability model?

1. Expected cost
2. Every amortized sequence bound
3. The definition of an input size

<!--
Poll for a prediction before revealing any explanation. Answer: A. Expected cost averages over a stated distribution. Amortized analysis accounts for a sequence that includes expensive operations, without requiring random inputs. Link the distinction to the business case. Use a brief counterexample when a learner treats an assumption as a universal guarantee.
-->

---

<!-- _class: yourturn -->

## Your turn: Exercise: Count Fixed-Width Nesting

- Count three inner checks per outer iteration.
- Test n=0,4,8.
- Explain why this nested loop is linear.

[Open the section practice](2101_big_o.html)

<!--
Allow three to five minutes in pairs. This practice is drawn from the section's actual exercise; it does not create a new assessment ID. Answer and debrief: The counts are zero,12,24. Three is fixed rather than proportional to n, so total work is 3n. Merely seeing two loops does not establish quadratic growth. Ask learners to show their trace or checks before consulting the lesson solution. Assess reasoning as well as printed output.
-->

---

## Verify before recommending

- Use exact integer arithmetic when checking formulas.
- Do not label one stopwatch value Big-O.
- Record cost model, case, sizes, and memory before recommending an algorithm.

<!--
Ask learners to separate implementation checks, model assumptions, and performance claims. A. Expected cost averages over a stated distribution. Amortized analysis accounts for a sequence that includes expensive operations, without requiring random inputs. Relate the requested evidence to the chapter lab/homework without changing their stable identities or making supporting readings silently compulsory.
-->

---

<!-- _class: recap -->

## Recap

- Choose input sizes and counted work
- Derive exact counts before growth classes
- Separate worst, expected, and amortized claims

[Continue with the lesson and exercises](2101_big_o.html)

<!--
Invite a learner to explain one goal using the worked case. The measured counter agrees with the exact formula for this input. Agreement at n=5 is evidence, not a proof for every n. Exit question: what input, representation, or contract change would require a new argument? Use the current assignment route and chapter schedule to select follow-up practice.
-->

---

<!-- _class: section -->

# 21.2. Correctness and Invariants

Computer Science in C#

<!--
This part addresses state a precise result contract, separate partial correctness from termination, use boundary counterexamples to challenge code. Read 2102_correctness.html with the worked examples. Use the selected trace and nearby practice within the chapter's existing meeting allocation; this part is a reading unit, not an extra required meeting.
-->

---

## Goals for this part

- State a precise result contract
- Separate partial correctness from termination
- Use boundary counterexamples to challenge code

<!--
Connect these goals to the chapter objectives before starting. The running case is: A report total must include every expense once. A success message is useful only if it follows an independently justified check. Ask learners to predict one result before execution. Revisit the same contract at the recap rather than introducing an unrelated API tour.
-->

---

## State the business question

A report total must include every expense once. A success message is useful only if it follows an independently justified check.

<!--
Ask which result the stakeholder actually needs. Preconditions describe legal inputs. A faster program is useful only when it still answers that question. Ask students to name one input or policy that would change the answer, then introduce the contract.
-->

---

## Make the contract explicit

- Preconditions describe legal inputs.
- An invariant describes state at an exact program point.
- Total correctness also requires a decreasing progress measure.

<!--
Explain each obligation in the running case. Before iteration i, total equals the sum of values in [0,i). The quantity n-i decreases on each iteration and cannot decrease forever. Separate what clients can rely on from representation details. Ask what a missing, empty, tied, or invalid input means before moving to the trace.
-->

---

## Trace one small instance

| Next index i | Processed prefix | Total for [4,-1,3] |
| ---: | --- | ---: |
| 0 | empty | 0 |
| 1 | [4] | 4 |
| 2 | [4,-1] | 3 |
| 3 | [4,-1,3] | 6 |

<!--
Walk the rows in order and pause before revealing the next state on screen. Initializing maximum from an actual item preserves the nonempty-array contract. Starting at zero would fail on this negative-only report. The table records a logical trace; distinguish any sorted presentation view from physical storage layout. Ask a learner to justify one transition using the stated contract.
-->

---

## Follow the mechanism

- Initialize the invariant before the loop.
- Show one iteration extends the prefix correctly.
- At exit i=n, connect the invariant to the required result.

<!--
Tie every step to a state change in the preceding trace. Before iteration i, total equals the sum of values in [0,i). The quantity n-i decreases on each iteration and cannot decrease forever. Ask which step would fail if omitted or moved. The complete implementation stays in the lesson so the slide can focus on the algorithm's own progress rather than long support classes.
-->

---

## Keep the invariant in view

Before iteration i, total equals the sum of values in [0,i). The quantity n-i decreases on each iteration and cannot decrease forever.

<!--
Name the exact program point where this statement applies. Contrast initialization, one update, and the exit condition. Do not call a printed success message a proof. Use the verification slide later to distinguish a check on a few examples from the general argument.
-->

---

## Run the small model

```csharp
using System;
int[] expense = { 4, -1, 3 }; long total = 0;
for (int i = 0; i < expense.Length; i++) total += expense[i];
Console.WriteLine(total);
int[] negative = { -7, -2, -9 };
int maximum = negative[0];
foreach (int value in negative) if (value > maximum) maximum = value;
Console.WriteLine(maximum);
```

```output
6
-2
```

<!--
Before running, ask learners to predict the complete output. Run this standalone cell in a fresh C# application; it requires no previous cell. Initializing maximum from an actual item preserves the nonempty-array contract. Starting at zero would fail on this negative-only report. If the demo environment fails, read the verified output and continue with the trace rather than spending the meeting on tool setup.
-->

---

## Explain the observed result

Initializing maximum from an actual item preserves the nonempty-array contract. Starting at zero would fail on this negative-only report.

<!--
Ask learners to connect the output to the contract, not just read the numbers aloud. Before iteration i, total equals the sum of values in [0,i). The quantity n-i decreases on each iteration and cannot decrease forever. Invite one controlled input change and predict its effect first. The worked output is evidence for this instance; the invariant and assumptions explain the broader claim.
-->

---

<!-- _class: check -->

## Quick check 1

A loop invariant implies the postcondition at exit. What is still needed?

1. Termination evidence
2. A larger computer
3. A sorted result for every problem

<!--
Give 30 seconds individually, then compare with a neighbor. Answer: A. Partial correctness says what follows if execution exits. A decreasing bounded variant supplies the missing termination argument. Ask for the reason, not only the letter. If a common wrong choice dominates, replay the contract or trace before proceeding.
-->

---

## Boundaries are part of the model

- Empty sum may be zero under its declared contract.
- A maximum of an empty array needs a failure policy.
- Null and empty are distinct inputs.

<!--
Choose one boundary and ask for an independently expected result. Predict outputs before running the candidate. Distinguish a legal empty result from an invalid input. Do not silently change the contract to make a failing test disappear.
-->

---

<!-- _class: check -->

## Quick check 2

A maximum result is at least every input. Is that condition alone sufficient?

1. Yes
2. No; it must also be an input value
3. Only if the input has duplicates

<!--
Poll for a prediction before revealing any explanation. Answer: B. A fabricated huge value satisfies the upper comparison condition but is not the maximum member. The result contract needs membership. Link the distinction to the business case. Use a brief counterexample when a learner treats an assumption as a universal guarantee.
-->

---

<!-- _class: yourturn -->

## Your turn: Exercise: Count Nonnegative Adjustments

- Count nonnegative expense adjustments.
- State the processed-prefix invariant and variant.
- Include zero in a boundary test.

[Open the section practice](2102_correctness.html)

<!--
Allow three to five minutes in pairs. This practice is drawn from the section's actual exercise; it does not create a new assessment ID. Answer and debrief: Before index i, the count equals the number of values at least zero in [0,i). The variant n-i decreases. A test containing zero exposes the incorrect predicate value>0. Ask learners to show their trace or checks before consulting the lesson solution. Assess reasoning as well as printed output.
-->

---

## Verify before recommending

- Predict outputs before running the candidate.
- Test extremes, absence, duplicates, and early returns.
- Treat a counterexample as a reason to repair the claim, not hide the input.

<!--
Ask learners to separate implementation checks, model assumptions, and performance claims. B. A fabricated huge value satisfies the upper comparison condition but is not the maximum member. The result contract needs membership. Relate the requested evidence to the chapter lab/homework without changing their stable identities or making supporting readings silently compulsory.
-->

---

<!-- _class: recap -->

## Recap

- State a precise result contract
- Separate partial correctness from termination
- Use boundary counterexamples to challenge code

[Continue with the lesson and exercises](2102_correctness.html)

<!--
Invite a learner to explain one goal using the worked case. Initializing maximum from an actual item preserves the nonempty-array contract. Starting at zero would fail on this negative-only report. Exit question: what input, representation, or contract change would require a new argument? Use the current assignment route and chapter schedule to select follow-up practice.
-->

---

<!-- _class: section -->

# 21.3. Recurrences and Recursive Cost

Computer Science in C#

<!--
This part addresses write base cases and rounded child sizes, separate total work from active depth, account for repeated subproblems and live storage. Read 2103_recurrences.html with the worked examples. Use the selected trace and nearby practice within the chapter's existing meeting allocation; this part is a reading unit, not an extra required meeting.
-->

---

## Goals for this part

- Write base cases and rounded child sizes
- Separate total work from active depth
- Account for repeated subproblems and live storage

<!--
Connect these goals to the chapter objectives before starting. The running case is: A balanced review splits a report in two and inspects all records at each combine level. Count the tree of calls separately from the longest active path. Ask learners to predict one result before execution. Revisit the same contract at the recap rather than introducing an unrelated API tour.
-->

---

## State the business question

A balanced review splits a report in two and inspects all records at each combine level. Count the tree of calls separately from the longest active path.

<!--
Ask which result the stakeholder actually needs. A recurrence includes a base case. A faster program is useful only when it still answers that question. Ask students to name one input or policy that would change the answer, then introduce the contract.
-->

---

## Make the contract explicit

- A recurrence includes a base case.
- Odd sizes require floor/ceiling child lengths.
- Sequential child calls do not keep both child stacks active simultaneously.

<!--
Explain each obligation in the running case. A binary splitting tree with n singleton leaves has 2n-1 total calls, while its active depth is logarithmic for balanced splits. Separate what clients can rely on from representation details. Ask what a missing, empty, tied, or invalid input means before moving to the trace.
-->

---

## Trace one small instance

| Size | Calls for two-child split | Peak depth |
| ---: | ---: | ---: |
| 1 | 1 | 1 |
| 2 | 3 | 2 |
| 4 | 7 | 3 |
| 8 | 15 | 4 |

<!--
Walk the rows in order and pause before revealing the next state on screen. The call counter has constant local work, unlike a merge process with linear combine work. Do not assign the merge-sort runtime to this counter program. The table records a logical trace; distinguish any sorted presentation view from physical storage layout. Ask a learner to justify one transition using the stated contract.
-->

---

## Follow the mechanism

- Count one call before deciding whether it is a base case.
- For balanced two-child division, sum work per level.
- Track storage that remains live while a child is executing.

<!--
Tie every step to a state change in the preceding trace. A binary splitting tree with n singleton leaves has 2n-1 total calls, while its active depth is logarithmic for balanced splits. Ask which step would fail if omitted or moved. The complete implementation stays in the lesson so the slide can focus on the algorithm's own progress rather than long support classes.
-->

---

## Keep the invariant in view

A binary splitting tree with n singleton leaves has 2n-1 total calls, while its active depth is logarithmic for balanced splits.

<!--
Name the exact program point where this statement applies. Contrast initialization, one update, and the exit condition. Do not call a printed success message a proof. Use the verification slide later to distinguish a check on a few examples from the general argument.
-->

---

## Run the small model

```csharp
using System;
static int Calls(int n) => n <= 1 ? 1 : 1 + Calls(n / 2) + Calls(n - n / 2);
foreach (int n in new[] { 1, 2, 4, 8 })
    Console.WriteLine($"{n}: {Calls(n)}");
```

```output
1: 1
2: 3
4: 7
8: 15
```

<!--
Before running, ask learners to predict the complete output. Run this standalone cell in a fresh C# application; it requires no previous cell. The call counter has constant local work, unlike a merge process with linear combine work. Do not assign the merge-sort runtime to this counter program. If the demo environment fails, read the verified output and continue with the trace rather than spending the meeting on tool setup.
-->

---

## Explain the observed result

The call counter has constant local work, unlike a merge process with linear combine work. Do not assign the merge-sort runtime to this counter program.

<!--
Ask learners to connect the output to the contract, not just read the numbers aloud. A binary splitting tree with n singleton leaves has 2n-1 total calls, while its active depth is logarithmic for balanced splits. Invite one controlled input change and predict its effect first. The worked output is evidence for this instance; the invariant and assumptions explain the broader claim.
-->

---

<!-- _class: check -->

## Quick check 1

Which count determines call-stack depth?

1. All calls ever made
2. Maximum simultaneously active calls
3. Total printed lines

<!--
Give 30 seconds individually, then compare with a neighbor. Answer: B. Earlier child calls have returned before later siblings execute. Count live frames, including the current one. Ask for the reason, not only the letter. If a common wrong choice dominates, replay the contract or trace before proceeding.
-->

---

## Boundaries are part of the model

- Explicitly handle n=0 if the domain allows it.
- Use n-n/2 for the other odd-sized child.
- Large repeated recursion can overflow time, stack, or result types.

<!--
Choose one boundary and ask for an independently expected result. Compare n=1, odd n, and powers of two. Distinguish a legal empty result from an invalid input. Do not silently change the contract to make a failing test disappear.
-->

---

<!-- _class: check -->

## Quick check 2

What growth follows from two half-size branches plus linear combine work?

1. Theta(n log n)
2. Theta(log n)
3. Theta(n squared) for every such recurrence

<!--
Poll for a prediction before revealing any explanation. Answer: A. Each balanced level contributes linear work, and there are logarithmically many levels. Base and rounding cases must still be justified. Link the distinction to the business case. Use a brief counterexample when a learner treats an assumption as a universal guarantee.
-->

---

<!-- _class: yourturn -->

## Your turn: Exercise: Leaves and Total Calls

- Use balanced two-child division for n=8.
- Print leaves and total calls.
- Contrast constant local work with linear combine work.

[Open the section practice](2103_recurrences.html)

<!--
Allow three to five minutes in pairs. This practice is drawn from the section's actual exercise; it does not create a new assessment ID. Answer and debrief: There are eight singleton leaves and fifteen total calls. This call counter has constant local work; a merge-like recurrence adds size-proportional work at each level and has a different total model. Ask learners to show their trace or checks before consulting the lesson solution. Assess reasoning as well as printed output.
-->

---

## Verify before recommending

- Compare n=1, odd n, and powers of two.
- Check the recurrence against actual counted operations.
- Distinguish modeled combine units from execution time of a recurrence counter.

<!--
Ask learners to separate implementation checks, model assumptions, and performance claims. A. Each balanced level contributes linear work, and there are logarithmically many levels. Base and rounding cases must still be justified. Relate the requested evidence to the chapter lab/homework without changing their stable identities or making supporting readings silently compulsory.
-->

---

<!-- _class: recap -->

## Recap

- Write base cases and rounded child sizes
- Separate total work from active depth
- Account for repeated subproblems and live storage

[Continue with the lesson and exercises](2103_recurrences.html)

<!--
Invite a learner to explain one goal using the worked case. The call counter has constant local work, unlike a merge process with linear combine work. Do not assign the merge-sort runtime to this counter program. Exit question: what input, representation, or contract change would require a new argument? Use the current assignment route and chapter schedule to select follow-up practice.
-->
