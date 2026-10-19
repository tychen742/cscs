namespace IntroCSCS;

internal class Program
{
    static void Main(string[] args)
    {
        if (args.Length > 0 && args[0] == "guess") GuessGame.Run();
        else if (args.Length > 0 && args[0] == "static-guess") Game.main();
        else TestAnimal.main();
    }
}
