---
marp: true
theme: thinkpress-lecture
paginate: true
title: "Files and Text"
book: Computer Science in C#
section: "Chapter 9"
primary: "#2a6b37"
accent: "#b8860b"
---

<!-- _class: title -->

# Files and Text

Chapter 9 · Computer Science in C#

Business models, worked traces, and verified C# examples.

<!--
Part 9.1: File Foundations: Reading and Writing, starts on slide 2.
Part 9.2: File Workflows, Paths, and Resources, starts on slide 17.
Part 9.3: Text Operations, starts on slide 32.
Part 9.4: Regular Expressions, starts on slide 47.
Part 9.5: Privacy and Security in Code, starts on slide 52.
Core reading parts share the chapter's existing three-meeting allocation, totaling 110 minutes. They are not separate fifty-minute meetings. Optional/reference parts add no required meeting. Speaker-note answers belong to the instructor output; publish student HTML with those notes stripped.
-->

---

<!-- _class: section -->

# File Foundations: Reading and Writing

Part 9.1 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 35 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. A coffee cart closes with three register totals. The saved report must contain one total per line and must be readable after writing finishes. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Read and write a text file.
- Separate stream position from stored text.
- Dispose a writer before reading its output.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. A writer buffers output. End its scope before another operation depends on the completed file. A reader advances after each ReadLine call. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

A coffee cart closes with three register totals. The saved report must contain one total per line and must be readable after writing finishes.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. A coffee cart closes with three register totals. The saved report must contain one total per line and must be readable after writing finishes. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

File I/O moves data across a program boundary. A path names the resource; a reader or writer owns a handle to it.

<!--
File I/O moves data across a program boundary. A path names the resource; a reader or writer owns a handle to it. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

A writer buffers output. End its scope before another operation depends on the completed file. A reader advances after each ReadLine call.

<!--
A writer buffers output. End its scope before another operation depends on the completed file. A reader advances after each ReadLine call. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 9.1

```csharp
using System;
using System.IO;
string path = Path.GetTempFileName();
try {
    using (var writer = new StreamWriter(path)) writer.WriteLine("Invoice 41");
    Console.Write(File.ReadAllText(path));
}
finally { File.Delete(path); }
```

