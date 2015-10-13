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
            // Add a Line Element
            Line = new Line();
            Line.Stroke = System.Windows.Media.Brushes.LightSteelBlue;
            Line.X1 = 1;
            Line.X2 = 50;
            Line.Y1 = 1;
            Line.Y2 = 50;
            Line.HorizontalAlignment = HorizontalAlignment.Left;
            Line.VerticalAlignment = VerticalAlignment.Center;
            Line.StrokeThickness = 2;
            GameGrid = MyGrid;
            GameGrid.Children.Add(Line);

        }

        private Line Line { get; set; }

        private void Button_Clicked(object sender, RoutedEventArgs e)
        {
            //FrameworkElement fe = sender as FrameworkElement;
            //((YourClass)fe.DataContext).DoYourCommand();
            Line.X2 += 5;
        }
        private Grid GameGrid;
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
	
    public void Paint() {
		
		
        g.setColor(Color.red);
        g.drawString("TETRIS 4 EVER!", 10, 100);
		
        for (int i = 0; i <= dasSpielfeld.xmax; i++) {
            g.drawLine(i * kbreite, 0, i * kbreite, dasSpielfeld.ymax * kbreite);
        }
        for (int j = 0; j <= dasSpielfeld.ymax; j++) {
            g.drawLine(0, j * kbreite, dasSpielfeld.xmax * kbreite, j * kbreite);
        }
        for (int i = 0; i < dasSpielfeld.xmax; i++ ) {
            for (int j = 0; j < dasSpielfeld.ymax; j++ ) {
                Color Farbe = CodeToColor(dasSpielfeld.feld[i + 1][j + 1]);
                g.setColor(Farbe);
                zeichneKaestchen(g, i, j);
            }
        }
    }
        private void zeichneKaestchen(Graphics g, int x, int y) {
        g.fillRect(x * kbreite + 1, y * kbreite + 1, kbreite - 1, kbreite - 1);
        }
	
        private Color CodeToColor(int Farbcode) {
            Color Farbe;
            if (Farbcode > 7) {
            Farbcode = Farbcode - 8;
            }
            switch (Farbcode) {
            case 0: Farbe = Color.black;
            break;
            case 1: Farbe = new Color(230, 10, 0);
            break;
            case 2: Farbe = new Color(255, 235, 0);
            break;
            case 3: Farbe = new Color(10, 170, 10);
            break;
            case 4: Farbe = new Color(20, 140, 180);
            break;
            case 5: Farbe = new Color(255, 250, 210);
            break;
            case 6: Farbe = new Color(210, 50, 130);
            break;
            case 7: Farbe = Color.orange;
            break;
            default:
            Farbe = Color.red;
            }
            return Farbe;
            }
	
	
        public void zeichneSpielstein(Spielstein einSpielstein, int Farbcode) {
            Graphics g = getGraphics();
            g.setColor(CodeToColor(Farbcode));
	
            zeichneKaestchen(g, einSpielstein.x1 - 1, einSpielstein.y1 - 1);
            zeichneKaestchen(g, einSpielstein.x2 - 1, einSpielstein.y2 - 1);
            zeichneKaestchen(g, einSpielstein.x3 - 1, einSpielstein.y3 - 1);
            zeichneKaestchen(g, einSpielstein.x4 - 1, einSpielstein.y4 - 1);
            }
	
    }
}
