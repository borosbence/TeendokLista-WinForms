using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeendokLista.Models
{
    public partial class feladat
    {
        public feladat(string cim, string szoveg, DateTime letrehozas, bool teljesitve, int id = 0)
        {
            Id = id;
            Cim = cim;
            Szoveg = szoveg;
            LetrehozasDatum = letrehozas;
            Teljesitve = teljesitve;
        }

        public feladat()
        {

        }
    }
}
