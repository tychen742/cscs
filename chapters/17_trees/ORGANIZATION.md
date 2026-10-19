---
orphan: true
---

# Chapter Organization: Trees

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `1701_tree_structure.ipynb` | Tree Structure and Recursive Models | Core content |
| `1704_tree_traversal.ipynb` | Tree Traversal, Returned Values, and Costs | Core content |
| `1702_binary_search_trees.ipynb` | Binary Search Trees | Core content |
| `1703_tree_lab.ipynb` | Tree Queries and Verification | Core content |

Keep the current section boundaries and recently developed content. Consolidate repeated in-page navigation, distinguish repeated practice headings, retain all substantive explanations/examples and finish the instructional material before the final Footnotes group.

Teach the section conceptual framework before detailed application; place syntax prerequisites before reasoning that requires them. Keep the new worked traces and guided checkpoints, followed by existing lab/homework transfer. Reading count does not set a meeting or word quota.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Current B-A Teaching Progression (2026-10-17)

This is the current progression within the existing section order; earlier meeting outlines below are historical where they conflict. Readings are not additional required meetings.

Retain structure/recursive models, traversal, BST updates and tree queries in the current reading order. Add leaf-query completion before students design a new recursive summary.

| Reading | Developed content-section coverage |
| --- | --- |
| `1701_tree_structure.ipynb` | Add guided node/leaf recursion with completed return table and standalone checkpoint before independent tree-query design. |

**Conceptual framework:** motivate the result contract and connect the new operation to prior control flow, state, representation or algorithm ideas.

**Subsection development:** use the new small trace and standalone worked example before the complete retained implementation. Interpret the saved output, vary an assumption and diagnose a plausible mistake. Syntax scaffolds are patterns, not hidden executable prerequisites.

**Practice progression:** Fill a return table, complete two operators, check empty/singleton/one-child/two-child trees, then design a one-child count. Existing service-desk lab and homework remain the independent application track.

Keep prerequisite explanations in these content sections. Labs apply the explained ideas and may scaffold the task; homework increases transfer. No existing explanation, exercise variation, assignment identity or independent-work requirement is removed to fit a time or word quota.


## Learning Objectives

Students trace recursive algorithms, preserve the BST ordering invariant across complete updates, analyze costs using height, and verify ordered-set behavior against an independent model.

## Class Meetings

1. **Tree structure and traversal, 35 minutes.** Draw the catalog tree; identify depths, leaves, and edges; trace Count returns and traversal timing; predict empty, singleton, and chain results. Separate total traversal work from active call-stack space.
2. **Binary search trees, 40 minutes.** Trace narrowing ancestor bounds, successful/failed search, and insertion returns. Explain duplicate handling and shape-dependent costs. Draw all deletion cases, including root replacement and a successor's right child.
3. **Applied tree operations, 35 minutes.** Use the service-ticket index for lookup and reporting. Trace range pruning and level-order queue contents. Compare updates against `SortedSet<int>` and introduce mutation checking before connected lab work.

The planned lecture total is 110 minutes, including predictions, hand traces, discussion, and code inspection. Assignments provide additional guided and independent work.

## Assignment Roles

- Preview checks vocabulary, ordering, traversal, and the successor rule before class.
- Lab builds one service-ticket index through registration, search, simple deletion, successor deletion, and lifecycle tests. Every cell contains its own setup; students carry completed methods forward explicitly.
- Homework transfers the algorithms to budgets, boundary-safe validation, an explicit traversal stack, interval reports, and greatest-eligible-key lookup.

## Scope and Conventions

- Keep general-tree structure separate from BST ordering. Use unique integer IDs as the implemented set contract.
- Keep balancing rotations outside this chapter. Explain why an unbalanced tree cannot guarantee logarithmic path costs.
- Coding-question cells carry the `exercise` tag (renamed from the legacy `thebe-interactive` tag on 2026-10-18).
- Slides remain pending; later Press work will provide HTML/PDF to students and restrict PPTX downloads to instructors.

