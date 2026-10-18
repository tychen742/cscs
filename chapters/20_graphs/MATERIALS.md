---
orphan: true
---

# Materials: Graphs and Traversal

## Core Materials

- `2001_graph_vocabulary.ipynb`: Graph Vocabulary
- `2002_adjacency_representations.ipynb`: Adjacency Representations
- `2003_graph_traversal.ipynb`: Traversal and Components
- `assignments/`: preview, connected lab, homework, and assignment index.

## Verification and Remaining Work

Standalone C# cells and reference console projects are checked during this revision. Updated slides and recordings are pending. Advanced sorting, tree rotations, weighted graph optimization, and further algorithm analysis are optional depth, not additional requirements for this unit.

## Section-Boundary Coverage Disposition (2026-10-17)

**Reviewed plan, now implemented:** Split BFS/path reasoning from DFS/components. The disposition below records the preimplementation baseline and rationale. See Implemented Reading Organization for the current reading files. Counts in this baseline exclude fenced code from prose; the refreshed inventory is in authoring/content_size/. They flag review needs, not quality scores.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `2001_graph_vocabulary.ipynb`: Graph Vocabulary and Models | Core content | 1,071 | 19 | 5 |
| `2002_adjacency_representations.ipynb`: Adjacency Representations | Core content | 1,130 | 19 | 7 |
| `2003_graph_traversal.ipynb`: Graph Traversal: Reachability, Paths, and Components | Core content | 504 | 16 | 6 |

### Source-to-Destination Plan

| Existing source | Proposed treatment and coverage to preserve |
| --- | --- |
| `2001` | Retain graph vocabulary/model assumptions. |
| `2002` | Retain representations and protected updates; link the optional representation workshop without adding it as a prerequisite. |
| `2003` | Split BFS discovery/layers/predecessor recovery from DFS discovery/cycle issues and component policies. Include a common graph to compare outcomes and costs. |
| `2601 (cross-chapter source)` | Use Chapter 26 traversal-verification contracts beside the relevant BFS/DFS arguments. Retain its existing URL as a supporting verification reading and retain final synthesis references. |

### Development Needed Before Moving Material

Develop frontier/visited/predecessor state tables, marking-time mistakes and direction-sensitive component reasoning before splitting physically. Do not create two skeletal outlines.

Before a later move, create a cell-level preservation map for these sources, including citations, figures, original code forms, worked traces, guided questions and independent exercise variants. Relocate prerequisite explanations from assignments into content when needed while retaining application requirements and IDs. A consolidated page must still teach its concepts; a split must not create two unsupported outlines. Existing runnable verification records describe earlier work, not verification of this proposal.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `2001_graph_vocabulary.ipynb`: Graph Vocabulary and Models.
- `2002_adjacency_representations.ipynb`: Adjacency Representations.
- `2003_graph_traversal.ipynb`: Breadth-First Search and Paths.
- `2004_depth_first_components.ipynb`: Depth-First Search and Components.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.
