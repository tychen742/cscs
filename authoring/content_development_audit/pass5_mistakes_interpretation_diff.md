---
orphan: true
---

# Pass 5 diff: mistakes and interpretation, Chapters 17 to 26 (2026-10-18)

Every change is an inserted markdown cell after the named code cell: an output interpretation, a common-mistake paragraph, or both. No existing cell was edited.

```diff
### chapters/17_trees/1701_tree_structure.ipynb + new markdown cell after 1601_tree_structure_004
+ **Common mistake.** Assigning `root.Left.Left = new TreeNode("C#")` before `root.Left` exists throws `NullReferenceException`, because there is no node to hang the child on yet. Build from the root downward, or use a constructor that takes the children, as the final section does.

### chapters/17_trees/1701_tree_structure.ipynb + new markdown cell after 298b1c92
+ **Common mistake.** Writing the recursive case as `n + SumDown(n)` instead of `SumDown(n - 1)` compiles and never reaches the base case; the calls pile up until the runtime stack is exhausted. Every recursive call must pass a strictly smaller argument.

### chapters/17_trees/1701_tree_structure.ipynb + new markdown cell after d623f963
+ **Common mistake.** Reading the trace as if the multiplications happened on the way down. Each `return` line appears only after the deeper call has finished, so `4 * 6` is computed last, when `Factorial(4)` resumes; that is why the result lines come out in the opposite order from the call lines.

### chapters/17_trees/1701_tree_structure.ipynb + new markdown cell after 1601_tree_structure_008
+ **Common mistake.** Forgetting the `null` base case and testing `node.Left is null` only. A call on an empty subtree then dereferences `null`, and the leaf count is wrong even when it does not crash, because `Count` would skip the missing-child contribution of zero.

### chapters/17_trees/1701_tree_structure.ipynb + new markdown cell after ba_9b09e08a5e661098a3
+ **Common mistake.** Adding one for the internal node in `CountLeaves`, as `Count` does. That counts every node, not every leaf; the table shows that node 3 and node 8 contribute only what their children return.

### chapters/17_trees/1702_binary_search_trees.ipynb + new markdown cell after 1602_binary_search_t_024
+ The output is `True` and then `False`. The search for 7 follows 8, 3, 6, 7 and stops at the match after four comparisons; the search for 2 follows 8, 3, 1 and then meets `null`, which ends the loop. Neither search looked at 10, 14, 4, or 13: that is the half of the tree the invariant let it discard at each step.

### chapters/17_trees/1702_binary_search_trees.ipynb + new markdown cell after library-choice-36
+ The output is `10, 20, 30`, `True`, and `10, 20`. The second `Add(20)` was ignored, because a set holds each value once; `Contains` ran in logarithmic time on the library's balanced tree; and `GetViewBetween` is the range query from the next section, provided by the library as a live view rather than a copy.
+ 
+ **Common mistake.** Expecting `SortedSet<T>` to keep duplicates. The second `Add(20)` returns `false` and the set still holds one 20; a report that needs both occurrences must use a list or a count per key.

### chapters/17_trees/1702_binary_search_trees.ipynb + new markdown cell after 1602_binary_search_t_008
+ **Common mistake.** Testing `value < current.Value` first and `value == current.Value` second is harmless, but swapping the branch for `<` and `>` sends the search down the wrong subtree, and it reports `False` for a value that is present. Keep the comparison and the direction paired exactly as the invariant states.

### chapters/17_trees/1702_binary_search_trees.ipynb + new markdown cell after 1602_binary_search_t_012
+ **Common mistake.** Calling `Insert(node.Left, value)` without assigning the result back, `node.Left = Insert(...)`. The new node is created and then lost, so the tree never grows past its root; the inorder check printed by the cell would show the missing values at once.

### chapters/17_trees/1702_binary_search_trees.ipynb + new markdown cell after 1602_binary_search_t_016
+ **Common mistake.** Assuming the library's sorted collections have the same chain problem. `SortedSet<T>` and `SortedDictionary<TKey, TValue>` rebalance after each update, so inserting sorted keys into them stays logarithmic; the chain here is a property of this teaching implementation.

### chapters/17_trees/1702_binary_search_trees.ipynb + new markdown cell after 1602_binary_search_t_020
+ **Common mistake.** Replacing a two-child node with its inorder successor and then forgetting to remove that successor from the right subtree. The value now appears twice, the inorder sequence repeats it, and `Count` disagrees with the number of reachable nodes.

### chapters/17_trees/1703_tree_lab.ipynb + new markdown cell after 01169f3b
+ The output is `active=10, 20, 30, 40, 50, 60, 70`, then `find 30=True, find 35=False`, then `minimum=10, count=7, height=2`. The inorder listing is sorted even though the IDs arrived out of order, which is the invariant at work. Height 2 for seven nodes is the best possible shape; insert the same IDs in ascending order and the height becomes 6.
+ 
+ **Common mistake.** Treating `Count` as the number of calls to `Add`. Adding an ID that is already active returns `false` and leaves `Count` unchanged, so `Count` reports distinct active tickets, not attempted insertions.

### chapters/17_trees/1703_tree_lab.ipynb + new markdown cell after 61fbd0ed
+ The output is `4` and `0`. The interval 25 to 60 contains 30, 40, 50, and 60; the subtree under 10 was never visited because 20 is already below the lower bound. For 80 to 90 the root is below the bound, so only the right spine 60, 70 is examined, and both are still too small: zero after three visits.

### chapters/17_trees/1703_tree_lab.ipynb + new markdown cell after 5c4938ce
+ **Common mistake.** Pruning the wrong side. When `node.Id < lower`, everything in the *left* subtree is even smaller, so only the right subtree can hold matches; reversing the two cases skips the matches and visits the subtree that cannot contain any.

### chapters/17_trees/1703_tree_lab.ipynb + new markdown cell after 051fa9bf
+ **Common mistake.** Using a stack where the queue is. The traversal still visits every node, but in a depth-first order, so the printed levels interleave and the `pending before` counts no longer describe layers.

### chapters/17_trees/1703_tree_lab.ipynb + new markdown cell after 1feccedb
+ **Common mistake.** Checking only `tree.Count == model.Count`. Two structures can agree on count while holding different IDs; the check compares the full inorder sequence because that is the only observation that pins down the set.

### chapters/17_trees/1704_tree_traversal.ipynb + new markdown cell after 1601_tree_structure_020
+ The output is `3`: the leaves are 1, 3, and 9. Node 2 has two children, so it contributes the sum of its subtrees rather than counting itself, and the root likewise.

### chapters/17_trees/1704_tree_traversal.ipynb + new markdown cell after 1601_tree_structure_012
+ **Common mistake.** Moving the `Visit` call without moving the recursive calls with it. Printing before, between, or after the two child calls is the whole difference between preorder, inorder, and postorder; a misplaced print produces an order that is none of the three.

### chapters/17_trees/1704_tree_traversal.ipynb + new markdown cell after 1601_tree_structure_016
+ **Common mistake.** Returning 0 for a leaf and `1 + max(children)` for an internal node but forgetting the `null` case, or returning 0 for `null` and 1 for a leaf. The two conventions differ by one at every level; pick one, state it, and test it on an empty tree and a single node.

### chapters/18_priority_queues/1801_priority_queues.ipynb + new markdown cell after nearby-18
+ The output is `Urgent`. Its priority 1 is lower than Routine's 5, so it leaves first even though Routine was enqueued first; arrival order does not matter here. Swap the two priorities and `Routine` comes out instead.

### chapters/18_priority_queues/1801_priority_queues.ipynb + new markdown cell after 26e80da53e4c
+ **Common mistake.** Expecting `foreach (var item in tasks)` to list the work in priority order. Enumeration follows the internal heap layout, which is not sorted; only repeated `Dequeue` calls deliver items by priority.

### chapters/18_priority_queues/1801_priority_queues.ipynb + new markdown cell after 4158bdb9c19f
+ **Common mistake.** Checking the heap rule only at the root, or comparing siblings. The order rule relates each parent to its own children: in `1, 3, 2, 7, 5, 6, 4` the siblings 3 and 2 are out of numeric order and the heap is still valid, while a single parent larger than one of its children would invalidate it.

### chapters/18_priority_queues/1802_heap_implementation.ipynb + new markdown cell after 3d476713294d
+ **Common mistake.** Computing the parent as `child / 2` instead of `(child - 1) / 2`. For index 1 both give 0, which hides the bug, but for index 2 the wrong formula gives 1 instead of 0, and the new value is compared with a sibling rather than its parent.

### chapters/18_priority_queues/1802_heap_implementation.ipynb + new markdown cell after 674d010ddfbe
+ **Common mistake.** Swapping with the left child whenever it is smaller than the parent, without checking the right child. If the right child is smaller still, the left child ends up above a smaller sibling and the order rule is broken one level down.

### chapters/18_priority_queues/1803_priority_applications.ipynb + new markdown cell after afc2328484e0
+ The output is `Payment outage`, `Password reset`, `New laptop request`: priorities 0, 3, and 5 in ascending order, regardless of the order the three calls to `Enqueue` appeared in. Enqueue them in a different order and the output does not change.

### chapters/18_priority_queues/1803_priority_applications.ipynb + new markdown cell after 45a21b376a62
+ The output is `99, 95`. The queue never held more than two values; each time a third arrived, `Dequeue` discarded the smallest retained amount. Draining a min-heap yields ascending order, which is why the list is reversed before printing.

### chapters/18_priority_queues/1803_priority_applications.ipynb + new markdown cell after 75ec42553a97
+ **Common mistake.** Using a max-heap for the k largest values. The root would then be the *best* retained value, not the one to discard, so every new candidate is compared against the wrong boundary; a min-heap exposes the weakest retained amount, which is the only one a candidate needs to beat.

### chapters/19_hash_collections/1901_hashing.ipynb + new markdown cell after nearby-24
+ The output is `Second`. With four buckets, IDs 1 and 9 both map to bucket 1, because 9 % 4 is 1, so they share a chain. The lookup computed that bucket, walked the chain comparing actual IDs, passed entry 1, and matched entry 9; a collision slowed the lookup by one comparison but did not confuse the two keys.

### chapters/19_hash_collections/1901_hashing.ipynb + new markdown cell after c9772f2e4f18
+ **Common mistake.** Writing `Math.Abs(hash) % bucketCount`. For `int.MinValue` the absolute value overflows and throws, and for other negative codes it silently maps to a different bucket than the unsigned reinterpretation; the unchecked cast is the version that works for every code.

### chapters/19_hash_collections/1901_hashing.ipynb + new markdown cell after 382573cd88d2
+ **Common mistake.** Appending to the chain without scanning it first. The same ID is then stored twice, `Count` overstates the entries, and a later `Remove` deletes only the first copy while the stale one keeps answering lookups.

### chapters/19_hash_collections/1901_hashing.ipynb + new markdown cell after 50946d9a3ec8
+ **Common mistake.** Clearing a deleted slot to `null`. Any key whose probe sequence passed through that slot becomes unreachable even though it is still stored; the tombstone exists so that lookups keep probing past a deletion.

### chapters/19_hash_collections/1902_dictionaries_sets.ipynb + new markdown cell after bc850a9f8ada
+ The output is `B,C`, `A`, `A,B,C,D`, and `Sources: 3, 3`. The lowercase `b` in `attended` matched `B` because both sets use the case-insensitive comparer. The two source counts are still 3 because each operation ran on a copy; call `registered.IntersectWith` directly and the second report would be computed from a set that had already lost A.
+ 
+ **Common mistake.** Calling `registered.IntersectWith(attended)` directly. The method rewrites `registered` in place, so the later no-show difference is computed from an already shrunken set; copy first, as the cell does, when more than one answer is needed.

### chapters/19_hash_collections/1902_dictionaries_sets.ipynb + new markdown cell after a89b0ceb096c
+ The output is `p100: stored 0` and `missing: missing`. The lookup for `p100` found the key stored as `P100` because the dictionary's comparer ignores case, and it reported the stored zero as a value rather than as absence. A test such as `units[id] == 0` could not tell these two lines apart.
+ 
+ **Common mistake.** Reading `units["missing"]` to see whether a key exists. The indexer throws `KeyNotFoundException` on absence, and testing `units[id] == 0` cannot distinguish a stored zero from a missing key; `TryGetValue` answers both questions at once.

### chapters/19_hash_collections/1902_dictionaries_sets.ipynb + new markdown cell after d2bf1c853517
+ The output is `A,C`: the planned IDs that never appeared in `actual`. `planned` still holds three IDs afterward, because `ExceptWith` ran on the copy named `missing`. Reversing the operands, actual minus planned, would report `D`, a different business question.

### chapters/19_hash_collections/1902_dictionaries_sets.ipynb + new markdown cell after cbe6a7d730e3
+ **Common mistake.** Giving the set and the dictionary different comparers. With a case-sensitive dictionary, `Open` and `open` become separate keys while the case-insensitive set counts one status, and the two reports disagree about the same data.

### chapters/19_hash_collections/1903_collection_selection.ipynb + new markdown cell after ca9c108c607d
+ The output is `next=Database outage`, `owner=Amina`, and `closed=True`. Each line is answered by a different structure: the priority queue chose the outage over the report by priority, the dictionary looked up an owner by ID, and the set answered a membership question. No single collection does all three in its own cost.
+ 
+ **Common mistake.** Choosing one structure and forcing every operation through it, such as scanning the priority queue to find an owner by ID. Each need in the table has a structure that answers it in its own cost; the application's job is to keep the shared IDs consistent across them.

### chapters/19_hash_collections/1903_collection_selection.ipynb + new markdown cell after e93c226f206a
+ The output is a single line, `T1: Avery`. T2 had the higher priority and came out of the queue first, but it had been cancelled, so `active.Remove` returned `false` and the loop skipped it. `Remove` with an `out` owner both checks membership and claims the ticket in one step, which prevents serving it twice.

### chapters/19_hash_collections/1903_collection_selection.ipynb + new markdown cell after ccf8e62e14d3
+ **Common mistake.** Measuring one lookup with a stopwatch and reporting the ratio as the algorithm's speedup. A single timing includes warm-up and noise and says nothing about growth; the comparison count is the evidence, and a benchmark must repeat, warm up, and report variation.

### chapters/19_hash_collections/1903_collection_selection.ipynb + new markdown cell after 392202c28b9d
+ **Common mistake.** Removing the record from the dictionary and assuming the queue entry is gone too. The stale entry still sits in the heap and will be popped later; the dequeue loop must check the dictionary before serving, which is what makes lazy deletion safe.

### chapters/20_graphs/2001_graph_vocabulary.ipynb + new markdown cell after 66876b7f
+ The output lists `vertices=6, edges=4`, the four edges, and the closing line about `Remote`. The vertex count comes from the `rooms` array, not from the edges: `Remote` is a vertex with degree zero, and a graph built from the edge list alone would have lost it.
+ 
+ **Common mistake.** Deriving the vertex set from the edge list. `Remote` has no edge, so it would vanish from a graph built that way, and every later count, reachability answer, and component list would be wrong by one vertex.

### chapters/20_graphs/2001_graph_vocabulary.ipynb + new markdown cell after 3321cf2f
+ The output is `Hall=3, Remote=0` and `degree sum=8, twice edges=8`. Each undirected edge adds one to the degree of both endpoints, so the total degree is always exactly twice the edge count; a degree table that fails this check has a missing or doubled edge.

### chapters/20_graphs/2001_graph_vocabulary.ipynb + new markdown cell after c0118b29
+ **Common mistake.** Counting a directed edge on both endpoints' degrees as if it were undirected. `Approve` would then show degree three with no distinction between its two prerequisites and its one successor; keep indegree and outdegree separate for arcs.

### chapters/20_graphs/2002_adjacency_representations.ipynb + new markdown cell after d55f7a25
+ The output is `edge 1-2 exists=True, weight=0`, `edge 0-2 exists=False`, and `stored loop 0-0=False`. The zero-minute route between rooms 1 and 2 is a real edge, distinguishable from the absent 0-2 edge only because the cell type is `int?`; the diagonal stays `null` because the model stores no self-loops.
+ 
+ **Common mistake.** Declaring the matrix as `int[,]` and using zero for a missing edge. The zero-minute Office to Storage route then reads as no route at all, and a shortest-path search routes around a corridor that exists.

### chapters/20_graphs/2002_adjacency_representations.ipynb + new markdown cell after a8e950bc
+ The output is `vertices=6, edges=4, valid=True`, then `replacement inserted=False, edges=4`, then `Hall-Lab found=True, minutes=5`, then `snapshot changed graph=False`, and `Remote degree=0`. Reassigning Hall to Lab changed the weight in both directions without adding an edge, and the edited snapshot left the graph untouched because `Neighbors` returned a copy.
+ 
+ **Common mistake.** Returning the internal dictionary as `IEnumerable<KeyValuePair<string, int>>` and calling it read-only. A caller can cast it back and modify the graph behind the class's checks; the copy returned by `Neighbors` is what the `snapshot` lines in the cell prove.

### chapters/20_graphs/2002_adjacency_representations.ipynb + new markdown cell after e43ea833
+ The output is `A-B=False, B-A=False` and `B-C=0, C-B=0`. Both stored directions of the A-B edge are gone, and the zero-weight B-C edge survived in both directions; removing only `adjacency["A"]["B"]` would have left a one-way edge that the symmetry check rejects.

### chapters/20_graphs/2002_adjacency_representations.ipynb + new markdown cell after d9ffcf86
+ **Common mistake.** Setting only `connected[index[a], index[b]]` for an undirected edge. The matrix then says Hall reaches Lab but Lab does not reach Hall, and any traversal that starts at Lab reports a different graph.

### chapters/20_graphs/2002_adjacency_representations.ipynb + new markdown cell after fcd621fc
+ **Common mistake.** Forgetting the reverse entry in an undirected update, writing `adjacency["Hall"]["Lab"] = 2` alone. The graph becomes directed by accident; `IsValid`-style symmetry checks, as in the protected graph below, catch exactly this.

### chapters/20_graphs/2002_adjacency_representations.ipynb + new markdown cell after ee516d34
+ **Common mistake.** Choosing a matrix for a sparse graph because lookup is O(1). With 50 vertices and 60 edges the matrix reserves 2,500 cells for 120 entries, and every neighbor scan still reads a whole row of mostly empty cells.

### chapters/20_graphs/2003_graph_traversal.ipynb + new markdown cell after d15ebcb3e7d1
+ The output is `Lobby: 0`, `Hall: 1`, `Lab: 2`, `Office: 2`, and `Remote: unreachable`. Lab is two hops away through Hall, even though it is also reachable through Office; BFS recorded the first, shorter discovery. `Remote` prints as unreachable because its distance is `null`, not zero.

### chapters/20_graphs/2003_graph_traversal.ipynb + new markdown cell after 94c4f76b0c26
+ The output is `Lobby -> Hall -> Lab`, `Remote route length: 0`, and `Lobby`. The route was rebuilt by following predecessors backward from Lab and reversing; the unreachable room gives an empty array rather than a made-up path; and the source's route to itself is the one-vertex list.
+ 
+ **Common mistake.** Returning the predecessor chain without reversing it. The list is collected from the destination backward, so the printed route reads Lab, Hall, Lobby; reverse once before displaying, as `PathTo` does.

### chapters/20_graphs/2003_graph_traversal.ipynb + new markdown cell after ba_e6988cf2a41450d2e9
+ **Common mistake.** Marking a vertex when it is dequeued instead of when it is enqueued. In the diamond, both B and C then enqueue D, D is processed twice, and the second processing can overwrite the predecessor recorded by the first.

### chapters/20_graphs/2004_depth_first_components.ipynb + new markdown cell after b622532636f3
+ Both lines print `Lobby, Hall, Lab, Office`. The two traversals agree here because Hall's neighbor list is in the order Lab, Office and both algorithms consume it the same way; they are still different algorithms. In the diamond traced above, DFS reached C at depth three where BFS reaches it at depth one.

### chapters/20_graphs/2004_depth_first_components.ipynb + new markdown cell after cc9d1794f4fd
+ The output is `Lobby, Hall, Lab, Office`, then `Remote`, then `True`. The undirected graph has two components, the second being the isolated room. In the directed pair, Approve reaches Pay but the BFS from Pay reports Approve as unreachable, which is why forward reachability is not the same thing as a component.

### chapters/20_graphs/2004_depth_first_components.ipynb + new markdown cell after 6fc02fb8a224
+ The output is the single line `Layer and path checks passed.` Silence is the point: each `throw` line is an assertion that fires only when the result violates the contract, so a passing run prints nothing but the final confirmation. Change the expected distance to 1 and the first check fails loudly.
+ 
+ **Common mistake.** Checking only that the destination was reached. A path can end at Lab and still be wrong, for example by using an edge the graph does not contain; the checks compare the distance with the layer bound and the path with the stored edges.

### chapters/20_graphs/2004_depth_first_components.ipynb + new markdown cell after ba_9e9f84f97e30d42aa3
+ **Common mistake.** Marking a vertex visited only after its neighbors have been explored. On the cycle A-B-D-C-A, D then re-enters C and C re-enters A, and the recursion never ends; marking on entry is what turns the cycle into a skipped neighbor.

### chapters/20_graphs/2004_depth_first_components.ipynb + new markdown cell after ba_bfb6b140924d8d2a0c
+ **Common mistake.** Calling `Components` on a directed graph and reading the result as strongly connected components. A forward search from Approve reaches Pay, but not the reverse, so the two are not mutually reachable; the method refuses directed graphs for that reason.

### chapters/21_algorithm_analysis/2101_big_o.ipynb + new markdown cell after cc7a9bc9
+ The output is `n=0, checks=0`, `n=4, checks=12`, `n=8, checks=24`: exactly `3n`. The inner loop runs a fixed three times regardless of `n`, so the nesting multiplies by a constant and the cost stays Θ(n).

### chapters/21_algorithm_analysis/2101_big_o.ipynb + new markdown cell after e0c9ad26
+ **Common mistake.** Counting the wrong operation, such as array allocations instead of additions, and then comparing that count with another algorithm's comparison count. A cost model names one operation and one input size; mixing models makes the numbers incomparable.

### chapters/21_algorithm_analysis/2101_big_o.ipynb + new markdown cell after 1142937d
+ **Common mistake.** Multiplying the two loop bounds for the triangular loop and reporting `n²`. The inner range depends on `i`, so the count is the sum `0 + 1 + ... + (n - 1)`, half of `n²`; both are Θ(n²), but the exact count is what a test can check.

### chapters/21_algorithm_analysis/2101_big_o.ipynb + new markdown cell after b7d26065
+ **Common mistake.** Calling a loop over `n` invoices and `m` vendors O(n²) because there are two nested loops. The cost is Θ(nm); when `m` is a small fixed number the loop is linear in `n`, and when `m` grows independently the two symbols cannot be merged.

### chapters/21_algorithm_analysis/2101_big_o.ipynb + new markdown cell after b97c79e1
+ **Common mistake.** Reading O(n²) as "the algorithm takes quadratic time". The symbol gives an upper bound only; a linear algorithm is also O(n²). Use Θ when both bounds hold, as the cell's constants 3 and 28 establish for this cost function.

### chapters/21_algorithm_analysis/2101_big_o.ipynb + new markdown cell after bf4c7301
+ **Common mistake.** Reporting the best case as the algorithm's cost because one test found its target at index 0. The checks column shows the count depends on where the target is; a cost claim must say which case it describes.

### chapters/21_algorithm_analysis/2101_big_o.ipynb + new markdown cell after 6f2a049a
+ **Common mistake.** Treating the stack depth as the whole memory cost. The copy in the last line allocates `n` elements while using one stack frame; auxiliary space counts that array, and a method with shallow recursion can still need linear memory.

### chapters/21_algorithm_analysis/2102_correctness.ipynb + new markdown cell after ca9fce20
+ The output is `nonnegative adjustments=2`, counting the 0 and the 5. Zero passes the `>=` test, which the specification required; a test with `> 0` would have counted one and been wrong in a way no exception reveals.

### chapters/21_algorithm_analysis/2102_correctness.ipynb + new markdown cell after 38a15d48
+ **Common mistake.** Promising only that the result is "at least every input value". `int.MaxValue` satisfies that promise for any input, so the specification must also require that the result be one of the inputs; the cell's contract states both.

### chapters/21_algorithm_analysis/2102_correctness.ipynb + new markdown cell after fd6e3fd2
+ **Common mistake.** Stating the invariant as "best is the maximum so far" without saying which indexes count. With a closed range `[0, i]` the claim is false at the loop head, because `values[i]` has not been compared yet; the half-open `[0, i)` is exact.

### chapters/21_algorithm_analysis/2102_correctness.ipynb + new markdown cell after 59eef471
+ **Common mistake.** Treating a true invariant as a proof that the loop finishes. `while (remaining > 0)` with no decrement keeps the invariant forever; the variant, a quantity that strictly decreases, is the separate argument that rules out running forever.

### chapters/21_algorithm_analysis/2102_correctness.ipynb + new markdown cell after 6e61b95a
+ **Common mistake.** Arguing only about the normal exit. The early `return i` leaves the loop before the exit condition holds, so its correctness needs its own argument: the match at `i` plus the invariant that no earlier index matched.

### chapters/21_algorithm_analysis/2102_correctness.ipynb + new markdown cell after bef3b288
+ **Common mistake.** Initializing `best` to 0. Every positive test passes, and the all-negative input returns 0, a value that is not in the array; initialize from `values[0]` after the nonempty check, as `MaxExpense` does.

### chapters/21_algorithm_analysis/2103_recurrences.ipynb + new markdown cell after 13c209a4
+ The output is `leaves=8, calls=15`: for `n = 8` there are `n` leaves and `2n - 1` calls in total, while the deepest stack holds only four frames. Add a linear combine step at each internal node and the modeled work becomes `n log₂ n + n`, as the Two Branches section computed.

### chapters/21_algorithm_analysis/2103_recurrences.ipynb + new markdown cell after 2843c540
+ **Common mistake.** Writing the recurrence without its base case, `C(n) = C(n - 1) + 1` alone. It has no solution, since nothing anchors `C(0)`; the base call is one unit of work and the closed form `n + 1` depends on it.

### chapters/21_algorithm_analysis/2103_recurrences.ipynb + new markdown cell after 9cd37895
+ **Common mistake.** Assuming the chain for `n = 9` is 9, 4.5, 2.25, ... and reporting a fractional depth. Integer division gives 9, 4, 2, 1, so the call count is `floor(log₂ 9) + 1 = 4`; the model must use the same arithmetic as the code.

### chapters/21_algorithm_analysis/2103_recurrences.ipynb + new markdown cell after 4cbcb151
+ **Common mistake.** Adding the two child costs and forgetting the work around them, `W(n) = 2W(n/2)`. That recurrence solves to Θ(n), the leaf count, and misses the `n` units of combining at every level that make the total `n log₂ n + n`.

### chapters/21_algorithm_analysis/2103_recurrences.ipynb + new markdown cell after 0c02b126
+ **Common mistake.** Splitting an odd length as `n/2` and `n/2`. For `n = 5` the two halves hold four items; one item is dropped on every odd split, and the recursion still terminates, so nothing signals the loss except a preservation check.

### chapters/21_algorithm_analysis/2103_recurrences.ipynb + new markdown cell after 7d77b000
+ **Common mistake.** Reading the 25 calls for `n = 6` as 25 simultaneous frames. The peak is 6, because sibling calls run one after the other; call count measures time and peak frames measure stack space, and the two grow at very different rates here.

### chapters/22_recursion_divide_conquer/2201_recursion.ipynb + new markdown cell after 1e7c8ba2
+ The output is `positive=2, empty=0`. The 0 was not counted, because the test is `> 0`, and the empty array returned 0 from the base case without reading any element.

### chapters/22_recursion_divide_conquer/2201_recursion.ipynb + new markdown cell after 1807e7f7
+ **Common mistake.** Letting the helper take the whole array as its parameter and recursing on a copy without the first element. Each call then allocates a new array, so the search costs Θ(n²) copying for a Θ(n) scan; an index into the shared array is the progress measure that costs nothing to advance.

### chapters/22_recursion_divide_conquer/2201_recursion.ipynb + new markdown cell after 507d4a8d
+ **Common mistake.** Using recursion for a long flat report because it "reads better". Each item adds a stack frame, so a list of a few hundred thousand amounts can exhaust the runtime stack where the loop needs one variable; recursion earns its cost on nested or halving structures, not on flat sequences.

### chapters/22_recursion_divide_conquer/2201_recursion.ipynb + new markdown cell after 049c8bda
+ **Common mistake.** Relying on the exception to stop a runaway recursion. A `StackOverflowException` cannot be caught and ends the process; the domain check in `Countdown` runs *before* the first recursive call, which is the only place a guard can protect the stack.

### chapters/22_recursion_divide_conquer/2201_recursion.ipynb + new markdown cell after e3b68088
+ **Common mistake.** Splitting as `Solve(start, middle)` and `Solve(middle + 1, end)`. The element at `middle` belongs to neither half, so one value is silently skipped; with half-open ranges the second call starts exactly at `middle`.

### chapters/22_recursion_divide_conquer/2201_recursion.ipynb + new markdown cell after 20978b29
+ **Common mistake.** Recursing on `Find(middle, end)` after learning that the target is larger than `values[middle]`. A one-element range then calls itself with the same bounds forever; excluding the middle on the right side is what guarantees the range shrinks.

### chapters/22_recursion_divide_conquer/2203_merge_sort_lab.ipynb + new markdown cell after 217700c5
+ The output is `1, 2, 3, 3, 3` and `1, 3, 3`. All three 3s survived the merge, which is the preservation check the `SequenceEqual` guard enforces, and merging with an empty right side copied the left run through unchanged.

### chapters/22_recursion_divide_conquer/2203_merge_sort_lab.ipynb + new markdown cell after a7659cdd
+ The output is six `verified` lines, one per case. Each line passed three checks: the sorted result matches an independent reference, the input array is unchanged, and the returned array is a different object. The last case shows that `int.MinValue` and `int.MaxValue` sort correctly because the comparison uses `CompareTo` rather than subtraction.
+ 
+ **Common mistake.** Asserting `actual.SequenceEqual(actual.OrderBy(x => x))`, which compares the output with a sorted copy of itself. That passes for any sorted output, including an empty one; the reference must be built from the *input*, as `before.OrderBy` is.

### chapters/22_recursion_divide_conquer/2203_merge_sort_lab.ipynb + new markdown cell after 3de9dcb0
+ The output is `D, A, C, B`: amounts in descending order, with A before C because they tie at 3 and A arrived first. Reversing the comparison operands produced the descending order without touching the tie rule, which is why stability survived.

### chapters/22_recursion_divide_conquer/2203_merge_sort_lab.ipynb + new markdown cell after df3dcddf
+ **Common mistake.** Stopping when one side is exhausted and returning the result as it stands. The remaining run of the other side is dropped, and the output is shorter than the input while still looking sorted; the two tail-copy loops are not optional.

### chapters/22_recursion_divide_conquer/2203_merge_sort_lab.ipynb + new markdown cell after 895c6a57
+ **Common mistake.** Returning the input array itself from the base case instead of a clone. A caller that sorts a one-element array then holds the same object twice, and the copy-returning contract the rest of the page relies on is silently broken for that length.

### chapters/22_recursion_divide_conquer/2203_merge_sort_lab.ipynb + new markdown cell after dabd3868
+ **Common mistake.** Advancing both `i` and `j` after a comparison. Only the side whose element was copied moves; advancing the other skips an unread element, and the invariant `k = i + j` stops holding at that step.

### chapters/22_recursion_divide_conquer/2203_merge_sort_lab.ipynb + new markdown cell after 8cc9f219
+ **Common mistake.** Merging into the same array that is being read, in place, from the front. Writing `values[k]` overwrites an unread left element before it is compared; the separate buffer and the final copy-back are what make the single-array version correct.

### chapters/22_recursion_divide_conquer/2203_merge_sort_lab.ipynb + new markdown cell after e6e39d06
+ **Common mistake.** Sorting by amount and then sorting the result again by ID with a non-stable algorithm to "fix" the tie order. The second sort destroys the amount order; a stable sort applied once, with ties left in arrival order, is the contract reports depend on.

### chapters/22_recursion_divide_conquer/2203_merge_sort_lab.ipynb + new markdown cell after d2c55e5d
+ **Common mistake.** Reading `n log₂ n` as the exact comparison count and treating the measured 17 or 49 as a bug. The model bounds growth; actual comparisons depend on when each merge side runs out, and the writes column grows exactly as `2n log₂ n` because every item is written twice per level.

### chapters/23_searching_sorting/2301_searching.ipynb + new markdown cell after a7f8c001
+ The output is `target=200, range=[1,3), count=2`, `target=250, range=[3,3), count=0`, and `empty lower=0`. For the missing 250 both bounds land on index 3, the position where it would be inserted, so the count is zero without any index being read; on an empty array both bounds are 0.

### chapters/23_searching_sorting/2301_searching.ipynb + new markdown cell after ba_b286f52cdc760b8f3b
+ **Common mistake.** Returning `mid` as soon as `values[mid] == target`, as the any-match search does. For the lower bound that can land on the second or third 4; the boundary searches must keep moving `high` or `low` past equal values until the range is empty.

### chapters/23_searching_sorting/2301_searching.ipynb + new markdown cell after e8832c10
+ **Common mistake.** Sorting with `StringComparer.Ordinal` and then searching with `OrdinalIgnoreCase`. The sorted order no longer matches the search's idea of equal, so binary search can skip the block where `acme` and `Acme` sit; the comparer is part of the data's contract, not a per-call option.

### chapters/23_searching_sorting/2301_searching.ipynb + new markdown cell after df61e398
+ **Common mistake.** Reporting `lower` as a found position without checking `sorted[lower] == target`. For the missing target 250 the lower bound is 4, a legal index that holds 300; the `found` test in the cell is what separates "first match" from "insertion point".

### chapters/23_searching_sorting/2302_sorting.ipynb + new markdown cell after 1447c840
+ **Common mistake.** Writing the swap as `values[a] = values[b]; values[b] = values[a];`. After the first assignment the original `values[a]` is gone, and the array ends with two copies of `values[b]`; the tuple assignment reads both before writing either.

### chapters/23_searching_sorting/2302_sorting.ipynb + new markdown cell after c8ea65c4
+ **Common mistake.** Swapping as soon as a smaller value is seen during the scan instead of after the scan ends. The prefix still grows, but the extra swaps break the exact count the invariant promises and move elements that will have to move again.

### chapters/23_searching_sorting/2302_sorting.ipynb + new markdown cell after a9807404
+ **Common mistake.** Shifting with `>=` instead of `>`. Equal keys are then moved past each other on every pass, the sort is no longer stable, and the shift count no longer equals the number of inversions.

### chapters/23_searching_sorting/2302_sorting.ipynb + new markdown cell after 0b6c409a
+ **Common mistake.** Letting every pass run to the full end of the array. The sort still produces the right order, but it compares against the already settled suffix on every pass, and the early-exit saving on sorted input disappears.

### chapters/23_searching_sorting/2302_sorting.ipynb + new markdown cell after e699c034
+ **Common mistake.** Testing stability with an integer array. Equal integers are indistinguishable, so any output looks stable; the labeled invoices are the only input on which a reversed tie, `C, B, A`, can be seen.

### chapters/23_searching_sorting/2303_comparison_lab.ipynb + new markdown cell after d7f3083b
+ The cell prints the requirement and three candidate recommendations. It is a template: replace the first line with the actual requirement, keep the recommendation that matches its order, query, and update facts, and attach the measured counts from the earlier cells as evidence.
+ 
+ **Common mistake.** Recommending by algorithm name, such as "use binary search because it is O(log n)", without stating the data's order, the query frequency, and the update rate. The recommendation is only as good as the requirement it quotes, which is why the cell prints the requirement first.

### chapters/23_searching_sorting/2303_comparison_lab.ipynb + new markdown cell after 60cd5edd
+ The output is seven lines in which `comparisons` equals `expected` for every size from 0 through 6, including the already sorted inputs that `Enumerable.Range` produces. Selection sort pays `n(n - 1) / 2` comparisons whatever the order of the data; the formula is exact, not an upper bound.

### chapters/23_searching_sorting/2303_comparison_lab.ipynb + new markdown cell after ed32cec3
+ **Common mistake.** Comparing linear and binary search on different targets, or on an unsorted array for the binary side. The probe counts then measure different questions; the cell fixes one sorted array and one target set so that only the algorithm varies.

### chapters/23_searching_sorting/2303_comparison_lab.ipynb + new markdown cell after 1c6d2928
+ **Common mistake.** Running the three sorts on the same array object in turn. After the first algorithm the input is already sorted, so the other two are measured on a different input than they were given; the clone per algorithm keeps the comparison fair.

### chapters/23_searching_sorting/2303_comparison_lab.ipynb + new markdown cell after afd7320e
+ **Common mistake.** Adding comparisons, swaps, and shifts into one "operations" number. A shift moves one element, a swap moves two, and a comparison moves none; a sum of unlike operations says nothing unless the cost model gives each a weight.

### chapters/23_searching_sorting/2303_comparison_lab.ipynb + new markdown cell after 9ddf5663
+ **Common mistake.** Concluding that merge sort is faster at `n = 8` because 24 is less than 28. The growth model is not a comparison count, and at small sizes constants and the data's order decide; the table's claims are about growing `n`.

### chapters/23_searching_sorting/2303_comparison_lab.ipynb + new markdown cell after 0a30e753
+ **Common mistake.** Comparing one binary search against one linear scan and declaring the sorted approach cheaper. The sort cost is paid before the first query; the cell adds `preparation` to the binary total so the comparison is between complete workloads.

### chapters/23_searching_sorting/2304_advanced_sorts.ipynb + new markdown cell after restore2-shell-gaps
+ The output reports `sorted=True` for all three gap families, `32,16,8,4,2,1`, `40,13,4,1`, and `31,15,7,3,1`. Each ends with a gap of 1, so the final pass is an ordinary insertion sort and the result is guaranteed; which family does less work is a separate measurement.
+ 
+ **Common mistake.** Using a gap sequence that does not end in 1. The final pass is a plain insertion sort over the whole array; without it the array is only sorted within each gap class, and the result check against `Array.Sort` fails.

### chapters/23_searching_sorting/2305_quicksort.ipynb + new markdown cell after b4619594
+ Both lines print `1 2 3 4 5 6 7 8 9`: the shell sort and the quicksort agree on the sorted result for the test array. The tracing tasks in the paragraph above are for you to do by hand; the cell confirms only that the two implementations produce the same order.
+ 
+ **Common mistake.** Not advancing the scan indexes after a swap when both values equal the pivot. The next iteration swaps the same two elements back, and the loop never terminates; the `left++` and `right--` after the exchange are what move the scans past equal values.

### chapters/24_greedy_graph_optimization/2401_greedy_choice.ipynb + new markdown cell after 110acd64
+ The output is `A,B` and `zero duration rejected`. A ends at 0 and B starts at 0, so under half-open intervals they are compatible; C overlaps both and is rejected. The zero-duration meeting fails the `Start < End` contract before any scheduling happens.

### chapters/24_greedy_graph_optimization/2401_greedy_choice.ipynb + new markdown cell after 058e1e92
+ **Common mistake.** Sorting by start time or by duration instead of by finish time. Earliest start can pick the long meeting `C` and block three others; earliest finish is the one rule the exchange argument supports for the count objective.

### chapters/24_greedy_graph_optimization/2401_greedy_choice.ipynb + new markdown cell after 1cc694a8
+ **Common mistake.** Accepting a meeting whose start equals `lastEnd` as a conflict, or rejecting it. With half-open intervals a meeting starting exactly when the last one ends is compatible, which is why the test is `m.Start >= lastEnd` and not `>`.

### chapters/24_greedy_graph_optimization/2401_greedy_choice.ipynb + new markdown cell after 4c01fb7f
+ **Common mistake.** Keeping the earliest-finish rule and adding the values afterward. Value eight loses to nine here, and no tie-break repairs it; a changed objective needs a changed argument, which Chapter 25 supplies.

### chapters/24_greedy_graph_optimization/2401_greedy_choice.ipynb + new markdown cell after 0dba4c05
+ **Common mistake.** Trusting the exhaustive check on a large instance. With twenty meetings the subset loop runs about a million times, and with forty it cannot finish; the oracle is for tiny instances, and the proof covers the rest.

### chapters/24_greedy_graph_optimization/2402_spanning_trees_shortest_paths.ipynb + new markdown cell after f6543f2c
+ The trace accepts HQ-Shop, Shop-Lab, and Lab-Depot while the components drop from 4 to 2, then rejects Shop-Depot and HQ-Lab as cycles, and ends with `cost=9, components=2, spanning tree=False`. `Remote` never appears in an edge, so it stays its own component, and three accepted edges for five vertices is exactly `V - c`.
+ 
+ **Common mistake.** Treating the forest's total cost as the cost of traveling between two offices. Four cables can connect everything cheaply while the route from HQ to Depot along them is longer than a direct cable the forest rejected; the shortest-path section makes this concrete.

### chapters/24_greedy_graph_optimization/2402_spanning_trees_shortest_paths.ipynb + new markdown cell after ba_1244ead09ccc360596
+ **Common mistake.** Reading a parent link as a chosen cable. After `Union(0, 2)`, vertex 2's parent may be 0 even though the accepted edge was between 1 and 2; the parent array answers "same component?", and the accepted-edge list answers "which cables?".

### chapters/24_greedy_graph_optimization/2402_spanning_trees_shortest_paths.ipynb + new markdown cell after 1492eb91
+ **Common mistake.** Checking `edges == vertices - 1` to decide whether Kruskal succeeded. With `Remote` isolated the forest has three edges for five vertices and is still the correct answer; the check must use the component count, `V - c`.

### chapters/24_greedy_graph_optimization/2404_shortest_paths.ipynb + new markdown cell after 083993b6
+ The output is `C=2147483648, route=A->B->C, remote path length=0` and `unreachable negative arc rejected`. The distance exceeds `int.MaxValue` by one and is correct because distances are `long`; the unreachable vertex gets an empty path; and the negative arc is rejected by validation even though no route would ever use it.

### chapters/24_greedy_graph_optimization/2404_shortest_paths.ipynb + new markdown cell after dcb91b96
+ The output is `empty forest: cost=0, components=0`, `negative MST cost=-2`, `singleton path=A`, and `unknown endpoint rejected`. Each line is a boundary the contract names: an empty input is valid, a negative cable cost is valid for a forest, a source's route to itself is one vertex, and a reference to a vertex that was never added is an error rather than an isolate.
+ 
+ **Common mistake.** Rejecting negative weights everywhere. A negative cable cost is valid for a spanning forest, where edges are chosen rather than traversed; only Dijkstra's argument fails on negative arcs.

### chapters/24_greedy_graph_optimization/2404_shortest_paths.ipynb + new markdown cell after 6087cc3e
+ The output is `cable forest=9, delivery Depot=1`. The new one-minute arc made the delivery route to Depot cheaper, but the cable forest was computed from the original undirected edges and still costs 9: the two answers come from two inputs and two objectives, so one can change without the other.

### chapters/24_greedy_graph_optimization/2404_shortest_paths.ipynb + new markdown cell after 6da0ca4e
+ **Common mistake.** Supplying one arc per road for a two-way network. Dijkstra then finds routes in one direction only, and `Remote` is not the only unreachable vertex; add both directions explicitly, as the triangle example does.

### chapters/24_greedy_graph_optimization/2404_shortest_paths.ipynb + new markdown cell after ffd24fc8
+ **Common mistake.** Relaxing with `<=` instead of `<`. On the zero-weight cycle between B and D every pop re-enqueues the other vertex at an equal distance, and the loop runs until the queue is full of duplicates.

### chapters/24_greedy_graph_optimization/2404_shortest_paths.ipynb + new markdown cell after aac0f03d
+ **Common mistake.** Returning `[target]` for an unreachable vertex because the loop that follows predecessors found none. A one-vertex route reads as "the target is the source"; the method must check the distance first and return an empty path.

### chapters/24_greedy_graph_optimization/2404_shortest_paths.ipynb + new markdown cell after 6efaef75
+ **Common mistake.** Running Kruskal because the scenario says "cheapest" and then reading routes off the result. The cheapest network minimizes total cable, and the route A to C along it costs four against a direct road of three.

### chapters/24_greedy_graph_optimization/2404_shortest_paths.ipynb + new markdown cell after 311d6d4f
+ **Common mistake.** Accepting a path because its first element is the source and its last is the target. The check must also confirm that each consecutive pair is a stored arc and that the arc weights sum to the reported distance.

### chapters/25_dynamic_programming_backtracking/2501_memoization_tabulation.ipynb + new markdown cell after ba_ba8c313b2de676a748
+ **Common mistake.** Keying the cache on something other than the complete state. A cache keyed only by `n` is correct here because `n` is the whole question; reusing it after changing the base values, or for a two-parameter problem, returns answers to a different question.

### chapters/25_dynamic_programming_backtracking/2501_memoization_tabulation.ipynb + new markdown cell after ba_380ac417ba8888f861
+ **Common mistake.** Filling the table from `n` downward. Entry `i` needs `i - 1` and `i - 2`, which are still default zeros when the loop runs backward, so the table silently fills with wrong values and no exception signals it.

### chapters/25_dynamic_programming_backtracking/2501_memoization_tabulation.ipynb + new markdown cell after 4118640c
+ **Common mistake.** Comparing the naive call count at one `n` with the memoized count at another. The two counts are only comparable for the same `n`; the cell runs both at 8 so that the difference is the repeated work alone.

### chapters/25_dynamic_programming_backtracking/2501_memoization_tabulation.ipynb + new markdown cell after 5fa6626e
+ **Common mistake.** Writing `table[1] = 1` without the `n >= 1` guard. For `n = 0` the table has one entry, index 1 is out of range, and a method that is correct for every other input throws on the smallest one.

### chapters/25_dynamic_programming_backtracking/2502_backtracking.ipynb + new markdown cell after 6d237a2e
+ The output is `sum=4294967293, IDs=0,1,2`, `impossible=True`, and `budget exhausted: feasibility unknown`. The witness uses all three positions and its sum is `2 * int.MaxValue - 1`, which only fits because sums are accumulated in `long`. The third line is not a failure: a budget limit means the search stopped before deciding, which is a different outcome from a proven `null`.

### chapters/25_dynamic_programming_backtracking/2502_backtracking.ipynb + new markdown cell after 313f8053
+ The output is `zero count=0, missing reachable=False`, `independent witness=0,1`, and `empty subset feasible=True`. With no denominations, target 0 needs zero coins and target 1 is unreachable; the second search's witness was untouched by the edit to the first, because each result owns its array; and the empty subset is a real answer for target 0.

### chapters/25_dynamic_programming_backtracking/2502_backtracking.ipynb + new markdown cell after ef06df33
+ **Common mistake.** Adding the shared `chosen` list itself to the results instead of a copy. Every later undo edits the stored subsets too, and the final list holds `n` references to one empty list; the snapshot at the leaf is what the `subsets[0][0] = 99` line checks.

### chapters/25_dynamic_programming_backtracking/2502_backtracking.ipynb + new markdown cell after 237c505c
+ **Common mistake.** Recursing on `(i, r - value)` without advancing `i`. The same position can then be chosen again, turning the one-use invoices into unlimited coins, and the search may report a witness that uses one record twice.

### chapters/25_dynamic_programming_backtracking/2502_backtracking.ipynb + new markdown cell after e27e6ede
+ **Common mistake.** Pruning on `remaining < 0` with signed values. The `8, -3` witness for target 5 overshoots to 8 first and is cut off before the `-3` can bring it back; the suffix bounds are the version of the test that is safe for signed inputs.

### chapters/25_dynamic_programming_backtracking/2502_backtracking.ipynb + new markdown cell after 44e52636
+ **Common mistake.** Caching `r` alone as failed. The same remaining amount reached with different positions left is a different question, and a later state with more inventory would be wrongly declared infeasible.

### chapters/25_dynamic_programming_backtracking/2502_backtracking.ipynb + new markdown cell after 59a7446f
+ **Common mistake.** Forgetting to reset `used[i]` after the recursive call returns. The second branch then sees position `i` as taken, and the generator produces fewer than `n!` orders without any error.

### chapters/25_dynamic_programming_backtracking/2502_backtracking.ipynb + new markdown cell after ca8bf6a2
+ **Common mistake.** Reusing the search's own pruning rule inside the reference. A reference that shares the implementation's assumption cannot catch a wrong assumption; the exhaustive check enumerates subsets blindly on purpose.

### chapters/25_dynamic_programming_backtracking/2504_optimization_models.ipynb + new markdown cell after 263b251e
+ The output is `target=0, count=0, witness=[]`, `target=2, count=unreachable, witness=[]`, `target=6, count=2, witness=[3,3]`, and `zero denomination rejected`. The duplicate 3 in the denominations was normalized away, so the witness is still valid; target 2 is unreachable with packs of 3 and 4; and the zero pack is refused because it would never reduce the remaining amount.

### chapters/25_dynamic_programming_backtracking/2504_optimization_models.ipynb + new markdown cell after ba_f1664f67d936b09b5a
+ **Common mistake.** Initializing unreachable entries to 0 instead of `null`. Zero reads as "reachable with no packs", so amount 2 would borrow `best[2 - 3]`-style answers that do not exist; the nullable entry is what keeps unreachable states out of the minimum.

### chapters/25_dynamic_programming_backtracking/2504_optimization_models.ipynb + new markdown cell after 89657c54
+ **Common mistake.** Taking the largest pack first because it "obviously" minimizes count. For target 6 that gives `4 + 1 + 1`, three packs, while the table finds `3 + 3`; the recurrence compares every legal last pack instead of committing to one.

### chapters/25_dynamic_programming_backtracking/2504_optimization_models.ipynb + new markdown cell after bcbbf6a5
+ **Common mistake.** Checking only that the witness sums to the target. A witness proves feasibility, not optimality: `4 + 1 + 1` also sums to six. The count comparison against the table, or an independent reference, is the part that checks the minimum.

### chapters/25_dynamic_programming_backtracking/2504_optimization_models.ipynb + new markdown cell after 20cb4a53
+ **Common mistake.** Deduplicating the invoice values before searching. Two records worth four are two distinct positions; removing one as a duplicate makes target 8 infeasible when it is not.

### chapters/25_dynamic_programming_backtracking/2504_optimization_models.ipynb + new markdown cell after 549933d5
+ **Common mistake.** Letting the level search re-enqueue an amount it has already discovered. Without the `ContainsKey` check the queue grows without bound and later discoveries overwrite the first, minimal level.

### chapters/26_advanced_graphs_strings_limits/2602_shortest_paths_strings.ipynb + new markdown cell after 0213d935
+ **Common mistake.** Advancing the start position by the pattern length after a match. That skips overlapping occurrences, so `aaa` in `aaaaa` reports one position instead of three; the contract says every legal start is tested, so the start advances by one.

### chapters/26_advanced_graphs_strings_limits/2603_limits_project.ipynb + new markdown cell after 187a7952
+ The output is `feasible greedy=3, exact=2; no singleton covers all` and `unknown skill rejected`. The greedy choice covered every requirement with three teams, the exhaustive search found two, and because no single team covers all six, two is provably optimal; the mask with an undeclared bit is rejected before either search runs.

### chapters/26_advanced_graphs_strings_limits/2603_limits_project.ipynb + new markdown cell after f6f06edb
+ **Common mistake.** Computing `1 << n` with `int` for `n = 40`. The shift wraps around and reports a small candidate count, which makes an infeasible search look affordable; `BigInteger` keeps the comparison honest.

### chapters/26_advanced_graphs_strings_limits/2603_limits_project.ipynb + new markdown cell after d4a863a2
+ **Common mistake.** Presenting the greedy result as the answer because it covers every skill. Feasible is not optimal: three teams cover the six skills, and so do two. The exact search exists to show the gap, and the cell prints both.

### chapters/26_advanced_graphs_strings_limits/2603_limits_project.ipynb + new markdown cell after a4bf91aa
+ **Common mistake.** Comparing the two strategies' times before checking that both results actually cover the requirements. A fast strategy that returns an incomplete cover has not solved the problem; the union check runs first for that reason.

### chapters/26_advanced_graphs_strings_limits/2604_prefix_matching.ipynb + new markdown cell after 2c067f07
+ The output lists `[0,1,2]` for `aa` in `aaaa`, the four boundaries `[0,1,2,3]` for the empty pattern, and no positions for a pattern longer than the text or one that differs only in case. Both matchers agree on every case and on the library's ordinal first match, which is the contract this reading set out to preserve.

### chapters/26_advanced_graphs_strings_limits/2604_prefix_matching.ipynb + new markdown cell after ba_a141fe29725da76656
+ **Common mistake.** Letting the border include the whole segment. `prefix[i]` must be a *proper* prefix length, strictly less than `i + 1`; otherwise `AAAA` would produce `1, 2, 3, 4` and the scan would never shift.

### chapters/26_advanced_graphs_strings_limits/2604_prefix_matching.ipynb + new markdown cell after ba_e9cde3ade540a0a37d
+ **Common mistake.** Resetting `q` to zero after reporting a match. The occurrence of `ABAB` at start 2 in `ABABAB` is then missed, because the `AB` already matched at the end of the first occurrence is thrown away.

### chapters/26_advanced_graphs_strings_limits/2604_prefix_matching.ipynb + new markdown cell after 7fc1d418
+ **Common mistake.** Falling back to `prefix[q]` instead of `prefix[q - 1]`. The index is off by one, so the scan consults the border of a segment that includes the mismatched position and either skips a valid alignment or loops.

### chapters/26_advanced_graphs_strings_limits/2604_prefix_matching.ipynb + new markdown cell after fb348585
+ **Common mistake.** Moving the text index back after a mismatch, as the direct scan does. That reintroduces the quadratic behavior KMP exists to avoid; the invariant guarantees that the consumed text never needs rereading.

### chapters/26_advanced_graphs_strings_limits/2604_prefix_matching.ipynb + new markdown cell after 9bc4791b
+ **Common mistake.** Reporting KMP as faster from the scan count alone. The prefix table costs comparisons too, and for a single short search the direct scan can be cheaper; the total column includes preparation for that reason.

### chapters/18_priority_queues/1802_heap_implementation.ipynb + new markdown cell after ad5b64b59809
+ The output is `1`, `1`, `3`, `4`. Both copies of 1 come out, in some order, before 3 and 4; duplicates are ordinary values to a heap. The invariant check runs against the same comparer the heap uses, so a heap built with a reversed comparer would validate under its own rule, not under `<=`.
```
