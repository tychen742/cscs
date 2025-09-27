namespace IntroCSCS
{
    interface IA
    {
        void M() { Console.WriteLine("IA.M"); } 
    }                       // a concrete method

    class C : IA { }        // no need to implement; use directly
                            // see Program.cs
}