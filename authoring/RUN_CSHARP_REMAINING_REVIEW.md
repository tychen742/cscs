# Run C# — remaining cells needing human review

Updated 2026-09-16. Supersedes the original Category-C-only version of this file.

Of 184 total REPL-pattern cells (92 bare-expression + 92 cross-cell-reference), **100 were fixed and compiler-verified** and are now live. The **84 below still need a human decision** — either because they are genuinely broken in a way that needs content judgment, or because they were never really REPL/cross-cell cells to begin with (intentional exercises, syntax templates, fragments).

## Reverted after a fix attempt (real issues found, not mechanically fixable) — 15 cells

- `chapters/02-var_data/0202-data_types.ipynb` cell 45 (Type Conversion): definite-assignment teaching claim is inaccurate for C# locals; needs content judgment
- `chapters/02-var_data/0206-input_output.ipynb` cell 31 (Composite formatting): prose text was inside the code cell, not a real expression
- `chapters/02-var_data/assignments/lab.ipynb` cell 6 (User Input): intentional '...' student fill-in stub
- `chapters/02-var_data/assignments/review.ipynb` cell 1 (Chapter Review): likely an intentional operator-precedence/type-error prediction exercise
- `chapters/04-decision/0401-intro-decision.ipynb` cell 5 (Boolean Expressions): trailing prose text was inside the code cell
- `chapters/05-iteration/0502-for-statements.ipynb` cell 13 (Nested `for` Loop): pure pseudocode outline (outer-Loop/inner-Loop aren't valid identifiers), not real code
- `chapters/05-iteration/0502-for-statements.ipynb` cell 15 (Nested `for` Loop): pure pseudocode outline with literal '....' placeholders
- `chapters/05-iteration/0503-while-statement.ipynb` cell 1 (While-Statements): pure syntax template with literal *condition* markdown-emphasis leak
- `chapters/05-iteration/0503-while-statement.ipynb` cell 6 (While-Statements): stray markdown blockquote '>' plus trailing prose telling reader to use csharprepl/VS Code
- `chapters/05-iteration/assignments/lab.ipynb` cell 32 (Sum To `n`): intentional '...' student fill-in stub for a method body
- `chapters/07-arrays/0702-twodim.ipynb` cell 11 (Rectangular Arrays (Two Dimensional)): my transform incorrectly touched a multi-line array-initializer continuation; needs a hand fix
- `chapters/08-collections/0802-list-dictionary.ipynb` cell 2 (Generics): bare 'List<T>' generic-syntax notation, not a real expression
- `chapters/06-files-text/0602-file-operations.ipynb` cell 13 (Reading to End of Stream): needs a real file to read (StreamReader on 'reader') -- can't self-contain without adding file-creation code first, needs individual review
- `chapters/06-files-text/assignments/lab.ipynb` cell 10 (Copy to Upper Case): needs real files for both reader and writer -- can't self-contain without adding file-creation code first, needs individual review
- `chapters/12-oop/1204-polymorphism.ipynb` cell 2 (Method Overriding: virtual/override/base): cell is missing a Cat class entirely (myCat.animalSound() called with no Cat type or instance anywhere) -- needs the same structural fix as cell 5, individual review

## Never real REPL bare-expression cells (Category A false positives) — 27 cells

These had a compile error code that looked REPL-shaped but the actual cell is something else: real typos, an intentional debugging exercise, prose accidentally left inside a code cell, or a deliberately-incomplete guided-construction fragment.

### `chapters/02-var_data/0202-data_types.ipynb` cell 31 — Escape Special Characters
```csharp
string toBe1 = ""To be, or not to be" is a speech given by Prince Hamlet.";
```

### `chapters/02-var_data/assignments/review.ipynb` cell 5 — Chapter Review
```csharp
   int x= (int)5.8;
   double y = (double)6;
   char c = (char)('a' + 1)
   int z = (int)'a' + 1;

```

### `chapters/04-decision/assignments/review.ipynb` cell 13 — Chapter Review
```csharp
    public class Test1
    {
       public static void Main(String[] args)
       {
          int x = 3;
          if (x > 0
                Console.WriteLine("x is greater than 0")
          else
                Console.WriteLine(x is less than or equal 0");
       }
    }

```

### `chapters/05-iteration/0503-while-statement.ipynb` cell 4 — While-Statements
```csharp
    int i = 4;
    while (i < 9)
    {
       Console.WriteLine(i);
       i = i + 2;
    }

Compare the preceding code to the code loop below:

```

### `chapters/05-iteration/0503-while-statement.ipynb` cell 5 — While-Statements
```csharp
int i = 4; while (i < 9)
{
i = i + 2;
Console.WriteLine(i);
}


    Do they produce the same result? Now, compare the preceding code with the following:

```

### `chapters/05-iteration/0503-while-statement.ipynb` cell 12 — String Operations
```csharp
while (i < s.Length) {

```

### `chapters/05-iteration/0503-while-statement.ipynb` cell 21 — Strange Sequence Exercise
```csharp
Jump(3) = 3*3+1 = 10; Jump(10) = 10/2 = 5;
Jump(5) = 3*5+1 = 16; Jump(16) = 16/2 = 8;
Jump(8) = 8/2  =   4; Jump(4) =   4/2 = 2;
Jump(2) = 2/2  =   1

```

### `chapters/05-iteration/0503-while-statement.ipynb` cell 24 — Roundoff Exercise II
```csharp
/// Return the largest possible number y, so in C#: x+y = x
/// If x is Infinity return Infinity.
/// If x is -Infinity, return double.MaxValue.
/// Assume x is not NaN (which is equal to nothing).
static double Epsilon(double x)

```

### `chapters/05-iteration/assignments/lab.ipynb` cell 13 — Reversed String Return
```csharp
// this is a method return a string `s` in reverse order.
// say, if s is "drab", return "bard".
// below is the possible form of the header for the method
static string Reverse (string s)

```

### `chapters/05-iteration/assignments/lab.ipynb` cell 15 — Reversed String Return
```csharp
for (int i = s.Length - 1; i >= 0; i--) {

```

### `chapters/05-iteration/assignments/lab.ipynb` cell 27 — Number Guessing Game
```csharp
    static void Game()

```

### `chapters/05-iteration/assignments/lab.ipynb` cell 40 — Sum To `n`
```csharp
while (i <= n) {

```

### `chapters/05-iteration/assignments/lab.ipynb` cell 44 — Sum To `n`
```csharp
int sum = 1, i = 2;
while (i <= n) {
   int newSum = sum + i;
   sum = newSum:
   i = i + 1;
}

```

### `chapters/05-iteration/assignments/lab.ipynb` cell 51 — Loan Table
```csharp
/// Print a loan table, showing payment number, principal at the
/// beginning of the payment period, interest over the period, and
/// payment at the end of the period.
/// The principal is the initial amount of the loan.
/// The rate is fraction representing the rate of interest per PAYMENT.
/// The periodic regular payment is also specified.
public static void LoanTable(decimal principal, decimal rate,
                             decimal payment)

```

### `chapters/06-files-text/assignments/lab.ipynb` cell 4 — Example: Sum Numbers in File
```csharp
bool File.Exists(string filenamePath)

```

### `chapters/06-files-text/assignments/lab.ipynb` cell 7 — Safe Sum File
```csharp
   // Prompt the user to enter a file name to open for reading.
   // Repeat until the name of an existing file is given.
   // Open and return the file.
   public static StreamReader PromptFile(string prompt)

```

### `chapters/06-files-text/assignments/review.ipynb` cell 1 — Chapter Review
```csharp
   if (inFile.ReadLine().Contains("!")) {
      Console.WriteLine(inFile.ReadLine() + "\n contains the symbol !")
   }

```

### `chapters/07-arrays/0702-twodim.ipynb` cell 14 — Advanced topic: Array of Arrays
```csharp
// declare the array of three elements
int[][] table2 = new int[3][];

// initialize the array elements
table2[0] = new int[4] {2, 3, 7, 55}
table2[1] = new int[4] {3, 1, 8, 10}
table2[2] = new int[2] {6, 0}

// access an element by row and column index
Console.WriteLine(table2[0][3]);    // output 55

// display the array elements:
for (int i = 0; i < table2.Length; i++)
{
   System.Console.Write($"Element [{i}] Array: ");
   for (int j = 0; j < table2[i].Length; j++)
         Console.Write($"{table2[i][j]} ");
   Console.WriteLine();
}     // output:
      // Element [0] Array: 2 3 7 55
      // Element [1] Array: 3 1 8 10
      // Element [2] Array: 6 0

```

### `chapters/07-arrays/assignments/review.ipynb` cell 7 — Chapter Review
```csharp
    static void f(int num)
    //...

```

### `chapters/07-arrays/assignments/review.ipynb` cell 11 — Chapter Review
```csharp
    static void f(int[] nums)
    //...

```

### `chapters/08-collections/0802-list-dictionary.ipynb` cell 23 — List Constructors and Methods
```csharp
Console.WriteLine(words)
```

### `chapters/08-collections/0802-list.ipynb` cell 23 — List Constructors and Methods
```csharp
Console.WriteLine(words)
```

### `chapters/08-collections/assignments/review.ipynb` cell 3 — Chapter Review
```csharp
    words.Clear()

    words = new List<string>();

```

### `chapters/11-classes/assignments/hw-booklist.ipynb` cell 2 — Book class
```csharp
public Book(string title, string author, int year)

```

### `chapters/11-classes/assignments/hw-booklist.ipynb` cell 4 — Book class
```csharp
public string GetTitle()

public string GetAuthor()

public int GetYear()

```

### `chapters/11-classes/assignments/hw-booklist.ipynb` cell 6 — Book class
```csharp
public override string ToString()

```

### `chapters/11-classes/assignments/hw-booklist.ipynb` cell 11 — BookList class
```csharp
public BookList()

```

## Never attempted (Category B) — 42 cells, 4 subtypes

### Pure syntax-template pseudocode (e.g. `type variableName = value;`, `if (condition) {...}`) — should become a plain markdown code block, not a runnable cell (9 cells)

- `chapters/02-var_data/0201-variables.ipynb` cell 4 (Declaring Local Variables)
- `chapters/04-decision/0401-intro-decision.ipynb` cell 6 (Boolean Expressions)
- `chapters/04-decision/0402-ifstatement.ipynb` cell 7 (else-if Statements)
- `chapters/04-decision/0406-switch.ipynb` cell 2 (Switch Statement)
- `chapters/04-decision/assignments/review.ipynb` cell 3 (Chapter Review)
- `chapters/04-decision/assignments/review.ipynb` cell 5 (Chapter Review)
- `chapters/05-iteration/0502-for-statements.ipynb` cell 27 (Step in loop header)
- `chapters/05-iteration/0502-for-statements.ipynb` cell 29 (Step in loop header)
- `chapters/05-iteration/assignments/lab.ipynb` cell 46 (Sum To `n`)

### Depends on the book's custom UI/UIF input-helper class (materials/examples/ui/) — needs either inlining that class or rewriting with plain Console.ReadLine() (6 cells)

- `chapters/02-var_data/0206-input_output.ipynb` cell 9 (User Input: The UI class)
- `chapters/04-decision/assignments/lab.ipynb` cell 5 (`if-else` Exercise)
- `chapters/04-decision/assignments/lab.ipynb` cell 7 (`if-else` Exercise)
- `chapters/05-iteration/0503-while-statement.ipynb` cell 36 (`do-while` Example: Right Triangle)
- `chapters/06-files-text/0602-file-operations.ipynb` cell 11 (Reading to End of Stream)
- `chapters/08-collections/assignments/lab.ipynb` cell 9 (The FakeHelp Class)

### References an undeclared METHOD, not a variable — needs real design work (what should it return/do), not a fake declaration (19 cells)

- `chapters/03-methods/assignments/lab.ipynb` cell 4 (Return Statement)
- `chapters/03-methods/assignments/lab.ipynb` cell 8 (Return Statement)
- `chapters/03-methods/assignments/lab.ipynb` cell 10 (Return Statement)
- `chapters/03-methods/assignments/review.ipynb` cell 1 (Chapter Review)
- `chapters/03-methods/assignments/review.ipynb` cell 3 (Chapter Review)
- `chapters/03-methods/assignments/review.ipynb` cell 7 (Chapter Review)
- `chapters/03-methods/assignments/review.ipynb` cell 9 (Chapter Review)
- `chapters/03-methods/assignments/review.ipynb` cell 11 (Chapter Review)
- `chapters/04-decision/assignments/lab.ipynb` cell 10 (Calculate Weekly Wages)
- `chapters/04-decision/assignments/review.ipynb` cell 1 (Chapter Review)
- `chapters/06-files-text/0603-text-operations.ipynb` cell 27 (Structured Lines)
- `chapters/07-arrays/assignments/lab.ipynb` cell 3 (Lab: Arrays)
- `chapters/07-arrays/assignments/review.ipynb` cell 9 (Chapter Review)
- `chapters/07-arrays/assignments/review.ipynb` cell 13 (Chapter Review)
- `chapters/08-collections/0802-list-dictionary.ipynb` cell 37 (List Constructors and Methods)
- `chapters/08-collections/0802-list.ipynb` cell 39 (Exercise: Generic List)
- `chapters/08-collections/assignments/lab.ipynb` cell 6 (The FakeHelpVerbose Class)
- `chapters/09-datastructure/0901-intro-ds.ipynb` cell 34 (Destructuring)
- `chapters/11-classes/assignments/hw-booklist.ipynb` cell 13 (BookList class)

### "Predict the output across scenarios //a/b/c/d" reasoning exercise — likely never meant to run as one program; consider markdown instead (4 cells)

- `chapters/04-decision/assignments/review.ipynb` cell 7 (Chapter Review)
- `chapters/04-decision/assignments/review.ipynb` cell 9 (Chapter Review)
- `chapters/04-decision/assignments/review.ipynb` cell 11 (Chapter Review)
- `chapters/12-oop/1205-abstraction.ipynb` cell 10 (!powershell)

### all_names_locally_redeclared_already (4 cells)

- `chapters/11-classes/assignments/hw-booklist.ipynb` cell 9 (BookList class)
- `chapters/12-oop/1204-polymorphism.ipynb` cell 13 (Method Overloading)
- `chapters/12-oop/1205-abstraction.ipynb` cell 4 (Abstract Classes)
- `chapters/13-exceptions-testing/1303-testing.ipynb` cell 3 (Simple Testing)

## Original Category C (mixed/other, from the first scan pass) — 38 cells

Unchanged since 2026-09-16 first pass — full per-cell source/error list in the sibling file `authoring/RUN_CSHARP_REVIEW_CATEGORY_C_DETAIL.md`.
