---
marp: true
theme: thinkpress-lecture
paginate: true
title: "Chapter 25: Dynamic Programming and Backtracking"
book: "Computer Science in C#"
section: "Chapter 25"
primary: "#2a6b37"
accent: "#b8860b"
---

<!-- _class: title -->

# 25. Dynamic Programming and Backtracking

Computer Science in C#

Contracts, worked traces, practice, and verified examples.

<!--
Chapter 25: Dynamic Programming and Backtracking.
Existing 110-minute chapter allocation: 40 minutes repeated-work/state models;40 minutes backtracking;30 minutes optimization/witness verification across the three readings.
Part 25.1: Memoization, Tabulation, and Repeated Work, starting slide 2.
Part 25.2: Optimization States and Reconstructed Solutions, starting slide 17.
Part 25.3: Backtracking, Pruning, and Search States, starting slide 32.
Each core part is a reading unit; follow the current three-meeting allocation rather than add one meeting per part. Supporting parts are explicitly optional. Quick-check and Your turn answers remain in these instructor notes; the student HTML omits them. All complete C# examples are standalone and recorded in the code verification manifest.
-->

---

<!-- _class: section -->

# 25.1. Memoization, Tabulation, and Repeated Work

Computer Science in C#

<!--
This part addresses define a complete subproblem state, compare recursion, caching, and table order, separate computed states from all calls. Read 2501_memoization_tabulation.html with the worked examples. Use the selected trace and nearby practice within the chapter's existing meeting allocation; this part is a reading unit, not an extra required meeting.
-->

---

## Goals for this part

- Define a complete subproblem state
- Compare recursion, caching, and table order
- Separate computed states from all calls

<!--
Connect these goals to the chapter objectives before starting. The running case is: A planning recurrence revisits the same Fibonacci subproblems. Saving answers avoids recomputation, but a call hitting the cache is still a call. Ask learners to predict one result before execution. Revisit the same contract at the recap rather than introducing an unrelated API tour.
-->

---

## State the business question

A planning recurrence revisits the same Fibonacci subproblems. Saving answers avoids recomputation, but a call hitting the cache is still a call.

<!--
Ask which result the stakeholder actually needs. F(0)=0 and F(1)=1 define the base values. A faster program is useful only when it still answers that question. Ask students to name one input or policy that would change the answer, then introduce the contract.
-->

---

## Make the contract explicit

- F(0)=0 and F(1)=1 define the base values.
- A cache key must identify every remaining choice.
- A table fills dependencies before their users.

<!--
Explain each obligation in the running case. Before table entry i is filled, all entries it depends on are already correct. Rolling state retains those dependencies but not the whole history. Separate what clients can rely on from representation details. Ask what a missing, empty, tied, or invalid input means before moving to the trace.
-->

---

## Trace one small instance

| Method for F(5) | Reused state idea |
| --- | --- |
| Naive recursion | Recomputes overlapping calls |
| Memoization | Compute each missing index once |
| Tabulation | Fill indices zero through five |
| Rolling state | Retain only the two previous values |

<!--
Walk the rows in order and pause before revealing the next state on screen. The first line is F(8); the second records the F(0) base expected in a boundary check. Rolling state stores only two consecutive recurrence values, so it cannot return the full table afterward. The table records a logical trace; distinguish any sorted presentation view from physical storage layout. Ask a learner to justify one transition using the stated contract.
-->

---

## Follow the mechanism

- Write state, base cases, and recurrence before storage.
- Count calls, hits, and non-base computations consistently.
- Choose sparse caching or dense tables from the reachable state space.

<!--
Tie every step to a state change in the preceding trace. Before table entry i is filled, all entries it depends on are already correct. Rolling state retains those dependencies but not the whole history. Ask which step would fail if omitted or moved. The complete implementation stays in the lesson so the slide can focus on the algorithm's own progress rather than long support classes.
-->

---

## Keep the invariant in view

Before table entry i is filled, all entries it depends on are already correct. Rolling state retains those dependencies but not the whole history.

