# Section-boundary review

Planning review, October 17, 2026. Recommendations are not implemented notebook changes.

The size inventory is a screening tool. Boundaries below are judged by the instructional problem, prerequisite order, topic relationships, changes of reasoning, and practice progression. A short page with a distinct role normally needs expansion. A long page warrants a split when it contains multiple substantial learning sequences. Three meetings do not require three reading pages.

This review uses the current 26-chapter TOC, each chapter's MATERIALS.md and ORGANIZATION.md, notebook headings, explanatory passages and examples. It is a structural/content-development plan, not a new correctness audit or a claim that every topic is adequate. Published supporting readings are separated from required core below.

## Recommendations across the book

| Chapter | Current published content pages | Proposed core readings | Recommendation | Priority |
| --- | ---: | ---: | --- | --- |
| 1. Computing, Programs, and Responsibility | 3 | 3 | Retain; clarify internal reading levels | Later |
| 2. Variables & Types | 3 | 4 | Split Variables and Types | High |
| 3. Conditionals | 3 | 2 | Combine Switch with selection forms | High |
| 4. Iteration | 4 | 3 | Retain three core lessons and GCD support | Medium |
| 5. Methods | 5 | 5 | Redistribute the overloaded design lesson | High |
| 6. Testing, Debugging, and Error Handling | 4 | 3 | Retain distinct lessons; expand two thin ones | High |
| 7. Arrays | 2 | 3 | Split the one-dimensional array lesson | High |
| 8. Data Collections | 3 | 4 | Split the collection overview by instructional role | High |
| 9. Files and Text | 5 | 3 | Recombine file basics; integrate thin regex orientation | High |
| 10. Classes and Objects | 4 | 3 | Retain core progression and Averager support | Medium |
| 11. Object Design and Composition | 4 | 4 | Split reference semantics from struct/record design | High |
| 12. Inheritance, Interfaces, and Polymorphism | 4 | 3 | Retain the three conceptual boundaries | High |
| 13. ADTs | 4 | 4 | Retain four roles; develop the foundations | High |
| 14. Linear Lists | 3 | 3 | Retain representation-to-comparison sequence | Medium |
| 15. Stacks & Queues | 3 | 3 | Retain; organize queue complexity internally | Medium |
| 16. Searching and Basic Sorting | 3 | 2 | Combine workload material into two developed lessons | High |
| 17. Trees | 3 | 4 | Split the initial tree/recursion/traversal lesson | High |
| 18. Priority Queues and Heaps | 3 | 3 | Retain contract, implementation, and application roles | High |
| 19. Hash Collections and Sets | 3 | 3 | Retain hashing, set semantics, and coordination | High |
| 20. Graphs and Traversal | 3 | 4 | Split BFS/path reasoning from DFS/components | High |
| 21. Analysis | 3 | 3 | Retain three distinct analysis tools | High |
| 22. Recursion | 3 | 2 | Combine recursive design; retain merge sort as a full lesson | High |
| 23. Advanced Searching and Sorting | 4 | 3 | Retain advanced core; separate optional sort families | High |
| 24. Greedy Algorithms | 3 | 3 | Split spanning forests from shortest paths; distribute verification | High |
| 25. Dynamic Programming | 3 | 3 | Split DP foundations from optimization modeling; integrate verification | High |
| 26. Advanced Algorithms | 3 | 3 | Reframe around string algorithms and limits | High |

## Preservation and implementation gates

No notebook, TOC, published URL, assessment identity, or example is moved by this pass. For a later implementation: inventory each original cell and distinct explanation/exercise; map every source to a destination; develop thin receiving lessons before moving content; preserve all variants, code, figures, citations and outputs; retain original exercise/assignment IDs; update links, navigation labels, landing pages, Chapter Topics, and published-URL redirects together. Keep short navigation labels separate from full page headings.

Content sections teach. Assignments apply. Pages currently called Lab but containing explanations remain content until their teaching passages have explicit content destinations. Supporting readings remain available, including the full GCD, unit-testing walkthrough, Averager, restored OOP variants, and optional advanced sorts. Setup and Git remain in appendices.

## Chapter-specific rationale

### 1. Computing, Programs, and Responsibility

**Retain; clarify internal reading levels.** The three pages answer different questions: how computing solves problems, what responsible decisions require, and how to run/read a program. Word count alone does not justify combining them.

Proposed core: Computing and problem solving → Computing and professional responsibility → First program and basic syntax.

