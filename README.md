# Walters Garage 2

En konsolapplikation i C# för att hantera ett garage med en `List<Vehicle>`. Programmet
låter användaren parkera, söka efter och hämta ut fordon samt följa garagets kapacitet.

## Funktioner

- Skapa ett garage med valfri kapacitet.
- Parkera bilar, motorcyklar, flygplan, bussar och båtar.
- Förhindra dubbla registreringsnummer och parkering när garaget är fullt.
- Visa alla parkerade fordon och antal fordon per typ.
- Söka efter registreringsnummer, färg, antal hjul eller fordonstyp.
- Fylla garaget med exempelfordon.
- Visa total kapacitet, antal parkerade fordon och lediga platser.

## Krav

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Kom igång

Kör följande kommandon från projektets rot:

```bash
dotnet run
```

För att bygga projektet utan att starta programmet:

```bash
dotnet build
```

Vid start anger du garagets kapacitet och använder sedan menyn i konsolen. Avsluta
programmet genom att välja `0`.

## Fordonstyper

Programmet stöder följande fordon och egenskaper:

| Fordon | Extra egenskaper |
| --- | --- |
| Bil | Bränsletyp och cylindervolym |
| Motorcykel | Motorvolym |
| Flygplan | Antal motorer |
| Buss | Antal sittplatser |
| Båt | Längd i meter |

## Projektstruktur

- `Program.cs` – konsolmeny och användarflöde.
- `Garage.cs` – lagring, parkering, borttagning och sökning av fordon.
- `Vehicle.cs` – gemensam basklass för fordon.
- `Car.cs`, `Motorcycle.cs`, `Airplane.cs`, `Bus.cs` och `Boat.cs` – specifika fordonstyper.
