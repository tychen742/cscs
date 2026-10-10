---
marp: true
theme: default
paginate: true
style: |
  /* ── Base ── */
  section {
    font-family: 'Segoe UI', system-ui, sans-serif;
    font-size: 20px;
    color: #1a1a1a;
    padding: 30px 50px 60px 50px;
    background: white;
  }

  /* ── Headings ── */
  h1 { color: #2a6b37; font-size: 1.8em; border-bottom: 3px solid #b8860b; padding-bottom: 8px; margin-bottom: 16px; }
  h2 { color: #2a6b37; font-size: 1.35em; margin-bottom: 10px; }
  h3 { color: #b8860b; font-size: 1.05em; margin-bottom: 6px; }
  ul { margin-left: 1.2em; }
  li { margin-bottom: 4px; line-height: 1.4; }

  /* ── Title slide ── */
  section.title {
    background: #2a6b37; color: white;
    text-align: center;
    display: flex; flex-direction: column; align-items: center; justify-content: center;
  }
  section.title h1 { color: white; border: none; font-size: 2.2em; }
  section.title p   { color: #c8e6c9; font-size: 0.95em; }

  /* ── Section divider ── */
  section.section {
    background: #2a6b37; color: white;
    text-align: center;
    display: flex; flex-direction: column; align-items: center; justify-content: center;
  }
  section.section h2 { color: white; border: none; font-size: 1.9em; }
  section.section p  { color: #c8e6c9; font-size: 0.95em; }

  /* ── Two-column layout ── */
  .cols     { display: grid; grid-template-columns: 1fr 1fr; gap: 18px; align-items: start; }
  .cols.r46 { grid-template-columns: 4fr 6fr; }
  .cols.r64 { grid-template-columns: 6fr 4fr; }

  /* ── Callout boxes ── */
  .callout      { background: #e8f5eb; border-left: 4px solid #2a6b37; border-radius: 4px; padding: 7px 11px; margin: 8px 0; font-size: 0.72em; line-height: 1.35; }
  .callout.warn { background: #fff8e1; border-color: #b8860b; }
  .callout.rule { background: #f0f4ff; border-color: #5577cc; }

  /* ── Code ── */
  pre { background: #f6f8fa !important; border: 1px solid #d0e8d4; border-radius: 6px; margin: 8px 0; font-size: 0.68em; line-height: 1.35; }
  code { color: #c7254e; background: #f6f8fa; border: 1px solid #e0e0e0; border-radius: 3px; padding: 1px 4px; }
  pre code { color: inherit; background: none; border: none; padding: 12px 14px; }

  /* ── Tables ── */
  table { font-size: 0.68em; border-collapse: collapse; width: 100%; }
  th { background: #2a6b37; color: white; padding: 5px 8px; text-align: left; }
  td { padding: 5px 8px; border-bottom: 1px solid #e0e0e0; }
  tr:nth-child(even) td { background: #f7faf7; }

  /* ── Pagination ── */
  section::after { color: #aaa; font-size: 0.7em; }
---

<!-- _class: title -->

# Chapter 1

Getting Started with C#

*Sections: Computing Ideas & Process · Development Tools · Program Structure*

*← → or Space to navigate · F for fullscreen*

---

<!-- _class: section -->

## Computing Ideas & Process

How a program moves from an idea to running code

---

## From Source Code to Running Program

- **IPO Model** — every program takes Input, Processes it, produces Output
- **Compilation** translates C# source into machine-runnable code *before* the program runs
- **Interpretation** executes source code directly, line by line, no separate compile step
- C# is a **compiled** language — the compiler catches many mistakes before your program ever runs

<div class="callout">

An algorithm is a precise, step-by-step procedure — code is one way to write an algorithm down.

</div>

---

## Compiler vs. Interpreter

<div class="cols">
<div>

**Compiled languages**

- Translated to machine code first
- Errors caught at compile time
- Fast to run (C#, C, Rust)

<div class="callout rule">

C# compiles to an intermediate form, then the .NET runtime executes it.

</div>

</div>
<div>

**Interpreted languages**

- Executed directly, line by line
- Errors surface only when that line runs
- Slower, but flexible (Python, JavaScript)

</div>
</div>

---

<!-- _class: section -->

## Development Tools

The tools you'll use every day in this course

---

## Your C# Toolchain

- **.NET SDK** — the tools that build and run .NET/C# programs
- **VS Code** — free, cross-platform editor with a C# extension
- **Terminal / Shell** — where you'll run `dotnet` commands
- **csharprepl** — an interactive REPL for trying out expressions one at a time

<div class="callout">

Setup once, use all semester: install the .NET SDK and VS Code before the next class meeting.

</div>

---

## Git Basics

<div class="cols">
<div>

**Core habits**

- `git status` before you do anything
- Small, frequent commits
- Write commit messages that explain *why*

</div>
<div>

**Single-developer loop**

```
git add .
git commit -m "message"
git push
```

</div>
</div>

---

<!-- _class: section -->

## Program Structure

What every C# program looks like

---

## Anatomy of a C# Program

- A **Console App** runs in a terminal, not a window
- `Program.cs` holds the program's entry point
- Modern C# uses **top-level statements** — no explicit `Main` method wrapper needed
- A **Solution** groups one or more **Projects** together

```csharp
// Program.cs — top-level statements
Console.WriteLine("Hello, C#!");
```

---

## Quick Reference

| Concept | Syntax / Notes |
|---|---|
| Print to console | `Console.WriteLine("text");` |
| New console project | `dotnet new console` |
| Build and run | `dotnet run` |
| Code block | `{ }` groups statements together |
| Statement terminator | every statement ends in `;` |

---

<!-- _class: title -->

# End of Chapter 1

*Next: Chapter 2 — Variables & Types*
