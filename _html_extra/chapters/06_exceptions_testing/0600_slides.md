---
marp: true
theme: thinkpress-lecture
paginate: true
title: "Testing, Debugging, and Error Handling"
book: "Computer Science in C#"
section: "Chapter 6"
primary: "#2a6b37"
accent: "#b8860b"
---

<!-- _class: title -->

# Testing, Debugging, and Error Handling

Chapter 6 · Computer Science in C#

<!--
Part map (1-based slide numbers): 6.1 Error Handling and Validation: slide 2; 6.2 Debugging Workflow: slide 18; 6.3 Unit Testing and Independent Expectations: slide 34; 6.4 Optional Cases: When Software Fails People: slide 50. Meeting 1: validation and error handling in 6.1, 35 minutes; meeting 2: debugging in 6.2, 35 minutes; meeting 3: unit testing in 6.3, 40 minutes. Total 110 minutes. Failure cases in 6.4 are optional. Use selected examples and checks inside the existing allocation. Additional source detail remains preparation/reference reading. Every example is standalone; instructor answers remain in notes.
-->

---

<!-- _class: section -->

## Error Handling and Validation

6.1 · [6.1 reading](0601_error_handling.html)

Read, predict, trace, then apply.

<!--
Meeting 1: validation and error handling in 6.1, 35 minutes; meeting 2: debugging in 6.2, 35 minutes; meeting 3: unit testing in 6.3, 40 minutes. Total 110 minutes. Failure cases in 6.4 are optional. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. An order entry receives -2. It is valid integer text but an invalid quantity. A different line, two, cannot be parsed as an integer at all.
-->

---

## Goals and preparation

- Choose validation or an exception from the failure contract
- Trace try, catch and finally control flow
- Give a useful message without hiding the failure

