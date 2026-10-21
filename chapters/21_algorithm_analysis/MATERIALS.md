---
orphan: true
---

# Chapter Materials: Analysis

## Aligned Lecture Deck (2026-10-21)

One chapter source at `_html_extra/chapters/21_algorithm_analysis/2100_slides.md` contains 46 slides, with one complete part per current core reading. Chapter-title speaker notes list part starts and the existing 110-minute meeting allocation; reading parts do not add meetings. Every slide has instructor notes, with check/practice answers confined to notes. Existing chapter order, assessments, and their identities are unchanged. Student HTML and instructor-only editable PowerPoint are generated centrally; complete standalone C# examples are verified from `authoring/slide_revision/code_18_26.json`.

## Assignment Alignment Revision (2026-10-21)

Preview retains the ten numbered question slots and original cells, adds native radio response controls and specific answer explanations, varies option display order while keeping canonical a-d values, and replaces calculation/tracing preparation with glossary recognition where needed. Homework True/False questions now have native controls, hidden explanatory answers, and visible course-submission guidance. Chapters24-25 include balanced applied cases. Static page choices do not claim to record course attempts; authenticated submission remains the existing course workflow.

## Sequence and Coverage

- `2101_big_o.ipynb`: Cost models, exact sequential/rectangular/triangular counts, halving and multiple inputs, O/Ω/Θ inequalities, input-dependent and amortized costs, auxiliary space, and responsible measurement.
- `2102_correctness.ipynb`: Precise result and failure contracts, processed-prefix invariants, initialization/maintenance/exit arguments, decreasing variants, early returns, boundary tests, and counterexamples.
- `2103_recurrences.ipynb`: Base cases, integer rounding, linear and halving chains, balanced level sums, total calls versus active frames, auxiliary buffers, and overlapping subproblems.
- Preview: Ten multiple-choice questions.
- Lab: Five connected expense-report analysis tasks, including exact counts, contracts, search exits, and balanced review costs.
- Homework: Five applied true/false questions and five independent coding tasks.

## Verification and Scope

All 29 completed code cells and hidden answers compile/run independently, with saved answer stdout. The reference program in `../../demos/21_algorithm_analysis/AnalysisChecks.cs` passed 600 count/contract cases and 128 recurrence cases plus boundaries. The full-book build passed with five pre-existing warnings outside this chapter. Six representative examples/answers passed browser Run, including exact counts, bound inequalities, branching work, Fibonacci calls, wide sums, and the final lab task.

Recursive programming is developed in Chapter 22, searching/sorting in Chapter 23, and memoization in Chapter 25. Slides remain deferred to Press: student HTML/PDF and instructor-only PPTX. Keep legacy exercise tags until coordinated UI migration.

## Foundation Placement (2026-10-07)

Chapter 13 supplies basic notation and counts. This optional chapter develops formal bounds, exact counts, richer case models, correctness, and recurrences.

## Section-Boundary Coverage Disposition (2026-10-17)

**Reviewed plan, now implemented:** Retain three distinct analysis tools. The disposition below records the preimplementation baseline and rationale. See Implemented Reading Organization for the current reading files. Counts in this baseline exclude fenced code from prose; the refreshed inventory is in authoring/content_size/. They flag review needs, not quality scores.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `2101_big_o.ipynb`: Big-O and Complexity | Core content | 672 | 24 | 8 |
| `2102_correctness.ipynb`: Correctness and Invariants | Core content | 515 | 21 | 7 |
| `2103_recurrences.ipynb`: Recurrences and Recursive Cost | Core content | 614 | 21 | 7 |

### Source-to-Destination Plan

| Existing source | Proposed treatment and coverage to preserve |
| --- | --- |
| `2101` | Retain exact-count to bound reasoning, with multiple input shapes and clear units. |
| `2102` | Retain a dedicated correctness lesson; develop initialization/maintenance/exit and termination step by step. |
| `2103` | Retain recurrences; connect unfolding, level sums and stack/storage to already taught recursion rather than reintroducing its syntax. |

### Development Needed Before Moving Material

