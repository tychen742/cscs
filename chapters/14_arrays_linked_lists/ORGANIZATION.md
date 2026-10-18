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

## Historical Foundation Placement (2026-10-07, superseded)

The following records an earlier placement. Searching and sorting now belong to Chapter 16; do not use this historical allocation as the current teaching sequence.

Added `1601_searching.ipynb`: first-match linear search, iterative binary search, missing-target traces, library search results, stable reports, and a standalone report exercise. Detailed custom sorting, duplicate bounds, and workload analysis remain in Chapter 23.

### Revised Pacing

1. **Dynamic arrays, 30 minutes.**
2. **Linked nodes, 30 minutes.**
3. **Representation comparison, search, and library sorting, 50 minutes.** Use the new search/sort notebook for the final portion; detailed custom sorting stays optional.

Total: 110 minutes. Preparation and assignments supply additional practice.


## 2026-10-15 Scope

Searching and sorting now form Chapter 16, following stacks and queues. This chapter focuses on linear storage and its contracts.

## Section-Boundary Review (2026-10-17)

**Status: implemented.** The following records the reviewed recommendation and its baseline. See Implemented Reading Organization below for the final current filenames and order; earlier meeting allocations are historical where they conflict.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `1401_dynamic_arrays.ipynb`: Dynamic Arrays | Core content | 1,294 | 25 | 4 |
| `1402_linked_nodes.ipynb`: Linked Nodes | Core content | 1,122 | 27 | 5 |
| `1403_comparison_lab.ipynb`: Representation Comparison Lab | Core content | 1,102 | 22 | 3 |

**Recommendation:** Retain representation-to-comparison sequence.

The two implementation lessons and the comparison lesson have distinct outcomes. The comparison page contains instruction, so its Lab title should not cause explanations to be moved out of content.

### Proposed Reading Sequence

1. Dynamic arrays.
2. Linked representations.
3. Comparing representations under the same contract.

### Adequacy Before Reorganization

Preserve the workload comparison and all implementation variants; clarify navigation/lesson-versus-assignment roles. Remove stale planning claims that search remains in Chapter 14; the core search lesson is Chapter 16.

Reading sections and class meetings are different units; allocate discussion and practice after developing adequate explanations. Do not reduce distinct material to meet a section or word quota.

Preserve every existing explanation, exercise variation and assessment identity. The source-to-destination dispositions in MATERIALS.md govern any later move. Update TOC, links and redirects only in an authorized implementation pass.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `1401_dynamic_arrays.ipynb`: Dynamic Arrays.
- `1402_linked_nodes.ipynb`: Linked Nodes.
- `1403_comparison_lab.ipynb`: Representation Tradeoffs and Verification.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.
