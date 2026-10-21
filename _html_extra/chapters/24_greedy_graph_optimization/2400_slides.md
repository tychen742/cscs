---
marp: true
theme: thinkpress-lecture
paginate: true
title: "Chapter 24: Greedy Algorithms and Graph Optimization"
book: "Computer Science in C#"
section: "Chapter 24"
primary: "#2a6b37"
accent: "#b8860b"
---

<!-- _class: title -->

# 24. Greedy Algorithms and Graph Optimization

Computer Science in C#

Contracts, worked traces, practice, and verified examples.

<!--
Chapter 24: Greedy Algorithms and Graph Optimization.
Existing 110-minute chapter allocation: 35 minutes greedy scheduling;40 minutes forests;35 minutes shortest routes.
Part 24.1: Greedy Choices and Exchange Reasoning, starting slide 2.
Part 24.2: Minimum Spanning Forests and Kruskal, starting slide 17.
Part 24.3: Shortest Paths and Dijkstra, starting slide 32.
Each core part is a reading unit; follow the current three-meeting allocation rather than add one meeting per part. Supporting parts are explicitly optional. Quick-check and Your turn answers remain in these instructor notes; the student HTML omits them. All complete C# examples are standalone and recorded in the code verification manifest.
-->

---

<!-- _class: section -->

# 24.1. Greedy Choices and Exchange Reasoning

Computer Science in C#

<!--
This part addresses state the optimization objective, prove maximum-count interval scheduling, use counterexamples when the objective changes. Read 2401_greedy_choice.html with the worked examples. Use the selected trace and nearby practice within the chapter's existing meeting allocation; this part is a reading unit, not an extra required meeting.
-->

---

## Goals for this part

- State the optimization objective
- Prove maximum-count interval scheduling
- Use counterexamples when the objective changes

<!--
Connect these goals to the chapter objectives before starting. The running case is: A room manager wants the largest number of compatible positive-duration meetings. Choosing the highest-value meeting is a different objective. Ask learners to predict one result before execution. Revisit the same contract at the recap rather than introducing an unrelated API tour.
-->

---

## State the business question

A room manager wants the largest number of compatible positive-duration meetings. Choosing the highest-value meeting is a different objective.

<!--
Ask which result the stakeholder actually needs. Intervals are half-open: back-to-back meetings are compatible. A faster program is useful only when it still answers that question. Ask students to name one input or policy that would change the answer, then introduce the contract.
-->

---

## Make the contract explicit

- Intervals are half-open: back-to-back meetings are compatible.
- Every accepted interval has positive duration.
- The objective here is meeting count, not total value.

<!--
Explain each obligation in the running case. The selected schedule stays feasible. The exchange argument, not feasibility alone, establishes the maximum-count claim. Separate what clients can rely on from representation details. Ask what a missing, empty, tied, or invalid input means before moving to the trace.
-->

---

## Trace one small instance

| Finish order | Decision after B then C |
| --- | --- |
| B [0,2) | Accept, end=2 |
| C [2,3) | Accept, end=3 |
| A [0,4) | Reject, starts before 3 |
| D [3,5) | Accept, end=5 |

<!--
Walk the rows in order and pause before revealing the next state on screen. Three compatible meetings are selected. The example does not claim these meetings maximize revenue; changing values changes the optimization problem. The table records a logical trace; distinguish any sorted presentation view from physical storage layout. Ask a learner to justify one transition using the stated contract.
-->

---

## Follow the mechanism

- Sort candidates by earliest finishing time.
- Accept the next start at or after the last accepted end.
- Exchange an optimal first choice for an earlier finish without reducing the remaining count.

<!--
Tie every step to a state change in the preceding trace. The selected schedule stays feasible. The exchange argument, not feasibility alone, establishes the maximum-count claim. Ask which step would fail if omitted or moved. The complete implementation stays in the lesson so the slide can focus on the algorithm's own progress rather than long support classes.
-->

---

## Keep the invariant in view

