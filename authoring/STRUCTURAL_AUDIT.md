# Structural Audit — 2026-09-19

## Chapters 15–25 Consistency Follow-up — 2026-10-05

The September audit below is historical; its chapter numbering, TOC root, and status statements describe that earlier checkout. The current book has 25 chapters and root `index`.

This follow-up checked all 88 published notebooks in Chapters 15–25 against the current TOC. Notebook schemas, local Markdown destinations, Sphinx document targets, indexed content headings, final lesson footnotes, and assignment structure passed. Every chapter has five tagged lab questions and five hidden solutions, and five tagged homework coding questions and five hidden solutions. All hidden coding solutions retain verified output. Chapter handoffs consistently place graph representation in 19, analysis in 20, recursion/merge sort in 21, search/elementary sorting in 22, greedy graph optimization in 23, dynamic programming/search in 24, and traversal/string matching/limits in 25.

Fixed 17 missing cell IDs in Chapter 15’s preview, lab, and homework. IDs are deterministic and existing IDs, cell order, source, tags, and outputs remain unchanged. C# verification from each completed depth pass remains applicable; this follow-up changes metadata only.

Inactive source banks such as `15-pattern-records` and `16-generics-async` remain outside the published TOC and clearly describe their staging role. Their removal is not required for this pass. Slides and the legacy Interactive Exercise UI rename remain deferred to Press, as requested.

The verified full-book build has five existing warnings outside this sequence: C# lexer warnings in 0202, 0604, and the Preface, and unresolved `namespace` and `hg-and-teamwork` labels in 1001 and the Project appendix. These still require a separate cleanup before a warning-free publication build. This follow-up is a consistency check, not a fresh correctness proof or exhaustive pedagogical audit of the whole book.


Scope: book-level structure only. This pass compares the book-authoring rules,
`AGENTS.md`, `authoring/BOOK_PLAN.md`, `authoring/PROGRESS.md`, `_toc.yml`,
the real `chapters/` tree, assignment folders, and planning docs. It does not
judge prose quality or runnable C# examples yet.

## Current Truth

- `_toc.yml` builds from `root: chapters/preface`.
- Every file referenced by `_toc.yml` currently exists.
- `_config.yml` has `only_build_toc_files: true`, so non-TOC notebooks are not
  built unless they are added to `_toc.yml`.
- Active chapter folders now use Ch01-Ch24 without the former duplicate Ch06
  or missing Ch11.
- `authoring/PROGRESS.md` reflects the active 24-chapter direction better than
  `AGENTS.md`.
- Active regular assignment naming is Preview, Lab, and Homework.
- Active appendices in `_toc.yml` are Resources, Command Line, Project, and CS
  Index.

## Must Fix Before Final Publication

| Area | Finding | Evidence | Recommended action |
| ---- | ------- | -------- | ------------------ |
| Ch12 assignments | `chapters/11_databases` has no `assignments/` folder and no assignment section in `_toc.yml`. | Assignment folder scan. | Add `assignments/index.ipynb`, `preview.ipynb`, `lab.ipynb`, and `homework.ipynb` when returning to Ch12. |
| AGENTS mismatch | `AGENTS.md` still says "Chapter sequence is ch01-ch16" even though `_toc.yml` now has Ch01-Ch24. | `AGENTS.md`. | Update `AGENTS.md` after the final numbering decision so future agents do not follow stale project instructions. |
| Back matter | The shared book-authoring rule requires Appendices, Bibliography, and Index as back matter. This project currently has Appendices and `cs-index`, but no bibliography file or separate Bibliography/Index TOC parts. | `_toc.yml`; file scan found no `.bib` or bibliography file. | Decide whether CSCS intentionally omits bibliography. If not, add `chapters/bibliography.md`, `references.bib`, and separate Bibliography/Index parts. |

## Should Fix Soon

| Area | Finding | Evidence | Recommended action |
| ---- | ------- | -------- | ------------------ |
| Non-TOC chapter tracks | `chapters/13-exceptions-testing`, `chapters/14-functional-patterns`, `chapters/15-pattern-records`, and `chapters/16-generics-async` remain in `chapters/` but are not active in `_toc.yml`. | Chapter directory scan. | Move to an archive/staging location, or add clear local docs explaining their status. |
| Ch12 source leftovers | `chapters/11_databases/1201`-`1205` are former modern-C# topics and are not active in `_toc.yml`. | File scan and `_toc.yml`. | Move/archive/relabel after the Ch12 database assignment pass. |
| Old collection source notebooks | `chapters/09_collections/1101-intro-ds.ipynb` and `1102-collection-examples.ipynb` remain outside `_toc.yml` as source material for later reuse. | File scan and Ch08/Ch13 planning docs. | Keep out of the active TOC; mine remaining stack, queue, or tuple material only when it supports later chapters. |
| Ch08 stale merge source | `chapters/09_collections/0802-list-dictionary.ipynb` is not active in `_toc.yml`. | File scan and Ch08 `MATERIALS.md`. | Merge any useful material into `0902_list.ipynb` and `0903_dictionary.ipynb`, then archive or remove. |
| Legacy extra homework pages | Ch05, Ch09, and Ch10 list extra homework pages in `_toc.yml` in addition to standard Homework. | `_toc.yml`. | Decide whether these remain as extra homework, move under instructor-facing `assignments/`, or become extension pages. |
| Planning front matter | Older `MATERIALS.md` and `ORGANIZATION.md` files in Ch01-Ch10 and non-TOC staging tracks lack `orphan: true` front matter. | Planning-doc scan. | Add MyST front matter so excluded planning docs do not become warning sources. |
| Materials layout | Shared rule says runnable source should live in numbered `demos/NN/` folders. This project still mainly uses `demos/demos/` and `demos/examples/`. | `demos/` scan. | Decide whether to migrate to numbered folders or document CSCS as a legacy exception. |

## Deferrable Polish

| Area | Finding | Recommended action |
| ---- | ------- | ------------------ |
| Appendix landing draft | `chapters/appendices/appendix_overview.ipynb` exists but is not active in `_toc.yml`. | Add it to TOC only if appendices need a landing page; otherwise archive/remove. |
| Project assignment convention | `BOOK_PLAN.md` supports project assignments, but active chapter TOCs currently standardize only Preview/Lab/Homework. | Revisit after course project arc is finalized. |

## Clean Structural Baseline

These are already in good shape:

- `chapters/preface.ipynb` is the canonical root.
- Active chapter path numbering now matches the 24-chapter plan.
- Standard assignment files exist for active chapters except Ch12.
- Regular assignment sidebar titles use Preview, Lab, and Homework.
- Active Ch15-Ch24 folders have `MATERIALS.md`, `ORGANIZATION.md`, content
  notebooks, and assignment folders.
- Chapter video headings have been standardized to `Chapter Video` where videos
  are present.

## Recommended Starting Order

1. Update `AGENTS.md` to match the 24-chapter sequence once the in-progress
   AGENTS refinement is ready.
2. Finish Ch12 assignment scaffolding and TOC insertion.
3. Archive or label non-TOC chapter tracks.
4. Add `orphan: true` front matter to old planning docs.
5. Decide what to do with legacy extra homework pages.
6. Run a clean full-book build and record warnings before starting content prose
   QA.

## October 5, 2026 follow-up

Chapter 1 and Chapter 2 depth revisions were undone at the author's request, restoring their pre-review content and assessments. The separate Git and GitHub appendix remains available for later Commons migration; the original Chapter 1 Git section is restored. Slide authoring remains book-owned work after content completion, with Press providing delivery and access controls.
