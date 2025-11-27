# Entity framework core - implicite fremmednøgler

Her får du en begynder‑venlig tutorial i **Entity Framework Core (EF Core)** med fokus på, hvordan **implicitte fremmednøgler** fungerer (ofte kaldet *shadow foreign keys*). Jeg tager det trin for trin med korte forklaringer og eksempler, så du kan prøve det af med Code‑First og Migrations.

------

## Hvad betyder “implicit fremmednøgle” i EF Core?

Når du modellerer relationer i EF Core, kan du nøjes med **navigationsegenskaber** (fx `Order.Customer`) uden at definere en egentlig fremmednøgle‑property (fx `CustomerId`). EF Core **opretter automatisk** en fremmednøgle som en **shadow property** i modellen og i databasen, baseret på konventioner.

- **Navigationer → implicit FK**
  Hvis EF Core ser en reference eller samling, antager det et forhold og introducerer en intern FK.
- **Shadow property** betyder: du har **ingen C# property** på din modelklasse – men kolonnen **oprettes i databasen**, og værdien spores af EF Core via `ChangeTracker`/`Entry` API’er.

> Fordel: Renere domænemodeller uden id‑støj.
> Ulempe: Du kan ikke læse/skrives FK’en direkte i C# (medmindre du bruger metadata/Entry‑API’er).

------

## Hurtigt overblik: Typer af relationer

- **1:Many** – én `Customer` har mange `Orders`.
- **1:1** – én `Passport` til én `Person`.
- **Many:Many** – fx `Student` ↔ `Course` (EF Core kan implicit oprette en join‑tabel).

Implicitte FK’er opstår typisk i **1:Many** og **1:1** ved brug af navigationer uden FK‑property.

------

## Basissæt‑up (Code First)

**Models uden fremmednøgler (implicit FK):**

```csharp
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;

    // 1:M – navigation til børne-samling
    public List<Order> Orders { get; set; } = new();
}

public class Order
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }

    // Reference-navigation (ingen CustomerId property)
    public Customer Customer { get; set; } = default!;
}
```

**DbContext:**

```csharp
public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Data Source=app.db"); // eller SQL Server, PostgreSQL, osv.
}
```

**Konventionen** ser `Order.Customer` og `Customer.Orders` og skaber automatisk relationen.
 Der oprettes en **skygge‑FK** i databasen (fx `CustomerId` på `Orders`), selvom du ikke har en property i C#.

------

## Kør Migrations og se kolonnerne

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

Tjek den genererede tabel `Orders`: du vil finde en kolonne som typisk hedder `CustomerId`. Den kom fra konventionerne, **uden at du havde en `CustomerId` property i koden**.

------

## Arbejde med data (implicit FK i praksis)

**Opret og gem relaterede entiteter:**

```csharp
using var db = new AppDbContext();

var c = new Customer { Name = "Acme A/S" };
var o = new Order { CreatedAt = DateTime.UtcNow, Customer = c };

db.Add(o); // EF registrerer at Order refererer Customer
db.SaveChanges(); // opretter Customer, derefter Order med FK (shadow) til Customer.Id
```

**Query med navigations-inkludering:**

```csharp
var customers = db.Customers
                  .Include(c => c.Orders)
                  .ToList();
```

------



## 1:1 relation med implicit FK

```csharp
public class Person
{
    public int Id { get; set; }
    public Passport? Passport { get; set; } // valgfri 1:1
}

public class Passport
{
    public int Id { get; set; }
    public Person Person { get; set; } = default!;
}
```

Her oprettes en shadow‑FK `PersonId` på `Passport`‑tabellen.

------

## Many‑to‑Many med implicit join

```csharp
public class Student
{
    public int Id { get; set; }
    public List<Course> Courses { get; set; } = new();
}

public class Course
{
    public int Id { get; set; }
    public List<Student> Students { get; set; } = new();
}
```

EF Core opretter automatisk en **join‑tabel** med to FK’er (ofte `StudentId` og `CourseId`) **uden** dine modelklasser behøver en eksplicit join‑type. Du kan stadig konfigurere navne og delete behavior via Fluent API, hvis du vil.

------

## Delete behavior og referentiel integritet

Standard‑delete behavior kan variere afhængigt af optional/required. Det er god praksis at **sætte det eksplicit**:

- `Cascade` – slet børn, når forælder slettes.
- `Restrict` – forhindrer sletningen, hvis der findes børn.
- `SetNull` – sætter FK til `NULL` ved sletning af forælder (kræver nullable FK).

Eksempel:

```csharp
modelBuilder.Entity<Order>()
    .HasOne(o => o.Customer)
    .WithMany(c => c.Orders)
    .OnDelete(DeleteBehavior.Restrict);
```



------

## Konklusion

Implicitte fremmednøgler i EF Core er praktiske, når du vil holde dine domænemodeller rene og lade EF’s konventioner styre relationerne. De skaber **shadow‑properties** for FK’er og fungerer fint sammen med navigationer. 

