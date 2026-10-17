# Chapter 8 framework improvement verification

Completed locally on October 17, 2026, against baseline `c27d793a`. The three-section chapter organization and TOC are unchanged. Every pre-existing notebook cell ID remains. Original explanations and exercises are retained, with targeted corrections to misleading claims, malformed homework fragments, output displays, and exercise scaffolding.

| Review finding | Resolution |
| --- | --- |
| 8.1 dense orientation | Added reading path, access-question diagram, and guided collection selection. Full family/operation tables and examples remain. |
| 8.2 weak organizing problem | Connected the basket problem to resizing, positions, mutation, and traversal. |
| Missing local syntax support | Added construction and operation templates beside list and dictionary teaching. |
| Missing or uninformative outputs | All 22 completed list and 15 completed dictionary cells now have independently verified saved output. The separate type-name pitfalls remain explicit. |
| Position shifts hard to see | Added before/after list diagram, fruit trace table, integer value-versus-index variation. |
| Completed exercise presented as starter | Original score solution is retained as a hidden answer, with a new guided starter and boundary variations. Stable exercise ID remains on the question. |
| ReadLines not invoked | Added caller, expected transcript, null/end-of-input handling, and input boundaries. |
| Dictionary guided practice absent | Added safe stock lookup/update question and executed hidden answer. |
| Word-count jump and missing source | Retained original functions; added small-input trace, complete runnable companion, actual output, policies and variations; downloadable source/project in demos/08/word_count. |
| Overstated namespace/key/performance claims | Corrected implicit-import assumptions, stable hash/equality requirements, and expected lookup-cost wording. |
| Malformed homework aliasing question | Restored list setup and semicolon; alternatives are labeled reading fragments, with reasoning feedback. |
| Preview has two possible answers | Specified append-to-end, so Add is uniquely appropriate. |
| Insufficient transfer practice | Kept original review; added five concept checks and five independent coding tasks, with hidden executed solutions. |
| Lab needs boundary evidence | Retained all five connected tasks and IDs; added case, missing-key, repeated-word, first-match, rotation, and empty-fallback checks. |

## Verification

- 57 completed executable cells across lessons, lab, and homework compile/run independently in temporary .NET 10 projects with implicit usings disabled, nullable analysis enabled, and warnings treated as errors. Outputs are saved. Seven added content displays received focused re-verification.
- Key lesson outputs and all five new homework solutions match independent expected outputs.
- ReadLines passes empty stream, immediate blank line, one item, and duplicate-item inputs.
- Word count passes empty, ignored-only, mixed-case repeated-word, and threshold-report cases.
- Help-desk keyword matching passes normalization, empty/no-match, repeated keyword, and first-recognized-word policies; fallback rotation is checked.
- Three original SVGs have alt descriptions and prose interpretation. Diagram rendering, exercise reveal structure, output blocks, and source-download links are checked in built HTML.
- Jupyter Book build and whitespace checks pass. The full build reports two existing lexer warnings in Chapters 2 and 11; no Chapter 8 build warning was found.
- No deployment in this pass. Aligned lecture slides remain a previously recorded teaching-support gap.

Local before/after review: `http://127.0.0.1:8799/chapter08_framework_review.html`.
