using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns
{
    class Book : IComparable
    {
        public string Isbn {get; set;}


            public decimal Price {get; set;}

                public string Title {get; set;}

                public int CompareTo(object o) { return 1; }
    }
}
