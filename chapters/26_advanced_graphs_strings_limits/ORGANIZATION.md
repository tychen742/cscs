---
orphan: true
---

# Chapter Organization — Advanced Algorithms

## Aligned Lecture Deck (2026-10-21)

One chapter source at `_html_extra/chapters/26_advanced_graphs_strings_limits/2600_slides.md` contains 46 slides, with one complete part per current core reading. Chapter 20 graph contracts are explicit preparation for the retained synthesis assignments. Chapter-title speaker notes list part starts and the existing 110-minute meeting allocation; reading parts do not add meetings. Every slide has instructor notes, with check/practice answers confined to notes. Existing chapter order, assessments, and their identities are unchanged. Student HTML and instructor-only editable PowerPoint are generated centrally; complete standalone C# examples are verified from `authoring/slide_revision/code_18_26.json`.

## Assignment Alignment Revision (2026-10-21)

Preview now has native radio controls, hints, specific explanations, and varied display positions under unchanged numbered slots/cell IDs. Homework True/False choices have native controls and a balanced applied character-policy case. Visible submission guidance distinguishes page choices from a recorded course submission.

## Assignment Alignment Follow-up (2026-10-21)

The landing adds an explicit prior-graph synthesis objective and identifies Chapter 20 BFS/path and DFS/component review readings for the service-network assignments. Graph client-check starters now include visible GraphWalk support, with no dependence on a hidden answer. Preview questions one through five now sample direct matching, ordinal text units, prepared-prefix reuse, witness validity, and unknown resource-limited results; existing cell/question positions remain. The new matching/limits core remains three readings, with graph work explicitly identified as prerequisite synthesis.

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `2601_shortest_paths_strings.ipynb` | Direct String Matching and Result Contracts | Core content |
| `2602_prefix_matching.ipynb` | Prefix Reuse and KMP | Core content |
| `2603_limits_project.ipynb` | Algorithms and Computational Limits | Core content |

Three core readings remain: direct matching, prepared-prefix/KMP matching, then computational limits. The complete graph objective block is in 2404; traversal verification is the closing section of 2004 and the former page redirects there. Landing framing, objectives, glossary and Chapter Flow now match strings/limits. The existing graph video is retained and clearly captioned as prerequisite review for service-network assignments. All newly developed direct/KMP examples remain.

Teach the section conceptual framework before detailed application; place syntax prerequisites before reasoning that requires them. Keep the new worked traces and guided checkpoints, followed by existing lab/homework transfer. Reading count does not set a meeting or word quota.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Current B-A Teaching Progression (2026-10-17)

This is the current progression within the existing section order; earlier meeting outlines below are historical where they conflict. Readings are not additional required meetings.

Keep direct matching, prefix/KMP matching and computational limits. Traversal verification is now in Chapter 20. Develop direct candidate/offset reasoning before prefix construction, fallback and overlapping scan events. Retain graph objective reminders as a cross-chapter comparison.

| Reading | Developed content-section coverage |
| --- | --- |
| `2601_shortest_paths_strings.ipynb` | Trace candidate/character indexes in a complete direct matcher and guide overlap, empty and missing-result variations. |
| `2602_prefix_matching.ipynb` | Derive prefix fallback links and annotate KMP scanning/overlap with a compact executable matcher and guided repeated-symbol trace. |

**Conceptual framework:** motivate the result contract and connect the new operation to prior control flow, state, representation or algorithm ideas.

**Subsection development:** use the new small trace and standalone worked example before the complete retained implementation. Interpret the saved output, vary an assumption and diagnose a plausible mistake. Syntax scaffolds are patterns, not hidden executable prerequisites.

**Practice progression:** Trace direct overlap cases, fill proper-border/fallback tables, verify the compact scanner against direct results, then compare prepared-pattern workloads in the existing lab/homework. Preserve empty/ordinal/overlap result contracts.

Keep prerequisite explanations in these content sections. Labs apply the explained ideas and may scaffold the task; homework increases transfer. No existing explanation, exercise variation, assignment identity or independent-work requirement is removed to fit a time or word quota.


## Teaching Plan — 110 Minutes

1. Graph traversal (40 minutes): define graph contracts, prove discovery layers, reconstruct guarded paths, trace suspended DFS frames, and distinguish directed reachability from symmetric undirected components.
2. Paths and string matching (40 minutes): distinguish hop and weight objectives, establish matching policies, derive proper borders and fallback invariants, prove linear comparison work, and include preparation and result storage.
3. Computational limits and synthesis (30 minutes): compare exact growth models, validate a greedy quality counterexample against an exact optimum, distinguish feasibility and guarantees, and develop a reviewable final comparison.