```output
Invoice 41
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is Invoice 41. Connect each observation to the contract: A writer buffers output. End its scope before another operation depends on the completed file. A reader advances after each ReadLine call. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Event|File / handle state |
| --- | --- |
| Open writer|New output resource |
| Write Invoice 41|Output may still be buffered |
| Dispose writer|Buffered output flushed; handle released |
| Read file|Invoice 41 is available |

<!--
Walk through the rows before executing another example. Event: File / handle state. Open writer: New output resource. Write Invoice 41: Output may still be buffered. Dispose writer: Buffered output flushed; handle released. Read file: Invoice 41 is available. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## Which action completes buffered output?

1. Construct a reader
2. Dispose the writer
3. Assign the path again

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: B. Disposal flushes and releases the writer. A reader cannot complete another object's pending writes; assigning a path does no I/O. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Operation|Result |
| --- | --- |
| ReadAllText|One string containing all text |
| ReadLine|One line and an advanced position |
| WriteLine|Text plus a line ending |

<!--
Operation: Result. ReadAllText: One string containing all text. ReadLine: One line and an advanced position. WriteLine: Text plus a line ending. A writer buffers output. End its scope before another operation depends on the completed file. A reader advances after each ReadLine call. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

Calling ReadLine twice examines two different lines. Store one returned line, inspect it, and reuse that stored value.

<!--
Calling ReadLine twice examines two different lines. Store one returned line, inspect it, and reuse that stored value. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## A reader returns null. What does that mean?

1. End of input
2. An empty line
3. A zero numeric value

<!--
Poll again after the contrasting case. Answer: A. Null marks end of stream; an empty line returns the empty string. Neither result is a numeric conversion. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

The receipt contains an empty middle line. Should a line counter count it?

<!--
Pause for a prediction before changing the input or model. Answer: Yes: a line is still a line. A separate policy may skip blank records, but that changes the question being counted. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

In Write a Receipt and Read It Back, repair the missing writer call. Confirm three receipt lines and Lines read: 3.

[Open the lesson exercise](0901_stream_file.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: Add the missing writer.WriteLine call, dispose the writer, then count every successful ReadLine result. Do not increment only when the returned text is nonempty. Watch for this defect: Calling ReadLine twice examines two different lines. Store one returned line, inspect it, and reuse that stored value.
-->

---

## Verify more than one example

Check an empty file, a blank middle line, and a final line without a newline. Predict each line count before running.

<!--
Use independently predicted results. Check an empty file, a blank middle line, and a final line without a newline. Predict each line count before running. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Read and write a text file.
- Separate stream position from stored text.
- Dispose a writer before reading its output.

<!--
A writer buffers output. End its scope before another operation depends on the completed file. A reader advances after each ReadLine call. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->

---

<!-- _class: section -->

# File Workflows, Paths, and Resources

Part 9.2 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 40 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. A closing total must be added to an existing daily log. A failed import must release its writer without pretending partial output is a complete report. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Build a path without hard-coded separators.
- Choose overwrite or append intentionally.
- Explain cleanup after an exception.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. Path.Combine creates a string, not a directory. Append preserves previous rows; overwrite replaces them. Using bounds the lifetime even during exception unwinding. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

A closing total must be added to an existing daily log. A failed import must release its writer without pretending partial output is a complete report.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. A closing total must be added to an existing daily log. A failed import must release its writer without pretending partial output is a complete report. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

Path construction, acquisition, processing, and disposal are separate steps. Resource availability is different from record validity.

<!--
Path construction, acquisition, processing, and disposal are separate steps. Resource availability is different from record validity. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

Path.Combine creates a string, not a directory. Append preserves previous rows; overwrite replaces them. Using bounds the lifetime even during exception unwinding.

<!--
Path.Combine creates a string, not a directory. Append preserves previous rows; overwrite replaces them. Using bounds the lifetime even during exception unwinding. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 9.2

```csharp
using System;
using System.IO;
string path = Path.GetTempFileName();
try {
    File.WriteAllText(path, "20\n");
    using (var writer = new StreamWriter(path, append: true)) writer.WriteLine(30);
    Console.WriteLine(string.Join("|", File.ReadAllLines(path)));
}
finally { File.Delete(path); }
```

```output
20|30
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is 20|30. Connect each observation to the contract: Path.Combine creates a string, not a directory. Append preserves previous rows; overwrite replaces them. Using bounds the lifetime even during exception unwinding. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Event|Report contents |
| --- | --- |
| Initial write|20 |
| Append 30|20, 30 |
| Read after disposal|Two complete lines |
| Overwrite instead|Only the replacement line |

<!--
Walk through the rows before executing another example. Event: Report contents. Initial write: 20. Append 30: 20, 30. Read after disposal: Two complete lines. Overwrite instead: Only the replacement line. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## Does Path.Combine create the directory?

1. Yes, if the name is valid
2. No; it builds a path string
3. Only on Windows

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: B. Directory.CreateDirectory is a separate operation. A valid-looking path does not establish existence or permissions. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Outcome|Interpretation |
| --- | --- |
| Missing input|No readable source was acquired |
| Existing empty input|A valid source has zero rows |
| Malformed row|A record failed its parsing contract |

<!--
Outcome: Interpretation. Missing input: No readable source was acquired. Existing empty input: A valid source has zero rows. Malformed row: A record failed its parsing contract. Path.Combine creates a string, not a directory. Append preserves previous rows; overwrite replaces them. Using bounds the lifetime even during exception unwinding. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

File.Exists before opening is not a guarantee: another process or permissions may change. Handle the open operation according to the stated failure policy.

<!--
File.Exists before opening is not a guarantee: another process or permissions may change. Handle the open operation according to the stated failure policy. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## A writer is disposed after row three fails. Which guarantee holds?

