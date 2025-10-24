
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DiningPhilosophers
{
    public sealed class DiningTable
    {
        private readonly List<Chopstick> _chopsticks;
        private readonly List<Philosopher> _philosophers;
        private readonly SemaphoreSlim? _waiter;

        public DiningTable(int philosopherCount, EatingStrategy strategy)
        {
            if (philosopherCount < 2)
                throw new ArgumentOutOfRangeException(nameof(philosopherCount), "Mindst to filosoffer.");

            _waiter = strategy == EatingStrategy.Waiter
                ? new SemaphoreSlim(philosopherCount - 1, philosopherCount - 1)
                : null;

            _chopsticks = Enumerable.Range(0, philosopherCount)
                                    .Select(i => new Chopstick(i))
                                    .ToList();

            _philosophers = Enumerable.Range(0, philosopherCount)
                                      .Select(i =>
                                      {
                                          var left = _chopsticks[i];
                                          var right = _chopsticks[(i + 1) % philosopherCount];
                                          return new Philosopher(i, left, right, strategy, _waiter);
                                      })
                                      .ToList();
        }

        public async Task RunAsync(TimeSpan duration)
        {
            using var cts = new CancellationTokenSource(duration);
            var tasks = _philosophers.Select(p => p.LiveAsync(cts.Token));
            try
            {
                await Task.WhenAll(tasks);
            }
            catch (OperationCanceledException)
            {
                // Naturlig afslutning
            }
        }
    }
}
