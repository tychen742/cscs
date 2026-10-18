# Word Count by Chapter, Section, and Subsection (2026-10-18)

Prose words count markdown text with fenced code, `{index}`/`{contents}`/`{rubric}` directives, directive options, and HTML tags removed. Code tokens count whitespace-separated tokens in code cells. Assignments (preview, lab, homework, projects, extra practice) are listed per chapter but excluded from the section totals.

## Observations

| Measure | Value |
| --- | --- |
| Content sections | 95 |
| `##` subsections | 635 |
| Total section prose | 153,934 words |
| Median section prose | 1,431 words |
| Median subsection prose | 173 words |
| Subsections under 60 prose words | 38 |

- **Part I-II pages are about twice the length of Part IV-VII pages.** Chapters 1-9 average 1,700-2,600 prose words per section; Chapters 13-26 average 1,050-1,700. The longest sections are 8.4 (4,024), 6.3 (3,725), 2.4 (3,426), and 5.1 (3,394); the shortest are 13.1 (860), 5.5 (922), 10.4 (974), and 13.4 (988).
- **Four pages have a single `##` subsection above 2,000 words**: 6.3 "Framework Setup and Test Attributes" (2,523), 5.1 "Connect Calls, Definitions, and Program Forms" (2,487), 2.4 "Types" (2,324). These carry `###` headings underneath, but each is a long stretch for one reading sitting and is a candidate for splitting.
- **9.6 Regular Expressions is the thinnest construct page.** Five of its subsections carry 7-15 prose words around one code cell each (Checking for a Match, Finding All Matches, Replacing with a Pattern, Using Groups to Extract Fields, Validation Patterns). It was not in the pass 3 caption-only list and is the clearest remaining explanation gap.
- **Most other short subsections are closing Summary, Practice, or Exercise blocks** in Chapters 13-17, which is expected; the content-bearing exceptions are 13.1 "Interfaces as Contracts" (28), 2.1 "The `var` Keyword" (38), 13.2 "Array-Backed Stack" (38), 6.1 "Error Message Quality" (34), 25.1 "Memoization and Tabulation" (48), and 25.2 "Backtracking and Search Spaces" (47).
- **Chapters 3 and 22 have only two content sections each** against the preferred three per chapter.
- **Landing pages** run 390-850 words except the developed 16, 18, 19, and 20 (1,250-1,720), which carry 30-43 glossary rows.

## Chapter Summary

| Ch | Title | Content sections | Section prose | Section code tokens | Code cells | Landing prose | Assignment prose | Prose per section (avg) |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| 1 | Computing, Programs, and Responsibility | 3 | 7,844 | 220 | 13 | 845 | 1,835 | 2,614 |
| 2 | Variables, Data Types, and Operators | 4 | 8,915 | 2,475 | 83 | 629 | 3,000 | 2,228 |
| 3 | Decisions | 2 | 3,353 | 653 | 17 | 388 | 1,453 | 1,676 |
| 4 | Iteration | 4 | 8,462 | 1,318 | 45 | 443 | 3,308 | 2,115 |
| 5 | Methods | 6 | 10,884 | 1,802 | 50 | 622 | 4,453 | 1,814 |
| 6 | Testing, Debugging, and Error Handling | 4 | 8,467 | 1,080 | 19 | 545 | 1,177 | 2,116 |
| 7 | Arrays | 4 | 7,917 | 2,098 | 34 | 776 | 2,350 | 1,979 |
| 8 | Data Collections | 4 | 9,388 | 1,643 | 52 | 690 | 1,864 | 2,347 |
| 9 | Files and Text | 5 | 8,409 | 2,070 | 43 | 505 | 3,877 | 1,681 |
| 10 | Classes and Objects | 4 | 6,731 | 2,610 | 31 | 417 | 4,183 | 1,682 |
| 11 | Object Design and Composition | 5 | 5,913 | 2,864 | 24 | 509 | 1,296 | 1,182 |
| 12 | Inheritance, Interfaces, and Polymorphism | 4 | 4,907 | 1,994 | 21 | 460 | 1,616 | 1,226 |
| 13 | Abstract Data Types | 4 | 4,421 | 845 | 13 | 527 | 913 | 1,105 |
| 14 | Arrays and Linked Lists | 3 | 5,060 | 1,438 | 18 | 543 | 1,111 | 1,686 |
| 15 | Stacks, Queues, and Deques | 3 | 3,276 | 1,398 | 26 | 557 | 1,231 | 1,092 |
| 16 | Searching and Basic Sorting | 3 | 3,882 | 2,444 | 22 | 1,361 | 1,179 | 1,294 |
| 17 | Trees and Binary Search Trees | 4 | 5,988 | 3,907 | 28 | 642 | 1,471 | 1,497 |
| 18 | Priority Queues and Heaps | 3 | 3,171 | 1,373 | 15 | 1,248 | 1,199 | 1,057 |
| 19 | Hash Collections and Sets | 3 | 4,039 | 1,503 | 16 | 1,279 | 1,229 | 1,346 |
| 20 | Graphs and Traversal | 4 | 6,161 | 3,883 | 25 | 1,718 | 1,219 | 1,540 |
| 21 | Algorithm Analysis | 3 | 4,014 | 1,067 | 22 | 537 | 977 | 1,338 |
| 22 | Recursion and Divide-and-Conquer | 2 | 3,021 | 1,385 | 18 | 580 | 910 | 1,510 |
| 23 | Advanced Searching and Sorting | 5 | 5,953 | 2,598 | 23 | 591 | 1,481 | 1,190 |
| 24 | Greedy Algorithms and Graph Optimization | 3 | 4,553 | 4,723 | 21 | 526 | 874 | 1,517 |
| 25 | Dynamic Programming and Backtracking | 3 | 5,126 | 2,530 | 22 | 513 | 1,002 | 1,708 |
| 26 | String Matching and Computational Limits | 3 | 4,079 | 1,486 | 14 | 547 | 949 | 1,359 |
| | **Total** | 95 | 153,934 | 51,407 | 715 | 17,998 | 46,157 | 1,620 |

## Sections and Subsections

### Chapter 1: Computing, Programs, and Responsibility

| Section | Prose | Code tokens | Code cells |
| --- | --- | --- | --- |
| **Computing and Problem Solving** (`0101_cs_ideas`) | **2,439** | **8** | **1** |
| &nbsp;&nbsp;&nbsp;Computers, Software, and Data | 217 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Describe Input, Processing, and Output | 417 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Thinking Like a Computer Scientist | 262 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Algorithms and Development Workflow | 420 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Number Systems and Data Representation | 292 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;From Source Code to Execution | 497 | 8 | 1 |
| &nbsp;&nbsp;&nbsp;Execution Order and Correctness | 260 | 0 | 0 |
| **Computing and Professional Responsibility** (`0102_computing_responsibility`) | **2,917** | **0** | **0** |
| &nbsp;&nbsp;&nbsp;Identify Stakeholders and Possible Harm | 527 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Distinguish Correct Execution from Sound Decisions | 370 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Handle Personal Information with Care | 412 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Make Information Understandable and Accessible | 447 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Respect Sources and Explain Your Work | 334 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Understand the Role of AI Assistance | 648 | 0 | 0 |
| **Your First C# Program and Basic Syntax** (`0103_program_structure`) | **2,488** | **212** | **12** |
| &nbsp;&nbsp;&nbsp;Create and Run Your First Console Application | 294 | 14 | 1 |
| &nbsp;&nbsp;&nbsp;Read the Program from the Outside In | 490 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Edit, Save, and Run Again | 110 | 58 | 3 |
| &nbsp;&nbsp;&nbsp;Statements, Expressions, and Literal Values | 169 | 56 | 4 |
| &nbsp;&nbsp;&nbsp;Names, Keywords, and Case | 289 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Read a Method Call | 118 | 4 | 1 |
| &nbsp;&nbsp;&nbsp;Blocks, Formatting, and Comments | 212 | 41 | 1 |
| &nbsp;&nbsp;&nbsp;Read and Repair Compiler Messages | 241 | 39 | 2 |
| &nbsp;&nbsp;&nbsp;Source Files and the Project File | 271 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Recognize Top-Level Statements | 136 | 0 | 0 |
| *Assignments (5 pages)* | *1,835* | *557* | *20* |

### Chapter 2: Variables, Data Types, and Operators

| Section | Prose | Code tokens | Code cells |
| --- | --- | --- | --- |
| **Variables, Assignment, and State** (`0201_variables_types`) | **1,398** | **325** | **13** |
| &nbsp;&nbsp;&nbsp;Declaring Local Variables | 118 | 45 | 2 |
| &nbsp;&nbsp;&nbsp;The `var` Keyword | 38 | 25 | 1 |
| &nbsp;&nbsp;&nbsp;Assignment Statements | 696 | 209 | 9 |
| &nbsp;&nbsp;&nbsp;Variable, Identifiers, and Literals | 111 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Naming Convention of Identifiers | 89 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Optional: Escaped Identifiers and Contextual Keywords | 222 | 46 | 1 |
| **Types and Conversion** (`0204_types_conversion`) | **3,426** | **985** | **26** |
| &nbsp;&nbsp;&nbsp;Types | 2,324 | 730 | 17 |
| &nbsp;&nbsp;&nbsp;Type Conversion | 803 | 225 | 8 |
| &nbsp;&nbsp;&nbsp;Keep Stored Values Separate from Their Display | 200 | 30 | 1 |
| **Operators and Built-In Methods** (`0202_operators_built_in_methods`) | **2,172** | **730** | **23** |
| &nbsp;&nbsp;&nbsp;C# Operator Types | 473 | 75 | 1 |
| &nbsp;&nbsp;&nbsp;Operation Examples | 290 | 390 | 12 |
| &nbsp;&nbsp;&nbsp;Operator Precedence | 194 | 71 | 2 |
| &nbsp;&nbsp;&nbsp;C# Operator Reference | 291 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Built-In Methods | 718 | 194 | 8 |
| **Input and Output** (`0203_input_output`) | **1,919** | **435** | **21** |
| &nbsp;&nbsp;&nbsp;Input: Reading from the Keyboard | 198 | 42 | 3 |
| &nbsp;&nbsp;&nbsp;User Input with a Supplied UI Class | 361 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Output | 251 | 39 | 3 |
| &nbsp;&nbsp;&nbsp;Composite Formatting | 613 | 221 | 11 |
| &nbsp;&nbsp;&nbsp;String Interpolation | 104 | 53 | 1 |
| &nbsp;&nbsp;&nbsp;Guided Practice: Read and Report an Invoice Line | 370 | 80 | 3 |
| *Assignments (5 pages)* | *3,000* | *1,457* | *36* |

