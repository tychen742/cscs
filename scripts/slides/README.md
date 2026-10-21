# Lecture slide tools

The builder and theme originate from `ai_shared/templates/chapter-slides/`.
The local builder also preserves lesson links as PowerPoint hyperlinks.
It keeps classroom font sizes, moves long check questions below a short title,
and uses light links and emphasis on dark slide backgrounds.

Install the locked dependencies once:

```sh
npm ci --ignore-scripts --prefix scripts/slides
```

Build a chapter's student HTML and editable instructor PowerPoint:

```sh
node scripts/slides/build.mjs _html_extra/chapters/01_context/0100_slides.md --pptx-dir assignments/slides
```

Commit the Markdown, generated HTML, and instructor PowerPoint together.
Every slide requires teaching notes; every C# example requires verified output.
Notes are omitted from the student HTML. PowerPoints remain outside the public
book build. Chapter title notes list the starting slide for each part.

After building the book, stage student assets with the same command used in CI:

```sh
.venv/bin/python scripts/stage_lecture_slides.py
```

The staging script excludes Markdown and PowerPoint files. Do not recursively
copy the whole source directory into a public build.

Verify standalone C# examples and then output/preservation checks:

```sh
.venv/bin/python scripts/verify_slide_examples.py
.venv/bin/python scripts/verify_lecture_slides.py --html-dir _build/html
```

The visual renderer requires Pillow in the Python environment. Office XML
validation uses the shared PowerPoint skill's validator and its lxml/defusedxml
dependencies. Neither tool is needed by the deployment staging step.

For visual QA, Marp can export slide images using the same local theme:

```sh
scripts/slides/node_modules/.bin/marp _html_extra/chapters/01_context/0100_slides.md --html --allow-local-files --images png --theme-set scripts/slides/thinkpress-lecture.css --output /tmp/cscs_slides/slide.png
```

Inspect every slide, check the PowerPoint with the Office validator, and verify
part-start notes before committing. Preview quizzes precede class; labs provide
guided practice; homework follows class. Slides reference existing assessments
without creating new assessment IDs.
