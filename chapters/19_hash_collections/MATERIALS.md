---
orphan: true
---

# Materials: Hash Collections and Sets

## Core Materials

- `1901_hashing.ipynb`: Hashing and Collisions
- `1902_dictionaries_sets.ipynb`: Dictionaries and Set Algebra
- `1903_collection_selection.ipynb`: Collection Selection
- `assignments/`: preview, connected lab, homework, and assignment index.

## Verification and Remaining Work

Standalone C# cells and reference console projects are checked during this revision. Updated slides and recordings are pending. Advanced sorting, tree rotations, weighted graph optimization, and further algorithm analysis are optional depth, not additional requirements for this unit.

## Section-Boundary Coverage Disposition (2026-10-17)

**Reviewed plan, now implemented:** Retain hashing, set semantics, and coordination. The disposition below records the preimplementation baseline and rationale. See Implemented Reading Organization for the current reading files. Counts in this baseline exclude fenced code from prose; the refreshed inventory is in authoring/content_size/. They flag review needs, not quality scores.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `1901_hashing.ipynb`: Hash Tables, Equality, and Collisions | Core content | 1,158 | 20 | 6 |
| `1902_dictionaries_sets.ipynb`: Dictionaries, Sets, and Reconciliation | Core content | 454 | 15 | 5 |
| `1903_collection_selection.ipynb`: Choosing and Coordinating Collections | Core content | 772 | 16 | 5 |

### Source-to-Destination Plan

| Existing source | Proposed treatment and coverage to preserve |
| --- | --- |
| `1901` | Retain hash/equality, chaining, rehashing and open-addressing contrasts; distinguish essential implementation from optional alternatives. |
| `1902` | Develop set union/intersection/difference and reconciliation with small concrete sets and counts; do not merge it away because it has 454 words. |
| `1903` | Retain workload choice and two-index cancellation/consistency as synthesis beyond Chapter 8's orientation. |

### Development Needed Before Moving Material

Add worked collision/deletion/rehash reasoning, equality-policy examples and set membership diagrams. Align assignment-role prose with hashing/reconciliation rather than copied graph-traversal wording.

Before a later move, create a cell-level preservation map for these sources, including citations, figures, original code forms, worked traces, guided questions and independent exercise variants. Relocate prerequisite explanations from assignments into content when needed while retaining application requirements and IDs. A consolidated page must still teach its concepts; a split must not create two unsupported outlines. Existing runnable verification records describe earlier work, not verification of this proposal.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `1901_hashing.ipynb`: Hash Tables, Equality, and Collisions.
- `1902_dictionaries_sets.ipynb`: Dictionaries, Sets, and Reconciliation.
- `1903_collection_selection.ipynb`: Choosing and Coordinating Collections.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.

## Landing Page Development (2026-10-17)

`1900_hash_collections.ipynb` was rewritten from a generic template (about 200 words, three generic objectives, six glossary rows) to a full chapter landing page. It now has a chapter introduction grounded in the three sections (hash tables, equality, and collisions; dictionaries, sets, and reconciliation; choosing and coordinating collections) and the chapter's service-desk and reporting examples, seven numbered objectives tied to hash-to-bucket mapping, equality policy and dictionary contracts, chaining and tombstone traces, load factor and rehashing with costs, set algebra for reconciliation, workload-based selection, and coordinated indexes with lazy deletion, the Chapter Flow in TOC order without the assignments link, a numbered glossary of 35 terms drawn from 1901 through 1903, and a Lecture Slides section marked pending. No Chapter Video is embedded yet; the slot stays open for author selection. The landing page carries no content sections or index entries; content notebooks, `_toc.yml`, and assignments were not changed.


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
