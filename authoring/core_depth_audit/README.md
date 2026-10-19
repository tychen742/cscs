# Core B-A Depth and Organization Audit

Date: 2026-10-19. Source revision: `a4bbbd4258c861f36827c60f7dd94dad01505467`. Report only; chapter notebooks, TOC, assignments and optional readings are unchanged.

Core content only; assignments and optional/supporting readings excluded. Guided practice inside core pages is included. Opening context and parent/child development are read together. Footnotes excluded from subsection screening; prior published counts include them and are triage only. Short blocks were reviewed in context; a numerical threshold is not a verdict.

Inventory of all 84 core pages and their heading hierarchy, followed by contextual reading of flagged passages, ancestors, neighboring sections, examples and local practice. This is a depth/organization audit, not certification of every code cell, factual claim or index entry.

The reusable procedure is [the shared B-A core-content audit plan](/Users/tcn85/ai_shared/prompts/audit-content.md), linked from the book-authoring skill. The older B-A and content-development reports describe historical findings; this pass confirms current evidence rather than repeating those findings.

## Main conclusion

Prioritize local prerequisite order and uneven subsection development, not equal chapter lengths. The strongest immediate repairs are the debugger prerequisite sequence (C05) and text-parsing reasoning/validation trace (C08). Most other findings call for reorganizing existing material or adding one precise worked step. No core chapter is classified as a stub.

The earlier broad suggestion to trim Trees or expand every short chapter is not supported by this narrower audit. The recent algorithm development contains useful traces, invariant arguments, completion exercises and feedback that should remain. Chapter 3 already has a service decision table and boundary practice; Chapter 2 already explains short-circuit evaluation. Chapter 12 already teaches concrete dispatch, interface composition and test doubles.

## Findings

### C01: Should fix / Expand and integrate

Chapter 2; **The `var` Keyword**. Source: [0201_variables_types.ipynb](/Users/tcn85/workspace/cscs/chapters/02_var_data/0201_variables_types.ipynb), stable heading cell `4db14fad`.

**Already adequate:** The declaration examples establish that the compiler infers a type.

**Finding:** The 38-word subsection does not make the inferred type versus later reassignment distinction explicit.

**Proposed change:** Add an annotated initializer-to-inferred-type trace and a predict/explain check contrasting a valid reassignment with assigning a different type. Do not introduce dynamic typing as a new topic.

### C02: Should fix / Reorganize and explain

Chapter 2; **Operation Examples**. Source: [0202_operators_built_in_methods.ipynb](/Users/tcn85/workspace/cscs/chapters/02_var_data/0202_operators_built_in_methods.ipynb), stable heading cell `66d12086`.

**Already adequate:** Operator definitions, category tables, runnable examples, comments, and short-circuit rules already exist.

**Finding:** Definitions and examples are separated. Arithmetic, Comparison, and Logical demonstration blocks have only 7-9 prose words around code; the broader surrounding explanation does not interpret these particular results.

**Proposed change:** Pair each essential category with its existing worked cell, interpret selected intermediate values and results, and add one bounded prediction. Keep the comprehensive table as a later reference within the lesson. No exercise quota per operator.

### C03: Should fix / Reorganize and add local practice

Chapter 3; **Compare Ways to Express the Same Decision**. Source: [0302_ifstatement.ipynb](/Users/tcn85/workspace/cscs/chapters/03_decision/0302_ifstatement.ipynb), stable heading cell `4a5faf67`.

**Already adequate:** The service-code decision table, switch example, invalid-case explanation, and guided variation are useful.

**Finding:** The lesson compares if/else-if and switch before the later sections develop the basic selection forms. Local practice is weighted toward modifying supplied examples rather than choosing and tracing branches.

**Proposed change:** Keep the business problem/table as framing. Develop if, if/else, else-if, nesting and switch, then use the existing cross-form comparison as synthesis. Add a first-match-versus-independent-if trace and a boundary/invalid-case completion. Chapter 2 already explains short-circuit evaluation; reuse it rather than claiming it is absent.

### C04: Should fix / Reorganize

