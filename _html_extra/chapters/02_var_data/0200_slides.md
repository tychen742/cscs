---
marp: true
theme: thinkpress-lecture
paginate: true
title: "Variables, Data Types, and Operators"
book: "Computer Science in C#"
section: "Chapter 2"
primary: "#2a6b37"
accent: "#b8860b"
---

<!-- _class: title -->

# Variables, Data Types, and Operators

Chapter 2 · Computer Science in C#

<!--
Part map (1-based slide numbers): 2.1 Variables, Assignment, and State: slide 2; 2.2 Types and Conversion: slide 18; 2.3 Operators and Built-In Methods: slide 34; 2.4 Input and Output: slide 50. Meeting 1: 2.1 and the type overview in 2.2, 35 minutes; meeting 2: conversion in 2.2 and operators/calls in 2.3, 40 minutes; meeting 3: 2.4, 35 minutes. Total 110 minutes. Use selected examples and checks inside the existing allocation. Additional source detail remains preparation/reference reading. Every example is standalone; instructor answers remain in notes.
-->

---

<!-- _class: section -->

## Variables, Assignment, and State

2.1 · [2.1 reading](0201_variables_types.html)

Read, predict, trace, then apply.

<!--
Meeting 1: 2.1 and the type overview in 2.2, 35 minutes; meeting 2: conversion in 2.2 and operators/calls in 2.3, 40 minutes; meeting 3: 2.4, 35 minutes. Total 110 minutes. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. A stock desk stores available units and reserved units. A later change to one variable does not automatically recalculate a value previously stored in another.
-->

---

## Goals and preparation

- Declare meaningfully named variables
- Trace reassignment in sequence
- Distinguish inferred type from changing values

