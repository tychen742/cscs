using System;

// Addition1: flat version without a helper function.
// Compare with addition2, which introduces SumProblemString().
class Addition1
{
   static void Main()
   {
      int x = 2, y = 3;
      int sum = x + y;
      Console.WriteLine("The sum of " + x + " and " + y + " is " + sum + ".");

      x = 12345; y = 53579;
      sum = x + y;
      Console.WriteLine("The sum of " + x + " and " + y + " is " + sum + ".");

      Console.Write("Enter an integer: ");
      int a = int.Parse(Console.ReadLine());
      Console.Write("Enter another integer: ");
      int b = int.Parse(Console.ReadLine());
      sum = a + b;
      Console.WriteLine("The sum of " + a + " and " + b + " is " + sum + ".");
   }
}
