namespace Garage2;

public class Garage
{
    private readonly List<Vehicle> vehicles = new();
    private readonly int capacity;

    public int Capacity => capacity;
    public int Count => vehicles.Count;
    public int AvailableSpaces => capacity - vehicles.Count;

    public Garage(int capacity)
    {
        if (capacity <= 0)
            throw new ArgumentException("Garagets kapacitet måste vara större än noll.");

        this.capacity = capacity;
    }

    public bool ParkVehicle(Vehicle vehicle, out string message)
    {
        if (vehicle is null)
        {
            message = "Inget fordon angavs.";
            return false;
        }

        if (vehicles.Count >= capacity)
        {
            message = "Garaget är fullt.";
            return false;
        }

        if (FindVehicle(vehicle.RegistrationNumber) is not null)
        {
            message = $"Registreringsnumret {vehicle.RegistrationNumber} finns redan i garaget.";
            return false;
        }

        vehicles.Add(vehicle);
        message = $"Fordonet {vehicle.RegistrationNumber} parkerades.";
        return true;
    }

    public Vehicle? RemoveVehicle(string registrationNumber, out string message)
    {
        Vehicle? vehicle = FindVehicle(registrationNumber);

        if (vehicle is null)
        {
            message = $"Hittade inget fordon med registreringsnummer {registrationNumber}.";
            return null;
        }

        vehicles.Remove(vehicle);
        message = $"Fordonet {vehicle.RegistrationNumber} hämtades ut.";
        return vehicle;
    }

    public Vehicle? FindVehicle(string registrationNumber)
    {
        if (string.IsNullOrWhiteSpace(registrationNumber))
            return null;

        foreach (Vehicle vehicle in vehicles)
        {
            if (string.Equals(vehicle.RegistrationNumber.Trim(),
                registrationNumber.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                return vehicle;
            }
        }

        return null;
    }

    public List<Vehicle> GetAllVehicles()
    {
        // Returnerar en kopia så att anroparen inte kan ändra garagets interna lista.
        return new List<Vehicle>(vehicles);
    }

    public List<Vehicle> SearchVehicles(string? color, int? numberOfWheels, string? vehicleType)
    {
        List<Vehicle> results = new();

        foreach (Vehicle vehicle in vehicles)
        {
            bool matches = true;

            if (!string.IsNullOrWhiteSpace(color) &&
                !string.Equals(vehicle.Color, color.Trim(), StringComparison.OrdinalIgnoreCase))
                matches = false;

            if (numberOfWheels.HasValue && vehicle.NumberOfWheels != numberOfWheels.Value)
                matches = false;

            if (!string.IsNullOrWhiteSpace(vehicleType) &&
                !vehicle.GetType().Name.Equals(vehicleType.Trim(), StringComparison.OrdinalIgnoreCase))
                matches = false;

            if (matches)
                results.Add(vehicle);
        }

        return results;
    }

    public Dictionary<string, int> GetVehicleTypeCounts()
    {
        Dictionary<string, int> counts = new();

        foreach (Vehicle vehicle in vehicles)
        {
            string type = vehicle.GetType().Name;

            if (counts.ContainsKey(type))
                counts[type]++;
            else
                counts.Add(type, 1);
        }

        return counts;
    }
}
