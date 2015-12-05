using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RichtrisObjects
{
    public interface ITetrisMain
    {
        void CreateMap();
        void Update(Spielfeld spielfeld, bool remove = false);

        void ResetView();

        void Remove(Spielstein einSpielstein);

        void GameOver();
    }
}
