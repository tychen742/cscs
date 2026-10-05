---
orphan: true
---

# Chapter Organization: Linear Lists

## Learning Objectives

Implement the same sequence contract with array-backed and singly linked representations; trace changing storage/references; preserve representation invariants; derive amortized append cost; test boundary behavior; justify a representation using a workload and API assumptions.

## Instructional Sequence

1. Dynamic arrays: service-desk motivation, count/capacity, growth, shift traces, generic implementation, and aggregate copy analysis.
2. Linked nodes: cursor versus head, correct insertion ordering, lost links and cycles, head/tail cases, generic wrapper, and doubly linked contrast.
3. Comparison: separate locating from updating; compare identical operations; count concrete workloads; test the shared contract; qualify decisions with locality and memory.

## Pedagogical Pattern

Each added major subsection includes concrete explanation or trace and a basic, applied, or challenge prompt. Complete examples are standalone; assignment starters intentionally require student completion. Students predict results before execution, then test and justify them. No recursion is required. Cost notation is explained through counts before the formal analysis chapter.

## Assignments and Verification

Preview checks terms. Lab uses five connected work-order tasks with independently runnable starters, removal and endpoint traces, shared contract tests, and workload counts. Homework contains five coding tasks and a design challenge; students implement growth accounting and remove a chain through singleton and empty cases. The local material checks both implementations against the same contract and a standard List reference model; invalid operations must preserve state. Planning, landing glossary/objectives, and Chapter Topics are synchronized. Lecture-slide synchronization remains pending; no new slide deck is claimed by this pass.
