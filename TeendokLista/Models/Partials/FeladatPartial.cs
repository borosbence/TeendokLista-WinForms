using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeendokLista.Models
{
    public partial class feladat
    {
        public feladat(int id, string cim, string szoveg, DateTime datum, bool teljesitve)
        {
            this.id = id;
            this.cim = cim;
            this.szoveg = szoveg;
            letrehozas_datum = datum;
            this.teljesitve = teljesitve;
        }

        public feladat()
        {

        }
    }
}
