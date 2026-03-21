namespace IntroCSCS
{
    class MethodOverLoading
    {
        public int Add(int num1, int num2)
        {
            return (num1 + num2);
        }
        public int Add(int num1, int num2, int num3)
        {
            return (num1 + num2 + num3);
        }
        public float Add(float num1, float num2)
        {
            return (num1 + num2);
        }
        public string Add(string value1, string value2)
        {
            return (value1 + " " + value2);
        }
    }
}