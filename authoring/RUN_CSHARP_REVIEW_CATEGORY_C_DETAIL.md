# Run C# review — Category C (mixed/other), 2026-09-16

Follow-up from the book-wide compile scan (see thinkcscs.md project memory for full context).
Category A (92 cells, REPL-style bare expressions) and Category B (92 cells, cross-cell variable references) are being fixed as content edits — see [[thinkcscs]].
This file tracks Category C: the 38 cells that did not fit either pattern cleanly. Needs individual review — mix of pure syntax-template pseudocode, likely-intentional teaching errors, method-only fragments with no entry point, and at least one confirmed typo.

## `chapters/02-var_data/0202-data_types.ipynb` cell 24 — Creating a String
Error codes: CS0165

```csharp
#pragma warning disable CS8632

using System.Runtime.InteropServices;

string message1;                // Declare without initializing.
string? message2 = null;        // Initialize to null.
string message3 = System.String.Empty;  // Initialize as an empty string use the Empty constant instead of the literal "".
string oldPath = "c:\\Program Files\\Microsoft Visual Studio 8.0";  // Initialize with a regular string literal.
string newPath = @"c:\Program Files\Microsoft Visual Studio 9.0";   // Initialize with a verbatim string literal.
System.String greeting = "Hello World!";    // Use System.String if you prefer.
var temp = "I'm still a strongly-typed System.String!"; // In local variables (i.e. within a method body) you can use implicit typing.
const string message4 = "You can't get rid of me!"; // Use a const string to prevent 'message4' from being used to store another string value.
char[] letters = { 'A', 'B', 'C' }; // Use the String constructor only when creating a string from a char*, char[], or sbyte*. See System.String documentation for details.
string alphabet = new string(letters);

Console.WriteLine("1. " + message1);
Console.WriteLine("2. " + message2);
Console.WriteLine("3. " + message3);
Console.WriteLine("4. " + oldPath);
Console.WriteLine("5. " + newPath);
Console.WriteLine("6. " + greeting);
Console.WriteLine("7. " + temp);
Console.WriteLine("8. " + message4);
Console.WriteLine("9. " + letters);
Console.WriteLine("10. " + alphabet);

#pragma warning restore CS8632
```

## `chapters/02-var_data/0202-data_types.ipynb` cell 43 — Type Conversion
Error codes: CS0266

```csharp
double d = 2.0;
int i = d;
```

## `chapters/03-methods/0303-parameter.ipynb` cell 7 — Method Tracing
Error codes: CS5001

```csharp
public static void inchesToCentimeters(double i)    // parameter with type
{
    double c = i * 2.54;
    printInCentimeters(i, c);
}

public static void printInCentimeters(double inches, double centimeters)
{
    Console.WriteLine(inches + "-->" + centimeters);
}

public static void main(String[] args)
{
    inchesToCentimeters(10);
}
```

## `chapters/05-iteration/0501-iteration.ipynb` cell 1 — Iteration
Error codes: CS8803

```csharp
using System;
// namespace IntroCSCS
// {
#pragma warning disable CS7022
internal class Chapter05
{
    public static void Main(string[] args)
    {
        Console.Write("1 ");
        Console.Write("2 ");
        Console.Write("3 ");
        Console.Write("4 ");
        Console.Write("5 ");
        Console.Write("6 ");
        Console.Write("7 ");
        Console.Write("8 ");
        Console.Write("9 ");
        Console.Write("10 ");
        // output: 1 2 3 4 5 6 7 8 9 10
        Console.WriteLine();
    }
}
#pragma warning restore CS7022
// }

Chapter05.Main(null);
```

## `chapters/05-iteration/assignments/lab.ipynb` cell 24 — Number in Range [1…100]
Error codes: CS0117, CS1503

```csharp
var num = int.Parse(Console.WiteLine());
while (num < 1 && num > 100)
{
   Console.WriteLine("Invalid number!");
   num = int.Parse(Console.WriteLine());
}
Console.WriteLine("The number is: {{10}", num);
```

