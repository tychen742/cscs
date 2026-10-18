# Pass 7: Standalone Compile-and-Run of Every Demonstration Cell (2026-10-18)

Every code cell in the 95 content-section notebooks of Chapters 1-26 was
extracted and run on its own as a .NET 10 top-level program with stdin closed.
Practice starters were skipped (cells containing `Your code starts here`,
`/* TODO`, `// Exercise`, or the `thebe-interactive` tag).

| Measure | Count |
| --- | --- |
| Demonstration cells run | 604 |
| Practice starters skipped | 93 |
| Cells that compiled and ran cleanly | 597 |
| Cells that did not | 7 |

## The seven non-passing cells

| Page | Cell | Result | Classification |
| --- | --- | --- | --- |
| 2.4 Types and Conversion | `f7191c06` (`int i = d;`) | CS0266 | Intentional: the text shows that assigning a `double` to an `int` fails to compile. |
| 2.4 Types and Conversion | `874b96a2` (unescaped quotation marks) | CS1003 | Intentional: the text introduces escape characters by showing the syntax error at (1,18). |
| 2.4 Types and Conversion | `2239a9b4` (`Console.ReadLine()` age) | NullReferenceException with stdin closed | Keyboard input by design; runs in the browser kernel, which prompts for input. |
| 4.1 Iteration | `51e60a41` (`int.Parse(Console.ReadLine())`) | ArgumentNullException with stdin closed | Keyboard input by design; same as above. |
| 6.3 Testing | `0a9d014c` (`BasicMaths` class) | CS5001 no entry point | Declaration-only cell for the NUnit example; valid in the REPL kernel. |
| 9.6 Regular Expressions | `bfaec7ea` (`using System.Text.RegularExpressions;`) | CS5001 no entry point | Declaration-only cell; valid in the REPL kernel. |
| 7.2 Two-Dimensional Arrays | `c9f57b8a` (jagged array `table2`) | CS1002 `;` expected, three lines | Genuine defect. Fixed in this pass: semicolons added after the three row initializers. The cell now prints `55` and the three `Element [i] Array:` lines shown in its comments. |

No other defects were found. The run logs are in the session scratchpad
(`pass7_out1.txt` to `pass7_out4.txt`).
