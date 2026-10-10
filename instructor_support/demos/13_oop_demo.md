# Instructor Walkthrough: 13/oop_demo

**Role:** Concept companion across the OOP sections.

**Supports:** [1304_polymorphism](../../chapters/13_oop/1304_polymorphism.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../demos/13/oop_demo/README.md); [project file](../../demos/13/oop_demo/oop_demo.csproj).

## Run Before Class

From the repository root:

```bash
dotnet run --project demos/13/oop_demo/oop_demo.csproj
```

Verified output:

```text
Balance: 1300
Tuut, tuut!
Ford Mustang
The animal makes a sound
1 The dog says: bow wow
The animal makes a sound
The animal makes a sound
Two integers: 5
Three integers: 13
Two floats: 25
hello world
Drawing a circle.
Area: 314.16
Drawing a rectangle.
Area: 12.00
Drawing a triangle.
Area: 6.00
Student: Alex Chen, age 20
IA.M
```

## Explain the Code

Main demonstrates account methods, inherited vehicle members, virtual dispatch, explicit method hiding, overloads, abstract Shape implementations, properties, and a default interface method.

## Teaching Sequence

Teach it in small pieces. Trace an Animal reference to Dog, contrast Cat hiding, then compare shape areas 12 and 6.

## Common Mistakes and Boundaries

Cat uses new to hide a method rather than override it. Account withdrawals have no business-policy validation. This demonstration is not a production banking implementation.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