<!--
Name the exact program point where this statement applies. Contrast initialization, one update, and the exit condition. Do not call a printed success message a proof. Use the verification slide later to distinguish a check on a few examples from the general argument.
-->

---

## Run the small model

```csharp
using System;
static long Fib(int n) {
    if (n < 0) throw new ArgumentOutOfRangeException(nameof(n));
    long previous = 0, current = 1;
    for (int i = 0; i < n; i++) {
        long next = checked(previous + current);
        previous = current; current = next;
    } return previous;
}
Console.WriteLine(Fib(8));
Console.WriteLine(Fib(0));
```

```output
21
0
```

<!--
Before running, ask learners to predict the complete output. Run this standalone cell in a fresh C# application; it requires no previous cell. The first line is F(8); the second records the F(0) base expected in a boundary check. Rolling state stores only two consecutive recurrence values, so it cannot return the full table afterward. If the demo environment fails, read the verified output and continue with the trace rather than spending the meeting on tool setup.
-->

---

## Explain the observed result

The first line is F(8); the second records the F(0) base expected in a boundary check. Rolling state stores only two consecutive recurrence values, so it cannot return the full table afterward.

<!--
Ask learners to connect the output to the contract, not just read the numbers aloud. Before table entry i is filled, all entries it depends on are already correct. Rolling state retains those dependencies but not the whole history. Invite one controlled input change and predict its effect first. The worked output is evidence for this instance; the invariant and assumptions explain the broader claim.
-->

---

<!-- _class: check -->

## Quick check 1

Does memoization make every cache request disappear?

1. Yes
2. No; hits are calls that avoid recomputation
3. Only when inputs are random

<!--
Give 30 seconds individually, then compare with a neighbor. Answer: B. Distinguish call count from the number of states whose recurrence body is evaluated. Ask for the reason, not only the letter. If a common wrong choice dominates, replay the contract or trace before proceeding.
-->

---

## Boundaries are part of the model

- Zero must follow the declared base case.
- Checked arithmetic exposes numeric limits.
- Changing the counting recurrence may change bases without changing the recurrence shape.

<!--
Choose one boundary and ask for an independently expected result. Check small inputs against an independent table or hand trace. Distinguish a legal empty result from an invalid input. Do not silently change the contract to make a failing test disappear.
-->

---

<!-- _class: check -->

## Quick check 2

Which table order computes F(i)=F(i-1)+F(i-2) safely?

1. Increasing index after the bases
2. Decreasing index from an empty table
3. Arbitrary order without checking dependencies

<!--
Poll for a prediction before revealing any explanation. Answer: A. Filling a state before its predecessor values exist reads defaults, not the recurrence's mathematical answers. Link the distinction to the business case. Use a brief counterexample when a learner treats an assumption as a universal guarantee.
-->

---

<!-- _class: yourturn -->

## Your turn: Exercise: Count Repeated Subproblems

- Trace calls and cache hits for a small n.
- Compare the same input across methods.
- Explain what rolling state gives up.

[Open the section practice](2501_memoization_tabulation.html)

<!--
Allow three to five minutes in pairs. This practice is drawn from the section's actual exercise; it does not create a new assessment ID. Answer and debrief: Use the same call-count convention, including base and cache-hit calls. Rolling state reduces retained auxiliary values but loses the complete history unless outputs are separately stored. Ask learners to show their trace or checks before consulting the lesson solution. Assess reasoning as well as printed output.
-->

---

## Verify before recommending

- Check small inputs against an independent table or hand trace.
- Count retained states separately from requested calls.
- Do not infer constant storage merely because each state is computed once.

<!--
Ask learners to separate implementation checks, model assumptions, and performance claims. A. Filling a state before its predecessor values exist reads defaults, not the recurrence's mathematical answers. Relate the requested evidence to the chapter lab/homework without changing their stable identities or making supporting readings silently compulsory.
-->

---

<!-- _class: recap -->

