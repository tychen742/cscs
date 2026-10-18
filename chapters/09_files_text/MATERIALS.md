# Chapter Materials — Files and Text

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `0901_stream_file.ipynb` | File Foundations: Reading and Writing | Core content |
| `0902_file_operations.ipynb` | File Workflows, Paths, and Resources | Core content |
| `0903_text_operations.ipynb` | Text Operations | Core content |
| `0906_regex.ipynb` | Regular Expressions | Supporting reading |
| `0905_privacy_security.ipynb` | Privacy and Security in Code | Optional reading |

Retain three core readings: file foundations, paths/resources, and text operations. Regex is explicitly Supporting Reading and privacy explicitly Optional Reading in the TOC, matching their supporting roles. Keep the recent standalone path/resource examples. No recombination of these developed lessons is performed.

No assessment identity, assignment notebook, worked code, output or exercise variant is removed. `authoring/integration_cleanup/` records the original cells, exact edits, moves and URL/fragment compatibility.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Current Priority-Section Coverage (2026-10-17)

This coverage update describes the current notebooks and supersedes older pre-reorganization filename summaries below. Historical plans and verification records are retained.

| Reading | Developed content-section coverage |
| --- | --- |
| `0902_file_operations.ipynb` | Standalone temporary-directory workflow, Path.Combine/using syntax, resource timeline, deterministic unavailable-input check and guided append variation. |

Keep file foundations, paths/resources and text operations in the current order. Regex and privacy remain supporting readings. Teach scope/disposal in content before an import or export lab.

All original lesson cells remain, except the explicitly documented presentation/syntax/result corrections and stale chapter references in `authoring/priority_development/source_corrections.json`. Original assignment notebooks and exercise IDs remain untouched. Full standalone code is retained beside the new smaller teaching cores; newly added code verification is recorded separately from historical checks.


## Landing Page

- `0900_files_text.ipynb` — Chapter landing page

## Section Notebooks

- `0901_stream_file.ipynb` — Streams and file basics
- `0902_file_operations.ipynb` — File read / write operations
- `0903_text_operations.ipynb` — Text processing: splitting, token validation, safe replacement, structured records. Basic string methods (cleaning, immutability, searching, `Substring`, `Replace`) moved to `05_methods/0504_strings.ipynb` on 2026-10-04.
- `0906_regex.ipynb` — Regular expressions

## Assignments

- `assignments/hw_gradefiles.ipynb` — Hw Gradefiles
- `assignments/index.ipynb` — Index
- `assignments/lab.ipynb` — Lab
- `assignments/preview.ipynb` — Preview
- `assignments/homework.ipynb` — Homework

## Notes

- Source examples live in `demos/` at the project root.
- Clean up section headings in `0902_file_operations.ipynb` so StreamWriter, StreamReader, paths, and directories appear as coherent subsections rather than competing notebook-level titles.

## Runnable Demo Projects

- [`demos/09/file_demo/`](../../demos/09/file_demo/README.md): Read a bundled file of integers.

All demo projects target .NET 10. Run commands and verification are documented
in `demos/README.md` and each project README.

## Integrated Responsibility Practice (2026-10-15)

Optional `0905_privacy_security.ipynb` extends personal-data masking, validation, and safe logging. Retained `assignments/privacy_index.ipynb`, `privacy_preview.ipynb`, `privacy_lab.ipynb`, and `privacy_homework.ipynb` preserve former ethics assessments and IDs. Source reference: `demos/09/privacy_pass_lab_solution.cs`. SQL injection demonstration now lives in the database appendix.

## AI Literacy Integration (2026-10-15)

The text-processing lesson adds a prepared AI-review activity for a synthetic stock import: specify the schema, reject malformed/out-of-range records, and preserve original input. Prompt privacy and response validation accompany the code. Live assistant use is optional and subject to course policy.

## Restored CS1 Material (2026-10-17)

- `assignments/additional_practice.ipynb`: restored explanations and exercises; retains current lessons and assignment IDs.
- `assignments/help_responses.ipynb`: restored explanations and exercises; retains current lessons and assignment IDs.

The file-driven collections lab follows Files; Chapter 8 links forward to it. Downloadable starter: `demos/09/help_responses_lab.zip`.

## Section-Boundary Coverage Disposition (2026-10-17)

**Reviewed plan, now implemented:** Recombine file basics; integrate thin regex orientation. The disposition below records the preimplementation baseline and rationale. See Implemented Reading Organization for the current reading files. Counts in this baseline exclude fenced code from prose; the refreshed inventory is in authoring/content_size/. They flag review needs, not quality scores.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `0901_stream_file.ipynb`: Files As Streams | Core content | 834 | 8 | 1 |
| `0902_file_operations.ipynb`: `StreamWriter` | Core content | 2,329 | 15 | 5 |
| `0903_text_operations.ipynb`: Text Operations | Core content | 559 | 17 | 9 |
| `0906_regex.ipynb`: Regular Expressions | Supporting reading | 297 | 13 | 8 |
| `0905_privacy_security.ipynb`: Privacy and Security in Code | Supporting reading | 696 | 20 | 4 |

### Source-to-Destination Plan

| Existing source | Proposed treatment and coverage to preserve |
| --- | --- |
| `0901` | Combine streams/file lifecycle and simple File-class operations with initial read/write material from 0902. |
| `0902` | Split its duties: basic read/write joins file foundations; StreamReader/Writer lifecycle, paths/directories and failure/cleanup form the workflow lesson. Preserve all examples and path variants. |
| `0903` | Retain text tokenization/schema validation and AI import review as the final core lesson; integrate a small regex-versus-string comparison after the same text problem is understood. |
| `0906` | Use the introductory regex explanations in the text lesson; retain the full regex examples/groups/replacement practice as a linked supporting reading at the existing URL. Expand that reading if it is later taught independently. |
| `0905` | Keep privacy/security and legacy privacy assessments as optional reinforcement. |

