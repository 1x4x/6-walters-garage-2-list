namespace Garage2;

public class Car : Vehicle
{
    public string FuelType { get; }
    public int CylinderVolume { get; }

    public Car(string registrationNumber, string color, int numberOfWheels,
        string fuelType, int cylinderVolume)
        : base(registrationNumber, color, numberOfWheels)
    {
        if (string.IsNullOrWhiteSpace(fuelType))
            throw new ArgumentException("Bränsletyp får inte vara tom.");
        if (cylinderVolume < 0)
            throw new ArgumentException("Cylindervolym kan inte vara negativ.");

        FuelType = fuelType.Trim();
        CylinderVolume = cylinderVolume;
    }

    public override string GetInfo() =>
        $"{base.GetInfo()}, Bränsletyp: {FuelType}, Cylindervolym: {CylinderVolume} cc";
}
