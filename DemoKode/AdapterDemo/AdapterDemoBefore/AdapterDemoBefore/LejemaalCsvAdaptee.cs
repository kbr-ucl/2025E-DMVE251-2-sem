namespace AdapterDemoBefore;

public class LejemaalCsvAdaptee
{
    public string DataFileName { get; set; } = "LejemaalData.csv";

    /// <summary>
    ///     Indlæser ejendommens lejlighednummer, kvadratmeter og antal rum ud fra ejendommens lejelmål.
    ///     Lejemål er i en simikolon separeret tekstfil. Formatet af filen er:
    ///     lejlighednummer; kvadratmeter; antal rum
    ///     lejlighednummer: int
    ///     kvadratmeter: double
    ///     antal rum: double
    ///     Første linje i filen er en header og skal ignoreres.
    ///     Filen med lejemål er med i projektet og hedder "LejemaalData.csv"
    /// </summary>
    /// <returns>
    ///     Et Dictonary hvor lejlighedsnummer er key og data er et string array med lejlighednummer, kvadratmeter og antal rum
    /// </returns>
    public Dictionary<int, string[]> GetLejemaalData()
    {
        var lejemaalene = File.ReadAllLines(DataFileName);

        var lejemaalData = new Dictionary<int, string[]>();

        foreach (var lejemaal in lejemaalene)
        {
            var lejemaalParts = lejemaal.Split(';');
            double lejemaalKvadratmeter;
            int lejemaalNummer;
            int antalRum;
            double.TryParse(RemoveQuotes(lejemaalParts[1]), out lejemaalKvadratmeter);
            int.TryParse(RemoveQuotes(lejemaalParts[0]), out lejemaalNummer);
            int.TryParse(RemoveQuotes(lejemaalParts[2]), out antalRum);

            lejemaalData.Add(lejemaalNummer, new[]
            {
                lejemaalNummer.ToString(),
                lejemaalKvadratmeter.ToString(),
                antalRum.ToString()
            });
        }

        return lejemaalData;
    }

    private string RemoveQuotes(string lejemaalPart)
    {
        return lejemaalPart.Replace('"', ' ').Trim();
    }
}