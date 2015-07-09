using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uebung06.Observer;
using log4net;


namespace UnitTestUebung6
{
    [TestClass]
    public class UnitTestPreise
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(UnitTestComposite));

        private PreisListe preisliste = new PreisListe();
        private PreisBeobachter beobachter1;
        private PreisBeobachter beobachter2;
        
        [TestMethod]
        public void TestPreisliste()
        {
            preisliste.SetPreis("Apple IPhone", 599.99d);
            preisliste.SetPreis("Samsung Galaxy", 500.00d);
            preisliste.SetPreis("Sony Experia", 219.00d);
            preisliste.SetPreis("Nokia Lumia", 180.00d);

            // Beobachter wird angelegt und beim Ticker registriert
            beobachter1 = new PreisBeobachter("Geizhals", "Apple IPhone", 499.99d);
            IDisposable disposeB1 = preisliste.Subscribe(beobachter1);

            // Beobachter wird angelegt und beim Ticker registriert
            beobachter2 = new PreisBeobachter("Shopper", "Apple IPhone", 550.00d);
            IDisposable disposeB2 = preisliste.Subscribe(beobachter2);

            log.Info("Neuer Artikel eingefügt: Motorola GP 2");
            preisliste.SetPreis("Motorola GP 2", 199.90d);  // Einfügen von neuen Artikel
            log.Info("Preis geändert: Apple IPhone");
            preisliste.SetPreis("Apple IPhone", 549.99d); // Änderung von Preis

            Assert.AreEqual(549.99d, preisliste.GetPreis("Apple IPhone"));
            Assert.AreEqual(199.90d, preisliste.GetPreis("Motorola GP 2"));

            disposeB2.Dispose();  // beobachter2 abmelden
            beobachter1.Artikel = "Sony Experia";
            beobachter1.Preislimit = 200d;
            log.Info("Preis geändert: Sony Experia");
            preisliste.SetPreis("Sony Experia", 199.00d); // Änderung von Preis

            log.Info("Test Preisliste erfolgreich");
        }
    }
}
