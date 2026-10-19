Console.Write("What is the temperature? ");
string? input = Console.ReadLine();
if (double.TryParse(input, out double temperature))
{
    if (temperature > 70) Console.WriteLine("Wear shorts.");
    else Console.WriteLine("Wear long pants.");
    Console.WriteLine("Get some exercise outside.");
}
else Console.WriteLine("Enter a numeric temperature.");
