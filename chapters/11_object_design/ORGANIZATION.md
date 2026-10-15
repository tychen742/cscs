# Organization: Object Design and Composition

## Objectives

Trace aliases; distinguish identity from business equality; select mutability and sharing policies; compose collaborating classes; preserve collection ownership; and test contracts independently of console input.

## Class Meetings

1. Objects, references, and state (35 minutes): reference diagrams, parameter passing, identity and SKU equality, mutability, immutability, and copy depth.
2. Composition and responsibilities (40 minutes): products, lines, orders, validation boundaries, computed totals, and safe snapshots.
3. Testing collaboration (35 minutes): arrange/act/assert, boundary tables, rejected changes, independent orders, and refactoring a parallel-list design.

Total: 110 minutes including prediction, traces, discussion, and code inspection. Assignments add guided and independent practice.

## Assessment

Preview: ten vocabulary multiple-choice items. Lab: five connected order-model tasks. Homework: five workplace true/false cases and five transfer coding tasks. Coding question cells are followed by hidden solutions with executed output. IDs use `cscs-object-design-*` and do not depend on future chapter numbering.

## Boundaries

Products and lines are immutable; each order owns its list. Repeated products create separate lines; SKU matching is case-sensitive. Snapshots copy the outer collection and share fixed line/product objects. Keep inheritance and interfaces in Chapter 12 and persistence in the optional database appendix. Video and slides remain pending.
