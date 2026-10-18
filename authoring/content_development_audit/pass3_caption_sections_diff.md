---
orphan: true
---

# Pass 3 diff: caption-only sections in 14.1, 14.2, 14.3, 13.3, 6.1, 10.3, 11.5, 9.3, 5.4 (2026-10-18)

Cell-level record of every change. Lines starting with - and + are edits to existing cells; entries marked "new ... cell" were inserted after the named cell.

```diff
### chapters/14_arrays_linked_lists/1401_dynamic_arrays.ipynb cell storage-body expand explanation
+
+Two numbers describe the structure at every moment. *Capacity* is `storage.Length`, fixed when the array was created. *Count* is how many of those slots hold real data, and it is the program's job to track it, because the array itself cannot tell a stored `0` from an unused slot. The append pattern is always the same two steps:
+
+```csharp
+storage[count] = value;   // write into the first unused slot
+count++;                  // that slot is now used
+```
+
+The example appends three values and reads one back by index:

### chapters/14_arrays_linked_lists/1401_dynamic_arrays.ipynb + new markdown cell after storage-code Contiguous Storage interpretation
+ The output is `count=3, capacity=5` and then `20`. Slots 3 and 4 still hold the default `0`, but they are not part of the sequence: a loop over the data must stop at `count`, not at `storage.Length`. Using `Length` as the number of items is the first mistake to avoid; it would report five values, two of them phantom zeros. The second is appending when `count == storage.Length`, which throws `IndexOutOfRangeException`; the next section shows what to do instead.

### chapters/14_arrays_linked_lists/1401_dynamic_arrays.ipynb cell resize-body expand explanation
+
+The resize has three steps, and the order matters: allocate the larger array, copy every used slot, then make the variable refer to the new array. The old array is unreachable afterward and is reclaimed by the runtime.
+
+```csharp
+int[] larger = new int[old.Length * 2];   // 1. allocate
+for (int i = 0; i < old.Length; i++)      // 2. copy the used slots
+    larger[i] = old[i];
+storage = larger;                         // 3. the variable now refers to the new array
+```
+
+`Grow` below performs the first two steps and returns the result; the caller performs the third.

### chapters/14_arrays_linked_lists/1401_dynamic_arrays.ipynb + new markdown cell after resize-code Resizing interpretation
+ The first two lines print `10, 20, 30, 0, 0` with `Length of storage: 5`; after the blank line the new array prints `10, 20, 30, 0, 0, 0, 0, 0, 0, 0` with `Length of new storage: 10`. The three stored values arrived in the larger array through the copy loop, so the assignment `newStorage[2] = 30` is redundant: it rewrites a value that was already copied. The mistake that matters is forgetting step three. If the dynamic array called `Grow(storage)` without assigning the result back to its field, it would keep appending into the old, full array and fail on the next add.

### chapters/14_arrays_linked_lists/1401_dynamic_arrays.ipynb cell class-body expand explanation
+
+Read `Add` in two halves. The `if` handles the full case by doubling, exactly as `Grow` did, but assigns the larger array back to the field so the object keeps it. The last two lines are the two-step append pattern. The indexer checks `index` against `Count`, not against `items.Length`, so unused capacity is never readable. Starting capacity is 2, so the five appends below resize twice; the printed line after each append shows when.

### chapters/14_arrays_linked_lists/1401_dynamic_arrays.ipynb + new markdown cell after class-code Worked example interpretation
+ The output is:
+ 
+ ```text
+ added=10, count=1, capacity=2
+ added=20, count=2, capacity=2
+ added=30, count=3, capacity=4
+ added=40, count=4, capacity=4
+ added=50, count=5, capacity=8
+ values[3]=40
+ ```
+ 
+ Capacity doubled on the third and fifth appends, when `Count` had caught up with it. After the last line, `values[4]` is `50` and `values[5]` throws, even though the backing array has eight slots: the indexer enforces the sequence contract, not the storage size. Variation: change the starting capacity to 1 and predict the capacity column before running.

### chapters/14_arrays_linked_lists/1401_dynamic_arrays.ipynb cell cost-body expand explanation
+
+Count the copies for sixteen appends starting from capacity 2:
+
+| Resize at append | New capacity | Values copied |
+| ---: | ---: | ---: |
+| 3 | 4 | 2 |
+| 5 | 8 | 4 |
+| 9 | 16 | 8 |
+| Total | | 14 |
+
+Sixteen appends caused fourteen copies, fewer than one per append, and the ratio stays below one however long the sequence grows. That is the amortized argument in numbers; the last section of this page states it in general.

### chapters/14_arrays_linked_lists/1402_linked_nodes.ipynb cell node-body expand explanation
+
+A node is a small class with two members, and the whole list is built from nothing but nodes:
+
+```csharp
+public class Node<T>
+{
+    public T Value { get; }          // the stored item, fixed at construction
+    public Node<T>? Next { get; set; }   // the following node, or null at the end
+}
+```
+
+The `?` on `Next` says that `null` is an expected value, not an error: the last node's `Next` is always `null`. Chapter 11 introduced that annotation. The example links three nodes by hand, assigning each `Next` after the node is created:

### chapters/14_arrays_linked_lists/1402_linked_nodes.ipynb + new markdown cell after node-code Nodes interpretation
+ The output is `10` and then `20`. `first.Next.Next.Next` is `null`, so `first.Next.Next.Next.Value` would throw `NullReferenceException`; every walk along `Next` references has to stop at `null`, which is what the traversal loop in the next section does. Notice that there is no array anywhere: the three nodes can sit anywhere in memory, and only the references connect them.

### chapters/14_arrays_linked_lists/1402_linked_nodes.ipynb cell traversal-body expand explanation
+
+The traversal loop has the same three parts as a counting `for` loop, with a reference in place of an index:
+
+```csharp
+for (Node<T>? current = head; current is not null; current = current.Next)
+{
+    // use current.Value
+}
+```
+
+Start at the head, continue while there is a node, and advance by following `Next`. The loop ends when `current` becomes `null`, which happens one step past the last node.

### chapters/14_arrays_linked_lists/1402_linked_nodes.ipynb + new markdown cell after traversal-code Traversal interpretation
+ The output is three lines, `visit 1: alpha` through `visit 3: gamma`. Reaching `gamma` cost three visits because there is no way to jump to it; an array would have read index 2 directly. Two mistakes produce wrong loops: testing `current.Next is not null` instead of `current is not null` skips the last node, and forgetting the `current = current.Next` step never ends.

### chapters/14_arrays_linked_lists/1402_linked_nodes.ipynb cell insert-body expand explanation
+
+The order of the two assignments is the whole technique. Point the new node at the old successor first; only then redirect the current node. Reversing them loses the rest of the list, because the only reference to `C` was `node.Next`, and overwriting it first leaves nothing to copy.

### chapters/14_arrays_linked_lists/1402_linked_nodes.ipynb + new markdown cell after insert-code Insertion interpretation
+ The output is `A`, `B`, `C`. No node moved: `A` still sits where it was, and `C` is reached through `B` now. Trace the reversed order to see the defect: `node.Next = inserted` first makes `A` point at `B`, and then `inserted.Next = node.Next` sets `B.Next` to `B` itself, a loop that drops `C` and never ends when traversed.

### chapters/14_arrays_linked_lists/1402_linked_nodes.ipynb cell delete-body expand explanation
+
+The method returns `false` when there is nothing after the given node, so the caller can tell "nothing removed" from "removed". Removing the *first* node is different, because no node precedes the head; the Removal, Head, and Tail Invariants section below handles that case.

### chapters/14_arrays_linked_lists/1402_linked_nodes.ipynb + new markdown cell after delete-code Deletion interpretation
+ The output is `A`, `C`. Node `B` still exists for a moment, still pointing at `C`, but nothing points at `B` any more, so it is unreachable and the runtime reclaims it. The only reference that changed is `A.Next`. Contrast this with an array, where removing the middle element means shifting every later element one slot to the left.

### chapters/14_arrays_linked_lists/1403_comparison_lab.ipynb cell array-search-body expand explanation
+
+The example counts visits so the two costs can be compared: a search by value, which must inspect elements until it finds the target, and a read by index, which needs no visits at all.

### chapters/14_arrays_linked_lists/1403_comparison_lab.ipynb + new markdown cell after array-search-code Array search interpretation
+ The output is `Found 15 at index 4 after 5 visits.` and `Direct index values[2] = 19`. The target sits in the last slot, so the scan inspected every element; a missing target would also cost five visits. The direct read is one arithmetic step from the index to the slot, no matter how long the array is. That asymmetry is what the linked version below cannot offer.

### chapters/14_arrays_linked_lists/1403_comparison_lab.ipynb cell linked-search-body expand explanation
+
+The same five values and the same target, stored as a chain of nodes. The visit counter counts how many `Next` references the loop followed before it found the value.

### chapters/14_arrays_linked_lists/1403_comparison_lab.ipynb + new markdown cell after linked-search-code Linked traversal interpretation
+ The output is `Found 15 after 5 node visits.` The search cost matches the array scan exactly, because both inspect values in order. What has no counterpart here is `values[2]`: to reach the third value in the chain the program must follow two references from the head, so a "read by index" is itself a traversal. The costs table in the previous section records this as O(n) for indexed reads.

### chapters/14_arrays_linked_lists/1403_comparison_lab.ipynb cell middle-body expand explanation
+
+The array has four stored values and room for six. Inserting `30` at index 2 means every value from index 2 onward moves one slot to the right, starting from the end so that no value is overwritten before it is copied:
+
+```csharp
+for (int i = count; i > insertIndex; i--)
+    values[i] = values[i - 1];     // shift right, last element first
+values[insertIndex] = newValue;
+count++;
+```

### chapters/14_arrays_linked_lists/1403_comparison_lab.ipynb + new markdown cell after middle-code Middle insertion interpretation
+ The output is `10, 20, 30, 40, 50` with `shifts=2`: the values `40` and `50` each moved one slot. In general an insertion at index `k` shifts `count - k` values, so inserting at the front of a long array is expensive and appending at the end costs nothing. Shifting in the other direction, from `insertIndex` upward, is the classic mistake: it copies `40` over `50` before `50` has been moved, and the array ends up as `10, 20, 30, 40, 40`.

### chapters/13_abstract_data_types/1303_generics.ipynb + new markdown cell after 7d874642 Generic Methods explanation
+ A **generic method** declares one or more *type parameters* in angle brackets after its name and then uses them like ordinary types in its signature and body:
+ 
+ ```csharp
+ static TResult Name<T>(T parameter, ...)   // T stands for a type chosen at each call
+ ```
+ 
+ The caller usually does not write the type argument: the compiler infers `T` from the arguments. `Repeat` below builds an array of `count` copies of `value`, and the same body serves `int` and `string`:

### chapters/13_abstract_data_types/1303_generics.ipynb + new markdown cell after gen03 Generic Methods interpretation
+ The output is `0, 0, 0, 0, 0` and `hi, hi, hi`. For the first call the compiler infers `T` as `int` from the argument `0`, so the method returns `int[]`; for the second it infers `string`. You can name the type argument explicitly, `Repeat<double>(1.5, 2)`, which is required when inference has nothing to go on. The mistake to watch for is mixing types in one call: `Repeat(0, "3")` does not compile because `count` is declared `int`, not `T`.

### chapters/13_abstract_data_types/1303_generics.ipynb + new markdown cell after 6b14ecf2 Generic Classes explanation
+ A **generic class** puts the type parameter on the class instead of a method, so every member can use it. The type argument is chosen once, when an object is created, and fixes the type of that object's contents for its whole life:
+ 
+ ```csharp
+ class Cell<T>
+ {
+     private T value;                      // a field of the chosen type
+     public Cell(T initialValue) { ... }   // the constructor takes that type
+     public T Get() { ... }                // members return and accept it
+ }
+ 
+ Cell<int> score = new Cell<int>(95);      // T is int for this object
+ ```

### chapters/13_abstract_data_types/1303_generics.ipynb + new markdown cell after gen05 Generic Classes interpretation
+ The output is `98` and `Ada`. `score` can only ever hold an `int`: `score.Set("x")` is a compile error, which is the type safety that an `object`-based cell cannot offer. The common mistake is writing `new Cell(95)` without the type argument; unlike a method call, a class has no arguments to infer from, so the compiler asks for `Cell<int>` explicitly. The library's `List<T>`, `Dictionary<TKey, TValue>`, and `Queue<T>` are generic classes of exactly this kind.

### chapters/13_abstract_data_types/1303_generics.ipynb + new markdown cell after gen07 Type Constraints interpretation
+ The output is `7` and `banana`. Without the `where T : IComparable<T>` clause the body does not compile: the compiler cannot assume an arbitrary `T` has `CompareTo`. The constraint is a promise the caller must keep, so `Max(3, 7)` and `Max("apple", "banana")` are accepted while a call with a type that cannot compare itself is rejected at compile time. Strings compare in ordinal order here, so `"Zebra"` would rank before `"apple"`; Chapter 16 returns to ordering policies.

### chapters/13_abstract_data_types/1303_generics.ipynb cell f21cb248 expand explanation
+
+The short implementation below keeps its elements in an array that doubles when full, the dynamic-array idea from Chapter 14, and shows that one class can satisfy `IStack<T>` for every `T` at once:

### chapters/13_abstract_data_types/1303_generics.ipynb + new code cell after f21cb248 Generic Interfaces worked example
+ using System;
+ 
+ IStack<string> tasks = new ArrayStack<string>();
+ tasks.Push("draft"); tasks.Push("review"); tasks.Push("ship");
+ Console.WriteLine($"{tasks.Count} tasks, next is {tasks.Peek()}");
+ while (tasks.Count > 0) Console.WriteLine($"popped {tasks.Pop()}");
+ 
+ interface IStack<T>
+ {
+     int Count { get; }
+     void Push(T item);
+     T Pop();
+     T Peek();
+ }
+ 
+ class ArrayStack<T> : IStack<T>
+ {
+     private T[] items = new T[2];
+     public int Count { get; private set; }
+ 
+     public void Push(T item)
+     {
+         if (Count == items.Length) Array.Resize(ref items, items.Length * 2);
+         items[Count] = item;
+         Count++;
+     }
+ 
+     public T Pop()
+     {
+         if (Count == 0) throw new InvalidOperationException("The stack is empty.");
+         Count--;
+         return items[Count];
+     }
+ 
+     public T Peek()
+     {
+         if (Count == 0) throw new InvalidOperationException("The stack is empty.");
+         return items[Count - 1];
+     }
+ }

### chapters/13_abstract_data_types/1303_generics.ipynb + new markdown cell after f21cb248 Generic Interfaces worked example
+ The output is `3 tasks, next is ship`, then `popped ship`, `popped review`, `popped draft`. The variable is declared as `IStack<string>`, so the code that uses it depends only on the contract; a linked implementation of the same interface could replace `ArrayStack` without changing those lines. Chapter 15 develops both implementations and their costs.

### chapters/06_exceptions_testing/0601_error_handling.ipynb cell 5ed19b49 syntax and explanation
+The statement has three parts, and only the first is required to have company:
-Use `finally` for cleanup (closing resources, resetting state):
+```csharp
+try
+{
+    // statements that might throw
+}
+catch (SpecificException ex)      // runs only if that exception type was thrown
+{
+    // respond to that failure; ex.Message describes it
+}
+catch (AnotherException)          // more catch blocks, most specific first
+{
+}
+finally                           // runs whether or not anything was thrown
+{
+    // cleanup: close resources, reset state
+}
+```
+
+When a statement inside `try` throws, the rest of the `try` block is skipped, the first matching `catch` runs, and then `finally` runs. When nothing throws, the `catch` blocks are skipped and `finally` still runs. The example parses a number; in the browser there is no keyboard, so the cell falls back to the text `12x`, which is not a whole number:

### chapters/06_exceptions_testing/0601_error_handling.ipynb cell b53e50b6 browser-safe input
+using System;
+
+string raw = Console.ReadLine() ?? "12x";   // no keyboard in the browser: use a bad sample
-    Console.Write("Enter a number: ");
-    int value = int.Parse(Console.ReadLine()!);
+    Console.WriteLine($"Parsing '{raw}'");
+    int value = int.Parse(raw);

### chapters/06_exceptions_testing/0601_error_handling.ipynb + new markdown cell after b53e50b6 try/catch interpretation
+ The output is `Parsing '12x'`, `Input must be a whole number.`, and `Input attempt complete.` The line `You entered ...` never printed, because `int.Parse` threw before reaching it. Change the sample to `"2147483648"` and the second `catch` runs instead, since that value is one more than `int` can hold; change it to `"42"` and no `catch` runs at all, but `finally` still prints. Two mistakes: putting a `catch (Exception)` block *before* the specific ones, which the compiler rejects because the later blocks could never run, and putting cleanup only at the end of the `try` block, where a thrown exception skips it.

### chapters/06_exceptions_testing/0601_error_handling.ipynb cell 79da984f syntax and explanation
+If invalid input is *expected*, avoid throwing exceptions entirely. `TryParse` reports success as a `bool` and delivers the parsed value through an `out` parameter, the mechanism Chapter 5 introduced:
-If invalid input is *expected*, avoid throwing exceptions entirely:
+```csharp
+if (int.TryParse(text, out int value))   // true and value set when text is a whole number
+{
+    // use value
+}
+```
+
+The `out` variable is declared inside the condition and is available afterward. In the browser the cell falls back to the sample `41`:

### chapters/06_exceptions_testing/0601_error_handling.ipynb cell d00bac38 browser-safe input
-Console.Write("Enter age: ");
-string raw = Console.ReadLine() ?? "";
+using System;
+
+string raw = Console.ReadLine() ?? "41";    // no keyboard in the browser: use a sample

### chapters/06_exceptions_testing/0601_error_handling.ipynb + new markdown cell after d00bac38 TryParse interpretation
+ The output is `Age recorded: 41`. With the sample `"forty"` the first condition is false and the message prints; with `"-3"` parsing succeeds but the second condition fails, so the same message prints. No exception is created in either case, which is cheaper and reads as ordinary decision logic. The mistake to avoid is using `age` after `TryParse` returned false: it is set to `0` then, and `0` is a plausible age.

### chapters/06_exceptions_testing/0601_error_handling.ipynb cell b7dba66b explanation
-
-Catch specific exception types before broad ones:
+File operations fail for reasons outside the program's control, so they are the classic place for `try`. The `using` declaration disposes the reader when the block ends, whether normally or by an exception, which is why no `finally` is needed for the file itself. Catch blocks are listed most specific first: `FileNotFoundException` and `UnauthorizedAccessException` are both kinds of `IOException`, so the general one comes last. In the browser `scores.txt` does not exist, which is the case the first `catch` handles:

### chapters/06_exceptions_testing/0601_error_handling.ipynb + new markdown cell after bd8912f5 File I/O interpretation
+ The output is `Could not find file: scores.txt`. Reverse the order and put `catch (IOException ex)` first: the compiler refuses with an error, because the two later blocks could never run. Create the file first with `File.WriteAllText(path, "90\n85")` at the top of the cell and the loop prints the two lines instead; the `catch` blocks are then skipped entirely.

### chapters/06_exceptions_testing/0601_error_handling.ipynb cell b5cdaa50 syntax and explanation
+Throwing is how a method refuses an argument it cannot honor. The statement creates an exception object with a message and hands control to the nearest matching `catch` up the call chain:
-Throw when an API is used incorrectly and execution should stop:
+```csharp
+throw new ArgumentException("why the argument is unacceptable", nameof(parameter));
+```
+
+`nameof(parameter)` records which parameter was wrong without retyping its name as a string. The second call below triggers the throw, and the caller catches it so the cell can finish:

### chapters/06_exceptions_testing/0601_error_handling.ipynb cell 1c51443d catch the intentional throw
+using System;
+
+Console.WriteLine(Divide(10, 2));
+try
+{
+    Console.WriteLine(Divide(10, 0));   // throws before anything is printed
+}
+catch (ArgumentException ex)
+{
+    Console.WriteLine($"Caught: {ex.Message}");
+}
+
-
-Console.WriteLine(Divide(10, 2));   // 5
-Console.WriteLine(Divide(10, 0));   // throws

### chapters/06_exceptions_testing/0601_error_handling.ipynb cell 4bc96ab1 interpretation
-This is better than returning meaningless sentinel values that hide bugs.
+The output is `5` and then `Caught: Denominator cannot be zero. (Parameter 'denominator')`; the runtime appended the parameter name to the message. Returning a sentinel such as `-1` or `double.NaN` instead would let a bad call continue silently and surface as a wrong total somewhere far away, which is harder to trace than an exception thrown at the point of misuse. Throw for arguments the method's contract rules out; use `TryParse`-style results for input that is merely often wrong.

### chapters/06_exceptions_testing/0601_error_handling.ipynb cell ae6ed273 expand explanation
+
+| | Validation | Exception |
+| --- | --- | --- |
+| When | Before the risky operation | When the operation has already failed |
+| Typical trigger | Empty text, negative quantity, missing field | Missing file, lost connection, bug in a called method |
+| Cost | A comparison | Building an exception object and unwinding the stack |
+| Example | `if (int.TryParse(text, out int n) && n >= 0)` | `catch (FileNotFoundException)` |
+
+The two are not rivals: validate what you can predict, and leave `catch` for what you cannot.

### chapters/06_exceptions_testing/0601_error_handling.ipynb cell 9c27b9fe expand mistakes
+- **Catching `Exception` everywhere.** `catch (Exception)` also catches bugs such as `NullReferenceException` and hides them behind a generic message. Catch the types you can actually respond to.
+- **Swallowing exceptions.** An empty `catch { }` makes the failure disappear and the program continue with bad state. At minimum, report what happened.
+- **Using exceptions for normal control flow.** Parsing user input with `try { int.Parse(...) }` throws on every typo; `TryParse` is the right tool when bad input is expected.
+- **Showing stack traces to end users.** The trace helps the developer, not the customer. Log it, and show the user a specific, actionable message as in the table above.
-- Catching `Exception` everywhere and ignoring details
-- Swallowing exceptions without logging or reporting
-- Using exceptions for normal control flow (use `TryParse` instead)
-- Showing stack traces directly to end users
+```csharp
+try { total = int.Parse(text); }
+catch { }                        // mistake: the failure vanishes and total keeps its old value
+```

### chapters/10_classes/1003_class_instance.ipynb + new markdown cell after 2316258ee770 instance state interpretation
+ The output is `Front: 2 items, 7.50` and `Patio: 1 item, 2.00`. The constructor trimmed `" Front "` to `Front`, and the two registers kept separate totals because `Total` and `ItemCount` are instance properties: each `new` created its own pair. Declare them `static` instead and run again: both lines report the combined 9.50 and 3 items, which is the shared-state mistake the explanation warns about.

### chapters/10_classes/1003_class_instance.ipynb + new markdown cell after ff61c2e73f21 public surface interpretation
+ The output is `Rejected negative price.` followed by `1 item, 5.00`. The rejected call changed nothing, because the check runs before either property is updated. Add the line `register.Total = 10m;` before the class and it does not compile: the setter is private, so the only way to change the total from outside is `Add`, which keeps the count in step with it.

### chapters/10_classes/1003_class_instance.ipynb + new markdown cell after e5f595f18018 computed behavior interpretation
+ The output is `0.00`, `5.00`, and `0 items, 0.00`. `Average` is recomputed from the two stored values on every read, so it is correct immediately after `Add` and immediately after `Clear` without any extra bookkeeping. Storing the average as a third property would require every method that changes `Total` or `ItemCount` to update it too, and forgetting once would leave a stale value.

### chapters/11_object_design/1104_nullability.ipynb + new markdown cell after nul02 nullable value interpretation
+ The output is `No score yet.` and `Display: 0`. `int?` is shorthand for `Nullable<int>`, a small wrapper with `HasValue` and `Value`. Reading `score.Value` while `HasValue` is false throws `InvalidOperationException`, so test first or use `??` to supply a default as the second line does. Arithmetic is lifted: `score + 1` is `null` when `score` is `null`, not an error, which can hide a missing value in a total if nobody checks.

### chapters/11_object_design/1104_nullability.ipynb + new markdown cell after nul04 nullable reference interpretation
+ The output is a single empty line: `nick?.Length` evaluates to `null` because `nick` is `null`, and `Console.WriteLine` prints nothing for it. Uncomment the previous line and the compiler issues a warning, not an error; the program still compiles and would throw `NullReferenceException` at that line. Treat the warning as the bug report it is. The `!` operator silences it without fixing anything, which is why Chapter 11 reserves it for cases where the code has already proven the value is present.

### chapters/11_object_design/1104_nullability.ipynb + new markdown cell after nul06 null operators interpretation
+ The output is `(none)`, `default`, and an empty line. `??` chose the fallback because `input` was `null`; `??=` then assigned `"default"` into `input` because it was still `null`, and would have left an existing value alone. `words?.Length` short-circuits the whole expression to `null`, so `len` is `int?`, not `int`: the result of a null-conditional access is always nullable, even when the member itself is not.

### chapters/11_object_design/1104_nullability.ipynb cell f8004066 
-Pattern matching integrates cleanly with nullability:
+A `switch` expression can test for `null` as its first case, then match on properties of a non-null value, with the catch-all `_` last. The compiler knows that `s` is not null in the later arms:

### chapters/11_object_design/1104_nullability.ipynb + new code cell after f8004066 pattern matching worked example
+ using System;
+ 
+ string?[] samples = { null, "", "Ana Diaz" };
+ foreach (string? s in samples)
+ {
+     string result = s switch
+     {
+         null => "(none)",
+         { Length: 0 } => "(empty)",
+         _ => s
+     };
+     Console.WriteLine(result);
+ }

### chapters/11_object_design/1104_nullability.ipynb + new markdown cell after f8004066 pattern matching worked example
+ The output is `(none)`, `(empty)`, and `Ana Diaz`. The `{ Length: 0 }` arm is a property pattern: it only runs for a non-null string whose `Length` is zero, so there is no risk of dereferencing `null` there. Reorder the arms so `_` comes first and the compiler reports that the other arms are unreachable, a useful check that the cases are listed from most to least specific.

### chapters/09_files_text/0903_text_operations.ipynb cell b83b166d syntax and explanation
+Splitting turns one text line into meaningful fields. `Split` takes the separator and returns an array with one string per field, in order:
-Splitting turns one text line into meaningful fields.
+```csharp
+string[] parts = line.Split(',');   // one element per comma-separated field
+```
+
+The three fields of `Ada,98,CS` land at indexes 0, 1, and 2. Note that `parts[1]` is the *text* `"98"`, not a number, until the program converts it:

### chapters/09_files_text/0903_text_operations.ipynb + new markdown cell after 18e0436a split interpretation
+ The output is `Ada`, `98`, and `CS`. Each field is a separate string, and the commas themselves are gone. A line with a different number of commas produces a different array length, which is why the validation step below checks `parts.Length` before indexing.

### chapters/09_files_text/0903_text_operations.ipynb + new markdown cell after eef30e34 trim interpretation
+ The output is `'Ada'`, `'98'`, and `'CS'`, with the quotes showing that the surrounding spaces are gone. `Split` keeps whitespace inside each field, so `" 98 "` would fail `int.TryParse` until it is trimmed; trimming every field once, right after the split, is cheaper than remembering to do it at every use.

### chapters/09_files_text/0903_text_operations.ipynb + new markdown cell after 82b18a5f remove empty interpretation
+ The output is `2`. The option discarded the empty middle field, which is convenient for lines padded with repeated commas but dangerous for records with a fixed field order: `parts[1]` is now `CS`, not the missing score, so a later `parts[2]` throws and `parts[1]` silently names the wrong column. For fixed-format records, keep the empty entries and treat them as missing values instead.

### chapters/09_files_text/0903_text_operations.ipynb cell c4183f7c explanation and syntax
+Replacing text is safe when it cannot destroy information you still need:
-1. Preserve the original text
-2. Create a cleaned copy
-3. Validate the output
-4. Write to a new file first
+1. Preserve the original text. Strings are immutable, so `Replace` already returns a new string; keep the variable that refers to the original.
+2. Create a cleaned copy and work on that.
+3. Validate the output before trusting it, for example by parsing the replaced field.
+4. Write to a new file first, then swap it into place, so a failure part way through leaves the original intact.
+
+```csharp
+string updated = original.Replace(oldText, newText);   // every occurrence; original is unchanged
+```

### chapters/09_files_text/0903_text_operations.ipynb + new markdown cell after 8dc6d75f replace interpretation
+ The output is `original: Score: N/A` and `updated:  Score: 0`. `Replace` is case-sensitive and replaces every occurrence, so `"N/A, N/A"` would become `"0, 0"`. The mistake to avoid is calling `original.Replace(...)` without assigning the result: the original is untouched and the cleaned text is thrown away.

### chapters/09_files_text/0903_text_operations.ipynb cell 3fbf7a9f expand explanation
+
+A parser for one record follows the `TryParse` shape from Chapter 6: it returns `true` with the fields delivered through `out` parameters, or `false` with safe defaults, and it never throws for a malformed line. Three checks guard the three ways a line can be wrong: blank, wrong field count, and a score that is not a number.

### chapters/09_files_text/0903_text_operations.ipynb + new markdown cell after 7f7f6d6b structured lines interpretation
+ The output is `Alice (CS) scored 98`, `Skipped malformed line: 'Bob,abc,Math'`, `Carol (Physics) scored 87`, and `Skipped malformed line: ''`. Bob's line has three fields but `abc` fails the integer parse, so the method returns `false` after having set `name` and `major`; the caller must not use any of the outputs when the result is `false`. Variation: add a fourth field to Alice's line and predict which check rejects it.

### chapters/09_files_text/0903_text_operations.ipynb cell 66b60623a5ba expand explanation
+
+| Need | Text file | Relational database |
+| --- | --- | --- |
+| Read every record once, in order | Natural | Possible, more setup |
+| Find one record by key, often | Scan the file each time | Indexed lookup |
+| Keep two related record sets consistent | Program must enforce it | Constraints enforce it |
+| Several programs updating at once | Risky | Transactions coordinate it |
+| Hand the data to another tool | Universal | Needs an export, often to text |

### chapters/05_methods/0504_strings.ipynb + new markdown cell after 0f87d673 searching interpretation
+ The output is `True`, `True`, `4`, and `-1`. The first two methods answer yes-or-no questions; `IndexOf` answers *where*, and `-1` is its way of saying nowhere. Because `0` is a real position, the common mistake is treating the result as a Boolean: `if (sku.IndexOf("ELEC"))` does not compile, and `if (sku.IndexOf("ELEC") > 0)` wrongly reports a match at the very start as missing. Compare with `>= 0`.

### chapters/05_methods/0504_strings.ipynb cell e0803c92 syntax
+The two forms are:
+
+```csharp
+text.Substring(start, length)   // length characters beginning at index start
+text.Substring(start)           // from start to the end
+```
+

### chapters/05_methods/0504_strings.ipynb + new markdown cell after ad70652a extracting interpretation
+ The output is `Category: ELEC`, `Number:   1042`, and `Color:    BLK`. Each extraction is computed from positions, so it depends on the code's format: a SKU with a five-digit number would make `Substring(dash + 1, 4)` return the wrong text, and a start or length that runs past the end throws `ArgumentOutOfRangeException`. The Guard the Format section below checks the format first for that reason.

### chapters/05_methods/0504_strings.ipynb + new markdown cell after 36b78c09 replacing interpretation
+ The output is `Ship to: 12 Main Street Deliver by Friday` and `Mentions Friday: True`. The two `Replace` calls are chained, each working on the result of the previous one, and `note` itself is unchanged. `Replace` is always case-sensitive, so it would leave `st.` alone; the case-insensitive comparison applies to the search methods, which is why the `Contains` call finds `Friday` from `friday`.

### chapters/09_files_text/0903_text_operations.ipynb cell 7f7f6d6b make standalone
+using System;
+
+
+static bool TryParseStudent(string line, out string name, out int score, out string major)
+{
+    name  = "";
+    major = "";
+    score = 0;
+
+    if (string.IsNullOrWhiteSpace(line)) return false;
+
+    string[] parts = line.Split(',');
+    if (parts.Length != 3) return false;
+
+    name  = parts[0].Trim();
+    major = parts[2].Trim();
+
+    return int.TryParse(parts[1].Trim(), out score);
+}
```
