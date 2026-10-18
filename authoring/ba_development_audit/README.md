# B-A development audit — all content readings

Audit date: 2026-10-17. Report only; no teaching-source or planning changes.

Reviewed 95 chapter content readings across Chapters 1–26 and nine explanatory appendix readings. Landing pages, assignment specifications, curriculum mappings and retired drafts are excluded from this content-development pass. The inventory records every included reading. Current TOC order includes Recursive Methods, Searching and Sorting Arrays, and Merge Sort.

B-A is a flexible framework: conceptual framing and connections; explanation/syntax and worked interpretation; guided practice before independent transfer. Concrete annotated declarations count as syntax. Conceptual reasoning counts as worked development. A short parent heading, absent code-cell output or absence of the word “guided” is not itself a gap. The matrix is a qualitative screening judgment, not a certification of every line or executable cell.

The main remaining weaknesses are specific rather than universal: contradictory legacy explanations, a property-accessor teaching gap, uneven guided practice in early CS1, and several starters with hidden prerequisites. Many recently expanded algorithm sections already contain substantial traces and checkpoints. Preserve them.

## Findings

### B01 · High — Conversion explanations contradict the correct worked treatment

Already present: The later evaluation/type table correctly separates casting, parsing, and domain validation.

Gap: The earlier text says implicit widening never loses data and attributes the lack of string-to-int conversion to string immutability. These are incorrect causal rules, not missing topics.

Proposed development: Reconcile the retained passages. Explain representable range versus precision; use a small precision-loss counterexample and distinguish textual parsing from numeric conversion.

Evidence: `chapters/02_var_data/0204_types_conversion.ipynb` cell 61 (ID `edeea9ad`); `chapters/02_var_data/0204_types_conversion.ipynb` cell 70 (ID `0692ab55`); `chapters/02_var_data/0204_types_conversion.ipynb` cell 78 (ID `cbafcaaa`).

### B02 · High — Division comments teach a result type that the expression does not have

Already present: The chapter already has useful division and formatting examples, and Types and Conversion gives a correct intermediate-value table.

Gap: The comment on 6.0 / 3.0 says a zero remainder makes the quotient an int. The surrounding integer-division explanation also describes implicit conversion rather than operand-dependent arithmetic.

Proposed development: Align comments and prose with operand types; show value and result type together, then ask students to predict a mixed/integer/floating variation.

Evidence: `chapters/02_var_data/0202_operators_built_in_methods.ipynb` cell 38 (ID `a4d79135`); `chapters/02_var_data/0202_operators_built_in_methods.ipynb` cell 41 (ID `ebb5ee3f`).

### B03 · High — Postfix explanation confuses expression value with the updated variable

Already present: Prefix/postfix examples are already present.

Gap: The text says i++ retains the old value in the body until the next iteration. Postfix returns the previous value as the expression result but updates the variable during evaluation.

Proposed development: Explain old expression value versus new stored value with a two-column trace; distinguish a for-loop update location from postfix semantics.

Evidence: `chapters/04_iteration/0401_iteration.ipynb` cell 12 (ID `aaed10f8`); `chapters/04_iteration/0401_iteration.ipynb` cell 14 (ID `3298c732`).

### B04 · High — Properties are used before a proper property-accessor lesson

Already present: Getter/setter methods, Contact, this, and ToString explanations are substantial and should remain. An Employee example already contains auto-properties.

Gap: The main lesson still promises a future update and teaches GetName/SetEmail methods. The later { get; set; } syntax appears without a developed accessor explanation or a guided property task.

Proposed development: Teach field versus property versus method, general accessor and auto-property forms, implicit value, validation/backing state, and a worked caller trace. Convert one Contact member with guided checks; retain the method approach for comparison.

Evidence: `chapters/10_classes/1002_properties.ipynb` cell 5 (ID `0ad059f5`); `chapters/10_classes/1002_properties.ipynb` cell 8 (ID `541fe992`); `chapters/10_classes/1002_properties.ipynb` cell 14 (ID `dd3d45cd`); `chapters/10_classes/1002_properties.ipynb` cell 25 (ID `cf8e32d6`).

