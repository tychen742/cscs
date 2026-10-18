---
orphan: true
---

# Content-section development audit (B-A) — October 18, 2026

Scope: the 95 content notebooks listed in `_toc.yml` for Chapters 1 to 26
(core and supporting readings), at main commit 32e46c1d. Landing pages,
assignments, part overviews, and appendices are excluded. Audit only: no
notebook was changed.

Standard applied: the book-authoring skill's section rules. Each `##`
section should carry an explanation, the general syntax when a construct is
introduced (labeled as a pattern), a verified worked example with its output
interpreted, meaningful variations and common mistakes, and guided practice,
with visual support where it clarifies. The skill calls this a flexible
framework, not a checklist, so a purely conceptual section is not a gap.

Method: a scripted scan of every section (prose words outside code fences,
runnable cells, starter and solution cells, syntax pattern blocks, tables and
figures, practice and mistake wording, whether prose follows code) plus
reading of every flagged section in Chapters 4, 6, 8, 9, 10, 13, 14, and 16
to confirm the pattern. Counts are triage aids, not quality scores. Per-page
detail is in `findings.json`. A separate folder, `authoring/ba_development_audit/`,
appeared untracked at 22:55 while this scan ran, holding a cell inventory and
no findings; it is another session's work and was not used here.

## Book-wide picture

| Part | Pages | `##` sections | With code | With practice | Code with caption only | Long prose, no example | Pages with no practice |
| --- | ---: | ---: | ---: | ---: | ---: | ---: | ---: |
| I. Fundamentals (1-6) | 23 | 142 | 60% | 19% | 8 | 31 | 8 |
| II. Data and I/O (7-9) | 13 | 75 | 61% | 25% | 8 | 14 | 2 |
| III. OOP (10-12) | 13 | 73 | 60% | 30% | 5 | 6 | 2 |
| IV. Linear structures (13-16) | 13 | 123 | 47% | 16% | 18 | 9 | 1 |
| V. Trees, hashing, graphs (17-20) | 14 | 78 | 73% | 29% | 1 | 4 | 0 |
| VI. Analysis and design (21-23) | 10 | 70 | 77% | 34% | 2 | 3 | 0 |
| VII. Optimization and limits (24-26) | 9 | 73 | 67% | 30% | 4 | 4 | 0 |
| All | 95 | 634 | 62% | 25% | 46 | 71 | 13 |

"Code with caption only" is a section whose code cell is introduced by fewer
than 60 words and followed by no interpretation. "Long prose, no example" is a
non-practice section of more than 220 words with no runnable cell; many are
legitimately conceptual, and the lists below name only the ones that teach a
construct or algorithm.

Every page has the `{contents}` directive and a Footnotes block. The developed
openings added in October (the first section of most pages in Chapters 5 to 26)
are consistently strong: problem first, trace table, guided check. The gaps are
in what follows them.

## Must fix

### M1. Code shown with a caption instead of an explanation (46 sections)

The section introduces a cell with one sentence and nothing reads the output.
Worst cases, with words of prose around the code:

- `13_abstract_data_types/1303_generics.ipynb`: Generic Methods (0 words) and
  Generic Classes (0 words) are code cells alone under a heading.
- `06_exceptions_testing/0601_error_handling.ipynb`: Basic `try`/`catch`/`finally`
  (8), File I/O with Safe Handling (7), Throwing Exceptions Intentionally (22),
  Prefer `TryParse` for User Input (36). These are the chapter's core syntax
  and have no general-syntax block, no trace of control flow, and no output
  interpretation; the developed opening section explains the ideas but the
  construct sections do not.
- `14_arrays_linked_lists/1402_linked_nodes.ipynb`: Nodes and References (32),
  Traversal (25), Insertion After a Node (34), Deletion After a Node (17).
  `1401_dynamic_arrays.ipynb`: Contiguous Storage (43), Resizing by Copying
  (54), Worked Example (23). `1403_comparison_lab.ipynb`: Array Search and
  Indexing (21), Linked Traversal (14), Middle Insertion Costs (31). The
  developed trace sections later on each page explain the ideas, but the
  code that students run comes first with almost no words.
