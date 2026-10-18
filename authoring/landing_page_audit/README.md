# Chapter landing-page compliance audit — October 17, 2026

All 26 numbered chapter landing pages were checked. None fully complies with the current B-A landing-page standard. This is an audit only: no teaching notebooks, exercises, or chapter organization were changed.

## What was checked

Compared landing source, current TOC content order, content-section headings/scope and chapter planning documents; inspected the existing local HTML build for all 26 pages. Checked orientation bullets, measurable numbered objectives, heading order, content-only Chapter Flow, glossary rendering, video embed metadata and lecture-deck links. Content scope was used to identify stale promises, not to repeat a full pedagogical audit of every section. Counts below are rendered table rows, not a recommended vocabulary quota. Video availability/playback and runtime were not externally verified; no URLs were changed. No new build or visual screenshot review was performed because this pass changed no book source.

## Required fixes across the book

- **26/26:** no linked chapter lecture deck. Some pages explicitly acknowledge pending media; this is unfinished compliance, not evidence of missing teaching content.
- **26/26:** Chapter Flow lacks the specified `chapter-flow` container. All 26 nevertheless list their local content sections in TOC order.
- **8 chapters have malformed glossaries:** 13 concatenates two rows; 20–26 show continuation rows as literal pipe text.
- **6 chapters use the wrong glossary columns:** 11, 12, 16, 18, 19, 20.
- **4 need substantial orientation/objective revision:** 16, 18, 19, 20 repeat generic template language despite specific developed content.
- **5 have no embedded video:** 1, 11, 16, 19, 20. All 21 existing embeds lack iframe titles and nearby runtimes, and use ordinary YouTube domains rather than privacy-enhanced embeds. Existing creator links and ownership notes are present; metadata repair does not require changing video IDs.
- **9 omit the prescribed objectives opening sentence:** 11, 12, 16, 18, 19, 20, 21, 22, 23. Chapters 16, 18, 19, 20 also use unnumbered objectives.
- **5 include assignments in Chapter Flow:** 2, 16, 18, 19, 20. Cross-chapter review notes in 6 and 26 need their own paragraph after the list rather than joining its last item.
- **7 retain landing-page index directives:** 3, 4, 7, 8, 9, 10, 13. Remove these from orientation pages.

## Scope/alignment findings

Chapter 14 still promises binary-search/stable-reporting instruction relocated to Chapter 16. Chapter 11 says three notebooks even though its current sequence has four core readings plus supporting nullability. Chapter 16 says three lessons but has two; Chapter 20 says three but has four. Chapter 26’s retained video is a graph prerequisite review, not an introduction to its main concepts; replacement requires author approval under B-A. Chapter 9 should distinguish optional regex outcomes from core completion goals.

## Flexible improvements

Do not add glossary terms simply to reach a count, or cut measurable objectives merely to reach 4–5. Rebuild vocabulary from what each content section actually teaches. Particularly useful candidates to verify/include are string operations and method contracts (5), regression testing and diagnostics (6), aliasing/copying (7), collection access verbs (8), paths/resource lifetime/token validation (9), nullability and ownership (11), search result policies and stable snapshots (16), heap invariants and count/capacity (18), key equality and multiplicity (19), representation/density/path terminology (20), and exact/heuristic/resource-limit results (26). Keep full chapter titles on the page; sidebar abbreviations should remain navigation labels.

## Chapter-by-chapter findings

### 1. Computing, Programs, and Responsibility

Source: `chapters/01_context/0100_getting_started.ipynb`. Rendered glossary rows: 50. Local content links match TOC order: yes.

- No embedded chapter video.
- No linked chapter lecture deck; supply the chapter deck after the glossary.
- Chapter Flow has no chapter-flow container.
- Chapter video and lecture deck explicitly pending.

### 2. Variables & Types

Source: `chapters/02_var_data/0200_variables_types.ipynb`. Rendered glossary rows: 21. Local content links match TOC order: yes.

