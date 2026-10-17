---
orphan: true
---

# Chapter Materials: Computing, Programs, and Responsibility

## Core Sections

- `0101_cs_ideas.ipynb`: computing, hardware/software/data, IPO, algorithms/workflow, compilation, sequential execution, and correctness.
- `0102_computing_responsibility.ipynb`: stakeholders and harm, correctness and fairness, privacy/security, accessibility, attribution/accountability, and AI literacy, developed through explained business examples. No coding activity is assigned in this conceptual section.
- `0103_program_structure.ipynb`: first saved console project and basic syntax: statements/expressions, literals/interpolation, identifiers/keywords/case, method calls/arguments/return values, blocks/formatting/comments, compiler diagnostics, and recognition of top-level statements. Connected order-desk predict/run/modify/repair exercises use no variables or input.

## Assignments

Preview has ten vocabulary MCQs. Lab builds a fictional reminder in five standalone stages, then applies the existing saved-project workflow. Homework has five applied true/false cases and five simple output programs. The coding tasks need no variables, decisions, loops, or user-defined methods.

## Resources and Boundaries

Source demonstration: `demos/01/hello_world/`. Setup lives in `chapters/appendices/development_tools/csharp_setup.ipynb`, under Appendix B. The existing setup video moves there unchanged. Git and detailed professional practice are in Appendix C. Optional software-failure cases are in Chapter 6; optional privacy/security practice and the former ethics assessments are in Chapter 9. Their original identifiers remain unchanged.

A recording and slide deck for the revised Chapter 1 remain pending. The prior overview deck remains at its published URL for compatibility but is not presented as the revised chapter deck.

## AI Literacy Integration (2026-10-15)

Core AI literacy in 1.2 distinguishes generative AI, LLMs, prompts, coding assistance, and verified behavior. Students predict, ask focused questions when permitted, check suggestions, use synthetic data, and record assistance. It does not require live AI access.

## Basic Syntax Revision (2026-10-15)

Section 1.3 uses a connected Northwind order-desk message with predict/run, modify, and repair exercises. Eleven standalone code cells compile and produce verified output; the intentionally broken repair starter reproduces CS1002, then CS0103 after the semicolon is fixed. Demonstrations and hidden solutions retain executed output. Assessment IDs and the section URL remain unchanged.

## Keyword Placement (2026-10-15)

The basic reserved-keyword explanation and collapsed list live in Section 1.3. Section 2.1 retains a linked optional note on escaped identifiers and contextual keywords, with a standalone shipment example using meaningful `itemCount` instead of `var var`. The existing `keywords-section` anchor remains in 2.1.


## Understanding Checks (2026-10-15)

The five short conceptual prompts in Sections 1.1 and 1.2 use the label “Check Your Understanding.” Each has a separate, initially collapsed Suggested Answer with a possible response and its reasoning. These are ungraded self-checks, distinct from coding exercises and submitted assignments. Section 1.1 references its existing workflow footnote in the development-process discussion.


## Responsibility Section Expansion (2026-10-15)

Section 1.2 is approximately 2,900 words including tables and source notes. Removed the responsible-reminder coding exercise, its starter/solution/output, the earlier code demonstration, and the dependent AI prompt practice. Six substantive topics use bookstore reports, payroll, discounts, order status, and source-use examples. Two short conceptual understanding checks retain collapsed suggested answers. No live AI use, C# syntax, or legal analysis is required. Source notes link ACM ethics, W3C accessibility guidance, and CS2023 AI education.


## Restored CS1 Teaching Content (2026-10-17)

Author-requested additive merge from the standalone restored CS1 reference. Existing lessons, responsibility/AI material, assignments, and assessment IDs remain. Setup and Git stay in Appendices B and C. Restored concepts are reading and practice within the current three-section sequence, not extra required meetings.

Section 1.1 regains IPO/storage/feedback diagrams, the explicit seven development activities, binary/ASCII place-value work, byte capacity and qualified address-width explanation, compiler/interpreter figures, and IL/JIT/CLR/BCL explanation. Historical blanket language classifications and memory-limit claims are corrected. Section 1.3 adds template/project/solution organization; Appendix B holds the multi-project command reference. Suggested answers accompany the new conceptual checks. Existing first-program and responsibility activities are retained.

Use the restored diagrams/place-value walkthrough within meeting one (35 minutes), responsibility as planned (35), and first-program work in meeting three (40); additional platform/project detail is reference reading. Total guided time remains 110 minutes. The archived diagrams retain their source attribution.

Verification: all 13 restored code cells compiled independently as .NET 10 console programs with nullable checks and warnings treated as errors; completed cells retain executed output. Checked alternative trace inputs, zero/exact/proper-fraction division cases, and timestamp second/parity boundaries against independent arithmetic/date calculations. The eight template/solution/project commands were verified in a temporary workspace. Full Jupyter Book build passes with existing lexer warnings in the unchanged character/nullability examples. All original Chapter 1–2 cells, code, outputs, and standard-assignment IDs remain.
