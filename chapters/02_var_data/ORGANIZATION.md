# Chapter Organization — Variables and Data Types

## Learning Objectives

1. Declare and initialize variables with types appropriate to the data.
2. Evaluate arithmetic, comparison, and logical expressions, including integer and fractional division.
3. Call library methods with arguments and use their return values in calculations or assignments.
4. Parse valid console input and print labeled, formatted results.
5. Distinguish changing a stored value from formatting its display.

## Sequence

- Variables and types: declarations, assignment, identifiers, primitive types, conversion
- Operators and built-in methods: operators and precedence; method calls, arguments, return values; `Math`, `Parse`; brief string methods
- Console input and output

## Notes

- 2026-10-10: five sections merged into three (one per class meeting). Built-in methods are taught here, before Chapters 3-5, so students know what a method call, argument, and return value are before they write methods. Chapter 5 defines methods and keeps the full string methods section (5.4).
- `using`/namespaces are covered in 1.4 (implicit usings); this chapter only reminds students that `Math` and `string` live in `System`.

## Assessment Sequence (2026-10-15)

Preview introduces vocabulary from all three sections without code prediction. Lab retains the office-supply theme: declare an order, calculate rounded amounts, parse a quantity, plan boxes with quotient/remainder and Ceiling, and produce a normalized input-driven invoice. Homework transfers the same concepts to sales targets, workload averages, staff badges, expense summaries, and budget differences.

The five true/false cases have two true and three false answers. They address value assignment, method return values, parsed input, cast placement, and logical conjunction. Homework code is independent of the lab and uses no later control-flow or object-design skills. Valid-input and numeric-culture assumptions are explicit. The chapter's three section notebooks remain unchanged by this assessment pass.

## Keyword Progression (2026-10-15)

Section 1.3 introduces reserved keywords and provides the collapsed list. Section 2.1 links back and treats escaped identifiers and contextual keywords as optional reading after variables and type inference.

## Reliability Progression (2026-10-16)

Predict expression/output results and check conversions and formatting against explicit expected values. Keep valid-input assumptions visible; do not require exception handling. This is the current teaching plan; this structural pass does not claim a new practice or assessment implementation.


## Restored CS1 Teaching Content (2026-10-17)

Author-requested additive merge from the standalone restored CS1 reference. Existing lessons, responsibility/AI material, assignments, and assessment IDs remain. Setup and Git stay in Appendices B and C. Restored concepts are reading and practice within the current three-section sequence, not extra required meetings.

Section 2.1 adds the original step-by-step variable state table and independently runnable trace. assignments/additional_practice.ipynb restores UpdateVars/MathFun prediction and state tracing, MathDivision mixed-fraction output, the composite-formatting follow-up, format-reading puzzles, Mad Lib, and live/fixed Unix-time operator practice. This page is linked from the current Lab; it supplements the five-stage office-supply lab rather than replacing its submission requirements. Valid-input assumptions are explicit. The live-clock demonstration is distinguished from reproducible fixed-timestamp predictions. Existing lab/preview/homework questions and identifiers are preserved.

## CS1 Preservation Follow-up (2026-10-17)

Original mixed-expression legality, necessary/redundant casts, one-call multiline output, add3 and quotient-sentence review variations restored in Extra Practice. The UI helper source-import workflow is restored in 2.3 with namespaced client and downloadable demonstration (`demos/02/ui_helper.zip`). Setup and Git remain in appendices.
