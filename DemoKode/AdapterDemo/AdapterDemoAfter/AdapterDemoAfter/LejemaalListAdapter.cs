namespace AdapterDemoAfter;

public class LejemaalListAdapter : ILejemaalListTarget
{
    List<Lejemaal> ILejemaalListTarget.HentLejemaal()
    {
        var lejemaalAdaptee = new LejemaalCsvAdaptee();
        var lejemaalData = lejemaalAdaptee.GetLejemaalData();
        var lejemaalList = new List<Lejemaal>();
        
        foreach (var lejemaal in lejemaalData)
        {
            var lejemaalParts = lejemaal.Value;
            double lejemaalKvadratmeter;
            int lejemaalNummer;
            int antalRum;
            double.TryParse(lejemaalParts[1], out lejemaalKvadratmeter);
            int.TryParse(lejemaalParts[0], out lejemaalNummer);
            int.TryParse(lejemaalParts[2], out antalRum);
            lejemaalList.Add(new Lejemaal
            {
                Lejlighednummer = lejemaalNummer,
                Kvadratmeter = lejemaalKvadratmeter,
                AntalRum = antalRum
            });
        }

        return lejemaalList;
    }
}