

using System;
namespace RichtrisObjects{

public class Spielstein {

	public int farbCode;
	public int x1;
	public int y1;
	public int x2;
	public int y2;
	public int x3;
	public int y3;
	public int x4;
	public int y4;
    public int x5;
    public int y5;

	
	public Spielstein(int i){
		
		switch(i){
		
	case 1: x1 = 7; y1 = 2; 
		    x2 = 7; y2 = 1;  
			x3 = 7; y3 = 3; 	//Langer
			x4 = 7; y4 = 4; 
			farbCode = 1;
			break;
	
	case 2: x1 = 7; y1 = 1; 
    x2 = 6; y2 = 1;  
	x3 = 8; y3 = 1; 
	x4 = 7; y4 = 2; 		//T-Spin Triple*
	farbCode = 2;
	break;
	
	case 3: x1 = 7; y1 = 1; 
    x2 = 7; y2 = 2;  
	x3 = 8; y3 = 1; 
	x4 = 8; y4 = 2;  //Quattro Formaggi
	farbCode = 3;
	break;
	
	case 4: x1 = 7; y1 = 2; 
    x2 = 7; y2 = 1;  
	x3 = 7; y3 = 3; //L
	x4 = 8; y4 = 3; 
	farbCode = 4;
	break;
	
	case 5: x1 = 7; y1 = 2; 
    x2 = 7; y2 = 1;  
	x3 = 7; y3 = 3; //J
	x4 = 6; y4 = 3; 
	farbCode = 5;
	break;
	
	case 6: x1 = 7; y1 = 2; 
    x2 = 7; y2 = 1;  
	x3 = 8; y3 = 1; //S
	x4 = 6; y4 = 2; 
	farbCode = 6;
	break;
	
	case 7: x1 = 7; y1 = 2; 
    x2 = 6; y2 = 1;  
	x3 = 7; y3 = 1; //Z
	x4 = 8; y4 = 2; 
	farbCode = 7;
	break;
			
		}}
	
	public void Verschieben(int x, int y){
		
		x1 = x1 + x;
		x2 = x2 + x;
		x3 = x3 + x;
		x4 = x4 + x;
		
		y1 = y1 + y;
		y2 = y2 + y;
		y3 = y3 + y;
		y4 = y4 + y;
	}
	
	public void Drehen(){
		
		int x,y;
		
		x = XkoordDrehen(y2);
		y = YkoordDrehen(x2);
		x2=x;
		y2=y;
		x = XkoordDrehen(y3);
		y = YkoordDrehen(x3);
		x3=x;
		y3=y;
		x = XkoordDrehen(y4);
		y = YkoordDrehen(x4);
		x4=x;
		y4=y;
		
		
			}
	
	private int XkoordDrehen(int y){
		
		return x1 - y1 + y;
	}
	
	private int YkoordDrehen(int x){
		
		return y1 + x1 - x;
	}

	public Spielstein Kopie(){
		
		Spielstein neu = new Spielstein(this.farbCode);
		
		neu.x1 = this.x1;
		neu.y1 = this.y1;
		neu.x2 = this.x2;
		neu.y2 = this.y2;
		neu.x3 = this.x3;
		neu.y3 = this.y3;
		neu.x4 = this.x4;
		neu.y4 = this.y4;
		
		return neu;
		
	}
	
}
}