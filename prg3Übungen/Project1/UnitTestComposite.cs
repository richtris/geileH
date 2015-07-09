using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uebung06.Composite;
using log4net;
using log4net.Config;

namespace UnitTestUebung6
{
    [TestClass]
    public class UnitTestComposite
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(UnitTestComposite));
        [TestMethod]
        public void TestComposite()
        {
            XmlConfigurator.Configure();
            XmlConfigurator.Configure();

            //Elemente vom Dateisystem anlegen
            IDirectoryElement knoten1 = new Folder("Wurzel");
            Assert.AreEqual(knoten1.Size(), 0);  // Test leerer Folder
            IDirectoryElement knoten2 = new Folder("Unterverzeichnis");
            IDirectoryElement blatt1 = new File(100, "Datei1");
            IDirectoryElement blatt2 = new File(500, "Datei2");
            IDirectoryElement blatt3 = new File(20, "Datei3");
            Assert.AreEqual(blatt3.Size(), 20);
            Assert.IsTrue(blatt3.Size() == 20);

            // Dateisystem (Folder und Files) zusammenbauen
            knoten1.Add(knoten2);
            knoten1.Add(blatt1);
            knoten1.Add(blatt2);
            knoten2.Add(blatt3);

            // Groesse des Dateisystems berechnen
            Assert.AreEqual(knoten1.Size(), 620);

            // Ausnahme bei Files testen
            try
            {
                blatt1.Add(blatt2);
                Assert.Fail();
            }
            catch (NotSupportedException e)
            {
                log.Info("Ausnahme unerlaubtes add erkannt");
            }
            log.Info("Test Composite erfolgreich");
        }
    }
}
