
    using System;
    using System.Threading.Tasks;

    namespace DiningPhilosophers
    {
        public enum EatingStrategy { Waiter, Ordered }

        public static class Program
        {
            public static async Task Main(string[] args)
            {
                int philosophers = args.Length > 0 && int.TryParse(args[0], out var n) ? Math.Max(2, n) : 5;
                int seconds      = args.Length > 1 && int.TryParse(args[1], out var s) ? Math.Max(1, s) : 10;
                var strategy     = EatingStrategy.Waiter;

                if (args.Length > 2)
                {
                    var sarg = args[2].Trim().ToLowerInvariant();
                    strategy = sarg.StartsWith("ord") ? EatingStrategy.Ordered : EatingStrategy.Waiter;
                }

                Console.WriteLine($"Starter med {philosophers} filosoffer i {seconds}s, strategi: {strategy}");

                var table = new DiningTable(philosophers, strategy);
                await table.RunAsync(TimeSpan.FromSeconds(seconds));

                Console.WriteLine("Færdig.");
            }
        }
    }