- Video metadata: add runtime and a descriptive iframe title; use the privacy-enhanced embed when possible.
- No linked chapter lecture deck; supply the chapter deck after the glossary.
- Chapter Flow has no chapter-flow container.
- Chapter Flow includes an assignment (Tracing and Expression Practice); move its link outside the content-only flow.

### 3. Conditionals

Source: `chapters/03_decision/0300_conditionals.ipynb`. Rendered glossary rows: 12. Local content links match TOC order: yes.

- Remove the landing-page index directive; subject entries belong at teaching locations.
- Video metadata: add runtime and a descriptive iframe title; use the privacy-enhanced embed when possible.
- No linked chapter lecture deck; supply the chapter deck after the glossary.
- Chapter Flow has no chapter-flow container.

### 4. Iteration

Source: `chapters/04_iteration/0400_iteration.ipynb`. Rendered glossary rows: 14. Local content links match TOC order: yes.

- Remove the landing-page index directive; subject entries belong at teaching locations.
- Video metadata: add runtime and a descriptive iframe title; use the privacy-enhanced embed when possible.
- No linked chapter lecture deck; supply the chapter deck after the glossary.
- Chapter Flow has no chapter-flow container.

### 5. Methods

Source: `chapters/05_methods/0500_methods.ipynb`. Rendered glossary rows: 12. Local content links match TOC order: yes.

- Video metadata: add runtime and a descriptive iframe title; use the privacy-enhanced embed when possible.
- No linked chapter lecture deck; supply the chapter deck after the glossary.
- Chapter Flow has no chapter-flow container.

### 6. Testing, Debugging, and Error Handling

Source: `chapters/06_exceptions_testing/0600_exceptions_testing.ipynb`. Rendered glossary rows: 13. Local content links match TOC order: yes.

- Video metadata: add runtime and a descriptive iframe title; use the privacy-enhanced embed when possible.
- No linked chapter lecture deck; supply the chapter deck after the glossary.
- Chapter Flow has no chapter-flow container.

### 7. Arrays

Source: `chapters/07_arrays/0700_arrays.ipynb`. Rendered glossary rows: 14. Local content links match TOC order: yes.

- Remove the landing-page index directive; subject entries belong at teaching locations.
- Video metadata: add runtime and a descriptive iframe title; use the privacy-enhanced embed when possible.
- No linked chapter lecture deck; supply the chapter deck after the glossary.
- Chapter Flow has no chapter-flow container.

### 8. Data Collections

Source: `chapters/08_collections/0800_data_collections.ipynb`. Rendered glossary rows: 26. Local content links match TOC order: yes.

- Remove the landing-page index directive; subject entries belong at teaching locations.
- Video metadata: add runtime and a descriptive iframe title; use the privacy-enhanced embed when possible.
- No linked chapter lecture deck; supply the chapter deck after the glossary.
- Chapter Flow has no chapter-flow container.

### 9. Files and Text

Source: `chapters/09_files_text/0900_files_text.ipynb`. Rendered glossary rows: 14. Local content links match TOC order: yes.

- Remove the landing-page index directive; subject entries belong at teaching locations.
- Video metadata: add runtime and a descriptive iframe title; use the privacy-enhanced embed when possible.
- No linked chapter lecture deck; supply the chapter deck after the glossary.
- Chapter Flow has no chapter-flow container.
- Separate core outcomes from optional regex supporting-reading outcomes so requirements remain clear.

### 10. Classes and Objects

Source: `chapters/10_classes/1000_classes.ipynb`. Rendered glossary rows: 12. Local content links match TOC order: yes.

- Remove the landing-page index directive; subject entries belong at teaching locations.
- Video metadata: add runtime and a descriptive iframe title; use the privacy-enhanced embed when possible.
- No linked chapter lecture deck; supply the chapter deck after the glossary.
- Chapter Flow has no chapter-flow container.

### 11. Object Design and Composition

