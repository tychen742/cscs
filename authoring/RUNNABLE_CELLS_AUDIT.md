# Runnable Cell Audit

Generated 2026-10-04 by compiling every runnable code cell (cells tagged `no-run` and setup-only cells excluded) through the local execution runner, one cell at a time, exactly as the browser Run button sends it.

Runnable cells checked: 765. Failing: 188.

| Group | Cause | Cells |
|---|---|---|
| A | Declares types only, no code to run (CS5001) | 65 |
| B | Classes declared before the code that uses them (CS8803) | 42 |
| C | Uses a variable, method, or type from an earlier cell (CS0103/CS0246) | 42 |
| D | Syntax errors and fragments | 31 |
| E | Runtime exception | 6 |
| F | Timed out (15 s) | 2 |

## A. Declares types only, no code to run (CS5001)

| File | Cell | First error | First line |
|---|---|---|---|
| [05_methods/0503_parameter.ipynb](chapters/05_methods/0503_parameter.ipynb) | 9 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `public static void inchesToCentimeters(double i)    // parameter with type` |
| [06_exceptions_testing/0603_testing.ipynb](chapters/06_exceptions_testing/0603_testing.ipynb) | 7 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `public class BasicMaths` |
| [12_classes/1204_operator_overloading.ipynb](chapters/12_classes/1204_operator_overloading.ipynb) | 6 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `public struct SomeMath` |
| [12_classes/assignments/homework.ipynb](chapters/12_classes/assignments/homework.ipynb) | 1 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `class DoMath` |
| [12_classes/assignments/homework.ipynb](chapters/12_classes/assignments/homework.ipynb) | 3 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `static class SomeMath` |
| [12_classes/assignments/homework.ipynb](chapters/12_classes/assignments/homework.ipynb) | 5 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `class Customer` |
| [12_oop/1305_abstraction.ipynb](chapters/12_oop/1305_abstraction.ipynb) | 4 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `abstract class Shape` |
| [12_oop/1305_abstraction.ipynb](chapters/12_oop/1305_abstraction.ipynb) | 16 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `abstract class Shape` |
| [12_oop/1305_abstraction.ipynb](chapters/12_oop/1305_abstraction.ipynb) | 18 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `interface Animal` |
| [13_abstract_data_types/assignments/homework.ipynb](chapters/13_abstract_data_types/assignments/homework.ipynb) | 4 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// 1. Write a generic IQueue<T> interface with Count, Enqueue, Dequeue, and Peek.` |
| [13_abstract_data_types/assignments/homework.ipynb](chapters/13_abstract_data_types/assignments/homework.ipynb) | 5 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `interface IQueue<T>` |
| [13_abstract_data_types/assignments/lab.ipynb](chapters/13_abstract_data_types/assignments/lab.ipynb) | 2 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Define IStack<T> here.` |
| [13_abstract_data_types/assignments/lab.ipynb](chapters/13_abstract_data_types/assignments/lab.ipynb) | 3 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `interface IStack<T>` |
| [13_abstract_data_types/assignments/lab.ipynb](chapters/13_abstract_data_types/assignments/lab.ipynb) | 14 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// List-backed stack:` |
| [14_arrays_linked_lists/assignments/lab.ipynb](chapters/14_arrays_linked_lists/assignments/lab.ipynb) | 8 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `class Node<T>` |
| [15_stacks_queues/assignments/homework.ipynb](chapters/15_stacks_queues/assignments/homework.ipynb) | 2 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [15_stacks_queues/assignments/homework.ipynb](chapters/15_stacks_queues/assignments/homework.ipynb) | 4 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [15_stacks_queues/assignments/homework.ipynb](chapters/15_stacks_queues/assignments/homework.ipynb) | 6 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [15_stacks_queues/assignments/homework.ipynb](chapters/15_stacks_queues/assignments/homework.ipynb) | 8 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [15_stacks_queues/assignments/homework.ipynb](chapters/15_stacks_queues/assignments/homework.ipynb) | 10 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [17_trees/assignments/homework.ipynb](chapters/17_trees/assignments/homework.ipynb) | 2 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [17_trees/assignments/homework.ipynb](chapters/17_trees/assignments/homework.ipynb) | 4 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [17_trees/assignments/homework.ipynb](chapters/17_trees/assignments/homework.ipynb) | 6 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [17_trees/assignments/homework.ipynb](chapters/17_trees/assignments/homework.ipynb) | 8 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [17_trees/assignments/homework.ipynb](chapters/17_trees/assignments/homework.ipynb) | 10 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [18_heaps_hash_tables/assignments/homework.ipynb](chapters/18_heaps_hash_tables/assignments/homework.ipynb) | 2 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [18_heaps_hash_tables/assignments/homework.ipynb](chapters/18_heaps_hash_tables/assignments/homework.ipynb) | 4 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [18_heaps_hash_tables/assignments/homework.ipynb](chapters/18_heaps_hash_tables/assignments/homework.ipynb) | 6 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [18_heaps_hash_tables/assignments/homework.ipynb](chapters/18_heaps_hash_tables/assignments/homework.ipynb) | 8 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [18_heaps_hash_tables/assignments/homework.ipynb](chapters/18_heaps_hash_tables/assignments/homework.ipynb) | 10 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [19_graphs/assignments/homework.ipynb](chapters/19_graphs/assignments/homework.ipynb) | 2 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [19_graphs/assignments/homework.ipynb](chapters/19_graphs/assignments/homework.ipynb) | 4 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [19_graphs/assignments/homework.ipynb](chapters/19_graphs/assignments/homework.ipynb) | 6 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [19_graphs/assignments/homework.ipynb](chapters/19_graphs/assignments/homework.ipynb) | 8 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [19_graphs/assignments/homework.ipynb](chapters/19_graphs/assignments/homework.ipynb) | 10 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [20_algorithm_analysis/assignments/homework.ipynb](chapters/20_algorithm_analysis/assignments/homework.ipynb) | 2 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [20_algorithm_analysis/assignments/homework.ipynb](chapters/20_algorithm_analysis/assignments/homework.ipynb) | 4 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [20_algorithm_analysis/assignments/homework.ipynb](chapters/20_algorithm_analysis/assignments/homework.ipynb) | 6 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [20_algorithm_analysis/assignments/homework.ipynb](chapters/20_algorithm_analysis/assignments/homework.ipynb) | 8 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [20_algorithm_analysis/assignments/homework.ipynb](chapters/20_algorithm_analysis/assignments/homework.ipynb) | 10 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [21_recursion_divide_conquer/assignments/homework.ipynb](chapters/21_recursion_divide_conquer/assignments/homework.ipynb) | 2 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [21_recursion_divide_conquer/assignments/homework.ipynb](chapters/21_recursion_divide_conquer/assignments/homework.ipynb) | 4 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [21_recursion_divide_conquer/assignments/homework.ipynb](chapters/21_recursion_divide_conquer/assignments/homework.ipynb) | 6 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [21_recursion_divide_conquer/assignments/homework.ipynb](chapters/21_recursion_divide_conquer/assignments/homework.ipynb) | 8 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [21_recursion_divide_conquer/assignments/homework.ipynb](chapters/21_recursion_divide_conquer/assignments/homework.ipynb) | 10 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [22_searching_sorting/assignments/homework.ipynb](chapters/22_searching_sorting/assignments/homework.ipynb) | 2 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [22_searching_sorting/assignments/homework.ipynb](chapters/22_searching_sorting/assignments/homework.ipynb) | 4 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [22_searching_sorting/assignments/homework.ipynb](chapters/22_searching_sorting/assignments/homework.ipynb) | 6 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [22_searching_sorting/assignments/homework.ipynb](chapters/22_searching_sorting/assignments/homework.ipynb) | 8 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [22_searching_sorting/assignments/homework.ipynb](chapters/22_searching_sorting/assignments/homework.ipynb) | 10 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [23_greedy_graph_optimization/assignments/homework.ipynb](chapters/23_greedy_graph_optimization/assignments/homework.ipynb) | 2 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [23_greedy_graph_optimization/assignments/homework.ipynb](chapters/23_greedy_graph_optimization/assignments/homework.ipynb) | 4 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [23_greedy_graph_optimization/assignments/homework.ipynb](chapters/23_greedy_graph_optimization/assignments/homework.ipynb) | 6 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [23_greedy_graph_optimization/assignments/homework.ipynb](chapters/23_greedy_graph_optimization/assignments/homework.ipynb) | 8 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [23_greedy_graph_optimization/assignments/homework.ipynb](chapters/23_greedy_graph_optimization/assignments/homework.ipynb) | 10 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [24_dynamic_programming_backtracking/assignments/homework.ipynb](chapters/24_dynamic_programming_backtracking/assignments/homework.ipynb) | 2 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [24_dynamic_programming_backtracking/assignments/homework.ipynb](chapters/24_dynamic_programming_backtracking/assignments/homework.ipynb) | 4 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [24_dynamic_programming_backtracking/assignments/homework.ipynb](chapters/24_dynamic_programming_backtracking/assignments/homework.ipynb) | 6 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [24_dynamic_programming_backtracking/assignments/homework.ipynb](chapters/24_dynamic_programming_backtracking/assignments/homework.ipynb) | 8 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [24_dynamic_programming_backtracking/assignments/homework.ipynb](chapters/24_dynamic_programming_backtracking/assignments/homework.ipynb) | 10 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [25_advanced_graphs_strings_limits/assignments/homework.ipynb](chapters/25_advanced_graphs_strings_limits/assignments/homework.ipynb) | 2 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [25_advanced_graphs_strings_limits/assignments/homework.ipynb](chapters/25_advanced_graphs_strings_limits/assignments/homework.ipynb) | 4 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [25_advanced_graphs_strings_limits/assignments/homework.ipynb](chapters/25_advanced_graphs_strings_limits/assignments/homework.ipynb) | 6 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [25_advanced_graphs_strings_limits/assignments/homework.ipynb](chapters/25_advanced_graphs_strings_limits/assignments/homework.ipynb) | 8 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [25_advanced_graphs_strings_limits/assignments/homework.ipynb](chapters/25_advanced_graphs_strings_limits/assignments/homework.ipynb) | 10 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |

