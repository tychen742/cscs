# Chapter 10: Classes and Objects Assignments

The standard assignments assess one class at a time. The coffee-register lab moves through procedural accumulation, instance storage, a validated property, shared receipt numbering, and a text report. Each cell starts a fresh process, including the static receipt counter. Do not require prior browser runs.

The lab assumes valid prices, quantities, and tax rates. Tax is rounded once per receipt with the default midpoint-to-even rule. Receipt identifiers are unique only within one run; this is not a production checkout system. Stage five should report Front at $32.04, Drive-thru at $15.28, and the store at $47.32.

The downloadable `demos/10/coffee_register_starter/` matches stage five. Students complete ToString there; the preceding lab stages remain notebook exercises. The existing animal/guessing-game project in `classes_lab/` is supplementary, not the solution to this lab.

Homework transfers the chapter skills:

| Question | Evidence to inspect |
| --- | --- |
| Supplier | Trim a valid name; reject null, empty, and whitespace-only names. |
| Stock bin | Reject nonpositive and excessive withdrawals before mutation; allow exact depletion. |
| Invoice | Calculate from current properties, including revised and zero hours; avoid a redundant stored total. |
| Ticket | Use one static counter while preserving each ticket's instance number and department. |
| Purchase order | Report current instance state through ToString; changing one independently constructed order leaves the other unchanged. |

The true/false balance is three true and two false. Discuss why an exception does not roll back prior assignments and why per-branch balances should not be static. Preview contains ten vocabulary questions, with one correct answer each.

Canonical solutions are the five hide-input code cells in each standard coding assignment. Their saved stdout is the expected output. Existing Homework assignment and exercise identifiers are preserved. This revision introduces no course registration or grading-service configuration.

Book List remains optional legacy practice after Chapter 11. Its collection-owning class, equality extension, and file loading are beyond this pass; a complete reference solution is not claimed.
