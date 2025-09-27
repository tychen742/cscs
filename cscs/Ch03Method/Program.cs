using System;
internal class Program
{
    private static void Main(string[] args)
    {
        ////////// LastFirst //////////
        Console.WriteLine(LastFirst("Benjamin", "Franklin"));
        Console.WriteLine(LastFirst("Andrew", "Harrington"));

        ////////// AddTwo //////////
        Console.WriteLine(SumProblemString(2, 3));
        Console.WriteLine(SumProblemString(12345, 53579));
        Console.Write("Enter an integer: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Enter another integer: ");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine(SumProblemString(a, b));

        MyMethod();                      // method MyMethod (line# 9) is called
        MyMethod2();


        int digit = 4;
        int squaredNum = SquareTheNumber(digit);
        int squaredAndSummed = squaredNum + SquareTheNumber(digit);

        Console.WriteLine(squaredNum);
        Console.WriteLine(squaredAndSummed);
        Console.WriteLine(SquareTheNumber(5));

        ///// verse
        Verse("chicken", "buk");
    }

    public static void Verse(String animal, String noise)
    {
        Console.WriteLine("Old MacDonald had a farm");
        Console.WriteLine("E-I-E-I-O");
        Console.WriteLine("And on that farm he had a " + animal);
        Console.WriteLine("E-I-E-I-O");
        Console.WriteLine("With a " + noise + "-" + noise + " here");
        Console.WriteLine("And a " + noise + "-" + noise + " there");
        Console.WriteLine("Here a " + noise + ", there a " + noise);
        Console.WriteLine("Everywhere a " + noise + "-" + noise);
        Console.WriteLine("Old MacDonald had a farm");
        Console.WriteLine("E-I-E-I-O");
    }

    static int SquareTheNumber(int num)
    {
        return num * num;
    }


    static string LastFirst(string firstName, string lastName)
    {
        string separator = ", ";
        string result = "Hi, " + firstName + " " + lastName + "!";
        return result;
    }

}

class TryMethods                       // class declaration

{


    static void MyMethod()              // static: the method can be called directly as a member of the class
    {                                   // void: no return to caller; just print something here
        Console.WriteLine("aaaaa");
        Console.WriteLine("bbbbb");
    }

    void MyMethod2()              // static: the method can be called directly as a member of the class
    {                                   // void: no return to caller; just print something here
        Console.WriteLine("ccccc");
        Console.WriteLine("ddddd");
    }

}