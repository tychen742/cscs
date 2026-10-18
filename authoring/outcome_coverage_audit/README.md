---
orphan: true
---

# CS1 and CS2 outcome coverage audit

Prepared October 17, 2026, against main commit `48afdb5d`. Audit only: no chapter plan, teaching notebook, assignment, TOC, or book plan was edited.

The principal gap is the distance between the developed lessons and what several assignments require students to demonstrate. This is not evidence that all those explanations are absent. Chapters 14, 15, and 17 already contain substantial implementation, tracing, and verification tasks and should not be replaced with simpler templates.

## Scope and method

Read the book plan, progression records and current TOC; used all 40 MATERIALS.md/ORGANIZATION.md files for Chapters 1–20 to establish chapter roles, assessment promises, prerequisites, and core/supporting boundaries. Traced all 108 published numbered core objectives into explanation, worked example or worked case/trace, section practice, and assessment prompts. Inventoried the 192 TOC-linked notebooks in those chapters, including retained and optional assignment pages. Eight additional planned/published topic tracks are mapped separately so a short extension is not silently counted as a required course outcome.

The map distinguishes the student's editable task from the complete code supplied around it. A lab can provide independent implementation evidence; its label does not make it guided by definition. Conversely, a page titled Homework does not establish independence when its answer is one argument or constant. A worked ethical case can serve the example role without code. Prior-chapter guided work can support a later outcome without repeating an exercise quota.

The current-arrangement/implemented-reading declarations take precedence over historical recommendations left in the plans. The map cites cells in the current source, using one-based cell positions and recording existing cell IDs. References to an entire legacy homework cell are qualified by the question named in the findings. Positive source evidence does not certify compilation, grading configuration, actual student performance, or every incidental API. This was not a new external-comparator, runtime, index, or media audit. The existing build was used for link destinations; no rebuild was necessary for this audit-only artifact.

**Status key:** Supported means a relevant chain is identifiable, not that the lesson has received a universal quality score. Partial identifies a specific weak bridge or assessment-demand mismatch. Gap identifies a missing matched assessment for an explicit core outcome. Source-presence counts do not establish pedagogy by themselves.

## Actual gaps, in priority order

### F01. Heap repair is taught but not independently demonstrated (Must fix)

Chapter 18 explicitly asks students to implement sift-up and sift-down. In Lab 3 the complete 76-line heap is supplied and the edit is an Enqueue call; Lab 4 changes the draining condition. Homework likewise changes calls, policies, and constants. The section exercise writes an invariant checker, not the repair bodies.

**Why it matters:** Correct output from supplied code cannot establish the published implementation outcome. Fairness is in the organization document's direct assessment scope, but neither standard assignment asks for its analysis.

**A later repair should:** Retain these introductory API tasks. Identify a later repair-body or diagnostic-trace task with its own invariant and boundary checks, plus a fairness justification when required.

Evidence: `1802_heap_implementation.ipynb` cells 5–23; `lab.ipynb` cells 8–13; `homework.ipynb` cells 14–27.

### F02. Coordinated indexes and hash traces do not reach matching assessment (Must fix)

Chapter 19 teaches rehashing, deleted slots, and a coordinated queue/dictionary cancellation model. Lab 3–4 call Put/Remove on a supplied 98-line map; homework changes isolated dictionary/set calls. No standard task assesses the coordinated-index workload choice from 19.3.

**Why it matters:** The tasks check collection use but do not establish the stated trace and coordination outcomes.

**A later repair should:** Add an appropriately sized collision/growth trace or repair, and an independently reasoned cancellation/consistency task; implementing an entire hash library from scratch is not necessary.

Evidence: `1901_hashing.ipynb` cells 16–28; `1903_collection_selection.ipynb` cells 16–28; `lab.ipynb` cells 8–13; `homework.ipynb` cells 14–27.

### F03. Graph assignments select supplied traversals rather than assess their reasoning (Must fix)

Chapter 20 supplies complete BFS, DFS, and component implementations in the lab/homework cells. Typical edits select a source, target, or component call. They do not require the queue/discovery/predecessor or suspended-frame trace that the objectives promise. Representation/density analysis is also not independently assessed.

**Why it matters:** The explanations are present, but assessed API use is weaker evidence than the published traversal and cost outcomes require.

**A later repair should:** Keep API-use practice and follow it with a new trace, partial implementation, or deliberately defective traversal plus independently chosen verification cases. Require a representation/cost justification where that outcome is assessed.

Evidence: `2003_graph_traversal.ipynb` cells 5–24; `2004_depth_first_components.ipynb` cells 5–39; `lab.ipynb` cells 5–16; `homework.ipynb` cells 14–28.

### F04. Chapter 13 does not assess its iterator outcome or much independent analysis (Must fix)

13.4 has explanations, runnable examples, and CountDown/Pair<T> section exercises. No preview/lab/homework task addresses IEnumerable<T> or yield return. The generic history class is supplied in the assignments; homework 6 changes Push(0) to Push(42). Quantitative cost reasoning is mostly assessed through a recognition question or true/false claim.

**Why it matters:** An explicit outcome is not connected to a formal assignment; template edits provide limited evidence of designing a generic abstraction or deriving a cost claim.

**A later repair should:** Map a small independent enumerable or generic transfer and a counted-work explanation into an assessment, preserving the existing undo-history tasks.

Evidence: `1304_iterators.ipynb` cells 10–25; `homework.ipynb` cells 14–27; `preview.ipynb` cells 3–4.

### F05. Structs and records have no corresponding independent assessment (Must fix)

11.2 explains value copying, generated equality, defaults, shallow with copies, and record structs, with worked programs and predictions. The chapter's preview, lab, and homework still assess ordinary class references and composition only.

**Why it matters:** The recently expanded explanation is useful, but its core published outcome is not independently demonstrated.

**A later repair should:** Add a compact type-choice/copy/equality task that distinguishes a struct, record class, and class without replacing the existing order-model work.

Evidence: `1105_value_record_types.ipynb` cells 5–20; `preview.ipynb` cells 2–21; `lab.ipynb` cells 2–16; `homework.ipynb` cells 14–28.

### F06. Some language prerequisites are introduced in practice instead of lessons (Must fix)

Chapter 4 Lab 2 explains TryParse(text, out quantity), while the preceding while lesson uses Parse. Random bounds/seeding are taught in Chapter 4 additional practice; params syntax is taught in Chapter 10 additional practice. Chapter 9 shows and assigns a custom multi-out parser, and 13.3/14 homework request ref parameters without a developed declaration/call explanation beforehand.

**Why it matters:** This conflicts with the requested content-first progression. The distinction between passing an object reference by value and a ref parameter is particularly easy to misunderstand.

**A later repair should:** Locate the first assigned use of each construct, then provide general syntax, caller/callee behavior, and a small worked example in an appropriate earlier content section. Retain application instructions and all practice variants.

Evidence: `lab.ipynb` cells 5–6; `0403_while_statement.ipynb` cell 56; `additional_practice.ipynb` cells 9–13; `0903_text_operations.ipynb` cell 28; `homework.ipynb` cell 6; `additional_practice.ipynb` cells 15–20; `1303_generics.ipynb` cell 36; `homework.ipynb` cells 16–17.

### F07. The coherent test-project walkthrough lives in assignments while the lesson is inconsistent (Must fix)

0603 cell 25 describes a project-reference command as adding NUnit, then presents MSTest attributes and Assert.AreEqual(res, expected) calls. The retained Unit Testing Walkthrough instead provides coherent MSTest project commands and expected/actual order. Homework also asks about throw versus throw ex without a corresponding developed rethrow explanation in the content.

**Why it matters:** Students must resolve conflicting instructions or learn prerequisite explanation in a lab. This is an explanation/consistency gap, not a reason to remove testing.

**A later repair should:** Make the content lesson the authoritative framework and failure-output walkthrough; preserve the full lab as application. Explain rethrow semantics before assessing them, or explicitly classify that question as extension.

Evidence: `0603_testing.ipynb` cells 24–25; `unit_testing_walkthrough.ipynb` cells 4–12; `homework.ipynb` cell 1.

### F08. Search/sort homework retains almost the entire algorithm (Should fix)

Chapter 16 contains real algorithm and workload development. The lab repairs one linear return or binary boundary; homework restores one saved insertion value, changes a library condition, or increments a comparison counter. The complete loops are supplied.

**Why it matters:** These are useful guided repairs but weak final evidence for implementing an insertion sort or reasoning independently about a whole reporting/query workload.

**A later repair should:** Follow them with a faded scaffold or transfer task that requires a complete loop, occurrence/stability checks, and a brief preparation/query/update comparison.

Evidence: `1602_basic_sorting.ipynb` cells 5–50; `lab.ipynb` cells 2–16; `homework.ipynb` cells 14–28.

### F09. Independent testing and debugging evidence is thinner than the taught progression (Should fix)

Chapter 5 develops contracts, refactoring checks, and AI-candidate review. Chapter 6 develops a hypothesis-driven debugger investigation and boundary-test critique. The main Chapter 6 homework asks recall questions and one TryParse snippet; its lab adds one method/test to a supplied project. It does not request an independent debugger record or justified boundary/regression suite.

**Why it matters:** The conceptual progression is stronger than the evidence students are required to produce.

