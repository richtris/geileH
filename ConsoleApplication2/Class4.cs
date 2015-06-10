using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    class Buchverwaltung : IProductAdmin,IProductModule 
    {
     public   void BuchEingabe(Book buch) { }
     public   IList<Book> BuecherAnzeigen() { return new List<Book>(); }
       public void BuecherLoeschen() { }

     public   IDictionary<Book, int>
           Search(string searchTerm) { return new Dictionary <Book, int>(); }

      public  int GetQuantity(string isbn) { return 0; }
        
    }
}
