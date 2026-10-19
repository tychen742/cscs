# Core Depth Revision Review

Local changes only. No commit, push or deployment has been performed.

[Open the side-by-side notebook diffs](review.html) or [read the unified content and planning diff](source.diff). The original audit is [here](../core_depth_audit/README.md).

## Scope

Address all 15 core findings while preserving existing explanations, examples, exercise variants, notebook paths, cell identities and saved outputs. Assignments and optional/supporting readings remain unchanged. Chapter 2 basic syntax is deliberately early exposure, not full instruction; its short previews are not expanded to satisfy an instructional word quota. Apply the same recognition-before-combination principle to later compact syntax.

The revision changes 17 core notebooks in 14 chapters, synchronizes their 28 MATERIALS/ORGANIZATION files, and adds one reviewed subject-index mapping for the new helper-learning heading. The TOC is unchanged.

## Finding dispositions

| Finding | Chapter | Implemented change |
| --- | --- | --- |
| C01 | 2 | Brief var recognition note; no new mastery requirement. |
| C02 | 2 | Retained early exposure; definitions/examples paired, selected outputs explained. |
| C03 | 3 | Selection forms before cross-form synthesis; standalone branch-order repair. |
| C04 | 5 | Top-level helper path before retained class/project comparisons. |
| C05 | 6 | Familiar scalar-loop debugger investigation before array transfers; bug comment corrected. |
| C06 | 7 | Array parameters/aliasing together, then preserved command-line application. |
| C07 | 8 | Concrete sequence/key examples before full comparison tables and namespace reference. |
| C08 | 9 | Whitespace-parsing claim corrected; shape/parse/domain matrix and standalone example. |
| C09 | 10 | Tuple result/deconstruction/collection interpretations and explicit input contract; existing practice retained. |
| C10 | 11 | Nested-sharing object graph, mutation/copy table and two core cross-references. |
| C11 | 12 | Declared/runtime type, override and explicit base-call prediction trace. |
| C12 | 13 | Loop/query comparison, deferred snapshot prediction and 110-minute meeting map. |
| C13 | 14 | Cursor/lost-link reasoning before mutations; complete list before sentinel alternative. |
| C14 | 20 | Direction rules grouped before component application; all explanations/anchors retained. |
| C15 | 24 | Focused complete algorithm first; repeated full models collapsed and clearly labeled. |

## Preservation

- All 959 original cells are retained with their original IDs, and all original saved outputs/execution counts are unchanged.
- Every original code example is retained. Only the misleading comment on the intentionally defective array loop changes in old executable source; its behavior and defect remain.
- Six old prose/comment cells receive factual or relative-position corrections. Heading nesting changes retain all heading text and anchors. Full before/after evidence is in cell_changes.json.
- 262 other notebooks are byte-identical to the baseline, including all 124 assignment notebooks and every optional/supporting notebook. Embedded optional material in otherwise core pages is also retained unchanged.
- Forty-six cells are added, including four executable cells. Existing examples and independent browser-cell setup are preserved when programs are collapsed for readability.

## Verification

- All 138 selected complete/new C# cells compile and run independently on .NET 10.0.107. Twenty existing incomplete learner starters are outside this demonstration check. The four new cells retain their verified output, including the deliberately wrong but compiling branch-order starter.
- The actual decision solution also passes the promised 59/60/89/90/95 boundary cases.
- Five retained tuple/dispatch transcripts match the exact numeric and text interpretations added beside them.
- All edited notebooks pass nbformat schema validation; preservation checks and git diff --check pass.
- Generated HTML checks cover 17 revised readings and 673 article links, with no missing local file or anchor. The diagram links, decision sequence and retained collapsed Dijkstra programs are checked.
- A full build passed. Three pre-existing lexer warnings remain in unchanged source blocks in 2.2 Types and Conversion, 10.1 Class Syntax, and the optional database appendix. New cross-reference warnings were repaired; the final incremental build is recorded separately in build_verification.json.
- Browser screenshot review was unavailable because the browser tool rejected local-file navigation. HTML checks inspect generated structure and links rather than claiming visual verification. The user can open the diff and rendered readings locally.

## Review notes

Red/green moves in the diff do not imply deleted teaching content. The preservation verifier compares every original cell and allows only the documented factual/relative-position corrections and heading-level changes. It also compares every excluded notebook with its original hash. No optional material is reclassified and no assignment is modernized in this pass.