The selected schedule stays feasible. The exchange argument, not feasibility alone, establishes the maximum-count claim.

<!--
Name the exact program point where this statement applies. Contrast initialization, one update, and the exit condition. Do not call a printed success message a proof. Use the verification slide later to distinguish a check on a few examples from the general argument.
-->

---

## Run the small model

```csharp
using System; using System.Linq;
(int Start, int End, string Id)[] meetings = {
    (0, 4, "A"), (0, 2, "B"), (2, 3, "C"), (3, 5, "D") };
int lastEnd = int.MinValue;
foreach (var meeting in meetings.OrderBy(m => m.End))
    if (meeting.Start >= lastEnd) {
        Console.WriteLine(meeting.Id); lastEnd = meeting.End;
    }
```

```output
B
C
D
```

<!--
Before running, ask learners to predict the complete output. Run this standalone cell in a fresh C# application; it requires no previous cell. Three compatible meetings are selected. The example does not claim these meetings maximize revenue; changing values changes the optimization problem. If the demo environment fails, read the verified output and continue with the trace rather than spending the meeting on tool setup.
-->

---

## Explain the observed result

Three compatible meetings are selected. The example does not claim these meetings maximize revenue; changing values changes the optimization problem.

<!--
Ask learners to connect the output to the contract, not just read the numbers aloud. The selected schedule stays feasible. The exchange argument, not feasibility alone, establishes the maximum-count claim. Invite one controlled input change and predict its effect first. The worked output is evidence for this instance; the invariant and assumptions explain the broader claim.
-->

---

<!-- _class: check -->

## Quick check 1

What does a non-overlap invariant prove by itself?

1. Feasibility
2. Global optimality for every objective
3. Constant runtime

<!--
Give 30 seconds individually, then compare with a neighbor. Answer: A. To claim maximum count, add the exchange reasoning. A feasible schedule can still have fewer meetings than another feasible one. Ask for the reason, not only the letter. If a common wrong choice dominates, replay the contract or trace before proceeding.
-->

---

## Boundaries are part of the model

- Empty input yields an empty schedule.
- Back-to-back equality is allowed by half-open intervals.
- Reject zero or negative duration before optimizing.

<!--
Choose one boundary and ask for an independently expected result. Check feasibility and objective value separately. Distinguish a legal empty result from an invalid input. Do not silently change the contract to make a failing test disappear.
-->

---

<!-- _class: check -->

## Quick check 2

A long booking pays more than several short bookings. Does earliest finish maximize value?

1. Always
2. No; the count proof does not establish maximum value
3. Only if values are printed

<!--
Poll for a prediction before revealing any explanation. Answer: B. A verified counterexample is enough to refute the changed universal claim. Preserve the original count theorem under its stated objective. Link the distinction to the business case. Use a brief counterexample when a learner treats an assumption as a universal guarantee.
-->

---

<!-- _class: yourturn -->

## Your turn: Exercise: Scheduling Boundaries

- Select a maximum-count compatible schedule.
- Include negative starts and back-to-back meetings.
- Reject a zero-duration booking and explain the exchange.

[Open the section practice](2401_greedy_choice.html)

<!--
Allow three to five minutes in pairs. This practice is drawn from the section's actual exercise; it does not create a new assessment ID. Answer and debrief: Half-open equality permits the next meeting to start at the previous end. A negative start is legal when duration is positive. Reject zero duration under the chosen contract; feasibility alone does not supply the maximum-count proof. Ask learners to show their trace or checks before consulting the lesson solution. Assess reasoning as well as printed output.
-->

---

## Verify before recommending

- Check feasibility and objective value separately.
- Verify small instances by exhaustive subsets.
- Include sorting preparation and the subsequent linear scan in cost claims.

<!--
Ask learners to separate implementation checks, model assumptions, and performance claims. B. A verified counterexample is enough to refute the changed universal claim. Preserve the original count theorem under its stated objective. Relate the requested evidence to the chapter lab/homework without changing their stable identities or making supporting readings silently compulsory.
-->

