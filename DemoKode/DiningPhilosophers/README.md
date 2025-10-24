
# Dining Philosophers (C# / .NET 8)

Deadlock-fri demonstration af **Dining Philosophers** med to strategier og brug af `Task` og klasser.

## Krav
- .NET 10 SDK (eller nyere)

## Kørsel

Fra projektmappen:

```bash
dotnet run -- [antal_filosoffer] [sekunder] [strategi]
```

**Parametre (optionelle):**
- `antal_filosoffer` (default `5`, min `2`)
- `sekunder` (default `10`, min `1`)
- `strategi` = `waiter` (default) eller `ordered`

**Eksempler:**
```bash
dotnet run -- 5 10 waiter
dotnet run -- 7 15 ordered
```

## Strategier

- **Waiter (arbitrator):** Tillader højst `N-1` samtidige forsøg på at tage pinde. Det bryder cirklen og forhindrer deadlock.
- **Ordered (total orden):** Hver filosof tager altid først den pind med lavest id, derefter den højeste – ingen cirkulær venten kan opstå.

## Filer
- `Program.cs` – CLI, opsætning, afvikling.
- `DiningTable.cs` – opretter pinde og filosoffer, styrer livscyklus.
- `Philosopher.cs` – tænke-/spiselogik, begge strategier.
- `Chopstick.cs` – simpel binær ressource med `SemaphoreSlim`.

## Pædagogiske noter
- `SemaphoreSlim` bruges både som lås for pinde og som "tjener".
- `Random.Shared` giver jitter for at visualisere samtidighed.
- For fairness/sult kan man udbygge med kø-baseret semaphore eller tællere per filosof.