1. Previous output is rolled back
2. The file is always complete
3. The handle is released

<!--
Poll again after the contrasting case. Answer: C. Cleanup releases the resource and may flush prior rows; it does not undo them. Atomic publication needs a separate design. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

The first imported line is malformed. What can the output contain?

<!--
Pause for a prediction before changing the input or model. Answer: An empty partial file may have been created. The failure signal still matters; empty output does not prove successful processing. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Run the section's partial-output scenario. Predict what remains after the third amount fails, then reopen the report.

[Open the lesson exercise](0902_file_operations.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: The first two accepted amounts remain; the invalid third line stops processing. The using scope releases the writer so reading or exclusive reopening can succeed. Watch for this defect: File.Exists before opening is not a guarantee: another process or permissions may change. Handle the open operation according to the stated failure policy.
-->

---

## Verify more than one example

Compare missing input with an existing empty file; test append to an empty file and failure after two accepted rows.

<!--
Use independently predicted results. Compare missing input with an existing empty file; test append to an empty file and failure after two accepted rows. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Build a path without hard-coded separators.
- Choose overwrite or append intentionally.
- Explain cleanup after an exception.

<!--
Path.Combine creates a string, not a directory. Append preserves previous rows; overwrite replaces them. Using bounds the lifetime even during exception unwinding. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->

---

<!-- _class: section -->

# Text Operations

Part 9.3 · Core reading

Computer Science in C#

<!--
This part supports the existing chapter plan: 35 minutes of selected explanation, prediction, code runs, and practice. Reading parts are not extra meetings; this chapter remains a three-meeting, 110-minute unit. A stock import accepts SKU,quantity records. A syntactically valid negative quantity still violates the business rule. Begin by asking what an acceptable result must look like.
-->

---

## Goals for this reading

- Separate splitting from validation.
- Check shape before indexing.
- Assign output values only after acceptance.

<!--
By the end of this part, students should demonstrate these actions rather than recite API names. Never index fields[1] until two fields are established. On rejection, keep output parameters at their documented empty defaults. Reuse the business case to connect each goal to an observable result.
-->

---

## Start with the business question

A stock import accepts SKU,quantity records. A syntactically valid negative quantity still violates the business rule.

<!--
Ask students to name the input, required result, and a failure that the customer would notice. A stock import accepts SKU,quantity records. A syntactically valid negative quantity still violates the business rule. Resolve that requirement before choosing an implementation.
-->

---

## Name the model

Parsing converts representation; validation decides acceptance. Check field count, required text, numeric syntax, and business range in that order.

<!--
Parsing converts representation; validation decides acceptance. Check field count, required text, numeric syntax, and business range in that order. Use the running case to separate the data, the operation, and the rule it must preserve. Ask for one concrete observation before moving to the contract.
-->

---

## State the contract

Never index fields[1] until two fields are established. On rejection, keep output parameters at their documented empty defaults.

<!--
Never index fields[1] until two fields are established. On rejection, keep output parameters at their documented empty defaults. Ask which input is accepted and which observation would expose a violation. Keep the stated domain in view during the worked example.
-->

---

## Worked example 9.3

```csharp
using System;
foreach (string line in new[] { "PEN,4", "BOOK,-2", "PEN" }) {
    string[] fields = line.Split(',');
    bool ok = fields.Length == 2 && fields[0].Trim().Length > 0
        && int.TryParse(fields[1], out int count) && count >= 0;
    Console.WriteLine(ok);
}
```

```output
True
False
False
```

<!--
Run this complete cell independently; it needs no earlier slide state. The predicted output is True; False; False. Connect each observation to the contract: Never index fields[1] until two fields are established. On rejection, keep output parameters at their documented empty defaults. If local tooling fails, use the saved output and continue the trace.
-->

---

## Trace one change at a time

| Record|Decision |
| --- | --- |
| PEN,4|Accept |
| BOOK,-2|Reject domain |
| PEN|Reject shape |
| ,3|Reject missing SKU |

<!--
Walk through the rows before executing another example. Record: Decision. PEN,4: Accept. BOOK,-2: Reject domain. PEN: Reject shape. ,3: Reject missing SKU. Ask students which state is logical and which belongs to the representation.
-->

---

<!-- _class: check -->

## TryParse accepts -2. Is the record valid?

1. Always
2. Only if the domain permits it
3. Never for any program

<!--
Allow thirty seconds for individual predictions, then compare reasons. Answer: B. Parsing recognizes an integer; the stock contract separately permits or rejects negative quantities. Use the trace to distinguish the relevant alternatives.
-->

---

## Compare the choices

| Check|Question |
| --- | --- |
| Shape|Are the required fields present? |
| Syntax|Can the number be converted? |
| Domain|Is that number allowed here? |

<!--
Check: Question. Shape: Are the required fields present?. Syntax: Can the number be converted?. Domain: Is that number allowed here?. Never index fields[1] until two fields are established. On rejection, keep output parameters at their documented empty defaults. Ask which difference changes the client result or workload rather than merely its notation.
-->

---

## A defect worth detecting

A prepared suggestion that directly calls Parse on fields[1] can fail before it checks the contract. Review it against missing, malformed, and out-of-range examples.

<!--
A prepared suggestion that directly calls Parse on fields[1] can fail before it checks the contract. Review it against missing, malformed, and out-of-range examples. Ask for an input that would distinguish the defective version from the intended contract. Do not accept compilation alone as evidence.
-->

---

<!-- _class: check -->

## What should reject output parameters contain?

1. Half-parsed values
2. The previous call's values
3. Their documented empty defaults

<!--
Poll again after the contrasting case. Answer: C. Initialize outputs, validate into local variables, then commit accepted values. This prevents a rejected record from leaking partial state. Have a student explain the rejected alternative in terms of an observable consequence.
-->

---

## Change one assumption

Add a third field to PEN,4. Is it harmless?

<!--
Pause for a prediction before changing the input or model. Answer: Not under an exactly-two-field schema. Reject the extra field rather than silently changing the format. This is a variation of the same contract, not a new required assignment.
-->

---

<!-- _class: yourturn -->

## Your turn

Complete TryReadStockLine in the section's prepared-import review. Keep the synthetic schema and predict acceptance before running.

[Open the lesson exercise](0903_text_operations.html)

<!--
Use the named existing lesson exercise; keep its current identifier and starter. Give pairs two to three minutes, then inspect one prediction and one repair. Answer: Initialize SKU to empty and quantity to zero. Require exactly two fields, trim and require SKU text, TryParse a local quantity, check its range, then assign both outputs and return true. Watch for this defect: A prepared suggestion that directly calls Parse on fields[1] can fail before it checks the contract. Review it against missing, malformed, and out-of-range examples.
-->

---

## Verify more than one example

Use missing/extra fields, blank SKU, whitespace, malformed digits, zero, and the specified quantity boundary. Do not introduce regex or general CSV quoting.

<!--
Use independently predicted results. Use missing/extra fields, blank SKU, whitespace, malformed digits, zero, and the specified quantity boundary. Do not introduce regex or general CSV quoting. Require a short account of why these cases detect a plausible defect; tests should not simply repeat the implementation's own decisions.
-->

---

<!-- _class: recap -->

## Recap

- Separate splitting from validation.
- Check shape before indexing.
- Assign output values only after acceptance.

<!--
Never index fields[1] until two fields are established. On rejection, keep output parameters at their documented empty defaults. Ask students to connect one goal to the trace and one to their exercise repair. Continue with the next reading in the existing chapter sequence; the lab and homework supply transfer beyond these selected live examples.
-->

---

<!-- _class: section -->

# Regular Expressions

Part 9.4 · Supporting / optional reference

Selected depth; no additional required meeting.

<!--
This is supporting material, not an extra required meeting or an automatic assessment prerequisite. Goal: Regex as a whole-record contract. The instructor selects its depth according to course policy and available time. Match Ticket=4821 as a complete record and extract only its four digits. Anchors constrain the whole input; a named group supplies the result.
-->

---

## Regex as a whole-record contract

Match Ticket=4821 as a complete record and extract only its four digits. Anchors constrain the whole input; a named group supplies the result.

An unanchored pattern accepts prefix Ticket=4821. Use ^Ticket=(?<id>[0-9]{4})$ and read id only after Success.

<!--
Match Ticket=4821 as a complete record and extract only its four digits. Anchors constrain the whole input; a named group supplies the result. An unanchored pattern accepts prefix Ticket=4821. Use ^Ticket=(?<id>[0-9]{4})$ and read id only after Success. Connect this extension to the core contract rather than introducing it as a prerequisite for the standard lab.
-->

---

<!-- _class: check -->

## Two quick checks

A: Does [0-9]+ mean exactly four digits?

B: Does a successful match prove the record's business meaning?

<!--
Answers: A: No, plus means one or more. B: No, syntax matching is not domain validation. Ask students to justify each answer using the stated contract. These checks are optional review, not a change to existing assessment IDs.
-->

---

<!-- _class: yourturn -->

## Your turn: selected practice

Repair the lesson's Ticket extraction exercise; reject Ticket=48x1 and prefix Ticket=4821.

[Open the supporting reading](0904_regex.html)

<!--
Use the existing exercise only if this supporting reading was selected. Answer: Anchor both ends, name the group id, and return rejected on a failed match. Expected results are 4821, rejected, rejected. Retain the original exercise identity and do not require unsupported syntax in a core assignment.
-->

---

<!-- _class: recap -->

## Reference recap

- An unanchored pattern accepts prefix Ticket=4821. Use ^Ticket=(?<id>[0-9]{4})$ and read id only after Success.
- Return to the core sequence when this reference question is resolved.

<!--
Anchor both ends, name the group id, and return rejected on a failed match. Expected results are 4821, rejected, rejected. The core chapter remains complete without an extra meeting. Keep these notes available for students taking the recommended extension route.
-->

---

<!-- _class: section -->

# Privacy and Security in Code

Part 9.5 · Supporting / optional reference

Selected depth; no additional required meeting.

<!--
This is supporting material, not an extra required meeting or an automatic assessment prerequisite. Goal: Privacy in a useful log. The instructor selects its depth according to course policy and available time. Show only the last four card digits in a synthetic support view. A useful diagnostic need not reproduce the original secret.
-->

---

## Privacy in a useful log

Show only the last four card digits in a synthetic support view. A useful diagnostic need not reproduce the original secret.

Masking changes what is displayed; it does not erase the original value or make stored data anonymous.

<!--
Show only the last four card digits in a synthetic support view. A useful diagnostic need not reproduce the original secret. Masking changes what is displayed; it does not erase the original value or make stored data anonymous. Connect this extension to the core contract rather than introducing it as a prerequisite for the standard lab.
-->

---

<!-- _class: check -->

## Two quick checks

A: Is masking the same as deleting the source?

B: Should a private support log store a password?

<!--
Answers: Both no. Control storage and access separately; logs must not collect secrets merely because they help debugging. Ask students to justify each answer using the stated contract. These checks are optional review, not a change to existing assessment IDs.
-->

---

<!-- _class: yourturn -->

## Your turn: selected practice

Complete Mask a Card Number in the optional privacy reading.

[Open the supporting reading](0905_privacy_security.html)

<!--
Use the existing exercise only if this supporting reading was selected. Answer: For 4111111111111234 return **** **** **** 1234; for a value shorter than four digits return (invalid card). Test exactly four digits too. Retain the original exercise identity and do not require unsupported syntax in a core assignment.
-->

---

<!-- _class: recap -->

## Reference recap

- Masking changes what is displayed; it does not erase the original value or make stored data anonymous.
- Return to the core sequence when this reference question is resolved.

<!--
For 4111111111111234 return **** **** **** 1234; for a value shorter than four digits return (invalid card). Test exactly four digits too. The core chapter remains complete without an extra meeting. Keep these notes available for students taking the recommended extension route.
-->
