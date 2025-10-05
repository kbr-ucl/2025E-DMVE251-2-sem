namespace CPU_boundTaskDemo;

// ReSharper disable once InconsistentNaming
internal class TPLversion
{
    public void CalculatePrimenumbers(int maxNumber)
    {
        Console.WriteLine($"TPL Version - Calculating Prime numbers! - in the range 0 - {maxNumber}");

        var primes = new List<long>();
        var tasks = new List<Task<List<long>>>();
        var startTid = DateTime.Now;

        for (long i = 0; i < maxNumber; i += 1000000)
        {
            var start = i;
            var end = Math.Min(i + 1000000, maxNumber);
            tasks.Add(Task.Run(() =>
            {
                var result = new List<long>();
                for (var n = start; n < end; n++)
                    if (MyMath.IsPrime(n))
                        result.Add(n);
                return result;
            }));
        }

        Task.WaitAll(tasks);
        var endTid = DateTime.Now;

        tasks.ForEach(a => primes = primes.Union(a.Result).ToList());
        var sortedPrimes = primes.Order().ToList();
        var sortEndTid = DateTime.Now;

        Console.WriteLine(
            $"TPL Version - Done - Task Tid: {endTid - startTid} - Sort tid: {sortEndTid - endTid} - Antal primtal: {sortedPrimes.Count()}");
    }
}