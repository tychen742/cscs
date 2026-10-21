# Chapter Organization — Arrays

## Current Lecture Deck (2026-10-21)

The revised chapter deck is `_html_extra/chapters/07_arrays/0700_slides.md`. It follows the current reading order with a named part per reading, worked examples and state traces, quick checks, existing exercise links, and instructor notes. Meeting 1: 7.1 and traversal/aliases in 7.2, 35 minutes; meeting 2: searches and one insertion-sort pass in 7.3, 40 minutes; meeting 3: 7.4 and parameter behavior in 7.2, 35 minutes. Total 110 minutes. Reading pages do not add meetings. Optional supporting parts remain unassessed. The chapter landing links the student HTML deck; the former overview remains unchanged for compatibility. Code verification is recorded with `authoring/slide_revision/code_01_08.json`; final render/build evidence is recorded by the shared slide workflow. Assessment identities and assignment notebooks are unchanged.

## Standard Homework Scoring (2026-10-21)

Standard Homework now has five applied true/false questions and five independent coding questions for ten points. The existing last-match, half-open binary-search, descending insertion-sort, and sorted-clone library-contract tasks remain core with their existing identities. A standalone rectangular branch/day summary adds direct 7.4 evidence, including zero rows, one row, and one column. The original twenty-question review follows Submit as explicitly optional, ungraded reference. New completed solutions retain independently verified .NET 10 output. Existing cells, metadata identities, and radio names/values remain; slides stay deferred.

## Assignment Alignment Revision (2026-10-21)

Preview now samples insertion-sort preservation and the binary-search sorted-order precondition alongside array basics. All original cell IDs remain in place; chapter order and assessment identities are unchanged.

## Assignment Alignment Repair (2026-10-21)

The existing independent binary-search question/reference now uses the same half-open [low, high) convention as core 7.3 and its objective. A new independent library-contract exercise sorts a clone with an ordinal comparer, searches with the same policy, distinguishes negative encodings from a universal -1 assumption, and checks original order, empty, and singleton inputs. Existing handwritten algorithms and assessment IDs remain.

All existing notebook cell IDs, assessment/exercise IDs, radio names/values, and chapter order are preserved. New practice uses distinct semantic identities. Slides remain deferred. Completed new or changed solutions are compiled and executed independently under .NET 10; verification evidence is consolidated in the assignment-revision report.

## Current Teaching Allocation (2026-10-21)

This allocation supersedes earlier meeting estimates where they differ. Core readings remain assigned; a reading page is not a separate meeting. Preparation means reading the relevant explanations and predicting the named example before class.

| Meeting | Minutes | Preparation | Guided class work |
| --- | ---: | --- | --- |
| 1 | 35 | 7.1 and the traversal opening of 7.2. | Create an array, check empty/last positions, and trace a processing loop and an alias. |
| 2 | 40 | 7.3. | Trace linear and half-open binary search, then one insertion-sort pass; repair one boundary or saved-item defect. |
| 3 | 35 | 7.4 and parameter behavior in 7.2. | Summarize rows and columns, check rectangular dimensions, and distinguish shared elements from copied references. |

Total: 110 minutes including predictions, selected code runs, and nearby checks. Lab and homework provide subsequent guided and independent transfer. No additional assessment questions are introduced by this allocation.

Keep command-line argument programs and jagged/ND-array variants as reference examples. Students read all core sections, but class selects traces and one repair rather than running every sorting example live.

## Core Depth Revision (2026-10-19)

C06: teach array parameter/reference behavior and aliases together, followed by the preserved Main/Command Line Adder application. The command-line application reuses the same array semantics rather than interrupting their explanation.

This current arrangement supersedes conflicting historical outlines below. Assignments and optional/supporting readings are unchanged. Existing explanations, examples, exercise identities and published paths are preserved. Verification and cell-preservation evidence are recorded in `authoring/core_depth_revision/`.

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `0701_onedim.ipynb` | Creating and Accessing Arrays | Core content |
| `0702_array_processing.ipynb` | Processing and Sharing Arrays | Core content |
| `0704_twodim.ipynb` | 2D & ND Arrays | Core content |

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
| `0704_twodim.ipynb`: 2D & ND Arrays | Core content | 1,598 | 13 | 7 |

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
- `0702_array_processing.ipynb`: Processing and Sharing Arrays.
- `0704_twodim.ipynb`: 2D & ND Arrays.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.


