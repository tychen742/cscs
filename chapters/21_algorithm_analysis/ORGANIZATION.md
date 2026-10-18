---
orphan: true
---

# Chapter Organization: Analysis

## Class Meetings

1. **Cost models and growth, 40 minutes.** Choose input sizes and counted operations; derive sequential, dependent-loop, and halving counts; establish tight bounds with inequalities; distinguish worst/expected/amortized claims and auxiliary storage.
2. **Contracts and correctness, 35 minutes.** Specify maximum and first-match results, trace processed prefixes, argue initialization/maintenance/exit, establish termination with variants, and challenge implementations with boundaries and counterexamples.
3. **Recursive costs, 35 minutes.** Expand base-case recurrences, count reductions and frames consistently, sum balanced levels, preserve odd-size inputs, and contrast branching call totals with active depth and other storage.

The lecture plan totals 110 minutes including predictions, hand traces, discussion, and code inspection.

## Assignment Roles

Preview checks distinctions students will use in class. The connected expense-report lab progresses from totals to pair comparisons, maximum contracts, early-exit search, and balanced report review. Homework transfers dependent counts, multiple input sizes, safe sums, search counterexamples, and integer halving.

## Boundaries

Teach analysis tools rather than full algorithm implementations. Keep recurrence assumptions explicit and distinguish a counter program's runtime from the work it models. Defer slides and tag migration to Press.

## Foundation Placement (2026-10-07)

Chapter 13 supplies basic notation and counts. This optional chapter develops formal bounds, exact counts, richer case models, correctness, and recurrences.

## Section-Boundary Review (2026-10-17)

**Status: implemented.** The following records the reviewed recommendation and its baseline. See Implemented Reading Organization below for the final current filenames and order; earlier meeting allocations are historical where they conflict.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `2101_big_o.ipynb`: Big-O and Complexity | Core content | 672 | 24 | 8 |
| `2102_correctness.ipynb`: Correctness and Invariants | Core content | 515 | 21 | 7 |
| `2103_recurrences.ipynb`: Recurrences and Recursive Cost | Core content | 614 | 21 | 7 |

**Recommendation:** Retain three distinct analysis tools.

Growth analysis, proof of behavior and recursive cost modeling answer different questions. The 515-672-word pages are compressed treatments of substantial topics; merging them would not resolve missing explanation.

### Proposed Reading Sequence

1. Cost models and asymptotic bounds.
2. Correctness, invariants, and termination.
3. Recurrences, total work, and active storage.

### Adequacy Before Reorganization

Add derivations and interpreted diagrams between formulas and code. Current runnable checks and historical verification notes do not demonstrate adequate proof instruction.

Reading sections and class meetings are different units; allocate discussion and practice after developing adequate explanations. Do not reduce distinct material to meet a section or word quota.

Preserve every existing explanation, exercise variation and assessment identity. The source-to-destination dispositions in MATERIALS.md govern any later move. Update TOC, links and redirects only in an authorized implementation pass.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `2101_big_o.ipynb`: Big-O and Complexity.
- `2102_correctness.ipynb`: Correctness and Invariants.
- `2103_recurrences.ipynb`: Recurrences and Recursive Cost.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.

## Mistakes and Interpretation Pass (2026-10-18)

Pass 5 of the content-development audit (`authoring/content_development_audit/`), all three pages: 16 mistakes beside the examples (mixed cost models, multiplying dependent bounds, merging independent sizes, reading O as Theta, reporting the best case, counting stack depth as memory, weak specifications, closed-range invariants, invariant without variant, early return without its own argument, best initialized to zero, missing base case, fractional halving, dropped combine work, odd splits, call count as stack depth) and interpretation after the exercise solutions. Every demonstration cell on these pages was rerun and the interpretations quote the actual output. No code cell, heading, cell ID, or exercise ID changed.
