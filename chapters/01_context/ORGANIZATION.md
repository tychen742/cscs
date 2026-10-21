---
orphan: true
---

# Organization: Computing, Programs, and Responsibility

## Current Lecture Deck (2026-10-21)

The revised chapter deck is `_html_extra/chapters/01_context/0100_slides.md`. It follows the current reading order with a named part per reading, worked examples and state traces, quick checks, existing exercise links, and instructor notes. Meeting 1: 1.1, 35 minutes; meeting 2: 1.2, 35 minutes; meeting 3: 1.3, 40 minutes. Total 110 minutes. Platform details remain reference reading. Reading pages do not add meetings. Optional supporting parts remain unassessed. The chapter landing links the student HTML deck; the former overview remains unchanged for compatibility. Code verification is recorded with `authoring/slide_revision/code_01_08.json`; final render/build evidence is recorded by the shared slide workflow. Assessment identities and assignment notebooks are unchanged.

## Current Integrated Arrangement (2026-10-17)

This is the current reading order and coverage. Earlier arrangement/count records below remain historical where they conflict.

| Current reading file | Instructional role/title | Status |
| --- | --- | --- |
| `0101_cs_ideas.ipynb` | Computing and Problem Solving | Core content |
| `0102_computing_responsibility.ipynb` | Computing and Professional Responsibility | Core content |
| `0103_program_structure.ipynb` | Your First C# Program and Basic Syntax | Core content |

Keep the current section boundaries and recently developed content. Consolidate repeated in-page navigation, distinguish repeated practice headings, retain all substantive explanations/examples and finish the instructional material before the final Footnotes group.

Teach the section conceptual framework before detailed application; place syntax prerequisites before reasoning that requires them. Keep the new worked traces and guided checkpoints, followed by existing lab/homework transfer. Reading count does not set a meeting or word quota.

Each content page has one local contents directive and one final Footnotes group. Retained reference details receive useful headings rather than obsolete page titles or provenance notices.


## Class Meetings

1. Computing and Problem Solving, 30 minutes: hardware/software/data, IPO, precise procedures, workflow, compilation/runtime, and simple sequential output.
2. Computing and Professional Responsibility, 35 minutes: explain how software affects stakeholders; distinguish execution, data quality, business rules, and fairness; introduce privacy/security, accessibility, attribution/accountability, and AI literacy with worked business examples.
3. Your First C# Program and Basic Syntax, 45 minutes: create and edit a console project (10 minutes), read statements, expressions, names, and method calls (15 minutes), and predict/run/modify/repair an order-desk message (20 minutes). Recognize Main and project files without requiring full understanding of their declarations.

Total: 110 minutes including examples and practice. Appendix B setup is preparation before the saved-project meeting, not a separate content section. Browser examples can support the initial encounter while a local environment is prepared. The first program and edit/build/run workflow remain in the chapter.

## Assessment and Scope

Preview checks vocabulary from all three sections. The connected Lab produces a fictional reminder with clear, restrained output and a local project handoff. Homework applies the ideas to new business messages. Core assignments use Console.WriteLine and comments. Section 1.3 adds literal expressions, simple interpolation, and recognition of a returned value without requiring variables or input; those follow in Chapter 2. Existing Chapter 1 cell IDs are retained where content is replaced, and new coding questions receive semantic exercise IDs.

Ethical analysis is introduced here and revisited with testing (Chapter 6), privacy/text processing (Chapter 9), professional collaboration (Appendix C), and database parameters (database appendix). Original ethics assessment identifiers remain stable in optional privacy practice. A full ethics course's coverage/contact hours are not claimed.

## AI Literacy Integration (2026-10-15)

Core AI literacy in 1.2 distinguishes generative AI, LLMs, prompts, coding assistance, and verified behavior. Students predict, ask focused questions when permitted, check suggestions, use synthetic data, and record assistance. It does not require live AI access.

## Keyword Progression (2026-10-15)

Section 1.3 introduces reserved keywords and provides the collapsed list. Section 2.1 links back and treats escaped identifiers and contextual keywords as optional reading after variables and type inference.


## Understanding Checks (2026-10-15)

The five short conceptual prompts in Sections 1.1 and 1.2 use the label “Check Your Understanding.” Each has a separate, initially collapsed Suggested Answer with a possible response and its reasoning. These are ungraded self-checks, distinct from coding exercises and submitted assignments. Section 1.1 references its existing workflow footnote in the development-process discussion.


## Section 1.2 Teaching Sequence (2026-10-15)

