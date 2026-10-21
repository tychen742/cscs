---
orphan: true
---

# Curriculum Alignment Authoring Record

Current evidence mirrors the published curriculum appendix. Introductory AI literacy is integrated with programming practice; DB and AI application capstones remain optional. Neither establishes full degree-level coverage of its area.

```{index} curriculum alignment; CS2023
```

(cs2023_alignment)=

# Curriculum Alignment (IS2020 and CS2023)

The primary audience is students in College of Business information systems programs. The IS2020 mapping therefore comes first and explains the book’s contribution to that pathway. The CS2023 mapping follows as a reference for its broader computer science foundation and optional technical depth. Neither mapping establishes complete degree-program coverage.


(is2020-alignment)=

```{index} curriculum alignment; IS2020
```

## IS2020 Mapping



*IS2020: A Competency Model for Undergraduate Programs in Information Systems* provides curriculum guidance from the Association for Computing Machinery (ACM) and the Association for Information Systems (AIS), including for IS/MIS programs in colleges of business.[^is2020] Its competency areas describe degree-level expectations. The following mapping is the author's interpretation of this book's contribution, not a claim of complete program coverage or graduate competency attainment.

**Direct** means the book explicitly teaches relevant introductory knowledge and skills. **Partial** means it introduces selected topics. **Supporting** means activities can contribute when instructors assess them in context. **Outside scope** means another course must supply the area. These descriptions are local mapping labels, not IS2020 proficiency levels.

| IS2020 required competency area | Book evidence | Contribution and boundary |
|---|---|---|
| Foundations of Information Systems | Chapter 1: computing concepts, input-process-output, and development workflow; the database appendix: persistent data. | **Partial.** Introduces computing and information processing; organizational IS roles and enterprise processes need a broader IS foundations course. |
| Data / Information Management | Chapters 7-9: arrays, collections, files, and text; Database appendix: relational models, keys, SQL queries and changes, and a C# database workflow. | **Direct introductory contribution.** Supports representing and persisting application data; database administration and organization-wide data governance require further study. |
| IT Infrastructure | Chapter 1: compiler/runtime roles and edit/build/run; Appendix B: SDK, editor, terminal, and REPL setup. | **Partial.** Provides a development environment foundation; networking, cloud infrastructure, and production operations are outside this sequence. |
| Secure Computing | Chapter 6: validation and error handling; Chapter 1: introductory privacy; Chapter 9: masking, validation, and safe logging; the database appendix: parameterized SQL. | **Partial.** Teaches selected secure coding practices; infrastructure defense and organizational security management require other courses. |
| Systems Analysis & Design | Chapter 1: development workflow; Chapters 10-12: classes, encapsulation, interfaces, and object-oriented design; Group Project appendix: feature planning and refinement. | **Partial.** Supports small application design; stakeholder elicitation and formal analysis/modeling methods need dedicated instruction. |
| Application Development / Programming | Chapters 1-12: C# fundamentals, testing, collections, object-oriented programs, with optional database access in the appendix; Chapters 13-20: data structures and their algorithmic foundations; optional Chapters 21-26: deeper analysis and algorithm design. | **Direct introductory contribution.** This is the book's main role in an IS program. Web/mobile development and production deployment remain outside scope. |
| Ethics, Use & Implications for Society | Chapter 1.2: social impact, ethical analysis, introductory privacy, accessibility, attribution, and responsible AI use; Chapter 6: failure cases; Chapter 9: privacy practice; Appendix C: professional practice. | **Direct introductory contribution.** Cases support ethical reasoning; instructors should also assess it in project and organizational decisions. |
| IS Management & Strategy | Business examples supply application context throughout the book. | **Outside scope.** Business examples alone do not teach IS strategy, governance, sourcing, or investment decisions. |
| IS Project Management | Group Project appendix: roles, periodic reports, staged implementations, team coordination, and presentations. | **Supporting.** Provides practice opportunities; formal scope, schedule, budget, and risk management require additional instruction and assessment. |
| IS Practicum | Group Project appendix: integrated implementation, testing, documentation, demonstration, and individual reflection. | **Supporting.** Can contribute to a practicum when the instructor specifies organizational requirements and assesses integration. A programming project alone does not establish full practicum coverage. |



```{index} IS2020; object-oriented paradigm
```

## IS2020 Course Use and Evidence



Chapters 1-12 provide the programming and information-systems foundation for the College of Business pathway. Instructors select Parts IV-V (Chapters 13-20) for the CS2 foundation. Basic Big-O, searching and library sorting, recursive calls, and graph traversal appear there without requiring Parts VI-VII (Chapters 21-26), which provide optional algorithmic depth.

The IS2020 elective area **Object-Oriented Paradigm** has relevant support in Chapters 10-12 and the interfaces and generics of Chapter 13. Other specializations, such as web programming, mobile programming, and user interface design, need additional material.

An instructor can use completed programs and tests for programming evidence, SQL and schema exercises for data-management evidence, Chapter 1.2 case analyses for ethics evidence, and project reports and demonstrations for integration evidence. The optional database appendix includes a connected inventory lab; assess its SQL and schema work separately when it is assigned.

This mapping records learning opportunities in the published sequence. A program-level review must separately establish the required knowledge, skill levels, dispositions, and assessment evidence across its courses.



```{index} curriculum alignment; CS2023
```

## CS2023 Mapping



