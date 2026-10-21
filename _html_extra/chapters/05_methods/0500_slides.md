---
marp: true
theme: thinkpress-lecture
paginate: true
title: "Methods"
book: "Computer Science in C#"
section: "Chapter 5"
primary: "#2a6b37"
accent: "#b8860b"
---

<!-- _class: title -->

# Methods

Chapter 5 · Computer Science in C#

<!--
Part map (1-based slide numbers): 5.1 Designing and Calling Methods: slide 2; 5.2 Method Parameters and Scope: slide 18; 5.3 Returned Results and Method Contracts: slide 34; 5.4 Strings and Their Methods: slide 50; 5.5 Composition, Refactoring, and Method Checks: slide 66; 5.6 Supporting Reading: Recursive Methods: slide 76. Meeting 1: 5.1 and argument mapping in 5.2, 35 minutes; meeting 2: returned values in 5.2 and contracts in 5.3, 40 minutes; meeting 3: strings in 5.4 and synthesis in 5.5, 35 minutes. Total 110 minutes. Part 5.5 is a short core recap; 5.6 is optional supporting preparation. Use selected examples and checks inside the existing allocation. Additional source detail remains preparation/reference reading. Every example is standalone; instructor answers remain in notes.
-->

---

<!-- _class: section -->

## Designing and Calling Methods

5.1 · [5.1 reading](0501_intro_methods.html)

Read, predict, trace, then apply.

<!--
Meeting 1: 5.1 and argument mapping in 5.2, 35 minutes; meeting 2: returned values in 5.2 and contracts in 5.3, 40 minutes; meeting 3: strings in 5.4 and synthesis in 5.5, 35 minutes. Total 110 minutes. Part 5.5 is a short core recap; 5.6 is optional supporting preparation. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. Two parts of a store application print the same returns notice. A single printing helper allows the wording to change in one place while callers retain their intent.
-->

---

## Goals and preparation

- Name a reusable task with one responsibility
- Distinguish a definition from a call
- Follow control into a helper and back