### B05 · High — File API explanation names a read method as a write operation

Already present: The API table and later read/write walkthrough contain the correct WriteAllText and ReadAllText calls.

Gap: The introductory prose tells students to use File.ReadAllText(string path, string content) to write. This conflicts with the correct examples and presents a nonexistent write signature.

Proposed development: Correct the explanatory call; separate general read and write patterns, argument meanings, returned text, and overwrite behavior. Reuse the existing examples.

Evidence: `chapters/09_files_text/0901_stream_file.ipynb` cell 20 (ID `7c0bb79e`).

### B06 · High — Guided starters require undeclared types

Already present: The questions state meaningful boundary cases and the hidden solutions supply complete implementations.

Gap: Three visible starter cells instantiate MeetingSchedule.Meeting or GreedyGraph.Edge without defining those types. Fresh-cell builds fail with CS0246 before students can work on the intended algorithm.

Proposed development: Supply the required types and scaffolding inside each starter, with a bounded missing operation and expected checks. Alternatively mark a deliberate sequence and provide the required standalone reset/setup cell; do not make the hidden answer the setup.

Evidence: `chapters/24_greedy_graph_optimization/2401_greedy_choice.ipynb` cell 34 (ID `54362327`); `chapters/24_greedy_graph_optimization/2401_greedy_choice.ipynb` cell 35 (ID `e8496a78`); `chapters/24_greedy_graph_optimization/2404_shortest_paths.ipynb` cell 38 (ID `7f93eb17`); `chapters/24_greedy_graph_optimization/2404_shortest_paths.ipynb` cell 39 (ID `6447ba28`); `chapters/24_greedy_graph_optimization/2404_shortest_paths.ipynb` cell 56 (ID `52920949`); `chapters/24_greedy_graph_optimization/2404_shortest_paths.ipynb` cell 57 (ID `daca0787`).

### B07 · Medium — A structured-record example silently depends on a previous cell

Already present: The parsing helper and the caller are both present, alongside a stronger later prepared import-review activity.

Gap: The caller cell uses TryParseStudent defined only in the previous cell; a fresh compile fails with CS0103. The pair is not labeled as an intentional stateful sequence with reset/setup.

Proposed development: Make the demonstration standalone or explicitly label and provide the sequence setup. Show accepted and rejected records with a brief reason for each result.

Evidence: `chapters/09_files_text/0903_text_operations.ipynb` cell 28 (ID `3fbf7a9f`); `chapters/09_files_text/0903_text_operations.ipynb` cell 29 (ID `53856479`); `chapters/09_files_text/0903_text_operations.ipynb` cell 30 (ID `7f7f6d6b`).

### B08 · Medium — Variable-state practice is mostly supplied rather than attempted locally

Already present: The worked assignment/state trace and declaration examples establish the concepts.

Gap: The learner has limited local completion-and-feedback practice for following successive assignments; further practice is primarily reached through the assignments link.

Proposed development: After the worked trace, give a short unfinished state table and a revealable explanation. Include reassignment and an expression using the previous value.

Evidence: `chapters/02_var_data/0201_variables_types.ipynb` cell 31 (ID `2efea84b`); `chapters/02_var_data/0201_variables_types.ipynb` cell 32 (ID `restored-variable-trace`).

### B09 · Medium — Operator practice does not cover the breadth of the operator lesson

Already present: There is a guided pricing/Math task; operator and built-in method examples are not absent.

Gap: That checkpoint does not sufficiently scaffold the earlier precedence and numeric-evaluation distinctions. A complete pricing solution is a different skill from tracing intermediate values and types.

Proposed development: Add a small predict/explain/repair task on precedence and division with answer reasoning, then transfer to the existing pricing task. Do not require every reference-table operator to receive its own exercise.

Evidence: `chapters/02_var_data/0202_operators_built_in_methods.ipynb` cell 94 (ID `0613a03d`); `chapters/02_var_data/0202_operators_built_in_methods.ipynb` cell 95 (ID `e5a06fe7`); `chapters/02_var_data/0202_operators_built_in_methods.ipynb` cell 96 (ID `6cd02ace`).

