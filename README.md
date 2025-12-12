# MVC Training

En enkel ASP.NET Core MVC-app (target .NET 9) som visar uppfinnarens kontaktuppgifter och listar alster. Uppbyggd enligt Model-View-Controller.

## Installera och starta
- Krav: .NET SDK 9.0 (eller nyare runtime om du kör publicerad exe).
- Lokal utveckling: `dotnet restore` och sedan `dotnet run` från projektroten.
- Färdigbyggd exe finns redan i repot under `bin\Release\net9.0\win-x64\publish\`. Kopiera hela den katalogen till den plats där du vill köra programmet (alla filer måste följa med) och starta `MVC Inventor.exe` i den kopierade publish-mappen.
- (Valfritt) Bygg om själv: `dotnet publish -c Release -r win-x64 --self-contained true`.

## Datastruktur för alster
- Källdata: `Data/Alster.json` kopieras till utdata vid build/publish.
- Struktur: varje post har fälten `id`, `name`, `description`, `image`.
- Tillhörande bilder ligger i `wwwroot/Images` och refereras via `image`-fältet (t.ex. `Images/1.webp`).
- Motivering: JSON i en egen katalog är enkel att uppdatera utan kodändring, och kan senare ersättas av databas genom att behålla interfacet `IAlsterRepository`.

## Reflektion kring val
- MVC-struktur för tydlig separation av ansvar och enkel vidareutveckling.
- Repositorymönster: `IAlsterRepository` + `JsonAlsterRepository` gör datakällan utbytbar (kan bytas till DB senare utan att röra controllers/views).
- Statisk data + bilder i `Data/` och `wwwroot/Images` för att hålla innehåll redigerbart och skilt från logik.
- Publicering som self-contained exe med hela publish-katalogen för att kunna köra på maskiner utan .NET installerat och samtidigt få med statiska webbtillgångar.
