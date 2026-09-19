# Structural Audit — 2026-09-19

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
| Ch12 assignments | `chapters/12-databases` has no `assignments/` folder and no assignment section in `_toc.yml`. | Assignment folder scan. | Add `assignments/index.ipynb`, `preview.ipynb`, `lab.ipynb`, and `homework.ipynb` when returning to Ch12. |
| AGENTS mismatch | `AGENTS.md` still says "Chapter sequence is ch01-ch16" even though `_toc.yml` now has Ch01-Ch24. | `AGENTS.md`. | Update `AGENTS.md` after the final numbering decision so future agents do not follow stale project instructions. |
| Back matter | The shared book-authoring rule requires Appendices, Bibliography, and Index as back matter. This project currently has Appendices and `cs-index`, but no bibliography file or separate Bibliography/Index TOC parts. | `_toc.yml`; file scan found no `.bib` or bibliography file. | Decide whether CSCS intentionally omits bibliography. If not, add `chapters/bibliography.md`, `references.bib`, and separate Bibliography/Index parts. |

## Should Fix Soon

| Area | Finding | Evidence | Recommended action |
| ---- | ------- | -------- | ------------------ |
| Non-TOC chapter tracks | `chapters/13-exceptions-testing`, `chapters/14-functional-patterns`, `chapters/15-pattern-records`, and `chapters/16-generics-async` remain in `chapters/` but are not active in `_toc.yml`. | Chapter directory scan. | Move to an archive/staging location, or add clear local docs explaining their status. |
| Ch12 source leftovers | `chapters/12-databases/1201`-`1205` are former modern-C# topics and are not active in `_toc.yml`. | File scan and `_toc.yml`. | Move/archive/relabel after the Ch12 database assignment pass. |
| Old collection source notebooks | `chapters/08-collections/1101-intro-ds.ipynb` and `1102-collection-examples.ipynb` remain outside `_toc.yml` as source material for later reuse. | File scan and Ch08/Ch13 planning docs. | Keep out of the active TOC; mine remaining stack, queue, or tuple material only when it supports later chapters. |
| Ch08 stale merge source | `chapters/08-collections/0802-list-dictionary.ipynb` is not active in `_toc.yml`. | File scan and Ch08 `MATERIALS.md`. | Merge any useful material into `0802-list.ipynb` and `0803-dictionary.ipynb`, then archive or remove. |
| Legacy extra homework pages | Ch05, Ch09, and Ch10 list extra homework pages in `_toc.yml` in addition to standard Homework. | `_toc.yml`. | Decide whether these remain as extra homework, move under instructor-facing `assignments/`, or become extension pages. |
| Planning front matter | Older `MATERIALS.md` and `ORGANIZATION.md` files in Ch01-Ch10 and non-TOC staging tracks lack `orphan: true` front matter. | Planning-doc scan. | Add MyST front matter so excluded planning docs do not become warning sources. |
| Materials layout | Shared rule says runnable source should live in numbered `materials/NN/` folders. This project still mainly uses `materials/demos/` and `materials/examples/`. | `materials/` scan. | Decide whether to migrate to numbered folders or document CSCS as a legacy exception. |

## Deferrable Polish

| Area | Finding | Recommended action |
| ---- | ------- | ------------------ |
| Appendix landing draft | `chapters/appendices/appendix-intro.ipynb` exists but is not active in `_toc.yml`. | Add it to TOC only if appendices need a landing page; otherwise archive/remove. |
| Commented TOC entry | Ch01 has a commented `lab-versioncontrol` TOC entry and the file exists. | Keep commented if intentionally parked; otherwise archive or add as an explicit extension. |
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
