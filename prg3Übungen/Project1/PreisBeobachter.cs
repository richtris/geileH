using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung06.Observer
{
    /**
     * Diese Klasse kann eine Preisliste auf der Konsole ausgeben. Bei jeder Änderung
     * der Preisliste wird sie erneut ausgegeben.
     *
     * @see Ticker
     */
    public class PreisBeobachter : IObserver<IDictionary<String, double>>
    {

        /**
         * Der name des Preisbeobachters.
         */
        private String name;

        /**
         * Erzeugt einen neuen Preisbeobachter.
         *
         * @param name dieser Name ist rein informativ.
         */
        public PreisBeobachter(String name, String artikel, double preislimit )
        {
            this.name = name;
            Artikel = artikel;
            Preislimit = preislimit;
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public String Artikel
        {
            get;
            set;
        }

        public double Preislimit
        {
            get;
            set;
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }


        /**
          * This method is called whenever the observed object is changed. An
          * application calls an <tt>Observable</tt> object's
          * <code>notifyObservers</code> method to have all the object's
          * observers notified of the change. <br>
          * Die aktuelle Preisliste wird auf der Konsole ausgegeben.
          *
          * @param   o     the observable object.
          * @param   arg   an argument passed to the <code>notifyObservers</code>
          *                 method.
          */
        public void OnNext(IDictionary<string, double> preise)
        {
            Console.WriteLine("Preise der Preisliste für " + name);
            foreach (KeyValuePair<string, double> entry in preise)
            {
                Console.WriteLine(entry.Key + ": " + entry.Value);
            }
            Console.WriteLine();
        }
    }
}