## Assignment Progression

Preview introduces discovery, frames, matching policies, borders, and quality guarantees. The lab follows one service review through BFS layers, DFS reachability and BFS paths, message matching, repeated-pattern workload counts, and team coverage quality. Homework transfers cycle/snapshot boundaries, component preconditions, empty/overlapping/ordinal matches, exact comparison counts, and impossible/oversized coverage inputs with exact growth arithmetic.

## Coverage Boundary

This final chapter synthesizes earlier graph representations, queues/stacks, analysis, greedy correctness, and state-based search. Keep weighted shortest-path implementation in Chapter 24; use a concrete objective counterexample here. KMP supplies a complete algorithm rather than a catalog of text methods. Limits distinguish model estimates from benchmarks and implementation costs from problem lower bounds. Durable final project submissions remain in the established appendix/project track; slides remain a deferred Press task.

## Foundation Placement (2026-10-07)

Basic graph traversal now belongs to Chapter 20. `2601_graph_traversal.ipynb` retains its published URL and develops verification contracts; string algorithms, limits, and the network integration lab remain here.

The earlier lecture allocation is superseded where it repeats relocated introductory topics. Use that time for contract counterexamples, verification traces, and the chapter’s optional advanced applications. Students complete Chapters 14, 16, and 19 foundations first as relevant.

## Section-Boundary Review (2026-10-17)

**Status: implemented.** The following records the reviewed recommendation and its baseline. See Implemented Reading Organization below for the final current filenames and order; earlier meeting allocations are historical where they conflict.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `2601_graph_traversal.ipynb`: Traversal Verification | Supporting reading | 224 | 8 | 0 |
| `2601_shortest_paths_strings.ipynb`: Shortest Paths and String Matching | Core content | 687 | 21 | 7 |
| `2603_limits_project.ipynb`: Algorithms and Computational Limits | Core content | 718 | 21 | 5 |

**Recommendation:** Reframe around string algorithms and limits.

The 224-word traversal page is already a verification extension of Chapter 20. The other page combines a graph-objective reminder with direct matching and KMP, whose prefix/fallback reasoning warrants its own development.

### Proposed Reading Sequence

1. Direct string matching and result contracts.
2. Prefix reuse, KMP, and complete workload costs.
3. Computational limits, guarantees, and synthesis.

### Adequacy Before Reorganization

Develop character-by-character direct/prefix/fallback traces, explain text units and full preparation/output costs, and expand feasibility versus guarantee reasoning. Retain the exact cover counterexample and all boundary witnesses.

Retain the supporting readings identified above outside the required core. Reading sections and class meetings are different units; allocate discussion and practice after developing adequate explanations. Do not reduce distinct material to meet a section or word quota.

Preserve every existing explanation, exercise variation and assessment identity. The source-to-destination dispositions in MATERIALS.md govern any later move. Update TOC, links and redirects only in an authorized implementation pass.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `2601_shortest_paths_strings.ipynb`: Direct String Matching and Result Contracts.
- `2602_prefix_matching.ipynb`: Prefix Reuse and KMP.
- `2603_limits_project.ipynb`: Algorithms and Computational Limits.
- `2601_graph_traversal.ipynb`: Traversal Verification.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.

## Mistakes and Interpretation Pass (2026-10-18)

Pass 5 of the content-development audit (`authoring/content_development_audit/`), all three pages: mistakes beside the examples (skipping overlapping matches, int shifts for 2^40, feasible read as optimal, timing before validating, improper borders, resetting q after a match, the off-by-one fallback index, moving the text backward, scan counts without preparation) and interpretation after the exercise solutions. Every demonstration cell on these pages was rerun and the interpretations quote the actual output. No code cell, heading, cell ID, or exercise ID changed.

## OpenDSA-Modeled Development (2026-10-19)

Pass 8 placed the work analysis, per-start trace, and inner-loop completion after Direct Matching with an Explicit Contract in 26.1; the prefix-table trace and fallback completion after Proper Prefixes Survive a Mismatch in 26.2; and the difficulty-class table with its concept check after Exact Search and a Concrete Heuristic in 26.3. Each page closes with Check Your Understanding before its Exercise or Footnotes. New headings are `###`; each page stays within one class segment. See MATERIALS.md for the gap list.
