---
marp: true
theme: thinkpress-lecture
paginate: true
title: "Computing, Programs, and Responsibility"
book: "Computer Science in C#"
section: "Chapter 1"
primary: "#2a6b37"
accent: "#b8860b"
---

<!-- _class: title -->

# Computing, Programs, and Responsibility

Chapter 1 · Computer Science in C#

<!--
Part map (1-based slide numbers): 1.1 Computing and Problem Solving: slide 2; 1.2 Computing and Professional Responsibility: slide 20; 1.3 Your First C# Program and Basic Syntax: slide 38. Meeting 1: 1.1, 35 minutes; meeting 2: 1.2, 35 minutes; meeting 3: 1.3, 40 minutes. Total 110 minutes. Platform details remain reference reading. Use selected examples and checks inside the existing allocation. Additional source detail remains preparation/reference reading. Every example is standalone; instructor answers remain in notes.
-->

---

<!-- _class: section -->

## Computing and Problem Solving

1.1 · [1.1 reading](0101_cs_ideas.html)

Read, predict, trace, then apply.

<!--
Meeting 1: 1.1, 35 minutes; meeting 2: 1.2, 35 minutes; meeting 3: 1.3, 40 minutes. Total 110 minutes. Platform details remain reference reading. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. An appointment desk wants reminders that reach the intended customer with the correct time. Start with the task and the people, before choosing statements.
-->

---

## Goals and preparation

- Describe a system with input, processing, output and storage
- Write an unambiguous procedure
- Distinguish source, build, execution and correctness

[1.1 reading](0101_cs_ideas.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: 1.1, 35 minutes; meeting 2: 1.2, 35 minutes; meeting 3: 1.3, 40 minutes. Total 110 minutes. Platform details remain reference reading. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The business question

An appointment desk wants reminders that reach the intended customer with the correct time. Start with the task and the people, before choosing statements.

> What information, rule and observable result do we need?

<!--
An appointment desk wants reminders that reach the intended customer with the correct time. Start with the task and the people, before choosing statements. Ask pairs to name the input, required result and a possible wrong answer. Expected discussion: distinguish the stated business requirement from an implementation that merely runs. Use the trace in this part to make that distinction concrete.
-->

---

## Model the task before the code

- Input: time, approved destination, permission
- Process: select an appointment and compose a message
- Output: a clear reminder

<!--
A program is a set of instructions a computer executes. Computer science asks how to represent information, describe a procedure precisely, and evaluate whether the result solves the intended problem. Programming makes those ideas concrete. Consider a small business that sends appointment reminders. A useful program must select the right appointment, produce an understandable message, and avoid exposing unnecessary information. Begin by describing the task before choosing C# statements.  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The output can become a later input. A successful send is different from a correct appointment time; review the data and the procedure independently.
-->

---

## Hardware, software and data have different jobs

- Hardware carries out physical operations
- Software supplies instructions
- An encoding gives bit patterns meaning

<!--
**Hardware** is the physical equipment, including a processor, memory, storage, and input/output devices. **Software** supplies instructions. An operating system manages hardware and provides services to applications, such as reading a file or displaying text. Computers encode data as bits, each with two possible values, conventionally written `0` and `1`. Eight bits form a byte. An encoding determines what a sequence of bits means: a number, text, an image, or another kind of data. The same bit pattern can mean different things under different encodings. You will choose C# data types in Chapter 2; a type constrains the values and operations your program uses. For an appointment service, a date is data, a reminder application is software, and the computer that runs it is hardware. A correctly functioning computer can still execute instructions that send the wrong date. Hardware operation and application correctness are different questions. **Check Your Understanding:** Identify one input device, one output device, and one stored data item used by the appointment service.  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. The output can become a later input. A successful send is different from a correct appointment time; review the data and the procedure independently.
-->

---

## Follow one reminder through the system

| Stage | Information or action |
| --- | --- |
| Input | Tuesday 10:00; approved contact |
| Processing | Select appointment; compose minimal notice |
| Output | Appointment Tuesday at 10:00 |
| Storage and feedback | Record delivery; correct a wrong time |

<!--
The output can become a later input. A successful send is different from a correct appointment time; review the data and the procedure independently. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Appointment Tuesday at 10:00.");
        Console.WriteLine("Contact the office to make a change.");
    }
}
```

```output
Appointment Tuesday at 10:00.
Contact the office to make a change.
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is 'Appointment Tuesday at 10:00.\nContact the office to make a change.\n'. The output can become a later input. A successful send is different from a correct appointment time; review the data and the procedure independently. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

