---
marp: true
theme: thinkpress-lecture
paginate: true
title: "Chapter 26: String Matching and Computational Limits"
book: "Computer Science in C#"
section: "Chapter 26"
primary: "#2a6b37"
accent: "#b8860b"
---

<!-- _class: title -->

# 26. String Matching and Computational Limits

Computer Science in C#

Contracts, worked traces, practice, and verified examples.

<!--
Chapter 26: String Matching and Computational Limits.
Existing 110-minute chapter allocation: 35 minutes direct matching;40 minutes prefix reuse;35 minutes limits/coverage. Chapter 20 graph review is preparation for the synthesis assignments.
Part 26.1: Direct String Matching and Result Contracts, starting slide 2.
Part 26.2: Prefix Reuse and KMP, starting slide 17.
Part 26.3: Algorithms and Computational Limits, starting slide 32.
Each core part is a reading unit; follow the current three-meeting allocation rather than add one meeting per part. Supporting parts are explicitly optional. Quick-check and Your turn answers remain in these instructor notes; the student HTML omits them. All complete C# examples are standalone and recorded in the code verification manifest.
-->

---

<!-- _class: section -->

# 26.1. Direct String Matching and Result Contracts

Computer Science in C#

<!--
This part addresses define ordinal, overlap, and empty-pattern policies, separate candidate start from matched length, verify every returned position. Read 2601_shortest_paths_strings.html with the worked examples. Use the selected trace and nearby practice within the chapter's existing meeting allocation; this part is a reading unit, not an extra required meeting.
-->

---

## Goals for this part

- Define ordinal, overlap, and empty-pattern policies
- Separate candidate start from matched length
- Verify every returned position

<!--
Connect these goals to the chapter objectives before starting. The running case is: A service message contains repeated Alert-like patterns. The report needs all overlapping occurrences, not just the first convenient match. Ask learners to predict one result before execution. Revisit the same contract at the recap rather than introducing an unrelated API tour.
-->

---

## State the business question

A service message contains repeated Alert-like patterns. The report needs all overlapping occurrences, not just the first convenient match.

<!--
Ask which result the stakeholder actually needs. Positions count ordinal UTF-16 code units. A faster program is useful only when it still answers that question. Ask students to name one input or policy that would change the answer, then introduce the contract.
-->

---

## Make the contract explicit

- Positions count ordinal UTF-16 code units.
- A nonempty pattern may start through n-m when m is at most n.
- An empty pattern matches every boundary from zero through n.

<!--
Explain each obligation in the running case. The checked prefix at a candidate start is evidence about that start. A mismatch does not authorize skipping arbitrary future starts. Separate what clients can rely on from representation details. Ask what a missing, empty, tied, or invalid input means before moving to the trace.
-->

---

## Trace one small instance

| Text abababa, pattern aba | Candidate result |
| ---: | --- |
| 0 | Match |
| 1 | First character differs |
| 2 | Match overlapping the first |
| 3 | First character differs |
| 4 | Match |

<!--
Walk the rows in order and pause before revealing the next state on screen. The three matches overlap, and the eight boundaries include both ends of the seven-unit text. The contract must state whether callers want all matches or a first-result API. The table records a logical trace; distinguish any sorted presentation view from physical storage layout. Ask a learner to justify one transition using the stated contract.
-->

---

## Follow the mechanism

- For each legal start, reset matched length to zero.
- Advance within the pattern while characters agree.
- Report the start only when the whole pattern matched.

<!--
Tie every step to a state change in the preceding trace. The checked prefix at a candidate start is evidence about that start. A mismatch does not authorize skipping arbitrary future starts. Ask which step would fail if omitted or moved. The complete implementation stays in the lesson so the slide can focus on the algorithm's own progress rather than long support classes.
-->

---

## Keep the invariant in view

The checked prefix at a candidate start is evidence about that start. A mismatch does not authorize skipping arbitrary future starts.

