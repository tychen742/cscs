# Instructor Support

Use this index to prepare lessons when you are still learning C#. A **demo
walkthrough** explains complete runnable code and how to teach it. An **assignment
solution** answers a specific task in the current book. An older completed
exercise is supplementary unless a current assignment match has been established.

These repository guides are not added to the student book's table of contents.
Their location is not an access restriction; notebook answers remain available
through the book's existing reveal controls.

## Prepare a Lesson

1. Follow the lesson link and read the demo walkthrough's role and boundaries.
2. Open its project in VS Code, run it with the supplied input, and compare the output.
3. Trace the important statements and rehearse the teaching sequence.
4. Ask students to predict a change, run it, and explain the result.
5. For an assignment, use its exact solution guide and stated contracts; do not substitute a similarly named older project.

All mapped demo projects target .NET 10. `python3 materials/verify_demos.py`
checks builds, console behavior, unit tests, and algorithm checks. Walkthrough
output captures were rerun during preparation; trailing spaces are omitted for readability. Random/timing values and
exception stack paths can vary.

## Demo and Supporting-Project Map

“Concept companion” means the project illustrates the linked lesson, not that
it reproduces the notebook or solves an assignment. Legacy folders named `lab`
do not by themselves imply a relationship to a current lab.

| Resource | Role | Instructor walkthrough |
| --- | --- | --- |
| [`01/hello_world/HelloWorld.csproj`](../../materials/01/hello_world/HelloWorld.csproj) | Exact first-program example | [Walkthrough](demos/01_hello_world.md) |
| [`02/input/input.csproj`](../../materials/02/input/input.csproj) | Concept companion | [Walkthrough](demos/02_input.md) |
| [`02/output/output.csproj`](../../materials/02/output/output.csproj) | Concept companion | [Walkthrough](demos/02_output.md) |
| [`03/methods_demo/methods_demo.csproj`](../../materials/03/methods_demo/methods_demo.csproj) | Concept companion | [Walkthrough](demos/03_methods_demo.md) |
| [`04/conditional_demo/conditional_demo.csproj`](../../materials/04/conditional_demo/conditional_demo.csproj) | Concept companion | [Walkthrough](demos/04_conditional_demo.md) |
| [`05/for_loop_demo/for_loop_demo.csproj`](../../materials/05/for_loop_demo/for_loop_demo.csproj) | Concept companion | [Walkthrough](demos/05_for_loop_demo.md) |
| [`05/while_loop_demo/while_loop_demo.csproj`](../../materials/05/while_loop_demo/while_loop_demo.csproj) | Concept companion | [Walkthrough](demos/05_while_loop_demo.md) |
| [`10/file_demo/file_demo.csproj`](../../materials/10/file_demo/file_demo.csproj) | Concept companion | [Walkthrough](demos/10_file_demo.md) |
| [`08/arrays_demo/arrays_demo.csproj`](../../materials/08/arrays_demo/arrays_demo.csproj) | Concept companion with jagged-array extension | [Walkthrough](demos/08_arrays_demo.md) |
| [`08/array_lab/array_lab.csproj`](../../materials/08/array_lab/array_lab.csproj) | Completed legacy exercise; not a current lab solution | [Walkthrough](demos/08_array_lab.md) |
| [`09/collections_demo/collections_demo.csproj`](../../materials/09/collections_demo/collections_demo.csproj) | Concept companion | [Walkthrough](demos/09_collections_demo.md) |
| [`09/help_responses/help_responses.csproj`](../../materials/09/help_responses/help_responses.csproj) | Supplementary integrated example | [Walkthrough](demos/09_help_responses.md) |
| [`12/classes_demo/classes_demo.csproj`](../../materials/12/classes_demo/classes_demo.csproj) | Concept companion | [Walkthrough](demos/12_classes_demo.md) |
| [`12/classes_lab/classes_lab.csproj`](../../materials/12/classes_lab/classes_lab.csproj) | Completed legacy exercise; not a current lab solution | [Walkthrough](demos/12_classes_lab.md) |
| [`13/oop_demo/oop_demo.csproj`](../../materials/13/oop_demo/oop_demo.csproj) | Concept companion across the OOP sections | [Walkthrough](demos/13_oop_demo.md) |
| [`13/oop_lab/oop_lab.csproj`](../../materials/13/oop_lab/oop_lab.csproj) | Supplementary example; not a current lab solution | [Walkthrough](demos/13_oop_lab.md) |
| [`22/search_sort_demo/search_sort_demo.csproj`](../../materials/22/search_sort_demo/search_sort_demo.csproj) | Concept companion with timing extensions | [Walkthrough](demos/22_search_sort_demo.md) |
| [`12/enum_demo/enum_demo.csproj`](../../materials/12/enum_demo/enum_demo.csproj) | Supplementary type example | [Walkthrough](demos/12_enum_demo.md) |
| [`06/exceptions_demo/exceptions_demo.csproj`](../../materials/06/exceptions_demo/exceptions_demo.csproj) | Concept companion | [Walkthrough](demos/06_exceptions_demo.md) |
| [`06/math_tests/math_app/math_app.csproj`](../../materials/06/math_tests/math_app/math_app.csproj) | Testing demonstration library | [Walkthrough](demos/06_math_tests_math_app.md) |
| [`06/math_tests/math_app_test/math_app_test.csproj`](../../materials/06/math_tests/math_app_test/math_app_test.csproj) | Concept companion test suite | [Walkthrough](demos/06_math_tests_math_app_test.md) |
| [`06/math_lab/math_app/math_app.csproj`](../../materials/06/math_lab/math_app/math_app.csproj) | Supplementary console/test example; not a current lab solution | [Walkthrough](demos/06_math_lab_math_app.md) |
| [`06/math_lab/math_app_test/math_app_test.csproj`](../../materials/06/math_lab/math_app_test/math_app_test.csproj) | Supplementary test suite; not a current lab solution | [Walkthrough](demos/06_math_lab_math_app_test.md) |
| [`_extras/one_hour_of_code/one_hour_of_code.csproj`](../../materials/_extras/one_hour_of_code/one_hour_of_code.csproj) | Optional multi-chapter overview | [Walkthrough](demos/_extras_one_hour_of_code.md) |
| [`_extras/contact_demo/contact_demo.csproj`](../../materials/_extras/contact_demo/contact_demo.csproj) | Supplementary instance-method example | [Walkthrough](demos/_extras_contact_demo.md) |
| [`_extras/console_input_introcs/console_input_introcs.csproj`](../../materials/_extras/console_input_introcs/console_input_introcs.csproj) | Reusable helper library | [Walkthrough](demos/_extras_console_input_introcs.md) |
| [`_extras/console_input_intro_cscs/console_input_intro_cscs.csproj`](../../materials/_extras/console_input_intro_cscs/console_input_intro_cscs.csproj) | Reusable helper library | [Walkthrough](demos/_extras_console_input_intro_cscs.md) |

