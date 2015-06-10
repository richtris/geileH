using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeileH
{
    class FeuerZauber : Zauber
    {
        public FeuerZauber(){

            this.Category = "Feuer";
        }
        public override string Zaubern()
        {
            return "Zaubere Feuer...";
        }
    }


    class WasserZauber : Zauber
    {
         public WasserZauber(){

            this.Category = "Wasser";
        }
        public override string Zaubern()
        {
             return "Zaubere Wasser...";
        }
    }

    class LuftZauber : Zauber
    {
        public LuftZauber(){

            this.Category = "Luft";
        }
        public override string Zaubern()
        {
            return "Zaubere Luft...";
        }
    }

    class ErdeZauber : Zauber
    {
        public ErdeZauber(){

            this.Category = "Erde";
        }
        public override string Zaubern()
        {
            return "Zaubere Erde...";
        }
    }

}
