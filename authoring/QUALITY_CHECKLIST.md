# Quality Checklist — CSCS in C\#

Use before finalizing any chapter. Adapted from `rubrics/chapter-quality.md` in ai_shared.

## Structure

- [ ] Chapter covers one week's worth of content (100–120 min lecture)
- [ ] `NN01` covers major/overall concepts; `NN02+` each have a focused topic
- [ ] Sections are well organized and pedagogically sound
- [ ] All essential CS/IT topics for this chapter are included
- [ ] No topics that belong in another chapter

## Landing Page (`NN00-*.ipynb`)

- [ ] Numbered learning goals (measurable outcomes)
- [ ] Chapter table of contents (`{tableofcontents}`)
- [ ] Chapter glossary
- [ ] Only one `#` heading; all other headers are `<h2>` / `<h3>` raw HTML

## Content Notebooks

- [ ] Each `##` and `###` heading is in its own markdown cell with a blank line after
- [ ] Every `##` and `###` header has a Sphinx index entry
- [ ] Each section includes at least one code example
- [ ] Every content section ends with a Footnotes block (`{rubric} Footnotes`)
- [ ] All C# code examples compile and run correctly

## Assignments

- [ ] Preview quiz: 5–10 conceptual questions
- [ ] Lab: ~5 connected questions on one theme, each building on previous output
- [ ] Review (homework): 5–10 questions, majority coding practice

## Prose

- [ ] Second person ("you"), active voice
- [ ] Short paragraphs; breaks at concept boundaries
- [ ] No unexplained jargon on first use
- [ ] Conceptual parts explained clearly, not just syntax
