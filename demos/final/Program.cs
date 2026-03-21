internal class Program
{
    private static void Main(string[] args)
    {
        // access Level.Medium in Enums.cs
        // Level myVar = Level.Medium;
        // Console.WriteLine(myVar);

        // int april = (int)Months.April;
        // Console.WriteLine(april);
        Console.Write(User("TY", "333"));

    }

    public void User (string name, string phone){

        
        Console.WriteLine($"Name is {name}");
        Console.WriteLine($"Phone is {phone}");

    }
}