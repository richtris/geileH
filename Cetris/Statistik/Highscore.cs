using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cetris.Statistik
{
    class Highscore
    {
        Dictionary<string,int> liste = new Dictionary<string,int>();

        public void WriteHighscoreToConsole()
        {
            var topten = liste.OrderBy(l => l.Key).Take(10);
            foreach(var entry in topten)
            {
                Console.WriteLine("name " + entry.Key + ", score: " + entry.Value);
            }
        }
        
        public void Add(string name, int score)
        {
            liste.Add(name, score);
        }


    }
}