Strengthen transitions between development workflow and the first program; use a visible reading path rather than creating separate pages for every platform detail.

Planning: [ORGANIZATION.md](../chapters/01_context/ORGANIZATION.md) and [MATERIALS.md](../chapters/01_context/MATERIALS.md).

### 2. Variables & Types

**Split Variables and Types.** 0201 combines changing variable state with a substantial type taxonomy and conversion lesson. These are distinct beginner reasoning tasks. 0202 and 0203 already provide separate application roles.

Proposed core: Variables, assignment, and state → Types, representation, and conversion → Operators and built-in calls → Console input and formatted output.

Develop type selection and numeric conversion through worked decisions, not only a hierarchy/table. Each resulting page needs a coherent problem and guided application before any physical split.

Planning: [ORGANIZATION.md](../chapters/02_var_data/ORGANIZATION.md) and [MATERIALS.md](../chapters/02_var_data/MATERIALS.md).

### 3. Conditionals

**Combine Switch with selection forms.** The 249-word switch page describes a related selection form but does not develop an independent problem. Combining it with conditional selection supports direct comparison. Boolean reasoning remains a separate prerequisite.

Proposed core: Boolean expressions and decision reasoning → Selection with if, else-if, nested conditions, and switch.

Expand switch explanation and decision-table practice before merging; combining three short descriptions is not adequate instruction by itself.

Planning: [ORGANIZATION.md](../chapters/03_decision/ORGANIZATION.md) and [MATERIALS.md](../chapters/03_decision/MATERIALS.md).

### 4. Iteration

**Retain three core lessons and GCD support.** Planning repetition, counted traversal, and condition-controlled repetition have different instructional roles. The complete GCD lesson is a supporting case, not a fourth required meeting.

Proposed core: Iteration models and loop planning → Counted loops, traversal, and nested repetition → Condition-controlled loops, input, and termination.

Develop loop selection and invariant/state traces; distinguish required fundamentals from optional mathematical cases. No new page is needed simply to meet a three-meeting template.

Planning: [ORGANIZATION.md](../chapters/04_iteration/ORGANIZATION.md) and [MATERIALS.md](../chapters/04_iteration/MATERIALS.md).

### 5. Methods

**Redistribute the overloaded design lesson.** 0502 mixes initial definition/call mechanics with returned-value reasoning and contract checks. Meanwhile 0505 repeats syntax/scope reference material. Redistributing those topics yields five focused lessons without adding a sixth.

Proposed core: Decomposition, definitions, and calls → Parameters, scope, and local state → Returned results, contracts, and return paths → String methods and composed transformations → Method composition, refactoring, and checks.

Add fuller method-boundary design reasoning, Boolean-returning helpers, argument-expression/type variations, and multi-step string reasoning. This plan does not declare the recent revision fully adequate.

Planning: [ORGANIZATION.md](../chapters/05_methods/ORGANIZATION.md) and [MATERIALS.md](../chapters/05_methods/MATERIALS.md).

### 6. Testing, Debugging, and Error Handling

**Retain distinct lessons; expand two thin ones.** Validation/recovery, diagnosing a defect, and testing a contract are different skills. The 280-word and 313-word pages need teaching development, not consolidation that hides missing instruction.

Proposed core: Validation and recoverable exceptions → Systematic debugging → Repeatable tests and a unit-test workflow.

Add interpreted error examples, validation/failure-policy comparisons and an actual debugging walkthrough. The large testing page is not evidence that the other two lessons are adequate.

Planning: [ORGANIZATION.md](../chapters/06_exceptions_testing/ORGANIZATION.md) and [MATERIALS.md](../chapters/06_exceptions_testing/MATERIALS.md).

### 7. Arrays

**Split the one-dimensional array lesson.** 0701 moves from declaration/indexing to command-line parameters and reference aliasing. Creating/accessing a collection and reasoning about processing/sharing it deserve separate teaching sequences.

Proposed core: Arrays as fixed-length indexed collections → Processing arrays, method arguments, and shared references → Rectangular multidimensional arrays.

Develop sum/count/search or transformation traces and guided tasks before the processing page is separated. Explain reference copying before its method-side effects; use command-line tooling as an application rather than the definition of array processing.

Planning: [ORGANIZATION.md](../chapters/07_arrays/ORGANIZATION.md) and [MATERIALS.md](../chapters/07_arrays/MATERIALS.md).

### 8. Data Collections

**Split the collection overview by instructional role.** 0801 contains 5,337 prose words, family orientation, generic notation, operation tables, behavioral demonstrations and reference sharing. The big-idea map should remain first, but the operational development can have its own focused reading.