## `chapters/06-files-text/0606-regex.ipynb` cell 1 — Regular Expressions
Error codes: CS5001

```csharp
using System.Text.RegularExpressions;
```

## `chapters/07-arrays/assignments/homework.ipynb` cell 3 — Homework
Error codes: CS0200

```csharp
    char[] a = {'n', 'o', 'w'};
    a[0] = 'c';

    string s = "now";
    s[0] = 'c';
```

## `chapters/08-collections/0802-list-dictionary.ipynb` cell 19 — List Constructors and Methods
Error codes: CS0103, CS0201

```csharp
words[0];
words[2];
words[2] = "Coconut";
words;
```

## `chapters/08-collections/0802-list-dictionary.ipynb` cell 27 — List Constructors and Methods
Error codes: CS0103, CS0201

```csharp
words.Count;
```

## `chapters/08-collections/0802-list.ipynb` cell 19 — List Constructors and Methods
Error codes: CS0103, CS0201

```csharp
words[0];
words[2];
words[2] = "Coconut";
words;
```

## `chapters/08-collections/0802-list.ipynb` cell 27 — List Constructors and Methods
Error codes: CS0103, CS0201

```csharp
words.Count;
```

## `chapters/11-classes/1102-properties.ipynb` cell 7 — Default ToString behavior
Error codes: CS1022

```csharp
namespace IntroCSCS
{
class Animal
{
public string name;
public Animal(string name)
{
this.name = name; }
}
}

public class TestAnimal
{
public static void Main()
{
Animal frog = new Animal("Froggy");
Console.WriteLine(frog.ToString()); ///// print: IntroCSCS.Animal; Animal is the type
Console.WriteLine(frog.name); ///// print: Froggy
}
}
}
```

## `chapters/11-classes/1104-operator-overloading.ipynb` cell 4 — Pictorial Playing Computer
Error codes: CS5001

```csharp
public struct SomeMath
{
   // ...
}
```

## `chapters/11-classes/assignments/hw-booklist.ipynb` cell 18 — Extra Credit
Error codes: CS0026

```csharp
   Console.Write(this);
```

## `chapters/11-classes/assignments/homework.ipynb` cell 1 — Homework
Error codes: CS5001

```csharp
    class DoMath
    {
        public int Sum(int num1, int num2)
        {
            var total = num1 + num2;
            return total;
        }
    }
```

## `chapters/11-classes/assignments/homework.ipynb` cell 3 — Homework
Error codes: CS5001

```csharp
    static class SomeMath
    {
        public static int Sum(int a, int b)
        {
            return a + b;
        }
    }
```

## `chapters/11-classes/assignments/homework.ipynb` cell 5 — Homework
Error codes: CS5001

```csharp
    class Customer
    {
        // Fields, properties, methods and events go here...
    }
```

## `chapters/12-oop/1204-polymorphism.ipynb` cell 8 — Method Overriding: virtual/override/base
Error codes: CS0239

```csharp
public class Shape
{
public virtual void Draw()
{
Console.WriteLine("Drawing a shape");
}
}

public class Circle : Shape
{
public override void Draw()
{
base.Draw(); // Call the implementation in the base class
Console.WriteLine("Drawing a circle");
}
}

public class Rectangle : Shape
{
public sealed override void Draw() // note the "sealed" keyword
{
Console.WriteLine("Drawing a rectangle");
}
}

public class Triangle : Shape
{
public override void Draw()
{
Console.WriteLine("Drawing a triangle");
}
}

public class Square : Rectangle
{
// This will cause a compile-error because the Draw method is sealed in the Rectangle class
public override void Draw()
{
Console.WriteLine("Drawing a square");
}
}
```

## `chapters/12-oop/1205-abstraction.ipynb` cell 2 — Abstract Classes
Error codes: CS5001