### Chapter 3: Decisions

| Section | Prose | Code tokens | Code cells |
| --- | --- | --- | --- |
| **Boolean Expressions & Logical Operators** (`0301_intro_decision`) | **1,294** | **267** | **8** |
| &nbsp;&nbsp;&nbsp;Selection Statements | 258 | 31 | 1 |
| &nbsp;&nbsp;&nbsp;Boolean Data Type | 149 | 33 | 1 |
| &nbsp;&nbsp;&nbsp;Boolean Expressions | 292 | 76 | 3 |
| &nbsp;&nbsp;&nbsp;Compound Boolean Expressions | 591 | 127 | 3 |
| **Conditional Selection with if and switch** (`0302_ifstatement`) | **2,059** | **386** | **9** |
| &nbsp;&nbsp;&nbsp;Compare Ways to Express the Same Decision | 272 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Reason About the Unselected Branches | 156 | 37 | 1 |
| &nbsp;&nbsp;&nbsp;Simple `if` Statements | 422 | 24 | 1 |
| &nbsp;&nbsp;&nbsp;`if-else` Statements: Two-Way Selection | 243 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;`else-if` Statements: Multi-Selection | 321 | 233 | 4 |
| &nbsp;&nbsp;&nbsp;Nested Conditionals | 364 | 22 | 1 |
| &nbsp;&nbsp;&nbsp;Switch Statement | 274 | 70 | 2 |
| *Assignments (5 pages)* | *1,453* | *849* | *21* |

### Chapter 4: Iteration

| Section | Prose | Code tokens | Code cells |
| --- | --- | --- | --- |
| **Iteration** (`0401_iteration`) | **1,670** | **344** | **12** |
| &nbsp;&nbsp;&nbsp;C# Iteration Statements | 241 | 20 | 1 |
| &nbsp;&nbsp;&nbsp;Iterator/Step | 337 | 136 | 6 |
| &nbsp;&nbsp;&nbsp;`break` and `continue` | 158 | 58 | 1 |
| &nbsp;&nbsp;&nbsp;Loop Planning Rubric | 784 | 109 | 3 |
| **The `for` Statement** (`0402_for_statements`) | **2,333** | **520** | **17** |
| &nbsp;&nbsp;&nbsp;For Statement Syntax | 422 | 33 | 2 |
| &nbsp;&nbsp;&nbsp;`break` and `continue` Statements | 343 | 236 | 4 |
| &nbsp;&nbsp;&nbsp;Nested `for` Loop | 217 | 68 | 2 |
| &nbsp;&nbsp;&nbsp;Additional Loop Step Patterns | 95 | 24 | 2 |
| &nbsp;&nbsp;&nbsp;`foreach` Essentials | 315 | 34 | 1 |
| &nbsp;&nbsp;&nbsp;Apply Loops to Formatted Tables | 423 | 81 | 5 |
| &nbsp;&nbsp;&nbsp;Repeated Trials and Random Values | 432 | 44 | 1 |
| **While-Statements** (`0403_while_statement`) | **2,030** | **226** | **11** |
| &nbsp;&nbsp;&nbsp;Infinite loops | 159 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;While Examples | 628 | 170 | 8 |
| &nbsp;&nbsp;&nbsp;Do-While Loops | 615 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Validate a Number Before Using It | 351 | 24 | 1 |
| **Greatest Common Divisor** (`0404_gcd`) | **2,429** | **228** | **5** |
| &nbsp;&nbsp;&nbsp;Euclid's Algorithm | 371 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;GCD "Brute Force" Method | 713 | 59 | 1 |
| &nbsp;&nbsp;&nbsp;GCD Subtraction Method | 516 | 48 | 1 |
| &nbsp;&nbsp;&nbsp;GCD Remainder Loop | 225 | 89 | 2 |
| &nbsp;&nbsp;&nbsp;Preview: Recursive GCD | 310 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Run the Loop Now | 212 | 32 | 1 |
| *Assignments (6 pages)* | *3,308* | *852* | *18* |

### Chapter 5: Methods

| Section | Prose | Code tokens | Code cells |
| --- | --- | --- | --- |
| **Designing and Calling Methods** (`0501_intro_methods`) | **3,394** | **107** | **6** |
| &nbsp;&nbsp;&nbsp;Discover a Task Before Naming a Method | 328 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;A Repeated Task Needs a Name | 392 | 12 | 1 |
| &nbsp;&nbsp;&nbsp;Connect Calls, Definitions, and Program Forms | 2,487 | 45 | 3 |
| &nbsp;&nbsp;&nbsp;Guided Practice: Reuse a Notice | 182 | 50 | 2 |
| **Method Parameters** (`0503_parameter`) | **2,313** | **444** | **10** |
| &nbsp;&nbsp;&nbsp;Map Arguments to Parameters | 223 | 27 | 1 |
| &nbsp;&nbsp;&nbsp;Return Values, out, and ref | 283 | 50 | 1 |
| &nbsp;&nbsp;&nbsp;Variable Scopes | 499 | 33 | 1 |
| &nbsp;&nbsp;&nbsp;Static Variables | 286 | 39 | 1 |
| &nbsp;&nbsp;&nbsp;Method Tracing | 120 | 30 | 1 |
| &nbsp;&nbsp;&nbsp;Reuse a Loop Through a Method Contract | 147 | 32 | 1 |
| &nbsp;&nbsp;&nbsp;Keep Interaction in the Caller | 155 | 27 | 1 |
| &nbsp;&nbsp;&nbsp;Guided Practice: Use a Returned Value | 50 | 101 | 2 |
| **Returned Results and Method Contracts** (`0502_signature_call`) | **1,968** | **299** | **10** |
| &nbsp;&nbsp;&nbsp;A Boolean Result Answers a Question | 233 | 15 | 1 |
| &nbsp;&nbsp;&nbsp;Returned Values Replace Calls | 426 | 16 | 1 |
| &nbsp;&nbsp;&nbsp;Returned Strings and Formatted Results | 580 | 65 | 2 |
| &nbsp;&nbsp;&nbsp;Print or Return? Choose the Contract | 110 | 39 | 1 |
| &nbsp;&nbsp;&nbsp;Decisions, Early Returns, and Complete Return Paths | 185 | 22 | 1 |
| &nbsp;&nbsp;&nbsp;AI Review: Match a Method to Its Contract | 242 | 73 | 2 |
| &nbsp;&nbsp;&nbsp;Guided Practice: Return a Commission | 187 | 69 | 2 |
| **Strings and Their Methods** (`0504_strings`) | **1,268** | **389** | **12** |
| &nbsp;&nbsp;&nbsp;Length and Indexing | 89 | 28 | 1 |
| &nbsp;&nbsp;&nbsp;Cleaning Text | 152 | 75 | 3 |
| &nbsp;&nbsp;&nbsp;Strings Are Immutable | 101 | 22 | 1 |
| &nbsp;&nbsp;&nbsp;Searching | 92 | 32 | 1 |
| &nbsp;&nbsp;&nbsp;Extracting Part of a String | 115 | 58 | 1 |
| &nbsp;&nbsp;&nbsp;Replacing Text | 85 | 28 | 1 |
| &nbsp;&nbsp;&nbsp;Chaining Method Calls | 190 | 35 | 1 |
| &nbsp;&nbsp;&nbsp;Guard the Format Before Extracting | 112 | 30 | 1 |
| &nbsp;&nbsp;&nbsp;Guided Practice: Clean a Department Code | 43 | 81 | 2 |
| &nbsp;&nbsp;&nbsp;Summary | 91 | 0 | 0 |
| **Composition, Refactoring, and Method Checks** (`0505_summary`) | **922** | **224** | **4** |
| &nbsp;&nbsp;&nbsp;Refactor in Small Steps That Keep an Observable Contract | 242 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Choose Tests That Can Distinguish Plausible Defects | 187 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Refactor and Check a Checkout Calculation | 310 | 112 | 2 |
| &nbsp;&nbsp;&nbsp;Guided Synthesis: Report a Line Total | 45 | 112 | 2 |
| &nbsp;&nbsp;&nbsp;Bounded Extensions: Overloading and Recursion | 133 | 0 | 0 |
| **Recursive Methods** (`0506_recursive_methods`) | **1,019** | **339** | **8** |
| &nbsp;&nbsp;&nbsp;A Method May Call Itself | 166 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Trace the Calls: A Deadline Countdown | 237 | 106 | 3 |
| &nbsp;&nbsp;&nbsp;Return a Value: Sum the First n Numbers | 119 | 56 | 1 |
| &nbsp;&nbsp;&nbsp;The Call Stack and Why Progress Matters | 151 | 41 | 1 |
| &nbsp;&nbsp;&nbsp;Recursion or a Loop? | 168 | 76 | 1 |
| &nbsp;&nbsp;&nbsp;Guided Practice: Count the Digits of an Order Number | 135 | 60 | 2 |
| *Assignments (6 pages)* | *4,453* | *1,142* | *19* |

### Chapter 6: Testing, Debugging, and Error Handling

