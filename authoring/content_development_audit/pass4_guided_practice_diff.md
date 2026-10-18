---
orphan: true
---

# Pass 4 diff: guided practices, task text, reflection prompts (2026-10-18)

Cell-level record of every change. Entries marked "new ... cell" were inserted at the stated position; lines starting with - and + are edits to existing cells.

```diff
### chapters/01_context/0101_cs_ideas.ipynb + new markdown cell at 12 Reflection: Describe a System You Use
+ ```{index} Reflection: Describe a System You Use
+ ```
+ 
+ ### Reflection: Describe a System You Use

### chapters/01_context/0101_cs_ideas.ipynb + new markdown cell at 12 Reflection: Describe a System You Use
+ Answer in a few sentences each before moving on; these questions are discussed in class.
+ 
+ 1. Pick one system you used today, such as a campus portal, a payment app, or a streaming service. Name its input, its processing, and its output in one line each.
+ 2. Which of those three parts could fail without you noticing at the time? What would the first visible symptom be?
+ 3. Where does the data come from and where does it go afterward? Name one place it is stored.

### chapters/01_context/0102_computing_responsibility.ipynb + new markdown cell at 8 Reflection: Map the Stakeholders of One Feature
+ ```{index} Reflection: Map the Stakeholders of One Feature
+ ```
+ 
+ ### Reflection: Map the Stakeholders of One Feature

### chapters/01_context/0102_computing_responsibility.ipynb + new markdown cell at 8 Reflection: Map the Stakeholders of One Feature
+ Take the appointment-reminder example from this chapter, or a feature from a system you know, and write short answers.
+ 
+ 1. List every group the feature touches: the people it is for, the people who run it, and anyone affected without using it.
+ 2. For each group, name one way the feature could cause harm if it worked exactly as specified.
+ 3. Which harm would be hardest for the affected person to detect or contest? What would the developer need to add so that it could be noticed and corrected?

### chapters/06_exceptions_testing/0605_software_responsibility.ipynb + new markdown cell at 17 Reflection: Apply the Questions to a Small Defect
+ ```{index} Reflection: Apply the Questions to a Small Defect
+ ```
+ 
+ ### Reflection: Apply the Questions to a Small Defect

### chapters/06_exceptions_testing/0605_software_responsibility.ipynb + new markdown cell at 17 Reflection: Apply the Questions to a Small Defect
+ Take the small-defect-at-scale example from earlier on this page and work through the questions above.
+ 
+ 1. Who is affected, and how would each group find out that the defect exists?
+ 2. What is the smallest change that would make the defect visible before release? Is it a test, a review step, or a message to a user?
+ 3. If you discovered the defect after release, what would you tell, and to whom, in the first hour?

### chapters/02_var_data/0201_variables_types.ipynb + new markdown cell at 32 Guided Practice: Swap Two Prices
+ ```{index} Guided Practice: Swap Two Prices
+ ```
+ 
+ ### Guided Practice: Swap Two Prices

### chapters/02_var_data/0201_variables_types.ipynb + new markdown cell at 32 Guided Practice: Swap Two Prices
+ Two prices were entered in the wrong variables. Swap them using a third variable so the output is `regular=120, sale=95`. Predict what happens if you write `regular = sale;` first without saving the old value.

### chapters/02_var_data/0201_variables_types.ipynb + new code cell at 32 Guided Practice: Swap Two Prices
+ using System;
+ 
+ int regular = 95;
+ int sale = 120;
+ 
+ // Your code starts here.
+ // Swap the two values using a temporary variable.
+ // Your code ends here.
+ 
+ Console.WriteLine($"regular={regular}, sale={sale}");

### chapters/02_var_data/0201_variables_types.ipynb + new code cell at 32 Guided Practice: Swap Two Prices
+ using System;
+ 
+ // Solution
+ int regular = 95;
+ int sale = 120;
+ 
+ int saved = regular;   // keep the old value before it is overwritten
+ regular = sale;
+ sale = saved;
+ 
+ Console.WriteLine($"regular={regular}, sale={sale}");

### chapters/02_var_data/0201_variables_types.ipynb + new markdown cell at 32 Guided Practice: Swap Two Prices
+ Without the temporary variable, `regular = sale;` destroys the only copy of 95, and both variables end up holding 120. An assignment copies a value into a box; it does not remember what the box held before.

### chapters/02_var_data/0203_input_output.ipynb + new markdown cell at 54 Guided Practice: Format an Order Line
+ ```{index} Guided Practice: Format an Order Line
+ ```
+ 
+ ### Guided Practice: Format an Order Line

### chapters/02_var_data/0203_input_output.ipynb + new markdown cell at 54 Guided Practice: Format an Order Line
+ Print one order line with composite formatting so the output is exactly `Stapler x3 @ $4.25 = $12.75`. Use `{2:F2}` style specifiers for the two money values and compute the total in the argument list.

### chapters/02_var_data/0203_input_output.ipynb + new code cell at 54 Guided Practice: Format an Order Line
+ using System;
+ 
+ string item = "Stapler";
+ int quantity = 3;
+ decimal price = 4.25m;
+ 
+ // Your code starts here.
+ Console.WriteLine("{0} x{1}", item, quantity);
+ // Your code ends here.

### chapters/02_var_data/0203_input_output.ipynb + new code cell at 54 Guided Practice: Format an Order Line
+ using System;
+ 
+ // Solution
+ string item = "Stapler";
+ int quantity = 3;
+ decimal price = 4.25m;
+ 
+ Console.WriteLine("{0} x{1} @ ${2:F2} = ${3:F2}", item, quantity, price, quantity * price);

### chapters/02_var_data/0203_input_output.ipynb + new markdown cell at 54 Guided Practice: Format an Order Line
+ The placeholders are numbered by position in the argument list, so `{3:F2}` formats the fourth argument, the computed total, with two decimals. Rewrite the same line with string interpolation after reading the next section and compare which is easier to read.

### chapters/03_decision/0301_intro_decision.ipynb + new markdown cell at 16 Guided Practice: Decide Free Shipping
+ ```{index} Guided Practice: Decide Free Shipping
+ ```
+ 
+ ### Guided Practice: Decide Free Shipping

### chapters/03_decision/0301_intro_decision.ipynb + new markdown cell at 16 Guided Practice: Decide Free Shipping
+ An order ships free when its total is at least 50 and it is not international. Write the Boolean expression so the two printed lines are `True` and `False`.

### chapters/03_decision/0301_intro_decision.ipynb + new code cell at 16 Guided Practice: Decide Free Shipping
+ using System;
+ 
+ decimal total = 64.00m;
+ bool international = false;
+ 
+ // Your code starts here.
+ bool freeShipping = false;
+ // Your code ends here.
+ 
+ Console.WriteLine(freeShipping);
+ international = true;
+ Console.WriteLine(total >= 50m && !international);

### chapters/03_decision/0301_intro_decision.ipynb + new code cell at 16 Guided Practice: Decide Free Shipping
+ using System;
+ 
+ // Solution
+ decimal total = 64.00m;
+ bool international = false;
+ 
+ bool freeShipping = total >= 50m && !international;
+ 
+ Console.WriteLine(freeShipping);
+ international = true;
+ Console.WriteLine(total >= 50m && !international);

### chapters/03_decision/0301_intro_decision.ipynb + new markdown cell at 16 Guided Practice: Decide Free Shipping
+ A Boolean expression is a value you can store, print, or test later; it does not need an `if` around it. Change the total to 49.99 and predict both lines before running again.

### chapters/04_iteration/0401_iteration.ipynb + new markdown cell at 17 Guided Practice: Count Down by Twos
+ ```{index} Guided Practice: Count Down by Twos
+ ```
+ 
+ ### Guided Practice: Count Down by Twos

### chapters/04_iteration/0401_iteration.ipynb + new markdown cell at 17 Guided Practice: Count Down by Twos
+ Change the step so the loop prints `10 8 6 4 2`. The starter counts down by one; only the third part of the header should change.

### chapters/04_iteration/0401_iteration.ipynb + new code cell at 17 Guided Practice: Count Down by Twos
+ using System;
+ 
+ for (int i = 10; i >= 2; i = i - 1)   // Your code starts here: fix the step.
+ {
+     Console.Write(i + " ");
+ }
+ Console.WriteLine();

### chapters/04_iteration/0401_iteration.ipynb + new code cell at 17 Guided Practice: Count Down by Twos
+ using System;
+ 
+ // Solution
+ for (int i = 10; i >= 2; i = i - 2)
+ {
+     Console.Write(i + " ");
+ }
+ Console.WriteLine();

### chapters/04_iteration/0401_iteration.ipynb + new markdown cell at 17 Guided Practice: Count Down by Twos
+ The step runs after every iteration, so `i = i - 2` visits 10, 8, 6, 4, 2 and stops when 0 fails the test `i >= 2`. Writing `i = i - 2` as `i -= 2` is the same statement; the next section covers that shorthand.

### chapters/04_iteration/0404_gcd.ipynb + new markdown cell at 25 Guided Practice: Count the Remainder Steps
+ ```{index} Guided Practice: Count the Remainder Steps
+ ```
+ 
+ ### Guided Practice: Count the Remainder Steps

### chapters/04_iteration/0404_gcd.ipynb + new markdown cell at 25 Guided Practice: Count the Remainder Steps
+ Add a counter to the remainder loop so the output is `GCD 81 after 2 steps` for 810 and 729. Then try 10 and 15, and explain why the first step only swaps the two values.

### chapters/04_iteration/0404_gcd.ipynb + new code cell at 25 Guided Practice: Count the Remainder Steps
+ using System;
+ 
+ int a = 810, b = 729;
+ int steps = 0;
+ while (b != 0)
+ {
+     int remainder = a % b;
+     a = b;
+     b = remainder;
+     // Your code starts here.
+     // Count this step.
+     // Your code ends here.
+ }
+ Console.WriteLine($"GCD {a} after {steps} steps");

### chapters/04_iteration/0404_gcd.ipynb + new code cell at 25 Guided Practice: Count the Remainder Steps
+ using System;
+ 
+ // Solution
+ int a = 810, b = 729;
+ int steps = 0;
+ while (b != 0)
+ {
+     int remainder = a % b;
+     a = b;
+     b = remainder;
+     steps++;
+ }
+ Console.WriteLine($"GCD {a} after {steps} steps");

### chapters/04_iteration/0404_gcd.ipynb + new markdown cell at 25 Guided Practice: Count the Remainder Steps
+ Two steps against 729 trial divisions and 9 subtractions on the same input. For 10 and 15 the first remainder is `10 % 15 = 10`, so the step produces `a = 15, b = 10`: a swap that costs one iteration and then proceeds normally.

### chapters/09_files_text/0901_stream_file.ipynb + new markdown cell at 32 Guided Practice: Write a Receipt and Read It Back
+ ```{index} Guided Practice: Write a Receipt and Read It Back
+ ```
+ 
+ ### Guided Practice: Write a Receipt and Read It Back

### chapters/09_files_text/0901_stream_file.ipynb + new markdown cell at 32 Guided Practice: Write a Receipt and Read It Back
+ The starter writes three receipt lines and then reads the file back, but it reports `Lines read: 0`. Find the missing call, add it, and confirm the output becomes three lines followed by `Lines read: 3`. The file is created in a temporary location and removed at the end.

### chapters/09_files_text/0901_stream_file.ipynb + new code cell at 32 Guided Practice: Write a Receipt and Read It Back
+ using System;
+ using System.IO;
+ 
+ string path = Path.Combine(Path.GetTempPath(), "cscs_receipt_" + Guid.NewGuid().ToString("N") + ".txt");
+ 
+ StreamWriter writer = new StreamWriter(path);
+ writer.WriteLine("Stapler      4.25");
+ writer.WriteLine("Paper        6.50");
+ writer.WriteLine("Total       10.75");
+ // Your code starts here.
+ // Something is missing before the file is read.
+ // Your code ends here.
+ 
+ int lines = 0;
+ StreamReader reader = new StreamReader(path);
+ while (!reader.EndOfStream)
+ {
+     Console.WriteLine(reader.ReadLine());
+     lines++;
+ }
+ reader.Close();
+ Console.WriteLine($"Lines read: {lines}");
+ File.Delete(path);

### chapters/09_files_text/0901_stream_file.ipynb + new code cell at 32 Guided Practice: Write a Receipt and Read It Back
+ using System;
+ using System.IO;
+ 
+ // Solution
+ string path = Path.Combine(Path.GetTempPath(), "cscs_receipt_" + Guid.NewGuid().ToString("N") + ".txt");
+ 
+ StreamWriter writer = new StreamWriter(path);
+ writer.WriteLine("Stapler      4.25");
+ writer.WriteLine("Paper        6.50");
+ writer.WriteLine("Total       10.75");
+ writer.Close();           // flushes the buffer and releases the file
+ 
+ int lines = 0;
+ StreamReader reader = new StreamReader(path);
+ while (!reader.EndOfStream)
+ {
+     Console.WriteLine(reader.ReadLine());
+     lines++;
+ }
+ reader.Close();
+ Console.WriteLine($"Lines read: {lines}");
+ File.Delete(path);

### chapters/09_files_text/0901_stream_file.ipynb + new markdown cell at 32 Guided Practice: Write a Receipt and Read It Back
+ Without `Close`, the three lines sit in the writer's buffer and the file on disk is still empty when the reader opens it; on some systems the open fails outright because the writer still holds the file. This is the forgotten-close bug the warning above describes, now seen from the reader's side.

### chapters/09_files_text/0905_privacy_security.ipynb + new markdown cell at 14 Guided Practice: Mask a Card Number
+ ```{index} Guided Practice: Mask a Card Number
+ ```
+ 
+ ### Guided Practice: Mask a Card Number

### chapters/09_files_text/0905_privacy_security.ipynb + new markdown cell at 14 Guided Practice: Mask a Card Number
+ Complete `MaskCard` so that only the last four digits remain visible: `4111111111111234` becomes `**** **** **** 1234`. A number shorter than four digits should return `(invalid card)`.

### chapters/09_files_text/0905_privacy_security.ipynb + new code cell at 14 Guided Practice: Mask a Card Number
+ using System;
+ 
+ Console.WriteLine(MaskCard("4111111111111234"));
+ Console.WriteLine(MaskCard("123"));
+ 
+ static string MaskCard(string number)
+ {
+     // Your code starts here.
+     return number;
+     // Your code ends here.
+ }

### chapters/09_files_text/0905_privacy_security.ipynb + new code cell at 14 Guided Practice: Mask a Card Number
+ using System;
+ 
+ // Solution
+ Console.WriteLine(MaskCard("4111111111111234"));
+ Console.WriteLine(MaskCard("123"));
+ 
+ static string MaskCard(string number)
+ {
+     if (number.Length < 4)
+     {
+         return "(invalid card)";
+     }
+     return "**** **** **** " + number.Substring(number.Length - 4);
+ }

### chapters/09_files_text/0905_privacy_security.ipynb + new markdown cell at 14 Guided Practice: Mask a Card Number
+ The mask never stores or prints the hidden digits, so a log line built from `MaskCard` cannot leak them. Compare with `MaskEmail` above: both keep just enough to recognize the record and nothing that identifies the account.

### chapters/12_oop/1204_oop_examples.ipynb + new markdown cell at 13 Guided Practice: Add a Truck
+ ```{index} Guided Practice: Add a Truck
+ ```
+ 
+ ### Guided Practice: Add a Truck

### chapters/12_oop/1204_oop_examples.ipynb + new markdown cell at 13 Guided Practice: Add a Truck
+ Add a `Truck` class that inherits from `Vehicle`, gives it a `CapacityKg` field of 1500, and make the output `Ford 1500` followed by `Tuut, tuut!`. The starter's `Truck` does not inherit anything yet, so `Brand` and `Honk` are not available on it.

### chapters/12_oop/1204_oop_examples.ipynb + new code cell at 13 Guided Practice: Add a Truck
+ using System;
+ 
+ Truck truck = new Truck();
+ Console.WriteLine(truck.CapacityKg);
+ 
+ class Vehicle
+ {
+     public string Brand = "Ford";
+     public void Honk() { Console.WriteLine("Tuut, tuut!"); }
+ }
+ 
+ // Your code starts here.
+ class Truck
+ {
+     public int CapacityKg = 0;
+ }
+ // Your code ends here.

### chapters/12_oop/1204_oop_examples.ipynb + new code cell at 13 Guided Practice: Add a Truck
+ using System;
+ 
+ // Solution
+ Truck truck = new Truck();
+ Console.WriteLine(truck.Brand + " " + truck.CapacityKg);
+ truck.Honk();
+ 
+ class Vehicle
+ {
+     public string Brand = "Ford";
+     public void Honk() { Console.WriteLine("Tuut, tuut!"); }
+ }
+ 
+ class Truck : Vehicle
+ {
+     public int CapacityKg = 1500;
+ }

### chapters/12_oop/1204_oop_examples.ipynb + new markdown cell at 13 Guided Practice: Add a Truck
+ The colon in `class Truck : Vehicle` is what makes `Brand` and `Honk` members of every `Truck`; the derived class adds `CapacityKg` without repeating anything the base class already has.

### chapters/14_arrays_linked_lists/1403_comparison_lab.ipynb + new markdown cell at 16 Guided Practice: Count the Deletion Shifts
+ ```{index} Guided Practice: Count the Deletion Shifts
+ ```
+ 
+ ### Guided Practice: Count the Deletion Shifts

### chapters/14_arrays_linked_lists/1403_comparison_lab.ipynb + new markdown cell at 16 Guided Practice: Count the Deletion Shifts
+ Remove the value at index 1 from an array holding five values by shifting the later values left, and count the shifts. Expected output: `removed 20`, then `10, 30, 40, 50`, then `shifts=3`.

### chapters/14_arrays_linked_lists/1403_comparison_lab.ipynb + new code cell at 16 Guided Practice: Count the Deletion Shifts
+ using System;
+ 
+ int[] values = { 10, 20, 30, 40, 50 };
+ int count = 5;
+ int removeIndex = 1;
+ int shifts = 0;
+ 
+ int removed = values[removeIndex];
+ // Your code starts here.
+ // Shift every later value one slot to the left, counting each move.
+ // Your code ends here.
+ count--;
+ 
+ Console.WriteLine($"removed {removed}");
+ Console.WriteLine(string.Join(", ", values[..count]));
+ Console.WriteLine($"shifts={shifts}");

### chapters/14_arrays_linked_lists/1403_comparison_lab.ipynb + new code cell at 16 Guided Practice: Count the Deletion Shifts
+ using System;
+ 
+ // Solution
+ int[] values = { 10, 20, 30, 40, 50 };
+ int count = 5;
+ int removeIndex = 1;
+ int shifts = 0;
+ 
+ int removed = values[removeIndex];
+ for (int i = removeIndex; i < count - 1; i++)
+ {
+     values[i] = values[i + 1];     // shift left, first element first
+     shifts++;
+ }
+ count--;
+ 
+ Console.WriteLine($"removed {removed}");
+ Console.WriteLine(string.Join(", ", values[..count]));
+ Console.WriteLine($"shifts={shifts}");

### chapters/14_arrays_linked_lists/1403_comparison_lab.ipynb + new markdown cell at 16 Guided Practice: Count the Deletion Shifts
+ Deletion shifts left and starts at the gap, the mirror image of insertion, which shifts right and starts at the end. Both move `count - index` values, so the costs table's O(n) for middle updates applies to each.

### chapters/02_var_data/0202_operators_built_in_methods.ipynb + new markdown cell at 60 Guided Practice: Split a Bill
+ ```{index} Guided Practice: Split a Bill
+ ```
+ 
+ ### Guided Practice: Split a Bill

### chapters/02_var_data/0202_operators_built_in_methods.ipynb + new markdown cell at 60 Guided Practice: Split a Bill
+ Four colleagues share a bill of 47 dollars in whole dollars. Use integer division and the remainder operator so the output is `each pays 11, 3 left over`.

### chapters/02_var_data/0202_operators_built_in_methods.ipynb + new code cell at 60 Guided Practice: Split a Bill
+ using System;
+ 
+ int total = 47;
+ int people = 4;
+ 
+ // Your code starts here.
+ int each = 0;
+ int leftOver = 0;
+ // Your code ends here.
+ 
+ Console.WriteLine($"each pays {each}, {leftOver} left over");

### chapters/02_var_data/0202_operators_built_in_methods.ipynb + new code cell at 60 Guided Practice: Split a Bill
+ using System;
+ 
+ // Solution
+ int total = 47;
+ int people = 4;
+ 
+ int each = total / people;       // integer division truncates
+ int leftOver = total % people;   // the remainder
+ 
+ Console.WriteLine($"each pays {each}, {leftOver} left over");

### chapters/02_var_data/0202_operators_built_in_methods.ipynb + new markdown cell at 60 Guided Practice: Split a Bill
+ `47 / 4` is 11 because both operands are `int`; the remainder operator recovers the 3 that division dropped. Change `total` to `47.0` and the division produces 11.75 instead, which is why the types of the operands, not the operator, decide what kind of division happens.

### chapters/04_iteration/0402_for_statements.ipynb + new markdown cell at 20 Guided Practice: Find the First Space
+ ```{index} Guided Practice: Find the First Space
+ ```
+ 
+ ### Guided Practice: Find the First Space

### chapters/04_iteration/0402_for_statements.ipynb + new markdown cell at 20 Guided Practice: Find the First Space
+ Scan the text and stop at the first space, printing its index. Expected output: `First space at 5`. Keep the `break` so the loop does not keep scanning after the match.

### chapters/04_iteration/0402_for_statements.ipynb + new code cell at 20 Guided Practice: Find the First Space
+ using System;
+ 
+ string text = "Order 204 ready";
+ int spaceIndex = -1;
+ 
+ for (int i = 0; i < text.Length; i++)
+ {
+     // Your code starts here.
+     // Record i and leave the loop when text[i] is a space.
+     // Your code ends here.
+ }
+ 
+ Console.WriteLine($"First space at {spaceIndex}");

### chapters/04_iteration/0402_for_statements.ipynb + new code cell at 20 Guided Practice: Find the First Space
+ using System;
+ 
+ // Solution
+ string text = "Order 204 ready";
+ int spaceIndex = -1;
+ 
+ for (int i = 0; i < text.Length; i++)
+ {
+     if (text[i] == ' ')
+     {
+         spaceIndex = i;
+         break;
+     }
+ }
+ 
+ Console.WriteLine($"First space at {spaceIndex}");

### chapters/04_iteration/0402_for_statements.ipynb + new markdown cell at 20 Guided Practice: Find the First Space
+ Without the `break`, the loop would keep going and record the *last* space, index 9, instead of the first. `-1` remains in `spaceIndex` when the text has no space, the same convention `IndexOf` uses.

### chapters/04_iteration/0403_while_statement.ipynb + new markdown cell at 45 Guided Practice: Years to Double an Investment
+ ```{index} Guided Practice: Years to Double an Investment
+ ```
+ 
+ ### Guided Practice: Years to Double an Investment

### chapters/04_iteration/0403_while_statement.ipynb + new markdown cell at 45 Guided Practice: Years to Double an Investment
+ An account grows 7 percent a year. Count the years until 100 dollars has more than doubled. The starter's condition is wrong, so the loop never runs; fix it so the output is `11 years, 210.49`.

### chapters/04_iteration/0403_while_statement.ipynb + new code cell at 45 Guided Practice: Years to Double an Investment
+ using System;
+ 
+ double amount = 100.0;
+ int years = 0;
+ 
+ while (amount < 100.0)   // Your code starts here: fix the condition.
+ {
+     amount = amount * 1.07;
+     years++;
+ }
+ 
+ Console.WriteLine($"{years} years, {amount:F2}");

### chapters/04_iteration/0403_while_statement.ipynb + new code cell at 45 Guided Practice: Years to Double an Investment
+ using System;
+ 
+ // Solution
+ double amount = 100.0;
+ int years = 0;
+ 
+ while (amount <= 200.0)
+ {
+     amount = amount * 1.07;
+     years++;
+ }
+ 
+ Console.WriteLine($"{years} years, {amount:F2}");

### chapters/04_iteration/0403_while_statement.ipynb + new markdown cell at 45 Guided Practice: Years to Double an Investment
+ A `while` loop tests its condition before every pass, including the first; a condition that is already false runs the body zero times, which is what the starter did. The condition `amount <= 200.0` keeps going exactly until the amount passes 200.

### chapters/05_methods/0504_strings.ipynb + new markdown cell at 14 Guided Practice: Normalize a Product Code
+ ```{index} Guided Practice: Normalize a Product Code
+ ```
+ 
+ ### Guided Practice: Normalize a Product Code

### chapters/05_methods/0504_strings.ipynb + new markdown cell at 14 Guided Practice: Normalize a Product Code
+ Codes are typed with stray spaces and in any case. Clean `" sku-1042 "` so the output is `[SKU-1042]`. The starter changes the case but leaves the spaces.

### chapters/05_methods/0504_strings.ipynb + new code cell at 14 Guided Practice: Normalize a Product Code
+ using System;
+ 
+ string typed = " sku-1042 ";
+ 
+ // Your code starts here.
+ string code = typed.ToUpper();
+ // Your code ends here.
+ 
+ Console.WriteLine($"[{code}]");

### chapters/05_methods/0504_strings.ipynb + new code cell at 14 Guided Practice: Normalize a Product Code
+ using System;
+ 
+ // Solution
+ string typed = " sku-1042 ";
+ 
+ string code = typed.Trim().ToUpper();
+ 
+ Console.WriteLine($"[{code}]");

### chapters/05_methods/0504_strings.ipynb + new markdown cell at 14 Guided Practice: Normalize a Product Code
+ The calls are chained: `Trim` returns a new string without the spaces, and `ToUpper` is called on that result. Neither call changes `typed`, which still holds the original text with its spaces.

### chapters/05_methods/0506_recursive_methods.ipynb + new markdown cell at 9 Guided Practice: Count Up Instead
+ ```{index} Guided Practice: Count Up Instead
+ ```
+ 
+ ### Guided Practice: Count Up Instead

### chapters/05_methods/0506_recursive_methods.ipynb + new markdown cell at 9 Guided Practice: Count Up Instead
+ Make the method print `1 2 3` instead of `3 2 1` by moving one statement. Nothing else changes: the base case and the recursive call stay where they are.

### chapters/05_methods/0506_recursive_methods.ipynb + new code cell at 9 Guided Practice: Count Up Instead
+ using System;
+ 
+ CountUp(3);
+ Console.WriteLine();
+ 
+ static void CountUp(int n)
+ {
+     if (n == 0) return;
+     // Your code starts here.
+     Console.Write(n + " ");
+     CountUp(n - 1);
+     // Your code ends here.
+ }

### chapters/05_methods/0506_recursive_methods.ipynb + new code cell at 9 Guided Practice: Count Up Instead
+ using System;
+ 
+ // Solution
+ CountUp(3);
+ Console.WriteLine();
+ 
+ static void CountUp(int n)
+ {
+     if (n == 0) return;
+     CountUp(n - 1);           // first let the smaller calls print
+     Console.Write(n + " ");  // then print this call's number
+ }

### chapters/05_methods/0506_recursive_methods.ipynb + new markdown cell at 9 Guided Practice: Count Up Instead
+ Printing after the recursive call means the deepest call, `CountUp(1)`, prints first, because every outer call is still waiting on the stack for its inner call to return. Work done before the call happens on the way down; work done after it happens on the way back up.

### chapters/08_collections/0802_list.ipynb + new markdown cell at 14 Guided Practice: Insert and Remove by Position
+ ```{index} Guided Practice: Insert and Remove by Position
+ ```
+ 
+ ### Guided Practice: Insert and Remove by Position

### chapters/08_collections/0802_list.ipynb + new markdown cell at 14 Guided Practice: Insert and Remove by Position
+ Starting from `10, 20, 30`, insert `15` at index 1 and then remove the element at index 0 so the output is `15, 20, 30` with a count of 3.

### chapters/08_collections/0802_list.ipynb + new code cell at 14 Guided Practice: Insert and Remove by Position
+ using System;
+ using System.Collections.Generic;
+ 
+ List<int> numbers = new List<int> { 10, 20, 30 };
+ 
+ // Your code starts here.
+ // Insert 15 at index 1, then remove the element at index 0.
+ // Your code ends here.
+ 
+ Console.WriteLine(string.Join(", ", numbers));
+ Console.WriteLine(numbers.Count);

### chapters/08_collections/0802_list.ipynb + new code cell at 14 Guided Practice: Insert and Remove by Position
+ using System;
+ using System.Collections.Generic;
+ 
+ // Solution
+ List<int> numbers = new List<int> { 10, 20, 30 };
+ 
+ numbers.Insert(1, 15);   // 10, 15, 20, 30
+ numbers.RemoveAt(0);     // 15, 20, 30
+ 
+ Console.WriteLine(string.Join(", ", numbers));
+ Console.WriteLine(numbers.Count);

### chapters/08_collections/0802_list.ipynb + new markdown cell at 14 Guided Practice: Insert and Remove by Position
+ Unlike an array, the list's `Count` changed twice, up to 4 and back to 3, and the list did the shifting itself. `RemoveAt(0)` takes an index; `Remove(10)` would take a value, and the two are easy to confuse when the values are small integers.

### chapters/14_arrays_linked_lists/1401_dynamic_arrays.ipynb + new markdown cell at 11 Guided Practice: Append with Growth
+ ```{index} Guided Practice: Append with Growth
+ ```
+ 
+ ### Guided Practice: Append with Growth

### chapters/14_arrays_linked_lists/1401_dynamic_arrays.ipynb + new markdown cell at 11 Guided Practice: Append with Growth
+ Append seven values into storage that starts with capacity 2. The starter throws `IndexOutOfRangeException` at the third append because it never grows; add the growth check so the output is `count=7, capacity=8`.

### chapters/14_arrays_linked_lists/1401_dynamic_arrays.ipynb + new code cell at 11 Guided Practice: Append with Growth
+ using System;
+ 
+ int[] storage = new int[2];
+ int count = 0;
+ 
+ for (int value = 10; value <= 70; value += 10)
+ {
+     // Your code starts here.
+     // If storage is full, replace it with a copy of double the length.
+     // Your code ends here.
+     storage[count] = value;
+     count++;
+ }
+ 
+ Console.WriteLine($"count={count}, capacity={storage.Length}");

### chapters/14_arrays_linked_lists/1401_dynamic_arrays.ipynb + new code cell at 11 Guided Practice: Append with Growth
+ using System;
+ 
+ // Solution
+ int[] storage = new int[2];
+ int count = 0;
+ 
+ for (int value = 10; value <= 70; value += 10)
+ {
+     if (count == storage.Length)
+     {
+         int[] larger = new int[storage.Length * 2];
+         Array.Copy(storage, larger, count);
+         storage = larger;        // the variable must refer to the new array
+     }
+     storage[count] = value;
+     count++;
+ }
+ 
+ Console.WriteLine($"count={count}, capacity={storage.Length}");

### chapters/14_arrays_linked_lists/1401_dynamic_arrays.ipynb + new markdown cell at 11 Guided Practice: Append with Growth
+ Capacity went 2, 4, 8, with a copy at the third and fifth appends. Leave out the line `storage = larger;` and the program still throws at the third append: the copy was made, but the loop kept writing into the old array.

### chapters/14_arrays_linked_lists/1402_linked_nodes.ipynb + new markdown cell at 12 Guided Practice: Count the Nodes
+ ```{index} Guided Practice: Count the Nodes
+ ```
+ 
+ ### Guided Practice: Count the Nodes

### chapters/14_arrays_linked_lists/1402_linked_nodes.ipynb + new markdown cell at 12 Guided Practice: Count the Nodes
+ Complete `Count` with the traversal loop so the output is `3`, and make sure an empty list (`null`) returns `0` without throwing.

### chapters/14_arrays_linked_lists/1402_linked_nodes.ipynb + new code cell at 12 Guided Practice: Count the Nodes
+ using System;
+ 
+ CountNode<string> head = new CountNode<string>("alpha");
+ head.Next = new CountNode<string>("beta");
+ head.Next.Next = new CountNode<string>("gamma");
+ 
+ Console.WriteLine(Count(head));
+ Console.WriteLine(Count<string>(null));   // no argument to infer T from, so name it
+ 
+ static int Count<T>(CountNode<T>? head)
+ {
+     // Your code starts here.
+     return 0;
+     // Your code ends here.
+ }
+ 
+ public class CountNode<T>
+ {
+     public T Value { get; }
+     public CountNode<T>? Next { get; set; }
+     public CountNode(T value) => Value = value;
+ }

### chapters/14_arrays_linked_lists/1402_linked_nodes.ipynb + new code cell at 12 Guided Practice: Count the Nodes
+ using System;
+ 
+ // Solution
+ CountNode<string> head = new CountNode<string>("alpha");
+ head.Next = new CountNode<string>("beta");
+ head.Next.Next = new CountNode<string>("gamma");
+ 
+ Console.WriteLine(Count(head));
+ Console.WriteLine(Count<string>(null));   // no argument to infer T from, so name it
+ 
+ static int Count<T>(CountNode<T>? head)
+ {
+     int count = 0;
+     for (CountNode<T>? current = head; current is not null; current = current.Next)
+     {
+         count++;
+     }
+     return count;
+ }
+ 
+ public class CountNode<T>
+ {
+     public T Value { get; }
+     public CountNode<T>? Next { get; set; }
+     public CountNode(T value) => Value = value;
+ }

### chapters/14_arrays_linked_lists/1402_linked_nodes.ipynb + new markdown cell at 12 Guided Practice: Count the Nodes
+ The loop handles the empty list for free: `current` starts as `null`, the condition fails at once, and `count` stays 0. A list keeps no stored count unless its class maintains one, which is why Chapter 14's complete sequence class tracks `Count` on every insert and delete.

### chapters/15_stacks_queues/1501_stack.ipynb + new markdown cell at 11 Guided Practice: Undo Past the Beginning
+ ```{index} Guided Practice: Undo Past the Beginning
+ ```
+ 
+ ### Guided Practice: Undo Past the Beginning

### chapters/15_stacks_queues/1501_stack.ipynb + new markdown cell at 11 Guided Practice: Undo Past the Beginning
+ The history holds two actions, and the user presses undo three times. The starter throws `InvalidOperationException` on the third press. Guard each pop so the output is `Undo: Add chart`, `Undo: Open report`, `Nothing to undo`.

### chapters/15_stacks_queues/1501_stack.ipynb + new code cell at 11 Guided Practice: Undo Past the Beginning
+ using System;
+ using System.Collections.Generic;
+ 
+ var history = new Stack<string>();
+ history.Push("Open report");
+ history.Push("Add chart");
+ 
+ for (int press = 1; press <= 3; press++)
+ {
+     // Your code starts here.
+     Console.WriteLine($"Undo: {history.Pop()}");
+     // Your code ends here.
+ }

### chapters/15_stacks_queues/1501_stack.ipynb + new code cell at 11 Guided Practice: Undo Past the Beginning
+ using System;
+ using System.Collections.Generic;
+ 
+ // Solution
+ var history = new Stack<string>();
+ history.Push("Open report");
+ history.Push("Add chart");
+ 
+ for (int press = 1; press <= 3; press++)
+ {
+     if (history.TryPop(out string? action))
+     {
+         Console.WriteLine($"Undo: {action}");
+     }
+     else
+     {
+         Console.WriteLine("Nothing to undo");
+     }
+ }

### chapters/15_stacks_queues/1501_stack.ipynb + new markdown cell at 11 Guided Practice: Undo Past the Beginning
+ `TryPop` combines the emptiness check and the pop in one call and reports the result as a Boolean, so the loop never reaches a state it cannot handle. Checking `history.Count > 0` before `Pop` is the two-statement equivalent.

### chapters/15_stacks_queues/1503_applications_lab.ipynb + new markdown cell at 16 Guided Practice: Visit Pages in Arrival Order
+ ```{index} Guided Practice: Visit Pages in Arrival Order
+ ```
+ 
+ ### Guided Practice: Visit Pages in Arrival Order

### chapters/15_stacks_queues/1503_applications_lab.ipynb + new markdown cell at 16 Guided Practice: Visit Pages in Arrival Order
+ The crawler below uses the wrong collection, so it prints the pages in reverse. Replace it with the collection whose access rule is first-in, first-out so the output is `home`, `products`, `support`.

### chapters/15_stacks_queues/1503_applications_lab.ipynb + new code cell at 16 Guided Practice: Visit Pages in Arrival Order
+ using System;
+ using System.Collections.Generic;
+ 
+ // Your code starts here.
+ var pending = new Stack<string>();
+ pending.Push("home"); pending.Push("products"); pending.Push("support");
+ while (pending.Count > 0) Console.WriteLine(pending.Pop());
+ // Your code ends here.

### chapters/15_stacks_queues/1503_applications_lab.ipynb + new code cell at 16 Guided Practice: Visit Pages in Arrival Order
+ using System;
+ using System.Collections.Generic;
+ 
+ // Solution
+ var pending = new Queue<string>();
+ pending.Enqueue("home"); pending.Enqueue("products"); pending.Enqueue("support");
+ while (pending.Count > 0) Console.WriteLine(pending.Dequeue());

### chapters/15_stacks_queues/1503_applications_lab.ipynb + new markdown cell at 16 Guided Practice: Visit Pages in Arrival Order
+ Only the collection and its three verbs changed; the loop shape is identical. That is the point of this page: the access rule is the design decision, and the structure follows from it.

### chapters/16_searching_sorting/1604_merge_sort.ipynb + new markdown cell at 9 Guided Practice: Merge Descending Runs
+ ```{index} Guided Practice: Merge Descending Runs
+ ```
+ 
+ ### Guided Practice: Merge Descending Runs

### chapters/16_searching_sorting/1604_merge_sort.ipynb + new markdown cell at 9 Guided Practice: Merge Descending Runs
+ Two branches send their amounts sorted from largest to smallest. Change one comparison so the merge produces a descending result, `9, 7, 5, 5, 2, 1`, and keep the left run winning ties.

### chapters/16_searching_sorting/1604_merge_sort.ipynb + new code cell at 9 Guided Practice: Merge Descending Runs
+ using System;
+ 
+ int[] north = { 9, 5, 2 };
+ int[] south = { 7, 5, 1 };
+ Console.WriteLine(string.Join(", ", MergeDescending(north, south)));
+ 
+ static int[] MergeDescending(int[] left, int[] right)
+ {
+     int[] result = new int[left.Length + right.Length];
+     int i = 0, j = 0, k = 0;
+     while (i < left.Length && j < right.Length)
+     {
+         // Your code starts here.
+         if (left[i] <= right[j]) result[k++] = left[i++];
+         else result[k++] = right[j++];
+         // Your code ends here.
+     }
+     while (i < left.Length) result[k++] = left[i++];
+     while (j < right.Length) result[k++] = right[j++];
+     return result;
+ }

### chapters/16_searching_sorting/1604_merge_sort.ipynb + new code cell at 9 Guided Practice: Merge Descending Runs
+ using System;
+ 
+ // Solution
+ int[] north = { 9, 5, 2 };
+ int[] south = { 7, 5, 1 };
+ Console.WriteLine(string.Join(", ", MergeDescending(north, south)));
+ 
+ static int[] MergeDescending(int[] left, int[] right)
+ {
+     int[] result = new int[left.Length + right.Length];
+     int i = 0, j = 0, k = 0;
+     while (i < left.Length && j < right.Length)
+     {
+         if (left[i] >= right[j]) result[k++] = left[i++];   // larger first; left wins ties
+         else result[k++] = right[j++];
+     }
+     while (i < left.Length) result[k++] = left[i++];
+     while (j < right.Length) result[k++] = right[j++];
+     return result;
+ }

### chapters/16_searching_sorting/1604_merge_sort.ipynb + new markdown cell at 9 Guided Practice: Merge Descending Runs
+ The starter prints `7, 5, 1, 9, 5, 2`: with an ascending comparison the merge takes the whole south run before the north run's 9 looks small enough. The `>=` keeps the tie rule, so the north 5 still precedes the south 5.

### chapters/17_trees/1701_tree_structure.ipynb + new markdown cell at 26 Guided Practice: Sum the Values
+ ```{index} Guided Practice: Sum the Values
+ ```
+ 
+ ### Guided Practice: Sum the Values

### chapters/17_trees/1701_tree_structure.ipynb + new markdown cell at 26 Guided Practice: Sum the Values
+ Complete `Sum` so it adds every value in the tree, following the same shape as `Count`: a base case for `null` and one recursive call per child. Expected output: `28`.

### chapters/17_trees/1701_tree_structure.ipynb + new code cell at 26 Guided Practice: Sum the Values
+ using System;
+ 
+ var root = new SumNode(8);
+ root.Left = new SumNode(3);
+ root.Right = new SumNode(10);
+ root.Left.Left = new SumNode(1);
+ root.Left.Right = new SumNode(6);
+ 
+ Console.WriteLine(Sum(root));
+ 
+ static int Sum(SumNode? node)
+ {
+     // Your code starts here.
+     return 0;
+     // Your code ends here.
+ }
+ 
+ class SumNode
+ {
+     public int Value { get; }
+     public SumNode? Left { get; set; }
+     public SumNode? Right { get; set; }
+     public SumNode(int value) => Value = value;
+ }

### chapters/17_trees/1701_tree_structure.ipynb + new code cell at 26 Guided Practice: Sum the Values
+ using System;
+ 
+ // Solution
+ var root = new SumNode(8);
+ root.Left = new SumNode(3);
+ root.Right = new SumNode(10);
+ root.Left.Left = new SumNode(1);
+ root.Left.Right = new SumNode(6);
+ 
+ Console.WriteLine(Sum(root));
+ 
+ static int Sum(SumNode? node)
+ {
+     if (node is null) return 0;
+     return node.Value + Sum(node.Left) + Sum(node.Right);
+ }
+ 
+ class SumNode
+ {
+     public int Value { get; }
+     public SumNode? Left { get; set; }
+     public SumNode? Right { get; set; }
+     public SumNode(int value) => Value = value;
+ }

### chapters/17_trees/1701_tree_structure.ipynb + new markdown cell at 26 Guided Practice: Sum the Values
+ `Count` and `Sum` differ in one token: `1 +` becomes `node.Value +`. The recursive structure of the tree dictates the shape of every whole-tree summary; only the combining step changes.

### chapters/17_trees/1703_tree_lab.ipynb + new markdown cell at 11 Guided Practice: Find the Largest ID
+ ```{index} Guided Practice: Find the Largest ID
+ ```
+ 
+ ### Guided Practice: Find the Largest ID

### chapters/17_trees/1703_tree_lab.ipynb + new markdown cell at 11 Guided Practice: Find the Largest ID
+ In a binary search tree the largest key is reached by following `Right` links until there is no right child. Complete `Max` so the output is `70`; the starter stops at the root and prints `40`.

### chapters/17_trees/1703_tree_lab.ipynb + new code cell at 11 Guided Practice: Find the Largest ID
+ using System;
+ 
+ var root = new MaxNode(40)
+ {
+     Left = new MaxNode(20) { Left = new MaxNode(10), Right = new MaxNode(30) },
+     Right = new MaxNode(60) { Left = new MaxNode(50), Right = new MaxNode(70) }
+ };
+ Console.WriteLine(Max(root));
+ 
+ static int Max(MaxNode node)
+ {
+     MaxNode current = node;
+     // Your code starts here.
+     // Follow Right while there is a right child.
+     // Your code ends here.
+     return current.Id;
+ }
+ 
+ class MaxNode
+ {
+     public int Id { get; }
+     public MaxNode? Left { get; set; }
+     public MaxNode? Right { get; set; }
+     public MaxNode(int id) => Id = id;
+ }

### chapters/17_trees/1703_tree_lab.ipynb + new code cell at 11 Guided Practice: Find the Largest ID
+ using System;
+ 
+ // Solution
+ var root = new MaxNode(40)
+ {
+     Left = new MaxNode(20) { Left = new MaxNode(10), Right = new MaxNode(30) },
+     Right = new MaxNode(60) { Left = new MaxNode(50), Right = new MaxNode(70) }
+ };
+ Console.WriteLine(Max(root));
+ 
+ static int Max(MaxNode node)
+ {
+     MaxNode current = node;
+     while (current.Right is not null)
+     {
+         current = current.Right;
+     }
+     return current.Id;
+ }
+ 
+ class MaxNode
+ {
+     public int Id { get; }
+     public MaxNode? Left { get; set; }
+     public MaxNode? Right { get; set; }
+     public MaxNode(int id) => Id = id;
+ }

### chapters/17_trees/1703_tree_lab.ipynb + new markdown cell at 11 Guided Practice: Find the Largest ID
+ No comparison with the target is needed, because the ordering invariant already says everything larger lies to the right. The walk visits one node per level, so its cost is the tree's height, the same bound as a search.

### chapters/20_graphs/2001_graph_vocabulary.ipynb + new markdown cell at 12 Guided Practice: Find the Starting Steps
+ ```{index} Guided Practice: Find the Starting Steps
+ ```
+ 
+ ### Guided Practice: Find the Starting Steps

### chapters/20_graphs/2001_graph_vocabulary.ipynb + new markdown cell at 12 Guided Practice: Find the Starting Steps
+ A step with no incoming dependency can start immediately. Print only those steps, in the order of the `steps` array. Expected output: `Request` and `Budget`.

### chapters/20_graphs/2001_graph_vocabulary.ipynb + new code cell at 12 Guided Practice: Find the Starting Steps
+ using System;
+ using System.Collections.Generic;
+ using System.Linq;
+ 
+ string[] steps = { "Request", "Budget", "Approve", "Archive" };
+ (string From, string To)[] dependencies =
+ {
+     ("Request", "Approve"), ("Budget", "Approve"), ("Approve", "Archive")
+ };
+ 
+ foreach (string step in steps)
+ {
+     // Your code starts here.
+     Console.WriteLine(step);
+     // Your code ends here.
+ }

### chapters/20_graphs/2001_graph_vocabulary.ipynb + new code cell at 12 Guided Practice: Find the Starting Steps
+ using System;
+ using System.Collections.Generic;
+ using System.Linq;
+ 
+ // Solution
+ string[] steps = { "Request", "Budget", "Approve", "Archive" };
+ (string From, string To)[] dependencies =
+ {
+     ("Request", "Approve"), ("Budget", "Approve"), ("Approve", "Archive")
+ };
+ 
+ foreach (string step in steps)
+ {
+     int incoming = dependencies.Count(e => e.To == step);
+     if (incoming == 0)
+     {
+         Console.WriteLine(step);
+     }
+ }

### chapters/20_graphs/2001_graph_vocabulary.ipynb + new markdown cell at 12 Guided Practice: Find the Starting Steps
+ In-degree zero is the formal name for "nothing has to happen first". Scheduling tools compute exactly this set to decide what can run now, and recompute it as steps finish.

### chapters/20_graphs/2002_adjacency_representations.ipynb + new markdown cell at 16 Guided Practice: List a Room's Neighbors
+ ```{index} Guided Practice: List a Room's Neighbors
+ ```
+ 
+ ### Guided Practice: List a Room's Neighbors

### chapters/20_graphs/2002_adjacency_representations.ipynb + new markdown cell at 16 Guided Practice: List a Room's Neighbors
+ Print the neighbors of `Hall` in alphabetical order from the adjacency collection, and then the number of neighbors `Remote` has. Expected output: `Lab, Lobby` and `0`.

### chapters/20_graphs/2002_adjacency_representations.ipynb + new code cell at 16 Guided Practice: List a Room's Neighbors
+ using System;
+ using System.Collections.Generic;
+ using System.Linq;
+ 
+ var adjacency = new Dictionary<string, Dictionary<string, int>>(StringComparer.Ordinal);
+ foreach (string room in new[] { "Lobby", "Hall", "Lab", "Remote" })
+     adjacency.Add(room, new Dictionary<string, int>(StringComparer.Ordinal));
+ adjacency["Lobby"]["Hall"] = adjacency["Hall"]["Lobby"] = 4;
+ adjacency["Hall"]["Lab"] = adjacency["Lab"]["Hall"] = 2;
+ 
+ // Your code starts here.
+ Console.WriteLine(string.Join(", ", adjacency.Keys));
+ // Your code ends here.

### chapters/20_graphs/2002_adjacency_representations.ipynb + new code cell at 16 Guided Practice: List a Room's Neighbors
+ using System;
+ using System.Collections.Generic;
+ using System.Linq;
+ 
+ // Solution
+ var adjacency = new Dictionary<string, Dictionary<string, int>>(StringComparer.Ordinal);
+ foreach (string room in new[] { "Lobby", "Hall", "Lab", "Remote" })
+     adjacency.Add(room, new Dictionary<string, int>(StringComparer.Ordinal));
+ adjacency["Lobby"]["Hall"] = adjacency["Hall"]["Lobby"] = 4;
+ adjacency["Hall"]["Lab"] = adjacency["Lab"]["Hall"] = 2;
+ 
+ var neighbors = adjacency["Hall"].Keys.OrderBy(name => name, StringComparer.Ordinal);
+ Console.WriteLine(string.Join(", ", neighbors));
+ Console.WriteLine(adjacency["Remote"].Count);

### chapters/20_graphs/2002_adjacency_representations.ipynb + new markdown cell at 16 Guided Practice: List a Room's Neighbors
+ The inner dictionary for a room *is* its neighbor list, so the lookup costs one hash access plus the size of that list, not a scan of every room. `Remote` has an entry with zero neighbors; a missing key would instead throw, which is why vertices are added before any edge.

### chapters/15_stacks_queues/1501_stack.ipynb + new markdown cell at 38 task text
+ Push the three task names `Build`, `Test`, and `Deploy` in that order, then pop and print until the stack is empty. Expected output: `Deploy`, `Test`, `Build`. Explain in one sentence why the order reversed.

### chapters/15_stacks_queues/1502_queue_deque.ipynb + new markdown cell at 40 task text
+ Enqueue the ticket IDs `T-101`, `T-102`, and `T-103`, then dequeue and print until the queue is empty. Expected output: the three IDs in the order they were added.

### chapters/15_stacks_queues/1503_applications_lab.ipynb + new markdown cell at 38 task text
+ Two urgent tickets and two normal tickets are waiting. Print one urgent ticket if any exist, otherwise one normal ticket, otherwise `No tickets waiting.` Expected output: `U-2`, because urgent work is handled most-recent-first. Then remove both `Push` calls and predict the new output.

### chapters/17_trees/1704_tree_traversal.ipynb + new markdown cell at 22 task text
+ Complete `CountLeaves` so it returns the number of nodes with no children. For the tree built in the cell the expected output is `3`. A `null` node contributes 0, a node with no children contributes 1, and any other node contributes the sum of its two subtrees.

### chapters/17_trees/1702_binary_search_trees.ipynb + new markdown cell at 36 task text
+ Complete the loop in `Contains` so it returns `True` for 7 and `False` for 2. At each node compare the target with the stored value: equal means found, smaller means go left, larger means go right; reaching `null` means the value is absent.

### chapters/17_trees/1703_tree_lab.ipynb + new markdown cell at 28 task text
+ Complete `CountRange` so it counts the IDs inside the inclusive interval, skipping any subtree the ordering invariant proves to be entirely outside it. Expected output: `4` for the interval 25 to 60 and `0` for 80 to 90.

### chapters/18_priority_queues/1803_priority_applications.ipynb + new markdown cell at 13 task text
+ Enqueue three tickets with priorities of your choice, where a lower number means more urgent, then dequeue and print them until the queue is empty. The output must list the tickets from most to least urgent regardless of the order you enqueued them.

### chapters/16_searching_sorting/1602_basic_sorting.ipynb cell 65423ec111ab expected output
-Create an independently ordered array before sorting; the original arrival order must remain unchanged.
+Create an independently ordered array before sorting; the original arrival order must remain unchanged. Expected output: `10,40,40`, and the check line must not throw.
```
