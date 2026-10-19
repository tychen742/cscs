---
orphan: true
---

# TOC comparison with CS1 and CS2 textbooks — October 18, 2026

Compares this book's 26-chapter sequence with the tables of contents of
widely adopted C#, Java, and data-structures textbooks and suggests
revisions. Findings only; no book source was changed. Textbook TOCs were
read from publisher or author pages on October 18, 2026 (sources at the end);
where a page could not be fetched, the TOC is reconstructed from the
publisher's preview and marked as such.

Updated October 19, 2026: the three OpenDSA books were added to the
comparison, and the "OpenDSA mapping" section below maps Chapters 13 to 26
to their CS2 and CS3 sections.

## Books compared

| Group | Book | Edition and role |
| --- | --- | --- |
| C# CS1 | Harrington, *Introduction to Computer Science in C#* (introcs.cs.luc.edu) | Open; this book's stated inspiration |
| C# CS1 | Nakov et al., *Fundamentals of Computer Programming with C#* | Open; 23 chapters, CS1 plus early data structures |
| C# CS1 | Gaddis, *Starting Out with Visual C#* | 6th ed., 15 chapters, GUI-first |
| C# CS1/CS2 | Deitel, *Visual C# How to Program* | 6th ed., 21 chapters plus online |
| Java CS1 | Reges and Stepp, *Building Java Programs* | 6th ed., 14 chapters; CS1 plus early CS2 |
| Java CS1/CS2 | Liang, *Introduction to Java Programming and Data Structures, Comprehensive* | 12th ed., 30 chapters plus bonus |
| Java CS1 | Downey and Mayfield, *Think Java* | 2nd ed., open, 17 chapters (from memory, not refetched) |
| Java CS2 | Carrano and Henry, *Data Structures and Abstractions with Java* | 5th ed., 30 chapters |
| Java CS2 | Weiss, *Data Structures and Problem Solving Using Java* | 4th ed., 21 chapters in four parts |
| Java CS2 | Goodrich, Tamassia, Goldwasser, *Data Structures and Algorithms in Java* | 6th ed., 15 chapters (publisher page without TOC; list from the Wiley description and memory) |
| Java CS2/algorithms | Sedgewick and Wayne, *Algorithms* | 4th ed., 6 chapters |
| Open CS2 | Morin, *Open Data Structures* (Java) | 14 chapters |
| C# CS2 | Jamro, *C# Data Structures and Algorithms* | 2nd ed., Packt 2024, 10 chapters (publisher page blocked; first five from preview, rest from memory) |
| Open CS2 (Java) | OpenDSA, *CS2* (Virginia Tech) | Open, MIT license; 12 chapters with interactive visualizations and exercises; primary reference for Parts IV and V (added October 19, 2026) |
| Open CS2/CS3 (Java) | OpenDSA, *CS3* (Virginia Tech) | Open, MIT license; 16 chapters; primary reference for Parts IV to VII (added October 19, 2026) |
| Java CS1 (objects-first) | OpenDSA, *Introduction to Software Design* (Virginia Tech) | Open, MIT license; 15 modules; secondary reference for exercise formats only, because it is objects-first and this book's CS1 is imperative-first (added October 19, 2026) |

## Where this book already matches the field

- **CS1 spine.** Intro, variables and types, decisions, iteration, methods,
  arrays, collections, files, classes, inheritance and interfaces is the
  order used by Liang, Gaddis, Nakov, and Harrington. Methods after loops
  (Chapter 5) matches Liang 6, Gaddis 6, and Nakov 9; only Reges and Stepp
  and Harrington put functions first.
- **Exceptions and files together.** Chapter 6 and Chapter 9 echo Liang 12
  (exception handling and text I/O), Deitel 6 and 11, and Nakov 12 and 15.
- **CS2 spine.** ADT contracts and costs, array and linked lists, stacks and
  queues, searching and sorting, trees and BSTs, heaps, hashing, graphs is
  the Carrano, Goodrich, and Liang 20 to 29 order, with Sedgewick's
  sorting-then-searching-then-graphs arc in Parts VI and VII.
