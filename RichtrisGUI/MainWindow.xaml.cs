using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RichtrisObjects;

namespace RichtrisGUI
{
    public partial class MainWindow : Window, ITetrisMain
    {
        public MainWindow()
        {
            InitializeComponent();

            this.KeyDown += new KeyEventHandler(OnCanvasKeyDown);
            dasSpielfeld = new Spielfeld(this, new CetrisStatistik());
            SpielfeldCanvas = MyGrid;
            dasSpielfeld.StarteSpiel();
        }

        private void Button_NewGame(object sender, RoutedEventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            dasSpielfeld.StarteSpiel();
        }
        private void Button_SoftDrop(object sender, RoutedEventArgs e)
        {
            Fallen();
        }

        private void Button_Left(object sender, RoutedEventArgs e)
        {
            Links();
        }

        private void Button_Right(object sender, RoutedEventArgs e)
        {
            Rechts();
        }

        private void Button_Rotate(object sender, RoutedEventArgs e)
        {
            Drehen();
        }

        private void Button_HardDrop(object sender, RoutedEventArgs e)
        {
            HardDrop();
        }

        private void Button_Up(object sender, RoutedEventArgs e)
        {
            Hoch();
        }

        private void Button_Musik(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri(@"C:\Users\Dark88Dragon\Desktop\Tetris Theme (Dubstep Remix).mp3", UriKind.Relative);
            var player = new MediaPlayer();
            player.Open(uri);
            player.Play();
        }

        private void AddLine(double x1, double y1, double x2, double y2)
        {
            Line = new Line();
            Line.Stroke = System.Windows.Media.Brushes.Tan;
            Line.X1 = x1;
            Line.X2 = x2;
            Line.Y1 = y1;
            Line.Y2 = y2;
            Line.HorizontalAlignment = HorizontalAlignment.Left;
            Line.VerticalAlignment = VerticalAlignment.Center;
            Line.StrokeThickness = 55;
            SpielfeldCanvas.Children.Add(Line);
        }

        private Line Line { get; set; }


        private void OnCanvasKeyDown(object sender, KeyEventArgs e)
        {
            switch(e.Key)
            {
                case Key.N:
                    StartGame();
                    break;
                case Key.Right:
                    Rechts();
                    break;
                case Key.Left:
                    Links();
                    break;
                case Key.Down:
                    Fallen();
                    break;
                case Key.Up:
                    Drehen();
                    break;
                case Key.Space:
                    HardDrop();
                    break;
                case Key.LeftCtrl:
                    Hoch();
                    break;
                case Key.X:
                    FreezeAndNew();
                    break;
            }
        }


        private void Fallen()
        {
            dasSpielfeld.Nach_unten();
        }

        private void Rechts()
        {
            dasSpielfeld.Nach_rechts();
        }

        private void Links()
        {
            dasSpielfeld.Nach_links();
        }

        private void Drehen()
        {
            dasSpielfeld.Drehen();
        }

        private void HardDrop()
        {
            dasSpielfeld.HardDrop();
        }

        private void Hoch()
        {
            dasSpielfeld.Nach_oben();
        }

        private void FreezeAndNew()
        {
            dasSpielfeld.AblegenUndNeu();
        }

        private Canvas SpielfeldCanvas;
           private int kbreite = 22;
           private Spielfeld dasSpielfeld;
	
    private void CodeToColor(){}
    public void paint (){}
	

    public void CreateMap()
    {
        Paint(true);
    }

    private Brush[,] spielfeldBrush;

