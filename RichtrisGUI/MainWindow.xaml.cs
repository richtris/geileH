using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Cannevas = MyGrid;
            AddLine(1, 50, 1, 50);
            Paint();
        }

        private void AddLine(double x1, double y1, double x2, double y2)
        {
            // Add a Line Element
            Line = new Line();
            Line.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            Line.X1 = x1;
            Line.X2 = x2;
            Line.Y1 = y1;
            Line.Y2 = y2;
            Line.HorizontalAlignment = HorizontalAlignment.Left;
            Line.VerticalAlignment = VerticalAlignment.Center;
            Line.StrokeThickness = 2;
            Cannevas.Children.Add(Line);
        }

        private Line Line { get; set; }

        private void Button_Clicked(object sender, RoutedEventArgs e)
        {
            //FrameworkElement fe = sender as FrameworkElement;
            //((YourClass)fe.DataContext).DoYourCommand();
            Line.X2 += 5;
        }
        private Canvas Cannevas;
           private int kbreite = 15;
    private Spielfeld dasSpielfeld = new Spielfeld();
	
   // public SpielfeldCanvas(){}
    private void CodeToColor(){}
    public void paint (){}
	
    //public SpielfeldCanvas(Spielfeld einSpielfeld) {
    //    dasSpielfeld = einSpielfeld;
    //    dasSpielfeld.einSpielfeldCanvas = this;
    //    }
	
    //public Dimension getPreferredSize()
    //{
    //    return new Dimension(241,451);	
    //}

    public void Paint()
    {


     //   g.setColor(Color.red);
     //   g.drawString("TETRIS 4 EVER!", 10, 100);

        for (int i = 0; i <= Spielfeld.xmax; i++)
        {
            AddLine(i * kbreite, 0, i * kbreite, Spielfeld.ymax * kbreite);
        }
        for (int j = 0; j <= Spielfeld.ymax; j++)
        {
            AddLine(0, j * kbreite, Spielfeld.xmax * kbreite, j * kbreite);
        }
        for (int i = 0; i < Spielfeld.xmax; i++)
        {
            for (int j = 0; j < Spielfeld.ymax; j++)
            {
                Color Farbe = CodeToColor(dasSpielfeld.feld[i + 1,j + 1]);
                //g.setColor(Farbe);
                ZeichneKaestchen(i, j);
            }
        }
    }
    private void ZeichneKaestchen(int x, int y)
    {
        //g.fillRect(x * kbreite + 1, y * kbreite + 1, kbreite - 1, kbreite - 1);
        // Create a Rectangle

        Rectangle kästchen = new Rectangle();

        kästchen.Height = kbreite - 1;
        kästchen.Width = kbreite - 1;



        // Create a blue and a black Brush

        SolidColorBrush blueBrush = new SolidColorBrush();
        blueBrush.Color = Colors.Blue;

        SolidColorBrush blackBrush = new SolidColorBrush();
        blackBrush.Color = Colors.Black;



        // Set Rectangle's width and color

        kästchen.StrokeThickness = 1;
        kästchen.Stroke = blackBrush;

        // Fill rectangle with blue color
        kästchen.Fill = blueBrush;



        // Add Rectangle to the Grid.
        Cannevas.Children.Add(kästchen);
        Canvas.SetLeft(kästchen, x * kbreite + 1);
        Canvas.SetTop(kästchen, y * kbreite + 1);
    }
	
        private Color CodeToColor(int Farbcode) {
            Color Farbe;
            if (Farbcode > 7) {
            Farbcode = Farbcode - 8;
            }
            switch (Farbcode) {
            case 0: Farbe = Colors.Black;
            break;
            case 1: Farbe = Color.FromRgb(230, 10, 0);
            break;
            case 2: Farbe = Color.FromRgb(255, 235, 0);
            break;
            case 3: Farbe = Color.FromRgb(10, 170, 10);
            break;
            case 4: Farbe = Color.FromRgb(20, 140, 180);
            break;
            case 5: Farbe = Color.FromRgb(255, 250, 210);
            break;
            case 6: Farbe = Color.FromRgb(210, 50, 130);
            break;
            case 7: Farbe = Colors.Orange;
            break;
            default: Farbe = Colors.Red;
            break;
            }
            return Farbe;
            }
	
	
        public void zeichneSpielstein(Spielstein einSpielstein, int Farbcode) {
            //Graphics g = getGraphics();
            // g.setColor(CodeToColor(Farbcode));

            ZeichneKaestchen(einSpielstein.x1 - 1, einSpielstein.y1 - 1);
            ZeichneKaestchen(einSpielstein.x2 - 1, einSpielstein.y2 - 1);
            ZeichneKaestchen(einSpielstein.x3 - 1, einSpielstein.y3 - 1);
            ZeichneKaestchen(einSpielstein.x4 - 1, einSpielstein.y4 - 1);
            }
	
    }
}
