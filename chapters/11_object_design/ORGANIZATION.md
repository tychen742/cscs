# Organization: Object Design and Composition

## Objectives

Trace aliases; distinguish identity from business equality; select mutability and sharing policies; compose collaborating classes; preserve collection ownership; and test contracts independently of console input.

## Class Meetings

1. Objects, references, and state (40 minutes): reference diagrams, parameter passing, identity and SKU equality, mutability, immutability, copy depth, and nullable value/reference distinctions and flow warnings.
2. Composition and responsibilities (35 minutes): products, lines, orders, validation boundaries, computed totals, safe snapshots, required versus optional references, and constructor null guards.
3. Testing collaboration (35 minutes): arrange/act/assert, boundary tables, rejected changes, independent orders, refactoring a parallel-list design, and tests of rejected nulls and absent optional data.

Total: 110 minutes including prediction, traces, discussion, and code inspection. Assignments add guided and independent practice.

## Assessment

Preview: ten vocabulary multiple-choice items. Lab: five connected order-model tasks. Homework: five workplace true/false cases and five transfer coding tasks. Coding question cells are followed by hidden solutions with executed output. IDs use `cscs-object-design-*` and do not depend on future chapter numbering.

## Boundaries

Products and lines are immutable; each order owns its list. Repeated products create separate lines; SKU matching is case-sensitive. Snapshots copy the outer collection and share fixed line/product objects. Keep inheritance and interfaces in Chapter 12 and persistence in the optional database appendix. Video and slides remain pending.

## Nullability Supporting Reading (2026-10-16)

`1104_nullability.ipynb` relocates the deeper discussion from Chapter 6. Use its value/reference distinction and compiler warnings in meeting one, then conditional access and optional relationships in meeting two; integrate missing-data checks in meeting three. It is supporting reading, not a fourth required meeting. Keep basic null checks in earlier chapters. Explain that nullable annotations do not enforce runtime validity, null differs from empty/zero, and `!` suppresses warnings without validating data.

The relocated page retains existing code and cell metadata. Rewrite its record-based example around the chapter's ordinary classes and align its advanced LINQ/pattern practice in a later content pass; those exercises are extension material, not prerequisites. Add missing-data examples/tests and transfer appropriate assessment items with their original IDs before claiming complete assessment alignment. Core generics remain in Chapter 13; library generic collections can be read using the Chapter 8 foundation.
