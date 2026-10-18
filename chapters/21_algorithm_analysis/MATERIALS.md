---
orphan: true
---

# Chapter Materials: Analysis

## Sequence and Coverage

- `2101_big_o.ipynb`: Cost models, exact sequential/rectangular/triangular counts, halving and multiple inputs, O/Ω/Θ inequalities, input-dependent and amortized costs, auxiliary space, and responsible measurement.
- `2102_correctness.ipynb`: Precise result and failure contracts, processed-prefix invariants, initialization/maintenance/exit arguments, decreasing variants, early returns, boundary tests, and counterexamples.
- `2103_recurrences.ipynb`: Base cases, integer rounding, linear and halving chains, balanced level sums, total calls versus active frames, auxiliary buffers, and overlapping subproblems.
- Preview: Ten multiple-choice questions.
- Lab: Five connected expense-report analysis tasks, including exact counts, contracts, search exits, and balanced review costs.
- Homework: Five applied true/false questions and five independent coding tasks.

## Verification and Scope

All 29 completed code cells and hidden answers compile/run independently, with saved answer stdout. The reference program in `../../demos/21/AnalysisChecks.cs` passed 600 count/contract cases and 128 recurrence cases plus boundaries. The full-book build passed with five pre-existing warnings outside this chapter. Six representative examples/answers passed browser Run, including exact counts, bound inequalities, branching work, Fibonacci calls, wide sums, and the final lab task.

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
