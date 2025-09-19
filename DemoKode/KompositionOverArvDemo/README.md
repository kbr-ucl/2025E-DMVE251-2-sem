# Komposition over arv – C# mini-projekt

Et lille, pædagogisk Visual Studio-projekt der demonstrerer **komposition over arv** med en hverdagsanalog: *"Bil har en motor og bremser"* (has‑a), fremfor *"Bil er en bestemt type motor"* (is‑a).

```
[ Bil ] --har--> [ IMotor ]
                    /            [BenzinMotor] [ElMotor]

[ Bil ] --har--> [ IBremse ]
                    /                 [SkiveBremse] [TromleBremse]
```

## Sådan kører du projektet
1. **Åbn** `KompositionOverArvDemo.csproj` i Visual Studio 2022+ (eller nyere).
   - Alternativt: `dotnet build` og `dotnet run` i mappen (kræver .NET 8 SDK).
2. **Kør (F5)** og se konsol-outputtet.
3. Kig i mappen `Domaene/` for kompositionsdelene og `ArvEksempel/` for arv-varianten.

## Nøglepointer til undervisning
- Komposition gør adfærd **udskiftelig** uden at ændre typen (vi skifter motor/bremser i runtime).
- Undgår **klasse-eksplosion** når flere dimensioner varierer (motor, bremser, …).
- Bedre **testbarhed**: `IMotor` og `IBremse` kan mocks/fakes i enhedstests.

## Mini-øvelse
1. Tilføj en ny komponent `INavigation` med fx `GpsNavigation` og `OfflineKortNavigation` og integrér den i `Bil`.
2. Skriv en `FakeMotor` der gemmer kald i en liste, og brug den til en lille enhedstest af `Bil`.
3. Diskutér hvornår **arv** stadig er passende (stabilt *is‑a* hierarki, fx `Cirkel : Form`).

God fornøjelse!