**A later repair should:** Ask students to choose expected results from a contract, expose a defect, record debugging evidence, repair it, and rerun unchanged regression checks on a fresh small method.

Evidence: `0505_summary.ipynb` cells 5–21; `0602_debugging_workflow.ipynb` cells 5–19; `0603_testing.ipynb` cells 17–22; `lab.ipynb` cell 3; `homework.ipynb` cell 1.

### F10. Stale prerequisites and cross-references remain below the landing pages (Should fix)

Chapter 14 Preview Foundation Check asks for the binary-search precondition before the developed Chapter 16 lesson. Chapter 1.1 says decisions and iteration are in Chapters 3 and 5; Chapter 9.3 describes string methods as Section 3.4 even though they are now 5.4. The semantic string label resolves, but the visible number is wrong.

**Why it matters:** Correct landing pages do not remove assessment sequencing or instructional navigation drift.

**A later repair should:** Correct visible references and decide whether the Chapter 14 preview item belongs in Chapter 16 or needs an explicit earlier prerequisite. Keep stable assessment IDs through any later move.

Evidence: `preview.ipynb` cells 4–5; `0101_cs_ideas.ipynb` cell 34; `0903_text_operations.ipynb` cell 6.

### F11. Two-dimensional arrays jump from a full example to a substantial report (Could improve)

7.2 provides rectangular-array syntax, GetLength, and a complete row/column-sum report. The sales lab asks students to produce a branch-by-day report. No small in-section aggregation checkpoint bridges the demonstration and the larger task.

**Why it matters:** The topic and an implementation task are present. The gap is scaffolding, not absent 2D coverage or necessarily missing homework.

**A later repair should:** Consider one guided row-total or column-total step before the full report, without adding another lesson or a practice quota.

Evidence: `0702_twodim.ipynb` cells 14–16; `lab.ipynb` cells 14–16.

## Adoption decisions, not automatically broken promises

| Route | Current evidence | Decision needed before adding content |
| --- | --- | --- |
| CS1, Chapters 1–12: elementary array search/sort | Array accumulation, minimum/count/order scans and library sorting are present. Chapter 4 has a character search, and Chapter 8 matches message words and dictionary keys. A developed first-match array-search algorithm and elementary sorting implementation arrive in Chapter 16. | If CS1 must include implementation of these array algorithms, explicitly add that route outcome and map teaching/practice/assessment together. “There is no search anywhere in CS1” would be inaccurate. |
| CS1: general recursive problem solving | GCD has a recursive supporting variant; 5.5 is explicitly recognition-level. Developed recursion precedes tree algorithms in 17.1. | Decide whether recursion is required or optional for each CS1 adoption. An optional reading does not establish a required outcome. Keep 17.1 accessible without that optional preparation. |
| CS2 foundation, Chapters 13–20: divide-and-conquer sorting | Insertion sort is developed in 16.2. Stable merge sort is developed in 22.2 outside this route. | If a general-CS2 profile requires a developed O(n log n) sort, recommend Chapter 22 with its recursion preparation or develop prerequisites before any earlier reuse. This is a route-boundary decision rather than a missing explanation within Chapter 16's stated basic scope. |
| LINQ and functional forms | 7.1 teaches aggregation calls; 13.3 teaches a lambda, Where/Select/OrderBy/ToArray, and deferred work. | Define whether reading pipelines or independently designing queries is expected. The latter needs more practice/assessment, but all LINQ teaching is not absent. |
| Other enrichment | Enums, StringBuilder, balanced rotations, topological ordering and postfix evaluation are not independently promised core outcomes in this map. Random and params already have retained teaching in assignments. | Evaluate adoption value and workload rather than treating every comparator topic as a mandatory addition. Correct content placement where an extension is assigned. |
| Desktop projects | BOOK_PLAN.md gives a path toward desktop applications. The individual-project appendix explicitly expects a console application and makes graphical work optional; the project overview leaves framework selection to the instructor. | Clarify core-console versus optional-desktop expectations. My earlier blanket agreement to exclude desktop GUI from scope was too broad; it should not override this existing project plan. No new required GUI chapter is inferred. |

## Coverage that should be retained

Chapter 1 has substantive stakeholder, harm, privacy, accessibility and AI-candidate explanations, worked cases, and assignment checks. Chapter 6 has a genuine debugging and test-design progression, despite the framework/assessment problems. Chapter 11 develops references, structs, records, ownership and nullability rather than merely naming them. Section 13.2 already includes cost models, a growth-rate table, case distinctions, amortization and auxiliary space. Chapters 14–15 and 17 require substantial update logic, invariants, boundary cases and explanations. These findings support targeted repair, not wholesale replacement or removal.

## How to repair later

1. Correct prerequisite placement and conflicting explanations, particularly the validation calls and testing workflow.
2. Define what each outcome requires students to produce: an explanation/trace, a repair, an implementation, a comparison, or a test suite. Then add missing assessment links while keeping existing starter tasks.
3. Fill the explicit iterator, structs/records and coordinated-index assessment gaps; strengthen algorithmic independence in Chapters 16 and 18–20.
4. Correct stale preview and visible chapter references.
5. Resolve adoption-route decisions before adding new required subjects or moving chapters.

Each later change should update the relevant MATERIALS.md and ORGANIZATION.md, preserve original explanation/exercise variations and assessment IDs, and receive source, runnable-code and rendered checks appropriate to that change. None of these repairs has been implemented by this audit.

## Chapter-by-chapter map

The full structured map is `mapping.json`; the interactive review exposes excerpts for each evidence reference. These chapter summaries include every numbered core objective. E = explanation; W = worked example/case/trace; G = section practice; A = assessment. Section practice may be a prediction or reasoning prompt rather than a runnable exercise cell.

### Chapter 1. Computing, Programs, and Responsibility

**Plan role:** Computing/IPO and representation; responsibility/AI; first saved program and checks.

Plans: `chapters/01_context/MATERIALS.md`, `chapters/01_context/ORGANIZATION.md`

**C01-O1: Describe hardware, software, data, and the input-process-output model.** (supported)

- E: `0101_cs_ideas.ipynb` cells 5–11.
- W: `0101_cs_ideas.ipynb` cells 10–11.
- G: `0101_cs_ideas.ipynb` cells 10–11.
- A: `preview.ipynb` cells 2–3; `additional_practice.ipynb` cell 4.

IPO is applied to a report, not merely named.

**C01-O2: Express a small business task as a precise procedure with checkable output.** (partial)

- E: `0101_cs_ideas.ipynb` cells 18–20.
- W: `0101_cs_ideas.ipynb` cell 18.
- G: `0101_cs_ideas.ipynb` cell 18.
- A: `additional_practice.ipynb` cell 4; `lab.ipynb` cell 2; `homework.ipynb` cells 18–19.

A procedure is requested in section practice, but standard homework asks for printing supplied instructions rather than designing a new algorithm; conceptual review supplies related explanation.

**C01-O3: Identify stakeholders and apply questions about harm, necessary data, and responsible action.** (supported)

- E: `0102_computing_responsibility.ipynb` cells 6–14.
- W: `0102_computing_responsibility.ipynb` cells 6–14.
- G: `0102_computing_responsibility.ipynb` cells 7–8; `0102_computing_responsibility.ipynb` cell 14.
- A: `lab.ipynb` cell 2; `lab.ipynb` cells 12–16; `homework.ipynb` cells 3–6.

Stakeholder reasoning is integrated with the reminder task and conceptual checks.

**C01-O4: Produce clear output using fictional data and explain privacy, accessibility, and attribution choices.** (supported)

- E: `0102_computing_responsibility.ipynb` cells 14–22.
- W: `0102_computing_responsibility.ipynb` cells 17–19.
- G: `0102_computing_responsibility.ipynb` cells 18–19.
- A: `lab.ipynb` cells 12–16; `homework.ipynb` cells 9–10; `homework.ipynb` cells 21–28.

Privacy, accessible messages, and attribution have concrete applications.

**C01-O5: Explain the roles of source code, the compiler, runtime, editor, and terminal.** (supported)

- E: `0101_cs_ideas.ipynb` cells 25–31; `0103_program_structure.ipynb` cells 70–76.
- W: `0101_cs_ideas.ipynb` cells 27–28; `0103_program_structure.ipynb` cells 7–8.
- G: `0103_program_structure.ipynb` cells 26–33.
- A: `preview.ipynb` cells 14–21; `additional_practice.ipynb` cell 4.

Explanation and conceptual review cover execution/tool roles.

**C01-O6: Create, edit, save, and run a C# console project and identify its entry point.** (supported)

- E: `0103_program_structure.ipynb` cells 5–8; `0103_program_structure.ipynb` cells 25–28.
- W: `0103_program_structure.ipynb` cells 7–8.
- G: `0103_program_structure.ipynb` cells 26–33.
- A: `lab.ipynb` cell 18.

Local save/run handoff is explicitly assigned.

**C01-O7: Distinguish an AI-generated suggestion from verified behavior and describe how to check it.** (partial)

- E: `0102_computing_responsibility.ipynb` cell 25.
- W: `0102_computing_responsibility.ipynb` cell 25.
- G: `0102_computing_responsibility.ipynb` cell 25.
- A: `homework.ipynb` cells 7–8.

