namespace IntroCSCS
{

    class Chapter04
    {
        static void Main(string[] args)
        {
            // Rolla();
            // Weight();
            Clothes();

            // Calculate Wages
            // Console.Write("Enter hours worked: ");
            // double hours = double.Parse(Console.ReadLine());
            // Console.Write("Enter dollars paid per hour: ");
            // double wage = double.Parse(Console.ReadLine());
            // double total = CalcWeeklyWages(hours, wage);
            // Console.WriteLine(
            //    "Wages for {0} hours at ${1:F2} per hour are ${2:F2}.",
            //    hours, wage, total);
        }

        internal static void Rolla()
        {
            bool isRollaQuiet = true;
            bool isChicagoClose = false;
            Console.WriteLine(isRollaQuiet);   // Outputs True
            Console.WriteLine(isChicagoClose);   // Outputs False
        }
        public static void Weight()
        {
            Console.Write("How many pounds does your suitcase weigh? ");
            double weight = double.Parse(Console.ReadLine());
            if (weight > 50)
            {
                Console.WriteLine("There is a $25 charge for luggage that heavy.");
            }
            Console.WriteLine("Thank you for your business.");
        }

        public static void Clothes()
        {
            Console.Write("What is the temperature? ");
            double temperature = double.Parse(Console.ReadLine());
            if (temperature > 70)
            {
                Console.WriteLine("Wear shorts.");
            }
            else
            {
                Console.WriteLine("Wear long pants.");
            }
            Console.WriteLine("Get some exercise outside.");
        }

        static char LetterGrade(double score)
        {
            char letter;
            if (score >= 90)
            {
                letter = 'A';
            }
            else
            {   // grade must be B, C, D or F 
                if (score >= 80)
                {
                    letter = 'B';
                }
                else
                { // grade must be C, D or F 
                    if (score >= 70)
                    {
                        letter = 'C';
                    }
                    else
                    {   // grade must D or F 
                        if (score >= 60)
                        {
                            letter = 'D';
                        }
                        else
                        {
                            letter = 'F';
                        }
                    }   //end else D or F
                }      // end of else C, D, or F
            }         // end of else B, C, D or F
            return letter;
        }
        static double CalcWeeklyWages(double totalHours, double hourlyWage)
        {
            double totalWages;
            if (totalHours <= 40)
            {
                totalWages = hourlyWage * totalHours;
            }
            else
            {
                double overtime = totalHours - 40;
                totalWages = hourlyWage * 40 + (1.5 * hourlyWage) * overtime;
            }
            return totalWages;
        }
    }
}
