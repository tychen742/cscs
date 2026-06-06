namespace IntroCSCS
{
    class Vehicle                               // base class (parent) 
    {
        public string brand = "Ford";           // Vehicle field
        public void honk()                      // Vehicle method 
        {
            Console.WriteLine("Tuut, tuut!");
        }
    }


    class Car : Vehicle                         // derived class (child)
    {
        public string modelName = "Mustang";    // Car field
    }

}