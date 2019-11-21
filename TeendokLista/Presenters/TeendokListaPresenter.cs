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
    class TeendokListaPresenter : IDisposable
    {
        private TeendokContext db = new TeendokContext();
        private ITeendokListaView view;
        public TeendokListaPresenter(ITeendokListaView param)
        {
            view = param;
            // Lista feltöltése
            LoadData();
            // Az első elem betöltése szerkesztés nézetben
            GetFeladat(db.feladat.First().Id);
        }

        public void LoadData()
        {
            view.feladatLista = db.feladat.ToList();
        }

        public void GetFeladat(int id)
        {
            view.feladat = db.feladat.Find(id);
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
            var letezik = db.feladat.Find(feladat.Id);
            //var letezik = db.feladat.AsNoTracking().SingleOrDefault(x => x.Id == feladat.Id);

            // Ha már létezik
            if (letezik != null)
            {
                // A jelenlegi felhasználó Id-jának lekérdezése
                feladat.felhasznaloId = CurrentUser.Id;
                letezik = feladat;
                db.Entry(letezik).State = EntityState.Modified;
            }
            else
            {
                // A jelenlegi felhasználó Id-jának lekérdezése
                feladat.felhasznaloId = CurrentUser.Id;
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

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
