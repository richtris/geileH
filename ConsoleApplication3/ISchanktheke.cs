using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung12
{
    public interface ISchanktheke
    {
        List<Getraenk> get();
        void put(Getraenk bier);
        int Durchsatz();
        int AnzahlGetraenke();
    }
}
