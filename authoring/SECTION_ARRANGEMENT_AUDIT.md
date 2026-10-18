# Section arrangement audit

Second pass, October 17, 2026, against the uncommitted working tree after the
"integration cleanup and prerequisite placement" pass recorded in
`authoring/integration_cleanup/README.md`. The first pass (same day) is
summarized under "Resolved since the first pass". Findings only; nothing is
edited by this audit.

Method: all 92 content notebooks in `_toc.yml` surveyed for headings, prose
size, runnable code cells, in-page directives, text after the Footnotes
rubric, and landing-page order. All 26 landing pages list their sections in
TOC order.

## Verdict

Chapter boundaries are now sound. No chapter needs a page combined or split
to be teachable in its current order. What remains is one misbalanced
chapter (8), one page that absorbed a block it should fold in (20.4), a
handful of within-page fragmentations the exact-duplicate check does not
catch (Chapters 3, 4, 5), and housekeeping. None of the current working-tree
changes are committed.

## Resolved since the first pass

Verified in the working tree:

- Merge seams: every page has one `{contents}` directive, no duplicate `##`
  headings, no provenance notes, instructional text before Footnotes
  (the xUnit/NUnit walkthrough now sits under "Framework Setup and Test
  Attributes" in 0603), BST Summary last.
- Chapter 2: 0204 teaches Types, Common Data Types, Data Types in Action,
  and Type Conversion before the developed conversion/display sections;
  input casting moved into 0204; the loop-generated table cluster moved to
  0402 "Apply Loops to Formatted Tables"; 0203 is now Input, UI class,
  Output, Composite Formatting, String Interpolation.
- Chapter 16: sort-a-copy and preparation/update workloads moved to 1602.
- Chapter 26: 2601 removed from the TOC (file is a one-cell "moved" stub)
  and folded into 2004; the hops-versus-cost counterexample moved to 2404;
  landing page, objectives, glossary, and Chapter Topics reframed to three
  string/limits readings.
- Supporting-reading titles restored in the TOC for 0605, 0906, 0905, 1104,
  2304, 2305.
- Thin pages developed: 0601 (783 to 1305 words), 0602 (916 to 1451),
  1104 (359 to 867), 2305 (639 to 1028, 2 code cells), 2501, 2504, 2402.
- 0701 and 0902 now have runnable cells.

Chapter 9 was deliberately kept at five pages with regex and privacy marked
supporting. With those labels the chapter reads as three core pages plus two
supporting ones, which matches the plan's intent; no further boundary change
is recommended. Chapter 23's Shell sort and quicksort pages are likewise
acceptable as labeled supporting readings now that quicksort is developed.

## A. Remaining structural findings

### Chapter 8: rebalance the family map and the operations page (Medium)

Unchanged from the first pass. `0804_collection_operations` is the largest
page in the book (3983 words, 11 code cells) while `0801_collections` (1843
words) has no runnable code. Move the per-family demonstrations under
"Collection Examples" (arrays/lists, linked lists, dictionaries, sets,
stacks/queues, priority queues) to the end of 0801, leaving 0804 with the
operation tables, traversal, and shared references. `0802_list` keeps a
"Generics" section that duplicates 0804's "Generic Collections"; keep one.

### Chapter 20.4: fold the appended verification block in (Medium)

`2004_depth_first_components` (now 1521 words, 528 code lines) ends with
"Verify a Traversal" followed by two further `##` headings carried over from
the retired 2601 page: "Traversal Verification Contracts" and "Components
and Direction". The second near-duplicates the page's own "Connected
Components and Direction", and its text still says "The component method in
Chapter 20" from inside Chapter 20 and points to "the Chapter 26 lab".
Demote both to `###` under "Verify a Traversal", merge the components
paragraph into the existing section, and fix the self-reference.

### Chapter 24.3: watch the size (Low, optional)

`2404_shortest_paths` absorbed the Chapter 26 counterexample and is now the
heaviest code page in the book (1393 words, 11 code cells, 967 lines). It
carries three roles: Dijkstra, route-model comparisons (hops versus cost,
cheapest network versus shortest-route tree), and verification/boundary
policy. It is teachable as one lesson; if the chapter ever needs a fourth
page, "Route Models and Verification" is the natural cut.

## B. Within-page fragmentation still open

| Page | Issue | Suggested fix |
| --- | --- | --- |
| `0301_intro_decision` | Opens with "Selection Statements" on the Boolean-expressions page | Move the paragraph to 0302's opening or retitle it "Why Decisions Need Boolean Values" |
| `0302_ifstatement` | Three else-if headings ("Multi-Selection", "else-if Statements", "for Cases") and three nested headings ("Nested Conditionals", "Nested `if`", "Nested `if-else`") | One `##` each with `###` subsections |
| `0401` / `0402` | `break`/`continue` taught in both; step patterns split across 0401 "Iterator/Step", 0402 "Additional Loop Step Patterns" and "Step in loop header"; "`foreach` Essentials" and "`foreach` Statement" are two headings for one topic | One break/continue section (0402), one step-pattern section, one foreach section |
| `0403_while_statement` | GCD appears three times: "GCD Example with a `while` Loop", a link to the full page, and 0404 itself | Keep a sentence plus the link |
| `0501_intro_methods` (3379 words) | Reference block "Static Methods / Method definition / Method Calls" from the old summary still follows the lesson | Move to a "Method Syntax Reference" dropdown at the end of 0505 |
| `0503_parameter` | Second "Scope" and "Static Storage Reference" sections repeat "Variable Scopes" and "Static Variables" | Same reference dropdown |
| `0501`, `0502` | 53-word tails after the Footnotes rubric | Move above the rubric |
| `1403_comparison_lab` | "Lab Tasks" heading on a content page | Rename to "Guided Comparison" |
| `0701_onedim` | "LINQ Methods" section, flagged as later reading, inside Chapter 7 | Acceptable; a dropdown would keep it from reading as required |

## C. Housekeeping

- `chapters/03_methods/` is still an empty leftover folder.
- Retired notebooks remain beside live ones: `0306_switch`, `1603_workloads`,
  `2202_divide_conquer`, `2403_optimization_lab`, `2503_optimization_lab`,
  and the `2601_graph_traversal` stub. `only_build_toc_files: true` keeps
  them out of the build. The convention is `materials/stale_chapters/`.
- `_ext/chapter_redirects.json` still sends old URLs to those retired paths
  (for example old `0406-switch` to `0306_switch`) and relies on the
  anchor-route layer to chain onward. The plan's rule is to flatten
  redirects to their final destination. One anchor route sends the retired
  2503 page's `#exercise` to `22_recursion_divide_conquer/2201_recursion`,
  the wrong chapter.
- Landing pages for Chapters 16, 18, and 19 remain 190 to 250 words with
  generic objectives; 1600 has no chapter introduction or video. Chapter
  20's landing grew to 380 words.
- The whole cleanup pass is uncommitted: 111 modified files plus the new
  `authoring/integration_cleanup/`, `authoring/priority_development/`, and
  six scripts. Review and commit before further structural work so the
  preservation baselines line up with a known commit.

## Suggested order of work

1. Commit the current working tree (no deploy).
2. Chapter 20.4 fold-in and Chapter 8 rebalance.
3. Chapters 3, 4, 5 within-page consolidation; 1403 heading.
4. Housekeeping: empty folder, retired notebooks to `materials/stale_chapters/`,
   flattened redirects, the misrouted anchor.
5. Thin landing pages for 16, 18, 19.