<!--
Name the exact program point where this statement applies. Contrast initialization, one update, and the exit condition. Do not call a printed success message a proof. Use the verification slide later to distinguish a check on a few examples from the general argument.
-->

---

## Run the small model

```csharp
using System; using System.Collections.Generic;
string text = "abababa", pattern = "aba";
var positions = new List<int>();
for (int start = 0; start <= text.Length - pattern.Length; start++) {
    int k = 0;
    while (k < pattern.Length && text[start + k] == pattern[k]) k++;
    if (k == pattern.Length) positions.Add(start);
}
Console.WriteLine(string.Join(",", positions));
Console.WriteLine($"empty-pattern boundaries={text.Length + 1}");
```

```output
0,2,4
empty-pattern boundaries=8
```

<!--
Before running, ask learners to predict the complete output. Run this standalone cell in a fresh C# application; it requires no previous cell. The three matches overlap, and the eight boundaries include both ends of the seven-unit text. The contract must state whether callers want all matches or a first-result API. If the demo environment fails, read the verified output and continue with the trace rather than spending the meeting on tool setup.
-->

---

## Explain the observed result

The three matches overlap, and the eight boundaries include both ends of the seven-unit text. The contract must state whether callers want all matches or a first-result API.

<!--
Ask learners to connect the output to the contract, not just read the numbers aloud. The checked prefix at a candidate start is evidence about that start. A mismatch does not authorize skipping arbitrary future starts. Invite one controlled input change and predict its effect first. The worked output is evidence for this instance; the invariant and assumptions explain the broader claim.
-->

---

<!-- _class: check -->

## Quick check 1

A text has length seven and pattern length three. What is the last possible start?

1. Four
2. Six
3. Seven

<!--
Give 30 seconds individually, then compare with a neighbor. Answer: A. The pattern needs three remaining code units. Starting later would read beyond the text. Ask for the reason, not only the letter. If a common wrong choice dominates, replay the contract or trace before proceeding.
-->

---

## Boundaries are part of the model

- Longer-than-text nonempty patterns have no candidates.
- Empty text with empty pattern has one boundary.
- Uppercase and lowercase differ under ordinal matching.

<!--
Choose one boundary and ask for an independently expected result. Check every reported substring and legal offset. Distinguish a legal empty result from an invalid input. Do not silently change the contract to make a failing test disappear.
-->

---

<!-- _class: check -->

## Quick check 2

Do ordinal offsets always equal user-perceived character positions?

1. Yes
2. No; one displayed character can use several UTF-16 units
3. Only when the pattern is empty

<!--
Poll for a prediction before revealing any explanation. Answer: B. State the unit. User-facing grapheme or culture-aware requirements call for different APIs and contracts. Link the distinction to the business case. Use a brief counterexample when a learner treats an assumption as a universal guarantee.
-->

---

<!-- _class: yourturn -->

## Your turn: Exercise: Verify Direct Matches

- Trace comparisons at each candidate start.
- Include overlap, absence, empty, and longer patterns.
- Check returned starts against a separate reference.

[Open the section practice](2601_shortest_paths_strings.html)

<!--
Allow three to five minutes in pairs. This practice is drawn from the section's actual exercise; it does not create a new assessment ID. Answer and debrief: For abababa and aba the starts are zero,two,four. An empty pattern matches every boundary; longer patterns return no matches. Verify complete positions rather than only a found/not-found Boolean. Ask learners to show their trace or checks before consulting the lesson solution. Assess reasoning as well as printed output.
-->

---

## Verify before recommending

- Check every reported substring and legal offset.
- Compare first results with StringComparison.Ordinal.
- Reuse Chapter 20 graph contracts explicitly for network-synthesis assignments; they are prerequisite review.

<!--
Ask learners to separate implementation checks, model assumptions, and performance claims. B. State the unit. User-facing grapheme or culture-aware requirements call for different APIs and contracts. Relate the requested evidence to the chapter lab/homework without changing their stable identities or making supporting readings silently compulsory.
-->

---

<!-- _class: recap -->

