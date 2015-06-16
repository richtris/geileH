using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    class Buchverwaltung : IProductAdmin,IProductModule 
    {

        private List<Book>Bücherliste { get; set; }

        public void BuchEingabe(Book buch) 
        { 
            Bücherliste.Add(buch); 
        }

     public   IList<Book> BuecherAnzeigen() 
     { 
         return Bücherliste;
     }
     
        public void BuecherLoeschen() 
        {
            Bücherliste.Clear(); 
        }

        public IDictionary<Book, int> Search(string searchTerm)
        {

            var ergebnisse = new Dictionary<Book, int>();

            foreach (Book buch in Bücherliste)
            {

                if (buch.Title.Contains(searchTerm))
                {
                    ergebnisse.Add(buch, 1);
                }
            }
            return ergebnisse;
        }
             

      public  int GetQuantity(string isbn) { return 0; }
        
    }
}