## Current Assignment Solution Guides

| Assignment | Canonical code | Instructor guide |
| --- | --- | --- |
| Chapter 3: Product Code Report task | `materials/03/sku_report_lab_solution.cs` | [Method reasoning, expected output, and assessment checkpoints](labs/03_lab_solution.md) |
| Chapter 7: Privacy Pass, Tasks 1-5 | `materials/07/privacy_pass_lab_solution.cs` | [Task walkthroughs and reflection guidance](labs/07_lab_solution.md) |
| Chapter 8: Sales lab, Tasks 1-5 | Five hidden answer cells in the current lab notebook | [Verified outputs and grading guidance](labs/08_sales_lab.md) |

The Chapter 3 reference does not cover all of Lab 03. Students must also add
their own example, explanation, and the requested submission evidence.
The completed `materials/08/array_lab/` helpers are **not** the sales-lab key.

## Assignment Inventory and Remaining Gaps

The inventory below counts coding-question cells (`thebe-interactive`) and
hidden answer cells (`hide-input`). These are structural observations, not a
correctness audit or a count of all questions. A page with zero hidden answers
can have answers in another format. Preview quizzes and true/false questions
need a separate answer-key review.

This pass supplies 27 demo/supporting-project walkthroughs and three current
assignment guides. Most other assignments still need instructor explanations,
expected outcomes, and grading guidance checked against their exact questions.
Do not describe the book as having a complete instructor solution manual yet.

