namespace EjendomsberegnerIoC;

public interface IEjendomBeregnerService
{
    double BeregnKvadratmeter();
}

/// <summary>
/// Kan funktionaliteten opdeles således koden bliver mere funktionel "ren" (en metode ét ansvar)?
///  Er der et skjult model objekt i opgaven?
///  Hvad skal retur typen for adapteren være?
/// </summary>
public class EjendomBeregnerService: IEjendomBeregnerService
{

    private ILejemaalRepository _repo;

    public EjendomBeregnerService(ILejemaalRepository repo)
    {
        _repo = repo;
    }

    /// <summary>
    ///     Beregner ejendommens kvadratmeter ud fra ejendommens lejelmål.
    ///     Lejemål er i en simikolon separeret tekstfil. Formatet af filen er:
    ///     lejlighednummer; kvadratmeter; antal rum
    ///     lejlighednummer: int
    ///     kvadratmeter: double
    ///     antal rum: double
    /// 
    ///     Første linje i filen er en header og skal ignoreres.
    /// 
    ///     Filen med lejemål er med i projektet og hedder "LejemaalData.csv"
    /// </summary>
    /// <returns></returns>
    double IEjendomBeregnerService.BeregnKvadratmeter()
    {
        var lejemaalene = _repo.HentLejemaal();
        double kvadratmeter = 0.0;


        foreach (Lejemaal lejemaal in lejemaalene)
        {
            kvadratmeter += lejemaal.Kvadratmeter;
        }

        return kvadratmeter;
    }






    public class Lejemaal
    {
        public int Lejlighednummer { get; set; }
        public double Kvadratmeter { get; set; }
        public int AntalRum { get; set; }
    }

    public interface ILejemaalRepository
    {
        List<Lejemaal> HentLejemaal();
    }

    public class LejemaalFraFilRepository : ILejemaalRepository
    {
        public LejemaalFraFilRepository()
        {
            Console.WriteLine();
        }
        public string DataFileName { get; set; } = "LejemaalData.csv";
        List<Lejemaal> ILejemaalRepository.HentLejemaal()
        {
            var raaData = File.ReadAllLines(DataFileName).Skip(1).ToArray();
            var lejemaal = Konverter(raaData);
            return lejemaal;
        }

        private List<Lejemaal> Konverter(string[] data)
        {
            var lejemaalListe = new List<Lejemaal>();
            foreach (string lejemaal in data)
            {
                string[] lejemaalParts = lejemaal.Split(';');
                double lejemaalKvadratmeter;
                int lejemaalNummer;
                int antalRum;
                double.TryParse(RemoveQuotes(lejemaalParts[1]), out lejemaalKvadratmeter);
                int.TryParse(RemoveQuotes(lejemaalParts[0]), out lejemaalNummer);
                int.TryParse(RemoveQuotes(lejemaalParts[2]), out antalRum);

                lejemaalListe.Add(new Lejemaal
                {
                    Lejlighednummer = lejemaalNummer,
                    Kvadratmeter = lejemaalKvadratmeter,
                    AntalRum = antalRum
                });
            }

            return lejemaalListe;
        }
        private string RemoveQuotes(string lejemaalPart)
        {
            return lejemaalPart.Replace('"', ' ').Trim();
        }
    }

}