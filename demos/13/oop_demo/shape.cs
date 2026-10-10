namespace IntroCSCS;

public abstract class Shape
{
    public abstract double GetArea();
    public abstract void Draw();
}

class Circle : Shape
{
    private readonly double radius;
    public Circle(double radius)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(radius);
        this.radius = radius;
    }
    public override double GetArea() => Math.PI * radius * radius;
    public override void Draw() => Console.WriteLine("Drawing a circle.");
}

class Rectangle : Shape
{
    private readonly double width;
    private readonly double height;
    public Rectangle(double width = 1, double height = 1)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(width);
        ArgumentOutOfRangeException.ThrowIfNegative(height);
        this.width = width;
        this.height = height;
    }
    public override double GetArea() => width * height;
    public override void Draw() => Console.WriteLine("Drawing a rectangle.");
}

public class Triangle : Shape
{
    private readonly double baseLength;
    private readonly double height;
    public Triangle(double baseLength = 1, double height = 1)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(baseLength);
        ArgumentOutOfRangeException.ThrowIfNegative(height);
        this.baseLength = baseLength;
        this.height = height;
    }
    public override double GetArea() => baseLength * height / 2;
    public override void Draw() => Console.WriteLine("Drawing a triangle.");
}