Source: `chapters/11_object_design/1100_object_design.ipynb`. Rendered glossary rows: 12. Local content links match TOC order: yes.

- Missing the standard Learning Objectives opening sentence.
- Glossary uses Term/Meaning instead of the required #/Term/Explanation table.
- No embedded chapter video.
- No linked chapter lecture deck; supply the chapter deck after the glossary.
- Chapter Flow has no chapter-flow container.
- Media placeholder incorrectly says three content notebooks; the flow now lists four core readings and one supporting reading.

### 12. Inheritance, Interfaces, and Polymorphism

Source: `chapters/12_oop/1200_oop_principles.ipynb`. Rendered glossary rows: 10. Local content links match TOC order: yes.

- Missing the standard Learning Objectives opening sentence.
- Glossary uses Term/Meaning instead of the required #/Term/Explanation table.
- Video metadata: add runtime and a descriptive iframe title; use the privacy-enhanced embed when possible.
- No linked chapter lecture deck; supply the chapter deck after the glossary.
- Chapter Flow has no chapter-flow container.

### 13. ADTs

Source: `chapters/13_abstract_data_types/1300_abstract_data_types.ipynb`. Rendered glossary rows: 19. Local content links match TOC order: yes.

- Remove the landing-page index directive; subject entries belong at teaching locations.
- Glossary rows 17 and 18 are concatenated; Input size is swallowed into Lazy evaluation rather than receiving its own row.
- Video metadata: add runtime and a descriptive iframe title; use the privacy-enhanced embed when possible.
- No linked chapter lecture deck; supply the chapter deck after the glossary.
- Chapter Flow has no chapter-flow container.

### 14. Linear Lists

Source: `chapters/14_arrays_linked_lists/1400_arrays_linked_lists.ipynb`. Rendered glossary rows: 21. Local content links match TOC order: yes.

- Video metadata: add runtime and a descriptive iframe title; use the privacy-enhanced embed when possible.
- No linked chapter lecture deck; supply the chapter deck after the glossary.
- Chapter Flow has no chapter-flow container.
- Objective 6 and glossary entries 19–21 still promise binary search and stable reporting after that material moved to Chapter 16; the current three content sections do not develop these topics.

### 15. Stacks & Queues

Source: `chapters/15_stacks_queues/1500_stacks_queues.ipynb`. Rendered glossary rows: 22. Local content links match TOC order: yes.

- Video metadata: add runtime and a descriptive iframe title; use the privacy-enhanced embed when possible.
- No linked chapter lecture deck; supply the chapter deck after the glossary.
- Chapter Flow has no chapter-flow container.

### 16. Searching and Basic Sorting

Source: `chapters/16_searching_sorting/1600_searching_sorting.ipynb`. Rendered glossary rows: 6. Local content links match TOC order: yes.

- Overview lacks the required 3–5 formatted concept bullets.
- Missing the standard Learning Objectives opening sentence.
- Objectives use bullets rather than a numbered list; initial outcomes are generic.
- Glossary uses Term/Meaning instead of the required #/Term/Explanation table.
- No embedded chapter video.
- No linked chapter lecture deck; supply the chapter deck after the glossary.
- Chapter Flow has no chapter-flow container.
- Assignments link remains inside Chapter Flow; separate it from the content-only sequence.
- Replace generic overview and objectives with search-result contracts, sorted-input requirements, insertion sorting, stability, mutation and repeated-query workloads. Correct “three lessons”: there are two content sections.

### 17. Trees

Source: `chapters/17_trees/1700_trees_bst.ipynb`. Rendered glossary rows: 27. Local content links match TOC order: yes.

- Video metadata: add runtime and a descriptive iframe title; use the privacy-enhanced embed when possible.
- No linked chapter lecture deck; supply the chapter deck after the glossary.
- Chapter Flow has no chapter-flow container.

### 18. Priority Queues and Heaps

Source: `chapters/18_priority_queues/1800_priority_queues.ipynb`. Rendered glossary rows: 6. Local content links match TOC order: yes.

