
static int PromptIntInRange(string prompt, int lowLim, int highLim)
{
    int number = UIF.PromptInt(prompt);
    while (number < lowLim || number > highLim)
    {
        Console.WriteLine("{0} is out of range!", number);
        number = UIF.PromptInt(prompt);
    }
    return number;
}