## B. Classes declared before the code that uses them (CS8803)

| File | Cell | First error | First line |
|---|---|---|---|
| [02_var_data/0202_data_types.ipynb](chapters/02_var_data/0202_data_types.ipynb) | 7 | CS8803 (line 9): Top-level statements must precede namespace and type declarations. | `// Preview of 'class' syntax (full treatment in Chapter 11) — used here` |
| [04_iteration/0401_iteration.ipynb](chapters/04_iteration/0401_iteration.ipynb) | 3 | CS8803 (line 26): Top-level statements must precede namespace and type declarations. | `using System;` |
| [06_exceptions_testing/0604_nullable.ipynb](chapters/11_object_design/1104_nullability.ipynb) | 10 | CS8803 (line 5): Top-level statements must precede namespace and type declarations. | `record Order(string? CustomerName, Address? ShippingAddress);` |
| [11_databases/1104_records.ipynb](chapters/11_databases/1104_records.ipynb) | 5 | CS8803 (line 4): Top-level statements must precede namespace and type declarations. | `record Point(int X, int Y);` |
| [11_databases/1104_records.ipynb](chapters/11_databases/1104_records.ipynb) | 7 | CS8803 (line 4): Top-level statements must precede namespace and type declarations. | `record Person(string Name, int Age);` |
| [11_databases/1104_records.ipynb](chapters/11_databases/1104_records.ipynb) | 9 | CS8803 (line 4): Top-level statements must precede namespace and type declarations. | `record Point(int X, int Y);` |
| [11_databases/1104_records.ipynb](chapters/11_databases/1104_records.ipynb) | 13 | CS8803 (line 8): Top-level statements must precede namespace and type declarations. | `record Person` |
| [13_abstract_data_types/1301_adt_contracts.ipynb](chapters/13_abstract_data_types/1301_adt_contracts.ipynb) | 5 | CS8803 (line 33): Top-level statements must precede namespace and type declarations. | `interface IStack<T>` |
| [13_abstract_data_types/1302_representations_costs.ipynb](chapters/13_abstract_data_types/1302_representations_costs.ipynb) | 5 | CS8803 (line 24): Top-level statements must precede namespace and type declarations. | `class ArrayStack<T>` |
| [13_abstract_data_types/1302_representations_costs.ipynb](chapters/13_abstract_data_types/1302_representations_costs.ipynb) | 8 | CS8803 (line 14): Top-level statements must precede namespace and type declarations. | `class Node<T>` |
| [13_abstract_data_types/1303_generics.ipynb](chapters/13_abstract_data_types/1303_generics.ipynb) | 5 | CS8803 (line 12): Top-level statements must precede namespace and type declarations. | `// A minimal generic cell ADT` |
| [13_abstract_data_types/1304_iterators.ipynb](chapters/13_abstract_data_types/1304_iterators.ipynb) | 6 | CS8803 (line 24): Top-level statements must precede namespace and type declarations. | `class NumberRange : IEnumerable<int>` |
| [13_abstract_data_types/assignments/homework.ipynb](chapters/13_abstract_data_types/assignments/homework.ipynb) | 6 | CS8803 (line 18): Top-level statements must precede namespace and type declarations. | `// 2. Complete a generic Cell<T> class with Get and Set methods.` |
| [13_abstract_data_types/assignments/homework.ipynb](chapters/13_abstract_data_types/assignments/homework.ipynb) | 7 | CS8803 (line 15): Top-level statements must precede namespace and type declarations. | `class Cell<T>` |
| [13_abstract_data_types/assignments/homework.ipynb](chapters/13_abstract_data_types/assignments/homework.ipynb) | 8 | CS8803 (line 16): Top-level statements must precede namespace and type declarations. | `// 3. Trace this linked structure by hand before running it.` |
| [13_abstract_data_types/assignments/lab.ipynb](chapters/13_abstract_data_types/assignments/lab.ipynb) | 5 | CS8803 (line 23): Top-level statements must precede namespace and type declarations. | `interface IStack<T>` |
| [13_abstract_data_types/assignments/lab.ipynb](chapters/13_abstract_data_types/assignments/lab.ipynb) | 6 | CS8803 (line 20): Top-level statements must precede namespace and type declarations. | `interface IStack<T>` |
| [13_abstract_data_types/assignments/lab.ipynb](chapters/13_abstract_data_types/assignments/lab.ipynb) | 8 | CS8803 (line 31): Top-level statements must precede namespace and type declarations. | `interface IStack<T>` |
| [13_abstract_data_types/assignments/lab.ipynb](chapters/13_abstract_data_types/assignments/lab.ipynb) | 9 | CS8803 (line 32): Top-level statements must precede namespace and type declarations. | `interface IStack<T>` |
| [13_abstract_data_types/assignments/lab.ipynb](chapters/13_abstract_data_types/assignments/lab.ipynb) | 13 | CS8803 (line 32): Top-level statements must precede namespace and type declarations. | `interface IStack<T>` |
| [14_arrays_linked_lists/1402_linked_nodes.ipynb](chapters/14_arrays_linked_lists/1402_linked_nodes.ipynb) | 3 | CS8803 (line 13): Top-level statements must precede namespace and type declarations. | `public sealed class IntroNode<T>` |
| [14_arrays_linked_lists/1402_linked_nodes.ipynb](chapters/14_arrays_linked_lists/1402_linked_nodes.ipynb) | 6 | CS8803 (line 9): Top-level statements must precede namespace and type declarations. | `public sealed class TraversalNode<T>` |
| [14_arrays_linked_lists/1402_linked_nodes.ipynb](chapters/14_arrays_linked_lists/1402_linked_nodes.ipynb) | 9 | CS8803 (line 9): Top-level statements must precede namespace and type declarations. | `public sealed class InsertNode<T>` |
| [14_arrays_linked_lists/1402_linked_nodes.ipynb](chapters/14_arrays_linked_lists/1402_linked_nodes.ipynb) | 13 | CS8803 (line 9): Top-level statements must precede namespace and type declarations. | `public sealed class DeleteNode<T>` |
| [14_arrays_linked_lists/1403_comparison_lab.ipynb](chapters/14_arrays_linked_lists/1403_comparison_lab.ipynb) | 6 | CS8803 (line 9): Top-level statements must precede namespace and type declarations. | `public sealed class Node<T>` |
| [14_arrays_linked_lists/assignments/homework.ipynb](chapters/14_arrays_linked_lists/assignments/homework.ipynb) | 6 | CS8803 (line 11): Top-level statements must precede namespace and type declarations. | `// 2. Write CountNodes for a linked chain.` |
| [14_arrays_linked_lists/assignments/homework.ipynb](chapters/14_arrays_linked_lists/assignments/homework.ipynb) | 7 | CS8803 (line 9): Top-level statements must precede namespace and type declarations. | `class CountNode<T>` |
| [14_arrays_linked_lists/assignments/lab.ipynb](chapters/14_arrays_linked_lists/assignments/lab.ipynb) | 2 | CS8803 (line 16): Top-level statements must precede namespace and type declarations. | `class SmallArray` |
| [14_arrays_linked_lists/assignments/lab.ipynb](chapters/14_arrays_linked_lists/assignments/lab.ipynb) | 3 | CS8803 (line 16): Top-level statements must precede namespace and type declarations. | `class SmallArray` |
| [14_arrays_linked_lists/assignments/lab.ipynb](chapters/14_arrays_linked_lists/assignments/lab.ipynb) | 5 | CS8803 (line 23): Top-level statements must precede namespace and type declarations. | `class DynamicArray` |
| [14_arrays_linked_lists/assignments/lab.ipynb](chapters/14_arrays_linked_lists/assignments/lab.ipynb) | 6 | CS8803 (line 23): Top-level statements must precede namespace and type declarations. | `class DynamicArray` |
| [14_arrays_linked_lists/assignments/lab.ipynb](chapters/14_arrays_linked_lists/assignments/lab.ipynb) | 9 | CS8803 (line 9): Top-level statements must precede namespace and type declarations. | `class Node<T>` |
| [14_arrays_linked_lists/assignments/lab.ipynb](chapters/14_arrays_linked_lists/assignments/lab.ipynb) | 12 | CS8803 (line 9): Top-level statements must precede namespace and type declarations. | `class LinkNode<T>` |
| [14_arrays_linked_lists/assignments/lab.ipynb](chapters/14_arrays_linked_lists/assignments/lab.ipynb) | 13 | CS8803 (line 9): Top-level statements must precede namespace and type declarations. | `class LinkNode<T>` |
| [14-functional-patterns/assignments/lab.ipynb](chapters/14-functional-patterns/assignments/lab.ipynb) | 4 | CS8803 (line 4): Top-level statements must precede namespace and type declarations. | `record Product(string Name, string Category, double Price);` |
| [15-pattern-records/assignments/lab-solutions.ipynb](chapters/15-pattern-records/assignments/lab-solutions.ipynb) | 4 | CS8803 (line 7): Top-level statements must precede namespace and type declarations. | `record Temperature(double Celsius)` |
| [15-pattern-records/assignments/lab-solutions.ipynb](chapters/15-pattern-records/assignments/lab-solutions.ipynb) | 6 | CS8803 (line 7): Top-level statements must precede namespace and type declarations. | `abstract record Shape;` |
| [15-pattern-records/assignments/lab.ipynb](chapters/15-pattern-records/assignments/lab.ipynb) | 4 | CS8803 (line 7): Top-level statements must precede namespace and type declarations. | `record Temperature(double Celsius)` |
| [16-generics-async/assignments/lab-solutions.ipynb](chapters/16-generics-async/assignments/lab-solutions.ipynb) | 2 | CS8803 (line 13): Top-level statements must precede namespace and type declarations. | `static int SafeParse(string? input)` |
| [16-generics-async/assignments/lab-solutions.ipynb](chapters/16-generics-async/assignments/lab-solutions.ipynb) | 4 | CS8803 (line 29): Top-level statements must precede namespace and type declarations. | `static T[] Repeat<T>(T value, int count)` |
| [16-generics-async/assignments/lab.ipynb](chapters/16-generics-async/assignments/lab.ipynb) | 2 | CS8803 (line 14): Top-level statements must precede namespace and type declarations. | `static int SafeParse(string? input)` |
| [16-generics-async/assignments/lab.ipynb](chapters/16-generics-async/assignments/lab.ipynb) | 4 | CS8803 (line 31): Top-level statements must precede namespace and type declarations. | `static T[] Repeat<T>(T value, int count)` |

