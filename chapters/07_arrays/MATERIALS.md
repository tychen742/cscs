# Chapter Materials — Arrays

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `0701_onedim.ipynb` | Creating and Accessing Arrays | Core content |
| `0703_array_processing.ipynb` | Processing and Sharing Arrays | Core content |
| `0702_twodim.ipynb` | 2D & ND Arrays | Core content |

Keep the current section boundaries and recently developed content. Consolidate repeated in-page navigation, distinguish repeated practice headings, retain all substantive explanations/examples and finish the instructional material before the final Footnotes group.

No assessment identity, assignment notebook, worked code, output or exercise variant is removed. `authoring/integration_cleanup/` records the original cells, exact edits, moves and URL/fragment compatibility.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Current Priority-Section Coverage (2026-10-17)

This coverage update describes the current notebooks and supersedes older pre-reorganization filename summaries below. Historical plans and verification records are retained.

| Reading | Developed content-section coverage |
| --- | --- |
| `0701_onedim.ipynb` | Executable allocation/index/update examples, index-state table, safe last access and guided bound repair; repair retained markup without discarding variants. |

Keep creation/access first, processing/sharing second and rectangular arrays third. Keep jagged arrays as extension reading. The repaired defaults/LINQ material remains in 0701.

All original lesson cells remain, except the explicitly documented presentation/syntax/result corrections and stale chapter references in `authoring/priority_development/source_corrections.json`. Original assignment notebooks and exercise IDs remain untouched. Full standalone code is retained beside the new smaller teaching cores; newly added code verification is recorded separately from historical checks.


## Landing Page

- `0700_arrays.ipynb` — Chapter landing page

## Section Notebooks

- `0701_onedim.ipynb` — One-dimensional arrays
- `0702_twodim.ipynb` — Two-dimensional arrays

## Assignments

- `assignments/index.ipynb` — Index
- `assignments/lab.ipynb` — Lab
- `assignments/preview.ipynb` — Preview
- `assignments/homework.ipynb` — Homework

## Notes

- Source examples live in `demos/` at the project root.
- Jagged arrays should be treated as applied extension material, not course core.

## Runnable Demo Projects

- [`demos/07/array_lab/`](../../demos/07/array_lab/README.md): Completed array lab algorithms.
- [`demos/07/arrays_demo/`](../../demos/07/arrays_demo/README.md): Command-line arrays, rectangular arrays, and jagged arrays.

All demo projects target .NET 10. Run commands and verification are documented
in `demos/README.md` and each project README.

Instructor support: [current lab walkthrough](../../instructor_support/labs/07_sales_lab.md). See its scope before treating a demo as an assignment answer.

## Restored CS1 Material (2026-10-17)

- `assignments/additional_practice.ipynb`: restored explanations and exercises; retains current lessons and assignment IDs.

The final source-list check also retains the original named array, reversal, and small abstract/interface variations in the corresponding supporting practice; see the preservation matrix for exact locations.

## Arrays and Collection Families (2026-10-17)

Landing pages and opening explanations explicitly classify arrays as collections and connect fixed-length indexed storage to lists, dictionaries, sets, and processing-order families. Chapter 7 develops array operations; Chapter 8 compares the broader families. Existing section order, examples, and assessments are unchanged.

## Section-Boundary Coverage Disposition (2026-10-17)

**Reviewed plan, now implemented:** Split the one-dimensional array lesson. The disposition below records the preimplementation baseline and rationale. See Implemented Reading Organization for the current reading files. Counts in this baseline exclude fenced code from prose; the refreshed inventory is in authoring/content_size/. They flag review needs, not quality scores.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `0701_onedim.ipynb`: 1D Arrays | Core content | 2,713 | 9 | 0 |
| `0702_twodim.ipynb`: 2D & ND Arrays | Core content | 1,598 | 13 | 7 |

### Source-to-Destination Plan

| Existing source | Proposed treatment and coverage to preserve |
| --- | --- |
| `0701` | Split after foundational creation/access/traversal: keep element types, allocation, initialization, defaults and index bounds in the first lesson. Put processing algorithms, arrays passed to methods, aliases and the command-line adder in the second, preserving all original examples. |
| `0702` | Retain rectangular arrays as the third lesson; keep jagged arrays as an explicitly labeled extension, not a replacement for core rectangular-array explanation. |

### Development Needed Before Moving Material

Develop sum/count/search or transformation traces and guided tasks before the processing page is separated. Explain reference copying before its method-side effects; use command-line tooling as an application rather than the definition of array processing.

Before a later move, create a cell-level preservation map for these sources, including citations, figures, original code forms, worked traces, guided questions and independent exercise variants. Relocate prerequisite explanations from assignments into content when needed while retaining application requirements and IDs. A consolidated page must still teach its concepts; a split must not create two unsupported outlines. Existing runnable verification records describe earlier work, not verification of this proposal.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `0701_onedim.ipynb`: Creating and Accessing Arrays.
- `0703_array_processing.ipynb`: Processing and Sharing Arrays.
- `0702_twodim.ipynb`: 2D & ND Arrays.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.


