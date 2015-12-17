using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cetris
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
void preview(Stein stein);
//Zeigt Score an
void ShowScore(int score);
//Zeigt Lines an
void ShowLines(int lines);
}
}