## C. Uses a variable, method, or type from an earlier cell (CS0103/CS0246)

| File | Cell | First error | First line |
|---|---|---|---|
| [02_var_data/0201_variables.ipynb](chapters/02_var_data/0201_variables.ipynb) | 6 | CS0246 (line 2): The type or namespace name 'type' could not be found (are you missing a u | `type variableName = value;` |
| [02_var_data/0202_data_types.ipynb](chapters/02_var_data/0202_data_types.ipynb) | 35 | CS0165 (line 16): Use of unassigned local variable 'message1' | `#pragma warning disable CS8632` |
| [02_var_data/0206_input_output.ipynb](chapters/02_var_data/0206_input_output.ipynb) | 12 | CS0103 (line 2): The name 'a' does not exist in the current context | `a = UI.PromptInt("Enter integer leg: ");` |
| [05_methods/assignments/homework.ipynb](chapters/05_methods/assignments/homework.ipynb) | 1 | CS0103 (line 2): The name 'Q1' does not exist in the current context | `double d = Q1(2, 5);` |
| [05_methods/assignments/homework.ipynb](chapters/05_methods/assignments/homework.ipynb) | 3 | CS0103 (line 2): The name 'Q4' does not exist in the current context | `Q4("hi");` |
| [05_methods/assignments/homework.ipynb](chapters/05_methods/assignments/homework.ipynb) | 7 | CS0103 (line 4): The name 'Q' does not exist in the current context | `static void Main()` |
| [05_methods/assignments/homework.ipynb](chapters/05_methods/assignments/homework.ipynb) | 9 | CS0103 (line 5): The name 'Q' does not exist in the current context | `static void Main()` |
| [05_methods/assignments/homework.ipynb](chapters/05_methods/assignments/homework.ipynb) | 12 | CS0103 (line 5): The name 'Q' does not exist in the current context | `static void Main()                   // 7` |
| [05_methods/assignments/lab.ipynb](chapters/05_methods/assignments/lab.ipynb) | 4 | CS0103 (line 2): The name 'F' does not exist in the current context | `Console.WriteLine(F(3));` |
| [05_methods/assignments/lab.ipynb](chapters/05_methods/assignments/lab.ipynb) | 8 | CS0103 (line 2): The name 'F' does not exist in the current context | `Console.WriteLine(F(3) + F(4));` |
| [05_methods/assignments/lab.ipynb](chapters/05_methods/assignments/lab.ipynb) | 10 | CS0103 (line 2): The name 'F' does not exist in the current context | `Console.WriteLine(9 + F(4));` |
| [03_decision/0301_intro_decision.ipynb](chapters/03_decision/0301_intro_decision.ipynb) | 8 | CS0103 (line 2): The name 'condition' does not exist in the current context | `if (condition)` |
| [03_decision/0302_ifstatement.ipynb](chapters/03_decision/0302_ifstatement.ipynb) | 8 | CS0103 (line 2): The name 'condition1' does not exist in the current context | `if (condition1)` |
| [03_decision/0306_switch.ipynb](chapters/03_decision/0306_switch.ipynb) | 3 | CS0103 (line 2): The name 'expression' does not exist in the current context | `switch(expression)` |
| [03_decision/assignments/homework.ipynb](chapters/03_decision/assignments/homework.ipynb) | 1 | CS0103 (line 2): The name 'IsBig' does not exist in the current context | `if (IsBig(x) == true)` |
| [03_decision/assignments/homework.ipynb](chapters/03_decision/assignments/homework.ipynb) | 3 | CS0103 (line 2): The name 'x' does not exist in the current context | `if (x > 0 && (y / x) == 3)` |
| [03_decision/assignments/homework.ipynb](chapters/03_decision/assignments/homework.ipynb) | 5 | CS0103 (line 2): The name 'x' does not exist in the current context | `if (x < 0)` |
| [03_decision/assignments/homework.ipynb](chapters/03_decision/assignments/homework.ipynb) | 7 | CS0103 (line 2): The name 'x' does not exist in the current context | `if (x > 7) {    //a` |
| [03_decision/assignments/homework.ipynb](chapters/03_decision/assignments/homework.ipynb) | 9 | CS0103 (line 2): The name 'y' does not exist in the current context | `y = 1;         //a` |
| [03_decision/assignments/homework.ipynb](chapters/03_decision/assignments/homework.ipynb) | 12 | CS0103 (line 2): The name 'x' does not exist in the current context | `if (x > 5)        //a` |
| [03_decision/assignments/lab.ipynb](chapters/03_decision/assignments/lab.ipynb) | 5 | CS0103 (line 2): The name 'UIF' does not exist in the current context | `string v = UIF.PromptLine("Enter a word: ");` |
| [03_decision/assignments/lab.ipynb](chapters/03_decision/assignments/lab.ipynb) | 7 | CS0103 (line 2): The name 'UIF' does not exist in the current context | `int x = UIF.PromptInt("Enter a integer: ");` |
| [03_decision/assignments/lab.ipynb](chapters/03_decision/assignments/lab.ipynb) | 10 | CS0103 (line 7): The name 'CalcWeeklyWages' does not exist in the current context | `// Calculate Wages` |
| [04_iteration/0402_for_statements.ipynb](chapters/04_iteration/0402_for_statements.ipynb) | 29 | CS0103 (line 2): The name 'x' does not exist in the current context | `x *= 5;` |
| [04_iteration/0402_for_statements.ipynb](chapters/04_iteration/0402_for_statements.ipynb) | 31 | CS0103 (line 2): The name 'x' does not exist in the current context | `x = x * 5;` |
| [04_iteration/0403_while_statement.ipynb](chapters/04_iteration/0403_while_statement.ipynb) | 38 | CS0103 (line 5): The name 'UI' does not exist in the current context | `int a, b, c;` |
| [04_iteration/assignments/lab.ipynb](chapters/04_iteration/assignments/lab.ipynb) | 46 | CS0103 (line 3): The name 'n' does not exist in the current context | `int sum = 1, i = 2;` |
| [06_exceptions_testing/0601_error_handling.ipynb](chapters/06_exceptions_testing/0601_error_handling.ipynb) | 10 | CS0841 (line 1): Cannot use local variable 'path' before it is declared | `string path = "scores.txt";` |
| [06_exceptions_testing/0603_testing.ipynb](chapters/06_exceptions_testing/0603_testing.ipynb) | 4 | CS0246 (line 8): The type or namespace name 'Calculator' could not be found (are you missi | `namespace IntroCSCS` |
| [07_arrays/assignments/lab.ipynb](chapters/07_arrays/assignments/lab.ipynb) | 3 | CS0103 (line 5): The name 'VectorDotProduct' does not exist in the current context | `double[] a = new double[] { 1.5, 2.0, 3.0 };` |
| [08_collections/0802-list-dictionary.ipynb](chapters/08_collections/0802-list-dictionary.ipynb) | 39 | CS0103 (line 3): The name 'MakeInt' does not exist in the current context | `List<int> digits = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };` |
| [08_collections/assignments/lab.ipynb](chapters/08_collections/assignments/lab.ipynb) | 6 | CS0103 (line 6): The name 'GetParagraphs' does not exist in the current context | `public static void Main(string[] args)` |
| [09_files_text/0902_file_operations.ipynb](chapters/09_files_text/0902_file_operations.ipynb) | 11 | CS0103 (line 10): The name 'UI' does not exist in the current context | `using System;` |
| [09_files_text/0902_file_operations.ipynb](chapters/09_files_text/0902_file_operations.ipynb) | 15 | CS0103 (line 2): The name 'reader' does not exist in the current context | `string wholeFile = reader.ReadToEnd();` |
| [09_files_text/0903_text_operations.ipynb](chapters/09_files_text/0903_text_operations.ipynb) | 29 | CS0103 (line 6): The name 'TryParseStudent' does not exist in the current context | `string[] records = { "Alice,98,CS", "Bob,abc,Math", "Carol,87,Physics", "" };` |
| [09_files_text/assignments/lab.ipynb](chapters/09_files_text/assignments/lab.ipynb) | 10 | CS0103 (line 2): The name 'reader' does not exist in the current context | `string contents = reader.ReadToEnd();` |
| [12_oop/1304_polymorphism.ipynb](chapters/12_oop/1304_polymorphism.ipynb) | 4 | CS0103 (line 34): The name 'm | `class Animal // Base class (parent)` |
| [12_oop/1304_polymorphism.ipynb](chapters/12_oop/1304_polymorphism.ipynb) | 15 | CS0246 (line 31): The type or namespace name 'MethodOverloading' could not be found (are y | `namespace IntroCSCS` |
| [12_oop/1305_abstraction.ipynb](chapters/12_oop/1305_abstraction.ipynb) | 6 | CS0246 (line 2): The type or namespace name 'Shape' could not be found (are you missing a  | `Shape shape = new Shape();` |
| [12_oop/1305_abstraction.ipynb](chapters/12_oop/1305_abstraction.ipynb) | 13 | CS0246 (line 2): The type or namespace name 'Shape' could not be found (are you missing a  | `class Circle : Shape` |
| [13_abstract_data_types/assignments/homework.ipynb](chapters/13_abstract_data_types/assignments/homework.ipynb) | 10 | CS0103 (line 9): The name 'First' does not exist in the current context | `// 4. Write a generic First<T> method for List<T>.` |
| [13_abstract_data_types/assignments/lab.ipynb](chapters/13_abstract_data_types/assignments/lab.ipynb) | 12 | CS0246 (line 8): The type or namespace name 'ListStack<>' could not be found (are you miss | `// Reuse your IStack<T> and ListStack<T> from Question 3.` |

## D. Syntax errors and fragments

| File | Cell | First error | First line |
|---|---|---|---|
| [02_var_data/0202_data_types.ipynb](chapters/02_var_data/0202_data_types.ipynb) | 42 | CS1003 (line 2): Syntax error, ',' expected | `string toBe1 = ""To be, or not to be" is a speech given by Prince Hamlet.";` |
| [02_var_data/0202_data_types.ipynb](chapters/02_var_data/0202_data_types.ipynb) | 54 | CS0266 (line 3): Cannot implicitly convert type 'double' to 'int'. An explicit conversion  | `double d = 2.0;` |
| [02_var_data/assignments/homework.ipynb](chapters/02_var_data/assignments/homework.ipynb) | 5 | CS1003 (line 4): Syntax error, ',' expected | `int x= (int)5.8;` |
| [02_var_data/assignments/lab.ipynb](chapters/02_var_data/assignments/lab.ipynb) | 6 | CS8635 (line 4): Unexpected character sequence '...' | `double numeratorDouble = numerator; // implicit cast` |
| [03_decision/assignments/homework.ipynb](chapters/03_decision/assignments/homework.ipynb) | 11 | CS1026 (line 7): ) expected | `public class Test1` |
| [04_iteration/0402_for_statements.ipynb](chapters/04_iteration/0402_for_statements.ipynb) | 15 | CS1002 (line 2): ; expected | `outer-Loop` |
| [04_iteration/0402_for_statements.ipynb](chapters/04_iteration/0402_for_statements.ipynb) | 17 | CS8635 (line 2): Unexpected character sequence '...' | `for (....) {` |
| [04_iteration/0403_while_statement.ipynb](chapters/04_iteration/0403_while_statement.ipynb) | 14 | CS1513 (line 2): } expected | `while (i < s.Length) {` |
| [04_iteration/assignments/lab.ipynb](chapters/04_iteration/assignments/lab.ipynb) | 15 | CS1513 (line 2): } expected | `for (int i = s.Length - 1; i >= 0; i--) {` |
| [04_iteration/assignments/lab.ipynb](chapters/04_iteration/assignments/lab.ipynb) | 24 | CS0117 (line 2): 'Console' does not contain a definition for 'WiteLine' | `var num = int.Parse(Console.WiteLine());` |
| [04_iteration/assignments/lab.ipynb](chapters/04_iteration/assignments/lab.ipynb) | 32 | CS8635 (line 5): Unexpected character sequence '...' | `/// Return the sum of the numbers from 1 through n.` |
| [04_iteration/assignments/lab.ipynb](chapters/04_iteration/assignments/lab.ipynb) | 40 | CS1513 (line 2): } expected | `while (i <= n) {` |
| [04_iteration/assignments/lab.ipynb](chapters/04_iteration/assignments/lab.ipynb) | 44 | CS1002 (line 5): ; expected | `int sum = 1, i = 2;` |
| [07_arrays/0702_twodim.ipynb](chapters/07_arrays/0702_twodim.ipynb) | 16 | CS1002 (line 6): ; expected | `// declare the array of three elements` |
| [07_arrays/assignments/homework.ipynb](chapters/07_arrays/assignments/homework.ipynb) | 3 | CS0200 (line 6): Property or indexer 'string.this | `char[] a = {'n', 'o', 'w'};` |
| [08_collections/0802-list-dictionary.ipynb](chapters/08_collections/0802-list-dictionary.ipynb) | 21 | CS0103 (line 2): The name 'words' does not exist in the current context | `words[0];` |
| [08_collections/0802-list-dictionary.ipynb](chapters/08_collections/0802-list-dictionary.ipynb) | 29 | CS0103 (line 2): The name 'words' does not exist in the current context | `words.Count;` |
| [08_collections/1101-intro-ds.ipynb](chapters/08_collections/1101-intro-ds.ipynb) | 36 | CS0103 (line 2): The name 'MinMax' does not exist in the current context | `var (min, max) = MinMax(new[] { 5, 2, 8, 1, 9, 3 });` |
| [08_collections/assignments/homework.ipynb](chapters/08_collections/assignments/homework.ipynb) | 3 | CS1002 (line 2): ; expected | `words.Clear()` |
| [08_collections/assignments/lab.ipynb](chapters/08_collections/assignments/lab.ipynb) | 9 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `public static void main()` |
| [09_files_text/assignments/homework.ipynb](chapters/09_files_text/assignments/homework.ipynb) | 1 | CS1002 (line 3): ; expected | `if (inFile.ReadLine().Contains("!")) {` |
| [12_classes/1202_properties.ipynb](chapters/12_classes/1202_properties.ipynb) | 8 | CS1022 (line 22): Type or namespace definition, or end-of-file expected | `namespace IntroCSCS` |
| [12_classes/assignments/hw_booklist.ipynb](chapters/12_classes/assignments/hw_booklist.ipynb) | 19 | CS0026 (line 2): Keyword 'this' is not valid in a static property, static method, or stati | `Console.Write(this);` |
| [12_oop/1304_polymorphism.ipynb](chapters/12_oop/1304_polymorphism.ipynb) | 10 | CS0239 (line 38): 'Square.Draw()': cannot override inherited member 'Rectangle.Draw()' bec | `public class Shape` |
| [11_databases/1105_async.ipynb](chapters/11_databases/1105_async.ipynb) | 6 | CS8421 (line 9): A static local function cannot contain a reference to 'client'. | `using System.Net.Http;` |
| [14_arrays_linked_lists/1401_dynamic_arrays.ipynb](chapters/14_arrays_linked_lists/1401_dynamic_arrays.ipynb) | 9 | CS1519 (line 35): Invalid token 'for' in class, record, struct, or interface member declar | `public sealed class DynamicIntArray` |
| [17_trees/1701_tree_structure.ipynb](chapters/17_trees/1701_tree_structure.ipynb) | 18 | CS0161 (line 14): 'CountLeaves(TreeNode?)': not all code paths return a value | `// Exercise: Count leaves` |
| [17_trees/assignments/homework.ipynb](chapters/17_trees/assignments/homework.ipynb) | 13 | CS0161 (line 14): 'Count(TreeNode?)': not all code paths return a value | `// 6. Count all nodes` |
| [17_trees/assignments/homework.ipynb](chapters/17_trees/assignments/homework.ipynb) | 16 | CS0161 (line 13): 'Minimum(TreeNode)': not all code paths return a value | `// 8. Find the minimum` |
| [17_trees/assignments/homework.ipynb](chapters/17_trees/assignments/homework.ipynb) | 18 | CS0161 (line 12): 'Height(TreeNode?)': not all code paths return a value | `// 9. Compute height` |
| [17_trees/assignments/lab.ipynb](chapters/17_trees/assignments/lab.ipynb) | 5 | CS0161 (line 10): 'Count(TreeNode?)': not all code paths return a value | `using System;` |

## E. Runtime exception

| File | Cell | First error | First line |
|---|---|---|---|
| [04_iteration/assignments/lab.ipynb](chapters/04_iteration/assignments/lab.ipynb) | 10 | System.IndexOutOfRangeException: Index was outside the bounds of the array. | `string s = "drab";` |
| [06_exceptions_testing/0601_error_handling.ipynb](chapters/06_exceptions_testing/0601_error_handling.ipynb) | 13 | System.ArgumentException: Denominator cannot be zero. (Parameter 'denominator') | `static double Divide(double numerator, double denominator)` |
| [07_arrays/assignments/homework.ipynb](chapters/07_arrays/assignments/homework.ipynb) | 17 | System.NullReferenceException: Object reference not set to an instance of an object. | `string[] a = new string[5];` |
| [09_files_text/0902_file_operations.ipynb](chapters/09_files_text/0902_file_operations.ipynb) | 10 | System.IO.FileNotFoundException: Could not find file '/tmp/cscs-9cf1893ca4f24a7486707dfb22 | `using System;` |
| [09_files_text/assignments/lab.ipynb](chapters/09_files_text/assignments/lab.ipynb) | 7 | System.IO.FileNotFoundException: Could not find file '/tmp/cscs-7f6dbc4bd2254e3d9c241ff11d | `using System.IO;` |
| [17_trees/assignments/lab.ipynb](chapters/17_trees/assignments/lab.ipynb) | 2 | System.NullReferenceException: Object reference not set to an instance of an object. | `using System;` |

## F. Timed out (15 s)

| File | Cell | First error | First line |
|---|---|---|---|
| [17_trees/1702_binary_search_trees.ipynb](chapters/17_trees/1702_binary_search_trees.ipynb) | 22 | timed out | `// Exercise: Complete search` |
| [17_trees/assignments/lab.ipynb](chapters/17_trees/assignments/lab.ipynb) | 12 | timed out | `using System;` |
