### Dokumentation

Jag började med att dela upp koden i delarna: Model, View, Controller.
<details>
<summary><strong>Model</strong></summary>

I Model-delen så delade jag upp koden i Spel-logik och datahantering. 

I datahanteringen gjorde jag ett interface för GameDAO som är ansvarig för att hämta och spara datan. Min tanke var att man enkelt kunde byta implementation av den till ett webapi eller liknande.
Jag flyttade sedan all kod som hade med datahantering till den klassen.<br><br>
Jag tog därefter spel-logiken och bröt ut de metoder som skulle vara densamma för alla andra framtida spel och satt det som metoder i en klass som jag döpte till GameContext. GameContext tar emot en IGameDAO i sin constructor för att sedan kunna implementera det i underliggande strategier.<br><br>
Resten av metoderna som var mer specifika för respektive spel bröt jag ut till en IGameStrategy interface som är grunden för MooGame och framtida spel.
Jag gick sedan igenom metoderna för att se så att varje metod höll sig så gott som möjligt till "single responsibility principle" och bröt vi behov ut privata metoder vid behov.
När jag hade alla funktioner separerade var interfacet för IGameStrategy färdigt för att kunna bygga nya spel i framtiden.<br><br>
Jag skapade även en metod för att via "method injection" ge varje IGameStrategy möjligheten att lagra ett IGameDAO i ett fält för att kunna spara och hämta resultat i spellogiken.<br><br>
För att kunna välja nya strategier i "strategy pattern" så skapade jag en SetGameStrategy i GameContext där man kunde välja vilket spel man vill spela. I den metoden valde jag att använda mig av "builder pattern" utan någon director för att konfigurera spelen på det sättet jag ville. Jag tyckte att det gav en bättre överblick över vad buildern faktiskt konfigurerar utan director.
</details>
<details>
<summary><strong>View</strong></summary>
I View så har jag ett interface för I/O som helt enkelt är till för att skicka strängar från spellogiken och rendera dem på något sätt. Samt att skicka vidare användarinput.
Jag tog ut radbyten som inte hade med sträng-formatering i metoderna i spellogiken att göra och lade dem här. På det sättet så tänkte jag att jag separerade spel-logiken från hur det renderas för spelaren. På det sättet kan man enkelt ändra utseendet på spelet (det vill säga radbyten) på ett ställe istället för att behöva gå igenom alla strategier och ändra där. Jag anser heller inte att det har med spellogik att göra, så varje klass får syssla med vad de ska göra.

</details>
<details>
<summary><strong>Controller</strong></summary>
Controllern är den klass som startar spel-loopen och får via "constructor injection" in IGameContext & IIO. Det är i denna klass som jag har MooGame (och efterföljande spel: s) spel-loopar. Det finns en som loopar över hela speltillfället och tillhörande meny, sedan finns det en som är ansvarig för att loopa varje spel tills rätt svar har givits.

</details>
