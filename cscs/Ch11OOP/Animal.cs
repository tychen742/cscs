namespace IntroCSCS
{

    // abstract class Animal                       // Abstract class
    // {
    //     public abstract void animalSound();     // Abstract method (does not have a body)

    //     public void sleep()                     // Regular method
    //     {
    //         Console.WriteLine("Zzz");
    //     }
    // }

    class Animal  // Base class (parent) 
    {
        // public void animalSound()
        public virtual void animalSound()
        {
            Console.WriteLine("The animal makes a sound");
        }
    }

    // class Pig : Animal  // Derived class (child) 
    // {
    //     // public void animalSound()
    //     public override void animalSound()
    //     {
    //         Console.WriteLine("The pig says: wee wee");
    //     }
    // }

    class Dog : Animal  // Derived class (child) 
    {
        // public void animalSound()
        public override void animalSound()
        {
            Console.WriteLine("1 The dog says: bow wow");
        }
    }
    class Cat : Animal  // Derived class (child) 
    {
        // public void animalSound()
        // public override void animalSound()
        // {
        //     base.animalSound();
        // }

        public void animalSound()
        {
            // animalSound();
            base.animalSound();
        }
    }
}