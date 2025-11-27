
using EfCoreSqlServerImplicitFkMini.Data;
using EfCoreSqlServerImplicitFkMini.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

Console.WriteLine("Starter EF Core SQL Server demo (implicit FK)...");

using var db = new AppDbContext();

// Kør migrations ved runtime (bedre end EnsureCreated i udvikling/produktion)
try
{
    // Add-Migration InitialCreate
    // Update-Database
    db.Database.Migrate();
}
catch (Exception ex)
{
    Console.WriteLine($"Migrate fejlede: {ex.Message}");
    Console.WriteLine("Tjek connection string og at SQL Server kører.");
    throw;
}

// Opret en kunde og en ordre der peger på kunden via navigation
var c = new Customer { Name = "Acme A/S" };
var o = new Order { CreatedAt = DateTime.UtcNow, Customer = c };

db.Add(o);
db.SaveChanges();

Console.WriteLine($"Customer oprettet: Id={c.Id}, Name={c.Name}");
Console.WriteLine($"Order oprettet: Id={o.Id}, CreatedAt={o.CreatedAt}");

// Læs shadow‑FK'en (normalt 'CustomerId') via Entry API
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
