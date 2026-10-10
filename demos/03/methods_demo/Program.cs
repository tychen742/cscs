namespace MethodDemo;

internal class Program
{
    static void Main()
    {
        Console.WriteLine(LastFirst("Benjamin", "Franklin"));
        Console.WriteLine(LastFirst("Andrew", "Harrington"));
        Console.WriteLine(SumProblemString(2, 3));
        Console.WriteLine(SumProblemString(12345, 53579));
        Console.Write("Enter an integer: ");
        int a = int.Parse(Console.ReadLine() ?? throw new EndOfStreamException());
        Console.Write("Enter another integer: ");
        int b = int.Parse(Console.ReadLine() ?? throw new EndOfStreamException());
        Console.WriteLine(SumProblemString(a, b));
        MyMethod();
        MyMethod2();
        Console.WriteLine(SquareTheNumber(4));
        Console.WriteLine(SquareTheNumber(4) + SquareTheNumber(4));
        Console.WriteLine(SquareTheNumber(5));
        Verse("chicken", "buk");
    }

    static string SumProblemString(int a, int b) => $"{a} + {b} = {a + b}";
    static string LastFirst(string firstName, string lastName) => $"Hi, {firstName} {lastName}!";
    static int SquareTheNumber(int number) => number * number;

    static void MyMethod()
    {
        Console.WriteLine("aaaaa");
        Console.WriteLine("bbbbb");
    }

    static void MyMethod2()
    {
        Console.WriteLine("ccccc");
        Console.WriteLine("ddddd");
    }

    public static void Verse(string animal, string noise)
    {
        Console.WriteLine("Old MacDonald had a farm");
        Console.WriteLine("E-I-E-I-O");
        Console.WriteLine($"And on that farm he had a {animal}");
        Console.WriteLine("E-I-E-I-O");
        Console.WriteLine($"With a {noise}-{noise} here");
        Console.WriteLine($"And a {noise}-{noise} there");
        Console.WriteLine($"Here a {noise}, there a {noise}");
        Console.WriteLine($"Everywhere a {noise}-{noise}");
        Console.WriteLine("Old MacDonald had a farm");
        Console.WriteLine("E-I-E-I-O");
    }
}
