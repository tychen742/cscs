# Chapter Organization — Arrays

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `0701_onedim.ipynb` | Creating and Accessing Arrays | Core content |
| `0703_array_processing.ipynb` | Processing and Sharing Arrays | Core content |
| `0702_twodim.ipynb` | 2D & ND Arrays | Core content |

Keep the current section boundaries and recently developed content. Consolidate repeated in-page navigation, distinguish repeated practice headings, retain all substantive explanations/examples and finish the instructional material before the final Footnotes group.

Teach the section conceptual framework before detailed application; place syntax prerequisites before reasoning that requires them. Keep the new worked traces and guided checkpoints, followed by existing lab/homework transfer. Reading count does not set a meeting or word quota.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Current B-A Teaching Progression (2026-10-17)

This is the current progression within the existing section order; earlier meeting outlines below are historical where they conflict. Readings are not additional required meetings.

Keep creation/access first, processing/sharing second and rectangular arrays third. Keep jagged arrays as extension reading. The repaired defaults/LINQ material remains in 0701.

| Reading | Developed content-section coverage |
| --- | --- |
| `0701_onedim.ipynb` | Executable allocation/index/update examples, index-state table, safe last access and guided bound repair; repair retained markup without discarding variants. |

**Conceptual framework:** motivate the result contract and connect the new operation to prior control flow, state, representation or algorithm ideas.

**Subsection development:** use the new small trace and standalone worked example before the complete retained implementation. Interpret the saved output, vary an assumption and diagnose a plausible mistake. Syntax scaffolds are patterns, not hidden executable prerequisites.

**Practice progression:** Trace indexed state changes; complete the safe last-element guard; vary empty/singleton inputs before the existing sales lab and array homework. Preserve all original loop, returned-array and string-array variations.

Keep prerequisite explanations in these content sections. Labs apply the explained ideas and may scaffold the task; homework increases transfer. No existing explanation, exercise variation, assignment identity or independent-work requirement is removed to fit a time or word quota.


## Learning Objectives

1. Declare, initialize and safely index an array; explain fixed length versus mutable elements.
2. Trace and implement traversal, accumulation and indexed updates, including empty inputs.
3. Explain aliasing and method-side element changes, and process rectangular arrays with nested loops.

## Sequence

- One-dimensional arrays
- Two-dimensional arrays

## Notes

- Keep core coverage on one-dimensional arrays, indexing, traversal, method parameters, references/aliases, and rectangular two-dimensional arrays.
- Treat jagged arrays as applied extension material.

## Restored CS1 Material (2026-10-17)

- `assignments/additional_practice.ipynb`: restored explanations and exercises; retains current lessons and assignment IDs.

The final source-list check also retains the original named array, reversal, and small abstract/interface variations in the corresponding supporting practice; see the preservation matrix for exact locations.

## Arrays and Collection Families (2026-10-17)

Landing pages and opening explanations explicitly classify arrays as collections and connect fixed-length indexed storage to lists, dictionaries, sets, and processing-order families. Chapter 7 develops array operations; Chapter 8 compares the broader families. Existing section order, examples, and assessments are unchanged.

## Section-Boundary Review (2026-10-17)

**Status: implemented.** The following records the reviewed recommendation and its baseline. See Implemented Reading Organization below for the final current filenames and order; earlier meeting allocations are historical where they conflict.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `0701_onedim.ipynb`: 1D Arrays | Core content | 2,713 | 9 | 0 |
| `0702_twodim.ipynb`: 2D & ND Arrays | Core content | 1,598 | 13 | 7 |

**Recommendation:** Split the one-dimensional array lesson.

0701 moves from declaration/indexing to command-line parameters and reference aliasing. Creating/accessing a collection and reasoning about processing/sharing it deserve separate teaching sequences.

### Proposed Reading Sequence

1. Arrays as fixed-length indexed collections.
2. Processing arrays, method arguments, and shared references.
3. Rectangular multidimensional arrays.

### Adequacy Before Reorganization

Develop sum/count/search or transformation traces and guided tasks before the processing page is separated. Explain reference copying before its method-side effects; use command-line tooling as an application rather than the definition of array processing.

Reading sections and class meetings are different units; allocate discussion and practice after developing adequate explanations. Do not reduce distinct material to meet a section or word quota.

Preserve every existing explanation, exercise variation and assessment identity. The source-to-destination dispositions in MATERIALS.md govern any later move. Update TOC, links and redirects only in an authorized implementation pass.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `0701_onedim.ipynb`: Creating and Accessing Arrays.
- `0703_array_processing.ipynb`: Processing and Sharing Arrays.
- `0702_twodim.ipynb`: 2D & ND Arrays.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.

## Searching and Sorting Section (2026-10-18)

Reading order: 7.1 Creating and Accessing, 7.2 Processing and Sharing, 7.3 Searching and Sorting Arrays, 7.4 2D & ND Arrays. 7.3 follows traversal and aliasing because the search loop reuses the accumulator pattern and sorting a clone reuses the aliasing discussion. Sequence within 7.3: contract, linear search, matching-rule practice, count and largest, library sort and search, why halving is faster, binary search by hand with a boundary-repair practice, insertion sort with a saved-item practice, choosing among the three, product-code practice. The landing page has eight objectives and 28 glossary terms; the homework's search and sort tasks are the independent evidence.
