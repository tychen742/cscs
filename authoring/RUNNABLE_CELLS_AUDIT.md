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
| [03-methods/0303-parameter.ipynb](chapters/03-methods/0303-parameter.ipynb) | 9 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `public static void inchesToCentimeters(double i)    // parameter with type` |
| [06-exceptions-testing/0603-testing.ipynb](chapters/06-exceptions-testing/0603-testing.ipynb) | 7 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `public class BasicMaths` |
| [12_classes/1204_operator_overloading.ipynb](chapters/12_classes/1204_operator_overloading.ipynb) | 6 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `public struct SomeMath` |
| [12_classes/assignments/homework.ipynb](chapters/12_classes/assignments/homework.ipynb) | 1 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `class DoMath` |
| [12_classes/assignments/homework.ipynb](chapters/12_classes/assignments/homework.ipynb) | 3 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `static class SomeMath` |
| [12_classes/assignments/homework.ipynb](chapters/12_classes/assignments/homework.ipynb) | 5 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `class Customer` |
| [13_oop/1305_abstraction.ipynb](chapters/13_oop/1305_abstraction.ipynb) | 4 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `abstract class Shape` |
| [13_oop/1305_abstraction.ipynb](chapters/13_oop/1305_abstraction.ipynb) | 16 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `abstract class Shape` |
| [13_oop/1305_abstraction.ipynb](chapters/13_oop/1305_abstraction.ipynb) | 18 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `interface Animal` |
| [14-abstract-data-types/assignments/homework.ipynb](chapters/14-abstract-data-types/assignments/homework.ipynb) | 4 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// 1. Write a generic IQueue<T> interface with Count, Enqueue, Dequeue, and Peek.` |
| [14-abstract-data-types/assignments/homework.ipynb](chapters/14-abstract-data-types/assignments/homework.ipynb) | 5 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `interface IQueue<T>` |
| [14-abstract-data-types/assignments/lab.ipynb](chapters/14-abstract-data-types/assignments/lab.ipynb) | 2 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Define IStack<T> here.` |
| [14-abstract-data-types/assignments/lab.ipynb](chapters/14-abstract-data-types/assignments/lab.ipynb) | 3 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `interface IStack<T>` |
| [14-abstract-data-types/assignments/lab.ipynb](chapters/14-abstract-data-types/assignments/lab.ipynb) | 14 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// List-backed stack:` |
| [15-arrays-linked-lists/assignments/lab.ipynb](chapters/15-arrays-linked-lists/assignments/lab.ipynb) | 8 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `class Node<T>` |
| [16-stacks-queues/assignments/homework.ipynb](chapters/16-stacks-queues/assignments/homework.ipynb) | 2 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [16-stacks-queues/assignments/homework.ipynb](chapters/16-stacks-queues/assignments/homework.ipynb) | 4 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [16-stacks-queues/assignments/homework.ipynb](chapters/16-stacks-queues/assignments/homework.ipynb) | 6 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [16-stacks-queues/assignments/homework.ipynb](chapters/16-stacks-queues/assignments/homework.ipynb) | 8 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [16-stacks-queues/assignments/homework.ipynb](chapters/16-stacks-queues/assignments/homework.ipynb) | 10 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [17-trees/assignments/homework.ipynb](chapters/17-trees/assignments/homework.ipynb) | 2 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [17-trees/assignments/homework.ipynb](chapters/17-trees/assignments/homework.ipynb) | 4 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [17-trees/assignments/homework.ipynb](chapters/17-trees/assignments/homework.ipynb) | 6 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [17-trees/assignments/homework.ipynb](chapters/17-trees/assignments/homework.ipynb) | 8 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [17-trees/assignments/homework.ipynb](chapters/17-trees/assignments/homework.ipynb) | 10 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [18-heaps-hash-tables/assignments/homework.ipynb](chapters/18-heaps-hash-tables/assignments/homework.ipynb) | 2 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [18-heaps-hash-tables/assignments/homework.ipynb](chapters/18-heaps-hash-tables/assignments/homework.ipynb) | 4 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [18-heaps-hash-tables/assignments/homework.ipynb](chapters/18-heaps-hash-tables/assignments/homework.ipynb) | 6 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [18-heaps-hash-tables/assignments/homework.ipynb](chapters/18-heaps-hash-tables/assignments/homework.ipynb) | 8 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [18-heaps-hash-tables/assignments/homework.ipynb](chapters/18-heaps-hash-tables/assignments/homework.ipynb) | 10 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [19-graphs/assignments/homework.ipynb](chapters/19-graphs/assignments/homework.ipynb) | 2 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [19-graphs/assignments/homework.ipynb](chapters/19-graphs/assignments/homework.ipynb) | 4 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [19-graphs/assignments/homework.ipynb](chapters/19-graphs/assignments/homework.ipynb) | 6 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [19-graphs/assignments/homework.ipynb](chapters/19-graphs/assignments/homework.ipynb) | 8 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [19-graphs/assignments/homework.ipynb](chapters/19-graphs/assignments/homework.ipynb) | 10 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [20-algorithm-analysis/assignments/homework.ipynb](chapters/20-algorithm-analysis/assignments/homework.ipynb) | 2 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [20-algorithm-analysis/assignments/homework.ipynb](chapters/20-algorithm-analysis/assignments/homework.ipynb) | 4 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [20-algorithm-analysis/assignments/homework.ipynb](chapters/20-algorithm-analysis/assignments/homework.ipynb) | 6 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [20-algorithm-analysis/assignments/homework.ipynb](chapters/20-algorithm-analysis/assignments/homework.ipynb) | 8 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [20-algorithm-analysis/assignments/homework.ipynb](chapters/20-algorithm-analysis/assignments/homework.ipynb) | 10 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [21-recursion-divide-conquer/assignments/homework.ipynb](chapters/21-recursion-divide-conquer/assignments/homework.ipynb) | 2 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [21-recursion-divide-conquer/assignments/homework.ipynb](chapters/21-recursion-divide-conquer/assignments/homework.ipynb) | 4 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [21-recursion-divide-conquer/assignments/homework.ipynb](chapters/21-recursion-divide-conquer/assignments/homework.ipynb) | 6 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [21-recursion-divide-conquer/assignments/homework.ipynb](chapters/21-recursion-divide-conquer/assignments/homework.ipynb) | 8 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [21-recursion-divide-conquer/assignments/homework.ipynb](chapters/21-recursion-divide-conquer/assignments/homework.ipynb) | 10 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [22-searching-sorting/assignments/homework.ipynb](chapters/22-searching-sorting/assignments/homework.ipynb) | 2 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [22-searching-sorting/assignments/homework.ipynb](chapters/22-searching-sorting/assignments/homework.ipynb) | 4 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [22-searching-sorting/assignments/homework.ipynb](chapters/22-searching-sorting/assignments/homework.ipynb) | 6 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [22-searching-sorting/assignments/homework.ipynb](chapters/22-searching-sorting/assignments/homework.ipynb) | 8 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [22-searching-sorting/assignments/homework.ipynb](chapters/22-searching-sorting/assignments/homework.ipynb) | 10 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [23-greedy-graph-optimization/assignments/homework.ipynb](chapters/23-greedy-graph-optimization/assignments/homework.ipynb) | 2 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [23-greedy-graph-optimization/assignments/homework.ipynb](chapters/23-greedy-graph-optimization/assignments/homework.ipynb) | 4 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [23-greedy-graph-optimization/assignments/homework.ipynb](chapters/23-greedy-graph-optimization/assignments/homework.ipynb) | 6 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [23-greedy-graph-optimization/assignments/homework.ipynb](chapters/23-greedy-graph-optimization/assignments/homework.ipynb) | 8 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [23-greedy-graph-optimization/assignments/homework.ipynb](chapters/23-greedy-graph-optimization/assignments/homework.ipynb) | 10 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [24-dynamic-programming-backtracking/assignments/homework.ipynb](chapters/24-dynamic-programming-backtracking/assignments/homework.ipynb) | 2 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [24-dynamic-programming-backtracking/assignments/homework.ipynb](chapters/24-dynamic-programming-backtracking/assignments/homework.ipynb) | 4 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [24-dynamic-programming-backtracking/assignments/homework.ipynb](chapters/24-dynamic-programming-backtracking/assignments/homework.ipynb) | 6 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [24-dynamic-programming-backtracking/assignments/homework.ipynb](chapters/24-dynamic-programming-backtracking/assignments/homework.ipynb) | 8 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [24-dynamic-programming-backtracking/assignments/homework.ipynb](chapters/24-dynamic-programming-backtracking/assignments/homework.ipynb) | 10 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [25-advanced-graphs-strings-limits/assignments/homework.ipynb](chapters/25-advanced-graphs-strings-limits/assignments/homework.ipynb) | 2 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [25-advanced-graphs-strings-limits/assignments/homework.ipynb](chapters/25-advanced-graphs-strings-limits/assignments/homework.ipynb) | 4 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [25-advanced-graphs-strings-limits/assignments/homework.ipynb](chapters/25-advanced-graphs-strings-limits/assignments/homework.ipynb) | 6 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [25-advanced-graphs-strings-limits/assignments/homework.ipynb](chapters/25-advanced-graphs-strings-limits/assignments/homework.ipynb) | 8 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |
| [25-advanced-graphs-strings-limits/assignments/homework.ipynb](chapters/25-advanced-graphs-strings-limits/assignments/homework.ipynb) | 10 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `// Solution` |

