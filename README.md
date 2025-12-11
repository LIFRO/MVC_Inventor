# MVC Training

En enkel ASP.NET Core MVC-app (target .NET 9) som visar en lista med snickerialster och en kontaktsida på svenska.

## Förutsättningar
- .NET SDK 9.0

## Kom igång
1. Klona projektet.
2. Installera beroenden: `dotnet restore`.
3. Starta: `dotnet run` (från projektroten). Applikationen hostas på den URL som skrivs ut i konsolen.

## Datastruktur för alster
- Källdata ligger i `Data/Alster.json` och kopieras till utdata vid build. Varje post har fälten `id`, `name`, `description`, `image`.
- Bilderna finns i `wwwroot/Images` och refereras via `image`-fältet, t.ex. `Images/1.webp`.
- `JsonAlsterRepository` läser in filen vid uppstart och exponerar data via `IAlsterRepository` (se `Program.cs`). Genom att isolera läsningen bakom ett interface kan källan bytas till t.ex. en databas utan att ändra vyerna.
- Lägg till/ändra alster genom att uppdatera `Data/Alster.json` och lägga motsvarande bild i `wwwroot/Images`. Starta om appen för att ladda nya poster.

## Vidareutveckling
- Behåll `IAlsterRepository` som kontrakt och implementera en ny repository-klass om du flyttar data till databas/filövervakning.
- Lägg till validering och formulär om alster ska skapas/redigeras från UI:t. Startpunkter finns i `Controllers/AlsterController.cs` och `Views/Alster/Index.cshtml`.
