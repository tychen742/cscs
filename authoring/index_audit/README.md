# Full subject-index audit

The earlier repair addressed parser fragments but left the index largely organized around teaching headings and automatically grouped keyword lists. This review covers all 1,435 distinct entries and their 1,920 indexed locations. Each entry has a disposition, reason, source link, enclosing heading and passage excerpt. All local targets exist. No lesson, notebook, source directive, or production page was changed in this audit.

| Decision | Entries | Meaning |
| --- | ---: | --- |
| Retain | 232 | Useful topical term; keep the indexed location, with house-style normalization during revision. |
| Rewrite | 750 | Replace a heading, activity title, vague phrase, duplicate form, or bare API name with a useful subject term. |
| Restructure | 419 | Review the subject/subentry relationship; separate distinct concepts and qualify API ownership. |
| Remove from index | 34 | Navigation, front matter, generic activity, or assessment administration. Keep the actual material. |

These are editorial recommendations, not claims that 1,203 lessons are wrong. “Restructure” includes conservative flags where a relationship should be made explicit. The same underlying problem can affect many entries.

## Highest-priority findings

1. **Misleading relationships.** `last in first out → Enqueue/Dequeue` mixes stack and queue policies. The indexed lesson correctly distinguishes LIFO and FIFO. `namespace → entry point` buries Main under a different concept. `tree height → tree depth` needs two definitions, not an implied equivalence.
2. **Wrong or ambiguous API lookup.** `string → Parse` can imply `string.Parse`; the lesson points to numeric parsing. `ReadLines` is a local example helper, not a `List<T>` API. Bare `Add`, `Count`, and `Length` need owning type/context and property/method distinctions. Preserve exact `Push`, `Pop`, `Enqueue`, and `Dequeue` capitalization.
3. **Heading catalog rather than subject vocabulary.** Entries such as “A Boolean Result Answers a Question,” “Guide a Last-Element Check,” and “Verify Delivery Routes Independently” belong in the lesson. Index the underlying concepts instead. Do not rename or shorten the teaching headings to repair the index.
4. **Remaining source artifacts.** `function → parameter parameter`, `dictionary → Keys Keys property`, and `generics < > for generics` remain malformed. `Shortest Paths and String Matching` is stale at its current graph path-reconstruction location.
5. **Missing direct access and cross-references.** Straightforward main entries are missing for recursion, dynamic programming, debugging, exception handling, structs, records, inheritance, polymorphism, binary search, linear search, insertion sort, selection sort, bubble sort, Dijkstra, Kruskal, KMP, BFS, and DFS. Related headings exist, but students should not need to guess them. All 1,920 collected entries are `single`; there are no explicit `see` or `seealso` relationships.
6. **Duplicate forms and peripheral entries.** Consolidate search/searching, singular/plural types, operator categories, and generic type names. Remove subject-index entries for cover/title page, assessment setup and submission, while retaining their normal navigation. Label legacy tools as historical where retained.

## Recommended revision

Use an explicit reviewed mapping from each existing entry/location to zero or more canonical subject entries. Preserve every lesson and anchor. Use concise noun phrases and exact API names, independent access for distinct concepts, hierarchical subentries only for genuine subtopics, and `see`/`seealso` for aliases and related terms. Replace automatic heading indexing and blanket semicolon expansion with explicit semantics. Keep the complete mapping as review evidence; fail verification on unresolved source entries rather than silently guessing.

Verify both directions: every retained destination exists and teaches the indexed concept; every essential concept in the chapter coverage plans has an accessible lookup entry. Then rebuild, inspect all alphabetical groups, verify aliases/cross-references, and compare the subject index against the reviewed mapping. No implementation or deployment is part of this audit.

## Evidence

- `review.json`: every entry, disposition, source location, heading and excerpt.
- `entries.json`: original collected entries and all locations.
- `summary.json`: completeness and link-target totals.
- `index.html`: searchable full ledger, including retained entries.
- `scripts/audit_subject_index.py`: review ledger generation and inventory validation against the local preview build. Editorial classifications are explicit review decisions in the script.
