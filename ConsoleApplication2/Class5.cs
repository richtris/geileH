using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Patterns
{
    class Preisliste : IObservable<Preisliste>
    {

        private Dictionary<string,decimal> preisliste = new Dictionary<string,decimal>{{"Gras",10.5m},{"Hasch",8.8m},{"Analsex",100.0123m}};

        private List<IObserver<Preisliste>> observers;
 
   
        public void setPreis(String name, decimal preis) { 
            
            if (preis <= 0) throw new  IndexOutOfRangeException("Preis muss positiv sein!");
        
            else if (String.IsNullOrWhiteSpace(name)) throw new Exception ("Kein Name vorhanden");

            preisliste.Add(name,preis);

            foreach (var observer in observers) { observer.OnNext(this); }
        
        }

        public IDisposable Subscribe(IObserver<Preisliste>observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
                return new Unsubscriber(observers,observer);
        }



        public double getKurs(String wechselkurs) {

           if (preisliste.ContainsKey(wechselkurs)) 
            
            return (double) preisliste[wechselkurs];
           else throw new IndexOutOfRangeException();


        }
    }
}
