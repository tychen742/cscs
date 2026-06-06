using System;
using System.IO;


namespace IntroCSCS
{
    internal class Ch07File
    {
        private static void Main(string[] args)
        {

            // var str1 = "This is a test on File class";
            // var str2 = "This is a test on FileStream class";
            // fileOpFile("TestFile", str1); // filename, write content, check file existence
            // fileOpFileStream("TestFileStream", str2); // filename, write content, check file existence


            // StreamWriter writer = new StreamWriter("sample.txt");
            // writer.WriteLine("This program is writing");
            // writer.WriteLine("our first file.");
            // writer.Close();

            // StreamReader reader = new StreamReader("sample.txt");
            // string? line = reader.ReadLine();  // first line
            // Console.WriteLine(line);
            // line = reader.ReadLine();         // second line
            // Console.WriteLine(line);
            // reader.Close();


            // string userFileName = UI.PromptLine("Enter name of file to print: ");
            // var reader = new StreamReader(userFileName);
            // while (!reader.EndOfStream)
            // {
            //     string line = reader.ReadLine();
            //     Console.WriteLine(line);
            // }
            // reader.Close();

            // string filename = UI.PromptLine(
            //          "Enter the name of a file of integers: ");
            // if (File.Exists(filename))
            // {
            //     Console.WriteLine("The sum is {0}", CalcSum(filename));
            // }
            // else
            // {
            //     Console.WriteLine("Bad file name {0}", filename);
            // }

            StreamReader sr = new StreamReader("integers.txt");
            while (sr.Peek() >= 0){
                Console.WriteLine(sr.ReadLine());
            }

        }

        // public static StreamReader PromptFile(string prompt)
        // {


        // }
        /// Open, read and close the named file and
        /// return the sum of an int from
        /// each line that is not just white space.
        static int CalcSum(string filename)
        {
            int sum = 0;
            var reader = new StreamReader(filename);
            while (!reader.EndOfStream)
            {
                string sVal = reader.ReadLine().Trim();
                if (sVal.Length > 0)
                {
                    sum += int.Parse(sVal);
                }
            }
            reader.Close();
            return sum;
        }
        static void fileOpFile(string path, string str)
        {

            File.WriteAllText(path, str);

            {
                if (File.Exists(path))
                {
                    Console.WriteLine($"The file {path} exists.");
                }
            }


        }
        static void fileOpFileStream(string path, string str)
        {
            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine(str);
            writer.Close();
        }
    }
}