## Recap

- Define a complete subproblem state
- Compare recursion, caching, and table order
- Separate computed states from all calls

[Continue with the lesson and exercises](2501_memoization_tabulation.html)

<!--
Invite a learner to explain one goal using the worked case. The first line is F(8); the second records the F(0) base expected in a boundary check. Rolling state stores only two consecutive recurrence values, so it cannot return the full table afterward. Exit question: what input, representation, or contract change would require a new argument? Use the current assignment route and chapter schedule to select follow-up practice.
-->

---

<!-- _class: section -->

# 25.2. Optimization States and Reconstructed Solutions

Computer Science in C#

<!--
This part addresses derive a minimum-count recurrence, represent unreachable states explicitly, recover and validate an optimal witness. Read 2502_optimization_models.html with the worked examples. Use the selected trace and nearby practice within the chapter's existing meeting allocation; this part is a reading unit, not an extra required meeting.
-->

---

## Goals for this part

- Derive a minimum-count recurrence
- Represent unreachable states explicitly
- Recover and validate an optimal witness

<!--
Connect these goals to the chapter objectives before starting. The running case is: A buyer requests six units using reusable pack sizes one, three, and four. Largest-first takes three packs, while the optimum uses two threes. Ask learners to predict one result before execution. Revisit the same contract at the recap rather than introducing an unrelated API tour.
-->

---

## State the business question

A buyer requests six units using reusable pack sizes one, three, and four. Largest-first takes three packs, while the optimum uses two threes.

<!--
Ask which result the stakeholder actually needs. B(0)=0 means an empty valid plan. A faster program is useful only when it still answers that question. Ask students to name one input or policy that would change the answer, then introduce the contract.
-->

---

## Make the contract explicit

- B(0)=0 means an empty valid plan.
- A missing state means unreachable, not zero cost.
- Only positive reusable pack sizes preserve smaller predecessor amounts.

<!--
Explain each obligation in the running case. A finite B(a) has a predecessor chain ending at zero. Checking its sum and count is separate from trusting the number in the last table cell. Separate what clients can rely on from representation details. Ask what a missing, empty, tied, or invalid input means before moving to the trace.
-->

---

## Trace one small instance

| Amount | B(amount) for sizes 1,3,4 | One predecessor |
| ---: | ---: | --- |
| 0 | 0 | Base |
| 3 | 1 | 0 + pack 3 |
| 4 | 1 | 0 + pack 4 |
| 6 | 2 | 3 + pack 3 |

<!--
Walk the rows in order and pause before revealing the next state on screen. Two packs suffice, and the independent witness 3+3 has the requested amount. This small bounded demo uses 99 above every possible valid count; the full lesson represents unreachable states explicitly. The table records a logical trace; distinguish any sorted presentation view from physical storage layout. Ask a learner to justify one transition using the stated contract.
-->

---

## Follow the mechanism

- For amount a, inspect legal predecessor amounts a-size.
- Choose the smallest predecessor count plus one.
- Store the chosen size if a witness must be reconstructed.

<!--
Tie every step to a state change in the preceding trace. A finite B(a) has a predecessor chain ending at zero. Checking its sum and count is separate from trusting the number in the last table cell. Ask which step would fail if omitted or moved. The complete implementation stays in the lesson so the slide can focus on the algorithm's own progress rather than long support classes.
-->

---

## Keep the invariant in view

A finite B(a) has a predecessor chain ending at zero. Checking its sum and count is separate from trusting the number in the last table cell.

<!--
Name the exact program point where this statement applies. Contrast initialization, one update, and the exit condition. Do not call a printed success message a proof. Use the verification slide later to distinguish a check on a few examples from the general argument.
-->

---

## Run the small model

```csharp
using System;
int[] sizes = { 1, 3, 4 }; int target = 6;
int[] best = new int[target + 1]; Array.Fill(best, 99); best[0] = 0;
for (int amount = 1; amount <= target; amount++)
    foreach (int size in sizes)
        if (size <= amount)
            best[amount] = Math.Min(best[amount], best[amount-size]+1);
Console.WriteLine(best[target]);
Console.WriteLine(3 + 3);
```

