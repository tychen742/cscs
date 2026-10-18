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


## Outcome Gap Repair (2026-10-17)

Preserve the current chapter notebooks, reading order, existing explanations, exercise variants, and assessment identifiers. The additions below close the outcome audit gaps within that organization. Explanations belong in content before independent application; earlier scaffolded tasks remain available.

| Location | Development or assessment |
| --- | --- |
| `preview.ipynb` | Assess binary-search prerequisite with the chapter that develops it. |

Progression: read the relevant lesson and worked example, complete its guided practice, then attempt the added independent homework without copying the solution. Require contract-derived expected results, boundary evidence, and reasoning about the chosen representation or design. Assess process and explanation as well as output. Existing labs remain scaffolded applications rather than the sole evidence of independent mastery.

Lecture decks remain a separately tracked task. No additional chapter, meeting, or required optional-topic track is introduced.

### Verified Topic-to-Assessment Progression

| Topic/outcome | Explanation and worked example | Guided preparation | Independent evidence |
| --- | --- | --- | --- |
| Linked-head replacement and valid prerequisites | 1402_linked_nodes existing reference-link operations, now linked to Ch5 ref contract | Existing link/invariant practice | Preview checks link preservation; original binary-search question and ID moved to Chapter 16 preview. |

Keep the original five-question coding tracks and smaller historical variations. Added transfer tasks complement them. Grade implementation, independently derived expected results, and the requested reasoning separately; correct output from a supplied class does not establish algorithm construction.


## Subsection Integration (2026-10-17)

This is the current internal teaching order for the repaired pages. Earlier outlines remain historical where they differ. Chapter/section notebook order is unchanged. All original explanations, examples, exercises, code outputs, assessment identifiers, and link destinations are retained.

### `1403_comparison_lab.ipynb`

- Array Search and Indexing
- Linked Traversal
- Middle Insertion Costs
- Separate Location Cost from Update Cost
- Count a Concrete Workload
- Test the Contract Before Comparing Speed
- Memory and Locality Qualify the Recommendation
- Decision Guide
- Lab Tasks
- Summary

Treat syntax, examples, and meaningful variations as children of their conceptual topic. Place prerequisite explanations before application, and distinguish a local checkpoint from later synthesis. Preserve distinct older/newer treatments by grouping them rather than deleting them. Keep the final Footnotes group after instructional content.

## Caption-Only Section Development (2026-10-18)

The short code-first sections at the top of 14.1, 14.2, and 14.3 now read as explanation, pattern, example, interpretation, mistake, so the developed trace sections later on each page build on something students have already run and understood. Headings, cell IDs, and exercise IDs are unchanged.

## Guided Practice Pass (2026-10-18)

Pass 4 of the content-development audit (`authoring/content_development_audit/`): added mid-page guided practices with solutions to 14.1 (append with growth; the starter throws until the growth check is added), 14.2 (count the nodes), and 14.3 (count the deletion shifts). Every new starter and solution compiles and runs standalone (.NET 10); starters that are meant to fail say so in their task text. No existing cell, heading, or exercise ID was removed.