- `10_classes/1003_class_instance.ipynb`: Give Each Instance Its Own State
  (49), Properties Describe the Public Surface (77), Calculate Behavior from
  State (55), none with output interpretation.
- `11_object_design/1104_nullability.ipynb`: Nullable Value Types (28),
  Nullable Reference Types (27), Pattern Matching and Null (6).
- `09_files_text/0903_text_operations.ipynb`: Splitting and Tokenizing (41
  words for 4 cells), Safe Replacement Strategy (22), Structured Lines (23).
- `05_methods/0504_strings.ipynb`: Searching (25), Extracting Part of a String
  (40), Replacing Text (19).
- Supporting readings in the same state: `09_files_text/0906_regex.ipynb`
  (five sections of 4 to 11 words) and `12_oop/1204_oop_examples.ipynb`
  (three sections of 54 to 100 words with no interpretation).

Repair shape: for each, add the general syntax as a labeled pattern, two or
three sentences on what the cell does and why, the expected output and what
to notice in it, and one variation or mistake. Part IV needs this most.

### M2. Constructs explained in prose with no runnable worked example

These sections teach syntax through legacy indented code blocks, so students
cannot run or vary the example, and the blocks render without C# highlighting:

- `10_classes/1002_properties.ipynb`: the Properties section is 1,241 words
  with 18 indented blocks and no runnable cell, and still carries the note
  "this section will be updated later to reflect the more current syntax".
  This is the only stale authoring note left in the content pages.
- `10_classes/1001_class_syntax.ipynb`: Declaring Classes (234 words), Using a
  Class (263), Constructors (430), Static Classes and Methods (195), all
  without a runnable cell; the page's five code cells are in the last two
  sections.
- `07_arrays/0701_onedim.ipynb`: Creating Arrays (498) and Accessing Array
  Elements (765) have no runnable cell; the page has two cells in total.
  `0703_array_processing.ipynb`: Parameters to Main (916 words) and References
  and Aliases (342) are legacy prose with indented code.
- `04_iteration/0404_gcd.ipynb` (supporting): four GCD methods described in
  2,000 words with one runnable cell at the end.
- `09_files_text/0901_stream_file.ipynb`: File Stream (429 words, no code);
  `0902_file_operations.ipynb`: Separate a File's Location from Its Contents
  (1,032 words, code only in unlabeled fences).
- `06_exceptions_testing/0603_testing.ipynb`: Framework Setup and Test
  Attributes is 2,784 words with no runnable cell. Test projects cannot run in
  the browser, so the fix is a labeled pattern plus a downloadable project,
  not a cell.

Repair shape: convert one block per section into a standalone runnable cell
with output, keep the schematic form as a labeled ```csharp pattern, and
delete the stale note in 1002.

### M3. Guided practice is rare and usually last

158 of 634 sections (25%) carry practice; the standard asks for one per
section with essential content. The specific gaps:

- 13 pages have no practice at all: `0101_cs_ideas`, `0102_computing_responsibility`,
  `0201_variables_types`, `0203_input_output`, `0301_intro_decision`,
  `0401_iteration`, `0404_gcd`, `0605_software_responsibility`,
  `0901_stream_file`, `0905_privacy_security`, `1002_properties`,
  `1204_oop_examples`, `1403_comparison_lab` (its "Lab Tasks" section is a
  list without starter cells).
- 21 more pages have practice only as the final section, so a student meets
  no checkpoint while reading: most of Part IV and the earlier CS2 pages
  (`1501`, `1502`, `1503`, `1702`, `1703`, `1704`, `1803`, `2001`, `2002`,
  `2101`, `2102`, `2103`, `2201`, `2301`, `2302`, `2401`, and others).
- 9 "Exercise" sections are code only, with no prose stating the task or the
  expected result (`1501_stack`, `1502_queue_deque`, `1503_applications_lab`,
  `1704_tree_traversal`, `1702_binary_search_trees`, `1703_tree_lab`,
  `1803_priority_applications`, and two in Chapter 21 to 24). The task lives
  in a `// Exercise:` comment inside the starter.
- The two conceptual pages of Chapter 1 and `0605` have no reflection or
  check-your-understanding prompts; a non-code practice form is appropriate
  there.