[5.1 reading](0501_intro_methods.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: 5.1 and argument mapping in 5.2, 35 minutes; meeting 2: returned values in 5.2 and contracts in 5.3, 40 minutes; meeting 3: strings in 5.4 and synthesis in 5.5, 35 minutes. Total 110 minutes. Part 5.5 is a short core recap; 5.6 is optional supporting preparation. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The business question

Two parts of a store application print the same returns notice. A single printing helper allows the wording to change in one place while callers retain their intent.

> What information, rule and observable result do we need?

<!--
Two parts of a store application print the same returns notice. A single printing helper allows the wording to change in one place while callers retain their intent. Ask pairs to name the input, required result and a possible wrong answer. Expected discussion: distinguish the stated business requirement from an implementation that merely runs. Use the trace in this part to make that distinction concrete.
-->

---

## Discover the task before naming the method

- Give the helper one recognizable responsibility
- Choose a name that describes that task
- Separate reusable work from the surrounding interaction

<!--
A method boundary should express a responsibility that a caller can understand. Imagine an invoice program that reads a quantity, computes a line amount, adds a packing fee, and prints a report. These actions are related, but they do not all need the same information or have the same effects. Separating them lets a calculation be checked without simulating keyboard input or capturing console output. Write a short sentence for each proposed task. Then identify the information that varies, what the caller needs back, and which effects are intentional. A method named Process does not tell a reader whether it calculates, prints, changes stock, or does all three. A name such as LineTotal makes a more specific promise when accompanied by its price/quantity contract. | Proposed task | Inputs | Useful result | Intentional external effect | | --- | --- | --- | --- | | Calculate line total | Unit price and quantity | Decimal amount | None | | Format receipt line | Description and amount | String | None | | Display receipt | Formatted text | No returned value | Console output | The table is a design tool, not a rule that every program must contain precisely these three methods. A very small program may keep printing in the caller. A reusable formatting policy may deserve a method even when it is initially called once. Repetition is one reason for extraction; giving a complicated idea a clear name is another. A common mistake is to extract a group of adjacent lines simply because they are adjacent. Instead ask whether they share one coherent purpose and whether the proposed interface hides irrelevant details. If callers need to know every internal step, the boundary may not be helping them. Guided decision: should CalculateDiscount read a customer name from the keyboard? Under a calculation-only contract, no. The caller obtains input and passes the values required by the rule. This makes the same calculation usable from a console program, a test, or a future interface without rewriting its arithmetic. For related explanation, see the further reading below.[^development-reading]  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The helper body does not execute merely because its definition appears in the file. The local-function form here keeps a compact standalone example; the lesson also maps definitions inside an explicit Program class.
-->

---

## Definition and execution occur at different times

- A definition describes the helper’s body
- A call transfers control into that body
- Execution returns to the statement after the call

<!--
A shop prints a store name and separator on every receipt. Copying those two statements for every receipt works at first, but a store-name change must then be made in several places. A method names the task once so callers can reuse it. This is **decomposition**: divide a larger program into understandable responsibilities. Before refactoring, the statements appear twice: After refactoring, two calls use one definition. Predict the output: defining the helper does not print anything by itself.  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The helper body does not execute merely because its definition appears in the file. The local-function form here keeps a compact standalone example; the lesson also maps definitions inside an explicit Program class.
-->

---

## Follow two calls to one helper

| Execution event | Visible output so far | Next control location |
| --- | --- | --- |
| First Notice call | One notice | Caller after first call |
| Second Notice call | Two notices | Caller after second call |
| Definition is reached as source text | No extra notice | End of caller |

<!--
The helper body does not execute merely because its definition appears in the file. The local-function form here keeps a compact standalone example; the lesson also maps definitions inside an explicit Program class. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
Notice();
Notice();
void Notice()
{
    Console.WriteLine("Returns accepted within 30 days.");
}
```

```output
Returns accepted within 30 days.
Returns accepted within 30 days.
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is 'Returns accepted within 30 days.\nReturns accepted within 30 days.\n'. The helper body does not execute merely because its definition appears in the file. The local-function form here keeps a compact standalone example; the lesson also maps definitions inside an explicit Program class. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

A helper is defined once and called twice. How often does its body execute?

1. Once
2. Twice
3. Three times including its definition

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. Each call executes the body; a definition by itself is not another call. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

## void is a deliberate contract

- A printing helper produces an output side effect
- It does not return a value for arithmetic
- Main remains the application entry point in an explicit program

<!--
The two-line header appears twice, in call order. Change the store name in the definition and run again: both calls use that change. Add a third call without copying the body. This demonstrates reuse rather than merely asserting that reuse is useful. Read the left column as duplicated instructions and the right as named calls. A method does not automatically make a program better; it should express a coherent responsibility. Separate calculation, input, and presentation when those have different jobs.  The helper body does not execute merely because its definition appears in the file. The local-function form here keeps a compact standalone example; the lesson also maps definitions inside an explicit Program class. Ask students to explain the difference this concept makes to the caller or to the person using the result.
-->

---

## Program form should not obscure control flow

- A helper can be shown with top-level local-function syntax or inside Program.
- The explicit Main starts automatically; ordinary helpers start when called.

<!--
The lesson maps both source forms. Do not paste class-member access modifiers into a top-level local-function definition or rename Main to lowercase main and expect the same entry point. Keep the public interface and the executable call distinct.
-->

---

## Challenge a plausible wrong result

Check zero, one and two calls. Count output lines and confirm the caller continues after each completed helper.

> Name one changed input that would expose a wrong boundary, missing case or unintended state change.

<!--
Ask for a counterexample before modifying the program. Answer A. A focused name and a focused responsibility help callers predict the method’s behavior. The trace provides an independent explanation of the ordinary case. The helper body does not execute merely because its definition appears in the file. The local-function form here keeps a compact standalone example; the lesson also maps definitions inside an explicit Program class.
-->

---

<!-- _class: check -->

## Quick check 2

Which responsibility best fits a method named ShowReturnNotice?

1. Print the returns notice
2. Calculate tax and update inventory too
3. Return a random customer record

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer A. A focused name and a focused responsibility help callers predict the method’s behavior. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Guided Practice: Reuse a Notice**

Define the existing no-argument notice helper and call it twice. Change the wording once, then verify both calls reflect the change.

[Open the existing practice](0501_intro_methods.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Exercise cell m5-a68bc782. Keep the helper void and put the output inside its body. The expected original sentence is Returns accepted within 30 days. Printed output should occur twice, not once at definition time. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- Check zero, one and two calls. Count output lines and confirm the caller continues after each completed helper.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. The helper body does not execute merely because its definition appears in the file. The local-function form here keeps a compact standalone example; the lesson also maps definitions inside an explicit Program class. For the Your Turn activity, the instructor answer is: Exercise cell m5-a68bc782. Keep the helper void and put the output inside its body. The expected original sentence is Returns accepted within 30 days. Printed output should occur twice, not once at definition time.
-->

---

## Vocabulary to explain, not memorize

- Method: named task
- definition: describes behavior
- call: executes behavior

[Chapter objectives and glossary](0500_methods.html)

<!--
Ask students to use each term in an explanation of this part’s case. Tie the vocabulary to the actions in the goals: Name a reusable task with one responsibility; Distinguish a definition from a call; Follow control into a helper and back. A correct definition without a correct trace is not yet sufficient evidence of application.
-->

---

<!-- _class: recap -->

## Recap and next step

- Name a reusable task with one responsibility
- Distinguish a definition from a call
- Follow control into a helper and back

[5.1 reading](0501_intro_methods.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. The helper body does not execute merely because its definition appears in the file. The local-function form here keeps a compact standalone example; the lesson also maps definitions inside an explicit Program class. Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: 5.1 and argument mapping in 5.2, 35 minutes; meeting 2: returned values in 5.2 and contracts in 5.3, 40 minutes; meeting 3: strings in 5.4 and synthesis in 5.5, 35 minutes. Total 110 minutes. Part 5.5 is a short core recap; 5.6 is optional supporting preparation.
-->

---

<!-- _class: section -->

## Method Parameters and Scope

5.2 · [5.2 reading](0502_parameter.html)

Read, predict, trace, then apply.

<!--
Meeting 1: 5.1 and argument mapping in 5.2, 35 minutes; meeting 2: returned values in 5.2 and contracts in 5.3, 40 minutes; meeting 3: strings in 5.4 and synthesis in 5.5, 35 minutes. Total 110 minutes. Part 5.5 is a short core recap; 5.6 is optional supporting preparation. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. A delivery calculation receives an amount and a charge. The reusable helper should return their sum while leaving the caller’s original amount available for the invoice.
-->

---

## Goals and preparation

- Map arguments to parameters by position and type
- Use a returned result without changing caller inputs
- Distinguish local scope from shared static state

[5.2 reading](0502_parameter.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: 5.1 and argument mapping in 5.2, 35 minutes; meeting 2: returned values in 5.2 and contracts in 5.3, 40 minutes; meeting 3: strings in 5.4 and synthesis in 5.5, 35 minutes. Total 110 minutes. Part 5.5 is a short core recap; 5.6 is optional supporting preparation. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The business question

A delivery calculation receives an amount and a charge. The reusable helper should return their sum while leaving the caller’s original amount available for the invoice.

> What information, rule and observable result do we need?

<!--
A delivery calculation receives an amount and a charge. The reusable helper should return their sum while leaving the caller’s original amount available for the invoice. Ask pairs to name the input, required result and a possible wrong answer. Expected discussion: distinguish the stated business requirement from an implementation that merely runs. Use the trace in this part to make that distinction concrete.
-->

---

## Parameters are the helper’s named inputs

- Arguments are the values supplied at the call
- Position maps each argument to a parameter
- Use compatible types and a meaningful order

<!--
A method should work with different caller data without reading hidden shared variables. The problem is to keep the task stable while allowing its inputs to vary. Parameters give each call named local inputs; returned values carry results back. The retained Verse comparison makes the repeated pattern visible, followed by business examples and scope traces.  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The parameter amount and the caller variable amount are separate storage locations for this value-type example. Returning 15 does not mutate the caller’s 12. ref would be a different, explicitly declared contract; prefer the simpler return here.
-->

---

## A returned result belongs to the caller’s expression

- return supplies one result and ends that path
- A caller can store or compose the result
- Passing ordinary value-type inputs copies their values

<!--
As a young child, you probably heard the "Old MacDonald" song. Consider the following two verses: | Verse 1 | Verse 2 | | --- | --- | | Old MacDonald had a farm | Old MacDonald had a farm | | E-I-E-I-O | E-I-E-I-O | | And on that farm he had a cow | And on that farm he had a duck | | E-I-E-I-O | E-I-E-I-O | | With a moo-moo here | With a quack-quack here | | And a moo-moo there | And a quack-quack there | | Here a moo, there a moo | Here a quack, there a quack | | Everywhere a moo-moo | Everywhere a quack-quack | | Old MacDonald had a farm | Old MacDonald had a farm | | E-I-E-I-O | E-I-E-I-O | As you can see, the two verses are in most part identical. We can probably create a method named `Verse` to abstract the repetitive lines, but the method will need two **parameters**, which are **placeholders** that allow different values to be substituted for the animal and noise when the method is called. The method body will use the parameters as variables to customize the print statements. Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The parameter amount and the caller variable amount are separate storage locations for this value-type example. Returning 15 does not mutate the caller’s 12. ref would be a different, explicitly declared contract; prefer the simpler return here.
-->

---

## Map a call without losing the original

| Location | amount | charge | Result |
| --- | ---: | ---: | ---: |
| Caller before call | 12 | 3 | not stored |
| Helper parameters | 12 | 3 | 15 |
| Caller after assignment | 12 | 3 | 15 |

<!--
The parameter amount and the caller variable amount are separate storage locations for this value-type example. Returning 15 does not mutate the caller’s 12. ref would be a different, explicitly declared contract; prefer the simpler return here. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
int amount = 12, charge = 3;
int delivered = AddDelivery(amount, charge);
Console.WriteLine($"original={amount}, delivered={delivered}");
Console.WriteLine(AddDelivery(0, 3));
int AddDelivery(int amount, int charge)
{
    return amount + charge;
}
```

```output
original=12, delivered=15
3
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is 'original=12, delivered=15\n3\n'. The parameter amount and the caller variable amount are separate storage locations for this value-type example. Returning 15 does not mutate the caller’s 12. ref would be a different, explicitly declared contract; prefer the simpler return here. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

AddDelivery(12, 3) returns 15. What happens to the caller’s int amount?

1. It automatically becomes 15
2. It remains 12 unless the caller assigns a new value
3. It becomes inaccessible

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. Ordinary value-type arguments supply values to separate parameter storage. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

## Keep state local unless sharing is intended

- Local variables belong to their declared scope
- ref and out explicitly expose caller storage
- Static storage persists across calls and can couple otherwise separate work

<!--
::::{dropdown} Class-based console-project version The top-level example above is the version to run as a standalone notebook cell. This complete project version retains the explicit `Main` structure. Save it as the only program in a separate console project; do not paste it after top-level statements in the same file. ::::  The parameter amount and the caller variable amount are separate storage locations for this value-type example. Returning 15 does not mutate the caller’s 12. ref would be a different, explicitly declared contract; prefer the simpler return here. Ask students to explain the difference this concept makes to the caller or to the person using the result.
-->

---

## ref and out make caller storage part of the contract

- ref requires a caller value before the call.
- out requires the helper to assign its output before returning normally.

<!--
Connect out to the already familiar TryParse pattern: one Boolean result communicates success and an output parameter receives a value. Do not infer successful parsing from a numeric output of zero because zero may also be valid input. Ordinary return is simpler for the delivery sum.
-->

---

## Challenge a plausible wrong result

Check zero amount, zero charge and repeated calls with different charges. Verify that the original caller values remain unchanged.

> Name one changed input that would expose a wrong boundary, missing case or unintended state change.

<!--
Ask for a counterexample before modifying the program. Answer A. A hidden dependency on previous calls makes isolated tests and reasoning harder; explicit parameters expose the needed inputs. The trace provides an independent explanation of the ordinary case. The parameter amount and the caller variable amount are separate storage locations for this value-type example. Returning 15 does not mutate the caller’s 12. ref would be a different, explicitly declared contract; prefer the simpler return here.
-->

---

<!-- _class: check -->

## Quick check 2

Why can unnecessary static mutable state make a helper harder to check?

1. Its output may depend on earlier calls
2. Static variables have no type
3. return cannot be used

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer A. A hidden dependency on previous calls makes isolated tests and reasoning harder; explicit parameters expose the needed inputs. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Guided Practice: Use a Returned Value**

Complete AddDelivery with local inputs and a returned sum. Print both the unchanged original amount and the returned result.

[Open the existing practice](0502_parameter.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Exercise cell m5-ea517946. Check 12 plus 3 gives 15 and zero plus 3 gives 3. Printing belongs to the caller. Do not use ref, out or shared static storage when a simple returned value meets this contract. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- Check zero amount, zero charge and repeated calls with different charges. Verify that the original caller values remain unchanged.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. The parameter amount and the caller variable amount are separate storage locations for this value-type example. Returning 15 does not mutate the caller’s 12. ref would be a different, explicitly declared contract; prefer the simpler return here. For the Your Turn activity, the instructor answer is: Exercise cell m5-ea517946. Check 12 plus 3 gives 15 and zero plus 3 gives 3. Printing belongs to the caller. Do not use ref, out or shared static storage when a simple returned value meets this contract.
-->

---

## Vocabulary to explain, not memorize

- Argument: call value
- parameter: helper input
- scope: where a name is available

[Chapter objectives and glossary](0500_methods.html)

<!--
Ask students to use each term in an explanation of this part’s case. Tie the vocabulary to the actions in the goals: Map arguments to parameters by position and type; Use a returned result without changing caller inputs; Distinguish local scope from shared static state. A correct definition without a correct trace is not yet sufficient evidence of application.
-->

---

<!-- _class: recap -->

## Recap and next step

- Map arguments to parameters by position and type
- Use a returned result without changing caller inputs
- Distinguish local scope from shared static state

[5.2 reading](0502_parameter.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. The parameter amount and the caller variable amount are separate storage locations for this value-type example. Returning 15 does not mutate the caller’s 12. ref would be a different, explicitly declared contract; prefer the simpler return here. Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: 5.1 and argument mapping in 5.2, 35 minutes; meeting 2: returned values in 5.2 and contracts in 5.3, 40 minutes; meeting 3: strings in 5.4 and synthesis in 5.5, 35 minutes. Total 110 minutes. Part 5.5 is a short core recap; 5.6 is optional supporting preparation.
-->

---

<!-- _class: section -->

## Returned Results and Method Contracts

5.3 · [5.3 reading](0503_signature_call.html)

Read, predict, trace, then apply.

<!--
Meeting 1: 5.1 and argument mapping in 5.2, 35 minutes; meeting 2: returned values in 5.2 and contracts in 5.3, 40 minutes; meeting 3: strings in 5.4 and synthesis in 5.5, 35 minutes. Total 110 minutes. Part 5.5 is a short core recap; 5.6 is optional supporting preparation. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. A supervisor asks whether a purchase is approved. A helper should answer that question as bool, so the caller can decide how and where to report it.
-->

---

## Goals and preparation

- Choose a Boolean, numeric or string return type from the question
- Separate calculating from printing
- Check every return path against the stated contract

[5.3 reading](0503_signature_call.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: 5.1 and argument mapping in 5.2, 35 minutes; meeting 2: returned values in 5.2 and contracts in 5.3, 40 minutes; meeting 3: strings in 5.4 and synthesis in 5.5, 35 minutes. Total 110 minutes. Part 5.5 is a short core recap; 5.6 is optional supporting preparation. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The business question

A supervisor asks whether a purchase is approved. A helper should answer that question as bool, so the caller can decide how and where to report it.

> What information, rule and observable result do we need?

<!--
A supervisor asks whether a purchase is approved. A helper should answer that question as bool, so the caller can decide how and where to report it. Ask pairs to name the input, required result and a possible wrong answer. Expected discussion: distinguish the stated business requirement from an implementation that merely runs. Use the trace in this part to make that distinction concrete.
-->

---

## Write the contract before the body

- State the accepted input domain
- Describe the exact returned result
- State whether output or other side effects are permitted

<!--
A returned result need not be a number to print. A method can answer a question, and a bool result can become the condition of an if statement. Suppose an order receives free delivery when its subtotal is at least 50. The question is whether an order qualifies, not how much its delivery costs. Keeping those contracts distinct helps explain why two related methods may have different return types. Trace the boundary: 49.99 does not qualify, 50 qualifies, and 50.01 qualifies. The equality is part of the rule. Writing `>` instead of `>=` would still compile and would pass examples far from the threshold. The boundary cases distinguish the intended rule from that plausible defect. The general form is `static bool QuestionName(parameterList) { return condition; }`. Here the condition already has type bool. There is no need to convert it into the strings `"true"` and `"false"`; those are text values and cannot serve as an if condition. Printing the answer inside a void method also does not give the caller a Boolean result to use. Guided variation: qualification additionally requires a nonnegative subtotal. Explain whether that is an input precondition or a condition the method must check. Either design can be explicit, but silently switching between them makes testing and reuse confusing. State the accepted domain before writing your new tests. For related explanation, see the further reading below.[^development-reading]  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The boundary row distinguishes <= from <; the manager-false row distinguishes the intended AND rule from a test that ignores approval. The helper returns a Boolean instead of a message, allowing multiple callers to use it.
-->

---

## Returning and printing are different interfaces

- A bool result can control a later decision
- A numeric result can feed later arithmetic
- A string result can be displayed by the caller

<!--
You probably have used mathematical functions in algebra class, but they all had calculated values associated with them. For instance if you defined > F(x)=x{sup}`2` then it follows that F(3) is 3{sup}`2` = 9, and F(3)+F(4) is 3{sup}`2` + 4{sup}`2` = 9 + 16 = 25. Method calls in expressions get replaced during evaluation by the value of the method. That's why when we can directly print out (line# 12-13) the result of the method call in the following code. The corresponding definition and examples in C# would be the following:  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The boundary row distinguishes <= from <; the manager-false row distinguishes the intended AND rule from a test that ignores approval. The helper returns a Boolean instead of a message, allowing multiple callers to use it.
-->

---

## Check an approval contract

| Amount | Manager approved | amount ≤ 100 | Returned approval |
| ---: | --- | --- | --- |
| 99 | true | true | true |
| 100 | true | true | true |
| 101 | true | false | false |
| 50 | false | true | false |

<!--
The boundary row distinguishes <= from <; the manager-false row distinguishes the intended AND rule from a test that ignores approval. The helper returns a Boolean instead of a message, allowing multiple callers to use it. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
Console.WriteLine(CanApprove(100, true));
Console.WriteLine(CanApprove(101, true));
Console.WriteLine(CanApprove(50, false));
bool CanApprove(int amount, bool managerApproved)
{
    return amount <= 100 && managerApproved;
}
```

```output
True
False
False
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is 'True\nFalse\nFalse\n'. The boundary row distinguishes <= from <; the manager-false row distinguishes the intended AND rule from a test that ignores approval. The helper returns a Boolean instead of a message, allowing multiple callers to use it. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

A numeric helper prints 10.00 but returns nothing. Does it meet a contract requiring a decimal result?

1. Yes, the digits match
2. No, the caller needs a returned numeric value
3. Only if the console is open

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. Matching visible digits cannot substitute for the required return type and usable result. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

## Every reachable path must honor the result type

- Early return can settle a case immediately
- Boundary operators encode the business rule
- A plausible AI candidate still needs independent checks

<!--
 The C# syntax to notice is the **return statement**, with the word `return` followed by an expression, value, or variable(s). Methods that return values can be used in expressions (e.g., line# 13: F(3) + F(4)), just like in math class. When an expression with a method call is evaluated, the method call is effectively replaced temporarily by its returned value. Inside the C# method, the value to be returned is given by the expression in the `return` statement. Since the method returns data, and all data in C# is typed, there must be a type given for the value returned. Note that the method header does not start with `static void`. In place of `void` is `int`. The `void` in earlier method header meant nothing was returned. The `int` here means that a value *is* returned and its type is `int`. After the method `F` finishes executing from inside  The boundary row distinguishes <= from <; the manager-false row distinguishes the intended AND rule from a test that ignores approval. The helper returns a Boolean instead of a message, allowing multiple callers to use it. Ask students to explain the difference this concept makes to the caller or to the person using the result.
-->

---

## Review a prepared candidate against every clause

- A fixed handling amount and a percentage contribution are separate requirements.
- One ordinary passing example cannot establish the complete contract.

<!--
For fixed4plus subtotal times0.05, subtotal30requires5.50 and subtotal0requires4.00. A candidate returning only the product omits the fixed part. A generated explanation is evidence to inspect; students can do this review entirely offline.
-->

---

## Challenge a plausible wrong result

Check a typical input, zero contribution and the exact business cutoff. Do not derive the expected value by calling the same candidate again.

> Name one changed input that would expose a wrong boundary, missing case or unintended state change.

<!--
Ask for a counterexample before modifying the program. Answer B. The required result is four even when the variable contribution is zero; a candidate returning only the product gives zero. The trace provides an independent explanation of the ordinary case. The boundary row distinguishes <= from <; the manager-false row distinguishes the intended AND rule from a test that ignores approval. The helper returns a Boolean instead of a message, allowing multiple callers to use it.
-->

---

<!-- _class: check -->

## Quick check 2

A handling helper should return 4 + subtotal × rate. Which input exposes omission of the fixed 4?

1. Only a large subtotal
2. Zero subtotal
3. No input can expose it

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. The required result is four even when the variable contribution is zero; a candidate returning only the product gives zero. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Guided Practice: Return a Commission**

Implement the existing commission contract for nonnegative sales and rate. Keep printing in the caller and derive the expected results independently.

[Open the existing practice](0503_signature_call.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Exercise cell m5-9d98d0da. Return sales * rate. Checks: 200 at 0.05 gives 10.00, zero sales gives 0.00. The return type should support numeric composition; a formatted string is a different contract. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- Check a typical input, zero contribution and the exact business cutoff. Do not derive the expected value by calling the same candidate again.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. The boundary row distinguishes <= from <; the manager-false row distinguishes the intended AND rule from a test that ignores approval. The helper returns a Boolean instead of a message, allowing multiple callers to use it. For the Your Turn activity, the instructor answer is: Exercise cell m5-9d98d0da. Return sales * rate. Checks: 200 at 0.05 gives 10.00, zero sales gives 0.00. The return type should support numeric composition; a formatted string is a different contract.
-->

---

## Vocabulary to explain, not memorize

- Contract: domain/result/effects
- return type: result representation
- early return: complete one path

[Chapter objectives and glossary](0500_methods.html)

<!--
Ask students to use each term in an explanation of this part’s case. Tie the vocabulary to the actions in the goals: Choose a Boolean, numeric or string return type from the question; Separate calculating from printing; Check every return path against the stated contract. A correct definition without a correct trace is not yet sufficient evidence of application.
-->

---

<!-- _class: recap -->

## Recap and next step

- Choose a Boolean, numeric or string return type from the question
- Separate calculating from printing
- Check every return path against the stated contract

[5.3 reading](0503_signature_call.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. The boundary row distinguishes <= from <; the manager-false row distinguishes the intended AND rule from a test that ignores approval. The helper returns a Boolean instead of a message, allowing multiple callers to use it. Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: 5.1 and argument mapping in 5.2, 35 minutes; meeting 2: returned values in 5.2 and contracts in 5.3, 40 minutes; meeting 3: strings in 5.4 and synthesis in 5.5, 35 minutes. Total 110 minutes. Part 5.5 is a short core recap; 5.6 is optional supporting preparation.
-->

---

<!-- _class: section -->

## Strings and Their Methods

5.4 · [5.4 reading](0504_strings.html)

Read, predict, trace, then apply.

<!--
Meeting 1: 5.1 and argument mapping in 5.2, 35 minutes; meeting 2: returned values in 5.2 and contracts in 5.3, 40 minutes; meeting 3: strings in 5.4 and synthesis in 5.5, 35 minutes. Total 110 minutes. Part 5.5 is a short core recap; 5.6 is optional supporting preparation. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. A department code arrives with surrounding spaces and inconsistent letter case. Normalize it before comparison, while distinguishing an empty result from an actual department.
-->

---

## Goals and preparation

- Normalize text using explicit string operations
- Use indexes and substring bounds safely
- Explain immutability and capture returned strings

[5.4 reading](0504_strings.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: 5.1 and argument mapping in 5.2, 35 minutes; meeting 2: returned values in 5.2 and contracts in 5.3, 40 minutes; meeting 3: strings in 5.4 and synthesis in 5.5, 35 minutes. Total 110 minutes. Part 5.5 is a short core recap; 5.6 is optional supporting preparation. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The business question

A department code arrives with surrounding spaces and inconsistent letter case. Normalize it before comparison, while distinguishing an empty result from an actual department.

> What information, rule and observable result do we need?

<!--
A department code arrives with surrounding spaces and inconsistent letter case. Normalize it before comparison, while distinguishing an empty result from an actual department. Ask pairs to name the input, required result and a possible wrong answer. Expected discussion: distinguish the stated business requirement from an implementation that merely runs. Use the trace in this part to make that distinction concrete.
-->

---

## Strings expose positions and searches

- Length counts UTF-16 code units in this introductory model
- Indexes run from zero to Length - 1
- IndexOf reports -1 when the search fails

<!--
Business data is mostly text: customer names, email addresses, product codes, and notes. A C# `string` is an object that comes with many ready-made methods for working with that text. In this section you are the **consumer** of methods someone else wrote. To use one, you need to know only three things: its name, the parameters it expects, and what it returns. How the method does its work is the writer's concern, not yours.[^0504_strings-string-class] You call a string method with dot notation: the string, a dot, the method name, and the arguments in parentheses, as in `email.Trim()`. Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. A chain sends each returned string into the next method. The original raw string still includes its spaces. An all-whitespace input becomes empty and follows the Unknown policy rather than inventing a department.
-->

---

## Normalization is a stated policy

- Trim removes surrounding whitespace
- ToUpperInvariant supplies a reproducible case policy
- Decide explicitly what an empty normalized code means

<!--
Connect this lesson to writing your own helpers: a caller supplies arguments, receives a typed result, and must obey the contract whether the implementation is yours or the library's. Properties such as Length, indexers such as text[index], instance methods such as text.Trim(), and static calls such as string.IsNullOrWhiteSpace(text) have different syntax. These are patterns, not one program. Choose an actual method and compatible arguments. Keep returned values you need; do not mistake an immutable string operation for an in-place edit. Section 5.3 explains string.Format and returned formatting before the lab uses them.  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. A chain sends each returned string into the next method. The original raw string still includes its spaces. An all-whitespace input becomes empty and follows the Unknown policy rather than inventing a department.
-->

---

## Trace normalization without changing raw text

| Step | raw | cleaned/result |
| --- | --- | --- |
| Input | "  hr  " | not computed |
| Trim | unchanged | "hr" |
| Uppercase | unchanged | "HR" |
| Empty check | unchanged | Return HR |

<!--
A chain sends each returned string into the next method. The original raw string still includes its spaces. An all-whitespace input becomes empty and follows the Unknown policy rather than inventing a department. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
Console.WriteLine(Department("  hr  "));
Console.WriteLine(Department("   "));
string Department(string raw)
{
    string cleaned = raw.Trim().ToUpperInvariant();
    return cleaned.Length == 0 ? "Unknown" : cleaned;
}
```

```output
HR
Unknown
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is 'HR\nUnknown\n'. A chain sends each returned string into the next method. The original raw string still includes its spaces. An all-whitespace input becomes empty and follows the Unknown policy rather than inventing a department. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

raw.Trim() is called and its result ignored. What happens to raw?

1. It is modified in place
2. It remains unchanged
3. It becomes null

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. Strings are immutable; Trim returns the normalized value, which must be used or assigned. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

## String operations return new values

- Strings are immutable
- Capture the value returned by Trim or Replace
- Validate shape before extracting a substring

<!--
`Length` is a property, not a method, so it has no parentheses. It gives the number of UTF-16 code units; for the simple Latin-letter examples here these correspond to the visible characters. Some Unicode symbols occupy more than one code unit. Square brackets with an index give one character (a `char`). Indexes start at 0, so the last character is at `Length - 1`. A chain sends each returned string into the next method. The original raw string still includes its spaces. An all-whitespace input becomes empty and follows the Unknown policy rather than inventing a department. Ask students to explain the difference this concept makes to the caller or to the person using the result.
-->

---

## Guard a format before slicing it

- Find the delimiter and check its position.
- Only then extract the required nonempty pieces.

<!--
An email-like domain exercise needs a valid delimiter position and an explicit policy for empty pieces. Substring start and length must stay in bounds. Tests with no delimiter, a delimiter at the beginning and a delimiter at the end distinguish format checks from blind extraction.
-->

---

## Challenge a plausible wrong result

Check empty text, whitespace only, already normalized text and a missing delimiter. Non-null is an explicit input assumption for this helper.

> Name one changed input that would expose a wrong boundary, missing case or unintended state change.

<!--
Ask for a counterexample before modifying the program. Answer B. A failed search is a control signal. Establish that the delimiter and substring bounds are valid before extracting. The trace provides an independent explanation of the ordinary case. A chain sends each returned string into the next method. The original raw string still includes its spaces. An all-whitespace input becomes empty and follows the Unknown policy rather than inventing a department.
-->

---

<!-- _class: check -->

## Quick check 2

IndexOf returns -1 before a substring extraction. What should happen first?

1. Treat -1 as the last character
2. Check the missing-delimiter policy
3. Add one and assume the format is valid

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. A failed search is a control signal. Establish that the delimiter and substring bounds are valid before extracting. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Guided Practice: Clean a Department Code**

Complete the existing non-null department-code helper. Return Unknown for whitespace-only input and keep output in the caller.

[Open the existing practice](0504_strings.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Exercise cell m5-d6fabf59. Trim, test the cleaned length, then return invariant uppercase. Check an already normalized code as well as hr with spaces. The compact demonstration uses a conditional return; an if/return form is equally suitable. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- Check empty text, whitespace only, already normalized text and a missing delimiter. Non-null is an explicit input assumption for this helper.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. A chain sends each returned string into the next method. The original raw string still includes its spaces. An all-whitespace input becomes empty and follows the Unknown policy rather than inventing a department. For the Your Turn activity, the instructor answer is: Exercise cell m5-d6fabf59. Trim, test the cleaned length, then return invariant uppercase. Check an already normalized code as well as hr with spaces. The compact demonstration uses a conditional return; an if/return form is equally suitable.
-->

---

## Vocabulary to explain, not memorize

- Immutable: contents cannot change
- normalization: chosen text policy
- substring: bounded extracted text

[Chapter objectives and glossary](0500_methods.html)

<!--
Ask students to use each term in an explanation of this part’s case. Tie the vocabulary to the actions in the goals: Normalize text using explicit string operations; Use indexes and substring bounds safely; Explain immutability and capture returned strings. A correct definition without a correct trace is not yet sufficient evidence of application.
-->

---

<!-- _class: recap -->

## Recap and next step

- Normalize text using explicit string operations
- Use indexes and substring bounds safely
- Explain immutability and capture returned strings

[5.4 reading](0504_strings.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. A chain sends each returned string into the next method. The original raw string still includes its spaces. An all-whitespace input becomes empty and follows the Unknown policy rather than inventing a department. Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: 5.1 and argument mapping in 5.2, 35 minutes; meeting 2: returned values in 5.2 and contracts in 5.3, 40 minutes; meeting 3: strings in 5.4 and synthesis in 5.5, 35 minutes. Total 110 minutes. Part 5.5 is a short core recap; 5.6 is optional supporting preparation.
-->

---

<!-- _class: section -->

## Composition, Refactoring, and Method Checks

5.5 · [5.5 reading](0505_summary.html)

Core synthesis within meeting 3.

<!--
Meeting 1: 5.1 and argument mapping in 5.2, 35 minutes; meeting 2: returned values in 5.2 and contracts in 5.3, 40 minutes; meeting 3: strings in 5.4 and synthesis in 5.5, 35 minutes. Total 110 minutes. Part 5.5 is a short core recap; 5.6 is optional supporting preparation. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. An invoice line needs a numeric calculation and a readable description. Let one helper calculate the amount, another compose the text, and the caller choose when to print.
-->

---

## Goals and preparation

- Compose a report from small returned results
- Refactor while preserving an observable contract
- Select checks that distinguish plausible defects

[5.5 reading](0505_summary.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: 5.1 and argument mapping in 5.2, 35 minutes; meeting 2: returned values in 5.2 and contracts in 5.3, 40 minutes; meeting 3: strings in 5.4 and synthesis in 5.5, 35 minutes. Total 110 minutes. Part 5.5 is a short core recap; 5.6 is optional supporting preparation. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## Composition turns returned values into inputs

- LineTotal returns a numeric result
- LineDescription calls LineTotal
- The caller prints the returned description

<!--
An invoice caller repeats price-times-quantity arithmetic in several places. Extracting LineTotal can give that calculation one name, but a safe refactoring needs more than moving those characters into braces. First record the existing accepted inputs, numerical outputs, formatting and mutation behavior. Then choose the new method's inputs/result so that callers can express the same work without depending on its internal temporary variables. For price 12 and quantity three, independently calculate 36 before running either version. A fixed packing charge of four makes the order total 40. Keep these two contracts distinct: LineTotal returns 36; OrderTotal returns 40. If the extracted line calculation starts adding packing as well, a caller that already adds packing can charge it twice even though both helper methods contain plausible arithmetic. | Refactoring stage | Evidence to retain | | --- | --- | | Before extraction | Expected amount and current observable output | | After extracting LineTotal | Same line amount for ordinary and zero inputs | | After composing OrderTotal | Exactly one application of the fixed charge | | After formatting a report | Same numerical meaning; display policy stays explicit | A useful composition passes returned values between helpers. It does not make each helper prompt independently for the same data. If CalculateTotal reads a second quantity while the caller formats the first, the report can display one order and charge another. Keep interaction in the caller and pass the accepted values into calculation helpers. For related explanation, see the further reading below.[^development-reading]  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The description helper must reuse LineTotal rather than duplicate the arithmetic. A calculation helper does not print. This separation allows a future report or test to use the same numeric contract without parsing text.
-->

---

## Follow a line through two helpers

| Stage | Inputs | Result |
| --- | --- | --- |
| LineTotal | quantity 3, price 7 | 21 |
| LineDescription | code PEN, numeric result 21 | PEN: 21 |
| Caller | returned string | One output line |
| Independent check | quantity 0, price 7 | Numeric total 0 |

<!--
The description helper must reuse LineTotal rather than duplicate the arithmetic. A calculation helper does not print. This separation allows a future report or test to use the same numeric contract without parsing text. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
Console.WriteLine(LineDescription("PEN", 3, 7));
Console.WriteLine(LineTotal(0, 7) == 0);
int LineTotal(int quantity, int price) => quantity * price;
string LineDescription(string code, int quantity, int price)
{
    return $"{code}: {LineTotal(quantity, price)}";
}
```

```output
PEN: 21
True
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is 'PEN: 21\nTrue\n'. The description helper must reuse LineTotal rather than duplicate the arithmetic. A calculation helper does not print. This separation allows a future report or test to use the same numeric contract without parsing text. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

During extraction, the helper starts printing intermediate totals. Is that necessarily behavior-preserving?

1. Yes, calculations are unchanged
2. No, output is part of the observable contract
3. Yes, helper output is invisible

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. New console lines change externally observable behavior even if the numeric return remains correct. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: check -->

## Quick check 2

A checkout candidate omits a fixed packing charge. Which tests help expose it?

1. Only repeated calls to the candidate
2. Independent expected totals including zero quantity
3. Changing expected values to match it

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. Expected values should come from the rule; a zero case can isolate fixed charges. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Guided Synthesis: Report a Line Total**

Complete the existing LineTotal and LineDescription synthesis. Require the description to call the calculation helper; print only in the caller.

[Open the existing practice](0505_summary.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Exercise cell m5-751ba022. Derive two numeric expected totals independently and add zero quantity under the stated nonnegative domain. A correct textual report alone does not establish the required composition. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- Check zero, one and several items, and compare output before and after extraction. Supporting recursion is not required for this core assignment.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. The description helper must reuse LineTotal rather than duplicate the arithmetic. A calculation helper does not print. This separation allows a future report or test to use the same numeric contract without parsing text. For the Your Turn activity, the instructor answer is: Exercise cell m5-751ba022. Derive two numeric expected totals independently and add zero quantity under the stated nonnegative domain. A correct textual report alone does not establish the required composition.
-->

---

<!-- _class: recap -->

## Recap and next step

- Compose a report from small returned results
- Refactor while preserving an observable contract
- Select checks that distinguish plausible defects

[5.5 reading](0505_summary.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. The description helper must reuse LineTotal rather than duplicate the arithmetic. A calculation helper does not print. This separation allows a future report or test to use the same numeric contract without parsing text. Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: 5.1 and argument mapping in 5.2, 35 minutes; meeting 2: returned values in 5.2 and contracts in 5.3, 40 minutes; meeting 3: strings in 5.4 and synthesis in 5.5, 35 minutes. Total 110 minutes. Part 5.5 is a short core recap; 5.6 is optional supporting preparation.
-->

---

<!-- _class: section -->

## Supporting Reading: Recursive Methods

5.6 · [5.6 reading](0506_recursive_methods.html)

Optional supporting reading. No added meeting or required assessment.

<!--
Meeting 1: 5.1 and argument mapping in 5.2, 35 minutes; meeting 2: returned values in 5.2 and contracts in 5.3, 40 minutes; meeting 3: strings in 5.4 and synthesis in 5.5, 35 minutes. Total 110 minutes. Part 5.5 is a short core recap; 5.6 is optional supporting preparation. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. A deadline countdown can print one value, then delegate the shorter countdown to the same method. The call must move toward a base case.
-->

---

## Goals and preparation

- Identify a base case and a smaller subproblem
- Trace calls and returned results
- Choose a loop or recursion deliberately

[5.6 reading](0506_recursive_methods.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: 5.1 and argument mapping in 5.2, 35 minutes; meeting 2: returned values in 5.2 and contracts in 5.3, 40 minutes; meeting 3: strings in 5.4 and synthesis in 5.5, 35 minutes. Total 110 minutes. Part 5.5 is a short core recap; 5.6 is optional supporting preparation. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## A recursive method can call itself

- A base case completes without another recursive call
- A recursive case reduces the problem
- Each active call has its own local state

<!--
This supporting reading extends the chapter's method skills; it is not a prerequisite for the required assignments. Read it once you are comfortable defining a method, passing arguments, and returning a value. For related explanation, see the further reading below.[^development-reading]  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The calls descend to zero before the pending additions finish. Each recursive call must decrease a nonnegative input. A base case alone does not help if the recursive argument never approaches it.
-->

---

## Trace SumTo(3)

| Call | Pending work | Returned value |
| --- | --- | ---: |
| SumTo(3) | 3 + SumTo(2) | 6 |
| SumTo(2) | 2 + SumTo(1) | 3 |
| SumTo(1) | 1 + SumTo(0) | 1 |
| SumTo(0) | Base case | 0 |

<!--
The calls descend to zero before the pending additions finish. Each recursive call must decrease a nonnegative input. A base case alone does not help if the recursive argument never approaches it. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
Console.WriteLine(SumTo(3));
Console.WriteLine(SumTo(0));
int SumTo(int n)
{
    if (n == 0) return 0;
    return n + SumTo(n - 1);
}
```

```output
6
0
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is '6\n0\n'. The calls descend to zero before the pending additions finish. Each recursive call must decrease a nonnegative input. A base case alone does not help if the recursive argument never approaches it. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

Which property makes this nonnegative-input recursion terminate?

1. The method has a short name
2. n decreases toward zero
3. Every call prints

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. The base case is reachable because the recursive argument decreases. Negative inputs are outside this stated demonstration domain. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Guided Practice: Count the Digits of an Order Number**

Trace the existing digit-counting practice before running. Identify the base case and the smaller integer passed recursively.

[Open the existing practice](0506_recursive_methods.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Existing supporting exercise identity remains unchanged. A one-digit nonnegative number has one digit; larger numbers reduce by integer division by ten. In particular zero must return one digit, not zero. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

<!-- _class: recap -->

## Recap and next step

- Identify a base case and a smaller subproblem
- Trace calls and returned results
- Choose a loop or recursion deliberately

[5.6 reading](0506_recursive_methods.html) · Optional reading; no required assessment.

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. The calls descend to zero before the pending additions finish. Each recursive call must decrease a nonnegative input. A base case alone does not help if the recursive argument never approaches it. This supporting part is optional and does not add a core assessment prerequisite. Meeting 1: 5.1 and argument mapping in 5.2, 35 minutes; meeting 2: returned values in 5.2 and contracts in 5.3, 40 minutes; meeting 3: strings in 5.4 and synthesis in 5.5, 35 minutes. Total 110 minutes. Part 5.5 is a short core recap; 5.6 is optional supporting preparation.
-->
