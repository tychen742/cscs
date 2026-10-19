namespace IntroCSCS;

class Program
{
    static void Main()
    {
        var account = new BankAccount(1000m);
        account.Deposit(500m);
        account.Withdraw(200m);
        Console.WriteLine($"Balance: {account.GetBalance()}");

        Car car = new Car();
        car.honk();
        Console.WriteLine($"{car.brand} {car.modelName}");

        Animal[] animals = { new Animal(), new Dog(), new Cat() };
        foreach (Animal animal in animals) animal.animalSound();
        // Cat explicitly hides the base method; the reference type selects it.
        new Cat().animalSound();

        var methods = new MethodOverLoading();
        Console.WriteLine($"Two integers: {methods.Add(3, 2)}");
        Console.WriteLine($"Three integers: {methods.Add(3, 2, 8)}");
        Console.WriteLine($"Two floats: {methods.Add(3f, 22f)}");
        Console.WriteLine(methods.Add("hello", "world"));

        Shape[] shapes = { new Circle(10), new Rectangle(3, 4), new Triangle(3, 4) };
        foreach (Shape shape in shapes)
        {
            shape.Draw();
            Console.WriteLine($"Area: {shape.GetArea():F2}");
        }

        Student student = new Student { Name = "Alex Chen", Age = 20 };
        Console.WriteLine($"Student: {student.Name}, age {student.Age}");
        IA example = new C();
        example.M();
    }
}
