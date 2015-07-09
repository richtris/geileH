using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung06.Composite
{
    public interface IDirectoryElement
    {
        /// <summary>
        /// Liefert die Groesse eines IDirectoryElements
        /// bei File die Dateigroesse
        /// bei Folder die Summe der Groessen der Element im Folder
        /// </summary>
        /// <returns>Integer-Wert der Komponente</returns>
        int Size();
        /// <summary>
        /// Fügt ein File oder ein Folder in einen Folder ein
        /// </summary>
        /// <param name="x">einzufügendes Directory Element</param>
        void Add(IDirectoryElement x);
    }
}
