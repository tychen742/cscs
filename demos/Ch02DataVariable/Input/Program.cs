namespace InputOutput;

class Input
{

   public static void Main(string[] args)
   {
      // string dayOfWeek = "Monday";
      // Console.WriteLine(dayOfWeek); 
      // string toBeOrNot1 = ""To be, or not to be" is a speech given by Prince Hamlet.";
      string toBeOrNot2 = "\"To be, or not to be\" is a speech given by Prince Hamlet.";

      // Console.WriteLine(toBeOrNot1);
      Console.WriteLine(toBeOrNot2);

      Console.WriteLine("Enter your age: ");      // prompt
      var ageInput = Console.ReadLine();          // save input to variable

      Console.WriteLine(ageInput.GetType());      // check type: string
      Console.WriteLine(ageInput);

      int age = int.Parse(ageInput);               // casting type to int

      Console.WriteLine(age.GetType());
      Console.WriteLine(age);

      // double
      string s = "34.5";
      double d = double.Parse(s);
      Console.WriteLine(d);

      Console.WriteLine("Enter your name: ");
      string name = Console.ReadLine();

      Console.WriteLine("Hello, " + name);


      string firstName;

      Console.Write("Enter you first name: ");
      firstName = Console.ReadLine();

      Console.WriteLine("Hiya, " + firstName + "!");

      Console.WriteLine("Hiya, {0}!", firstName);

      string lastName = "Chen";

      Console.WriteLine("My first name is {0} and my last name is {1}.", firstName, lastName);



      int n = PromptIntInRange("Enter a score (0 through 100): ", 0, 100);
      Console.WriteLine("Your score is {0}.", n);
      Console.WriteLine("Try another test.");
      n = PromptIntInRange("Enter a number (-10 through 10): ", -10, 10);
      Console.WriteLine("Your number is {0}.", n);

   }
}


class GoodSum
{
   static void SumTwo()
   {
      Console.Write("Enter an integer: ");
      string xString = Console.ReadLine();
      int x = int.Parse(xString);
      Console.Write("Enter another integer: ");
      string yString = Console.ReadLine();
      int y = int.Parse(yString);
      int sum = x + y;
      Console.WriteLine("They add up to " + sum);
   }
}