---
marp: true
theme: thinkpress-lecture
paginate: true
title: "Chapter 20: Graphs and Traversal"
book: "Computer Science in C#"
section: "Chapter 20"
primary: "#2a6b37"
accent: "#b8860b"
---

<!-- _class: title -->

# 20. Graphs and Traversal

Computer Science in C#

Contracts, worked traces, practice, and verified examples.

<!--
Chapter 20: Graphs and Traversal.
Existing 110-minute chapter allocation: 35 minutes 20.1-20.2 vocabulary/representations;40 minutes 20.3 BFS/readiness;35 minutes 20.4 DFS/components.
Part 20.1: Graph Vocabulary and Models, starting slide 2.
Part 20.2: Adjacency Representations, starting slide 17.
Part 20.3: Breadth-First Search and Paths, starting slide 32.
Part 20.4: Depth-First Search and Components, starting slide 49.
Each core part is a reading unit; follow the current three-meeting allocation rather than add one meeting per part. Supporting parts are explicitly optional. Quick-check and Your turn answers remain in these instructor notes; the student HTML omits them. All complete C# examples are standalone and recorded in the code verification manifest.
-->

---

<!-- _class: section -->

# 20.1. Graph Vocabulary and Models

Computer Science in C#

<!--
This part addresses choose vertices and edge meaning, distinguish direction, weight, and connectivity, check degrees against a declared graph contract. Read 2001_graph_vocabulary.html with the worked examples. Use the selected trace and nearby practice within the chapter's existing meeting allocation; this part is a reading unit, not an extra required meeting.
-->

---

## Goals for this part

- Choose vertices and edge meaning
- Distinguish direction, weight, and connectivity
- Check degrees against a declared graph contract

<!--
Connect these goals to the chapter objectives before starting. The running case is: A facilities team models room connections; a manager models approval dependencies. The same drawing conventions do not imply the same business rules. Ask learners to predict one result before execution. Revisit the same contract at the recap rather than introducing an unrelated API tour.
-->

---

## State the business question

A facilities team models room connections; a manager models approval dependencies. The same drawing conventions do not imply the same business rules.

<!--
Ask which result the stakeholder actually needs. Vertices represent named entities. A faster program is useful only when it still answers that question. Ask students to name one input or policy that would change the answer, then introduce the contract.
-->

---

## Make the contract explicit

- Vertices represent named entities.
- Edges represent one explicit relationship.
- Weights need units; direction needs a stated interpretation.

<!--
Explain each obligation in the running case. An undirected edge contributes two degree incidences. A directed arc contributes one outgoing and one incoming incidence. Separate what clients can rely on from representation details. Ask what a missing, empty, tied, or invalid input means before moving to the trace.
-->

---

## Trace one small instance

| Question | Vertices | Edge meaning |
| --- | --- | --- |
| Can a visitor reach a room? | Rooms | Passable doorway |
| Which task may start? | Tasks | Prerequisite completed |
| What does a delivery cost? | Sites | Directed travel with cost |

<!--
Walk the rows in order and pause before revealing the next state on screen. The isolated fourth room is still a vertex and a component. The degree-sum calculation assumes symmetric undirected adjacency, not arbitrary directed data. The table records a logical trace; distinguish any sorted presentation view from physical storage layout. Ask a learner to justify one transition using the stated contract.
-->

---

## Follow the mechanism

- Decide whether reverse travel is allowed.
- Record isolates even when they have no edges.
- Distinguish a walk, a simple path, and a cycle.

<!--
Tie every step to a state change in the preceding trace. An undirected edge contributes two degree incidences. A directed arc contributes one outgoing and one incoming incidence. Ask which step would fail if omitted or moved. The complete implementation stays in the lesson so the slide can focus on the algorithm's own progress rather than long support classes.
-->

---

## Keep the invariant in view

An undirected edge contributes two degree incidences. A directed arc contributes one outgoing and one incoming incidence.

