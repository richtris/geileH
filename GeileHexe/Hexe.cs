using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeileH
{
    class Hexe
    {
        public Hexe()
            : this(new Zauber[] { new WasserZauber(), new FeuerZauber(), new LuftZauber(), new ErdeZauber() })
        { }
      
        public Hexe(Zauber[] zauberliste)
        {
            foreach (Zauber z in zauberliste)
                this.AddZauber(z);
       }

        private Hut Hut
        {
            get; set;
        }
        private Zauber Zauber
        {
            get; set;
        }

        private Besen Besen
        {
            get; set;
        }

        private Dictionary<string,Zauber> Zauberliste { get; set; }

        public void AddZauber(Zauber zauber)
        {
            if (zauber == null)
                return;
            
            if(Zauberliste == null)
                Zauberliste = new Dictionary<string,Zauber>();
            
            this.Zauberliste.Add(zauber.Category,zauber);
       }

        public void Zaubere(Zauber zauber)
        {
            if (Zauberliste.Keys.Contains(zauber.Category))
            {
                var zauberspruch = Zauberliste[zauber.Category].Zaubern();
                Console.WriteLine(zauberspruch);
            }

            else throw new Exception("Die Hexe kann diesen Zauber nicht!");
        }
    }
}