- **Distinctive strengths with no counterpart in the comparators:** testing
  as a Chapter 6 topic before arrays (Harrington tests only after classes;
  Liang puts JUnit in a bonus chapter), professional responsibility and AI
  literacy in Chapter 1, nullability and ownership in Chapter 11, and
  explicit contract and verification framing throughout Parts IV and V.
- **Appendices.** The optional database capstone matches Gaddis 13, Deitel
  20, and Doyle; Git and tooling appendices match Harrington's.

## Gaps and differences that matter

### 1. CS1 adopters get no search or sort algorithm (high)

Every comparator teaches linear search, binary search, and at least one
elementary sort inside CS1: Harrington's Arrays chapter, Liang 7, Gaddis 7,
Reges and Stepp 13, Deitel 16, Nakov 7 and 16. In this book the first linear
search appears in Chapter 16 and the only CS1 sorting is a library call. A
Parts I to III adopter therefore finishes CS1 without the single most
standard array algorithm pair, and Chapter 14's landing page still promises
binary search it no longer teaches (see the landing-page audit).

**Suggestion.** Add a Chapter 7 section, or extend 7.2 Processing and
Sharing Arrays, with first-match linear search, a library `Array.Sort` and
`Array.BinarySearch` call with the sorted precondition stated, and an
optional selection or insertion sort trace. Keep Chapter 16 as the CS2
contract-and-cost treatment; it can then open by recalling the Chapter 7
version. This touches the Part I order rule in AGENTS.md only in Chapter 7.

### 2. Recursion is absent from CS1 and late in CS2 (high)

Reges and Stepp 12, Liang 18, Nakov 10, Think Java 8, Harrington's Recursion
chapter, and Deitel 5 all teach recursion in CS1. In CS2 every comparator
gives recursion its own chapter before trees and sorting: Goodrich 5,
Carrano 9 and 14, Weiss 7. This book first teaches it inside 17.1 Tree
Structure and Recursive Models and completes it in Chapter 22, which the
plan marks as optional depth. Chapter 5's summary mentions recursion in one
sentence and Chapter 4's GCD page shows a recursive variant.

**Suggestion.** Two options, in order of preference:

1. Add a supporting reading "Recursive Methods" at the end of Chapter 5
   (factorial, countdown, GCD recursion already in 4.4, call-stack trace,
   when a loop is better). Supporting readings do not add a meeting. Then
   let 17.1 recall it instead of introducing it.
2. Retitle 17.1 to "Recursion and Recursive Tree Models" and move the
   recursive-contract material from 22.1 forward into it, leaving Chapter 22
   with divide and conquer and merge sort. This keeps chapter numbering.

### 3. CS2-foundation students see only insertion sort (medium-high)

Carrano 15 and 16, Goodrich 12, Liang 23, Weiss 8, Reges and Stepp 13.4, and
Sedgewick 2 all put merge sort and usually quicksort in the CS2 core. Here
merge sort is in Chapter 22 and quicksort is a supporting reading in Chapter
23, both in the optional Parts VI and VII. A Parts IV and V route therefore
never develops an O(n log n) sort.

**Suggestion.** Either list Chapter 22 as the recommended ninth CS2 unit in
BOOK_PLAN.md and the part overviews, or add 16.3 "Merge Sort as a Reporting
Workload" as a supporting reading that reuses 22.2's stable merge sort. The
second option is cheaper and keeps Chapter 22 intact.

### 4. Big-O before data structures is thinner than comparators (medium)

Carrano 4, Goodrich 4, Weiss 5, Liang 22, and Sedgewick 1.4 give algorithm
analysis a full chapter at the start of CS2. Here 13.2 "Counting Work and
Big-O" carries that role in one section, and the formal chapter is 21 in
optional Part VI. 13.2 does name O(1), O(n), O(log n), and O(n log n).