### B10 · Medium — Console I/O has many demonstrations but no developed guided checkpoint

Already present: Prompt/read, output, composite formatting, alignment, and interpolation are explained with concrete examples and several expected transcripts.

Gap: The section largely asks readers to run supplied demonstrations. It lacks a bounded learner attempt combining input, a calculated value, and an exact output contract, with feedback.

Proposed development: Guide an invoice-line prompt and aligned result. Give sample input and required output, a partial program, and an explained solution; keep the larger independent work in assignments.

Evidence: `chapters/02_var_data/0203_input_output.ipynb` cell 32 (ID `31f8f0e7`); `chapters/02_var_data/0203_input_output.ipynb` cell 38 (ID `9173557a`); `chapters/02_var_data/0203_input_output.ipynb` cell 49 (ID `b0aa66ae`); `chapters/02_var_data/0203_input_output.ipynb` cell 53 (ID `c156f599`); `chapters/02_var_data/0203_input_output.ipynb` cell 57 (ID `561234ac`).

### B11 · Medium — Boolean-condition translation needs a learner-owned checkpoint

Already present: General Boolean syntax, graduation eligibility, interval conditions, and urgent/important alternatives are developed.

Gap: The main reasoning is demonstrated for the reader. The final clarity question does not check whether a student can translate a requirement or handle inclusive boundaries.

Proposed development: Have students complete one condition from a business rule, predict boundary truth values, and diagnose an &&/|| mistake before revealing the explanation.

Evidence: `chapters/03_decision/0301_intro_decision.ipynb` cell 21 (ID `12069b3f`); `chapters/03_decision/0301_intro_decision.ipynb` cell 23 (ID `bb82befb`); `chapters/03_decision/0301_intro_decision.ipynb` cell 26 (ID `1267f303`); `chapters/03_decision/0301_intro_decision.ipynb` cell 30 (ID `c5cb07e6`).

### B12 · Medium — The loop-planning rubric is not demonstrated as a planning process

Already present: Repetition examples, step expressions, and a useful planning-question list are present; later for/while readings provide detailed syntax.

Gap: The planning rubric is a list rather than a worked plan followed by a learner attempt. break/continue also receive little local application in this overview.

Proposed development: Walk through initialization, continuation, update, and exit for one small task; ask students to repair a related plan with feedback. Keep detailed loop syntax in its current sections.

Evidence: `chapters/04_iteration/0401_iteration.ipynb` cell 20 (ID `cc7b18f7`); `chapters/04_iteration/0401_iteration.ipynb` cell 23 (ID `21c6f82b`).

### B13 · Medium — First class construction needs guided application of its core model

Already present: Class/constructor examples and tuple syntax are present. The params extension already has a guided prediction task.

Gap: The explicit guided activity develops params, while creating an instance with valid initial fields and calling its behavior is mostly demonstrated. Tuple forms also lack a comparable local attempt.

Proposed development: Before extensions, guide a small class/constructor/member-call completion with a state/output check. Add a short tuple deconstruction variation, preserving the existing examples.

Evidence: `chapters/10_classes/1001_class_syntax.ipynb` cell 8 (ID `d1471367`); `chapters/10_classes/1001_class_syntax.ipynb` cell 11 (ID `df26bbdd`); `chapters/10_classes/1001_class_syntax.ipynb` cell 14 (ID `84beb7c2`); `chapters/10_classes/1001_class_syntax.ipynb` cell 22 (ID `0c352fa4306c`); `chapters/10_classes/1001_class_syntax.ipynb` cell 26 (ID `094596cb`).

### B14 · Medium — Regex extraction develops less fully than the validation opening

Already present: The opening anchored-label pattern has a useful breakdown, contrast with substring matching, and a checkpoint.

Gap: Later Match/Matches/Replace/capture-group introductions are brief and move toward an independent practice list. They need more explanation of result objects, no-match behavior, and group extraction before transfer.

Proposed development: Develop one matched/unmatched extraction trace, explain named groups and failure handling, and guide a small extraction/replacement variation with feedback. This is supporting reading, not a new required meeting.