## Outcome Gap Repair (2026-10-17)

Preserve the current chapter notebooks, reading order, existing explanations, exercise variants, and assessment identifiers. The additions below close the outcome audit gaps within that organization. Explanations belong in content before independent application; earlier scaffolded tasks remain available.

| Location | Development or assessment |
| --- | --- |
| `0704_twodim.ipynb` | From One Row to a Table Summary |

Progression: read the relevant lesson and worked example, complete its guided practice, then attempt the added independent homework without copying the solution. Require contract-derived expected results, boundary evidence, and reasoning about the chosen representation or design. Assess process and explanation as well as output. Existing labs remain scaffolded applications rather than the sole evidence of independent mastery.

Lecture decks remain a separately tracked task. No additional chapter, meeting, or required optional-topic track is introduced.

### Verified Topic-to-Assessment Progression

| Topic/outcome | Explanation and worked example | Guided preparation | Independent evidence |
| --- | --- | --- | --- |
| Two-dimensional aggregation bridge | 0704_twodim: branch/day table, one-row and one-column standalone demo | Change fixed coordinate, add branch, then reset each outer-loop total | Existing independent branch-by-day lab retained intact; it is assessment, not a replacement for the guided bridge. |

Keep the original five-question coding tracks and smaller historical variations. Added transfer tasks complement them. Grade implementation, independently derived expected results, and the requested reasoning separately; correct output from a supplied class does not establish algorithm construction.


## CS1 Search and Sort Progression

The core reading `0703_searching_sorting_arrays.ipynb` (7.3, between Processing and Sharing Arrays and 2D & ND Arrays) teaches linear search, binary search, and insertion sort, combining the library calls with hand-written versions. No existing notebook or exercise is removed or renamed; the search/sort cells drafted inside `0702_array_processing.ipynb` were moved into 7.3 on 2026-10-18 so nothing is taught twice. `0704_twodim.ipynb` places its core row/column bridge before optional jagged arrays.

| Outcome | Explanation and worked example | Guided practice | Independent assessment |
| --- | --- | --- | --- |
| Sequential matching | Linear-search method/call syntax, indexed trace, first-match/-1 contract | FirstAtLeast matching-rule variation and boundary inputs | Last matching shipment, including duplicates and absence |
| Ordered lookup | Binary-search precondition, half-open bounds as in Chapter 16, midpoint trace, progress and duplicate policy; `Array.BinarySearch` sign test | Repair final-candidate defect; test endpoints and empty input | Invoice lookup with independent expected cases and missing-target trace |
| Ordering and preservation | Insertion-sort saved-item trace, shifts, in-place mutation and copy | Restore saved-item placement; check empty, singleton, reversed, and duplicate inputs | Descending stock report preserving original input and occurrences |

All three topics use purposeful state tables and standalone executable examples, output interpretation, common mistakes, and progressively more independent practice. Student methods assume non-null arrays; empty arrays are supported. Sorting changes positions, so a search result in a sorted copy is not an original arrival index.

Chapter 16 retains its full deeper treatment: result contracts, correctness/invariants, ordering policies and comparers, labeled-record stability, exact work counts, preparation/update costs, library contracts, and repeated-query choices. Do not remove that development as duplication of the CS1 introduction. The chapter landing objectives and glossary now reflect the introductory algorithms.

## Searching and Sorting Section (2026-10-18)

Reading order: 7.1 Creating and Accessing, 7.2 Processing and Sharing, 7.3 Searching and Sorting Arrays, 7.4 2D & ND Arrays. 7.3 follows traversal and aliasing because the search loop reuses the accumulator pattern and sorting a clone reuses the aliasing discussion. Sequence within 7.3: contract, linear search, matching-rule practice, count and largest, library sort and search, why halving is faster, binary search by hand with a boundary-repair practice, insertion sort with a saved-item practice, choosing among the three, product-code practice. The landing page has eight objectives and 28 glossary terms; the homework's search and sort tasks are the independent evidence.

## Legacy Page Development (2026-10-18)

7.1 and 7.2 keep their reading order and headings; each legacy section now has a runnable worked example with interpretation after its explanation, and 7.1 has a guided practice before the defaults section. The command-line material remains a project exercise, with the runnable cells showing the same code on a supplied array.
