// NOTE: searching.cs, binary_searching.cs, and sorting.cs in this folder are
// modernized versions of the corresponding files in examples/searching/,
// examples/binary_searching/, and examples/sorting/. They differ in:
//   - namespace: IntroCSCS (here) vs. IntroCS (examples/)
//   - method names: BubbleSort (here) vs. IntArrayBubbleSort (examples/)
//   - indentation/code style updated to current conventions
// These copies are intentional — this is a standalone .NET 8 project while
// examples/ targets an older framework.

namespace IntroCSCS
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ////////// linear search #1 //////////
            int min = 0;
            int max = 10;
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8 };
            // int[] data = new int[max];
            // Random rand = new Random();
            // for (int i = 0; i < data.Length; i++)
            // {
            //     data[i] = rand.Next(min, max);
            // }
            // foreach (var ele in data)    // test
            // {
            //     Console.WriteLine(ele);
            // }

            ////////// linear search #1 //////////
            Console.Write("Your int array: ");
            foreach (int num in nums)
            {
                Console.Write($"{num} ");
            }
            Console.WriteLine(Searching.IntArrayLinearSearch(nums, 6));

            ////////// binary search //////////
            // BinarySearching bs = new BinarySearching();
            int item = 6;
            Console.WriteLine(BinarySearching.IntArrayBinarySearch(nums, item));

            string input = UI.PromptLine(
                "Please enter integers, separated by spaces and/or comma: "
            );
            int[] data = ExtractFromString.IntsFromString(input);
            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine("data[{0}]={1}", i, data[i]);
            }
            string prompt = "Please enter a number to find (blank line to end): ";
            input = UI.PromptLine(prompt);
            while (input.Length > 0)
            {
                int searchItem = int.Parse(input);
                int searchPos = UI.PromptIntInRange(
                    "At what position should the search start? ",
                    0,
                    data.Length
                );
                int foundPos = Searching.IntArrayLinearSearch(data, searchItem, searchPos);
                if (foundPos < 0)
                {
                    Console.WriteLine("Item {0} not found", searchItem);
                }
                else
                {
                    Console.WriteLine("Item {0} found at position {1}", searchItem, foundPos);
                }
                input = UI.PromptLine(prompt);
            }
        }

        ////////// Linear Search: Moved to searching.cs Searching //////////
        // public static int IntArrayLinearSearch(int[] data, int item)
        // {
        //     int N = data.Length;
        //     for (int i = 0; i < N; i++)
        //     {
        //         if (data[i] == item)
        //         {
        //             return i;
        //         }
        //     }
        //     return -1;
        // }
    }
}
