---
orphan: true
---

# Chapter Organization: Stacks & Queues

## Learning Objectives

Specify restricted-access contracts; trace stack and ring state; implement generic array stacks, bounded ring queues, and linked queues; reason from invariants; distinguish worst-case and amortized work; test boundary behavior; apply access policies to editing and service workflows.

## Instructional Sequence and Pacing

1. Stacks (about 35 minutes): LIFO and safe access, delimiter invariant, push/pop traces, generic implementation, correctness, and amortized growth.
2. Queues and deques (about 40 minutes): FIFO, wraparound, full versus empty, bounded-ring implementation, linked endpoints, logical-order growth, and both-end formulas.
3. Applications (about 35 minutes): access-policy choice, worklist discovery, undo/redo snapshots, fairness, costs, and contract verification.

The 110-minute plan includes student predictions and worked traces rather than reading every implementation line aloud. Existing exercises remain near the concepts they reinforce. Every completed cell is standalone; assignment stubs explicitly require completion.

## Assignments

Preview checks vocabulary and state distinctions. Lab builds one service-desk design through completed history, bounded arrivals, wrapped service, reference-model tests, and front restoration. Homework transfers the concepts to safe peek, ring growth, delimiter rejection, branch invalidation, and fair urgent scheduling. Five coding tasks accompany five true/false questions; answer cells retain verified output.

## Implementation and Verification

Use count rather than element values to determine emptiness. Validate before mutation, clear unused references, update linked endpoints after singleton removal, and copy logical order when growing a wrapped ring. Qualify allocation/growth costs instead of claiming every growable operation is O(1). The local source compares both queue representations with `Queue<int>` and the array stack with `Stack<int>` over reproducible mixed operations.

Lecture slide decks remain pending. Preserve the existing chapter video. The legacy `thebe-interactive` metadata remains until the shared Press UI and book-authoring tag migration is implemented.
