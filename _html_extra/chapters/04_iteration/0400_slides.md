---
marp: true
theme: thinkpress-lecture
paginate: true
title: "Iteration"
book: "Computer Science in C#"
section: "Chapter 4"
primary: "#2a6b37"
accent: "#b8860b"
---

<!-- _class: title -->

# Iteration

Chapter 4 · Computer Science in C#

<!--
Part map (1-based slide numbers): 4.1 Iteration and Loop Planning: slide 2; 4.2 The for Statement and Counted Traversal: slide 18; 4.3 while, do-while and Validation: slide 34; 4.4 Supporting Reading: Greatest Common Divisor: slide 50. Meeting 1: loop plans in 4.1, 35 minutes; meeting 2: counted traversal in 4.2, 40 minutes; meeting 3: state-controlled loops in 4.3, 35 minutes. Total 110 minutes. GCD is supporting reading, not a fourth meeting. Use selected examples and checks inside the existing allocation. Additional source detail remains preparation/reference reading. Every example is standalone; instructor answers remain in notes.
-->

---

<!-- _class: section -->

## Iteration and Loop Planning

4.1 · [4.1 reading](0401_iteration.html)

Read, predict, trace, then apply.

<!--
Meeting 1: loop plans in 4.1, 35 minutes; meeting 2: counted traversal in 4.2, 40 minutes; meeting 3: state-controlled loops in 4.3, 35 minutes. Total 110 minutes. GCD is supporting reading, not a fourth meeting. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. At closing time a desk announces 6, 4 and 2 minutes remaining, then stops. State the intended values before selecting the loop syntax.
-->

---

## Goals and preparation

- Plan initialization, condition, body and progress
- Trace state across repeated work
- Distinguish break, continue and normal completion

