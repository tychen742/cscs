---
orphan: true
---

# Chapter Materials — Dynamic Programming

## Sequence and Coverage

- `2400_dynamic_programming_backtracking.ipynb`: objectives, glossary, navigation, and deferred slides.
- `2401_memoization_tabulation.ipynb`: complete states, Fibonacci call/cache counts and induction, dependency-order invariants, rolling storage, minimum-coin recurrence and optimal substructure, unreachable markers, predecessor reconstruction, and pseudo-polynomial costs.
- `2402_backtracking.ipynb`: include/exclude completeness, undo and snapshots, signed one-use subset witnesses, safe suffix bounds, failed-state memoization, resource limits, and positional permutations with duplicate labels.
- `2403_optimization_lab.ipynb`: purchasing quantities versus one-use invoices; independent amount-level and exhaustive-position references; validated witnesses; boundary contracts and evidence-based method selection.
- Assignments: ten-question preview; five connected purchasing/reconciliation lab tasks; five applied true/false and five transfer coding homework tasks. Coding starters and hidden solutions are independent; solutions retain verified stdout.
- `demos/24/PlanningChecks.cs` and README: complete implementations with independent executable reference checks.

## Contracts and Scope

Fibonacci accepts 0..92 and uses checked long arithmetic; naive recursion is capped at 25. Minimum coins accepts unlimited positive denominations (duplicates normalized), targets 0..1,000,000, and null count for unreachable targets. Zero uses an empty valid witness. One-use subset search preserves distinct positions, supports signed int values and long targets, and returns null only for proven infeasibility. It accepts up to 128 positions and an explicit call budget, default one million; exhausting it throws with feasibility unknown. Bounds sum suffix negatives and positives. Enumeration snapshots position arrays; materialized subsets are capped at 16 positions and permutations at eight. Empty input has one empty subset and one empty permutation.

The chapter follows recursion/analysis and greedy counterexamples. Amount-level exploration is used only as a small reference here; systematic BFS/DFS and broader algorithm limits belong to Chapter 25. Slides remain a deferred Press task: student HTML/PDF and instructor-only PPTX.

## Verification — 2026-10-05

All 26 completed notebook cells compiled and ran independently; 13 hidden answers retain verified stdout. All 30 implementation copies match the downloadable verified classes. Reference checks passed 600 coin instances, 600 signed subset instances (each compared with three search variants), all 93 supported Fibonacci values, positional enumeration cardinality/uniqueness, snapshot independence, and boundary/input/resource guards. The full-book HTML build passed with five existing warnings outside Chapter 24. Six browser Runs passed: naive/memo counts, zero and upper Fibonacci boundary, minimum-coin reconstruction/unreachable quantity, signed wide-sum search with an honest budget limit, duplicate-label positional permutations, and the final lab comparison. The last instance measured 8,191 raw calls, 3,431 with safe bounds, and 85 with memoization; these are instance-specific measurements.
