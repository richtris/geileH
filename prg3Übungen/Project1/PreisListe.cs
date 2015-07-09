using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung06.Observer
{
    /**
     * Diese Klasse verwaltet eine Menge von Börsenkursen. Da sie von Observable
     * abgeleitet ist, können sich andere Objekte registrieren, um bei Änderungen
     * automatisch informiert zu werden.
     */
    public class PreisListe : IObservable<IDictionary<String, double>>
    {

        /**
         * Diese Map speichert die Preise
         */
        private IDictionary<String, Double> preise;
        private List<IObserver<IDictionary<String, double>>> observers;

        /**
         * Ein neuer Ticker wird erzeugt.
         */
        public PreisListe()
        {
            preise = new Dictionary<String, Double>();
            observers = new List<IObserver<IDictionary<String, double>>>();
        }

        /**
         * Es wird entweder ein neuer Artikel mit Preis hinzugefügt (Artikelname noch nicht vorhanden), oder
         * ein bestehnder Preis aktualisiert (Artikelname bereits vorhanden).
         *
         * @param name  name des Artikels
         * @param preis aktueller Preis des Artikels
         */
        public void SetPreis(String name, Double preis)
        {
            if (preise.ContainsKey(name))
                preise[name] = preis;
            else
                preise.Add(name, preis);

            foreach (var observer in observers)
            {
                observer.OnNext(preise);  //Observer benachrichtigen

                PreisBeobachter pb = (PreisBeobachter)observer;
                if (preise.ContainsKey(pb.Artikel) && preise[pb.Artikel] <= pb.Preislimit)
                {
                    // Preisalarm
                    IDictionary<String, Double> preisalarm = new Dictionary<String, Double>();
                    preisalarm.Add(pb.Artikel, preise[pb.Artikel]);
                    observer.OnNext(preisalarm);  //Observer benachrichtigen
                }
               
            }
        }


        /**
         * Lese einen Kurs aus der Kursliste aus.
         *
         * @param name Artikelname des zu lesenden Preises.
         *
         * @return aktueller Preis, oder <code>null</code>, wenn name nicht in der Liste vorhanden ist.
         */
        public Double GetPreis(String name)
        {
            return preise[name];
        }

        public IDisposable Subscribe(IObserver<IDictionary<String, double>> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }
    }
    class Unsubscriber : IDisposable
    {
        private List<IObserver<IDictionary<String, double>>> _observers;
        private IObserver<IDictionary<String, double>> _observer;

        public Unsubscriber(List<IObserver<IDictionary<String, double>>> observers, IObserver<IDictionary<String, double>> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observer != null && _observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}
