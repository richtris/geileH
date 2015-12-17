using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cetris
{
interface ISteuerung
{
// Neues Spiel starten
void NeuesSpiel(SpielTyp spieltyp);
//Bewegung des Spielsteins
void Rechts();
void Links();
void Runter();
void HardDrop();
void Drehen();
}
}