- Overview lacks the required 3–5 formatted concept bullets.
- Missing the standard Learning Objectives opening sentence.
- Objectives use bullets rather than a numbered list; initial outcomes are generic.
- Glossary uses Term/Meaning instead of the required #/Term/Explanation table.
- Video metadata: add runtime and a descriptive iframe title; use the privacy-enhanced embed when possible.
- No linked chapter lecture deck; supply the chapter deck after the glossary.
- Chapter Flow has no chapter-flow container.
- Assignments link remains inside Chapter Flow; separate it from the content-only sequence.
- Replace generic overview and objectives with priority/tie contracts, complete-tree shape, sift repairs, heap invariants and top-k workloads. Chapter Video appears after Teaching Materials instead of before objectives.

### 19. Hash Collections and Sets

Source: `chapters/19_hash_collections/1900_hash_collections.ipynb`. Rendered glossary rows: 6. Local content links match TOC order: yes.

- Overview lacks the required 3–5 formatted concept bullets.
- Missing the standard Learning Objectives opening sentence.
- Objectives use bullets rather than a numbered list; initial outcomes are generic.
- Glossary uses Term/Meaning instead of the required #/Term/Explanation table.
- No embedded chapter video.
- No linked chapter lecture deck; supply the chapter deck after the glossary.
- Chapter Flow has no chapter-flow container.
- Assignments link remains inside Chapter Flow; separate it from the content-only sequence.
- Replace generic overview and objectives with equality/hash consistency, collisions, growth, set/multiplicity operations and coordinating indexes.

### 20. Graphs and Traversal

Source: `chapters/20_graphs/2000_graphs.ipynb`. Rendered glossary rows: 6. Local content links match TOC order: yes.

- Overview lacks the required 3–5 formatted concept bullets.
- Missing the standard Learning Objectives opening sentence.
- Objectives use bullets rather than a numbered list; initial outcomes are generic.
- Glossary continuation renders as literal pipe text after a blank line; repair the single continuous table.
- Glossary uses Term/Meaning instead of the required #/Term/Explanation table.
- No embedded chapter video.
- No linked chapter lecture deck; supply the chapter deck after the glossary.
- Chapter Flow has no chapter-flow container.
- Assignments link remains inside Chapter Flow; separate it from the content-only sequence.
- Replace generic overview/objectives and stale “three lessons” claim: there are four content sections. Orient students to graph models, representations, BFS and DFS; move the unrelated string-matching/approximation bridge out of the chapter overview.

### 21. Analysis

Source: `chapters/21_algorithm_analysis/2100_algorithm_analysis.ipynb`. Rendered glossary rows: 11. Local content links match TOC order: yes.

- Missing the standard Learning Objectives opening sentence.
- Glossary continuation renders as literal pipe text after a blank line; repair the single continuous table.
- Video metadata: add runtime and a descriptive iframe title; use the privacy-enhanced embed when possible.
- No linked chapter lecture deck; supply the chapter deck after the glossary.
- Chapter Flow has no chapter-flow container.

### 22. Recursion

Source: `chapters/22_recursion_divide_conquer/2200_recursion_divide_conquer.ipynb`. Rendered glossary rows: 11. Local content links match TOC order: yes.

- Missing the standard Learning Objectives opening sentence.
- Glossary continuation renders as literal pipe text after a blank line; repair the single continuous table.
- Video metadata: add runtime and a descriptive iframe title; use the privacy-enhanced embed when possible.
- No linked chapter lecture deck; supply the chapter deck after the glossary.
- Chapter Flow has no chapter-flow container.

### 23. Advanced Searching and Sorting

Source: `chapters/23_searching_sorting/2300_searching_sorting.ipynb`. Rendered glossary rows: 11. Local content links match TOC order: yes.

