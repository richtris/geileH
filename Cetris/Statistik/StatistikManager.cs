using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cetris.Statistik
{
    class StatistikManager : IStatistik
    {
        public StatistikManager()
        {
            highscore = new Highscore();
            Reset();
        }

        public Highscore highscore
        {
            get;
            set;
        }

        public int Score
        {
            get;
            set;
        }

        public Dictionary<int, int> steinCount
        {
            get;
            set;
        }

        public DateTime Startzeit
        {
            get;
            set;
        }

        public string User
        {
            get;
            set;
        }

        public DateTime Endzeit
        {
            get;
            set;
        }

        public int BPM
        {
            get;
            set;
        }

        public int Level
        {
            get;
            set;
        }


        public int Lines
        {
            get;
            set;
        }

        public void Save()
        {
            highscore.Add(User, Score);
            Console.WriteLine("Daten werden in Datenbank gespeichert ...");
        }

        public void Reset()
        {
            Console.WriteLine("Daten werden zurückgesetzt...");
        }
    }
}
