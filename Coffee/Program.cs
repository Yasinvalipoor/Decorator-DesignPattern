using DecoratorPattern;
using System;

namespace DecoratorPattern
{
    // Component
    public abstract class Coffee
    {
        public abstract string GetDescription();
        public abstract double GetCost();
    }

    // ConcreteComponent
    public class SimpleCoffee : Coffee
    {
        public override string GetDescription()
        {
            return "Simple Coffee";
        }

        public override double GetCost()
        {
            return 5.0;
        }
    }

    // Decorator
    public abstract class CoffeeDecorator : Coffee
    {
        protected Coffee _coffee;

        public CoffeeDecorator(Coffee coffee)
        {
            _coffee = coffee;
        }

        public override string GetDescription()
        {
            return _coffee.GetDescription();
        }

        public override double GetCost()
        {
            return _coffee.GetCost();
        }
    }

    // ConcreteDecorator
    public class Milk : CoffeeDecorator
    {
        public Milk(Coffee coffee) : base(coffee)
        {
        }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + ", Milk";
        }

        public override double GetCost()
        {
            return _coffee.GetCost() + 1.5;
        }
    }

    // ConcreteDecorator
    public class Sugar : CoffeeDecorator
    {
        public Sugar(Coffee coffee) : base(coffee)
        {
        }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + ", Sugar";
        }

        public override double GetCost()
        {
            return _coffee.GetCost() + 0.5;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Order a simple coffee
            Coffee myCoffee = new SimpleCoffee();
            Console.WriteLine($"{myCoffee.GetDescription()} - ${myCoffee.GetCost()}");

            // Add milk
            myCoffee = new Milk(myCoffee);
            Console.WriteLine($"{myCoffee.GetDescription()} - ${myCoffee.GetCost()}");

            // Add sugar
            myCoffee = new Sugar(myCoffee);
            Console.WriteLine($"{myCoffee.GetDescription()} - ${myCoffee.GetCost()}");

            // Add another sugar
            myCoffee = new Sugar(myCoffee);
            Console.WriteLine($"{myCoffee.GetDescription()} - ${myCoffee.GetCost()}");
        }
    }
}


/*
 * 
+----------------------------+     +----------------------------+
|  <<abstract>>              |     |  SimpleCoffee              |
|     Coffee                 |<----|----------------------------|
|----------------------------|     | +GetDescription() : string |
| +GetDescription() : string |     | +GetCost() : double        |
| +GetCost() : double        |     +----------------------------+
+----------------------------+
       ^
       |
       |
       +----------------------------------------+
       |                                        |
+----------------------------+     +----------------------------+
|  <<abstract>>              |     |      Milk                  |
| CoffeeDecorator            |<----|----------------------------|
|----------------------------|     | +GetDescription() : string |
| -coffee : Coffee           |     | +GetCost() : double        |
| +GetDescription() : string |     +----------------------------+
| +GetCost() : double        |
+----------------------------+     +---------------------------+
                         |         |      Sugar                |
                         ----------|---------------------------|
                                   | +GetDescription() : string|
                                   | +GetCost() : double       |
                                   +---------------------------+
 */