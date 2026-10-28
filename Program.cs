namespace Garage2;

internal class Program
{
    private static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("  Välkommen till Walters Garage v2.0  ");
        Console.WriteLine("--------------------------------------");
        Console.WriteLine("In this Garage we use a List to store all vehicles.");
        Console.WriteLine(" ");
        Console.ResetColor();

        Garage garage = CreateGarage();

        bool running = true;
        while (running)
        {
            ShowMenu(garage);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Välj ett alternativ: ");
            Console.ResetColor();
            string? choice = Console.ReadLine();

            switch (choice?.Trim())
            {
                case "1":
                    ParkVehicleMenu(garage);
                    break;
                case "2":
                    RemoveVehicleMenu(garage);
                    break;
                case "3":
                    ListVehicles(garage);
                    break;
                case "4":
                    ShowTypeCounts(garage);
                    break;
                case "5":
                    FindVehicleMenu(garage);
                    break;
                case "6":
                    SearchVehiclesMenu(garage);
                    break;
                case "7":
                    ShowCapacity(garage);
                    break;
                case "8":
                    PopulateGarageMenu(garage);
                    break;
                case "0":
                    running = false;
                    Console.WriteLine("Programmet avslutas. Hej då!");
                    break;
                default:
                    Console.WriteLine("Ogiltigt val. Ange ett nummer från menyn.");
                    break;
            }

            if (running)
            {
                Console.WriteLine();
                Console.Write("Tryck Enter för att fortsätta...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }

    private static Garage CreateGarage()
    {
        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            int capacity = ReadInt("Ange garagets kapacitet (antal fordon): ", 1);
            Console.ResetColor();

            try
            {
                Garage garage = new Garage(capacity);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"  Ett garage med plats för {capacity} fordon har skapats");
                Console.ResetColor();
                Console.ReadLine();
                Console.Clear();
                return garage;
            }
            catch (ArgumentException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Fel: {ex.Message}");
                Console.ResetColor();
            }
        }
    }

    private static void ShowMenu(Garage garage)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
        Console.WriteLine("  Välkommen till Walters Garage v2.0  " + garage.Count + "/" + garage.Capacity + " platser upptagna    ");
        Console.WriteLine("-----------------------------------------------------------------------------------------------------");
        Console.WriteLine("In this Garage we use a List to store all vehicles.");
        Console.ResetColor();
        Console.WriteLine(" ");
        Console.WriteLine("1. Parkera fordon");
        Console.WriteLine("2. Hämta ut fordon");
        Console.WriteLine("3. Visa alla parkerade fordon");
        Console.WriteLine("4. Visa antal fordon per typ");
        Console.WriteLine("5. Sök via registreringsnummer");
        Console.WriteLine("6. Sök via egenskaper");
        Console.WriteLine("7. Visa kapacitet");
        Console.WriteLine("8. Fyll garaget med exempelfordon");
        Console.WriteLine("0. Avsluta");
        Console.WriteLine("-------------------------------------------------------------------------------------------");
    }

    private static void ParkVehicleMenu(Garage garage)
    {
        Console.WriteLine("\nVilken typ av fordon vill du parkera?");
        Console.WriteLine("1. Bil");
        Console.WriteLine("2. Motorcykel");
        Console.WriteLine("3. Flygplan");
        Console.WriteLine("4. Buss");
        Console.WriteLine("5. Båt");

        string type = ReadChoice("Välj fordonstyp: ", "1", "2", "3", "4", "5");
        string reg = ReadText("Registreringsnummer: ");
        string color = ReadText("Färg: ");
        int wheels = ReadInt("Antal hjul: ", 0);

        try
        {
            Vehicle vehicle;

            switch (type)
            {
                case "1":
                    string fuel = ReadText("Bränsletyp (t.ex. bensin eller diesel): ");
                    int cylinder = ReadInt("Cylindervolym (cc): ", 0);
                    vehicle = new Car(reg, color, wheels, fuel, cylinder);
                    break;
                case "2":
                    int engineDisplacement = ReadInt("Motorvolym (cc): ", 0);
                    vehicle = new Motorcycle(reg, color, wheels, engineDisplacement);
                    break;
                case "3":
                    int engines = ReadInt("Antal motorer (minst 1): ", 1);
                    vehicle = new Airplane(reg, color, wheels, engines);
                    break;
                case "4":
                    int seats = ReadInt("Antal sittplatser (minst 1): ", 1);
                    vehicle = new Bus(reg, color, wheels, seats);
                    break;
                default:
                    double length = ReadDouble("Båtens längd i meter: ", 0.01);
                    vehicle = new Boat(reg, color, wheels, length);
                    break;
            }

            garage.ParkVehicle(vehicle, out string message);
            Console.WriteLine(message);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Kunde inte skapa fordonet: {ex.Message}");
        }
    }

