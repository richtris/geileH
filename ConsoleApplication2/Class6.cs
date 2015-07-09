using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Patterns
{
    public class UnitTestPreise
    {

        private Preisliste preisliste = new Preisliste();
        private PreisBeobachter beobachter1;
        private PreisBeobachter beobachter2;

     
        public void TestPreisliste()
        {
            preisliste.SetPreis("Apple IPhone", 599.99d);
            preisliste.SetPreis("Samsung Galaxy", 500.00d);
            preisliste.SetPreis("Sony Experia", 219.00d);
            preisliste.SetPreis("Nokia Lumia", 180.00d);

            // Beobachter wird angelegt und beim Ticker registriert
   //         beobachter1 = new PreisBeobachter("Geizhals", "Apple IPhone", 499.99d);
            IDisposable disposeB1 = preisliste.Subscribe(beobachter1);

            // Beobachter wird angelegt und beim Ticker registriert
     //       beobachter2 = new PreisBeobachter("Shopper", "Apple IPhone", 550.00d);
            IDisposable disposeB2 = preisliste.Subscribe(beobachter2);

            Console.WriteLine("Neuer Artikel eingefügt: Motorola GP 2");
            preisliste.SetPreis("Motorola GP 2", 199.90d);  // Einfügen von neuen Artikel
            Console.WriteLine ("Preis geändert: Apple IPhone");
            preisliste.SetPreis("Apple IPhone", 549.99d); // Änderung von Preis

 //           Assert.AreEqual(549.99d, preisliste.GetPreis("Apple IPhone"));
   //         Assert.AreEqual(199.90d, preisliste.GetPreis("Motorola GP 2"));

            disposeB2.Dispose();  // beobachter2 abmelden
     //       beobachter1.Artikel = "Sony Experia";
       //     beobachter1.Preislimit = 200d;
            Console.WriteLine("Preis geändert: Sony Experia");
            preisliste.SetPreis("Sony Experia", 199.00d); // Änderung von Preis

            Console.WriteLine("Test Preisliste erfolgreich");
        }
    }
}