The conceptual boundary counterexample is taught; independent assessment is one true/false judgment rather than review of a fresh prepared candidate.

**C01-O8: Read basic C# syntax, predict labeled output, and repair simple compiler errors.** (supported)

- E: `0103_program_structure.ipynb` cells 35–65.
- W: `0103_program_structure.ipynb` cells 37–39; `0103_program_structure.ipynb` cells 57–58.
- G: `0103_program_structure.ipynb` cells 31–33; `0103_program_structure.ipynb` cells 64–66.
- A: `lab.ipynb` cells 3–16; `homework.ipynb` cells 15–28.

Prediction and compiler repair occur in content; output transfer occurs in homework.

### Chapter 2. Variables, Data Types, and Operators

**Plan role:** Variables/state, types/conversion, operators/library calls, then console I/O.

Plans: `chapters/02_var_data/MATERIALS.md`, `chapters/02_var_data/ORGANIZATION.md`

**C02-O1: Declare and initialize variables, then trace assignment and reassignment through changes in program state.** (supported)

- E: `0201_variables_types.ipynb` cells 7–32.
- W: `0201_variables_types.ipynb` cells 20–32.
- G: `0201_variables_types.ipynb` cells 30–32.
- A: `lab.ipynb` cells 2–4; `homework.ipynb` cells 3–4; `additional_practice.ipynb` cells 3–5.

Assignment and state tracing include prediction and a changed example.

**C02-O2: Choose numeric, Boolean, character, and string types appropriate to a stated data requirement.** (supported)

- E: `0204_types_conversion.ipynb` cells 9–29.
- W: `0204_types_conversion.ipynb` cells 28–59.
- G: `0204_types_conversion.ipynb` cells 78–81.
- A: `lab.ipynb` cells 2–4; `homework.ipynb` cells 14–18.

Type choice is applied to amounts, counts, and fractional results.

**C02-O3: Predict arithmetic, comparison, logical, and string-expression results using C# precedence and division rules.** (supported)

- E: `0202_operators_built_in_methods.ipynb` cells 8–66.
- W: `0202_operators_built_in_methods.ipynb` cells 28–60.
- G: `0202_operators_built_in_methods.ipynb` cells 93–94.
- A: `lab.ipynb` cells 11–13; `homework.ipynb` cells 14–18; `additional_practice.ipynb` cells 24–26.

Core arithmetic and Boolean use is independently practiced; bitwise/time material is an extension.

**C02-O4: Read a built-in method signature, supply arguments, and use results from methods such as `Math.Round` and `int.Parse`.** (supported)

- E: `0202_operators_built_in_methods.ipynb` cells 69–94.
- W: `0202_operators_built_in_methods.ipynb` cells 77–82.
- G: `0202_operators_built_in_methods.ipynb` cells 93–94.
- A: `lab.ipynb` cells 5–7; `homework.ipynb` cells 26–28.

Students must keep returned results rather than assume receiver mutation.

**C02-O5: Convert values with casts or parsing, read console input, and produce labeled, formatted output with checkable results.** (supported)

- E: `0204_types_conversion.ipynb` cells 61–81; `0203_input_output.ipynb` cells 6–58.
- W: `0203_input_output.ipynb` cells 31–58.
- G: `0204_types_conversion.ipynb` cells 78–81.
- A: `lab.ipynb` cells 8–16; `homework.ipynb` cells 23–28; `additional_practice.ipynb` cells 18–20.

Parsing, conversion, and output receive multiple tasks.

### Chapter 3. Decisions

**Plan role:** Boolean modeling and branch selection in top-level programs; no user-defined method prerequisite.

Plans: `chapters/03_decision/MATERIALS.md`, `chapters/03_decision/ORGANIZATION.md`

**C03-O1: Write `if`, `else if`, and `else` chains correctly.** (supported)

- E: `0302_ifstatement.ipynb` cells 13–44.
- W: `0302_ifstatement.ipynb` cell 14; `0302_ifstatement.ipynb` cells 27–29.
- G: `0302_ifstatement.ipynb` cells 5–10.
- A: `lab.ipynb` cells 2–13; `additional_practice.ipynb` cells 9–22.

Payroll and eligibility tasks transfer branch selection.

**C03-O2: Construct Boolean expressions with comparison and logical operators.** (supported)

- E: `0301_intro_decision.ipynb` cells 12–29.
- W: `0301_intro_decision.ipynb` cell 22; `0301_intro_decision.ipynb` cells 27–29.
- G: `0302_ifstatement.ipynb` cells 5–10.
- A: `homework.ipynb` cells 3–4; `additional_practice.ipynb` cells 13–18.

Compound conditions and short-circuit reasoning are exercised.

**C03-O3: Handle multiple exclusive cases with a `switch` statement.** (supported)

- E: `0302_ifstatement.ipynb` cells 56–69.
- W: `0302_ifstatement.ipynb` cell 61; `0302_ifstatement.ipynb` cell 66.
- G: **No matched evidence**.
- A: `lab.ipynb` cells 14–16; `preview.ipynb` cell 3.

Switch is implemented in the integrated payroll lab. No distinct content-section guided switch task was found; a further homework item is not automatically necessary.

**C03-O4: Trace which branch of a conditional statement will execute.** (supported)

- E: `0302_ifstatement.ipynb` cells 5–10.
- W: `0302_ifstatement.ipynb` cell 9; `0302_ifstatement.ipynb` cell 34.
- G: `0302_ifstatement.ipynb` cells 7–10.
- A: `homework.ipynb` cells 5–12.

Independent trace and equivalence questions match the outcome.

**C03-O5: Avoid common conditional mistakes such as dangling `else` and boundary errors.** (supported)

- E: `0302_ifstatement.ipynb` cells 46–69.
- W: `0302_ifstatement.ipynb` cell 50; `0302_ifstatement.ipynb` cell 61.
- G: `0302_ifstatement.ipynb` cells 5–10.
- A: `homework.ipynb` cells 7–14; `lab.ipynb` cells 11–16.

Nesting, dangling else, repairs, and threshold checks have evidence.

### Chapter 4. Iteration

**Plan role:** Counted/condition loops, validation and boundary checks; GCD is supporting reading.

Plans: `chapters/04_iteration/MATERIALS.md`, `chapters/04_iteration/ORGANIZATION.md`

**C04-O1: Write counted loops with `for` and open-ended loops with `while`.** (supported)

- E: `0402_for_statements.ipynb` cells 5–9; `0403_while_statement.ipynb` cells 4–8.
- W: `0402_for_statements.ipynb` cells 7–9; `0403_while_statement.ipynb` cells 7–8.
- G: `0403_while_statement.ipynb` cells 33–39.
- A: `lab.ipynb` cells 2–9; `homework.ipynb` cells 1–3.

Loop syntax and stopping conditions connect to repeated input.

**C04-O2: Trace loop variables through repeated iterations.** (supported)

- E: `0401_iteration.ipynb` cells 11–17; `0402_for_statements.ipynb` cells 12–13.
- W: `0402_for_statements.ipynb` cells 38–40.
- G: `0402_for_statements.ipynb` cells 54–55; `0403_while_statement.ipynb` cells 38–39.
- A: `homework.ipynb` cells 1–3; `additional_practice.ipynb` cell 21.

Tracing is assessed separately from writing loops.

**C04-O3: Use loops to process strings, numeric ranges, and repeated prompts.** (supported)

- E: `0402_for_statements.ipynb` cells 46–75; `0403_while_statement.ipynb` cells 14–39.
- W: `0402_for_statements.ipynb` cell 55; `0402_for_statements.ipynb` cells 69–75.
- G: `0402_for_statements.ipynb` cell 58; `0403_while_statement.ipynb` cells 33–39.
- A: `lab.ipynb` cells 5–16; `additional_practice.ipynb` cells 21–27.

Ranges, strings, tables, and accumulators are represented.

**C04-O4: Use `break` and `continue` only when they clarify loop behavior.** (supported)

- E: `0401_iteration.ipynb` cells 19–23; `0402_for_statements.ipynb` cells 15–20.
- W: `0402_for_statements.ipynb` cells 17–20; `0402_for_statements.ipynb` cell 58.
- G: `0402_for_statements.ipynb` cell 58.
- A: `homework.ipynb` cell 1; `lab.ipynb` cells 11–16.

Early exit has a worked character search and application.

**C04-O5: Recognize and avoid infinite loops and off-by-one mistakes.** (supported)

- E: `0401_iteration.ipynb` cells 22–23; `0403_while_statement.ipynb` cells 12–15.
- W: `0403_while_statement.ipynb` cells 7–8; `0403_while_statement.ipynb` cell 39.
- G: `0402_for_statements.ipynb` cell 58; `0403_while_statement.ipynb` cells 38–39.
- A: `lab.ipynb` cells 5–16; `homework.ipynb` cell 3; `additional_practice.ipynb` cells 23–27.

Boundary/termination practice exists; do not call the loop chapter empty.

### Chapter 5. Methods

**Plan role:** Five readings: design/calls, parameters, results/contracts, strings, composition/checks.

Plans: `chapters/05_methods/MATERIALS.md`, `chapters/05_methods/ORGANIZATION.md`

**C05-O1: Define and call methods with names, parameter lists, and return types that communicate their responsibilities.** (supported)

