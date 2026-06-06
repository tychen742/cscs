namespace IntroCSCS
{

    public abstract class Shape
    {
        public abstract double GetArea();
        public abstract void Draw();
    }


    // public class Shape
    // {
    //     public virtual void Draw()
    //     {
    //         Console.WriteLine("Drawing a shape");
    //     }
    // }

    // public class Circle : Shape
    // {
    //     public override void Draw()
    //     {
    //         Console.WriteLine("Drawing a circle");
    //     }
    // }

    class Circle : Shape
    {
        private double radius;                  // field (data)
        public Circle(double radius)            // a constructor intaking argument double radius
        {
            this.radius = radius;               // create the variable to be used in the object
        }

        public override double GetArea()        // implementation of the GetArea method from Shape
        {
            return Math.PI * radius * radius;
        }
        public override void Draw()
        {
            Console.WriteLine("Drawing a circle.");
        }
    }

    class Rectangle : Shape
    {
        public override double GetArea()
        {
            return 1;
        }
        public override void Draw()
        {
            Console.WriteLine("Drawing a rectangle");
        }
    }

    public class Triangle : Shape
    {
        public override global::System.Double GetArea()
        {
            return 1;
        }
        public override void Draw()
        {
            Console.WriteLine("Drawing a triangle");
        }
    }







}