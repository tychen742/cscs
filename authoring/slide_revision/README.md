# Aligned lecture decks — 2026-10-21

Created 26 chapter decks with 1,399 slides. Each core part has goals, explanations, a worked case/trace, quick checks, practice tied to existing exercises, and a recap. All slides have instructor notes. Parts follow the current reading order and existing teaching-time allocation; supporting parts remain explicitly optional where applicable.

Chapter 1 now teaches responsibility, offline AI review, and the explicit Main workflow. Installation and Git remain appendix preparation. Later decks retain half-open search conventions, full sort-preservation checks, versioned priority dispatch, graph prerequisites, and the distinction between required work and optional timing/advanced readings.

Changes are uncommitted for author review. [Readable source and notebook diffs](review.diff) show new slide sources, landing links, planning changes, and build/staging utilities. Generated HTML and binary PowerPoints are listed below rather than expanded into the text diff. Displayed diff lines omit trailing whitespace; use Git for exact bytes.

## Verification

- All 89 standalone C# examples compiled independently for .NET 10 with warnings treated as errors, and actual stdout matched the independently specified output. `code_results.json` retains full source, inputs, compiler/run results, and hashes. Changed examples were rerun after formatting fixes; unchanged verified sources reused matching records.
- All 26 deck builds completed without overflow warnings at classroom font sizes. All 26 editable PowerPoint packages passed the shared Office validator, with hashes in `pptx_validation.json`. Chapter 1 was also opened in Microsoft PowerPoint.
- All 1,399 slides were rendered and visually reviewed using contact sheets; final code-fit, question-format, title, and dark-background contrast fixes were checked. Final browser bounds checks found no clipping in any deck; all local lesson and assignment links resolve. See `rendered_checks.json`, `render_results.json`, and `visual_*.json`.
- Every original tracked notebook's cell order, IDs, and metadata are retained across 339 notebooks. Only the existing slide-link cells change in chapter landings; assignment contents remain unchanged. The TOC and legacy Chapter 1 overview files are byte-for-byte unchanged. See `preservation_checks.json`.
- The full book build succeeded. Eight new MyST warnings were corrected by using direct HTML deck links. The final incremental build has no warnings; three pre-existing lexer warnings appeared in the initial full build. See `book_build.json`.

The deployment workflow now stages student assets with `scripts/stage_lecture_slides.py`, excluding Markdown sources and instructor PowerPoints. Student HTML omits notes and answers. No deployment or commit has been performed in this revision.

## Decks

