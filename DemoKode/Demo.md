# Demo Code Overview

Denne fil giver et overblik over demokode og eksempler brugt i undervisningen, med fokus på softwaredesignprincipper og praktiske løsninger i C#. Her finder du kodeeksempler, projekter og links til yderligere ressourcer.

---

## InterfaceDemo

Eksempler på hvorledes kode omstruktureres fra en "all-in-one" løsning til funktionelt opdelt kode med lavere kobling og principper fra SOLID.

- Formål: Minimere afhængigheder, øge genbrugelighed og vedligeholdelighed.
- Sti: [DemoKode/InterfaceDemo](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/tree/main/DemoKode/InterfaceDemo)

### 1. All-in-one 
Projekt: `VatCalculatorV1`

> En klassisk implementering, hvor alle funktioner er implementeret i én klasse eller fil. Denne tilgang har høj kobling, og ingen adskillelse af ansvar.

---

### 2. Funktionel opdeling (Single Responsibility Principle)
Projekt: `VatCalculatorV2`

> Koden opdeles efter ansvar – hver klasse har kun ét formål (f.eks. Input, Beregning, Output). Dette gør det lettere at genbruge og teste komponenter hver for sig.

---

### 3. Interface Segregation Principle
Projekt: `VatCalculatorV3`

> Funktionelle grænseflader (interfaces) introduceres. Klasserne implementerer kun de interfaces, de faktisk har brug for – hvilket mindsker afhængigheder og gør koden mere fleksibel.

---

### 4. Dependency Inversion Principle
Projekt: `VatCalculatorV4`

> Højere niveau moduler afhænger nu af abstraktioner (interfaces) i stedet for konkrete implementationer. Dette muliggør nem dependency injection og udskiftning af komponenter, hvilket øger testbarhed og fleksibilitet.

---

## AdapterDemo

- Emne: Adapter designmønster (før/efter-refaktorering).
- Formål: Vise hvordan man indpakker en eksisterende/ekstern komponent bag et eget interface, så resten af systemet bliver uafhængigt af konkrete implementationer.

Indhold:
- Before: [AdapterDemoBefore](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/tree/main/DemoKode/AdapterDemo/AdapterDemoBefore)
- After: [AdapterDemoAfter](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/tree/main/DemoKode/AdapterDemo/AdapterDemoAfter)

---

## Booking (Clean Architecture + CQS/Ports/EF)

Et større undervisningsprojekt der demonstrerer:
- Lagdelt/Clean Architecture
- CQS (Command–Query Separation)
- Ports & Adapters
- Domænemodel, tests, konsol-UI og infrastruktur

Løsning og projekter:
- Løsning: [Booking.sln](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/blob/main/DemoKode/Booking/Booking.sln)
- Domæne: [Booking.Domain](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/tree/main/DemoKode/Booking/Booking.Domain)
- Applikation: [Booking.Application](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/tree/main/DemoKode/Booking/Booking.Application)
- Infrastruktur: [Booking.Infrastructor](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/tree/main/DemoKode/Booking/Booking.Infrastructor)
- Cross-cutting: [Booking.CrossCut](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/tree/main/DemoKode/Booking/Booking.CrossCut)
- Ports (Driving): [Boooking.Port.Driving](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/tree/main/DemoKode/Booking/Boooking.Port.Driving)
- Konsol-UI: [Booking.ConsoleUI](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/tree/main/DemoKode/Booking/Booking.ConsoleUI)
- Tests: [Booking.Domain.Test](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/tree/main/DemoKode/Booking/Booking.Domain.Test)

Dokumentation:
- CQS: [Anvendelse af CQS i Booking projektet (MD)](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/blob/main/DemoKode/Booking/Anvendelse%20af%20CQS%20i%20Booking%20projektet.md) – [PDF](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/blob/main/DemoKode/Booking/Anvendelse%20af%20CQS%20i%20Booking%20projektet.pdf)
- Ports: [Anvendelse af Port i Booking projektet (MD)](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/blob/main/DemoKode/Booking/Anvendelse%20af%20Port%20i%20Booking%20projektet.md) – [PDF](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/blob/main/DemoKode/Booking/Anvendelse%20af%20Port%20i%20Booking%20projektet.pdf)
- Entity Framework: [Anvendelse af Entity Framework i Booking projektet (MD)](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/blob/main/DemoKode/Booking/Anvendelse%20af%20Entity%20Framework%20i%20Booking%20projektet.md) – [PDF](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/blob/main/DemoKode/Booking/Anvendelse%20af%20Entity%20Framework%20i%20Booking%20projektet.pdf)

---

## CPU-boundTaskDemo

- Emne: Parallelisering og Tasks for CPU-bundne opgaver.
- Formål: Vise forskellen på synkrone vs. parallelle/Tasks-baserede løsninger ved CPU-tunge workloads (trådpool, planlægning, skalerbarhed).

Indhold:
- Løsning: [CPU-boundTaskDemo.slnx](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/blob/main/DemoKode/CPU-boundTaskDemo/CPU-boundTaskDemo.slnx)
- Projekt: [CPU-boundTaskDemo](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/tree/main/DemoKode/CPU-boundTaskDemo/CPU-boundTaskDemo)

---

## DecoratorDemo

- Emne: Decorator designmønster.
- Formål: Tilføje adfærd (f.eks. logging, validering, caching) til eksisterende funktionalitet uden at ændre den oprindelige klasse via komposition.

Indhold:
- Løsning: [DecoratorDemo.sln](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/blob/main/DemoKode/DecoratorDemo/DecoratorDemo.sln)
- Projekt: [DecoratorDemo](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/tree/main/DemoKode/DecoratorDemo/DecoratorDemo)

