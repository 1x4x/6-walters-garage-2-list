namespace Garage2;

public abstract class Vehicle
{
    public string RegistrationNumber { get; }
    public string Color { get; }
    public int NumberOfWheels { get; }

    protected Vehicle(string registrationNumber, string color, int numberOfWheels)
    {
        if (string.IsNullOrWhiteSpace(registrationNumber))
            throw new ArgumentException("Registreringsnumret får inte vara tomt.");

        if (string.IsNullOrWhiteSpace(color))
            throw new ArgumentException("Färgen får inte vara tom.");

        if (numberOfWheels < 0)
            throw new ArgumentException("Antal hjul kan inte vara negativt.");

        RegistrationNumber = registrationNumber.Trim().ToUpperInvariant();
        Color = color.Trim();
        NumberOfWheels = numberOfWheels;
    }

    public virtual string GetInfo()
    {
        return $"Typ: {GetType().Name}, Registreringsnummer: {RegistrationNumber}, " +
               $"Färg: {Color}, Antal hjul: {NumberOfWheels}";
    }
}
