using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeileH
{
    class Hut
    {
        enum HutStates
        {
            Auf = 1,
            Ab = 2,
        }

        enum HutFarben
        {
            Schwarz, Weiss, Rot
        }

        private HutStates state;
        private HutFarben farbe;

        public void Aufsetzen()
        {
            this.state = HutStates.Auf;
        }

        public void FarbeWechseln()
        {
            this.farbe = HutFarben.Schwarz;
        }

        public void Absetzen()
        {
            this.state = HutStates.Ab;
        }

        public String ToString()
        {
            return "Hut"; 
        }
    }
}
