namespace Garage2;

public class Motorcycle : Vehicle
{
    public int EngineDisplacement { get; }

    public Motorcycle(string registrationNumber, string color, int numberOfWheels,
        int engineDisplacement)
        : base(registrationNumber, color, numberOfWheels)
    {
        if (engineDisplacement < 0)
            throw new ArgumentException("Motorvolym kan inte vara negativ.");

        EngineDisplacement = engineDisplacement;
    }

    public override string GetInfo() =>
        $"{base.GetInfo()}, Motorvolym: {EngineDisplacement} cc";
}