The book is mapped to *Computer Science Curricula 2023* (CS2023), the joint curriculum guidelines of ACM, IEEE Computer Society, and AAAI.[^cs2023] CS2023 organizes computer science into knowledge areas, each divided into knowledge units such as `SDF-Fundamentals`. Its introductory sequence is built mainly from Software Development Fundamentals (SDF) and Algorithmic Foundations (AL). Semester 1 of this book corresponds to the CS2023 *CS I* course and Semester 2 to *CS II*, plus part of a separate algorithms course.

| Ch. | Topic | Primary CS2023 units | Also touches |
|---|---|---|---|
| 1 | Computing, Programs, and Responsibility | SDF-Fundamentals, SEP-Context, SEP-Ethical-Analysis | FPL-Translation, SDF-Practices, SEP-Professional-Ethics, SEP-Privacy, SEP-DEIA |
| 2 | Variables and Types | SDF-Fundamentals, FPL-Types | SEC-Coding |
| 3 | Decisions | SDF-Fundamentals | |
| 4 | Iteration | SDF-Fundamentals, SDF-Algorithms | |
| 5 | Methods and Strings | SDF-Fundamentals | SE-Construction, SDF-Data-Structures |
| 6 | Testing, Debugging, and Error Handling | SDF-Practices, SE-Validation | SEC-Coding, SEP-Professional-Ethics |
| 7 | Arrays | SDF-Data-Structures | SDF-Algorithms |
| 8 | Collections | SDF-Data-Structures | AL-Foundational, FPL-Systems |
| 9 | Files and Text | SDF-Fundamentals, SDF-Data-Structures | AL-Models, DM-Data, SEC-Coding, DM-Security, SEP-Privacy |
| 10 | Classes and Objects | FPL-OOP, SDF-Fundamentals | SE-Design |
| 11 | Object Design and Composition | FPL-OOP, SE-Design | SE-Construction (tests and invariants), FPL-Types (nullability) |
| 12 | Inheritance, Interfaces, and Polymorphism | FPL-OOP, SE-Design | SE-Construction |
| 13 | Abstract Data Types | SDF-Data-Structures, AL-Foundational | AL-Complexity, FPL-Types |
| 14 | Arrays and Linked Lists | AL-Foundational | AL-Complexity, FPL-Systems |
| 15 | Stacks and Queues | AL-Foundational | SDF-Algorithms |
| 16 | Searching and Basic Sorting | AL-Foundational, SDF-Algorithms | AL-Complexity |
| 17 | Trees and Binary Search Trees | AL-Foundational | AL-Complexity |
| 18 | Priority Queues and Heaps | AL-Foundational | AL-Complexity |
| 19 | Hash Collections and Sets | AL-Foundational | AL-Complexity, MSF-Discrete |
| 20 | Graphs and Traversal | AL-Foundational | MSF-Discrete |
| 21 | Algorithm Analysis | AL-Complexity | SDF-Algorithms, MSF-Discrete |
| 22 | Recursion and Divide and Conquer | AL-Strategies, SDF-Algorithms | |
| 23 | Advanced Searching and Sorting | AL-Foundational, SDF-Algorithms | AL-Complexity |
| 24 | Greedy Algorithms | AL-Strategies, AL-Foundational | |
| 25 | Dynamic Programming and Backtracking | AL-Strategies | |
| 26 | Advanced Graphs, Strings, and Limits | AL-Foundational, AL-Complexity | AL-Models |
| Appendix B | C# setup and development tools | SE-Tools | SDF-Practices |
| Appendix C | Git and professional practice | SE-Tools, SEP-IP | SEP-Communication, SEP-DEIA |
| Appendix | Databases and Bookstore Inventory | DM-Core, DM-Modeling, DM-Relational, DM-Querying | DM-Security, SEC-Coding |

Knowledge-area abbreviations: SDF (Software Development Fundamentals), AL (Algorithmic Foundations), FPL (Foundations of Programming Languages), SE (Software Engineering), DM (Data Management), SEC (Security), SEP (Society, Ethics, and the Profession), MSF (Mathematical and Statistical Foundations).

The mapping is a working draft. Chapter 1 introduces Society, Ethics, and the Profession (SEP), with further cases in Chapters 6 and 9 and Appendix C; coverage of functional and asynchronous programming is still being added. Formal languages and the mathematics units are left to theory and mathematics courses.

The integrated AI activities provide introductory AI literacy and programming-review evidence in Chapters 1, 3, 6, and 9. They do not constitute coverage of the full CS2023 Artificial Intelligence knowledge area or a machine-learning course. Database coverage depends on selecting the optional post-OOP capstone; it is not evidence that every CS1 adopter teaches SQL. The optional AI project extension is additional application practice, not a required outcome for the core route.


```{rubric} Footnotes
```

[^is2020]: The Joint ACM/AIS IS2020 Task Force (2021). *IS2020: A Competency Model for Undergraduate Programs in Information Systems*. ACM and AIS. <https://doi.org/10.1145/3460863>. See Chapter 4, Figure 4-2 for required and elective areas, and Section 4.3.2 for the business-school context.

[^cs2023]: Amruth N. Kumar, Rajendra K. Raj, et al. (2023). *Computer Science Curricula 2023*. ACM Press, IEEE Computer Society Press, and AAAI Press. <https://doi.org/10.1145/3664191>
