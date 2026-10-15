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

All mapped demo projects target .NET 10. `python3 scripts/verify_demos.py`
checks builds, console behavior, unit tests, and algorithm checks. Walkthrough
output captures were rerun during preparation; trailing spaces are omitted for readability. Random/timing values and
exception stack paths can vary.

## Demo and Supporting-Project Map

“Concept companion” means the project illustrates the linked lesson, not that
it reproduces the notebook or solves an assignment. Legacy folders named `lab`
do not by themselves imply a relationship to a current lab.

| Resource | Role | Instructor walkthrough |
| --- | --- | --- |
| [`01/hello_world/HelloWorld.csproj`](../demos/01/hello_world/HelloWorld.csproj) | Supporting project | See the project source |
| [`02/input/input.csproj`](../demos/02/input/input.csproj) | Supporting project | See the project source |
| [`02/output/output.csproj`](../demos/02/output/output.csproj) | Supporting project | See the project source |
| [`03/methods_demo/methods_demo.csproj`](../demos/03/methods_demo/methods_demo.csproj) | Supporting project | See the project source |
| [`04/conditional_demo/conditional_demo.csproj`](../demos/04/conditional_demo/conditional_demo.csproj) | Supporting project | See the project source |
| [`05/for_loop_demo/for_loop_demo.csproj`](../demos/05/for_loop_demo/for_loop_demo.csproj) | Supporting project | See the project source |
| [`05/while_loop_demo/while_loop_demo.csproj`](../demos/05/while_loop_demo/while_loop_demo.csproj) | Supporting project | See the project source |
| [`10/file_demo/file_demo.csproj`](../demos/10/file_demo/file_demo.csproj) | Supporting project | See the project source |
| [`08/arrays_demo/arrays_demo.csproj`](../demos/08/arrays_demo/arrays_demo.csproj) | Supporting project | See the project source |
| [`08/array_lab/array_lab.csproj`](../demos/08/array_lab/array_lab.csproj) | Supporting project | See the project source |
| [`09/collections_demo/collections_demo.csproj`](../demos/09/collections_demo/collections_demo.csproj) | Supporting project | See the project source |
| [`09/help_responses/help_responses.csproj`](../demos/09/help_responses/help_responses.csproj) | Supporting project | See the project source |
| [`11/classes_demo/classes_demo.csproj`](../demos/11/classes_demo/classes_demo.csproj) | Supporting project | See the project source |
| [`11/classes_lab/classes_lab.csproj`](../demos/11/classes_lab/classes_lab.csproj) | Supporting project | See the project source |
| [`13/oop_demo/oop_demo.csproj`](../demos/13/oop_demo/oop_demo.csproj) | Supporting project | See the project source |
| [`13/oop_lab/oop_lab.csproj`](../demos/13/oop_lab/oop_lab.csproj) | Supporting project | See the project source |
| [`24/search_sort_demo/search_sort_demo.csproj`](../demos/24/search_sort_demo/search_sort_demo.csproj) | Supporting project | See the project source |
| [`11/enum_demo/enum_demo.csproj`](../demos/11/enum_demo/enum_demo.csproj) | Supporting project | See the project source |
| [`06/exceptions_demo/exceptions_demo.csproj`](../demos/06/exceptions_demo/exceptions_demo.csproj) | Supporting project | See the project source |
| [`06/math_tests/math_app/math_app.csproj`](../demos/06/math_tests/math_app/math_app.csproj) | Supporting project | See the project source |
| [`06/math_tests/math_app_test/math_app_test.csproj`](../demos/06/math_tests/math_app_test/math_app_test.csproj) | Supporting project | See the project source |
| [`06/math_lab/math_app/math_app.csproj`](../demos/06/math_lab/math_app/math_app.csproj) | Supporting project | See the project source |
| [`06/math_lab/math_app_test/math_app_test.csproj`](../demos/06/math_lab/math_app_test/math_app_test.csproj) | Supporting project | See the project source |
| [`_extras/one_hour_of_code/one_hour_of_code.csproj`](../demos/_extras/one_hour_of_code/one_hour_of_code.csproj) | Supporting project | See the project source |
| [`_extras/contact_demo/contact_demo.csproj`](../demos/_extras/contact_demo/contact_demo.csproj) | Supporting project | See the project source |
| [`_extras/console_input_introcs/console_input_introcs.csproj`](../demos/_extras/console_input_introcs/console_input_introcs.csproj) | Supporting project | See the project source |
| [`_extras/console_input_intro_cscs/console_input_intro_cscs.csproj`](../demos/_extras/console_input_intro_cscs/console_input_intro_cscs.csproj) | Supporting project | See the project source |
| [`12/object_design/ObjectDesign.csproj`](../demos/12/object_design/ObjectDesign.csproj) | Supporting project | See the project source |
| [`13/policy_design/PolicyDesign.csproj`](../demos/13/policy_design/PolicyDesign.csproj) | Supporting project | See the project source |
| [`17/search_sort/BasicSearchSort.csproj`](../demos/17/search_sort/BasicSearchSort.csproj) | Searching and insertion-sort reference checks | [Guide](adoption_routes.md) |
| [`19/priority_queue/HeapChecks.csproj`](../demos/19/priority_queue/HeapChecks.csproj) | Generic heap reference checks | [Guide](adoption_routes.md) |
| [`20/hash_collections/HashChecks.csproj`](../demos/20/hash_collections/HashChecks.csproj) | Chained map and set reference checks | [Guide](adoption_routes.md) |
| [`21/graph_traversal/GraphChecks.csproj`](../demos/21/graph_traversal/GraphChecks.csproj) | Core BFS DFS path and component checks | [Guide](adoption_routes.md) |

