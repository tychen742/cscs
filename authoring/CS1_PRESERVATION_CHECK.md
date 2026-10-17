# CS1 preservation check

Restoration checked on October 17, 2026, against the restored standalone CS1 source (archive commit `f6e780e`) and the current Press baseline (`b46e1c26`). This pass supplements the earlier restoration.

All 15 findings from the second audit are closed. A further source-list check restored smaller array, reversal, abstract/interface, and collection-review variations. No further missing explanations or exercises were identified in the reviewed comparison. The machine-readable mapping is in `CS1_PRESERVATION_MATRIX.json`.

## Preservation and placement

Every pre-existing notebook cell retains its source, metadata, and saved output. Existing chapters and their relative reading order remain intact. New supporting reading and practice supplement the current lessons. Return-based exercises follow Methods; setup and Git remain in the appendices. The independent thinkcscs.org archive is unchanged by this pass.

Historical inaccuracies are corrected explicitly, including address-space limits, C# accessibility, inheritance terminology, UTF-16 indexing, and invalid property access. Intentionally failing examples are labeled and their expected diagnostics verified.

## Restored content

- **review1**: Seven original open-ended questions retained; inaccurate absolute premises corrected.
- **review2**: All six original review tasks now explicit, including eight expressions, four casts, single-call multiline output, add3, and quotient sentence.
- **return**: Original a-h return alternatives and four nested-if alternatives retained in full; complete runnable trace plus compiler-diagnostic checks.
- **Strange Sequence decomposition**: Three original named functions and their independent print/count roles retained, with term versus transition policy stated.
- **Congress extension**: Original three-way conclusion added without removing the independent Boolean variant.
- **Unicode foreach illustration**: Original ABCabc indexed and foreach numeric-code output restored with corrected string terminology.
- **while**: Missing program and zero-start follow-up copied from the repaired standalone review.
- **example**: Original two-field constructor, four accessors, ToString, full aliasing client and verified answer retained.
- **averager**: Full original outward contract, client listing/output, calculator-memory motivation, algebra and implementation retained.
- **params**: All ten original Classes review prompts, including both Sum assignments, are explicit; params is explained and demonstrated with boundary cases.
- **sealed**: Full original base/virtual/sealed rules and shape hierarchy; runnable valid form and explicitly diagnosed failing variation.
- **paradigms**: Scientific CS-thinking context and full original multi-paradigm/pillar/separation-of-concerns discussion restored with correctness clarifications.
- **oopreview**: All three Student questions and full Triangle/Rectangle GetArea assignment retained, with separate-file instructions and corrected/diagnosed historical errors.
- **Shell gap alternatives**: Original 2h+1 family, numerical sequence and three-family experiment restored with complete runnable code.
- **UI helper import workflow**: Step-by-step source copy/download, same project, namespace adjustment/import, client, single entry point and run workflow restored; setup remains in appendices.
- **additional-variants**: Full named array drills and original test inputs/prompt formatting, print-versus-return reversal and faulty-loop diagnosis, Circle/rectangle perimeter/abstract-instantiation/interface-animal variants retained after rechecking source lists. The original introductory-data-structures lookup-efficiency review question is also explicit in Collections homework.

## Validation

- All 31 newly added runnable C# cells compile and run independently with .NET 10; their outputs are saved in the notebooks.
- All 12 original return fragments were checked against independent expected branch results.
- Shell-sort gap variants passed 453 comparisons against Array.Sort, including duplicates and empty inputs.
- Invalid examples produced the expected compiler diagnostics; the original faulty reversal produced its expected bounds exception.
- The downloadable UI helper was extracted, compiled, and checked with valid input, retry input, and end of input. The separate-file Shape exercise compiled and ran.
- The coverage check confirms all mapped content is reachable through the active table of contents, all original notebook cells remain intact, and the chapter order is preserved.
- Jupyter Book HTML build and git whitespace checks pass. This is local verification; no deployment was performed in this pass.

A readable before/after comparison is generated with the local preview as `preservation_review.html`.
