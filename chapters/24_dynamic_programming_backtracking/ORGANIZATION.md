---
orphan: true
---

# Chapter Organization — Dynamic Programming

## Teaching Plan — 110 Minutes

1. Memoization and tabulation (40 minutes): define states and base cases, measure the same recursive problem, prove cache/table invariants, compare rolling storage, derive minimum coins, and reconstruct optimal plans.
2. Backtracking and search spaces (40 minutes): prove include/exclude coverage, preserve undo/snapshot invariants, reconstruct one-use signed witnesses, justify suffix pruning and cache keys, and account for exponential/factorial output.
3. Optimization verification (30 minutes): connect purchasing quantities to inventory constraints, validate objective values and witnesses with independent small references, exercise boundaries, and justify a method from state range and requested output.

## Assignment Progression

Preview establishes state and contract vocabulary. The lab follows one planning workflow through repeated-work measurement, retained-state choices, reusable pack optimization, signed invoice reconciliation, and a measured pruned/memoized infeasibility check. Homework transfers the recurrence to stairs with different bases, tests other pack denominations and unreachable states, validates signed wide sums, distinguishes positional permutations from repeated labels, and separates unknown budget-limited results from solved instances.

## Coverage Boundary

Keep the chapter focused on modeling and correctness rather than a catalog of DP puzzles. Reusable coin amounts and one-use invoice positions deliberately require different states. Fibonacci is a counting recurrence, not an optimization claim. Signed subset search extends the familiar nonnegative rule only after proving safe bounds. Chapter 25 develops graph traversal, string search, and computational limits. Slides remain deferred to Press.
