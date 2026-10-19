---
orphan: true
---

# Chapter Organization: Hash Collections and Sets

## Class Meetings

1. **Hashing and Collisions, 35 minutes.** Predict a result, trace a small example, inspect the runnable model, and complete a nearby exercise.
2. **Dictionaries and Set Algebra, 40 minutes.** Predict a result, trace a small example, inspect the runnable model, and complete a nearby exercise.
3. **Collection Selection, 35 minutes.** Predict a result, trace a small example, inspect the runnable model, and complete a nearby exercise.

Total: 110 minutes. Lab and homework add guided and independent practice.

## Assignment Roles

Preview checks vocabulary and contracts. Lab contains five connected coding tasks. Homework contains five workplace true/false questions and five standalone coding tasks. Hash/equality contracts, collisions, sets, reconciliation, and coordinated indexes are the direct assessment scope. Graph traversal follows in Chapter 20.

## Section-Boundary Review (2026-10-17)

**Status: implemented.** The following records the reviewed recommendation and its baseline. See Implemented Reading Organization below for the final current filenames and order; earlier meeting allocations are historical where they conflict.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `1901_hashing.ipynb`: Hash Tables, Equality, and Collisions | Core content | 1,158 | 20 | 6 |
| `1902_dictionaries_sets.ipynb`: Dictionaries, Sets, and Reconciliation | Core content | 454 | 15 | 5 |
| `1903_collection_selection.ipynb`: Choosing and Coordinating Collections | Core content | 772 | 16 | 5 |

**Recommendation:** Retain hashing, set semantics, and coordination.

Set algebra is not simply a shorter form of dictionary storage, and coordinating multiple indexes has its own consistency contract. The three roles should remain while underdeveloped explanations are expanded.

### Proposed Reading Sequence

1. Hashing, key equality, and collision handling.
2. Set algebra, frequency counts, and reconciliation.
3. Selecting and coordinating collection indexes.

### Adequacy Before Reorganization

Add worked collision/deletion/rehash reasoning, equality-policy examples and set membership diagrams. Align assignment-role prose with hashing/reconciliation rather than copied graph-traversal wording.

Reading sections and class meetings are different units; allocate discussion and practice after developing adequate explanations. Do not reduce distinct material to meet a section or word quota.

Preserve every existing explanation, exercise variation and assessment identity. The source-to-destination dispositions in MATERIALS.md govern any later move. Update TOC, links and redirects only in an authorized implementation pass.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `1901_hashing.ipynb`: Hash Tables, Equality, and Collisions.
- `1902_dictionaries_sets.ipynb`: Dictionaries, Sets, and Reconciliation.
- `1903_collection_selection.ipynb`: Choosing and Coordinating Collections.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.

## Landing Page Alignment (2026-10-17)

The landing page `1900_hash_collections.ipynb` now orients students to the three sections (hash tables, equality, and collisions; dictionaries, sets, and reconciliation; choosing and coordinating collections) with a grounded introduction, measurable objectives, and a glossary built from the content notebooks (see MATERIALS.md, Landing Page Development). Preview quizzes should draw vocabulary from that glossary. Class meeting allocations above are unchanged.


## Outcome Gap Repair (2026-10-17)

Preserve the current chapter notebooks, reading order, existing explanations, exercise variants, and assessment identifiers. The additions below close the outcome audit gaps within that organization. Explanations belong in content before independent application; earlier scaffolded tasks remain available.

| Location | Development or assessment |
| --- | --- |
| `homework.ipynb` | Trace Collisions and Maintain Coordinated Indexes |

Progression: read the relevant lesson and worked example, complete its guided practice, then attempt the added independent homework without copying the solution. Require contract-derived expected results, boundary evidence, and reasoning about the chosen representation or design. Assess process and explanation as well as output. Existing labs remain scaffolded applications rather than the sole evidence of independent mastery.

Lecture decks remain a separately tracked task. No additional chapter, meeting, or required optional-topic track is introduced.

### Verified Topic-to-Assessment Progression

| Topic/outcome | Explanation and worked example | Guided preparation | Independent evidence |
| --- | --- | --- | --- |
| Hash representation behavior | 1901_hashing existing collision/growth/deletion examples | Existing collision practice and set/comparer tasks retained | New separate-chaining rehash trace and independent linear-probing tombstone trace distinguish deletion policies. |
| Coordinated indexes and workload choice | 1903_collection_selection existing queue/dictionary cancellation example | Existing skip-cancelled exercise retained | New independent cancellation queue enforces never-reused IDs, checks stale/duplicate/empty cases, states coordination invariant, and compares sorted-range workload. |

Keep the original five-question coding tracks and smaller historical variations. Added transfer tasks complement them. Grade implementation, independently derived expected results, and the requested reasoning separately; correct output from a supplied class does not establish algorithm construction.

## Mistakes and Interpretation Pass (2026-10-18)

Pass 5 of the content-development audit (`authoring/content_development_audit/`), all three pages: mistakes beside the examples (Math.Abs on hash codes, appending to a chain without scanning it, clearing a tombstone, mismatched comparers, mutating a source set, indexing to test membership, forcing one structure to answer every need, trusting one stopwatch run, assuming cancellation empties the queue) and interpretation after the colliding-key, set-algebra, lookup, workload, and lazy-deletion cells. Every demonstration cell on these pages was rerun and the interpretations quote the actual output. No code cell, heading, cell ID, or exercise ID changed.

## OpenDSA-Modeled Development (2026-10-19)

Pass 8 placed hash-function principles after the bucket-mapping mistake and the load-factor analysis after Load Factor and Rehashing in 19.1, with the probing trace and the self-check before the existing practice. In 19.2 the counting completion follows Sets and Frequency Counts, the mutated-key demonstration sits inside Keys Must Keep Their Meaning, and the set-operation concept check precedes Practice: Report Missing IDs. In 19.3 the structure-selection check follows Match the Structure to the Workload and the versioned trace precedes Explain the Selection. 19.1 remains the longest page of the chapter at roughly one class segment plus the optional probing material already marked as a comparison. See MATERIALS.md for the gap list.
