using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung12
{
    public class Getraenk
    {
        private string name;
        private int tischNr;

        /**
         * erzeugt eine Maß Bier
         * bestimmt per Zufall eine Tischnummer 
         */
        public Getraenk()
        {
            name = "Bier";
            tischNr = (int)(new Random().Next(100));
        }
        public String getName()
        {
            return name;
        }
        public int getTischNr()
        {
            return tischNr;
        }
    }
}
