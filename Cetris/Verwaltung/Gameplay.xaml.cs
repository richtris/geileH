using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Cetris.Spiellogik;
using Cetris.Statistik;

namespace Cetris.Verwaltung
{
	public partial class Gameplay : UserControl, ISwitchable, IPaint
	{
        private int kbreite = 22;
        Spielfeld spielfeldlogik;
        Canvas spielfeldZeichenfläche;

		public Gameplay()
		{
            InitializeComponent();

            spielfeldlogik = new Spielfeld(this, new StatistikManager());
            spielfeldZeichenfläche = gui;
            spielfeldlogik.NeuesSpiel(Spieltyp.A);
		}

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var window = Window.GetWindow(this);
            window.KeyDown += OnCanvasKeyDown;
        }

        #region ISwitchable Members
        public void UtilizeState(object state)
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
        	Switcher.Switch(new MainMenu());
        }
        #endregion


        private Brush[,] spielfeldBrush;

        private Rectangle[,] spielfeldZeichnung;
        private void Paint(bool create, int[,] spielfelddaten)
        {
            if (create)
            {
                if (spielfeldZeichnung != null)
                {
                    for (int i = 0; i < Spielfeld.xmax; i++)
                    {
                        for (int j = 0; j < Spielfeld.ymax; j++)
                        {
                            if (spielfeldZeichnung[i, j] != null)
                            {
                                spielfeldZeichenfläche.Children.Remove(spielfeldZeichnung[i, j]);
                                spielfeldZeichnung[i, j] = null;
                            }
                            if (spielfeldBrush[i, j] != null)
                            {
                                spielfeldBrush[i, j] = null;
                            }
                        }
                    }
                }

                spielfeldZeichnung = new Rectangle[Spielfeld.xmax, Spielfeld.ymax];
                spielfeldBrush = new Brush[Spielfeld.xmax, Spielfeld.ymax];
            }

            for (int i = 0; i < Spielfeld.xmax; i++)
            {
                for (int j = 0; j < Spielfeld.ymax; j++)
                {
                    Color Farbe = CodeToColor(spielfelddaten[i + 1, j + 1]);

                    if (create)
                    {
                        var kaestchen = spielfeldZeichnung[i, j] = ZeichneKaestchen(i, j, Farbe);
                        spielfeldBrush[i, j] = kaestchen.Fill;
                    }
                    else
                    {
                        var brush = (SolidColorBrush)spielfeldBrush[i, j];
                        brush.Color = Farbe;

                    }
                }
            }

        }
        private Rectangle ZeichneKaestchen(int x, int y, Color farbe)
        {
            Rectangle kästchen = new Rectangle();

            // -1 wieder rein wenn Abstand gewünscht
            kästchen.Height = kbreite /*- 1*/;
            kästchen.Width = kbreite /*- 1*/;

            SolidColorBrush fillBrush = new SolidColorBrush();
            fillBrush.Color = farbe;
            kästchen.Fill = fillBrush;

            SolidColorBrush strokeBrush = new SolidColorBrush();
            strokeBrush.Color = Colors.DarkSlateGray;
            kästchen.StrokeThickness = 1.11;
            kästchen.Stroke = strokeBrush;

            kästchen.RadiusX = 3;
            kästchen.RadiusY = 3;

            spielfeldZeichenfläche.Children.Add(kästchen);
            Canvas.SetLeft(kästchen, x * kbreite + 1);
            Canvas.SetTop(kästchen, y * kbreite + 1);

            return kästchen;
        }

        private Color CodeToColor(int Farbcode)
        {
            Color Farbe;
            if (Farbcode > 7)
            {
                Farbcode = Farbcode - 8;
            }
            switch (Farbcode)
            {
                case 0: Farbe = Colors.LightSkyBlue;
                    break;
                case 1: Farbe = Color.FromRgb(230, 10, 0);
                    break;
                case 2: Farbe = Color.FromRgb(255, 235, 0);
                    break;
                case 3: Farbe = Color.FromRgb(10, 170, 10);
                    break;
                case 4: Farbe = Colors.DarkSlateBlue;
                    break;
                case 5: Farbe = Color.FromRgb(255, 250, 210);
                    break;
                case 6: Farbe = Color.FromRgb(210, 50, 130);
                    break;
                case 7: Farbe = Colors.Orange;
                    break;
                case 8: Farbe = Colors.White;
                    break;

                default: Farbe = Colors.Red;
                    break;
            }
            return Farbe;
        }

        private void Button_NewGame(object sender, RoutedEventArgs e)
        {
        }

        private void OnCanvasKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Down:
                    spielfeldlogik.Runter();
                    break;
            }
        }

        public void Create(int[,] spielfelddaten)
        {
            Paint(true, spielfelddaten);
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Update(int[,] spielfelddaten)
        {
            Paint(false, spielfelddaten);
        }

        public void GameOver()
        {
            throw new NotImplementedException();
        }

        public void preview(Spielstein stein)
        {
            throw new NotImplementedException();
        }
    }
}