## Development is a feedback process

| Activity | Reminder-service evidence |
| --- | --- |
| Requirements and design | Approved recipients; clear procedure |
| Implementation and build | Saved source; compiler result |
| Testing and debugging | Expected time versus actual message |
| Deployment | Approved release into use |
| Maintenance | Correct records/rules as needs change |

<!--
The reading names seven activities: requirements analysis, design, implementation, build/compilation, testing/debugging, deployment and maintenance. The table pairs related activities to fit the business trace. They are not a guarantee that real development is a one-way waterfall; test evidence can send the team back to a requirement or design.
-->

---

## Work one byte by place value

| Bit position | 7 | 6 | 5 | 4 | 3 | 2 | 1 | 0 |
| --- | ---: | ---: | ---: | ---: | ---: | ---: | ---: | ---: |
| Place value | 128 | 64 | 32 | 16 | 8 | 4 | 2 | 1 |
| Pattern | 0 | 1 | 0 | 0 | 0 | 0 | 0 | 1 |

0100 0001 gives 64 + 1 = 65; ASCII interprets 65 as uppercase A.

<!--
Ask students to point to the two nonzero contributions. The same bits require an encoding to mean text rather than a number. A byte offers256patterns, not256characters under every encoding. Qualified address-width details remain reference reading within the first meeting.
-->

---

<!-- _class: check -->

## Quick check 1

A reminder runs but names the wrong day. What does successful execution establish?

1. The requirements were appropriate
2. The instructions ran
3. The stored data was current

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. Running establishes execution, not data quality or agreement with the intended rule. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

## An algorithm must settle the choices

- Specify which appointments qualify
- State what information the message includes
- Define how the result will be checked

<!--
The **input-process-output (IPO) model** describes a task through the information it receives, the work it performs, and the result it produces. | Stage | Appointment reminder example | | --- | --- | | Input | Appointment time, contact destination, and permission to send a reminder. | | Processing | Select the appointment that needs a reminder and compose an appropriate message. | | Output | A message telling the recipient when to arrive. | The model separates a problem from its implementation. A receptionist and a computer can follow the same reminder procedure using different tools. Input can also come from a file or another system rather than a keyboard; output can be stored rather than displayed. Specify an observable result: “A reminder displays the correct appointment time without including the reason for the visit.” That statement supports both a correctness check and a privacy decision. “Make a good reminder app” does not say what to test. **Check Your Understanding:** Describe input, processing, and output for a bookstore's daily sales summary. Name a result the manager could check.  The output can become a later input. A successful send is different from a correct appointment time; review the data and the procedure independently. Ask students to explain the difference this concept makes to the caller or to the person using the result.
-->

---

## Representations need an interpretation

- A byte has 256 possible patterns. ASCII A uses decimal 65, or 0100 0001.
- C# source is compiled to intermediate instructions; .NET normally uses JIT translation during execution.

<!--
Work from right to left with binary place values: 64 + 1 gives 65. Do not equate an encoding with the physical data bits. The compilation/runtime pipeline can combine techniques rather than dividing all languages permanently into compiled or interpreted.
-->

---

## Challenge a plausible wrong result

Check an ordinary appointment, a corrected time and a missing permission. Separate a compilation failure from a wrong message.

> Name one changed input that would expose a wrong boundary, missing case or unintended state change.

