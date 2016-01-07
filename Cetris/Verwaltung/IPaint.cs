using Cetris.Spiellogik;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cetris.Verwaltung
{
interface IPaint
{
// Erzeugt eine neue Spielfeldansicht
void Create();
// Setzt die Ansicht zurück auf den Anfangszustand (neues Spiel)
void Reset();
// Änderungen am Spielfeld sichtbar machen
void Update(int[,] spielfelddaten);
// Steuerung deaktivieren, GameOver Text anzeigen
void GameOver();
//Zeigt nächsten Stein an
void preview(Spielstein stein);


//Todo: remove, GUI zieht Daten selbst aus Istatistik (?)
////Zeigt Score an
//void ShowScore(int score);
////Zeigt Lines an
//void ShowLines(int lines);


}
}
