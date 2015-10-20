//////import gameplay.Spielfeld;
//////import javax.swing.JFrame;
//////import javax.swing.JButton;
//////import javax.swing.JLabel;
//////import java.awt.event.ActionEvent;
//////import java.awt.event.ActionListener;
//////import java.awt.Canvas;
//////import java.awt.Color;
//////import java.awt.GridLayout;
//////import java.awt.event.KeyAdapter;
//////import java.awt.event.KeyListener;
//////import java.awt.event.KeyEvent;
//////import javax.swing.Timer;

//namespace RichtrisObjects{
//public class Tetris /*extends JFrame*/ {
	
//    private Spielfeld einSpielfeld = new Spielfeld();
//    private SpielfeldCanvas einSpielfeldCanvas = new SpielfeldCanvas(einSpielfeld);
//    //private JButton JBstart;
//    //private JButton JBanhalten;
//    //private JButton JBbeenden;
//    //private JButton JLPunkte;
//    //private JButton JBunten;
//    //private JButton JBlinks;
//    //private JButton JBrechts;
//    //private JButton JBdrehen;
//    //private JButton JBfallen;
//    //private JLabel JLStein;
	
//    private int Tempo = 500;
//    private Timer einTimer;
	
//    public Tetris(){
		
		
		
		
//        JFrame frm = this;
//        frm.setTitle("Richtris");

//        frm.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
//        frm.setLayout(new GridLayout(1,1));
	
//        //einSpielfeld.neuerStein();
		
//        JBlinks = new JButton("Links");
//        JBlinks.addActionListener(new ActionListener() { 
//              public void actionPerformed(ActionEvent e) { 
//                  JBlinksActionPerformed();
//                  } 
//                } );
		
//        JBunten = new JButton("Unten");
//        JBunten.addActionListener(new ActionListener() { 
//              public void actionPerformed(ActionEvent e) { 
//                  jBUntenActionPerformed();
//                  } 
//                } );
//        JBrechts = new JButton("Rechts");
//        JBrechts.addActionListener(new ActionListener() { 
//              public void actionPerformed(ActionEvent e) { 
//                  JBrechtsActionPerformed();
//                  } 
//                } );
//        JBdrehen = new JButton("Drehen");
//        JBdrehen.addActionListener(new ActionListener() { 
//              public void actionPerformed(ActionEvent e) { 
//                  JBdrehenActionPerformed();
//                  } 
//                } );
		
//        JBstart = new JButton("Start");
//        JBstart.addActionListener(new ActionListener() { 
//              public void actionPerformed(ActionEvent e) { 
//                  jBStartenActionPerformed();
//                  } 
//                } );
		
//        JBanhalten = new JButton("Pause");
//        JBanhalten.addActionListener(new ActionListener() { 
//              public void actionPerformed(ActionEvent e) { 
//                  JBanhaltenActionPerformed();
//                  } 
//                } );
		
//        JBbeenden = new JButton("Beenden");
//        JBbeenden.addActionListener(new ActionListener() { 
//              public void actionPerformed(ActionEvent e) { 
//                  JBbeendenActionPerformed();
//                  } 
//                } );
		
			
//        einSpielfeldCanvas.addKeyListener(new KeyAdapter() {
//            public void keyPressed(KeyEvent event) {
//                int key = event.getKeyCode();
//            if (key == KeyEvent.VK_S) einSpielfeld.neuerStein();
//            if (key == KeyEvent.VK_LEFT) einSpielfeld.nach_links();
//            if (key == KeyEvent.VK_RIGHT) einSpielfeld.nach_rechts();
//            if (key == KeyEvent.VK_DOWN) einSpielfeld.nach_unten();
//            if (key == KeyEvent.VK_UP) einSpielfeld.drehen();
//            if (key == KeyEvent.VK_SPACE) einSpielfeld.hardDrop();
//            einSpielfeldCanvas.repaint();
//            }
//            });
		
//        ActionListener Fallen = new ActionListener () {
//            public void actionPerformed(ActionEvent evt){
//            einSpielfeld.nach_unten();
//            einSpielfeldCanvas.repaint();
//            //JLPunkte.setText("Punkte: " + einSpielfeld.punkte);
//                        }
//            };
		
//            einTimer = new Timer(Tempo, Fallen);
			
//        frm.add(einSpielfeldCanvas);
//        frm.add(JBstart);
//        frm.add(JBanhalten);
//        //frm.add(JBlinks);
//        //frm.add(JBunten);
//        //frm.add(JBrechts);
//        //frm.add(JBdrehen);
	
//        frm.setSize(800,600);
//        frm.setLocation(50,50);
//        setResizable(false);
//        setVisible(true);
//        einSpielfeldCanvas.requestFocusInWindow(); // richtige Position
//        }
	
//    public void jBStartenActionPerformed() {
//        einSpielfeld.neuerStein();
//        einSpielfeldCanvas.requestFocusInWindow();
//        einTimer.start();
//        }
	
	
//    public void JBanhaltenActionPerformed(){
//        einTimer.stop();
		
//    };
//    public void JBbeendenActionPerformed(){};
//    public void jBUntenActionPerformed() {
//            einSpielfeld.nach_unten();
//            einSpielfeldCanvas.repaint();
//            einSpielfeldCanvas.requestFocusInWindow();
//    }
		
		
	
//    public void JBlinksActionPerformed(){
//        einSpielfeld.nach_links();
//        einSpielfeldCanvas.repaint();
//        einSpielfeldCanvas.requestFocusInWindow();
		
//    };
//    public void JBrechtsActionPerformed(){
//        einSpielfeld.nach_rechts();
//        einSpielfeldCanvas.repaint();
//        einSpielfeldCanvas.requestFocusInWindow();
//    };
//    public void JBdrehenActionPerformed(){
//        einSpielfeld.drehen();
//        einSpielfeldCanvas.repaint();
//        einSpielfeldCanvas.requestFocusInWindow();
//    };
//    public void JBfallenActionPerformed(){};
//    public void JBSteinActionPerformed(){};
	

//    public static void main(String[] args)
//    {
//        Tetris tetris = new Tetris();
		
//    }

//}
