# CS1 teaching-content restoration

The comparison baseline is the independently restored CS1 edition in `thinkcscs-archive` at `a6ced58`. The current Press baseline is `1cfd051a`. The restoration adds material while preserving the existing chapter sequence, lesson cells, assessment IDs, current assignments, and newer additions. Setup and Git remain in the appendices.

| Earlier material | Current home |
| --- | --- |
| Boolean-output, word-length/magnitude, graduation, and Congress tasks | Decisions: Extra Practice. |
| Iterative factorial/overflow, coin simulations, Group Flips, guessing game/replay, Sum to n, and loan schedules | Iteration: Extra Practice. |
| Full mathematical GCD development, trial division, improvement exercise, subtraction, remainder, and recursion comparison | Iteration: GCD supporting reading; includes a top-level runnable version. |
| PrintReps/StringOfReps, reverse strings, OnlyLetters, palindrome, generalized power table, and multi-method Strange Sequence | Methods: Extra Practice. |
| Original complete multi-project unit-testing lab workflow and source listings | Testing: linked Unit Testing Walkthrough. |
| ReadInts, destination versus new-array addition, ascending subsequences/runs, and dot product | Arrays: Extra Practice. |
| PromptFile cancellation and uppercase file copy | Files: Extra Practice. |
| Hard-coded versus file-driven responder; ReadParagraph/GetParagraphs/GetDictionary; random fallback | Files: File-Driven Responses, linked forward from Collections; downloadable .NET starter under `demos/09_files_text/`. |
| Statistics, constructor experiment, alternate internal state, GuessGame instances, and Animal/TestAnimal | Classes: class-instance explanations plus Extra Practice. |
| Shell sort/gap experiments, Quicksort/partition explanation, and four-representation empirical search lab | Advanced Searching and Sorting: supporting lesson and assignment. |

Methods and OOP explanations that survived the reorganization were retained. No duplicate chapter or required meeting is introduced. Original project wrappers were adapted where Decisions/Iteration now precede Methods. The full GCD prose and constructor/state exercises are preserved, with prerequisites and correctness clarifications.

## Correctness repairs

- The population standard-deviation expression is `sqrt(sumOfSqr / count - average * average)`; the older expression grouped the division incorrectly. Empty populations return NaN; the example documents cancellation limits.
- The guessing-game worked sequence has four guesses, not three.
- Loan schedules explicitly round midpoint interest away from zero, matching the historical tables. The default midpoint-to-even overload produces different balances. Final payments and non-amortizing payments are checked.
- Unit-test assertions use expected, then actual. The deliberate multiplication defect remains; its failure reads expected 100, actual 20. MSTest assertions are not described as debug-only assertions.
- Quicksort handles empty ranges; the midpoint calculation avoids adding the two bounds.
- Timing compares identical query values and reports actual repetition counts. Optional scaled timings are identified as estimates.

## Verification

- Compiled and ran all newly added executable notebook cells independently with .NET 10; retained their printed outputs.
- Checked demonstration outputs against independent expected values, including array transformations, palindrome outcomes, integer-factorial capacity, loan final payments, and empty Statistics behavior.
- Checked all four restored GCD implementations against an independent remainder oracle for 900 positive pairs each.
- Verified Shell sort and Quicksort against Array.Sort for lengths zero through 120 with duplicates, plus subrange sentinels.
- Executed the exact solution/project/reference commands in the testing walkthrough. The intentional defect produced one failed and three passed tests; its repair passed all four tests.
- Extracted the downloadable response-lab starter and checked both the hard-coded program and the file-driven program after supplying the completed helpers.
- Compared existing notebook cells with the baseline: all original cells remain unchanged, except moving two historical constructor/state anchors from the opening cell to the actual restored exercises.
- Built the Press book and the standalone reference edition. Existing lexer warnings for character literals and nullable syntax are unrelated to this restoration.

The independent site's While Loop Review is fixed in its own private repository, commit `f6e780e`. The original review body was recovered from `26fb270d`; its historical final prompt lacked a code fragment, so a short decrementing-loop question was supplied. Its minimal deployment updates only the review HTML, downloadable notebook, and search index, with backups. Production publication requires the existing server owner's sudo access.