- E: `0501_intro_methods.ipynb` cells 5–22.
- W: `0501_intro_methods.ipynb` cells 10–22.
- G: `0501_intro_methods.ipynb` cells 23–26.
- A: `lab.ipynb` cells 2–15; `homework.ipynb` cells 1–6.

Calls and definitions are developed before the exercises.

**C05-O2: Trace arguments, parameters, local scope, and returned values between a caller and a method.** (supported)

- E: `0503_parameter.ipynb` cells 11–29.
- W: `0503_parameter.ipynb` cells 27–29; `0502_signature_call.ipynb` cells 9–23.
- G: `0503_parameter.ipynb` cells 45–48.
- A: `homework.ipynb` cells 7–13; `lab.ipynb` cells 5–7.

Parameter, local-scope, and return tracing have substantial original questions.

**C05-O3: Distinguish a `void` method from a value-returning method and use a returned result in a larger expression.** (supported)

- E: `0502_signature_call.ipynb` cells 5–45.
- W: `0502_signature_call.ipynb` cells 9–23; `0502_signature_call.ipynb` cells 38–40.
- G: `0502_signature_call.ipynb` cells 55–58.
- A: `homework.ipynb` cells 1–6; `lab.ipynb` cells 5–12.

Printing and returning are distinguished explicitly.

**C05-O4: Decompose repeated calculations into methods with explicit input and result contracts.** (partial)

- E: `0505_summary.ipynb` cells 5–16.
- W: `0505_summary.ipynb` cells 10–16.
- G: `0505_summary.ipynb` cells 18–21.
- A: `lab.ipynb` cells 16–18; `additional_practice.ipynb` cells 36–39.

Composition is applied in the SKU task, but independent homework chiefly tests declarations/traces and string methods; optional Grade Calculation 2 provides fuller decomposition.

**C05-O5: Clean, search, and extract text with string methods while preserving the original string unless a result is assigned.** (supported)

- E: `0504_strings.ipynb` cells 7–46.
- W: `0504_strings.ipynb` cells 11–36.
- G: `0504_strings.ipynb` cells 44–47.
- A: `lab.ipynb` cells 16–18; `homework.ipynb` cells 14–16; `additional_practice.ipynb` cells 4–11.

String transformations and returned values transfer beyond recall.

**C05-O6: Check methods with expected results and boundary cases, including reviewing a prepared AI suggestion against its contract.** (partial)

- E: `0505_summary.ipynb` cells 7–16; `0502_signature_call.ipynb` cells 48–53.
- W: `0505_summary.ipynb` cells 10–16; `0502_signature_call.ipynb` cells 50–53.
- G: `0505_summary.ipynb` cells 18–21.
- A: `lab.ipynb` cells 19–20; `homework.ipynb` cell 16.

Boundary checks are requested, but independent test selection and a fresh AI-method review are not required in the standard homework.

### Chapter 6. Testing, Debugging, and Error Handling

**Plan role:** Validation/exceptions, hypothesis-driven debugging, repeatable tests; computing/society supports the core.

Plans: `chapters/06_exceptions_testing/MATERIALS.md`, `chapters/06_exceptions_testing/ORGANIZATION.md`

**C06-O1: Choose validation or exception handling for a stated failure and use `TryParse` for expected invalid input.** (supported)

- E: `0601_error_handling.ipynb` cells 5–11; `0601_error_handling.ipynb` cells 18–28.
- W: `0601_error_handling.ipynb` cells 6–9; `0601_error_handling.ipynb` cells 27–28.
- G: `0601_error_handling.ipynb` cells 8–9; `0601_error_handling.ipynb` cells 44–45.
- A: `homework.ipynb` cell 1.

Homework question 5 applies TryParse; the expected-failure distinction is taught.

**C06-O2: Trace `try`, matching `catch`, and `finally` paths and report or throw failures intentionally.** (partial)

- E: `0601_error_handling.ipynb` cells 13–23; `0601_error_handling.ipynb` cells 34–43.
- W: `0601_error_handling.ipynb` cells 15–16; `0601_error_handling.ipynb` cell 23.
- G: `0601_error_handling.ipynb` cells 44–45.
- A: `homework.ipynb` cell 1.

Control-flow explanation is present, but practical handling is weakly assessed; framework and rethrow explanations also contain the specific issues listed in findings.

**C06-O3: Reproduce a defect, form a hypothesis, and use breakpoints, watches, stepping, and the call stack to test it.** (partial)

- E: `0602_debugging_workflow.ipynb` cells 5–43.
- W: `0602_debugging_workflow.ipynb` cells 6–10.
- G: `0602_debugging_workflow.ipynb` cells 9–19; `0602_debugging_workflow.ipynb` cells 45–46.
- A: `lab.ipynb` cell 3; `homework.ipynb` cell 1.

Content has a debugger investigation; the main homework contains no independent debugger evidence task.

**C06-O4: Write repeatable method tests with explicit expected results and meaningful normal, boundary, and failure cases.** (partial)

- E: `0603_testing.ipynb` cells 8–14; `0603_testing.ipynb` cells 24–25.
- W: `0603_testing.ipynb` cell 9; `0603_testing.ipynb` cell 14.
- G: `0603_testing.ipynb` cells 17–22.
- A: `lab.ipynb` cell 3; `unit_testing_walkthrough.ipynb` cells 4–12; `homework.ipynb` cell 1.

The complete correct MSTest workflow is under assignments; the content setup explanation mixes frameworks and reverses assertion arguments.

**C06-O5: Verify a repair with regression checks and evaluate whether proposed tests challenge the actual contract.** (partial)

- E: `0602_debugging_workflow.ipynb` cells 17–19; `0603_testing.ipynb` cells 17–22.
- W: `0603_testing.ipynb` cells 20–22.
- G: `0603_testing.ipynb` cells 19–22.
- A: `unit_testing_walkthrough.ipynb` cells 10–12; `homework.ipynb` cell 1.

Regression repair is practiced; adding one test in the copied project does not establish independent boundary-case suite design.

### Chapter 7. Arrays

**Plan role:** Array creation, processing/sharing, and rectangular data; retain original array practice.

Plans: `chapters/07_arrays/MATERIALS.md`, `chapters/07_arrays/ORGANIZATION.md`

**C07-O1: Explain why an array is a collection, then declare, initialize, and access one-dimensional arrays within their valid index ranges.** (supported)

- E: `0701_onedim.ipynb` cells 5–21.
- W: `0701_onedim.ipynb` cells 6–11.
- G: `0701_onedim.ipynb` cells 9–11.
- A: `lab.ipynb` cells 2–7; `homework.ipynb` cells 1–3; `additional_practice.ipynb` cells 18–22.

Creation, empty/last indexes, and safe reads are developed.

**C07-O2: Traverse arrays with `for` and `foreach` to calculate results and update elements where appropriate.** (supported)

- E: `0703_array_processing.ipynb` cells 5–9.
- W: `0703_array_processing.ipynb` cell 5; `0703_array_processing.ipynb` cell 9.
- G: `0703_array_processing.ipynb` cell 8.
- A: `lab.ipynb` cells 2–10; `homework.ipynb` cells 5–7; `additional_practice.ipynb` cells 18–22.

Totals, minimum indexes, counts, and ordering scans have applications.

**C07-O3: Trace array reference assignment and distinguish sharing from making a separate shallow copy.** (supported)

- E: `0703_array_processing.ipynb` cell 8; `0703_array_processing.ipynb` cells 17–18.
- W: `0703_array_processing.ipynb` cell 18.
- G: `0703_array_processing.ipynb` cell 8.
- A: `homework.ipynb` cells 7–19.

The original homework tests element mutation versus parameter reassignment.

**C07-O4: Pass arrays to methods and return array results while explaining which operations can change the caller's elements.** (supported)

- E: `0703_array_processing.ipynb` cells 7–18.
- W: `0703_array_processing.ipynb` cell 9; `0703_array_processing.ipynb` cell 18.
- G: `0703_array_processing.ipynb` cell 8.
- A: `lab.ipynb` cells 11–13; `homework.ipynb` cells 7–19; `additional_practice.ipynb` cells 6–13.

Destination and newly allocated arrays are distinguished.

**C07-O5: Declare and process rectangular arrays using the correct bounds for each dimension.** (partial)

- E: `0702_twodim.ipynb` cells 5–16.
- W: `0702_twodim.ipynb` cells 7–16.
- G: **No matched evidence**.
- A: `lab.ipynb` cells 14–16.

Worked row/column processing leads to a substantial lab implementation, but there is no small content-section guided aggregation checkpoint before that larger report.

### Chapter 8. Data Collections

**Plan role:** Families/selection, shared operations, lists, dictionaries, and reference behavior.

Plans: `chapters/08_collections/MATERIALS.md`, `chapters/08_collections/ORGANIZATION.md`

**C08-O1: Match the introductory collection families to their access rules and choose a family for a stated business task.** (partial)

- E: `0801_collections.ipynb` cells 5–16.
- W: `0801_collections.ipynb` cells 10–16.
- G: `0801_collections.ipynb` cell 16.
- A: `homework.ipynb` cells 1–7.

Array/list/dictionary choice is assessed; broader families remain mostly guided orientation rather than an independently justified selection task.

