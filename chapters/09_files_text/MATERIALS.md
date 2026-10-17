# Chapter Materials — Files and Text

## Landing Page

- `0900_files_text.ipynb` — Chapter landing page

## Section Notebooks

- `0901_stream_file.ipynb` — Streams and file basics
- `0902_file_operations.ipynb` — File read / write operations
- `0903_text_operations.ipynb` — Text processing: splitting, token validation, safe replacement, structured records. Basic string methods (cleaning, immutability, searching, `Substring`, `Replace`) moved to `05_methods/0504_strings.ipynb` on 2026-10-04.
- `0906_regex.ipynb` — Regular expressions

## Assignments

- `assignments/hw_gradefiles.ipynb` — Hw Gradefiles
- `assignments/index.ipynb` — Index
- `assignments/lab.ipynb` — Lab
- `assignments/preview.ipynb` — Preview
- `assignments/homework.ipynb` — Homework

## Notes

- Source examples live in `demos/` at the project root.
- Clean up section headings in `0902_file_operations.ipynb` so StreamWriter, StreamReader, paths, and directories appear as coherent subsections rather than competing notebook-level titles.

## Runnable Demo Projects

- [`demos/09/file_demo/`](../../demos/09/file_demo/README.md): Read a bundled file of integers.

All demo projects target .NET 10. Run commands and verification are documented
in `demos/README.md` and each project README.

## Integrated Responsibility Practice (2026-10-15)

Optional `0905_privacy_security.ipynb` extends personal-data masking, validation, and safe logging. Retained `assignments/privacy_index.ipynb`, `privacy_preview.ipynb`, `privacy_lab.ipynb`, and `privacy_homework.ipynb` preserve former ethics assessments and IDs. Source reference: `demos/09/privacy_pass_lab_solution.cs`. SQL injection demonstration now lives in the database appendix.

## AI Literacy Integration (2026-10-15)

The text-processing lesson adds a prepared AI-review activity for a synthetic stock import: specify the schema, reject malformed/out-of-range records, and preserve original input. Prompt privacy and response validation accompany the code. Live assistant use is optional and subject to course policy.

## Restored CS1 Material (2026-10-17)

- `assignments/additional_practice.ipynb`: restored explanations and exercises; retains current lessons and assignment IDs.
- `assignments/help_responses.ipynb`: restored explanations and exercises; retains current lessons and assignment IDs.

The file-driven collections lab follows Files; Chapter 8 links forward to it. Downloadable starter: `demos/09/help_responses_lab.zip`.
