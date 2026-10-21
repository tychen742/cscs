---
orphan: true
---

# Materials: Graphs and Traversal

## Assignment Alignment Revision (2026-10-21)

Repeated Preview concepts are replaced in the same radio groups with distinct contract questions; existing canonical values and identities remain. Homework True/False items are concrete applied cases with misconception-specific explanations instead of generic feedback. Existing independent coding assessments remain; reference checklists make their separate trace/test evidence explicit.

## Independent Assessment Feedback (2026-10-21)

The existing independent homework implementation and its exercise identity are retained. Added reference feedback distinguishes the completed code core from the full requested trace, boundary, policy, and representation evidence; students still submit all parts of the original prompt.

## Current Teaching Allocation (2026-10-21)

The current three-meeting, 110-minute preparation/class/reference allocation is recorded at the start of [ORGANIZATION.md](ORGANIZATION.md). It supersedes conflicting earlier estimates without removing readings, examples, or assessment identities.

Keep complete representation/update implementations, alternate topological-order traces, and additional directed-graph cases as reference examples. Choose one small network for the three live traces; students use the remaining examples for preparation and practice.

## Core Depth Revision (2026-10-19)

C14: group the preserved directed/undirected explanations as one component comparison before the component-report application. Keep DFS frames first and verification last; retain all original paragraphs, counterexamples, code and heading text/anchors.

This current arrangement supersedes conflicting historical outlines below. Assignments and optional/supporting readings are unchanged. Existing explanations, examples, exercise identities and published paths are preserved. Verification and cell-preservation evidence are recorded in `authoring/core_depth_revision/`.

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `2001_graph_vocabulary.ipynb` | Graph Vocabulary and Models | Core content |
| `2002_adjacency_representations.ipynb` | Adjacency Representations | Core content |
| `2003_graph_traversal.ipynb` | Breadth-First Search and Paths | Core content |
| `2004_depth_first_components.ipynb` | Depth-First Search and Components | Core content |

Four core readings remain. The DFS/components reading closes with the full traversal-verification contracts previously published as 2601. The landing objectives/vocabulary now include those checks. Preserve the new BFS queue and DFS frame/component walkthroughs and original complete implementations. The former 2601 page redirects here.

No assessment identity, assignment notebook, worked code, output or exercise variant is removed. `authoring/integration_cleanup/` records the original cells, exact edits, moves and URL/fragment compatibility.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Current Priority-Section Coverage (2026-10-17)

This coverage update describes the current notebooks and supersedes older pre-reorganization filename summaries below. Historical plans and verification records are retained.

| Reading | Developed content-section coverage |
| --- | --- |
| `2003_graph_traversal.ipynb` | Connect BFS queue/discovery/predecessor updates to a small standalone traversal and guided route reconstruction. |
| `2004_depth_first_components.ipynb` | Trace recursive DFS frames and entry/exit events, then label undirected components with a guided isolate variation. |

Retain vocabulary, representations, BFS/paths and DFS/components. Use small traversal cores and state traces before the complete standalone graph classes. Component labeling uses symmetric undirected input.

All original lesson cells remain, except the explicitly documented presentation/syntax/result corrections and stale chapter references in `authoring/priority_development/source_corrections.json`. Original assignment notebooks and exercise IDs remain untouched. Full standalone code is retained beside the new smaller teaching cores; newly added code verification is recorded separately from historical checks.


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

## Landing Page Development (2026-10-17)

`2000_graphs.ipynb` was rewritten from a generic template to a full chapter landing page. The old page had two bulleted objective groups (three generic bullets plus two specific ones), a Chapter Flow that ended with a stray assignments link, and a glossary cell holding two tables run together (a six-row header table followed by seven headerless rows, which rendered as a broken table). It now has a chapter introduction grounded in the four sections (vocabulary and models; adjacency representations; breadth-first search and paths; depth-first search and components) and the chapter's facilities, delivery, and workflow examples, seven numbered objectives covering graph modeling, degree identities, walks/paths/cycles and components, representation tradeoffs and density, RouteGraph invariants, BFS tracing and route reconstruction, and DFS frames with component labeling and verification, the Chapter Flow in TOC order without the assignments link, one numbered glossary of 43 terms drawn from 2001 through 2004, and a Lecture Slides section marked pending in place of Teaching Materials. The landing page carries no content sections, video, or index entries; content notebooks, `_toc.yml`, and assignments were not changed.