Evidence: `chapters/09_files_text/0906_regex.ipynb` cell 18 (ID `81749266`); `chapters/09_files_text/0906_regex.ipynb` cell 22 (ID `57e0824a`); `chapters/09_files_text/0906_regex.ipynb` cell 26 (ID `0ccfb926`); `chapters/09_files_text/0906_regex.ipynb` cell 31 (ID `ff0ba205`); `chapters/09_files_text/0906_regex.ipynb` cell 41 (ID `7f5aa13d`).

### B15 · Medium — Optional privacy reading ends with summary rather than guided application

Already present: Masking, untrusted input, safe logging, and collect/show/keep principles have concrete examples.

Gap: There is no comparable local learner attempt with explained feedback tying these habits to a particular record or log line.

Proposed development: Provide a synthetic log-review checkpoint: identify unnecessary exposure, repair one line, and explain why masking display does not erase the stored original. Keep its optional status.

Evidence: `chapters/09_files_text/0905_privacy_security.ipynb` cell 10 (ID `76913847`); `chapters/09_files_text/0905_privacy_security.ipynb` cell 14 (ID `5d540c71`); `chapters/09_files_text/0905_privacy_security.ipynb` cell 17 (ID `478d6409`); `chapters/09_files_text/0905_privacy_security.ipynb` cell 23 (ID `3e3fe35b`); `chapters/09_files_text/0905_privacy_security.ipynb` cell 28 (ID `d30a4823`).

### B16 · Medium — SQL queries need concrete results and guided feedback

Already present: The relational model, schema, SELECT/WHERE/GROUP BY/JOIN and data changes are introduced with concrete SQL and independent practice prompts.

Gap: The Books/Sales query progression does not supply a consistent small seeded dataset and resulting tables. Practice requests lack worked feedback; students cannot readily trace JOIN multiplicity or distinguish grouping from filtering.

Proposed development: Add one consistent disposable dataset, explain actual result rows for a filter, group and join, and include a partially completed query with feedback. Keep both explicitly distinguished schema variants.

Evidence: `chapters/appendices/databases/relational_data_sql.ipynb` cell 11 (ID `53103c3f5a06`); `chapters/appendices/databases/relational_data_sql.ipynb` cell 17 (ID `a2deaaa7bf91`); `chapters/appendices/databases/relational_data_sql.ipynb` cell 19 (ID `52d72eb35f8c`); `chapters/appendices/databases/relational_data_sql.ipynb` cell 21 (ID `9e6b85b0bd65`); `chapters/appendices/databases/relational_data_sql.ipynb` cell 23 (ID `8a3532d2f2a9`); `chapters/appendices/databases/relational_data_sql.ipynb` cell 25 (ID `add15615b11e`); `chapters/appendices/databases/relational_data_sql.ipynb` cell 37 (ID `ac149207e30c`).

### B17 · Medium — SQLite mapping and transactions rely heavily on inspecting the full project

Already present: A complete parameterized query with expected output and a strong contract-check table are already present.

Gap: Mapping, affected-row outcomes, and transaction coordination are explained mainly by referring to Program.cs. They lack a compact step-by-step worked before/after state and a guided failure-path interpretation.

Proposed development: Bring a short mapping excerpt and transaction state trace into the content reading; guide a rollback prediction with feedback, retaining the project and existing checks as independent application.

Evidence: `chapters/appendices/databases/csharp_sqlite.ipynb` cell 8 (ID `f1fe5376700f`); `chapters/appendices/databases/csharp_sqlite.ipynb` cell 14 (ID `9ab0fa5f76ee`); `chapters/appendices/databases/csharp_sqlite.ipynb` cell 16 (ID `1b1226617208`); `chapters/appendices/databases/csharp_sqlite.ipynb` cell 18 (ID `7e750c619d45`).

### B18 · Medium — Operator-overloading extension needs a guided operator contract task

Already present: Rational method reasoning and the complete Amount addition example with expected 20.00 are present.

Gap: The reading offers a finished operator example but no bounded learner attempt checking a custom operator against its declared value contract.