| Chapter | Title | Slides | Student deck | Instructor deck |
| --- | --- | ---: | --- | --- |
| 1 | Computing, Programs, and Responsibility | 54 | [HTML](../../_html_extra/chapters/01_context/0100_slides.html) | [PowerPoint](../../assignments/slides/0100_slides.pptx) |
| 2 | Variables, Data Types, and Operators | 65 | [HTML](../../_html_extra/chapters/02_var_data/0200_slides.html) | [PowerPoint](../../assignments/slides/0200_slides.pptx) |
| 3 | Decisions | 33 | [HTML](../../_html_extra/chapters/03_decision/0300_slides.html) | [PowerPoint](../../assignments/slides/0300_slides.pptx) |
| 4 | Iteration | 57 | [HTML](../../_html_extra/chapters/04_iteration/0400_slides.html) | [PowerPoint](../../assignments/slides/0400_slides.pptx) |
| 5 | Methods | 83 | [HTML](../../_html_extra/chapters/05_methods/0500_slides.html) | [PowerPoint](../../assignments/slides/0500_slides.pptx) |
| 6 | Testing, Debugging, and Error Handling | 57 | [HTML](../../_html_extra/chapters/06_exceptions_testing/0600_slides.html) | [PowerPoint](../../assignments/slides/0600_slides.pptx) |
| 7 | Arrays | 67 | [HTML](../../_html_extra/chapters/07_arrays/0700_slides.html) | [PowerPoint](../../assignments/slides/0700_slides.pptx) |
| 8 | Collections | 73 | [HTML](../../_html_extra/chapters/08_collections/0800_slides.html) | [PowerPoint](../../assignments/slides/0800_slides.pptx) |
| 9 | Files and Text | 56 | [HTML](../../_html_extra/chapters/09_files_text/0900_slides.html) | [PowerPoint](../../assignments/slides/0900_slides.pptx) |
| 10 | Classes and Objects | 51 | [HTML](../../_html_extra/chapters/10_classes/1000_slides.html) | [PowerPoint](../../assignments/slides/1000_slides.pptx) |
| 11 | Object Design and Composition | 66 | [HTML](../../_html_extra/chapters/11_object_design/1100_slides.html) | [PowerPoint](../../assignments/slides/1100_slides.pptx) |
| 12 | Inheritance, Interfaces, and Polymorphism | 51 | [HTML](../../_html_extra/chapters/12_oop/1200_slides.html) | [PowerPoint](../../assignments/slides/1200_slides.pptx) |
| 13 | Abstract Data Types | 61 | [HTML](../../_html_extra/chapters/13_abstract_data_types/1300_slides.html) | [PowerPoint](../../assignments/slides/1300_slides.pptx) |
| 14 | Arrays and Linked Lists | 46 | [HTML](../../_html_extra/chapters/14_arrays_linked_lists/1400_slides.html) | [PowerPoint](../../assignments/slides/1400_slides.pptx) |
| 15 | Stacks, Queues, and Deques | 46 | [HTML](../../_html_extra/chapters/15_stacks_queues/1500_slides.html) | [PowerPoint](../../assignments/slides/1500_slides.pptx) |
| 16 | Searching and Basic Sorting | 36 | [HTML](../../_html_extra/chapters/16_searching_sorting/1600_slides.html) | [PowerPoint](../../assignments/slides/1600_slides.pptx) |
| 17 | Trees and Binary Search Trees | 61 | [HTML](../../_html_extra/chapters/17_trees/1700_slides.html) | [PowerPoint](../../assignments/slides/1700_slides.pptx) |
| 18 | Chapter 18: Priority Queues and Heaps | 46 | [HTML](../../_html_extra/chapters/18_priority_queues/1800_slides.html) | [PowerPoint](../../assignments/slides/1800_slides.pptx) |
| 19 | Chapter 19: Hash Collections and Sets | 46 | [HTML](../../_html_extra/chapters/19_hash_collections/1900_slides.html) | [PowerPoint](../../assignments/slides/1900_slides.pptx) |
| 20 | Chapter 20: Graphs and Traversal | 63 | [HTML](../../_html_extra/chapters/20_graphs/2000_slides.html) | [PowerPoint](../../assignments/slides/2000_slides.pptx) |
| 21 | Chapter 21: Algorithm Analysis | 46 | [HTML](../../_html_extra/chapters/21_algorithm_analysis/2100_slides.html) | [PowerPoint](../../assignments/slides/2100_slides.pptx) |
| 22 | Chapter 22: Recursion and Divide-and-Conquer | 31 | [HTML](../../_html_extra/chapters/22_recursion_divide_conquer/2200_slides.html) | [PowerPoint](../../assignments/slides/2200_slides.pptx) |
| 23 | Chapter 23: Advanced Searching and Sorting | 66 | [HTML](../../_html_extra/chapters/23_searching_sorting/2300_slides.html) | [PowerPoint](../../assignments/slides/2300_slides.pptx) |
| 24 | Chapter 24: Greedy Algorithms and Graph Optimization | 46 | [HTML](../../_html_extra/chapters/24_greedy_graph_optimization/2400_slides.html) | [PowerPoint](../../assignments/slides/2400_slides.pptx) |
| 25 | Chapter 25: Dynamic Programming and Backtracking | 46 | [HTML](../../_html_extra/chapters/25_dynamic_programming_backtracking/2500_slides.html) | [PowerPoint](../../assignments/slides/2500_slides.pptx) |
| 26 | Chapter 26: String Matching and Computational Limits | 46 | [HTML](../../_html_extra/chapters/26_advanced_graphs_strings_limits/2600_slides.html) | [PowerPoint](../../assignments/slides/2600_slides.pptx) |

## Rebuild and recheck

```sh
npm ci --ignore-scripts --prefix scripts/slides
.venv/bin/python scripts/build_lecture_slides.py
.venv/bin/python scripts/verify_slide_examples.py
.venv/bin/jupyter-book build . --builder html
.venv/bin/python scripts/stage_lecture_slides.py
.venv/bin/python scripts/verify_lecture_slides.py --html-dir _build/html
```

`verify_slide_examples.py --fresh` reruns all examples. The default reuses only matching successful source/input/output records. `verify_lecture_slides.py` checks evidence against current files; it does not execute C# or run the Office schema validator itself. For image rendering and the shared validator dependencies, see `scripts/slides/README.md`.
