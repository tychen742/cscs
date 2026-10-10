using System.Reflection;
using System.Text;
using IntroCSCS;

// Compare demo results with independent reference behavior, including boundary cases.
internal class DemoChecks
{
    static int checks;

    static void Check(bool condition, string description)
    {
        checks++;
        if (!condition) throw new InvalidOperationException(description);
    }

    static T Call<T>(Type type, string name, params object[] args)
    {
        MethodInfo method = type.GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic)
            ?? throw new MissingMethodException(type.Name, name);
        return (T)method.Invoke(null, args)!;
    }

    static StreamReader Reader(string content) =>
        new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(content)));

    static void Main()
    {
        Action<int[]>[] sorts = {
            Sorting.BubbleSort, Sorting.IntArraySelectionSort, Sorting.IntArrayInsertionSort,
            Sorting.IntArrayShellSortNaive, Sorting.IntArrayShellSortBetter,
            Sorting.IntArrayQuickSort
        };
        var random = new Random(42);
        for (int length = 0; length <= 50; length++)
        {
            int[] source = Enumerable.Range(0, length).Select(_ => random.Next(-10, 11)).ToArray();
            int[] expected = (int[])source.Clone();
            Array.Sort(expected);
            foreach (Action<int[]> sort in sorts)
            {
                int[] actual = (int[])source.Clone();
                sort(actual);
                Check(actual.SequenceEqual(expected), $"Sort failed for length {length}.");
            }
            for (int target = -12; target <= 12; target++)
            {
                Check(Searching.IntArrayLinearSearch(source, target) == Array.IndexOf(source, target),
                    "Linear search must return the first occurrence or -1.");
                int index = BinarySearching.IntArrayBinarySearch(expected, target);
                Check(Array.IndexOf(expected, target) < 0 ? index == -1 : index >= 0 && expected[index] == target,
                    "Binary search returned an incorrect match or missing result.");
            }
            Check(Call<int>(typeof(IntroCS.ArrayLab), "CountEven", source) == source.Count(x => x % 2 == 0),
                "Even count is incorrect.");
            if (length > 0)
                Check(Call<int>(typeof(IntroCS.ArrayLab), "Minimum", source) == source.Min(),
                    "Minimum is incorrect.");
            Check(Call<bool>(typeof(IntroCS.ArrayLab), "IsAscending", expected), "Sorted array should be ascending.");
            int[] sums = Call<int[]>(typeof(IntroCS.ArrayLab), "NewPairwiseAdd", source, source);
            Check(sums.SequenceEqual(source.Select(x => 2 * x)), "Pairwise sums are incorrect.");
        }
        Check(!Call<bool>(typeof(IntroCS.ArrayLab), "IsAscending", new[] { 2, 5, 3, 8 }),
            "Descending pair must be detected.");
        Check(Call<int>(typeof(ForLoopDemo), "Factorial", 0) == 1, "0! must be 1.");
        Check(Call<int>(typeof(ForLoopDemo), "Factorial", 5) == 120, "5! must be 120.");
        Check(Call<string>(typeof(ForLoopDemo), "OnlyLetters", "Order #42: Ready!") == "OrderReady",
            "Letter filtering is incorrect.");

        using (var reader = Reader("first line\nsecond line"))
        {
            var paragraphs = IntroCS.FileUtil.GetParagraphs(reader);
            Check(paragraphs.Count == 1 && paragraphs[0].Contains("second line"),
                "Paragraph at EOF must be retained without a trailing blank line.");
        }
        using (var reader = Reader("\ncrash\nRestart the app.\n\nslow\nCheck the queue."))
        {
            var responses = IntroCS.FileUtil.GetDictionary(reader);
            Check(responses.Count == 2 && responses["slow"].Contains("Check the queue."),
                "Dictionary must handle blank lines and final value at EOF.");
        }
        using (var reader = Reader(""))
            Check(IntroCS.FileUtil.GetDictionary(reader).Count == 0, "Empty dictionary file must be accepted.");

        TextReader originalInput = Console.In;
        TextWriter originalOutput = Console.Out;
        try
        {
            Console.SetOut(TextWriter.Null);
            Console.SetIn(new StringReader("not-an-int\n99999999999999999999\n42\n"));
            Check(IntroCSCS.UI.PromptInt("") == 42, "Input helper must reject malformed/overflowing integers.");
            Console.SetIn(new StringReader("Infinity\n1e9999\n2.5\n"));
            Check(IntroCSCS.UI.PromptDouble("") == 2.5, "Input helper must reject nonfinite doubles.");
            Console.SetIn(new StringReader("not-an-int\n42\n"));
            Check(IntroCS.UI.PromptInt("") == 42, "Alternative input helper must retry invalid input.");
            Console.SetIn(new StringReader(""));
            bool ended = false;
            try { IntroCSCS.UI.PromptLine(""); }
            catch (EndOfStreamException) { ended = true; }
            Check(ended, "EOF must terminate input rather than retry forever.");
        }
        finally
        {
            Console.SetIn(originalInput);
            Console.SetOut(originalOutput);
        }
        Check(new Rectangle(3, 4).GetArea() == 12, "Rectangle area is incorrect.");
        Check(new Triangle(3, 4).GetArea() == 6, "Triangle area is incorrect.");
        Check(Math.Abs(new Circle(2).GetArea() - 4 * Math.PI) < 1e-10, "Circle area is incorrect.");
        Console.WriteLine($"Passed {checks} demo behavior checks.");
    }
}
