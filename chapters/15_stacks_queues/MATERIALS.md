---
orphan: true
---

# Chapter Materials: Stacks & Queues

## Aligned Lecture Deck (2026-10-21)

Source: `_html_extra/chapters/15_stacks_queues/1500_slides.md`, using the shared thinkpress-lecture theme. One part follows each current core content notebook with explicit goals, business examples, state traces, two quick checks, an existing exercise, verification cases, and a recap. Supporting/optional readings have short labeled reference parts and add no required meetings. The chapter title notes list one-based part start slides and the existing 110-minute allocation. Every slide has instructor notes with answers; student HTML excludes them. Code examples are standalone and listed in `authoring/slide_revision/code_09_17.json` for central execution verification. Existing assessment IDs, chapter order, and lesson content are unchanged. The landing page links one student deck; instructor PPTX is generated outside published assets.

## Active Notebooks

- `1500_stacks_queues.ipynb`: orientation, measurable objectives, flow, video, and glossary.
- `1501_stack.ipynb`: LIFO contract, safe access, delimiter validation, state traces, generic array stack, invariants, and amortized growth cost.
- `1502_queue_deque.ipynb`: FIFO contract, ring wraparound/full/empty traces, bounded generic ring queue, linked endpoints, logical-order growth, and deque tradeoffs.
- `1503_applications_lab.ipynb`: access policies, backtracking, queue discovery, actual undo/redo snapshots, starvation, qualified costs, and contract tests.
- `assignments/preview.ipynb`: ten concept checks, including full/empty ring-buffer state.
- `assignments/lab.ipynb`: five connected service-desk tasks with independent starters, traces, boundary checks, and restoration-policy reasoning.
- `assignments/homework.ipynb`: five true/false questions and five independent coding tasks for safe peek, ring growth, nesting, redo invalidation, and urgent-service limits.

## Runnable Materials

- `demos/15_stacks_queues/ServiceDeskStructures.cs`: implementations and 600 seeded reference-model operation checks, with boundary/reuse tests.
- `demos/15_stacks_queues/README.md`: local console-project instructions and expected output.

## Verification and Remaining Work

All 29 completed notebook code cells compiled and ran independently. The ten assignment solutions and three content-exercise solutions retain verified output. The source-material checks passed. The full HTML build succeeded with five pre-existing warnings outside Chapter 15. Six browser Run checks passed through the hosted runner: stack growth, ring wraparound, linked singleton reuse, undo/redo, lab contract tests, and bounded urgent scheduling. The downloadable source link resolves. Lecture decks are pending; the missing overview link has been replaced with an explicit pending notice. Existing video retained.

## Coverage Boundary

The stack is growable and does not shrink; the ring queue has a fixed positive capacity and rejects overflow. Ring growth and deque formulas are taught with traces; production iterator invalidation, concurrency, blocking producers, and priority queues are outside this implementation pass. Delimiter validation examines characters only, without parsing source-language strings or comments. Graph traversal correctness receives fuller treatment in later graph chapters.

## Section-Boundary Coverage Disposition (2026-10-17)

**Reviewed plan, now implemented:** Retain; organize queue complexity internally. The disposition below records the preimplementation baseline and rationale. See Implemented Reading Organization for the current reading files. Counts in this baseline exclude fenced code from prose; the refreshed inventory is in authoring/content_size/. They flag review needs, not quality scores.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `1501_stack.ipynb`: Stacks | Core content | 889 | 23 | 7 |
| `1502_queue_deque.ipynb`: Queues and Deques | Core content | 995 | 25 | 8 |
| `1503_applications_lab.ipynb`: Applications Lab | Core content | 889 | 23 | 7 |

### Source-to-Destination Plan

| Existing source | Proposed treatment and coverage to preserve |
| --- | --- |
| `1501` | Retain stack contracts, implementation and delimiter reasoning. |
| `1502` | Use internal subsections to distinguish queue contract, ring representation, wraparound/growth and deque contrast. If future full deque implementation becomes required, reassess a separate page then. |
| `1503` | Retain undo/redo, discovery/fairness and verification instruction as content; a future title such as Access Policies and Applications avoids confusing it with assignments/lab. |

### Development Needed Before Moving Material

Develop ring-state traces and the relationship between logical and physical order. Do not combine stacks and queues merely because both restrict access.

