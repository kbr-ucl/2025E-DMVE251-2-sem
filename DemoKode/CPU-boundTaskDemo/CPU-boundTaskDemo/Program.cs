var maxNumber = 100000000;

Console.WriteLine($"Calculating Prime numbers! - in the range 0 - {maxNumber}");

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
            if (IsPrime(n))
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
    $"Done - Task Tid: {endTid - startTid} - Sort tid: {sortEndTid - endTid} - Antal primtal: {sortedPrimes.Count()}");
Console.WriteLine("Press any key to output");
Console.Read();
return;

// Returnerer true hvis n er primtal
static bool IsPrime(long n)
{
    if (n < 2) return false;
    if (n == 2) return true;
    if (n % 2 == 0) return false;

    var limit = (long)Math.Floor(Math.Sqrt(n));
    for (long d = 3; d <= limit; d += 2)
        if (n % d == 0)
            return false;
    return true;
}