# TODO

## 1. Cleanup

1. [ ] Standardize assignment folders around Preview, Lab, and Homework, and create solutions where needed. Legacy review pages have been renamed to `homework.ipynb`.
2. [ ] NN00 intro vs NN01 intro.
3. [ ] normalize the chapter folders to match the book chapters online and normalize the section filenames.
4. [ ] Add one chapter to Appendices about Tooling.

## 2. Content

1. [x] Review `1508-lab.ipynb` intro sentence — still says "pattern matching, record types, and nullable operators" (doesn't mention generics/async)
2. [ ] Add sample solutions notebook for the `15-pattern-records` lab (inactive source bank)
3. [ ] Consolidate the AI_guidelines.ipynb file in the projects (cscs, py, dsm) to have the same shared components
4. [ ] Check all chapter sections for quality issues. For example, 
5. [ ] Reflow all paragraphs in book content so each paragraph is a single line (for better wrapping and formatting)
6. [ ] Teaching devices adapted from introcs.cs.luc.edu (comparison 2026-10-04; use business examples):
   1. [ ] Ch.1: a "Learning to Solve Problems" study-skills page (don't memorize everything, keep a running summary, try first and then check), updated for when and how to use AI assistants.
   2. [ ] Ch.2: teach reading syntax templates as an explicit skill early; today it appears only in `0302-signature_call`.
   3. [ ] Ch.3: make the writer and consumer roles of a method explicit in `0301-intro-methods` (a caller needs the name, parameters, and return value; the writer decides how).
   4. [ ] Ch.8: a light performance lab timing linear vs. binary search with `Stopwatch`, to motivate Big-O in Semester 1 (today only `1803-performance-lab` in Semester 2).
   5. [ ] Ch.11/12: plan classes from a console transcript (nouns become classes, verbs become methods), using an order-entry session (Customer, Order, Product).
7. [x] Teach string operations earlier than Ch.10: new `03-methods/0304-strings.ipynb` (2026-10-04); Ch.10 `1003-text-operations` keeps splitting, validation, and structured records.
   1. [x] Add string-method questions to the Ch.3 preview, lab, and homework (2026-10-04; lab solution in `materials/03/`).
8. [ ] Society, Ethics, and the Profession (CS2023 SEP): first draft of Ch.7 added 2026-10-04 (`chapters/07-society-ethics`). Still to do: a chapter video; short SEP callbacks in later chapters (privacy in Ch.13 Databases, parameterized commands in `1309-csharp-database-workflow`, sustainability in Ch.20).

## 3. Build

1. [ ] Verify `jbb` succeeds cleanly after all TOC changes
2. [ ] Check cross-references between the Ch.11 tuples section (`1101-class-syntax`, label `tuples`) and the records material in the `15-pattern-records` source bank
3. [ ] Verify `jbb` builds cleanly after all TOC restructuring changes

## 4. Done

8. [x] Review `1508-lab.ipynb` intro sentence — still says "pattern matching, record types, and nullable operators" (doesn't mention generics/async)
1. [x] Remove `examples/Properties/` stub folders (~134)
2. [x] Remove `examples/bin/` output folders (~125)
3. [x] Delete `cscs/introcs-csharp-examples-master/` (superseded)
4. [x] Delete `requirements.txt_OLD`
5. [x] Delete empty `test` file in project root
6. [x] Remove legacy image folders: `lab-hg/`, `lab-edit/`, `lab-monodevelop/`, `xcode/`, `logo_OLD.svg`
7. [x] Clean `_ext/__pycache__/`