**Suggestion.** No reordering. Make 13.2 explicitly the CS2 analysis
baseline: add growth-rate table, best versus worst case, and a short
"reading a bound" checklist, and have Chapters 14 to 20 cite it rather than
Chapter 21. Keep Chapter 21 as the proof-level treatment.

### 5. No LINQ, lambdas, or delegates as a taught topic (medium, C#-specific)

Gaddis 14 and 15, Deitel 7 and 19, and Nakov 22 all teach lambda expressions
and LINQ, and `System.Linq` is imported in fourteen of this book's chapters
without being taught. 7.1 has a short "LINQ Methods" heading and 13.3 uses
`Func<>`. The CS2023 appendix already notes functional coverage as pending.

**Suggestion.** Add a supporting reading in Chapter 8, "Querying Collections
with Lambdas and LINQ" (Where, Select, OrderBy, Sum, Average, GroupBy on a
list of orders), positioned as applied extension, not core. It is the most
business-relevant C# feature the comparators cover that this book does not.

### 6. Enums, random numbers, and StringBuilder are not taught (low)

Gaddis 9 (structured data types with enums), Gaddis 5 and Reges and Stepp 5
(random numbers), and Deitel 14 (StringBuilder) cover these. Here `enum`
appears only incidentally, `Random` only in three examples, and
`StringBuilder` nowhere.

**Suggestion.** Fold enums into 11.2 Structs, Records, and Data Models (a
status enum on an order record); add `Random` to a Chapter 4 simulation
example; add `StringBuilder` to 9.3 Text Operations. Each is a subsection,
not a new reading.

### 7. Balanced search trees are mentioned but never shown (low)

Liang 26, Carrano 28, Goodrich 11, Sedgewick 3.3, and Open Data Structures 7
to 9 teach AVL or red-black trees; 17.3 names them and defers rotations.
Many IS programs skip this, so a concept-level supporting reading in Chapter
17 ("Why height matters; one rotation; use `SortedDictionary`") is enough.

### 8. Topological ordering is missing from the graph chapters (low)

Goodrich 14, Sedgewick 4.2, and Liang 28 cover topological sort; it is the
graph algorithm closest to business scheduling (task dependencies, course
prerequisites, build order). Chapter 20 has DFS and components and Chapter 24
has MST and shortest paths, but no DAG ordering.

**Suggestion.** Add a DFS-based topological ordering subsection to 20.4 or a
short 24.4 supporting reading.

### 9. Chapter 15 applications are lighter than comparators (low)

Weiss 11 and Reges and Stepp 12.5 evaluate expressions (infix to postfix)
with a stack; Chapter 15 has delimiter matching and undo/redo. Postfix
evaluation is a classic that also motivates recursion. Optional addition to
15.3.

### 10. Naming and labeling (low, editorial)

- Sidebar labels diverge from chapter titles: "ADTs", "Linear Lists",
  "Analysis", "Recursion", "Greedy Algorithms", "Dynamic Programming",
  "Advanced Algorithms". Comparators use the full title in the TOC. Consider
  aligning sidebar labels with the landing-page titles or shortening both.
- "Chapter 16 Searching and Basic Sorting" and "Chapter 23 Advanced Searching
  and Sorting" read as a split of one comparator chapter; the Chapter 16
  landing now says what the split means, so Chapter 23's landing should
  say the same from its side.
- The book's Out of Scope list names web and mobile; add desktop GUI, which
  Gaddis, Deitel, Reges and Stepp, and Liang all include, so adopters know
  the omission is deliberate.

## What not to change

- Keep methods after iteration (Chapter 5): the majority of comparators do
  the same, and the Part I order rule already settled it.
- Keep testing in Chapter 6 before arrays; it is a strength, not a gap.
- Keep Chapter 1's responsibility and AI-literacy material; no comparator
  has it, and IS2020 rewards it.
- Keep Parts VI and VII selectable. Sedgewick and Goodrich show the same
  material as a third course, so making it optional matches practice.
- Do not add GUI, networking, threads, or web chapters; they are out of
  scope by design and would dilute the console-plus-tests workflow.

