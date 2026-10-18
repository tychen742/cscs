# Chapter 5 coverage and teaching development

Completed locally on October 17, 2026, against `b8559b09`. The five existing
sections, notebook paths, TOC order, and original assessment identities remain.
This implements the Chapter 5 MATERIALS/ORGANIZATION coverage plan using the
shared book-authoring framework. No deployment was performed.

| Section | Teaching development |
| --- | --- |
| 5.1 Introduction | Concrete repetition/decomposition problem, before/after receipt header, diagram, program-form comparison, guided method construction. |
| 5.2 Designing Methods | Contracts and syntax, corrected header/signature distinction, return versus print, returned-call substitution, call/return diagram, original LastFirst walkthrough, formatted returned strings, decision/early-return checks, guided commission exercise. |
| 5.3 Method Parameters | Argument binding, value-copy diagram, local/block scope, shared static state versus constants, corrected standalone tracing program, parameterized loop and boundary checks, computation versus input/output, guided delivery exercise. |
| 5.4 Strings | Typed API patterns, immutability/result interpretation, string-chain diagram and trace, extraction assumptions and guarded fallback, guided normalization exercise. Existing seven examples remain with saved outputs. |
| 5.5 Static Methods | Existing reference material plus design-question map, worked before/after refactoring, composed helpers, independent expected/actual checks, guided synthesis. Overloading/recursion remain bounded extensions. |

## Preservation and relocation

All 180 nonempty original notebook cell identities remain across the chapter,
including cells relocated between files. One originally empty cell was omitted. Existing code was repaired or given a standalone runnable
form; original complete explicit-Main programs remain in labeled reading
references. The previously invalid access-modifier example is preserved as a
labeled diagnosis exercise beside its corrected runnable version.

Identity retention is a structural check, not a substitute for reviewing meaning.
The source comparisons also expose the targeted wording corrections, moved
passages, and preserved exercise requirements. The restored Extra Practice bank
and optional Grade Calculation 2 notebook are byte-for-byte unchanged.

| Lab source | Destination | Preserved application |
| --- | --- | --- |
| Return Statement mathematical explanation; cells 13f9bf84, 9b9bbaee, 050e8417, 2aba7b7a, 98b771f0, 866013ae, fb209153, 24cac997, 420d70bd, 21321cf8, e78e3006 | 5.2 returned-value walkthrough | Returns project, run/comment/screenshot task, prediction and comparison. |
| Return Strings introduction; full LastFirst trace fbf3f15d | 5.2 returned strings and execution trace; binding developed in 5.3 | Two-call tracing, values, source-line association and returned-result use. |
| Return Formatted String explanation and newline note | 5.2 formatted results | Addition2a project, variable-renaming variation and explanation. |
| Interview/Birthday prerequisite concepts | 5.3 computation versus interaction and call/output policy | Original refactoring, Maria call, both blank-line placements and deliverables. |
| SKU prerequisite concepts | 5.4 extraction/normalization and 5.5 helper composition | Four TODO helpers, original three reports, own-input variation and design reflection. |

Labs retain brief reminders and task-specific assumptions. The teaching sequence
now precedes those tasks. Preview/homework questions about overloading and
recursion are explicitly extensions; the original questions remain available.
The methods-demo README distinguishes its greeting contract from the lab's
lastname-first contract; the existing exact SKU reference remains available.

## Verification

- All 38 lesson code cells compile and run independently in temporary .NET 10
  console projects with implicit usings disabled, nullable analysis enabled,
  warnings treated as errors, and shared compilation disabled. Outputs are saved
  in the notebooks, including the revealed solutions. Student placeholders are
  explicitly labeled and their observed output is not presented as an answer.
- All seven lab/homework code cells compile and run under the same settings.
  Interactive formatting uses input 2/3; interview uses Ana/10:30. The unfinished
  SKU starter is a task scaffold, not a completed reference solution.
- Independently expected checks verify Square, returned-expression substitution,
  caller-versus-parameter values, local scope, loop inputs 0/1/4, commission
  ordinary/zero values, delivery threshold 49.99/50/50.01, string normalization,
  and four composed checkout checks. Prepared AI candidate output remains
  intentionally incorrect and is compared with its repaired solution.
- Compiler checks confirm the teaching diagnostics for assigning a void result,
  missing return paths, and a public modifier on a top-level local function.
- Four SVGs have alt text, captions, and explanatory prose; browser inspection
  confirms readable rendering. Guided solution reveal and saved output rendering
  were checked on the Strings page.
- Jupyter Book build succeeds; the final incremental build reports no warnings.
  Notebook validity, local lesson links/assets, and whitespace are checked.

Aligned chapter lecture slides remain a recorded teaching-support gap. Console
verification does not certify a live Docker/browser execution service. This
pass preserves the current assessment submission instructions.

Local before/after review: `http://127.0.0.1:8799/chapter05_framework_review.html`.
