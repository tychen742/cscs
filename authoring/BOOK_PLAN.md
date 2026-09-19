# Book Plan — CSCS in C\#

## Title and Publication

- **Title**: Introduction to Computer Science in C\#
- **Format**: Jupyter Book (open access, online)
- **Inspired by**: introcs.cs.luc.edu — aims to be a better-structured open alternative
- **Scope note**: despite the working title, this book is not only an
	introductory programming text. It spans a two-semester sequence from first
	programming concepts through data structures and algorithmic problem solving.

## Audience

- College students in a two-semester CS/programming sequence
- No prior programming experience assumed at the start of Semester 1
- Semester 1 supports beginning programmers; Semester 2 supports students who
	have completed the programming and information-systems foundation
- Focus: CS and IT concepts, data structures, algorithms, and programming
	practice, not just syntax

## Goals

- Teach C# programming through a CS and IT conceptual lens
- Cover programming mechanics, information-systems practice, data structures,
	and algorithmic problem solving
- Each chapter is one week's named student-facing unit. Each chapter contains
	several notebooks or sections, including explanation, examples, practice,
	and assignments.
- Labs build toward a semester-long project students can demonstrate on GitHub

## Scope

Five parts:

| Part | Topic | Chapters |
| ---- | ----- | -------- |
| I | Fundamentals | 01 Context, 02 Variables & Types, 03 Methods, 04 Decision, 05 Iteration, 06 Exceptions & Testing |
| II | Data and I/O | 07 Arrays, 08 Data Collections, 09 Files & Text |
| III | Object-Oriented Information Systems | 10 Classes, 11 OOP Principles, 12 Databases |
| IV | Data Structures | 13 ADTs, 14 Linear Lists, 15 Stacks & Queues, 16 Trees, 17 Hashing & Heaps, 18 Graphs |
| V | Algorithms | 19 Analysis, 20 Recursion, 21 Search & Sort, 22 Greedy Algorithms, 23 Dynamic Programming, 24 Advanced Algorithms |

Appendix covers resources, command line, and index.

## Chapter Sequence

See `_toc.yml` for the authoritative notebook order.

## Two-Semester Course Design

This book now contains two semesters of material. The intended split is:

- **Semester 1: Programming and Information Systems Foundations** — Chapters
	1-12.
- **Semester 2: Data Structures and Algorithms Foundations** — Chapters 13-24.

The book should remain usable as a single open text, but each semester needs a
clear instructional arc, assessment plan, and project rhythm. Instructors may
assign only the relevant semester in a given course.

### Semester 1: Programming and Information Systems Foundations

Semester 1 introduces programming in C# and ends with persistent
information-system data. Its required sequence is:

1. computing context, development tools, and program structure (Chapter 1)
2. variables, types, expressions, and console input/output (Chapter 2)
3. methods, parameters, and decomposition (Chapter 3)
4. decisions and iteration (Chapters 4-5)
5. exceptions, debugging, and testing (Chapter 6)
6. arrays and collections (Chapters 7-8)
7. files, text processing, and regular expressions (Chapter 9)
8. classes, properties, instances, and object-oriented principles
	 (Chapters 10-11)
9. database concepts, SQL, and persistent information-system data (Chapter 12)

The semester should include a project that grows from single-file programs into
a small multi-class information-system application. The final weeks should
include integration, testing, documentation, demonstration, and a small C#
database workflow.

### Semester 2: Data Structures and Algorithms Foundations

Semester 2 assumes the programming and information-systems foundation from
Semester 1. It introduces abstract data types, implementation choices,
operation costs, and algorithm design. Its required sequence is:

1. abstract data types, interfaces, generics, references, and memory
	 (Chapter 13)
2. linear structures: arrays, dynamic arrays, linked lists, stacks, queues, and
	 deques (Chapters 14-15)
3. trees, heaps, hash tables, and graph representations (Chapters 16-18)
4. algorithm analysis, recursion, searching, and sorting (Chapters 19-21)
5. greedy algorithms, dynamic programming, backtracking, and advanced graph or
	 string algorithms (Chapters 22-24)

Semester 2 should have its own project arc. It should emphasize choosing
representations, explaining tradeoffs, implementing reusable data structures,
testing invariants, and applying algorithms to realistic data problems.

### Proposed 24-Chapter Layout

