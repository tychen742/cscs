# Chapter Organization — Arrays

## Learning Objectives

<!-- List 3–5 measurable student outcomes -->

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