    private static void RemoveVehicleMenu(Garage garage)
    {
        string reg = ReadText("Ange registreringsnumret på fordonet som ska hämtas ut: ");
        garage.RemoveVehicle(reg, out string message);
        Console.WriteLine(message);
    }

    private static void ListVehicles(Garage garage)
    {
        List<Vehicle> vehicles = garage.GetAllVehicles();

        if (vehicles.Count == 0)
        {
            Console.WriteLine("Garaget är tomt.");
            return;
        }

        Console.WriteLine("\nParkerade fordon:");
        foreach (Vehicle vehicle in vehicles)
            Console.WriteLine(vehicle.GetInfo());
    }

    private static void ShowTypeCounts(Garage garage)
    {
        Dictionary<string, int> counts = garage.GetVehicleTypeCounts();

        if (counts.Count == 0)
        {
            Console.WriteLine("Det finns inga fordon i garaget.");
            return;
        }

        Console.WriteLine("\nAntal fordon per typ:");
        foreach (KeyValuePair<string, int> item in counts)
            Console.WriteLine($"{item.Key}: {item.Value}");
    }

    private static void FindVehicleMenu(Garage garage)
    {
        string reg = ReadText("Ange registreringsnummer: ");
        Vehicle? vehicle = garage.FindVehicle(reg);

        if (vehicle is null)
            Console.WriteLine("Inget fordon hittades med det registreringsnumret.");
        else
            Console.WriteLine(vehicle.GetInfo());
    }

    private static void SearchVehiclesMenu(Garage garage)
    {
        Console.WriteLine("Lämna ett fält tomt om du inte vill filtrera på det.");
        Console.Write("Färg: ");
        string? color = Console.ReadLine();

        int? wheels = null;
        Console.Write("Antal hjul (eller Enter för att hoppa över): ");
        string? wheelsInput = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(wheelsInput))
        {
            if (int.TryParse(wheelsInput, out int parsedWheels) && parsedWheels >= 0)
                wheels = parsedWheels;
            else
            {
                Console.WriteLine("Ogiltigt antal hjul. Sökningen avbröts.");
                return;
            }
        }

        Console.Write("Fordonstyp (Car, Motorcycle, Airplane, Bus, Boat eller Enter för alla): ");
        string? type = Console.ReadLine();

        List<Vehicle> results = garage.SearchVehicles(color, wheels, type);

        if (results.Count == 0)
        {
            Console.WriteLine("Inga fordon matchade sökningen.");
            return;
        }

        Console.WriteLine($"\nHittade {results.Count} fordon:");
        foreach (Vehicle vehicle in results)
            Console.WriteLine(vehicle.GetInfo());
    }

    private static void ShowCapacity(Garage garage)
    {
        Console.WriteLine($"Total kapacitet: {garage.Capacity}");
        Console.WriteLine($"Parkerade fordon: {garage.Count}");
        Console.WriteLine($"Lediga platser: {garage.AvailableSpaces}");
    }

    private static void PopulateGarageMenu(Garage garage)
    {
        Vehicle[] examples =
        {
            new Car("ABC123", "Svart", 4, "Bensin", 1600),
            new Motorcycle("MOT456", "Rosa", 3, 500),
            new Airplane("AIR789", "Vit", 6, 2),
            new Bus("BUS321", "Röd", 6, 50),
            new Boat("BOA654", "Blå", 0, 7.5)
        };

        int added = 0;
        foreach (Vehicle vehicle in examples)
        {
            if (garage.ParkVehicle(vehicle, out string message))
            {
                added++;
                Console.WriteLine(message);
            }
        }

        Console.WriteLine($"Exempel klart. {added} fordon lades till.");
    }

    private static string ReadText(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                return input.Trim();

            Console.WriteLine("Fältet får inte vara tomt. Försök igen.");
        }
    }

    private static int ReadInt(string prompt, int minimum)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int value) && value >= minimum)
                return value;

            Console.WriteLine($"Ange ett heltal som är minst {minimum}.");
        }
    }

    private static double ReadDouble(string prompt, double minimum)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (double.TryParse(input, System.Globalization.NumberStyles.Float,
                System.Globalization.CultureInfo.CurrentCulture, out double value) &&
                value >= minimum)
                return value;

            // Tillåt även decimalpunkt om datorns kultur använder decimalcomma.
            if (double.TryParse(input?.Replace(',', '.'),
                System.Globalization.NumberStyles.Float,
                System.Globalization.CultureInfo.InvariantCulture, out value) &&
                value >= minimum)
                return value;

            Console.WriteLine($"Ange ett tal som är minst {minimum}.");
        }
    }

    private static string ReadChoice(string prompt, params string[] validChoices)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine()?.Trim();

            foreach (string choice in validChoices)
            {
                if (input == choice)
                    return choice;
            }

            Console.WriteLine("Ogiltigt val. Försök igen.");
        }
    }
}