## Current Assignment Solution Guides

| Assignment | Canonical code | Instructor guide |
| --- | --- | --- |
| Chapter 3: Product Code Report task | `demos/03/sku_report_lab_solution.cs` | [Method reasoning, expected output, and assessment checkpoints](labs/03_lab_solution.md) |
| Chapter 7: Privacy Pass, Tasks 1-5 | `demos/07/privacy_pass_lab_solution.cs` | [Task walkthroughs and reflection guidance](labs/07_lab_solution.md) |
| Chapter 8: Sales lab, Tasks 1-5 | Five hidden answer cells in the current lab notebook | [Verified outputs and grading guidance](labs/08_sales_lab.md) |

The Chapter 3 reference does not cover all of Lab 03. Students must also add
their own example, explanation, and the requested submission evidence.
The completed `demos/08/array_lab/` helpers are **not** the sales-lab key.

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
| [chapters/01_context/assignments/homework.ipynb](../chapters/01_context/assignments/homework.ipynb) | 0 | 0 |
| [chapters/01_context/assignments/lab.ipynb](../chapters/01_context/assignments/lab.ipynb) | 0 | 0 |
| [chapters/01_context/assignments/preview.ipynb](../chapters/01_context/assignments/preview.ipynb) | 0 | 0 |
| [chapters/02_var_data/assignments/homework.ipynb](../chapters/02_var_data/assignments/homework.ipynb) | 0 | 0 |
| [chapters/02_var_data/assignments/lab.ipynb](../chapters/02_var_data/assignments/lab.ipynb) | 5 | 5 |
| [chapters/02_var_data/assignments/preview.ipynb](../chapters/02_var_data/assignments/preview.ipynb) | 0 | 0 |
| [chapters/03_methods/assignments/homework.ipynb](../chapters/03_methods/assignments/homework.ipynb) | 0 | 0 |
| [chapters/03_methods/assignments/lab.ipynb](../chapters/03_methods/assignments/lab.ipynb) | 0 | 0 |
| [chapters/03_methods/assignments/preview.ipynb](../chapters/03_methods/assignments/preview.ipynb) | 0 | 0 |
| [chapters/04_decision/assignments/homework.ipynb](../chapters/04_decision/assignments/homework.ipynb) | 0 | 0 |
| [chapters/04_decision/assignments/lab.ipynb](../chapters/04_decision/assignments/lab.ipynb) | 5 | 5 |
| [chapters/04_decision/assignments/preview.ipynb](../chapters/04_decision/assignments/preview.ipynb) | 0 | 0 |
| [chapters/05_iteration/assignments/homework_gradecalculation.ipynb](../chapters/05_iteration/assignments/homework_gradecalculation.ipynb) | 0 | 0 |
| [chapters/05_iteration/assignments/homework_gradecalculation2.ipynb](../chapters/05_iteration/assignments/homework_gradecalculation2.ipynb) | 0 | 0 |
| [chapters/05_iteration/assignments/homework.ipynb](../chapters/05_iteration/assignments/homework.ipynb) | 0 | 0 |
| [chapters/05_iteration/assignments/lab.ipynb](../chapters/05_iteration/assignments/lab.ipynb) | 5 | 5 |
| [chapters/05_iteration/assignments/preview.ipynb](../chapters/05_iteration/assignments/preview.ipynb) | 0 | 0 |
| [chapters/06_exceptions_testing/assignments/homework.ipynb](../chapters/06_exceptions_testing/assignments/homework.ipynb) | 0 | 0 |
| [chapters/06_exceptions_testing/assignments/lab.ipynb](../chapters/06_exceptions_testing/assignments/lab.ipynb) | 0 | 0 |
| [chapters/06_exceptions_testing/assignments/preview.ipynb](../chapters/06_exceptions_testing/assignments/preview.ipynb) | 0 | 0 |
| [chapters/07_society_ethics/assignments/homework.ipynb](../chapters/07_society_ethics/assignments/homework.ipynb) | 0 | 0 |
| [chapters/07_society_ethics/assignments/lab.ipynb](../chapters/07_society_ethics/assignments/lab.ipynb) | 0 | 0 |
| [chapters/07_society_ethics/assignments/preview.ipynb](../chapters/07_society_ethics/assignments/preview.ipynb) | 0 | 0 |
| [chapters/08_arrays/assignments/homework.ipynb](../chapters/08_arrays/assignments/homework.ipynb) | 0 | 0 |
| [chapters/08_arrays/assignments/lab.ipynb](../chapters/08_arrays/assignments/lab.ipynb) | 5 | 5 |
| [chapters/08_arrays/assignments/preview.ipynb](../chapters/08_arrays/assignments/preview.ipynb) | 0 | 0 |
| [chapters/09_collections/assignments/homework.ipynb](../chapters/09_collections/assignments/homework.ipynb) | 0 | 0 |
| [chapters/09_collections/assignments/lab.ipynb](../chapters/09_collections/assignments/lab.ipynb) | 5 | 5 |
| [chapters/09_collections/assignments/preview.ipynb](../chapters/09_collections/assignments/preview.ipynb) | 0 | 0 |
| [chapters/10_files_text/assignments/homework.ipynb](../chapters/10_files_text/assignments/homework.ipynb) | 0 | 0 |
| [chapters/10_files_text/assignments/hw_gradefiles.ipynb](../chapters/10_files_text/assignments/hw_gradefiles.ipynb) | 0 | 0 |
| [chapters/10_files_text/assignments/lab.ipynb](../chapters/10_files_text/assignments/lab.ipynb) | 5 | 5 |
| [chapters/10_files_text/assignments/preview.ipynb](../chapters/10_files_text/assignments/preview.ipynb) | 0 | 0 |
| [chapters/11_classes/assignments/homework.ipynb](../chapters/11_classes/assignments/homework.ipynb) | 0 | 0 |
| [chapters/11_classes/assignments/hw_booklist.ipynb](../chapters/11_classes/assignments/hw_booklist.ipynb) | 0 | 0 |
| [chapters/11_classes/assignments/lab.ipynb](../chapters/11_classes/assignments/lab.ipynb) | 5 | 5 |
| [chapters/11_classes/assignments/preview.ipynb](../chapters/11_classes/assignments/preview.ipynb) | 0 | 0 |
| [chapters/13_oop/assignments/homework.ipynb](../chapters/13_oop/assignments/homework.ipynb) | 0 | 0 |
| [chapters/13_oop/assignments/lab.ipynb](../chapters/13_oop/assignments/lab.ipynb) | 0 | 0 |
| [chapters/13_oop/assignments/preview.ipynb](../chapters/13_oop/assignments/preview.ipynb) | 0 | 0 |
| [chapters/14_abstract_data_types/assignments/homework.ipynb](../chapters/14_abstract_data_types/assignments/homework.ipynb) | 5 | 5 |
| [chapters/14_abstract_data_types/assignments/lab.ipynb](../chapters/14_abstract_data_types/assignments/lab.ipynb) | 5 | 5 |
| [chapters/14_abstract_data_types/assignments/preview.ipynb](../chapters/14_abstract_data_types/assignments/preview.ipynb) | 0 | 0 |
| [chapters/15_arrays_linked_lists/assignments/homework.ipynb](../chapters/15_arrays_linked_lists/assignments/homework.ipynb) | 5 | 5 |
| [chapters/15_arrays_linked_lists/assignments/lab.ipynb](../chapters/15_arrays_linked_lists/assignments/lab.ipynb) | 5 | 5 |
| [chapters/15_arrays_linked_lists/assignments/preview.ipynb](../chapters/15_arrays_linked_lists/assignments/preview.ipynb) | 0 | 0 |
| [chapters/16_stacks_queues/assignments/homework.ipynb](../chapters/16_stacks_queues/assignments/homework.ipynb) | 5 | 5 |
| [chapters/16_stacks_queues/assignments/lab.ipynb](../chapters/16_stacks_queues/assignments/lab.ipynb) | 5 | 5 |
| [chapters/16_stacks_queues/assignments/preview.ipynb](../chapters/16_stacks_queues/assignments/preview.ipynb) | 0 | 0 |
| [chapters/17_searching_sorting/assignments/homework.ipynb](../chapters/17_searching_sorting/assignments/homework.ipynb) | 5 | 5 |
| [chapters/17_searching_sorting/assignments/lab.ipynb](../chapters/17_searching_sorting/assignments/lab.ipynb) | 5 | 5 |
| [chapters/17_searching_sorting/assignments/preview.ipynb](../chapters/17_searching_sorting/assignments/preview.ipynb) | 0 | 0 |
| [chapters/18_trees/assignments/homework.ipynb](../chapters/18_trees/assignments/homework.ipynb) | 5 | 5 |
| [chapters/18_trees/assignments/lab.ipynb](../chapters/18_trees/assignments/lab.ipynb) | 5 | 5 |
| [chapters/18_trees/assignments/preview.ipynb](../chapters/18_trees/assignments/preview.ipynb) | 0 | 0 |
| [chapters/19_priority_queues/assignments/homework.ipynb](../chapters/19_priority_queues/assignments/homework.ipynb) | 5 | 5 |
| [chapters/19_priority_queues/assignments/lab.ipynb](../chapters/19_priority_queues/assignments/lab.ipynb) | 5 | 5 |
| [chapters/19_priority_queues/assignments/preview.ipynb](../chapters/19_priority_queues/assignments/preview.ipynb) | 0 | 0 |
| [chapters/20_hash_collections/assignments/homework.ipynb](../chapters/20_hash_collections/assignments/homework.ipynb) | 5 | 5 |
| [chapters/20_hash_collections/assignments/lab.ipynb](../chapters/20_hash_collections/assignments/lab.ipynb) | 5 | 5 |
| [chapters/20_hash_collections/assignments/preview.ipynb](../chapters/20_hash_collections/assignments/preview.ipynb) | 0 | 0 |
| [chapters/21_graphs/assignments/homework.ipynb](../chapters/21_graphs/assignments/homework.ipynb) | 5 | 5 |
| [chapters/21_graphs/assignments/lab.ipynb](../chapters/21_graphs/assignments/lab.ipynb) | 5 | 5 |
| [chapters/21_graphs/assignments/preview.ipynb](../chapters/21_graphs/assignments/preview.ipynb) | 0 | 0 |
| [chapters/22_algorithm_analysis/assignments/homework.ipynb](../chapters/22_algorithm_analysis/assignments/homework.ipynb) | 5 | 5 |
| [chapters/22_algorithm_analysis/assignments/lab.ipynb](../chapters/22_algorithm_analysis/assignments/lab.ipynb) | 5 | 5 |
| [chapters/22_algorithm_analysis/assignments/preview.ipynb](../chapters/22_algorithm_analysis/assignments/preview.ipynb) | 0 | 0 |
| [chapters/23_recursion_divide_conquer/assignments/homework.ipynb](../chapters/23_recursion_divide_conquer/assignments/homework.ipynb) | 5 | 5 |
| [chapters/23_recursion_divide_conquer/assignments/lab.ipynb](../chapters/23_recursion_divide_conquer/assignments/lab.ipynb) | 5 | 5 |
| [chapters/23_recursion_divide_conquer/assignments/preview.ipynb](../chapters/23_recursion_divide_conquer/assignments/preview.ipynb) | 0 | 0 |
| [chapters/24_searching_sorting/assignments/homework.ipynb](../chapters/24_searching_sorting/assignments/homework.ipynb) | 5 | 5 |
| [chapters/24_searching_sorting/assignments/lab.ipynb](../chapters/24_searching_sorting/assignments/lab.ipynb) | 5 | 5 |
| [chapters/24_searching_sorting/assignments/preview.ipynb](../chapters/24_searching_sorting/assignments/preview.ipynb) | 0 | 0 |
| [chapters/25_greedy_graph_optimization/assignments/homework.ipynb](../chapters/25_greedy_graph_optimization/assignments/homework.ipynb) | 5 | 5 |
| [chapters/25_greedy_graph_optimization/assignments/lab.ipynb](../chapters/25_greedy_graph_optimization/assignments/lab.ipynb) | 5 | 5 |
| [chapters/25_greedy_graph_optimization/assignments/preview.ipynb](../chapters/25_greedy_graph_optimization/assignments/preview.ipynb) | 0 | 0 |
| [chapters/26_dynamic_programming_backtracking/assignments/homework.ipynb](../chapters/26_dynamic_programming_backtracking/assignments/homework.ipynb) | 5 | 5 |
| [chapters/26_dynamic_programming_backtracking/assignments/lab.ipynb](../chapters/26_dynamic_programming_backtracking/assignments/lab.ipynb) | 5 | 5 |
| [chapters/26_dynamic_programming_backtracking/assignments/preview.ipynb](../chapters/26_dynamic_programming_backtracking/assignments/preview.ipynb) | 0 | 0 |
| [chapters/27_advanced_graphs_strings_limits/assignments/homework.ipynb](../chapters/27_advanced_graphs_strings_limits/assignments/homework.ipynb) | 5 | 5 |
| [chapters/27_advanced_graphs_strings_limits/assignments/lab.ipynb](../chapters/27_advanced_graphs_strings_limits/assignments/lab.ipynb) | 5 | 5 |
| [chapters/27_advanced_graphs_strings_limits/assignments/preview.ipynb](../chapters/27_advanced_graphs_strings_limits/assignments/preview.ipynb) | 0 | 0 |

