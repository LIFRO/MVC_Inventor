# Reflektion

Jag valde att lägga alsterdata i en separat JSON-fil (`Data/Alster.json`) och läsa in den via `JsonAlsterRepository` som registreras mot `IAlsterRepository`. Det gör att vyerna bara känner till kontraktet och inte källan, vilket underlättar om data senare flyttas till en databas eller ett API. Filen kopieras till utdata vid build och ligger nära projektet så att den är enkel att uppdatera utan att röra koden.

Jag justerade också bildvägarna till `wwwroot/Images` (stort I) för att undvika problem på filsystem som är skiftlägeskänsliga, och bytte modellen till PascalCase-egenskaper (`Description`) så att den följer .NET-konventioner. UI-texten är på svenska, med en minimal navbar bevarad och en kontaktsida som visar en svensk adress och e-post.

Problem som dök upp var främst teckenkodning (svenska tecken i vyer/JSON) och inkonsekventa property-namn. Jag verifierade filerna med UTF-8 och rensade upp namn och länkar så att de fungerar likadant i vyn och datastrukturen. Nästa steg för vidare utveckling är att lägga till ett formulär för att skapa/redigera alster och ersätta JSON-läsningen med en databasimplementation bakom samma interface, samt att komplettera med tester för repositoryt och MVC-flödena.