<!--
Name the exact program point where this statement applies. Contrast initialization, one update, and the exit condition. Do not call a printed success message a proof. Use the verification slide later to distinguish a check on a few examples from the general argument.
-->

---

## Run the small model

```csharp
using System;
int[][] neighbors = { new[] { 1, 2 }, new[] { 0 },
                      new[] { 0 }, Array.Empty<int>() };
int degreeSum = 0;
foreach (int[] row in neighbors) degreeSum += row.Length;
Console.WriteLine($"vertices={neighbors.Length}, edges={degreeSum / 2}");
Console.WriteLine($"isolated degree={neighbors[3].Length}");
```

```output
vertices=4, edges=2
isolated degree=0
```

<!--
Before running, ask learners to predict the complete output. Run this standalone cell in a fresh C# application; it requires no previous cell. The isolated fourth room is still a vertex and a component. The degree-sum calculation assumes symmetric undirected adjacency, not arbitrary directed data. If the demo environment fails, read the verified output and continue with the trace rather than spending the meeting on tool setup.
-->

---

## Explain the observed result

The isolated fourth room is still a vertex and a component. The degree-sum calculation assumes symmetric undirected adjacency, not arbitrary directed data.

<!--
Ask learners to connect the output to the contract, not just read the numbers aloud. An undirected edge contributes two degree incidences. A directed arc contributes one outgoing and one incoming incidence. Invite one controlled input change and predict its effect first. The worked output is evidence for this instance; the invariant and assumptions explain the broader claim.
-->

---

<!-- _class: check -->

## Quick check 1

Does a directed edge A to B guarantee a route B to A?

1. Yes, always
2. No, reverse reachability needs its own edges
3. Only if A sorts before B

<!--
Give 30 seconds individually, then compare with a neighbor. Answer: B. Direction belongs to the model. A route may exist through other edges, but a single forward arc does not supply it. Ask for the reason, not only the letter. If a common wrong choice dominates, replay the contract or trace before proceeding.
-->

---

## Boundaries are part of the model

- A self-loop and duplicate edge need an explicit policy.
- An isolated vertex remains in the model.
- An empty graph has no vertices or components.

<!--
Choose one boundary and ask for an independently expected result. Check every edge endpoint names a stored vertex. Distinguish a legal empty result from an invalid input. Do not silently change the contract to make a failing test disappear.
-->

---

<!-- _class: check -->

## Quick check 2

The undirected degree sum is eight. How many edges does it encode?

1. Four
2. Eight
3. Sixteen

<!--
Poll for a prediction before revealing any explanation. Answer: A. Each undirected edge is counted at both endpoints. Apply this only under the declared representation policy. Link the distinction to the business case. Use a brief counterexample when a learner treats an assumption as a universal guarantee.
-->

---

<!-- _class: yourturn -->

## Your turn: Exercise: Check Degree Totals

- Complete the Hall/Remote degree report.
- Check sum of degrees against twice EdgeCount.
- Explain why the isolated room remains a vertex.

[Open the section practice](2001_graph_vocabulary.html)

<!--
Allow three to five minutes in pairs. This practice is drawn from the section's actual exercise; it does not create a new assessment ID. Answer and debrief: The retained exercise reports Hall=3, Remote=0 and degree sum=8, twice edges=8. Each undirected edge contributes at both endpoints; a failed equality exposes a missing or doubled stored incidence. Ask learners to show their trace or checks before consulting the lesson solution. Assess reasoning as well as printed output.
-->

---

## Verify before recommending

- Check every edge endpoint names a stored vertex.
- Compare degree totals with edge count.
- State whether connectivity means undirected connection or directed reachability.

<!--
Ask learners to separate implementation checks, model assumptions, and performance claims. A. Each undirected edge is counted at both endpoints. Apply this only under the declared representation policy. Relate the requested evidence to the chapter lab/homework without changing their stable identities or making supporting readings silently compulsory.
-->

---

<!-- _class: recap -->

## Recap

- Choose vertices and edge meaning
- Distinguish direction, weight, and connectivity
- Check degrees against a declared graph contract

