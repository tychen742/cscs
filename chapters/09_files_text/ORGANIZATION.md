# Chapter Organization — Files and Text

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

Teach the section conceptual framework before detailed application; place syntax prerequisites before reasoning that requires them. Keep the new worked traces and guided checkpoints, followed by existing lab/homework transfer. Reading count does not set a meeting or word quota.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Current B-A Teaching Progression (2026-10-17)

This is the current progression within the existing section order; earlier meeting outlines below are historical where they conflict. Readings are not additional required meetings.

Keep file foundations, paths/resources and text operations in the current order. Regex and privacy remain supporting readings. Teach scope/disposal in content before an import or export lab.

| Reading | Developed content-section coverage |
| --- | --- |
| `0902_file_operations.ipynb` | Standalone temporary-directory workflow, Path.Combine/using syntax, resource timeline, deterministic unavailable-input check and guided append variation. |

**Conceptual framework:** motivate the result contract and connect the new operation to prior control flow, state, representation or algorithm ideas.

**Subsection development:** use the new small trace and standalone worked example before the complete retained implementation. Interpret the saved output, vary an assumption and diagnose a plausible mistake. Syntax scaffolds are patterns, not hidden executable prerequisites.

**Practice progression:** Run an owned temporary-directory workflow; predict append versus overwrite; distinguish missing input from invalid rows. Transfer to the existing file/grade import assignments, preserving their IDs and tasks.

Keep prerequisite explanations in these content sections. Labs apply the explained ideas and may scaffold the task; homework increases transfer. No existing explanation, exercise variation, assignment identity or independent-work requirement is removed to fit a time or word quota.


## Learning Objectives

1. Choose file modes and paths and distinguish resource failures from invalid records.
2. Use streams with a deliberate disposal lifetime and interpret read/write output.
3. Parse and validate text records before applying them; keep regex and privacy as supporting extensions.

## Sequence

- Streams and file basics
- File read / write operations
- Text processing
- Regular expressions

## Notes

- The active coverage is sound: streams/file basics, read/write operations, text processing, and regular expressions.
- Clean up the file-operations notebook structure before polishing objectives or glossary terms.

## Integrated Responsibility Practice (2026-10-15)

Optional `0905_privacy_security.ipynb` extends personal-data masking, validation, and safe logging. Retained `assignments/privacy_index.ipynb`, `privacy_preview.ipynb`, `privacy_lab.ipynb`, and `privacy_homework.ipynb` preserve former ethics assessments and IDs. Source reference: `demos/09/privacy_pass_lab_solution.cs`. SQL injection demonstration now lives in the database appendix.

## AI Literacy Integration (2026-10-15)

The text-processing lesson adds a prepared AI-review activity for a synthetic stock import: specify the schema, reject malformed/out-of-range records, and preserve original input. Prompt privacy and response validation accompany the code. Live assistant use is optional and subject to course policy.

## Reliability Progression (2026-10-16)

Revisit Chapter 6 with missing files, malformed records, specific recoverable exceptions, and deterministic cleanup with using. Distinguish invalid records from unavailable resources. This is the current teaching plan; this structural pass does not claim a new practice or assessment implementation.

## Restored CS1 Material (2026-10-17)

- `assignments/additional_practice.ipynb`: restored explanations and exercises; retains current lessons and assignment IDs.
- `assignments/help_responses.ipynb`: restored explanations and exercises; retains current lessons and assignment IDs.

The file-driven collections lab follows Files; Chapter 8 links forward to it. Downloadable starter: `demos/09/help_responses_lab.zip`.

## Section-Boundary Review (2026-10-17)

**Status: implemented.** The following records the reviewed recommendation and its baseline. See Implemented Reading Organization below for the final current filenames and order; earlier meeting allocations are historical where they conflict.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `0901_stream_file.ipynb`: Files As Streams | Core content | 834 | 8 | 1 |
| `0902_file_operations.ipynb`: `StreamWriter` | Core content | 2,329 | 15 | 5 |
| `0903_text_operations.ipynb`: Text Operations | Core content | 559 | 17 | 9 |
| `0906_regex.ipynb`: Regular Expressions | Supporting reading | 297 | 13 | 8 |
| `0905_privacy_security.ipynb`: Privacy and Security in Code | Supporting reading | 696 | 20 | 4 |

**Recommendation:** Recombine file basics; integrate thin regex orientation.

0901 introduces File operations that overlap 0902, while 0902 has competing top-level titles. 0903 and the 297-word regex page need a connected text-processing development rather than two thin API tours.

### Proposed Reading Sequence

1. File model and basic reading/writing.
2. Paths, streaming workflows, failure handling, and cleanup.
3. Text records, validation, and pattern-based processing.

### Adequacy Before Reorganization

Develop malformed-record handling, partial processing, resource cleanup and a sustained worked import. Do not let moving regex examples substitute for explanation of patterns and groups.

Retain the supporting readings identified above outside the required core. Reading sections and class meetings are different units; allocate discussion and practice after developing adequate explanations. Do not reduce distinct material to meet a section or word quota.

Preserve every existing explanation, exercise variation and assessment identity. The source-to-destination dispositions in MATERIALS.md govern any later move. Update TOC, links and redirects only in an authorized implementation pass.

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

9.1 and 9.2 keep their order. Each previously code-free section (File Stream, Paths in C#, The Directory Class, Bound Resource Lifetime Explicitly) now has a worked example or a comparison table, and the File-class section has a modern top-level example beside the project form.