    private Rectangle[,] spielfeldZeichnung;
    private void Paint(bool create)
    {

        if (create)
        {
            spielfeldZeichnung = new Rectangle[Spielfeld.xmax, Spielfeld.ymax];
            spielfeldBrush = new Brush[Spielfeld.xmax, Spielfeld.ymax];


            /// Grid: rausmachen weil nicht schön?
            //for (int i = 0; i <= Spielfeld.xmax; i++)
            //{
            //    AddLine(i * kbreite, 0, i * kbreite, Spielfeld.ymax * kbreite);
            //}
            //for (int j = 0; j <= Spielfeld.ymax; j++)
            //{
            //    AddLine(0, j * kbreite, Spielfeld.xmax * kbreite, j * kbreite);
            //}

        }
        for (int i = 0; i < Spielfeld.xmax; i++)
        {
            for (int j = 0; j < Spielfeld.ymax; j++)
            {
                Color Farbe = CodeToColor(dasSpielfeld.FeldMatrix[i + 1, j + 1]);

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

        SpielfeldCanvas.Children.Add(kästchen);
        Canvas.SetLeft(kästchen, x * kbreite + 1);
        Canvas.SetTop(kästchen, y * kbreite + 1);

        return kästchen;
    }
	
        private Color CodeToColor(int Farbcode) {
            Color Farbe;
            if (Farbcode > 7) {
            Farbcode = Farbcode - 8;
            }
            switch (Farbcode) {
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

        public void STEIN(Spielstein stein)
        {


        }

        private Dictionary<Spielstein, Rectangle[]> steinMap = new Dictionary<Spielstein, Rectangle[]>();
        public void UpdateZeichnung(Spielstein einSpielstein, bool remove = false)
        {
            if (einSpielstein == null)
                return;

            var farbe = CodeToColor(einSpielstein.farbCode);


            Rectangle[] stein;

            if (steinMap.TryGetValue(einSpielstein, out stein))
            {
                if (remove)
                {
                     Remove(einSpielstein);
                }
                else
                {
                    UpdateSpielstein(einSpielstein, stein);
                }
            }
            else if(!remove)
            {
                stein = new Rectangle[5];

                stein[0] = ZeichneKaestchen(einSpielstein.x1 - 1, einSpielstein.y1 - 1, farbe);
                stein[1] = ZeichneKaestchen(einSpielstein.x2 - 1, einSpielstein.y2 - 1, farbe);
                stein[2] = ZeichneKaestchen(einSpielstein.x3 - 1, einSpielstein.y3 - 1, farbe);
                stein[3] = ZeichneKaestchen(einSpielstein.x4 - 1, einSpielstein.y4 - 1, farbe);
                stein[4] = ZeichneKaestchen(einSpielstein.x5 - 1, einSpielstein.y5 - 1, farbe);
               

                steinMap.Add(einSpielstein, stein);

            }
        }

        private void UpdateSpielstein(Spielstein einSpielstein, Rectangle[] stein)
        {
            if (steinMap.TryGetValue(einSpielstein, out stein))
            {
                var coords = new int[,] {
                    {einSpielstein.x1 - 1, einSpielstein.y1 - 1},
                    {einSpielstein.x2 - 1, einSpielstein.y2 - 1},
                    {einSpielstein.x3 - 1, einSpielstein.y3 - 1},
                    {einSpielstein.x4 - 1, einSpielstein.y4 - 1},
                    {einSpielstein.x5 - 1, einSpielstein.y5 - 1},
                };

                var i=0;
                foreach (var kästchen in stein)
                {
                    Canvas.SetLeft(kästchen, coords[i,0] * kbreite + 1);
                    Canvas.SetTop(kästchen, coords[i, 1] * kbreite + 1);
                        i++;
                }
            
            }

        }

        public void Update(Spielfeld spielfeld, bool remove = false)
        {
            this.Dispatcher.Invoke((Action<Spielstein, bool>)UpdateZeichnung, dasSpielfeld.aktSpielstein, remove);
            // UpdateZeichnung(dasSpielfeld.aktSpielstein, remove);
            this.Dispatcher.Invoke((Action<bool>)Paint,false);
        }

        public void ResetView()
        {
            spielfeldBrush = null;
            spielfeldZeichnung = null;
            steinMap = new Dictionary<Spielstein, Rectangle[]>();
            RemoveInGameMessage();
            Paint(true);
        }
        public void Remove(Spielstein spielstein)
        {
                foreach(var kästchen in steinMap[spielstein])
                {
                    SpielfeldCanvas.Children.Remove(kästchen);
                }
                steinMap.Remove(spielstein);
            
        }

        public void GameOver()
        {
            this.Dispatcher.Invoke((Action<double, double, string, Color>)Text, 50, 30, "Game Over", Colors.Black);
           // MessageBoxResult result = MessageBox.Show("Nochmal?", "GameOver.", MessageBoxButton.YesNo, MessageBoxImage.Question);
           // if (result == MessageBoxResult.No)
          //  {
     //           Application.Current.Shutdown();
         //   }
        }

        private TextBlock inGameMessage;
        private void Text (double x, double y, string text, Color color) 
            {
                if(inGameMessage != null)
                {
                    RemoveInGameMessage();
                }
                inGameMessage = new TextBlock();
                inGameMessage.Text = text;
                inGameMessage.Background = new SolidColorBrush(Colors.MistyRose);
                inGameMessage.Foreground = new SolidColorBrush(color);
                inGameMessage.FontSize = 25;
                inGameMessage.FontWeight = FontWeights.ExtraBold;
                Canvas.SetLeft(inGameMessage, x);
                Canvas.SetTop(inGameMessage, y);
                Canvas.SetZIndex(inGameMessage, 10);
                SpielfeldCanvas.Children.Add(inGameMessage);
                
            }

        private void RemoveInGameMessage()
        {
            if (SpielfeldCanvas.Children.Contains(inGameMessage))
            {
                SpielfeldCanvas.Children.Remove(inGameMessage);
            }

            inGameMessage = null;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
