# Chapter landing-page revision (2026-10-17)

Revised all 26 numbered chapter landing pages using B-A and the current content readings and planning documents. This does not reorganize chapters, revise their teaching sections, or deploy the book.

## Completed

- Replaced generic or stale orientation with chapter-specific introductions and connections to prior ideas. Each landing has three to five concept bullets.
- Kept or refined specific measurable objectives, numbered them, and supplied the standard opening sentence. Core and supporting-reading outcomes are distinguished, especially in Chapters 9 and 11. Existing substantive outcomes were retained; Chapter 14's relocated search/report promise is now assigned to Chapter 16.
- Made Chapter Flow an explicit `chapter-flow` container containing only local content readings, in unchanged TOC order. Retained assignment and cross-chapter links outside that container.
- Repaired the Chapter 13 concatenated rows and the Chapter 20–26 glossary continuations. All glossaries use one continuous `# | Term | Explanation` table. Vocabulary additions follow the actual readings rather than a numerical quota. Chapter 14's relocated search/sorting vocabulary appears in Chapter 16.
- Reused the B-A glossary CSS snippet. Full chapter titles remain on landing pages; short labels are maintained in the sidebar. Old heading anchors remain available after title expansions.
- Removed the seven landing-page index directives so subject pointers belong at teaching passages.
- Kept every existing video ID. Corrected displayed metadata from the official public YouTube player response, added runtimes and accessible iframe titles, and used privacy-enhanced player URLs. Filled empty Chapter 1, 11, 16, 19, and 20 video slots. Added a KMP introduction before Chapter 26's retained graph-prerequisite review. External playback was not exhaustively tested; metadata reported all selected videos available and embeddable at the time of checking.

## Validation

Full Jupyter Book build succeeded. It retains the preexisting Chapter 2 character-literal syntax-highlighting warning. The final static/anchor update also passed an incremental build.

`verify_landing_pages.py` checked all 26 rendered pages: heading order, orientation bullets, numbered objectives, flow destinations/order, continuous three-column glossaries, sequential row numbers, unique term spellings, video attributes/retained IDs, legacy heading anchors, and 129 local links and fragments. All 315 other tracked notebooks remain byte-identical, including content, assignments, appendices, and front matter. `_toc.yml` is unchanged. No C# was changed, so executable-example tests were not rerun.

Representative browser inspection confirmed the Chapter 20 flow and glossary layout. The before/after review includes full source diffs for every landing.

- Preview: `http://127.0.0.1:8800/landing_revision_review.html`
- `manifest.json`: chapter titles, objective and glossary counts, video IDs, old/new hashes, and retained heading anchors.
- `verification.json`: rendered checks and preservation result.
- `preserved_notebooks.json`: SHA-256 baseline for the 315 unchanged notebooks.
- `editorial_choices.json`: chapter-specific introductions, objective changes, concept changes, and supplementary vocabulary.
- `review.html`: complete before/after comparisons.
- Video metadata: `video_metadata.json`; original audit remains historical evidence.

## Separate lecture-deck task

The author explicitly chose “Fix landing pages; track decks separately.” Full B-A compliance still requires the student HTML and instructor PowerPoint lecture decks. Each revised landing has the correctly placed Lecture Slides section and an honest preparation note; no placeholder links were introduced. Do not treat the retained legacy Chapter 1 overview as a complete chapter lecture deck.

For each chapter, develop one complete part per current content reading using the B-A lecture-deck standard, build HTML and instructor PowerPoint, validate notes and layout, then replace the landing preparation note with one real student deck link. Instructor files must stay outside the deployed tree.

| Chapter | Planned student deck | Status |
| --- | --- | --- |
| 1. Computing, Programs, and Responsibility | `chapters/01_context/0100-slides.html` | Deferred, separate authoring task |
| 2. Variables, Data Types, and Operators | `chapters/02_var_data/0200-slides.html` | Deferred, separate authoring task |
| 3. Decisions | `chapters/03_decision/0300-slides.html` | Deferred, separate authoring task |
| 4. Iteration | `chapters/04_iteration/0400-slides.html` | Deferred, separate authoring task |
| 5. Methods | `chapters/05_methods/0500-slides.html` | Deferred, separate authoring task |
| 6. Testing, Debugging, and Error Handling | `chapters/06_exceptions_testing/0600-slides.html` | Deferred, separate authoring task |
| 7. Arrays | `chapters/07_arrays/0700-slides.html` | Deferred, separate authoring task |
| 8. Data Collections | `chapters/08_collections/0800-slides.html` | Deferred, separate authoring task |
| 9. Files and Text | `chapters/09_files_text/0900-slides.html` | Deferred, separate authoring task |
| 10. Classes and Objects | `chapters/10_classes/1000-slides.html` | Deferred, separate authoring task |
| 11. Object Design and Composition | `chapters/11_object_design/1100-slides.html` | Deferred, separate authoring task |
| 12. Inheritance, Interfaces, and Polymorphism | `chapters/12_oop/1200-slides.html` | Deferred, separate authoring task |
| 13. Abstract Data Types | `chapters/13_abstract_data_types/1300-slides.html` | Deferred, separate authoring task |
| 14. Arrays and Linked Lists | `chapters/14_arrays_linked_lists/1400-slides.html` | Deferred, separate authoring task |
| 15. Stacks, Queues, and Deques | `chapters/15_stacks_queues/1500-slides.html` | Deferred, separate authoring task |
| 16. Searching and Basic Sorting | `chapters/16_searching_sorting/1600-slides.html` | Deferred, separate authoring task |
| 17. Trees and Binary Search Trees | `chapters/17_trees/1700-slides.html` | Deferred, separate authoring task |
| 18. Priority Queues and Heaps | `chapters/18_priority_queues/1800-slides.html` | Deferred, separate authoring task |
| 19. Hash Collections and Sets | `chapters/19_hash_collections/1900-slides.html` | Deferred, separate authoring task |
| 20. Graphs and Traversal | `chapters/20_graphs/2000-slides.html` | Deferred, separate authoring task |
| 21. Algorithm Analysis | `chapters/21_algorithm_analysis/2100-slides.html` | Deferred, separate authoring task |
| 22. Recursion and Divide-and-Conquer | `chapters/22_recursion_divide_conquer/2200-slides.html` | Deferred, separate authoring task |
| 23. Advanced Searching and Sorting | `chapters/23_searching_sorting/2300-slides.html` | Deferred, separate authoring task |
| 24. Greedy Algorithms and Graph Optimization | `chapters/24_greedy_graph_optimization/2400-slides.html` | Deferred, separate authoring task |
| 25. Dynamic Programming and Backtracking | `chapters/25_dynamic_programming_backtracking/2500-slides.html` | Deferred, separate authoring task |
| 26. String Matching and Computational Limits | `chapters/26_advanced_graphs_strings_limits/2600-slides.html` | Deferred, separate authoring task |