[Continue with the lesson and exercises](2001_graph_vocabulary.html)

<!--
Invite a learner to explain one goal using the worked case. The isolated fourth room is still a vertex and a component. The degree-sum calculation assumes symmetric undirected adjacency, not arbitrary directed data. Exit question: what input, representation, or contract change would require a new argument? Use the current assignment route and chapter schedule to select follow-up practice.
-->

---

<!-- _class: section -->

# 20.2. Adjacency Representations

Computer Science in C#

<!--
This part addresses compare matrix and adjacency costs, represent absence separately from weight zero, protect graph invariants during updates. Read 2002_adjacency_representations.html with the worked examples. Use the selected trace and nearby practice within the chapter's existing meeting allocation; this part is a reading unit, not an extra required meeting.
-->

---

## Goals for this part

- Compare matrix and adjacency costs
- Represent absence separately from weight zero
- Protect graph invariants during updates

<!--
Connect these goals to the chapter objectives before starting. The running case is: A route system must answer direct-edge checks and enumerate neighbors. Dense and sparse networks favor different storage choices. Ask learners to predict one result before execution. Revisit the same contract at the recap rather than introducing an unrelated API tour.
-->

---

## State the business question

A route system must answer direct-edge checks and enumerate neighbors. Dense and sparse networks favor different storage choices.

<!--
Ask which result the stakeholder actually needs. A Boolean matrix records whether an edge exists. A faster program is useful only when it still answers that question. Ask students to name one input or policy that would change the answer, then introduce the contract.
-->

---

## Make the contract explicit

- A Boolean matrix records whether an edge exists.
- A weighted model must distinguish zero cost from absence.
- A protected graph validates endpoints and consistent reverse edges.

<!--
Explain each obligation in the running case. For an undirected weighted graph, each reverse edge has the same weight. A zero weight is a present edge, not an absence marker. Separate what clients can rely on from representation details. Ask what a missing, empty, tied, or invalid input means before moving to the trace.
-->

---

## Trace one small instance

| Representation | Storage | Edge test | Neighbors of v |
| --- | --- | --- | --- |
| Matrix | V squared cells | Constant | Scan V cells |
| List rows | V plus adjacency entries | Scan degree(v) | Scan degree(v) |
| Hash rows | V plus adjacency entries | Expected constant | Scan degree(v) |

<!--
Walk the rows in order and pause before revealing the next state on screen. Two undirected edges occupy four true cells in a nine-cell matrix. The absent A-C edge still consumes a matrix cell. The table records a logical trace; distinguish any sorted presentation view from physical storage layout. Ask a learner to justify one transition using the stated contract.
-->

---

## Follow the mechanism

- Choose a representation from actual operations and density.
- Update both directions for an undirected edge.
- Return snapshots when callers must not mutate internal storage.

<!--
Tie every step to a state change in the preceding trace. For an undirected weighted graph, each reverse edge has the same weight. A zero weight is a present edge, not an absence marker. Ask which step would fail if omitted or moved. The complete implementation stays in the lesson so the slide can focus on the algorithm's own progress rather than long support classes.
-->

---

## Keep the invariant in view

For an undirected weighted graph, each reverse edge has the same weight. A zero weight is a present edge, not an absence marker.

<!--
Name the exact program point where this statement applies. Contrast initialization, one update, and the exit condition. Do not call a printed success message a proof. Use the verification slide later to distinguish a check on a few examples from the general argument.
-->

---

## Run the small model

```csharp
using System;
bool[,] edge = { { false, true, false },
                 { true, false, true },
                 { false, true, false } };
int present = 0;
foreach (bool value in edge) if (value) present++;
Console.WriteLine($"matrix cells={edge.Length}, stored true={present}");
Console.WriteLine(edge[0, 2]);
```

```output
matrix cells=9, stored true=4
False
```

