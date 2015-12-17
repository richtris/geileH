using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cetris
{
interface IStatistik
{
// Gibt die aktuelle Highscoreliste zurück
Highscore highscore {get; private set;}
// Punktestand
int Score {get; private set;}
// Anzahl der gefallenen Steine (typId, anzahl)
Dictionary<int,int> steinCount;
// Spielstart
DateTime Startzeit {get; private set;}
// Der aktuelle User
String User {get; private set}
// Speichert die Daten eines Spiels in DB
void Save();
// Spielende
DateTime Endzeit {get; private set; }
// Blocks per Minute
int BPM {get; private set; }

// Spiellevel
int Level {get; private set;}

}
