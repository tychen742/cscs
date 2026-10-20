# Runnable C# Demos and Supporting Code

## Open in VS Code

Clone the repository, then open the chapter's demo folder in VS Code and run
the project from the integrated terminal. Demo folders use the same
`NN_chapter_name` names as the book's chapters, so Chapter 10 Classes and
Objects lives in `demos/10_classes/`. For example:

```bash
git clone https://github.com/tychen742/cscs.git
cd cscs/demos/10_classes/classes_demo
code .
dotnet run
```

## Layout

The chapter demos use the **.NET 10 SDK** and target `net10.0`. Source files
are grouped by chapter folder, `demos/NN_chapter_name/`, matching the folder
names under `chapters/` (Chapter 13 has no demo folder). `_extras/` contains
cross-chapter demonstrations and reusable helper libraries; `_archived/`
contains retired source material.

From the repository root, build and run a demo with its project path:

```bash
dotnet build demos/01_context/hello_world/HelloWorld.csproj
dotnet run --project demos/01_context/hello_world/HelloWorld.csproj
```

Read each demo's README for console input and run modes. File demos copy
their data to the build output and locate it relative to the executable, so
they also work when run from the repository root.

## Roles and Complete Inventory

- **Demo:** complete code illustrating a concept; it is not automatically an assignment answer.
- **Student starter:** intentionally unfinished work. A successful build does not mean the lab is complete. Verification checks its documented starting behavior, including expected exceptions.
- **Lab solution/reference:** completed code matched to a named assignment, checked against saved output or its internal contract checks.
- **Supplementary completed practice:** older completed exercises retained for teaching; these are not substitutes for current lab answers.
- **Helper library, test suite, and verification harness:** supporting code and correctness checks.
- **Reference checks:** standalone implementations with executable checks, isolated in temporary projects by the verifier.

`demo_projects.json` lists every active project, its role, and its purpose.
`standalone_sources.json` lists the standalone source programs. `_archived/`
is preserved history and is excluded from active verification. Chapter 13 has
no separate demo folder. ZIP files are distribution copies, not additional
verification targets; the source folders below are authoritative.

### Projects

