using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeileH;

namespace GeileHexe
{
    class Program
    {
        static void Main(string[] args)
        {

 
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