```csharp
abstract class Shape
{
    public abstract double GetArea();
}
```

## `chapters/12-oop/1205-abstraction.ipynb` cell 14 — !powershell
Error codes: CS5001

```csharp
abstract class Shape
{
    public abstract double GetArea();
    public abstract double GetPerimeter();
}

class Rectangle : Shape
{
    private double width;
    private double height;

    public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public override double GetArea()
    {
        return width * height;
    }

    public override double GetPerimeter()
    {
        return 2 * (width + height);
    }
}
```

## `chapters/12-oop/1205-abstraction.ipynb` cell 16 — Interfaces
Error codes: CS5001

```csharp
interface Animal
{
    void animalSound();     ///// interface method (does not have a body)
    void run();             ///// interface method (does not have a body)
}
```

## `chapters/06-exceptions-testing/1301-error-handling.ipynb` cell 8 — File I/O with Safe Handling
Error codes: CS0841

```csharp
string path = "scores.txt";

try
{
    using StreamReader reader = new StreamReader(path);
    string? line;
    while ((line = reader.ReadLine()) != null)
        Console.WriteLine(line);
}
catch (FileNotFoundException)
{
    Console.WriteLine($"Could not find file: {path}");
}
catch (UnauthorizedAccessException)
{
    Console.WriteLine("Permission denied while reading the file.");
}
catch (IOException ex)
{
    Console.WriteLine($"I/O error: {ex.Message}");
}
```

## `chapters/06-exceptions-testing/1303-testing.ipynb` cell 6 — The Unit Testing Process
Error codes: CS5001

```csharp
    public class BasicMaths
    {
       public double Add(double num1, double num2) {
          return num1 + num2;
       }
       public double Subtract(double num1, double num2) {
          return num1 - num2;
       }
       public double divide(double num1, double num2) {
          return num1 / num2;
       }
       public double Multiply(double num1, double num2) {
          // To trace error while testing, writing + operator instead of * operator.
          return num1 + num2;
       }
    }
```

## `chapters/14-selected-topics/assignments/lab.ipynb` cell 4 — Part 2: Lambdas and LINQ
Error codes: CS8803

```csharp
record Product(string Name, string Category, double Price);

var products = new List<Product>
{
    new("Laptop",     "Electronics", 999.99),
    new("Phone",      "Electronics", 699.00),
    new("Headphones", "Electronics", 149.99),
    new("Desk",       "Furniture",   349.00),
    new("Chair",      "Furniture",   199.00),
    new("Notebook",   "Stationery",    4.99),
    new("Pen",        "Stationery",    1.49),
};

// 2a. Names of Electronics under $500, sorted by price ascending
// 2b. Average price per category (use GroupBy)
// 2c. Most expensive product overall
// 2d. Total revenue if all products sold once
```

## `chapters/15-modern-csharp/1502-records.ipynb` cell 3 — Value-Based Equality
Error codes: CS8803

```csharp
record Point(int X, int Y);

var a = new Point(1, 2);
var b = new Point(1, 2);
var c = new Point(3, 4);

Console.WriteLine(a == b);   // True  — same values
Console.WriteLine(a == c);   // False
Console.WriteLine(a);        // Point { X = 1, Y = 2 }
```

## `chapters/15-modern-csharp/1502-records.ipynb` cell 5 — `with` Expressions
Error codes: CS8803

```csharp
record Person(string Name, int Age);

var alice = new Person("Alice", 30);
var olderAlice = alice with { Age = 31 };

Console.WriteLine(alice);       // Person { Name = Alice, Age = 30 }
Console.WriteLine(olderAlice);  // Person { Name = Alice, Age = 31 }
Console.WriteLine(alice == olderAlice);  // False
```

## `chapters/15-modern-csharp/1502-records.ipynb` cell 7 — Deconstruction
Error codes: CS8803

```csharp
record Point(int X, int Y);

var p = new Point(3, 7);
var (x, y) = p;
Console.WriteLine($"x={x}, y={y}");  // x=3, y=7
```