| Project | Role | Teaching purpose |
| --- | --- | --- |
| [01_context/hello_world/HelloWorld.csproj](01_context/hello_world/HelloWorld.csproj) | Demo | First C# console program and printed greeting. |
| [02_var_data/input/input.csproj](02_var_data/input/input.csproj) | Demo | Console input, parsing, arithmetic, and range validation. |
| [02_var_data/order_invoice_starter/order_invoice_starter.csproj](02_var_data/order_invoice_starter/order_invoice_starter.csproj) | Student starter | Unfinished office-supply invoice lab; expected to print nothing. |
| [02_var_data/output/output.csproj](02_var_data/output/output.csproj) | Demo | Formatted console output and interview-time input. |
| [02_var_data/ui_helper/ui_helper.csproj](02_var_data/ui_helper/ui_helper.csproj) | Demo | Namespace/helper-file import and validated integer input. |
| [03_decision/conditional_demo/conditional_demo.csproj](03_decision/conditional_demo/conditional_demo.csproj) | Demo | Top-level decisions and temperature-input validation. |
| [04_iteration/for_loop_demo/for_loop_demo.csproj](04_iteration/for_loop_demo/for_loop_demo.csproj) | Demo | Counted loops, character traversal, and accumulators. |
| [04_iteration/while_loop_demo/while_loop_demo.csproj](04_iteration/while_loop_demo/while_loop_demo.csproj) | Demo | Guessing-game repetition and input validation. |
| [05_methods/loop_methods_demo/loop_methods_demo.csproj](05_methods/loop_methods_demo/loop_methods_demo.csproj) | Demo | Method-based loop examples after Chapter 5; supplementary to top-level loops. |
| [05_methods/methods_demo/methods_demo.csproj](05_methods/methods_demo/methods_demo.csproj) | Demo | Method declarations, arguments, return values, and repeated calls. |
| [05_methods/sku_report_lab_solution.csproj](05_methods/sku_report_lab_solution.csproj) | Lab solution/reference | Completed SKU report lab reference. |
| [06_exceptions_testing/exceptions_demo/exceptions_demo.csproj](06_exceptions_testing/exceptions_demo/exceptions_demo.csproj) | Demo | Exception handling and access-error reporting. |
| [06_exceptions_testing/math_lab/math_app/math_app.csproj](06_exceptions_testing/math_lab/math_app/math_app.csproj) | Supplementary completed practice | Completed arithmetic console practice used with the paired test suite. |
| [06_exceptions_testing/math_lab/math_app_test/math_app_test.csproj](06_exceptions_testing/math_lab/math_app_test/math_app_test.csproj) | Test suite | Four MSTest arithmetic checks for the console-practice variant. |
| [06_exceptions_testing/math_tests/math_app/math_app.csproj](06_exceptions_testing/math_tests/math_app/math_app.csproj) | Helper library | Arithmetic library used by the paired test suite. |
| [06_exceptions_testing/math_tests/math_app_test/math_app_test.csproj](06_exceptions_testing/math_tests/math_app_test/math_app_test.csproj) | Test suite | Four MSTest arithmetic checks for the library variant. |
| [07_arrays/array_lab/array_lab.csproj](07_arrays/array_lab/array_lab.csproj) | Supplementary completed practice | Completed array drills; supplementary, not the current sales-lab answer. |
| [07_arrays/arrays_demo/arrays_demo.csproj](07_arrays/arrays_demo/arrays_demo.csproj) | Demo | Array arguments, traversal, and numeric-array operations. |
| [08_collections/collections_demo/collections_demo.csproj](08_collections/collections_demo/collections_demo.csproj) | Demo | Array traversal baseline with commented list examples for teaching variations. |
| [08_collections/help_responses/help_responses.csproj](08_collections/help_responses/help_responses.csproj) | Demo | Completed dictionary-based response simulation; supplementary integrated example. |
| [08_collections/word_count/word_count.csproj](08_collections/word_count/word_count.csproj) | Demo | Dictionary word counts with an ignore set and sorted reporting. |
| [09_files_text/file_demo/file_demo.csproj](09_files_text/file_demo/file_demo.csproj) | Demo | File reading, writing, and executable-relative sample data. |
| [09_files_text/help_responses_lab/help_responses_lab.csproj](09_files_text/help_responses_lab/help_responses_lab.csproj) | Student starter | File-response exercise starter; default hard-coded mode only. |
| [09_files_text/privacy_pass_lab_solution.csproj](09_files_text/privacy_pass_lab_solution.csproj) | Lab solution/reference | Completed optional privacy-pass file-processing lab. |
| [10_classes/classes_demo/classes_demo.csproj](10_classes/classes_demo/classes_demo.csproj) | Demo | Object construction, identity, and shared/static state. |
| [10_classes/classes_lab/classes_lab.csproj](10_classes/classes_lab/classes_lab.csproj) | Supplementary completed practice | Completed animal/employee and guessing-game exercises; not a current lab solution. |
| [10_classes/coffee_register_starter/coffee_register_starter.csproj](10_classes/coffee_register_starter/coffee_register_starter.csproj) | Student starter | Coffee-register lab with unfinished ToString; totals already work. |
| [10_classes/enum_demo/enum_demo.csproj](10_classes/enum_demo/enum_demo.csproj) | Demo | Named enum values and their underlying integer values. |
| [11_object_design/object_design/ObjectDesign.csproj](11_object_design/object_design/ObjectDesign.csproj) | Demo | Order collaboration model with 21 object-design checks. |
| [12_oop/oop_demo/oop_demo.csproj](12_oop/oop_demo/oop_demo.csproj) | Demo | Inheritance, polymorphism, overloads, interfaces, and shape behavior. |
| [12_oop/oop_lab/oop_lab.csproj](12_oop/oop_lab/oop_lab.csproj) | Supplementary completed practice | Completed bank-account encapsulation example; not a current lab solution. |
| [12_oop/policy_design/PolicyDesign.csproj](12_oop/policy_design/PolicyDesign.csproj) | Demo | Interface/override discount policies with 13 checks. |
| [16_searching_sorting/search_sort/BasicSearchSort.csproj](16_searching_sorting/search_sort/BasicSearchSort.csproj) | Demo | Searching and insertion-sort reference checks |
| [18_priority_queues/priority_queue/HeapChecks.csproj](18_priority_queues/priority_queue/HeapChecks.csproj) | Demo | Generic heap reference checks |
| [19_hash_collections/hash_collections/HashChecks.csproj](19_hash_collections/hash_collections/HashChecks.csproj) | Demo | Chained map and set reference checks |
| [20_graphs/graph_traversal/GraphChecks.csproj](20_graphs/graph_traversal/GraphChecks.csproj) | Demo | Core BFS DFS path and component checks |
| [23_searching_sorting/search_sort_demo/search_sort_demo.csproj](23_searching_sorting/search_sort_demo/search_sort_demo.csproj) | Demo | Interactive search and six sorting demonstrations with optional timing. |
| [_extras/bookstore_inventory/BookstoreInventory.csproj](_extras/bookstore_inventory/BookstoreInventory.csproj) | Lab solution/reference | Optional database appendix completed reference; in-memory checks. |
| [_extras/bookstore_inventory_starter/BookstoreInventory.csproj](_extras/bookstore_inventory_starter/BookstoreInventory.csproj) | Student starter | Optional database appendix unfinished lab; expected NotImplementedException. |
| [_extras/console_input_intro_cscs/console_input_intro_cscs.csproj](_extras/console_input_intro_cscs/console_input_intro_cscs.csproj) | Helper library | Reusable IntroCSCS console-input helper library. |
| [_extras/console_input_introcs/console_input_introcs.csproj](_extras/console_input_introcs/console_input_introcs.csproj) | Helper library | Reusable IntroCS console-input helper library. |
| [_extras/contact_demo/contact_demo.csproj](_extras/contact_demo/contact_demo.csproj) | Demo | Supplementary contact-object construction and display. |
| [_extras/demo_checks/demo_checks.csproj](_extras/demo_checks/demo_checks.csproj) | Verification harness | Independent regression checks for demo algorithms and helpers. |
| [_extras/one_hour_of_code/one_hour_of_code.csproj](_extras/one_hour_of_code/one_hour_of_code.csproj) | Demo | Short business-order introduction with input and shipping decisions. |