## Verification Infrastructure

[`scripts/verify_demos.py`](../scripts/verify_demos.py) and
[`_extras/demo_checks/README.md`](../demos/_extras/demo_checks/README.md)
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
| [demos/15/WorkOrderLists.cs](../demos/15/WorkOrderLists.cs) | [README](../demos/15/README.md) |
| [demos/16/ServiceDeskStructures.cs](../demos/16/ServiceDeskStructures.cs) | [README](../demos/16/README.md) |
| [demos/18/TicketTree.cs](../demos/18/TicketTree.cs) | [README](../demos/18/README.md) |
| [demos/20/HeapHashStructures.cs](../demos/20/HeapHashStructures.cs) | [README](../demos/20/README.md) |
| [Core graph traversal](../demos/21/graph_traversal/Model.cs) | [README](../demos/21/README.md) |
| [demos/21/RouteGraph.cs](../demos/21/RouteGraph.cs) | [README](../demos/21/README.md) |
| [demos/22/AnalysisChecks.cs](../demos/22/AnalysisChecks.cs) | [README](../demos/22/README.md) |
| [demos/23/StableSort.cs](../demos/23/StableSort.cs) | [README](../demos/23/README.md) |
| [demos/24/SearchSortChecks.cs](../demos/24/SearchSortChecks.cs) | [README](../demos/24/README.md) |
| [demos/25/GreedyChecks.cs](../demos/25/GreedyChecks.cs) | [README](../demos/25/README.md) |
| [demos/26/PlanningChecks.cs](../demos/26/PlanningChecks.cs) | [README](../demos/26/README.md) |
| [demos/27/AdvancedChecks.cs](../demos/27/AdvancedChecks.cs) | [README](../demos/27/README.md) |

## Recheck Current Lab References

```bash
python3 scripts/verify_lab_solutions.py
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

Optional database appendix: [bookstore inventory lab guidance](labs/bookstore_inventory.md), with a dedicated starter, reference application, and isolated verification modes.

Part III references: [object design](../demos/12/object_design/README.md) and [policy design](../demos/13/policy_design/README.md). The lesson/assignment sources include executed solution output; see [Part III guidance](labs/part_03_oop.md).


See [Course Adoption Routes](adoption_routes.md) for standalone CS1 and flexible CS2 use.


See [Course Adoption Routes](adoption_routes.md) for standalone CS1 and flexible CS2 use.