---

<!-- _class: recap -->

## Recap

- State the optimization objective
- Prove maximum-count interval scheduling
- Use counterexamples when the objective changes

[Continue with the lesson and exercises](2401_greedy_choice.html)

<!--
Invite a learner to explain one goal using the worked case. Three compatible meetings are selected. The example does not claim these meetings maximize revenue; changing values changes the optimization problem. Exit question: what input, representation, or contract change would require a new argument? Use the current assignment route and chapter schedule to select follow-up practice.
-->

---

<!-- _class: section -->

# 24.2. Minimum Spanning Forests and Kruskal

Computer Science in C#

<!--
This part addresses distinguish network cost from route cost, track union-find components, return a forest for disconnected input. Read 2402_spanning_trees_shortest_paths.html with the worked examples. Use the selected trace and nearby practice within the chapter's existing meeting allocation; this part is a reading unit, not an extra required meeting.
-->

---

## Goals for this part

- Distinguish network cost from route cost
- Track union-find components
- Return a forest for disconnected input

<!--
Connect these goals to the chapter objectives before starting. The running case is: A facilities team buys undirected cables to connect sites at minimum total cost. Remote has no possible cable and must remain a separate component. Ask learners to predict one result before execution. Revisit the same contract at the recap rather than introducing an unrelated API tour.
-->

---

## State the business question

A facilities team buys undirected cables to connect sites at minimum total cost. Remote has no possible cable and must remain a separate component.

<!--
Ask which result the stakeholder actually needs. Edges are undirected and connect known vertices. A faster program is useful only when it still answers that question. Ask students to name one input or policy that would change the answer, then introduce the contract.
-->

---

## Make the contract explicit

- Edges are undirected and connect known vertices.
- Negative cable weights are permitted by the model.
- Disconnected input returns a minimum spanning forest, not an invented spanning tree.

<!--
Explain each obligation in the running case. Union-find describes connectivity of accepted edges. It is not the chosen cable set itself, and path compression does not add graph edges. Separate what clients can rely on from representation details. Ask what a missing, empty, tied, or invalid input means before moving to the trace.
-->

---

## Trace one small instance

| Edge by increasing weight | Decision | Reason |
| --- | --- | --- |
| B-C:2 | Accept | Different components |
| C-D:3 | Accept | Different components |
| A-B:4 | Accept | Different components |
| A-C:6 | Reject | Would close a cycle |

<!--
Walk the rows in order and pause before revealing the next state on screen. The four connected sites use three accepted cables costing nine. The fifth vertex is retained as an isolated component, so the full graph has no spanning tree. The table records a logical trace; distinguish any sorted presentation view from physical storage layout. Ask a learner to justify one transition using the stated contract.
-->

---

## Follow the mechanism

- Begin with one union-find component per vertex.
- Process edges in nondecreasing weight order.
- Accept only edges joining different components, then unite their roots.

<!--
Tie every step to a state change in the preceding trace. Union-find describes connectivity of accepted edges. It is not the chosen cable set itself, and path compression does not add graph edges. Ask which step would fail if omitted or moved. The complete implementation stays in the lesson so the slide can focus on the algorithm's own progress rather than long support classes.
-->

---

## Keep the invariant in view

Union-find describes connectivity of accepted edges. It is not the chosen cable set itself, and path compression does not add graph edges.

<!--
Name the exact program point where this statement applies. Contrast initialization, one update, and the exit condition. Do not call a printed success message a proof. Use the verification slide later to distinguish a check on a few examples from the general argument.
-->

---

## Run the small model

```csharp
using System; using System.Linq;
(int A, int B, int W)[] edges = { (0,1,4), (1,2,2), (0,2,6), (2,3,3) };
int[] parent = { 0, 1, 2, 3, 4 }; int components = 5; long total = 0;
int Root(int v) { while (parent[v] != v) v = parent[v]; return v; }
foreach (var e in edges.OrderBy(e => e.W)) {
    int a = Root(e.A), b = Root(e.B);
    if (a == b) continue;
    parent[a] = b; components--; total += e.W;
}
Console.WriteLine($"total={total}, components={components}");
```