Chapter 5; **Connect Calls, Definitions, and Program Forms**. Source: [0501_intro_methods.ipynb](/Users/tcn85/workspace/cscs/chapters/05_methods/0501_intro_methods.ipynb), stable heading cell `5275fbe6`.

**Already adequate:** The page has a conceptual motivation, program-form comparison, method definitions/signatures, call flow, and guided practice.

**Finding:** One subsection spans roughly 2,460 inclusive prose words. Its direct text repeats reasons for methods and terminology before separate definition, signature, and execution-flow children; top-level and class-based forms compete for attention.

**Proposed change:** Use one task and top-level helper as the main sequence: definition, call, arguments/parameters, execution/return. Group the retained class-member/Main forms as clearly bounded project comparison after that sequence. Preserve the distinct examples and traces.

### C05: Must fix / Reorganize prerequisites

Chapter 6; **Step 2: Minimize the Failing Case**. Source: [0602_debugging_workflow.ipynb](/Users/tcn85/workspace/cscs/chapters/06_exceptions_testing/0602_debugging_workflow.ipynb), stable heading cell `b1224fc3`.

**Already adequate:** The later Credits example supplies a complete familiar-loop investigation, expected result, breakpoint trace, repair and regression checks.

**Finding:** The first detailed workflow example uses scores arrays before arrays are taught in Chapter 7. The familiar-loop treatment appears later, despite describing itself as preparation before array applications.

**Proposed change:** Move the familiar-loop investigation into the first workflow demonstration and map the workflow steps onto it. Retain the array/CSV transfers after it with explicit later-prerequisite labels; do not count them as needed to understand the core debugger process. Correct the ambiguous retained loop comment during an authorized repair.

### C06: Should fix / Reorganize

Chapter 7; **Parameters to Main**. Source: [0703_array_processing.ipynb](/Users/tcn85/workspace/cscs/chapters/07_arrays/0703_array_processing.ipynb), stable heading cell `807480fa`.

**Already adequate:** Array parameter behavior, command-line arguments and aliases all have developed explanations.

**Finding:** The Parameters to Main/Command Line Adder group occupies about 896 inclusive words between passing-array instruction and References and Aliases. This interrupts the parameter/sharing conceptual dependency.

**Proposed change:** Teach traversal, passing arrays, reference copying/aliasing and mutation together. Put the command-line application after that complete sequence, with a transition showing it applies the same array model. Preserve its project workflow and examples.

### C07: Should fix / Reorganize

Chapter 8; **Similar Operations, Different Methods**. Source: [0804_collection_operations.ipynb](/Users/tcn85/workspace/cscs/chapters/08_collections/0804_collection_operations.ipynb), stable heading cell `4306eac8`.

**Already adequate:** The family map and operations tables explain meaningful differences; list/dictionary lessons develop the main APIs.

**Finding:** The 4,019-word operations page presents a long general/namespace/table sequence before the family-specific examples, then revisits related families. Its length is largely sequencing and reference breadth, not a missing-concept problem.

**Proposed change:** Retain a compact conceptual map first. Pair the shared put/inspect/remove rules with an early concrete list/dictionary comparison, then attach each existing family example to the relevant table row. Keep later-family recognition distinct from the current implementation focus, without silently changing core prerequisites.

### C08: Must fix / Correct and expand worked reasoning

Chapter 9; **Splitting and Tokenizing / Token Validation**. Source: [0903_text_operations.ipynb](/Users/tcn85/workspace/cscs/chapters/09_files_text/0903_text_operations.ipynb), stable heading cell `647294e5`.

**Already adequate:** The split/trim examples, missing-field warning and later Structured Lines parser are substantive.

**Finding:** The text incorrectly says int.TryParse would fail for " 98 " until trimmed. The Token Validation subsection has 11 prose words and a valid-record-only cell, which never enters its rejection branch.

**Proposed change:** Correct the whitespace explanation and distinguish normalization, field count, numeric parsing and domain validation. Add a short accepted/rejected record trace, including missing and extra fields; connect it to the existing parser instead of adding another full implementation. Verified locally: int.TryParse(" 98 ", out int score) returns true with 98 on .NET 10.

### C09: Should fix / Expand locally

