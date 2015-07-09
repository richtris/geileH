using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Uebung12
{
    public class Bedienung
    {
        private ISchanktheke theke;
        private int id;
        private int umsatz = 0;
        private int wartezeit = 0;
        private Stopwatch stopWatch = new Stopwatch();
        private const int BEDIENZEIT_MIN = 20000;
        private const int BEDIENZEIT_MAX = 30000;

        public Bedienung(int id, ISchanktheke schanktheke)
        {
            this.id = id;
            this.theke = schanktheke;
        }
        public void run()
        {
            try
            {
                while (true)
                {
                    stopWatch.Start();
                    List<Getraenk> biere = theke.get();
                    stopWatch.Stop();
                    // Get the elapsed time as a TimeSpan value.
                    TimeSpan ts = stopWatch.Elapsed;
                    wartezeit += ts.Seconds;
                    umsatz += biere.Count;
                    Console.WriteLine("<Bedienung " + id + "> Bringe " + biere.Count + " Getränke zu den Tischen ");
                    Thread.Sleep(new Random().Next(BEDIENZEIT_MIN, BEDIENZEIT_MAX));
                }
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine("Bedienung " + id + " Umsatz " + umsatz + " Maß, Wartezeit: " + wartezeit);
            }
        }
        public int GetWartezeit()
        {
            return wartezeit;
        }
    }
}