```output
total=9, components=2
```

<!--
Before running, ask learners to predict the complete output. Run this standalone cell in a fresh C# application; it requires no previous cell. The four connected sites use three accepted cables costing nine. The fifth vertex is retained as an isolated component, so the full graph has no spanning tree. If the demo environment fails, read the verified output and continue with the trace rather than spending the meeting on tool setup.
-->

---

## Explain the observed result

The four connected sites use three accepted cables costing nine. The fifth vertex is retained as an isolated component, so the full graph has no spanning tree.

<!--
Ask learners to connect the output to the contract, not just read the numbers aloud. Union-find describes connectivity of accepted edges. It is not the chosen cable set itself, and path compression does not add graph edges. Invite one controlled input change and predict its effect first. The worked output is evidence for this instance; the invariant and assumptions explain the broader claim.
-->

---

<!-- _class: check -->

## Quick check 1

How many accepted edges does a forest with V vertices and c components have?

1. V-c
2. V always
3. V+c

<!--
Give 30 seconds individually, then compare with a neighbor. Answer: A. Each accepted edge merges two components. Starting at V components, V-c successful unions reach c. Ask for the reason, not only the letter. If a common wrong choice dominates, replay the contract or trace before proceeding.
-->

---

## Boundaries are part of the model

- Keep isolates even when the edge list omits them.
- Tied weights may produce different optimal edge sets.
- Use a wide total and reject unknown endpoints.

<!--
Choose one boundary and ask for an independently expected result. Check acyclicity and component preservation independently. Distinguish a legal empty result from an invalid input. Do not silently change the contract to make a failing test disappear.
-->

---

<!-- _class: check -->

## Quick check 2

What does the cut argument justify?

1. A light crossing edge is safe for extending an optimal forest
2. Every accepted edge is a shortest route
3. Every graph is connected

<!--
Poll for a prediction before revealing any explanation. Answer: A. The exchange replaces a crossing edge without increasing cost. It concerns total network cost, not distances from one source. Link the distinction to the business case. Use a brief counterexample when a learner treats an assumption as a universal guarantee.
-->

---

<!-- _class: yourturn -->

## Your turn: Exercise: Inspect the Cable Forest

- Trace edge decisions and roots.
- Report total, edge count, and components.
- Verify a disconnected or tied-edge case without demanding one fixed edge set.

[Open the section practice](2402_spanning_trees_shortest_paths.html)

<!--
Allow three to five minutes in pairs. This practice is drawn from the section's actual exercise; it does not create a new assessment ID. Answer and debrief: The chosen example gives three edges, cost nine, and two components. With ties, verify minimum cost and connectivity/invariants rather than a particular sequence of labels. Ask learners to show their trace or checks before consulting the lesson solution. Assess reasoning as well as printed output.
-->

---

## Verify before recommending

- Check acyclicity and component preservation independently.
- Compare a small instance with exhaustive candidate forests.
- Account for sorting plus union-find work under its actual implementation.

<!--
Ask learners to separate implementation checks, model assumptions, and performance claims. A. The exchange replaces a crossing edge without increasing cost. It concerns total network cost, not distances from one source. Relate the requested evidence to the chapter lab/homework without changing their stable identities or making supporting readings silently compulsory.
-->

---

<!-- _class: recap -->

## Recap

- Distinguish network cost from route cost
- Track union-find components
- Return a forest for disconnected input

[Continue with the lesson and exercises](2402_spanning_trees_shortest_paths.html)

<!--
Invite a learner to explain one goal using the worked case. The four connected sites use three accepted cables costing nine. The fifth vertex is retained as an isolated component, so the full graph has no spanning tree. Exit question: what input, representation, or contract change would require a new argument? Use the current assignment route and chapter schedule to select follow-up practice.
-->

