# Chapter 2 Assessment Alignment

The three sections introduce variables/types, operators/library methods, and input/output. Assess sequential code and method calls here; defining methods belongs to Chapter 5. The assessment revision leaves the content notebooks unchanged.

| Section | Lab evidence | Homework evidence |
| --- | --- | --- |
| 2.1 Variables and types | Order declarations, decimal money, int quantities, bool eligibility, explicit cast. | Copied integer target case, fractional workload average. |
| 2.2 Operators and built-in methods | Store Math.Round results, use Ceiling on fractional division, Trim and Parse. | Math.Max shortfall, comparison and conjunction, Trim/ToUpper return values, Math.Round/Math.Abs report. |
| 2.3 Input and output | Quantity input, final three-line input invoice, composite formatting and aligned interpolation. | Three parsed expense amounts and labeled formatted reports. |

Preview contains ten vocabulary MCQs. Homework has five concept cases (two true, three false) and five coding tasks. Each program includes its own declarations and imports. No array, loop, user-defined method, custom class, or exception handler is required.

The lab's monetary policy rounds the discount to cents, subtracts it, rounds tax on that discounted amount, then adds the rounded tax. Math.Round uses midpoint-to-even by default. F2 changes the display, not stored data. The sample final total is 469.62; a 1.25 unit price yields 15.25. Explain why calling Round without using its return value does not update a variable.

For packing, integer division gives full boxes, remainder gives leftover cases, and Ceiling of a fractional quotient gives all required boxes. Converting after integer division cannot recover a lost fraction. Boundary quantities 0, 5, 10, and 12 need 0, 1, 2, and 3 boxes. The supplied capacity is positive.

Input tasks assume valid, in-range numeric text. They use ReadLine with an empty-text fallback for end-of-input; that fallback is not validation. Numeric parsing/formatting follows the environment's culture, and saved output uses a period decimal separator. Browser capture does not echo typed input; explicit newlines keep the saved prompts readable. Students type the sample values into the input fields or local terminal.

Canonical answers are the five hidden code cells in each Lab/Homework notebook. The starter at `demos/02_var_data/order_invoice_starter/` matches only final Lab stage five. Existing input/output demonstrations remain supporting examples rather than lab solution projects. The retired unstructured homework prompts are recoverable from Git history.