<!--
Ask for a counterexample before modifying the program. Answer C: eight binary positions give 2^8 patterns. The encoding determines their interpretation. The trace provides an independent explanation of the ordinary case. The output can become a later input. A successful send is different from a correct appointment time; review the data and the procedure independently.
-->

---

<!-- _class: check -->

## Quick check 2

How many distinct patterns fit in one byte?

1. 8
2. 128
3. 256

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer C: eight binary positions give 2^8 patterns. The encoding determines their interpretation. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Reflection: Describe a System You Use**

Describe input, processing, output and one stored record for a campus system. Identify a failure whose symptom appears later.

[Open the existing practice](0101_cs_ideas.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Existing reflection heading; no assessment identity changed. Suggested answer: registration takes course choices, checks prerequisites and seats, produces a schedule and stores enrollment. An outdated prerequisite record can produce an incorrect rejection. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- Check an ordinary appointment, a corrected time and a missing permission. Separate a compilation failure from a wrong message.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. The output can become a later input. A successful send is different from a correct appointment time; review the data and the procedure independently. For the Your Turn activity, the instructor answer is: Existing reflection heading; no assessment identity changed. Suggested answer: registration takes course choices, checks prerequisites and seats, produces a schedule and stores enrollment. An outdated prerequisite record can produce an incorrect rejection.
-->

---

## Vocabulary to explain, not memorize

- IPO: describe the task
- algorithm: precise procedure
- compiler/runtime: translate and execute

[Chapter objectives and glossary](0100_getting_started.html)

<!--
Ask students to use each term in an explanation of this part’s case. Tie the vocabulary to the actions in the goals: Describe a system with input, processing, output and storage; Write an unambiguous procedure; Distinguish source, build, execution and correctness. A correct definition without a correct trace is not yet sufficient evidence of application.
-->

---

<!-- _class: recap -->

## Recap and next step

- Describe a system with input, processing, output and storage
- Write an unambiguous procedure
- Distinguish source, build, execution and correctness

[1.1 reading](0101_cs_ideas.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. The output can become a later input. A successful send is different from a correct appointment time; review the data and the procedure independently. Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: 1.1, 35 minutes; meeting 2: 1.2, 35 minutes; meeting 3: 1.3, 40 minutes. Total 110 minutes. Platform details remain reference reading.
-->

---

<!-- _class: section -->

## Computing and Professional Responsibility

1.2 · [1.2 reading](0102_computing_responsibility.html)

Read, predict, trace, then apply.

<!--
Meeting 1: 1.1, 35 minutes; meeting 2: 1.2, 35 minutes; meeting 3: 1.3, 40 minutes. Total 110 minutes. Platform details remain reference reading. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. A bookstore automatically sends overdue notices. The manager sees the report, but customers, staff and people sharing a contact address bear its consequences.
-->

---

## Goals and preparation

- Identify stakeholders and possible harm
- Distinguish implementation, data, rules and consequences
- Explain privacy, accessibility, attribution and verified AI assistance

[1.2 reading](0102_computing_responsibility.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: 1.1, 35 minutes; meeting 2: 1.2, 35 minutes; meeting 3: 1.3, 40 minutes. Total 110 minutes. Platform details remain reference reading. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The business question

A bookstore automatically sends overdue notices. The manager sees the report, but customers, staff and people sharing a contact address bear its consequences.

> What information, rule and observable result do we need?

<!--
A bookstore automatically sends overdue notices. The manager sees the report, but customers, staff and people sharing a contact address bear its consequences. Ask pairs to name the input, required result and a possible wrong answer. Expected discussion: distinguish the stated business requirement from an implementation that merely runs. Use the trace in this part to make that distinction concrete.
-->

---

## A stakeholder may never use the software

- Customers may pay a fee because of a report
- Staff must investigate disputed records
- Managers need evidence before acting

<!--
Computing systems help organizations sell goods, pay employees, manage collections, and provide services. Their results influence what people believe and what they can do. A stock report can cause a manager to reorder supplies. An overdue notice can cause a customer to pay a fee. An account restriction can prevent someone from completing a task. Understanding a program therefore includes understanding the work and decisions around it. **Professional responsibility** means taking care in the work you perform, explaining its limits honestly, and considering the people affected by it. This section introduces that responsibility before you begin writing larger programs. You do not need C# syntax to understand the examples. Each example connects a computing decision to a consequence; later chapters give you the programming tools to examine and improve such decisions. The Association for Computing Machinery (ACM) publishes a professional code addressing harm, honesty, fairness, privacy, and the quality of computing work.[^0102_computing_responsibility-acm] A code supplies principles for judgment. Applying them still requires understanding the particular people, information, and task involved.  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. Ask who can detect each problem and who can correct it. A report confined to a manager can still cause a harmful later action. A working correction route is part of responsible system design.
-->

---

## Correct execution is only one question

- Implementation: did the code follow the rule?
- Data and requirements: were the records and rule suitable?
- Consequences: is the proposed decision appropriate?

<!--
A **stakeholder** is a person or group affected by a system or a decision about it. The person who operates the software is one stakeholder, but others may never touch it. In a bookstore, a cashier uses the sales system, a customer relies on its receipt, a manager uses its reports, and warehouse staff act on its stock requests. A change that saves the cashier time might create extra work for another group. Consider a bookstore that introduces automatic overdue notices for rented textbooks. Its goal is reasonable: reduce the time staff spend checking rentals and help customers return books. The system compares a stored due date with a recorded return date and selects customers to notify. Before examining any code, we can identify several possible consequences. | Stakeholder | What they rely on | What could go wrong | | --- | --- | --- | | Customer | Accurate return status and a way to correct mistakes | An incorrect notice causes worry or an unfair charge. | | Desk staff | Records that reflect accepted returns | Staff must investigate repeated complaints. | | Manager | Reports that distinguish outstanding rentals from record errors | A misleading report leads to a mistaken business decision. | | Another person using a shared account or device | Appropriate limits on information displayed | A notice exposes someone else's borrowing details. | **Harm** is a negative consequence, such as financial loss, disclosure of information, exclusion from a service, or damage to trust. A useful analysis identifies the consequence and who experiences it. Saying that a program is “bad” does not explain what needs to change. Automation can repeat an error across many records before anyone notices. If a return-processing step is delayed, a nightly notice program might contact every affected customer. Faster execution would make that particular problem spread faster. The appropriate response might include checking how return records are updated, reviewing uncertain cases, and giving customers a correction route. It is not necessarily a faster computer. Four questions help organize an initial review: **Who is affected? What could go wrong? What information is necessary? What should change or be disclosed?** These questions lead from a general concern to an issue that an organization can investigate.  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. Ask who can detect each problem and who can correct it. A report confined to a manager can still cause a harmful later action. A working correction route is part of responsible system design.
-->

---

## Trace a report into a decision

| Step | Possible failure | Person affected |
| --- | --- | --- |
| Read return record | A return was not recorded | Customer |
| Classify overdue | Wrong cutoff rule | Customer and staff |
| Deliver notice | Shared address reveals history | Other recipients |
| Contest result | Smartphone-only route excludes users | Customer |

<!--
Ask who can detect each problem and who can correct it. A report confined to a manager can still cause a harmful later action. A working correction route is part of responsible system design. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Work a second responsibility case

A stock screen marks low inventory only with red.

- Add the words “Reorder needed.”
- Check keyboard access and reading order separately.
- Provide a usable route to question a wrong stock status.

<!--
The text label reduces reliance on color. It does not establish full accessibility or prove that the stock data is correct. Ask which issue belongs to perception, which belongs to data quality, and which belongs to accountability. No C# activity is assigned in1.2.
-->

---

## Privacy and security answer different questions

A report exports customer names, phone numbers and purchase history.

- Which fields are actually needed for this decision?
- Who may access the export?
- How long should it be retained?

<!--
Minimization and retention concern appropriate personal-data use. Access control and protection against unauthorized access concern security. A protected export can still be unnecessarily intrusive, and removing names alone does not establish anonymity when identifiers can be linked elsewhere. Use synthetic examples only.
-->

---

## Review a prepared AI suggestion

Requirement: offer the discount at 100 or more.

Prepared suggestion: “Use a strict greater-than comparison.”

Before accepting it, identify a counterexample and record the assistance.

<!--
Answer: exactly100qualifies under the stated requirement but a strict greater-than test excludes it. An LLM generates text from a prompt; an AI coding assistant can combine a model with tools. Neither a confident explanation nor a successful ordinary example establishes the boundary. Students can review this prepared candidate without using a live service. Keep this part conceptual; do not introduce C# syntax here.
-->

---

<!-- _class: check -->

## Quick check 1

Only the manager receives a faulty overdue report. Who can still be affected?

1. Only the manager
2. Customers whose accounts are acted on
3. Nobody until the report is public

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. A private report can drive charges or restrictions; the affected person need not read the report. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

## Minimize barriers and unnecessary exposure

- Privacy concerns appropriate use and retention
- Security protects against unauthorized access
- Text labels and usable correction routes support accessibility

<!--
**Check Your Understanding:** A bookstore's overdue report is sent only to its manager. Does that mean customers cannot be affected by an error in it? Explain the connection between the report and a later decision.  Ask who can detect each problem and who can correct it. A report confined to a manager can still cause a harmful later action. A working correction route is part of responsible system design. Ask students to explain the difference this concept makes to the caller or to the person using the result.
-->

---

## Credit, permission and evidence

- Attribution identifies a source; a license supplies reuse conditions.
- Prepared AI suggestions are claims to inspect, not proof of correctness.

<!--
Ask whether adding a name alone permits copying: no, permissions still matter. A prepared AI candidate can be reviewed without an account. Require a requirement trace, synthetic data, independent checks and an honest account of assistance. Do not paste personal customer information into a tool.
-->

---

## Challenge a plausible wrong result

Evaluate a wrong record, an inaccessible correction route and a prepared AI suggestion that omits a requirement. No live AI account is needed.

> Name one changed input that would expose a wrong boundary, missing case or unintended state change.

<!--
Ask for a counterexample before modifying the program. Answer B. Text adds a second way to perceive meaning; keyboard access, reading order and other needs still require evaluation. The trace provides an independent explanation of the ordinary case. Ask who can detect each problem and who can correct it. A report confined to a manager can still cause a harmful later action. A working correction route is part of responsible system design.
-->

---

<!-- _class: check -->

## Quick check 2

A stock display adds “Reorder needed” beside red items. What has been established?

1. Every accessibility need is met
2. A color-only information barrier has been reduced
3. Keyboard navigation is verified

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. Text adds a second way to perceive meaning; keyboard access, reading order and other needs still require evaluation. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Reflection: Map the Stakeholders of One Feature**

Map an appointment reminder to its users, operators and indirectly affected people. Name one harm even if the feature follows its specification.

[Open the existing practice](0102_computing_responsibility.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Existing conceptual reflection. Possible answer: a correct reminder sent to a shared phone exposes an appointment; use an approved channel and minimal details, and supply a correction route. There is no coding task in this part. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- Evaluate a wrong record, an inaccessible correction route and a prepared AI suggestion that omits a requirement. No live AI account is needed.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. Ask who can detect each problem and who can correct it. A report confined to a manager can still cause a harmful later action. A working correction route is part of responsible system design. For the Your Turn activity, the instructor answer is: Existing conceptual reflection. Possible answer: a correct reminder sent to a shared phone exposes an appointment; use an approved channel and minimal details, and supply a correction route. There is no coding task in this part.
-->

---

## Vocabulary to explain, not memorize

- Stakeholder: affected person
- privacy/security: appropriate use/protection
- attribution/license: credit/permission

[Chapter objectives and glossary](0100_getting_started.html)

<!--
Ask students to use each term in an explanation of this part’s case. Tie the vocabulary to the actions in the goals: Identify stakeholders and possible harm; Distinguish implementation, data, rules and consequences; Explain privacy, accessibility, attribution and verified AI assistance. A correct definition without a correct trace is not yet sufficient evidence of application.
-->

---

<!-- _class: recap -->

## Recap and next step

- Identify stakeholders and possible harm
- Distinguish implementation, data, rules and consequences
- Explain privacy, accessibility, attribution and verified AI assistance

[1.2 reading](0102_computing_responsibility.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. Ask who can detect each problem and who can correct it. A report confined to a manager can still cause a harmful later action. A working correction route is part of responsible system design. Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: 1.1, 35 minutes; meeting 2: 1.2, 35 minutes; meeting 3: 1.3, 40 minutes. Total 110 minutes. Platform details remain reference reading.
-->

---

<!-- _class: section -->

## Your First C# Program and Basic Syntax

1.3 · [1.3 reading](0103_program_structure.html)

Read, predict, trace, then apply.

<!--
Meeting 1: 1.1, 35 minutes; meeting 2: 1.2, 35 minutes; meeting 3: 1.3, 40 minutes. Total 110 minutes. Platform details remain reference reading. This part belongs to that allocation; slides are teaching choices, not separate timed lectures. Introduce the business question before syntax. The Northwind order desk needs three clear lines of output. The first program has fixed text and literal arithmetic; variables and keyboard input come in Chapter 2.
-->

---

## Goals and preparation

- Create, save, build and run a console project
- Read statements, expressions, literals and method calls
- Use diagnostics to repair a small message

[1.3 reading](0103_program_structure.html)

<!--
Map these goals to the chapter landing objectives. Ask students to predict the worked example before its run. Meeting 1: 1.1, 35 minutes; meeting 2: 1.2, 35 minutes; meeting 3: 1.3, 40 minutes. Total 110 minutes. Platform details remain reference reading. Use the later independent lab/homework for transfer rather than adding another meeting.
-->

---

## The business question

The Northwind order desk needs three clear lines of output. The first program has fixed text and literal arithmetic; variables and keyboard input come in Chapter 2.

> What information, rule and observable result do we need?

<!--
The Northwind order desk needs three clear lines of output. The first program has fixed text and literal arithmetic; variables and keyboard input come in Chapter 2. Ask pairs to name the input, required result and a possible wrong answer. Expected discussion: distinguish the stated business requirement from an implementation that merely runs. Use the trace in this part to make that distinction concrete.
-->

---

## Read from the outside in

- A namespace groups type names
- Program contains Main, the entry point
- Statements inside Main run from top to bottom

<!--
A store needs a short console message for its order desk. You will build that message, read the punctuation in its source code, and change it without losing its meaning. **Syntax** means the rules for writing valid code. Learning a few rules lets you read unfamiliar programs before you know every feature they use. Complete {doc}`C# Setup and Verification ` before the local steps. A **console application** communicates through text in a terminal. The shell accepts commands such as `dotnet run`; the application produces the store message. When the application ends, the shell prompt returns. For each short exercise, predict the output before selecting **Run**, compare the result, and explain any difference. Browser cells run independently. For local practice, put their executable statements inside your project's `Main` method; a `using System;` directive belongs at the top of the file, outside the class. Variables and keyboard input follow in Chapter 2.  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. Quotes delimit literal text and are not printed. Braces in interpolation enclose an expression, while braces around Main delimit its block. Saving makes the edited file available to the build.
-->

---

## A value and an instruction have different roles

- A literal writes a value directly
- An expression computes a value
- A statement tells the program to do something

<!--
Open your terminal and navigate to the workspace folder you created in Appendix B. If you are still inside `csharprepl`, enter `exit` first so that you can type shell commands. Run these commands one at a time: The first command creates a console project in a new folder named `HelloWorld`. The `--use-program-main` option makes the template show the `Program` class and `Main` method explicitly.[^0103_program_structure-1] The second command moves the shell into that folder. The third opens the folder in VS Code. If `code .` is unavailable, use **File > Open Folder** in VS Code and select `HelloWorld`. A **project** groups source files and the settings needed to build an application. The `HelloWorld` folder is your project folder. In VS Code's **Explorer**, expand that folder and identify these two files: | File | What you do with it | | --- | --- | | `Program.cs` | Open and edit the C# source code. The `.cs` extension identifies a C# source file. | | `HelloWorld.csproj` | Inspect the project settings. The `.csproj` extension identifies a C# project file. | Opening the project folder lets VS Code work with the source files and their build settings together. The folder is where you keep the files; the `.csproj` tells .NET how to build the application. The project name, `HelloWorld`, is not itself an executable C# instruction. In VS Code, open `Program.cs`. Its contents should look like the following complete program:  Teaching cue: explain why each step matters in this specific business case, then have a student restate the rule before the worked trace. Quotes delimit literal text and are not printed. Braces in interpolation enclose an expression, while braces around Main delimit its block. Saving makes the edited file available to the build.
-->

---

## Predict the order-desk message

| Source action | Value supplied | Output line |
| --- | --- | --- |
| First WriteLine | String literal | Northwind Store |
| Second WriteLine | Interpolation with 2 + 2 | Items ready: 4 |
| Third WriteLine | String literal | Collect at the order desk. |

<!--
Quotes delimit literal text and are not printed. Braces in interpolation enclose an expression, while braces around Main delimit its block. Saving makes the edited file available to the build. Reveal or discuss one row at a time. Ask for the next state before showing it; a wrong prediction identifies exactly which operation or policy needs attention.
-->

---

## Run the complete example

```csharp
using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Northwind Store");
        Console.WriteLine($"Items ready: {2 + 2}");
        Console.WriteLine("Collect at the order desk.");
    }
}
```

```output
Northwind Store
Items ready: 4
Collect at the order desk.
```

<!--
This is one complete standalone C# program, not a fragment requiring state from another slide. Explain the output against the preceding trace. Expected stdout is 'Northwind Store\nItems ready: 4\nCollect at the order desk.\n'. Quotes delimit literal text and are not printed. Braces in interpolation enclose an expression, while braces around Main delimit its block. Saving makes the edited file available to the build. Keep the saved output visible if a live environment is unavailable; do not treat it as the learner’s own run.
-->

---

## Create and run from the project folder

```text
dotnet new console --use-program-main -o HelloWorld
cd HelloWorld
code .
dotnet run
```

Save edits to Program.cs, then run again.

<!--
These shell commands require the AppendixBSDK/editor setup. The explicit Main template fits the program form in this part. cd changes the current working directory; dotnet run locates the project there. If code is unavailable, open the folder from VSCode. The browser can support first output while local setup is being completed; it does not replace the saved-project handoff.
-->

---

<!-- _class: check -->

## Quick check 1

Which instruction displays the result 3?

1. WriteLine("2 + 1")
2. WriteLine(2 + 1)
3. WriteLine("3 items")

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer B. The unquoted arithmetic expression is evaluated; A prints the expression text and C prints a labeled string. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

## Edit, save, run and inspect

- Create with dotnet new console --use-program-main
- Run dotnet run from the project folder
- Read the first useful diagnostic and repair one cause

<!--
Run the application from the terminal while you are in the `HelloWorld` folder: The output is `Hello, World!`. The application then ends and the shell prompt returns. In VS Code, you can use **Terminal > New Terminal**; check that its current folder is `HelloWorld`.  Quotes delimit literal text and are not printed. Braces in interpolation enclose an expression, while braces around Main delimit its block. Saving makes the edited file available to the build. Ask students to explain the difference this concept makes to the caller or to the person using the result.
-->

---

## Read diagnostics as evidence

- A missing semicolon and a misspelled identifier are different causes.
- Repair the earliest useful message, save and rebuild.

<!--
The lesson repair deliberately exposes a missing semicolon first and then a case-sensitive name. Ask why one repair can reveal another error: the first prevents the compiler from analyzing the later statement cleanly. Source files and the .csproj are project artifacts; a namespace is not another folder.
-->

---

## Challenge a plausible wrong result

Compare exact text, spaces, line order and line count. For a diagnostic, repair the semicolon before chasing a later misspelled name.

> Name one changed input that would expose a wrong boundary, missing case or unintended state change.

<!--
Ask for a counterexample before modifying the program. Answer A. The build reads saved source. C changes a case-sensitive entry-point name and can cause a separate error. The trace provides an independent explanation of the ordinary case. Quotes delimit literal text and are not printed. Braces in interpolation enclose an expression, while braces around Main delimit its block. Saving makes the edited file available to the build.
-->

---

<!-- _class: check -->

## Quick check 2

The editor shows a changed message, but the file is unsaved. What should you check first?

1. Save, then run from the project folder
2. Reinstall the SDK
3. Rename Main to main

<!--
Allow 30 seconds of individual thinking, then poll and ask for a reason. Answer A. The build reads saved source. C changes a case-sensitive entry-point name and can cause a separate error. If the distractor attracts many responses, return to the relevant trace row and ask students to apply the stated rule.
-->

---

<!-- _class: yourturn -->

## Your turn

**Modify: An Order-Desk Summary**

Complete the existing order-desk exercise with an interpolated quantity. Predict all three lines, run, and compare the text exactly.

[Open the existing practice](0103_program_structure.html)

<!--
Give pairs a short attempt within the chapter’s existing practice allocation. Assessment ID cscs-first-program-modify remains unchanged. Answer: output Northwind Store, Items ready: 4, and Collect at the order desk. Keep 2 + 2 as the interpolated expression; do not introduce variables. Ask students to explain their result before revealing the lesson’s suggested answer. This slide points to the existing exercise and creates no new assessment ID.
-->

---

## Evidence before declaring success

- Predict the required result from the rule.
- Record the actual result and explain any discrepancy.
- Compare exact text, spaces, line order and line count. For a diagnostic, repair the semicolon before chasing a later misspelled name.

<!--
The evidence should distinguish this topic’s likely defect, rather than merely repeat a known passing run. Quotes delimit literal text and are not printed. Braces in interpolation enclose an expression, while braces around Main delimit its block. Saving makes the edited file available to the build. For the Your Turn activity, the instructor answer is: Assessment ID cscs-first-program-modify remains unchanged. Answer: output Northwind Store, Items ready: 4, and Collect at the order desk. Keep 2 + 2 as the interpolated expression; do not introduce variables.
-->

---

## Vocabulary to explain, not memorize

- Statement: instruction
- expression: value
- identifier: case-sensitive name

[Chapter objectives and glossary](0100_getting_started.html)

<!--
Ask students to use each term in an explanation of this part’s case. Tie the vocabulary to the actions in the goals: Create, save, build and run a console project; Read statements, expressions, literals and method calls; Use diagnostics to repair a small message. A correct definition without a correct trace is not yet sufficient evidence of application.
-->

---

<!-- _class: recap -->

## Recap and next step

- Create, save, build and run a console project
- Read statements, expressions, literals and method calls
- Use diagnostics to repair a small message

[1.3 reading](0103_program_structure.html) · [Lab](assignments/lab.html) · [Homework](assignments/homework.html)

<!--
Ask students to supply a concrete example for each goal, using the business case rather than repeating a definition. Quotes delimit literal text and are not printed. Braces in interpolation enclose an expression, while braces around Main delimit its block. Saving makes the edited file available to the build. Use the existing lab for connected practice and homework for independent transfer. Assessment IDs remain unchanged. Meeting 1: 1.1, 35 minutes; meeting 2: 1.2, 35 minutes; meeting 3: 1.3, 40 minutes. Total 110 minutes. Platform details remain reference reading.
-->
