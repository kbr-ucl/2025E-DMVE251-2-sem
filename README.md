# DMVE251 - 2. Semester

Dette repository indeholder undervisningsmaterialer, demo kode og scripts til kurset DMVE251 2. semester på UCL (University College).

## 📚 Indhold

- [Demo Kode](#-demo-kode)
- [Scripts](#-scripts)
- [Forudsætninger](#-forudsætninger)
- [Kom i gang](#-kom-i-gang)
- [Licens](#-licens)

## 🎯 Demo Kode

Repository'et indeholder forskellige .NET C# demo projekter der illustrerer vigtige softwareudviklingsprincipper og design patterns.

### Interface og SOLID Principper

#### InterfaceDemo
Demonstrerer hvordan kode kan omstruktureres fra "All-in-one" til funktionelt opdelt kode med reduceret kobling gennem interfaces.

Projektforløbet viser:
1. **VatCalculatorV1** - All-in-one implementation
2. **VatCalculatorV2** - Funktionel opdeling (Single Responsibility Principle)
3. **VatCalculatorV3** - Interface Segregation Principle
4. **VatCalculatorV4** - Dependency Inversion Principle

📖 [Læs mere](DemoKode/Demo.md#interfacedemo)

#### IoCdemo
Introducerer dependency injection til at udføre basis aritmetiske operationer og momsberegninger. Demonstrerer opsætning af DI container med interfaces og implementationer for `ICalculator` og `IVatCalculator`.

📖 [Læs mere](DemoKode/Demo.md#iocdemo)

#### IndkapslingDemo
Viser principperne for indkapsling i objektorienteret programmering.

#### KompositionOverArvDemo
Demonstrerer hvorfor komposition ofte er at foretrække frem for arv i objektorienteret design.

### Design Patterns

#### AdapterDemo
Illustrerer Adapter pattern der tillader inkompatible interfaces at arbejde sammen.

#### DecoratorDemo
Viser Decorator pattern til dynamisk at tilføje funktionalitet til objekter.

### Concurrency og Performance

#### CPU-boundTaskDemo
Demonstrerer håndtering af CPU-intensive opgaver i .NET.

#### DiningPhilosophers
Klassisk concurrency problem der viser udfordringer med deadlocks og resource sharing.

### Praktiske Applikationer

#### Booking
Booking system demonstration.

#### EjendomsBeregner
Ejendomsberegnings applikation.

#### EntityframeworkConsoleApp
Console applikation der demonstrerer brug af Entity Framework til database operationer.

#### PriceCalculator
Vejledende løsning til opgaven: [01 - 01 - OOP - 1-sem repetition opgave - Forberedelse](https://ucl.itslearning.com/ContentArea/ContentArea.aspx?LocationType=1&LocationID=22186)

En forbedret løsning er udarbejdet af Dennis: [Link](https://github.com/DennisJohnsenUCL/PriceCalculator)

#### Maler
Demo kode fra undervisningen d. 21/8-2025.

📖 [Se alle demo projekter](DemoKode/Demo.md)

## 🛠 Scripts

Repository'et indeholder hjælpescripts til projektopsætning:

### KbrOnionTemplate Scripts
- **KbrOnionTemplate-Core-9.bat** - Opretter en onion arkitektur projekt struktur med .NET Core 9
- **KbrOnionTemplate-Core-latest.bat** - Opretter en onion arkitektur projekt struktur med seneste .NET Core version

📖 [Læs mere om scripts](Scripts/Scripts.md)

## 📋 Forudsætninger

For at arbejde med projekterne i dette repository skal du have følgende installeret:

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 eller nyere)
- En IDE såsom:
  - [Visual Studio 2022](https://visualstudio.microsoft.com/) (anbefalet)
  - [Visual Studio Code](https://code.visualstudio.com/) med C# extension
  - [JetBrains Rider](https://www.jetbrains.com/rider/)
- [Git](https://git-scm.com/downloads) til version control

## 🚀 Kom i gang

1. **Clone repository'et:**
   ```bash
   git clone https://github.com/kbr-ucl/2025E-DMVE251-2-sem.git
   cd 2025E-DMVE251-2-sem
   ```

2. **Åbn et demo projekt:**
   
   Naviger til den ønskede demo folder og åbn `.sln` filen:
   ```bash
   cd DemoKode/InterfaceDemo
   # Åbn InterfaceDemo.sln i Visual Studio
   ```

3. **Build og kør:**
   
   I Visual Studio:
   - Tryk `F5` for at bygge og køre projektet
   - Eller brug Build menu → Build Solution
   
   Via kommandolinjen:
   ```bash
   dotnet build
   dotnet run
   ```

## 📄 Licens

Dette projekt er licenseret under MIT License - se [LICENSE](LICENSE) filen for detaljer.

Copyright (c) 2025 Kaj Bromose

## 👨‍🏫 Kontakt

Dette repository vedligeholdes som en del af DMVE251 kurset på UCL.

For spørgsmål relateret til kurset, kontakt din underviser.