// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

IRabatBeregner beregner;
var ordre = new Order { Kunde = new Kunde { KundeType = KundeType.Privat }, OrdreSum = 1000};
beregner = Factory(ordre.Kunde.KundeType);

IRabatBeregner Factory(KundeType kundeType)
{
    if (kundeType == KundeType.Privat) return new PrivatKundeRabat();
}

beregner.BeregnRabat(ordre);

public interface IRabatBeregner
{
    double BeregnRabat(Order ordre);
}

public class PrivatKundeRabat : IRabatBeregner
{
    /// <summary>
    /// Hvis ordresummen er over 1.000,- gives en rabat på 10% af ordresummen.
    /// Hvis ordresummen er over 5.000,- gives en rabat på 15% af ordresummen.
    /// Hvis ordresummen er over 10.000,- gives en rabat på 20% af ordresummen.
    /// </summary>
    /// <param name="ordre"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
        double IRabatBeregner.BeregnRabat(Order ordre)
        {
            if (ordre.OrdreSum > 10000) return ordre.OrdreSum * 0.2;
            if (ordre.OrdreSum > 5000) return ordre.OrdreSum * 0.15;
            if (ordre.OrdreSum > 1000) return ordre.OrdreSum * 0.10;

            return 0;
        }
}

public class Kunde
{
    public KundeType KundeType { get; set; }
}

public enum KundeType
{
    Privat,
    Virksomhed
}

public class Order
{
    public Kunde Kunde { get; set; }
    public double OrdreSum { get; set;}
}