


using System;
using System.Collections;
using System.Timers;

namespace RichtrisObjects
{

    public class Spielfeld : ISpielfeld
    {

        public static readonly int xmax = 10;
        public static readonly int ymax = 20;
        private int[,] feld = new int[xmax + 2, ymax + 2];
        public int[,] FeldMatrix { get { return feld; } }

        public int punkte;
        public Spielstein aktSpielstein;
        private Random random = new Random();
        private ITetrisMain mainApp;
        private IStatistik stats;

        private LevelManager levelManager;

        public enum GameStates
        {
           New, Running, GameOver
        }

        public GameStates State { get; private set; }
        public Spielfeld(ITetrisMain mainApp, IStatistik stats)
        {
            this.mainApp = mainApp;
            this.stats = stats;
            this.levelManager = new LevelManager(this);
            this.State = GameStates.New;
        }

        private void InitSpielfeld()
        {
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

        public void StarteSpiel()
        {
            if (!(State == GameStates.New))
            {
                ResetSpiel();
            }
            InitSpielfeld();
            mainApp.CreateMap();
            NeuerSpielstein();
            levelManager.Start();
            mainApp.Update(this, false);
            State = GameStates.Running;

        }

        public void ResetSpiel()
        {
            levelManager.Reset();
            aktSpielstein = null;
            mainApp.ResetView();
        }

        private void GameOver()
        {
            State = GameStates.GameOver;
            levelManager.Stop();
            mainApp.GameOver();
        }

        private void NeuerSpielstein()
        {
            var randomInt = random.Next(1, 8);
            var neuerStein = new Spielstein((int)(randomInt));
            if (Setzbar(neuerStein))
            {
                aktSpielstein = neuerStein;
                
                if(Verschiebbar(aktSpielstein,0,1) || Verschiebbar(aktSpielstein,1,0) || Verschiebbar(aktSpielstein,-1,0))
                {
                    return;
                }
                else
                {
                    Setzen(aktSpielstein);
                }
            }
            aktSpielstein = null;
            GameOver();
        }

        public void OnGravity(Object source, System.Timers.ElapsedEventArgs e)
        {
              this.Nach_unten();
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
            if (einSpielstein == null)
                return;

            einSpielstein.farbCode = einSpielstein.farbCode + 8;
            Setzen(einSpielstein);
            mainApp.Update(this,true);

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

            stats.Punkte += 100;
        //    mainApp.Update(this);

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
            levelManager.LinesCleared(1);
           // Console.WriteLine(punkte);
           // mainApp.Update(this);
        }

        private bool Verschiebbar(Spielstein einSpielstein, int x, int y)
        {
            if (einSpielstein == null)
                return false;

            Spielstein verschobenerSpielstein = einSpielstein.Kopie();
            verschobenerSpielstein.Verschieben(x, y);
            return Setzbar(verschobenerSpielstein);

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

        private bool Setzbar(Spielstein s)
        {
            int f = s.farbCode;
            return (feld[s.x1, s.y1] == f || feld[s.x1, s.y1] == 0) &&
            (feld[s.x2, s.y2] == f || feld[s.x2, s.y2] == 0) &&
            (feld[s.x3, s.y3] == f || feld[s.x3, s.y3] == 0) &&
            (feld[s.x4, s.y4] == f || feld[s.x4, s.y4] == 0);
        }


        public void Nach_unten()
        {
            if (Verschiebbar(aktSpielstein, 0, 1))
            {
                Verschieben(aktSpielstein, 0, 1);
                mainApp.Update(this);
            }
            else
            {
                Ablegen(aktSpielstein);
                if (State == GameStates.Running)
                {
                    NeuerStein();
                }
            }
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