- Missing the standard Learning Objectives opening sentence.
- Glossary continuation renders as literal pipe text after a blank line; repair the single continuous table.
- Video metadata: add runtime and a descriptive iframe title; use the privacy-enhanced embed when possible.
- No linked chapter lecture deck; supply the chapter deck after the glossary.
- Chapter Flow has no chapter-flow container.

### 24. Greedy Algorithms

Source: `chapters/24_greedy_graph_optimization/2400_greedy_graph_optimization.ipynb`. Rendered glossary rows: 10. Local content links match TOC order: yes.

- Glossary continuation renders as literal pipe text after a blank line; repair the single continuous table.
- Video metadata: add runtime and a descriptive iframe title; use the privacy-enhanced embed when possible.
- No linked chapter lecture deck; supply the chapter deck after the glossary.
- Chapter Flow has no chapter-flow container.

### 25. Dynamic Programming

Source: `chapters/25_dynamic_programming_backtracking/2500_dynamic_programming_backtracking.ipynb`. Rendered glossary rows: 11. Local content links match TOC order: yes.

- Glossary continuation renders as literal pipe text after a blank line; repair the single continuous table.
- Video metadata: add runtime and a descriptive iframe title; use the privacy-enhanced embed when possible.
- No linked chapter lecture deck; supply the chapter deck after the glossary.
- Chapter Flow has no chapter-flow container.

### 26. Advanced Algorithms

Source: `chapters/26_advanced_graphs_strings_limits/2600_advanced_graphs_strings_limits.ipynb`. Rendered glossary rows: 7. Local content links match TOC order: yes.

- Glossary continuation renders as literal pipe text after a blank line; repair the single continuous table.
- Video metadata: add runtime and a descriptive iframe title; use the privacy-enhanced embed when possible.
- No linked chapter lecture deck; supply the chapter deck after the glossary.
- Chapter Flow has no chapter-flow container.
- The retained graph-course video is explicitly labeled prerequisite review, but does not introduce the chapter’s main string-matching/computational-limits concepts. Keep the existing URL unless the author approves replacement.

## Mechanical fix pass — October 17, 2026

Applied by script to all 26 landing pages (`chapters/*/NN00_*.ipynb`); no content notebooks, `_toc.yml`, or assignments were changed.

- **Chapter Flow:** every list now sits inside the `{div} chapter-flow` container, listing content sections only in `_toc.yml` order (checked programmatically). The Chapter 2 assignment link and the cross-chapter notes in Chapters 1, 6, and 26 moved to their own paragraph after the container. `_static/custom.css` gained the `.chapter-flow a` rule.
- **Learning Objectives:** added "By the end of this chapter, you will be able to:" to Chapters 11, 12, 21, 22, and 23. All 26 now use numbered objectives.
- **Index directives:** removed from the landing pages of Chapters 3, 4, 7, 8, 9, 10, and 13; the `(label)=` anchors stay.
- **Glossaries:** all 26 use one continuous `| # | Term | Explanation |` table with sequential numbering. Chapter 13 rows 17 and 18 were split; the blank line that broke the tables in Chapters 21 to 26 was removed; Chapters 11 and 12 were converted from Term/Meaning to the numbered shape.
- **Videos:** the 21 `youtube` directive embeds were converted to the skill's raw iframe markup on `youtube-nocookie.com` with a descriptive `title` attribute, a linked "Title (M:SS)" line, and the standard short ownership note. Every video ID is unchanged; the empty slots in Chapters 1, 11, 16, 19, and 20 remain empty. Titles and runtimes were read from each video's YouTube watch page on this date; two retained link titles (Chapters 24 and 26) were replaced by the video's actual title, and emoji were dropped from the Bro Code titles. Chapter 21 keeps its supplement sentence after the standard note.

Still open (judgment items, not changed here): the Chapter 14 objective 6 and glossary rows 19 to 21 that promise binary search and stable reporting; the Chapter 11 "three content notebooks" placeholder; the Chapter 9 core-versus-optional regex outcomes; the Chapter 26 prerequisite-review video; and the missing lecture decks and the five empty video slots book-wide.