## Outcome Gap Repair (2026-10-17)

Preserve the current chapter notebooks, reading order, existing explanations, exercise variants, and assessment identifiers. The additions below close the outcome audit gaps within that organization. Explanations belong in content before independent application; earlier scaffolded tasks remain available.

| Location | Development or assessment |
| --- | --- |
| `homework.ipynb` | Implement and Verify Traversal Evidence |

Progression: read the relevant lesson and worked example, complete its guided practice, then attempt the added independent homework without copying the solution. Require contract-derived expected results, boundary evidence, and reasoning about the chosen representation or design. Assess process and explanation as well as output. Existing labs remain scaffolded applications rather than the sole evidence of independent mastery.

Lecture decks remain a separately tracked task. No additional chapter, meeting, or required optional-topic track is introduced.

### Verified Topic-to-Assessment Progression

| Topic/outcome | Explanation and worked example | Guided preparation | Independent evidence |
| --- | --- | --- | --- |
| Traversal construction and verification | 2003_graph_traversal and 2004_depth_first_components existing queue/frame traces and contracts | Existing guided BFS/DFS practice retained | New independent BFS discovery/predecessor/distance/path evidence, DFS frame/finish trace, components/cycle distinction, and adversarial cases. |
| Representation tradeoffs | 2002_adjacency_representations existing density/storage examples | Existing representation practice | New five-vertex list/matrix comparison requires stored-entry count and operation-specific workload reasoning. |

Keep the original five-question coding tracks and smaller historical variations. Added transfer tasks complement them. Grade implementation, independently derived expected results, and the requested reasoning separately; correct output from a supplied class does not establish algorithm construction.


## Subsection Integration (2026-10-17)

This is the current internal teaching order for the repaired pages. Earlier outlines remain historical where they differ. Chapter/section notebook order is unchanged. All original explanations, examples, exercises, code outputs, assessment identifiers, and link destinations are retained.

### `2003_graph_traversal.ipynb`

- Discover a Vertex Once, Then Process Its Neighbors
  - Turn Queue Events into a Traversal Loop
  - Breadth-First Search and Discovery
- Recover a Path from Earlier Layers
  - Recover a Path with Predecessors
  - Guide the Route and Tie-Policy Checks

### `2004_depth_first_components.ipynb`

- Watch the Suspended Neighbor Loop
  - Finish One Branch Before Returning to Its Alternatives
  - Depth-First Search and Cycles
- Connectivity Depends on Direction
  - Extend Reachability into a Component Report
  - Connected Components and Direction
  - Components and Direction
- Costs and Contracts
- Verify a Traversal
  - Traversal Verification Contracts
  - Practice: Check a Reachability Report

Treat syntax, examples, and meaningful variations as children of their conceptual topic. Place prerequisite explanations before application, and distinguish a local checkpoint from later synthesis. Preserve distinct older/newer treatments by grouping them rather than deleting them. Keep the final Footnotes group after instructional content.

## Guided Practice Pass (2026-10-18)

