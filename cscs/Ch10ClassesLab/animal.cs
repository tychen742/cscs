using System;
using Microsoft.VisualBasic;

namespace IntroCSCS
{
   class Animal
   {
      public string name;
      public List<string> gut = new List<string>();

      public Animal(string name)
      {
         this.name = name;
      }
      public void Greet()
      {
         Console.WriteLine($"Hello, my name is {name}");
      }

      public void Eat(string food)
      {
         // Console.WriteLine("testing Eat()");
         gut.Add(food);
      }
      public void Excrete()
      {
         if (gut.Any())
         {
            Console.WriteLine(gut[0]);
            gut.RemoveAt(0);
         }
         else
         {
            Console.WriteLine("");
         }
      }
      public override string ToString()
      {
         return string.Format(@"Animal: {0}", name);
      }
      public void Print()
      {
         Console.WriteLine(ToString());
      }

   }

   class Employee
   {
      public string Name { get; set; }
      public int Salary { get; set; }

      public override string ToString()
      {
         return "Employee: " + Name + " " + Salary;
      }

      public void Print()
      {
         // Console.WriteLine(ToString());
         Console.WriteLine(this);
      }
   }
}