Proposed core: Collection big ideas, families, and selection → Shared operations, syntax, traversal, and behavioral comparisons → Lists → Dictionaries.

The new operations lesson must connect the tables to interpreted behavior. Keep linked lists/sets/stacks/queues/priority queues at recognition level; detailed implementations remain in Chapters 14, 15, 18 and 19.

Planning: [ORGANIZATION.md](../chapters/08_collections/ORGANIZATION.md) and [MATERIALS.md](../chapters/08_collections/MATERIALS.md).

### 9. Files and Text

**Recombine file basics; integrate thin regex orientation.** 0901 introduces File operations that overlap 0902, while 0902 has competing top-level titles. 0903 and the 297-word regex page need a connected text-processing development rather than two thin API tours.

Proposed core: File model and basic reading/writing → Paths, streaming workflows, failure handling, and cleanup → Text records, validation, and pattern-based processing.

Develop malformed-record handling, partial processing, resource cleanup and a sustained worked import. Do not let moving regex examples substitute for explanation of patterns and groups.

Planning: [ORGANIZATION.md](../chapters/09_files_text/ORGANIZATION.md) and [MATERIALS.md](../chapters/09_files_text/MATERIALS.md).

### 10. Classes and Objects

**Retain core progression and Averager support.** Class construction, encapsulation, and tracing state through clients have distinct purposes. The retained Averager is supporting development of the same ideas, not an additional required introductory lesson.

Proposed core: Classes, objects, and construction → Controlled state through properties and behavior → Independent instances, state traces, and model checks.

Use identity/reference and constructor state traces consistently. Preserve the full old development alongside the newer business examples.

Planning: [ORGANIZATION.md](../chapters/10_classes/ORGANIZATION.md) and [MATERIALS.md](../chapters/10_classes/MATERIALS.md).

### 11. Object Design and Composition

**Split reference semantics from struct/record design.** 1101 now teaches both reference/alias semantics and several new type forms. A proper struct/record introduction has its own syntax, copy/equality reasoning and selection decisions. The short nullability page should support relevant object contracts rather than stand alone as another required meeting.

Proposed core: References, identity, mutation, and copying → Structs, records, and selecting a data model → Composition, ownership, and optional relationships → Testing collaborating objects.

Expand structs/records beyond a quick syntax comparison and develop null versus empty/zero, annotations versus runtime guards, and shallow-copy consequences before exercises.

Planning: [ORGANIZATION.md](../chapters/11_object_design/ORGANIZATION.md) and [MATERIALS.md](../chapters/11_object_design/MATERIALS.md).

### 12. Inheritance, Interfaces, and Polymorphism

**Retain the three conceptual boundaries.** The three core pages are short but represent different reasoning tasks. Combining them would obscure substitution, dynamic dispatch and capability contracts rather than solve underdevelopment.

Proposed core: Inheritance and substitution → Runtime dispatch and abstract classes → Interfaces and interchangeable collaborators.

Add slower worked client-call reasoning, common failures and guided design comparisons. Supporting examples do not replace core explanation.

Planning: [ORGANIZATION.md](../chapters/12_oop/ORGANIZATION.md) and [MATERIALS.md](../chapters/12_oop/MATERIALS.md).

### 13. ADTs

**Retain four roles; develop the foundations.** Contracts, representations, generics and iterators are distinct foundations for CS2. Their low counts do not make them redundant; merging them now would conceal missing development.

Proposed core: ADT behavior and contracts → Representations, invariants, and elementary costs → Defining reusable generic types and policies → Iteration contracts and lazy traversal.

Use one contract across client, alternate representations, generic implementation and enumeration. Add worked transitions and counterexamples before independent implementation.

Planning: [ORGANIZATION.md](../chapters/13_abstract_data_types/ORGANIZATION.md) and [MATERIALS.md](../chapters/13_abstract_data_types/MATERIALS.md).

### 14. Linear Lists

**Retain representation-to-comparison sequence.** The two implementation lessons and the comparison lesson have distinct outcomes. The comparison page contains instruction, so its Lab title should not cause explanations to be moved out of content.

Proposed core: Dynamic arrays → Linked representations → Comparing representations under the same contract.

Preserve the workload comparison and all implementation variants; clarify navigation/lesson-versus-assignment roles. Remove stale planning claims that search remains in Chapter 14; the core search lesson is Chapter 16.

