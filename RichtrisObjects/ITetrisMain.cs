using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichtrisObjects
{
    public interface ITetrisMain
    {
        void Update(Spielfeld spielfeld, bool remove = false);

        void Remove(Spielstein einSpielstein);
    }
}
