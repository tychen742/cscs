---
orphan: true
---

# Chapter Organization — Greedy Algorithms

## Teaching Plan — 110 Minutes

1. Greedy choice and correctness (35 minutes): specify objective and feasibility, trace interval scheduling, exchange the first choice, and disprove inappropriate greedy rules with feasible alternatives.
2. Spanning forests and shortest paths (45 minutes): distinguish global connection cost from route distance; trace union-find and the cut argument; prove settling under nonnegative weights; inspect stale queue entries and reconstruct paths safely.
3. Optimization verification (30 minutes): compare tiny instances with independent references, check forest and path invariants, exercise empty/disconnected/zero/negative/wide-cost boundaries, and choose a model from units and constraints.

## Assignment Progression

Preview establishes objectives and algorithm assumptions. The five-task lab follows one facilities-planning scenario: schedule meetings, change their value objective, connect buildings, route deliveries, and add a zero-cost directed route without changing the cable network. Homework transfers these ideas to touching intervals, parallel and negative cable edges, stale priorities with zero cycles, wide distances and invalid inputs, and a triangle where minimum network cost differs from shortest route cost.

## Coverage Boundary

Keep representations in Chapter 19 and priority-queue mechanics in Chapter 18. This chapter explains why particular greedy choices are safe and how complete implementations honor their contracts. Weighted scheduling and noncanonical coin systems motivate Chapter 24. Chapter 25 extends traversal and algorithm limits. Slides are a deferred Press task.
