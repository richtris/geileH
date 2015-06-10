using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
  interface IProductModule
    {

        IDictionary<Book, int>
            Search(string searchTerm);

        int GetQuantity(string isbn);
        


        }
    }