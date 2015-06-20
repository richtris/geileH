package Jonasbrother;

public class biohumandigital implements Runnable {

	private String name;
	
	public biohumandigital(String name){
		this.name = name;
		
		
	}
	
	
	
	@Override
	public void run() {
		
		int i = 0;
		while (true){
			
			 try{
			 Thread.sleep(1000);}
			 
			 catch (InterruptedException bitsch ){}
			
			System.out.println(name+":   Abrakadabra-Simsalabim  "+i++);
		}
		
	}
	
	

}