```output
2
6
```

<!--
Before running, ask learners to predict the complete output. Run this standalone cell in a fresh C# application; it requires no previous cell. Two packs suffice, and the independent witness 3+3 has the requested amount. This small bounded demo uses 99 above every possible valid count; the full lesson represents unreachable states explicitly. If the demo environment fails, read the verified output and continue with the trace rather than spending the meeting on tool setup.
-->

---

## Explain the observed result

Two packs suffice, and the independent witness 3+3 has the requested amount. This small bounded demo uses 99 above every possible valid count; the full lesson represents unreachable states explicitly.

<!--
Ask learners to connect the output to the contract, not just read the numbers aloud. A finite B(a) has a predecessor chain ending at zero. Checking its sum and count is separate from trusting the number in the last table cell. Invite one controlled input change and predict its effect first. The worked output is evidence for this instance; the invariant and assumptions explain the broader claim.
-->

---

<!-- _class: check -->

## Quick check 1

What does B(0)=0 represent?

1. An unreachable request
2. A valid empty plan
3. A request that needs one arbitrary pack

<!--
Give 30 seconds individually, then compare with a neighbor. Answer: B. Zero units needs no packs. Conflating this with unreachable states breaks both recurrence initialization and witness interpretation. Ask for the reason, not only the letter. If a common wrong choice dominates, replay the contract or trace before proceeding.
-->

---

## Boundaries are part of the model

- Normalize duplicate denominations without changing reusable inventory.
- Reject nonpositive denomination sizes.
- Table size depends on numeric target, so a small input description can still create a large table.

<!--
Choose one boundary and ask for an independently expected result. Compare with an independent small exhaustive or amount-level reference. Distinguish a legal empty result from an invalid input. Do not silently change the contract to make a failing test disappear.
-->

---

<!-- _class: check -->

## Quick check 2

Can a reusable-pack solution be applied unchanged to one-use invoices?

1. Yes, since amounts are integers
2. No; remaining inventory changes the state
3. Only if every value is positive

<!--
Poll for a prediction before revealing any explanation. Answer: B. An amount-only state forgets which positions remain available. One-use search needs additional ownership information. Link the distinction to the business case. Use a brief counterexample when a learner treats an assumption as a universal guarantee.
-->

---

<!-- _class: yourturn -->

## Your turn: Exercise: Validate Pack Contracts

- Test zero, unreachable, and duplicate denominations.
- Reject an invalid nonpositive size.
- Explain reusable versus one-use state.

[Open the section practice](2502_optimization_models.html)

<!--
Allow three to five minutes in pairs. This practice is drawn from the section's actual exercise; it does not create a new assessment ID. Answer and debrief: Zero target has an empty valid witness. For reusable sizes 2,5,5, normalize duplicates; target one is unreachable. A nonpositive denomination breaks the strictly-smaller predecessor reasoning. One-use invoices need position/inventory information. Ask learners to show their trace or checks before consulting the lesson solution. Assess reasoning as well as printed output.
-->

---

## Verify before recommending

- Compare with an independent small exhaustive or amount-level reference.
- Distinguish feasibility checks from optimality reasoning.
- Account for the numeric target, retained predecessor data, and output plan size.

<!--
Ask learners to separate implementation checks, model assumptions, and performance claims. B. An amount-only state forgets which positions remain available. One-use search needs additional ownership information. Relate the requested evidence to the chapter lab/homework without changing their stable identities or making supporting readings silently compulsory.
-->

---

<!-- _class: recap -->

## Recap

- Derive a minimum-count recurrence
- Represent unreachable states explicitly
- Recover and validate an optimal witness

[Continue with the lesson and exercises](2502_optimization_models.html)

