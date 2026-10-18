# B-A Development Revision and Recheck

2026-10-18. All 18 audit findings addressed using the current source as the baseline. Existing teaching cells, examples, exercises and original output records remain. Current chapter/reading order and assignments are unchanged. Not deployed.

## B01: Conversion explanations contradict the correct worked treatment

Qualified the retained conversion chain; separated range, precision, casting, parsing and domain validation; added a verified loss-of-one-unit example and comparison table.

## B02: Division comments teach a result type that the expression does not have

Corrected the integer-division prose and floating-point comment. The new guided evaluation trace distinguishes operand types, intermediate values and display formatting.

## B03: Postfix explanation confuses expression value with the updated variable

Corrected the postfix causal explanation. A verified result/state demonstration distinguishes old expression value, updated storage and the location of a for-loop update.

## B04: Properties are used before a proper property-accessor lesson

The current source already contained a proper accessor lesson, validated backing-field example and Email exercise. Retained all of them, independently verified all seven examples, and repaired the question/answer tags.

## B05: File API explanation names a read method as a write operation

Corrected the read/write API call; added separate call/result patterns and an overwrite prediction without replacing the existing walkthrough.

## B06: Guided starters require undeclared types

Retained each client-check task and embedded its complete supporting types. All three visible starters and all three complete answers compile independently.

## B07: A structured-record example silently depends on a previous cell

The current caller already included its helper. Preserved that source exactly, verified it in a fresh project, and added accepted/rejected-record and domain-contract interpretation.

## B08: Variable-state practice is mostly supplied rather than attempted locally

Retained the newer Swap Two Prices activity and added a learner-completed stock/reservation table, standalone task, solution and feedback about assignment timing.

## B09: Operator practice does not cover the breadth of the operator lesson

Retained bill-splitting and Math/pricing tasks. Added a precedence/value/type table and a fractional-hours repair with explained incorrect and correct outputs.

## B10: Console I/O has many demonstrations but no developed guided checkpoint

Added prompt/read/parse/format patterns, an invoice transcript, field-width explanation, guided Folders report and boundary/mistake feedback. Supplied-input assumptions are explicit.

## B11: Boolean-condition translation needs a learner-owned checkpoint

Retained and verified the newer shipping-condition exercise; added threshold cases and counterexamples for || versus && and > versus >=, including stored-Boolean timing.

## B12: The loop-planning rubric is not demonstrated as a planning process

Retained the countdown-by-twos activity; applied the planning rubric to a concrete reminder task and added a condition-boundary repair with zero-iteration feedback.

## B13: First class construction needs guided application of its core model

Retained and verified current Product construction practice and repaired its exercise tags. Added tuple-deconstruction transfer with units/position feedback; kept params and all prior tuple examples.

## B14: Regex extraction develops less fully than the validation opening

Added extraction API/result patterns, named-group and no-match explanation, matched/unmatched trace, immutable replacement demonstration and a guided whole-record repair before the retained independent practice.

## B15: Optional privacy reading ends with summary rather than guided application

Retained card masking, corrected its overclaim about identification, and added purpose-based synthetic log review with feedback distinguishing display minimization from storage deletion.

## B16: SQL queries need concrete results and guided feedback

Added a reproducible three-book/three-sale dataset, general query pattern, actual filter/group/join results and guided threshold/grouping feedback. Six query results and an empty boundary were checked with SQLite.

## B17: SQLite mapping and transactions rely heavily on inspecting the full project

Added complete project-only row-mapping/affected-row and rollback examples, state tables and explained guided variations. Verified forced failure, valid commit, omitted commit and missing/existing IDs.

## B18: Operator-overloading extension needs a guided operator contract task

Retained Rational and Money. Added general operator syntax, a value/nonmutation contract and a standalone guided Amount addition exercise with zero-boundary and unchanged-operand evidence.

## Verification

```json
{
  "original_cells_retained_in_order": 873,
  "original_code_cells_retained": 166,
  "original_output_records_unchanged": 35,
  "added_cells": 76,
  "documented_source_corrections": 11,
  "exercise_metadata_repairs": 14,
  "unchanged_other_notebooks_and_toc": 263,
  "unchanged_assignment_notebooks": 124,
  "planning_files_updated": 16
}
```

48 independent C# checks passed. Six SQL result queries and an empty-result boundary passed. Full HTML build passed with one existing lexer warning from an unchanged character-literal example. `reaudit.json` records current evidence; `lesson_sources.diff` shows the source changes. The HTML report also includes full before/after diffs.
