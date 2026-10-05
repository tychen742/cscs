---
orphan: true
---
# Chapter Materials: Getting Started with C#

## Active notebooks

- `0100-getting-started.ipynb`: orientation, existing video, outcomes, glossary, and chapter links.
- `0101-cs_ideas.ipynb`: problem modeling, algorithms, sequential execution, representations, compilation, and checking.
- `0102-dev_tools.ipynb`: SDK/editor setup, terminal context, console-project workflow, and local Git history.
- `0103-program_structure.ipynb`: execution workflows, entry points, namespace, syntax, and optional solution workspace.
- `assignments/index.ipynb`, `preview.ipynb`, `lab.ipynb`, and `homework.ipynb`: active assignment sequence.

## Runnable source

`materials/01/ServiceDesk.cs` is the final lab report. `ServiceDeskMain.cs` illustrates explicit Main. Run each independently with the .NET 10 SDK; the directory README gives commands. Generated project/build files remain outside the repository.

## Depth pass, October 5, 2026

Replaced jargon-heavy introductions with worked business models, predictions, trace questions, and boundary cases. Corrected address-space versus installed-memory claims and the compiler/runtime explanation. Distinguished program entry-point syntax from files, projects, and solution organization. Replaced disconnected assignments with ten preview questions, a five-stage lab, and five true/false plus five coding homework questions.

Verification covers independent notebook examples and answers, retained answer stdout, file-based and console-project executions, explicit Main, the .NET 10 .slnx workspace, local Git staging/commit behavior, and the book build.

## Inactive and deferred material

`assignments/lab-versioncontrol.ipynb` is historical Mercurial source, excluded from the published TOC. Slides are authored by the book after content completion; Press handles distribution and access controls.

All 21 completed notebook code cells compiled and ran independently. The 13 hidden answers retain verified stdout. Project, explicit Main, file-based app, solution, and local Git workflows passed. The full book build and subsequent metadata correction build succeeded; four existing warnings outside Chapter 1 remain. Adding the namespace target resolves the prior Chapter 10 cross-reference warning.