Proposed development: Guide completion or review of one operator, ask for expected results and unchanged operands, then reveal the explanation. Treat it as optional enrichment, not additional CS1 core.

Evidence: `chapters/appendices/operator_overloading.ipynb` cell 6 (ID `2f193764`); `chapters/appendices/operator_overloading.ipynb` cell 11 (ID `operator-worked-context`); `chapters/appendices/operator_overloading.ipynb` cell 12 (ID `operator-worked-code`).

## Verification and limits

Targeted fresh-project checks are recorded in `targeted_checks.json`; compile failures are expected evidence, not a new source change. Numeric/postfix counterexamples were run separately. No whole-book execution is claimed. Source hashes cover the original notebooks and planning inputs.

Microsoft references used to validate the factual corrections: [Numeric conversions](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/numeric-conversions), [Properties](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties). The file call has also been checked against the API signature in the installed reference/runtime.

## Full section matrix

“Supported” means this scan did not establish an additional material development gap. It does not mean every example is equally deep or every cell was rerun.

| Reading | Explanation | General syntax | Worked development | Guided practice | Findings |
| --- | --- | --- | --- | --- | --- |
| chapters/01_context/0101_cs_ideas.ipynb | Supported in this scan | Not a new C# construct / contextual patterns | Supported in this scan | Supported in this scan |  |
| chapters/01_context/0102_computing_responsibility.ipynb | Supported in this scan | Not a new C# construct / contextual patterns | Supported in this scan | Supported in this scan |  |
| chapters/01_context/0103_program_structure.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/02_var_data/0201_variables_types.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Needs development/correction | B08 |
| chapters/02_var_data/0204_types_conversion.ipynb | Needs development/correction | Supported in this scan | Supported in this scan | Supported in this scan | B01 |
| chapters/02_var_data/0202_operators_built_in_methods.ipynb | Needs development/correction | Supported in this scan | Needs development/correction | Needs development/correction | B02, B09 |
| chapters/02_var_data/0203_input_output.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Needs development/correction | B10 |
| chapters/03_decision/0301_intro_decision.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Needs development/correction | B11 |
| chapters/03_decision/0302_ifstatement.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/04_iteration/0401_iteration.ipynb | Needs development/correction | Supported in this scan | Needs development/correction | Needs development/correction | B03, B12 |
| chapters/04_iteration/0402_for_statements.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/04_iteration/0403_while_statement.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/04_iteration/0404_gcd.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/05_methods/0501_intro_methods.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/05_methods/0503_parameter.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/05_methods/0502_signature_call.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/05_methods/0504_strings.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/05_methods/0505_summary.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/05_methods/0506_recursive_methods.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/06_exceptions_testing/0601_error_handling.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/06_exceptions_testing/0602_debugging_workflow.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/06_exceptions_testing/0603_testing.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/06_exceptions_testing/0605_software_responsibility.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/07_arrays/0701_onedim.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/07_arrays/0703_array_processing.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/07_arrays/0704_searching_sorting_arrays.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/07_arrays/0702_twodim.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/08_collections/0801_collections.ipynb | Supported in this scan | Not a new C# construct / contextual patterns | Supported in this scan | Supported in this scan |  |
| chapters/08_collections/0804_collection_operations.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/08_collections/0802_list.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/08_collections/0803_dictionary.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/09_files_text/0901_stream_file.ipynb | Needs development/correction | Needs development/correction | Supported in this scan | Supported in this scan | B05 |
| chapters/09_files_text/0902_file_operations.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/09_files_text/0903_text_operations.ipynb | Supported in this scan | Supported in this scan | Needs development/correction | Supported in this scan | B07 |
| chapters/09_files_text/0906_regex.ipynb | Needs development/correction | Supported in this scan | Supported in this scan | Needs development/correction | B14 |
| chapters/09_files_text/0905_privacy_security.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Needs development/correction | B15 |
| chapters/10_classes/1001_class_syntax.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Needs development/correction | B13 |
| chapters/10_classes/1002_properties.ipynb | Needs development/correction | Needs development/correction | Needs development/correction | Needs development/correction | B04 |
| chapters/10_classes/1003_class_instance.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/10_classes/1004_averager.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/11_object_design/1101_objects_references.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/11_object_design/1105_value_record_types.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/11_object_design/1102_composition.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/11_object_design/1103_testing_collaboration.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/11_object_design/1104_nullability.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/12_oop/1201_inheritance.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/12_oop/1202_polymorphism.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/12_oop/1203_interfaces.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/12_oop/1204_oop_examples.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/13_abstract_data_types/1301_adt_contracts.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/13_abstract_data_types/1302_representations_costs.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/13_abstract_data_types/1303_generics.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/13_abstract_data_types/1304_iterators.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/14_arrays_linked_lists/1401_dynamic_arrays.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/14_arrays_linked_lists/1402_linked_nodes.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/14_arrays_linked_lists/1403_comparison_lab.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/15_stacks_queues/1501_stack.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/15_stacks_queues/1502_queue_deque.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/15_stacks_queues/1503_applications_lab.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/16_searching_sorting/1601_searching.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/16_searching_sorting/1602_basic_sorting.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/16_searching_sorting/1604_merge_sort.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/17_trees/1701_tree_structure.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/17_trees/1704_tree_traversal.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/17_trees/1702_binary_search_trees.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/17_trees/1703_tree_lab.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/18_priority_queues/1801_priority_queues.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/18_priority_queues/1802_heap_implementation.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/18_priority_queues/1803_priority_applications.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/19_hash_collections/1901_hashing.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/19_hash_collections/1902_dictionaries_sets.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/19_hash_collections/1903_collection_selection.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/20_graphs/2001_graph_vocabulary.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/20_graphs/2002_adjacency_representations.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/20_graphs/2003_graph_traversal.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/20_graphs/2004_depth_first_components.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/21_algorithm_analysis/2101_big_o.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/21_algorithm_analysis/2102_correctness.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/21_algorithm_analysis/2103_recurrences.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/22_recursion_divide_conquer/2201_recursion.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/22_recursion_divide_conquer/2203_merge_sort_lab.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/23_searching_sorting/2301_searching.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/23_searching_sorting/2302_sorting.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/23_searching_sorting/2303_comparison_lab.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/23_searching_sorting/2304_advanced_sorts.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/23_searching_sorting/2305_quicksort.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/24_greedy_graph_optimization/2401_greedy_choice.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Needs development/correction | B06 |
| chapters/24_greedy_graph_optimization/2402_spanning_trees_shortest_paths.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/24_greedy_graph_optimization/2404_shortest_paths.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Needs development/correction | B06 |
| chapters/25_dynamic_programming_backtracking/2501_memoization_tabulation.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/25_dynamic_programming_backtracking/2504_optimization_models.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/25_dynamic_programming_backtracking/2502_backtracking.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/26_advanced_graphs_strings_limits/2602_shortest_paths_strings.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/26_advanced_graphs_strings_limits/2604_prefix_matching.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/26_advanced_graphs_strings_limits/2603_limits_project.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/appendices/development_tools/csharp_setup.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/appendices/development_tools/command_line_basics.md | Supported in this scan | Not a new C# construct / contextual patterns | Supported in this scan | Supported in this scan |  |
| chapters/appendices/development_tools/editing_tools.md | Supported in this scan | Not a new C# construct / contextual patterns | Supported in this scan | Supported in this scan |  |
| chapters/appendices/development_tools/interactive_language_environments.md | Supported in this scan | Not a new C# construct / contextual patterns | Supported in this scan | Supported in this scan |  |
| chapters/appendices/github.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/appendices/github/professional_practice.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Supported in this scan |  |
| chapters/appendices/databases/relational_data_sql.ipynb | Supported in this scan | Supported in this scan | Needs development/correction | Needs development/correction | B16 |
| chapters/appendices/databases/csharp_sqlite.ipynb | Supported in this scan | Supported in this scan | Needs development/correction | Needs development/correction | B17 |
| chapters/appendices/operator_overloading.ipynb | Supported in this scan | Supported in this scan | Supported in this scan | Needs development/correction | B18 |
