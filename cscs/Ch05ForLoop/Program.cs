namespace IntroCSCS
{

    internal class Chapter05
    {
        private static void Main(string[] args)
        {
            // Console.WriteLine("Hello, World!");
            // CountToTen();
            // PostfixOperation();
            // PostfixIncrement();
            // PrefixIncrement();

            // PrintReps("Ok", 9);
            // Console.WriteLine(StringOfReps("Ok", 9));

            // Flip();
            // Flip coin 10 times
            // for (int i = 0; i < 10; i++)
            // {
            //     Console.WriteLine(Flip());
            // }

            // GroupFlips(10, 9);

            ReverseString("abcde");
        }
        static void GroupFlips(int total, int groupSize)
        {
            int numLines = (int)Math.Ceiling((double)(total / groupSize));

            for (int i = 0; i < numLines; i++)
            {
                for (int j = 0; j < groupSize; j++)
                {
                    Flip();
                }
                Console.WriteLine("");
            }
            for (int j = 0; j < total % groupSize; j++)
            {
                Flip();
            }
            Console.WriteLine("");
        }

        static string Flip()
        {
            Random r = new Random();



            int n = r.Next(0, 2);
            if (n == 0)
            {
                Console.Write("Heads ");
            }
            else
            {
                Console.Write("Tails ");
            }

            // else
            // {

            // Console.WriteLine("");
            return "";
            // }


        }
        static void PrintReps(string s, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write(s);
            }
            Console.WriteLine();
        }

        static string StringOfReps(string s, int n)
        {
            string temp = "";
            for (int i = 0; i < n; i++)
            {
                temp = temp + s;
            }
            return temp;
        }

        static void ReverseString(string s)
        {
            char[] newS = s.ToCharArray();
            Array.Reverse(newS);
            foreach (char ch in newS)
            {
                // newS = newS.Insert(0,  ch.ToString()
                Console.Write(ch);
            }
            Console.WriteLine();
        }
        static string OnlyLetters(string s)
        {
            
        }
        static int Factorial(int n)
        {  // body
            return 1;  // so it compiles
        }

        static void CountToTen()
        {
            for (int i = 1; i <= 10; i = i + 1)
            {
                Console.WriteLine(i);
            }
        }

        static void PostfixIncrement()
        {
            int i = 0;
            Console.WriteLine("i == {0}", i);
            Console.WriteLine("i++ == {0}", i++);
            Console.WriteLine("i == {0}", i);
        }

        static void PrefixIncrement()
        {
            int j = 0;
            Console.WriteLine("j == {0}", j);
            Console.WriteLine("++j == {0}", ++j);
            Console.WriteLine("j == {0}", j);
        }


    }
}