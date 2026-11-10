# 🚗 Walters Garage 2.0 🏁

En C#-konsolapplikation för att hantera ett garage där alla fordon lagras i en `List<Vehicle>`. Programmet låter användaren parkera, söka efter, lista och ta ut fordon samtidigt som garagets kapacitet och lediga platser följs.

## ✨ Funktioner

- 🚙 Parkera olika typer av fordon
  - Bil
  - Motorcykel
  - Flygplan
  - Buss
  - Båt
- 🅿️ Kontroll av garagets kapacitet och lediga platser
- 🔎 Sök efter fordon via registreringsnummer, färg, hjulantal eller typ
- 📊 Visa hur många fordon som finns av varje typ
- ✅ Förhindra dubbla registreringsnummer och överfullt garage
- 🧰 Fyll garaget med exempelfordon direkt från menyn

## 🏗️ Projektstruktur

```text
6-walters-garage-2-list/
├── Airplane.cs
├── Boat.cs
├── Bus.cs
├── Car.cs
├── Garage.cs
├── Garage2.csproj
├── Motorcycle.cs
├── Program.cs
├── README.md
├── Vehicle.cs
├── walters-garage-2-list.sln
├── .gitignore
└── E6 - Garage 2.0 - internally uses a List to store vehicles - C# Console - Lexicon - Walter Schötz.mp4
```

## 🚘 Fordonstyper

Programmet stöder följande fordon och specialegenskaper:

| Fordon | Extra egenskaper |
| --- | --- |
| 🚗 Bil | Bränsletyp och cylindervolym |
| 🏍️ Motorcykel | Motorvolym |
| ✈️ Flygplan | Antal motorer |
| 🚌 Buss | Antal sittplatser |
| 🚤 Båt | Längd i meter |

## ▶️ Kom igång

Se till att du har .NET SDK installerat.

### Kör applikationen

```bash
dotnet run
```

### Bygg projektet

```bash
dotnet build
```

## 🧪 Användning

När programmet startar skapas ett garage med vald kapacitet. Därefter visas en meny med alternativ som:

- Parkera fordon
- Hämta ut fordon
- Visa alla parkerade fordon
- Visa antal fordon per typ
- Sök efter registreringsnummer
- Sök via egenskaper
- Visa kapacitet
- Fyll garaget med exempelfordon

## 🧩 Källkod och ansvar

- `Program.cs` – konsolmeny och användarflöde
- `Garage.cs` – lagring, parkering, borttagning och sökning av fordon
- `Vehicle.cs` – basklass för all typisk fordonsdata
- `Car.cs`, `Motorcycle.cs`, `Airplane.cs`, `Bus.cs`, `Boat.cs` – specifika fordonstyper

## 📌 Tekniker

- C#
- .NET
- `List<Vehicle>` för lagring
- Objektorienterad design

## 🏁 Sammanfattning

Walters Garage 2.0 är ett enkelt men ändå komplett exempel på hur ett garage kan modelleras i C# med en lista, olika fordonsklasser och användarinteraktion via konsol.
