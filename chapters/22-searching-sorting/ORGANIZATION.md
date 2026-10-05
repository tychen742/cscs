---
orphan: true
---

# Chapter Organization: Search and Sort

## Class Meetings

1. **Search contracts, 40 minutes.** Distinguish first, any, and all matches; choose equality/order policies; trace half-open binary search and missing targets; derive lower/upper bounds, count probes, and decode library return values.
2. **Elementary sort invariants, 40 minutes.** Trace swaps and sorted prefixes/suffixes; prove selection, strict-shift insertion, and shrinking-end bubble behavior; derive exact counts/inversion relationships; inspect record stability and library contracts.
3. **Compare complete workloads, 30 minutes.** Verify sorted permutations and equivalent query results; vary input order; interpret comparisons versus moves; include preparation, query, update, and storage costs in recommendations; connect the purchasing-report lab.

The 110-minute plan includes predictions, traces, discussion, and code inspection.

## Assignment Roles

The lab progresses from first-arrival scans through selection counts, stable invoice reports, full duplicate groups, and complete membership workloads. Homework transfers case-sensitive policies, independently checked boundaries, inversion counts, optimized bubble tests, and library failure encoding.

## Conventions and Scope

Count comparer calls once, excluding loop-bound checks. Separate swaps from shifts. All elementary sorts mutate arrays and use constant auxiliary state. Clone starting arrays for fair comparisons. Stable algorithms compare only the business key and preserve identity within ties. Searching requires matching order policies and retains IDs rather than confusing sorted positions with arrival indexes. Use workload evidence, not universal size cutoffs. Merge sort remains in Chapter 21; advanced sorting/timing and slides remain deferred.
