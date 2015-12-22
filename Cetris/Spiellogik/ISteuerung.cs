﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cetris.Verwaltung;

namespace Cetris.Spiellogik
{
interface ISteuerung
{
// Neues Spiel starten
void NeuesSpiel(Spieltyp spieltyp);
//Bewegung des Spielsteins
void Rechts();
void Links();
void Runter();
void HardDrop();
void Drehen();
}
}
