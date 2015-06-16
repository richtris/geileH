using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    /* dei muadder sei intergsicht */
   interface IProductAdmin
    {
       void BuchEingabe(Book buch); 
          IList<Book> BuecherAnzeigen(); 
        void BuecherLoeschen();

    }
}