Pass 4 of the content-development audit (`authoring/content_development_audit/`): added mid-page guided practices with solutions to 20.1 (find the starting steps by in-degree) and 20.2 (list a room's neighbors). Every new starter and solution compiles and runs standalone (.NET 10); starters that are meant to fail say so in their task text. No existing cell, heading, or exercise ID was removed.

## Mistakes and Interpretation Pass (2026-10-18)

Pass 5 of the content-development audit (`authoring/content_development_audit/`), all four pages: mistakes beside the examples (deriving vertices from edges, counting arcs as degrees, one-direction matrix entries, zero as absence, a missing reverse entry, a matrix for a sparse graph, exposing the internal dictionary, marking on dequeue, forgetting to reverse a path, marking on exit, reading forward reachability as a component, checking only the destination) and interpretation after every code cell that had none, including the exercise solutions. Every demonstration cell on these pages was rerun and the interpretations quote the actual output. No code cell, heading, cell ID, or exercise ID changed.

## Visual Support and Part I Shape (2026-10-18)

Pass 6 of the content-development audit (`authoring/content_development_audit/`): 20.1 gained a side-by-side table of undirected and directed terms on the chapter's own examples and the degree list that the handshake check relies on. New code cells compile and run standalone (.NET 10); tables and text diagrams are placed beside the example they explain. No heading, cell ID, or exercise ID changed.

## OpenDSA References (2026-10-19)

Added **Visualize it** pointer cells after the worked examples in 20.3 (BFS; CS3 Graph Traversals, breadth-first anchor) and 20.4 (DFS; depth-first anchor), each one sentence linking the matching OpenDSA JSAV slideshow on the `opendsa-server.cs.vt.edu` host (every URL checked with curl, HTTP 200, 2026-10-19). No OpenDSA text or code is copied; no existing cell, heading, cell ID, or exercise ID changed. Re-hosted the existing OpenDSA "Further reading" footnote links to `opendsa-server.cs.vt.edu` CS2/CS3 pages, because `opendsa.org`, `opendsa.cs.vt.edu`, and `opendsax.cs.vt.edu` either fail strict fetches or are not the host this book links to. The roles of the OpenDSA books are recorded in `authoring/toc_comparison/README.md` (OpenDSA mapping) and Appendix A. Chapter 20: the two footnotes now point to CS3 14.3 Graph Traversals. CS3 14.4 Topological Sort is recorded in the README as the reference for the earlier gap item.

## OpenDSA Gap List and Development (2026-10-19)

Pass 8 (`authoring/content_development_audit/pass8_cs2_opendsa_development.md`) compared the four sections with OpenDSA CS3 14.1 Graph Terminology and Implementation, 14.2 Graph Implementations, 14.3 Graph Traversals, and 14.4 Topological Sort (14.5-14.8 belong to Chapters 24 and 26). Concepts, explanations, and exercise types OpenDSA has that this chapter lacked or treated in under 100 words:

| Gap | OpenDSA treatment | Where it is now developed |
| --- | --- | --- |
| Survey of what graphs model; lists and trees as special cases; edge-count bounds and sparse versus dense | 14.1 introduction | 20.1 What Graphs Model (new table) |
| Acyclic graphs, DAGs, free trees, forests | 14.1 terminology | 20.1 Acyclic Graphs, DAGs, and Free Trees (new) |
| Terminology recall questions | 14.1.2 Graph Terminology Questions | 20.1 Concept Check: Classify the Graph |
| Reading a matrix as a graph; converting between representations | 14.1.1, 14.2 | 20.2 Code Tracing: Read the Matrix as a Graph; Code Completion: Build the Matrix from the Neighbor Map |
| BFS queue trace with neighbor order fixed | 14.3.2 | 20.3 Code Tracing: Queue Contents Layer by Layer |
| Topological sort, queue-based, with cycle detection | 14.4.1.2 Queue-based Solution | 20.3 Order Tasks with a Topological Sort (new, runnable) and Code Completion: Release the Dependents |
| Topological sort from DFS exit order | 14.4.1.1 Depth-first solution | 20.4 Code Tracing: Enter and Exit Events (reverse exit order checked) |
| Summary questions | 14.9 Graph Concepts Summary | Check Your Understanding on every page |

Exercises added: code tracing (20.2 Read the Matrix as a Graph, 20.3 Queue Contents Layer by Layer, 20.4 Enter and Exit Events), code completion (20.2 Build the Matrix from the Neighbor Map, 20.3 Release the Dependents), concept recall with a dropdown answer (20.1), and a Check Your Understanding block of four questions on each page. Every new code cell was compiled and run standalone under .NET 10 and carries its stored output. No existing cell, heading, exercise ID, or footnote was removed; no OpenDSA text, code, or figure was copied. The concurrent reference-and-visualization pass owns the OpenDSA reference entries on these pages; this pass added none.
