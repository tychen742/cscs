string text = "abcde";
for (int i = text.Length - 1; i >= 0; i--) Console.Write(text[i]);
Console.WriteLine();
string order = "Order #42: Ready!";
foreach (char letter in order)
{
    if ((letter >= 'A' && letter <= 'Z') || (letter >= 'a' && letter <= 'z'))
        Console.Write(letter);
}
Console.WriteLine();
int factorial = 1;
for (int i = 2; i <= 5; i++) factorial *= i;
Console.WriteLine($"5! = {factorial}");
for (int i = 0; i < 3; i++) Console.Write("Ok");
Console.WriteLine();
