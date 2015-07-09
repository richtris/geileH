using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Uebung12
{
    class Schankwirt
    {
        private ISchanktheke schanktheke;
        private int id;
        private const int SCHANKZEIT = 500;

        public Schankwirt(int id, ISchanktheke schankheke)
        {
            this.id = id;
            this.schanktheke = schankheke;
        }

        public void run()
        {
            while (true)
            {
                Getraenk bier = new Getraenk();
                int anzahlBiere = schanktheke.AnzahlGetraenke();
                schanktheke.put(bier);
                Console.WriteLine("<Schankwirt " + id + "> Habe " +
                    (schanktheke.AnzahlGetraenke() - anzahlBiere) +
                    bier.getName() + " gezapft");
                Thread.Sleep(SCHANKZEIT);
            }
        }

    }
}