<!--
Invite a learner to explain one goal using the worked case. Two packs suffice, and the independent witness 3+3 has the requested amount. This small bounded demo uses 99 above every possible valid count; the full lesson represents unreachable states explicitly. Exit question: what input, representation, or contract change would require a new argument? Use the current assignment route and chapter schedule to select follow-up practice.
-->

---

<!-- _class: section -->

# 25.3. Backtracking, Pruning, and Search States

Computer Science in C#

<!--
This part addresses keep one-use positions in the state, prove pruning rules for signed values, restore shared state before sibling branches. Read 2503_backtracking.html with the worked examples. Use the selected trace and nearby practice within the chapter's existing meeting allocation; this part is a reading unit, not an extra required meeting.
-->

---

## Goals for this part

- Keep one-use positions in the state
- Prove pruning rules for signed values
- Restore shared state before sibling branches

<!--
Connect these goals to the chapter objectives before starting. The running case is: Invoice amounts 8,-3,4,4 include a credit and two distinct four-unit records. Find a one-use subset totaling five. Ask learners to predict one result before execution. Revisit the same contract at the recap rather than introducing an unrelated API tour.
-->

---

## State the business question

Invoice amounts 8,-3,4,4 include a credit and two distinct four-unit records. Find a one-use subset totaling five.

<!--
Ask which result the stakeholder actually needs. Each position may be chosen at most once. A faster program is useful only when it still answers that question. Ask students to name one input or policy that would change the answer, then introduce the contract.
-->

---

## Make the contract explicit

- Each position may be chosen at most once.
- Equal numeric values can identify different records.
- A failed-state cache key includes position and remaining amount.

<!--
Explain each obligation in the running case. Negative remaining amount is not failure when later credits can reduce the sum. A prune needs a bound that remains valid for all remaining choices. Separate what clients can rely on from representation details. Ask what a missing, empty, tied, or invalid input means before moving to the trace.
-->

---

## Trace one small instance

| Choice | Selected positions | Remaining amount |
| --- | --- | ---: |
| Start | none | 5 |
| Include position 0:8 | 0 | -3 |
| Include position 1:-3 | 0,1 | 0 |
| Witness | amounts 8,-3 | Sum 5 |

<!--
Walk the rows in order and pause before revealing the next state on screen. Mask three chooses positions zero and one: 8 plus -3. Mask fourteen chooses -3 and both distinct four-unit records. This small exhaustive reference checks backtracking independently instead of sharing its prune logic. The table records a logical trace; distinguish any sorted presentation view from physical storage layout. Ask a learner to justify one transition using the stated contract.
-->

---

## Follow the mechanism

- Choose one position, explore its children, then undo its own choice.
- Use suffix negative/positive sums to bound achievable remaining amounts.
- Copy completed witnesses before later mutation of shared partial state.

<!--
Tie every step to a state change in the preceding trace. Negative remaining amount is not failure when later credits can reduce the sum. A prune needs a bound that remains valid for all remaining choices. Ask which step would fail if omitted or moved. The complete implementation stays in the lesson so the slide can focus on the algorithm's own progress rather than long support classes.
-->

---

## Keep the invariant in view

Negative remaining amount is not failure when later credits can reduce the sum. A prune needs a bound that remains valid for all remaining choices.

<!--
Name the exact program point where this statement applies. Contrast initialization, one update, and the exit condition. Do not call a printed success message a proof. Use the verification slide later to distinguish a check on a few examples from the general argument.
-->

---

## Run the small model

```csharp
using System;
int[] invoice = { 8, -3, 4, 4 }; long target = 5; int witnesses = 0;
for (int mask = 0; mask < (1 << invoice.Length); mask++) {
    long sum = 0;
    for (int i = 0; i < invoice.Length; i++)
        if ((mask & (1 << i)) != 0) sum += invoice[i];
    if (sum == target) { Console.WriteLine(mask); witnesses++; }
}
Console.WriteLine($"witnesses={witnesses}");
```

```output
3
14
witnesses=2
```

