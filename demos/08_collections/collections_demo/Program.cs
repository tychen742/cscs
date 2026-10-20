using System;
using System.Collections.Generic;
namespace IntroCSCS
{
    /// <summary>
    /// Animal record
    /// </summary>
    public record Animal(int Age, string Name, int Legs, string Sound);

    internal class Program
    {

        private static void Main(string[] args)
        {

            /////////////// array (fixed size)
            Console.WriteLine("");
            Console.WriteLine("Collections: Arrays");
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
            Console.WriteLine("\n");


            /////////////// list (dynamic size)
            Console.WriteLine("--- Collections: Lists ---");
            var words = new List<string>();
            // List<string> words = new List<string>();
            string[] temp = { "apple", "banana", "cherry" };    // array of strings
            foreach (string s in temp)
            {
                words.Add(s);
            }
            foreach (string s in words)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            /////////////// list (dynamic size)
            var animals = new List<Animal>();
            // List<Animal> animals = new List<Animal>();
            animals.Add(new Animal(5, "Dog", 4, "Woof"));
            animals.Add(new Animal(3, "Cat", 4, "Meow"));
            foreach (Animal a in animals)
            {
                Console.WriteLine($"{a.Name} is {a.Age} years old, has {a.Legs} legs and says {a.Sound}.");
            }

            /////////////// dictionary (key-value pairs)
            Console.WriteLine();
            Console.WriteLine("--- Collections: Dictionary ---");
            // Dictionary<string, int> ages = new Dictionary<string, int>();
            var ages = new Dictionary<string, int>();
            ages.Add("Alice", 30);
            ages.Add("Bob", 25);
            ages.Add("Charlie", 35);
            foreach (var kvp in ages)
            {
                Console.WriteLine($"{kvp.Key} is {kvp.Value} years old.");
            }

            /////////////// hashset (unique values)
            Console.WriteLine();
            Console.WriteLine("--- Collections: HashSet ---");
            var uniqueNumbers = new HashSet<int>();
            uniqueNumbers.Add(1);
            uniqueNumbers.Add(2);
            uniqueNumbers.Add(2); // Duplicate, will not be added
            uniqueNumbers.Add(2); // Duplicate, will not be added
            uniqueNumbers.Add(3);
            foreach (int n in uniqueNumbers)
            {
                Console.Write(n + " ");
            }
            Console.WriteLine();



            /////////////// stack (last in first out (LIFO))
            Console.WriteLine();
            Console.WriteLine("--- Collections: Stack ---");
            var stack = new Stack<string>();
            stack.Push("First");
            stack.Push("Second");
            stack.Push("Third");
            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }

            /////////////// queue: first in first out (FIFO)
            Console.WriteLine();
            Console.WriteLine("--- Collections: Queue ---");
            var queue = new Queue<string>();
            queue.Enqueue("First");
            queue.Enqueue("Second");
            queue.Enqueue("Third");
            queue.Enqueue("Third");
            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }

            /////////////// sortedlist (sorted by key)
            Console.WriteLine();
            Console.WriteLine("--- Collections: SortedList ---");
            var sortedList = new SortedList<int, string>();
            sortedList.Add(3, "Three");
            sortedList.Add(1, "One");
            sortedList.Add(2, "Two");
            foreach (var kvp in sortedList)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            /////////////// linkedlist (doubly linked list)
            Console.WriteLine();
            Console.WriteLine("--- Collections: LinkedList ---");
            var linkedList = new LinkedList<string>();
            linkedList.AddLast("First");
            linkedList.AddLast("Second");
            linkedList.AddLast("Third");
            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
