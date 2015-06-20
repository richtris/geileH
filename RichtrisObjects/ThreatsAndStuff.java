package Jonasbrother;

import static org.junit.Assert.*;

import org.junit.Test;

public class ThreatsAndStuff {

	@Test
	public void test() {
		
		Thread Gefahr = new Thread(new biohumandigital("Jabba da Hut"));
		Gefahr.start();
		
		Thread Gefahr2 = new Thread (new biohumandigital("Hitler"));
		Gefahr2.start();
		
		 try{
			 Thread.sleep(10000);}
			 
			 catch (InterruptedException bitsch ){}
			
		 
		assertTrue(true);
		assertFalse(false);
		
	}
	
	@Test	
public void test2(){
	
	assertTrue(true);
}
}