<!--
Before running, ask learners to predict the complete output. Run this standalone cell in a fresh C# application; it requires no previous cell. Mask three chooses positions zero and one: 8 plus -3. Mask fourteen chooses -3 and both distinct four-unit records. This small exhaustive reference checks backtracking independently instead of sharing its prune logic. If the demo environment fails, read the verified output and continue with the trace rather than spending the meeting on tool setup.
-->

---

## Explain the observed result

Mask three chooses positions zero and one: 8 plus -3. Mask fourteen chooses -3 and both distinct four-unit records. This small exhaustive reference checks backtracking independently instead of sharing its prune logic.

<!--
Ask learners to connect the output to the contract, not just read the numbers aloud. Negative remaining amount is not failure when later credits can reduce the sum. A prune needs a bound that remains valid for all remaining choices. Invite one controlled input change and predict its effect first. The worked output is evidence for this instance; the invariant and assumptions explain the broader claim.
-->

---

<!-- _class: check -->

## Quick check 1

Why is amount-only memoization unsafe for one-use invoices?

1. Different remaining positions can have different answers
2. All sums must be negative
3. A dictionary cannot store amounts

<!--
Give 30 seconds individually, then compare with a neighbor. Answer: A. The same remaining amount at two positions can have different available records. Position is part of the complete state. Ask for the reason, not only the letter. If a common wrong choice dominates, replay the contract or trace before proceeding.
-->

---

## Boundaries are part of the model

- Empty input has one empty subset and one empty permutation.
- Duplicate labels do not merge distinct positions.
- Budget exhaustion means unknown unless the search completed its proof.

<!--
Choose one boundary and ask for an independently expected result. Validate every position is legal and used at most once. Distinguish a legal empty result from an invalid input. Do not silently change the contract to make a failing test disappear.
-->

---

<!-- _class: check -->

## Quick check 2

When saving a completed mutable selection, what should be stored?

1. The same list reference for every result
2. An independent snapshot of the chosen positions
3. Only the number of later branches

<!--
Poll for a prediction before revealing any explanation. Answer: B. Otherwise later undo operations mutate previously saved results. Copy at the moment the witness is complete. Link the distinction to the business case. Use a brief counterexample when a learner treats an assumption as a universal guarantee.
-->

---

<!-- _class: yourturn -->

## Your turn: Practice: Validate Search Evidence

- Check empty input and zero target.
- Validate unreachable requests and witness snapshots.
- Distinguish a completed failure proof from a budget limit.

[Open the section practice](2503_backtracking.html)

<!--
Allow three to five minutes in pairs. This practice is drawn from the section's actual exercise; it does not create a new assessment ID. Answer and debrief: Empty input with target zero succeeds with the empty witness. A later undo must not mutate a saved snapshot. An exhausted budget leaves the answer unknown; only completed exhaustive/pruned reasoning can establish infeasibility. Ask learners to show their trace or checks before consulting the lesson solution. Assess reasoning as well as printed output.
-->

---

## Verify before recommending

- Validate every position is legal and used at most once.
- Check small infeasible and credit-containing cases independently.
- Include output enumeration and saved witness size in time/space explanations.

<!--
Ask learners to separate implementation checks, model assumptions, and performance claims. B. Otherwise later undo operations mutate previously saved results. Copy at the moment the witness is complete. Relate the requested evidence to the chapter lab/homework without changing their stable identities or making supporting readings silently compulsory.
-->

---

<!-- _class: recap -->

## Recap

- Keep one-use positions in the state
- Prove pruning rules for signed values
- Restore shared state before sibling branches

[Continue with the lesson and exercises](2503_backtracking.html)

<!--
Invite a learner to explain one goal using the worked case. Mask three chooses positions zero and one: 8 plus -3. Mask fourteen chooses -3 and both distinct four-unit records. This small exhaustive reference checks backtracking independently instead of sharing its prune logic. Exit question: what input, representation, or contract change would require a new argument? Use the current assignment route and chapter schedule to select follow-up practice.
-->
