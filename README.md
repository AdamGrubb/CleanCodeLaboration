### Dokumentation

Jag började med att dela upp koden i delarna: Model, View, Controller.
<details>
<summary><strong>Model</strong></summary><br>

I Model-delen så delade jag upp koden i **Spel-logik** och **datahantering**. 

För **datahanteringen** gjorde jag ett interface (IGameDAO) som ska implemeneras av klassen som kommer vara ansvarig för att hämta och spara datan. Min tanke var att man enkelt kunde byta implementation av den till ett webapi eller liknande. Den logik som finns ursprungligen i MooGame implementerade jag i klassen LocalFileDAO.
Jag flyttade sedan all kod som hade med datahantering till den klassen.<br><br> Jag valde att använda strategy pattern för att hantera olika spel i min applikation.
Först bröt jag ut de metoder som skulle vara samma för alla andra framtida spel och satt det som metoder i en klass som jag döpte till GameContext. GameContext tar emot en **IGameDAO** i sin constructor för att sedan kunna implementera det i underliggande strategier.<br><br>
Resten av metoderna som ska vara specifika för respektive spel bröt jag ut till en **IGameStrategy** interface som är grunden för MooGame och framtida spel.
Jag gick sedan igenom metoderna för att se så att varje metod höll sig så gott som möjligt till "single responsibility principle" och bröt vid behov ut privata metoder.<br><br>
Jag skapade även en metod för att via "method injection" ge varje **IGameStrategy** möjligheten att lagra ett IGameDAO i ett fält för att kunna spara och hämta resultat i spellogiken.<br><br>
För att kunna välja nya strategier i "strategy pattern" så skapade jag en SetGameStrategy i GameContext där man kunde välja vilket spel man vill spela. I den metoden valde jag att använda mig av "builder pattern" utan någon director för att konfigurera spelen på det sättet jag ville. Jag tyckte att det gav en bättre överblick över vad buildern faktiskt konfigurerar.
</details>
<details>
<summary><strong>View</strong></summary><br>
I View så skapade jag ett interface för I/O som helt enkelt är till för att skicka strängar från spellogiken och rendera dem på något sätt. Samt att skicka "tillbaka" användarinput.<br><br>
I flera strängar i MooGame så fanns "\n" för att skapa önskade radbyten. Jag valde att flytta dessa ur metoderna i spellogiken och lägga dem i I/O-klassen. 

```csharp
   public class ConsoleView : IIO
    {
        string spacing = "\n";
        public void GameOutput(string gameOutput)
        {
            Console.WriteLine(gameOutput + spacing);
        }

        public string GetUserInput()
        {
            return Console.ReadLine();
        }
    } 
```

På det sättet så separerar jag det från spel-logiken och hur det visas upp för spelaren. Om man skulle vilja ändra utseendet på spelet (med fler eller färre radbyte) så behöver man inte gå igenom alla strategier och ändra i koden. Utan man kan istället ändra på ett ställe i implementationen av I/O.

</details>
<details>
<summary><strong>Controller</strong></summary><br>
Controllern är den klass som startar spel-loopen och får via "constructor injection" in IGameContext & IIO. Det är i denna klass som jag har MooGame (och efterföljande spel) spel-loopar. En loop över hela "speltillfället" och tillhörande meny. Sen en loop gör att spelaren får gissa rätt svar.

</details>