Add derivations and interpreted diagrams between formulas and code. Current runnable checks and historical verification notes do not demonstrate adequate proof instruction.

Before a later move, create a cell-level preservation map for these sources, including citations, figures, original code forms, worked traces, guided questions and independent exercise variants. Relocate prerequisite explanations from assignments into content when needed while retaining application requirements and IDs. A consolidated page must still teach its concepts; a split must not create two unsupported outlines. Existing runnable verification records describe earlier work, not verification of this proposal.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `2101_big_o.ipynb`: Big-O and Complexity.
- `2102_correctness.ipynb`: Correctness and Invariants.
- `2103_recurrences.ipynb`: Recurrences and Recursive Cost.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.

## Mistakes and Interpretation Pass (2026-10-18)

Pass 5 of the content-development audit (`authoring/content_development_audit/`), all three pages: 16 mistakes beside the examples (mixed cost models, multiplying dependent bounds, merging independent sizes, reading O as Theta, reporting the best case, counting stack depth as memory, weak specifications, closed-range invariants, invariant without variant, early return without its own argument, best initialized to zero, missing base case, fractional halving, dropped combine work, odd splits, call count as stack depth) and interpretation after the exercise solutions. Every demonstration cell on these pages was rerun and the interpretations quote the actual output. No code cell, heading, cell ID, or exercise ID changed.

## OpenDSA References (2026-10-19)

Re-hosted the existing OpenDSA "Further reading" footnote links to `opendsa-server.cs.vt.edu` CS2/CS3 pages, because `opendsa.org`, `opendsa.cs.vt.edu`, and `opendsax.cs.vt.edu` either fail strict fetches or are not the host this book links to. The roles of the OpenDSA books are recorded in `authoring/toc_comparison/README.md` (OpenDSA mapping) and Appendix A. Chapter 21: the three footnotes now point to CS3 4.10 Common Misunderstandings.

## OpenDSA Gap List and Development (2026-10-19)

Pass 8 (`authoring/content_development_audit/pass8_cs2_opendsa_development.md`) compared the three sections with OpenDSA CS3 3.5 Summations, 3.6 Recurrence Relations, 3.7 Proof Techniques, 4.2 Problems, Algorithms, and Programs, 4.3 Growth Rates, 4.5 Faster Computer or Faster Algorithm, 4.6 Asymptotic Analysis (simplifying rules), 4.9 Analyzing Problems, 4.10 Common Misunderstandings, and 4.14 Summary Exercises. Gaps found and where they are now developed:

| Gap | OpenDSA treatment | Where it is now developed |
| --- | --- | --- |
| Simplifying rules; upper bound versus worst case confusion | 4.6.1.2, 4.10 | 21.1 Simplifying Rules for Growth Classes (new) |
| Faster computer versus faster algorithm; problem-size gain table | 4.5 | 21.1 A Faster Computer or a Faster Algorithm? (new, computed) |
| Growth-rate ordering; loop-body counting practice | 4.3.2, 4.8 | 21.1 Growth-Rate Ordering; Code Tracing: Count the Loop Bodies |
| Lower bounds on problems versus algorithms | 4.9 | 21.1 Check Your Understanding |
| Direct proof, contradiction, induction; invariants as induction | 3.7 | 21.2 Three Proof Shapes (new) |
| Executable invariant checks; invariant table practice | 3.7 exercises | 21.2 Code Completion: Assert the Invariant; Code Tracing: Fill the Invariant Table |
| Closed forms of common summations | 3.5 | 21.3 Summations You Will Meet (new, verified) |
| Solving recurrences by expansion, then induction | 3.6 | 21.3 Solve a Recurrence by Expanding (new) |
| Recurrence classification; call-count tracing | 3.9, 4.14 | 21.3 Concept Check; Code Tracing: How Many Calls? |

Exercises added: code tracing (21.1, 21.2, 21.3), code completion (21.2), growth-rate ordering (21.1), concept recall (21.3), and Check Your Understanding on every page. Every new cell compiled and ran under .NET 10 with stored output; no existing cell, heading, exercise ID, or footnote was removed; no OpenDSA text, code, or figure was copied.