[2.1 reading](0201_variables_types.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: 2.1 and the type overview in 2.2, 35 minutes; meeting 2: conversion in 2.2 and operators/calls in 2.3, 40 minutes; meeting 3: 2.4, 35 minutes. Total 110 minutes. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The business question

A stock desk stores available units and reserved units. A later change to one variable does not automatically recalculate a value previously stored in another.

> What information, rule and observable result do we need?

<!--
A stock desk stores available units and reserved units. A later change to one variable does not automatically recalculate a value previously stored in another. Ask pairs to name the input, required result and a possible wrong answer. Expected discussion: distinguish the stated business requirement from an implementation that merely runs. Use the trace in this part to make that distinction concrete.
-->

---

## A variable holds a current value of a type

- Declaration supplies a name and type
- Initialization gives its first value
- Use business names such as stock and reserved

<!--
These names associated with a data storage location are called *variables*. In other words, variables represent the locations of objects in memory. Some general rules for C# variables are: - Every variable has a **type** that determines what values can be stored in the variable. - The C# compiler guarantees that values stored in variables are always of the appropriate type. - The value of a variable can be changed through **assignment** or through use of the ++ and -- operators. - Variables are either initially assigned or initially unassigned. Variables can have local scope or global scope: - Local variables are declared within a method and can only be accessed within that method. - Global variables typically refer to static fields that are accessible throughout the class.  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. Each row is the complete state after a statement. The final reserved update does not rerun the stock assignment. Ask a student to point to the only changed cell in the final row.
-->

---

## Assignment reads the right side first

- Evaluate with the current state
- Store the result in the left variable
- Earlier assignments do not become live formulas

<!--
 A declaration statement declares a new local variable, local constant, or local reference variable. To declare a local variable, specify a type and provide a variable name. You can declare multiple variables of the same type in one statement: > `type variableName;` In this syntax, - **type** is a C# type (such as int or string), - **variableName** is the name of the variable (such as x or name) - the semicolon `;` is the statement terminator. For example, you may declare the following variables  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. Each row is the complete state after a statement. The final reserved update does not rerun the stock assignment. Ask a student to point to the only changed cell in the final row.
-->

---

## Play computer with stock

| Statement completed | stock | reserved |
| --- | ---: | ---: |
| stock = 12 | 12 | not declared |
| reserved = stock - 8 | 12 | 4 |
| stock = stock - reserved | 8 | 4 |
| reserved = reserved + 1 | 8 | 5 |

<!--
Each row is the complete state after a statement. The final reserved update does not rerun the stock assignment. Ask a student to point to the only changed cell in the final row. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
int stock = 12;
int reserved = stock - 8;
stock = stock - reserved;
reserved = reserved + 1;
Console.WriteLine($"stock={stock}, reserved={reserved}");
```

```output
stock=8, reserved=5
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is 'stock=8, reserved=5\n'. Each row is the complete state after a statement. The final reserved update does not rerun the stock assignment. Ask a student to point to the only changed cell in the final row. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

After a = 8; b = a; a = 3; what value remains in b?

1. 3
2. 8
3. It has no value

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. Assignment copied the value 8 at that time; it did not link two integer variables. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

## var infers a type once

- The initializer determines the static type
- Later assignment must fit that type
- Use a temporary variable when both old values matter

<!--
 In this syntax, - the equal sign `=` is the assignment operator (note that it is not the equal sign in mathematics)  Each row is the complete state after a statement. The final reserved update does not rerun the stock assignment. Ask a student to point to the only changed cell in the final row. Ask students to explain the difference this concept makes to the caller or to the person using the result.
-->

---

## Preserve an old value before overwriting it

- A swap requires a temporary value when both originals are needed.
- regular = sale first destroys the old regular price.

<!--
For starting regular=95 and sale=120, save regular, assign regular from sale, then assign sale from the saved value. The final values are120 and95. Equal starting values conceal this bug, so use distinct prices.
-->

---

## Challenge a plausible wrong result

Trace distinct values, equal values and a later reassignment. Check values after each statement rather than only the final display.

> Name one changed input that would expose a wrong boundary, missing case or unintended state change.

<!--
Ask for a counterexample before modifying the program. Answer B. Type inference selects int at declaration and does not make the variable dynamically typed. The trace provides an independent explanation of the ordinary case. Each row is the complete state after a statement. The final reserved update does not rerun the stock assignment. Ask a student to point to the only changed cell in the final row.
-->

---

<!-- _class: check -->

## Quick check 2

With var count = 3, can count later hold 3.5 without conversion?

1. Yes, var changes type
2. No, its inferred type is int
3. Only if it is printed

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. Type inference selects int at declaration and does not make the variable dynamically typed. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Guided Practice: Swap Two Prices**

Swap the two entered prices using a third variable. Predict the incorrect result if the first old value is overwritten too early.

[Open the existing practice](0201_variables_types.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Existing exercise cell p4_095918a0ea. Expected regular=120, sale=95. Save one original value in a temporary variable, perform the first assignment, then restore the saved value into the other variable. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- Trace distinct values, equal values and a later reassignment. Check values after each statement rather than only the final display.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. Each row is the complete state after a statement. The final reserved update does not rerun the stock assignment. Ask a student to point to the only changed cell in the final row. For the Your Turn activity, the instructor answer is: Existing exercise cell p4_095918a0ea. Expected regular=120, sale=95. Save one original value in a temporary variable, perform the first assignment, then restore the saved value into the other variable.
-->

---

## Vocabulary to explain, not memorize

- Declaration: name/type
- assignment: replace value
- state: current values

[Chapter objectives and glossary](0200_variables_types.html)

<!--
Ask students to use each term in an explanation of this part’s case. Tie the vocabulary to the actions in the goals: Declare meaningfully named variables; Trace reassignment in sequence; Distinguish inferred type from changing values. A correct definition without a correct trace is not yet sufficient evidence of application.
-->

---

<!-- _class: recap -->

## Recap and next step

- Declare meaningfully named variables
- Trace reassignment in sequence
- Distinguish inferred type from changing values

[2.1 reading](0201_variables_types.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. Each row is the complete state after a statement. The final reserved update does not rerun the stock assignment. Ask a student to point to the only changed cell in the final row. Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: 2.1 and the type overview in 2.2, 35 minutes; meeting 2: conversion in 2.2 and operators/calls in 2.3, 40 minutes; meeting 3: 2.4, 35 minutes. Total 110 minutes.
-->

---

<!-- _class: section -->

## Types and Conversion

2.2 · [2.2 reading](0202_types_conversion.html)

Read, predict, trace, then apply.

<!--
Meeting 1: 2.1 and the type overview in 2.2, 35 minutes; meeting 2: conversion in 2.2 and operators/calls in 2.3, 40 minutes; meeting 3: 2.4, 35 minutes. Total 110 minutes. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. A delivery desk divides ten units among four orders. The type of the operands determines whether the calculation stores whole units or a fractional average.
-->

---

## Goals and preparation

- Choose types to represent business values
- Distinguish range, precision and display
- Trace conversions without assuming lost data returns

[2.2 reading](0202_types_conversion.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: 2.1 and the type overview in 2.2, 35 minutes; meeting 2: conversion in 2.2 and operators/calls in 2.3, 40 minutes; meeting 3: 2.4, 35 minutes. Total 110 minutes. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The business question

A delivery desk divides ten units among four orders. The type of the operands determines whether the calculation stores whole units or a fractional average.

> What information, rule and observable result do we need?

<!--
A delivery desk divides ten units among four orders. The type of the operands determines whether the calculation stores whole units or a fractional average. Ask pairs to name the input, required result and a possible wrong answer. Expected discussion: distinguish the stated business requirement from an implementation that merely runs. Use the trace in this part to make that distinction concrete.
-->

---

## Choose a representation for the meaning

- int represents whole counts within its range
- decimal suits many base-10 monetary rules
- bool, char and string represent different kinds of information

<!--
A business value has a meaning before it has a C# type. A count of delivered packages is a whole number; a quoted price may need decimal fractions; a product code is text even when it consists of digits. Choosing a type is therefore a modeling decision, not a search for the smallest box that happens to fit today's example. Start with the allowed values and operations. Ask whether fractional values make sense, whether leading zeros matter, and whether the quantity can exceed a chosen numeric range. Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. Do not describe the second expression as floating-point division: the inner operation has already lost the fractional part. Distinguish a stored value of two from the textual representation chosen by a display.
-->

---

## A conversion can discard information

- Integer division discards a fractional quotient
- Casting after division cannot restore it
- Convert an operand before fractional division

<!--
In C#, **everything is a type**. Every value you store, every variable you declare, and every expression you write has a type. A **type** defines three things: - **Value**: The **set of valid values** it can hold (e.g., `int` holds whole numbers −2,147,483,648 to 2,147,483,647). - **Operation**: The **operations** permitted on those values (e.g., arithmetic on numbers, `.Length` on strings). - **Memory**: The **amount of memory** reserved when a variable of that type is created. C# types split into two fundamental categories: **value types** and **reference types**. The difference between them is not just a classification detail — it changes what happens when you assign one variable to another, which is worth seeing directly before anything else. Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. Do not describe the second expression as floating-point division: the inner operation has already lost the fractional part. Distinguish a stored value of two from the textual representation chosen by a display.
-->

---

## Follow the quotient through its types

| Expression | Evaluation | Result |
| --- | --- | --- |
| 10 / 4 | int division | 2 |
| (double)(10 / 4) | int division, then conversion | 2.0 stored |
| (double)10 / 4 | floating-point division | 2.5 |
| 10m / 4 | decimal division | 2.5 |

<!--
Do not describe the second expression as floating-point division: the inner operation has already lost the fractional part. Distinguish a stored value of two from the textual representation chosen by a display. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
Console.WriteLine(10 / 4);
Console.WriteLine((double)(10 / 4) == 2);
Console.WriteLine((double)10 / 4 == 2.5);
Console.WriteLine(10m / 4 == 2.5m);
```

```output
2
True
True
True
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is '2\nTrue\nTrue\nTrue\n'. Do not describe the second expression as floating-point division: the inner operation has already lost the fractional part. Distinguish a stored value of two from the textual representation chosen by a display. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

Which retains the fractional quotient?

1. (double)(10 / 4)
2. (double)10 / 4
3. int result = 10 / 4

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. The conversion occurs before division. A converts the already truncated quotient. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

## Stored value and displayed text are separate

- A format specifier changes the report text
- Rounding rules may change a calculated value
- Wide range does not guarantee exact precision

<!--
Every specific type you will meet in this book -- `int`, `string`, an array, a class you write yourself -- is an **instance** of a small number of umbrella concepts. Learning those umbrella concepts first means every new type you meet afterward already has a slot to fit into, instead of feeling like a fresh, unrelated fact. This section covers three of them: - **value** types, which copy on assignment, - **reference** types, which share on assignment, - `void` (the type that means "no value"), and - default values (what a variable holds before you give it one). Do not describe the second expression as floating-point division: the inner operation has already lost the fractional part. Distinguish a stored value of two from the textual representation chosen by a display. Ask students to explain the difference this concept makes to the caller or to the person using the result.
-->

---

## Types also describe storage behavior

- Value types and reference types are distinct categories.
- A local variable must be definitely assigned before use; do not assume a default local value.

<!--
The reading distinguishes defaults for fields and array elements from local definite assignment. A string is a reference type with immutable contents; integers are value types. void describes the absence of a returned result, not a variable that stores nothing.
-->

---

## Challenge a plausible wrong result

Check exact division, a remainder, zero numerator and an explicitly nonzero divisor. Invalid-input policy is not a prerequisite for this arithmetic exercise.

> Name one changed input that would expose a wrong boundary, missing case or unintended state change.

<!--
Ask for a counterexample before modifying the program. Answer B. Formatting produces text. A separate calculation must enforce a rounding rule when the business contract requires it. The trace provides an independent explanation of the ordinary case. Do not describe the second expression as floating-point division: the inner operation has already lost the fractional part. Distinguish a stored value of two from the textual representation chosen by a display.
-->

---

<!-- _class: check -->

## Quick check 2

Printing a value with F2 guarantees what?

1. The stored number now has two decimal places
2. The displayed text has two fractional digits
3. All future calculations use the rounded text

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. Formatting produces text. A separate calculation must enforce a rounding rule when the business contract requires it. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Tracing and Expression Practice**

Use the existing division and conversion practice. Predict each expression before executing; identify the type at the division step.

[Open the existing practice](assignments/additional_practice.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Retained additional-practice exercises keep their existing IDs. A correct explanation identifies operand types first and separates a cast before division from a cast after division. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- Check exact division, a remainder, zero numerator and an explicitly nonzero divisor. Invalid-input policy is not a prerequisite for this arithmetic exercise.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. Do not describe the second expression as floating-point division: the inner operation has already lost the fractional part. Distinguish a stored value of two from the textual representation chosen by a display. For the Your Turn activity, the instructor answer is: Retained additional-practice exercises keep their existing IDs. A correct explanation identifies operand types first and separates a cast before division from a cast after division.
-->

---

## Vocabulary to explain, not memorize

- Type: permitted values/operations
- conversion: representation change
- precision: representable detail

[Chapter objectives and glossary](0200_variables_types.html)

<!--
Ask students to use each term in an explanation of this part’s case. Tie the vocabulary to the actions in the goals: Choose types to represent business values; Distinguish range, precision and display; Trace conversions without assuming lost data returns. A correct definition without a correct trace is not yet sufficient evidence of application.
-->

---

<!-- _class: recap -->

## Recap and next step

- Choose types to represent business values
- Distinguish range, precision and display
- Trace conversions without assuming lost data returns

[2.2 reading](0202_types_conversion.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. Do not describe the second expression as floating-point division: the inner operation has already lost the fractional part. Distinguish a stored value of two from the textual representation chosen by a display. Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: 2.1 and the type overview in 2.2, 35 minutes; meeting 2: conversion in 2.2 and operators/calls in 2.3, 40 minutes; meeting 3: 2.4, 35 minutes. Total 110 minutes.
-->

---

<!-- _class: section -->

## Operators and Built-In Methods

2.3 · [2.3 reading](0203_operators_built_in_methods.html)

Read, predict, trace, then apply.

<!--
Meeting 1: 2.1 and the type overview in 2.2, 35 minutes; meeting 2: conversion in 2.2 and operators/calls in 2.3, 40 minutes; meeting 3: 2.4, 35 minutes. Total 110 minutes. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. Four colleagues share a bill of 47 whole dollars. The desk needs the amount each pays and the dollars still unallocated.
-->

---

## Goals and preparation

- Evaluate expressions using types and precedence
- Use quotient and remainder together
- Read built-in method arguments and results

[2.3 reading](0203_operators_built_in_methods.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: 2.1 and the type overview in 2.2, 35 minutes; meeting 2: conversion in 2.2 and operators/calls in 2.3, 40 minutes; meeting 3: 2.4, 35 minutes. Total 110 minutes. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The business question

Four colleagues share a bill of 47 whole dollars. The desk needs the amount each pays and the dollars still unallocated.

> What information, rule and observable result do we need?

<!--
Four colleagues share a bill of 47 whole dollars. The desk needs the amount each pays and the dollars still unallocated. Ask pairs to name the input, required result and a possible wrong answer. Expected discussion: distinguish the stated business requirement from an implementation that merely runs. Use the trace in this part to make that distinction concrete.
-->

---

## Group the calculation deliberately

- Multiplication, division and remainder precede addition
- Parentheses state a grouping explicitly
- Operand types still determine each operation

<!--
Operators in programming languages are symbols that tells the compiler or interpreter to perform specific operations. The operand combined with the operator makes an operation. In an operation, an *operand* is the data that is being operated on. The position of the operator, with respect to its operands, may be prefix, infix or postfix. Common simple operators include - *arithmetic* (e.g. addition with +), - *comparison* (relational) (e.g. "greater than" with >), - *logical* (e.g. AND, also written && in some languages), and - *assignment* (e.g., =, +=) operators. Additional types of operators include assignment (usually = or :=), field access in a record or object (usually .), and bitwise and shift operators. Operators can be categorized based on the number of operands required. The three categories of operators based on the number of operands they require are: - Unary operators: which require one operand (e.g., ++, !) - Binary operators: which require two operands (e.g., +) - Ternary operators: which require three operands (e.g., condition ? consequent : alternative) (arithmetic-operators)=  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The remainder is not a fractional share. Use the reconstruction equation to challenge a plausible wrong result. Parentheses change the arithmetic tree, not the type of integer operands.
-->

---

## Quotient and remainder answer different questions

- 47 / 4 gives whole dollars each
- 47 % 4 gives dollars left over
- Check divisor × quotient + remainder against the original

<!--
The table below summarizes key C# operators. | Category | Operators | Description | Example | |----------|-----------|-------------|---------| | **Assignment** | `=` `+=` `-=` `*=` `/=` `%=` `++` `--` | Assign and update values | `x = 5`, `x += 3` | | **Arithmetic** | `+` `-` `*` `/` `%` | Mathematical operations | `5 + 3`, `14 / 4`, `14 % 4` | | **Comparison** | `==` `!=` `>` `=` ` 3`, `x == y` | | **Logical** | `&&` `\|\|` `!` | Combine or invert `bool` expressions | `x > 0 && x >` | Bit-level operations on integers | `5 & 3`, `5 << 1` | Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The remainder is not a fractional share. Use the reconstruction equation to challenge a plausible wrong result. Parentheses change the arithmetic tree, not the type of integer operands.
-->

---

## Trace the split before printing

| Step | Calculation | Value |
| --- | --- | ---: |
| Share | 47 / 4 | 11 |
| Remainder | 47 % 4 | 3 |
| Independent check | 4 × 11 + 3 | 47 |
| Compare grouping | 2 + 10 / 3 versus (2 + 10) / 3 | 5 versus 4 |

<!--
The remainder is not a fractional share. Use the reconstruction equation to challenge a plausible wrong result. Parentheses change the arithmetic tree, not the type of integer operands. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
int bill = 47, people = 4;
int each = bill / people;
int left = bill % people;
Console.WriteLine($"each pays {each}, {left} left over");
Console.WriteLine(people * each + left == bill);
```

```output
each pays 11, 3 left over
True
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is 'each pays 11, 3 left over\nTrue\n'. The remainder is not a fractional share. Use the reconstruction equation to challenge a plausible wrong result. Parentheses change the arithmetic tree, not the type of integer operands. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

What is 2 + 10 / 3 with integer operands?

1. 4
2. 5
3. About 5.33

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. Division happens first and produces 3; adding 2 gives 5. Parenthesizing the addition would produce 4. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

## Read a call as input and returned result

- Math.Abs receives a number and returns a number
- Parse receives numeric text under a valid-input assumption
- A signature tells you the accepted types and result

<!--
**Early exposure, not a syntax mastery checklist.** The category map and reference table let you recognize symbols before they appear inside larger tasks. Concentrate on the arithmetic, assignment, and library calls used in this chapter's sequential calculations. Logical conditions receive their full treatment in Chapter 3; loop control is developed in Chapter 4. Bitwise examples are a first look, not a requirement to implement bit-level algorithms here. Return to a table when a later lesson needs its syntax, rather than memorizing it now.  The remainder is not a fractional share. Use the reconstruction equation to challenge a plausible wrong result. Parentheses change the arithmetic tree, not the type of integer operands. Ask students to explain the difference this concept makes to the caller or to the person using the result.
-->

---

## A built-in call has a readable contract

- Read parameter types and the returned type before composing a call.
- Comparison and logical operators produce bool; bitwise operations work on representations.

<!--
Have students say the argument and result of Math.Abs(-3): it receives a negative integer and returns3. Do not mistake Console.WriteLine for a numeric calculation. The full operator and bitwise tables are reference material rather than a memorization quota.
-->

---

## Challenge a plausible wrong result

Check a divisible total, a smaller total than the positive divisor and the original example. Keep the input-domain assumptions explicit.

> Name one changed input that would expose a wrong boundary, missing case or unintended state change.

<!--
Ask for a counterexample before modifying the program. Answer A. Returning a value does not mean displaying it. Match the result type to the next operation. The trace provides an independent explanation of the ordinary case. The remainder is not a fractional share. Use the reconstruction equation to challenge a plausible wrong result. Parentheses change the arithmetic tree, not the type of integer operands.
-->

---

<!-- _class: check -->

## Quick check 2

What should a caller do with a returned calculation it needs later?

1. Store it or use it in another expression
2. Assume the method printed it
3. Ignore the return type

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer A. Returning a value does not mean displaying it. Match the result type to the next operation. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Guided Practice: Split a Bill**

Complete the existing integer quotient/remainder task, then change the bill to a multiple of four. Predict the remaining dollars.

[Open the existing practice](0203_operators_built_in_methods.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Exercise cell p4_f2da12f1f9 is preserved. Answer for 47 is each pays 11, 3 left over. For 48, each pays 12 and the remainder is zero; do not convert both operands to floating point. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- Check a divisible total, a smaller total than the positive divisor and the original example. Keep the input-domain assumptions explicit.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. The remainder is not a fractional share. Use the reconstruction equation to challenge a plausible wrong result. Parentheses change the arithmetic tree, not the type of integer operands. For the Your Turn activity, the instructor answer is: Exercise cell p4_f2da12f1f9 is preserved. Answer for 47 is each pays 11, 3 left over. For 48, each pays 12 and the remainder is zero; do not convert both operands to floating point.
-->

---

## Vocabulary to explain, not memorize

- Precedence: evaluation grouping
- remainder: unallocated whole units
- signature: call contract

[Chapter objectives and glossary](0200_variables_types.html)

<!--
Ask students to use each term in an explanation of this part’s case. Tie the vocabulary to the actions in the goals: Evaluate expressions using types and precedence; Use quotient and remainder together; Read built-in method arguments and results. A correct definition without a correct trace is not yet sufficient evidence of application.
-->

---

<!-- _class: recap -->

## Recap and next step

- Evaluate expressions using types and precedence
- Use quotient and remainder together
- Read built-in method arguments and results

[2.3 reading](0203_operators_built_in_methods.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. The remainder is not a fractional share. Use the reconstruction equation to challenge a plausible wrong result. Parentheses change the arithmetic tree, not the type of integer operands. Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: 2.1 and the type overview in 2.2, 35 minutes; meeting 2: conversion in 2.2 and operators/calls in 2.3, 40 minutes; meeting 3: 2.4, 35 minutes. Total 110 minutes.
-->

---

<!-- _class: section -->

## Input and Output

2.4 · [2.4 reading](0204_input_output.html)

Read, predict, trace, then apply.

<!--
Meeting 1: 2.1 and the type overview in 2.2, 35 minutes; meeting 2: conversion in 2.2 and operators/calls in 2.3, 40 minutes; meeting 3: 2.4, 35 minutes. Total 110 minutes. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. A clerk enters the quantity of folders. The report must calculate quantity × unit price and display a labeled amount, rather than echoing the typed characters.
-->

---

## Goals and preparation

- Separate reading text, parsing and calculation
- Choose Write versus WriteLine
- Use interpolation and formatting for clear reports

[2.4 reading](0204_input_output.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: 2.1 and the type overview in 2.2, 35 minutes; meeting 2: conversion in 2.2 and operators/calls in 2.3, 40 minutes; meeting 3: 2.4, 35 minutes. Total 110 minutes. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The business question

A clerk enters the quantity of folders. The report must calculate quantity × unit price and display a labeled amount, rather than echoing the typed characters.

> What information, rule and observable result do we need?

<!--
A clerk enters the quantity of folders. The report must calculate quantity × unit price and display a labeled amount, rather than echoing the typed characters. Ask pairs to name the input, required result and a possible wrong answer. Expected discussion: distinguish the stated business requirement from an implementation that merely runs. Use the trace in this part to make that distinction concrete.
-->

---

## Reading supplies text, not a number

- ReadLine returns a line of text or missing input
- Parse converts valid numeric text
- Keep the chapter example’s valid-input assumption visible

<!--
% ReadKey % tip::¶ % % Save the file before ``dotnet run``. % Use ``dotnet build`` or ``dotnet build`` *ProjectName* when needed. (read-from-console)=  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. A hard-coded two bypasses the input requirement. Printing the input string bypasses the arithmetic. Capture stdout separately from a terminal’s keyboard echo; typed input need not appear in captured output.
-->

---

## Output has both content and layout

- Write leaves the cursor on the same line
- WriteLine ends the line
- Interpolation inserts expression values into text

<!--
 At console or terminal, input is done in two parts: Prompt and read. Because the lack of better visual cues, we use a *prompt* to instruct the user how to respond. For example:  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. A hard-coded two bypasses the input requirement. Printing the input string bypasses the arithmetic. Capture stdout separately from a terminal’s keyboard echo; typed input need not appear in captured output.
-->

---

## Trace one entered invoice line

| Stage | Representation | Value |
| --- | --- | --- |
| Enter | text | "2" |
| Parse | int | 2 |
| Calculate | decimal | 2 × 3.25 = 6.50 |
| Display | formatted text | Folders: 6.50 |

<!--
A hard-coded two bypasses the input requirement. Printing the input string bypasses the arithmetic. Capture stdout separately from a terminal’s keyboard echo; typed input need not appear in captured output. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
using System.Globalization;
Console.WriteLine("Quantity?");
int quantity = int.Parse(Console.ReadLine()!);
decimal amount = quantity * 3.25m;
Console.WriteLine("Folders: " + amount.ToString("F2", CultureInfo.InvariantCulture));
```

```output
Quantity?
Folders: 6.50
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Supply stdin '2\n'. Explain the output against the preceding trace. Expected stdout is 'Quantity?\nFolders: 6.50\n'. A hard-coded two bypasses the input requirement. Printing the input string bypasses the arithmetic. Capture stdout separately from a terminal’s keyboard echo; typed input need not appear in captured output. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

If the input text is "2", what operation creates a usable integer quantity?

1. Console.WriteLine
2. int.Parse
3. F2 formatting

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. Reading supplies text, Parse converts it, and formatting is a later output step. The example assumes valid integer input. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

## Formatting expresses the display contract

- F2 displays two fractional digits
- Field width supports aligned columns
- Use a deliberate culture for a reproducible report

<!--
 The user input from keyboard is automatically shown in the terminal or console window. For a program to take in the characters typed, another method in the `Console` class is used: `Console.ReadLine`. The read method reads the data from a line typed at the keyboard by the user. When the user presses the Enter (Return) key, the sequence of characters, form the string *value* of the read method. With any method producing a value, the value is *lost* unless it is *immediately* used. We therefore assign the value from the read method to a variable like in  A hard-coded two bypasses the input requirement. Printing the input string bypasses the arithmetic. Capture stdout separately from a terminal’s keyboard echo; typed input need not appear in captured output. Ask students to explain the difference this concept makes to the caller or to the person using the result.
-->

---

## Inspect layout after checking arithmetic

- A field width is a minimum display width, not a fixed storage size.
- Choose numeric culture deliberately for a portable expected report.

<!--
The original exercise uses two aligned fields; longer text may extend beyond the minimum width. Keyboard echo is separate from stdout. InvariantCulture makes this compact demonstration reproducible; a real audience may need a local currency and number convention.
-->

---

## Challenge a plausible wrong result

Run with quantity 0, 1 and 2. Check arithmetic independently, then inspect widths, decimal digits and line breaks.

> Name one changed input that would expose a wrong boundary, missing case or unintended state change.

<!--
Ask for a counterexample before modifying the program. Answer B. A terminal may echo input; a noninteractive runner generally records only the program’s output. The trace provides an independent explanation of the ordinary case. A hard-coded two bypasses the input requirement. Printing the input string bypasses the arithmetic. Capture stdout separately from a terminal’s keyboard echo; typed input need not appear in captured output.
-->

---

<!-- _class: check -->

## Quick check 2

A captured run shows the prompt and result but not the entered 2. Is that necessarily wrong?

1. Yes, ReadLine must print the input
2. No, keyboard echo and stdout are different
3. Yes, parsing failed

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. A terminal may echo input; a noninteractive runner generally records only the program’s output. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Guided Practice: Read and Report an Invoice Line**

Complete the existing Folders report using the supplied input rather than a fixed quantity. Retain the specified column widths.

[Open the existing practice](0204_input_output.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Exercise cell ba18_e0c455ba28ed. With input 2, the amount is 6.50; there are nine spaces after Folders in the original aligned report. A zero quantity should display 0.00. This slide uses a compact label rather than replacing the exercise layout. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- Run with quantity 0, 1 and 2. Check arithmetic independently, then inspect widths, decimal digits and line breaks.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. A hard-coded two bypasses the input requirement. Printing the input string bypasses the arithmetic. Capture stdout separately from a terminal’s keyboard echo; typed input need not appear in captured output. For the Your Turn activity, the instructor answer is: Exercise cell ba18_e0c455ba28ed. With input 2, the amount is 6.50; there are nine spaces after Folders in the original aligned report. A zero quantity should display 0.00. This slide uses a compact label rather than replacing the exercise layout.
-->

---

## Vocabulary to explain, not memorize

- Input: supplied text
- parsing: text to value
- formatting: value to display

[Chapter objectives and glossary](0200_variables_types.html)

<!--
Ask students to use each term in an explanation of this part’s case. Tie the vocabulary to the actions in the goals: Separate reading text, parsing and calculation; Choose Write versus WriteLine; Use interpolation and formatting for clear reports. A correct definition without a correct trace is not yet sufficient evidence of application.
-->

---

<!-- _class: recap -->

## Recap and next step

- Separate reading text, parsing and calculation
- Choose Write versus WriteLine
- Use interpolation and formatting for clear reports

[2.4 reading](0204_input_output.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. A hard-coded two bypasses the input requirement. Printing the input string bypasses the arithmetic. Capture stdout separately from a terminal’s keyboard echo; typed input need not appear in captured output. Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: 2.1 and the type overview in 2.2, 35 minutes; meeting 2: conversion in 2.2 and operators/calls in 2.3, 40 minutes; meeting 3: 2.4, 35 minutes. Total 110 minutes.
-->
