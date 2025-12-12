# MVC Training

En enkel ASP.NET Core MVC-app (target .NET 9) som visar uppfinnarens kontaktuppgifter och listar alster. Uppbyggd enligt Model-View-Controller.

## Installera och starta
- Krav: .NET SDK 9.0 (eller nyare runtime om du kör publicerad exe).
- Lokal utveckling: `dotnet restore` och sedan `dotnet run` från projektroten.
- Färdigbyggd exe finns redan i repot under `bin\Release\net9.0\win-x64\publish\`. Kopiera hela den katalogen till den plats där du vill köra programmet (alla filer måste följa med) och starta `MVC Inventor.exe` i den kopierade publish-mappen.
- (Valfritt) Bygg om själv: `dotnet publish -c Release -r win-x64 --self-contained true`.
- Om du startar `MVC Inventor.exe` direkt: ett konsolfönster/logg visar rader som `Now listening on: http://localhost:XXXX`; öppna någon av adresserna som visas där. Publish-läget använder oftast http://localhost:5000 (och https://localhost:5001 om utvecklarcertifikat finns), men gå alltid på den URL som skrivs ut vid start.


## Datastruktur för alster
- Källdata: `Data/Alster.json` kopieras till utdata vid build/publish.
- Struktur: varje post har fälten `id`, `name`, `description`, `image`.
- Tillhörande bilder ligger i `wwwroot/Images` och refereras via `image`-fältet (t.ex. `Images/1.webp`).
- Motivering: JSON i en egen katalog är enkel att uppdatera utan kodändring, och kan senare ersättas av databas genom att behålla interfacet `IAlsterRepository`.
