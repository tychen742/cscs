using System;
using System.Security.Principal;
namespace IntroCSCS
{
    class Ch06WhileLoop
    {

        static void Main() //testing routine
        {
            // // string to char
            // Console.Write("Please enter a string: ");
            // string s = Console.ReadLine();
            // OneCharPerLine(s);

            // Calculate_Investment_Growth();
            // RightTriangle();
            // Console.WriteLine(SumToN(100));
            // LoanTable(1000m, .05m, 196m);


            // generate a number
            Random r = new Random();
            int secret = r.Next(1, 100);
            int guess = 0;
            //  ask for a number


            do
            {
                Console.WriteLine("Please choose 1 to 100");
                guess = int.Parse(Console.ReadLine());

                if (guess > secret)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("Higher");
                }

            } while (guess != secret);



        }

        static void LoanTable(decimal principal, decimal rate, decimal payment)
        {

            int count = 1;
            Console.WriteLine("{0, 6} {1,10:C2} {2,10:C2} {3,10:C2}", "Number", "Principal", "Interest", "Payment");

            do
            {

                // decimal interest = principal * rate / 100;
                decimal interest = Math.Round(principal * rate, 2);

                if ((principal + interest) < payment)
                {
                    payment = principal + interest;
                }

                Console.WriteLine("{0,6} {1,10:N2} {2,10:N2} {3,10:N2}", count, principal, interest, payment);

                principal = (principal - payment) + interest;

                count++;


                // Console.WriteLine(interest);
                // Console.WriteLine(payment);

                // principal = principal - principal * interestRate;

            } while (principal > 0);
        }

        static int SumToN(int n)
        {
            int sum = 0;
            for (int i = 0; i <= n; i++)
            {
                sum = sum + i;
            }
            return sum;
        }

        static void RightTriangle()
        {
            int a, b, c;
            do
            {
                Console.WriteLine("Think of integer sides for a right triangle.");
                a = UI.PromptInt("Enter integer leg: ");
                b = UI.PromptInt("Enter another integer leg: ");
                c = UI.PromptInt("Enter integer hypotenuse: ");
                if (a * a + b * b != c * c)
                {
                    Console.WriteLine("Not a right triangle: Try again!");
                }
            } while (a * a + b * b != c * c);
        }

        static void OneCharPerLine(string s)
        {
            int i = 0;
            while (i < s.Length)
            {
                Console.WriteLine(s[i]);
                i++;
            }
        }


        static void Calculate_Investment_Growth()
        {
            // Get user inputs
            Console.Write("Enter the monthly investment amount: ");
            double monthlyInvestment = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the annual return rate as a decimal (e.g., 0.05 for 5%): ");
            double annualRate = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter the desired final balance: ");
            double desiredBalance = Convert.ToDouble(Console.ReadLine());

            // Initialize variables
            double balance = 0.0;
            int years = 0;

            // Print the initial balance
            Console.WriteLine($"Year: {years}, Balance: ${balance:F2}");

            // Loop until the balance reaches the desired amount
            while (balance < desiredBalance)
            {
                // Calculate the balance at the end of the year
                for (int month = 0; month < 12; month++)
                {
                    balance += monthlyInvestment; // Add monthly investment
                    balance *= (1 + annualRate / 12); // Apply monthly compounded interest
                }

                years++;
                Console.WriteLine($"Year: {years}, Balance: ${balance:F2}");
            }
        }                              // past new chunk


    }
}
