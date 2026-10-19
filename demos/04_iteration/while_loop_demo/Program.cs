// A supplied built-in call selects the secret; no custom methods are needed.
int secret = Random.Shared.Next(1, 101);
bool correct = false;
while (!correct)
{
    Console.Write("Guess a number (1-100): ");
    string? input = Console.ReadLine();
    if (input == null) { Console.WriteLine("No more input."); break; }
    if (!int.TryParse(input, out int guess)) { Console.WriteLine("Enter a whole number."); continue; }
    if (guess == secret) { Console.WriteLine("Correct!"); correct = true; }
    else if (guess < secret) Console.WriteLine("Higher.");
    else Console.WriteLine("Lower.");
}