### Development Needed Before Moving Material

Develop malformed-record handling, partial processing, resource cleanup and a sustained worked import. Do not let moving regex examples substitute for explanation of patterns and groups.

Before a later move, create a cell-level preservation map for these sources, including citations, figures, original code forms, worked traces, guided questions and independent exercise variants. Relocate prerequisite explanations from assignments into content when needed while retaining application requirements and IDs. A consolidated page must still teach its concepts; a split must not create two unsupported outlines. Existing runnable verification records describe earlier work, not verification of this proposal.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `0901_stream_file.ipynb`: File Foundations: Reading and Writing.
- `0902_file_operations.ipynb`: File Workflows, Paths, and Resources.
- `0903_text_operations.ipynb`: Text Operations.
- `0906_regex.ipynb`: Regular Expressions.
- `0905_privacy_security.ipynb`: Privacy and Security in Code.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.


## Outcome Gap Repair (2026-10-17)

Preserve the current chapter notebooks, reading order, existing explanations, exercise variants, and assessment identifiers. The additions below close the outcome audit gaps within that organization. Explanations belong in content before independent application; earlier scaffolded tasks remain available.

| Location | Development or assessment |
| --- | --- |
| `0903_text_operations.ipynb` | Repair stale prerequisite cross-reference. |
| `privacy_lab.ipynb` | Repair stale prerequisite cross-reference. |
| `0903_text_operations.ipynb` | Custom `out` definitions are now taught in 5.2 (parameter notebook); retain the record-parser worked example and later independent parsing tasks. |

Progression: read the relevant lesson and worked example, complete its guided practice, then attempt the added independent homework without copying the solution. Require contract-derived expected results, boundary evidence, and reasoning about the chosen representation or design. Assess process and explanation as well as output. Existing labs remain scaffolded applications rather than the sole evidence of independent mastery.

Lecture decks remain a separately tracked task. No additional chapter, meeting, or required optional-topic track is introduced.

### Verified Topic-to-Assessment Progression

| Topic/outcome | Explanation and worked example | Guided preparation | Independent evidence |
| --- | --- | --- | --- |
| Custom out parser prerequisite | Chapter 5 parameter lesson precedes 0903_text_operations; local link now explicit | Existing parser worked example and record practice | Retained parser homework can rely on an already explained output-parameter contract; stale string-method reference corrected to 5.4. |

Keep the original five-question coding tracks and smaller historical variations. Added transfer tasks complement them. Grade implementation, independently derived expected results, and the requested reasoning separately; correct output from a supplied class does not establish algorithm construction.


## Subsection Integration (2026-10-17)

This is the current internal teaching order for the repaired pages. Earlier outlines remain historical where they differ. Chapter/section notebook order is unchanged. All original explanations, examples, exercises, code outputs, assessment identifiers, and link destinations are retained.

### `0901_stream_file.ipynb`

- File Stream
  - File handling process
  - The `System.IO` namespace
  - Directory path
- Simple File Handling: `File` Class
- `StreamWriter`
  - Writing Files
- `StreamReader`
  - Reading to End of Stream

### `0902_file_operations.ipynb`

- Run a Complete File Lifetime in an Owned Workspace
- Predict Append and Missing-Input Outcomes
- Separate a File's Location from Its Contents
  - Path Strings
  - Paths in C\#
  - The Directory Class
- Bound Resource Lifetime Explicitly

Treat syntax, examples, and meaningful variations as children of their conceptual topic. Place prerequisite explanations before application, and distinguish a local checkpoint from later synthesis. Preserve distinct older/newer treatments by grouping them rather than deleting them. Keep the final Footnotes group after instructional content.

## Legacy Page Development (2026-10-18)

`0901_stream_file.ipynb` gained a Console-versus-file method comparison table in File Stream, labeled fences for the File-class transcripts, and a runnable `File.WriteAllText`, `AppendAllText`, `ReadAllText`, `Exists`, `Delete` example in an owned temporary location with interpretation; two unlabeled fences were labeled. `0902_file_operations.ipynb` gained runnable `Path` helper, `Directory` listing, and partial-output resource-lifetime examples (the last runs the page's guided scenario: two lines written, the third fails, the report is partial) and a fenced using-declaration pattern. All 4 new code cells compile and run standalone (.NET 10) and clean up after themselves.

## Caption-Only Section Development (2026-10-18)

Pass 3 of the content-development audit: in 9.3 Splitting and Tokenizing gained the `Split` pattern and interpretation after each of its three cells (including the index-shift hazard of RemoveEmptyEntries on fixed-format records), Safe Replacement gained a sentence per step and the `Replace` pattern, Structured Lines gained an explanation of the TryParse-shaped parser and interpretation of the four results, and When to Use a Database gained a text-file-versus-database comparison table. No code changed; cells were rerun to confirm outputs.

## Guided Practice Pass (2026-10-18)

Pass 4 of the content-development audit (`authoring/content_development_audit/`): added mid-page guided practices with solutions to 9.1 (write a receipt and read it back, whose starter demonstrates the forgotten Close) and the optional 9.5 (mask a card number). Every new starter and solution compiles and runs standalone (.NET 10); starters that are meant to fail say so in their task text. No existing cell, heading, or exercise ID was removed.

## Visual Support and Part I Shape (2026-10-18)

Pass 6 of the content-development audit (`authoring/content_development_audit/`): 9.5 gained a table mapping the collect-less, show-less, keep-less habits to the code on the page. New code cells compile and run standalone (.NET 10); tables and text diagrams are placed beside the example they explain. No heading, cell ID, or exercise ID changed.