Chapter 10; **Tuples: When a Class Is Too Much**. Source: [1001_class_syntax.ipynb](/Users/tcn85/workspace/cscs/chapters/10_classes/1001_class_syntax.ipynb), stable heading cell `f1bcb96f`.

**Already adequate:** Tuple syntax, creation, returns, deconstruction/discards, collections and a tuple/class comparison already exist.

**Finding:** Four child topics have 22-41 prose words before their runnable examples and no following prose interpretation. The SalesRange example indexes element zero without stating a nonempty-input contract.

**Proposed change:** Explain how a returned tuple maps into named fields and deconstructed variables, interpret one transcript, state the nonempty-array assumption or a chosen empty policy, and add one bounded completion with feedback. Preserve tuples as the bridge used by later examples.

### C10: Should fix / Expand one worked representation

Chapter 11; **Copies Need a Depth Policy**. Source: [1101_objects_references.ipynb](/Users/tcn85/workspace/cscs/chapters/11_object_design/1101_objects_references.ipynb), stable heading cell `f7152d161384`.

**Already adequate:** Identity, assignment, mutability and copy-depth policy are explicitly explained. The following records page correctly warns that with is shallow.

**Finding:** The copy-depth subsection explains an order/product graph verbally but does not work through the nested-sharing case as an actual object diagram or before/after trace.

**Proposed change:** Add one small shared-product/two-orders diagram and a table of which observations change after a nested mutation or shallow copy. Reuse it from the records and composition pages; no new full program or blanket chapter expansion is needed.

### C11: Could defer / Expand one local trace

Chapter 12; **Virtual Calls Select an Override**. Source: [1202_polymorphism.ipynb](/Users/tcn85/workspace/cscs/chapters/12_oop/1202_polymorphism.ipynb), stable heading cell `0abd920f4094`.

**Already adequate:** The core already has concrete overrides, predicted numeric output, constructor examples, interfaces, test doubles and local exercises.

**Finding:** The declared-type/runtime-type distinction is explained mostly in prose. The local final practice checks result bounds using already-supplied overrides rather than requiring the learner to follow dispatch choices.

**Proposed change:** Add a small declared type / actual object / selected member / base call / result table and a prediction before revealing it. Keep the three core readings; low total words alone do not justify a broad expansion or importing optional hiding examples.

### C12: Should fix / Expand a prerequisite bridge and clarify organization

Chapter 13; **Reading Short Expressions and Queries**. Source: [1303_generics.ipynb](/Users/tcn85/workspace/cscs/chapters/13_abstract_data_types/1303_generics.ipynb), stable heading cell `generic-bridge-14`.

**Already adequate:** Generic methods/classes/constraints/interfaces and iterators now have substantial explanation and local tracing/completion practice.

**Finding:** The compact bridge introduces lambda syntax, Where, Select, OrderBy, ToArray, deferred execution, expression-bodied members and target-typed new in about 138 prose words. These are several distinct forms for an introductory CS2 transition.

**Proposed change:** Give one explicit loop-to-pipeline worked comparison with intermediate values and a deferred/materialized prediction. Place syntax reminders at first later use. Keep the generic/iterator lessons intact; distinguish the hand-written enumerator comparison from the basic yield path. The 35-40-minute-per-reading claim for four readings also conflicts with the 110-minute chapter allocation and needs a coherent meeting map.

### C13: Should fix / Reorganize

Chapter 14; **References Are Paths, Not Copies / Insertion Order and Lost Links**. Source: [1402_linked_nodes.ipynb](/Users/tcn85/workspace/cscs/chapters/14_arrays_linked_lists/1402_linked_nodes.ipynb), stable heading cell `d32ee8a9`.

**Already adequate:** The chapter now has strong pointer explanations, update traces, a sentinel comparison, complete implementations and local practice.

**Finding:** The cursor/reference diagram and lost-link trace come after the first traversal, insertion and deletion examples. The alternative header-node model is introduced before the complete no-sentinel sequence, requiring a representation switch and switch back.

**Proposed change:** Move reference/cursor interpretation before traversal and attach the lost-link trace to the first insertion. Complete one representation before comparing the sentinel alternative. Preserve both complete treatments and the exercises.