<!--
Before running, ask learners to predict the complete output. Run this standalone cell in a fresh C# application; it requires no previous cell. Two undirected edges occupy four true cells in a nine-cell matrix. The absent A-C edge still consumes a matrix cell. If the demo environment fails, read the verified output and continue with the trace rather than spending the meeting on tool setup.
-->

---

## Explain the observed result

Two undirected edges occupy four true cells in a nine-cell matrix. The absent A-C edge still consumes a matrix cell.

<!--
Ask learners to connect the output to the contract, not just read the numbers aloud. For an undirected weighted graph, each reverse edge has the same weight. A zero weight is a present edge, not an absence marker. Invite one controlled input change and predict its effect first. The worked output is evidence for this instance; the invariant and assumptions explain the broader claim.
-->

---

<!-- _class: check -->

## Quick check 1

Why can zero not universally mean no edge in a weighted graph?

1. Zero-cost travel or transitions may be valid
2. Every weight is negative
3. A matrix cannot store zero

<!--
Give 30 seconds individually, then compare with a neighbor. Answer: A. Keep presence separate, for example with nullable weights or a separate Boolean field. Ask for the reason, not only the letter. If a common wrong choice dominates, replay the contract or trace before proceeding.
-->

---

## Boundaries are part of the model

- Removing a vertex must remove incident entries.
- Replacing a weight should not create a duplicate edge.
- Validate reverse weights before trusting an undirected edge count.

<!--
Choose one boundary and ask for an independently expected result. Run empty, isolated, and disconnected cases. Distinguish a legal empty result from an invalid input. Do not silently change the contract to make a failing test disappear.
-->

---

<!-- _class: check -->

## Quick check 2

Which workload benefits most directly from constant-time matrix edge tests?

1. Repeated checks of arbitrary vertex pairs
2. Only sequential file output
3. Only appending names to a queue

<!--
Poll for a prediction before revealing any explanation. Answer: A. Matrices trade quadratic storage and row scans for direct cell access. Count the requested operations rather than declaring one representation universally best. Link the distinction to the business case. Use a brief counterexample when a learner treats an assumption as a universal guarantee.
-->

---

<!-- _class: yourturn -->

## Your turn: Exercise: Remove an Undirected Edge

- Remove A-B in both directions.
- Preserve the zero-weight B-C edge.
- Check the representation invariant afterward.

[Open the section practice](2002_adjacency_representations.html)

<!--
Allow three to five minutes in pairs. This practice is drawn from the section's actual exercise; it does not create a new assessment ID. Answer and debrief: The result is A-B=False, B-A=False and B-C=0,C-B=0. Removing only one direction violates symmetry; deleting every zero value would confuse a present zero-cost edge with absence. Ask learners to show their trace or checks before consulting the lesson solution. Assess reasoning as well as printed output.
-->

---

## Verify before recommending

- Run empty, isolated, and disconnected cases.
- Use a degree-sum check under the undirected contract.
- Separate adjacency payload counts from runtime object overhead.

<!--
Ask learners to separate implementation checks, model assumptions, and performance claims. A. Matrices trade quadratic storage and row scans for direct cell access. Count the requested operations rather than declaring one representation universally best. Relate the requested evidence to the chapter lab/homework without changing their stable identities or making supporting readings silently compulsory.
-->

---

<!-- _class: recap -->

## Recap

- Compare matrix and adjacency costs
- Represent absence separately from weight zero
- Protect graph invariants during updates

[Continue with the lesson and exercises](2002_adjacency_representations.html)

<!--
Invite a learner to explain one goal using the worked case. Two undirected edges occupy four true cells in a nine-cell matrix. The absent A-C edge still consumes a matrix cell. Exit question: what input, representation, or contract change would require a new argument? Use the current assignment route and chapter schedule to select follow-up practice.
-->

---

<!-- _class: section -->

# 20.3. Breadth-First Search and Paths

Computer Science in C#

<!--
This part addresses trace discovery layers with a queue, mark at enqueue to prevent duplicate work, reconstruct a minimum-hop route. Read 2003_graph_traversal.html with the worked examples. Use the selected trace and nearby practice within the chapter's existing meeting allocation; this part is a reading unit, not an extra required meeting.
-->

