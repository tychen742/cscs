# Online comparison and development decisions

Reviewed October 17, 2026. Online chapters/tutorials informed the instructional comparison; existing authored content is preserved. This is not a claim of sentence-by-sentence equivalence with other books. Business traces and guided reasoning are original examples, not copied tutorial passages.

| Comparison | Structural lesson applied | Boundary retained |
| --- | --- | --- |
| Nakov: primitive types, conditionals, loops, arrays, methods, strings | Separate explanation of state/type choices and collection processing; develop examples before transferring to exercises. | Older runtime/tooling assumptions are not adopted as current C# guidance. Setup/Git stay in appendices. |
| Loyola: parameters and returned values | Explain the changes between calls, arguments, parameters and returned expressions. | All original CS1 variations remain; assignment placement is not copied. |
| Microsoft Learn methods and current language guidance | Keep return/print, type compatibility and record-copy semantics precise. | No new advanced C# feature is made a prerequisite merely because the reference lists it. |
| Microsoft C# debugger and exception guidance | Separate validation, diagnosis, recovery and regression evidence. | The core workflow precedes file APIs and assumes no arrays. |
| OpenDSA: lists/ADTs, trees, heaps, hashing and traversal | Give contracts, representation/state traces and result reasoning their own development. | Language-independent ideas are expressed in existing C# examples, not copied Java interfaces. |
| OpenDSA: analysis and DP | Distinguish cost/proof/state questions, derive tables and identify complete subproblem states. | Counting checks do not replace explanations; finite tests are not universal proofs. |
| Sedgewick/Wayne: graph algorithms and strings | Separate MST and shortest-route objectives; separate direct matching from prefix reuse. | Existing forest, directed-arc, overlap and empty-pattern policies remain. KMP here uses prefix fallback rather than copying a DFA implementation. |

## Sources consulted

- [Loyola, Function Parameters](https://introcs.cs.luc.edu/functions/funcparam.html).
- [Microsoft, C# Record Types](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/records).
- [Microsoft, Collections and Data Structures](https://learn.microsoft.com/en-us/dotnet/standard/collections/).
- [Microsoft, Exceptions and Exception Handling](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/exceptions/).
- [Microsoft, Methods in C#](https://learn.microsoft.com/en-us/dotnet/csharp/methods).
- [Nakov and colleagues, Arrays](https://introprogramming.info/english-intro-csharp-book/read-online/chapter-7-arrays/).
- [Nakov and colleagues, Conditional Statements](https://introprogramming.info/english-intro-csharp-book/read-online/chapter-5-conditional-statements/).
- [Nakov and colleagues, Methods](https://introprogramming.info/english-intro-csharp-book/read-online/chapter-9-methods/).
- [Nakov and colleagues, Primitive Types and Variables](https://introprogramming.info/english-intro-csharp-book/read-online/chapter-2-primitive-types-and-variables/).
- [Nakov and colleagues, Strings and Text Processing](https://introprogramming.info/english-intro-csharp-book/read-online/chapter-13-strings-and-text-processing/).
- [OpenDSA, Binary Trees: Chapter Introduction](https://opendsa.org/OpenDSA/Books/Catalog/html/BinaryTreeIntro.html).
- [OpenDSA, Common Analysis Misunderstandings](https://opendsa.org/OpenDSA/Books/Catalog/html/AnalMisunderstanding.html).
- [OpenDSA, Dynamic Programming](https://opendsa.org/OpenDSA/Books/CS4104/html/DynamicProgramming.html).
- [OpenDSA, Graph Traversals](https://opendsa.org/OpenDSA/Books/Catalog/html/GraphTraversal.html).
- [OpenDSA, Heaps and Priority Queues](https://opendsax.cs.vt.edu/ODSA/Books/Everything/html/Heaps.html).
- [OpenDSA, Introduction to Hashing](https://opendsax.cs.vt.edu/OpenDSA/Books/Everything/html/HashIntro.html).
- [OpenDSA, Lists: Chapter Introduction](https://opendsa.org/OpenDSA/Books/Catalog/html/ListIntro.html).
- [OpenDSA, Search in Sorted Arrays](https://opendsa.cs.vt.edu/OpenDSA/Books/Catalog/html/SortedSearch.html).
- [OpenDSA, Stacks](https://opendsa.org/OpenDSA/Books/Catalog/html/StackArray.html).
- [Sedgewick and Wayne, Minimum Spanning Trees](https://algs4.cs.princeton.edu/43mst/index.php).
- [Sedgewick and Wayne, Strings](https://algs4.cs.princeton.edu/50strings/).
- [Microsoft, C# Debugging in VS Code](https://code.visualstudio.com/docs/csharp/debugging).
- [Microsoft, Regex Anchors](https://learn.microsoft.com/en-us/dotnet/standard/base-types/anchors-in-regular-expressions).
- [Sedgewick and Wayne, Graphs](https://algs4.cs.princeton.edu/40graphs/).
- [Sedgewick and Wayne, Shortest Paths lecture](https://algs4.cs.princeton.edu/lectures/keynote/44ShortestPaths-2x2.pdf).
- [Microsoft Learn, Create Methods learning path](https://learn.microsoft.com/en-us/training/paths/get-started-c-sharp-part-5/).

Some direct OpenDSA/Princeton page opens returned errors; indexed primary-source text, the available catalog/modules and author-hosted overview/lecture pages supplied the comparison. This limitation is not a claim that unavailable full chapters were read.