[6.1 reading](0601_error_handling.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: validation and error handling in 6.1, 35 minutes; meeting 2: debugging in 6.2, 35 minutes; meeting 3: unit testing in 6.3, 40 minutes. Total 110 minutes. Failure cases in 6.4 are optional. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The business question

An order entry receives -2. It is valid integer text but an invalid quantity. A different line, two, cannot be parsed as an integer at all.

> What information, rule and observable result do we need?

<!--
An order entry receives -2. It is valid integer text but an invalid quantity. A different line, two, cannot be parsed as an integer at all. Ask pairs to name the input, required result and a possible wrong answer. Expected discussion: distinguish the stated business requirement from an implementation that merely runs. Use the trace in this part to make that distinction concrete.
-->

---

## Classify the failure before catching it

- Malformed user input is an expected interaction
- A contract violation may require a deliberate exception
- A catch must define a useful response

<!--
A business calculation should either return a meaningful value or make failure explicit. A returned zero could mean that no payment is due; it must not secretly mean that the calculation never succeeded. Use the method-contract ideas from Chapter 5 to decide which inputs the calculation accepts, and the control-flow ideas from Chapters 3 and 4 to follow what happens next. The general pattern below is schematic. Replace the operation, exception type, and response with the policy for the actual task. The braces delimit blocks. `catch (ExceptionType name)` selects a compatible exception and gives that exception a local name. It does not execute after every successful operation. There can be several catch blocks, ordered from more specific types to more general ones. Only the first matching catch runs for that thrown exception. A `finally` block is optional, as are catch blocks when a try has a finally. Cleanup is not a substitute for handling the failure, and catching a failure does not restart the interrupted statement. Consider distributing an invoice amount across a positive number of periods. The method rejects zero periods before division. Its caller knows how to explain that particular argument failure. No file API or collection is needed to understand this example.  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The finally message means the attempt is complete, not that parsing succeeded. A matching catch receives control after the throw. Prefer TryParse when a user typing a nonnumber is an expected case; use this small example to make exception control flow visible.
-->

---

## try does not resume at the failed statement

- A thrown exception skips the rest of that try
- A matching catch handles that failure
- finally runs when control leaves this attempt

<!--
Read the two attempts separately. For three periods, the call returns 40 and the success message runs. For zero periods, `throw` ends the method before division. Control leaves the unfinished try block, enters the matching catch, and then executes finally. There is no `Amount` line for the failed attempt. | Attempt | Does the method return an amount? | Runs the catch? | Runs finally? | | --- | --- | --- | --- | | Three periods | Yes, 40 | No | Yes | | Zero periods | No | Yes | Yes | | Negative periods | No | Yes | Yes | The exception is created by `new ArgumentOutOfRangeException(...)`; `throw` transfers control. `nameof(periods)` records the parameter name without duplicating its spelling in a string. Do not catch an unrelated type merely because its name sounds like an error. An unmatched exception continues to an enclosing handler after this finally runs. The statement after the failed call is not resumed. Printing from finally is used only to make control visible here. In Chapter 9, resource disposal will be a concrete cleanup responsibility. Finally does not mean that a result was produced, and it is not guaranteed to run after process termination or machine failure.  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The finally message means the attempt is complete, not that parsing succeeded. A matching catch receives control after the throw. Prefer TryParse when a user typing a nonnumber is an expected case; use this small example to make exception control flow visible.
-->

---

## Trace an invalid number attempt

| Event | Next executed action | Skipped action |
| --- | --- | --- |
| int.Parse("two") throws | Matching FormatException catch | Print parsed value |
| Catch prints guidance | finally prints completion | No retry unless caller supplies one |
| Finally completes | Continue after construct | Failed parse does not resume |

<!--
The finally message means the attempt is complete, not that parsing succeeded. A matching catch receives control after the throw. Prefer TryParse when a user typing a nonnumber is an expected case; use this small example to make exception control flow visible. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
try
{
    int value = int.Parse("two");
    Console.WriteLine(value);
}
catch (FormatException) { Console.WriteLine("Enter a whole number."); }
finally { Console.WriteLine("Attempt complete."); }
```

```output
Enter a whole number.
Attempt complete.
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is 'Enter a whole number.\nAttempt complete.\n'. The finally message means the attempt is complete, not that parsing succeeded. A matching catch receives control after the throw. Prefer TryParse when a user typing a nonnumber is an expected case; use this small example to make exception control flow visible. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

After Parse throws, does execution print the parsed value in the same try?

1. Yes, after catch
2. No, that remaining try statement is skipped
3. Only if finally exists

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. Handling transfers control to catch; it does not resume the failed instruction. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

## Keep handling specific and truthful

- Prefer TryParse for routine input
- Do not catch and silently report success
- Use throw; to rethrow while retaining the failure origin

<!--
First predict the complete output for `ShowPlan(1)` and `ShowPlan(-2)`. Identify the first statement that is not executed in the negative case. Then change the contract: a negative total is invalid, while zero total remains valid. Add an argument guard to the calculation, rather than returning a fake amount. Try valid zero, valid positive, and invalid negative totals with one and zero periods. Derive each expected outcome before running it. Later file-handling examples are previews of Chapter 9, where their APIs and ownership rules are taught; they are not prerequisites for this control-flow lesson.  The finally message means the attempt is complete, not that parsing succeeded. A matching catch receives control after the throw. Prefer TryParse when a user typing a nonnumber is an expected case; use this small example to make exception control flow visible. Ask students to explain the difference this concept makes to the caller or to the person using the result.
-->

---

## Rethrow without hiding the failure origin

- A catch may add context and then use throw; to preserve the original failure.
- finally marks leaving the attempt; it does not guarantee a successful operation.

<!--
The lesson traces Validate through Submit to the caller. Submit records failure and rethrows; the caller still receives it. Catching and returning a normal-looking value would instead erase the required failure contract. File examples remain later applications after Chapter9, not new prerequisites.
-->

---

## Challenge a plausible wrong result

Check malformed text, a parsed out-of-range value, a valid boundary and the declared exception type. File cleanup is a later Chapter 9 application.

> Name one changed input that would expose a wrong boundary, missing case or unintended state change.

<!--
Ask for a counterexample before modifying the program. Answer B. Conversion success establishes an integer representation, not the domain required by the business rule. The trace provides an independent explanation of the ordinary case. The finally message means the attempt is complete, not that parsing succeeded. A matching catch receives control after the throw. Prefer TryParse when a user typing a nonnumber is an expected case; use this small example to make exception control flow visible.
-->

---

<!-- _class: check -->

## Quick check 2

TryParse succeeds for -2, but the contract requires a nonnegative quantity. What remains?

1. Nothing
2. Check the range and explain the invalid quantity
3. Catch FormatException

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. Conversion success establishes an integer representation, not the domain required by the business rule. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Homework Question 5: Parse Routine Input**

Complete existing Question 5: read a number with int.TryParse, handle text that is not a valid integer, and explain when this is preferable to exception handling.

[Open the existing practice](assignments/homework.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Existing homework Question 5 in cell c44b5e5e retains its assessment identity. Branch on the Boolean returned by TryParse; use the parsed integer only on success, otherwise print useful guidance. Explain that malformed user input is expected interaction. A business range check is a separate policy, not automatically part of parsing. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- Check malformed text, a parsed out-of-range value, a valid boundary and the declared exception type. File cleanup is a later Chapter 9 application.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. The finally message means the attempt is complete, not that parsing succeeded. A matching catch receives control after the throw. Prefer TryParse when a user typing a nonnumber is an expected case; use this small example to make exception control flow visible. For the Your Turn activity, the instructor answer is: Existing homework Question 5 in cell c44b5e5e retains its assessment identity. Branch on the Boolean returned by TryParse; use the parsed integer only on success, otherwise print useful guidance. Explain that malformed user input is expected interaction. A business range check is a separate policy, not automatically part of parsing.
-->

---

## Vocabulary to explain, not memorize

- Validation: check domain
- exception: failure transfer
- finally: completion/cleanup path

[Chapter objectives and glossary](0600_exceptions_testing.html)

<!--
Ask students to use each term in an explanation of this part’s case. Tie the vocabulary to the actions in the goals: Choose validation or an exception from the failure contract; Trace try, catch and finally control flow; Give a useful message without hiding the failure. A correct definition without a correct trace is not yet sufficient evidence of application.
-->

---

<!-- _class: recap -->

## Recap and next step

- Choose validation or an exception from the failure contract
- Trace try, catch and finally control flow
- Give a useful message without hiding the failure

[6.1 reading](0601_error_handling.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. The finally message means the attempt is complete, not that parsing succeeded. A matching catch receives control after the throw. Prefer TryParse when a user typing a nonnumber is an expected case; use this small example to make exception control flow visible. Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: validation and error handling in 6.1, 35 minutes; meeting 2: debugging in 6.2, 35 minutes; meeting 3: unit testing in 6.3, 40 minutes. Total 110 minutes. Failure cases in 6.4 are optional.
-->

---

<!-- _class: section -->

## Debugging Workflow

6.2 · [6.2 reading](0602_debugging_workflow.html)

Read, predict, trace, then apply.

<!--
Meeting 1: validation and error handling in 6.1, 35 minutes; meeting 2: debugging in 6.2, 35 minutes; meeting 3: unit testing in 6.3, 40 minutes. Total 110 minutes. Failure cases in 6.4 are optional. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. A daily-credit helper should add day numbers 1 through days. For three days the requirement says 6, but a candidate gives 3. Trace the first divergence instead of guessing.
-->

---

## Goals and preparation

- Reproduce and minimize a discrepancy
- Use a breakpoint and watched state to test a hypothesis
- Repair the cause and retain a regression check

[6.2 reading](0602_debugging_workflow.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: validation and error handling in 6.1, 35 minutes; meeting 2: debugging in 6.2, 35 minutes; meeting 3: unit testing in 6.3, 40 minutes. Total 110 minutes. Failure cases in 6.4 are optional. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The business question

A daily-credit helper should add day numbers 1 through days. For three days the requirement says 6, but a candidate gives 3. Trace the first divergence instead of guessing.

> What information, rule and observable result do we need?

<!--
A daily-credit helper should add day numbers 1 through days. For three days the requirement says 6, but a candidate gives 3. Trace the first divergence instead of guessing. Ask pairs to name the input, required result and a possible wrong answer. Expected discussion: distinguish the stated business requirement from an implementation that merely runs. Use the trace in this part to make that distinction concrete.
-->

---

## Turn a symptom into a reproducible question

- Record exact input, expected result and actual result
- Reduce to the smallest useful failing input
- Change one hypothesis at a time

<!--
A report says that three expense entries, 12, 8 and 5, total 20. Saying that the total is wrong identifies a symptom, but it does not yet locate the defect. First derive the expected total independently: 12 + 8 + 5 is 25. Keep the three inputs fixed. A changing input set makes it difficult to tell whether a code change repaired the problem or merely avoided it. Suppose the program loops while index is less than the number of entries minus one. The loop body may contain correct addition and still omit the final item. This is why debugging begins with the contract and a concrete failing case rather than rewriting whichever line looks suspicious. At this point, students can use a simple three-value loop; the same workflow later applies to arrays and object state. For related explanation, see the further reading below.[^development-reading]  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The variable total is not reset incorrectly; the body omits the last day. With days=1 the defective loop performs zero bodies, a smaller useful counterexample. Replacing < with <= repairs this domain; negative-input rejection is a separate contract improvement.
-->

---

## Inspect state where a decision is made

- A breakpoint pauses before a selected statement
- Step follows the next executed statement
- Watch and call stack explain values and callers

<!--
Use a calculation that needs only methods, decisions, and loops. A shop awards one credit for each of the first `days` days. With three days, the expected credits are 1 + 2 + 3 = 6. This expectation comes from the problem, not from running the implementation. The following complete cell deliberately contains a logic defect. It compiles, but the loop stops too soon. A compiler cannot infer that the business rule requires the last day.  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The variable total is not reset incorrectly; the body omits the last day. With days=1 the defective loop performs zero bodies, a smaller useful counterexample. Replacing < with <= repairs this domain; negative-input rejection is a separate contract improvement.
-->

---

## Locate the off-by-one error

| days = 3, condition day < days | total after body |
| --- | ---: |
| day = 1: true | 1 |
| day = 2: true | 3 |
| day = 3: false | No addition of 3 |
| Required final result | 6 |

<!--
The variable total is not reset incorrectly; the body omits the last day. With days=1 the defective loop performs zero bodies, a smaller useful counterexample. Replacing < with <= repairs this domain; negative-input rejection is a separate contract improvement. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
Console.WriteLine(Credits(0));
Console.WriteLine(Credits(1));
Console.WriteLine(Credits(3));
int Credits(int days)
{
    int total = 0;
    for (int day = 1; day <= days; day++) total += day;
    return total;
}
```

```output
0
1
6
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is '0\n1\n6\n'. The variable total is not reset incorrectly; the body omits the last day. With days=1 the defective loop performs zero bodies, a smaller useful counterexample. Replacing < with <= repairs this domain; negative-input rejection is a separate contract improvement. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

The faulty condition is day < days. Which small input isolates the omitted last day?

1. 1
2. Only 1000
3. No input below 3

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer A. For one day, the faulty loop returns zero instead of one, making the missing body immediately visible. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

## A repair needs evidence beyond the original input

- Fix the cause, not a special-case symptom
- Rerun the failing input unchanged
- Add nearby and boundary regression checks

<!--
Save this code as the Program.cs of a console project using the Appendix B workflow. Run `dotnet run` to reproduce the failure before starting a debugger. In VS Code, open the folder containing the project, set a breakpoint on `total += day`, and start the C# debugger for that project. The browser cell can demonstrate the result; the editor debugger supplies paused state. Write the hypothesis: “the loop omits day three.” A breakpoint pauses **before** the marked statement executes. At its first stop, watch `day`, `days`, and `total`. Step Over the update, then continue to the next stop. Use the method's own frame in the Call Stack panel to inspect its local values. The call stack explains who called the method; it is not a list of all previous loop iterations. | Observation | day | total before addition | total after addition | | --- | ---: | ---: | ---: | | First stopped iteration | 1 | 0 | 1 | | Second stopped iteration | 2 | 1 | 3 | | Third iteration required by the contract | 3 | 3 | 6 | The third row does not occur in the defective run. After the second addition, `day` becomes three and `day < days` is false. This distinguishes a missing iteration from an incorrect addition. If all three additions had occurred, investigate a later overwrite or the printed expression instead of changing the boundary blindly. Repair only the condition to `day <= days`. Step through the same input again: a stop with day three should now appear. Keep the old input; changing both the data and the program would weaken the evidence.  The variable total is not reset incorrectly; the body omits the last day. With days=1 the defective loop performs zero bodies, a smaller useful counterexample. Replacing < with <= repairs this domain; negative-input rejection is a separate contract improvement. Ask students to explain the difference this concept makes to the caller or to the person using the result.
-->

---

## Choose the debugger observation that tests the hypothesis

- Watch day and total immediately before the loop condition.
- Compare the current call stack with the intended caller and input.

<!--
For days3, the faulty loop stops with day3and total3. The required last addition never executes. A hypothesis about bad addition predicts a different trace from a hypothesis about an excluded iteration. Use observations to reject one explanation, then repair a single cause.
-->

---

## Challenge a plausible wrong result

Check zero, one, three and four days. Arrays in the later reference examples are applications after Chapter 7, not debugging prerequisites.

> Name one changed input that would expose a wrong boundary, missing case or unintended state change.

<!--
Ask for a counterexample before modifying the program. Answer B. Keep independently derived expectations and rerun them; changing expectations to fit a defect erases the evidence. The trace provides an independent explanation of the ordinary case. The variable total is not reset incorrectly; the body omits the last day. With days=1 the defective loop performs zero bodies, a smaller useful counterexample. Replacing < with <= repairs this domain; negative-input rejection is a separate contract improvement.
-->

---

<!-- _class: check -->

## Quick check 2

What is the best evidence after a fix?

1. It looks shorter
2. The original failing test and relevant boundary tests now pass
3. The expected output was changed to the new result

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. Keep independently derived expectations and rerun them; changing expectations to fit a defect erases the evidence. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Debugging practice: preserve a failing case**

Use the existing daily-credit walkthrough. Set a breakpoint at the loop condition, record day and total, and explain why the last required addition is skipped.

[Open the existing practice](0602_debugging_workflow.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Existing worked starter ba_3e10138791c8204613 and repair ba_7d03ef855d21b8ab57 retain their IDs. The faulty three-day result is 3; correct results for 0,1,3,4 are 0,1,6,10. Keep the before/after observation and separate the negative-input guard from the off-by-one cause. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- Check zero, one, three and four days. Arrays in the later reference examples are applications after Chapter 7, not debugging prerequisites.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. The variable total is not reset incorrectly; the body omits the last day. With days=1 the defective loop performs zero bodies, a smaller useful counterexample. Replacing < with <= repairs this domain; negative-input rejection is a separate contract improvement. For the Your Turn activity, the instructor answer is: Existing worked starter ba_3e10138791c8204613 and repair ba_7d03ef855d21b8ab57 retain their IDs. The faulty three-day result is 3; correct results for 0,1,3,4 are 0,1,6,10. Keep the before/after observation and separate the negative-input guard from the off-by-one cause.
-->

---

## Vocabulary to explain, not memorize

- Reproduction: same symptom
- hypothesis: proposed cause
- regression: retained check against recurrence

[Chapter objectives and glossary](0600_exceptions_testing.html)

<!--
Ask students to use each term in an explanation of this part’s case. Tie the vocabulary to the actions in the goals: Reproduce and minimize a discrepancy; Use a breakpoint and watched state to test a hypothesis; Repair the cause and retain a regression check. A correct definition without a correct trace is not yet sufficient evidence of application.
-->

---

<!-- _class: recap -->

## Recap and next step

- Reproduce and minimize a discrepancy
- Use a breakpoint and watched state to test a hypothesis
- Repair the cause and retain a regression check

[6.2 reading](0602_debugging_workflow.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. The variable total is not reset incorrectly; the body omits the last day. With days=1 the defective loop performs zero bodies, a smaller useful counterexample. Replacing < with <= repairs this domain; negative-input rejection is a separate contract improvement. Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: validation and error handling in 6.1, 35 minutes; meeting 2: debugging in 6.2, 35 minutes; meeting 3: unit testing in 6.3, 40 minutes. Total 110 minutes. Failure cases in 6.4 are optional.
-->

---

<!-- _class: section -->

## Unit Testing and Independent Expectations

6.3 · [6.3 reading](0603_testing.html)

Read, predict, trace, then apply.

<!--
Meeting 1: validation and error handling in 6.1, 35 minutes; meeting 2: debugging in 6.2, 35 minutes; meeting 3: unit testing in 6.3, 40 minutes. Total 110 minutes. Failure cases in 6.4 are optional. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. Shipping costs 5 for 1–9 units and 0 for 10 or more; nonpositive units are rejected. Tests only at 3 and 12 miss both the exact cutoff and invalid-input contract.
-->

---

## Goals and preparation

- Design tests from a contract rather than the implementation
- Use arrange, act and assert
- Run and interpret a small MSTest project

[6.3 reading](0603_testing.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: validation and error handling in 6.1, 35 minutes; meeting 2: debugging in 6.2, 35 minutes; meeting 3: unit testing in 6.3, 40 minutes. Total 110 minutes. Failure cases in 6.4 are optional. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The business question

Shipping costs 5 for 1–9 units and 0 for 10 or more; nonpositive units are rejected. Tests only at 3 and 12 miss both the exact cutoff and invalid-input contract.

> What information, rule and observable result do we need?

<!--
Shipping costs 5 for 1–9 units and 0 for 10 or more; nonpositive units are rejected. Tests only at 3 and 12 miss both the exact cutoff and invalid-input contract. Ask pairs to name the input, required result and a possible wrong answer. Expected discussion: distinguish the stated business requirement from an implementation that merely runs. Use the trace in this part to make that distinction concrete.
-->

---

## Derive an oracle independently

- Write the expected result before calling the candidate
- Partition ordinary, boundary and rejected inputs
- A passing sample does not establish all clauses

<!--
 The purpose of testing in software development is to establish developer’s confidence that the code continues to have high quality and less errors, hence to ensure that the requirements of the project are met. Testing is a critical part of software development. In JetBrain’s The State of Developer Ecosystem 2023 survey [1], for example, 80% of the respondents say that “testing plays an integral role in their software development projects.” Also, 63% of respondents say they use **Unit testing** in their projects while 47% say they use Integration testing. It is also noteworthy that while 41% of respondents say they have less than 1 tester/Quality Assurance Engineer per 10 developers, 32% of the respondents say that they have 1-3 testers/QA per 10 software developers. Testing, especially unit testing, therefore, is a common practice in real world software development. Amazon AWS defines unit testing as: > Unit testing is the process where you test the smallest functional unit of code. > Software testing helps ensure code quality, and it’s an integral part of software > development. It’s a software development best practice to write software as small, > functional units then write a unit test for each code unit. You can first write > unit tests as code. Then, run that test code automatically every time you make > changes in the software code. This way, if a test fails, you can quickly isolate > the area of the code that has the bug or error. Unit testing enforces modular > thinking paradigms and improves test coverage and quality. Automated unit > testing helps ensure you or your developers have more time to concentrate on coding. [2] The notion of unit testing is straightforward in principle. When you write a program in general, the program comprises what are properly known as units of development. Each language has its own definition of what units are but most modern programming languages view the **class** concept as the core unit of testing, although it can be done at lower level such as **method** and higher level such as package. Once we have a class, we can test it and all of the parts associated with it, especially its methods. Unit testing is usually done by using testing frameworks. For C#, popular testing frameworks include: MSTest, NUnit, and xUnit. Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The prepared AI candidate uses >10 and accepts nonpositive inputs. Both ordinary tests can pass. Require at least the exact boundary and the rejected domain, with expected outcomes unchanged before and after the repair. No live model is needed.
-->

---

## Arrange, act and assert separate three jobs

- Arrange supplies a known case
- Act calls the unit once
- Assert compares actual behavior with the stated expectation

<!--
 Assuming that you have a killer app like: namespace IntroCSCS { public class Calculator { public int Add(int x, int y) { return x + y; } } } Let’s say you want to know that this app is doing what you intend for it to do. The best way to achieve that validation is probably by providing a set of validation code that does nothing but running the app to **test** if the results come out right, such as the following: Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The prepared AI candidate uses >10 and accepts nonpositive inputs. Both ordinary tests can pass. Require at least the exact boundary and the rejected domain, with expected outcomes unchanged before and after the repair. No live model is needed.
-->

---

## Challenge two ordinary passing tests

| Units | Required behavior | Defect exposed |
| ---: | --- | --- |
| 3 | Fee 5 | Ordinary paid case |
| 12 | Fee 0 | Ordinary free case |
| 10 | Fee 0 | Wrong > instead of ≥ |
| 0 and -1 | Reject | Missing domain guard |

<!--
The prepared AI candidate uses >10 and accepts nonpositive inputs. Both ordinary tests can pass. Require at least the exact boundary and the rejected domain, with expected outcomes unchanged before and after the repair. No live model is needed. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
Console.WriteLine(ShippingFee(3) == 5);
Console.WriteLine(ShippingFee(10) == 0);
try { ShippingFee(0); Console.WriteLine("FAIL"); }
catch (ArgumentOutOfRangeException) { Console.WriteLine("PASS rejected zero"); }
int ShippingFee(int units)
{
    if (units <= 0) throw new ArgumentOutOfRangeException(nameof(units));
    return units >= 10 ? 0 : 5;
}
```

```output
True
True
PASS rejected zero
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is 'True\nTrue\nPASS rejected zero\n'. The prepared AI candidate uses >10 and accepts nonpositive inputs. Both ordinary tests can pass. Require at least the exact boundary and the rejected domain, with expected outcomes unchanged before and after the repair. No live model is needed. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

Tests at 3 and 12 both pass for a candidate using units > 10. What remains untested?

1. The exact free-shipping cutoff
2. Every possible ordinary value is wrong
3. Nothing relevant

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer A. Ten distinguishes > from >=; nonpositive cases separately distinguish a missing guard. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

## A framework makes checks repeatable

- MSTest uses TestClass and TestMethod attributes
- Application and test projects are separate
- dotnet test discovers and runs the saved tests

<!--
Currently, there is only one method (Add) in the Calculator class. As you add more methods, you will need more cases and your Program.cs will become disorganized. This is where the established tooling comes in.  The prepared AI candidate uses >10 and accepts nonpositive inputs. Both ordinary tests can pass. Require at least the exact boundary and the rejected domain, with expected outcomes unchanged before and after the repair. No live model is needed. Ask students to explain the difference this concept makes to the caller or to the person using the result.
-->

---

## Run the two-project MSTest workflow

- From UnitTestProject1, create MathApp and MathAppTest; add the explicit project reference.
- Use public TestClass/TestMethod fixtures and run dotnet test on the test project.

<!--
Use the complete application/test files and exact commands in the lesson and connected lab, rather than pasting an attribute fragment into a browser cell. The MathAppTest project references MathApp/MathApp.csproj. Test methods are public, parameterless and void. Restore/build/discovery failures are different from a failing multiplication assertion. The earlier verified lesson intentionally returns a sum from Multiply so the test suite has a meaningful red/repair/green cycle.
-->

---

## Challenge a plausible wrong result

Check 0, -1, 1, 9, 10 and 11. Keep framework setup, discovery failure and incorrect application results as different diagnostic categories.

> Name one changed input that would expose a wrong boundary, missing case or unintended state change.

<!--
Ask for a counterexample before modifying the program. Answer A. The reference connects projects. The mstest template supplies the testing dependencies, and the tests still need independent assertions. The trace provides an independent explanation of the ordinary case. The prepared AI candidate uses >10 and accepts nonpositive inputs. Both ordinary tests can pass. Require at least the exact boundary and the rejected domain, with expected outcomes unchanged before and after the repair. No live model is needed.
-->

---

<!-- _class: check -->

## Quick check 2

What does adding a project reference establish?

1. The test project can use the application code
2. Every test is correct
3. A test framework was automatically added to the application

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer A. The reference connects projects. The mstest template supplies the testing dependencies, and the tests still need independent assertions. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**AI Review: Challenge Suggested Tests**

Complete the prepared shipping review: add counterexamples, observe the candidate’s failures, repair it, and rerun the same expected outcomes.

[Open the existing practice](0603_testing.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Assessment ID cscs-testing-ai-counterexamples. Add checks for 10 and -1 alongside the supplied zero case. The candidate fails the cutoff and rejection clauses. Distinguish browser manual checks from the earlier saved MSTest project workflow; both should use the same contract. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- Check 0, -1, 1, 9, 10 and 11. Keep framework setup, discovery failure and incorrect application results as different diagnostic categories.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. The prepared AI candidate uses >10 and accepts nonpositive inputs. Both ordinary tests can pass. Require at least the exact boundary and the rejected domain, with expected outcomes unchanged before and after the repair. No live model is needed. For the Your Turn activity, the instructor answer is: Assessment ID cscs-testing-ai-counterexamples. Add checks for 10 and -1 alongside the supplied zero case. The candidate fails the cutoff and rejection clauses. Distinguish browser manual checks from the earlier saved MSTest project workflow; both should use the same contract.
-->

---

## Vocabulary to explain, not memorize

- Oracle: expected behavior
- assertion: comparison
- unit test: repeatable focused check

[Chapter objectives and glossary](0600_exceptions_testing.html)

<!--
Ask students to use each term in an explanation of this part’s case. Tie the vocabulary to the actions in the goals: Design tests from a contract rather than the implementation; Use arrange, act and assert; Run and interpret a small MSTest project. A correct definition without a correct trace is not yet sufficient evidence of application.
-->

---

<!-- _class: recap -->

## Recap and next step

- Design tests from a contract rather than the implementation
- Use arrange, act and assert
- Run and interpret a small MSTest project

[6.3 reading](0603_testing.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. The prepared AI candidate uses >10 and accepts nonpositive inputs. Both ordinary tests can pass. Require at least the exact boundary and the rejected domain, with expected outcomes unchanged before and after the repair. No live model is needed. Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: validation and error handling in 6.1, 35 minutes; meeting 2: debugging in 6.2, 35 minutes; meeting 3: unit testing in 6.3, 40 minutes. Total 110 minutes. Failure cases in 6.4 are optional.
-->

---

<!-- _class: section -->

## Optional Cases: When Software Fails People

6.4 · [6.4 reading](0604_software_responsibility.html)

Optional supporting reading. No added meeting or required assessment.

<!--
Meeting 1: validation and error handling in 6.1, 35 minutes; meeting 2: debugging in 6.2, 35 minutes; meeting 3: unit testing in 6.3, 40 minutes. Total 110 minutes. Failure cases in 6.4 are optional. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. A store promises a discount at 100, but a comparison excludes exactly 100. Repeated across many customers, a one-character defect can become a substantial fairness and trust problem.
-->

---

## Goals and preparation

- Connect a small defect to its consequences
- Explain evidence and uncertainty honestly
- Apply a professional reasoning framework

[6.4 reading](0604_software_responsibility.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: validation and error handling in 6.1, 35 minutes; meeting 2: debugging in 6.2, 35 minutes; meeting 3: unit testing in 6.3, 40 minutes. Total 110 minutes. Failure cases in 6.4 are optional. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## Scale changes the consequences of a small defect

- Count affected decisions, not only faulty lines
- Boundary rules can shift costs between groups
- A correction needs a route to affected people

<!--
Optional cases extend Chapter 1.2 with software failures, boundary tests, and professional accountability. Use these after the core testing lesson.  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The exact boundary identifies a specific defect. Passing below and above the cutoff would not expose it. Technical evidence should support a truthful explanation of scope, not an unsupported claim that every past transaction is now corrected.
-->

---

## Trace the discount threshold

| Total | Promised rate | Faulty > 100 | Correct ≥ 100 |
| ---: | ---: | ---: | ---: |
| 99 | 0% | 0% | 0% |
| 100 | 10% | 0% | 10% |
| 101 | 10% | 10% | 10% |

<!--
The exact boundary identifies a specific defect. Passing below and above the cutoff would not expose it. Technical evidence should support a truthful explanation of scope, not an unsupported claim that every past transaction is now corrected. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
Console.WriteLine(Rate(99) == 0);
Console.WriteLine(Rate(100) == 10);
Console.WriteLine(Rate(101) == 10);
int Rate(int total) => total >= 100 ? 10 : 0;
```

```output
True
True
True
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is 'True\nTrue\nTrue\n'. The exact boundary identifies a specific defect. Passing below and above the cutoff would not expose it. Technical evidence should support a truthful explanation of scope, not an unsupported claim that every past transaction is now corrected. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

<!-- _class: check -->

## Quick check 1

Which case distinguishes > 100 from ≥ 100?

1. 99
2. 100
3. 101

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. Only the exact cutoff changes between these two predicates. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Reflection: Apply the Questions to a Small Defect**

Use the existing reflection to identify stakeholders, harm, evidence, response and a limitation for one software defect.

[Open the existing practice](0604_software_responsibility.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. The optional reflection retains its original identity. A strong answer distinguishes restoring correct future behavior from identifying past affected people and communicating a supported remedy. Do not infer that a passing code test proves the organizational response is complete. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

<!-- _class: recap -->

## Recap and next step

- Connect a small defect to its consequences
- Explain evidence and uncertainty honestly
- Apply a professional reasoning framework

[6.4 reading](0604_software_responsibility.html) · Optional reading; no required assessment.

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. The exact boundary identifies a specific defect. Passing below and above the cutoff would not expose it. Technical evidence should support a truthful explanation of scope, not an unsupported claim that every past transaction is now corrected. This supporting part is optional and does not add a core assessment prerequisite. Meeting 1: validation and error handling in 6.1, 35 minutes; meeting 2: debugging in 6.2, 35 minutes; meeting 3: unit testing in 6.3, 40 minutes. Total 110 minutes. Failure cases in 6.4 are optional.
-->
