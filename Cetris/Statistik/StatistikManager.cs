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
            Highscore = new Highscore();
            Reset();
        }

        public Highscore Highscore
        {
            get;
            private set;
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
            private set;
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
            Highscore.Add(User, Score);
            Console.WriteLine("Daten werden in Datenbank gespeichert ...");
        }

        public void Reset()
        {
            Console.WriteLine("Daten werden zurückgesetzt...");
        }
    }
}
