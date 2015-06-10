using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeileH
{
    class Besen
    {
        private string zustand;


        public string Zustand
        {

            get { return String.Format("Der Besen {0}.",this.zustand); }

            private set { zustand = value;}
        }

        public void Putzen()
        {
            this.Zustand = "putzt";
         
        }

        public void Fliegen()
        {
            this.Zustand = "fliegt";
        }

    }
}
/*
public liste= superliste
tu zeug indexer liste
rechne
gib aus
mach irgendwas
du hure
*/