---

<!-- _class: section -->

# 24.3. Shortest Paths and Dijkstra

Computer Science in C#

<!--
This part addresses validate all nonnegative arcs, skip stale priority entries, distinguish minimum hops, route cost, and network cost. Read 2403_shortest_paths.html with the worked examples. Use the selected trace and nearby practice within the chapter's existing meeting allocation; this part is a reading unit, not an extra required meeting.
-->

---

## Goals for this part

- Validate all nonnegative arcs
- Skip stale priority entries
- Distinguish minimum hops, route cost, and network cost

<!--
Connect these goals to the chapter objectives before starting. The running case is: A delivery route from A may improve after another vertex is discovered. A priority queue can still contain the old distance after an improved entry is added. Ask learners to predict one result before execution. Revisit the same contract at the recap rather than introducing an unrelated API tour.
-->

---

## State the business question

A delivery route from A may improve after another vertex is discovered. A priority queue can still contain the old distance after an improved entry is added.

<!--
Ask which result the stakeholder actually needs. All arcs, including unreachable ones, must be nonnegative. A faster program is useful only when it still answers that question. Ask students to name one input or policy that would change the answer, then introduce the contract.
-->

---

## Make the contract explicit

- All arcs, including unreachable ones, must be nonnegative.
- Distance accumulation uses a wide type and an overflow policy.
- A reachable route has a valid predecessor witness; an unreachable target has none.

<!--
Explain each obligation in the running case. The minimum current nonnegative tentative distance can be settled. An obsolete queue entry is not a new reason to rescan adjacency. Separate what clients can rely on from representation details. Ask what a missing, empty, tied, or invalid input means before moving to the trace.
-->

---

## Trace one small instance

| Event | Tentative distances from A |
| --- | --- |
| Expand A | B=5, C=1 |
| Expand C at 1 | B=2, D=7 |
| Expand B at 2 | D=3 |
| Later entries B=5, D=7 | Stale; skip |

<!--
Walk the rows in order and pause before revealing the next state on screen. The best A-to-D cost is three through C then B. The earlier cost-seven candidate is obsolete, and hop count is not the optimization objective. The table records a logical trace; distinguish any sorted presentation view from physical storage layout. Ask a learner to justify one transition using the stated contract.
-->

---

## Follow the mechanism

- Validate the model before searching.
- On strict improvement, update distance/predecessor and enqueue the new distance.
- Skip a removal whose priority differs from the current best distance.

<!--
Tie every step to a state change in the preceding trace. The minimum current nonnegative tentative distance can be settled. An obsolete queue entry is not a new reason to rescan adjacency. Ask which step would fail if omitted or moved. The complete implementation stays in the lesson so the slide can focus on the algorithm's own progress rather than long support classes.
-->

---

## Keep the invariant in view

The minimum current nonnegative tentative distance can be settled. An obsolete queue entry is not a new reason to rescan adjacency.

<!--
Name the exact program point where this statement applies. Contrast initialization, one update, and the exit condition. Do not call a printed success message a proof. Use the verification slide later to distinguish a check on a few examples from the general argument.
-->

---

## Run the small model

```csharp
(int To,int W)[][] edges = { new[] {(1,5),(2,1)}, new[] {(3,1)},
    new[] {(1,1),(3,6)}, Array.Empty<(int,int)>() };
foreach (var row in edges) foreach (var e in row)
    if (e.W < 0) throw new ArgumentException();
long[] d = { 0, long.MaxValue, long.MaxValue, long.MaxValue };
var q = new PriorityQueue<int,long>(); q.Enqueue(0,0);
while (q.TryDequeue(out int v, out long cost)) { if (cost != d[v]) continue;
    foreach (var e in edges[v]) { long next = checked(cost + e.W);
        if (next < d[e.To]) { d[e.To] = next; q.Enqueue(e.To,next); }
    } }
Console.WriteLine(string.Join(",",d));
```

