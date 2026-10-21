---
orphan: true
---

# Chapter Organization: Priority Queues and Heaps

## Aligned Lecture Deck (2026-10-21)

One chapter source at `_html_extra/chapters/18_priority_queues/1800_slides.md` contains 46 slides, with one complete part per current core reading. Chapter-title speaker notes list part starts and the existing 110-minute meeting allocation; reading parts do not add meetings. Every slide has instructor notes, with check/practice answers confined to notes. Existing chapter order, assessments, and their identities are unchanged. Student HTML and instructor-only editable PowerPoint are generated centrally; complete standalone C# examples are verified from `authoring/slide_revision/code_18_26.json`.

## Assignment Alignment Revision (2026-10-21)

Repeated Preview concepts are replaced in the same radio groups with distinct contract questions; existing canonical values and identities remain. Homework True/False items are concrete applied cases with misconception-specific explanations instead of generic feedback. Existing independent coding assessments remain; reference checklists make their separate trace/test evidence explicit.

## Independent Assessment Feedback (2026-10-21)

The existing independent homework implementation and its exercise identity are retained. Added reference feedback distinguishes the completed code core from the full requested trace, boundary, policy, and representation evidence; students still submit all parts of the original prompt.

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `1801_priority_queues.ipynb` | Priority Queue Contracts and Heap Shape | Core content |
| `1802_heap_implementation.ipynb` | Implementing and Checking a Binary Heap | Core content |
| `1803_priority_applications.ipynb` | Priority Workloads and Top-K Selection | Core content |

Keep the current section boundaries and recently developed content. Consolidate repeated in-page navigation, distinguish repeated practice headings, retain all substantive explanations/examples and finish the instructional material before the final Footnotes group.

Teach the section conceptual framework before detailed application; place syntax prerequisites before reasoning that requires them. Keep the new worked traces and guided checkpoints, followed by existing lab/homework transfer. Reading count does not set a meeting or word quota.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Class Meetings

1. **Priority Contracts, 35 minutes.** Predict a result, trace a small example, inspect the runnable model, and complete a nearby exercise.
2. **Heap Implementation, 40 minutes.** Predict a result, trace a small example, inspect the runnable model, and complete a nearby exercise.
3. **Priority Applications, 35 minutes.** Predict a result, trace a small example, inspect the runnable model, and complete a nearby exercise.

Total: 110 minutes. Lab and homework add guided and independent practice.

## Assignment Roles

Preview checks vocabulary and contracts. Lab contains five connected coding tasks. Homework contains five workplace true/false questions and five standalone coding tasks. Priority policy, heap invariants, top-K selection, and fairness are the direct assessment scope. Graph traversal follows in Chapter 20.

## Section-Boundary Review (2026-10-17)

**Status: implemented.** The following records the reviewed recommendation and its baseline. See Implemented Reading Organization below for the final current filenames and order; earlier meeting allocations are historical where they conflict.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `1801_priority_queues.ipynb`: Priority Queue Contracts and Heap Shape | Core content | 545 | 15 | 5 |
| `1802_heap_implementation.ipynb`: Implementing and Checking a Binary Heap | Core content | 636 | 14 | 5 |
| `1803_priority_applications.ipynb`: Priority Workloads and Top-K Selection | Core content | 412 | 11 | 5 |

**Recommendation:** Retain contract, implementation, and application roles.

The application page is short but top-K and fairness are genuine transfers, not duplicate heap syntax. All three pages need expansion rather than automatic merging.

### Proposed Reading Sequence

1. Priority contracts and heap representation.
2. Heap operations and invariants.
3. Priority workloads, top-K, and fairness.

### Adequacy Before Reorganization

Add index/parent reasoning, empty/singleton/tied-priority traces, heap versus sorted-order distinctions and top-K justification. Correct generic planning text that claims graph traversal is this chapter's direct assessment target.

Reading sections and class meetings are different units; allocate discussion and practice after developing adequate explanations. Do not reduce distinct material to meet a section or word quota.

