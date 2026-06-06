namespace InputOutput;

class MathOperations
{
    public static void Demo()
    {
        int x = 3;
        int y = x + 2;
        y = 2 * y;
        x = y - x;

        Console.WriteLine(x + " " + y);
    }
}