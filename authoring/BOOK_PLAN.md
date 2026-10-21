# Book Plan: Computer Science in C#

## Audience and Scope

Computer Science in C# is an open Jupyter Book for students beginning programming, with management and business examples and a wider CS/IT foundation. No programming experience is assumed. COB, IST, IT, IS, and LIS programs can adopt CS1 alone or a CS1/CS2 sequence.

Parts I-III (Chapters 1-12) form the complete CS1 route. Parts IV-V (Chapters 13-20) supply eight CS2 foundation units. Parts VI-VII (Chapters 21-26) supply six selectable units of algorithmic depth. The 26-chapter volume is not a requirement to teach 26 weeks. Instructors reserve time for review, exams, and projects.

## Current Sequence

### Part I. Fundamentals (Chapters 1-6)

1. Computing, Programs, and Responsibility.
2. Variables, Data Types, and Operators.
3. Decisions.
4. Iteration.
5. Methods.
6. Testing, Debugging, and Error Handling.

### Part II. Data and I/O (Chapters 7-9)

7. Arrays.
8. Collections.
9. Files and Text.

### Part III. Object-Oriented Programming (Chapters 10-12)

10. Classes and Objects.
11. Object Design and Composition.
12. Inheritance, Interfaces, and Polymorphism.

### Part IV. Data Abstraction and Linear Structures (Chapters 13-16)

13. Abstract Data Types.
14. Arrays and Linked Lists.
15. Stacks and Queues.
16. Searching and Basic Sorting.

### Part V. Trees, Hashing, and Graphs (Chapters 17-20)

17. Trees and Binary Search Trees.
18. Priority Queues and Heaps.
19. Hash Collections and Sets.
20. Graphs and Traversal.

### Part VI. Algorithm Analysis and Design (Chapters 21-23)

21. Algorithm Analysis.
22. Recursion and Divide and Conquer.
23. Advanced Searching and Sorting.

### Part VII. Optimization and Computational Limits (Chapters 24-26)

24. Greedy Algorithms and Graph Optimization.
25. Dynamic Programming and Backtracking.
26. Advanced Algorithms: String Matching and Computational Limits.

## Testing, Debugging, and Error-Handling Progression

Testing is a development habit from the first program, not a topic that begins in Chapter 6. Keep three roles distinct: testing checks behavior against expectations, debugging investigates discrepancies, and exception handling defines failure responses.

| Location | Teaching role |
| --- | --- |
| Chapters 1-2 | Read compiler/runtime diagnostics, predict output, and compare actual results with expected results. Use valid-input assumptions explicitly; do not require exception syntax. |
| Chapters 3-4 | Check decision boundaries, invalid values, and zero/one/many iterations. Use decisions and TryParse for routine validation when appropriate. |
| Chapter 5 | Define methods around familiar decisions and loops, then test return values with independent expected results and ordinary and boundary cases. |
| Chapter 6 | Consolidate systematic test design, debugger use, regression checks, and basic try/catch/throw. Retain basic null checks for missing input; do not require the full nullable operator/reference-type system. |
| Chapter 9 | Revisit exceptions with missing files, malformed records, and deterministic resource cleanup. |
| Chapters 10-12 | Extend tests to object state and collaboration. Chapter 11 owns deeper nullability: nullable value versus reference types, compiler flow warnings, required versus optional relationships, constructor contracts, safe navigation, and missing-data tests. Revisit failure contracts through interfaces in Chapter 12. |

The relocated nullability notebook is supporting reading within Chapter 11's three meetings, not an additional week. Basic null checks remain available earlier wherever needed. Nullable annotations describe a compile-time contract; runtime validation still enforces required values. Do not teach the null-forgiving operator as a repair for an invalid contract.

## Part Boundaries and Prerequisites

Keep all 26 chapters in their existing order. Parts IV and V divide the CS2 foundation into linear structures and trees/hashing/graphs. Parts VI and VII divide selectable depth into analysis/design and optimization/limits. Chapter 13 still introduces practical cost analysis before operation comparisons; Chapter 17 still introduces recursive cases and call-stack traces before tree algorithms. Neither foundation requires the later algorithms parts.