### Standalone Sources

| Source | Role | Teaching purpose |
| --- | --- | --- |
| [14_arrays_linked_lists/WorkOrderLists.cs](14_arrays_linked_lists/WorkOrderLists.cs) | Reference checks | Linear-list verification |
| [15_stacks_queues/ServiceDeskStructures.cs](15_stacks_queues/ServiceDeskStructures.cs) | Reference checks | Stack and queue verification |
| [17_trees/TicketTree.cs](17_trees/TicketTree.cs) | Reference checks | Chapter 17: Trees |
| [19_hash_collections/HeapHashStructures.cs](19_hash_collections/HeapHashStructures.cs) | Reference checks | Combined heap/map reference with boundary checks; retained under Chapter 19. |
| [20_graphs/RouteGraph.cs](20_graphs/RouteGraph.cs) | Reference checks | Chapter 20: Graph representations |
| [21_algorithm_analysis/AnalysisChecks.cs](21_algorithm_analysis/AnalysisChecks.cs) | Reference checks | Chapter 21: Analysis checks |
| [22_recursion_divide_conquer/StableSort.cs](22_recursion_divide_conquer/StableSort.cs) | Reference checks | Chapter 22: Stable merge sort |
| [23_searching_sorting/SearchSortChecks.cs](23_searching_sorting/SearchSortChecks.cs) | Reference checks | Chapter 23: Search and sort checks |
| [24_greedy_graph_optimization/GreedyChecks.cs](24_greedy_graph_optimization/GreedyChecks.cs) | Reference checks | Chapter 24: Greedy optimization checks |
| [25_dynamic_programming_backtracking/PlanningChecks.cs](25_dynamic_programming_backtracking/PlanningChecks.cs) | Reference checks | Chapter 25: Planning checks |
| [26_advanced_graphs_strings_limits/AdvancedChecks.cs](26_advanced_graphs_strings_limits/AdvancedChecks.cs) | Reference checks | Chapter 26: Advanced algorithm checks |
| [_extras/advanced_graph_walk/GraphWalk.cs](_extras/advanced_graph_walk/GraphWalk.cs) | Supplementary demo | Advanced graph traversal reference |

## Verify All Active Source

```bash
python3 scripts/verify_demos.py
```

Requires Python 3 and the **.NET 10 SDK**. The first run restores NuGet
packages, including MSTest and Microsoft.Data.Sqlite. Run from the repository
root. Verification covers all **44 projects and 12 standalone programs**:

- Build every project with warnings treated as errors. The invoice starter's two intentionally unused rate variables allow only `CS0219`; its source remains unfinished.
- Run demos with documented input and output checks, additional search/game/decision modes, both four-test MSTest suites, and the independent behavior-check harness.
- Compare the SKU-report and privacy-pass lab references with saved instructor output. Run both core and full database-reference checks in memory.
- Check starter behavior separately: the invoice prints nothing, the coffee register has blank unfinished summaries but working totals, the response lab runs its hard-coded mode, and the database starter raises its specific unfinished-task exception. These results do not certify completed student solutions.
- Copy each standalone `.cs` file unchanged into a temporary .NET 10 project, compile it, and verify its documented output. No permanent project scaffolding is needed in these folders.
- Fail if an active project or C# source is absent from the inventories, or an active demo README contains a broken local link. Archived code is excluded.