| Assignment notebook | Coding-question cells | Hidden answer cells |
| --- | --- | --- |
| [chapters/01-context/assignments/homework.ipynb](../../chapters/01-context/assignments/homework.ipynb) | 0 | 0 |
| [chapters/01-context/assignments/lab.ipynb](../../chapters/01-context/assignments/lab.ipynb) | 0 | 0 |
| [chapters/01-context/assignments/preview.ipynb](../../chapters/01-context/assignments/preview.ipynb) | 0 | 0 |
| [chapters/02-var_data/assignments/homework.ipynb](../../chapters/02-var_data/assignments/homework.ipynb) | 0 | 0 |
| [chapters/02-var_data/assignments/lab.ipynb](../../chapters/02-var_data/assignments/lab.ipynb) | 5 | 5 |
| [chapters/02-var_data/assignments/preview.ipynb](../../chapters/02-var_data/assignments/preview.ipynb) | 0 | 0 |
| [chapters/03-methods/assignments/homework.ipynb](../../chapters/03-methods/assignments/homework.ipynb) | 0 | 0 |
| [chapters/03-methods/assignments/lab.ipynb](../../chapters/03-methods/assignments/lab.ipynb) | 0 | 0 |
| [chapters/03-methods/assignments/preview.ipynb](../../chapters/03-methods/assignments/preview.ipynb) | 0 | 0 |
| [chapters/04-decision/assignments/homework.ipynb](../../chapters/04-decision/assignments/homework.ipynb) | 0 | 0 |
| [chapters/04-decision/assignments/lab.ipynb](../../chapters/04-decision/assignments/lab.ipynb) | 5 | 5 |
| [chapters/04-decision/assignments/preview.ipynb](../../chapters/04-decision/assignments/preview.ipynb) | 0 | 0 |
| [chapters/05-iteration/assignments/homework-gradecalculation.ipynb](../../chapters/05-iteration/assignments/homework-gradecalculation.ipynb) | 0 | 0 |
| [chapters/05-iteration/assignments/homework-gradecalculation2.ipynb](../../chapters/05-iteration/assignments/homework-gradecalculation2.ipynb) | 0 | 0 |
| [chapters/05-iteration/assignments/homework.ipynb](../../chapters/05-iteration/assignments/homework.ipynb) | 0 | 0 |
| [chapters/05-iteration/assignments/lab.ipynb](../../chapters/05-iteration/assignments/lab.ipynb) | 5 | 5 |
| [chapters/05-iteration/assignments/preview.ipynb](../../chapters/05-iteration/assignments/preview.ipynb) | 0 | 0 |
| [chapters/06-exceptions-testing/assignments/homework.ipynb](../../chapters/06-exceptions-testing/assignments/homework.ipynb) | 0 | 0 |
| [chapters/06-exceptions-testing/assignments/lab.ipynb](../../chapters/06-exceptions-testing/assignments/lab.ipynb) | 0 | 0 |
| [chapters/06-exceptions-testing/assignments/preview.ipynb](../../chapters/06-exceptions-testing/assignments/preview.ipynb) | 0 | 0 |
| [chapters/07-society-ethics/assignments/homework.ipynb](../../chapters/07-society-ethics/assignments/homework.ipynb) | 0 | 0 |
| [chapters/07-society-ethics/assignments/lab.ipynb](../../chapters/07-society-ethics/assignments/lab.ipynb) | 0 | 0 |
| [chapters/07-society-ethics/assignments/preview.ipynb](../../chapters/07-society-ethics/assignments/preview.ipynb) | 0 | 0 |
| [chapters/08-arrays/assignments/homework.ipynb](../../chapters/08-arrays/assignments/homework.ipynb) | 0 | 0 |
| [chapters/08-arrays/assignments/lab.ipynb](../../chapters/08-arrays/assignments/lab.ipynb) | 5 | 5 |
| [chapters/08-arrays/assignments/preview.ipynb](../../chapters/08-arrays/assignments/preview.ipynb) | 0 | 0 |
| [chapters/09-collections/assignments/homework.ipynb](../../chapters/09-collections/assignments/homework.ipynb) | 0 | 0 |
| [chapters/09-collections/assignments/lab.ipynb](../../chapters/09-collections/assignments/lab.ipynb) | 5 | 5 |
| [chapters/09-collections/assignments/preview.ipynb](../../chapters/09-collections/assignments/preview.ipynb) | 0 | 0 |
| [chapters/10-files-text/assignments/homework.ipynb](../../chapters/10-files-text/assignments/homework.ipynb) | 0 | 0 |
| [chapters/10-files-text/assignments/hw-gradefiles.ipynb](../../chapters/10-files-text/assignments/hw-gradefiles.ipynb) | 0 | 0 |
| [chapters/10-files-text/assignments/lab.ipynb](../../chapters/10-files-text/assignments/lab.ipynb) | 5 | 5 |
| [chapters/10-files-text/assignments/preview.ipynb](../../chapters/10-files-text/assignments/preview.ipynb) | 0 | 0 |
| [chapters/12_classes/assignments/homework.ipynb](../../chapters/12_classes/assignments/homework.ipynb) | 0 | 0 |
| [chapters/12_classes/assignments/hw_booklist.ipynb](../../chapters/12_classes/assignments/hw_booklist.ipynb) | 0 | 0 |
| [chapters/12_classes/assignments/lab.ipynb](../../chapters/12_classes/assignments/lab.ipynb) | 5 | 5 |
| [chapters/12_classes/assignments/preview.ipynb](../../chapters/12_classes/assignments/preview.ipynb) | 0 | 0 |
| [chapters/13_oop/assignments/homework.ipynb](../../chapters/13_oop/assignments/homework.ipynb) | 0 | 0 |
| [chapters/13_oop/assignments/lab.ipynb](../../chapters/13_oop/assignments/lab.ipynb) | 0 | 0 |
| [chapters/13_oop/assignments/preview.ipynb](../../chapters/13_oop/assignments/preview.ipynb) | 0 | 0 |
| [chapters/14-abstract-data-types/assignments/homework.ipynb](../../chapters/14-abstract-data-types/assignments/homework.ipynb) | 5 | 5 |
| [chapters/14-abstract-data-types/assignments/lab.ipynb](../../chapters/14-abstract-data-types/assignments/lab.ipynb) | 5 | 5 |
| [chapters/14-abstract-data-types/assignments/preview.ipynb](../../chapters/14-abstract-data-types/assignments/preview.ipynb) | 0 | 0 |
| [chapters/14-functional-patterns/assignments/homework.ipynb](../../chapters/14-functional-patterns/assignments/homework.ipynb) | 0 | 0 |
| [chapters/14-functional-patterns/assignments/lab.ipynb](../../chapters/14-functional-patterns/assignments/lab.ipynb) | 0 | 0 |
| [chapters/14-functional-patterns/assignments/preview.ipynb](../../chapters/14-functional-patterns/assignments/preview.ipynb) | 0 | 0 |
| [chapters/15-arrays-linked-lists/assignments/homework.ipynb](../../chapters/15-arrays-linked-lists/assignments/homework.ipynb) | 5 | 5 |
| [chapters/15-arrays-linked-lists/assignments/lab.ipynb](../../chapters/15-arrays-linked-lists/assignments/lab.ipynb) | 5 | 5 |
| [chapters/15-arrays-linked-lists/assignments/preview.ipynb](../../chapters/15-arrays-linked-lists/assignments/preview.ipynb) | 0 | 0 |
| [chapters/15-pattern-records/assignments/homework.ipynb](../../chapters/15-pattern-records/assignments/homework.ipynb) | 0 | 0 |
| [chapters/15-pattern-records/assignments/lab-solutions.ipynb](../../chapters/15-pattern-records/assignments/lab-solutions.ipynb) | 0 | 0 |
| [chapters/15-pattern-records/assignments/lab.ipynb](../../chapters/15-pattern-records/assignments/lab.ipynb) | 0 | 0 |
| [chapters/15-pattern-records/assignments/preview.ipynb](../../chapters/15-pattern-records/assignments/preview.ipynb) | 0 | 0 |
| [chapters/16-generics-async/assignments/homework.ipynb](../../chapters/16-generics-async/assignments/homework.ipynb) | 0 | 0 |
| [chapters/16-generics-async/assignments/lab-solutions.ipynb](../../chapters/16-generics-async/assignments/lab-solutions.ipynb) | 0 | 0 |
| [chapters/16-generics-async/assignments/lab.ipynb](../../chapters/16-generics-async/assignments/lab.ipynb) | 0 | 0 |
| [chapters/16-generics-async/assignments/preview.ipynb](../../chapters/16-generics-async/assignments/preview.ipynb) | 0 | 0 |
| [chapters/16-stacks-queues/assignments/homework.ipynb](../../chapters/16-stacks-queues/assignments/homework.ipynb) | 5 | 5 |
| [chapters/16-stacks-queues/assignments/lab.ipynb](../../chapters/16-stacks-queues/assignments/lab.ipynb) | 5 | 5 |
| [chapters/16-stacks-queues/assignments/preview.ipynb](../../chapters/16-stacks-queues/assignments/preview.ipynb) | 0 | 0 |
| [chapters/17-trees/assignments/homework.ipynb](../../chapters/17-trees/assignments/homework.ipynb) | 5 | 5 |
| [chapters/17-trees/assignments/lab.ipynb](../../chapters/17-trees/assignments/lab.ipynb) | 5 | 5 |
| [chapters/17-trees/assignments/preview.ipynb](../../chapters/17-trees/assignments/preview.ipynb) | 0 | 0 |
| [chapters/18-heaps-hash-tables/assignments/homework.ipynb](../../chapters/18-heaps-hash-tables/assignments/homework.ipynb) | 5 | 5 |
| [chapters/18-heaps-hash-tables/assignments/lab.ipynb](../../chapters/18-heaps-hash-tables/assignments/lab.ipynb) | 5 | 5 |
| [chapters/18-heaps-hash-tables/assignments/preview.ipynb](../../chapters/18-heaps-hash-tables/assignments/preview.ipynb) | 0 | 0 |
| [chapters/19-graphs/assignments/homework.ipynb](../../chapters/19-graphs/assignments/homework.ipynb) | 5 | 5 |
| [chapters/19-graphs/assignments/lab.ipynb](../../chapters/19-graphs/assignments/lab.ipynb) | 5 | 5 |
| [chapters/19-graphs/assignments/preview.ipynb](../../chapters/19-graphs/assignments/preview.ipynb) | 0 | 0 |
| [chapters/20-algorithm-analysis/assignments/homework.ipynb](../../chapters/20-algorithm-analysis/assignments/homework.ipynb) | 5 | 5 |
| [chapters/20-algorithm-analysis/assignments/lab.ipynb](../../chapters/20-algorithm-analysis/assignments/lab.ipynb) | 5 | 5 |
| [chapters/20-algorithm-analysis/assignments/preview.ipynb](../../chapters/20-algorithm-analysis/assignments/preview.ipynb) | 0 | 0 |
| [chapters/21-recursion-divide-conquer/assignments/homework.ipynb](../../chapters/21-recursion-divide-conquer/assignments/homework.ipynb) | 5 | 5 |
| [chapters/21-recursion-divide-conquer/assignments/lab.ipynb](../../chapters/21-recursion-divide-conquer/assignments/lab.ipynb) | 5 | 5 |
| [chapters/21-recursion-divide-conquer/assignments/preview.ipynb](../../chapters/21-recursion-divide-conquer/assignments/preview.ipynb) | 0 | 0 |
| [chapters/22-searching-sorting/assignments/homework.ipynb](../../chapters/22-searching-sorting/assignments/homework.ipynb) | 5 | 5 |
| [chapters/22-searching-sorting/assignments/lab.ipynb](../../chapters/22-searching-sorting/assignments/lab.ipynb) | 5 | 5 |
| [chapters/22-searching-sorting/assignments/preview.ipynb](../../chapters/22-searching-sorting/assignments/preview.ipynb) | 0 | 0 |
| [chapters/23-greedy-graph-optimization/assignments/homework.ipynb](../../chapters/23-greedy-graph-optimization/assignments/homework.ipynb) | 5 | 5 |
| [chapters/23-greedy-graph-optimization/assignments/lab.ipynb](../../chapters/23-greedy-graph-optimization/assignments/lab.ipynb) | 5 | 5 |
| [chapters/23-greedy-graph-optimization/assignments/preview.ipynb](../../chapters/23-greedy-graph-optimization/assignments/preview.ipynb) | 0 | 0 |
| [chapters/24-dynamic-programming-backtracking/assignments/homework.ipynb](../../chapters/24-dynamic-programming-backtracking/assignments/homework.ipynb) | 5 | 5 |
| [chapters/24-dynamic-programming-backtracking/assignments/lab.ipynb](../../chapters/24-dynamic-programming-backtracking/assignments/lab.ipynb) | 5 | 5 |
| [chapters/24-dynamic-programming-backtracking/assignments/preview.ipynb](../../chapters/24-dynamic-programming-backtracking/assignments/preview.ipynb) | 0 | 0 |
| [chapters/25-advanced-graphs-strings-limits/assignments/homework.ipynb](../../chapters/25-advanced-graphs-strings-limits/assignments/homework.ipynb) | 5 | 5 |
| [chapters/25-advanced-graphs-strings-limits/assignments/lab.ipynb](../../chapters/25-advanced-graphs-strings-limits/assignments/lab.ipynb) | 5 | 5 |
| [chapters/25-advanced-graphs-strings-limits/assignments/preview.ipynb](../../chapters/25-advanced-graphs-strings-limits/assignments/preview.ipynb) | 0 | 0 |

