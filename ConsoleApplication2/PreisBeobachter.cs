using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    class PreisBeobachter : IObserver<Preisliste>
    {


        public void OnNext(Preisliste preisliste)
        {

            ZeigePreisliste(preisliste);
        }
    
       
 public void ZeigePreisliste(Preisliste preisliste){

        foreach(var preis in preisliste.getPreisliste()) {
        Console.WriteLine("{0},{1}",preis.Key,preis.Value);
        }
    }


 public void OnCompleted()
 {
     throw new NotImplementedException();
 }

 public void OnError(Exception error)
 {
     throw new NotImplementedException();
 }
    }
}