[4.1 reading](0401_iteration.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: loop plans in 4.1, 35 minutes; meeting 2: counted traversal in 4.2, 40 minutes; meeting 3: state-controlled loops in 4.3, 35 minutes. Total 110 minutes. GCD is supporting reading, not a fourth meeting. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The business question

At closing time a desk announces 6, 4 and 2 minutes remaining, then stops. State the intended values before selecting the loop syntax.

> What information, rule and observable result do we need?

<!--
At closing time a desk announces 6, 4 and 2 minutes remaining, then stops. State the intended values before selecting the loop syntax. Ask pairs to name the input, required result and a possible wrong answer. Expected discussion: distinguish the stated business requirement from an implementation that merely runs. Use the trace in this part to make that distinction concrete.
-->

---

## Every loop needs a progress story

- Initialization establishes the first state
- A condition decides whether another body runs
- An update moves toward termination

<!--
Iteration, or looping, is one of the three basic constructs in computer programming (see {ref}`programming-constructs`). The basic purpose of iteration is code repetition, which humans usually find difficult but comes very easy for computers. After starting, the repetitive execution of a block of code or a set of instructions/statements will not stop until certain criterion is met. The termination of iteration can be either **count**-controlled (for loops) or **condition**-controlled (while loops). In general, when you know exactly how many times you are going to loop through a block of code, you use the `for` loop; otherwise, you would choose a `while` loop. The need for code repetition can be seen from the following code:  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The condition is tested once more than the body runs. Replacing >= with > loses the required final two. Starting at one makes the pretest false and correctly performs zero iterations.
-->

---

## Separate the expression result from stored state

- Increment and decrement update a variable
- Prefix and postfix can yield different expression results
- Use separate statements while learning to trace

<!--
 Obviously, to code the print statement repetitively for 10 times is not a efficient use of time for a developer, not to mention the repetition could go for more than 10 times.  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The condition is tested once more than the body runs. Replacing >= with > loses the required final two. Starting at one makes the pretest false and correctly performs zero iterations.
-->

---

## Trace the closing-time countdown

| Condition tested | Body output | State after update |
| --- | --- | ---: |
| 6 ≥ 2: true | 6 | 4 |
| 4 ≥ 2: true | 4 | 2 |
| 2 ≥ 2: true | 2 | 0 |
| 0 ≥ 2: false | none | 0 |

<!--
The condition is tested once more than the body runs. Replacing >= with > loses the required final two. Starting at one makes the pretest false and correctly performs zero iterations. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
for (int minutes = 6; minutes >= 2; minutes -= 2)
{
    Console.WriteLine(minutes);
}
```

```output
6
4
2
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is '6\n4\n2\n'. The condition is tested once more than the body runs. Replacing >= with > loses the required final two. Starting at one makes the pretest false and correctly performs zero iterations. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

How many times does the condition run in this three-body countdown?

1. Two
2. Three
3. Four

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer C. The final false test is needed to stop the loop after the third body. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

## Control transfers still need a plan

- break leaves the nearest loop
- continue moves to the next iteration step
- A skipped statement may be the intended update

<!--
 The C# language reference states that iteration statements include `for`, `foreach`, `do`, and `while` and that the iteration statements "repeatedly execute a statement or a block of statements": [^0401_iteration-iteration-1] - The `for` statement [^0401_iteration-c-style-for-loop] executes its body of an iteration statement while a specified Boolean expression evaluates to true. - The `foreach` statement enumerates the elements of a collection and executes its body for each element of the collection. - The `do` statement conditionally executes its body one or more times. - The `while` statement conditionally executes its body zero or more times. As a solution to the preceding code repetition problem, a `for` loop can be used as below. Comparing the highlighted for statement with the, you can see the need for iteration. The syntax of the `for` loop statement will be explained in a later section.  The condition is tested once more than the body runs. Replacing >= with > loses the required final two. Starting at one makes the pretest false and correctly performs zero iterations. Ask students to explain the difference this concept makes to the caller or to the person using the result.
-->

---

## An update can yield a value as well as change state

- Postfix uses the old value in the surrounding expression.
- Prefix uses the updated value in that expression.

<!--
For x=3, assigning y=x++ gives y3 and x4; assigning y=++x from a fresh x3 gives y4 and x4. Separate update and use until the trace is comfortable. A for continue still reaches the header update.
-->

---

## Challenge a plausible wrong result

Check zero, one and several body executions. For a decreasing loop, inspect both the comparison and the sign of its update.

> Name one changed input that would expose a wrong boundary, missing case or unintended state change.

<!--
Ask for a counterexample before modifying the program. Answer B. A condition alone does not guarantee progress. A body that never changes relevant state may repeat forever. The trace provides an independent explanation of the ordinary case. The condition is tested once more than the body runs. Replacing >= with > loses the required final two. Starting at one makes the pretest false and correctly performs zero iterations.
-->

---

<!-- _class: check -->

## Quick check 2

Which loop-plan item explains why a while loop eventually stops?

1. Its variable name
2. Progress toward a false condition
3. Its indentation

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. A condition alone does not guarantee progress. A body that never changes relevant state may repeat forever. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Apply the Loop Plan to a Closing-Time Countdown**

Repair the existing loop so it includes 2. Predict the result with an initial value of 1 before executing.

[Open the existing practice](0401_iteration.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Exercise cell ba18_d5cbb17eb653 remains unchanged. Use a comparison that includes two; with initial one there is no output. Ask students to identify initialization, condition, body and progress in their own repair. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- Check zero, one and several body executions. For a decreasing loop, inspect both the comparison and the sign of its update.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. The condition is tested once more than the body runs. Replacing >= with > loses the required final two. Starting at one makes the pretest false and correctly performs zero iterations. For the Your Turn activity, the instructor answer is: Exercise cell ba18_d5cbb17eb653 remains unchanged. Use a comparison that includes two; with initial one there is no output. Ask students to identify initialization, condition, body and progress in their own repair.
-->

---

## Vocabulary to explain, not memorize

- Iteration: repeated work
- loop state: values between iterations
- termination: condition eventually false or explicit exit

[Chapter objectives and glossary](0400_iteration.html)

<!--
Ask students to use each term in an explanation of this part’s case. Tie the vocabulary to the actions in the goals: Plan initialization, condition, body and progress; Trace state across repeated work; Distinguish break, continue and normal completion. A correct definition without a correct trace is not yet sufficient evidence of application.
-->

---

<!-- _class: recap -->

## Recap and next step

- Plan initialization, condition, body and progress
- Trace state across repeated work
- Distinguish break, continue and normal completion

[4.1 reading](0401_iteration.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. The condition is tested once more than the body runs. Replacing >= with > loses the required final two. Starting at one makes the pretest false and correctly performs zero iterations. Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: loop plans in 4.1, 35 minutes; meeting 2: counted traversal in 4.2, 40 minutes; meeting 3: state-controlled loops in 4.3, 35 minutes. Total 110 minutes. GCD is supporting reading, not a fourth meeting.
-->

---

<!-- _class: section -->

## The for Statement and Counted Traversal

4.2 · [4.2 reading](0402_for_statements.html)

Read, predict, trace, then apply.

<!--
Meeting 1: loop plans in 4.1, 35 minutes; meeting 2: counted traversal in 4.2, 40 minutes; meeting 3: state-controlled loops in 4.3, 35 minutes. Total 110 minutes. GCD is supporting reading, not a fourth meeting. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. A dispatch desk prints a small branch-by-day table. The outer loop chooses a row; the inner loop completes all columns before the next row begins.
-->

---

## Goals and preparation

- Trace the for execution sequence
- Choose indexed or foreach traversal
- Use nested loops and deliberate output formatting

[4.2 reading](0402_for_statements.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: loop plans in 4.1, 35 minutes; meeting 2: counted traversal in 4.2, 40 minutes; meeting 3: state-controlled loops in 4.3, 35 minutes. Total 110 minutes. GCD is supporting reading, not a fourth meeting. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The business question

A dispatch desk prints a small branch-by-day table. The outer loop chooses a row; the inner loop completes all columns before the next row begins.

> What information, rule and observable result do we need?

<!--
A dispatch desk prints a small branch-by-day table. The outer loop chooses a row; the inner loop completes all columns before the next row begins. Ask pairs to name the input, required result and a possible wrong answer. Expected discussion: distinguish the stated business requirement from an implementation that merely runs. Use the trace in this part to make that distinction concrete.
-->

---

## A for header groups counted-loop control

- Initialize once
- Test before each body
- Update after each completed body

<!--
The `for` statement executes a statement or a block of statements while a specified **Boolean expression** evaluates to true. Such evaluation involves comparing the local loop counter variable (an **integer counter** that increments/decrements over every loop) to a preset value. Since the number of loops is controlled by comparing the counter with the **preset value**, you need to specify the preset value to decide the number of times you want to run the code block when defining a `for` loop statement. (for-loop-header)=  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The inner loop executes six bodies, while the outer loop executes two. Its initialization reruns for each row. Explain that row and column values are counters here; no array prerequisite is needed.
-->

---

## Choose the information the body needs

- for exposes an index and step
- foreach exposes each value directly
- String traversal is available before arrays

<!--
 `for` loops are usually favored for iteration because the all the information about the local loop variable are available in one place at the top, which helps quickly visualize the overall sequence in the loop. The C# for loop statement syntax is: Let us practice with `csharprepl`, `Run C#`, or a small VS Code project:  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The inner loop executes six bodies, while the outer loop executes two. Its initialization reruns for each row. Explain that row and column values are counters here; no array prerequisite is needed.
-->

---

## Count work in a 2 by 3 report

| Outer row | Inner columns visited | Cells printed so far |
| ---: | --- | ---: |
| 1 | 1, 2, 3 | 3 |
| 2 | 1, 2, 3 | 6 |
| After row 2 | No further row | 6 |

<!--
The inner loop executes six bodies, while the outer loop executes two. Its initialization reruns for each row. Explain that row and column values are counters here; no array prerequisite is needed. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
for (int branch = 1; branch <= 2; branch++)
{
    for (int day = 1; day <= 3; day++)
        Console.Write($"{branch}{day} ");
    Console.WriteLine();
}
```

```output
11 12 13 
21 22 23 
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is '11 12 13 \n21 22 23 \n'. The inner loop executes six bodies, while the outer loop executes two. Its initialization reruns for each row. Explain that row and column values are counters here; no array prerequisite is needed. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

A for body executes continue. What happens before the next condition test?

1. The for update runs
2. Initialization runs again
3. The loop always ends

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer A. Continue in a for loop advances to the update, then the condition. This differs from skipping a manual update in a while body. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

## Nested loops produce combinations

- The inner loop restarts for each outer value
- Write keeps cells on one row
- WriteLine ends the completed row

<!--
You can see that the `for` loop has four parts, a three-section semicolon-separated **header** and a **body**: - **Initializer**: This section is a **variable declaration statement** that declares a `local loop variable` (or `iterator variable` or the counter) and initialize it with an initial value. - **Condition**: The condition section is a **boolean expression** that determines if the next iteration in the loop should be executed or should the loop be terminated. If it evaluates to true, the next iteration is executed; otherwise, the loop is exited. - **Iterator**: The iterator (**iteration expression**) section that defines what happens to the counter after each execution of the body of the loop. A common behavior is reassigning (increment or decrement) the value of the counter. - The **body** of the loop, which must be a statement or a block of statements. In the example above, the *initializer* is `i = 1`, *condition* is `i `). Note that the initializer section is executed **only once**, before entering the loop. Also, the declared variable is local to the `for` loop heading and the loop body and can not be accessed from outside the for statement. The two semicolons are always needed in the `for` heading, but any of the parts they normally separate may be omitted. If the condition part is omitted, the condition is interpreted as always true, leading to an infinite loop, that can only terminate due to a `return` or {ref}`break statement ` in the body. **Header variation** The declaration of a for loop header is flexible. There may be several variables of the same type initialized, separated by commas. Also, at the end of the `for` loop heading, the iteration portion may include more than one expression, also separated by commas. For example: The inner loop executes six bodies, while the outer loop executes two. Its initialization reruns for each row. Explain that row and column values are counters here; no array prerequisite is needed. Ask students to explain the difference this concept makes to the caller or to the person using the result.
-->

---

## A simulation models outcomes rather than guarantees them

- Create one Random object and reuse it for a sequence of trials.
- Next(low, high) includes low and excludes high.

<!--
Explain that0and1 may encode heads/tails either way if the policy is consistent. Ten trials do not guarantee five of each. Expected checks focus on bounds, valid classification and the sum of counts rather than a hard-coded random sequence.
-->

---

## Challenge a plausible wrong result

Check an empty string, a first-position match, a last-position match and no match. For a table, independently count rows × columns.

> Name one changed input that would expose a wrong boundary, missing case or unintended state change.

<!--
Ask for a counterexample before modifying the program. Answer B. The upper bound is excluded. A finite run need not split the outcomes exactly evenly. The trace provides an independent explanation of the ordinary case. The inner loop executes six bodies, while the outer loop executes two. Its initialization reruns for each row. Explain that row and column values are counters here; no array prerequisite is needed.
-->

---

<!-- _class: check -->

## Quick check 2

A simulation uses Next(0, 2). Which values are possible?

1. Only 0
2. 0 and 1
3. 0, 1 and 2

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. The upper bound is excluded. A finite run need not split the outcomes exactly evenly. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Guided Practice: Find the First Space**

Use the existing string-search practice. Trace the characters before the first space, then test a string with no spaces.

[Open the existing practice](0402_for_statements.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Existing named guided practice retains its code-cell identity. The solution visits indexes in order, reports the first matching position and stops with break. For no match, preserve the exercise’s explicit missing-result behavior; do not treat zero as missing because zero is a valid first position. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- Check an empty string, a first-position match, a last-position match and no match. For a table, independently count rows × columns.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. The inner loop executes six bodies, while the outer loop executes two. Its initialization reruns for each row. Explain that row and column values are counters here; no array prerequisite is needed. For the Your Turn activity, the instructor answer is: Existing named guided practice retains its code-cell identity. The solution visits indexes in order, reports the first matching position and stops with break. For no match, preserve the exercise’s explicit missing-result behavior; do not treat zero as missing because zero is a valid first position.
-->

---

## Vocabulary to explain, not memorize

- for: counted control
- foreach: value traversal
- nested loop: complete inner work per outer iteration

[Chapter objectives and glossary](0400_iteration.html)

<!--
Ask students to use each term in an explanation of this part’s case. Tie the vocabulary to the actions in the goals: Trace the for execution sequence; Choose indexed or foreach traversal; Use nested loops and deliberate output formatting. A correct definition without a correct trace is not yet sufficient evidence of application.
-->

---

<!-- _class: recap -->

## Recap and next step

- Trace the for execution sequence
- Choose indexed or foreach traversal
- Use nested loops and deliberate output formatting

[4.2 reading](0402_for_statements.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. The inner loop executes six bodies, while the outer loop executes two. Its initialization reruns for each row. Explain that row and column values are counters here; no array prerequisite is needed. Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: loop plans in 4.1, 35 minutes; meeting 2: counted traversal in 4.2, 40 minutes; meeting 3: state-controlled loops in 4.3, 35 minutes. Total 110 minutes. GCD is supporting reading, not a fourth meeting.
-->

---

<!-- _class: section -->

## while, do-while and Validation

4.3 · [4.3 reading](0403_while_statement.html)

Read, predict, trace, then apply.

<!--
Meeting 1: loop plans in 4.1, 35 minutes; meeting 2: counted traversal in 4.2, 40 minutes; meeting 3: state-controlled loops in 4.3, 35 minutes. Total 110 minutes. GCD is supporting reading, not a fourth meeting. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. An order clerk must enter a quantity from 1 through 50. A malformed number and an out-of-range number both need a retry; end-of-input needs a deliberate stop.
-->

---

## Goals and preparation

- Choose pretest or posttest repetition
- Keep progress and stopping state visible
- Validate parsed values before using them

[4.3 reading](0403_while_statement.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: loop plans in 4.1, 35 minutes; meeting 2: counted traversal in 4.2, 40 minutes; meeting 3: state-controlled loops in 4.3, 35 minutes. Total 110 minutes. GCD is supporting reading, not a fourth meeting. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The business question

An order clerk must enter a quantity from 1 through 50. A malformed number and an out-of-range number both need a retry; end-of-input needs a deliberate stop.

> What information, rule and observable result do we need?

<!--
An order clerk must enter a quantity from 1 through 50. A malformed number and an out-of-range number both need a retry; end-of-input needs a deliberate stop. Ask pairs to name the input, required result and a possible wrong answer. Expected discussion: distinguish the stated business requirement from an implementation that merely runs. Use the trace in this part to make that distinction concrete.
-->

---

## Use while when the next repetition depends on state

- The condition is tested before the body
- Zero iterations may be correct
- Update the state that controls the condition

<!--
Just like the `for` loop, the while loop deals with iteration (*repetition* or *loops*). The `while` loop is **condition-controlled**, as opposing to `for` loop , which is **count-controlled**. This means a while loop runs a set of instructions continuously as long as the given **boolean condition** evaluates true, no matter how many loops it takes. Only when the condition is evaluated to NOT true, then the loop terminates. The flowchart of a while loop looks like the graph below, note that the sequential flow of a program is altered with the loops, just like with method calls and conditional statements: [1] :::{figure} ../../figures/flowchart-while-loop.jpg :alt: flowchart while loop :width: 250 ::: For `while` loop, it is common to initialize a variable to be used in the condition, therefore the syntax would look like:  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. A parseable zero is still invalid for this order policy. A missing line is not an endless stream of bad user entries. The demonstrated savings loop below isolates pretest progress without requiring interactive retry syntax on one slide.
-->

---

## Use do-while when one attempt must occur

- The body runs before its test
- A retry condition describes whether to repeat
- The final semicolon belongs to the do-while syntax

<!--
Note that, because the condition (boolean expression) is evaluated before each execution of the loop body, a `while` loop can execute **zero** times (if the condition evaluates to `false` immediately) or more times. Run the following code to get familiar with the C# `while` loop: This `while` loop does the same counting work as this `for` loop: Both pieces of code have an `initializer`, `conditional expression`, and `iterator expression` (see {ref}`for-loop-header`); except that in a `for` loop, the three sections are  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. A parseable zero is still invalid for this order policy. A missing line is not an endless stream of bad user entries. The demonstrated savings loop below isolates pretest progress without requiring interactive retry syntax on one slide.
-->

---

## Trace a bounded input attempt

| Supplied line | Parses? | In 1..50? | Action |
| --- | --- | --- | --- |
| abc | false | not used | Retry |
| 0 | true | false | Retry |
| 12 | true | true | Accept |
| End of input | no line | not used | Stop deliberately |

<!--
A parseable zero is still invalid for this order policy. A missing line is not an endless stream of bad user entries. The demonstrated savings loop below isolates pretest progress without requiring interactive retry syntax on one slide. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
int balance = 20, weeks = 0;
while (balance < 40)
{
    balance += 5;
    weeks++;
}
Console.WriteLine($"weeks={weeks}, balance={balance}");
```

```output
weeks=4, balance=40
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is 'weeks=4, balance=40\n'. A parseable zero is still invalid for this order policy. A missing line is not an endless stream of bad user entries. The demonstrated savings loop below isolates pretest progress without requiring interactive retry syntax on one slide. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

If balance already meets its target, how often does this while body run?

1. Zero
2. Once
3. Forever

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer A. A while loop tests first. That zero-iteration case is a meaningful part of the contract. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

## Parsing success and range validity are separate

- TryParse reports whether text represents an integer
- Then test the allowed business range
- Check missing input before repeatedly asking for more

<!--
placed together in the header, while they are placed in different locations in the `while` loop. **Stepping** Test yourself: Follow the code below to figure out what is printed:  A parseable zero is still invalid for this order policy. A missing line is not an endless stream of bad user entries. The demonstrated savings loop below isolates pretest progress without requiring interactive retry syntax on one slide. Ask students to explain the difference this concept makes to the caller or to the person using the result.
-->

---

## A loop needs a reason to stop

- A decreasing balance or smaller GCD remainder provides measurable progress.
- A retry loop also needs a response to missing input.

<!--
For a savings model, inspect whether the update can actually reach the target under the given assumptions. For input, a null line must exit or be handled deliberately. The small strange-sequence inputs are bounded practice, not a claim of general overflow safety.
-->

---

## Challenge a plausible wrong result

For accumulation, check zero/one/many iterations. For input, separate malformed text, valid boundary values and missing input.

> Name one changed input that would expose a wrong boundary, missing case or unintended state change.

<!--
Ask for a counterexample before modifying the program. Answer B. Syntactic conversion and the permitted range answer different questions. The trace provides an independent explanation of the ordinary case. A parseable zero is still invalid for this order policy. A missing line is not an endless stream of bad user entries. The demonstrated savings loop below isolates pretest progress without requiring interactive retry syntax on one slide.
-->

---

<!-- _class: check -->

## Quick check 2

TryParse succeeds for "0" in the quantity task. Should the order accept it?

1. Yes, parsing is validation of every rule
2. No, the business range must also be checked
3. Only inside a for loop

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. Syntactic conversion and the permitted range answer different questions. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Order Entry Lab: validation stages**

Use the existing connected lab’s quantity and confirmation stages. Test malformed input, 0, 1, 50, 51 and missing input before adding later order lines.

[Open the existing practice](assignments/lab.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Preserve every existing lab cell and exercise ID. The accepted quantity must parse and lie in 1..50. Only the exact accepted confirmation choices should advance the workflow; EOF must exit rather than retry forever. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- For accumulation, check zero/one/many iterations. For input, separate malformed text, valid boundary values and missing input.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. A parseable zero is still invalid for this order policy. A missing line is not an endless stream of bad user entries. The demonstrated savings loop below isolates pretest progress without requiring interactive retry syntax on one slide. For the Your Turn activity, the instructor answer is: Preserve every existing lab cell and exercise ID. The accepted quantity must parse and lie in 1..50. Only the exact accepted confirmation choices should advance the workflow; EOF must exit rather than retry forever.
-->

---

## Vocabulary to explain, not memorize

- while: pretest loop
- do-while: posttest loop
- validation: establish an input contract

[Chapter objectives and glossary](0400_iteration.html)

<!--
Ask students to use each term in an explanation of this part’s case. Tie the vocabulary to the actions in the goals: Choose pretest or posttest repetition; Keep progress and stopping state visible; Validate parsed values before using them. A correct definition without a correct trace is not yet sufficient evidence of application.
-->

---

<!-- _class: recap -->

## Recap and next step

- Choose pretest or posttest repetition
- Keep progress and stopping state visible
- Validate parsed values before using them

[4.3 reading](0403_while_statement.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. A parseable zero is still invalid for this order policy. A missing line is not an endless stream of bad user entries. The demonstrated savings loop below isolates pretest progress without requiring interactive retry syntax on one slide. Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: loop plans in 4.1, 35 minutes; meeting 2: counted traversal in 4.2, 40 minutes; meeting 3: state-controlled loops in 4.3, 35 minutes. Total 110 minutes. GCD is supporting reading, not a fourth meeting.
-->

---

<!-- _class: section -->

## Supporting Reading: Greatest Common Divisor

4.4 · [4.4 reading](0404_gcd.html)

Optional supporting reading. No added meeting or required assessment.

<!--
Meeting 1: loop plans in 4.1, 35 minutes; meeting 2: counted traversal in 4.2, 40 minutes; meeting 3: state-controlled loops in 4.3, 35 minutes. Total 110 minutes. GCD is supporting reading, not a fourth meeting. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. A warehouse wants the largest equal bundle size for two stock quantities. The greatest common divisor turns that question into repeated smaller remainders.
-->

---

## Goals and preparation

- Trace Euclid’s remainder loop
- Explain the stopping value
- Compare repeated subtraction and remainder

[4.4 reading](0404_gcd.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: loop plans in 4.1, 35 minutes; meeting 2: counted traversal in 4.2, 40 minutes; meeting 3: state-controlled loops in 4.3, 35 minutes. Total 110 minutes. GCD is supporting reading, not a fourth meeting. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The remainder preserves the common divisors

- For positive inputs, replace (a,b) with (b,a % b)
- The second value becomes smaller
- When b is zero, a is the GCD

<!--
This supporting lesson preserves the full 2025 mathematical development and comparison of brute-force, subtraction, remainder, and recursive approaches. The loop algorithms accept positive integers; the remainder and recursive variants also accept a single zero. The method listings are for revisiting after Chapter 5; recursion is a preview to revisit in Chapters 17 and 22. These explanations and tasks retain the earlier CS1 teaching material.[^0404_gcd-restored]  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. Save the remainder before overwriting either input. Common divisors are preserved by each replacement. The recursive preview in the source is recognition only and does not add a Chapter 4 methods prerequisite.
-->

---

## Trace GCD of 48 and 18

| a | b | a % b |
| ---: | ---: | ---: |
| 48 | 18 | 12 |
| 18 | 12 | 6 |
| 12 | 6 | 0 |
| 6 | 0 | stop |

<!--
Save the remainder before overwriting either input. Common divisors are preserved by each replacement. The recursive preview in the source is recognition only and does not add a Chapter 4 methods prerequisite. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
int a = 48, b = 18;
while (b != 0)
{
    int remainder = a % b;
    a = b;
    b = remainder;
}
Console.WriteLine(a);
```

```output
6
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is '6\n'. Save the remainder before overwriting either input. Common divisors are preserved by each replacement. The recursive preview in the source is recognition only and does not add a Chapter 4 methods prerequisite. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

When the loop finishes at (6,0), what is the GCD?

1. 0
2. 6
3. The last nonzero remainder minus one

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. The first value is the final nonzero divisor. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Guided Practice: Count the Remainder Steps**

Trace the existing remainder-loop practice and count body executions. Compare your count with the executed program.

[Open the existing practice](0404_gcd.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Existing supporting practice identity is unchanged. For 48 and 18, three remainder steps reach (6,0). Keep the temporary remainder; do not overwrite a before calculating it. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

<!-- _class: recap -->

## Recap and next step

- Trace Euclid’s remainder loop
- Explain the stopping value
- Compare repeated subtraction and remainder

[4.4 reading](0404_gcd.html) · Optional reading; no required assessment.

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. Save the remainder before overwriting either input. Common divisors are preserved by each replacement. The recursive preview in the source is recognition only and does not add a Chapter 4 methods prerequisite. This supporting part is optional and does not add a core assessment prerequisite. Meeting 1: loop plans in 4.1, 35 minutes; meeting 2: counted traversal in 4.2, 40 minutes; meeting 3: state-controlled loops in 4.3, 35 minutes. Total 110 minutes. GCD is supporting reading, not a fourth meeting.
-->
