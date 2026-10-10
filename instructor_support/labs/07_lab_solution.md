# Instructor Solution Walkthrough: Privacy Pass

**Exact assignment:** [Chapter 7 sign-up lab](../../chapters/07_society_ethics/assignments/lab.ipynb), Tasks 1-5 and its two reflection questions.

**Combined code reference:** [privacy_pass_lab_solution.cs](../../demos/07/privacy_pass_lab_solution.cs).

From the repository root:

```bash
dotnet run --project demos/07/privacy_pass_lab_solution.csproj
```

## Explain and Assess the Tasks

| Task | Reasoning | Assessment checkpoint |
| --- | --- | --- |
| 1: Validate email | Check one @, a nonempty prefix, a later dot, and no spaces. | All five provided examples match the specified Boolean results. This is a simplified task-specific check, not proof that an address can receive mail. |
| 2: Mask email | Validate first, retain the initial and domain, and substitute three asterisks. | Invalid input produces the invalid marker; neither example reveals the complete original address. |
| 3: Mask phone | Collect digits, require ten, and retain only the final four. | Formatting punctuation does not change the result; seven digits produce the invalid marker. |
| 4: Check age | TryParse separates nonnumeric input from the inclusive range check. | Check ages 18 and 120 as accepted boundaries; 17 and 121 are rejected. Reasons do not echo the supplied input. |
| 5: Log sign-up | Reject invalid email/age; otherwise compose masked values. | Logs omit the name, full email, full phone, and age. The reference returns an invalid-phone marker rather than rejecting it; that follows the task's stated rejection rules. |

Each student notebook cell must contain the helpers it calls so it works alone.
The combined reference demonstrates all tasks together; it does not replace the
lab's cell-by-cell submission requirements. Accept equivalent correct code;
no point weights are prescribed here.

## Reflection Guidance

Customers benefit from reduced exposure of personal information. Support staff
and developers retain enough diagnostic information to investigate issues, and
the organization reduces unnecessary collection in its logs. Look for an
explanation of this balance rather than a list of stakeholders alone.

The email check catches obvious typing errors before further work. A real
service would separately verify control of the address, for example through a
confirmation message; a syntactically plausible string is not proof of ownership
or deliverability. Masked data can still identify people in context, so do not
teach this exercise as a claim of complete anonymization.

## Common Mistakes

Avoid logging raw input in an error message, accepting the placeholder helper
unchanged, or calling Substring before validating its required indexes. Do not
change the stated age bounds or add unstated task requirements when grading.

## Verified Output

```text
True
False
False
False
False
a***@example.com
b***@example.com
(invalid email)
***-***-0142
***-***-0199
(invalid phone)
ok
age must be from 18 to 120
age must be a whole number
age must be from 18 to 120
ACCEPTED: a***@example.com ***-***-0142
REJECTED: invalid email
REJECTED: age must be from 18 to 120
```
