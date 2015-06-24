using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RichtrisObjects
{
    public sealed class Highscore
    {
        private static readonly Highscore instanceBiatch = new Highscore();
        private Highscore() { }

        public static Highscore Instance
        {
            get
            { return instanceBiatch; }


        }

        public Dictionary<String, int> Liste
        {
            get;

        }
    }
}

