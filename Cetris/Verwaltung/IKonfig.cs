using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cetris.Verwaltung
{
        interface IKonfig
        {
        // Der aktuelle User
        String User {get; set;}
        //Level eingeben
        int Level { get; set; }
        //Spieltyp A oder B
        Spieltyp SpielTyp {get; set;}
    }
}
