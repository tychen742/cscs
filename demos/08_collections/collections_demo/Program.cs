using System;
using System.Collections.Generic;
namespace IntroCSCS
{
        public record Animal(int Age, string Name, int Legs, string Sound);
    internal class Program
    {

        private static void Main(string[] args)
        {
           
            ///// Main method command line args
            // int sum = 0;
            // for (int i = 0; i < args.Length; i++)
            // {
            //     sum = sum + int.Parse(args[i]);
            // }
            // Console.WriteLine(sum);

            Console.WriteLine("Collections:Arrays");
            // int[] numbers = { 1, 2, 3, 4, 5 };
            int[] numbers = new int[5];
            // numbers[0] = 1;
            // numbers[1] = 2;
            // numbers[2] = 3;
            // numbers[3] = 4;
            // numbers[4] = 5;
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i + 1;
            }

            foreach (int n in numbers)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();

            
            /////////////// list
            Console.WriteLine("--- Collections:Lists ---");
            var words = new List<string>();
            // List<string> words = new List<string>();
            string[] temp = { "apple", "banana", "cherry" };
            foreach (string s in temp)
            {
                words.Add(s);
            }
            foreach (string s in words)
            {
                Console.Write(s + " ");
            }
Console.WriteLine();

            /////////////// dictionary
            Console.WriteLine("--- Collections:Dictionary ---");
            var ages = new Dictionary<string, int>();
            ages.Add("Alice", 30);
            ages.Add("Bob", 25);
            ages.Add("Charlie", 35);
            foreach (var kvp in ages)
            {
                Console.WriteLine($"{kvp.Key} is {kvp.Value} years old.");
            }

        }
    }
}