---

## Goals for this part

- Trace discovery layers with a queue
- Mark at enqueue to prevent duplicate work
- Reconstruct a minimum-hop route

<!--
Connect these goals to the chapter objectives before starting. The running case is: The service network has A to B,C and both B,C to D. Two frontiers can discover D, but D needs only one queue entry. Ask learners to predict one result before execution. Revisit the same contract at the recap rather than introducing an unrelated API tour.
-->

---

## State the business question

The service network has A to B,C and both B,C to D. Two frontiers can discover D, but D needs only one queue entry.

<!--
Ask which result the stakeholder actually needs. BFS minimizes edge count in an unweighted graph. A faster program is useful only when it still answers that question. Ask students to name one input or policy that would change the answer, then introduce the contract.
-->

---

## Make the contract explicit

- BFS minimizes edge count in an unweighted graph.
- Discovery sets distance and predecessor once.
- An unreachable target has no invented route.

<!--
Explain each obligation in the running case. Every queued vertex is already discovered. Its predecessor is a real edge from the previous distance layer. Separate what clients can rely on from representation details. Ask what a missing, empty, tied, or invalid input means before moving to the trace.
-->

---

## Trace one small instance

| Event | Queue afterward | New distance |
| --- | --- | --- |
| Discover A | A | A=0 |
| Expand A | B,C | B=1, C=1 |
| Expand B | C,D | D=2 |
| Expand C | D | No rediscovery of D |

<!--
Walk the rows in order and pause before revealing the next state on screen. D receives distance two through whichever predecessor is discovered first. Minimum hop count does not require a unique shortest path. The table records a logical trace; distinguish any sorted presentation view from physical storage layout. Ask a learner to justify one transition using the stated contract.
-->

---

## Follow the mechanism

- Initialize the source distance to zero and enqueue it.
- For an unseen neighbor, record distance and predecessor before enqueue.
- Recover a target route by following predecessor links backward.

<!--
Tie every step to a state change in the preceding trace. Every queued vertex is already discovered. Its predecessor is a real edge from the previous distance layer. Ask which step would fail if omitted or moved. The complete implementation stays in the lesson so the slide can focus on the algorithm's own progress rather than long support classes.
-->

---

## Keep the invariant in view

Every queued vertex is already discovered. Its predecessor is a real edge from the previous distance layer.

<!--
Name the exact program point where this statement applies. Contrast initialization, one update, and the exit condition. Do not call a printed success message a proof. Use the verification slide later to distinguish a check on a few examples from the general argument.
-->

---

## Run the small model

```csharp
using System; using System.Collections.Generic;
int[][] edges = { new[] { 1, 2 }, new[] { 3 }, new[] { 3 }, Array.Empty<int>() };
int[] distance = { 0, -1, -1, -1 };
var queue = new Queue<int>(); queue.Enqueue(0);
while (queue.Count > 0) {
    int vertex = queue.Dequeue();
    foreach (int next in edges[vertex]) {
        if (distance[next] != -1) continue;
        distance[next] = distance[vertex] + 1; queue.Enqueue(next);
    }
}
Console.WriteLine(string.Join(",", distance));
```

```output
0,1,1,2
```

<!--
Before running, ask learners to predict the complete output. Run this standalone cell in a fresh C# application; it requires no previous cell. D receives distance two through whichever predecessor is discovered first. Minimum hop count does not require a unique shortest path. If the demo environment fails, read the verified output and continue with the trace rather than spending the meeting on tool setup.
-->

---

## Explain the observed result

D receives distance two through whichever predecessor is discovered first. Minimum hop count does not require a unique shortest path.

<!--
Ask learners to connect the output to the contract, not just read the numbers aloud. Every queued vertex is already discovered. Its predecessor is a real edge from the previous distance layer. Invite one controlled input change and predict its effect first. The worked output is evidence for this instance; the invariant and assumptions explain the broader claim.
-->