## `chapters/15-modern-csharp/1502-records.ipynb` cell 10 — Init-Only Properties
Error codes: CS8803

```csharp
record Person
{
    public string Name { get; init; } = "";
    public int    Age  { get; init; }
}

var p = new Person { Name = "Alice", Age = 30 };
Console.WriteLine(p);  // Person { Name = Alice, Age = 30 }

// p.Age = 31;  // compile error — init-only after construction

// Works fine in object initializer:
var q = p with { Age = 31 };  // creates a copy
Console.WriteLine(q);  // Person { Name = Alice, Age = 31 }
```

## `chapters/15-modern-csharp/1503-nullable.ipynb` cell 8 — Chaining `?.` and `??`
Error codes: CS8803

```csharp
record Order(string? CustomerName, Address? ShippingAddress);
record Address(string City, string Zip);

Order? order = null;

// Safe deep access with fallback
string city = order?.ShippingAddress?.City ?? "Unknown";
Console.WriteLine(city);  // Unknown
```

## `chapters/15-modern-csharp/1504-generics.ipynb` cell 5 — Generic Classes
Error codes: CS8803

```csharp
// A minimal generic pair
class Pair<T1, T2>
{
    public T1 First  { get; }
    public T2 Second { get; }

    public Pair(T1 first, T2 second) { First = first; Second = second; }

    public override string ToString() => $"({First}, {Second})";
}

var p1 = new Pair<string, int>("Alice", 30);
var p2 = new Pair<double, bool>(3.14, true);

Console.WriteLine(p1);  // (Alice, 30)
Console.WriteLine(p2);  // (3.14, True)
```

## `chapters/15-modern-csharp/1505-async.ipynb` cell 4 — `async` and `await`
Error codes: CS8421

```csharp
using System.Net.Http;

// async marks the method as asynchronous
static async Task<string> FetchAsync(string url)
{
    using var client = new HttpClient();
    // await suspends THIS method until the HTTP call finishes
    // — the thread is free to do other work meanwhile
    string content = await client.GetStringAsync(url);
    return content[..200];  // first 200 chars
}

string result = await FetchAsync("https://example.com");
Console.WriteLine(result);
```

## `chapters/15-modern-csharp/Assignments/1508-lab-solutions.ipynb` cell 4 — Part 2: Record Types
Error codes: CS8803

```csharp
record Temperature(double Celsius)
{
    public double Fahrenheit => Celsius * 9.0 / 5.0 + 32;
}

var a = new Temperature(100);
var b = new Temperature(100);
Console.WriteLine(a == b);         // True
Console.WriteLine(a.Fahrenheit);   // 212

record Person(string Name, int Age);
var sam = new Person("Sam", 20);
for (int age = 21; age <= 23; age++)
{
    sam = sam with { Age = age };
    Console.WriteLine(sam);
}
```

## `chapters/15-modern-csharp/Assignments/1508-lab-solutions.ipynb` cell 6 — Part 3: Nullable Operators
Error codes: CS8803

```csharp
static int SafeParse(string? input)
{
    return int.TryParse(input, out var n) ? n : 0;
}

var names = new List<string?> { "Alice", null, "Bob", null, "Carol" };
var safeNames = names.Select(n => n ?? "Anonymous").ToList();
Console.WriteLine(string.Join(", ", safeNames));

record Address(string City);
record User(string Name, Address? Address);
User? user = new User("Jane", new Address("Boston"));
Console.WriteLine(user?.Address?.City ?? "No city");
```

## `chapters/15-modern-csharp/Assignments/1508-lab-solutions.ipynb` cell 8 — Part 4: Generics
Error codes: CS8803