Console runs use an isolated working directory to catch accidental dependence
on the caller's directory and keep generated databases/files out of the
checkout. Builds create normal ignored `bin/` and `obj/` folders.

After restoring the existing projects, use:

```bash
python3 scripts/verify_demos.py --no-restore
```

Temporary standalone projects still need their initial SDK restore. For a
quick inventory and local-link check without building:

```bash
python3 scripts/verify_demos.py --inventory-only
```

`python3 scripts/verify_lab_solutions.py` also checks the Chapter 7 notebook's
five answer cells independently, in addition to the two saved lab references.

Both arithmetic test projects pass normally. To practice finding a defect,
change `Multiply` from `num1 * num2` to `num1 + num2`, run `dotnet test`, inspect
the failing multiplication test, then restore the multiplication operator.

## Former Demo Paths

The following source paths were migrated without changing any published
notebook URLs. They were not linked from the student book.

| Former path under `materials/demos/` | Current path under `demos/` |
| --- | --- |
| `Ch01Intro/HelloWorld/` | `01_context/hello_world/` |
| `Ch02DataVariable/Input/` | `02_var_data/input/` |
| `Ch02DataVariable/Ouput/` | `02_var_data/output/` |
| `Ch03Method/` | `05_methods/methods_demo/` |
| `Ch04Conditional/` | `03_decision/conditional_demo/` |
| `Ch05ForLoop/` | `04_iteration/for_loop_demo/` |
| `Ch06WhileLoop/` | `04_iteration/while_loop_demo/` |
| `Ch07File/` | `09_files_text/file_demo/` |
| `Ch08Arrays/` | `07_arrays/arrays_demo/` |
| `Ch08ArraysLab/` | `07_arrays/array_lab/` |
| `Ch09Collections/` | `08_collections/collections_demo/` |
| `Ch09CollectionsLab/` | `08_collections/help_responses/` |
| `Ch10Classes/` | `10_classes/classes_demo/` |
| `Ch10ClassesLab/` | `10_classes/classes_lab/` |
| `Ch11OOP/` | `12_oop/oop_demo/` |
| `Ch11OOPLab/` | `12_oop/oop_lab/` |
| `Ch12DataStructure/` | `23_searching_sorting/search_sort_demo/` |
| `Ch13Enum/` | `10_classes/enum_demo/` |
| `Ch13SelectedTopics/Exceptions/` | `06_exceptions_testing/exceptions_demo/` |
| `Ch13SelectedTopics/UnitTestProject1/` | `06_exceptions_testing/math_tests/` |
| `Ch13SelectedTopicsLab/UnitTestProject1/` | `06_exceptions_testing/math_lab/` |
| `OneHourOfCode/` | `_extras/one_hour_of_code/` |
| `final/` | `_extras/contact_demo/` |
| `ui/` | `_extras/console_input_introcs/` |
| `ui.cs` | `_extras/console_input_intro_cscs/ui.cs` |

The former CSharpier tool manifest is retained in `_archived/demo_tools/`;
it is not required to build or verify the .NET 10 demos.

The empty `Ch13SelectedTopics.csproj` container was removed after its exception
and testing projects were separated. Empty wrappers, the unused empty
`array1.cs`, and the obsolete array-project backup were removed. The two math
variants are retained: one demonstrates a library with tests, and the other
adds a console application with tests.

## Instructor Support

See [Instructor Support](../instructor_support/README.md) for
lesson mappings, walkthroughs, expected outputs, exact assignment solutions,
and identified gaps. A demo project is not automatically an assignment answer;
older projects named `lab` are explicitly labeled where no current match exists.

## Optional database appendix

`_extras/bookstore_inventory/` contains the verified reference; `_extras/bookstore_inventory_starter/` and its ZIP contain the student starter. Both target .NET 10 and pin Microsoft.Data.Sqlite 10.0.13. See the appendix for the connected lab and the project READMEs for restore/run commands.

## Part III model references

`11_object_design/object_design/` supplies the order collaboration model and boundary checks. `12_oop/policy_design/` supplies interface/override model checks. Both are .NET 10 console projects without package dependencies; see their READMEs for run commands.

## Chapter 10 Assignment Starter

[`10_classes/coffee_register_starter`](10_classes/coffee_register_starter/README.md) matches the final stage of the current coffee-register lab. It intentionally leaves ToString unfinished. The notebook hidden answer cells provide the canonical solution and expected output; the animal/guessing-game `classes_lab` project remains supplementary.

## Chapter 2 Assignment Starter

[`02_var_data/order_invoice_starter`](02_var_data/order_invoice_starter/README.md) matches the final stage of the office-supply Lab. Students complete its input, calculations, and report. The notebook answer cells contain the canonical solution and expected output.
