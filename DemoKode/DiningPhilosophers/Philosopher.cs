
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DiningPhilosophers
{
    public sealed class Philosopher
    {
        public int Id { get; }
        private readonly Chopstick _left;
        private readonly Chopstick _right;
        private readonly EatingStrategy _strategy;
        private readonly SemaphoreSlim? _waiter; // Bruges kun ved Waiter-strategien

        public Philosopher(int id, Chopstick left, Chopstick right, EatingStrategy strategy, SemaphoreSlim? waiter)
        {
            Id = id;
            _left = left;
            _right = right;
            _strategy = strategy;
            _waiter = waiter;
        }

        public async Task LiveAsync(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                await ThinkAsync(ct);
                await EatAsync(ct);
            }
        }

        private async Task ThinkAsync(CancellationToken ct)
        {
            Log("tænker…");
            await DelayJitter(400, 1000, ct);
        }

        private async Task EatAsync(CancellationToken ct)
        {
            switch (_strategy)
            {
                case EatingStrategy.Waiter:
                    await EatWithWaiterAsync(ct);
                    break;
                case EatingStrategy.Ordered:
                    await EatWithOrderAsync(ct);
                    break;
            }
        }

        private async Task EatWithWaiterAsync(CancellationToken ct)
        {
            if (_waiter is null) throw new InvalidOperationException("Waiter-strategi kræver en SemaphoreSlim-‘waiter’.");

            bool waiterTaken = false, leftTaken = false, rightTaken = false;
            try
            {
                await _waiter.WaitAsync(ct);
                waiterTaken = true;

                await _left.PickUpAsync(ct);
                leftTaken = true;
                Log($"tog venstre (C{_left.Id})");

                await _right.PickUpAsync(ct);
                rightTaken = true;
                Log($"tog højre (C{_right.Id})");

                Log("spiser 🍝");
                await DelayJitter(300, 800, ct);
            }
            finally
            {
                if (rightTaken)
                {
                    _right.PutDown();
                    Log($"lagde højre (C{_right.Id})");
                }
                if (leftTaken)
                {
                    _left.PutDown();
                    Log($"lagde venstre (C{_left.Id})");
                }
                if (waiterTaken)
                {
                    _waiter.Release();
                }
            }
        }

        private async Task EatWithOrderAsync(CancellationToken ct)
        {
            var first  = _left.Id < _right.Id ? _left : _right;
            var second = _left.Id < _right.Id ? _right : _left;

            bool firstTaken = false, secondTaken = false;
            try
            {
                await first.PickUpAsync(ct);
                firstTaken = true;
                Log($"tog først C{first.Id}");

                await second.PickUpAsync(ct);
                secondTaken = true;
                Log($"tog derefter C{second.Id}");

                Log("spiser 🍝");
                await DelayJitter(300, 800, ct);
            }
            finally
            {
                if (secondTaken)
                {
                    second.PutDown();
                    Log($"lagde C{second.Id}");
                }
                if (firstTaken)
                {
                    first.PutDown();
                    Log($"lagde C{first.Id}");
                }
            }
        }

        private static async Task DelayJitter(int minMs, int maxMs, CancellationToken ct)
        {
            int delay = Random.Shared.Next(minMs, maxMs);
            await Task.Delay(delay, ct);
        }

        private void Log(string msg)
        {
            var t = DateTime.Now.ToString("HH:mm:ss.fff");
            Console.WriteLine($"[{t}] P{Id}: {msg}");
        }
    }
}
