namespace IntroCSCS
{
    class Program
    {
        static void Main(string[] args)
        {
            // ////////// BankAccount 1 //////////
            // Can access balance through the Balance property
            // BankAccount account = new BankAccount();
            // account.Balance = 100;
            // Console.WriteLine(account.Balance);

            // ////////// BankAccount 2 //////////
            // BankAccount myAccount = new BankAccount(1000);
            // myAccount.Deposit(500);
            // Console.WriteLine("Balance: " + myAccount.GetBalance());
            // myAccount.Withdraw(2000);
            // Console.WriteLine("Balance: " + myAccount.GetBalance());


            // // ////////// Vehicle //////////
            Car myCar = new Car();              // Create a myCar object
            myCar.honk();                       // Call the honk() method (From the Vehicle class) on the myCar object
            Console.WriteLine(myCar.brand + " " + myCar.modelName);
            // Display the value of the brand field (from the Vehicle class) 
            // and the value of the modelName from the Car class


            // ////////// Animal ///////////
            // Animal myAnimal = new Animal();  // Create a Animal object
            // // Animal myPig = new Pig();  // Create a Pig object
            // Animal myDog = new Dog();  // Create a Dog object
            // Animal myCat = new Cat();
            // myAnimal.animalSound();
            // // myPig.animalSound();
            // myDog.animalSound();
            // myCat.animalSound();


            ////////// Method Overloading //////////
            // MethodOverloading mol = new MethodOverloading();  
            // Console.WriteLine("Add two int parameter: " + mol.Add(3, 2));  
            // Console.WriteLine("Add three int parameter: " + mol.Add(3, 2, 8));  
            // Console.WriteLine("Add two float parameter: " + mol.Add(3f, 22f));  
            // Console.WriteLine("Add two string parameter: " + mol.Add("hello", "world"));  


            // ////////// Shape //////////
            //  // Shape shape = new Shape();   /// ERROR instantiating abstract class!!! 
            // Circle circle = new Circle(10);
            // double area = circle.GetArea();
            // Console.WriteLine(area);

            // // Shape shape1 = new Shape();
            // Shape shape2 = new Circle(10);
            // Shape shape3 = new Rectangle();
            // Shape shape4 = new Triangle();

            // shape1.Draw(); // Outputs "Drawing a shape"
            // shape2.Draw(); // Outputs "Drawing a circle"
            // shape3.Draw(); // Outputs "Drawing a rectangle"
            // shape4.Draw(); // Outputs "Drawing a triangle"


            ////////// Student //////////
            // Student obj = new Student();
            // obj.Name = "TY Chen";
            // obj.Age = 35;
            // Console.WriteLine(" Name : " + obj.Name);   // output: Name : TY Chen
            // Console.WriteLine(" Age : " + obj.Age);     // output: Age : 35


            ////////// Interface //////////
            // IA i = new C();
            // i.M(); // prints "IA.M"

            
        }
    }
}