- Stakeholders and consequences, five minutes: follow a bookstore report through to a decision affecting a customer.
- Correctness, data quality, and fairness, seven minutes: contrast a discount boundary, missing payroll data, and a smartphone-only correction route.
- Privacy and security, six minutes: explain the information needs of reports, exports, and diagnostic records.
- Accessibility and communication, six minutes: examine color-only stock status and truthful order messages.
- Attribution and accountability, five minutes: distinguish credit, reuse permission, and evidence supporting a claim.
- AI literacy, six minutes: define the tools, explain a requirement mismatch, and connect permitted assistance to independent understanding.

Total: 35 minutes, with the two conceptual checks included in discussion. The reading develops explanations that can be prepared before class. Removed the reminder coding practice and dependent AI prompt activity rather than moving them elsewhere. Section 1.2 has no coding requirement; syntax and coding practice begin in Section 1.3. Later chapters revisit responsibility with records, methods, tests, and text processing.

## Reliability Progression (2026-10-16)

Read diagnostics and compare expected and actual output in the first-program workflow; do not require test frameworks or exception syntax. This is the current teaching plan; this structural pass does not claim a new practice or assessment implementation.


## Restored CS1 Teaching Content (2026-10-17)

Author-requested additive merge from the standalone restored CS1 reference. Existing lessons, responsibility/AI material, assignments, and assessment IDs remain. Setup and Git stay in Appendices B and C. Restored concepts are reading and practice within the current three-section sequence, not extra required meetings.

Section 1.1 regains IPO/storage/feedback diagrams, the explicit seven development activities, binary/ASCII place-value work, byte capacity and qualified address-width explanation, compiler/interpreter figures, and IL/JIT/CLR/BCL explanation. Historical blanket language classifications and memory-limit claims are corrected. Section 1.3 adds template/project/solution organization; Appendix B holds the multi-project command reference. Suggested answers accompany the new conceptual checks. Existing first-program and responsibility activities are retained.

Use the restored diagrams/place-value walkthrough within meeting one (35 minutes), responsibility as planned (35), and first-program work in meeting three (40); additional platform/project detail is reference reading. Total guided time remains 110 minutes. The archived diagrams retain their source attribution.

## CS1 Preservation Follow-up (2026-10-17)

Original seven-question conceptual review and mathematics/engineering/empirical CS-thinking discussion restored. Existing responsibility/output assignments remain; Extra Practice adds the original open-ended questions with corrected implementation/address-space premises.

## Section-Boundary Review (2026-10-17)

**Status: implemented.** The following records the reviewed recommendation and its baseline. See Implemented Reading Organization below for the final current filenames and order; earlier meeting allocations are historical where they conflict.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `0101_cs_ideas.ipynb`: Computing and Problem Solving | Core content | 2,319 | 27 | 1 |
| `0102_computing_responsibility.ipynb`: Computing and Professional Responsibility | Core content | 2,796 | 21 | 0 |
| `0103_program_structure.ipynb`: Your First C# Program and Basic Syntax | Core content | 2,489 | 47 | 12 |

**Recommendation:** Retain; clarify internal reading levels.

The three pages answer different questions: how computing solves problems, what responsible decisions require, and how to run/read a program. Word count alone does not justify combining them.

### Proposed Reading Sequence

1. Computing and problem solving.
2. Computing and professional responsibility.
3. First program and basic syntax.

### Adequacy Before Reorganization

Strengthen transitions between development workflow and the first program; use a visible reading path rather than creating separate pages for every platform detail.

Reading sections and class meetings are different units; allocate discussion and practice after developing adequate explanations. Do not reduce distinct material to meet a section or word quota.

Preserve every existing explanation, exercise variation and assessment identity. The source-to-destination dispositions in MATERIALS.md govern any later move. Update TOC, links and redirects only in an authorized implementation pass.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `0101_cs_ideas.ipynb`: Computing and Problem Solving.
- `0102_computing_responsibility.ipynb`: Computing and Professional Responsibility.
- `0103_program_structure.ipynb`: Your First C# Program and Basic Syntax.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.

## Guided Practice Pass (2026-10-18)

Pass 4 of the content-development audit (`authoring/content_development_audit/`): added mid-page reflection questions to 1.1 (describe a system you use) and 1.2 (map the stakeholders of one feature), the first practice prompts on those conceptual pages. Every new starter and solution compiles and runs standalone (.NET 10); starters that are meant to fail say so in their task text. No existing cell, heading, or exercise ID was removed.