## Outcome Gap Repair (2026-10-17)

Preserve the current chapter notebooks, reading order, existing explanations, exercise variants, and assessment identifiers. The additions below close the outcome audit gaps within that organization. Explanations belong in content before independent application; earlier scaffolded tasks remain available.

| Location | Development or assessment |
| --- | --- |
| `0702_twodim.ipynb` | From One Row to a Table Summary |

Progression: read the relevant lesson and worked example, complete its guided practice, then attempt the added independent homework without copying the solution. Require contract-derived expected results, boundary evidence, and reasoning about the chosen representation or design. Assess process and explanation as well as output. Existing labs remain scaffolded applications rather than the sole evidence of independent mastery.

Lecture decks remain a separately tracked task. No additional chapter, meeting, or required optional-topic track is introduced.

### Verified Topic-to-Assessment Progression

| Topic/outcome | Explanation and worked example | Guided preparation | Independent evidence |
| --- | --- | --- | --- |
| Two-dimensional aggregation bridge | 0702_twodim: branch/day table, one-row and one-column standalone demo | Change fixed coordinate, add branch, then reset each outer-loop total | Existing independent branch-by-day lab retained intact; it is assessment, not a replacement for the guided bridge. |

Keep the original five-question coding tracks and smaller historical variations. Added transfer tasks complement them. Grade implementation, independently derived expected results, and the requested reasoning separately; correct output from a supplied class does not establish algorithm construction.


## CS1 Search and Sort Progression

The core reading `0704_searching_sorting_arrays.ipynb` (7.3, between Processing and Sharing Arrays and 2D & ND Arrays) teaches linear search, binary search, and insertion sort, combining the library calls with hand-written versions. No existing notebook or exercise is removed or renamed; the search/sort cells drafted inside `0703_array_processing.ipynb` were moved into 7.3 on 2026-10-18 so nothing is taught twice. `0702_twodim.ipynb` places its core row/column bridge before optional jagged arrays.

| Outcome | Explanation and worked example | Guided practice | Independent assessment |
| --- | --- | --- | --- |
| Sequential matching | Linear-search method/call syntax, indexed trace, first-match/-1 contract | FirstAtLeast matching-rule variation and boundary inputs | Last matching shipment, including duplicates and absence |
| Ordered lookup | Binary-search precondition, half-open bounds as in Chapter 16, midpoint trace, progress and duplicate policy; `Array.BinarySearch` sign test | Repair final-candidate defect; test endpoints and empty input | Invoice lookup with independent expected cases and missing-target trace |
| Ordering and preservation | Insertion-sort saved-item trace, shifts, in-place mutation and copy | Restore saved-item placement; check empty, singleton, reversed, and duplicate inputs | Descending stock report preserving original input and occurrences |

All three topics use purposeful state tables and standalone executable examples, output interpretation, common mistakes, and progressively more independent practice. Student methods assume non-null arrays; empty arrays are supported. Sorting changes positions, so a search result in a sorted copy is not an original arrival index.

Chapter 16 retains its full deeper treatment: result contracts, correctness/invariants, ordering policies and comparers, labeled-record stability, exact work counts, preparation/update costs, library contracts, and repeated-query choices. Do not remove that development as duplication of the CS1 introduction. The chapter landing objectives and glossary now reflect the introductory algorithms.

## Searching and Sorting Section (2026-10-18)

`0704_searching_sorting_arrays.ipynb` is core reading 7.3. It combines two drafts: a library-first page (search contract and sentinel, first-match linear search against `Array.IndexOf`, count and largest-element scans, `Array.Sort` on a clone with `StringComparer.Ordinal`, `Array.BinarySearch` with its sorted precondition and sign test, a halving table) and the hand-written algorithms drafted for 7.2 (binary search, insertion sort, three defect-repair guided practices, NIST footnotes). The hand-written binary search uses the half-open interval [low, high) so that Chapter 7 and Chapter 16 teach one convention. Labels `ch07-linear-search`, `ch07-binary-search`, and `ch07-insertion-sort` are kept for the homework. All 14 code cells compile and run standalone (.NET 10) with the outputs the prose states, including the deliberately defective starters.

## Legacy Page Development (2026-10-18)

`0701_onedim.ipynb` and `0703_array_processing.ipynb` were developed in place from the content-development audit. 7.1 Creating Arrays and Accessing Array Elements gained runnable worked examples (creation forms; index reads and assignments with the three loop forms and the `d[k + 1]` versus `d[k] + 1` distinction; `PrintStrings` and a returned-array `MakeCodes` standing in for keyboard input), a guided Double Every Slot practice, and a runnable defaults example; legacy indented code and REPL transcripts are now labeled fences. 7.2 Parameters to Main and the Command Line Adder gained browser-runnable versions that supply the argument array, and References and Aliases gained a runnable int-copy versus array-alias and `Scale` example; its two inline image fragments were repaired into figure directives. All 9 new code cells compile and run standalone (.NET 10).