------

------



# Eksempel med SQL Server

Her er et **komplet, begynder‑venligt eksempel med SQL Server** der demonstrerer **implicitte fremmednøgler (shadow FKs)** i EF Core. Du kan kopiere det direkte ind i et nyt `.NET`‑projekt og køre det.

> **Mål:** Vi modellerer `Customer` ↔ `Order` (1:M) **uden** en eksplicit `CustomerId` property på `Order`. EF Core opretter automatisk FK‑kolonnen (`CustomerId`) i databasen.

------

## 1) Opret projekt og tilføj pakker

```bash
dotnet new console -n EfCoreSqlServerImplicitFkDemo
cd EfCoreSqlServerImplicitFkDemo

# EF Core SQL Server provider + Tools til migrationer
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

------

## 2) Modeller (uden eksplicit FK)

**Models/Customer.cs**

```csharp
namespace EfCoreSqlServerImplicitFkDemo.Models;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;

    // 1:M – samling af relaterede orders
    public List<Order> Orders { get; set; } = new();
}
```

**Models/Order.cs**

```csharp
namespace EfCoreSqlServerImplicitFkDemo.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }

    // Reference-navigation (ingen CustomerId property)
    public Customer Customer { get; set; } = default!;
}
```

------

## 3) DbContext med SQL Server

**Data/AppDbContext.cs**

```csharp
using EfCoreSqlServerImplicitFkDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreSqlServerImplicitFkDemo.Data;

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Order> Orders => Set<Order>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // Vælg den connection string der passer til din instans:
        // LocalDB (VS):
        options.UseSqlServer("Server=localhost;Database=EfCoreImplicitFkDemoDb;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True");
    }
}
```

> **Bemærk:** Med ovenstående konfiguration opretter EF Core en **FK‑kolonne** (typisk `CustomerId`) i tabellen **Orders**, selvom `Order` ikke har en `CustomerId` property i C#.

------

## 4) Program.cs (demo med shadow FK læsning)

**Program.cs**

```csharp
using EfCoreSqlServerImplicitFkDemo.Data;
using EfCoreSqlServerImplicitFkDemo.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Starter EF Core SQL Server demo (implicit FK)...");

using var db = new AppDbContext();

// Sikr at DB kan oprettes (du kan alternativt køre migrations)
db.Database.Migrate();

// Opret en kunde og en ordre der peger på kunden via navigation
var c = new Customer { Name = "Acme A/S" };
var o = new Order { CreatedAt = DateTime.UtcNow, Customer = c };

db.Add(o);
db.SaveChanges();

Console.WriteLine($"Customer oprettet: Id={c.Id}, Name={c.Name}");
Console.WriteLine($"Order oprettet: Id={o.Id}, CreatedAt={o.CreatedAt}");

// Læs shadow‑FK'en (fx 'CustomerId') via Entry API
var fkValue = db.Entry(o).Property<int>("CustomerId").CurrentValue;
Console.WriteLine($"Shadow FK på Order: CustomerId={fkValue}");

// Demonstrér Include
var customers = db.Customers.Include(x => x.Orders).ToList();
foreach (var cust in customers)
{
    Console.WriteLine($"Kunde {cust.Id} har {cust.Orders.Count} ordre(r).");
}

// Slet kunde og se Cascade
db.Remove(c);
db.SaveChanges();

var ordersLeft = db.Orders.Count();
Console.WriteLine($"Ordrer tilbage efter sletning af kunde: {ordersLeft}");
```

> `db.Database.Migrate()` sørger for at køre migrationer ved runtime, **hvis** de findes. Du kan også vælge at bruge `EnsureCreated()` i rene demoer, men `Migrate()` + migrations er bedre til produktion/udvikling.

------

## 5) Opret og kør migrationer

```bash
# Generér den første migration
dotnet ef migrations add InitialCreate

# Opdater databasen (kør migrationer)
dotnet ef database update

# Kør programmet
dotnet run
```

Eller i visual studio, brug Package Manager Console:
```powershell
Add-Migration InitialCreate
Update-Database
```

Efter `update` kan du åbne databasen og inspicere tabellen **Orders**:

- Du vil se en kolonne **`CustomerId`** (NOT NULL, fordi relationen er required).
- Der er en FK‑constraint som peger på `Customers(Id)`.



## Generereret SQL

```sql
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Customers] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY ([Id])
);

CREATE TABLE [Orders] (
    [Id] int NOT NULL IDENTITY,
    [CreatedAt] datetime2 NOT NULL,
    [CustomerId] int NOT NULL,
    CONSTRAINT [PK_Orders] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Orders_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [Customers] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_Orders_CustomerId] ON [Orders] ([CustomerId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20251127130225_InitialCreate', N'10.0.0');

COMMIT;
GO
```

