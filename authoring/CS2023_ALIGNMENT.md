# CS2023 Alignment — Introduction to Computer Science in C\#

Draft, 2026-10-04; updated the same day for the new Chapter 7 (Society, Ethics,
and the Profession) and the renumbering of later chapters to 8–25. A condensed chapter table is published as an appendix (`chapters/appendices/cs2023-alignment.ipynb`, label `cs2023-alignment`; moved from the Preface on 2026-10-04); keep the two in sync. Maps the book's chapters to the knowledge units of
*Computer Science Curricula 2023* (CS2023). The audience is instructors and
departments that need to show how a course built on this book meets the
curriculum. A later version may become an instructor-facing appendix.

**Source.** Amruth N. Kumar, Rajendra K. Raj, et al. 2023. *Computer Science
Curricula 2023*. ACM Press, IEEE Computer Society Press, and AAAI Press. The
Joint Task Force on Computer Science Curricula (ACM, IEEE-CS, AAAI). DOI
[10.1145/3664191](https://doi.org/10.1145/3664191). Final Report, January 2024,
version 2024-04-28, <https://csed.acm.org/final-report/>. Unit codes and hours
below were checked against that report on 2026-10-04.

**How to read this draft.** The mapping was made from the section titles, the
chapter planning files, and spot checks of the notebooks. Confirm each row when
the chapter is next audited. Status values:

- **Covered** — the book teaches the unit's core topics.
- **Partial** — some core topics are taught; the gaps are named.
- **Gap** — CS Core topics the book does not teach yet.
- **Out of scope** — belongs to another course in a typical program (for
  example discrete mathematics or theory of computation).

## CS2023 Terms Used Here

- **Knowledge area (KA)** and **knowledge unit (KU):** CS2023 has 17 knowledge
  areas, each divided into units written as `KA-Unit`, for example
  `SDF-Fundamentals`.
- **CS Core:** topics every computer science graduate should know. **KA Core:**
  topics a program that covers the area in depth should include.
- **Introductory sequence:** CS2023 says the SDF and AL core topics "typically
  constitute the introductory course sequence," and its course-packaging
  examples begin with *CS I* and *CS II*. Semester 1 of this book (Chapters
  1–13) corresponds to CS I and Semester 2 (Chapters 14–25) to CS II, plus part
  of the separate Algorithms course.

## Summary by Knowledge Area

| KA | Unit | CS Core hrs | Book coverage | Status |
|---|---|---|---|---|
| SDF | SDF-Fundamentals — Fundamental Programming Concepts and Practices | 20 | Ch. 1–6, 10 | Covered |
| SDF | SDF-Data-Structures — Fundamental Data Structures | 6 + 6 (AL) | Ch. 3 (strings), 8–10, 14–16 | Covered |
| SDF | SDF-Algorithms — Algorithms | 3 + 3 (AL) | Ch. 5, 8, 20–22 | Covered |
| SDF | SDF-Practices — Software Development Practices | 5 | Ch. 1, 6; semester project | Covered |
| SDF | SDF-SEP — Society, Ethics, and the Profession | in SEP | Ch. 7 | Covered (first draft) |
| AL | AL-Foundational — Foundational Data Structures and Algorithms | 11 | Ch. 14–19, 22 | Covered |
| AL | AL-Strategies — Algorithmic Strategies | 6 | Ch. 21, 23, 24 | Covered |
| AL | AL-Complexity — Complexity | 6 | Ch. 18 lab, 20, 22 | Covered |
| AL | AL-Models — Computational Models and Formal Languages | 9 | Ch. 10 regular expressions (practical only); Ch. 25 limits | Partial; mostly out of scope |
| AL | AL-SEP | in SEP | Ch. 7 (sustainability, briefly) | Partial |
| FPL | FPL-OOP — Object-Oriented Programming | 4 + 1 (SDF) | Ch. 11–12, 14 | Covered |
| FPL | FPL-Types — Type Systems | 3 | Ch. 2, 6 (nullable), 14 (generics) | Covered |
| FPL | FPL-Functional — Functional Programming | 4 | lambdas and LINQ appear in passing (Ch. 6, 8, 9, 14); the dedicated notebooks are off the TOC | Gap |
| FPL | FPL-Event-Driven — Event-Driven and Reactive Programming | 2 | none (console programs only) | Gap |
| FPL | FPL-Parallel — Parallel and Distributed Computing | 2 + 1 (PDC) | async notebook is off the TOC | Gap |
| FPL | FPL-Scripting — Shell Scripting | 2 | Command Line appendix (commands, not scripts) | Partial |
| FPL | FPL-Translation — Language Translation and Execution | 2 | Ch. 1 (compile, build, run) | Partial |
| FPL | FPL-Systems — Systems Execution and Memory Model | 2 + 1 (AR, OS) | Ch. 9 (reference vs. value types), Ch. 15 (linked nodes) | Partial |
| SE | SE-Tools — Tools and Environments | 1 | Ch. 1 (VS Code, `dotnet`, Git), Command Line appendix | Covered |
| SE | SE-Construction — Software Construction | 1 + 3 (SDF) | Ch. 3, 6, 11–12 | Covered |
| SE | SE-Validation — Software Verification and Validation | 1 | Ch. 6 (unit testing, debugging), Ch. 7 (boundary tests) | Covered |
| SE | SE-Design — Software Design | 1 | Ch. 12 (encapsulation, abstraction), Ch. 14 (ADT contracts) | Covered |
| SE | SE-Teamwork — Teamwork | 2 + 3 (SEP) | Project appendix (if run as a group project) | Partial |
| SE | SE-Requirements — Product Requirements | 0 + 3 (SEP) | Ch. 7 (stakeholders) | Partial |
| DM | DM-Data — The Role of Data and the Data Life Cycle | 2 | Ch. 7 (data minimization, retention), 10, 13 | Covered |
| DM | DM-Core — Core Database System Concepts | 2 | Ch. 13 | Covered |
| DM | DM-Modeling — Data Modeling | 2 | Ch. 13 (relational model) | Covered |
| DM | DM-Relational — Relational Databases | 1 | Ch. 13 | Covered |
| DM | DM-Querying — Query Construction | 2 | Ch. 13 (SQL queries and changes) | Covered |
| DM | DM-Security — Data Security and Privacy | 1 | Ch. 7 (privacy, masking), Ch. 13 (parameterized commands) | Covered |
| SEC | SEC-Coding — Secure Coding | 2 + 6 (FPL, SDF, SE) | Ch. 6 and 7 (input validation, injection), Ch. 13 (parameterized commands) | Covered |
| SEC | SEC-Foundations — Foundational Security | 1 + 7 | Ch. 7 (confidentiality, integrity, availability; least privilege) | Partial |
| SEP | SEP-Context — Social Context | 3 | Ch. 7.1 | Covered (first draft) |
| SEP | SEP-Ethical-Analysis — Methods for Ethical Analysis | 2 | Ch. 7.1 (four-question checklist) | Covered (first draft) |
| SEP | SEP-Professional-Ethics — Professional Ethics | 2 | Ch. 7.1 (ACM Code), 7.3 (AI assistants) | Covered (first draft) |
| SEP | SEP-IP — Intellectual Property | 1 | Ch. 7.3 (copyright, licenses) | Covered (first draft) |
| SEP | SEP-Privacy — Privacy and Civil Liberties | 2 | Ch. 7.2 (GDPR, CCPA, FERPA; masking) | Covered (first draft) |
| SEP | SEP-Communication — Communication | 2 | Ch. 7.3 (error messages, honest status) | Partial |
| SEP | SEP-Sustainability — Sustainability | 1 | Ch. 7.3 (brief) | Partial |
| SEP | SEP-History — History | 1 | Ch. 7.1 (case studies only) | Partial |
| SEP | SEP-Economies — Economies of Computing | 0 | none | Not core |
| SEP | SEP-Security — Security Policies, Laws, and Computer Crimes | 2 | Ch. 7.2 (privacy laws, injection) | Partial |
| SEP | SEP-DEIA — Diversity, Equity, Inclusion and Accessibility | 2 | Ch. 7.3 (accessibility, internationalization) | Partial |
| PDC | PDC-Programs — Programs | 2 | async notebook is off the TOC | Gap |
| MSF | MSF-Discrete and others | 55 total | Ch. 19 (graph terms), Ch. 20 (recurrences) | Out of scope (math courses) |
| AR, OS, NC, SF, HCI, GIT, AI, SPD | | | | Out of scope for this sequence |

## Chapter Map

| Ch. | Title | Primary units | Also touches |
|---|---|---|---|
| 1 | Context | SDF-Fundamentals, SE-Tools | FPL-Translation, SDF-Practices |
| 2 | Variables and Types | SDF-Fundamentals, FPL-Types | SEC-Coding (input handling) |
| 3 | Methods and Strings | SDF-Fundamentals | SE-Construction, SDF-Data-Structures (strings) |
| 4 | Decisions | SDF-Fundamentals | |
| 5 | Iteration | SDF-Fundamentals, SDF-Algorithms | |
| 6 | Exceptions and Testing | SDF-Practices, SE-Validation | FPL-Types (nullable), SEC-Coding (validation) |
| 7 | Society, Ethics, and the Profession | SEP-Context, SEP-Ethical-Analysis, SEP-Professional-Ethics, SEP-Privacy | SEP-Security, SEP-IP, SEP-DEIA, SEC-Coding, DM-Security |
| 8 | Arrays | SDF-Data-Structures | SDF-Algorithms (linear search) |
| 9 | Data Collections | SDF-Data-Structures | AL-Foundational (maps), FPL-Systems (references) |
| 10 | Files and Text | SDF-Fundamentals (I/O), SDF-Data-Structures (strings) | AL-Models (regular expressions), DM-Data |
| 11 | Classes | FPL-OOP, SDF-Fundamentals | SE-Design |
| 12 | OOP Principles | FPL-OOP, SE-Design | SE-Construction |
| 13 | Databases | DM-Core, DM-Modeling, DM-Relational, DM-Querying | DM-Security, SEC-Coding (SQL injection) |
| 14 | Abstract Data Types | SDF-Data-Structures, AL-Foundational | FPL-Types (generics), FPL-OOP (iterators) |
| 15 | Arrays and Linked Lists | AL-Foundational | AL-Complexity, FPL-Systems |
| 16 | Stacks and Queues | AL-Foundational | |
| 17 | Trees | AL-Foundational | |
| 18 | Heaps and Hash Tables | AL-Foundational | AL-Complexity (performance lab) |
| 19 | Graphs | AL-Foundational | MSF-Discrete |
| 20 | Algorithm Analysis | AL-Complexity | SDF-Algorithms (correctness), MSF-Discrete (recurrences) |
| 21 | Recursion and Divide and Conquer | AL-Strategies, SDF-Algorithms | |
| 22 | Searching and Sorting | AL-Foundational, SDF-Algorithms | AL-Complexity |
| 23 | Greedy Algorithms | AL-Strategies, AL-Foundational | |
| 24 | Dynamic Programming and Backtracking | AL-Strategies | |
| 25 | Advanced Graphs, Strings, and Limits | AL-Foundational, AL-Complexity | AL-Models (limits of computation) |

## Gaps to Close

Ordered by how much CS Core time they carry and how naturally they fit.

1. **SEP beyond Chapter 7.** CS2023 puts an SEP unit inside most other
   knowledge areas and says ethics topics "should arise in the context of
   other computing courses, not just siloed in an 'SEP course.'" Chapter 7 is a
   first draft; short callbacks in later chapters would carry the thread:
   - Ch. 10: personal data in files, retention, and deletion (SEP-Privacy,
     DM-Data).
   - Ch. 13: customer-data privacy and least-privilege database access
     (SEP-Privacy, DM-Security); parameterized commands as the fix for the
     injection shown in Ch. 7 (SEP-Security, SEC-Coding).
   - Ch. 20 or 25: computational cost and energy use (SEP-Sustainability).
   - Semester 2 project: teamwork and communication (SE-Teamwork,
     SEP-Communication).
2. **Functional programming (FPL-Functional, 4 CS Core hours).** Lambdas and
   LINQ already appear in passing. `chapters/13-databases/1301-lambdas.ipynb`
   and `1302-linq.ipynb` are complete but off the TOC since Chapter 13 became
   Databases. Candidate homes: a section in Ch. 9 (querying collections) or
   Ch. 14.
3. **Parallel and asynchronous programs (FPL-Parallel, PDC-Programs, about
   4 CS Core hours together).** `1305-async.ipynb` is off the TOC. A short
   async section fits Ch. 10 (asynchronous file I/O) or a semester-2 chapter.
4. **Event-driven programming (FPL-Event-Driven, 2 CS Core hours).** Not
   covered; C# events and delegates could follow Ch. 12.
5. **Security foundations (SEC-Foundations).** Ch. 7 introduces
   confidentiality, integrity, availability, and least privilege; threat
   modeling (what can go wrong, and who might try) is not yet covered.
6. **Shell scripting (FPL-Scripting, 2 CS Core hours).** The Command Line
   appendix teaches commands; a short script example would complete it.

Formal languages and automata (AL-Models) and the mathematics units (MSF) are
usually taught in theory and mathematics courses. Note them as out of scope
rather than adding them.

## Open Questions

- Should the published map also appear on the ThinkPress catalog page for the
  book?
- Should hours per chapter be estimated, so departments can compare against the
  CS2023 CS Core totals?
