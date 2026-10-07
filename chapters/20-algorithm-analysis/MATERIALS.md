---
orphan: true
---

# Chapter Materials: Analysis

## Sequence and Coverage

- `2001-big-o.ipynb`: Cost models, exact sequential/rectangular/triangular counts, halving and multiple inputs, O/Ω/Θ inequalities, input-dependent and amortized costs, auxiliary space, and responsible measurement.
- `2002-correctness.ipynb`: Precise result and failure contracts, processed-prefix invariants, initialization/maintenance/exit arguments, decreasing variants, early returns, boundary tests, and counterexamples.
- `2003-recurrences.ipynb`: Base cases, integer rounding, linear and halving chains, balanced level sums, total calls versus active frames, auxiliary buffers, and overlapping subproblems.
- Preview: Ten multiple-choice questions.
- Lab: Five connected expense-report analysis tasks, including exact counts, contracts, search exits, and balanced review costs.
- Homework: Five applied true/false questions and five independent coding tasks.

## Verification and Scope

All 29 completed code cells and hidden answers compile/run independently, with saved answer stdout. The reference program in `../../materials/20/AnalysisChecks.cs` passed 600 count/contract cases and 128 recurrence cases plus boundaries. The full-book build passed with five pre-existing warnings outside this chapter. Six representative examples/answers passed browser Run, including exact counts, bound inequalities, branching work, Fibonacci calls, wide sums, and the final lab task.

Recursive programming is developed in Chapter 21, searching/sorting in Chapter 22, and memoization in Chapter 24. Slides remain deferred to Press: student HTML/PDF and instructor-only PPTX. Keep legacy exercise tags until coordinated UI migration.

## Foundation Placement (2026-10-07)

Chapter 14 supplies basic notation and counts. This optional chapter develops formal bounds, exact counts, richer case models, correctness, and recurrences.