| Section | Prose | Code tokens | Code cells |
| --- | --- | --- | --- |
| **Error Handling and Validation** (`0601_error_handling`) | **2,272** | **322** | **7** |
| &nbsp;&nbsp;&nbsp;Follow One Failed Calculation Through Its Caller | 391 | 60 | 1 |
| &nbsp;&nbsp;&nbsp;Guide a Repair Before Broadening the Failure Policy | 173 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Decide What a Failure Means Before Catching It | 247 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Follow Control Through an Exception | 254 | 28 | 1 |
| &nbsp;&nbsp;&nbsp;Validation vs. Exceptions | 105 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Basic `try` / `catch` / `finally` | 181 | 57 | 1 |
| &nbsp;&nbsp;&nbsp;Prefer `TryParse` for User Input | 154 | 40 | 1 |
| &nbsp;&nbsp;&nbsp;File I/O with Safe Handling | 146 | 49 | 1 |
| &nbsp;&nbsp;&nbsp;Throwing Exceptions Intentionally | 146 | 45 | 1 |
| &nbsp;&nbsp;&nbsp;Error Message Quality | 34 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Common Mistakes | 104 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Practice | 57 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Rethrow Without Losing the Failure Origin | 276 | 43 | 1 |
| **Debugging Workflow** (`0602_debugging_workflow`) | **1,433** | **242** | **5** |
| &nbsp;&nbsp;&nbsp;Turn a Symptom into a Reproducible Question | 150 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;The Workflow | 654 | 146 | 3 |
| &nbsp;&nbsp;&nbsp;Debug One Familiar Loop from Symptom to Evidence | 548 | 96 | 2 |
| &nbsp;&nbsp;&nbsp;Practice | 79 | 0 | 0 |
| **Unit Testing** (`0603_testing`) | **3,725** | **360** | **5** |
| &nbsp;&nbsp;&nbsp;Introduction | 376 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Simple Testing | 113 | 48 | 1 |
| &nbsp;&nbsp;&nbsp;The Unit Testing Process | 77 | 66 | 1 |
| &nbsp;&nbsp;&nbsp;Design Tests Independently of the Implementation | 252 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Framework Setup and Test Attributes | 2,523 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;AI Review: Challenge Suggested Tests | 381 | 246 | 3 |
| **Computing and Society** (`0605_software_responsibility`) | **1,037** | **156** | **2** |
| &nbsp;&nbsp;&nbsp;When Software Fails People | 238 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Small Defects at Scale | 132 | 156 | 2 |
| &nbsp;&nbsp;&nbsp;Thinking Through an Ethical Question | 275 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Professional Codes of Ethics | 172 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Summary | 149 | 0 | 0 |
| *Assignments (5 pages)* | *1,177* | *90* | *2* |

### Chapter 7: Arrays

| Section | Prose | Code tokens | Code cells |
| --- | --- | --- | --- |
| **Creating and Accessing Arrays** (`0701_onedim`) | **2,209** | **456** | **8** |
| &nbsp;&nbsp;&nbsp;See the Collection Before Writing Its Loop | 294 | 42 | 1 |
| &nbsp;&nbsp;&nbsp;Guide a Last-Element Check | 422 | 28 | 1 |
| &nbsp;&nbsp;&nbsp;Creating Arrays | 543 | 73 | 1 |
| &nbsp;&nbsp;&nbsp;Accessing Array Elements | 577 | 265 | 4 |
| &nbsp;&nbsp;&nbsp;Default Initializations | 188 | 48 | 1 |
| &nbsp;&nbsp;&nbsp;LINQ Methods | 180 | 0 | 0 |
| **Processing and Sharing Arrays** (`0703_array_processing`) | **1,623** | **238** | **4** |
| &nbsp;&nbsp;&nbsp;Process Positions Before Introducing a New Container | 224 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Passing an Array Does Not Copy Its Elements | 251 | 55 | 1 |
| &nbsp;&nbsp;&nbsp;Parameters to Main | 908 | 75 | 2 |
| &nbsp;&nbsp;&nbsp;References and Aliases | 236 | 108 | 1 |
| **Searching and Sorting Arrays** (`0704_searching_sorting_arrays`) | **2,543** | **1,100** | **14** |
| &nbsp;&nbsp;&nbsp;Ask What the Answer Must Be | 321 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Linear Search: Visit Positions in Order | 269 | 66 | 1 |
| &nbsp;&nbsp;&nbsp;Guided Practice: Change the Matching Rule | 115 | 117 | 2 |
| &nbsp;&nbsp;&nbsp;Count Matches and Find the Largest | 147 | 95 | 1 |
| &nbsp;&nbsp;&nbsp;Sort with the Library, Then Search Faster | 296 | 103 | 2 |
| &nbsp;&nbsp;&nbsp;Why a Sorted Array Searches Faster | 185 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Binary Search by Hand: Narrow a Sorted Interval | 308 | 104 | 1 |
| &nbsp;&nbsp;&nbsp;Guided Practice: Repair the Boundary | 159 | 221 | 2 |
| &nbsp;&nbsp;&nbsp;Insertion Sort: Grow an Ordered Prefix | 316 | 76 | 1 |
| &nbsp;&nbsp;&nbsp;Guided Practice: Preserve the Saved Item | 106 | 187 | 2 |
| &nbsp;&nbsp;&nbsp;Choose Among the Three | 156 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Guided Practice: Find a Product Code | 161 | 131 | 2 |
| **2D & ND Arrays** (`0702_twodim`) | **1,542** | **304** | **8** |
| &nbsp;&nbsp;&nbsp;Rectangular Arrays (Two Dimensional) | 963 | 109 | 5 |
| &nbsp;&nbsp;&nbsp;From One Row to a Table Summary | 192 | 51 | 1 |
| &nbsp;&nbsp;&nbsp;Advanced topic: Array of Arrays | 295 | 144 | 2 |
| *Assignments (5 pages)* | *2,350* | *2,180* | *30* |

### Chapter 8: Data Collections

| Section | Prose | Code tokens | Code cells |
| --- | --- | --- | --- |
| **Collection Families and Selection** (`0801_collections`) | **1,882** | **0** | **0** |
| &nbsp;&nbsp;&nbsp;Collections and Operations | 348 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Collection Families | 415 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Choosing a Collection | 747 | 0 | 0 |
| **Collection Operations and Behavior** (`0804_collection_operations`) | **4,024** | **372** | **11** |
| &nbsp;&nbsp;&nbsp;Read an Operation as a State Change and a Result | 380 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Generic Collections | 469 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Similar Operations, Different Methods | 877 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Collection Examples | 1,428 | 221 | 7 |
| &nbsp;&nbsp;&nbsp;Traversal and Shared References | 587 | 151 | 4 |
| &nbsp;&nbsp;&nbsp;Summary | 279 | 0 | 0 |
| **Lists** (`0802_list`) | **1,627** | **711** | **25** |
| &nbsp;&nbsp;&nbsp;Generics | 139 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Lists Basics | 222 | 122 | 4 |
| &nbsp;&nbsp;&nbsp;Lists Constructors and Methods | 463 | 257 | 13 |
| &nbsp;&nbsp;&nbsp;Common Pitfall: Modifying a List While Iterating | 101 | 88 | 2 |
| &nbsp;&nbsp;&nbsp;Exercise: Generic List | 350 | 161 | 5 |
| &nbsp;&nbsp;&nbsp;Interactive List Example | 121 | 83 | 1 |
| **Dictionaries** (`0803_dictionary`) | **1,855** | **560** | **16** |
| &nbsp;&nbsp;&nbsp;Creating a Dictionary | 163 | 46 | 3 |
| &nbsp;&nbsp;&nbsp;Accessing Data in Dictionary | 264 | 189 | 6 |
| &nbsp;&nbsp;&nbsp;Properties and Methods in Dictionary | 304 | 130 | 4 |
| &nbsp;&nbsp;&nbsp;Guided Practice: Update Stock Safely | 106 | 93 | 2 |
| &nbsp;&nbsp;&nbsp;Word Count Example | 508 | 102 | 1 |
| &nbsp;&nbsp;&nbsp;Dictionary Efficiency | 151 | 0 | 0 |
| *Assignments (4 pages)* | *1,864* | *1,829* | *20* |

### Chapter 9: Files and Text