## Verification Infrastructure

[`materials/verify_demos.py`](../../materials/verify_demos.py) and
[`materials/_extras/demo_checks/`](../../materials/_extras/demo_checks/README.md)
check demo behavior. They are authoring/verification tools, not student
assignment answers. The lab verifier below checks the specifically mapped
references without creating independently edited copies of notebook solutions.

## Other Chapter Source Banks

The following sources already contain chapter implementations/checks and have
existing run instructions. They were not moved by this pass. Their per-example
teaching walkthroughs remain to be developed; they are not automatically
assignment solutions.

| Source | Existing instructions |
| --- | --- |
| [materials/15/WorkOrderLists.cs](../../materials/15/WorkOrderLists.cs) | [README](../../materials/15/README.md) |
| [materials/16/ServiceDeskStructures.cs](../../materials/16/ServiceDeskStructures.cs) | [README](../../materials/16/README.md) |
| [materials/17/TicketTree.cs](../../materials/17/TicketTree.cs) | [README](../../materials/17/README.md) |
| [materials/18/HeapHashStructures.cs](../../materials/18/HeapHashStructures.cs) | [README](../../materials/18/README.md) |
| [materials/19/GraphWalk.cs](../../materials/19/GraphWalk.cs) | [README](../../materials/19/README.md) |
| [materials/19/RouteGraph.cs](../../materials/19/RouteGraph.cs) | [README](../../materials/19/README.md) |
| [materials/20/AnalysisChecks.cs](../../materials/20/AnalysisChecks.cs) | [README](../../materials/20/README.md) |
| [materials/21/StableSort.cs](../../materials/21/StableSort.cs) | [README](../../materials/21/README.md) |
| [materials/22/SearchSortChecks.cs](../../materials/22/SearchSortChecks.cs) | [README](../../materials/22/README.md) |
| [materials/23/GreedyChecks.cs](../../materials/23/GreedyChecks.cs) | [README](../../materials/23/README.md) |
| [materials/24/PlanningChecks.cs](../../materials/24/PlanningChecks.cs) | [README](../../materials/24/README.md) |
| [materials/25/AdvancedChecks.cs](../../materials/25/AdvancedChecks.cs) | [README](../../materials/25/README.md) |

## Recheck Current Lab References

```bash
python3 assignments/instructor_support/verify_lab_solutions.py
```

This compiles and runs both standalone references and each current Chapter 8
answer independently, then compares the output with the saved instructor
reference. If the notebook changes, review the guide and captured output before
updating the reference. Temporary projects are removed after verification.

## Maintaining Correspondence

`resource_map.json` records each migrated project's role, lesson, and guide;
`assignment_inventory.json` records the notebook answer-cell observations.
When a lesson or assignment changes, review its linked support and regenerate
its expected output. Keep notebook answer code canonical rather than copying
it into a second independently edited solution file.