Preserve every existing explanation, exercise variation and assessment identity. The source-to-destination dispositions in MATERIALS.md govern any later move. Update TOC, links and redirects only in an authorized implementation pass.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `1801_priority_queues.ipynb`: Priority Queue Contracts and Heap Shape.
- `1802_heap_implementation.ipynb`: Implementing and Checking a Binary Heap.
- `1803_priority_applications.ipynb`: Priority Workloads and Top-K Selection.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.

## Landing Page Alignment (2026-10-17)

The landing page `1800_priority_queues.ipynb` now orients students to the three sections (contracts and heap shape; implementing and checking a binary heap; priority workloads and top-k) with a grounded introduction, measurable objectives, and a glossary built from the content notebooks (see MATERIALS.md, Landing Page Development). Preview quizzes should draw vocabulary from that glossary. Class meeting allocations above are unchanged.


## Outcome Gap Repair (2026-10-17)

Preserve the current chapter notebooks, reading order, existing explanations, exercise variants, and assessment identifiers. The additions below close the outcome audit gaps within that organization. Explanations belong in content before independent application; earlier scaffolded tasks remain available.

| Location | Development or assessment |
| --- | --- |
| `homework.ipynb` | Implement Heap Repairs Without a Supplied Heap |

Progression: read the relevant lesson and worked example, complete its guided practice, then attempt the added independent homework without copying the solution. Require contract-derived expected results, boundary evidence, and reasoning about the chosen representation or design. Assess process and explanation as well as output. Existing labs remain scaffolded applications rather than the sole evidence of independent mastery.

Lecture decks remain a separately tracked task. No additional chapter, meeting, or required optional-topic track is introduced.

### Verified Topic-to-Assessment Progression

| Topic/outcome | Explanation and worked example | Guided preparation | Independent evidence |
| --- | --- | --- | --- |
| Heap repair and service policy | 1802_heap_implementation and 1803_priority_applications existing repair traces and top-k/fairness development | Existing invariant checker and scaffolded API tasks retained | New independent Push/PopMin bodies, invariant scan after each operation, boundary/duplicate checks, repair trace, fairness/aging scenario, and top-k orientation justification. |

Keep the original five-question coding tracks and smaller historical variations. Added transfer tasks complement them. Grade implementation, independently derived expected results, and the requested reasoning separately; correct output from a supplied class does not establish algorithm construction.

## Guided Practice Pass (2026-10-18)

Pass 4 of the content-development audit (`authoring/content_development_audit/`): added task text with the required output property above the code-only triage Exercise in 18.3. Every new starter and solution compiles and runs standalone (.NET 10); starters that are meant to fail say so in their task text. No existing cell, heading, or exercise ID was removed.

## Mistakes and Interpretation Pass (2026-10-18)

Pass 5 of the content-development audit (`authoring/content_development_audit/`), all three pages: mistakes beside the examples (expecting enumeration in priority order, checking the heap rule only at the root, the wrong parent formula, swapping with the left child without checking the right, a max-heap for top-k) and interpretation after the practice and exercise solutions. Every demonstration cell on these pages was rerun and the interpretations quote the actual output. No code cell, heading, cell ID, or exercise ID changed.

## OpenDSA-Modeled Development (2026-10-19)

Pass 8 placed the representation comparison after Priority Queue Behavior, the index-arithmetic example and the validity trace inside Heap Representation, and the self-check before the existing practice in 18.1. In 18.2 the enqueue trace follows the bubble-up table, and bottom-up construction, priority updates, and the sink-down completion follow the complete heap's cost discussion, with the self-check before Practice: Check Every Parent. In 18.3 heapsort and the cost-ordering exercise precede the Exercise, and the self-check precedes Priority Is Different from Fairness. New headings are `###`; each page stays within one class segment (about 700-900 added prose words and three to five short cells). See MATERIALS.md for the gap list.