| Section | Prose | Code tokens | Code cells |
| --- | --- | --- | --- |
| **File Foundations: Reading and Writing** (`0901_stream_file`) | **2,650** | **584** | **9** |
| &nbsp;&nbsp;&nbsp;File Stream | 507 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Simple File Handling: `File` Class | 451 | 161 | 2 |
| &nbsp;&nbsp;&nbsp;`StreamWriter` | 683 | 154 | 3 |
| &nbsp;&nbsp;&nbsp;`StreamReader` | 877 | 269 | 4 |
| **File Workflows, Paths, and Resources** (`0902_file_operations`) | **2,059** | **260** | **5** |
| &nbsp;&nbsp;&nbsp;Run a Complete File Lifetime in an Owned Workspace | 353 | 60 | 1 |
| &nbsp;&nbsp;&nbsp;Predict Append and Missing-Input Outcomes | 158 | 46 | 1 |
| &nbsp;&nbsp;&nbsp;Separate a File's Location from Its Contents | 1,215 | 86 | 2 |
| &nbsp;&nbsp;&nbsp;Bound Resource Lifetime Explicitly | 328 | 68 | 1 |
| **Text Operations** (`0903_text_operations`) | **1,545** | **546** | **9** |
| &nbsp;&nbsp;&nbsp;Treat Each Imported Line as a Small Contract | 427 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Splitting and Tokenizing | 245 | 89 | 4 |
| &nbsp;&nbsp;&nbsp;Safe Replacement Strategy | 129 | 14 | 1 |
| &nbsp;&nbsp;&nbsp;Structured Lines | 243 | 226 | 2 |
| &nbsp;&nbsp;&nbsp;When to Use a Database | 114 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;AI Review: Specify and Validate a Text Import | 372 | 217 | 2 |
| **Regular Expressions** (`0906_regex`) | **1,059** | **329** | **12** |
| &nbsp;&nbsp;&nbsp;Read a Pattern as a Description of Accepted Text | 413 | 17 | 2 |
| &nbsp;&nbsp;&nbsp;Checking for a Match | 15 | 34 | 1 |
| &nbsp;&nbsp;&nbsp;Common Pattern Elements | 79 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Extracting a Match | 81 | 22 | 1 |
| &nbsp;&nbsp;&nbsp;Finding All Matches | 7 | 26 | 1 |
| &nbsp;&nbsp;&nbsp;Replacing with a Pattern | 8 | 51 | 2 |
| &nbsp;&nbsp;&nbsp;Using Groups to Extract Fields | 14 | 21 | 1 |
| &nbsp;&nbsp;&nbsp;Validation Patterns | 7 | 41 | 1 |
| &nbsp;&nbsp;&nbsp;When to Use Regex vs. String Methods | 54 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Practice | 379 | 117 | 3 |
| **Privacy and Security in Code** (`0905_privacy_security`) | **1,096** | **351** | **8** |
| &nbsp;&nbsp;&nbsp;Personal Data and the Law | 259 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Show Less: Masking | 161 | 159 | 4 |
| &nbsp;&nbsp;&nbsp;Treat Every Input as Untrusted | 124 | 62 | 1 |
| &nbsp;&nbsp;&nbsp;Logging Without Leaking | 134 | 72 | 1 |
| &nbsp;&nbsp;&nbsp;Summary | 323 | 58 | 2 |
| *Assignments (8 pages)* | *3,877* | *689* | *15* |

### Chapter 10: Classes and Objects

| Section | Prose | Code tokens | Code cells |
| --- | --- | --- | --- |
| **Class Syntax** (`1001_class_syntax`) | **2,524** | **684** | **13** |
| &nbsp;&nbsp;&nbsp;Overview | 250 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Declaring Classes | 370 | 61 | 1 |
| &nbsp;&nbsp;&nbsp;Using a Class | 296 | 56 | 1 |
| &nbsp;&nbsp;&nbsp;Constructors | 554 | 200 | 3 |
| &nbsp;&nbsp;&nbsp;Static Classes & Methods | 242 | 40 | 1 |
| &nbsp;&nbsp;&nbsp;A Variable Number of Arguments | 299 | 40 | 1 |
| &nbsp;&nbsp;&nbsp;Tuples: When a Class Is Too Much | 510 | 287 | 6 |
| **Properties** (`1002_properties`) | **2,029** | **707** | **9** |
| &nbsp;&nbsp;&nbsp;Properties | 1,346 | 576 | 7 |
| &nbsp;&nbsp;&nbsp;ToString Override | 682 | 131 | 2 |
| **Instances, State, and Useful Behavior** (`1003_class_instance`) | **1,204** | **670** | **6** |
| &nbsp;&nbsp;&nbsp;Give Each Instance Its Own State | 172 | 111 | 1 |
| &nbsp;&nbsp;&nbsp;Properties Describe the Public Surface | 144 | 108 | 1 |
| &nbsp;&nbsp;&nbsp;Calculate Behavior from State | 122 | 101 | 1 |
| &nbsp;&nbsp;&nbsp;Practice: Reset and Reuse a Register | 53 | 233 | 2 |
| &nbsp;&nbsp;&nbsp;Statistics Exercise | 210 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Unneeded Constructor Code Exercise | 204 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Alternate Internal State Exercise | 237 | 117 | 1 |
| **Averager and Mutable State** (`1004_averager`) | **974** | **549** | **3** |
| &nbsp;&nbsp;&nbsp;More Getters and Setters | 176 | 376 | 2 |
| &nbsp;&nbsp;&nbsp;Beyond Getters and Setters | 755 | 173 | 1 |
| *Assignments (6 pages)* | *4,183* | *2,905* | *26* |

### Chapter 11: Object Design and Composition

