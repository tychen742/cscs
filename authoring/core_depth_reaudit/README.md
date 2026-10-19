# Core Depth Re-audit

Source: `e3fc679dbf6ea0747585db7a1cdeb94d3043f18b`. Core readings inventoried: 84. This audit precedes the separate, user-authorized Section 3.2 tabbed-practice pilot.

Core only. Assignments and optional/supporting readings excluded. Chapter 2 syntax previews are early exposure and are not deficiencies for lacking a full lesson or mastery exercise. Inventory captured before the separate one-section practice pilot.

## Conclusion

The prior 15 fixes substantially improve the sequence. No broad chapter expansion or trimming is justified by the remaining counts. Remaining findings concern three conceptual distinctions, attempt/feedback staging, final-practice coverage, and one repeated outline label. Recent algorithm traces, invariants, worked examples and completion questions remain useful and should be retained.

## R01: High, Validation vs. Exceptions

Source: [0601_error_handling.ipynb](/Users/tcn85/workspace/cscs/chapters/06_exceptions_testing/0601_error_handling.ipynb), cell `78f38d60`.

Already adequate: The developed opening already distinguishes failure policy and expected bad input.

Remaining issue: The later summary says exceptions handle unexpected failures and catch is for what cannot be predicted, while the same lesson intentionally throws for invalid arguments. Expectedness is not the criterion that defines exception-based API failure.

Recommendation: Explain routine validation versus a called operation reporting failure through an exception. Retain TryParse as the routine-input pattern; distinguish predictable failure from a guarantee that a precheck prevents it.

## R02: High, The Unit Testing Process

Source: [0603_testing.ipynb](/Users/tcn85/workspace/cscs/chapters/06_exceptions_testing/0603_testing.ipynb), cell `fd072853`.

Already adequate: The repeatable expected-result checks and full framework walkthrough are substantial.

Remaining issue: The subsection describes following TDD as a fundamental principle of adopting unit testing, blurring a test technique with one development workflow.

Recommendation: Define unit testing independently, then present red/green/refactor as one workflow. Explain tests can also characterize existing code; preserve the TDD diagram and intentional defect.

## R03: Medium, Static Methods

Source: [0501_intro_methods.ipynb](/Users/tcn85/workspace/cscs/chapters/05_methods/0501_intro_methods.ipynb), cell `fb260642`.

Already adequate: The program-form comparison and top-level versus class-member distinction are now explicit.

Remaining issue: The retained short summary associates static methods with procedural programming as opposed to object-oriented instance methods. Static methods also belong to classes and can participate in object-oriented programs; the contrast is receiver/instance dependence.

Recommendation: Clarify static/class access versus an instance receiver and per-object state. Keep the early program-form reference concise rather than adding an OOP unit here.

## R04: Medium, Practice: Service the Minimum Priority

Source: [1801_priority_queues.ipynb](/Users/tcn85/workspace/cscs/chapters/18_priority_queues/1801_priority_queues.ipynb), cell `nearby-15`.

Already adequate: The queue priority contract and swap-priority variation are clear.

Remaining issue: The task says to complete an operation, but the starter already calls Dequeue; the answer and its reasoning are printed immediately before it. It is useful demonstration/prediction material, not a completion task as labeled.

Recommendation: Retain the example. Make the requested response explicit, let learners record a prediction before revealing reasoning, or provide an actual bounded missing operation. Expected output may remain visible for coding tasks; full reasoning need not precede the attempt.

## R05: Medium, Practice: Replace a Component Without Changing Its Client

Source: [1203_interfaces.ipynb](/Users/tcn85/workspace/cscs/chapters/12_oop/1203_interfaces.ipynb), cell `553275b42096`.

Already adequate: The lesson includes interfaces, composition and a test double; the existing one-line completion is a valid guided check.

Remaining issue: The final practice changes return 0m to return subtotal in a complete supplied model. By itself it does not test whether students can design a different conforming component or explain a client dependency.

Recommendation: Keep this as the guided repair tab, then add a less-scaffolded policy/component task plus ordinary/boundary cases. Do not turn every guided task into a full project or borrow excluded assignments as missing lesson practice.

## R06: Medium, End-of-section organization

Source: [0601_error_handling.ipynb](/Users/tcn85/workspace/cscs/chapters/06_exceptions_testing/0601_error_handling.ipynb), cell `78f38d60`.

Already adequate: Inline checkpoints and complete reference comparisons serve real teaching roles.

Remaining issue: Several pages continue instruction after a Practice heading: 5.1 continues into project forms, 6.1 into rethrow behavior, and 16.2 into whole-workload reporting. A practice-labelled block is therefore not consistently the final consolidation.

Recommendation: For the tabbed pattern, place the final question set after the taught material and before Footnotes. Keep brief inline checks beside their concepts, and cover the final concepts too. Do not move every mid-lesson guided check to the end.

## R07: Low, Components and Direction / Connected Components and Direction

Source: [2004_depth_first_components.ipynb](/Users/tcn85/workspace/cscs/chapters/20_graphs/2004_depth_first_components.ipynb), cell `3615022f`.

Already adequate: The direction explanations are now grouped before the component application and all examples are retained.

Remaining issue: The grouped outline still has two nearly identical nested labels for the same distinction. This is navigation fragmentation rather than absent depth.

Recommendation: Use one visible teaching heading and retain the older anchors and all distinct paragraphs/counterexamples. Do not expand the short parent merely because it has few direct words.

## End-of-section practice direction

A section is a core reading notebook, not every small subsection. Preserve brief local guided checks and place a cohesive question set at the end of the reading before Footnotes. Use one tab per question. Match depth to taught content: predict/trace, explain or diagnose, complete/repair, then apply with less scaffolding. These are useful roles, not a quota of four questions or mandatory question types for every lesson. Conceptual lessons use cases and arguments. Chapter 2 exposures need recognition, not premature implementation demands.

Hints should support an attempt; revealable answers explain why the result is correct. Coding questions may show expected output, but do not reveal the complete reasoning as a prerequisite to making a prediction. Preserve all existing questions and IDs when reorganizing. No scores, timers, leaderboard or game progression is proposed.

## Verification and limits

This is a source-level re-audit of the included hierarchy and contextual reading of confirmed candidates, not a claim that every retained factual statement or executable cell was reverified. Existing code/build evidence remains historical. Only Section 3.2 is changed for the separately authorized pilot; all other findings are reported before edits. Assignments and optional readings remain outside both scopes.