**C08-O2: Compare shared collection operations while using the correct API for an array, list, dictionary, set, stack, or queue.** (supported)

- E: `0804_collection_operations.ipynb` cells 5–58.
- W: `0804_collection_operations.ipynb` cells 23–57.
- G: `0804_collection_operations.ipynb` cell 5; `0804_collection_operations.ipynb` cells 59–69.
- A: `homework.ipynb` cells 10–21; `lab.ipynb` cells 2–16.

Shared operations receive conceptual checks; implementations of all families are not claimed here.

**C08-O3: Create and update type-safe `List<T>` values and explain indexing, count, capacity, and traversal behavior.** (supported)

- E: `0802_list.ipynb` cells 8–49.
- W: `0802_list.ipynb` cells 10–49.
- G: `0802_list.ipynb` cells 52–65.
- A: `lab.ipynb` cells 2–4; `homework.ipynb` cells 27–29.

List growth, positions, and edits have practice.

**C08-O4: Store and retrieve `Dictionary<TKey, TValue>` entries using an explicit key and missing-value policy.** (supported)

- E: `0803_dictionary.ipynb` cells 7–55.
- W: `0803_dictionary.ipynb` cells 17–40; `0803_dictionary.ipynb` cells 53–55.
- G: `0803_dictionary.ipynb` cells 42–47.
- A: `lab.ipynb` cells 5–16; `homework.ipynb` cells 30–35.

Missing-versus-zero and update-versus-add policies are assessed.

**C08-O5: Distinguish collection reference assignment from copying elements, and explain the limits of a shallow copy.** (supported)

- E: `0804_collection_operations.ipynb` cells 59–69.
- W: `0804_collection_operations.ipynb` cells 63–69.
- G: `0703_array_processing.ipynb` cell 8.
- A: `homework.ipynb` cells 3–5; `homework.ipynb` cells 36–38.

Aliasing and outer-copy independence receive coding transfer. Earlier Chapter 7 guided alias prediction provides preparation.

**C08-O6: Check collection operations with empty inputs, duplicates, missing keys, and mutations that affect traversal.** (supported)

- E: `0802_list.ipynb` cells 46–49; `0803_dictionary.ipynb` cells 15–40.
- W: `0802_list.ipynb` cells 47–49; `0803_dictionary.ipynb` cells 53–55.
- G: `0803_dictionary.ipynb` cells 42–47.
- A: `homework.ipynb` cells 24–38; `lab.ipynb` cells 17–18.

Mutation, duplicates, and missing-key cases have explicit tasks.

### Chapter 9. Files and Text

**Plan role:** Three core file/text readings; regex supports and privacy/security is optional.

Plans: `chapters/09_files_text/MATERIALS.md`, `chapters/09_files_text/ORGANIZATION.md`

**C09-O1: Read and write text with `File`, `StreamReader`, and `StreamWriter` under an explicit overwrite or append policy.** (supported)

- E: `0901_stream_file.ipynb` cells 17–40.
- W: `0901_stream_file.ipynb` cells 24–40.
- G: `0902_file_operations.ipynb` cells 8–10.
- A: `lab.ipynb` cells 2–7; `homework.ipynb` cell 1.

Read/write and disposal tasks progress to file processing.

**C09-O2: Construct and inspect paths and handle file resources and expected I/O failures intentionally.** (supported)

- E: `0902_file_operations.ipynb` cells 5–25.
- W: `0902_file_operations.ipynb` cells 6–10.
- G: `0902_file_operations.ipynb` cells 8–10.
- A: `homework.ipynb` cell 1; `additional_practice.ipynb` cells 4–10.

Paths and file ownership are exercised, including cancellation in extended practice.

**C09-O3: Clean and split text, validate fields, and convert accepted records into typed values.** (partial)

- E: `0903_text_operations.ipynb` cells 5–28.
- W: `0903_text_operations.ipynb` cells 10–18; `0903_text_operations.ipynb` cell 28.
- G: `0903_text_operations.ipynb` cells 35–38.
- A: `lab.ipynb` cells 11–16; `homework.ipynb` cells 5–6.

Record processing is developed, but the custom multi-out parser signature appears without an explanation of defining out parameters.

**C09-O4: Check an import against malformed, missing, empty, and boundary cases without silently accepting invalid records.** (supported)

- E: `0903_text_operations.ipynb` cells 5–28; `0903_text_operations.ipynb` cells 35–38.
- W: `0903_text_operations.ipynb` cell 28; `0903_text_operations.ipynb` cells 36–38.
- G: `0903_text_operations.ipynb` cells 35–38.
- A: `lab.ipynb` cells 8–16; `homework.ipynb` cells 5–6.

Malformed structure and parsing cases have practical work; original Grade Files extends independent integration.

### Chapter 10. Classes and Objects

**Plan role:** Class syntax, properties, instance state; Averager supports. Book List requires Chapter 11.

Plans: `chapters/10_classes/MATERIALS.md`, `chapters/10_classes/ORGANIZATION.md`

**C10-O1: Define classes with fields, constructors, methods, and properties for a stated business responsibility.** (supported)

- E: `1001_class_syntax.ipynb` cells 7–18.
- W: `1001_class_syntax.ipynb` cells 8–18.
- G: `1003_class_instance.ipynb` cells 16–20.
- A: `lab.ipynb` cells 5–7; `homework.ipynb` cells 14–16; `additional_practice.ipynb` cells 8–11.

Class construction is practiced in both scaffolded and fuller retained tasks.

**C10-O2: Construct valid instances and protect their state with private fields and controlled public operations.** (supported)

- E: `1002_properties.ipynb` cells 4–16; `1003_class_instance.ipynb` cells 8–11.
- W: `1003_class_instance.ipynb` cell 11.
- G: `1003_class_instance.ipynb` cells 16–20.
- A: `lab.ipynb` cells 8–10; `homework.ipynb` cells 17–22.

Validation before mutation is explicitly assessed.

**C10-O3: Trace changes to independent objects and distinguish instance members from static members.** (supported)

- E: `1003_class_instance.ipynb` cells 5–15; `1001_class_syntax.ipynb` cells 16–18.
- W: `1003_class_instance.ipynb` cells 7–15.
- G: `1003_class_instance.ipynb` cells 16–20.
- A: `lab.ipynb` cells 11–16; `homework.ipynb` cells 3–12; `homework.ipynb` cells 23–28.

Independent instance state and a shared sequence counter have transfer.

**C10-O4: Explain class reference assignment and distinguish a shared object from an independent value.** (supported)

- E: `1003_class_instance.ipynb` cells 5–15; `1004_averager.ipynb` cells 14–18.
- W: `1004_averager.ipynb` cells 17–18.
- G: `1004_averager.ipynb` cells 7–11.
- A: `homework.ipynb` cells 3–4; `additional_practice.ipynb` cells 4–11.

Object independence and aliasing are developed; Chapter 11 deepens copying policies.

**C10-O5: Check constructor and operation contracts using normal and invalid inputs.** (supported)

- E: `1003_class_instance.ipynb` cells 5–15.
- W: `1003_class_instance.ipynb` cells 7–15.
- G: `1003_class_instance.ipynb` cells 16–20.
- A: `homework.ipynb` cells 14–28; `additional_practice.ipynb` cells 4–11.

Constructor and rejected-operation drivers test observable state.

### Chapter 11. Object Design and Composition

**Plan role:** References, structs/records, composition, collaboration tests; deeper nullability supports.

Plans: `chapters/11_object_design/MATERIALS.md`, `chapters/11_object_design/ORGANIZATION.md`

**C11-O1: Trace aliases and distinguish object identity from business equality.** (supported)

- E: `1101_objects_references.ipynb` cells 5–17.
- W: `1101_objects_references.ipynb` cell 11; `1101_objects_references.ipynb` cell 16.
- G: `1101_objects_references.ipynb` cells 26–30.
- A: `homework.ipynb` cells 3–6; `homework.ipynb` cells 14–19.

Reference identity and domain identity have explicit checks.

**C11-O2: Explain the effect of sharing mutable and immutable objects, and distinguish struct copying from record-class copying and equality.** (partial)

- E: `1101_objects_references.ipynb` cells 18–24; `1105_value_record_types.ipynb` cells 5–20.
- W: `1105_value_record_types.ipynb` cells 9–20.
- G: `1105_value_record_types.ipynb` cell 5; `1105_value_record_types.ipynb` cell 20.
- A: `homework.ipynb` cells 3–10.

Class-copy concepts are assessed, but no preview/lab/homework task requires struct/record construction, equality, or with-copy reasoning.

**C11-O3: Design collaborating product, order-line, and order classes.** (supported)

- E: `1102_composition.ipynb` cells 5–14.
- W: `1102_composition.ipynb` cell 14.
- G: `1102_composition.ipynb` cells 26–30.
- A: `lab.ipynb` cells 2–13; `homework.ipynb` cells 20–22.

Order-line responsibility is implemented and applied to a new cost model.

**C11-O4: Protect a private collection and explain shallow snapshot behavior.** (supported)

- E: `1102_composition.ipynb` cells 16–24.
- W: `1102_composition.ipynb` cells 19–24.
- G: `1103_testing_collaboration.ipynb` cells 26–30.
- A: `lab.ipynb` cells 14–16; `homework.ipynb` cells 7–10; `homework.ipynb` cells 23–25.

