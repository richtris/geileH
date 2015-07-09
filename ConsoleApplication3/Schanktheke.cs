using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Uebung12
{
    public class Schanktheke : ISchanktheke
    {
        //	 Anzahl der Getränke die in Durchreiche gleichzeitig stehen dürfen
        private int kapazitaet;
        private int durchsatz = 0;

        private List<Getraenk> getraenke = new List<Getraenk>();

        public Schanktheke(int kapazitaet)
        {
            this.kapazitaet = kapazitaet;
        }

        public List<Getraenk> get()
        {
            List<Getraenk> biere = new List<Getraenk>(); ;
            lock (getraenke)
            {
                while (getraenke.Count < Bierzelt.ANZAHL_BIER_PRO_BEDIENUNG)
                { // nicht genügend Getränke da
                    Console.WriteLine("Bedienung wartet");
                    Monitor.Wait(getraenke);
                }
                // Mehrere Getränke von der Theke nehemen
                for (int i = 0; i < Bierzelt.ANZAHL_BIER_PRO_BEDIENUNG; i++)
                {
                    biere.Add(getraenke[0]);
                    getraenke.RemoveAt(0);
                    durchsatz++;

                }
                Console.WriteLine("<Schanktheke> " + Bierzelt.ANZAHL_BIER_PRO_BEDIENUNG + " Bier von der Theke entfernt (-> Anzahl: "
                    + getraenke.Count + ")");
                Monitor.PulseAll(getraenke);  // Benachrichtigung, dass wieder ein Platz frei ist in Schanktheke
            }
            return biere;
        }

        public void put(Getraenk getraenk)
        {
            lock (getraenke)
            {
                while (getraenke.Count >= kapazitaet)
                {
                    Console.WriteLine("Schankwirt wartet");
                    Monitor.Wait(getraenke);  // kein Platz in Schanktheke
                }
                //Maximal 5 Getraenke zapfen
                int anzBier = 0;
                for (int i = 0; i < 5 && getraenke.Count < kapazitaet; i++)
                {
                    getraenke.Add(getraenk);
                    anzBier++;
                }
                Console.WriteLine("<Schanktheke> " + anzBier + " " + getraenk.getName() +
                        " auf die Theke gestellt (-> Anzahl: " + getraenke.Count + ")");
                Monitor.PulseAll(getraenke); // Benachrichtigung, dass neue Getränke auf Theke stehen
            }
        }


        public int Durchsatz()
        {
            return durchsatz;
        }
        public int AnzahlGetraenke()
        {
            return kapazitaet - getraenke.Count;
        }
    }
}