The book should use a simple one-chapter-per-week structure. The first twelve
chapters cover the applied programming and information-systems foundation. The
next twelve chapters cover the data structures and algorithms foundation for
the second semester.

#### Part I: Fundamentals

1. Computing context, development tools, and program structure
2. Variables, data types, expressions, and console input/output
3. Methods, parameters, and program decomposition
4. Decisions and conditional logic
5. Iteration and repetition
6. Exceptions, debugging, and testing

#### Part II: Data and I/O

7. Arrays and multidimensional data
8. Data Collections: lists, dictionaries, and sets
9. Files, streams, and text processing

#### Part III: Object-Oriented Information Systems

10. Classes, fields, properties, and object construction
11. Object-oriented principles: encapsulation, inheritance, polymorphism, and
	interfaces
12. Databases, SQL, and persistent information-system data

Chapters 1-12 form the complete first-semester programming and
information-systems foundation. Chapter 6 appears before classes so students
practice failure handling, debugging, and tests before larger object-oriented
projects. Memory, references, and program state should be introduced where
they support Chapters 7-11 rather than treated as an isolated advanced
chapter.

#### Part IV: Data Structures

13. ADTs: abstract data types, interfaces, generics, references, and memory
14. Linear lists: arrays, dynamic arrays, and linked lists
15. Stacks & queues: LIFO, FIFO, deque operations, and implementations
16. Trees: hierarchy, traversal, and binary search trees
17. Hashing & heaps: priority queues, heaps, hash tables, sets, and dictionaries
18. Graphs: vertices, edges, adjacency, and graph representations

#### Part V: Algorithms

19. Analysis: correctness, asymptotic notation, space growth, and recurrences
20. Recursion: recursive methods, call-stack reasoning, and divide-and-conquer
21. Search & sort: searching, sorting, preconditions, and comparison costs
22. Greedy algorithms: greedy choice, correctness, MSTs, and shortest paths
23. Dynamic programming: memoization, tabulation, backtracking, and pruning
24. Advanced algorithms: graph traversal, string matching, and computational limits

The chapter number is the weekly organizing unit; it does not limit the
number of notebooks inside a chapter. Each chapter should normally include a
landing notebook, two or three content notebooks, and an assignments area with
Preview, Lab, and Homework work.

### Semester 2 Depth: Data Structures and Algorithms

Data Structures and Algorithms form the second-semester arc. Chapters 13-24
are organized as two focused six-chapter sequences: data structures first,
then algorithms.

The detailed chapter organization is listed in Parts IV and V above. Existing
chapter filenames and stable assignment IDs should be preserved during the
transition; renumber files only when the final publication structure requires
it.

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

## Interactive C# and REPL Teaching

The book should use a two-stage learning model. In the first stage, students
use `csharprepl` and the terminal for short, immediate experiments. This keeps
setup friction low for business students who may not yet understand projects,
compilation, or IDE workflows, while giving them a concrete experience of
running code and reading compiler feedback.

In the second stage, students move into VS Code and standalone C# source code.
The transition should be gradual and purposeful: students need to learn
declarations, methods, classes, `Main`, compilation, and how program state
differs between one execution and another. The goal is not to make every
student an expert in build tooling in one pass, but to ensure that the tools
become understandable as the course progresses.

The local `csharprepl` and terminal experience is part of the instruction and
should not be replaced by the browser execution service. The browser runner is
an additional access path for demonstrations, review, and students who need a
low-friction way to try code online. It should support both REPL-like snippets
and standalone C# examples without making either workflow mandatory too early.

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
or REPL-only syntax. Any REPL-specific expression should have a standalone C#
equivalent before it becomes a required example.

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

The browser draft and VS Code project should not be treated as one live shared
filesystem. Instead, they share the same assignment ID, starter version,
learning objectives, and tests. The book should provide an explicit handoff:
students can download their current browser code as a `.cs` file or starter
project, then continue in VS Code. Conversely, a later browser upload/import
feature may accept a `.cs` file for experimentation, but it should not replace
GitHub as the source of submitted project history.

Persistence requirements:

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
- **Run C#**: execute the current C# cell through the execution service
- **Preview**: inspect the rendered page before publishing

The notebook file remains the source of truth. Git remains the synchronization,
versioning, review, and rollback system. Publishing rebuilds the Jupyter Book
from the saved notebook files; the browser editor does not create a second
content format or require an immediate migration to a database-backed CMS.

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
