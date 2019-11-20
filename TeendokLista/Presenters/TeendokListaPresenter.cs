using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
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
            LoadData();
        }

        public void LoadData()
        {
            view.feladatLista = db.feladat.ToList();
            // GetFeladat(db.feladat.First().Id);
        }

        public void GetFeladat(int id)
        {
            view.feladat = db.feladat.SingleOrDefault(x => x.Id == id);
        }

        public void CheckFeladat(int id, bool allapot)
        {
            var feladat = db.feladat.Find(id);
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
        }

        public void CreateFeladat()
        {
            view.feladat = new feladat(null,null,DateTime.Now,false);
        }

        public void SaveFeladat()
        {
            var feladat = view.feladat;
            // Megkeressük a db-ben
            var letezik = db.feladat.SingleOrDefault(x => x.Id == feladat.Id);

            // Ha már létezik
            if (letezik != null)
            {
                // TODO: admin Id-jének lekérdezése
                feladat.felhasznaloId = 1;
                letezik = feladat;
                db.Entry(letezik).State = EntityState.Modified;
            }
            else
            {
                // TODO: admin Id-jének lekérdezése
                feladat.felhasznaloId = 1;
                db.feladat.Add(feladat);
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            LoadData();
        }

        public void DeleteFeladat(int id)
        {
            var feladat = db.feladat.Find(id);

            if (feladat != null)
            {
                db.feladat.Remove(feladat);
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            LoadData();
        }
    }
}
