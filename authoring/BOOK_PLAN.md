# Book Plan — CSCS in C\#

## Title and Publication

- **Title**: Introduction to Computer Science in C\#
- **Format**: Jupyter Book (open access, online)
- **Inspired by**: introcs.cs.luc.edu — aims to be a better-structured open alternative

## Audience

- College students in an introductory CS/programming course
- No prior programming experience assumed
- Focus: CS and IT concepts, not just syntax

## Goals

- Teach C# programming through a CS and IT conceptual lens
- Cover both programming mechanics and computer science ideas
- Each chapter = one week of student work and lecture (100–120 min of content)
- Labs build toward a semester-long project students can demonstrate on GitHub

## Scope

Five parts:

| Part | Topic | Chapters |
| ---- | ----- | -------- |
| I | Fundamentals | 01 Context & CS Ideas, 02 Variables & Types, 03 Methods, 04 Decision, 05 Iteration |
| II | Data and I/O | 06 Files & Text, 07 Arrays, 08 Collections |
| III | Object-Oriented | 11 Classes, 12 OOP Principles |
| IV | DSA | 09 Data Structures, 10 Algorithms |
| V | Advanced Topics | 13 Exceptions & Testing, 14 Selected Topics, 15 Modern C\# |

Appendix covers resources, command line, and index.

## Chapter Sequence

See `_toc.yml` for the authoritative notebook order.

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

This decision should be revisited when designing introductory chapters and
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
| Lab | Practice the week's technical skills | Five connected coding questions |
| Homework | Reinforce concepts and coding | Five true/false questions and five coding questions |
| Project | Apply concepts in a durable artifact | A cumulative VS Code project milestone or deliverable |

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
weekly labs link to only the deliverable needed at that point. This keeps the
book complete for instruction while giving students a manageable next step and
giving VS Code projects a clear purpose throughout the semester.
