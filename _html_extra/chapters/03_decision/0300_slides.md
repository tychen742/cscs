---
marp: true
theme: thinkpress-lecture
paginate: true
title: "Decisions"
book: "Computer Science in C#"
section: "Chapter 3"
primary: "#2a6b37"
accent: "#b8860b"
---

<!-- _class: title -->

# Decisions

Chapter 3 · Computer Science in C#

<!--
Part map (1-based slide numbers): 3.1 Boolean Expressions and Logical Operators: slide 2; 3.2 Conditional Selection with if and switch: slide 18. Meeting 1: Boolean rules in 3.1, 35 minutes; meeting 2: if/else and ordered tiers in 3.2, 40 minutes; meeting 3: switch/default and transfer practice in 3.2, 35 minutes. Total 110 minutes. Use selected examples and checks inside the existing allocation. Additional source detail remains preparation/reference reading. Every example is standalone; instructor answers remain in notes.
-->

---

<!-- _class: section -->

## Boolean Expressions and Logical Operators

3.1 · [3.1 reading](0301_intro_decision.html)

Read, predict, trace, then apply.

<!--
Meeting 1: Boolean rules in 3.1, 35 minutes; meeting 2: if/else and ordered tiers in 3.2, 40 minutes; meeting 3: switch/default and transfer practice in 3.2, 35 minutes. Total 110 minutes. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. An order ships free when its total is at least 50 and it is not international. Both conditions belong to the rule; meeting only one is insufficient.
-->

---

## Goals and preparation

- Translate a business rule into a Boolean expression
- Combine conditions with AND, OR and NOT
- Choose boundary and counterexample inputs