Before a later move, create a cell-level preservation map for these sources, including citations, figures, original code forms, worked traces, guided questions and independent exercise variants. Relocate prerequisite explanations from assignments into content when needed while retaining application requirements and IDs. A consolidated page must still teach its concepts; a split must not create two unsupported outlines. Existing runnable verification records describe earlier work, not verification of this proposal.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `1501_stack.ipynb`: Stacks.
- `1502_queue_deque.ipynb`: Queues and Deques.
- `1503_applications_lab.ipynb`: Access Policies and Applications.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.

## Guided Practice Pass (2026-10-18)

Pass 4 of the content-development audit (`authoring/content_development_audit/`): added mid-page guided practices with solutions to 15.1 (undo past the beginning with TryPop) and 15.3 (visit pages in arrival order), and task text with expected output above the previously code-only Exercise cells of 15.1, 15.2, and 15.3. Every new starter and solution compiles and runs standalone (.NET 10); starters that are meant to fail say so in their task text. No existing cell, heading, or exercise ID was removed.

## OpenDSA References (2026-10-19)

Re-hosted the existing OpenDSA "Further reading" footnote links to `opendsa-server.cs.vt.edu` CS2/CS3 pages, because `opendsa.org`, `opendsa.cs.vt.edu`, and `opendsax.cs.vt.edu` either fail strict fetches or are not the host this book links to. The roles of the OpenDSA books are recorded in `authoring/toc_comparison/README.md` (OpenDSA mapping) and Appendix A. Chapter 15: the 15.2 footnote now points to CS2 6.1 Stacks.

## OpenDSA Gap List and Development (2026-10-19)

Pass 8 (`authoring/content_development_audit/pass8_cs2_opendsa_development.md`) compared the three sections with OpenDSA CS2 6.1 Stacks, 6.2 Linked Stacks (with the array-versus-linked comparison), 9.1 Queues (array-based and circular queues), 9.2 Linked Queues, the Stack and Queue Summary Questions, and CS3 5.11 Implementing Recursion. Concepts, explanations, and exercise types OpenDSA has that this chapter lacked or treated in under 100 words:

| Gap | OpenDSA treatment | Where it is now developed |
| --- | --- | --- |
| Linked stack implementation and the array-versus-linked stack comparison, including two stacks sharing one array | 6.2 | 15.1 Stack Implementation Choices (was 86 words; runnable `LinkedIntStack`, comparison table) |
| Queue vocabulary and why restricted access is the point | 9.1 terminology | 15.2 Queue Behavior (was 89 words) |
| Worklist loop shape and layer property | 9.1 | 15.2 Worklists and Scheduling (was 57 words) |
| The drifting array queue and why indexes wrap | 9.1.1 Array-Based Queues | 15.2 Ring Buffers (was 94 words) |
| Pigeonhole argument that front and back alone cannot distinguish full from empty, and the two repairs | 9.1.2 The Circular Queue | 15.2 Why Front and Back Alone Cannot Tell Full from Empty (new) |
| Deque operation pairs and the stack/queue special cases | 9.1, 9.2 | 15.2 Deques (was 92 words) |
| Output interpretation of the bounded ring example | 9.1.3 | 15.2 A Complete Bounded Generic Queue (new interpretation cell) |
| Backtracking as advance, fail, resume | 6.1 applications | 15.3 Backtracking with a Stack (was 58 words) |
| A stack replaces the call stack; recursion as a stack algorithm | CS3 5.11 Implementing Recursion | 15.3 A Stack Can Replace the Call Stack (new, bill-of-materials example) |
| Reading the cost table as what each structure gave up | 9.2 comparison | 15.3 Comparing Costs (expanded) |
| Exercise types: array-based dequeue practice (code completion), stack and queue tracing, summary questions | 9.1.2 Array-based Dequeue Practice, 9.2.3.1 Summary Questions | Listed below |

Exercises added: code tracing (15.1 The Stack While Matching, 15.2 Ring State After Each Operation, 15.3 Undo and Redo Histories), code completion (15.2 Dequeue from a Ring), and a Check Your Understanding block of four questions on each page. Every new code cell was compiled and run standalone under .NET 10 and carries its stored output. No existing cell, heading, exercise ID, or footnote was removed; no OpenDSA text, code, or figure was copied.

## Demo folder rename (2026-10-19)

The chapter's demo source moved from the former two-digit folder `15/` to `demos/15_stacks_queues/`, the same folder name as this chapter, so a cloned repository opened in VS Code shows the book's chapter names. The notebook download and link paths in this chapter were updated to the new folder; no cell content, heading, cell id, or exercise ID changed.