---

<!-- _class: check -->

## Quick check 1

When should BFS mark a neighbor discovered?

1. When enqueueing it
2. Only after its second removal
3. After all predecessor paths are printed

<!--
Give 30 seconds individually, then compare with a neighbor. Answer: A. Delayed marking lets several frontier vertices enqueue the same neighbor. Record discovery atomically with its queue insertion. Ask for the reason, not only the letter. If a common wrong choice dominates, replay the contract or trace before proceeding.
-->

---

## Boundaries are part of the model

- Source to itself has distance zero and a one-vertex path.
- Unknown source is rejected under the chapter contract.
- Known unreachable target has a missing distance and an empty path.

<!--
Choose one boundary and ask for an independently expected result. Compare reached vertices against an independent small reference. Distinguish a legal empty result from an invalid input. Do not silently change the contract to make a failing test disappear.
-->

---

## Dependency readiness is a different queue rule

| Processed task | Newly ready | Remaining Package indegree |
| --- | --- | ---: |
| Compile | Test | 1 |
| Test | Package | 0 |
| Package | Deploy | Already processed |

<!--
For Compile-to-Test, Compile-to-Package, Test-to-Package, and Package-to-Deploy dependencies, initial indegrees are zero,one,two,one. Output Compile first and decrement every outgoing neighbor once. Package becomes ready only after both prerequisites. This is topological readiness, not BFS distance.
-->

---

<!-- _class: check -->

## Quick check: a dependency cycle

Review waits for Sign, and Sign waits for Review. No other task can release either.

1. Invent an alphabetical order.
2. Report unresolved prerequisites rather than a valid full order.
3. Treat their indegrees as distances.

<!--
Answer: B. Neither task reaches indegree zero. A partial output is not a complete topological order; unresolved vertices can lie on or depend on cycles. Do not claim every remaining vertex is itself on a cycle. The section completion exercise asks students to release dependents by decrementing indegrees.
-->

---

<!-- _class: check -->

## Quick check 2

Why does BFS not minimize arbitrary weighted cost?

1. Its queue orders by edge-count layers, not accumulated weight
2. It ignores all vertices
3. It requires negative weights

<!--
Poll for a prediction before revealing any explanation. Answer: A. A one-edge route may cost more than a two-edge route. Dijkstra addresses nonnegative weighted routes in Chapter 24. Link the distinction to the business case. Use a brief counterexample when a learner treats an assumption as a universal guarantee.
-->

---

<!-- _class: yourturn -->

## Your turn: Practice: Verify a Route

- Recover a path to D from predecessor links.
- Check source, target, every edge, and path length.
- Predict how reversing neighbor order changes ties.

[Open the section practice](2003_graph_traversal.html)

<!--
Allow three to five minutes in pairs. This practice is drawn from the section's actual exercise; it does not create a new assessment ID. Answer and debrief: A-B-D and A-C-D both have two hops. A valid witness has distance+1 vertices and only real edges. Neighbor order may change the chosen predecessor, not the minimum distance. Ask learners to show their trace or checks before consulting the lesson solution. Assess reasoning as well as printed output.
-->

---

## Verify before recommending

- Compare reached vertices against an independent small reference.
- Reject a repeated predecessor or impossible edge.
- For dependency ordering, separately track indegrees; topological readiness is not BFS distance.

<!--
Ask learners to separate implementation checks, model assumptions, and performance claims. A. A one-edge route may cost more than a two-edge route. Dijkstra addresses nonnegative weighted routes in Chapter 24. Relate the requested evidence to the chapter lab/homework without changing their stable identities or making supporting readings silently compulsory.
-->

---

<!-- _class: recap -->

## Recap

- Trace discovery layers with a queue
- Mark at enqueue to prevent duplicate work
- Reconstruct a minimum-hop route

[Continue with the lesson and exercises](2003_graph_traversal.html)