Planning: [ORGANIZATION.md](../chapters/14_arrays_linked_lists/ORGANIZATION.md) and [MATERIALS.md](../chapters/14_arrays_linked_lists/MATERIALS.md).

### 15. Stacks & Queues

**Retain; organize queue complexity internally.** LIFO, FIFO and applied policy selection form a coherent sequence. Queue/ring/deque details need layered development, but the current short page should be developed before considering another notebook.

Proposed core: Stack behavior and implementation → Queues, ring buffers, and deque tradeoffs → Access policies, undo/redo, and worklist applications.

Develop ring-state traces and the relationship between logical and physical order. Do not combine stacks and queues merely because both restrict access.

Planning: [ORGANIZATION.md](../chapters/15_stacks_queues/ORGANIZATION.md) and [MATERIALS.md](../chapters/15_stacks_queues/MATERIALS.md).

### 16. Searching and Basic Sorting

**Combine workload material into two developed lessons.** 1603 applies the searches and sorting already introduced; its 513 words work as synthesis within those two lessons. The result should be two full lessons, not a thin chapter compressed into fewer pages.

Proposed core: Search contracts, traces, and repeated queries → Ordering, insertion sort, and safe reporting workloads.

Expand successful/missing/duplicate search traces, insertion movement, sorted-prefix reasoning and independent order/preservation checks before consolidation. These are core CS2 lessons, not optional advanced prerequisites.

Planning: [ORGANIZATION.md](../chapters/16_searching_sorting/ORGANIZATION.md) and [MATERIALS.md](../chapters/16_searching_sorting/MATERIALS.md).

### 17. Trees

**Split the initial tree/recursion/traversal lesson.** 1701 introduces tree vocabulary, first recursion, traversal timing and height/space costs in one page. First encountering recursive control flow deserves space before comparing traversal algorithms.

Proposed core: Tree structure and recursive modeling → Traversal orders, call/return traces, and costs → BST contracts and complete updates → Applied queries and independent verification.

Expand stack-frame traces and connect visits versus returned values. Four reading pages can support three meetings; do not cut deletion cases to fit the meeting count.

Planning: [ORGANIZATION.md](../chapters/17_trees/ORGANIZATION.md) and [MATERIALS.md](../chapters/17_trees/MATERIALS.md).

### 18. Priority Queues and Heaps

**Retain contract, implementation, and application roles.** The application page is short but top-K and fairness are genuine transfers, not duplicate heap syntax. All three pages need expansion rather than automatic merging.

Proposed core: Priority contracts and heap representation → Heap operations and invariants → Priority workloads, top-K, and fairness.

Add index/parent reasoning, empty/singleton/tied-priority traces, heap versus sorted-order distinctions and top-K justification. Correct generic planning text that claims graph traversal is this chapter's direct assessment target.

Planning: [ORGANIZATION.md](../chapters/18_priority_queues/ORGANIZATION.md) and [MATERIALS.md](../chapters/18_priority_queues/MATERIALS.md).

### 19. Hash Collections and Sets

**Retain hashing, set semantics, and coordination.** Set algebra is not simply a shorter form of dictionary storage, and coordinating multiple indexes has its own consistency contract. The three roles should remain while underdeveloped explanations are expanded.

Proposed core: Hashing, key equality, and collision handling → Set algebra, frequency counts, and reconciliation → Selecting and coordinating collection indexes.

Add worked collision/deletion/rehash reasoning, equality-policy examples and set membership diagrams. Align assignment-role prose with hashing/reconciliation rather than copied graph-traversal wording.

Planning: [ORGANIZATION.md](../chapters/19_hash_collections/ORGANIZATION.md) and [MATERIALS.md](../chapters/19_hash_collections/MATERIALS.md).

### 20. Graphs and Traversal

**Split BFS/path reasoning from DFS/components.** 2003 packs two traversal strategies, path reconstruction, cycle behavior and connectivity into 504 prose words. Different worklist semantics and correctness arguments need distinct teaching sequences.

Proposed core: Graph modeling and contracts → Adjacency representations and update invariants → BFS discovery, layers, and predecessor paths → DFS, cycles, components, and verification.

Develop frontier/visited/predecessor state tables, marking-time mistakes and direction-sensitive component reasoning before splitting physically. Do not create two skeletal outlines.

Planning: [ORGANIZATION.md](../chapters/20_graphs/ORGANIZATION.md) and [MATERIALS.md](../chapters/20_graphs/MATERIALS.md).

### 21. Analysis