```output
0,2,1,3
```

<!--
Before running, ask learners to predict the complete output. Run this standalone cell in a fresh C# application; it requires no previous cell. The best A-to-D cost is three through C then B. The earlier cost-seven candidate is obsolete, and hop count is not the optimization objective. If the demo environment fails, read the verified output and continue with the trace rather than spending the meeting on tool setup.
-->

---

## Explain the observed result

The best A-to-D cost is three through C then B. The earlier cost-seven candidate is obsolete, and hop count is not the optimization objective.

<!--
Ask learners to connect the output to the contract, not just read the numbers aloud. The minimum current nonnegative tentative distance can be settled. An obsolete queue entry is not a new reason to rescan adjacency. Invite one controlled input change and predict its effect first. The worked output is evidence for this instance; the invariant and assumptions explain the broader claim.
-->

---

<!-- _class: check -->

## Quick check 1

Should an unreachable negative arc be ignored during input validation?

1. Yes, because it is not traversed
2. No; the declared graph contract rejects it
3. Only when it is a self-loop

<!--
Give 30 seconds individually, then compare with a neighbor. Answer: B. Validate every input arc before search. A run-specific reachability shortcut would weaken the stated contract. Ask for the reason, not only the letter. If a common wrong choice dominates, replay the contract or trace before proceeding.
-->

---

## Boundaries are part of the model

- Zero-weight edges and cycles require strict improvement.
- A missing distance is not the same as a fabricated singleton path.
- An MST route can cost more than the true shortest source-target route.

<!--
Choose one boundary and ask for an independently expected result. Validate every predecessor edge and reconstructed total. Distinguish a legal empty result from an invalid input. Do not silently change the contract to make a failing test disappear.
-->

---

<!-- _class: check -->

## Quick check 2

Why skip a queue entry at cost five after d[v] becomes two?

1. Its relaxation evidence is obsolete
2. Every cost five is invalid
3. To remove all paths to v

<!--
Poll for a prediction before revealing any explanation. Answer: A. The newer entry represents the current claim. Rescanning the obsolete one adds work and can undermine a careless implementation's correctness argument. Link the distinction to the business case. Use a brief counterexample when a learner treats an assumption as a universal guarantee.
-->

---

<!-- _class: yourturn -->

## Your turn: Practice: Compare Facilities Models

- Specify cable cost versus delivery-route cost.
- Check a predecessor path and sum its real edges.
- Test unreachable, zero-weight, and wide-distance cases.

[Open the section practice](2403_shortest_paths.html)

<!--
Allow three to five minutes in pairs. This practice is drawn from the section's actual exercise; it does not create a new assessment ID. Answer and debrief: Minimum total cable cost and minimum A-to-C travel cost are different objectives. The lesson triangle has an MST route of four versus a shortest direct route of three; neither result substitutes for the other. Ask learners to show their trace or checks before consulting the lesson solution. Assess reasoning as well as printed output.
-->

---

## Verify before recommending

- Validate every predecessor edge and reconstructed total.
- Compare small route costs against an independent reference.
- Count stale entries, heap operations, scans, and output in a complete workload.

<!--
Ask learners to separate implementation checks, model assumptions, and performance claims. A. The newer entry represents the current claim. Rescanning the obsolete one adds work and can undermine a careless implementation's correctness argument. Relate the requested evidence to the chapter lab/homework without changing their stable identities or making supporting readings silently compulsory.
-->

---

<!-- _class: recap -->

## Recap

- Validate all nonnegative arcs
- Skip stale priority entries
- Distinguish minimum hops, route cost, and network cost

[Continue with the lesson and exercises](2403_shortest_paths.html)

<!--
Invite a learner to explain one goal using the worked case. The best A-to-D cost is three through C then B. The earlier cost-seven candidate is obsolete, and hop count is not the optimization objective. Exit question: what input, representation, or contract change would require a new argument? Use the current assignment route and chapter schedule to select follow-up practice.
-->
