---
orphan: true
---

# Response to the chapter organization review

Response prepared October 17, 2026, against the current main checkout and the deployed landing-page revision (`48afdb5d`). The supplied worktree path was unavailable; the review was found at `authoring/toc_comparison/README.md`. This response records editorial judgments, not authorization to implement every proposed addition. No teaching content or organization was changed.

The review identifies worthwhile questions about the completeness of the CS1 and CS2 adoption routes. Its strongest contribution is distinguishing what a student actually encounters on each route from what exists somewhere in the full book. I support that approach. However, recommendations should follow a coverage-and-prerequisite check of the current notebooks, not just a comparison of chapter titles.

## Retain the distinctive teaching progression

Keep professional responsibility and AI literacy in Chapter 1, testing in Chapter 6, and deeper nullability and ownership in Chapter 11. Their justification is educational, whether or not a comparator uses a similar chapter title.

Chapter 1 establishes responsible action, independent understanding, and verification before students develop habits around code and AI suggestions. Chapter 6 consolidates checks introduced earlier, after students can write methods and test their contracts. Chapter 11 connects missing data and nullable-flow reasoning to object references, composition, and public contracts. Basic missing-input checks still belong earlier.

Replace “no counterpart in any comparator” with:

> These topics are not clearly represented as comparable units in the reviewed tables of contents. Retain them because they serve explicit learning goals and fit the book's progression. Comparator coverage informs organization; it does not determine scope.

A table of contents cannot establish that a subject is absent from a book. The review itself mentions testing in Harrington and JUnit in Liang. Nullability is also language-specific, so Java and older C# editions need especially careful comparison. Treat the repeated claims about AI literacy, contracts, and verification similarly: verify section-level coverage before asserting uniqueness.

## Responses to the recommendations

| Item | Response | Proposed disposition |
| --- | --- | --- |
| 1. Search and sort in CS1 | Agree that the CS1 route should explicitly develop elementary array-algorithm reasoning. Distinguish implementing an algorithm from calling a library operation. | Audit Chapter 7's content and assessments, then develop first-match linear search and a modest elementary-sort explanation with syntax, traces, output, mistakes, and guided practice. Library sorting and binary search can accompany these with their preconditions and mutation policies. Preserve Chapter 16's deeper treatment. An optional trace alone does not close a required outcome. |
| 2. Recursion | Agree that the present CS1 exposure is recognition-level, not a developed lesson. Avoid calling it completely absent: Chapter 4 retains a recursive GCD variant, Chapter 5 names recursion, and 17.1 develops recursive models before their use. | A focused Chapter 5 supporting reading is reasonable after method calls and returns. Include independent call frames, a base case, progress, returned results, and a loop comparison. If recursive problem solving becomes a required CS1 outcome, make that requirement explicit rather than relying on optional reading. Keep 17.1 self-contained for students who skip the extension. |
| 3. An efficient sort in CS2 | Agree that a route advertised as a general CS2 foundation should explain its sorting expectations. | Prefer an explicit adoption profile recommending Chapter 22 when recursive divide-and-conquer sorting is required. Do not merely link its merge-sort lesson into Chapter 16: that would place recursive code before the current recursion introduction. An earlier supporting reading would need its prerequisites developed locally. Keep advanced chapters selectable for other profiles. |
| 4. Introductory analysis | The proposed growth table is already present in 13.2, together with a cost model, tight versus upper bounds, input-dependent search cases, amortized growth, auxiliary space, and prediction practice. | Accept 13.2 as the CS2 analysis baseline, but review the adequacy of these existing explanations before adding duplicate material. Clarify best/worst-case terminology if needed and check that Chapters 14–20 point to the introductory treatment. Reserve Chapter 21 for deeper reasoning. |
| 5. LINQ, lambdas, and delegates | “Not taught” overstates the gap. Section 7.1 introduces aggregation calls; 13.3 explicitly explains a lambda, `Where`, `Select`, `OrderBy`, materialization, and deferred execution, with a runnable pipeline. This remains a short introduction rather than a developed query lesson. | Consider a coherent supporting lesson, with a general syntax explanation and a loop-to-pipeline comparison. If placed in Chapter 8, use numeric/string collections or supplied data that does not require untaught classes and records. Rich order-object queries fit better after OOP. Teach the callback/delegate concepts actually required; imports alone do not establish a need for an entire delegate unit. |
| 6. Enums, Random, StringBuilder | Sensible candidates, subject to checking actual uses and instructional need. | Introduce each before its first required use. Enums fit finite-state data models; a Chapter 4 simulation can introduce `Random` with reproducible checks; `StringBuilder` can extend Chapter 9's text construction after string immutability. Develop small lessons, not incidental API name-drops. |
| 7. Balanced trees | Useful optional depth, not automatically a missing requirement for every adoption route. | Connect height to operation costs and show a purposeful rotation if added. Distinguish implementing a balanced tree from using an ordered library collection. Preserve the current BST core. |
| 8. Topological ordering | A strong business-oriented application of directed graphs. | Prefer a supporting extension connected to Chapter 20, with directed acyclic graph assumptions, cycle detection, and a dependency-order example. Avoid adding another required meeting or placing it in the greedy chapter merely because it uses a graph. |
| 9. Postfix evaluation | A valid stack application, but being traditional does not make it necessary. | Add only if it teaches something not already developed through delimiter matching, histories, and worklists. It should not displace the current business applications or be used to justify calling a developed chapter “light” without examining its exercises. |
| 10. Naming and scope | Reject matching short sidebar labels to full page titles. This distinction is an explicit B-A requirement. Agree that deliberate scope boundaries should be clear. | Keep concise one-line navigation and full descriptive page titles. Explicitly name desktop GUI development among the excluded application frameworks. Keep the Chapter 16/23 distinction visible from both chapters. |