```csharp
static T[] Repeat<T>(T value, int count)
{
    return Enumerable.Repeat(value, count).ToArray();
}

var ints  = Repeat(7, 4);      // [7, 7, 7, 7]
var words = Repeat("hi", 3);   // ["hi", "hi", "hi"]
Console.WriteLine(string.Join(", ", ints));
Console.WriteLine(string.Join(", ", words));

static T Max<T>(T a, T b) where T : IComparable<T>
{
    return a.CompareTo(b) >= 0 ? a : b;
}

Console.WriteLine(Max(3, 7));
Console.WriteLine(Max(3.14, 2.71));
Console.WriteLine(Max("apple", "pear"));

class Pair<T1, T2>
{
    public T1 First  { get; }
    public T2 Second { get; }
    public Pair(T1 first, T2 second) { First = first; Second = second; }
    public Pair<T2, T1> Swap() => new Pair<T2, T1>(Second, First);
}

var pair    = new Pair<string, int>("hello", 42);
var swapped = pair.Swap();
Console.WriteLine($"{swapped.First}, {swapped.Second}");  // 42, hello
```

## `chapters/15-modern-csharp/Assignments/1508-lab-solutions.ipynb` cell 12 — Stretch Challenge
Error codes: CS8803

```csharp
abstract record Shape;
record Circle(double Radius) : Shape;
record Rectangle(double Width, double Height) : Shape;
record Triangle(double Base, double Height) : Shape;

double Area(Shape s) => s switch
{
    Circle(var r) => Math.PI * r * r,
    Rectangle(var w, var h) => w * h,
    Triangle(var b, var h) => 0.5 * b * h,
    _ => 0
};

string Describe(Shape? s) => s switch
{
    null => "No shape",
    var shape => $"Area: {Area(shape)}"
};
```

## `chapters/15-modern-csharp/Assignments/lab.ipynb` cell 4 — Part 2: Record Types
Error codes: CS8803

```csharp
record Temperature(double Celsius)
{
    public double Fahrenheit => Celsius * 9.0 / 5.0 + 32;
}

var a = new Temperature(100);
var b = new Temperature(100);
Console.WriteLine(a == b);         // True
Console.WriteLine(a.Fahrenheit);   // 212

record Person(string Name, int Age);
var sam = new Person("Sam", 20);
// TODO: produce sam at ages 21, 22, 23 using `with`
```

## `chapters/15-modern-csharp/Assignments/lab.ipynb` cell 6 — Part 3: Nullable Operators
Error codes: CS8803

```csharp
static int SafeParse(string? input)
{
    // TODO
    throw new NotImplementedException();
}

var names = new List<string?> { "Alice", null, "Bob", null, "Carol" };
// TODO: replace nulls with "Anonymous"

// Part 3c
record Address(string City);
record User(string Name, Address? Address);
User? user = null;  // try with a real user too
// TODO: safe one-liner
```

## `chapters/15-modern-csharp/Assignments/lab.ipynb` cell 8 — Part 4: Generics
Error codes: CS8803

```csharp
static T[] Repeat<T>(T value, int count)
{
    // TODO
    throw new NotImplementedException();
}

var ints  = Repeat(7, 4);      // [7, 7, 7, 7]
var words = Repeat("hi", 3);   // ["hi", "hi", "hi"]
Console.WriteLine(string.Join(", ", ints));
Console.WriteLine(string.Join(", ", words));

static T Max<T>(T a, T b) where T : IComparable<T>
{
    // TODO
    throw new NotImplementedException();
}

Console.WriteLine(Max(3, 7));
Console.WriteLine(Max(3.14, 2.71));
Console.WriteLine(Max("apple", "pear"));

class Pair<T1, T2>
{
    public T1 First  { get; }
    public T2 Second { get; }
    public Pair(T1 first, T2 second) { First = first; Second = second; }
    public Pair<T2, T1> Swap() => new Pair<T2, T1>(Second, First);
}

var pair    = new Pair<string, int>("hello", 42);
var swapped = pair.Swap();
Console.WriteLine($"{swapped.First}, {swapped.Second}");  // 42, hello
```
