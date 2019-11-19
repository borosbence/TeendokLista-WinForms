using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeendokLista.Models;
using TeendokLista.ViewInterfaces;

namespace TeendokLista.Presenters
{
    class TeendokListaPresenter
    {
        private TeendokContext db = new TeendokContext();
        private ITeendokListaView view;
        public TeendokListaPresenter(ITeendokListaView param)
        {
            view = param;
        }

        public void LoadData()
        { 
            view.feladatLista = db.feladat.ToList();
        }

        public void GetFeladat(int index)
        {
            var id = view.feladatLista[index].Id;
            view.feladat = db.feladat.SingleOrDefault(x => x.Id == id);
        }

        public void CheckFeladat(feladat feladat, bool allapot)
        {
            feladat.Teljesitve = allapot;
            db.Entry(feladat).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;
            }
            //LoadData();
        }
    }
}
