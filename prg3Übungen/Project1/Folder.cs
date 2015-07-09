using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uebung06.Composite
{
    /**
     * Mehrdimensionale Listen können über diese Klasse demonstriert werden. Das
     * Muster Komposition wird angewendet. 
     * Folder stellt ein Dateisystem dar, bestehend aus den Objekten File und Folder
     * Zu einem Folder können beliebige Directory Elemente (File, Folder)hinzugefügt werden, 
     * Über die value-Methode wird der rekursive Charakter dieses Musters deutlich.
     */
    public class Folder : IDirectoryElement
    {

        /**
         * Speicher für Folder und Files
         */
        private List<IDirectoryElement> myList;
        private String name; // Name des Folders

        /**
         * Konstruiert ein neuen Folder und initalisert den Listenspeicher.
         */
        public Folder(String name)
        {
            myList = new List<IDirectoryElement>();
            this.name = name;
        }

        /**
         * Füge ein neues Directory Element an den Folder ein.
         *
         * @param x Objekt, das angehängt werden soll.
         */
        public void Add(IDirectoryElement x)
        {
            myList.Add(x);
        }

        /**
         * summiert rekursiv alle Werte im Composite
         *
         * @return Summe der Dateigroessen in der Liste.
         */
        public int Size()
        {
            int result = 0;
            foreach (IDirectoryElement el in myList)
            {
                result = result + el.Size();
            }
            return result;
        }

    }

}
