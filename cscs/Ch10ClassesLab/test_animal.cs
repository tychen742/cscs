using System;

namespace IntroCSCS
{
   public class TestAnimal
   {
      /// Thoroughly test all Animal methods, with all the actions
      ///   clearly labeled for a person *not* reading the code.
      /// Start by creating a new Animal...
      public static void main()
      {
         // Console.WriteLine("TestAnimal still needs to be implemented");

         Animal frog = new Animal("Froggy");
         // frog.name = "Froggy";
         // frog.Greet();
         // frog.Eat("fly");
         // frog.Eat("worm");
         // frog.Excrete();
         // frog.Excrete();
         // frog.Excrete();
         // foreach (string ele in frog.gut)
         // {
         //    Console.WriteLine($"{ele} is in the gut");
         // }
         // frog.Print();
         // Console.WriteLine(frog.ToString());
         // Console.WriteLine(frog.name);

         Employee employee = new Employee { Name = "John", Salary = 100000 };
         Console.WriteLine(employee.ToString());
         Console.WriteLine(employee);
         employee.Print();

      }
   }
}