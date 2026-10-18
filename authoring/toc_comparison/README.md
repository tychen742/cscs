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
