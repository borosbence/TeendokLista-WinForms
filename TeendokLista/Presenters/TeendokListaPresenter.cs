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
            view.feladatLista = db.Feladat.ToList();
        }

        public void GetFeladat(int index)
        {
            var id = view.feladatLista[index].Id;
            view.feladat = db.Feladat.SingleOrDefault(x => x.Id == id);
        }

        public void CheckFeladat(Feladat feladat, bool allapot)
        {
            //var id = view.feladatLista[index].Id;
            //var feladat = db.Feladat.SingleOrDefault(x => x.Id == id);
            feladat.Teljesitve = allapot;
            /*
             * check the Copy to Output Directory of DB.
             * change the Copy to Output Directory property of the database file to Copy if newer..
             */
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
