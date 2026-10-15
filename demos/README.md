# Runnable C# Demos and Supporting Code

The chapter demos use the **.NET 10 SDK** and target `net10.0`. Source files
are grouped under the current two-digit chapter number. `_extras/` contains
cross-chapter demonstrations and reusable helper libraries; `_archived/`
contains retired source material.

From the repository root, build and run a demo with its project path:

```bash
dotnet build demos/01/hello_world/HelloWorld.csproj
dotnet run --project demos/01/hello_world/HelloWorld.csproj
```

Alternatively, open the demo folder in VS Code and run `dotnet run` from
that folder's terminal. Read each demo's README for console input and run modes.
File demos copy their data to the build output and locate it relative to the
executable, so they also work when run from the repository root.

## Demo Projects

| Project                                                                                             | Purpose                                                           | Kind    |
| --------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------- | ------- |
| [01/hello_world](01/hello_world/HelloWorld.csproj) | Supporting project | console |
| [02/input](02/input/input.csproj) | Supporting project | console |
| [02/output](02/output/output.csproj) | Supporting project | console |
| [03/methods_demo](03/methods_demo/methods_demo.csproj) | Supporting project | console |
| [04/conditional_demo](04/conditional_demo/conditional_demo.csproj) | Supporting project | console |
| [05/for_loop_demo](05/for_loop_demo/for_loop_demo.csproj) | Supporting project | console |
| [05/while_loop_demo](05/while_loop_demo/while_loop_demo.csproj) | Supporting project | console |
| [10/file_demo](09/file_demo/file_demo.csproj) | Supporting project | console |
| [08/arrays_demo](07/arrays_demo/arrays_demo.csproj) | Supporting project | console |
| [08/array_lab](07/array_lab/array_lab.csproj) | Supporting project | console |
| [09/collections_demo](08/collections_demo/collections_demo.csproj) | Supporting project | console |
| [09/help_responses](08/help_responses/help_responses.csproj) | Supporting project | console |
| [11/classes_demo](10/classes_demo/classes_demo.csproj) | Supporting project | console |
| [11/classes_lab](10/classes_lab/classes_lab.csproj) | Supporting project | console |
| [13/oop_demo](12/oop_demo/oop_demo.csproj) | Supporting project | console |
| [13/oop_lab](12/oop_lab/oop_lab.csproj) | Supporting project | console |
| [24/search_sort_demo](23/search_sort_demo/search_sort_demo.csproj) | Supporting project | console |
| [11/enum_demo](10/enum_demo/enum_demo.csproj) | Supporting project | console |
| [06/exceptions_demo](06/exceptions_demo/exceptions_demo.csproj) | Supporting project | console |
| [06/math_tests/math_app](06/math_tests/math_app/math_app.csproj) | Supporting project | library |
| [06/math_tests/math_app_test](06/math_tests/math_app_test/math_app_test.csproj) | Supporting project | test |
| [06/math_lab/math_app](06/math_lab/math_app/math_app.csproj) | Supporting project | console |
| [06/math_lab/math_app_test](06/math_lab/math_app_test/math_app_test.csproj) | Supporting project | test |
| [_extras/one_hour_of_code](_extras/one_hour_of_code/one_hour_of_code.csproj) | Supporting project | console |
| [_extras/contact_demo](_extras/contact_demo/contact_demo.csproj) | Supporting project | console |
| [_extras/console_input_introcs](_extras/console_input_introcs/console_input_introcs.csproj) | Supporting project | library |
| [_extras/console_input_intro_cscs](_extras/console_input_intro_cscs/console_input_intro_cscs.csproj) | Supporting project | library |
| [12/object_design](11/object_design/ObjectDesign.csproj) | Supporting project | console |
| [13/policy_design](12/policy_design/PolicyDesign.csproj) | Supporting project | console |
| [17/search_sort](16/search_sort/BasicSearchSort.csproj) | Searching and insertion-sort reference checks | console |
| [19/priority_queue](18/priority_queue/HeapChecks.csproj) | Generic heap reference checks | console |
| [20/hash_collections](19/hash_collections/HashChecks.csproj) | Chained map and set reference checks | console |
| [21/graph_traversal](20/graph_traversal/GraphChecks.csproj) | Core BFS DFS path and component checks | console |

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

| Former path under `materials/demos/`       | Current path under`demos/`           |
| ------------------------------------------- | ------------------------------------------ |
| `Ch01Intro/HelloWorld/`                   | `01/hello_world/`                        |
| `Ch02DataVariable/Input/`                 | `02/input/`                              |
| `Ch02DataVariable/Ouput/`                 | `02/output/`                             |
| `Ch03Method/`                             | `03/methods_demo/`                       |
| `Ch04Conditional/`                        | `04/conditional_demo/`                   |
| `Ch05ForLoop/`                            | `05/for_loop_demo/`                      |
| `Ch06WhileLoop/`                          | `05/while_loop_demo/`                    |
| `Ch07File/`                               | `10/file_demo/`                          |
| `Ch08Arrays/`                             | `08/arrays_demo/`                        |
| `Ch08ArraysLab/`                          | `08/array_lab/`                          |
| `Ch09Collections/`                        | `09/collections_demo/`                   |
| `Ch09CollectionsLab/`                     | `09/help_responses/`                     |
| `Ch10Classes/`                            | `11/classes_demo/`                       |
| `Ch10ClassesLab/`                         | `11/classes_lab/`                        |
| `Ch11OOP/`                                | `13/oop_demo/`                           |
| `Ch11OOPLab/`                             | `13/oop_lab/`                            |
| `Ch12DataStructure/`                      | `24/search_sort_demo/`                   |
| `Ch13Enum/`                               | `11/enum_demo/`                          |
| `Ch13SelectedTopics/Exceptions/`          | `06/exceptions_demo/`                    |
| `Ch13SelectedTopics/UnitTestProject1/`    | `06/math_tests/`                         |
| `Ch13SelectedTopicsLab/UnitTestProject1/` | `06/math_lab/`                           |
| `OneHourOfCode/`                          | `_extras/one_hour_of_code/`              |
| `final/`                                  | `_extras/contact_demo/`                  |
| `ui/`                                     | `_extras/console_input_introcs/`         |
| `ui.cs`                                   | `_extras/console_input_intro_cscs/ui.cs` |

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

`12/object_design/` supplies the order collaboration model and boundary checks. `13/policy_design/` supplies interface/override model checks. Both are .NET 10 console projects without package dependencies; see their READMEs for run commands.

## Chapter 10 Assignment Starter

[`11/coffee_register_starter`](10/coffee_register_starter/README.md) matches the final stage of the current coffee-register lab. It intentionally leaves ToString unfinished. The notebook hidden answer cells provide the canonical solution and expected output; the animal/guessing-game `classes_lab` project remains supplementary.

## Chapter 2 Assignment Starter

[`02/order_invoice_starter`](02/order_invoice_starter/README.md) matches the final stage of the office-supply Lab. Students complete its input, calculations, and report. The notebook answer cells contain the canonical solution and expected output.
