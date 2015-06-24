using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeileH;
using RichtrisObjects;

namespace GeileHexe
{
    class Program
    {
        static void Main(string[] args)
        {
            Highscore highscore = Highscore.Instance;

            highscore.Add("Ich", 2147438648);
            highscore.Add("Du", -2147438648);

            highscore.PrintHighscore();


            Highscore highscore2 = Highscore.Instance;

            highscore2.Add("Richi", 2147483647);
            highscore2.PrintHighscore();

            Hexe hexe = new Hexe();
            
            hexe.Zaubere(new WasserZauber());
            hexe.Zaubere(new FeuerZauber());
            hexe.Zaubere(new WasserZauber());
            hexe.Zaubere(new ErdeZauber());

            Console.ReadKey();
        }
    }
}
             /*
            var hut = hexe.Hut = new Hut();
            var besen = hexe.Besen = new Besen();
            var zauber = hexe.Zauber = new FeuerZauber();


            
            hut.Aufsetzen();

            besen.Fliegen();
   
            /*Console.WriteLine(besen.Zustand);
           
            hut.Absetzen();*/