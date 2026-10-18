---
orphan: true
---

# Chapter Organization: Graphs and Traversal

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `2001_graph_vocabulary.ipynb` | Graph Vocabulary and Models | Core content |
| `2002_adjacency_representations.ipynb` | Adjacency Representations | Core content |
| `2003_graph_traversal.ipynb` | Breadth-First Search and Paths | Core content |
| `2004_depth_first_components.ipynb` | Depth-First Search and Components | Core content |

Four core readings remain. The DFS/components reading closes with the full traversal-verification contracts previously published as 2601. The landing objectives/vocabulary now include those checks. Preserve the new BFS queue and DFS frame/component walkthroughs and original complete implementations. The former 2601 page redirects here.

Teach the section conceptual framework before detailed application; place syntax prerequisites before reasoning that requires them. Keep the new worked traces and guided checkpoints, followed by existing lab/homework transfer. Reading count does not set a meeting or word quota.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Current B-A Teaching Progression (2026-10-17)

This is the current progression within the existing section order; earlier meeting outlines below are historical where they conflict. Readings are not additional required meetings.

Retain vocabulary, representations, BFS/paths and DFS/components. Use small traversal cores and state traces before the complete standalone graph classes. Component labeling uses symmetric undirected input.

| Reading | Developed content-section coverage |
| --- | --- |
| `2003_graph_traversal.ipynb` | Connect BFS queue/discovery/predecessor updates to a small standalone traversal and guided route reconstruction. |
| `2004_depth_first_components.ipynb` | Trace recursive DFS frames and entry/exit events, then label undirected components with a guided isolate variation. |

**Conceptual framework:** motivate the result contract and connect the new operation to prior control flow, state, representation or algorithm ideas.

**Subsection development:** use the new small trace and standalone worked example before the complete retained implementation. Interpret the saved output, vary an assumption and diagnose a plausible mistake. Syntax scaffolds are patterns, not hidden executable prerequisites.

**Practice progression:** Predict queue and frame events; change neighbor order; reconstruct paths; label an isolate. Then use the current network lab/homework, checking distances, route witnesses and component membership independently of tie-dependent order.

Keep prerequisite explanations in these content sections. Labs apply the explained ideas and may scaffold the task; homework increases transfer. No existing explanation, exercise variation, assignment identity or independent-work requirement is removed to fit a time or word quota.


## Class Meetings

1. **Graph Vocabulary, 35 minutes.** Predict a result, trace a small example, inspect the runnable model, and complete a nearby exercise.
2. **Adjacency Representations, 40 minutes.** Predict a result, trace a small example, inspect the runnable model, and complete a nearby exercise.
3. **Traversal and Components, 35 minutes.** Predict a result, trace a small example, inspect the runnable model, and complete a nearby exercise.

Total: 110 minutes. Lab and homework add guided and independent practice.

## Assignment Roles

Preview checks vocabulary and contracts. Lab contains five connected coding tasks. Homework contains five workplace true/false questions and five standalone coding tasks. Graph traversal is assessed directly; weighted route optimization remains in Part VII.

## Section-Boundary Review (2026-10-17)

**Status: implemented.** The following records the reviewed recommendation and its baseline. See Implemented Reading Organization below for the final current filenames and order; earlier meeting allocations are historical where they conflict.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `2001_graph_vocabulary.ipynb`: Graph Vocabulary and Models | Core content | 1,071 | 19 | 5 |
| `2002_adjacency_representations.ipynb`: Adjacency Representations | Core content | 1,130 | 19 | 7 |
| `2003_graph_traversal.ipynb`: Graph Traversal: Reachability, Paths, and Components | Core content | 504 | 16 | 6 |

**Recommendation:** Split BFS/path reasoning from DFS/components.

2003 packs two traversal strategies, path reconstruction, cycle behavior and connectivity into 504 prose words. Different worklist semantics and correctness arguments need distinct teaching sequences.

### Proposed Reading Sequence

1. Graph modeling and contracts.
2. Adjacency representations and update invariants.
3. BFS discovery, layers, and predecessor paths.
4. DFS, cycles, components, and verification.

### Adequacy Before Reorganization

Develop frontier/visited/predecessor state tables, marking-time mistakes and direction-sensitive component reasoning before splitting physically. Do not create two skeletal outlines.

Reading sections and class meetings are different units; allocate discussion and practice after developing adequate explanations. Do not reduce distinct material to meet a section or word quota.

Preserve every existing explanation, exercise variation and assessment identity. The source-to-destination dispositions in MATERIALS.md govern any later move. Update TOC, links and redirects only in an authorized implementation pass.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `2001_graph_vocabulary.ipynb`: Graph Vocabulary and Models.
- `2002_adjacency_representations.ipynb`: Adjacency Representations.
- `2003_graph_traversal.ipynb`: Breadth-First Search and Paths.
- `2004_depth_first_components.ipynb`: Depth-First Search and Components.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.

## Landing Page Alignment (2026-10-17)

The landing page `2000_graphs.ipynb` now orients students to the four sections (vocabulary and models; adjacency representations; breadth-first search and paths; depth-first search and components) with a grounded introduction, seven measurable objectives, and a glossary built from the content notebooks (see MATERIALS.md, Landing Page Development). Preview quizzes should draw vocabulary from that glossary. Class meeting allocations above are unchanged.