## Suggested priority

1. Linear search, library sort, and binary search precondition in Chapter 7
   (gap 1), with Chapter 14's landing page corrected at the same time.
2. Recursive Methods supporting reading in Chapter 5 and 17.1 recall (gap 2).
3. Merge sort supporting reading or Chapter 22 recommended for CS2 (gap 3).
4. 13.2 as the explicit CS2 analysis baseline (gap 4).
5. LINQ and lambdas supporting reading in Chapter 8 (gap 5).
6. Small subsections: enums, Random, StringBuilder, topological ordering,
   balanced-tree concept, postfix evaluation (gaps 6 to 9).
7. Sidebar label and scope wording (gap 10).

Items 1 to 3 change what a CS1-only or CS2-foundation-only adopter can
teach; the rest are completeness. Every item can be added as a supporting
reading or subsection without renumbering chapters or changing assessment
IDs.

## OpenDSA mapping

OpenDSA (Virginia Tech) publishes open, MIT-licensed data structures and
algorithms eTextbooks with Java code, interactive JSAV slideshows, and
auto-graded exercises. For this book, [CS2](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/) and [CS3](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/) are the
primary references for Parts IV to VII, and [Introduction to Software
Design](https://opendsa-server.cs.vt.edu/OpenDSA/Books/IntroToSoftwareDesign/html/) is a secondary reference for exercise formats only: it is an
objects-first Java CS1, while Parts I to III here are imperative-first. The
table maps each chapter of Parts IV to VII to the matching OpenDSA sections
(tables of contents fetched October 19, 2026). Link to the
`opendsa-server.cs.vt.edu` host: `opendsa.org` serves a certificate for that
host name and fails strict fetches.

| This book | OpenDSA CS2 | OpenDSA CS3 | Notes |
| --- | --- | --- | --- |
| 13 Abstract Data Types (13.1 contracts, 13.2 representations and costs, 13.3 generics, 13.4 iterators) | [1.2 Abstract Data Types](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/ADT.html), [3.1 A List ADT](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/ListADT.html), [4.2 Comparing Algorithms](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/AnalIntro.html), [4.5 Asymptotic Analysis and Upper Bounds](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/AnalAsymptotic.html) | [1.2 Abstract Data Types](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/ADT.html), [5.1 Chapter Introduction: Lists](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/ListIntro.html), [5.2 A List ADT](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/ListADT.html), [4.3 Comparing Algorithms](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/AnalIntro.html), [4.6 Asymptotic Analysis and Upper Bounds](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/AnalAsymptotic.html) | OpenDSA states the List ADT as a Java interface; this book states contracts as observable histories first. Generics and iterators have no OpenDSA section. |
| 14 Arrays and Linked Lists | [3.2 Array-Based List Implementation](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/ListArray.html), [5.7 Link Nodes](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/Links1.html), [10.1 Linked Lists](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/ListLinked.html), [10.2 Comparison of List Implementations](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/ListAnalysis.html), [10.3 Doubly Linked Lists](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/ListDouble.html) | [5.3 Array-Based List Implementation](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/ListArray.html), [5.4 Linked Lists](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/ListLinked.html), [5.5 Comparison of List Implementations](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/ListAnalysis.html), [5.6 Doubly Linked Lists](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/ListDouble.html) | CS2 Chapter 5 (Pointers) teaches Java references at length; 14.2 covers the needed subset. Freelists (10.5, 5.10) are not taught here. |
| 15 Stacks and Queues | [6.1 Stacks](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/StackArray.html), [6.2 Linked Stacks](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/StackLinked.html), [9.1 Queues](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/Queue.html), [9.2 Linked Queues](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/QueueLinked.html) | [5.8 Stacks](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/StackArray.html), [5.9 Linked Stacks](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/StackLinked.html), [5.11 Implementing Recursion](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/StackRecur.html), [5.12 Queues](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/Queue.html), [5.13 Linked Queues](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/QueueLinked.html) | The ring buffer in 15.2 matches the circular queue in 9.1 and 5.12. 5.11 supports the backtracking-with-a-stack application in 15.3. |
| 16 Searching and Basic Sorting (16.3 Merge Sort is a supporting reading) | [8.1 Chapter Introduction: Sorting](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/InSort.html), [8.2 Sorting Terminology and Notation](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/SortNotation.html), [8.3 Comparing Records](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/Comparison.html), [8.4 Insertion Sort](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/InsertionSort.html) | [8.2 Sorting Terminology and Notation](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/SortNotation.html), [6.3 Comparing Records](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/Comparison.html), [8.3 Insertion Sort](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/InsertionSort.html), [8.9 Mergesort Concepts](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/Mergesort.html), [8.10 Implementing Mergesort](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/MergesortImpl.html) | Neither book has a searching chapter; the catalog module [Search in Sorted Arrays](https://opendsa-server.cs.vt.edu/OpenDSA/Books/Catalog/html/SortedSearch.html) (binary search, already cited in 16.1) is the closest match. |
| 17 Trees and Binary Search Trees | [7.1 Introduction to Recursion](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/RecIntro.html), [7.7 Tracing Recursive Code](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/Trace.html), [11.1 Binary Trees Chapter Introduction](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/BinaryTreeIntro.html), [11.2 Binary Trees](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/BinaryTree.html), [11.3 Binary Tree Traversals](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/BinaryTreeTraversal.html), [11.4 Binary Search Trees](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/BST.html) | [7.2 Binary Trees](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/BinaryTree.html), [7.3 Binary Tree as a Recursive Data Structure](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/RecursiveDS.html), [7.5 Binary Tree Traversals](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/BinaryTreeTraversal.html), [7.6 Implementing Tree Traversals](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/WritingTraversals.html), [7.7 Information Flow in Recursive Functions](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/BinaryTreeInfFlw.html), [7.11 Binary Search Trees](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/BST.html), [7.12 Dictionary Implementation Using a BST](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/BSTDict.html) | CS3 7.7 and 7.13 (information flow) match the returned-value emphasis of 17.4. The Full Binary Tree Theorem (7.4) and expression trees (7.9) are not taught here. |
| 18 Priority Queues and Heaps | No CS2 section. | [7.16 Array Implementation for Complete Binary Trees](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/CompleteTree.html), [7.17 Heaps and Priority Queues](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/Heaps.html) | [8.12 Heapsort](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/Heapsort.html) is a natural extension of 18.2 that this book does not teach; 18.3 uses the heap for top-k selection instead. |
| 19 Hash Collections and Sets | No CS2 section. | [6.4 The Dictionary ADT](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/Dictionary.html), [10.1 Introduction to Hashing](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/HashIntro.html), [10.2 Hash Function Principles](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/HashFunc.html), [10.3 Sample Hash Functions](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/HashFuncExamp.html), [10.4 Open Hashing](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/OpenHash.html), [10.6 Collision Resolution](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/HashCSimple.html), [10.7 Improved Collision Resolution](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/HashCImproved.html), [10.8 Analysis of Closed Hashing](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/HashAnal.html), [10.9 Hahing Deletion (sic)](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/HashDel.html) | Terminology differs: OpenDSA's open hashing is this book's separate chaining, and its closed hashing is this book's open addressing. 19.2 and 19.3 (sets, reconciliation, collection selection) have no OpenDSA counterpart. |
| 20 Graphs and Traversal | No CS2 section. | [14.1 Graphs Chapter Introduction](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/GraphIntro.html), [14.2 Graph Implementations](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/GraphImpl.html), [14.3 Graph Traversals](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/GraphTraversal.html) | [14.4 Topological Sort](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/GraphTopsort.html) covers gap item 8 above, with DFS-based and queue-based versions; a 20.4 subsection could cite it. |
| 21 Algorithm Analysis | [4.1 Problems, Algorithms, and Programs](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/AnalPrelim.html), [4.3 Best, Worst, and Average Cases](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/AnalCases.html), [4.4 Faster Computer, or Faster Algorithm?](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/AnalCompvsAlg.html), [4.6 Calculating Program Running Time](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/AnalProgram.html) | [3.4 Logarithms](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/Logarithms.html), [3.5 Summations Introduction](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/Summations.html), [3.6 An Introduction to Recurrence Relations](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/RecurrenceIntro.html), [3.7 Mathematical Proof Techniques](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/Proofs.html), [4.7 Lower Bounds and Theta Notation](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/AnalLower.html), [4.8 Calculating Program Running Time](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/AnalProgram.html), [4.9 Analyzing Problems](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/AnalProblem.html), [4.10 Common Misunderstandings](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/AnalMisunderstanding.html), [4.11 Multiple Parameters](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/AnalMultiple.html), [4.12 Space Bounds](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/AnalSpace.html), [4.13 Code Tuning and Empirical Analysis](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/AnalTuning.html) | 21.2 Correctness and Invariants has no OpenDSA counterpart beyond 3.7 (proof techniques). 13.2 remains the CS2 analysis baseline (gap item 4). |
| 22 Recursion and Divide and Conquer | [7.1 Introduction to Recursion](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/RecIntro.html), [7.2 Writing a recursive function](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/Write.html), [7.4 Writing More Sophisticated Recursive Functions](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/HarderWrite.html), [7.7 Tracing Recursive Code](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/Trace.html) | [3.6 An Introduction to Recurrence Relations](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/RecurrenceIntro.html), [8.9 Mergesort Concepts](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/Mergesort.html), [8.10 Implementing Mergesort](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/MergesortImpl.html) | CS2 Chapter 7 is the model for code-completion and tracing exercise formats (gap item 2); the recursion reading 5.6 can cite it. |
| 23 Advanced Searching and Sorting | [8.4 Insertion Sort](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/InsertionSort.html), [8.5 Bubble Sort](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/BubbleSort.html), [8.6 Selection Sort](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/SelectionSort.html) | [8.3 Insertion Sort](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/InsertionSort.html), [8.4 Bubble Sort](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/BubbleSort.html), [8.5 Selection Sort](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/SelectionSort.html), [8.6 The Cost of Exchange Sorting](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/ExchangeSort.html), [8.7 Optimizing Sort Algorithms with Code Tuning](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/SortOpt.html), [8.8 Shellsort](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/Shellsort.html), [8.11 Quicksort](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/Quicksort.html), [8.15 An Empirical Comparison of Sorting Algorithms](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/SortingEmpirical.html), [8.16 Lower Bounds for Sorting](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/SortingLowerBound.html) | 8.16 gives the decision-tree lower bound this book mentions but does not prove. Heapsort, [Binsort](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/BinSort.html), and [Radix Sort](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/RadixSort.html) (8.12 to 8.14) are not taught here. 23.1 (lower and upper bounds for duplicates) has no counterpart. |
| 24 Greedy Choices and Graph Optimization | No CS2 section. | [13.2 Union/Find and the Parent Pointer Implementation](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/UnionFind.html), [14.5 Shortest-Paths Problems](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/GraphShortest.html), [14.6 Minimal Cost Spanning Trees](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/MCST.html), [14.7 Kruskal's Algorithm](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/Kruskal.html) | 14.6 presents Prim, which this book omits in favor of Kruskal. [14.8 All-Pairs Shortest Paths](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/Floyd.html) is not taught. The exchange argument of 24.1 has no OpenDSA counterpart. |
| 25 Dynamic Programming and Backtracking | No CS2 section. | No CS3 section. | OpenDSA covers dynamic programming only in its CS4104 (algorithms) book, which 25.1 to 25.3 already cite in their footnotes. Backtracking has no OpenDSA module. |
| 26 Strings, Prefix Matching, and Limits | No CS2 section. | [4.7 Lower Bounds and Theta Notation](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/AnalLower.html), [4.9 Analyzing Problems](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/AnalProblem.html) | OpenDSA has no string-matching module, so 26.1 and 26.2 (direct matching and KMP) have no counterpart. Huffman coding (7.18, 7.20) is a greedy case this book does not teach. |

### CS3 topics deliberately omitted

- Chapter 2 (Java and Eclipse tooling, JUnit, mutation testing): tooling
  belongs to Appendix B, and testing is taught in C# in Chapter 6.
- Chapter 9 File Processing (disk drives, buffer pools, external sorting):
  Chapter 9 here teaches text files at the application level only.
- Chapter 11 Memory Management (sequential fit, buddy method, garbage
  collection): .NET manages memory; Chapter 11 covers references and
  ownership at the language level.
- Chapter 12 Indexing (linear indexing, ISAM, 2-3 trees, B-trees): database
  internals are out of scope; the database appendix uses SQLite as a client.
- Chapter 15 Advanced Data Structures (sparse matrix, skip lists, spatial
  structures: PR quadtree, KD tree, bintree): beyond an IS/IT program's
  needs.
- Within taught chapters: freelists, the Full Binary Tree Theorem,
  expression trees, heapsort, binsort and radix sort, Prim's algorithm,
  Floyd's all-pairs shortest paths, and Huffman coding trees.

### Earlier gap items that CS3 covers

- Gap 8, topological ordering: [14.4 Topological
  Sort](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/GraphTopsort.html) gives DFS-based and queue-based versions
  with slideshows; a 20.4 or 24.4 subsection can point there.
- Sorting lower bounds: [8.16 Lower Bounds for
  Sorting](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/SortingLowerBound.html) and [4.7 Lower Bounds and Theta
  Notation](https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/AnalLower.html) supply the decision-tree argument that 26.3
  mentions and Chapters 21 and 23 can cite.
- Gap 2, recursion exercises: CS2 Chapter 7 is a model for code-completion
  and tracing exercise formats, usable from the 5.6 and 22.1 readings.
- Gap 7, balanced trees: not covered by CS2 or CS3 either, apart from 2-3
  trees inside the omitted indexing chapter. The concept-level reading
  suggested above still has no OpenDSA counterpart.

## Sources

- Harrington, introcs.cs.luc.edu, fetched TOC.
- Nakov, introprogramming.info/english-intro-csharp-book/read-online/, fetched.
- Gaddis 6e, pearson.com/en-us/subject-catalog/p/starting-out-with-visual-c/P200000010677, fetched.
- Deitel 6e, pearson.com/en-us/subject-catalog/p/visual-c-how-to-program/P200000003492, fetched.
- Reges and Stepp 6e, buildingjavaprograms.com/toc.shtml, fetched.
- Liang 12e, informit.com/store/introduction-to-java-programming-and-data-structures-9780136520238, fetched.
- Carrano and Henry 5e, pearson.com/en-us/subject-catalog/p/data-structures-and-abstractions-with-java/P200000003498, fetched.
- Weiss 4e, pearson.com/en-us/subject-catalog/p/.../P200000003443 and informit.com, from search summaries.
- Goodrich, Tamassia, Goldwasser 6e, wiley.com product page (TOC not served); chapter list from the Wiley India description and memory.
- Sedgewick and Wayne 4e, algs4.cs.princeton.edu/home/, fetched.
- Morin, opendatastructures.org/ods-java/, fetched.
- Jamro 2e, packtpub.com product 9781803248271 (403 on fetch); chapters 1 to 5 from the Packt preview in search results, rest from memory.
- Downey and Mayfield, Think Java 2e, from memory (trinket.io redirect not followed).
- OpenDSA CS2, https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS2/html/, fetched TOC October 19, 2026.
- OpenDSA CS3, https://opendsa-server.cs.vt.edu/OpenDSA/Books/CS3/html/, fetched TOC October 19, 2026.
- OpenDSA Introduction to Software Design, https://opendsa-server.cs.vt.edu/OpenDSA/Books/IntroToSoftwareDesign/html/, fetched TOC October 19, 2026.