## B. Classes declared before the code that uses them (CS8803)

| File | Cell | First error | First line |
|---|---|---|---|
| [02-var_data/0202-data_types.ipynb](chapters/02-var_data/0202-data_types.ipynb) | 7 | CS8803 (line 9): Top-level statements must precede namespace and type declarations. | `// Preview of 'class' syntax (full treatment in Chapter 12) — used here` |
| [05-iteration/0501-iteration.ipynb](chapters/05-iteration/0501-iteration.ipynb) | 3 | CS8803 (line 26): Top-level statements must precede namespace and type declarations. | `using System;` |
| [06-exceptions-testing/0604-nullable.ipynb](chapters/06-exceptions-testing/0604-nullable.ipynb) | 10 | CS8803 (line 5): Top-level statements must precede namespace and type declarations. | `record Order(string? CustomerName, Address? ShippingAddress);` |
| [11_databases/1104_records.ipynb](chapters/11_databases/1104_records.ipynb) | 5 | CS8803 (line 4): Top-level statements must precede namespace and type declarations. | `record Point(int X, int Y);` |
| [11_databases/1104_records.ipynb](chapters/11_databases/1104_records.ipynb) | 7 | CS8803 (line 4): Top-level statements must precede namespace and type declarations. | `record Person(string Name, int Age);` |
| [11_databases/1104_records.ipynb](chapters/11_databases/1104_records.ipynb) | 9 | CS8803 (line 4): Top-level statements must precede namespace and type declarations. | `record Point(int X, int Y);` |
| [11_databases/1104_records.ipynb](chapters/11_databases/1104_records.ipynb) | 13 | CS8803 (line 8): Top-level statements must precede namespace and type declarations. | `record Person` |
| [14-abstract-data-types/1401-adt-contracts.ipynb](chapters/14-abstract-data-types/1401-adt-contracts.ipynb) | 5 | CS8803 (line 33): Top-level statements must precede namespace and type declarations. | `interface IStack<T>` |
| [14-abstract-data-types/1402-representations-costs.ipynb](chapters/14-abstract-data-types/1402-representations-costs.ipynb) | 5 | CS8803 (line 24): Top-level statements must precede namespace and type declarations. | `class ArrayStack<T>` |
| [14-abstract-data-types/1402-representations-costs.ipynb](chapters/14-abstract-data-types/1402-representations-costs.ipynb) | 8 | CS8803 (line 14): Top-level statements must precede namespace and type declarations. | `class Node<T>` |
| [14-abstract-data-types/1403-generics.ipynb](chapters/14-abstract-data-types/1403-generics.ipynb) | 5 | CS8803 (line 12): Top-level statements must precede namespace and type declarations. | `// A minimal generic cell ADT` |
| [14-abstract-data-types/1404-iterators.ipynb](chapters/14-abstract-data-types/1404-iterators.ipynb) | 6 | CS8803 (line 24): Top-level statements must precede namespace and type declarations. | `class NumberRange : IEnumerable<int>` |
| [14-abstract-data-types/assignments/homework.ipynb](chapters/14-abstract-data-types/assignments/homework.ipynb) | 6 | CS8803 (line 18): Top-level statements must precede namespace and type declarations. | `// 2. Complete a generic Cell<T> class with Get and Set methods.` |
| [14-abstract-data-types/assignments/homework.ipynb](chapters/14-abstract-data-types/assignments/homework.ipynb) | 7 | CS8803 (line 15): Top-level statements must precede namespace and type declarations. | `class Cell<T>` |
| [14-abstract-data-types/assignments/homework.ipynb](chapters/14-abstract-data-types/assignments/homework.ipynb) | 8 | CS8803 (line 16): Top-level statements must precede namespace and type declarations. | `// 3. Trace this linked structure by hand before running it.` |
| [14-abstract-data-types/assignments/lab.ipynb](chapters/14-abstract-data-types/assignments/lab.ipynb) | 5 | CS8803 (line 23): Top-level statements must precede namespace and type declarations. | `interface IStack<T>` |
| [14-abstract-data-types/assignments/lab.ipynb](chapters/14-abstract-data-types/assignments/lab.ipynb) | 6 | CS8803 (line 20): Top-level statements must precede namespace and type declarations. | `interface IStack<T>` |
| [14-abstract-data-types/assignments/lab.ipynb](chapters/14-abstract-data-types/assignments/lab.ipynb) | 8 | CS8803 (line 31): Top-level statements must precede namespace and type declarations. | `interface IStack<T>` |
| [14-abstract-data-types/assignments/lab.ipynb](chapters/14-abstract-data-types/assignments/lab.ipynb) | 9 | CS8803 (line 32): Top-level statements must precede namespace and type declarations. | `interface IStack<T>` |
| [14-abstract-data-types/assignments/lab.ipynb](chapters/14-abstract-data-types/assignments/lab.ipynb) | 13 | CS8803 (line 32): Top-level statements must precede namespace and type declarations. | `interface IStack<T>` |
| [15-arrays-linked-lists/1502-linked-nodes.ipynb](chapters/15-arrays-linked-lists/1502-linked-nodes.ipynb) | 3 | CS8803 (line 13): Top-level statements must precede namespace and type declarations. | `public sealed class IntroNode<T>` |
| [15-arrays-linked-lists/1502-linked-nodes.ipynb](chapters/15-arrays-linked-lists/1502-linked-nodes.ipynb) | 6 | CS8803 (line 9): Top-level statements must precede namespace and type declarations. | `public sealed class TraversalNode<T>` |
| [15-arrays-linked-lists/1502-linked-nodes.ipynb](chapters/15-arrays-linked-lists/1502-linked-nodes.ipynb) | 9 | CS8803 (line 9): Top-level statements must precede namespace and type declarations. | `public sealed class InsertNode<T>` |
| [15-arrays-linked-lists/1502-linked-nodes.ipynb](chapters/15-arrays-linked-lists/1502-linked-nodes.ipynb) | 13 | CS8803 (line 9): Top-level statements must precede namespace and type declarations. | `public sealed class DeleteNode<T>` |
| [15-arrays-linked-lists/1503-comparison-lab.ipynb](chapters/15-arrays-linked-lists/1503-comparison-lab.ipynb) | 6 | CS8803 (line 9): Top-level statements must precede namespace and type declarations. | `public sealed class Node<T>` |
| [15-arrays-linked-lists/assignments/homework.ipynb](chapters/15-arrays-linked-lists/assignments/homework.ipynb) | 6 | CS8803 (line 11): Top-level statements must precede namespace and type declarations. | `// 2. Write CountNodes for a linked chain.` |
| [15-arrays-linked-lists/assignments/homework.ipynb](chapters/15-arrays-linked-lists/assignments/homework.ipynb) | 7 | CS8803 (line 9): Top-level statements must precede namespace and type declarations. | `class CountNode<T>` |
| [15-arrays-linked-lists/assignments/lab.ipynb](chapters/15-arrays-linked-lists/assignments/lab.ipynb) | 2 | CS8803 (line 16): Top-level statements must precede namespace and type declarations. | `class SmallArray` |
| [15-arrays-linked-lists/assignments/lab.ipynb](chapters/15-arrays-linked-lists/assignments/lab.ipynb) | 3 | CS8803 (line 16): Top-level statements must precede namespace and type declarations. | `class SmallArray` |
| [15-arrays-linked-lists/assignments/lab.ipynb](chapters/15-arrays-linked-lists/assignments/lab.ipynb) | 5 | CS8803 (line 23): Top-level statements must precede namespace and type declarations. | `class DynamicArray` |
| [15-arrays-linked-lists/assignments/lab.ipynb](chapters/15-arrays-linked-lists/assignments/lab.ipynb) | 6 | CS8803 (line 23): Top-level statements must precede namespace and type declarations. | `class DynamicArray` |
| [15-arrays-linked-lists/assignments/lab.ipynb](chapters/15-arrays-linked-lists/assignments/lab.ipynb) | 9 | CS8803 (line 9): Top-level statements must precede namespace and type declarations. | `class Node<T>` |
| [15-arrays-linked-lists/assignments/lab.ipynb](chapters/15-arrays-linked-lists/assignments/lab.ipynb) | 12 | CS8803 (line 9): Top-level statements must precede namespace and type declarations. | `class LinkNode<T>` |
| [15-arrays-linked-lists/assignments/lab.ipynb](chapters/15-arrays-linked-lists/assignments/lab.ipynb) | 13 | CS8803 (line 9): Top-level statements must precede namespace and type declarations. | `class LinkNode<T>` |
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
| [02-var_data/0201-variables.ipynb](chapters/02-var_data/0201-variables.ipynb) | 6 | CS0246 (line 2): The type or namespace name 'type' could not be found (are you missing a u | `type variableName = value;` |
| [02-var_data/0202-data_types.ipynb](chapters/02-var_data/0202-data_types.ipynb) | 35 | CS0165 (line 16): Use of unassigned local variable 'message1' | `#pragma warning disable CS8632` |
| [02-var_data/0206-input_output.ipynb](chapters/02-var_data/0206-input_output.ipynb) | 12 | CS0103 (line 2): The name 'a' does not exist in the current context | `a = UI.PromptInt("Enter integer leg: ");` |
| [03-methods/assignments/homework.ipynb](chapters/03-methods/assignments/homework.ipynb) | 1 | CS0103 (line 2): The name 'Q1' does not exist in the current context | `double d = Q1(2, 5);` |
| [03-methods/assignments/homework.ipynb](chapters/03-methods/assignments/homework.ipynb) | 3 | CS0103 (line 2): The name 'Q4' does not exist in the current context | `Q4("hi");` |
| [03-methods/assignments/homework.ipynb](chapters/03-methods/assignments/homework.ipynb) | 7 | CS0103 (line 4): The name 'Q' does not exist in the current context | `static void Main()` |
| [03-methods/assignments/homework.ipynb](chapters/03-methods/assignments/homework.ipynb) | 9 | CS0103 (line 5): The name 'Q' does not exist in the current context | `static void Main()` |
| [03-methods/assignments/homework.ipynb](chapters/03-methods/assignments/homework.ipynb) | 12 | CS0103 (line 5): The name 'Q' does not exist in the current context | `static void Main()                   // 7` |
| [03-methods/assignments/lab.ipynb](chapters/03-methods/assignments/lab.ipynb) | 4 | CS0103 (line 2): The name 'F' does not exist in the current context | `Console.WriteLine(F(3));` |
| [03-methods/assignments/lab.ipynb](chapters/03-methods/assignments/lab.ipynb) | 8 | CS0103 (line 2): The name 'F' does not exist in the current context | `Console.WriteLine(F(3) + F(4));` |
| [03-methods/assignments/lab.ipynb](chapters/03-methods/assignments/lab.ipynb) | 10 | CS0103 (line 2): The name 'F' does not exist in the current context | `Console.WriteLine(9 + F(4));` |
| [04-decision/0401-intro-decision.ipynb](chapters/04-decision/0401-intro-decision.ipynb) | 8 | CS0103 (line 2): The name 'condition' does not exist in the current context | `if (condition)` |
| [04-decision/0402-ifstatement.ipynb](chapters/04-decision/0402-ifstatement.ipynb) | 8 | CS0103 (line 2): The name 'condition1' does not exist in the current context | `if (condition1)` |
| [04-decision/0406-switch.ipynb](chapters/04-decision/0406-switch.ipynb) | 3 | CS0103 (line 2): The name 'expression' does not exist in the current context | `switch(expression)` |
| [04-decision/assignments/homework.ipynb](chapters/04-decision/assignments/homework.ipynb) | 1 | CS0103 (line 2): The name 'IsBig' does not exist in the current context | `if (IsBig(x) == true)` |
| [04-decision/assignments/homework.ipynb](chapters/04-decision/assignments/homework.ipynb) | 3 | CS0103 (line 2): The name 'x' does not exist in the current context | `if (x > 0 && (y / x) == 3)` |
| [04-decision/assignments/homework.ipynb](chapters/04-decision/assignments/homework.ipynb) | 5 | CS0103 (line 2): The name 'x' does not exist in the current context | `if (x < 0)` |
| [04-decision/assignments/homework.ipynb](chapters/04-decision/assignments/homework.ipynb) | 7 | CS0103 (line 2): The name 'x' does not exist in the current context | `if (x > 7) {    //a` |
| [04-decision/assignments/homework.ipynb](chapters/04-decision/assignments/homework.ipynb) | 9 | CS0103 (line 2): The name 'y' does not exist in the current context | `y = 1;         //a` |
| [04-decision/assignments/homework.ipynb](chapters/04-decision/assignments/homework.ipynb) | 12 | CS0103 (line 2): The name 'x' does not exist in the current context | `if (x > 5)        //a` |
| [04-decision/assignments/lab.ipynb](chapters/04-decision/assignments/lab.ipynb) | 5 | CS0103 (line 2): The name 'UIF' does not exist in the current context | `string v = UIF.PromptLine("Enter a word: ");` |
| [04-decision/assignments/lab.ipynb](chapters/04-decision/assignments/lab.ipynb) | 7 | CS0103 (line 2): The name 'UIF' does not exist in the current context | `int x = UIF.PromptInt("Enter a integer: ");` |
| [04-decision/assignments/lab.ipynb](chapters/04-decision/assignments/lab.ipynb) | 10 | CS0103 (line 7): The name 'CalcWeeklyWages' does not exist in the current context | `// Calculate Wages` |
| [05-iteration/0502-for-statements.ipynb](chapters/05-iteration/0502-for-statements.ipynb) | 29 | CS0103 (line 2): The name 'x' does not exist in the current context | `x *= 5;` |
| [05-iteration/0502-for-statements.ipynb](chapters/05-iteration/0502-for-statements.ipynb) | 31 | CS0103 (line 2): The name 'x' does not exist in the current context | `x = x * 5;` |
| [05-iteration/0503-while-statement.ipynb](chapters/05-iteration/0503-while-statement.ipynb) | 38 | CS0103 (line 5): The name 'UI' does not exist in the current context | `int a, b, c;` |
| [05-iteration/assignments/lab.ipynb](chapters/05-iteration/assignments/lab.ipynb) | 46 | CS0103 (line 3): The name 'n' does not exist in the current context | `int sum = 1, i = 2;` |
| [06-exceptions-testing/0601-error-handling.ipynb](chapters/06-exceptions-testing/0601-error-handling.ipynb) | 10 | CS0841 (line 1): Cannot use local variable 'path' before it is declared | `string path = "scores.txt";` |
| [06-exceptions-testing/0603-testing.ipynb](chapters/06-exceptions-testing/0603-testing.ipynb) | 4 | CS0246 (line 8): The type or namespace name 'Calculator' could not be found (are you missi | `namespace IntroCSCS` |
| [08-arrays/assignments/lab.ipynb](chapters/08-arrays/assignments/lab.ipynb) | 3 | CS0103 (line 5): The name 'VectorDotProduct' does not exist in the current context | `double[] a = new double[] { 1.5, 2.0, 3.0 };` |
| [09-collections/0802-list-dictionary.ipynb](chapters/09-collections/0802-list-dictionary.ipynb) | 39 | CS0103 (line 3): The name 'MakeInt' does not exist in the current context | `List<int> digits = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };` |
| [09-collections/assignments/lab.ipynb](chapters/09-collections/assignments/lab.ipynb) | 6 | CS0103 (line 6): The name 'GetParagraphs' does not exist in the current context | `public static void Main(string[] args)` |
| [10-files-text/1002-file-operations.ipynb](chapters/10-files-text/1002-file-operations.ipynb) | 11 | CS0103 (line 10): The name 'UI' does not exist in the current context | `using System;` |
| [10-files-text/1002-file-operations.ipynb](chapters/10-files-text/1002-file-operations.ipynb) | 15 | CS0103 (line 2): The name 'reader' does not exist in the current context | `string wholeFile = reader.ReadToEnd();` |
| [10-files-text/1003-text-operations.ipynb](chapters/10-files-text/1003-text-operations.ipynb) | 29 | CS0103 (line 6): The name 'TryParseStudent' does not exist in the current context | `string[] records = { "Alice,98,CS", "Bob,abc,Math", "Carol,87,Physics", "" };` |
| [10-files-text/assignments/lab.ipynb](chapters/10-files-text/assignments/lab.ipynb) | 10 | CS0103 (line 2): The name 'reader' does not exist in the current context | `string contents = reader.ReadToEnd();` |
| [13_oop/1304_polymorphism.ipynb](chapters/13_oop/1304_polymorphism.ipynb) | 4 | CS0103 (line 34): The name 'm | `class Animal // Base class (parent)` |
| [13_oop/1304_polymorphism.ipynb](chapters/13_oop/1304_polymorphism.ipynb) | 15 | CS0246 (line 31): The type or namespace name 'MethodOverloading' could not be found (are y | `namespace IntroCSCS` |
| [13_oop/1305_abstraction.ipynb](chapters/13_oop/1305_abstraction.ipynb) | 6 | CS0246 (line 2): The type or namespace name 'Shape' could not be found (are you missing a  | `Shape shape = new Shape();` |
| [13_oop/1305_abstraction.ipynb](chapters/13_oop/1305_abstraction.ipynb) | 13 | CS0246 (line 2): The type or namespace name 'Shape' could not be found (are you missing a  | `class Circle : Shape` |
| [14-abstract-data-types/assignments/homework.ipynb](chapters/14-abstract-data-types/assignments/homework.ipynb) | 10 | CS0103 (line 9): The name 'First' does not exist in the current context | `// 4. Write a generic First<T> method for List<T>.` |
| [14-abstract-data-types/assignments/lab.ipynb](chapters/14-abstract-data-types/assignments/lab.ipynb) | 12 | CS0246 (line 8): The type or namespace name 'ListStack<>' could not be found (are you miss | `// Reuse your IStack<T> and ListStack<T> from Question 3.` |

## D. Syntax errors and fragments

| File | Cell | First error | First line |
|---|---|---|---|
| [02-var_data/0202-data_types.ipynb](chapters/02-var_data/0202-data_types.ipynb) | 42 | CS1003 (line 2): Syntax error, ',' expected | `string toBe1 = ""To be, or not to be" is a speech given by Prince Hamlet.";` |
| [02-var_data/0202-data_types.ipynb](chapters/02-var_data/0202-data_types.ipynb) | 54 | CS0266 (line 3): Cannot implicitly convert type 'double' to 'int'. An explicit conversion  | `double d = 2.0;` |
| [02-var_data/assignments/homework.ipynb](chapters/02-var_data/assignments/homework.ipynb) | 5 | CS1003 (line 4): Syntax error, ',' expected | `int x= (int)5.8;` |
| [02-var_data/assignments/lab.ipynb](chapters/02-var_data/assignments/lab.ipynb) | 6 | CS8635 (line 4): Unexpected character sequence '...' | `double numeratorDouble = numerator; // implicit cast` |
| [04-decision/assignments/homework.ipynb](chapters/04-decision/assignments/homework.ipynb) | 11 | CS1026 (line 7): ) expected | `public class Test1` |
| [05-iteration/0502-for-statements.ipynb](chapters/05-iteration/0502-for-statements.ipynb) | 15 | CS1002 (line 2): ; expected | `outer-Loop` |
| [05-iteration/0502-for-statements.ipynb](chapters/05-iteration/0502-for-statements.ipynb) | 17 | CS8635 (line 2): Unexpected character sequence '...' | `for (....) {` |
| [05-iteration/0503-while-statement.ipynb](chapters/05-iteration/0503-while-statement.ipynb) | 14 | CS1513 (line 2): } expected | `while (i < s.Length) {` |
| [05-iteration/assignments/lab.ipynb](chapters/05-iteration/assignments/lab.ipynb) | 15 | CS1513 (line 2): } expected | `for (int i = s.Length - 1; i >= 0; i--) {` |
| [05-iteration/assignments/lab.ipynb](chapters/05-iteration/assignments/lab.ipynb) | 24 | CS0117 (line 2): 'Console' does not contain a definition for 'WiteLine' | `var num = int.Parse(Console.WiteLine());` |
| [05-iteration/assignments/lab.ipynb](chapters/05-iteration/assignments/lab.ipynb) | 32 | CS8635 (line 5): Unexpected character sequence '...' | `/// Return the sum of the numbers from 1 through n.` |
| [05-iteration/assignments/lab.ipynb](chapters/05-iteration/assignments/lab.ipynb) | 40 | CS1513 (line 2): } expected | `while (i <= n) {` |
| [05-iteration/assignments/lab.ipynb](chapters/05-iteration/assignments/lab.ipynb) | 44 | CS1002 (line 5): ; expected | `int sum = 1, i = 2;` |
| [08-arrays/0802-twodim.ipynb](chapters/08-arrays/0802-twodim.ipynb) | 16 | CS1002 (line 6): ; expected | `// declare the array of three elements` |
| [08-arrays/assignments/homework.ipynb](chapters/08-arrays/assignments/homework.ipynb) | 3 | CS0200 (line 6): Property or indexer 'string.this | `char[] a = {'n', 'o', 'w'};` |
| [09-collections/0802-list-dictionary.ipynb](chapters/09-collections/0802-list-dictionary.ipynb) | 21 | CS0103 (line 2): The name 'words' does not exist in the current context | `words[0];` |
| [09-collections/0802-list-dictionary.ipynb](chapters/09-collections/0802-list-dictionary.ipynb) | 29 | CS0103 (line 2): The name 'words' does not exist in the current context | `words.Count;` |
| [09-collections/1101-intro-ds.ipynb](chapters/09-collections/1101-intro-ds.ipynb) | 36 | CS0103 (line 2): The name 'MinMax' does not exist in the current context | `var (min, max) = MinMax(new[] { 5, 2, 8, 1, 9, 3 });` |
| [09-collections/assignments/homework.ipynb](chapters/09-collections/assignments/homework.ipynb) | 3 | CS1002 (line 2): ; expected | `words.Clear()` |
| [09-collections/assignments/lab.ipynb](chapters/09-collections/assignments/lab.ipynb) | 9 | CS5001 (line -): Program does not contain a static 'Main' method suitable for an entry poi | `public static void main()` |
| [10-files-text/assignments/homework.ipynb](chapters/10-files-text/assignments/homework.ipynb) | 1 | CS1002 (line 3): ; expected | `if (inFile.ReadLine().Contains("!")) {` |
| [12_classes/1202_properties.ipynb](chapters/12_classes/1202_properties.ipynb) | 8 | CS1022 (line 22): Type or namespace definition, or end-of-file expected | `namespace IntroCSCS` |
| [12_classes/assignments/hw_booklist.ipynb](chapters/12_classes/assignments/hw_booklist.ipynb) | 19 | CS0026 (line 2): Keyword 'this' is not valid in a static property, static method, or stati | `Console.Write(this);` |
| [13_oop/1304_polymorphism.ipynb](chapters/13_oop/1304_polymorphism.ipynb) | 10 | CS0239 (line 38): 'Square.Draw()': cannot override inherited member 'Rectangle.Draw()' bec | `public class Shape` |
| [11_databases/1105_async.ipynb](chapters/11_databases/1105_async.ipynb) | 6 | CS8421 (line 9): A static local function cannot contain a reference to 'client'. | `using System.Net.Http;` |
| [15-arrays-linked-lists/1501-dynamic-arrays.ipynb](chapters/15-arrays-linked-lists/1501-dynamic-arrays.ipynb) | 9 | CS1519 (line 35): Invalid token 'for' in class, record, struct, or interface member declar | `public sealed class DynamicIntArray` |
| [17-trees/1701-tree-structure.ipynb](chapters/17-trees/1701-tree-structure.ipynb) | 18 | CS0161 (line 14): 'CountLeaves(TreeNode?)': not all code paths return a value | `// Exercise: Count leaves` |
| [17-trees/assignments/homework.ipynb](chapters/17-trees/assignments/homework.ipynb) | 13 | CS0161 (line 14): 'Count(TreeNode?)': not all code paths return a value | `// 6. Count all nodes` |
| [17-trees/assignments/homework.ipynb](chapters/17-trees/assignments/homework.ipynb) | 16 | CS0161 (line 13): 'Minimum(TreeNode)': not all code paths return a value | `// 8. Find the minimum` |
| [17-trees/assignments/homework.ipynb](chapters/17-trees/assignments/homework.ipynb) | 18 | CS0161 (line 12): 'Height(TreeNode?)': not all code paths return a value | `// 9. Compute height` |
| [17-trees/assignments/lab.ipynb](chapters/17-trees/assignments/lab.ipynb) | 5 | CS0161 (line 10): 'Count(TreeNode?)': not all code paths return a value | `using System;` |

## E. Runtime exception

| File | Cell | First error | First line |
|---|---|---|---|
| [05-iteration/assignments/lab.ipynb](chapters/05-iteration/assignments/lab.ipynb) | 10 | System.IndexOutOfRangeException: Index was outside the bounds of the array. | `string s = "drab";` |
| [06-exceptions-testing/0601-error-handling.ipynb](chapters/06-exceptions-testing/0601-error-handling.ipynb) | 13 | System.ArgumentException: Denominator cannot be zero. (Parameter 'denominator') | `static double Divide(double numerator, double denominator)` |
| [08-arrays/assignments/homework.ipynb](chapters/08-arrays/assignments/homework.ipynb) | 17 | System.NullReferenceException: Object reference not set to an instance of an object. | `string[] a = new string[5];` |
| [10-files-text/1002-file-operations.ipynb](chapters/10-files-text/1002-file-operations.ipynb) | 10 | System.IO.FileNotFoundException: Could not find file '/tmp/cscs-9cf1893ca4f24a7486707dfb22 | `using System;` |
| [10-files-text/assignments/lab.ipynb](chapters/10-files-text/assignments/lab.ipynb) | 7 | System.IO.FileNotFoundException: Could not find file '/tmp/cscs-7f6dbc4bd2254e3d9c241ff11d | `using System.IO;` |
| [17-trees/assignments/lab.ipynb](chapters/17-trees/assignments/lab.ipynb) | 2 | System.NullReferenceException: Object reference not set to an instance of an object. | `using System;` |

## F. Timed out (15 s)

| File | Cell | First error | First line |
|---|---|---|---|
| [17-trees/1702-binary-search-trees.ipynb](chapters/17-trees/1702-binary-search-trees.ipynb) | 22 | timed out | `// Exercise: Complete search` |
| [17-trees/assignments/lab.ipynb](chapters/17-trees/assignments/lab.ipynb) | 12 | timed out | `using System;` |