Snapshot behavior and private storage protection are assessed.

**C11-O5: Test boundaries and refactor while preserving observable behavior.** (partial)

- E: `1103_testing_collaboration.ipynb` cells 5–23.
- W: `1103_testing_collaboration.ipynb` cells 13–18.
- G: `1103_testing_collaboration.ipynb` cells 26–30.
- A: `lab.ipynb` cells 14–16; `homework.ipynb` cells 26–28.

Rejected-state checks are present; the main homework does not require an actual refactoring with before/after regression evidence.

### Chapter 12. Inheritance, Interfaces, and Polymorphism

**Plan role:** Inheritance/substitution, runtime dispatch/abstract classes, interfaces; retained OOP examples support.

Plans: `chapters/12_oop/MATERIALS.md`, `chapters/12_oop/ORGANIZATION.md`

**C12-O1: Construct a small hierarchy with validated base and derived state.** (supported)

- E: `1201_inheritance.ipynb` cells 5–23.
- W: `1201_inheritance.ipynb` cells 14–19.
- G: `1201_inheritance.ipynb` cells 24–28.
- A: `lab.ipynb` cells 2–7; `homework.ipynb` cells 14–16.

Base validation and subtype results are applied.

**C12-O2: Explain virtual dispatch and distinguish overriding from overloading.** (supported)

- E: `1202_polymorphism.ipynb` cells 5–14.
- W: `1202_polymorphism.ipynb` cell 10.
- G: `1202_polymorphism.ipynb` cells 24–28.
- A: `lab.ipynb` cells 8–10; `homework.ipynb` cells 17–19; `additional_practice.ipynb` cells 10–13.

Dispatch has a shared client and retained Shape implementation tasks.

**C12-O3: Implement concrete behavior for an abstract class.** (supported)

- E: `1202_polymorphism.ipynb` cells 16–22.
- W: `1202_polymorphism.ipynb` cell 19.
- G: `1202_polymorphism.ipynb` cells 24–28.
- A: `homework.ipynb` cells 17–19; `additional_practice.ipynb` cells 10–13.

Abstract behavior is independently supplied through an override.

**C12-O4: Supply interchangeable components through interfaces and constructors.** (supported)

- E: `1203_interfaces.ipynb` cells 5–20.
- W: `1203_interfaces.ipynb` cells 10–20.
- G: `1203_interfaces.ipynb` cells 25–29.
- A: `lab.ipynb` cells 11–16; `homework.ipynb` cells 20–25.

Interfaces and injected collaborators have coding tasks.

**C12-O5: Test shared contracts and choose composition or inheritance from requirements.** (partial)

- E: `1201_inheritance.ipynb` cells 21–28; `1203_interfaces.ipynb` cells 22–29.
- W: `1203_interfaces.ipynb` cell 20.
- G: `1203_interfaces.ipynb` cells 25–29.
- A: `homework.ipynb` cells 5–12; `homework.ipynb` cells 26–28.

Bad substitution is detected, but students rarely justify the composition-versus-inheritance choice for a fresh design.

### Chapter 13. Abstract Data Types

**Plan role:** ADT contracts, representation/cost baseline, generic policies, and iteration.

Plans: `chapters/13_abstract_data_types/MATERIALS.md`, `chapters/13_abstract_data_types/ORGANIZATION.md`

**C13-O1: Define an abstract data type by its values and operations.** (supported)

- E: `1301_adt_contracts.ipynb` cells 3–20.
- W: `1301_adt_contracts.ipynb` cell 14.
- G: `1301_adt_contracts.ipynb` cells 21–22.
- A: `lab.ipynb` cells 2–16; `homework.ipynb` cells 3–4.

Observable undo histories support contract-first reasoning.

**C13-O2: Distinguish an interface from an implementation.** (supported)

- E: `1301_adt_contracts.ipynb` cells 6–20; `1302_representations_costs.ipynb` cells 3–18.
- W: `1302_representations_costs.ipynb` cells 14–18.
- G: `1302_representations_costs.ipynb` cells 27–28.
- A: `homework.ipynb` cells 3–4; `homework.ipynb` cells 11–12.

Interface/representation separation has conceptual assessment and implemented history behavior.

**C13-O3: Trace references and object state in memory diagrams.** (partial)

- E: `1302_representations_costs.ipynb` cells 3–18.
- W: `1302_representations_costs.ipynb` cells 14–18.
- G: `1302_representations_costs.ipynb` cells 27–28.
- A: `homework.ipynb` cells 3–4.

Reference diagrams are requested in content practice; assignments do not independently require a representation trace.

**C13-O4: Use generics to write reusable collection-style code.** (partial)

- E: `1303_generics.ipynb` cells 3–29.
- W: `1303_generics.ipynb` cells 13–29.
- G: `1303_generics.ipynb` cells 35–36.
- A: `lab.ipynb` cells 2–16; `homework.ipynb` cells 14–16.

The generic implementation is mostly supplied; homework 6 changes Push(0) to Push(42), not a new generic abstraction.

**C13-O5: Explain input size, Big-O growth, amortized operations, and auxiliary space.** (partial)

- E: `1302_representations_costs.ipynb` cells 19–26.
- W: `1302_representations_costs.ipynb` cells 21–23.
- G: `1302_representations_costs.ipynb` cell 23; `1302_representations_costs.ipynb` cells 27–28.
- A: `preview.ipynb` cells 3–4; `homework.ipynb` cells 11–12.

Quantitative growth and amortization are taught but assessed mainly through recognition rather than deriving counts or a bound.

**C13-O6: Compare basic operation costs for common collection representations.** (partial)

- E: `1302_representations_costs.ipynb` cells 25–28.
- W: `1302_representations_costs.ipynb` cell 26.
- G: `1302_representations_costs.ipynb` cells 27–28.
- A: `homework.ipynb` cells 11–12.

A workload-cost true/false item does not test a reasoned representation comparison; stronger work arrives in Chapter 14.

**C13-O7: Implement `IEnumerable<T>` using `yield return` so a custom type supports `foreach`.** (gap)

- E: `1304_iterators.ipynb` cells 4–23.
- W: `1304_iterators.ipynb` cells 14–20.
- G: `1304_iterators.ipynb` cell 10; `1304_iterators.ipynb` cells 24–25.
- A: **No matched evidence**.

No preview/lab/homework item matches the explicit outcome to implement IEnumerable<T> with yield return.

### Chapter 14. Arrays and Linked Lists

**Plan role:** Array-backed and linked sequences, invariant-preserving updates, cost and verification; search/sort now belongs in 16.

Plans: `chapters/14_arrays_linked_lists/MATERIALS.md`, `chapters/14_arrays_linked_lists/ORGANIZATION.md`

**C14-O1: Explain how array-backed and linked representations store the same sequence contract.** (supported)

- E: `1401_dynamic_arrays.ipynb` cells 3–18; `1402_linked_nodes.ipynb` cells 3–22.
- W: `1401_dynamic_arrays.ipynb` cells 11–14; `1402_linked_nodes.ipynb` cells 7–18.
- G: `1401_dynamic_arrays.ipynb` cells 21–25.
- A: `lab.ipynb` cells 2–20; `homework.ipynb` cells 3–5.

Both representations implement and test a shared contract.

**C14-O2: Trace resizing, shifting, and the total copy cost of repeated array-backed appends.** (supported)

- E: `1401_dynamic_arrays.ipynb` cells 7–16; `1401_dynamic_arrays.ipynb` cells 32–36.
- W: `1401_dynamic_arrays.ipynb` cells 21–25.
- G: `1401_dynamic_arrays.ipynb` cells 21–25.
- A: `lab.ipynb` cells 2–8; `homework.ipynb` cells 7–8.

Growth copies, shifting, and amortized writes are explicitly counted.

**C14-O3: Implement generic array-backed and singly linked sequences while preserving count, head, and tail invariants.** (supported)

- E: `1401_dynamic_arrays.ipynb` cells 18–30; `1402_linked_nodes.ipynb` cells 22–34.
- W: `1401_dynamic_arrays.ipynb` cells 28–30; `1402_linked_nodes.ipynb` cells 32–34.
- G: `1402_linked_nodes.ipynb` cells 25–29.
- A: `lab.ipynb` cells 6–20; `homework.ipynb` cells 9–18.

Linked endpoints and complete operations receive substantive implementation work.

**C14-O4: Separate the cost of locating a position from the cost of insertion or deletion at that position.** (supported)

- E: `1403_comparison_lab.ipynb` cells 3–25.
- W: `1403_comparison_lab.ipynb` cells 24–25.
- G: `1403_comparison_lab.ipynb` cells 21–25.
- A: `lab.ipynb` cells 18–22; `homework.ipynb` cells 19–20.

Location and update costs are separated in a concrete workload.

**C14-O5: Test empty, singleton, duplicate, and invalid-index cases and justify a representation using workload and memory-locality evidence.** (supported)

- E: `1403_comparison_lab.ipynb` cells 27–31.
- W: `1403_comparison_lab.ipynb` cells 27–31.
- G: `1403_comparison_lab.ipynb` cells 27–31.
- A: `lab.ipynb` cells 18–22; `homework.ipynb` cells 19–20.

Independent tests and workload recommendations are requested.

### Chapter 15. Stacks, Queues, and Deques