<!--
Invite a learner to explain one goal using the worked case. D receives distance two through whichever predecessor is discovered first. Minimum hop count does not require a unique shortest path. Exit question: what input, representation, or contract change would require a new argument? Use the current assignment route and chapter schedule to select follow-up practice.
-->

---

<!-- _class: section -->

# 20.4. Depth-First Search and Components

Computer Science in C#

<!--
This part addresses reproduce recursive dfs with explicit frames, distinguish entry from finish events, restart traversal to find undirected components. Read 2004_depth_first_components.html with the worked examples. Use the selected trace and nearby practice within the chapter's existing meeting allocation; this part is a reading unit, not an extra required meeting.
-->

---

## Goals for this part

- Reproduce recursive DFS with explicit frames
- Distinguish entry from finish events
- Restart traversal to find undirected components

<!--
Connect these goals to the chapter objectives before starting. The running case is: A trace must preserve where a suspended neighbor loop resumes. A stack of vertices alone can visit the same set with different parents and finish events. Ask learners to predict one result before execution. Revisit the same contract at the recap rather than introducing an unrelated API tour.
-->

---

## State the business question

A trace must preserve where a suspended neighbor loop resumes. A stack of vertices alone can visit the same set with different parents and finish events.

<!--
Ask which result the stakeholder actually needs. A frame stores vertex and next-neighbor position. A faster program is useful only when it still answers that question. Ask students to name one input or policy that would change the answer, then introduce the contract.
-->

---

## Make the contract explicit

- A frame stores vertex and next-neighbor position.
- Discovery occurs once; finish occurs after all neighbors.
- Undirected components require repeated starts, including isolates.

<!--
Explain each obligation in the running case. Active frames describe the current root-to-vertex path. A finished vertex has no suspended neighbor work remaining. Separate what clients can rely on from representation details. Ask what a missing, empty, tied, or invalid input means before moving to the trace.
-->

---

## Trace one small instance

| DFS event on A:B,C; B:D; C:D | Frame meaning |
| --- | --- |
| Enter A then B | A remembers that B was selected |
| Enter D | B waits for its child |
| Finish D then B | Return to A at its next neighbor |
| Enter C then finish C,A | Seen D is not entered twice |

<!--
Walk the rows in order and pause before revealing the next state on screen. The output is finish order, not discovery order. Vertex 3 finishes before its parent 1; vertex 2 finishes later even though it points to already-seen 3. The table records a logical trace; distinguish any sorted presentation view from physical storage layout. Ask a learner to justify one transition using the stated contract.
-->

---

## Follow the mechanism

- Pop the current frame and inspect its next-neighbor index.
- Push the advanced parent before an unseen child.
- On exhausted neighbors, record finish instead of re-pushing.

<!--
Tie every step to a state change in the preceding trace. Active frames describe the current root-to-vertex path. A finished vertex has no suspended neighbor work remaining. Ask which step would fail if omitted or moved. The complete implementation stays in the lesson so the slide can focus on the algorithm's own progress rather than long support classes.
-->

---

## Keep the invariant in view

Active frames describe the current root-to-vertex path. A finished vertex has no suspended neighbor work remaining.

<!--
Name the exact program point where this statement applies. Contrast initialization, one update, and the exit condition. Do not call a printed success message a proof. Use the verification slide later to distinguish a check on a few examples from the general argument.
-->

---

## Run the small model

```csharp
using System; using System.Collections.Generic;
int[][] edges = { new[] { 1, 2 }, new[] { 3 }, new[] { 3 }, Array.Empty<int>() };
var frames = new Stack<(int V, int Next)>(); var done = new List<int>();
bool[] seen = { true, false, false, false }; frames.Push((0, 0));
while (frames.Count > 0) {
    var f = frames.Pop();
    if (f.Next == edges[f.V].Length) { done.Add(f.V); continue; }
    frames.Push((f.V, f.Next + 1)); int next = edges[f.V][f.Next];
    if (!seen[next]) { seen[next] = true; frames.Push((next, 0)); }
}
Console.WriteLine(string.Join(",", done));
```

