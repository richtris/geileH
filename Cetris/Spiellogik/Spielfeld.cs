using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cetris.Verwaltung;
using Cetris.Statistik;

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

        private IPaint gui;
        private IStatistik stats;

        public Spielfeld(IPaint gui, IStatistik stats)
        {
            this.gui = gui;
            this.stats = stats;
        }

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

        public void NeuesSpiel(Spieltyp spieltyp)
        {
            //Todo: Spieltyp wird noch nicht berücksichtigt ...

            InitSpielfeld();
            gui.Create(this.spielfeld);

            NeuerSpielstein();
            Setzen(aktSpielstein);
            gui.Update(this.spielfeld);

        }

        private void GameOver()
        {
            gui.GameOver();
        }

        public void Rechts()
        {
            if (Verschiebbar(aktSpielstein, Richtung.Rechts))
            {
                Verschieben(aktSpielstein, Richtung.Rechts);
            }

            gui.Update(this.spielfeld);
        }

        public void Links()
        {
            if (Verschiebbar(aktSpielstein, Richtung.Links))
            {
                Verschieben(aktSpielstein, Richtung.Links);
            }

            gui.Update(this.spielfeld);
        }
        

        public void Runter()
        {
            if (Verschiebbar(aktSpielstein, Richtung.Unten))
            {
                Verschieben(aktSpielstein, Richtung.Unten);
                gui.Update(this.spielfeld);
            }
            else
            {
                Ablegen(aktSpielstein);
              
                    NeuerSpielstein();
                    gui.Update(this.spielfeld);
                }
            }
        

        public void HardDrop()
        {
              bool dropped = false;
            do
            {
                if (Verschiebbar(aktSpielstein,Richtung.Unten))
                {
                    Verschieben(aktSpielstein,Richtung.Unten);
                }
                else
                {
                    Ablegen(aktSpielstein);
                    dropped = true;
                    NeuerSpielstein();
                    gui.Update(this.spielfeld);
                }
            } while (!dropped);
        }
        

        public void Drehen()
        {
            if (Drehbar(aktSpielstein))
            {
                Drehen(aktSpielstein);
            }

            gui.Update(this.spielfeld);
        }

        private bool Drehbar(Spielstein einSpielstein)
        {
            if (einSpielstein == null)
                return false;
            Spielstein verschobenerSpielstein = einSpielstein.Kopie();
            verschobenerSpielstein.Drehen();
            return Setzbar(verschobenerSpielstein);

        }

        private void Drehen(Spielstein stein)
        {
            Loeschen(stein);
            stein.Drehen();
            Setzen(stein);
        }


        /// <summary>
        /// Erzeugt einen neuen Spielstein
        /// </summary>
        private void NeuerSpielstein()
        {
            var randomInt = (int)(random.Next(1, 8));
            var neuerStein = new Spielstein(randomInt);

            // Wenn neuer Stein nicht setzbar, ist das Spiel zu Ende
            if (Setzbar(neuerStein))
            {
                aktSpielstein = neuerStein;

                // Kann der neue Stein nicht mehr verschoben werden, wird er sofort abgelegt. Danach ist das Spiel zu Ende.
                if (Verschiebbar(aktSpielstein, Richtung.Unten) || Verschiebbar(aktSpielstein, Richtung.Links) || Verschiebbar(aktSpielstein, Richtung.Rechts))
                {
                    return;
                }
                else
                {
                    Ablegen(aktSpielstein);
                }
            }
            aktSpielstein = null;
            GameOver();
        }


        /// <summary>
        ///  Prüft, ob der gegebene Spielstein in die gewünschte Richtung bewegt werden kann
        /// </summary>
        /// <param name="einSpielstein"></param>
        /// <param name="richtung"></param>
        /// <returns></returns>
        private bool Verschiebbar(Spielstein einSpielstein, Richtung richtung)
        {
            if (einSpielstein == null)
                return false;

            // "Geisterstein" erzeugen
            Spielstein verschobenerSpielstein = einSpielstein.Kopie();

            // mit Geisterstein die Bewegung simulieren
            verschobenerSpielstein.Verschieben(richtung);

            // Wenn Geisterstein an seiner neuen position setzbar, true zurückgeben
            return Setzbar(verschobenerSpielstein);

        }

        /// <summary>
        /// Stein wird im Spielfeld in die gewünschte Richtung verschoben
        /// </summary>
        /// <param name="einSpielstein"></param>
        /// <param name="richtung"></param>
        private void Verschieben(Spielstein einSpielstein, Richtung richtung)
        {
            Loeschen(einSpielstein);
            einSpielstein.Verschieben(richtung);
            Setzen(einSpielstein);
        }

        /// <summary>
        /// Prüft, ob der Stein an seiner aktuellen Position im Spielfeld gezeichnet werden kann
        /// </summary>
        /// <param name="stein"></param>
        /// <returns></returns>
        private bool Setzbar(Spielstein stein)
        {
            int farbe = stein.FarbCode;

            // Ist Spielfeld an der Position leer oder enthält die gleiche Farbe wie der aktuelle Stein? (wird für "Geisterstein" in der Methode Verschiebbar benötigt)
            return (spielfeld[stein.x1, stein.y1] == farbe || spielfeld[stein.x1, stein.y1] == 0) &&
            (spielfeld[stein.x2, stein.y2] == farbe || spielfeld[stein.x2, stein.y2] == 0) &&
            (spielfeld[stein.x3, stein.y3] == farbe || spielfeld[stein.x3, stein.y3] == 0) &&
            (spielfeld[stein.x4, stein.y4] == farbe || spielfeld[stein.x4, stein.y4] == 0);
        }


        /// <summary>
        /// Zeichnet den Stein an seiner aktuellen Position ins Spielfeld ein
        /// </summary>
        /// <param name="stein"></param>
        private void Setzen(Spielstein stein)
        {

            spielfeld[stein.x1, stein.y1] = stein.FarbCode;
            spielfeld[stein.x2, stein.y2] = stein.FarbCode;
            spielfeld[stein.x3, stein.y3] = stein.FarbCode;
            spielfeld[stein.x4, stein.y4] = stein.FarbCode;
        }

        /// <summary>
        /// Löscht den Stein aus dem Spielfeld raus
        /// </summary>
        /// <param name="stein"></param>
        private void Loeschen(Spielstein stein)
        {

            spielfeld[stein.x1, stein.y1] = 0;
            spielfeld[stein.x2, stein.y2] = 0;
            spielfeld[stein.x3, stein.y3] = 0;
            spielfeld[stein.x4, stein.y4] = 0;
        }

        private void Ablegen(Spielstein einSpielstein)
        {
            if (einSpielstein == null)
                return;

            einSpielstein.FarbCode = einSpielstein.FarbCode + 8;
            Setzen(einSpielstein);

            stats.Score += 10;

            // Hier exisistert noch ein Bug bei dem die Zeilen nicht verschwinden wenn größer x2 und mehrere Zeilen abgebaut werden sollen.
            // Lösung: Koordinaten vorher sortieren

            var yKoords = new int[4];
            yKoords[0] = einSpielstein.y1;
            yKoords[1] = einSpielstein.y2;
            yKoords[2] = einSpielstein.y3;
            yKoords[3] = einSpielstein.y4;

            Array.Sort(yKoords);

            foreach (var y in yKoords)
            {
                for (int i = 1; i <= xmax; ++i)
                {

                    if (spielfeld[i, y] == 0)
                    {
                        break;
                    }
                    if (i == xmax) ZeileLöschen(y);
                }
            }

            stats.Score += 100;
            gui.Update(this.spielfeld);
        }


        /// <summary>
        /// Löscht die Zeile an der y-Position und schiebt die darüber liegenden Zeilen um eins nach unten. Die oberste Zeile wird mit Null aufgefüllt
        /// </summary>
        /// <param name="y"></param>
        private void ZeileLöschen(int y)
        {
            for (int j = y; j >= 1; j--)
            {
                for (int i = 1; i <= xmax; ++i)
                {
                    if (j > 1)
                    {
                        // Kopiert aus der drüberliegenden Zeile in die aktuelle
                        spielfeld[i, j] = spielfeld[i, j - 1];

                    }
                    // Oberste Zeile
                    else if (j == 1) spielfeld[i, j] = 0;
                }

            }
        }
    }
}