**Plan role:** Stacks, bounded/wrapped queues, linked choices, histories, scheduling and costs.

Plans: `chapters/15_stacks_queues/MATERIALS.md`, `chapters/15_stacks_queues/ORGANIZATION.md`

**C15-O1: Specify stack, queue, and deque access rules and failure behavior.** (supported)

- E: `1501_stack.ipynb` cells 3–11; `1502_queue_deque.ipynb` cells 6–24.
- W: `1501_stack.ipynb` cells 6–11; `1502_queue_deque.ipynb` cells 9–24.
- G: `1501_stack.ipynb` cells 33–35; `1502_queue_deque.ipynb` cells 40–42.
- A: `lab.ipynb` cells 2–20; `homework.ipynb` cells 3–11.

Failure signals and access policies are assessed.

**C15-O2: Trace count, capacity, stack top, and ring-buffer wraparound.** (supported)

- E: `1501_stack.ipynb` cells 23–31; `1502_queue_deque.ipynb` cells 26–35.
- W: `1502_queue_deque.ipynb` cells 26–35.
- G: `1502_queue_deque.ipynb` cells 40–42.
- A: `lab.ipynb` cells 6–16; `homework.ipynb` cells 18–20.

Wraparound/full/empty traces and resize work are substantive.

**C15-O3: Implement generic array stacks, bounded ring queues, and linked queues while preserving their invariants.** (supported)

- E: `1501_stack.ipynb` cells 26–31; `1502_queue_deque.ipynb` cells 29–38.
- W: `1501_stack.ipynb` cells 27–31; `1502_queue_deque.ipynb` cells 30–38.
- G: `1502_queue_deque.ipynb` cells 40–42.
- A: `lab.ipynb` cells 2–16; `homework.ipynb` cells 18–20.

Stack and ring implementation are assessed; linked queue implementation is explained but less directly assessed.

**C15-O4: Distinguish worst-case and amortized operation costs and compare representation tradeoffs.** (supported)

- E: `1501_stack.ipynb` cells 30–31; `1503_applications_lab.ipynb` cells 18–20.
- W: `1501_stack.ipynb` cells 30–31.
- G: `1503_applications_lab.ipynb` cells 33–35.
- A: `homework.ipynb` cells 22–24; `lab.ipynb` cells 2–4.

Complexity reasoning is attached to actual implementations.

**C15-O5: Apply and test delimiter matching, undo/redo histories, queue worklists, and scheduling policies.** (supported)

- E: `1501_stack.ipynb` cells 13–16; `1503_applications_lab.ipynb` cells 3–31.
- W: `1503_applications_lab.ipynb` cells 23–28.
- G: `1503_applications_lab.ipynb` cells 33–35.
- A: `lab.ipynb` cells 18–20; `homework.ipynb` cells 22–32.

Delimiter, history, and bounded-service tasks provide transfer.

### Chapter 16. Searching and Basic Sorting

**Plan role:** Two readings: search/repeated queries, then sorting/report snapshots and complete workload choices.

Plans: `chapters/16_searching_sorting/MATERIALS.md`, `chapters/16_searching_sorting/ORGANIZATION.md`

**C16-O1: Specify first-match search and missing-result behavior, including the meaning of a library search result.** (supported)

- E: `1601_searching.ipynb` cells 5–14; `1601_searching.ipynb` cells 21–24.
- W: `1601_searching.ipynb` cell 14; `1601_searching.ipynb` cell 24.
- G: `1601_searching.ipynb` cells 28–32.
- A: `lab.ipynb` cells 2–4; `homework.ipynb` cells 14–16; `homework.ipynb` cells 20–22.

Search contracts and library sign results are practiced.

**C16-O2: Trace linear search and binary search while enforcing sorted-input and comparer requirements.** (partial)

- E: `1601_searching.ipynb` cells 7–19.
- W: `1601_searching.ipynb` cell 19.
- G: `1601_searching.ipynb` cells 28–32.
- A: `lab.ipynb` cells 8–13; `homework.ipynb` cells 23–25.

Assignments repair a supplied boundary or select a comparer; independent construction of the search loop is not required.

**C16-O3: Implement insertion sorting and verify order, occurrence preservation, and behavior at boundaries.** (partial)

- E: `1602_basic_sorting.ipynb` cells 5–24.
- W: `1602_basic_sorting.ipynb` cells 14–22.
- G: `1602_basic_sorting.ipynb` cells 26–30.
- A: `homework.ipynb` cells 17–19; `homework.ipynb` cells 26–28.

Homework restores the saved item or increments a counter inside a complete sort; it does not independently implement or verify the whole insertion algorithm.

**C16-O4: Prepare a report with explicit mutation and tie-order policies, including a separate snapshot when needed.** (partial)

- E: `1602_basic_sorting.ipynb` cells 7–9; `1602_basic_sorting.ipynb` cells 31–48.
- W: `1602_basic_sorting.ipynb` cell 34; `1602_basic_sorting.ipynb` cell 48.
- G: `1602_basic_sorting.ipynb` cells 38–42.
- A: `lab.ipynb` cells 5–7; `lab.ipynb` cells 14–16; `homework.ipynb` cells 7–8.

Snapshot copying is assessed, but tied-record stability and multi-record preservation receive little independent implementation/test design.

**C16-O5: Compare complete search/report workloads, accounting for preparation, repeated queries, updates, and storage.** (partial)

- E: `1602_basic_sorting.ipynb` cells 43–50; `1601_searching.ipynb` cells 25–26.
- W: `1602_basic_sorting.ipynb` cells 48–50.
- G: `1602_basic_sorting.ipynb` cells 38–42.
- A: `homework.ipynb` cells 26–28; `homework.ipynb` cells 11–12.

Comparison counting is a small edit; standard assignments do not independently compare preparation, repeated queries, and updates.

### Chapter 17. Trees and Binary Search Trees

**Plan role:** Recursive models/returns, traversals, BST lifecycle, queries, inherited-bound and model verification.

Plans: `chapters/17_trees/MATERIALS.md`, `chapters/17_trees/ORGANIZATION.md`

**C17-O1: Explain base cases, smaller recursive calls, and suspended call frames.** (supported)

- E: `1701_tree_structure.ipynb` cells 11–24.
- W: `1701_tree_structure.ipynb` cells 14–19.
- G: `1701_tree_structure.ipynb` cells 27–29.
- A: `lab.ipynb` cells 2–4; `homework.ipynb` cells 14–16.

Recursive return reasoning is practiced before BST updates.

**C17-O2: Distinguish a general tree, a binary tree, and a binary search tree.** (supported)

- E: `1701_tree_structure.ipynb` cells 4–9; `1702_binary_search_trees.ipynb` cells 3–6.
- W: `1701_tree_structure.ipynb` cells 6–9.
- G: `1701_tree_structure.ipynb` cells 27–29.
- A: `preview.ipynb` cell 3; `homework.ipynb` cells 18–20.

General hierarchies are separated from ordered BSTs.

**C17-O3: Trace preorder, inorder, postorder, and level-order traversal.** (supported)

- E: `1704_tree_traversal.ipynb` cells 4–13; `1703_tree_lab.ipynb` cells 12–15.
- W: `1704_tree_traversal.ipynb` cells 12–13; `1703_tree_lab.ipynb` cells 14–15.
- G: `1704_tree_traversal.ipynb` cells 21–23.
- A: `homework.ipynb` cells 22–24.

Iterative inorder is constructed; level-order is demonstrated and compared conceptually rather than independently implemented.

**C17-O4: Compute node count, leaf count, and height using explicit base cases.** (supported)

- E: `1704_tree_traversal.ipynb` cells 15–18; `1701_tree_structure.ipynb` cells 21–29.
- W: `1704_tree_traversal.ipynb` cells 17–18.
- G: `1704_tree_traversal.ipynb` cells 21–23.
- A: `lab.ipynb` cells 2–4; `homework.ipynb` cells 5–6; `homework.ipynb` cells 14–16.

Independent aggregation transfers the recursive-return pattern.

**C17-O5: Implement and explain BST search, insertion, and all three removal cases.** (supported)

- E: `1702_binary_search_trees.ipynb` cells 9–33.
- W: `1702_binary_search_trees.ipynb` cells 12–18; `1702_binary_search_trees.ipynb` cells 30–33.
- G: `1702_binary_search_trees.ipynb` cells 35–37.
- A: `lab.ipynb` cells 2–20.

The lab requires all deletion cases and successor-subtree preservation.

**C17-O6: Validate ancestor bounds and test updates against an ordered-set model.** (supported)

- E: `1703_tree_lab.ipynb` cells 17–20.
- W: `1703_tree_lab.ipynb` cells 19–20.
- G: `1703_tree_lab.ipynb` cells 22–24.
- A: `lab.ipynb` cells 18–20; `homework.ipynb` cells 18–20.

Ancestor bounds and lifecycle-model checks receive assessed tasks.

**C17-O7: Analyze path operations in terms of height and explain range-query pruning.** (supported)

- E: `1702_binary_search_trees.ipynb` cells 21–24; `1703_tree_lab.ipynb` cells 7–10.
- W: `1703_tree_lab.ipynb` cells 9–10.
- G: `1703_tree_lab.ipynb` cells 22–24.
- A: `homework.ipynb` cells 26–28; `homework.ipynb` cells 5–12.

