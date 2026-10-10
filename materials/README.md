# Runnable C# Materials

The chapter demos use the **.NET 10 SDK** and target `net10.0`. Source files
are grouped under the current two-digit chapter number. `_extras/` contains
cross-chapter demonstrations and reusable helper libraries; `_archived/`
contains retired source material.

From the repository root, build and run a demo with its project path:

```bash
dotnet build materials/01/hello_world/HelloWorld.csproj
dotnet run --project materials/01/hello_world/HelloWorld.csproj
```

Alternatively, open the demo folder in VS Code and run `dotnet run` from
that folder's terminal. Read each demo's README for console input and run modes.
File demos copy their data to the build output and locate it relative to the
executable, so they also work when run from the repository root.

## Demo Projects

| Project | Purpose | Kind |
| --- | --- | --- |
| [01/hello_world](01/hello_world/HelloWorld.csproj) | First console application | console |
| [02/input](02/input/input.csproj) | Console input, parsing, and range validation | console |
| [02/output](02/output/output.csproj) | Interview appointment output | console |
| [03/methods_demo](03/methods_demo/methods_demo.csproj) | Method calls, parameters, and return values | console |
| [04/conditional_demo](04/conditional_demo/conditional_demo.csproj) | Conditional statements | console |
| [05/for_loop_demo](05/for_loop_demo/for_loop_demo.csproj) | For loops and string helpers | console |
| [05/while_loop_demo](05/while_loop_demo/while_loop_demo.csproj) | While loops and a number guessing game | console |
| [10/file_demo](10/file_demo/file_demo.csproj) | Read a bundled file of integers | console |
| [08/arrays_demo](08/arrays_demo/arrays_demo.csproj) | Command-line arrays, rectangular arrays, and jagged arrays | console |
| [08/array_lab](08/array_lab/array_lab.csproj) | Completed array lab algorithms | console |
| [09/collections_demo](09/collections_demo/collections_demo.csproj) | List construction and sorting | console |
| [09/help_responses](09/help_responses/help_responses.csproj) | Dictionary-based help response simulation | console |
| [12/classes_demo](12/classes_demo/classes_demo.csproj) | Class instances and methods | console |
| [12/classes_lab](12/classes_lab/classes_lab.csproj) | Animal/employee objects and instance versus static guessing games | console |
| [13/oop_demo](13/oop_demo/oop_demo.csproj) | Encapsulation, inheritance, overloading, shapes, and interfaces | console |
| [13/oop_lab](13/oop_lab/oop_lab.csproj) | Bank-account encapsulation demonstration | console |
| [22/search_sort_demo](22/search_sort_demo/search_sort_demo.csproj) | Linear/binary search and sort timing extensions | console |
| [12/enum_demo](12/enum_demo/enum_demo.csproj) | Enum values and their integer representation | console |
| [06/exceptions_demo](06/exceptions_demo/exceptions_demo.csproj) | Caught exception demonstration | console |
| [06/math_tests/math_app](06/math_tests/math_app/math_app.csproj) | Basic arithmetic library | library |
| [06/math_tests/math_app_test](06/math_tests/math_app_test/math_app_test.csproj) | Unit tests for the arithmetic library | test |
| [06/math_lab/math_app](06/math_lab/math_app/math_app.csproj) | Arithmetic console demonstration | console |
| [06/math_lab/math_app_test](06/math_lab/math_app_test/math_app_test.csproj) | Unit tests for the arithmetic lab | test |
| [_extras/one_hour_of_code](_extras/one_hour_of_code/one_hour_of_code.csproj) | Introductory C# walkthrough | console |
| [_extras/contact_demo](_extras/contact_demo/contact_demo.csproj) | Calling an instance method | console |
| [_extras/console_input_introcs](_extras/console_input_introcs/console_input_introcs.csproj) | Reusable IntroCS console input helper | library |
| [_extras/console_input_intro_cscs](_extras/console_input_intro_cscs/console_input_intro_cscs.csproj) | Reusable IntroCSCS console input helper | library |

Other numbered folders retain the chapter-specific source examples documented
in their existing READMEs or chapter `MATERIALS.md` files. The table above
covers the former `demos/` collection, not every source file in the book.

## Verify the Demos

```bash
python3 materials/verify_demos.py
```

The verifier builds all 27 migrated projects plus a behavior-check project with
compiler warnings treated as errors, runs every console demo with documented
input, checks additional decision/game/sorting modes, and runs both MSTest
suites. The behavior checks compare sorting and searching against independent
reference results and exercise array algorithms, paragraph parsing at EOF,
input validation, factorials, and shape areas. Requires Python 3 and the .NET 10 SDK.
The first run restores the existing MSTest packages from NuGet; subsequent runs
can use `python3 materials/verify_demos.py --no-restore`.

Both arithmetic test projects now pass normally. To practice finding a defect,
change `Multiply` from `num1 * num2` to `num1 + num2`, run `dotnet test`, inspect
the failing multiplication test, then restore the multiplication operator.

## Former Demo Paths

The following source paths were migrated without changing any published
notebook URLs. They were not linked from the student book.

| Former path under `materials/demos/` | Current path under `materials/` |
| --- | --- |
| `Ch01Intro/HelloWorld/` | `01/hello_world/` |
| `Ch02DataVariable/Input/` | `02/input/` |
| `Ch02DataVariable/Ouput/` | `02/output/` |
| `Ch03Method/` | `03/methods_demo/` |
| `Ch04Conditional/` | `04/conditional_demo/` |
| `Ch05ForLoop/` | `05/for_loop_demo/` |
| `Ch06WhileLoop/` | `05/while_loop_demo/` |
| `Ch07File/` | `10/file_demo/` |
| `Ch08Arrays/` | `08/arrays_demo/` |
| `Ch08ArraysLab/` | `08/array_lab/` |
| `Ch09Collections/` | `09/collections_demo/` |
| `Ch09CollectionsLab/` | `09/help_responses/` |
| `Ch10Classes/` | `12/classes_demo/` |
| `Ch10ClassesLab/` | `12/classes_lab/` |
| `Ch11OOP/` | `13/oop_demo/` |
| `Ch11OOPLab/` | `13/oop_lab/` |
| `Ch12DataStructure/` | `22/search_sort_demo/` |
| `Ch13Enum/` | `12/enum_demo/` |
| `Ch13SelectedTopics/Exceptions/` | `06/exceptions_demo/` |
| `Ch13SelectedTopics/UnitTestProject1/` | `06/math_tests/` |
| `Ch13SelectedTopicsLab/UnitTestProject1/` | `06/math_lab/` |
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

See [Instructor Support](../assignments/instructor_support/README.md) for
lesson mappings, walkthroughs, expected outputs, exact assignment solutions,
and identified gaps. A demo project is not automatically an assignment answer;
older projects named `lab` are explicitly labeled where no current match exists.
