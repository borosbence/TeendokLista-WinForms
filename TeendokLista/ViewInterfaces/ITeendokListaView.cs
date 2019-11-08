using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeendokLista.Models;

namespace TeendokLista.ViewInterfaces
{
    interface ITeendokListaView
    {
        IList<Feladat> feladatLista { get; set; }

        Feladat feladat { get; set; }
    }
}
