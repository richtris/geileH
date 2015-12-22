using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cetris.Verwaltung;

namespace Cetris.Spiellogik
{
    class Spielfeld : ISteuerung
    {
        // Spielfeldgröße
        public static readonly int xmax = 10;
        public static readonly int ymax = 20;

        // Die Spielfeldmatrix
        private int[,] spielfeld = new int[xmax + 2, ymax + 2];

        // Der momentan aktive Spielstein
        public Spielstein aktSpielstein;

        // Zufallsgenerator initialisieren
        private Random random = new Random();

        /// <summary>
        /// Leeres Spielfeld + Rahmen erzeugen
        /// </summary>
        private void InitSpielfeld()
        {
            for (int i = 0; i < xmax + 2; i++)
            {
                for (int j = 0; j < ymax + 2; j++)
                {
                    if (i == 0 || j == 0 || i == xmax + 1 || j == ymax + 1)
                    {
                        //Rand mit -1 auffüllen, damit Steine nicht drüber rutschen
                        spielfeld[i, j] = -1;
                    }
                    else
                        // Alles andere Leer
                        spielfeld[i, j] = 0;
                }
            }
        }
    }
}