## Recap

- Define ordinal, overlap, and empty-pattern policies
- Separate candidate start from matched length
- Verify every returned position

[Continue with the lesson and exercises](2601_shortest_paths_strings.html)

<!--
Invite a learner to explain one goal using the worked case. The three matches overlap, and the eight boundaries include both ends of the seven-unit text. The contract must state whether callers want all matches or a first-result API. Exit question: what input, representation, or contract change would require a new argument? Use the current assignment route and chapter schedule to select follow-up practice.
-->

---

<!-- _class: section -->

# 26.2. Prefix Reuse and KMP

Computer Science in C#

<!--
This part addresses build the proper-prefix fallback table, preserve overlap after a full match, count preparation and each scan separately. Read 2602_prefix_matching.html with the worked examples. Use the selected trace and nearby practice within the chapter's existing meeting allocation; this part is a reading unit, not an extra required meeting.
-->

---

## Goals for this part

- Build the proper-prefix fallback table
- Preserve overlap after a full match
- Count preparation and each scan separately

<!--
Connect these goals to the chapter objectives before starting. The running case is: Two repetitive activity messages share the pattern aaaaab. Preparing its prefix evidence once can avoid restarting every earlier text comparison. Ask learners to predict one result before execution. Revisit the same contract at the recap rather than introducing an unrelated API tour.
-->

---

## State the business question

Two repetitive activity messages share the pattern aaaaab. Preparing its prefix evidence once can avoid restarting every earlier text comparison.

<!--
Ask which result the stakeholder actually needs. prefix[i] is the longest proper prefix also a suffix through i. A faster program is useful only when it still answers that question. Ask students to name one input or policy that would change the answer, then introduce the contract.
-->

---

## Make the contract explicit

- prefix[i] is the longest proper prefix also a suffix through i.
- A mismatch follows prefix[matched-1] rather than moving the text backward.
- After a full match, fallback preserves overlapping candidates.

<!--
Explain each obligation in the running case. A retained suffix must be equal to a pattern prefix, not merely share its length. This proof is what makes the skipped comparisons safe. Separate what clients can rely on from representation details. Ask what a missing, empty, tied, or invalid input means before moving to the trace.
-->

---

## Trace one small instance

| Pattern ababa position | Prefix length |
| ---: | ---: |
| 0:a | 0 |
| 1:b | 0 |
| 2:a | 1 |
| 3:b | 2 |
| 4:a | 3 |

<!--
Walk the rows in order and pause before revealing the next state on screen. The full pattern ends with aba, a proper prefix of length three. The second line confirms that a displayed emoji plus A occupies three UTF-16 code units under the stated C# string model. The table records a logical trace; distinguish any sorted presentation view from physical storage layout. Ask a learner to justify one transition using the stated contract.
-->

---

## Follow the mechanism

- Build fallback evidence from earlier pattern positions.
- On mismatch, reduce the proven matched length.
- Advance the text index only when the scan has consumed or rejected its current unit.

<!--
Tie every step to a state change in the preceding trace. A retained suffix must be equal to a pattern prefix, not merely share its length. This proof is what makes the skipped comparisons safe. Ask which step would fail if omitted or moved. The complete implementation stays in the lesson so the slide can focus on the algorithm's own progress rather than long support classes.
-->

---

## Keep the invariant in view

A retained suffix must be equal to a pattern prefix, not merely share its length. This proof is what makes the skipped comparisons safe.

<!--
Name the exact program point where this statement applies. Contrast initialization, one update, and the exit condition. Do not call a printed success message a proof. Use the verification slide later to distinguish a check on a few examples from the general argument.
-->

---

## Run the small model

```csharp
using System;
string pattern = "ababa"; int[] prefix = new int[pattern.Length];
for (int i = 1, j = 0; i < pattern.Length; i++) {
    while (j > 0 && pattern[i] != pattern[j]) j = prefix[j - 1];
    if (pattern[i] == pattern[j]) j++;
    prefix[i] = j;
}
Console.WriteLine(string.Join(",", prefix));
Console.WriteLine("😀A".Length);
```

