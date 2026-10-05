---
orphan: true
---
# Chapter Materials: Variables, Types, Operators, and I/O

## Active notebooks

- `0200-variables-types.ipynb`: orientation, existing video, learning outcomes, flow, and glossary.
- `0201-variables.ipynb`: declarations, initialization, state, assignment order, naming, var, const, and scope.
- `0202-data_types.ipynb`: meaning-driven types, overflow, precision/rounding, strings, assignment semantics, and conversions.
- `0203-operators.ipynb`: arithmetic and division, updates, comparisons, logical evaluation, and optional bit operations.
- `0206-input_output.ipynb`: prompt/read/parse, input assumptions, culture, formatting, and invoice alignment without loops.
- `assignments/index.ipynb`, `preview.ipynb`, `lab.ipynb`, and `homework.ipynb`: standard active assignment sequence.

## Runnable source

`materials/02/Invoice.cs` produces the final discounted invoice. `ReadInvoice.cs` reads a known-valid quantity and produces an undiscounted total. Run files independently with the .NET 10 SDK as documented in the directory README. Classroom rates and rounding are assumptions, not tax guidance.

## Depth pass, October 5, 2026

Repaired claims about implicit-conversion precision, decimal exactness, local defaults, stack/heap placement, string semantics, UTF-16 characters, numeric parsing, division result types, and format specifiers. Removed premature loop-based formatting and broad syntax inventories. Added state traces, stale-total explanations, boundary checks, explicit rounding, and guarded short-circuit arithmetic.

Preserved cross-reference anchors and the existing video. Standardized preview to ten MCQs and homework to five applied true/false questions plus five coding tasks. Rebuilt five connected invoice lab stages with sample input, independent setup, and retained answer output.

## Deferred work

Slides are book-owned content to author after content completion. Press provides delivery and access controls. Input-recovery logic and broader team workflows remain later topics.

## Verification results

All 47 completed notebook cells compiled and ran independently without compiler warnings; 14 hidden answers and all demonstrations retain verified stdout. The downloadable file-based apps also ran successfully. An independent decimal oracle matched 101 discounted invoices and checked displayed-component totals. Quotient/remainder and shipping checks matched 101 quantities; four valid input totals, five intentionally rejected parse cases, and a negative input accepted by Parse confirmed the documented assumptions. Full book build passed with three pre-existing warnings outside Chapter 2 (nullable lexer, preface lexer, and historical Mercurial cross-reference). Notebook schemas, indexed independent headings, final lesson footnotes, and assignment cell counts passed.

Six browser Runs passed: stale-total recalculation, midpoint rounding, short-circuit division, decimal-price input, three-line homework input, and final invoice. Narrow (545 px) and desktop (1280 px) document widths had no page overflow; the viewport override was reset. Rendered source downloads and assignment cards are present. Readable prose/code diff: `/tmp/ch02-depth.diff`; verification screenshot: `/tmp/ch02-browser-verification.png`.
