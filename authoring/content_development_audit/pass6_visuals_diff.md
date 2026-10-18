---
orphan: true
---

# Pass 6 diff: visual support and Part I construct pages (2026-10-18)

Inserted cells are marked "new ... cell"; lines starting with + under a cell id are text appended to an existing cell.

```diff
### chapters/04_iteration/0401_iteration.ipynb + new markdown cell at 9 (for loop trace table)
+ Read the loop as a table. Each row is one pass: the condition is tested, the body prints, then the step runs and the next test uses the new value.
+ 
+ | Pass | `i` at the test | `i <= 10`? | Printed | `i` after the step |
+ | ---: | ---: | --- | --- | ---: |
+ | 1 | 1 | true | `1 ` | 2 |
+ | 2 | 2 | true | `2 ` | 3 |
+ | ... | ... | ... | ... | ... |
+ | 10 | 10 | true | `10 ` | 11 |
+ | 11 | 11 | false | nothing; the loop ends | |
+ 
+ The eleventh test fails and the body does not run, which is why the loop prints exactly ten numbers and `i` is 11 afterward. Every counting loop in this chapter can be traced with the same four columns.

### chapters/04_iteration/0401_iteration.ipynb + new markdown cell at 26 (break and continue example)
+ Both statements change where control goes without changing the loop header. In the example, `continue` skips the closed ticket and `break` stops at the first ticket over the limit:

### chapters/04_iteration/0401_iteration.ipynb + new code cell at 26 (break and continue example)
+ using System;
+ 
+ int[] tickets = { 12, 0, 7, 45, 3 };
+ int reviewed = 0;
+ foreach (int minutes in tickets)
+ {
+     if (minutes == 0) continue;        // closed ticket: skip the rest of this pass
+     if (minutes > 30) break;           // over the limit: leave the loop entirely
+     reviewed++;
+     Console.WriteLine($"Reviewed a {minutes}-minute ticket");
+ }
+ Console.WriteLine($"Reviewed {reviewed} tickets");

### chapters/04_iteration/0401_iteration.ipynb + new markdown cell at 26 (break and continue example)
+ The output is two `Reviewed` lines, for 12 and 7 minutes, and then `Reviewed 2 tickets`. The 0 was skipped by `continue`, and the 45 ended the loop before 3 was ever examined. A `continue` placed after the counter instead of before it would still count the skipped ticket; place the skip before the work it is meant to skip.

### chapters/04_iteration/0401_iteration.ipynb + new markdown cell at 31 (rubric worked example)
+ Before reading the checklist, see it applied. A store adds each day's sales to a running total and stops at the first day the total passes 1,000:

### chapters/04_iteration/0401_iteration.ipynb + new code cell at 31 (rubric worked example)
+ using System;
+ 
+ int[] dailySales = { 320, 410, 150, 275, 500 };   // data
+ int total = 0;                                     // initialization
+ int day = 0;
+ while (day < dailySales.Length && total <= 1000)   // continuation condition
+ {
+     total += dailySales[day];                      // repeated action
+     day++;                                         // update
+ }
+ Console.WriteLine($"Passed 1,000 after day {day} with {total}");   // done once, after the loop

### chapters/04_iteration/0401_iteration.ipynb + new markdown cell at 31 (rubric worked example)
+ The output is `Passed 1,000 after day 4 with 1155`. Each comment names the rubric question it answers:
+ 
+ | Rubric question | Answer in this loop |
+ | --- | --- |
+ | Data and loop variables | `dailySales`, `total`, `day` |
+ | Initialization | `total = 0`, `day = 0` |
+ | Continuation condition | `day < dailySales.Length && total <= 1000` |
+ | Done once | Print the result after the loop |
+ | Repeated action | Add one day's sales |
+ | Update | `day++` |
+ | Will the condition eventually fail? | `day` grows by one each pass, so it reaches the array length even if the total never passes 1,000 |
+ 
+ The second half of the condition is the one students forget: without the `day < dailySales.Length` guard, a week that never reaches 1,000 reads past the end of the array.

### chapters/04_iteration/0404_gcd.ipynb cell 9b02e0da (trace and comparison tables)
+
+The remainder steps for 810 and 729, and the work the three methods did on the same input:
+
+| Step | `a` | `b` | `a % b` |
+| ---: | ---: | ---: | ---: |
+| start | 810 | 729 | 81 |
+| 1 | 729 | 81 | 0 |
+| 2 | 81 | 0 | stop |
+
+| Method | Work on (810, 729) | Grows with |
+| --- | ---: | --- |
+| Trial division | 729 tests | the smaller number |
+| Repeated subtraction | 9 subtractions | the quotient at each stage |
+| Remainder loop | 2 steps | roughly the number of digits |

### chapters/09_files_text/0905_privacy_security.ipynb cell 6df61f7d (principles table)
+
+| Habit | What it means in code | Where this page shows it |
+| --- | --- | --- |
+| Collect less | Ask only for the fields the task needs; do not store a card number to show its last four digits | the masking helpers keep only what a screen needs |
+| Show less | Mask or summarize before displaying or logging | `MaskEmail`, `MaskCard` |
+| Keep less | Delete temporary files and expire records on a schedule | the file examples in 9.2 delete their workspace |
+| Check every input | Validate type and business range before using a value | `CheckQuantity` |
+| Log actions, not secrets | Record who did what and whether it succeeded, never a password or token | `LogLine` |

### chapters/10_classes/1002_properties.ipynb + new markdown cell at 7 (property forms table)
+ The four forms differ in who may read and write, which is the design decision behind each one:
+ 
+ | Form | Read from outside | Write from outside | Typical use |
+ | --- | --- | --- | --- |
+ | `{ get; set; }` | yes | yes | a plain data field the caller may change, such as a phone number |
+ | `{ get; }` | yes | only in the constructor | an identity fixed at creation, such as a name or SKU |
+ | `{ get; private set; }` | yes | no; the class changes it through methods | a running total that `Add` and `Clear` maintain |
+ | `=> expression` | yes, recomputed each time | no | a value derived from other properties, such as a summary line |
+ | full `get`/`set` with a backing field | yes | yes, through validation | a value that must be checked before it is stored |

### chapters/10_classes/1003_class_instance.ipynb + new markdown cell at 8 (object diagram and state table)
+ Draw the two objects as separate records; the variables hold references to them, not the data itself:
+ 
+ ```text
+ front ──▶ ┌────────────────────┐      patio ──▶ ┌────────────────────┐
+           │ CashRegister       │                │ CashRegister       │
+           │ Station = "Front"  │                │ Station = "Patio"  │
+           │ Total   = 7.50     │                │ Total   = 2.00     │
+           │ ItemCount = 2      │                │ ItemCount = 1      │
+           └────────────────────┘                └────────────────────┘
+ ```
+ 
+ The three `Add` calls change one record each:
+ 
+ | Call | `front.Total` | `front.ItemCount` | `patio.Total` | `patio.ItemCount` |
+ | --- | ---: | ---: | ---: | ---: |
+ | after construction | 0.00 | 0 | 0.00 | 0 |
+ | `front.Add(4.50m)` | 4.50 | 1 | 0.00 | 0 |
+ | `front.Add(3m)` | 7.50 | 2 | 0.00 | 0 |
+ | `patio.Add(2m)` | 7.50 | 2 | 2.00 | 1 |

### chapters/10_classes/1004_averager.ipynb + new markdown cell at 17 (Averager state table)
+ Follow the two instance variables through the demonstration; `GetAverage` divides them on each request and stores nothing extra:
+ 
+ | Event | `dataCount` | `sum` | `GetAverage()` |
+ | --- | ---: | ---: | ---: |
+ | new Averager | 0 | 0.0 | undefined, no data |
+ | `AddDatum(5.1)` | 1 | 5.1 | 5.1 |
+ | `AddDatum(-7.3)` | 2 | -2.2 | -1.1 |
+ | `AddDatum(11.0)` | 3 | 8.8 | 2.9333... |
+ | `AddDatum(3.7)` | 4 | 12.5 | 3.125 |
+ | `Clear()` | 0 | 0.0 | undefined, no data |
+ 
+ Two numbers are enough to answer the average question at any moment; storing the average itself would be a third value to keep in step with the other two on every call.

### chapters/11_object_design/1101_objects_references.ipynb + new markdown cell at 12 (reference diagrams)
+ The drawing the section asked for, before and after the assignment through the alias:
+ 
+ ```text
+ before otherScreen.Price = 12m          after otherScreen.Price = 12m
+ 
+ original    ──▶ ┌──────────────┐        original    ──▶ ┌──────────────┐
+                 │ StockItem    │                        │ StockItem    │
+ otherScreen ──▶ │ Price = 10   │        otherScreen ──▶ │ Price = 12   │
+                 └──────────────┘                        └──────────────┘
+ ```
+ 
+ Two arrows, one record. Compare the independent case, which is what `new` produces each time it runs:
+ 
+ ```text
+ first    ──▶ ┌──────────────┐        imported ──▶ ┌──────────────┐
+              │ Product      │                     │ Product      │
+              │ Sku = "P100" │                     │ Sku = "P100" │
+              └──────────────┘                     └──────────────┘
+ ```
+ 
+ | Situation | Objects | References | `ReferenceEquals` |
+ | --- | ---: | ---: | --- |
+ | `otherScreen = original` | 1 | 2 | true |
+ | two `new Product("P100", ...)` calls | 2 | 2 | false, same SKU |

### chapters/17_trees/1703_tree_lab.ipynb + new markdown cell at 11 (pruning diagram)
+ The visited and skipped nodes for the interval 25 to 60. Brackets mark a visited node; a struck subtree was proved outside the interval without being entered:
+ 
+ ```text
+                 [40]
+           ┌───────┴───────┐
+         [20]            [60]
+        ┌──┴──┐         ┌──┴──┐
+     ~~10~~  [30]     [50]  ~~70~~
+ 
+   visit 40: in range, search both sides
+   visit 20: below 25, skip its left subtree (10), search right
+   visit 30: in range
+   visit 60: at the upper bound, search left, skip right (70)
+   visit 50: in range
+ ```
+ 
+ Five nodes visited, two subtrees skipped, four matches. On a larger tree the skipped subtrees can hold thousands of nodes, which is where pruning pays.

### chapters/17_trees/1703_tree_lab.ipynb + new markdown cell at 23 (level-order queue table)
+ The queue, step by step:
+ 
+ | Dequeued and visited | Enqueued | Queue afterward |
+ | --- | --- | --- |
+ | | 40 | 40 |
+ | 40 | 20, 60 | 20, 60 |
+ | 20 | 10, 30 | 60, 10, 30 |
+ | 60 | 50, 70 | 10, 30, 50, 70 |
+ | 10 | | 30, 50, 70 |
+ | 30 | | 50, 70 |
+ | 50 | | 70 |
+ | 70 | | empty |
+ 
+ Each level's nodes sit together in the queue ahead of the next level's, which is the whole reason a queue, and not a stack, produces level order.

### chapters/20_graphs/2001_graph_vocabulary.ipynb + new markdown cell at 12 (comparison and degree table)
+ The two models side by side, using the rooms and the approval steps from the cells above:
+ 
+ | Term | Undirected rooms graph | Directed approval graph |
+ | --- | --- | --- |
+ | Edge | `Hall -- Lab`, usable both ways | `Request -> Approve`, one way |
+ | Degree | Hall: 3 (Lobby, Lab, Office) | Approve: in 2, out 1 |
+ | Isolated vertex | Remote, degree 0 | a step with in 0 and out 0 |
+ | Starting point | any room | a step with indegree 0: Request, Budget |
+ | Symmetry | `[Hall, Lab]` implies `[Lab, Hall]` | `Approve -> Request` is not implied |
+ 
+ Degrees of the six rooms: Lobby 1, Hall 3, Lab 1, Office 2, Storage 1, Remote 0. They sum to 8, twice the four edges, because every edge is counted once at each end.

### chapters/23_searching_sorting/2304_advanced_sorts.ipynb cell 99a405b5 (gap subsequence table)
+
+The subsequences the guided trace asks for, on eight positions:
+
+| Gap | Subsequence | Positions | Example values from `8 3 7 1 9 2 6 4` |
+| ---: | ---: | --- | --- |
+| 3 | 1 | 0, 3, 6 | 8, 1, 6 |
+| 3 | 2 | 1, 4, 7 | 3, 9, 4 |
+| 3 | 3 | 2, 5 | 7, 2 |
+| 1 | 1 | 0 through 7 | the whole array |
+
+After the gap-3 pass each row is sorted in place: positions 0, 3, 6 hold 1, 6, 8; positions 1, 4, 7 hold 3, 4, 9; positions 2, 5 hold 2, 7. The array reads `1 3 2 6 4 7 8 9`, nearly sorted but not sorted, which the final gap-1 insertion pass finishes with few shifts.

### chapters/02_var_data/0202_operators_built_in_methods.ipynb + new markdown cell at 7 (runnable example before the operator types)
+ Before the catalogue, one short program uses an operator from each group so you can see what they look like in a real line of code:

### chapters/02_var_data/0202_operators_built_in_methods.ipynb + new code cell at 7 (runnable example before the operator types)
+ using System;
+ 
+ int quantity = 7;
+ decimal unitPrice = 4.25m;
+ decimal total = quantity * unitPrice;          // arithmetic
+ total += 2.50m;                                // compound assignment: add shipping
+ bool bulk = quantity >= 5;                     // comparison produces a bool
+ bool freeShipping = bulk && total > 25m;       // logical operator combines two bools
+ Console.WriteLine($"Total {total:F2}, bulk {bulk}, free shipping {freeShipping}");
+ Console.WriteLine(quantity % 2 == 0 ? "even quantity" : "odd quantity");   // remainder and the conditional operator

### chapters/02_var_data/0202_operators_built_in_methods.ipynb + new markdown cell at 7 (runnable example before the operator types)
+ The output is `Total 32.25, bulk True, free shipping True` and `odd quantity`. Each group below explains one of the operators used here; come back to this cell and change a value to see which lines respond.

### chapters/03_decision/0301_intro_decision.ipynb + new markdown cell at 6 (if example before the statement list)
+ Run the pattern on a real decision before reading about the other forms. A store charges shipping unless the order total reaches 50:

### chapters/03_decision/0301_intro_decision.ipynb + new code cell at 6 (if example before the statement list)
+ using System;
+ 
+ decimal total = 64.00m;
+ decimal shipping = 5.95m;
+ 
+ if (total >= 50m)
+ {
+     shipping = 0m;                           // runs only when the condition is true
+ }
+ Console.WriteLine($"Total {total:F2}, shipping {shipping:F2}");

### chapters/03_decision/0301_intro_decision.ipynb + new markdown cell at 6 (if example before the statement list)
+ The output is `Total 64.00, shipping 0.00`. Change `total` to 20 and the block is skipped, so the printed shipping stays 5.95. The statement after the closing brace runs in both cases; only the block belongs to the `if`.

### chapters/03_decision/0301_intro_decision.ipynb + new code cell at 12 (runnable bool example)
+ using System;
+ 
+ bool isRollaQuiet = true;
+ bool isChicagoClose = false;
+ int credits = 96;
+ bool canGraduate = credits >= 120;        // a comparison produces a bool
+ Console.WriteLine(isRollaQuiet);
+ Console.WriteLine(isChicagoClose);
+ Console.WriteLine($"credits {credits}, can graduate: {canGraduate}");

### chapters/03_decision/0301_intro_decision.ipynb + new markdown cell at 12 (runnable bool example)
+ The output is `True`, `False`, and `credits 96, can graduate: False`. The third line shows where most Booleans come from in practice: not from typing `true` or `false`, but from a comparison whose result is stored and used later.
```
