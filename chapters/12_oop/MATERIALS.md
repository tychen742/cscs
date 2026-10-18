# Materials: Inheritance, Interfaces, and Polymorphism

Active sections: `1201_inheritance`, `1202_polymorphism`, and `1203_interfaces`. Examples use discount policies, checkout components, employees, and payments. Each runnable cell is complete.

Preview, Lab, and Homework accompany the three sections. Runnable source and checks: `demos/12/policy_design/`. Older companion examples remain in `demos/12/oop_demo/` and `oop_lab/`.

The five former OOP notebooks are retained in `materials/stale_chapters/oop_before_design_split/`; their published URLs redirect to the revised coverage. Encapsulation and ordinary collaboration are developed in Chapters 10-11. The original chapter video is preserved. Slides remain pending.

## CS1 Preservation Follow-up (2026-10-17)

Supporting `1204_oop_examples.ipynb` retains original paradigm/pillar/separation-of-concerns context and Vehicle/Car, hiding/override, numeric/string/arity overloads, base/sealed and abstract-animal variations, plus a corrected abstract-class/interface table. Extra Practice retains all original Student/property and Shape/GetArea review tasks. Current policy/payment/checkout examples, assessments and three meetings remain.

The final source-list check also retains the original named array, reversal, and small abstract/interface variations in the corresponding supporting practice; see the preservation matrix for exact locations.

## Section-Boundary Coverage Disposition (2026-10-17)

**Reviewed plan, now implemented:** Retain the three conceptual boundaries. The disposition below records the preimplementation baseline and rationale. See Implemented Reading Organization for the current reading files. Counts in this baseline exclude fenced code from prose; the refreshed inventory is in authoring/content_size/. They flag review needs, not quality scores.

| Page at review baseline | Role in this review | Prose words | Markdown cells | Code cells |
| --- | --- | ---: | ---: | ---: |
| `1201_inheritance.ipynb`: Inheritance and Substitution | Core content | 757 | 17 | 4 |
| `1202_polymorphism.ipynb`: Runtime Polymorphism and Abstract Classes | Core content | 732 | 17 | 4 |
| `1203_interfaces.ipynb`: Interfaces and Interchangeable Components | Core content | 753 | 17 | 5 |
| `1204_oop_examples.ipynb`: OOP Examples and Variations | Supporting reading | 1,724 | 22 | 6 |

### Source-to-Destination Plan

| Existing source | Proposed treatment and coverage to preserve |
| --- | --- |
| `1201` | Retain inheritance/substitution and constructor chaining; develop traces through base and derived objects. |
| `1202` | Retain override/overload/hiding distinctions and abstract classes; use restored contrasting cases alongside the current policies. |
| `1203` | Retain interface/client collaboration and test doubles; develop the design choice among composition, interfaces and base classes. |
| `1204` | Keep all original OOP examples and variations as supporting reading; link each case at its prerequisite rather than turning the entire bank into a fourth core meeting. |

### Development Needed Before Moving Material

Add slower worked client-call reasoning, common failures and guided design comparisons. Supporting examples do not replace core explanation.

Before a later move, create a cell-level preservation map for these sources, including citations, figures, original code forms, worked traces, guided questions and independent exercise variants. Relocate prerequisite explanations from assignments into content when needed while retaining application requirements and IDs. A consolidated page must still teach its concepts; a split must not create two unsupported outlines. Existing runnable verification records describe earlier work, not verification of this proposal.

## Implemented Reading Organization (2026-10-17)

The section-boundary plan above is implemented in the current TOC. The earlier proposed sequence is retained as the decision record. Reading pages and teaching meetings remain separate units.

- `1201_inheritance.ipynb`: Inheritance and Substitution.
- `1202_polymorphism.ipynb`: Runtime Polymorphism and Abstract Classes.
- `1203_interfaces.ipynb`: Interfaces and Interchangeable Components.
- `1204_oop_examples.ipynb`: OOP Examples and Variations.

All pre-revision explanations and exercises are retained, with headings adjusted for coherent nesting. Added development includes topic-specific reasoning, worked state/decision tables and guided variations, rather than a word quota. See `authoring/section_revision/` for the original baseline, preservation evidence, online comparison sources and verification status. Code/build checks are recorded there, not inferred from this planning status.
