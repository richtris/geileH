using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung06.Composite
{
    /// <summary>
    /// 
    /// </summary>
    public class File : IDirectoryElement
    {
        private int size;
        private String name;


        /// <summary>
        /// Erzeugt ein neue Datei
        /// </summary>
        /// <param name="size">Dateigroesse</param>
        /// <param name="name">Dateiname</param>
        public File(int size, String name)
        {
            this.size = size;
            this.name = name;
        }

        /// <summary>
        /// Gibt die Dateigroesse aus.
        /// </summary>
        /// <returns>Dateigroesse</returns>
        public int Size()
        {
            return size;
        }

        /// <summary>
        /// Add wird bei Blatt in Kopositum nicht unterstützt
        /// </summary>
        /// <param name="x"></param>
        public void Add(IDirectoryElement x)
        {
            throw new NotSupportedException();
        }

    }
}