```output
0,0,1,2,3
3
```

<!--
Before running, ask learners to predict the complete output. Run this standalone cell in a fresh C# application; it requires no previous cell. The full pattern ends with aba, a proper prefix of length three. The second line confirms that a displayed emoji plus A occupies three UTF-16 code units under the stated C# string model. If the demo environment fails, read the verified output and continue with the trace rather than spending the meeting on tool setup.
-->

---

## Explain the observed result

The full pattern ends with aba, a proper prefix of length three. The second line confirms that a displayed emoji plus A occupies three UTF-16 code units under the stated C# string model.

<!--
Ask learners to connect the output to the contract, not just read the numbers aloud. A retained suffix must be equal to a pattern prefix, not merely share its length. This proof is what makes the skipped comparisons safe. Invite one controlled input change and predict its effect first. The worked output is evidence for this instance; the invariant and assumptions explain the broader claim.
-->

---

<!-- _class: check -->

## Quick check 1

After matching aba in ababa, why fall back to prefix evidence?

1. To preserve the overlapping start at position two
2. To erase the text
3. To make matching case-insensitive

<!--
Give 30 seconds individually, then compare with a neighbor. Answer: A. The matched suffix a is also a pattern prefix. Restarting after the full matched span would miss the overlapping occurrence. Ask for the reason, not only the letter. If a common wrong choice dominates, replay the contract or trace before proceeding.
-->

---

## Boundaries are part of the model

- Handle empty patterns before indexing pattern[matched].
- Count mismatch checks, not only successful advances.
- Include result storage and output size in the complete bound.

<!--
Choose one boundary and ask for an independently expected result. Compare direct and KMP positions, including empty patterns. Distinguish a legal empty result from an invalid input. Do not silently change the contract to make a failing test disappear.
-->

---

<!-- _class: check -->

## Quick check 2

When searching two messages with one prepared pattern, what work is counted?

1. Preparation once plus both scans
2. Preparation twice but no scanning
3. Only the number of successful matches

<!--
Poll for a prediction before revealing any explanation. Answer: A. Reusing preparation changes the workload accounting. Each request still reads its own text and has its own comparison counter. Link the distinction to the business case. Use a brief counterexample when a learner treats an assumption as a universal guarantee.
-->

---

<!-- _class: yourturn -->

## Your turn: Exercise: Repair Prefix Fallback

- Trace the prefix table and a mismatch fallback.
- Run overlapping and repeated-prefix cases.
- Compare all positions with direct matching.

[Open the section practice](2602_prefix_matching.html)

<!--
Allow three to five minutes in pairs. This practice is drawn from the section's actual exercise; it does not create a new assessment ID. Answer and debrief: Use prefix[matched-1] when matched is nonzero. Preserve the text position while reducing the proved prefix; after a full match, retain the proper suffix before continuing. Never infer an arbitrary shift from one mismatch. Ask learners to show their trace or checks before consulting the lesson solution. Assess reasoning as well as printed output.
-->

---

## Verify before recommending

- Compare direct and KMP positions, including empty patterns.
- Record preparation and per-request counts separately.
- Use Chapter 20 BFS/DFS only for the separately identified graph-synthesis tasks.

<!--
Ask learners to separate implementation checks, model assumptions, and performance claims. A. Reusing preparation changes the workload accounting. Each request still reads its own text and has its own comparison counter. Relate the requested evidence to the chapter lab/homework without changing their stable identities or making supporting readings silently compulsory.
-->

---

<!-- _class: recap -->

## Recap

- Build the proper-prefix fallback table
- Preserve overlap after a full match
- Count preparation and each scan separately

[Continue with the lesson and exercises](2602_prefix_matching.html)

<!--
Invite a learner to explain one goal using the worked case. The full pattern ends with aba, a proper prefix of length three. The second line confirms that a displayed emoji plus A occupies three UTF-16 code units under the stated C# string model. Exit question: what input, representation, or contract change would require a new argument? Use the current assignment route and chapter schedule to select follow-up practice.
-->

