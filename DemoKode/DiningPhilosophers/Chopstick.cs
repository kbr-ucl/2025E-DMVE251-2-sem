
using System.Threading;
using System.Threading.Tasks;

namespace DiningPhilosophers
{
    // Repræsenterer en pind (gaffel) – en binær ressource.
    public sealed class Chopstick
    {
        private readonly SemaphoreSlim _sem = new SemaphoreSlim(1, 1);
        public int Id { get; }

        public Chopstick(int id) => Id = id;

        public Task PickUpAsync(CancellationToken ct) => _sem.WaitAsync(ct);

        public void PutDown() => _sem.Release();
    }
}
