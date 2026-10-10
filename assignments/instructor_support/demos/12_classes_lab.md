# Instructor Walkthrough: 12/classes_lab

**Role:** Completed legacy exercise; not a current lab solution.

**Supports:** [1203_class_instance](../../../chapters/12_classes/1203_class_instance.ipynb). This relationship does not imply the code is an answer to an assignment.

**Source and student run instructions:** [project README](../../../materials/12/classes_lab/README.md); [project file](../../../materials/12/classes_lab/classes_lab.csproj).

## Run Before Class

From the repository root:

```bash
dotnet run --project materials/12/classes_lab/classes_lab.csproj
```

Verified output:

```text
Employee: John 100000
Employee: John 100000
Employee: John 100000
```

## Explain the Code

Default execution calls TestAnimal.main and prints the Employee example. guess constructs a GuessGame object; static-guess calls Game.main.

## Teaching Sequence

Start with the default output, then compare instance and static game modes with a bound of 1 and a guess of 0.

## Common Mistakes and Boundaries

Lowercase main helpers are ordinary methods reached from Program.Main. The default test routine currently leaves most Animal actions commented out.

## Check Understanding

Ask the learner to explain which statement produces one observed result, predict a small change, and verify that prediction. For a test suite, ask which assertion would fail for a changed operation.
