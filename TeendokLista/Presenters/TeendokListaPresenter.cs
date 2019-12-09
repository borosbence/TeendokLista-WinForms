using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
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
            // Lista feltöltése
            LoadData();
            // Ha van feladat a listában
            if (db.feladat.First() != null)
            {
                // Az első elem betöltése szerkesztés nézetben
                GetFeladat(db.feladat.First().Id);
            }
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
            var id = db.feladat
                .Select(x => x.Id)
                .DefaultIfEmpty(0)
                .Max() + 1;
            view.feladat = new feladat(id,null,null,DateTime.Now,false);
        }

        public void SaveFeladat()
        {
            var feladat = view.feladat;
            // A jelenlegi felhasználó Id-jának lekérdezése
            feladat.felhasznaloId = CurrentUser.Id;

            // Megkeressük a db-ben
            var letezik = db.feladat.Find(feladat.Id);

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
