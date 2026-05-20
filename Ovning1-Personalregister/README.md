# C# Övning 1 - Personalregister

## Uppgift 1 — Vilka klasser bör ingå i programmet?

Tre klasser: `Person` för att representera en anställd, `PersonRegister` för att hantera samlingen av anställda, och `Menu` för att sköta användargränssnittet i konsolen. Varje klass har ett tydligt ansvar — data, logik och presentation.

## Uppgift 2 — Vilka attribut och metoder bör ingå i dessa klasser?

`Person` har attributen `Namn` (string) och `Lon` (string), samt en `ToString()`-metod för utskrift.

`PersonRegister` har en `List<Person>` internt och metoderna `AddPerson()` för att lägga till en anställd, `Last()` för att hämta den senast tillagda, och `ToString()` för att skriva ut hela registret.

`Menu` har inga egna attribut utan arbetar mot registret som skickas in. Den har metoderna `Add()` och `List()` för respektive menyval.

## Uppgift 3 — Programmet

Se `Program.cs` för den fullständiga implementationen.

### Notering

Lön lagras som `string` istället för `decimal`. Validering med `decimal.TryParse()` hade gjort programmet mer robust, men jag ansåg att det låg utanför uppgiftens scope då kravet var att ta emot och lagra — inte att validera inmatningen.