## Foundation Placement (2026-10-07)

Moved base/recursive cases and call-stack traces from Chapter 22 into `1701_tree_structure.ipynb`, before recursive tree operations. Helper contracts and divide-and-conquer remain in Chapter 22.

### Revised Pacing

1. **Tree structure, recursive calls, and traversal, 40 minutes.** Introduce base cases and call/return traces before tree recursion.
2. **Binary search trees, 40 minutes.**
3. **Applied operations, 30 minutes.**

Total: 110 minutes. Preparation and assignments supply additional practice.

## Section-Boundary Review (2026-10-17)

**Status: implemented.** The following records the reviewed recommendation and its baseline. See Implemented Reading Organization below for the final current filenames and order; earlier meeting allocations are historical where they conflict.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `1701_tree_structure.ipynb`: Tree Structure and Traversal | Core content | 1,380 | 29 | 8 |
| `1702_binary_search_trees.ipynb`: Binary Search Trees | Core content | 1,686 | 29 | 9 |
| `1703_tree_lab.ipynb`: Tree Implementation Lab | Core content | 864 | 17 | 6 |

**Recommendation:** Split the initial tree/recursion/traversal lesson.

1701 introduces tree vocabulary, first recursion, traversal timing and height/space costs in one page. First encountering recursive control flow deserves space before comparing traversal algorithms.

### Proposed Reading Sequence

1. Tree structure and recursive modeling.
2. Traversal orders, call/return traces, and costs.
3. BST contracts and complete updates.
4. Applied queries and independent verification.

### Adequacy Before Reorganization

Expand stack-frame traces and connect visits versus returned values. Four reading pages can support three meetings; do not cut deletion cases to fit the meeting count.

Reading sections and class meetings are different units; allocate discussion and practice after developing adequate explanations. Do not reduce distinct material to meet a section or word quota.

Preserve every existing explanation, exercise variation and assessment identity. The source-to-destination dispositions in MATERIALS.md govern any later move. Update TOC, links and redirects only in an authorized implementation pass.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `1701_tree_structure.ipynb`: Tree Structure and Recursive Models.
- `1704_tree_traversal.ipynb`: Tree Traversal, Returned Values, and Costs.
- `1702_binary_search_trees.ipynb`: Binary Search Trees.
- `1703_tree_lab.ipynb`: Tree Queries and Verification.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.

## Guided Practice Pass (2026-10-18)

Pass 4 of the content-development audit (`authoring/content_development_audit/`): added mid-page guided practices with solutions to 17.1 (sum the values) and 17.4 (find the largest ID), and task text with expected output above the code-only Exercise cells of 17.2, 17.3, and 17.4. Every new starter and solution compiles and runs standalone (.NET 10); starters that are meant to fail say so in their task text. No existing cell, heading, or exercise ID was removed.

## Mistakes and Interpretation Pass (2026-10-18)

Pass 5 of the content-development audit (`authoring/content_development_audit/`), all four pages: 16 common-mistake paragraphs beside the examples (building below a missing node, non-shrinking recursion, reading a trace top-down, pruning the wrong side, a stack in place of the level-order queue, successor left in place after removal) and interpretation after the exercise solutions, the SortedSet example, the TicketTree opener, and the range-count solution. Every demonstration cell on these pages was rerun and the interpretations quote the actual output. No code cell, heading, cell ID, or exercise ID changed.

## Visual Support and Part I Shape (2026-10-18)

Pass 6 of the content-development audit (`authoring/content_development_audit/`): 17.4 gained a pruning diagram marking visited and skipped nodes for the 25 to 60 range query and a step-by-step queue table for level order. New code cells compile and run standalone (.NET 10); tables and text diagrams are placed beside the example they explain. No heading, cell ID, or exercise ID changed.
