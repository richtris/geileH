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
        private Highscore() {
            this.Liste = new Dictionary<String, int>();
        
        }

        public static Highscore Instance
        {
            get
            { return instanceBiatch; }


        }

        private Dictionary<String, int> Liste
        {
            get;
            set;

        }

        public void Add(string name, int score)
        {
            Liste.Add(name, score);
        }

        public void PrintHighscore()
        {
            var items = from pair in Liste
                        orderby pair.Value descending
                        select pair;

            int i = 0;
            Console.WriteLine("Highscore\n___________");
            foreach (KeyValuePair<string, int> pair in items)
            {
                i++;

                Console.WriteLine(String.Format("--- {0} --- {1} --- {2} ", i, pair.Key, pair.Value));
            }
            Console.WriteLine("_____________________\n");

        }

    }
}

