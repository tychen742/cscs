# Section 3.2 practice pilot

One representative section, as requested. The initial pilot was deployed in commit bc6cab3e. The subsequent Predict correction below is a local revision pending review.

[Built section](/Users/tcn85/workspace/cscs/_build/html/chapters/03_decision/0302_ifstatement.html) · [Readable content diff](review.html) · [Unified content diff](source.diff) · [Remaining core audit](../core_depth_reaudit/README.md)

## Changes

The final practice set, immediately before Footnotes, has four desktop-style question tabs: Predict, Explain, Repair, Apply. The first and third reuse the original branch-trace and repair cells verbatim. The other two ask students to distinguish unknown service from zero charge and implement delivery rules with boundary checks. Questions require only material taught by this reading. Inline instructional checks remain beside their explanations.

The tabs support arrow keys, Home/End, links into question panels, local draft notes, and print/no-JavaScript fallbacks. Notes are stored in this browser, not submitted. Coding exercises retain the existing runner and exercise IDs. The original runnable cells are moved, not cloned. Styles and behavior activate only on the marked pilot region.

All 76 original cells are preserved exactly; 13 cells were added. All 278 other notebooks are byte-for-byte unchanged, including assignments and optional readings. The section planning files and book asset registrations were updated for the pilot.

## Verification

- Notebook schema and original-cell preservation passed; see preservation.json.
- Both new standalone C# cells and six delivery cases compiled and passed; see code_verification.json. Unused-variable warnings in the intentionally incomplete starter are expected.
- The built HTML passed four-tab, keyboard, ARIA state, draft, hash, initialization and fallback checks; see dom_verification.json. Existing code-node identity, editor value and event listener survived tab construction.
- The local book build succeeded. The full rebuild retained three existing lexer warnings; no new pilot warning was introduced.

DOM checks use temporary jsdom, with no repository dependency added:

```sh
CSCS_JSDOM_PATH=/tmp/cscs-practice-dom-check/node_modules/jsdom node scripts/verify_section_practice.js
```

The live browser runner API and visual layout have not been exercised by these automated checks. C# execution was verified locally. This pilot does not implement the other re-audit recommendations or roll tabs out to the rest of the book.

## Predict correction after student-facing review

The original Predict prompt mixed a score comparison with an unrelated service-table request and an undefined D code. It also provided a scratchpad without checkable predictions. The revision removes that request and replaces the scratchpad with two visible score programs and one multiple-choice output prediction per program. A Check predictions button handles missing selections and gives per-program feedback. The explanation and boundary checks remain revealable. C# spelling is corrected to else if.

[Review this correction](prediction_revision.html). Both programs compile and produce the expected output. DOM checks cover unanswered, incorrect and correct predictions as well as the existing tab behaviors. Existing runnable notebook cells are unchanged. Earlier baseline and preservation files describe the initial pilot; the two Predict markdown cells and one introduction have intentionally changed in this correction. No deployment has been performed for this correction.
