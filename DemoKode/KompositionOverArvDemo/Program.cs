using System;
using KompositionOverArvDemo.Domaene;

namespace KompositionOverArvDemo;

internal class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== Komposition over arv – demo ===
");

        var bil = new Bil(new BenzinMotor(), new SkiveBremse());
        bil.Kør();
        bil.FyldEnergi();
        bil.Nødstop();

        Console.WriteLine("
— Skifter motor til el —");
        bil.SkiftMotor(new ElMotor());
        bil.Kør();
        bil.FyldEnergi();

        Console.WriteLine("
— Skifter bremser til tromler —");
        bil.SkiftBremse(new TromleBremse());
        bil.Nødstop();

        Console.WriteLine("
(Se også mappen 'ArvEksempel' for en arv-baseret variant.)");
        Console.WriteLine("
Tryk en tast for at afslutte...");
        Console.ReadKey();
    }
}