| Section | Prose | Code tokens | Code cells |
| --- | --- | --- | --- |
| **References, Identity, and Copying** (`1101_objects_references`) | **1,153** | **341** | **5** |
| &nbsp;&nbsp;&nbsp;Missing Is Different from Empty | 183 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Objects, References, and State | 106 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Assignment Copies a Reference | 231 | 61 | 1 |
| &nbsp;&nbsp;&nbsp;Identity and Business Equality | 180 | 86 | 1 |
| &nbsp;&nbsp;&nbsp;Mutable and Immutable Objects | 198 | 87 | 1 |
| &nbsp;&nbsp;&nbsp;Copies Need a Depth Policy | 132 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Practice: Draw the Arrows | 119 | 107 | 2 |
| **Structs, Records, and Data Models** (`1105_value_record_types`) | **1,271** | **162** | **3** |
| &nbsp;&nbsp;&nbsp;Choose Copy and Equality Semantics Together | 415 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Structs: Define a Value Type | 248 | 69 | 1 |
| &nbsp;&nbsp;&nbsp;Records: Data and Equality | 268 | 55 | 1 |
| &nbsp;&nbsp;&nbsp;Record Structs and Choosing a Type | 335 | 38 | 1 |
| **Composition and Object Responsibilities** (`1102_composition`) | **1,201** | **1,071** | **5** |
| &nbsp;&nbsp;&nbsp;Establish Required and Optional Relationships at Their Boundary | 413 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Has-a Relationships | 172 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Let Each Object Calculate Its Own Result | 163 | 135 | 1 |
| &nbsp;&nbsp;&nbsp;Keep Collection Ownership Inside the Order | 198 | 234 | 1 |
| &nbsp;&nbsp;&nbsp;Return Useful Results Without Exposing Storage | 173 | 241 | 1 |
| &nbsp;&nbsp;&nbsp;Practice: Count Requested Units | 78 | 461 | 2 |
| **Testing and Refactoring Collaborating Objects** (`1103_testing_collaboration`) | **1,181** | **1,052** | **4** |
| &nbsp;&nbsp;&nbsp;Test Through the Surface a Client Is Allowed to Use | 325 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Contracts Describe Observable Behavior | 172 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Arrange, Act, Assert | 152 | 265 | 1 |
| &nbsp;&nbsp;&nbsp;Rejected Changes Must Preserve State | 152 | 255 | 1 |
| &nbsp;&nbsp;&nbsp;Refactor Without Changing the Contract | 175 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Prepare a Durable Multi-Class Project | 119 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Practice: Challenge the Ownership Rules | 81 | 532 | 2 |
| **Nullability and Missing Data** (`1104_nullability`) | **1,107** | **238** | **7** |
| &nbsp;&nbsp;&nbsp;Give Missing Data Its Own Meaning | 291 | 40 | 1 |
| &nbsp;&nbsp;&nbsp;Guide a Required-Value Guard and an Optional Label | 184 | 19 | 1 |
| &nbsp;&nbsp;&nbsp;Nullable Value Types | 98 | 27 | 1 |
| &nbsp;&nbsp;&nbsp;Nullable Reference Types (C# 8+) | 113 | 34 | 1 |
| &nbsp;&nbsp;&nbsp;The Null Operators | 174 | 80 | 2 |
| &nbsp;&nbsp;&nbsp;Pattern Matching and Null | 104 | 38 | 1 |
| &nbsp;&nbsp;&nbsp;Practice | 50 | 0 | 0 |
| *Assignments (4 pages)* | *1,296* | *2,783* | *22* |

### Chapter 12: Inheritance, Interfaces, and Polymorphism

| Section | Prose | Code tokens | Code cells |
| --- | --- | --- | --- |
| **Inheritance and Substitution** (`1201_inheritance`) | **1,026** | **304** | **4** |
| &nbsp;&nbsp;&nbsp;Substitution Is a Client's Behavioral Expectation | 364 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Is-a Is a Behavioral Promise | 168 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Base and Derived Members | 159 | 82 | 1 |
| &nbsp;&nbsp;&nbsp;Construction and Shared State | 130 | 66 | 1 |
| &nbsp;&nbsp;&nbsp;Substitution Preserves the Contract | 128 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Practice: Preserve the Discount Contract | 74 | 156 | 2 |
| **Runtime Polymorphism and Abstract Classes** (`1202_polymorphism`) | **1,043** | **535** | **4** |
| &nbsp;&nbsp;&nbsp;Distinguish Choosing a Member from Dispatching Its Implementation | 372 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Virtual Calls Select an Override | 153 | 126 | 1 |
| &nbsp;&nbsp;&nbsp;Overriding Is Different from Overloading | 155 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Abstract Classes Require an Implementation | 155 | 113 | 1 |
| &nbsp;&nbsp;&nbsp;Check Every Implementation Against Shared Expectations | 127 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Practice: Test Through the Base Type | 76 | 296 | 2 |
| **Interfaces and Interchangeable Components** (`1203_interfaces`) | **1,019** | **438** | **5** |
| &nbsp;&nbsp;&nbsp;Depend on the Capability the Client Needs | 315 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;A Small Capability Contract | 156 | 63 | 1 |
| &nbsp;&nbsp;&nbsp;Supply Collaborators Through Constructors | 159 | 123 | 1 |
| &nbsp;&nbsp;&nbsp;Use a Test Double to Observe Collaboration | 121 | 101 | 1 |
| &nbsp;&nbsp;&nbsp;Choose Composition, an Interface, or a Base Class | 193 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Practice: Replace a Component Without Changing Its Client | 71 | 151 | 2 |
| **OOP Examples and Variations** (`1204_oop_examples`) | **1,819** | **717** | **8** |
| &nbsp;&nbsp;&nbsp;Programming Paradigms and Separation of Concerns | 722 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Inheritance: Vehicle and Car | 134 | 127 | 3 |
| &nbsp;&nbsp;&nbsp;Nonvirtual Hiding and Virtual Overriding | 105 | 103 | 1 |
| &nbsp;&nbsp;&nbsp;Overloading by Type and Number of Arguments | 107 | 179 | 1 |
| &nbsp;&nbsp;&nbsp;Calling base and Sealing an Override | 200 | 85 | 1 |
| &nbsp;&nbsp;&nbsp;Abstract Classes and Interfaces Compared | 518 | 223 | 2 |
| *Assignments (5 pages)* | *1,616* | *1,989* | *26* |

### Chapter 13: Abstract Data Types

| Section | Prose | Code tokens | Code cells |
| --- | --- | --- | --- |
| **ADT Contracts** (`1301_adt_contracts`) | **860** | **99** | **1** |
| &nbsp;&nbsp;&nbsp;Describe the Observable History First | 231 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Separate Client Knowledge from Implementation Knowledge | 223 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;What an ADT Specifies | 93 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Interfaces as Contracts | 28 | 99 | 1 |
| &nbsp;&nbsp;&nbsp;Client Code Depends on Behavior | 61 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Contracts Include Rules | 67 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Practice | 40 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Summary | 83 | 0 | 0 |
| **Representations and Costs** (`1302_representations_costs`) | **1,138** | **190** | **3** |
| &nbsp;&nbsp;&nbsp;One Behavior Can Have Different Physical Work | 258 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Define What You Count | 176 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;One Contract, Multiple Representations | 71 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Array-Backed Stack | 38 | 76 | 1 |
| &nbsp;&nbsp;&nbsp;Linked Nodes and References | 54 | 69 | 1 |
| &nbsp;&nbsp;&nbsp;Counting Work and Big-O | 285 | 45 | 1 |
| &nbsp;&nbsp;&nbsp;Operation Costs | 94 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Practice | 47 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Summary | 87 | 0 | 0 |
| **Generics for Reusable ADTs** (`1303_generics`) | **1,435** | **431** | **7** |
| &nbsp;&nbsp;&nbsp;Why Generics Exist | 53 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Reuse an Algorithm Without Erasing Its Types | 179 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;State Which Operations the Generic Code Needs | 234 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Generic Methods | 144 | 78 | 1 |
| &nbsp;&nbsp;&nbsp;Generic Classes | 120 | 52 | 1 |
| &nbsp;&nbsp;&nbsp;Type Constraints | 150 | 42 | 1 |
| &nbsp;&nbsp;&nbsp;Generic Interfaces | 141 | 113 | 1 |
| &nbsp;&nbsp;&nbsp;Ordering and Equality Are Different Contracts | 135 | 111 | 2 |
| &nbsp;&nbsp;&nbsp;Reading Short Expressions and Queries | 136 | 35 | 1 |
| &nbsp;&nbsp;&nbsp;Practice | 93 | 0 | 0 |
| **Iterators** (`1304_iterators`) | **988** | **125** | **2** |
| &nbsp;&nbsp;&nbsp;Why foreach Works | 111 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Separate Producing a Sequence from Storing One | 181 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;A Yield Point Suspends Rather than Finishes the Sequence | 237 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Writing an Iterator with yield return | 113 | 48 | 1 |
| &nbsp;&nbsp;&nbsp;Making Your Own Type foreach-able | 106 | 77 | 1 |
| &nbsp;&nbsp;&nbsp;Iterators Are Lazy | 83 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Practice | 92 | 0 | 0 |
| *Assignments (4 pages)* | *913* | *1,893* | *22* |

### Chapter 14: Arrays and Linked Lists

| Section | Prose | Code tokens | Code cells |
| --- | --- | --- | --- |
| **Dynamic Arrays** (`1401_dynamic_arrays`) | **1,889** | **490** | **6** |
| &nbsp;&nbsp;&nbsp;Contiguous Storage | 194 | 24 | 1 |
| &nbsp;&nbsp;&nbsp;Resizing by Copying | 298 | 180 | 3 |
| &nbsp;&nbsp;&nbsp;Worked Example: A Small Dynamic Array | 165 | 98 | 1 |
| &nbsp;&nbsp;&nbsp;Cost of Append and Indexing | 133 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;A Sequence Contract and Its Invariants | 192 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Trace Growth Before Writing Code | 146 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Middle Updates: Preserve the Unread Values | 238 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Complete Generic Implementation | 170 | 188 | 1 |
| &nbsp;&nbsp;&nbsp;Why Doubling Gives Amortized Constant Cost | 227 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Practice | 47 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Summary | 54 | 0 | 0 |
| **Linked Nodes** (`1402_linked_nodes`) | **1,631** | **646** | **7** |
| &nbsp;&nbsp;&nbsp;Nodes and References | 151 | 41 | 1 |
| &nbsp;&nbsp;&nbsp;Traversal | 213 | 211 | 3 |
| &nbsp;&nbsp;&nbsp;Insertion After a Node | 144 | 70 | 1 |
| &nbsp;&nbsp;&nbsp;Deletion After a Node | 124 | 71 | 1 |
| &nbsp;&nbsp;&nbsp;Costs and Tradeoffs | 74 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;References Are Paths, Not Copies | 119 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Insertion Order and Lost Links | 168 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Removal, Head, and Tail Invariants | 171 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;A Complete Singly Linked Sequence | 228 | 253 | 1 |
| &nbsp;&nbsp;&nbsp;Doubly Linked Lists: A Different Tradeoff | 119 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Practice | 35 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Summary | 44 | 0 | 0 |
| **Representation Tradeoffs and Verification** (`1403_comparison_lab`) | **1,540** | **302** | **5** |
| &nbsp;&nbsp;&nbsp;Array Search and Indexing | 128 | 50 | 1 |
| &nbsp;&nbsp;&nbsp;Linked Traversal | 118 | 82 | 1 |
| &nbsp;&nbsp;&nbsp;Middle Insertion Costs | 236 | 170 | 3 |
| &nbsp;&nbsp;&nbsp;Separate Location Cost from Update Cost | 218 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Count a Concrete Workload | 189 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Test the Contract Before Comparing Speed | 200 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Memory and Locality Qualify the Recommendation | 172 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Decision Guide | 76 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Lab Tasks | 110 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Summary | 53 | 0 | 0 |
| *Assignments (4 pages)* | *1,111* | *3,243* | *20* |

### Chapter 15: Stacks, Queues, and Deques

| Section | Prose | Code tokens | Code cells |
| --- | --- | --- | --- |
| **Stacks** (`1501_stack`) | **999** | **502** | **9** |
| &nbsp;&nbsp;&nbsp;Stack Behavior | 131 | 24 | 1 |
| &nbsp;&nbsp;&nbsp;Empty Stacks and Safe Access | 145 | 104 | 3 |
| &nbsp;&nbsp;&nbsp;Matching Delimiters | 121 | 110 | 1 |
| &nbsp;&nbsp;&nbsp;Stack Implementation Choices | 86 | 69 | 1 |
| &nbsp;&nbsp;&nbsp;Trace the Stack Invariant | 139 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;A Complete Generic Array Stack | 140 | 128 | 1 |
| &nbsp;&nbsp;&nbsp;Correctness and Cost of Stack Operations | 155 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Exercise | 35 | 67 | 2 |
| &nbsp;&nbsp;&nbsp;Summary | 46 | 0 | 0 |
| **Queues and Deques** (`1502_queue_deque`) | **1,269** | **498** | **8** |
| &nbsp;&nbsp;&nbsp;Separate Logical Order from the Positions That Store It | 229 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Queue Behavior | 89 | 19 | 1 |
| &nbsp;&nbsp;&nbsp;Worklists and Scheduling | 57 | 33 | 1 |
| &nbsp;&nbsp;&nbsp;Ring Buffers | 94 | 99 | 1 |
| &nbsp;&nbsp;&nbsp;Deques | 92 | 18 | 1 |
| &nbsp;&nbsp;&nbsp;Trace Wraparound and Distinguish Full from Empty | 186 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;A Complete Bounded Generic Queue | 112 | 151 | 1 |
| &nbsp;&nbsp;&nbsp;Linked Queue Endpoints and Growth Choices | 119 | 115 | 1 |
| &nbsp;&nbsp;&nbsp;Growing a Ring and Choosing a Deque Representation | 189 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Exercise | 29 | 63 | 2 |
| &nbsp;&nbsp;&nbsp;Summary | 70 | 0 | 0 |
| **Access Policies and Applications** (`1503_applications_lab`) | **1,008** | **398** | **9** |
| &nbsp;&nbsp;&nbsp;Choosing the Access Rule | 102 | 44 | 1 |
| &nbsp;&nbsp;&nbsp;Backtracking with a Stack | 58 | 32 | 1 |
| &nbsp;&nbsp;&nbsp;Breadth-First Processing with a Queue | 121 | 122 | 3 |
| &nbsp;&nbsp;&nbsp;Comparing Costs | 129 | 23 | 1 |
| &nbsp;&nbsp;&nbsp;Undo and Redo Require Two Histories | 147 | 74 | 1 |
| &nbsp;&nbsp;&nbsp;Worklist Order, Duplicate Discovery, and Fairness | 202 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Validate Behavior Before Measuring | 143 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Exercise | 44 | 103 | 2 |
| &nbsp;&nbsp;&nbsp;Summary | 58 | 0 | 0 |
| *Assignments (4 pages)* | *1,231* | *2,060* | *20* |

### Chapter 16: Searching and Basic Sorting

| Section | Prose | Code tokens | Code cells |
| --- | --- | --- | --- |
| **Search Contracts and Repeated Queries** (`1601_searching`) | **1,174** | **482** | **5** |
| &nbsp;&nbsp;&nbsp;Specify the Answer Before Counting Comparisons | 209 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Trace a Shrinking Candidate Region | 283 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;First-Match Linear Search | 174 | 113 | 1 |
| &nbsp;&nbsp;&nbsp;Binary Search Requires the Right Order | 210 | 114 | 1 |
| &nbsp;&nbsp;&nbsp;Library Results Have Their Own Contract | 84 | 29 | 1 |
| &nbsp;&nbsp;&nbsp;Choose a Search for the Workload | 103 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Practice: State the Matching Policy | 105 | 226 | 2 |
| **Sorting and Safe Reporting Workloads** (`1602_basic_sorting`) | **1,494** | **887** | **9** |
| &nbsp;&nbsp;&nbsp;Maintain a Sorted Prefix While Preserving Every Record | 279 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Preparation, Mutation, and the Report Caller | 197 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Insert into a Sorted Prefix | 132 | 85 | 1 |
| &nbsp;&nbsp;&nbsp;Sorting Objects Uses an Ordering Policy | 93 | 145 | 1 |
| &nbsp;&nbsp;&nbsp;Count Work for Different Inputs | 93 | 87 | 1 |
| &nbsp;&nbsp;&nbsp;Verify Order and Preservation | 95 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Practice: Preserve the Saved Item | 20 | 171 | 2 |
| &nbsp;&nbsp;&nbsp;Library Operations and Clear Comparers | 85 | 17 | 1 |
| &nbsp;&nbsp;&nbsp;Design a Boundary Matrix | 120 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Practice: Choose a Safe Reporting Snapshot | 32 | 195 | 2 |
| &nbsp;&nbsp;&nbsp;Compare Reporting and Query Workloads | 74 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Preserve Arrival Order While Preparing a Report | 76 | 187 | 1 |
| &nbsp;&nbsp;&nbsp;Include Preparation and Updates | 193 | 0 | 0 |
| **Merge Sort for Reporting Workloads** (`1604_merge_sort`) | **1,214** | **1,075** | **8** |
| &nbsp;&nbsp;&nbsp;When Insertion Sort Is Not Enough | 134 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Merge Two Sorted Runs | 286 | 304 | 3 |
| &nbsp;&nbsp;&nbsp;Divide, Sort Each Half, Merge | 216 | 176 | 1 |
| &nbsp;&nbsp;&nbsp;Count the Work | 130 | 191 | 1 |
| &nbsp;&nbsp;&nbsp;Verify Order, Preservation, and Stability | 120 | 205 | 1 |
| &nbsp;&nbsp;&nbsp;Choose for the Workload | 174 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Practice: Merge Two Daily Files | 99 | 199 | 2 |
| *Assignments (4 pages)* | *1,179* | *2,163* | *22* |

### Chapter 17: Trees and Binary Search Trees

| Section | Prose | Code tokens | Code cells |
| --- | --- | --- | --- |
| **Tree Structure and Recursive Models** (`1701_tree_structure`) | **1,415** | **477** | **7** |
| &nbsp;&nbsp;&nbsp;Tree Vocabulary | 413 | 58 | 1 |
| &nbsp;&nbsp;&nbsp;Base Case and Recursive Case | 148 | 28 | 1 |
| &nbsp;&nbsp;&nbsp;Tracing the Call Stack | 148 | 42 | 1 |
| &nbsp;&nbsp;&nbsp;Recursive Structure | 364 | 256 | 3 |
| &nbsp;&nbsp;&nbsp;Complete a Recursive Summary Before Designing a New Query | 337 | 93 | 1 |
| **Tree Traversal, Returned Values, and Costs** (`1704_tree_traversal`) | **1,172** | **371** | **4** |
| &nbsp;&nbsp;&nbsp;A Visit and a Returned Result Are Different Events | 216 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Count Active Calls Separately from Visited Nodes | 184 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Traversal Orders | 325 | 114 | 1 |
| &nbsp;&nbsp;&nbsp;Height and Shape | 294 | 78 | 1 |
| &nbsp;&nbsp;&nbsp;Exercise | 80 | 179 | 2 |
| &nbsp;&nbsp;&nbsp;Summary | 67 | 0 | 0 |
| **Binary Search Trees** (`1702_binary_search_trees`) | **2,027** | **1,459** | **9** |
| &nbsp;&nbsp;&nbsp;The BST Invariant | 295 | 121 | 1 |
| &nbsp;&nbsp;&nbsp;Search | 228 | 147 | 1 |
| &nbsp;&nbsp;&nbsp;Insertion | 324 | 149 | 1 |
| &nbsp;&nbsp;&nbsp;Shape and Performance | 266 | 165 | 1 |
| &nbsp;&nbsp;&nbsp;Removal and Subtree Replacement | 557 | 531 | 2 |
| &nbsp;&nbsp;&nbsp;Exercise | 108 | 317 | 2 |
| &nbsp;&nbsp;&nbsp;Tree Shape and Library Choice | 193 | 29 | 1 |
| &nbsp;&nbsp;&nbsp;Summary | 53 | 0 | 0 |
| **Tree Queries and Verification** (`1703_tree_lab`) | **1,374** | **1,600** | **8** |
| &nbsp;&nbsp;&nbsp;An Ordered Service Desk | 242 | 421 | 1 |
| &nbsp;&nbsp;&nbsp;Range Queries and Pruning | 428 | 329 | 3 |
| &nbsp;&nbsp;&nbsp;Level Order with a Queue | 298 | 102 | 1 |
| &nbsp;&nbsp;&nbsp;Verify Updates Against a Model | 218 | 513 | 1 |
| &nbsp;&nbsp;&nbsp;Exercise | 100 | 235 | 2 |
| &nbsp;&nbsp;&nbsp;Summary | 84 | 0 | 0 |
| *Assignments (4 pages)* | *1,471* | *5,396* | *20* |

### Chapter 18: Priority Queues and Heaps

| Section | Prose | Code tokens | Code cells |
| --- | --- | --- | --- |
| **Priority Queue Contracts and Heap Shape** (`1801_priority_queues`) | **1,000** | **175** | **5** |
| &nbsp;&nbsp;&nbsp;Priority Describes Removal, Not a Fully Sorted Array | 299 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Priority Queue Behavior | 298 | 75 | 2 |
| &nbsp;&nbsp;&nbsp;Heap Representation | 298 | 63 | 1 |
| &nbsp;&nbsp;&nbsp;Practice: Service the Minimum Priority | 99 | 37 | 2 |
| **Implementing and Checking a Binary Heap** (`1802_heap_implementation`) | **1,174** | **918** | **5** |
| &nbsp;&nbsp;&nbsp;Repair Only the Part an Operation Can Disturb | 370 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Enqueue and Bubble Up | 214 | 57 | 1 |
| &nbsp;&nbsp;&nbsp;Dequeue and Sink Down | 465 | 370 | 2 |
| &nbsp;&nbsp;&nbsp;Practice: Check Every Parent | 119 | 491 | 2 |
| **Priority Workloads and Top-K Selection** (`1803_priority_applications`) | **997** | **280** | **5** |
| &nbsp;&nbsp;&nbsp;Keep the Boundary of the Best K Items | 462 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Top-K with a Min-Heap | 258 | 97 | 1 |
| &nbsp;&nbsp;&nbsp;Exercise | 85 | 70 | 2 |
| &nbsp;&nbsp;&nbsp;Priority Is Different from Fairness | 95 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Practice: Explain Priority and Fairness | 92 | 113 | 2 |
| *Assignments (4 pages)* | *1,199* | *3,637* | *22* |

### Chapter 19: Hash Collections and Sets

| Section | Prose | Code tokens | Code cells |
| --- | --- | --- | --- |
| **Hash Tables, Equality, and Collisions** (`1901_hashing`) | **1,549** | **1,086** | **6** |
| &nbsp;&nbsp;&nbsp;A Collision Is Not Evidence That Keys Are Equal | 203 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Dictionary Contracts and Key Equality | 195 | 24 | 1 |
| &nbsp;&nbsp;&nbsp;Hash Codes and Bucket Mapping | 209 | 30 | 1 |
| &nbsp;&nbsp;&nbsp;Separate Chaining and Complete Operations | 290 | 320 | 1 |
| &nbsp;&nbsp;&nbsp;Load Factor and Rehashing | 247 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Open Addressing and Deleted Slots | 274 | 87 | 1 |
| &nbsp;&nbsp;&nbsp;Practice: Find a Colliding Key | 126 | 625 | 2 |
| **Dictionaries, Sets, and Reconciliation** (`1902_dictionaries_sets`) | **1,157** | **155** | **5** |
| &nbsp;&nbsp;&nbsp;A Set Answers Membership; a Count Answers Multiplicity | 216 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Choose Equality Before Comparing the Groups | 270 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Sets and Frequency Counts | 131 | 57 | 1 |
| &nbsp;&nbsp;&nbsp;Union, Intersection, and Difference | 178 | 28 | 1 |
| &nbsp;&nbsp;&nbsp;Lookup and Missing Values | 169 | 18 | 1 |
| &nbsp;&nbsp;&nbsp;Keys Must Keep Their Meaning | 97 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Practice: Report Missing IDs | 92 | 52 | 2 |
| **Choosing and Coordinating Collections** (`1903_collection_selection`) | **1,333** | **262** | **5** |
| &nbsp;&nbsp;&nbsp;Coordinate Indexes with One Consistency Story | 330 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Match the Structure to the Workload | 298 | 40 | 1 |
| &nbsp;&nbsp;&nbsp;Count Work Before Timing | 209 | 81 | 1 |
| &nbsp;&nbsp;&nbsp;Dispatch from Two Consistent Indexes | 269 | 89 | 1 |
| &nbsp;&nbsp;&nbsp;Explain the Selection | 107 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Practice: Skip a Cancelled Entry | 116 | 52 | 2 |
| *Assignments (4 pages)* | *1,229* | *2,435* | *22* |

### Chapter 20: Graphs and Traversal

| Section | Prose | Code tokens | Code cells |
| --- | --- | --- | --- |
| **Graph Vocabulary and Models** (`2001_graph_vocabulary`) | **1,426** | **393** | **7** |
| &nbsp;&nbsp;&nbsp;Vertices and Edges | 245 | 49 | 1 |
| &nbsp;&nbsp;&nbsp;Directed and Undirected Relationships | 392 | 159 | 3 |
| &nbsp;&nbsp;&nbsp;Weights and Model Assumptions | 156 | 41 | 1 |
| &nbsp;&nbsp;&nbsp;Neighbors, Degree, and Connectivity | 135 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Walks, Paths, and Cycles | 215 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Simple-Graph Contracts | 180 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Exercise | 99 | 144 | 2 |
| **Adjacency Representations** (`2002_adjacency_representations`) | **1,553** | **761** | **9** |
| &nbsp;&nbsp;&nbsp;Adjacency Matrices | 225 | 85 | 1 |
| &nbsp;&nbsp;&nbsp;Weights and Absence | 146 | 36 | 1 |
| &nbsp;&nbsp;&nbsp;Adjacency Collections | 299 | 157 | 3 |
| &nbsp;&nbsp;&nbsp;Density and Workload Costs | 317 | 43 | 1 |
| &nbsp;&nbsp;&nbsp;A Protected Route Graph | 214 | 313 | 1 |
| &nbsp;&nbsp;&nbsp;Removal, Invariants, and Testing | 253 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Exercise | 97 | 127 | 2 |
| **Breadth-First Search and Paths** (`2003_graph_traversal`) | **1,426** | **904** | **3** |
| &nbsp;&nbsp;&nbsp;Discover a Vertex Once, Then Process Its Neighbors | 707 | 501 | 2 |
| &nbsp;&nbsp;&nbsp;Recover a Path from Earlier Layers | 715 | 403 | 1 |
| **Depth-First Search and Components** (`2004_depth_first_components`) | **1,756** | **1,825** | **6** |
| &nbsp;&nbsp;&nbsp;Watch the Suspended Neighbor Loop | 734 | 471 | 2 |
| &nbsp;&nbsp;&nbsp;Connectivity Depends on Direction | 560 | 512 | 2 |
| &nbsp;&nbsp;&nbsp;Costs and Contracts | 104 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Verify a Traversal | 354 | 842 | 2 |
| *Assignments (4 pages)* | *1,219* | *8,085* | *22* |

### Chapter 21: Algorithm Analysis

| Section | Prose | Code tokens | Code cells |
| --- | --- | --- | --- |
| **Big-O and Complexity** (`2101_big_o`) | **1,432** | **415** | **8** |
| &nbsp;&nbsp;&nbsp;Derive a Count Before Naming a Growth Class | 203 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;A Bound Is a Statement with a Domain | 286 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Choose an Input and a Cost Model | 126 | 43 | 1 |
| &nbsp;&nbsp;&nbsp;Sequential, Rectangular, and Triangular Loops | 121 | 92 | 1 |
| &nbsp;&nbsp;&nbsp;Logarithmic Loops and Multiple Inputs | 136 | 69 | 1 |
| &nbsp;&nbsp;&nbsp;Bounds and Tight Growth | 143 | 35 | 1 |
| &nbsp;&nbsp;&nbsp;Best, Worst, Expected, and Amortized Costs | 145 | 57 | 1 |
| &nbsp;&nbsp;&nbsp;Space, Growth, and Measurement | 138 | 53 | 1 |
| &nbsp;&nbsp;&nbsp;Exercise | 131 | 66 | 2 |
| **Correctness and Invariants** (`2102_correctness`) | **1,240** | **371** | **7** |
| &nbsp;&nbsp;&nbsp;Make the Claim Strong Enough to Guide the Program | 235 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Partial Correctness and Termination Are Separate Questions | 262 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Specifications and Failure Policies | 123 | 81 | 1 |
| &nbsp;&nbsp;&nbsp;An Invariant with an Exact Boundary | 138 | 44 | 1 |
| &nbsp;&nbsp;&nbsp;Termination and Total Correctness | 126 | 20 | 1 |
| &nbsp;&nbsp;&nbsp;Early Return and First-Match Search | 117 | 50 | 1 |
| &nbsp;&nbsp;&nbsp;Boundary Tests and a Counterexample | 117 | 116 | 1 |
| &nbsp;&nbsp;&nbsp;Exercise | 119 | 60 | 2 |
| **Recurrences and Recursive Cost** (`2103_recurrences`) | **1,342** | **281** | **7** |
| &nbsp;&nbsp;&nbsp;Account for the Children and the Work Around Them | 228 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Track Rounding and Live Storage | 256 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Base Cases and Linear Recurrences | 139 | 48 | 1 |
| &nbsp;&nbsp;&nbsp;Halving with Integer Inputs | 121 | 36 | 1 |
| &nbsp;&nbsp;&nbsp;Two Branches and Work per Level | 160 | 46 | 1 |
| &nbsp;&nbsp;&nbsp;Rounding and Auxiliary Storage | 130 | 36 | 1 |
| &nbsp;&nbsp;&nbsp;Branching and Repeated Subproblems | 159 | 34 | 1 |
| &nbsp;&nbsp;&nbsp;Exercise | 145 | 81 | 2 |
| *Assignments (4 pages)* | *977* | *669* | *20* |

### Chapter 22: Recursion and Divide-and-Conquer

| Section | Prose | Code tokens | Code cells |
| --- | --- | --- | --- |
| **Recursive Contracts and Divide-and-Conquer** (`2201_recursion`) | **1,277** | **193** | **7** |
| &nbsp;&nbsp;&nbsp;Let a Helper Promise Exactly One Smaller Problem | 340 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Progress Measures | 161 | 28 | 1 |
| &nbsp;&nbsp;&nbsp;Recursion and Iteration | 145 | 19 | 1 |
| &nbsp;&nbsp;&nbsp;Recursive Risks | 133 | 24 | 1 |
| &nbsp;&nbsp;&nbsp;Exercise | 93 | 48 | 2 |
| &nbsp;&nbsp;&nbsp;The Pattern | 158 | 39 | 1 |
| &nbsp;&nbsp;&nbsp;Halving Strategies | 243 | 35 | 1 |
| **Stable Merge Sort and Verification** (`2203_merge_sort_lab`) | **1,744** | **1,192** | **11** |
| &nbsp;&nbsp;&nbsp;Prove the Combining Step Before Hiding It in Recursion | 328 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Combining Sorted Parts | 169 | 136 | 1 |
| &nbsp;&nbsp;&nbsp;Merge Sort | 155 | 115 | 1 |
| &nbsp;&nbsp;&nbsp;Design Checklist | 47 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Checkpoint: Apply the Basic Merge Sort | 144 | 162 | 2 |
| &nbsp;&nbsp;&nbsp;Trace Merge Fronts | 114 | 24 | 1 |
| &nbsp;&nbsp;&nbsp;Sort Ranges with One Buffer | 172 | 146 | 1 |
| &nbsp;&nbsp;&nbsp;Verify Stability with Labeled Invoices | 128 | 146 | 1 |
| &nbsp;&nbsp;&nbsp;Check Order, Preservation, and Copying | 132 | 156 | 1 |
| &nbsp;&nbsp;&nbsp;Compare Measured Operations | 158 | 145 | 1 |
| &nbsp;&nbsp;&nbsp;Practice: Verify Merge Results | 192 | 162 | 2 |
| *Assignments (4 pages)* | *910* | *1,145* | *20* |

### Chapter 23: Advanced Searching and Sorting

| Section | Prose | Code tokens | Code cells |
| --- | --- | --- | --- |
| **Searching** (`2301_searching`) | **1,270** | **624** | **5** |
| &nbsp;&nbsp;&nbsp;Trace the Boundary Rather than Stopping at Equality | 437 | 100 | 1 |
| &nbsp;&nbsp;&nbsp;Duplicates Turn One Position into an Interval | 348 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Equality and Ordering Policies | 136 | 161 | 1 |
| &nbsp;&nbsp;&nbsp;Lower and Upper Bounds for Duplicates | 139 | 173 | 1 |
| &nbsp;&nbsp;&nbsp;Repeated-Query Workloads | 76 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Exercise | 132 | 190 | 2 |
| **Sorting** (`2302_sorting`) | **1,184** | **567** | **7** |
| &nbsp;&nbsp;&nbsp;Compare the Invariant That Each Sort Maintains | 310 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Swap and Preservation | 132 | 11 | 1 |
| &nbsp;&nbsp;&nbsp;Selection Sort and Its Prefix Invariant | 160 | 120 | 1 |
| &nbsp;&nbsp;&nbsp;Insertion Sort, Shifts, and Nearly Sorted Data | 152 | 32 | 1 |
| &nbsp;&nbsp;&nbsp;Bubble Sort and a Settled Suffix | 139 | 124 | 1 |
| &nbsp;&nbsp;&nbsp;Stability Is Visible on Records | 205 | 132 | 1 |
| &nbsp;&nbsp;&nbsp;Exercise | 84 | 148 | 2 |
| **Comparing Complete Search and Sort Workloads** (`2303_comparison_lab`) | **1,293** | **864** | **8** |
| &nbsp;&nbsp;&nbsp;Make Competing Implementations Answer the Same Question | 342 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Compare Equivalent Search Tasks | 131 | 173 | 1 |
| &nbsp;&nbsp;&nbsp;Check Order and Occurrence Preservation | 117 | 142 | 1 |
| &nbsp;&nbsp;&nbsp;Vary Input Order and Count Meaningfully | 125 | 143 | 1 |
| &nbsp;&nbsp;&nbsp;Exact Formulas and Growth Models | 152 | 16 | 1 |
| &nbsp;&nbsp;&nbsp;Include Preparation in Repeated Queries | 142 | 186 | 1 |
| &nbsp;&nbsp;&nbsp;Write a Requirement-Based Recommendation | 139 | 46 | 1 |
| &nbsp;&nbsp;&nbsp;Exercise | 139 | 158 | 2 |
| **Shell Sort and Gap Families** (`2304_advanced_sorts`) | **1,067** | **206** | **1** |
| &nbsp;&nbsp;&nbsp;Each Gap Pass Solves an Interleaved Insertion Problem | 402 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Shell Sort | 250 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Compare Correct Results | 410 | 206 | 1 |
| **Quicksort and Partitioning** (`2305_quicksort`) | **1,139** | **337** | **2** |
| &nbsp;&nbsp;&nbsp;Work the Two-Scan Partition Before Recursing | 426 | 109 | 1 |
| &nbsp;&nbsp;&nbsp;Partition Establishes a Boundary, Not a Fully Sorted Array | 349 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Quicksort | 361 | 228 | 1 |
| *Assignments (5 pages)* | *1,481* | *1,858* | *21* |

### Chapter 24: Greedy Algorithms and Graph Optimization

| Section | Prose | Code tokens | Code cells |
| --- | --- | --- | --- |
| **Greedy Choices and Exchange Reasoning** (`2401_greedy_choice`) | **1,228** | **542** | **7** |
| &nbsp;&nbsp;&nbsp;Identify the Objective That Makes the Exchange Work | 330 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Schedule the Maximum Number of Meetings | 151 | 77 | 1 |
| &nbsp;&nbsp;&nbsp;Trace Accepted and Rejected Choices | 86 | 87 | 1 |
| &nbsp;&nbsp;&nbsp;Exchange the First Choice | 129 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;A Verified Counterexample for a Different Objective | 123 | 86 | 1 |
| &nbsp;&nbsp;&nbsp;Another Greedy Trap: Coin Counts | 78 | 19 | 1 |
| &nbsp;&nbsp;&nbsp;Exercise | 166 | 177 | 2 |
| &nbsp;&nbsp;&nbsp;Validate the Meeting Objective | 160 | 96 | 1 |
| **Minimum Spanning Forests and Kruskal** (`2402_spanning_trees_shortest_paths`) | **1,431** | **750** | **3** |
| &nbsp;&nbsp;&nbsp;Keep Connectivity State Separate from the Cable Budget | 442 | 142 | 1 |
| &nbsp;&nbsp;&nbsp;Guide a New Edge Before Running the Full Program | 166 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Connect Every Site Without Paying for a Cycle | 378 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;MST Contracts and Disconnected Graphs | 149 | 301 | 1 |
| &nbsp;&nbsp;&nbsp;Kruskal Invariants and the Cut Argument | 140 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Inspect the Cable Forest | 151 | 307 | 1 |
| **Shortest Paths and Dijkstra** (`2404_shortest_paths`) | **1,894** | **3,431** | **11** |
| &nbsp;&nbsp;&nbsp;Improve Tentative Routes Before Declaring Them Final | 259 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Check the Witness as Well as the Number | 131 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Dijkstra with Nonnegative Directed Arcs | 177 | 303 | 1 |
| &nbsp;&nbsp;&nbsp;Stale Queue Entries and Qualified Costs | 168 | 303 | 1 |
| &nbsp;&nbsp;&nbsp;Reconstruct Only Reachable Routes | 193 | 306 | 1 |
| &nbsp;&nbsp;&nbsp;Minimum Hops Is Not Minimum Cost | 99 | 302 | 1 |
| &nbsp;&nbsp;&nbsp;The Cheapest Network Is Not a Shortest-Route Tree | 126 | 308 | 1 |
| &nbsp;&nbsp;&nbsp;Exercise | 141 | 628 | 2 |
| &nbsp;&nbsp;&nbsp;Verify Delivery Routes Independently | 118 | 329 | 1 |
| &nbsp;&nbsp;&nbsp;Boundary Policies Are Part of Correctness | 134 | 307 | 1 |
| &nbsp;&nbsp;&nbsp;Choose the Model Before the Rule | 77 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Practice: Compare Facilities Models | 267 | 645 | 2 |
| *Assignments (4 pages)* | *874* | *2,703* | *20* |

### Chapter 25: Dynamic Programming and Backtracking

| Section | Prose | Code tokens | Code cells |
| --- | --- | --- | --- |
| **Memoization, Tabulation, and Repeated Work** (`2501_memoization_tabulation`) | **1,449** | **458** | **5** |
| &nbsp;&nbsp;&nbsp;Compare Three Executions of the Same Dependency Rule | 352 | 70 | 1 |
| &nbsp;&nbsp;&nbsp;Fill the Same States Without Recursive Calls | 260 | 47 | 1 |
| &nbsp;&nbsp;&nbsp;Save Answers to Repeated Questions, Not Arbitrary Intermediate State | 343 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Memoization and Tabulation | 48 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Repeated Work Is Visible | 159 | 113 | 1 |
| &nbsp;&nbsp;&nbsp;Memoization Stores Complete States | 124 | 113 | 1 |
| &nbsp;&nbsp;&nbsp;Tabulation Follows Dependency Order | 158 | 115 | 1 |
| **Optimization States and Reconstructed Solutions** (`2504_optimization_models`) | **1,893** | **791** | **7** |
| &nbsp;&nbsp;&nbsp;Derive Every Entry of a Small Purchasing Plan | 419 | 112 | 1 |
| &nbsp;&nbsp;&nbsp;Guide an Unreachable Entry and Check Its Witness | 198 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Define the State from the Choices That Remain | 242 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Preserve Enough Information to Explain the Answer | 179 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Minimum Coins: Model Before Implementation | 209 | 101 | 1 |
| &nbsp;&nbsp;&nbsp;State Size, Numeric Size, and the Requested Result | 152 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Exercise | 111 | 129 | 2 |
| &nbsp;&nbsp;&nbsp;Verify an Optimum and Its Witness | 112 | 100 | 1 |
| &nbsp;&nbsp;&nbsp;Inventory Changes the Answer | 92 | 230 | 1 |
| &nbsp;&nbsp;&nbsp;Compare DP with an Independent Small Reference | 174 | 119 | 1 |
| **Backtracking, Pruning, and Search States** (`2502_backtracking`) | **1,784** | **1,281** | **10** |
| &nbsp;&nbsp;&nbsp;Undo Exactly the Choice Owned by the Current Call | 386 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Backtracking and Search Spaces | 47 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Choose, Explore, Undo, and Snapshot | 184 | 79 | 1 |
| &nbsp;&nbsp;&nbsp;One-Use Subset Sum Needs a Two-Part State | 167 | 147 | 1 |
| &nbsp;&nbsp;&nbsp;Prove Bounds Before Pruning | 193 | 159 | 1 |
| &nbsp;&nbsp;&nbsp;Memoize Failed States Without Losing Choices | 192 | 153 | 1 |
| &nbsp;&nbsp;&nbsp;Permutations Use Every Position Exactly Once | 141 | 83 | 1 |
| &nbsp;&nbsp;&nbsp;Exercise | 84 | 174 | 2 |
| &nbsp;&nbsp;&nbsp;Check Search Against Exhaustive Positions | 101 | 221 | 1 |
| &nbsp;&nbsp;&nbsp;Explain a Recommendation with Evidence | 104 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Practice: Validate Search Evidence | 180 | 265 | 2 |
| *Assignments (4 pages)* | *1,002* | *1,610* | *20* |

### Chapter 26: String Matching and Computational Limits

| Section | Prose | Code tokens | Code cells |
| --- | --- | --- | --- |
| **Direct String Matching and Result Contracts** (`2602_shortest_paths_strings`) | **1,016** | **207** | **2** |
| &nbsp;&nbsp;&nbsp;Separate a Candidate Start from Its Matched Length | 348 | 65 | 1 |
| &nbsp;&nbsp;&nbsp;Define What Counts as a Match Before Choosing an Algorithm | 230 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Use Mismatches as Evidence | 208 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Direct Matching with an Explicit Contract | 224 | 142 | 1 |
| **Prefix Reuse and KMP** (`2604_prefix_matching`) | **1,823** | **824** | **7** |
| &nbsp;&nbsp;&nbsp;Build the Fallback Table Before Scanning Text | 336 | 55 | 1 |
| &nbsp;&nbsp;&nbsp;Keep a Proven Suffix After Reporting a Match | 405 | 146 | 1 |
| &nbsp;&nbsp;&nbsp;Reuse a Prefix Only When It Is Also the Needed Suffix | 229 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Separate Two Progress Arguments | 230 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Proper Prefixes Survive a Mismatch | 171 | 140 | 1 |
| &nbsp;&nbsp;&nbsp;KMP Keeps the Text Moving Forward | 159 | 148 | 1 |
| &nbsp;&nbsp;&nbsp;Measure a Complete Workload and Define Text Units | 140 | 156 | 1 |
| &nbsp;&nbsp;&nbsp;Exercise | 149 | 179 | 2 |
| **Algorithms and Computational Limits** (`2603_limits_project`) | **1,240** | **455** | **5** |
| &nbsp;&nbsp;&nbsp;A Limit on One Program Is Not a Lower Bound on Every Algorithm | 376 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Growth Models Are Not Benchmarks | 128 | 28 | 1 |
| &nbsp;&nbsp;&nbsp;Exact Search and a Concrete Heuristic | 176 | 128 | 1 |
| &nbsp;&nbsp;&nbsp;Guarantees, Heuristics, and Unknown Answers | 138 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Validate Results Before Comparing Speed | 134 | 136 | 1 |
| &nbsp;&nbsp;&nbsp;A Reviewable Final Comparison | 142 | 0 | 0 |
| &nbsp;&nbsp;&nbsp;Exercise | 142 | 163 | 2 |
| *Assignments (4 pages)* | *949* | *2,419* | *20* |

