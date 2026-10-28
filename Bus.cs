namespace Garage2;

public class Bus : Vehicle
{
    public int NumberOfSeats { get; }

    public Bus(string registrationNumber, string color, int numberOfWheels,
        int numberOfSeats)
        : base(registrationNumber, color, numberOfWheels)
    {
        if (numberOfSeats < 1)
            throw new ArgumentException("En buss måste ha minst en sittplats.");

        NumberOfSeats = numberOfSeats;
    }

    public override string GetInfo() =>
        $"{base.GetInfo()}, Antal sittplatser: {NumberOfSeats}";
}