---

<!-- _class: section -->

# 26.3. Algorithms and Computational Limits

Computer Science in C#

<!--
This part addresses validate exact and heuristic witnesses, distinguish feasibility from minimum objective value, limit claims to proved models and guarantees. Read 2603_limits_project.html with the worked examples. Use the selected trace and nearby practice within the chapter's existing meeting allocation; this part is a reading unit, not an extra required meeting.
-->

---

## Goals for this part

- Validate exact and heuristic witnesses
- Distinguish feasibility from minimum objective value
- Limit claims to proved models and guarantees

<!--
Connect these goals to the chapter objectives before starting. The running case is: A support manager must cover six required skills with as few teams as possible. A feasible greedy plan may use more teams than an exact plan. Ask learners to predict one result before execution. Revisit the same contract at the recap rather than introducing an unrelated API tour.
-->

---

## State the business question

A support manager must cover six required skills with as few teams as possible. A feasible greedy plan may use more teams than an exact plan.

<!--
Ask which result the stakeholder actually needs. A witness must use valid distinct team positions. A faster program is useful only when it still answers that question. Ask students to name one input or policy that would change the answer, then introduce the contract.
-->

---

## Make the contract explicit

- A witness must use valid distinct team positions.
- Coverage establishes feasibility, not necessarily optimality.
- Resource limits can leave the optimum unknown.

<!--
Explain each obligation in the running case. A successful witness proves the stated requirements are covered. An optimum requires a completed exact argument, and an approximation ratio requires a theorem under assumptions. Separate what clients can rely on from representation details. Ask what a missing, empty, tied, or invalid input means before moving to the trace.
-->

---

## Trace one small instance

| Team | Skill mask | Greedy consequence |
| --- | --- | --- |
| 0 | 001111 | First covers four skills |
| 1 | 010011 | Adds one missing skill |
| 2 | 101100 | Adds the final missing skill |
| Teams 1 and 2 together | 111111 | Two-team exact solution |

<!--
Walk the rows in order and pause before revealing the next state on screen. The exact enumeration finds two teams. Choosing the four-skill team first leaves two separate gaps, requiring all three teams for that greedy sequence. The table records a logical trace; distinguish any sorted presentation view from physical storage layout. Ask a learner to justify one transition using the stated contract.
-->

---

## Follow the mechanism

- Check the union of selected team masks independently.
- Compare objective counts only for feasible plans.
- Use exact small instances to challenge heuristic quality claims.

<!--
Tie every step to a state change in the preceding trace. A successful witness proves the stated requirements are covered. An optimum requires a completed exact argument, and an approximation ratio requires a theorem under assumptions. Ask which step would fail if omitted or moved. The complete implementation stays in the lesson so the slide can focus on the algorithm's own progress rather than long support classes.
-->

---

## Keep the invariant in view

A successful witness proves the stated requirements are covered. An optimum requires a completed exact argument, and an approximation ratio requires a theorem under assumptions.

<!--
Name the exact program point where this statement applies. Contrast initialization, one update, and the exit condition. Do not call a printed success message a proof. Use the verification slide later to distinguish a check on a few examples from the general argument.
-->

---

## Run the small model

```csharp
using System;
int[] teams = { 0b001111, 0b010011, 0b101100 }; int optimum = 99;
for (int mask = 0; mask < (1 << teams.Length); mask++) {
    int covered = 0, count = 0;
    for (int i = 0; i < teams.Length; i++)
        if ((mask & (1 << i)) != 0) { covered |= teams[i]; count++; }
    if (covered == 0b111111) optimum = Math.Min(optimum, count);
}
Console.WriteLine($"exact teams={optimum}");
int union = teams[0] | teams[1] | teams[2];
Console.WriteLine($"greedy first choice then both others covers={union}");
```

```output
exact teams=2
greedy first choice then both others covers=63
```

