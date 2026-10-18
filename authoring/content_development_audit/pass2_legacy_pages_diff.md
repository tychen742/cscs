---
orphan: true
---

# Pass 2 diff: legacy pages 10.1, 10.2, 7.1, 7.2, 4.4, 9.1, 9.2 (2026-10-18)

Cell-level record of every change. Lines starting with - and + are edits to existing cells; entries marked "new ... cell" were inserted after the named cell.

```diff
### chapters/10_classes/1001_class_syntax.ipynb cell 2ee50e56 citation
-  variable and may have a different value for each instance of a type. [1]
+  variable and may have a different value for each instance of a type.[^1001_class_syntax-field]

### chapters/10_classes/1001_class_syntax.ipynb cell d1471367 citation
-- Access Modifiers: The default access for a class type is internal. Basic levels of access for a class include [2] :  
+- Access Modifiers: The default access for a class type is internal. Basic levels of access for a class include:[^1001_class_syntax-access]

### chapters/10_classes/1001_class_syntax.ipynb cell d1471367 citation
-  - **internal**: Access is limited to the current assembly. [3]
+  - **internal**: Access is limited to the current assembly.[^1001_class_syntax-internal]

### chapters/10_classes/1001_class_syntax.ipynb cell 2dbfe984-a25a-4b83-97a2-571b7757cdde footnotes
+[^1001_class_syntax-field]: See [What is the difference between a field and a property?](https://stackoverflow.com/questions/295104/what-is-the-difference-between-a-field-and-a-property).
+[^1001_class_syntax-access]: Microsoft, C# language reference: [Accessibility Levels](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/accessibility-levels).
+[^1001_class_syntax-internal]: Microsoft, C# language reference: [internal](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/internal).

### chapters/10_classes/1001_class_syntax.ipynb + new markdown cell after d1471367 Declaring Classes worked example
+ The pattern above is the smallest possible class. The runnable version below gives `Customer` one field for the name, one for the credit limit, and one method that uses both. The class is only a description until the `new` expression creates an object from it; the two statements after `new` store values in that object's fields, and the method call reads them back.

### chapters/10_classes/1001_class_syntax.ipynb + new code cell after d1471367 Declaring Classes worked example
+ using System;
+ 
+ Customer first = new Customer();       // create one object from the class
+ first.Name = "Avery Chen";             // store state in its fields
+ first.CreditLimit = 2500m;
+ Console.WriteLine(first.Describe());   // a method reads the object's own fields
+ 
+ public class Customer
+ {
+     public string Name = "";
+     public decimal CreditLimit;
+ 
+     public string Describe()
+     {
+         return $"{Name} may charge up to {CreditLimit:F2}";
+     }
+ }

### chapters/10_classes/1001_class_syntax.ipynb + new markdown cell after d1471367 Declaring Classes worked example
+ The output is `Avery Chen may charge up to 2500.00`. Two mistakes are common at this point. Declaring the variable without `new`, as in `Customer first;` followed by `first.Name = ...`, does not compile, because no object exists yet. Naming the class `customer` compiles but breaks the PascalCase convention that lets a reader tell a type from a variable at a glance. The fields here are public so the example stays short; the Properties section shows the protected form that real classes use.

### chapters/10_classes/1001_class_syntax.ipynb cell df26bbdd fence indented code (1 blocks)
-    internal class Program
-    {
-       static void Main(string[] args)
-       {
-          DoMath doMath = new DoMath();    // create an object using the new keyword
-          int aSum = doMath.Sum(2, 2);     // use the [object].[method] syntax to use the methods
-          Console.WriteLine(aSum);         // output 4
-       }
-    }
+```csharp
+internal class Program
+{
+   static void Main(string[] args)
+   {
+      DoMath doMath = new DoMath();    // create an object using the new keyword
+      int aSum = doMath.Sum(2, 2);     // use the [object].[method] syntax to use the methods
+      Console.WriteLine(aSum);         // output 4
+   }
+}
-    class DoMath                           // class accessability level is default to internal
-    {
-       public int Sum(int num1, int num2)
-       {
-          var total = num1 + num2;
-          return total;
-       }
-    }
+class DoMath                           // class accessability level is default to internal
+{
+   public int Sum(int num1, int num2)
+   {
+      var total = num1 + num2;
+      return total;
+   }
+}
+```

### chapters/10_classes/1001_class_syntax.ipynb cell df26bbdd label pattern
-using the `new` keyword and 2) use the dot notation (`.`) to access a method defined in DoMath:
+using the `new` keyword and 2) use the dot notation (`.`) to access a method defined in DoMath. This is the project form with a `Main` method, shown as a pattern:

### chapters/10_classes/1001_class_syntax.ipynb + new markdown cell after df26bbdd Using a Class worked example
+ In this book's runnable cells the top-level statements play the role of `Main`, so the same example looks like this:

### chapters/10_classes/1001_class_syntax.ipynb + new code cell after df26bbdd Using a Class worked example
+ using System;
+ 
+ DoMath doMath = new DoMath();      // create an object using the new keyword
+ int aSum = doMath.Sum(2, 2);       // [object].[method] runs the method on that object
+ Console.WriteLine(aSum);
+ Console.WriteLine(doMath.Sum(10, 32));
+ 
+ class DoMath                       // accessibility defaults to internal
+ {
+     public int Sum(int num1, int num2)
+     {
+         int total = num1 + num2;
+         return total;
+     }
+ }

### chapters/10_classes/1001_class_syntax.ipynb + new markdown cell after df26bbdd Using a Class worked example
+ The output is `4` and then `42`. `doMath` is a variable of type `DoMath`, exactly as `reader` was a variable of type `StreamReader`; the dot after it selects a member of that one object. Calling `DoMath.Sum(2, 2)` on the class name does not compile here, because `Sum` is an instance method and needs an object to run on. The next section explains the one kind of class where the class name is the right receiver.

### chapters/10_classes/1001_class_syntax.ipynb cell 84beb7c2 fence indented code (1 blocks)
-    internal class Program
-    {
-       static void Main(string[] args)
-       {
-          CheckID check = new CheckID("taylor swift");
-       }
-    }
+```csharp
+internal class Program
+{
+   static void Main(string[] args)
+   {
+      CheckID check = new CheckID("taylor swift");
+   }
+}
-    class CheckID
-    {
-       public string name;           // this is an instance field (variable)
-       public CheckID(string name)
-       {
-          this.name = name;          // The "this" keyword refers to the current instance of the class
-       }
+class CheckID
+{
+   public string name;           // this is an instance field (variable)
+   public CheckID(string name)
+   {
+      this.name = name;          // The "this" keyword refers to the current instance of the class
+   }
-       public void PrintResult()
-       {
-          // ... if ID for this name exists ...
-          Console.WriteLine($"{name} has an existing ID!"); // using the "name" variable in method
-       }                             // output "taylor swift has an existing ID!"
-       // ....
-       // ....
-    }
+   public void PrintResult()
+   {
+      // ... if ID for this name exists ...
+      Console.WriteLine($"{name} has an existing ID!"); // using the "name" variable in method
+   }                             // output "taylor swift has an existing ID!"
+   // ....
+   // ....
+}
+```

### chapters/10_classes/1001_class_syntax.ipynb + new markdown cell after 84beb7c2 Constructors worked example and practice
+ `CheckID` stores the name but never shows it. The runnable version below completes the idea: a `Contact` whose constructor copies all three parameters into fields, and a `Print` method that proves each object kept its own state.

### chapters/10_classes/1001_class_syntax.ipynb + new code cell after 84beb7c2 Constructors worked example and practice
+ using System;
+ 
+ Contact first = new Contact("Marie Ortiz", "773-508-7890", "mortiz2@example.edu");
+ Contact second = new Contact("Otto Heinz", "773-508-9999", "oheinz@example.edu");
+ first.Print();
+ second.Print();
+ 
+ class Contact
+ {
+     private string name, phone, email;
+ 
+     public Contact(string fullName, string phoneNumber, string emailAddress)
+     {
+         name = fullName;          // copy each parameter into a field
+         phone = phoneNumber;
+         email = emailAddress;
+     }
+ 
+     public void Print()
+     {
+         Console.WriteLine($"Name: {name}, Phone: {phone}, Email: {email}");
+     }
+ }

### chapters/10_classes/1001_class_syntax.ipynb + new markdown cell after 84beb7c2 Constructors worked example and practice
+ Each `new Contact(...)` runs the constructor once with its own arguments, so the first line printed is Marie's record and the second is Otto's. The parameters `fullName`, `phoneNumber`, and `emailAddress` disappear when the constructor returns; the fields keep the values for as long as the object exists.
+ 
+ A common mistake is to declare the fields a second time inside the constructor:
+ 
+ ```csharp
+ public Contact(string fullName, string phoneNumber, string emailAddress)
+ {
+     string name = fullName;    // LOGICAL ERROR: a new local variable, not the field
+     string phone = phoneNumber;
+     string email = emailAddress;
+ }
+ ```
+ 
+ This compiles, but the three locals vanish at the closing brace and the fields keep their default value, `null`. `Print` would then show empty values. Fields are declared once, outside every method and constructor; inside them, use the field name without a type.

### chapters/10_classes/1001_class_syntax.ipynb + new markdown cell after 84beb7c2 Constructors worked example and practice
+ ```{index} Guided Practice: Build a Product Class
+ ```
+ 
+ ### Guided Practice: Build a Product Class

### chapters/10_classes/1001_class_syntax.ipynb + new markdown cell after 84beb7c2 Constructors worked example and practice
+ Complete `Product` so that the constructor stores both parameters and `LineTotal` multiplies the stored price by the quantity. Expected output: `10.00` and then `PEN-01 x 4 = 10.00`.

### chapters/10_classes/1001_class_syntax.ipynb + new code cell after 84beb7c2 Constructors worked example and practice
+ using System;
+ 
+ Product pen = new Product("PEN-01", 2.50m);
+ Console.WriteLine(pen.LineTotal(4).ToString("F2"));
+ Console.WriteLine(pen.Describe(4));
+ 
+ class Product
+ {
+     private string code = "";
+     private decimal price;
+ 
+     public Product(string productCode, decimal unitPrice)
+     {
+         // Your code starts here.
+         // Store both parameters in the fields.
+         // Your code ends here.
+     }
+ 
+     public decimal LineTotal(int quantity)
+     {
+         // Your code starts here.
+         return 0m;
+         // Your code ends here.
+     }
+ 
+     public string Describe(int quantity)
+     {
+         return $"{code} x {quantity} = {LineTotal(quantity):F2}";
+     }
+ }

### chapters/10_classes/1001_class_syntax.ipynb + new code cell after 84beb7c2 Constructors worked example and practice
+ using System;
+ 
+ // Solution
+ Product pen = new Product("PEN-01", 2.50m);
+ Console.WriteLine(pen.LineTotal(4).ToString("F2"));
+ Console.WriteLine(pen.Describe(4));
+ 
+ class Product
+ {
+     private string code = "";
+     private decimal price;
+ 
+     public Product(string productCode, decimal unitPrice)
+     {
+         code = productCode;
+         price = unitPrice;
+     }
+ 
+     public decimal LineTotal(int quantity)
+     {
+         return price * quantity;
+     }
+ 
+     public string Describe(int quantity)
+     {
+         return $"{code} x {quantity} = {LineTotal(quantity):F2}";
+     }
+ }

### chapters/10_classes/1001_class_syntax.ipynb + new markdown cell after 84beb7c2 Constructors worked example and practice
+ The starter prints `0.00` twice because `price` is never stored and `LineTotal` ignores it. Variation: add a second constructor parameter check that rejects a negative price with an exception, as Chapter 6 showed, and confirm that `new Product("PEN-01", -1m)` fails before any line total is computed.

### chapters/10_classes/1001_class_syntax.ipynb cell 61aae2b0 fence indented code (3 blocks)
-    static class SomeMath
-    {
-       public static int Sum(int a, int b)    // a public static method
-       {
-          return a + b;
-       }
-    }
+```csharp
+static class SomeMath
+{
+   public static int Sum(int a, int b)    // a public static method
+   {
+      return a + b;
+   }
+}
+```
-    internal class Program
-    {
-       static void Main(string[] args)
-       {
-          int aSum = SomeMath.Sum(2, 2);
-          Console.WriteLine(aSum);      // output 4
-       }
-    }
+```csharp
+internal class Program
+{
+   static void Main(string[] args)
+   {
+      int aSum = SomeMath.Sum(2, 2);
+      Console.WriteLine(aSum);      // output 4
+   }
+}
+```
-    double dub = -3.14;
-    Console.WriteLine(Math.Abs(dub));               // 3.14
-    Console.WriteLine(Math.Floor(dub));             // -4
-    Console.WriteLine(Math.Round(Math.Abs(dub)));   // 3
+```csharp
+double dub = -3.14;
+Console.WriteLine(Math.Abs(dub));               // 3.14
+Console.WriteLine(Math.Floor(dub));             // -4
+Console.WriteLine(Math.Round(Math.Abs(dub)));   // 3
+```

### chapters/10_classes/1001_class_syntax.ipynb + new markdown cell after 61aae2b0 Static classes worked example
+ Run the two forms side by side. `SomeMath.Sum` and the `Math` methods are called through the class name; no object is created anywhere in this cell.

### chapters/10_classes/1001_class_syntax.ipynb + new code cell after 61aae2b0 Static classes worked example
+ using System;
+ 
+ Console.WriteLine(SomeMath.Sum(2, 2));       // class name, then the method
+ double dub = -3.14;
+ Console.WriteLine(Math.Abs(dub));
+ Console.WriteLine(Math.Floor(dub));
+ Console.WriteLine(Math.Round(Math.Abs(dub)));
+ 
+ static class SomeMath
+ {
+     public static int Sum(int a, int b)       // a public static method
+     {
+         return a + b;
+     }
+ }

### chapters/10_classes/1001_class_syntax.ipynb + new markdown cell after 61aae2b0 Static classes worked example
+ The output is `4`, `3.14`, `-4`, and `3`. Compare this with `DoMath` earlier: an instance method needs `new DoMath()` first and then `doMath.Sum`, while a static method is reached as `SomeMath.Sum`. Writing `new SomeMath()` does not compile, because a static class cannot be instantiated. Choose static when the method needs no per-object state, as with arithmetic; choose instances when each object carries its own data, as with contacts and products.

### chapters/10_classes/1002_properties.ipynb cell 0ad059f5 replace stale note with intro and syntax
-Although the content are still valid, this section will be updated later to reflect
-the more current syntax and discussion of properties such as in [Using Properties](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-properties#the-get-accessor).
+A **property** is a class member that a caller reads and writes like a field, while the class decides what each read or write actually does. Properties appear as public data members, but they are implemented as small methods called *accessors*: `get` runs when the property is read, `set` runs when it is assigned. That is why C# code almost never exposes a public field: a property gives the same convenient syntax and keeps the class in control.
-A property is a member that provides a flexible mechanism to read, write, or compute
-the value of a data field. Properties appear as public data members, but they’re
-implemented as special methods called accessors.
+The forms you will meet, as patterns:
+
+```csharp
+public string Phone { get; set; }            // auto-implemented: the compiler stores the value
+public string Name { get; }                  // read-only: assigned only in the constructor
+public decimal Total { get; private set; }   // readable everywhere, assignable only inside the class
+public string Summary => $"{Name} ({Phone})";   // computed: recalculated on every read
+public string Phone                          // full property with a backing field
+{
+    get { return phone; }
+    set { phone = value; }                   // value is the assigned value
+}
+```
+
+Inside a `set` accessor the keyword `value` names whatever the caller assigned. The runnable example uses the first, second, and fourth forms:

### chapters/10_classes/1002_properties.ipynb + new code cell after 0ad059f5 Properties intro worked example
+ using System;
+ 
+ Contact first = new Contact("Marie Ortiz", "773-508-7890");
+ Console.WriteLine($"{first.Name}: {first.Phone}");
+ first.Phone = "555-555-5555";          // allowed: Phone has a public set
+ Console.WriteLine($"{first.Name}: {first.Phone}");
+ Console.WriteLine(first.Summary);      // computed each time it is read
+ 
+ class Contact
+ {
+     public string Name { get; }                      // read-only after construction
+     public string Phone { get; set; }                // readable and writable
+     public string Summary => $"{Name} ({Phone})";   // computed property
+ 
+     public Contact(string name, string phone)
+     {
+         Name = name;
+         Phone = phone;
+     }
+ }

### chapters/10_classes/1002_properties.ipynb + new markdown cell after 0ad059f5 Properties intro worked example
+ The output is `Marie Ortiz: 773-508-7890`, then `Marie Ortiz: 555-555-5555`, then `Marie Ortiz (555-555-5555)`. Reading `first.Phone` looks exactly like reading a field, and assigning it looks like assigning a field, yet both go through accessors. Adding the line `first.Name = "Someone Else";` would not compile, because `Name` has no `set`; the read-only form is how a class promises that a value fixed at construction stays fixed. `Summary` has no storage of its own: the `=>` form recomputes the string from the current `Name` and `Phone` every time, which is why it shows the new phone number without being updated.
+ 
+ The next three subsections show what properties replace: the explicit getter and setter methods that older code, and languages such as Java, use for the same purpose. Reading them explains what the accessors above do behind the scenes, and the subsection after them rewrites the same class with properties.

### chapters/10_classes/1002_properties.ipynb + new markdown cell after 541fe992 Getters worked example
+ Run the same class as top-level statements. The three getters let the caller inspect the fields; nothing outside the class can assign to them.

### chapters/10_classes/1002_properties.ipynb + new code cell after 541fe992 Getters worked example
+ using System;
+ 
+ Contact c1 = new Contact("Marie Ortiz", "773-508-7890", "mortiz2@example.edu");
+ Contact c2 = new Contact("Otto Heinz", "773-508-9999", "oheinz@example.edu");
+ Console.WriteLine("Marie's full name: " + c1.GetName());
+ Console.WriteLine("Her phone number: " + c1.GetPhone());
+ Console.WriteLine("Her email: " + c1.GetEmail());
+ Console.WriteLine("\nFull contact info for Otto:");
+ c2.Print();
+ 
+ class Contact
+ {
+     private string name, phone, email;
+ 
+     public Contact(string fullName, string phoneNumber, string emailAddress)
+     {
+         name = fullName;
+         phone = phoneNumber;
+         email = emailAddress;
+     }
+ 
+     public string GetName() { return name; }
+     public string GetPhone() { return phone; }
+     public string GetEmail() { return email; }
+ 
+     public void Print()
+     {
+         Console.WriteLine($"Name:  {name}\nPhone: {phone}\nEmail: {email}");
+     }
+ }

### chapters/10_classes/1002_properties.ipynb + new markdown cell after 541fe992 Getters worked example
+ Each getter returns the current value of one private field. Try adding `Console.WriteLine(c1.name);` before the class: it does not compile, because `name` is private, and that refusal is the point of the design. The caller gets exactly the access the class chose to offer.

### chapters/10_classes/1002_properties.ipynb cell 93b902b5 fence the name = name block
-    public Contact(string name, string phone, string email)
-    {
-       name = name; // ????
-       ...
+```csharp
+public Contact(string name, string phone, string email)
+{
+   name = name; // ????
+   ...
+```

### chapters/10_classes/1002_properties.ipynb + new markdown cell after 93b902b5 This Object worked example
+ The runnable form shows `this` doing its job: the parameter and the field share a name, and `this.name` picks the field.

### chapters/10_classes/1002_properties.ipynb + new code cell after 93b902b5 This Object worked example
+ using System;
+ 
+ Contact c = new Contact("Amy Li", "847-111-2222");
+ c.Print();
+ 
+ class Contact
+ {
+     private string name, phone;
+ 
+     public Contact(string name, string phone)
+     {
+         this.name = name;      // the field on the left, the parameter on the right
+         this.phone = phone;
+     }
+ 
+     public void Print()
+     {
+         Console.WriteLine($"{name}: {phone}");
+     }
+ }

### chapters/10_classes/1002_properties.ipynb + new markdown cell after 93b902b5 This Object worked example
+ The output is `Amy Li: 847-111-2222`. Remove `this.` from the two assignments and run again: the output becomes `: ` because each statement assigns the parameter to itself and the fields keep their default `null`. Inside `Print`, plain `name` is unambiguous, since no local variable hides it there.

### chapters/10_classes/1002_properties.ipynb cell dd3d45cd fence indented code (1 blocks)
-    Contact c1 = new Contact("Marie Ortiz", "773-508-7890", "mortiz2@luc.edu");
-    c1.SetEmail ("maria.ortiz@gmail.com");
-    c1.SetPhone("555-555-5555");
-    c1.Print();
+```csharp
+Contact c1 = new Contact("Marie Ortiz", "773-508-7890", "mortiz2@luc.edu");
+c1.SetEmail ("maria.ortiz@gmail.com");
+c1.SetPhone("555-555-5555");
+c1.Print();
+```

### chapters/10_classes/1002_properties.ipynb + new markdown cell after dd3d45cd Setters worked example, properties subsection, practice
+ The complete second version, run as top-level statements, combines the setters with the `ToString` override developed in the next section:

### chapters/10_classes/1002_properties.ipynb + new code cell after dd3d45cd Setters worked example, properties subsection, practice
+ using System;
+ 
+ Contact c1 = new Contact("Marie Ortiz", "773-508-7890", "mortiz2@example.edu");
+ c1.SetEmail("maria.ortiz@example.com");
+ c1.SetPhone("555-555-5555");
+ c1.Print();
+ Console.WriteLine();
+ Console.WriteLine(c1);          // Console.WriteLine calls ToString for you
+ 
+ class Contact
+ {
+     private string name, phone, email;
+ 
+     public Contact(string name, string phone, string email)
+     {
+         this.name = name;
+         this.phone = phone;
+         this.email = email;
+     }
+ 
+     public string GetName() { return name; }
+     public void SetPhone(string newPhone) { phone = newPhone; }
+     public void SetEmail(string email) { this.email = email; }
+ 
+     public override string ToString()
+     {
+         return $"Name:  {name}\nPhone: {phone}\nEmail: {email}";
+     }
+ 
+     public void Print()
+     {
+         Console.WriteLine(ToString());
+     }
+ }

### chapters/10_classes/1002_properties.ipynb + new markdown cell after dd3d45cd Setters worked example, properties subsection, practice
+ Both printed blocks show the changed phone and email, because the setters assigned the private fields and every later read sees the new values. A setter can also refuse a change, which a public field never can; the next subsection shows that with a property.

### chapters/10_classes/1002_properties.ipynb + new markdown cell after dd3d45cd Setters worked example, properties subsection, practice
+ ```{index} Properties Replace Getters and Setters
+ ```
+ 
+ (properties-replace-accessors)=
+ 
+ ### Properties Replace Getters and Setters

### chapters/10_classes/1002_properties.ipynb + new markdown cell after dd3d45cd Setters worked example, properties subsection, practice
+ `GetPhone` and `SetPhone` work, but C# gives the pair one name and the field syntax. A full property keeps the private backing field and puts the two accessors together; the `set` accessor can validate `value` before storing it, and a property with only `get` is read-only. The caller writes `c.Phone` to read and `c.Phone = "..."` to write, and never sees the field.
+ 
+ ```csharp
+ private string phone = "";          // backing field
+ 
+ public string Phone                  // the property the caller uses
+ {
+     get { return phone; }
+     set
+     {
+         if (string.IsNullOrWhiteSpace(value))
+             throw new ArgumentException("Phone cannot be blank.");
+         phone = value;
+     }
+ }
+ ```

### chapters/10_classes/1002_properties.ipynb + new code cell after dd3d45cd Setters worked example, properties subsection, practice
+ using System;
+ 
+ Contact c = new Contact("Marie Ortiz", "773-508-7890");
+ Console.WriteLine(c.Phone);
+ c.Phone = "555-555-5555";          // runs the set accessor
+ Console.WriteLine(c.Phone);
+ try
+ {
+     c.Phone = "";                  // the set accessor rejects this
+ }
+ catch (ArgumentException ex)
+ {
+     Console.WriteLine($"Rejected: {ex.Message}");
+ }
+ Console.WriteLine(c.Phone);        // unchanged by the rejected assignment
+ 
+ class Contact
+ {
+     private string phone = "";
+ 
+     public string Name { get; }
+ 
+     public string Phone
+     {
+         get { return phone; }
+         set
+         {
+             if (string.IsNullOrWhiteSpace(value))
+                 throw new ArgumentException("Phone cannot be blank.");
+             phone = value;
+         }
+     }
+ 
+     public Contact(string name, string phone)
+     {
+         Name = name;
+         Phone = phone;     // runs the setter's check during construction too
+     }
+ }

### chapters/10_classes/1002_properties.ipynb + new markdown cell after dd3d45cd Setters worked example, properties subsection, practice
+ The output is `773-508-7890`, `555-555-5555`, `Rejected: Phone cannot be blank.`, and `555-555-5555` again. The blank assignment never reached the field, so the object stayed valid. The constructor assigns through the property on purpose, so the same check protects construction; assigning `phone = ""` directly inside the class would bypass it. When no check is needed, the auto-implemented form `public string Phone { get; set; }` is the whole declaration; add the full form only when a `set` has work to do.

### chapters/10_classes/1002_properties.ipynb + new markdown cell after dd3d45cd Setters worked example, properties subsection, practice
+ ```{index} Guided Practice: Validate an Email Property
+ ```
+ 
+ ### Guided Practice: Validate an Email Property

### chapters/10_classes/1002_properties.ipynb + new markdown cell after dd3d45cd Setters worked example, properties subsection, practice
+ Add an `Email` property to `Contact` with a backing field. The setter must reject a value that does not contain `@` and store any accepted value in lowercase. Expected output: `mortiz2@example.edu`, then `Rejected: Email must contain @.`, then `mortiz2@example.edu` again.

### chapters/10_classes/1002_properties.ipynb + new code cell after dd3d45cd Setters worked example, properties subsection, practice
+ using System;
+ 
+ Contact c = new Contact("Marie Ortiz", "MOrtiz2@Example.edu");
+ Console.WriteLine(c.Email);
+ try { c.Email = "not-an-address"; }
+ catch (ArgumentException ex) { Console.WriteLine($"Rejected: {ex.Message}"); }
+ Console.WriteLine(c.Email);
+ 
+ class Contact
+ {
+     private string email = "";
+ 
+     public string Name { get; }
+ 
+     public string Email
+     {
+         get { return email; }
+         set
+         {
+             // Your code starts here.
+             email = value;
+             // Your code ends here.
+         }
+     }
+ 
+     public Contact(string name, string email)
+     {
+         Name = name;
+         Email = email;
+     }
+ }

### chapters/10_classes/1002_properties.ipynb + new code cell after dd3d45cd Setters worked example, properties subsection, practice
+ using System;
+ 
+ // Solution
+ Contact c = new Contact("Marie Ortiz", "MOrtiz2@Example.edu");
+ Console.WriteLine(c.Email);
+ try { c.Email = "not-an-address"; }
+ catch (ArgumentException ex) { Console.WriteLine($"Rejected: {ex.Message}"); }
+ Console.WriteLine(c.Email);
+ 
+ class Contact
+ {
+     private string email = "";
+ 
+     public string Name { get; }
+ 
+     public string Email
+     {
+         get { return email; }
+         set
+         {
+             if (!value.Contains('@'))
+                 throw new ArgumentException("Email must contain @.");
+             email = value.ToLowerInvariant();
+         }
+     }
+ 
+     public Contact(string name, string email)
+     {
+         Name = name;
+         Email = email;
+     }
+ }

### chapters/10_classes/1002_properties.ipynb + new markdown cell after dd3d45cd Setters worked example, properties subsection, practice
+ The starter prints the address exactly as typed and then accepts the bad value, so its second and third lines differ from the expected output. In the solution, lowercase normalization happens in one place, the setter, so every path that assigns an email gets the same rule.

### chapters/10_classes/1002_properties.ipynb cell a517095f de-indent prose that rendered as code
-    Think more generally about string representations:
-    All the built-in type values can be concatenated into strings with the '+' operator,
-    or displayed with `Console.Write`. We would like that behavior with our custom types,
-    too.
+Think more generally about string representations: all the built-in type values can be concatenated into strings with the `+` operator, or displayed with `Console.Write`. We would like that behavior with our custom types, too.
-    Types frequently `override` the Object.ToString method to provide a more suitable string
-    representation or display of a particular type instead of the default fully qualified type name.
-    For example:
+Types frequently `override` the `Object.ToString` method to provide a more suitable string representation of a particular type instead of the default fully qualified type name. For example:

### chapters/10_classes/1002_properties.ipynb cell 67dee676 fence indented code (2 blocks)
-    public void Print()
-    {
-       Console.WriteLine(ToString());
-       // Console.WriteLine(this);         ///// "this" returns the same as ToString()
-    }
+```csharp
+public void Print()
+{
+   Console.WriteLine(ToString());
+   // Console.WriteLine(this);         ///// "this" returns the same as ToString()
+}
+```
-    Employee employee = new Employee { Name = "John", Salary = 100000 };
-    Console.WriteLine(employee.ToString());
-    Console.WriteLine(employee);
-    employee.Print();
+```csharp
+Employee employee = new Employee { Name = "John", Salary = 100000 };
+Console.WriteLine(employee.ToString());
+Console.WriteLine(employee);
+employee.Print();
+```

### chapters/10_classes/1002_properties.ipynb cell dd5dc720 close the unterminated output fence
-``` bash
-tcn85@mac:~/workspace/introcscs/Ch10ClassesLab$ dotnet run
+```text
+```
+
+All three lines are the same because `Console.WriteLine(employee)` and `Print` both end up calling the one `ToString` override.

### chapters/10_classes/1002_properties.ipynb cell f7afcc28 remove stray footnote text that belonged to 10.1
-
-`{rubric} footnote`
-
-[1] See the answer at [What is the difference between a field and a property?](https://stackoverflow.com/questions/295104/what-is-the-difference-between-a-field-and-a-property)
-
-[2] [Accessibility Levels (C# Reference)](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/accessibility-levels).
-
-[3] See [internal](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/internal)

### chapters/07_arrays/0701_onedim.ipynb cell 3de0d8d4 fence indented code (6 blocks)
-    int[] a;
+```csharp
+int[] a;
+```
-    int[] a;
-    a = new int[4];
+```csharp
+int[] a;
+a = new int[4];
+```
-    int[] a = new int[4];
+```csharp
+int[] a = new int[4];
+```
-    > foreach (int i in a)
-      {
-          Console.Write(i);
-      }
-    0000
-    >
+```text
+> foreach (int i in a)
+  {
+      Console.Write(i);
+  }
+0000
+>
+```
-    int[] a = {0, 2, 4, 6, 8};
+```csharp
+int[] a = {0, 2, 4, 6, 8};
+```
-    int[] a = new int[] {0, 2, 4, 6, 8};
+```csharp
+int[] a = new int[] {0, 2, 4, 6, 8};
+```

### chapters/07_arrays/0701_onedim.ipynb + new markdown cell after 3de0d8d4 Creating Arrays worked example
+ Run the three creation forms together. The first array exists only after `new`; the second and third hold the same five values.

### chapters/07_arrays/0701_onedim.ipynb + new code cell after 3de0d8d4 Creating Arrays worked example
+ using System;
+ 
+ int[] a;                                  // declare an array variable: no array yet
+ a = new int[4];                           // create the array object: four zeros
+ Console.WriteLine($"a has {a.Length} elements: {string.Join(" ", a)}");
+ 
+ int[] b = new int[] { 0, 2, 4, 6, 8 };    // creation expression with values
+ int[] c = { 0, 2, 4, 6, 8 };              // initializer shorthand, same result
+ Console.WriteLine($"b: {string.Join(", ", b)}");
+ Console.WriteLine($"c has {c.Length} elements; c[4] is {c[4]}");

### chapters/07_arrays/0701_onedim.ipynb + new markdown cell after 3de0d8d4 Creating Arrays worked example
+ The output is `a has 4 elements: 0 0 0 0`, then `b: 0, 2, 4, 6, 8`, then `c has 5 elements; c[4] is 8`. Two mistakes to try on purpose: `new int[]` with neither a length nor an initializer does not compile, and `a[4]` on the four-element array compiles but throws `IndexOutOfRangeException` when it runs, because the last valid index is 3.

### chapters/07_arrays/0701_onedim.ipynb cell 5e887346 fence indented code (10 blocks)
-    a[0] = 7;
-    a[1] = 5;
-    a[2] = 9;
-    a[3] = 6;
+```csharp
+a[0] = 7;
+a[1] = 5;
+a[2] = 9;
+a[3] = 6;
+```
-    int[] b = {7, 5, 9, 6};
+```csharp
+int[] b = {7, 5, 9, 6};
+```
-    a[2] = 4*a[1] - a[3];
+```csharp
+a[2] = 4*a[1] - a[3];
+```
-    Console.WriteLine(b.Length); // prints 4
+```csharp
+Console.WriteLine(b.Length); // prints 4
+```
-    for (int i= 0; i < b.Length; i++) {
-       Console.WriteLine(b[i]);
-    }
+```csharp
+for (int i= 0; i < b.Length; i++) {
+   Console.WriteLine(b[i]);
+}
+```
-    foreach ( int x in b) {
-       Console.WriteLine(x);
-    }
+```csharp
+foreach ( int x in b) {
+   Console.WriteLine(x);
+}
+```
-    > int[] a = { 1, 2, 3, 4, 5 };
-    > int i = 0;
-    > while ( i < a.Length){
-       Console.Write(a[i]);
-       i++;
-      }
-    12345
-    >
+```text
+> int[] a = { 1, 2, 3, 4, 5 };
+> int i = 0;
+> while ( i < a.Length){
+   Console.Write(a[i]);
+   i++;
+  }
+12345
+>
+```
-    for(int i= 0; i < 3; i++) {
-       Console.WriteLine(b[i]);
-    }
+```csharp
+for(int i= 0; i < 3; i++) {
+   Console.WriteLine(b[i]);
+}
+```
-    for(int i= 0; i < b.Length; i++) {
-       b[i] = 5*i;
-    }
+```csharp
+for(int i= 0; i < b.Length; i++) {
+   b[i] = 5*i;
+}
+```
-    string[] hamlet = {"To be", "or not", "to be!"};
-    PrintStrings(hamlet);
+```csharp
+string[] hamlet = {"To be", "or not", "to be!"};
+PrintStrings(hamlet);
+```

### chapters/07_arrays/0701_onedim.ipynb cell 5e887346 fence single line
-    a[2]
+```csharp
+a[2]
+```

### chapters/07_arrays/0701_onedim.ipynb + new markdown cell after 5e887346 Accessing Array Elements worked examples and practice
+ The fragments above come together in two runnable cells. The first reads and assigns by index and shows the three loop forms; the second passes an array to a method and returns one from a method. `MakeCodes` plays the role of `InputNStrings` without the keyboard, which the browser cannot supply.

### chapters/07_arrays/0701_onedim.ipynb + new code cell after 5e887346 Accessing Array Elements worked examples and practice
+ using System;
+ 
+ int[] a = new int[4];
+ a[0] = 7; a[1] = 5; a[2] = 9; a[3] = 6;
+ Console.WriteLine($"a[2] is {a[2]}");
+ a[2] = 4 * a[1] - a[3];
+ Console.WriteLine($"a[2] is now {a[2]}; Length is {a.Length}");
+ 
+ int[] b = { 7, 5, 9, 6 };
+ for (int i = 0; i < b.Length; i++) b[i] = 5 * i;    // assign by index
+ Console.WriteLine("b after the loop: " + string.Join(", ", b));
+ foreach (int x in b) Console.Write(x + " ");        // read only
+ Console.WriteLine();
+ 
+ int[] d = { 5, 9, 15, -4 };
+ int k = 2;
+ Console.WriteLine($"d[k] = {d[k]}, d[k + 1] = {d[k + 1]}, d[k] + 1 = {d[k] + 1}");

### chapters/07_arrays/0701_onedim.ipynb + new markdown cell after 5e887346 Accessing Array Elements worked examples and practice
+ The output is `a[2] is 9`, `a[2] is now 14; Length is 4`, `b after the loop: 0, 5, 10, 15`, the same four values on one line from `foreach`, and `d[k] = 15, d[k + 1] = -4, d[k] + 1 = 16`. The last line is the one to study: `d[k + 1]` evaluates the index expression first and reads position 3, while `d[k] + 1` reads position 2 and then adds.

### chapters/07_arrays/0701_onedim.ipynb + new code cell after 5e887346 Accessing Array Elements worked examples and practice
+ using System;
+ 
+ string[] hamlet = { "To be", "or not", "to be!" };
+ PrintStrings(hamlet);
+ string[] codes = MakeCodes(3);
+ PrintStrings(codes);
+ 
+ static void PrintStrings(string[] data)
+ {
+     foreach (string s in data) Console.WriteLine(s);
+ }
+ 
+ static string[] MakeCodes(int n)
+ {
+     string[] lines = new string[n];          // create the array first
+     for (int i = 0; i < n; i++)              // fill every position
+         lines[i] = $"SKU-{100 + i}";
+     return lines;                            // return the filled array
+ }

### chapters/07_arrays/0701_onedim.ipynb + new markdown cell after 5e887346 Accessing Array Elements worked examples and practice
+ `PrintStrings` only reads its parameter, so the caller's arrays are unchanged. `MakeCodes` follows the three-step pattern for returning an array: create it with a length, fill every position in a loop, return it. The next section shows what happens when a method *does* assign into its array parameter.

### chapters/07_arrays/0701_onedim.ipynb + new markdown cell after 5e887346 Accessing Array Elements worked examples and practice
+ ```{index} Guided Practice: Double Every Slot
+ ```
+ 
+ ### Guided Practice: Double Every Slot

### chapters/07_arrays/0701_onedim.ipynb + new markdown cell after 5e887346 Accessing Array Elements worked examples and practice
+ Complete the loop so that every quantity is doubled in place, then print the array. Expected output: `14, 10, 18, 12`. Then explain why a `foreach` loop cannot do this job.

### chapters/07_arrays/0701_onedim.ipynb + new code cell after 5e887346 Accessing Array Elements worked examples and practice
+ using System;
+ 
+ int[] quantities = { 7, 5, 9, 6 };
+ for (int i = 0; i < quantities.Length; i++)
+ {
+     // Your code starts here.
+     // Replace the element at index i with twice its value.
+     // Your code ends here.
+ }
+ Console.WriteLine(string.Join(", ", quantities));

### chapters/07_arrays/0701_onedim.ipynb + new code cell after 5e887346 Accessing Array Elements worked examples and practice
+ using System;
+ 
+ // Solution
+ int[] quantities = { 7, 5, 9, 6 };
+ for (int i = 0; i < quantities.Length; i++)
+ {
+     quantities[i] = 2 * quantities[i];
+ }
+ Console.WriteLine(string.Join(", ", quantities));

### chapters/07_arrays/0701_onedim.ipynb + new markdown cell after 5e887346 Accessing Array Elements worked examples and practice
+ A `foreach` loop hands you a copy of each value; assigning to that copy changes nothing in the array, and C# refuses the assignment outright for the iteration variable. Only an index names a slot.

### chapters/07_arrays/0701_onedim.ipynb + new markdown cell after c3088f20 Default Initializations worked example
+ The defaults are easy to see when the arrays are printed, and the null case is easy to repair with the loop:

### chapters/07_arrays/0701_onedim.ipynb + new code cell after c3088f20 Default Initializations worked example
+ using System;
+ 
+ int[] counts = new int[3];
+ bool[] flags = new bool[2];
+ string[] words = new string[2];
+ Console.WriteLine($"counts: {string.Join(", ", counts)}");
+ Console.WriteLine($"flags: {string.Join(", ", flags)}");
+ Console.WriteLine($"words[0] is null: {words[0] is null}");
+ for (int i = 0; i < words.Length; i++) words[i] = "";
+ Console.WriteLine($"words[0].Length after the loop: {words[0].Length}");

### chapters/07_arrays/0701_onedim.ipynb + new markdown cell after c3088f20 Default Initializations worked example
+ The output is `counts: 0, 0, 0`, `flags: False, False`, `words[0] is null: True`, and `words[0].Length after the loop: 0`. Reading `words[0].Length` before the loop would throw `NullReferenceException`, which is the error the warning above describes.

### chapters/07_arrays/0703_array_processing.ipynb + new markdown cell after c0ecab1a Parameters to Main worked example
+ A browser cell has no command line, so the runnable version supplies the array that `dotnet run hi there 123` would build. Everything after that line is the same as in `Main`.

### chapters/07_arrays/0703_array_processing.ipynb + new code cell after c0ecab1a Parameters to Main worked example
+ using System;
+ 
+ string[] arguments = { "hi", "there", "123" };   // what dotnet run hi there 123 passes to Main
+ Console.WriteLine($"There are {arguments.Length} command line parameters.");
+ foreach (string s in arguments)
+ {
+     Console.WriteLine(s);
+ }

### chapters/07_arrays/0703_array_processing.ipynb + new markdown cell after c0ecab1a Parameters to Main worked example
+ The array holds strings even when a parameter looks like a number: `"123"` is text until the program converts it, which the adder below does with `int.Parse`.

### chapters/07_arrays/0703_array_processing.ipynb cell ee4c4d6d fence indented code (1 blocks)
-    ////////// args array from command line.
-    int sum = 0;
-    for (int i = 0; i < args.Length; i++)
-    {
-          sum = sum + int.Parse(args[i]);
-    }
-    Console.WriteLine(sum);
+```csharp
+////////// args array from command line.
+int sum = 0;
+for (int i = 0; i < args.Length; i++)
+{
+      sum = sum + int.Parse(args[i]);
+}
+Console.WriteLine(sum);
+```

### chapters/07_arrays/0703_array_processing.ipynb + new code cell after ee4c4d6d Command Line Adder worked example
+ using System;
+ 
+ string[] arguments = { "2", "5", "22" };   // what dotnet run 2 5 22 passes to Main
+ int sum = 0;
+ for (int i = 0; i < arguments.Length; i++)
+ {
+     sum = sum + int.Parse(arguments[i]);
+ }
+ Console.WriteLine(sum);

### chapters/07_arrays/0703_array_processing.ipynb + new markdown cell after ee4c4d6d Command Line Adder worked example
+ The output is `29`. If one of the parameters were `hi`, `int.Parse` would throw `FormatException`; Chapter 6's `TryParse` is the way to reject such input politely in a real command-line tool.

### chapters/07_arrays/0703_array_processing.ipynb cell 0430df81 fence indented code (3 blocks)
-    b[2] = -10;
-    d[1] = 55;
+```csharp
+b[2] = -10;
+d[1] = 55;
+```
-    // Modify a by multiplying all elements by multiplier.
-    static void Scale(int[] a, int multiplier)
-    {
-       for (int i = 0; i < a.Length; i++) {
-          a[i] *= multiplier;  // or:  a[i] = a[i] * multiplier
-       }
-    }
+```csharp
+// Modify a by multiplying all elements by multiplier.
+static void Scale(int[] a, int multiplier)
+{
+   for (int i = 0; i < a.Length; i++) {
+      a[i] *= multiplier;  // or:  a[i] = a[i] * multiplier
+   }
+}
+```
-    int[] nums = {2, 4, 1};
-    Scale(nums, 5);
+```csharp
+int[] nums = {2, 4, 1};
+Scale(nums, 5);
+```

### chapters/07_arrays/0703_array_processing.ipynb cell 0430df81 repair figure directive
-`{image} ../../figures/intCopy.png :align: center :alt: copying an int :width: 90 pt`
+```{figure} ../../figures/intCopy.png
+:align: center
+:alt: copying an int
+:width: 90pt
+```

### chapters/07_arrays/0703_array_processing.ipynb cell 0430df81 repair figure directive
-`{image} ../../figures/arrayAlias.png :align: center :alt: copying an array reference :width: 300 pt`
+```{figure} ../../figures/arrayAlias.png
+:align: center
+:alt: copying an array reference
+:width: 300pt
+```

### chapters/07_arrays/0703_array_processing.ipynb + new markdown cell after 0430df81 References and Aliases worked example
+ Run the comparison. The two `int` variables go their separate ways after the copy; the two array variables are two names for one array, and `Scale` changes the caller's array through its parameter.

### chapters/07_arrays/0703_array_processing.ipynb + new code cell after 0430df81 References and Aliases worked example
+ using System;
+ 
+ int b1 = 5;
+ int d1 = b1;          // copies the value
+ d1 = 99;
+ Console.WriteLine($"ints: b1 = {b1}, d1 = {d1}");
+ 
+ int[] b = { 1, 2, 3 };
+ int[] d = b;          // copies the reference: one array, two names
+ b[2] = -10;
+ d[1] = 55;
+ Console.WriteLine($"b: {string.Join(", ", b)}");
+ Console.WriteLine($"d: {string.Join(", ", d)}");
+ Console.WriteLine($"Same array object: {ReferenceEquals(b, d)}");
+ 
+ int[] nums = { 2, 4, 1 };
+ Scale(nums, 5);
+ Console.WriteLine($"nums after Scale: {string.Join(", ", nums)}");
+ 
+ static void Scale(int[] a, int multiplier)
+ {
+     for (int i = 0; i < a.Length; i++)
+     {
+         a[i] *= multiplier;       // or: a[i] = a[i] * multiplier
+     }
+ }

### chapters/07_arrays/0703_array_processing.ipynb + new markdown cell after 0430df81 References and Aliases worked example
+ The output is `ints: b1 = 5, d1 = 99`, then `b: 1, 55, -10` and `d: 1, 55, -10`, then `Same array object: True`, then `nums after Scale: 10, 20, 5`. The assignment through `d` is visible through `b` because there is only one array. The common mistake is expecting `Scale` to work on a private copy; if the caller needs its original values afterwards, it must pass a clone, `Scale((int[])nums.Clone(), 5)`, or `Scale` must build and return a new array instead of assigning into its parameter.

### chapters/04_iteration/0404_gcd.ipynb cell c8c2d6d7 label fence
-``` csharp
+```csharp

### chapters/04_iteration/0404_gcd.ipynb + new markdown cell after c8c2d6d7 Brute force runnable
+ The method form waits for Chapter 5. The same loop runs now as top-level statements, with a counter that shows how many candidates it tests:

### chapters/04_iteration/0404_gcd.ipynb + new code cell after c8c2d6d7 Brute force runnable
+ using System;
+ 
+ int a = 810, b = 729;
+ int n = Math.Min(a, b);
+ int gcd = 1, i = 1, tests = 0;
+ while (i <= n)
+ {
+     tests++;
+     if (a % i == 0 && b % i == 0)
+     {
+         gcd = i;
+     }
+     i++;
+ }
+ Console.WriteLine($"GCD of {a} and {b} is {gcd} after {tests} tests");

### chapters/04_iteration/0404_gcd.ipynb + new markdown cell after c8c2d6d7 Brute force runnable
+ The output is `GCD of 810 and 729 is 81 after 729 tests`. Every candidate from 1 through the smaller number is tried, and `gcd` is overwritten each time a larger common divisor appears, so the last one kept is the greatest. Keep the count of 729 in mind for the comparison below.

### chapters/04_iteration/0404_gcd.ipynb cell 986da74c label fence
-``` csharp
+```csharp

### chapters/04_iteration/0404_gcd.ipynb + new markdown cell after 986da74c Subtraction runnable
+ As top-level statements, with a counter for the subtractions:

### chapters/04_iteration/0404_gcd.ipynb + new code cell after 986da74c Subtraction runnable
+ using System;
+ 
+ int a = 810, b = 729, steps = 0;
+ while (a != b)
+ {
+     while (a > b) { a = a - b; steps++; }
+     while (b > a) { b = b - a; steps++; }
+ }
+ Console.WriteLine($"GCD is {a} after {steps} subtractions");

### chapters/04_iteration/0404_gcd.ipynb + new markdown cell after 986da74c Subtraction runnable
+ The output is `GCD is 81 after 9 subtractions`: one subtraction brings 810 down to 81, then eight subtractions of 81 bring 729 down to 81, and the outer loop ends when the two values meet. Nine steps against 729 tests is already a large saving, and the remainder loop below needs only two.

### chapters/04_iteration/0404_gcd.ipynb cell c944138f fence indented code (1 blocks)
-    /// Return the greatest common divisor of nonnegative numbers,
-    /// not both 0.
-    public static int GreatestCommonDivisor (int a, int b)
-    {
-       while (b != 0) {
-          int r = a % b;
-          a = b;
-          b = r;
-       }
-       return a;
-    } 
+```csharp
+/// Return the greatest common divisor of nonnegative numbers,
+/// not both 0.
+public static int GreatestCommonDivisor (int a, int b)
+{
+   while (b != 0) {
+      int r = a % b;
+      a = b;
+      b = r;
+   }
+   return a;
+} 
+```

### chapters/04_iteration/0404_gcd.ipynb cell 67806454 fence indented code (2 blocks)
-    gcd(a, b) = gcd(b, a % b)
+```csharp
+gcd(a, b) = gcd(b, a % b)
+```
-    /// Return the greatest common divisor of nonnegative numbers,
-    /// not both 0.
-    public static int GreatestCommonDivisor (int a, int b)
-    {
-       if (b == 0) {                               // base
-          return a;                                //   case
-       } else {
-          return GreatestCommonDivisor (b, a % b); // recursion
-       }
-    }
+```csharp
+/// Return the greatest common divisor of nonnegative numbers,
+/// not both 0.
+public static int GreatestCommonDivisor (int a, int b)
+{
+   if (b == 0) {                               // base
+      return a;                                //   case
+   } else {
+      return GreatestCommonDivisor (b, a % b); // recursion
+   }
+}
+```

### chapters/04_iteration/0404_gcd.ipynb cell 67806454 formula is not C#
-```csharp
+```text

### chapters/04_iteration/0404_gcd.ipynb cell 67806454 link to 5.6
-answer can be directly calculated.
+answer can be directly calculated. Chapter 5's supporting reading {doc}`Recursive Methods <../05_methods/0506_recursive_methods>` runs this GCD beside its loop form and traces the calls.

### chapters/04_iteration/0404_gcd.ipynb cell 9b02e0da tie counts together
-For the current chapter, the same remainder updates can be written as top-level statements. Save the remainder before changing `a`; otherwise `a % b` would use the changed value. Trace `(810, 729)`, `(10, 15)`, and `(15, 10)`. Compare the number of iterations with trial division and subtraction. The common divisor is unchanged by each remainder step; the second value strictly decreases after the initial swap until it becomes zero.
+For the current chapter, the same remainder updates can be written as top-level statements. Save the remainder before changing `a`; otherwise `a % b` would use the changed value. Trace `(810, 729)`, `(10, 15)`, and `(15, 10)`. Compare the number of iterations with trial division (729 tests above) and subtraction (9 steps). The common divisor is unchanged by each remainder step; the second value strictly decreases after the initial swap until it becomes zero.

### chapters/09_files_text/0901_stream_file.ipynb cell 84b7854f comparison table
+
+The console methods you already use have file counterparts with the same names:
+
+| Console | File writing | File reading | What it does |
+| --- | --- | --- | --- |
+| `Console.WriteLine(text)` | `writer.WriteLine(text)` | | Writes text followed by a newline |
+| `Console.Write(text)` | `writer.Write(text)` | | Writes text without a newline |
+| `Console.ReadLine()` | | `reader.ReadLine()` | Returns the next line, or `null` at the end |
+| | `writer.Close()` | `reader.Close()` | Releases the file; for a writer, also finishes writing |
+
+Here `writer` is a `StreamWriter` and `reader` is a `StreamReader`, the two classes developed below.

### chapters/09_files_text/0901_stream_file.ipynb cell 7c0bb79e fence indented code (4 blocks)
-        > File.Create("MyTest.txt");
+    ```text
+    > File.Create("MyTest.txt");
+    ```
-        > if (File.Exists("MyTest.txt"))
-          {
-             Console.WriteLine("MyTest.txt exists");
-          }
-        MyTest.txt exists
+    ```text
+    > if (File.Exists("MyTest.txt"))
+      {
+         Console.WriteLine("MyTest.txt exists");
+      }
+    MyTest.txt exists
+    ```
-        > File.WriteAllText("MyTest.txt", "Hello, this is a test.");
+    ```text
+    > File.WriteAllText("MyTest.txt", "Hello, this is a test.");
+    ```
-        > File.ReadAllText("MyTest.txt");
+    ```text
+    > File.ReadAllText("MyTest.txt");
-        > Console.WriteLine(File.ReadAllText("MyTest.txt"));
-        Hello, this is a test.
+    > Console.WriteLine(File.ReadAllText("MyTest.txt"));
+    Hello, this is a test.
-        >
+    >
+    ```

### chapters/09_files_text/0901_stream_file.ipynb + new markdown cell after d3440b72 File class worked example
+ The project above writes `MyTest.txt` into the working directory. The runnable version below does the same work as top-level statements in a temporary location it owns, adds `AppendAllText`, and removes the file at the end so the cell can be run repeatedly.

### chapters/09_files_text/0901_stream_file.ipynb + new code cell after d3440b72 File class worked example
+ using System;
+ using System.IO;
+ 
+ string path = Path.Combine(Path.GetTempPath(), "cscs_file_demo_" + Guid.NewGuid().ToString("N") + ".txt");
+ Console.WriteLine($"Exists before writing: {File.Exists(path)}");
+ File.WriteAllText(path, "Hello, I know how to write files.");   // creates the file
+ Console.WriteLine($"Exists after writing: {File.Exists(path)}");
+ File.AppendAllText(path, "\nSecond line.");                       // adds to the end
+ string contents = File.ReadAllText(path);
+ Console.WriteLine(contents);
+ File.Delete(path);
+ Console.WriteLine($"Exists after delete: {File.Exists(path)}");

### chapters/09_files_text/0901_stream_file.ipynb + new markdown cell after d3440b72 File class worked example
+ The output is `Exists before writing: False`, `Exists after writing: True`, the two lines of the file, and `Exists after delete: False`. `WriteAllText` creates or overwrites; `AppendAllText` keeps what is there and adds to the end. Calling `WriteAllText` a second time would silently replace both lines, which is the mistake to watch for when a report is meant to grow.

### chapters/09_files_text/0901_stream_file.ipynb cell 476c0b2d label fence
-> ```
+> ```csharp

### chapters/09_files_text/0901_stream_file.ipynb cell 476c0b2d label fence
-```
+```text

### chapters/09_files_text/0902_file_operations.ipynb + new markdown cell after 0ead8250 Path helpers worked example
+ Run the `Path` helpers on one relative path. The last line depends on the working directory of the process, which is the point: a relative path is only meaningful together with that directory.

### chapters/09_files_text/0902_file_operations.ipynb + new code cell after 0ead8250 Path helpers worked example
+ using System;
+ using System.IO;
+ 
+ Console.WriteLine($"Separator on this system: '{Path.DirectorySeparatorChar}'");
+ string relative = Path.Combine("..", "data", "sample.txt");
+ Console.WriteLine($"Combined: {relative}");
+ Console.WriteLine($"File name: {Path.GetFileName(relative)}");
+ Console.WriteLine($"Extension: {Path.GetExtension(relative)}");
+ Console.WriteLine($"Directory part: {Path.GetDirectoryName(relative)}");
+ Console.WriteLine($"Rooted: {Path.IsPathRooted(relative)}");
+ Console.WriteLine($"Full path from the working directory: {Path.GetFullPath(relative)}");

### chapters/09_files_text/0902_file_operations.ipynb + new markdown cell after 0ead8250 Path helpers worked example
+ On macOS or Linux the combined path prints as `../data/sample.txt`; on Windows it prints with backslashes. `Combine` only builds the string: nothing checks that `data` exists. `IsPathRooted` is false because the path starts with `..`, and `GetFullPath` resolves it against the working directory, so the same program prints a different full path when started from a different folder. That is the usual cause of "file not found" for a file that is plainly there.

### chapters/09_files_text/0902_file_operations.ipynb + new markdown cell after 1ab86cf0 Directory class worked example
+ The example creates a directory it owns, writes two daily order files into it, lists them, and removes the directory afterward:

### chapters/09_files_text/0902_file_operations.ipynb + new code cell after 1ab86cf0 Directory class worked example
+ using System;
+ using System.IO;
+ 
+ string workspace = Path.Combine(Path.GetTempPath(), "cscs_dir_demo_" + Guid.NewGuid().ToString("N"));
+ Directory.CreateDirectory(workspace);
+ try
+ {
+     File.WriteAllText(Path.Combine(workspace, "orders_mon.txt"), "3 orders");
+     File.WriteAllText(Path.Combine(workspace, "orders_tue.txt"), "5 orders");
+     Console.WriteLine($"Is a directory: {Directory.Exists(workspace)}");
+     string[] files = Directory.GetFiles(workspace);
+     Array.Sort(files, StringComparer.Ordinal);
+     foreach (string file in files)
+         Console.WriteLine($"{Path.GetFileName(file)}: {File.ReadAllText(file)}");
+     Console.WriteLine($"Files found: {files.Length}");
+ }
+ finally
+ {
+     Directory.Delete(workspace, recursive: true);
+ }
+ Console.WriteLine($"Still exists: {Directory.Exists(workspace)}");

### chapters/09_files_text/0902_file_operations.ipynb + new markdown cell after 1ab86cf0 Directory class worked example
+ The output is `Is a directory: True`, the two file lines, `Files found: 2`, and `Still exists: False`. `GetFiles` returns full paths, so `GetFileName` trims them for display, and the explicit sort makes the order predictable: the file system does not promise one. `Directory.Delete` with `recursive: true` removes the files too; without that argument it refuses to delete a non-empty directory.

### chapters/09_files_text/0902_file_operations.ipynb cell 821f77d7 pattern fence
-A StreamReader or StreamWriter owns resources that must be disposed. A using statement or declaration expresses that lifetime. The general declaration form is `using ResourceType name = acquisitionExpression;`; this is a syntax pattern. Processing statements use that acquired resource inside its permitted scope. Disposal handles resource release; it does not establish that every record was valid or that a business transaction completed successfully.
+A StreamReader or StreamWriter owns resources that must be disposed. A using statement or declaration expresses that lifetime. The general declaration form is a syntax pattern:
+
+```csharp
+using ResourceType name = acquisitionExpression;   // disposed at the end of the enclosing block
+```
+ Processing statements use that acquired resource inside its permitted scope. Disposal handles resource release; it does not establish that every record was valid or that a business transaction completed successfully.

### chapters/09_files_text/0902_file_operations.ipynb + new markdown cell after 821f77d7 Resource lifetime worked example
+ Run the guided scenario. The third amount is not a number, so `int.Parse` throws inside the loop after two lines have been written:

### chapters/09_files_text/0902_file_operations.ipynb + new code cell after 821f77d7 Resource lifetime worked example
+ using System;
+ using System.IO;
+ 
+ string workspace = Path.Combine(Path.GetTempPath(), "cscs_partial_" + Guid.NewGuid().ToString("N"));
+ Directory.CreateDirectory(workspace);
+ string reportPath = Path.Combine(workspace, "report.txt");
+ string[] amounts = { "120", "85", "not a number" };
+ try
+ {
+     using StreamWriter writer = new StreamWriter(reportPath);
+     foreach (string amount in amounts)
+     {
+         writer.WriteLine($"Amount {int.Parse(amount)}");   // the third line throws
+     }
+ }
+ catch (FormatException)
+ {
+     Console.WriteLine("Import stopped: a line was not a number.");
+ }
+ Console.WriteLine("Report contains:");
+ Console.Write(File.ReadAllText(reportPath));
+ Directory.Delete(workspace, recursive: true);

### chapters/09_files_text/0902_file_operations.ipynb + new markdown cell after 821f77d7 Resource lifetime worked example
+ The output is `Import stopped: a line was not a number.`, then `Report contains:` followed by `Amount 120` and `Amount 85`. The `using` declaration disposed the writer while the exception was unwinding, which is why those two lines reached the file instead of staying in the buffer. What cleanup did not do is undo them: the report on disk is partial. A caller that needs all-or-nothing output must write to a temporary file and rename it only after the loop completes.
```
