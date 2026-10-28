namespace Garage2;

public class Boat : Vehicle
{
    public double Length { get; }

    public Boat(string registrationNumber, string color, int numberOfWheels,
        double length)
        : base(registrationNumber, color, numberOfWheels)
    {
        if (length <= 0)
            throw new ArgumentException("Båtens längd måste vara större än noll.");

        Length = length;
    }

    public override string GetInfo() =>
        $"{base.GetInfo()}, Längd: {Length} meter";
}