**Retain three distinct analysis tools.** Growth analysis, proof of behavior and recursive cost modeling answer different questions. The 515-672-word pages are compressed treatments of substantial topics; merging them would not resolve missing explanation.

Proposed core: Cost models and asymptotic bounds → Correctness, invariants, and termination → Recurrences, total work, and active storage.

Add derivations and interpreted diagrams between formulas and code. Current runnable checks and historical verification notes do not demonstrate adequate proof instruction.

Planning: [ORGANIZATION.md](../chapters/21_algorithm_analysis/ORGANIZATION.md) and [MATERIALS.md](../chapters/21_algorithm_analysis/MATERIALS.md).

### 22. Recursion

**Combine recursive design; retain merge sort as a full lesson.** 2201 is a 405-word bridge after introductory recursion moved to Chapter 17. It naturally precedes the decomposition/range reasoning in 2202. The merge implementation has a separate substantial combining-and-verification role.

Proposed core: Recursive contracts and divide-and-conquer design → Stable merge sort, verification, and measured work.

Expand call/return and half-open/odd-split traces plus the combining step. Two reading sections do not require reducing the original example set or squeezing all teaching into two meetings.

Planning: [ORGANIZATION.md](../chapters/22_recursion_divide_conquer/ORGANIZATION.md) and [MATERIALS.md](../chapters/22_recursion_divide_conquer/MATERIALS.md).

### 23. Advanced Searching and Sorting

**Retain advanced core; separate optional sort families.** Search-result policies, sort invariants and fair comparisons remain distinct even after basics moved to Chapter 16. Optional Shell sort and quicksort are different algorithms and should not be rushed in one reference tour.

Proposed core: Duplicate-aware search contracts → Elementary sort behavior, invariants, and stability → Equivalent-workload comparison.

Expand duplicate-bound traces and comparison-count interpretation. Develop each optional algorithm before separating the pages; short pages are not the goal.

Planning: [ORGANIZATION.md](../chapters/23_searching_sorting/ORGANIZATION.md) and [MATERIALS.md](../chapters/23_searching_sorting/MATERIALS.md).

### 24. Greedy Algorithms

**Split spanning forests from shortest paths; distribute verification.** 2402 combines different optimization objectives, graph contracts, invariants and proofs. The 389-word verification page is better used beside each relevant algorithm plus a final comparison than as an underspecified third meeting.

Proposed core: Greedy choices, objectives, and exchange reasoning → Minimum spanning forests and Kruskal → Single-source shortest paths and Dijkstra.

Develop stepwise union/find and relaxation/queue traces, why each greedy choice is safe, and independent witness checks. Word count is low even though topic load is high.

Planning: [ORGANIZATION.md](../chapters/24_greedy_graph_optimization/ORGANIZATION.md) and [MATERIALS.md](../chapters/24_greedy_graph_optimization/MATERIALS.md).

### 25. Dynamic Programming

**Split DP foundations from optimization modeling; integrate verification.** 2501 moves from counting Fibonacci to deriving minimum-coin optimal substructure and reconstruction. 2502 has a different exhaustive-search design. Verification in 2503 belongs beside these respective reasoning steps.

Proposed core: Repeated subproblems, memoization, and tabulation → Modeling an optimum and reconstructing a solution → Backtracking, pruning, and search-state correctness.

Develop tables and decision/reconstruction traces, explain state sufficiency and optimal substructure, and contrast unlimited packs with one-use positions. Preserve every boundary and resource-limit policy.

Planning: [ORGANIZATION.md](../chapters/25_dynamic_programming_backtracking/ORGANIZATION.md) and [MATERIALS.md](../chapters/25_dynamic_programming_backtracking/MATERIALS.md).

### 26. Advanced Algorithms

**Reframe around string algorithms and limits.** The 224-word traversal page is already a verification extension of Chapter 20. The other page combines a graph-objective reminder with direct matching and KMP, whose prefix/fallback reasoning warrants its own development.

Proposed core: Direct string matching and result contracts → Prefix reuse, KMP, and complete workload costs → Computational limits, guarantees, and synthesis.

Develop character-by-character direct/prefix/fallback traces, explain text units and full preparation/output costs, and expand feasibility versus guarantee reasoning. Retain the exact cover counterexample and all boundary witnesses.

Planning: [ORGANIZATION.md](../chapters/26_advanced_graphs_strings_limits/ORGANIZATION.md) and [MATERIALS.md](../chapters/26_advanced_graphs_strings_limits/MATERIALS.md).

