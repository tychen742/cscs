# Chapter Materials — Context and CS Ideas

## Landing Page

- `0100-getting-started.ipynb` — Chapter landing page

## Section Notebooks

- `0101-cs_ideas.ipynb` — CS ideas and problem solving
- `0102-dev_tools.ipynb` — Development tools and environment
- `0103-program_structure.ipynb` — First console application and program structure in C#

## Assignments

- `assignments/index.ipynb` — Index
- `assignments/lab.ipynb` — Lab
- `assignments/preview.ipynb` — Preview
- `assignments/homework.ipynb` — Homework

## Notes

- Source examples live in `materials/` at the project root.

- Section 1.3 uses an explicit `Main` console project and terminal `dotnet run`; namespaces are explained before Chapter 3.
- Project explanations connect VS Code Explorer, `.csproj` settings, compilation, and code organization; solution setup remains deferred.

## Runnable Demo Projects

- [`materials/01/hello_world/`](../../materials/01/hello_world/README.md): First console application.

All demo projects target .NET 10. Run commands and verification are documented
in `materials/README.md` and each project README.

- Git workflow instruction lives in Appendix C; Section 1.2 links to it.

Section 1.2 is a guided .NET 10/C# setup using Commons references for command-line,
editing, and REPL fundamentals. It opens with an orientation to the Microsoft
language and .NET ecosystem (C#, F#, Visual Basic, C++/CLI; console, web, MAUI,
and Windows desktop stacks). It directs students to install and verify the
.NET 10 SDK, then install VS Code and C# Dev Kit, and verify and manually install
any missing C# Dev Kit extension dependencies. The first saved console application
remains in Section 1.3.

The legacy Mercurial/Bitbucket version-control lab is archived at
`materials/_archived/01/lab-versioncontrol.ipynb`. Its motivation and two-computer
workflow now live in the Git and GitHub appendix, in Git terms.
