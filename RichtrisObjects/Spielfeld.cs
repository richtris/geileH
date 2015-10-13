


namespace RichtrisObjects{

public class Spielfeld {

	public readonly int xmax = 16;
	public readonly int ymax = 30;
	public  int[,] feld = new int[xmax + 2, ymax + 2];
	public int punkte;
	public Spielstein aktSpielstein; 
		
	
	public Spielfeld(){
		
		for(int i=0;i<xmax+2;i++){
			
			for (int j=0;j<ymax+2;j++){
				
			if(i==0 || j==0 || i==xmax+1 || j == ymax+1 ){
				feld[i][j] = -1;
			}
			else
				feld[i][j] = 0;
			}
		}
		
	}
	
	private void loeschen(Spielstein stein){
	
		feld[stein.x1][stein.y1] = 0;
		feld[stein.x2][stein.y2] = 0;
		feld[stein.x3][stein.y3] = 0;
		feld[stein.x4][stein.y4] = 0;
	
		
	}
	private void setzen (Spielstein stein){
		
		feld[stein.x1][stein.y1] = stein.farbCode;
		feld[stein.x2][stein.y2] = stein.farbCode;
		feld[stein.x3][stein.y3] = stein.farbCode;
		feld[stein.x4][stein.y4] = stein.farbCode;
		
	
	}
	
	private void verschieben (Spielstein einSpielstein, int x, int y){
		
		loeschen(einSpielstein);
		einSpielstein.verschieben(x, y);
		setzen(einSpielstein);
	}
	
	
	private void ablegen(Spielstein einSpielstein) {
		einSpielstein.farbCode = einSpielstein.farbCode + 8;
		setzen(einSpielstein);
		punkte += 10;
		Console.writeline(punkte);
		for (int i = 0; i <=xmax;++i){
			
		if(feld[i][einSpielstein.y1]==0) break;
		if (i== xmax) zeileLöschen(einSpielstein.y1);
		}
		
		for (int i = 0; i <=xmax;++i){
			
		if(feld[i][einSpielstein.y2]==0) break;
		if (i== xmax) zeileLöschen(einSpielstein.y2);
		}
		
		for (int i = 0; i <=xmax;++i){
			
		if(feld[i][einSpielstein.y3]==0) break;
		if (i== xmax) zeileLöschen(einSpielstein.y3);
		}
		
		for (int i = 0; i <=xmax;++i){
			
		if(feld[i][einSpielstein.y4]==0) break;
		if (i== xmax) zeileLöschen(einSpielstein.y4);
		}
		
		
		
		}
	private void zeileLöschen (int y){
		
		
		for ( int j = y; j >= 1; j--){
			
			for (int i = 0; i <=xmax;++i){
				if (j > 1)
				{
					int color1 = feld[i][j];
					int color2 = feld[i][j]=feld[i][j-1];
					
				} 
				else if (j == 1) feld[i][j]=0;
				}
			
		}
		punkte += 400;
		Console.WriteLine(punkte);
	}
	
	private bool verschiebbar (Spielstein einSpielstein, int x, int y){
		
		Spielstein verschobenerSpielstein = einSpielstein.Kopie();
		verschobenerSpielstein.verschieben(x, y);
		return setzbar(verschobenerSpielstein);
		
	}
	
	private bool drehbar(Spielstein einSpielstein){
		
		Spielstein verschobenerSpielstein = einSpielstein.Kopie();
		verschobenerSpielstein.drehen();
		return setzbar(verschobenerSpielstein);
		
	}
	
	private void drehen(Spielstein stein)
	{
		loeschen(stein);
		stein.drehen();
		setzen(stein);
	}
	
	private bool setzbar(Spielstein s) {
		int f = aktSpielstein.farbCode;
		return (feld[s.x1][s.y1] == f || feld[s.x1][s.y1] == 0) &&
		(feld[s.x2][s.y2] == f || feld[s.x2][s.y2] == 0) &&
		(feld[s.x3][s.y3] == f || feld[s.x3][s.y3] == 0) &&
		(feld[s.x4][s.y4] == f || feld[s.x4][s.y4] == 0); }
	
	
	private void neuerSpielstein(){
		
		aktSpielstein = new Spielstein((int)(Math.random()*8));
	}
	
	public void nach_unten() {
		if (verschiebbar(aktSpielstein, 0, 1)) {
		verschieben(aktSpielstein, 0, 1);
		}
		else 
			{ ablegen(aktSpielstein);
				neuerStein();
			}
	}
		
	public void hardDrop(){		
		bool dropped = false;
		do
		{
		if (verschiebbar(aktSpielstein, 0, 1)) {
		verschieben(aktSpielstein, 0, 1);
		}
		else 
			{ ablegen(aktSpielstein);
				dropped = true;
				neuerStein();
			}
		} while(!dropped);
		}
	public void nach_links(){
		if (verschiebbar(aktSpielstein, -1,0)) {
			verschieben(aktSpielstein, -1, 0);
			}	
		
	}
	public void nach_rechts(){
		if (verschiebbar(aktSpielstein, 1,0)) {
			verschieben(aktSpielstein, 1, 0);
			}		
	}
	public void drehen(){
		
		if (drehbar(aktSpielstein)) {
				drehen(aktSpielstein);
			}	
		
	}
	public void neuerStein(){
		
		neuerSpielstein();
	}

	
	
	
	
	
}
}