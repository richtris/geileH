using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Uebung12
{
    public class Bierzelt
    {
        public const int ANZAHL_SCHANKWIRTE = 2;
        public const int ANZAHL_BEDIENUNGEN = 10;
        public const int KAPAZITAET_THEKE = 28;
        public static int ANZAHL_BIER_PRO_BEDIENUNG = 10;
        public static int ANZAHL_BIER_PRO_SCHANKWIRT = 5;
        public static int UMSATZ = 500;
        static void Main(string[] args)
        {
            ISchanktheke theke = new Schanktheke(KAPAZITAET_THEKE);

            Console.WriteLine("Starte Bierzelt ------------------------");
            Console.WriteLine("Schankwirte: " + ANZAHL_SCHANKWIRTE);
            Console.WriteLine("Bedienungen: " + ANZAHL_BEDIENUNGEN);
            Console.WriteLine("Kapazität Theke: " + KAPAZITAET_THEKE);

            // Zeitnahm starten
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Thread[] wirte = new Thread[ANZAHL_SCHANKWIRTE];
            for (int i = 0; i < ANZAHL_SCHANKWIRTE; i++)
            {
                Schankwirt sw = new Schankwirt(i + 1, theke);
                wirte[i] = new Thread(new ThreadStart(sw.run));
                wirte[i].Start();
            }

            Thread[] bedienungen = new Thread[ANZAHL_BEDIENUNGEN];
            Bedienung[] b = new Bedienung[ANZAHL_BEDIENUNGEN];
            for (int j = 0; j < ANZAHL_BEDIENUNGEN; j++)
            {
                b[j] = new Bedienung(j + 1, theke);
                bedienungen[j] = new Thread(new ThreadStart(b[j].run));
                bedienungen[j].Start();
            }

            // Bierzelt läuft bis Umsatzziel erreicht ist
            while (theke.Durchsatz() < UMSATZ)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Aktueller Durchsatz ist " + theke.Durchsatz());
            }
            Console.WriteLine("Ziel Durchsatz ist erreicht: " + theke.Durchsatz());
            Console.WriteLine("Ende des Betriebs");

            // Stoppen der Wirte
            for (int i = 0; i < ANZAHL_SCHANKWIRTE; i++)
            {
                wirte[i].Abort();
            }
            // Stoppen der Bedienungen
            int wartezeit = 0;
            for (int j = 0; j < ANZAHL_BEDIENUNGEN; j++)
            {
                wartezeit += b[j].GetWartezeit();
                bedienungen[j].Abort();
            }

            stopWatch.Stop();
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}",
                ts.Hours, ts.Minutes, ts.Seconds);
            Console.WriteLine("Betriebsdauer " + elapsedTime);
            Console.WriteLine("Wartezeit " + wartezeit);
            Console.WriteLine("Ende des Betriebs");
            Console.ReadKey();

        }
    }
}