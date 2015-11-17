


using System;
using System.Collections;
namespace RichtrisObjects
{

    public class Spielfeld
    {

        public static readonly int xmax = 10;
        public static readonly int ymax = 20;
        public int[,] feld = new int[xmax + 2, ymax + 2];
        public int punkte;
        public Spielstein aktSpielstein;
        private Random random = new Random();
        private ITetrisMain mainApp;

        public Spielfeld(ITetrisMain mainApp)
        {
            this.mainApp = mainApp;

            for (int i = 0; i < xmax + 2; i++)
            {

                for (int j = 0; j < ymax + 2; j++)
                {

                    if (i == 0 || j == 0 || i == xmax + 1 || j == ymax + 1)
                    {
                        //Rand mit -1 auffüllen, damit Steine nicht drüber rutschen
                        feld[i, j] = -1;
                    }
                    else
                        // Alles andere Leer
                        feld[i, j] = 0;
                }
            }

        }

        private void Loeschen(Spielstein stein)
        {

            feld[stein.x1, stein.y1] = 0;
            feld[stein.x2, stein.y2] = 0;
            feld[stein.x3, stein.y3] = 0;
            feld[stein.x4, stein.y4] = 0;


        }
        private void Setzen(Spielstein stein)
        {

            feld[stein.x1, stein.y1] = stein.farbCode;
            feld[stein.x2, stein.y2] = stein.farbCode;
            feld[stein.x3, stein.y3] = stein.farbCode;
            feld[stein.x4, stein.y4] = stein.farbCode;


        }

        private void Verschieben(Spielstein einSpielstein, int x, int y)
        {

            Loeschen(einSpielstein);
            einSpielstein.Verschieben(x, y);
            Setzen(einSpielstein);
        }


        private void Ablegen(Spielstein einSpielstein)
        {
            einSpielstein.farbCode = einSpielstein.farbCode + 8;
            Setzen(einSpielstein);

            punkte += 10;
            Console.WriteLine(punkte);
            for (int i = 0; i <= xmax; ++i)
            {

                if (feld[i, einSpielstein.y1] == 0) break;
                if (i == xmax) ZeileLöschen(einSpielstein.y1);
            }

            for (int i = 0; i <= xmax; ++i)
            {

                if (feld[i, einSpielstein.y2] == 0) break;
                if (i == xmax) ZeileLöschen(einSpielstein.y2);
            }

            for (int i = 0; i <= xmax; ++i)
            {

                if (feld[i, einSpielstein.y3] == 0) break;
                if (i == xmax) ZeileLöschen(einSpielstein.y3);
            }

            for (int i = 0; i <= xmax; ++i)
            {

                if (feld[i, einSpielstein.y4] == 0) break;
                if (i == xmax) ZeileLöschen(einSpielstein.y4);
            }


            mainApp.Update(this);

        }
        private void ZeileLöschen(int y)
        {


            for (int j = y; j >= 1; j--)
            {

                for (int i = 0; i <= xmax; ++i)
                {
                    if (j > 1)
                    {
                        int color1 = feld[i, j];
                        int color2 = feld[i, j] = feld[i, j - 1];

                    }
                    else if (j == 1) feld[i, j] = 0;
                }

            }
            punkte += 400;
            Console.WriteLine(punkte);
            mainApp.Update(this);
        }

        private bool Verschiebbar(Spielstein einSpielstein, int x, int y)
        {

            Spielstein verschobenerSpielstein = einSpielstein.Kopie();
            verschobenerSpielstein.Verschieben(x, y);
            return Setzbar(verschobenerSpielstein);

        }

        private bool Drehbar(Spielstein einSpielstein)
        {

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

        private bool Setzbar(Spielstein s)
        {
            int f = aktSpielstein.farbCode;
            return (feld[s.x1, s.y1] == f || feld[s.x1, s.y1] == 0) &&
            (feld[s.x2, s.y2] == f || feld[s.x2, s.y2] == 0) &&
            (feld[s.x3, s.y3] == f || feld[s.x3, s.y3] == 0) &&
            (feld[s.x4, s.y4] == f || feld[s.x4, s.y4] == 0);
        }


        private void NeuerSpielstein()
        {
            var randomInt = random.Next(1, 8);
            aktSpielstein = new Spielstein((int)(randomInt));
        }

        public void Nach_unten()
        {
            if (Verschiebbar(aktSpielstein, 0, 1))
            {
                Verschieben(aktSpielstein, 0, 1);
            }
            else
            {
                Ablegen(aktSpielstein);
                NeuerStein();
            }

            mainApp.Update(this);
        }

        public void AblegenUndNeu()
        {
            Ablegen(aktSpielstein);
            NeuerStein();

            mainApp.Update(this);
        }

        public void HardDrop()
        {
            bool dropped = false;
            do
            {
                if (Verschiebbar(aktSpielstein, 0, 1))
                {
                    Verschieben(aktSpielstein, 0, 1);
                }
                else
                {
                    Ablegen(aktSpielstein);
                    dropped = true;
                    NeuerStein();
                }
            } while (!dropped);
        }
        public void Nach_links()
        {
            if (Verschiebbar(aktSpielstein, -1, 0))
            {
                Verschieben(aktSpielstein, -1, 0);
            }

            mainApp.Update(this);

        }
        public void Nach_rechts()
        {
            if (Verschiebbar(aktSpielstein, 1, 0))
            {
                Verschieben(aktSpielstein, 1, 0);
            }

            mainApp.Update(this);
        }

        public void Nach_oben()
        {
            if (Verschiebbar(aktSpielstein, 0, -1))
            {
                Verschieben(aktSpielstein, 0, -1);
            }

            mainApp.Update(this);
        }
        public void Drehen()
        {

            if (Drehbar(aktSpielstein))
            {
                Drehen(aktSpielstein);
            }

            mainApp.Update(this);

        }
        public void NeuerStein()
        {
            NeuerSpielstein();
            mainApp.Update(this);
        }






    }
}