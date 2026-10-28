namespace Garage2;

public class Airplane : Vehicle
{
    public int NumberOfEngines { get; }

    public Airplane(string registrationNumber, string color, int numberOfWheels,
        int numberOfEngines)
        : base(registrationNumber, color, numberOfWheels)
    {
        if (numberOfEngines < 1)
            throw new ArgumentException("Ett flygplan måste ha minst en motor.");

        NumberOfEngines = numberOfEngines;
    }

    public override string GetInfo() =>
        $"{base.GetInfo()}, Antal motorer: {NumberOfEngines}";
}
