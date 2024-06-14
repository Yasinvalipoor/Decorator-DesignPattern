

CarAbstract benz = new Benz();
Console.WriteLine($"{benz.Name()} - ${benz.Cost()}");

benz = new DarkCover(benz);
benz = new BackFireRemapEngine(benz);

Console.WriteLine($"{benz.Name()} - ${benz.Cost()}");




public abstract class CarAbstract
{
    public abstract string Name();
    public abstract int Cost();
}


public class Benz : CarAbstract
{
    public override int Cost()
    {
        return 1000;
    }

    public override string Name()
    {
        return "Benz SLS";
    }
}

public class BMW : CarAbstract
{
    public override int Cost()
    {
        return 500;
    }

    public override string Name()
    {
        return "BMW i4";
    }
}

public abstract class OptionalFeatureAbstract : CarAbstract
{
    protected readonly CarAbstract _car;

    public OptionalFeatureAbstract(CarAbstract car)
    {
        this._car = car;
    }

    public override int Cost()
    {
        return _car.Cost();
    }

    public override string Name()
    {
        return _car.Name();
    }
}





public class DarkCover : OptionalFeatureAbstract
{
    public DarkCover(CarAbstract car) : base(car) { }

    public override int Cost()
    {
        return _car.Cost() + 1000;
    }

    public override string Name()
    {
        return _car.Name() + " + Dark Cover";
    }
}


public class BackFireRemapEngine : OptionalFeatureAbstract
{
    public BackFireRemapEngine(CarAbstract car) : base(car) { }

    public override int Cost()
    {
        return _car.Cost() + 5000;
    }

    public override string Name()
    {
        return _car.Name() + " + Remap BackFire";
    }
}










