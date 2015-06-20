package view;
import java.awt.*;
import gameplay.Spielfeld;
import gameplay.Spielstein;

public class SpielfeldCanvas extends Canvas {
	
	private int kbreite = 15;
	private Spielfeld dasSpielfeld;
	
	public SpielfeldCanvas(){}
	private void CodeToColor(){};
	public void paint (){};
	
	public SpielfeldCanvas(Spielfeld einSpielfeld) {
		dasSpielfeld = einSpielfeld;
		dasSpielfeld.einSpielfeldCanvas = this;
		}
	
	public Dimension getPreferredSize()
	{
		return new Dimension(241,451);	
	}
	
	public void paint(Graphics g) {
		
		
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
