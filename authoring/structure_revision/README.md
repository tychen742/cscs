# Structure Revision, October 21, 2026

Implemented the structure audit while retaining all 26 numbered chapters in their existing order and leaving slides for a later pass.

| Audit finding | Result |
| --- | --- |
| Conflicting first-course/project promises | The Preface, Book Plan, and project overview identify tested console applications as the core. The midterm uses concepts taught by its due date; the final integrates collections, files, and collaborating classes. Database, GUI, and AI work remain optional. |
| Expanded readings versus three meetings | Chapters 2, 5, 7, 8, 11, 13, 17, and 20 now have preparation/class/reference allocations in ORGANIZATION.md and visible three-meeting tables on their landing pages. Each allocation totals 110 minutes; examples and core readings are retained. |
| Efficient sorting on the CS2 route | The Preface, Book Plan, Part IV overview, and Chapter 16 recommend 5.6 before 16.3. The lighter applied route remains explicit. |
| Chapter 23 identity | The chapter retains its title and explains its duplicate-contract, invariant, correctness, and workload role. The algorithms route recommends 23.5 alongside Chapter 22. |
| CS1 query discovery | Optional 8.5 develops lambdas, filtering, ordering, transformation, materialization, and deferred source reads through primitive decimal lists, a loop/query comparison, and a dispatch-report exercise. Chapter 13 retains its self-contained delegate/policy treatment. |
| Documentation drift and references | The earlier comparison has a current-disposition table separating repaired gaps from its historical baseline. A generated selected bibliography follows the appendices; local footnotes remain in place. |

No numbered chapter, existing reading, published path, assignment, assessment ID, existing cell ID, or existing code/output was removed or renamed. The new optional exercise uses `cscs-collections-linq-dispatch`. The new bibliography and optional reading are the only TOC additions.

## Review

[Readable before/after diff](review.diff) shows notebook changes as instructional text and code instead of escaped JSON. It also includes the configuration, planning, bibliography, and navigation changes.

[Preservation checks](preservation.json) record the unchanged existing reading order, 124 active assignment notebooks, 1,413 existing code cells, and 7,531 existing chapter cell IDs. All existing slide assets are unchanged.

[Query verification](query_verification.json) records compilation and independently expected output for all five new standalone C# cells, plus empty, all-invalid, zero, and duplicate-boundary variants of the solution. Each program compiled under .NET 10 with warnings treated as errors. The incomplete exercise starter compiles and intentionally produces no output. Stored demonstration and solution outputs are retained in the notebook.

## Build

Command: `.venv/bin/jupyter-book build . --builder html --path-output /tmp/cscs_structure_revision_20261021`

The full build passes with the same three pre-existing C# highlighting warnings seen in the audit baseline (Chapter 2 character literals, the Chapter 10 schematic ellipsis, and the SQLite raw-string example). The reviewed subject-index gate passes, including the new LINQ entries. The final incremental build also passes without warnings. [Rendered checks](rendered_checks.json) confirm all 26 chapter numbers, eight 110-minute meeting tables, the new exercise/output and index destinations, seven generated bibliography entries, and local links on the new pages. Notebook execution is disabled in the book configuration; new lesson code is verified separately as described above. Slides were neither generated nor revised.