Range pruning and cost claims are challenged by explicit cases.

### Chapter 18. Priority Queues and Heaps

**Plan role:** Priority contracts, heap shape and repairs, top-k; fairness is explicitly named as assessment scope.

Plans: `chapters/18_priority_queues/MATERIALS.md`, `chapters/18_priority_queues/ORGANIZATION.md`

**C18-O1: Specify priority order, tie behavior, and empty-removal behavior for a priority queue.** (supported)

- E: `1801_priority_queues.ipynb` cells 5–12.
- W: `1801_priority_queues.ipynb` cells 9–12.
- G: `1801_priority_queues.ipynb` cells 21–25.
- A: `lab.ipynb` cells 2–7; `homework.ipynb` cells 3–12.

Priority direction and ties are assessed through API behavior.

**C18-O2: Map complete-tree positions to array indexes and check the heap-order invariant.** (partial)

- E: `1801_priority_queues.ipynb` cells 14–19; `1802_heap_implementation.ipynb` cells 20–24.
- W: `1801_priority_queues.ipynb` cells 17–19.
- G: `1802_heap_implementation.ipynb` cells 20–24.
- A: `preview.ipynb` cells 4–9; `homework.ipynb` cells 5–10.

The parent invariant is implemented in section practice; lab/homework provide it and mainly test recognition or calls.

**C18-O3: Trace and implement sift-up and sift-down repairs for insertion and removal.** (gap)

- E: `1802_heap_implementation.ipynb` cells 5–19.
- W: `1802_heap_implementation.ipynb` cells 9–19.
- G: `1802_heap_implementation.ipynb` cells 20–24.
- A: `lab.ipynb` cells 8–13.

The explicit implement-repairs outcome has no independent repair-body task: the complete heap is supplied and students insert values or change a draining condition.

**C18-O4: Explain heap operation costs and distinguish a valid heap from a fully sorted array.** (partial)

- E: `1802_heap_implementation.ipynb` cells 17–19.
- W: `1802_heap_implementation.ipynb` cells 17–19.
- G: `1803_priority_applications.ipynb` cells 19–22.
- A: `homework.ipynb` cells 5–6.

No independent operation-count derivation or worst/amortized distinction task matches the cost outcome.

**C18-O5: Maintain a bounded top-k selection and compare priority scheduling with fairness requirements.** (partial)

- E: `1803_priority_applications.ipynb` cells 5–18.
- W: `1803_priority_applications.ipynb` cells 10–11.
- G: `1803_priority_applications.ipynb` cells 12–15; `1803_priority_applications.ipynb` cells 19–22.
- A: `lab.ipynb` cells 14–16; `homework.ipynb` cells 26–28.

Top-k assessment changes a capacity constant; there is no fresh bounded-selection design or fairness analysis.

### Chapter 19. Hash Collections and Sets

**Plan role:** Hash/equality consistency, collisions/growth, sets/counts/reconciliation, coordinated indexes and workloads.

Plans: `chapters/19_hash_collections/MATERIALS.md`, `chapters/19_hash_collections/ORGANIZATION.md`

**C19-O1: Choose a key equality policy and explain why equal keys must have compatible hash codes.** (supported)

- E: `1901_hashing.ipynb` cells 5–14; `1902_dictionaries_sets.ipynb` cell 8.
- W: `1901_hashing.ipynb` cells 9–14.
- G: `1901_hashing.ipynb` cells 30–34.
- A: `preview.ipynb` cells 2–7; `homework.ipynb` cells 3–8; `homework.ipynb` cells 23–25.

Equality/hash consistency and case-policy selection have assessment.

**C19-O2: Trace bucket selection, collision resolution, deletion, and rehashing as load changes.** (partial)

- E: `1901_hashing.ipynb` cells 16–28.
- W: `1901_hashing.ipynb` cell 19; `1901_hashing.ipynb` cells 23–28.
- G: `1901_hashing.ipynb` cells 30–34.
- A: `lab.ipynb` cells 8–13.

Collision code is supplied; tasks call Put/Remove. No independent rehash/tombstone trace or repair verifies the stated outcome.

**C19-O3: Use dictionaries, sets, and frequency counts to distinguish lookup, membership, and multiplicity.** (partial)

- E: `1902_dictionaries_sets.ipynb` cells 5–22.
- W: `1902_dictionaries_sets.ipynb` cells 13–22.
- G: `1902_dictionaries_sets.ipynb` cells 26–30.
- A: `homework.ipynb` cells 14–22; `lab.ipynb` cells 2–7.

Membership/lookup are assessed; a new frequency-count solution is not required in these assignments, though Chapter 8 has one.

**C19-O4: Compute union, intersection, and difference for a record-reconciliation task under a consistent equality policy.** (supported)

- E: `1902_dictionaries_sets.ipynb` cells 8–18.
- W: `1902_dictionaries_sets.ipynb` cell 18.
- G: `1902_dictionaries_sets.ipynb` cells 26–30.
- A: `lab.ipynb` cells 14–16; `homework.ipynb` cells 17–22.

Set reconciliation and operand order have direct tasks.

**C19-O5: Choose and coordinate collection indexes for a workload, test cancelled or updated entries, and explain consistency and operation costs.** (gap)

- E: `1903_collection_selection.ipynb` cells 5–22.
- W: `1903_collection_selection.ipynb` cells 19–20.
- G: `1903_collection_selection.ipynb` cells 24–28.
- A: **No matched evidence**.

The coordinated dictionary/queue cancellation and workload choice taught in 19.3 have no matching independent assessment; assignments stay with isolated map/set calls.

### Chapter 20. Graphs and Traversal

**Plan role:** Four core readings: vocabulary/models, representations, BFS paths, DFS/components and traversal verification.

Plans: `chapters/20_graphs/MATERIALS.md`, `chapters/20_graphs/ORGANIZATION.md`

**C20-O1: Model a network with explicit vertex, edge, direction, weight, and simple-graph assumptions.** (supported)

- E: `2001_graph_vocabulary.ipynb` cells 4–25.
- W: `2001_graph_vocabulary.ipynb` cells 7–16.
- G: `2001_graph_vocabulary.ipynb` cells 27–30.
- A: `lab.ipynb` cells 2–4; `homework.ipynb` cells 14–19; `homework.ipynb` cells 3–12.

Direction, isolation, and simple graph behavior have applications.

**C20-O2: Compare adjacency matrices and adjacency collections in terms of storage, density, and required operations.** (partial)

- E: `2002_adjacency_representations.ipynb` cells 4–27.
- W: `2002_adjacency_representations.ipynb` cells 6–21.
- G: `2002_adjacency_representations.ipynb` cells 29–32.
- A: `preview.ipynb` cells 20–21.

Worked matrix/density analysis exists, but no standard lab/homework asks students to compare storage and operation counts or construct another representation.

**C20-O3: Trace BFS discovery and layer invariants and reconstruct a valid minimum-hop path.** (partial)

- E: `2003_graph_traversal.ipynb` cells 5–24.
- W: `2003_graph_traversal.ipynb` cells 6–9; `2003_graph_traversal.ipynb` cells 20–24.
- G: `2003_graph_traversal.ipynb` cells 8–9.
- A: `lab.ipynb` cells 5–10; `homework.ipynb` cells 20–22.

Assessed work selects a source/target on a fully supplied BFS; no independent queue/discovery/predecessor implementation or trace is required.

**C20-O4: Trace DFS with explicit suspended frames and identify components only under the appropriate direction assumptions.** (partial)

- E: `2004_depth_first_components.ipynb` cells 5–27.
- W: `2004_depth_first_components.ipynb` cells 6–11; `2004_depth_first_components.ipynb` cells 20–24.
- G: `2004_depth_first_components.ipynb` cells 28–32.
- A: `lab.ipynb` cells 11–16; `homework.ipynb` cells 17–19.

The assignments call supplied DFS/Components; they do not independently trace or implement suspended frames or component discovery.

**C20-O5: Verify reachability, paths, and component reports with boundary cases and explain traversal costs for the chosen representation.** (partial)

- E: `2004_depth_first_components.ipynb` cells 25–39.
- W: `2004_depth_first_components.ipynb` cells 35–39.
- G: `2004_depth_first_components.ipynb` cells 28–32.
- A: `homework.ipynb` cells 23–28.

A supplied source check and snapshot mutation are assessed, but no independent full-result verifier or traversal-cost argument is required.

## Verification and files

All 694 source evidence references, all 108 objective texts, and the 40 plan paths were checked against current source. The audit preservation manifest confirms 333 chapter/planning/book-context files unchanged. The review has 694 valid local book links, and its Chapter 18 filter was checked in the browser. No teaching code was executed or changed.

- `mapping.json`: all core outcomes and their four evidence stages.
- `supplemental_mapping.json`: eight additional topic tracks.
- `planning_crosswalk.json`: chapter roles, current plan excerpts, and outcome IDs.
- `findings.json`: prioritized gaps and evidence.
- `source_inventory.json`: 192 TOC-linked notebooks.
- `preservation.json` and `verification.json`: source integrity and reference checks.
- `review.html`: interactive map and evidence excerpts.

Preview: http://127.0.0.1:8800/outcome_coverage_review.html