---

## DiningPhilosophers

- Emne: Tråde, locks og klassiske samtidighedsproblemer (deadlock/sult).
- Formål: Demonstrere synkronisering, lock-orden og teknikker til at undgå deadlocks.

Nøgelfiler:
- [Program.cs](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/blob/main/DemoKode/DiningPhilosophers/Program.cs)
- [DiningTable.cs](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/blob/main/DemoKode/DiningPhilosophers/DiningTable.cs)
- [Philosopher.cs](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/blob/main/DemoKode/DiningPhilosophers/Philosopher.cs)
- [Chopstick.cs](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/blob/main/DemoKode/DiningPhilosophers/Chopstick.cs)
- Læs mere: [README.md](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/blob/main/DemoKode/DiningPhilosophers/README.md)

---

## EjendomsBeregner

- Emne: Trinvis refaktorering og IoC/DI.
- Formål: Vise udviklingen fra monolitisk løsning til løs kobling med interfaces og dependency injection.

Indhold:
- Before: [EjendomsberegnerBefore](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/tree/main/DemoKode/EjendomsBeregner/EjendomsberegnerBefore)
- After: [EjendomsberegnerAfter](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/tree/main/DemoKode/EjendomsBeregner/EjendomsberegnerAfter)
- IoC: [EjendomsberegnerIoC](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/tree/main/DemoKode/EjendomsBeregner/EjendomsberegnerIoC)

---

## EntityframeworkConsoleApp

- Emne: Entity Framework Core i en konsolapplikation.
- Formål: Demonstrere konfiguration af DbContext, migrationer og simple CRUD-operationer.

Nøgelfiler og mapper:
- [Program.cs](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/blob/main/DemoKode/EntityframeworkConsoleApp/Program.cs)
- [Database.cs](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/blob/main/DemoKode/EntityframeworkConsoleApp/Database.cs)
- Migrations: [Migrations/](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/tree/main/DemoKode/EntityframeworkConsoleApp/Migrations)
- Løsning/projekt: [EntityframeworkConsoleApp.sln](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/blob/main/DemoKode/EntityframeworkConsoleApp/EntityframeworkConsoleApp.sln), [EntityframeworkConsoleApp.csproj](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/blob/main/DemoKode/EntityframeworkConsoleApp/EntityframeworkConsoleApp.csproj)

---

## IndkapslingDemo

- Emne: Indkapsling i OOP (adgangsmodifikatorer, properties, invariants).
- Formål: Vise hvordan man beskytter objekters tilstand og eksponerer veldefinerede API’er.

Indhold:
- Løsning: [IndkapslingDemo.sln](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/blob/main/DemoKode/IndkapslingDemo/IndkapslingDemo.sln)
- Projekt: [IndkapslingDemo](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/tree/main/DemoKode/IndkapslingDemo/IndkapslingDemo)

---

## KompositionOverArvDemo

- Emne: Komposition frem for arv.
- Formål: Illustrere hvorfor komposition ofte giver lavere kobling og højere fleksibilitet end arv.

Indhold:
- Eksempler på arv: [ArvEksempel/](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/tree/main/DemoKode/KompositionOverArvDemo/ArvEksempel)
- Domænekode m. komposition: [Domaene/](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/tree/main/DemoKode/KompositionOverArvDemo/Domaene)
- Nøgelfiler: [Program.cs](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/blob/main/DemoKode/KompositionOverArvDemo/Program.cs) – [README.md](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/blob/main/DemoKode/KompositionOverArvDemo/README.md)

---

## IoC Demo

- Emne: Introduktion til Inversion of Control (IoC) og Dependency Injection (DI) i konsolapplikationer.
- Formål: Demonstrere hvordan man opbygger en fleksibel applikation der anvender DI Containeren til at håndtere afhængigheder, samt hvordan man bygger løse koblinger mellem komponenter.
- Sti: [DemoKode/IoCdemo](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/tree/main/DemoKode/IoCdemo)

Eksempel indeholder:
- `ICalculator` interface + implementering
- `IVatCalculator` interface + implementering
- Opsætning af DI container (f.eks. med Microsoft.Extensions.DependencyInjection)
- Hovedprogram der anvender DI og viser beregning af moms og simple aritmetiske operationer

---

## Maler (Templates)

Eksempler og demonstrationer fra undervisningen (senest opdateret: 21/08/2025).

- Indeholder kode, som kan bruges som udgangspunkt for egne projekter eller opgaver fra timerne.
- Sti: [DemoKode/Maler](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/tree/main/DemoKode/Maler)

---

## PriceCalculator

Vejledende løsning til opgaven:  
01 - 01 - OOP - 1-sem repetition opgave - Forberedelse  
Se opgavebeskrivelse: [itslearning](https://ucl.itslearning.com/ContentArea/ContentArea.aspx?LocationType=1&LocationID=22186)

En alternativ, forbedret løsning udarbejdet af Dennis  
[Se løsning på GitHub](https://github.com/DennisJohnsenUCL/PriceCalculator)

- Sti: [DemoKode/PriceCalculator](https://github.com/kbr-ucl/2025E-DMVE251-2-sem/tree/main/DemoKode/PriceCalculator)

---

## Ressourcer & Links

- [SOLID Principles Explained (Wikipedia)](https://en.wikipedia.org/wiki/SOLID)
- [Microsoft Docs: Dependency injection in .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
- [C# Interfaces](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/interfaces/)

---

Tip: For at se koden i praksis – følg projektstierne i repoet ovenfor og brug kommentaren i starten af hver fil for forståelse af formål og designvalg.