## Chapter 1 and Development Tools

Chapter 1 is Computing, Programs, and Responsibility: 1.1 Computing and Problem Solving (30 minutes), 1.2 Computing and Professional Responsibility (35 minutes), and 1.3 Your First C# Program and Basic Syntax (45 minutes). Its 110-minute progression uses an appointment-reminder example for responsibility and an order-desk message for syntax. Keep editor/compiler/runtime roles and the first edit/build/run workflow in the chapter.

Appendix B provides .NET SDK installation, VS Code/C# extensions, terminal/workspace preparation, CSharpRepl, ecosystem reference, and setup troubleshooting. Its existing Commons reference pages remain synced sources. Appendix C retains Git and adds the detailed professional-practice reference. The previous setup video moves with setup; a revised chapter video and slides are pending.

There is no standalone ethics chapter. Introductory ethical reasoning appears in 1.2. Optional software-failure cases accompany Chapter 6; optional privacy/security coding and the retained privacy assessments accompany Chapter 9. Professional-practice detail is in Appendix C. Database injection prevention and parameterized SQL remain in the optional database appendix. Optional privacy practice retains all existing assessment identifiers and is not a new required class meeting.

## Migration and Assessment Identity

The former Chapters 8-27 become Chapters 7-26. Numbered demo folders follow the displayed chapters. Existing assignment IDs, exercise IDs, radio names, and notebook/cell metadata remain independent of displayed chapter numbers. Preserve old published URLs with direct redirects and flatten earlier redirect destinations. Legacy ethics assessments remain available as optional privacy practice; they are not deleted or reassigned new IDs. Preserve the recent Chapter 2 and Classes assessment revisions.

## Course Design

CS1 progresses from problem solving and responsibility through sequential programs, variables, decisions, iteration, methods, testing, arrays, collections, files, and object-oriented design. Its project grows from a small console program to a tested application. Database persistence is optional after OOP.

CS2 assumes methods, collections, classes, and interfaces. Its foundation studies contracts/costs, linear structures, searching/sorting, recursive trees, heaps, hashing, and graph traversal. Projects emphasize choosing representations, testing invariants, and explaining tradeoffs. Instructors select optional algorithms according to course goals.

### Course Alignment Rule

The book should distinguish three levels of material:

- **Course core:** required for the corresponding IST course and its exams.
- **Applied extension:** useful for projects and information-systems work but
	not required for every student to master immediately.
- **Further study:** material retained in the book for a complete CS pathway,
	future courses, or students continuing into data science and software work.

The two-semester design should preserve the book's broader foundation without
quietly turning every advanced topic into a prerequisite for the first-semester
course.

### Weekly Pacing

One chapter is the weekly organizing unit. A chapter's notebooks should make
the week's progression visible: orientation and objectives, content sections,
worked examples, practice, and assignments. Reviews, exams, and project
demonstrations can occupy the appropriate chapter's assignment area without
requiring a separate top-level chapter.

## Out of Scope