```output
3,1,2,0
```

<!--
Before running, ask learners to predict the complete output. Run this standalone cell in a fresh C# application; it requires no previous cell. The output is finish order, not discovery order. Vertex 3 finishes before its parent 1; vertex 2 finishes later even though it points to already-seen 3. If the demo environment fails, read the verified output and continue with the trace rather than spending the meeting on tool setup.
-->

---

## Explain the observed result

The output is finish order, not discovery order. Vertex 3 finishes before its parent 1; vertex 2 finishes later even though it points to already-seen 3.

<!--
Ask learners to connect the output to the contract, not just read the numbers aloud. Active frames describe the current root-to-vertex path. A finished vertex has no suspended neighbor work remaining. Invite one controlled input change and predict its effect first. The worked output is evidence for this instance; the invariant and assumptions explain the broader claim.
-->

---

<!-- _class: check -->

## Quick check 1

What information makes a DFS frame different from a bare vertex?

1. The next neighbor position to resume
2. The globally minimum route cost
3. The total graph degree sum

<!--
Give 30 seconds individually, then compare with a neighbor. Answer: A. Recursive calls suspend a local neighbor loop. The explicit frame retains that local continuation. Ask for the reason, not only the letter. If a common wrong choice dominates, replay the contract or trace before proceeding.
-->

---

## Boundaries are part of the model

- An isolated vertex is one undirected component.
- An empty graph has zero components.
- Outgoing reachability in a directed graph is not strong connectivity.

<!--
Choose one boundary and ask for an independently expected result. Compare reached sets with BFS under the same source. Distinguish a legal empty result from an invalid input. Do not silently change the contract to make a failing test disappear.
-->

---

<!-- _class: check -->

## Quick check 2

An undirected DFS sees the reverse edge to its parent. Is that alone a cycle?

1. Yes
2. No; distinguish the parent edge from other visited neighbors
3. Only if labels are uppercase

<!--
Poll for a prediction before revealing any explanation. Answer: B. Every ordinary undirected tree edge appears in both adjacency directions. A non-parent visited connection supplies the additional cycle evidence. Link the distinction to the business case. Use a brief counterexample when a learner treats an assumption as a universal guarantee.
-->

---

<!-- _class: yourturn -->

## Your turn: Practice: Check a Reachability Report

- Trace entry and finish events on a small graph.
- Restart at an isolate to count components.
- Explain a directed example where reachability is asymmetric.

[Open the section practice](2004_depth_first_components.html)

<!--
Allow three to five minutes in pairs. This practice is drawn from the section's actual exercise; it does not create a new assessment ID. Answer and debrief: For A to B only, A reaches B while B cannot reach A. An undirected component partition assumes symmetric adjacency. Write down the explicit frames before comparing with recursive order. Ask learners to show their trace or checks before consulting the lesson solution. Assess reasoning as well as printed output.
-->

---

## Verify before recommending

- Compare reached sets with BFS under the same source.
- Verify finish events occur only after descendants finish.
- Count graph work as V+E under adjacency assumptions, with separate stack storage.

<!--
Ask learners to separate implementation checks, model assumptions, and performance claims. B. Every ordinary undirected tree edge appears in both adjacency directions. A non-parent visited connection supplies the additional cycle evidence. Relate the requested evidence to the chapter lab/homework without changing their stable identities or making supporting readings silently compulsory.
-->

---

<!-- _class: recap -->

## Recap

- Reproduce recursive DFS with explicit frames
- Distinguish entry from finish events
- Restart traversal to find undirected components

[Continue with the lesson and exercises](2004_depth_first_components.html)

<!--
Invite a learner to explain one goal using the worked case. The output is finish order, not discovery order. Vertex 3 finishes before its parent 1; vertex 2 finishes later even though it points to already-seen 3. Exit question: what input, representation, or contract change would require a new argument? Use the current assignment route and chapter schedule to select follow-up practice.
-->
