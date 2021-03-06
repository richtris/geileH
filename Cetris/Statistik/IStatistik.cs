﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cetris.Statistik
{
    interface IStatistik
    {
        // Gibt die aktuelle Highscoreliste zurück
        Highscore highscore {get; set;}
        // Punktestand
        int Score {get; set;}
        // Anzahl der gefallenen Steine (typId, anzahl)
        Dictionary<int,int> steinCount {get; set;}
        // Spielstart
        DateTime Startzeit {get; set;}
        // Der aktuelle User
        String User { get; set; }
        // Spielende
        DateTime Endzeit {get; set; }
        // Blocks per Minute
        int BPM {get; set; }
        // Spiellevel
        int Level {get; set;}
        // Anzahl Lines
        int Lines { get; set; }
        // Speichert die Daten eines Spiels in DB
        void Save();
        // Setzt die Spieldaten zurück
        void Reset();
    
    }
}
