using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichtrisObjects
{
    public interface ISpielfeld
    {
        int[,] FeldMatrix { get; }
        void StarteSpiel();
        void Nach_unten();
        void Nach_rechts();
        void Nach_links();
        void Drehen();
        void HardDrop();
        void Nach_oben();
        void AblegenUndNeu();
    }
}