<!--
Before running, ask learners to predict the complete output. Run this standalone cell in a fresh C# application; it requires no previous cell. The exact enumeration finds two teams. Choosing the four-skill team first leaves two separate gaps, requiring all three teams for that greedy sequence. If the demo environment fails, read the verified output and continue with the trace rather than spending the meeting on tool setup.
-->

---

## Explain the observed result

The exact enumeration finds two teams. Choosing the four-skill team first leaves two separate gaps, requiring all three teams for that greedy sequence.

<!--
Ask learners to connect the output to the contract, not just read the numbers aloud. A successful witness proves the stated requirements are covered. An optimum requires a completed exact argument, and an approximation ratio requires a theorem under assumptions. Invite one controlled input change and predict its effect first. The worked output is evidence for this instance; the invariant and assumptions explain the broader claim.
-->

---

<!-- _class: check -->

## Quick check 1

What does an exponential enumeration implementation establish?

1. A cost claim about that implementation
2. An exponential lower bound for every possible algorithm
3. That no input has a solution

<!--
Give 30 seconds individually, then compare with a neighbor. Answer: A. Do not turn one algorithm's growth into a universal impossibility proof. State the computational model and what has actually been proved. Ask for the reason, not only the letter. If a common wrong choice dominates, replay the contract or trace before proceeding.
-->

---

## Boundaries are part of the model

- Zero required skills permit an empty plan.
- A partial union is not a full feasible cover.
- Exceeding an exact-search input budget is not proof of infeasibility.

<!--
Choose one boundary and ask for an independently expected result. Use exact BigInteger growth counts rather than overflowing integers. Distinguish a legal empty result from an invalid input. Do not silently change the contract to make a failing test disappear.
-->

---

<!-- _class: check -->

## Quick check 2

Several examples show a heuristic near optimum. Is that an approximation guarantee?

1. Yes
2. No; a proved ratio under stated assumptions is needed
3. Only when the code is short

<!--
Poll for a prediction before revealing any explanation. Answer: B. Empirical quality is useful evidence but cannot establish a worst-case approximation theorem. Link the distinction to the business case. Use a brief counterexample when a learner treats an assumption as a universal guarantee.
-->

---

<!-- _class: yourturn -->

## Your turn: Exercise: Verify the Cover Counterexample

- Validate all six required skill bits.
- Show why the best two-team cover is optimal.
- Reject an unknown requirement bit.

[Open the section practice](2603_limits_project.html)

<!--
Allow three to five minutes in pairs. This practice is drawn from the section's actual exercise; it does not create a new assessment ID. Answer and debrief: Teams one and two cover all six skills, while no single team covers all six, so optimum two is proved for this instance. Greedy first chooses team zero and then needs both others. A bit outside the declared six requirements is invalid input, not an extra implicit requirement. Ask learners to show their trace or checks before consulting the lesson solution. Assess reasoning as well as printed output.
-->

---

## Verify before recommending

- Use exact BigInteger growth counts rather than overflowing integers.
- Separate unknown, infeasible, feasible, and proved optimal states.
- Include preparation, repeated requests, storage, and output in the final recommendation.

<!--
Ask learners to separate implementation checks, model assumptions, and performance claims. B. Empirical quality is useful evidence but cannot establish a worst-case approximation theorem. Relate the requested evidence to the chapter lab/homework without changing their stable identities or making supporting readings silently compulsory.
-->

---

<!-- _class: recap -->

## Recap

- Validate exact and heuristic witnesses
- Distinguish feasibility from minimum objective value
- Limit claims to proved models and guarantees

[Continue with the lesson and exercises](2603_limits_project.html)

<!--
Invite a learner to explain one goal using the worked case. The exact enumeration finds two teams. Choosing the four-skill team first leaves two separate gaps, requiring all three teams for that greedy sequence. Exit question: what input, representation, or contract change would require a new argument? Use the current assignment route and chapter schedule to select follow-up practice.
-->
