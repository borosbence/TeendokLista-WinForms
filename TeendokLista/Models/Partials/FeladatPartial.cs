using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeendokLista.Models
{
    public partial class Feladat
    {
        public Feladat(string cim, string szoveg, DateTime letrehozas, bool teljesitve)
        {
            //Id = id;
            Cim = cim;
            Szoveg = szoveg;
            LetrehozasDatum = letrehozas;
            Teljesitve = teljesitve;
        }

        public Feladat()
        {

        }
    }
}
