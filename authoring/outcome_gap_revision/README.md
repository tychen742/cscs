# Outcome Gap Revision

This pass implements F01-F11 from the outcome coverage audit within the existing chapter organization. All original notebook cells remain present by ID, including documented relocations. Corrections and moves are recorded in `changes.json`; complete original notebook sources are in `before.json`. The earlier audit remains historical evidence.

The content sections now introduce TryParse validation, Random trials, out/ref definitions, params arrays, rethrowing, coherent MSTest projects, and a guided 2D aggregation bridge before independent application. Homework adds independent method/test design, value/record semantics, composition, iterators/costs, search/sort, heap repairs, coordinated indexes/hash traces, and graph traversal verification. Existing API/scaffold tasks remain intact.

Both MATERIALS.md and ORGANIZATION.md in each affected chapter contain a concrete progression map. Setup and Git remain in appendices; chapter/section order and existing exercise IDs are preserved. Lecture decks remain a separate task.

Open `review.html` for readable full source diffs and lesson links. Verification evidence: `code_results.json`, `mstest_results.json`, `preservation_results.json`, and `build_results.json`. Run `python3 scripts/verify_outcome_gap_revision.py` to check preservation and recorded execution evidence.
