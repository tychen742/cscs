using System;
using System.Collections.Generic;
namespace IntroCSCS
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ///// hello world
            // Console.WriteLine("hello, world");

            ///// Main method command line args
            // int sum = 0;
            // for (int i = 0; i < args.Length; i++)
            // {
            //     sum = sum + int.Parse(args[i]);
            // }
            // Console.WriteLine(sum);

            /////////////// list
            // var words = new List<string>();
            // List<string> words = new List<string>();
            // string[] temp = { "apple", "banana", "cherry" };
            // foreach (string s in temp)
            // {
            //     words.Add(s);
            // }
            // foreach (string s in words)
            // {
            //     Console.WriteLine(s);
            // }

            string[] fruits = { "apple", "cherry", "banana" };

            SortFruits(fruits);

        }

        static void SortFruits(string[] fruits)
        {

            // fruits.ToList();
            var f = new List<string>(fruits); 
            Console.WriteLine(fruits.GetType());
            Console.WriteLine(f.GetType());
            f.Sort();
            foreach (string fruit in f)
            {
                Console.WriteLine(fruit);
            }
        }
    }
}