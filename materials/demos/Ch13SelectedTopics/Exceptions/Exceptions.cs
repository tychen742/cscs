namespace Excepts
{
    public class Except1
    {
        public static void checkAge(int age)
        {
            try
            {
                if (age < 18)
                {
                    throw new ArithmeticException("Access denied: you must be at least 18 years old to play this game.");
                }
                else
                {
                    Console.WriteLine("Access granted: You are old enough.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}