Repair shape: one short guided practice (starter cell with "Your code starts
here", solution cell, stated expected output) after each page's main
construct, not only at the end; a sentence of task text above every existing
code-only Exercise.

## Should fix

### S1. Legacy code formatting (60 indented blocks, 16 unlabeled fences)

Indented and unlabeled code renders without C# highlighting and is not
distinguished from runnable cells or labeled patterns. Concentrated in
`1002_properties` (18 + 5), `0701_onedim` (9 + 4), `1001_class_syntax` (8),
`0302_ifstatement` (5 + 2), `0702_twodim` (4), `0703_array_processing` (4),
`0901_stream_file` (3 + 1), `0403_while_statement` (3), `0902_file_operations`
(3 unlabeled), `0404_gcd` (2), `0502_signature_call` (2). A mechanical pass
can convert these to ```csharp fences; M2 decides which become runnable.

### S2. Common mistakes are missing from most pages

36 pages have no mistake, pitfall, or defect discussion by wording, including
every page of Chapters 17, 20, 21, and most of 22 to 26, and the construct
pages `0201`, `0203`, `0301`, `0402`, `0702`, `0802`, `1001`, `1002`, `1201`,
`1202`. The developed opening sections often contain a defect trace; the
construct sections that follow rarely do. Pair one named mistake with the
example it explains in each construct section.

### S3. Output is not interpreted in developed CS2 pages

In pages that are otherwise well developed, the explanation precedes the code
and nothing follows it: `1602_basic_sorting` (7 of 13 sections),
`1702_binary_search_trees` (2), `1703_tree_lab` (2), `2002_adjacency_representations`
(2), `1902_dictionaries_sets` (2), `2404_shortest_paths` (2), `1003`, `1204`.
Add two or three sentences after each cell saying what the printed result
shows and what would change under a variation.

### S4. No visual support on 10 pages

`0401_iteration`, `0404_gcd`, `0905_privacy_security`, `1002_properties`,
`1003_class_instance`, `1004_averager`, `1101_objects_references`,
`1703_tree_lab`, `2001_graph_vocabulary`, `2304_advanced_sorts`. Reference
and object pages (1003, 1101) need an object-reference diagram; 2001 needs a
drawn graph; the loop pages need a trace table.

### S5. Part I construct pages lean on reference tables instead of examples

`0202_operators_built_in_methods` has 679 words of operator reference table
and 510 words of operator types with no runnable cell before Operation
Examples; `0301_intro_decision` has three no-code sections before its first
cell; `0401_iteration` ends with a 413-word Loop Planning Rubric and has no
practice. These are the earliest construct pages students read and the ones
most likely to need the syntax-first, example-second shape.

## Could defer

- Supporting readings `0906_regex`, `1204_oop_examples`, `2304_advanced_sorts`
  are thin but labeled supporting; fix after the core pages.
- Summary sections exist on 15 pages and not others; the project convention
  (Footnotes block) is met everywhere, so this is consistency only.
- Exercise numbering and difficulty labels (*(basic)*, *(applied)*) from the
  skill's exercise rules are not used anywhere in the book; adopt only if the
  grading flow wants them.

## Proposed repair passes

1. Mechanical formatting: convert indented and unlabeled code to labeled
   fences; delete the 1002 stale note (S1).
2. Chapters 10 and 7 legacy pages: runnable worked examples for 1001, 1002,
   0701, 0703, then 0404, 0901, 0902 (M2).
3. Part IV caption-only sections: 1401, 1402, 1403, 1303, then 0601, 1003,
   1104, 0903, 0504 (M1).
4. Guided practice pass: one mid-page checkpoint per page, task text on every
   code-only Exercise, reflection prompts on 0101, 0102, 0605 (M3).
5. Mistakes and interpretation pass across Parts V to VII (S2, S3).
6. Visuals (S4) and Part I shape (S5).
7. Full build and standalone compile of every new cell after each pass.

Each pass keeps existing cell IDs, exercise IDs, headings, and anchors, and
records its changes in the chapter's MATERIALS.md and ORGANIZATION.md.