### C14: Should fix / Consolidate and reorder

Chapter 20; **Connected Components and Direction / Components and Direction**. Source: [2004_depth_first_components.ipynb](/Users/tcn85/workspace/cscs/chapters/20_graphs/2004_depth_first_components.ipynb), stable heading cell `3615022f`.

**Already adequate:** DFS frames, reachability, component examples and verification contracts are developed.

**Finding:** Two nearby subsections repeat the directed-versus-undirected component distinction. The second 48-word block partly refers onward rather than advancing the current explanation.

**Proposed change:** Combine the direction rules and existing small counterexample into one comparison before the component implementation. Keep frame/enter-exit tracing first and verification as the concluding synthesis. Preserve distinct contracts, examples and old anchors.

### C15: Should fix / Reorganize presentation

Chapter 24; **Shortest Paths and Dijkstra**. Source: [2404_shortest_paths.ipynb](/Users/tcn85/workspace/cscs/chapters/24_greedy_graph_optimization/2404_shortest_paths.ipynb), stable heading cell `e464b3be`.

**Already adequate:** The distance trace, relaxation completion, stale-entry argument, path witness checks and model comparison are substantive.

**Finding:** The reading includes 1,274 code lines across demonstrations, starters and hidden answers, with repeated approximately 100-line standalone classes. Full verification infrastructure competes visually with the central settle/relax/path reasoning.

**Proposed change:** Organize the reading as one focused algorithm narrative followed by a clearly labeled full implementation and verification reference. Keep independent execution by supplying complete setup in each runnable unit; use collapsible support or a downloadable project rather than removing declarations or creating hidden state. Do not delete the boundary cases or correctness arguments.

## Retain without broad expansion

Chapters 1, 4, 15, 16, 17, 18, 19, 21, 22, 23, 25, 26: retain their core depth. Concise introductions, short summaries and parent headings are not deficiencies when children supply the explanation. Specific retention reasons follow.

- Chapter 1 uses conceptual cases and reflection; absence of code in the responsibility lesson is appropriate.
- Chapter 4 has a coherent loop progression; GCD support is excluded.
- Chapters 15, 18 and 19 connect contracts to implementation and applications, with local checks.
- Chapters 16 and 22 have two reading notebooks but substantial contracts, invariants, traces and verification; notebook count is not meeting count.
- Chapter 17 develops BST deletion and returned-subtree reasoning; preserve these rather than shortening to match other chapter totals.
- Chapter 21 needs mathematical reasoning and derivations; preserve the examples while selecting a coherent classroom route.
- Chapter 23 has a balanced three-reading core after Shell Sort and Quicksort are excluded.
- Chapter 25 has substantial worked state design, reconstruction, and choose/explore/undo practice. It needs pacing choices, not automatic cutting or extra examples for their own sake.
- Chapter 26 already has developed prefix-table and overlap traces plus completion/feedback. Its KMP material is a positive model, not an expansion target.

## Proposed repair sequence

1. Correct the two confirmed prerequisite/causal problems, C05 and C08.
2. Reorganize existing instruction in Chapters 3, 5, 7, 8, 14, 20 and 24, preserving original examples, practice, IDs, anchors and published routes.
3. Add bounded development in Chapters 2, 9, 10, 11 and 13; defer the optional polish in C11 until these are done.
4. Reconcile the ADT meeting map with its four readings without deleting instruction to satisfy a time quota.
5. Recheck affected core prerequisites, run changed code, and verify the build and relevant rendered pages during an authorized fix pass. Assignments and optional-reading revisions remain deferred.

## Verification and limits

Targeted .NET 10.0.107 run: untrimmed integer parse true/98; retained array loop 345 vs complete sum 433. No full code rerun or fresh build.

The local HTML build lacks some current pages, so it was not treated as evidence of current presentation. Existing verification logs are historical context, not fresh execution of all retained cells. Source hashes in findings.json permit checking that this audit made no teaching-source edits. Quantitative totals from the prior core-word-count report remain triage measures; they include footnotes and some legacy indented snippets, so they are not exact instructional-prose budgets.
