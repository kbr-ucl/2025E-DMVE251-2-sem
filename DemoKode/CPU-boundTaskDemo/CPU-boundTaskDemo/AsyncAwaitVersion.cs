namespace CPU_boundTaskDemo;

internal class AsyncAwaitVersion
{
    public async Task CalculatePrimenumbers(int maxNumber)
    {
        Console.WriteLine($"Async-Await Version - Calculating Prime numbers! - in the range 0 - {maxNumber}");

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

        var results = await Task.WhenAll(tasks);

        var endTid = DateTime.Now;
        foreach (var result in results) primes = primes.Union(result).ToList();

        //results.ToList().ForEach(a => primes = primes.Union(a).ToList());
        var sortedPrimes = primes.Order().ToList();
        var sortEndTid = DateTime.Now;

        Console.WriteLine(
            $"Async-Await Version - Done - Task Tid: {endTid - startTid} - Sort tid: {sortEndTid - endTid} - Antal primtal: {sortedPrimes.Count()}");
    }
}