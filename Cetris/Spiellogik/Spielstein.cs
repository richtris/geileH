namespace Cetris.Spiellogik
{
    public enum Richtung
    {
        Rechts, Links, Unten
    }
    public class Spielstein
    {
        public int FarbCode { get; set; }

        // Dieses Kästchen ist als Drehpunkt festgelegt
        public int x1;
        public int y1;
        
        // Die restlichen 3 Kästchen
        public int x2;
        public int y2;
        public int x3;
        public int y3;
        public int x4;
        public int y4;

        public Spielstein(int i)
        {

            switch (i)
            {

                case 1: x1 = 7; y1 = 2;
                    x2 = 7; y2 = 1;
                    x3 = 7; y3 = 3; 	//Langer
                    x4 = 7; y4 = 4;
                    FarbCode = 1;
                    break;

                case 2: x1 = 7; y1 = 1;
                    x2 = 6; y2 = 1;
                    x3 = 8; y3 = 1;
                    x4 = 7; y4 = 2; 		//T-Spin Triple*
                    FarbCode = 2;
                    break;

                case 3: x1 = 7; y1 = 1;
                    x2 = 7; y2 = 2;
                    x3 = 8; y3 = 1;
                    x4 = 8; y4 = 2;  //Quattro Formaggi
                    FarbCode = 3;
                    break;

                case 4: x1 = 7; y1 = 2;
                    x2 = 7; y2 = 1;
                    x3 = 7; y3 = 3; //L
                    x4 = 8; y4 = 3;
                    FarbCode = 4;
                    break;

                case 5: x1 = 7; y1 = 2;
                    x2 = 7; y2 = 1;
                    x3 = 7; y3 = 3; //J
                    x4 = 6; y4 = 3;
                    FarbCode = 5;
                    break;

                case 6: x1 = 7; y1 = 2;
                    x2 = 7; y2 = 1;
                    x3 = 8; y3 = 1; //S
                    x4 = 6; y4 = 2;
                    FarbCode = 6;
                    break;

                case 7: x1 = 7; y1 = 2;
                    x2 = 6; y2 = 1;
                    x3 = 7; y3 = 1; //Z
                    x4 = 8; y4 = 2;
                    FarbCode = 7;
                    break;
            }
        }

        /// <summary>
        /// Verändert die Koordinaten des Spielsteins um den angegebenen x bzw. y-Wert
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void Verschieben(Richtung richtung)
        {
            int x = 0, y = 0;

            switch(richtung)
            {
                case Richtung.Rechts:
                    x = 1;
                    break;
                case Richtung.Links:
                    x = -1;
                    break;
                case Richtung.Unten:
                    y = 1;
                    break;
            }

            // X-Verschiebung der Kästchen
            x1 = x1 + x;
            x2 = x2 + x;
            x3 = x3 + x;
            x4 = x4 + x;

            // Y-Verschiebung der Kästchen
            y1 = y1 + y;
            y2 = y2 + y;
            y3 = y3 + y;
            y4 = y4 + y;
        }

        /// <summary>
        /// Dreht den Stein um den im Konstruktor festgelegten Drehpunkt (x1,y1)
        /// Geometrische Grundlage:
        /// Drehen eines Punktes um einen anderen Punkt im 2D-Raum
        /// http://www.matheboard.de/archive/460078/thread.html
        /// </summary>
        public void Drehen()
        {
            int x, y;

            // Kästchen 2
            x = XkoordDrehen(y2);
            y = YkoordDrehen(x2);
            x2 = x;
            y2 = y;

            // Kästchen 3
            x = XkoordDrehen(y3);
            y = YkoordDrehen(x3);
            x3 = x;
            y3 = y;

            // Kästchen 4
            x = XkoordDrehen(y4);
            y = YkoordDrehen(x4);
            x4 = x;
            y4 = y;
        }

        // x und y drehen um den Drehpunkt 

        private int XkoordDrehen(int y)
        {
            return x1 - y1 + y;
        }

        private int YkoordDrehen(int x)
        {
            return y1 + x1 - x;
        }

        /// <summary>
        /// Erzeugt eine exakte Kopie dieses Spielsteins.
        /// Damit können im Spielfeld Bewegungen des Steins getestet werden, ohne den
        /// ursprünglichen Stein zu verändern (Quasi eine Sicherungskopie / Geisterstein) 
        /// </summary>
        /// <returns></returns>
        public Spielstein Kopie()
        {

            Spielstein neuerSpielstein = new Spielstein(this.FarbCode);

            neuerSpielstein.x1 = this.x1;
            neuerSpielstein.y1 = this.y1;
            neuerSpielstein.x2 = this.x2;
            neuerSpielstein.y2 = this.y2;
            neuerSpielstein.x3 = this.x3;
            neuerSpielstein.y3 = this.y3;
            neuerSpielstein.x4 = this.x4;
            neuerSpielstein.y4 = this.y4;

            return neuerSpielstein;

        }
    }
}
