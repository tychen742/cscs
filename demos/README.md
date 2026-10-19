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

## Demo Projects

| Project | Purpose | Kind |
| --- | --- | --- |
| [01_context/hello_world](01_context/hello_world/HelloWorld.csproj) | Supporting project | console |
| [02_var_data/input](02_var_data/input/input.csproj) | Supporting project | console |
| [02_var_data/output](02_var_data/output/output.csproj) | Supporting project | console |
| [05_methods/methods_demo](05_methods/methods_demo/methods_demo.csproj) | Supporting project | console |
| [03_decision/conditional_demo](03_decision/conditional_demo/conditional_demo.csproj) | Supporting project | console |
| [04_iteration/for_loop_demo](04_iteration/for_loop_demo/for_loop_demo.csproj) | Supporting project | console |
| [04_iteration/while_loop_demo](04_iteration/while_loop_demo/while_loop_demo.csproj) | Supporting project | console |
| [09_files_text/file_demo](09_files_text/file_demo/file_demo.csproj) | Supporting project | console |
| [07_arrays/arrays_demo](07_arrays/arrays_demo/arrays_demo.csproj) | Supporting project | console |
| [07_arrays/array_lab](07_arrays/array_lab/array_lab.csproj) | Supporting project | console |
| [08_collections/collections_demo](08_collections/collections_demo/collections_demo.csproj) | Supporting project | console |
| [08_collections/help_responses](08_collections/help_responses/help_responses.csproj) | Supporting project | console |
| [10_classes/classes_demo](10_classes/classes_demo/classes_demo.csproj) | Supporting project | console |
| [10_classes/classes_lab](10_classes/classes_lab/classes_lab.csproj) | Supporting project | console |
| [12_oop/oop_demo](12_oop/oop_demo/oop_demo.csproj) | Supporting project | console |
| [12_oop/oop_lab](12_oop/oop_lab/oop_lab.csproj) | Supporting project | console |
| [23_searching_sorting/search_sort_demo](23_searching_sorting/search_sort_demo/search_sort_demo.csproj) | Supporting project | console |
| [10_classes/enum_demo](10_classes/enum_demo/enum_demo.csproj) | Supporting project | console |
| [06_exceptions_testing/exceptions_demo](06_exceptions_testing/exceptions_demo/exceptions_demo.csproj) | Supporting project | console |
| [06_exceptions_testing/math_tests/math_app](06_exceptions_testing/math_tests/math_app/math_app.csproj) | Supporting project | library |
| [06_exceptions_testing/math_tests/math_app_test](06_exceptions_testing/math_tests/math_app_test/math_app_test.csproj) | Supporting project | test |
| [06_exceptions_testing/math_lab/math_app](06_exceptions_testing/math_lab/math_app/math_app.csproj) | Supporting project | console |
| [06_exceptions_testing/math_lab/math_app_test](06_exceptions_testing/math_lab/math_app_test/math_app_test.csproj) | Supporting project | test |
| [_extras/one_hour_of_code](_extras/one_hour_of_code/one_hour_of_code.csproj) | Supporting project | console |
| [_extras/contact_demo](_extras/contact_demo/contact_demo.csproj) | Supporting project | console |
| [_extras/console_input_introcs](_extras/console_input_introcs/console_input_introcs.csproj) | Supporting project | library |
| [_extras/console_input_intro_cscs](_extras/console_input_intro_cscs/console_input_intro_cscs.csproj) | Supporting project | library |
| [11_object_design/object_design](11_object_design/object_design/ObjectDesign.csproj) | Supporting project | console |
| [12_oop/policy_design](12_oop/policy_design/PolicyDesign.csproj) | Supporting project | console |
| [16_searching_sorting/search_sort](16_searching_sorting/search_sort/BasicSearchSort.csproj) | Searching and insertion-sort reference checks | console |
| [18_priority_queues/priority_queue](18_priority_queues/priority_queue/HeapChecks.csproj) | Generic heap reference checks | console |
| [19_hash_collections/hash_collections](19_hash_collections/hash_collections/HashChecks.csproj) | Chained map and set reference checks | console |
| [20_graphs/graph_traversal](20_graphs/graph_traversal/GraphChecks.csproj) | Core BFS DFS path and component checks | console |
| [05_methods/loop_methods_demo](05_methods/loop_methods_demo/loop_methods_demo.csproj) | Supporting project | console |

Other numbered folders retain the chapter-specific source examples documented
in their existing READMEs or chapter `MATERIALS.md` files. The table above
covers the former `demos/` collection, not every source file in the book.

## Verify the Demos

```bash
python3 scripts/verify_demos.py
```

The verifier builds all 33 mapped projects plus a behavior-check project with
compiler warnings treated as errors, runs every console demo with documented
input, checks additional decision/game/sorting modes, and runs both MSTest
suites. The behavior checks compare sorting and searching against independent
reference results and exercise array algorithms, paragraph parsing at EOF,
input validation, factorials, and shape areas. Requires Python 3 and the .NET 10 SDK.
The first run restores the existing MSTest packages from NuGet; subsequent runs
can use `python3 scripts/verify_demos.py --no-restore`.

Both arithmetic test projects now pass normally. To practice finding a defect,
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
