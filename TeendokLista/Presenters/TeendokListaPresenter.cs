using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeendokLista.Models;
using TeendokLista.Services;
using TeendokLista.ViewInterfaces;

namespace TeendokLista.Presenters
{
    class TeendokListaPresenter
    {
        private TeendokContext db;
        private ITeendokListaView view;
        public TeendokListaPresenter(ITeendokListaView param)
        {
            view = param;
            db = new TeendokContext();
            // Ha van feladat a listában
            if (db.feladat.Any())
            {
                // Az első elem betöltése szerkesztés nézetben
                GetFeladat(db.feladat.First().id);
            }
        }

        /// <summary>
        /// Lista feltöltése adatbázisból.
        /// </summary>
        public void LoadData()
        {
            view.feladatLista = db.feladat.ToList();
        }
        /// <summary>
        /// Feladat részleteinek lerkédezése.
        /// </summary>
        /// <param name="id">Feladat azonosító</param>
        public void GetFeladat(int id)
        {
            view.feladat = db.feladat.Find(id);
        }

        /// <summary>
        /// Feladat beállítása elvégzettre
        /// </summary>
        /// <param name="id">Feladat azonosító</param>
        /// <param name="allapot">Állapot</param>
        public void CheckFeladat(int id, bool allapot)
        {
            var feladat = db.feladat.Find(id);
            feladat.teljesitve = allapot;
            db.Entry(feladat).State = EntityState.Modified;

            db.SaveChanges();
        }

        public void CreateFeladat()
        {
            var id = db.feladat
                .Select(x => x.id)
                .DefaultIfEmpty(0)
                .Max() + 1;
            view.feladat = new feladat(id, null, null, DateTime.Now, false);
        }

        public void SaveFeladat()
        {
            var feladat = view.feladat;
            // A jelenlegi felhasználó id-jának lekérdezése
            feladat.felhasznalo_id = CurrentUser.Id;

            // Megkeressük a db-ben
            var letezik = db.feladat.Find(feladat.id);

            // Ha már létezik
            if (letezik != null)
            {
                db.Entry(letezik).State = EntityState.Detached;
                db.Entry(feladat).State = EntityState.Modified;
            }
            else
            {
                db.feladat.Add(feladat);
            }

            db.SaveChanges();
            LoadData();
        }

        public void DeleteFeladat(int id)
        {
            var feladat = db.feladat.Find(id);

            if (feladat != null)
            {
                db.feladat.Remove(feladat);
            }

            db.SaveChanges();
            LoadData();
        }
    }
}
