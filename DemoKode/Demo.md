# Demo Code Overview

Denne fil giver et overblik over demokode og eksempler brugt i undervisningen, med fokus på softwaredesignprincipper og praktiske løsninger i C#. Her finder du kodeeksempler, projekter og links til vejledende løsninger.

---

## InterfaceDemo

Eksempler på hvorledes kode omstruktureres fra en "all-in-one" løsning til funktionelt opdelt kode med lavere kobling og principper fra SOLID.

- **Formål:** Minimere afhængigheder, øge genbrugelighed og vedligeholdelighed.

### 1. All-in-one 
**Projekt:** `VatCalculatorV1`

> En klassisk implementering, hvor alle funktioner er implementeret i én klasse eller fil. Denne tilgang har høj kobling, og ingen adskillelse af ansvar.

---

### 2. Funktionel opdeling (Single Responsibility Principle)
**Projekt:** `VatCalculatorV2`

> Koden opdeles efter ansvar – hver klasse har kun ét formål (f.eks. Input, Beregning, Output). Dette gør det lettere at genbruge og teste komponenter hver for sig.

---

### 3. Interface Segregation Principle
**Projekt:** `VatCalculatorV3`

> Funktionelle grænseflader (interfaces) introduceres. Klasserne implementerer kun de interfaces, de faktisk har brug for – hvilket mindsker afhængigheder og gør koden mere fleksibel.

---

### 4. Dependency Inversion Principle
**Projekt:** `VatCalculatorV4`

> Højere niveau moduler afhænger nu af abstraktioner (interfaces) i stedet for konkrete implementationer. Dette muliggør nem dependency injection og udskiftning af komponenter, hvilket øger testbarhed og fleksibilitet.

---

## IoC Demo

**Emne:** Introduktion til Inversion of Control (IoC) og Dependency Injection (DI) i konsolapplikationer.

- **Formål:** Demonstrere hvordan man opbygger en fleksibel applikation der anvender DI Containeren til at håndtere afhængigheder, samt hvordan man bygger løse koblinger mellem komponenter.

**Eksempel indeholder:**
- `ICalculator` interface + implementering
- `IVatCalculator` interface + implementering
- Opsætning af DI container (f.eks. med Microsoft.Extensions.DependencyInjection)
- Hovedprogram der anvender DI og viser beregning af moms og simple aritmetiske operationer

---

## Maler (Templates)

Eksempler og demononstrationer fra undervisningen (senest opdateret: 21/08/2025).

- Indeholder kode, som kan bruges som udgangspunkt for egne projekter eller opgaver fra timerne.

---

## PriceCalculator

Vejledende løsning til opgaven:  
**01 - 01 - OOP - 1-sem repetition opgave - Forberedelse**  
Se opgavebeskrivelse: [itslearning](https://ucl.itslearning.com/ContentArea/ContentArea.aspx?LocationType=1&LocationID=22186)

En alternativ, forbedret løsning udarbejdet af Dennis  
[Se løsning på GitHub](https://github.com/DennisJohnsenUCL/PriceCalculator)

---

## Ressourcer & Links

- [SOLID Principles Explained (Wikipedia)](https://en.wikipedia.org/wiki/SOLID)
- [Microsoft Docs: Dependency injection in .NET](https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection)
- [C# Interfaces](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/interfaces/)

---

> **Tip:** For at se koden i praksis – følg projektstierne i repoet ovenfor og brug kommentaren i starten af hver fil for forståelse af formål og designvalg.
