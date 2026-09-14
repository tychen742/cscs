# C# execution requirements

The book needs three kinds of runnable code cells.

## 1. Sample execution

Published sample cells must run in the browser and return compiler errors,
program output, and timeout information. The browser sends code to the task
execution API, which compiles and runs it in the Dockerized .NET SDK.
Cells that use `Console.ReadLine()` need browser-provided standard input. The
client sends optional `stdin` text with one input value per line; the execution
API pipes that text into the child process before waiting for output.

The book intentionally uses both complete C# programs and partial teaching
snippets. A complete program should include its own `using` directives, type
declaration, and correctly cased `Main` entry point when it is meant to model a
full source file. A teaching snippet may show loose method members so the
lesson can focus on method design, parameters, or tracing. The runner may wrap
loose method members in a temporary class so they compile, but it must not
silently translate `main` to `Main`; incorrect entry-point casing should remain
visible in the source so examples can be fixed intentionally.

Status: implemented and tested locally.

## 2. Sample editing and execution

Teachers and students must be able to edit a sample cell, run the edited code,
and see the new output without changing the published notebook source.

The browser client should provide an Edit control, preserve the original code
for Reset, and send the current editor contents to the execution API.

Status: browser implementation in progress.

## 3. Logged-in exercise persistence

A logged-in learner must be able to edit an exercise cell and return later to
find the edit still present. Persistence must be associated with:

- authenticated user ID
- book/chapter/page ID
- exercise/cell ID
- current source code
- updated timestamp

This requires an authentication provider, a durable database, and versioned
save/load API endpoints. Browser `localStorage` is not sufficient because it
is not tied to an account and cannot synchronize across devices.

Status: initial local authentication and SQLite persistence implemented; exercise
drafts and assignment management remain next.

Authentication implementation status:

- registration and login are working locally
- PBKDF2 password hashing is implemented
- cookie sessions and `/v1/auth/me` are working
- logout is implemented
- administrator access is controlled by `CSCS_ADMIN_EMAILS`
- email verification and password recovery are not yet implemented

## Later persistence roadmap

The future application database should support three related domains:

### Users

- authenticated user identity
- student, instructor, and administrator roles
- course or class membership
- account and sign-in metadata

### Exercises

- stable exercise ID
- user-specific draft source
- published starter version
- updated timestamp and revision history
- optional feedback or completion state

### Assignments

- stable assignment ID and assignment type
- chapter and course association
- published prompt and starter version
- due date and availability metadata
- submission references and status

Published book content remains versioned in Git. The database stores user data,
drafts, assignment state, and submission references; it does not become the
source of truth for the book's instructional content.

## Admin authoring mode

An authenticated administrator should be able to enable author mode on a book
page, edit markdown and C# cells inline, run C# cells, and save the edited cell
strings back to the original `.ipynb` file. Preview and publish should use the
normal Git-backed Jupyter Book build workflow.

Git remains the canonical synchronization and version-history mechanism. A
database may provide authentication, roles, draft recovery, edit locks, and
audit logs, but it does not replace notebook files as the content source of
truth.

Current admin-authoring backend status:

- notebook JSON validator implemented
- authenticated admin save endpoint implemented
- chapter notebook path restriction implemented
- timestamped backup before replacement implemented
- atomic file write implemented
- browser Author mode, Git automation, and rollback endpoint remain next

## Acceptance checks

- A sample cell runs without editing.
- Editing a sample cell changes the submitted source and output.
- Reset restores the published sample.
- An exercise edit is saved only for an authenticated user.
- An unauthenticated exercise edit is not presented as permanently saved.
- Saved exercise code is restored on another browser or device after login.