[3.1 reading](0301_intro_decision.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: Boolean rules in 3.1, 35 minutes; meeting 2: if/else and ordered tiers in 3.2, 40 minutes; meeting 3: switch/default and transfer practice in 3.2, 35 minutes. Total 110 minutes. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The business question

An order ships free when its total is at least 50 and it is not international. Both conditions belong to the rule; meeting only one is insufficient.

> What information, rule and observable result do we need?

<!--
An order ships free when its total is at least 50 and it is not international. Both conditions belong to the rule; meeting only one is insufficient. Ask pairs to name the input, required result and a possible wrong answer. Expected discussion: distinguish the stated business requirement from an implementation that merely runs. Use the trace in this part to make that distinction concrete.
-->

---

## A Boolean expression answers a precise question

- A bool value is True or False
- Comparison operators produce Boolean results
- Equality asks about values; assignment changes state

<!--
 Selection statements, sometimes referred to as conditional statements, are one of the three basic constructs (sequence, selection, iteration) in programming. Selection statements provide the logic to perform decision-making: taking different actions based on different conditions. When selecting from possible paths for execution, the decisions are made based on the value of an expression. C# has the following conditional statements: - The `if` statement specifies a block of code to be executed, only if a provided Boolean expression evaluates to `true`. - The `if-else` statement allows you to choose which of the two code paths to follow based on a Boolean expression. - The `else if` statement specifies a new `condition` to `test`. - `switch` statement selects from a list of code to execute based on a pattern match with an expression. The basic syntax for an if statement is:  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The equal-to case distinguishes >= from >. The international rows distinguish AND from OR. Ask which single row is enough to refute a candidate that uses OR: total 50 and international true is one counterexample.
-->

---

## Choose the connector from the requirement

- AND requires both conditions
- OR permits either condition, including both
- NOT reverses a Boolean result

<!--
 Here, `condition` is a **Boolean expression** — an expression that evaluates to either `true` or `false`. The parentheses around it are required syntax: they tell the compiler where the condition begins and ends, distinguishing it from the body of the `if` statement. This is different from parentheses in arithmetic expressions, where they are used to control the order of operations.  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The equal-to case distinguishes >= from >. The international rows distinguish AND from OR. Ask which single row is enough to refute a candidate that uses OR: total 50 and international true is one counterexample.
-->

---

## Build a decision table first

| Total | International | Total ≥ 50 | Not international | Free? |
| ---: | --- | --- | --- | --- |
| 49 | false | false | true | false |
| 50 | false | true | true | true |
| 50 | true | true | false | false |
| 80 | true | true | false | false |

<!--
The equal-to case distinguishes >= from >. The international rows distinguish AND from OR. Ask which single row is enough to refute a candidate that uses OR: total 50 and international true is one counterexample. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
int total = 50;
bool international = false;
bool freeShipping = total >= 50 && !international;
Console.WriteLine(freeShipping);
international = true;
Console.WriteLine(total >= 50 && !international);
```

```output
True
False
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is 'True\nFalse\n'. The equal-to case distinguishes >= from >. The international rows distinguish AND from OR. Ask which single row is enough to refute a candidate that uses OR: total 50 and international true is one counterexample. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

For free shipping, total ≥ 50 is true and international is true. What is the result?

1. True
2. False
3. The rule cannot decide

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. NOT international is false, so the AND condition is false even though the total qualifies. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

## Short-circuit evaluation follows left to right

- AND stops when the left side is false
- OR stops when the left side is true
- A guard can prevent an unsafe later operation

<!--
Run the pattern on a real decision before reading about the other forms. A store charges shipping unless the order total reaches 50:  The equal-to case distinguishes >= from >. The international rows distinguish AND from OR. Ask which single row is enough to refute a candidate that uses OR: total 50 and international true is one counterexample. Ask students to explain the difference this concept makes to the caller or to the person using the result.
-->

---

## Guard the unsafe operation on the right

- A missing-input check must precede a property access.
- Short-circuit AND can skip an unsafe right operand.

<!--
For text != null AND text.Length >0, the second test runs only if a line exists. Reverse the order and the missing-input protection is lost. This is a reason to preserve evaluation dependencies when translating nested decisions.
-->

---

## Challenge a plausible wrong result

Check 49, 50 and 51, each with international true and false. A plausible expression needs tests that distinguish its connector and boundary.

> Name one changed input that would expose a wrong boundary, missing case or unintended state change.

<!--
Ask for a counterexample before modifying the program. Answer B. A compound expression can combine appropriate tests, but it does not automatically preserve different actions or evaluation dependencies. The trace provides an independent explanation of the ordinary case. The equal-to case distinguishes >= from >. The international rows distinguish AND from OR. Ask which single row is enough to refute a candidate that uses OR: total 50 and international true is one counterexample.
-->

---

<!-- _class: check -->

## Quick check 2

Can every nested decision be replaced by one compound condition without considering branch behavior?

1. Always
2. Only after checking that the decisions and actions remain equivalent
3. Never

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. A compound expression can combine appropriate tests, but it does not automatically preserve different actions or evaluation dependencies. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Guided Practice: Decide Free Shipping**

Complete the existing free-shipping expression. Predict the ordinary case, exact threshold and international exclusion before running.

[Open the existing practice](0301_intro_decision.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Exercise cell p4_c40102fa98. Expected lines True and False. Use total >= 50 AND NOT international; preserve the provided assessment identity and avoid introducing methods. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- Check 49, 50 and 51, each with international true and false. A plausible expression needs tests that distinguish its connector and boundary.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. The equal-to case distinguishes >= from >. The international rows distinguish AND from OR. Ask which single row is enough to refute a candidate that uses OR: total 50 and international true is one counterexample. For the Your Turn activity, the instructor answer is: Exercise cell p4_c40102fa98. Expected lines True and False. Use total >= 50 AND NOT international; preserve the provided assessment identity and avoid introducing methods.
-->

---

## Vocabulary to explain, not memorize

- Boolean: two-valued result
- compound condition: combined tests
- short circuit: skip an unnecessary right operand

[Chapter objectives and glossary](0300_conditionals.html)

<!--
Ask students to use each term in an explanation of this part’s case. Tie the vocabulary to the actions in the goals: Translate a business rule into a Boolean expression; Combine conditions with AND, OR and NOT; Choose boundary and counterexample inputs. A correct definition without a correct trace is not yet sufficient evidence of application.
-->

---

<!-- _class: recap -->

## Recap and next step

- Translate a business rule into a Boolean expression
- Combine conditions with AND, OR and NOT
- Choose boundary and counterexample inputs

[3.1 reading](0301_intro_decision.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. The equal-to case distinguishes >= from >. The international rows distinguish AND from OR. Ask which single row is enough to refute a candidate that uses OR: total 50 and international true is one counterexample. Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: Boolean rules in 3.1, 35 minutes; meeting 2: if/else and ordered tiers in 3.2, 40 minutes; meeting 3: switch/default and transfer practice in 3.2, 35 minutes. Total 110 minutes.
-->

---

<!-- _class: section -->

## Conditional Selection with if and switch

3.2 · [3.2 reading](0302_ifstatement.html)

Read, predict, trace, then apply.

<!--
Meeting 1: Boolean rules in 3.1, 35 minutes; meeting 2: if/else and ordered tiers in 3.2, 40 minutes; meeting 3: switch/default and transfer practice in 3.2, 35 minutes. Total 110 minutes. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. A delivery desk recognizes free pickup and paid shipping. An unknown service code must not accidentally receive the valid pickup charge of zero.
-->

---

## Goals and preparation

- Choose one-way, two-way and multiple-way selection
- Trace first-match and nested decisions
- Handle unsupported switch values explicitly

[3.2 reading](0302_ifstatement.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: Boolean rules in 3.1, 35 minutes; meeting 2: if/else and ordered tiers in 3.2, 40 minutes; meeting 3: switch/default and transfer practice in 3.2, 35 minutes. Total 110 minutes. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The business question

A delivery desk recognizes free pickup and paid shipping. An unknown service code must not accidentally receive the valid pickup charge of zero.

> What information, rule and observable result do we need?

<!--
A delivery desk recognizes free pickup and paid shipping. An unknown service code must not accidentally receive the valid pickup charge of zero. Ask pairs to name the input, required result and a possible wrong answer. Expected discussion: distinguish the stated business requirement from an implementation that merely runs. Use the trace in this part to make that distinction concrete.
-->

---

## The branch structure expresses the policy

- if selects an optional action
- if/else selects one of two actions
- An else-if chain selects the first true condition

<!--
An order desk needs one charge for each service code: express `E` costs 8, standard `S` costs 3, and pickup `P` costs 0. An unknown code must be reported as invalid. Keep this rule in mind while learning the selection forms below. After `if`, `else if`, nesting, and `switch`, the final comparison returns to the same rule and tests whether different forms preserve it.  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. A zero charge is legitimate for P and cannot double as an unknown-code sentinel. In a top-level program, return can stop the program before a later charge report. A break only leaves the switch.
-->

---

## Ordering overlapping conditions matters

- Place a narrower high-priority rule before a broader one
- Separate independent if statements can both run
- Indentation helps readers; braces define the block

<!--
 The `if` statement specifies a block of C# code to be executed if a condition is True. :::{note} Note that C# is case sensitive, so `If` is not the same as `if`. "If" or "IF" will generate an error. ::: In `if` statements, the comparison operators (`>`, `=`, `<=`, `==`, and `!=`) are used to evaluate the comparison expressions to derive a value of either `true` or `false` from the Boolean expression. The first step to learn about the `if` statements is to perform some tests on the operators with `csharprepl`, `Run C#`, or a small test project, such as: with the output: When coding, we often play with variables rather than simple values. Observe the following code and test it with `csharprepl`, `Run C#`, or a small VS Code project to practice `if` statements with variables: Consider simple arithmetic comparisons that directly translate from math into C#. Run this C# code: Now think of which of these expressions below are true and which false, and then enter each one into your csharp session to test: You see that the expressions evaluate to either `true` or `false`. These are the only possible *Boolean* values. Run the example program below. Try it at least twice, with inputs: 30 and then 55. As you can see, you get different results, depending on the input. The main code is:  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. A zero charge is legitimate for P and cannot double as an unknown-code sentinel. In a top-level program, return can stop the program before a later charge report. A break only leaves the switch.
-->

---

## Trace recognized and unsupported services

| Service | Selected path | Report charge? |
| --- | --- | --- |
| P | Pickup case | Yes: free pickup |
| S | Shipping case | Yes: 8 |
| X | Default | No: unknown service |
| Empty text | Default | No: unknown service |

<!--
A zero charge is legitimate for P and cannot double as an unknown-code sentinel. In a top-level program, return can stop the program before a later charge report. A break only leaves the switch. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
string service = "X";
int charge;
switch (service)
{
    case "P": charge = 0; break;
    case "S": charge = 8; break;
    default: Console.WriteLine("Unknown service"); return;
}
Console.WriteLine($"Charge: {charge}");
```

```output
Unknown service
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is 'Unknown service\n'. A zero charge is legitimate for P and cannot double as an unknown-code sentinel. In a top-level program, return can stop the program before a later charge report. A break only leaves the switch. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

In an else-if chain, a score satisfies both score ≥ 60 and score ≥ 90. Which branch runs?

1. Both
2. The first true branch
3. The last true branch

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. A chain commits to its first true branch. Put a top tier before a broader passing tier when that is the intended policy. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

## A switch selects a discrete case

- Use explicit recognized codes
- break leaves the switch, then later statements continue
- default must implement the unsupported-input policy

<!--
Change `weight` to 50 and then 55. At 50 the charge is skipped; at 55 it is printed. The thank-you message follows the `if` block and always runs. You can see from this code that: 1. the general C# syntax for a simple `if` statement is: 2. If the condition is `true`, then `execute` the statement(s) in braces. If the condition is `not true`, then `skip` the statements in braces. 3. The `condition` is an `expression` that evaluates to either true or false, of type **boolean**. 4. An `if` statement only affects the normal sequential order *inside* the `if` statement itself (e.g., skipping the extra charge block when the condition is not true and still print the “thank you” line). Another code fragment of banking account transaction as an example: if (balance < 0) { transfer = - balance; // transfer enough from the backup account: backupAccount = backupAccount - transfer; balance = balance + transfer; } The assumption in the example above is that if an account goes negative, it is brought back to 0 by transferring money from a backup account. Note that the choice is between - **doing something** (if the condition is `true`) or - **nothing** (if the condition is `false`). A zero charge is legitimate for P and cannot double as an unknown-code sentinel. In a top-level program, return can stop the program before a later charge report. A break only leaves the switch. Ask students to explain the difference this concept makes to the caller or to the person using the result.
-->

---

## Equivalent decisions need equivalent actions

- Separate if statements and one else-if chain do not promise the same behavior.
- A combined condition must preserve the original meaning and safe evaluation order.

<!--
With score95, separate tests score>=60 and score>=90 can both print; an else-if chain prints only its first match. Ask students to compare branch actions before shortening source. Fewer lines alone is not evidence of an equivalent policy.
-->

---

## Challenge a plausible wrong result

Check every named case, an unsupported value, and each tier just below, at and above its cutoff. A successful recognized case does not verify the default path.

> Name one changed input that would expose a wrong boundary, missing case or unintended state change.

<!--
Ask for a counterexample before modifying the program. Answer B. To prevent a later report for an unsupported value, use an explicit failure path such as a top-level return. The trace provides an independent explanation of the ordinary case. A zero charge is legitimate for P and cannot double as an unknown-code sentinel. In a top-level program, return can stop the program before a later charge report. A break only leaves the switch.
-->

---

<!-- _class: check -->

## Quick check 2

What does break inside a switch do?

1. Ends the entire program
2. Leaves the switch and continues afterward
3. Automatically marks the input invalid

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. To prevent a later report for an unsupported value, use an explicit failure path such as a top-level return. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Explain an Invalid Code**

Repair the existing invalid-service exercise so P remains free pickup and X produces Unknown service without a charge report.

[Open the existing practice](0302_ifstatement.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Existing exercise cell tabs19_invalid_starter. Instructor answer: preserve case P and its zero charge; default prints Unknown service and returns before the report. Verify P and X separately. No loops or helper methods are needed. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- Check every named case, an unsupported value, and each tier just below, at and above its cutoff. A successful recognized case does not verify the default path.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. A zero charge is legitimate for P and cannot double as an unknown-code sentinel. In a top-level program, return can stop the program before a later charge report. A break only leaves the switch. For the Your Turn activity, the instructor answer is: Existing exercise cell tabs19_invalid_starter. Instructor answer: preserve case P and its zero charge; default prints Unknown service and returns before the report. Verify P and X separately. No loops or helper methods are needed.
-->

---

## Vocabulary to explain, not memorize

- Branch: selected action
- first match: one selected tier
- default: unsupported-case policy

[Chapter objectives and glossary](0300_conditionals.html)

<!--
Ask students to use each term in an explanation of this part’s case. Tie the vocabulary to the actions in the goals: Choose one-way, two-way and multiple-way selection; Trace first-match and nested decisions; Handle unsupported switch values explicitly. A correct definition without a correct trace is not yet sufficient evidence of application.
-->

---

<!-- _class: recap -->

## Recap and next step

- Choose one-way, two-way and multiple-way selection
- Trace first-match and nested decisions
- Handle unsupported switch values explicitly

[3.2 reading](0302_ifstatement.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. A zero charge is legitimate for P and cannot double as an unknown-code sentinel. In a top-level program, return can stop the program before a later charge report. A break only leaves the switch. Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: Boolean rules in 3.1, 35 minutes; meeting 2: if/else and ordered tiers in 3.2, 40 minutes; meeting 3: switch/default and transfer practice in 3.2, 35 minutes. Total 110 minutes.
-->
