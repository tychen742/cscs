// using System.Collections.Generic;

namespace IntroCSCS;
internal class Adder
{

    // private static void Main(string[] args)
    // {
//	Adder(2, 5, 22)
    // }

    public static void Add(int a, int b, int c){
	int[] arr = new int[3];
	for (int i = 0; i < 3; i++){
	    Console.Write("Enter an integer: ");
	    arr[i] = int.Parse(Console.ReadLine());
	}
	
	int sum = 0;
	for (int j = 0; j < arr.Length; j++) {
	    sum = sum + arr[j];
 	}
	
	Console.WriteLine(sum);
    }

    static void twoD()
    {
        int[,] ints = new int[3, 4];
        // Console.WriteLine(ints.GetLength(0));
        // ints[0, 0] = 0;
        // ints[0, 1] = 1;
        // ints[0, 2] = 2;
        // ints[0, 3] = 3;
        // ints[1, 0] = 4;
        // ints[1, 1] = 5;
        // ints[1, 2] = 6;
        // ints[1, 3] = 7;
        // ints[2, 0] = 8;
        // ints[2, 1] = 9;
        // ints[2, 2] = 10;
        // ints[2, 3] = 11;

        Random random = new Random();
        for (int i = 0; i < ints.GetLength(0); i++)
        {
            for (int j = 0; j < ints.GetLength(1); j++)
            {
                ints[i, j] = random.Next(0, 10);
            }
        }

        Console.WriteLine();
        Console.WriteLine("test");
        Console.WriteLine("ints.Length: " + ints.Length);
        var m = ints.GetLength(0);
        var n = ints.GetLength(1);
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write("{0, 5}", ints[i, j]);
            }
            Console.WriteLine();
        }
    }
    static void MultiDArray(int m, int n)
    {
        // Console.WriteLine("test");
        // Console.WriteLine(table.Length);
        // int n = 4;
        int[][] table2 = new int[m][];
        table2[0] = new int[4] { 2, 3, 7, 55 };
        table2[1] = new int[4] { 3, 1, 8, 10 };
        table2[2] = new int[2] { 6, 0 };

        Console.WriteLine(table2[0][3]);

        // Display the array elements:
        for (int i = 0; i < table2.Length; i++)
        {
            System.Console.Write($"Element [{i}] Array: ");
            for (int j = 0; j < table2[i].Length; j++)
                Console.Write($"{table2[i][j]} ");
            Console.WriteLine();
        }

    }
    ////////// tri
    static void Tri()
    {
        int[][] tri = new int[4][]; //create four null int[] elements
        for (int i = 0; i < tri.Length; i++)
        { // Length 4 (rows)
            tri[i] = new int[i + 1];  // each row has a different length
        }
    
    for (int i = 0; i < tri.Length; i++){
        for (int j = 0; j < tri[0].Length; j++){
            Console.WriteLine("{0, 5}", tri[i][j]);
        }
    }
    
    }


}
