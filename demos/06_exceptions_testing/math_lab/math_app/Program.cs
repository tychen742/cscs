namespace SomeMath
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BasicMath math = new BasicMath();
            Console.WriteLine($"10 + 10 = {math.Add(10, 10)}");
            Console.WriteLine($"10 - 10 = {math.Subtract(10, 10)}");
            Console.WriteLine($"10 / 5 = {math.Divide(10, 5)}");
            Console.WriteLine($"10 * 10 = {math.Multiply(10, 10)}");
        }
    }

    public class BasicMath
    {
        public double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        public double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        public double Divide(double num1, double num2)
        {
            return num1 / num2;
        }

        public double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }
    }
}