- Web or mobile development (aspirational future direction)
- Advanced frameworks (.NET ecosystem beyond core C\#)

## C# Tooling Progression

The book uses a staged C# tooling model. In **Part I: Fundamentals**, students
may use `csharprepl` heavily for quick demonstrations, expression testing, and
syntax learning. This lowers friction while students are still learning what
variables, expressions, conditionals, loops, methods, exceptions, and tests do.

The durable workflow for the book is still **Project/Application mode**:
students read the book, practice with browser `Run C#` cells when useful, and
do sustained work in VS Code using normal .NET console applications. As soon as
examples become multi-step, file-based, tested, or submitted for labs and
projects, they should move toward source files, compilation, debugging, and
predictable application execution.

`dotnet-script` and similar script tools may be mentioned as optional
exploration tools, but they are not a required course dependency unless a
specific assignment says so.

Authoring rule:

- Use `Console.WriteLine(...)` when a runnable cell should display an
  expression value in application-mode code.
- In Part I, REPL transcripts may use bare expressions when the goal is quick
  demonstration or syntax testing. Label those examples as `csharprepl` examples
  so students understand why a value appears without `Console.WriteLine`.
- Do not let required labs, homework, projects, or later-chapter examples depend
  on REPL-only behavior such as hidden cross-cell state or reading unassigned
  local variables.
- Explicitly initialize local variables in application-mode examples, including
  with `default` when teaching default values.
- When a Part I REPL transcript teaches a concept that students will also need
  in projects, include or soon transition to a normal runnable C# equivalent.

For browser reliability, every runnable code cell should work from the
beginning of the cell. A cell must include the variables, collections, and
imports it needs rather than depending on an earlier cell's hidden state. When
state across cells is the learning objective, the cells should be labeled as a
sequence and include a visible setup/reset cell.

Line numbers are a future editor enhancement for longer examples. They would
help students connect compiler diagnostics such as `Program.cs(4,1)` to the
editable code. Keep the current short-cell editor lightweight; when longer
cells become common, add a synchronized line-number gutter using CodeMirror or
another editor component rather than relying on a plain `<textarea>`.

Do not make the curriculum depend on Binder, Jupyter kernels, .NET Interactive,
or `dotnet-script`. `csharprepl` is part of the Part I learning workflow, but
not the final programming model of the book. The browser runner may support
REPL-like conveniences, but online examples used beyond quick Part I
demonstrations should continue to work as normal C# console-application code.

This decision should be revisited when designing first-semester chapters and
assignments, especially the first variables, methods, collections, and classes
activities.

## Assignment Delivery and Persistence

The book should contain the complete instructional assignment material: the
prompt, context, examples, rubric, starter code, tests, and submission
instructions. Each assignment and exercise must have a stable ID that is used
consistently in the notebook, browser execution service, downloadable files,
and any future gradebook integration.

The book recognizes four assignment types:

| Type | Purpose | Required shape |
| --- | --- | --- |
| Preview | Prepare for class | Multiple-choice questions based on the content |
| Lab | Practice technical skills through guided hands-on work | Connected coding questions on one theme |
| Homework | Reinforce concepts and coding | Five true/false questions and five coding questions |
| Project | Apply concepts in a durable artifact | A cumulative VS Code project milestone or deliverable |

Preview, Lab, and Homework are the regular chapter assignment set for technical
book chapters.
Student-facing post-class reinforcement should be called **Homework**, not
Review. Existing `homework.ipynb` pages are the standard post-class assignment files
during chapter cleanup.

The Project assignment is distinct from the Lab. A Lab is a guided practice
sequence that can be completed in the browser or locally. A Project produces a
versioned artifact with files, tests, documentation, and a submission history.

Assignments should support two coordinated workflows:

1. **Browser workflow**: students can read the prompt, edit short exercise
	 cells, run C# code, and save authenticated exercise drafts in the book
	 service. This is useful for preparation, low-friction practice, and quick
	 feedback.
2. **VS Code workflow**: students download or clone the assignment starter
	 project, open it in VS Code, run the provided tests and programs locally,
	 and submit the project through GitHub or the course LMS. This is the durable
	 workflow for multi-file assignments and project-based learning.

The semester projects (an individual midterm project and a group final project) should give students a path to build a desktop application.
Windows and macOS are acceptable target operating systems for that app, even
though students may use Linux for other course work. Before project work begins,
identify the supported operating systems and required build tools. In
particular, .NET MAUI supports Windows and macOS desktop targets but does not
officially support Linux desktop apps. If MAUI is selected, the student-facing
project instructions must state this clearly and provide Linux students an
instructor-approved alternative or access to a supported environment; do not
leave them to discover the limitation after choosing a project.

The browser draft and VS Code project should not be treated as one live shared
filesystem. Instead, they share the same assignment ID, starter version,
learning objectives, and tests. The book should provide an explicit handoff:
students can download their current browser code as a `.cs` file or starter
project, then continue in VS Code. Conversely, a later browser upload/import
feature may accept a `.cs` file for experimentation, but it should not replace
GitHub as the source of submitted project history.

Browser-runnable cells use two editing surfaces for the same underlying code
draft. In view mode, show **Edit | Inline | Run**. **Edit** opens a separate
"Your version" editor below the published sample; **Inline** replaces the
rendered code block with an in-place editor. After either editing surface is
opened, show **Done | Reset | Run**. **Done** returns to the published reading
view, **Reset** restores the original sample source, and **Run** executes the
current draft. This keeps quick reading experiments lightweight while still
offering a larger editing surface when students need it.

Future editor feature: robust multi-line mouse selection in inline mode. The
current inline editor is deliberately span-based and lightweight, which is good
for quick edits in short examples but not enough for full editor behavior. Keep
multi-line mouse selection, rectangular selection, multi-cursor editing,
automatic indentation, and syntax-aware editing as a future CodeMirror-level
enhancement rather than expanding the current inline editor into a fragile
custom IDE.

Persistence requirements:

- Anonymous reading continuity uses browser `localStorage` for the last page and
	scroll position. This supports "Continue Reading" on the same browser without
	requiring a login.
- Authenticated reading continuity is stored in the database by user and book,
	so a student can continue from the same page across browsers or devices.
- Cookies are used for authentication/session identity only. They should not be
	the storage location for reading progress, drafts, assignments, or grades.
- Browser drafts are associated with the authenticated student, assignment ID,
	exercise ID, and starter version.
- Published prompts and starter files are versioned with the book repository.
- Student drafts are stored separately from published content and never modify
	the book source.
- A browser draft is clearly labeled as a draft until the student submits the
	assignment through the course workflow.
- Every assignment that expects VS Code includes setup, run, test, and submit
	instructions in the book itself.

The later persistence service will need a database for three application
domains: user management, exercise drafts, and assignment management. User
records should include roles and course membership. Exercise records should
include the stable exercise ID, authenticated user ID, starter version, saved
source, timestamp, and optional revision or completion state. Assignment
records should include the stable assignment ID, type, chapter association,
published version, availability metadata, and submission references.

The database should store student and course state, not replace Git as the
source of truth for published book content. This persistence layer is a later
phase after browser execution, editing, and VS Code handoff are stable.

This model keeps the book comprehensive for learning and instruction while
allowing the local development environment to grow in complexity as students
are ready for it.

### Admin Authoring Mode

The first authoring CMS should remain deliberately lightweight. An authenticated
administrator can switch a book page into author mode and edit markdown or C#
cells inline. The authoring controls are:

- **Author**: enable editing for the page's cells
- **Save**: write the edited cell strings back to the same `.ipynb` source file
- **Sync**: commit pending browser-authored source changes and push them to GitHub
- **Run**: execute the current C# cell through the execution service
- **Preview**: inspect the rendered page before publishing

The notebook file remains the source of truth. Git remains the synchronization,
versioning, review, and rollback system. The server-side book root used by the
authoring API must be a Git checkout of the content repository, not a loose
rsync mirror. Browser edits save into that checkout as ordinary working-tree
changes that can be reviewed, committed, pushed, rebuilt, or rolled back.
Publishing rebuilds the Jupyter Book from the saved notebook files; the browser
editor does not create a second content format or require an immediate
migration to a database-backed CMS.

GitHub Actions is the production publishing bridge. A push to `main` builds the
book, deploys the generated HTML to `/var/www/cscs/`, and refreshes the
server-side authoring checkout from `origin/main` when that checkout is clean.
If browser-authored changes are still unsynced on the server, the workflow
should fail rather than overwrite them.

A database is supporting infrastructure for authentication, roles, autosave
drafts, edit locks, audit history, and recovery of unsaved work. It is not the
canonical authoring store. The first implementation should prioritize safe
authenticated file editing and Git-aware save/publish behavior, then add
database-backed conveniences as the authoring workflow matures.

### VS Code and Book Connection

Every substantial exercise should identify its relationship to a VS Code
project. The book page should provide:

- a stable exercise or assignment ID
- the browser version of the task
- a link to the matching starter project or repository folder
- the expected file name and project location for the solution
- commands for running the program and tests in VS Code's terminal
- the submission method and required files

The normal handoff is:

1. Read the explanation and try the small version in the browser.
2. Edit and run the browser exercise to check understanding.
3. Download or clone the matching starter project.
4. Open the project in VS Code and continue the solution there.
5. Run the supplied tests and submit the VS Code project through GitHub or the
	course LMS.

Students submit the code edited in VS Code, not the browser draft, for any
assignment that requires a project, multiple files, tests, or a durable Git
history. The browser draft is practice and may be exported as a starting point
when that is useful. The book should state this distinction directly on every
assignment page.

### Teaching Projects Through the Book

Projects should be introduced as a sequence of small deliverables inside the
book, not as a large specification that appears only at the end of the term.
Each relevant lab should include a short **Project connection** section that
answers three questions:

- What project feature is being built this week?
- Which chapter concept does it practice?
- What file, test, or demonstration should exist at the end?

The project progression should move from single-file programs to organized
multi-file projects, then to tests, persistence, and final documentation. A
typical progression is:

1. define the problem and sample input/output
2. implement a small function or data type
3. combine functions into a working program
4. separate responsibilities into files and classes
5. add tests and handle invalid input
6. document, demonstrate, and submit the project

The full project specification and rubric should live in an appendix, while
relevant labs or project assignment pages link to only the deliverable needed
at that point. This keeps the book complete for instruction while giving
students a manageable next step and giving VS Code projects a clear purpose
throughout the semester.

## Database Capstone and AI Scope (2026-10-15)

The database appendix is an optional business application capstone after OOP (Chapters 10-12), suitable for about one to two selected weeks or a project persistence milestone. It covers relational tables/keys, basic queries and joins, parameterized changes, constraints, and persistent SQLite state; the sales transaction remains a connected extension. Administration, ORM frameworks, migrations, and advanced SQL tuning are outside scope. Core business exercises can use synthetic data, collections, and files without databases.

AI literacy is part of the existing chapters, not a separate numbered chapter. Chapter 1 introduces generative AI, LLMs, prompts, limitations, privacy, attribution, and verification. Selected activities in Chapters 5, 6, and 9 ask students to review a prepared candidate, derive counterexamples, and verify a revision. Live assistants are optional and governed by course policy. Core tasks must remain usable without a paid AI account. Instructors retain independent tracing, explanation, modification, and testing as learning evidence.

Building an AI-powered application is a separate optional post-OOP project extension at `chapters/appendices/project/ai_extension.ipynb`, ID `cscs-ai-project-extension`. One narrow feature uses an isolated response-producing component, recorded synthetic responses, response validation, tests, and human review. The core application and grading demonstration remain runnable offline. A live provider is optional; this book pass adds no API client, credentials, model training, fine-tuning, or agent framework.

## Control Flow Before Method Definitions (2026-10-16)

Part I now runs Computing (1), Variables/Data/Operators (2), Decisions (3), Iteration (4), Methods (5), and Testing/Debugging/Error Handling (6). Chapter 2 still teaches calling built-in methods and reading their return values. Chapters 3-4 use top-level statements; they do not require students to define methods, classes, parameters, or return statements. Chapter 5 uses familiar decisions and loops to motivate decomposition and repeatable method tests.

Minimal string prerequisites are taught where needed: Chapter 2 introduces strings and library calls; Chapter 3 explains case-sensitive string equality; Chapter 4 introduces Length, zero-based character indexing, and foreach over a string. General cleaning, searching, extraction, immutability, and chaining remain in Section 5.4. Validation-loop labs use exact lowercase y/n responses and explain TryParse/out locally. No early required task depends on later string-processing tools.

The optional function-based Grade Calculation 2 assignment now belongs to Chapter 5. The first Grade Calculation stays with Iteration and explicitly permits top-level code. Existing assessment/cell IDs are independent of displayed numbering. Published old chapter/assignment URLs redirect directly to their new locations.

## Reading Boundaries (2026-10-17)

The 26-chapter sequence is unchanged. Section reorganization implements the
chapter MATERIALS/ORGANIZATION review: combine related fragments, separate
distinct substantial learning sequences, and retain supporting readings.
Reading-page counts are independent of teaching-meeting counts. Full original
explanations and exercise variants remain, with new worked reasoning and
guided development in thin lessons. Current paths/order are in `_toc.yml`;
preservation, online comparisons and verification are in
`authoring/section_revision/`. Setup and Git remain in the appendices.
