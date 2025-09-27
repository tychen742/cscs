   class CheckID
   {
      public string name;
      public CheckID(string name)
      {
         this.name = name;
      }

      public void PrintResult()
      {
        // if ID for this name exists
        Console.WriteLine($"{name} has an existing ID!");
      }
      // ....
      // ....
   }
internal class Program
{
    static void Main(string[] args)
    {
        // string greeting = "hello";

        // Console is a class 
        // and WriteLine is one of its members
        // Console.WriteLine(greeting.Length); // Prints 5

        CheckID check = new CheckID("taylor swift");
        // access members using dot "." notation
        check.PrintResult();

        // DoMath doMath = new DoMath();
        // int aSum = doMath.Sum(2, 2);
        // Console.WriteLine(aSum);
 
        // int aSum = SomeMath.Sum(2, 2);
        // Console.WriteLine(aSum);
    }

}



class DoMath
{

    public int Sum(int num1, int num2)
    {
        var total = num1 + num2;
        return total;
    }
}

static class SomeMath
{
    public static int Sum(int a, int b)
    {
        return a + b;
    }
}