## Findings already resolved or needing correction

The deployed landing-page revision already removes Chapter 14's stale binary-search/reporting objective and relocates its orientation vocabulary to Chapter 16. Chapter 23 now explicitly introduces itself as a deeper treatment of Chapter 16. All chapter landings have been revised, so those editorial recommendations should be marked resolved rather than left as open defects. Short sidebar labels remain intentional.

The claim that the *first linear search* appears in Chapter 16 needs a defined scope and a passage check. A named teaching lesson, a scanning loop, a library call, and an assessed implementation are different levels of coverage. The useful question is whether CS1 students receive a developed and assessed array-search lesson, not whether the phrase first appears at a particular location.

The review is dated October 18, while this response is prepared October 17. Confirm the report and retrieval dates before finalizing its provenance. Several comparator lists are explicitly reconstructed from memory. Keep those observations provisional, provide direct edition-specific source links, verify claims such as “every comparator,” and identify or remove the unlisted “Doyle” reference. This response does not certify those external TOCs; attempted checks of the Think Java and Princeton pages were unavailable through the browsing tool.

## Recommended next step

First define the essential outcomes for the CS1-only and CS2-foundation adoption routes. Then map each outcome to its current explanation, worked example, guided practice, and independent assessment. Use that map to distinguish an actual gap from a short treatment, a missing prerequisite, or optional enrichment.

Prioritize elementary array algorithms in CS1, the recursion expectations for each route, and an efficient-sorting option for a general CS2 profile. Verify the current analysis and LINQ coverage before expanding it. Consider the remaining enrichment separately, with adequate teaching development and realistic student workload. Supporting readings preserve the meeting structure, but they still require learning time; they are not a way to make every comparator topic cost-free.

Keep the current chapter order, existing explanations and exercise variations, assessment IDs, and the selectable role of Parts VI and VII. No moves or additions should follow from this review until their coverage and prerequisite rationale is concrete.
