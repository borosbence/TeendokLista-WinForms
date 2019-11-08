using System;
using System.Collections.Generic;
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

        public void GetFeladat(int id)
        {
            view.feladat = db.Feladat.SingleOrDefault(x => x.Id == id + 1);
        }

        //private DataTable ToDataTable<T>(T entity) where T : class
        //{
        //    var properties = typeof(T).GetProperties();
        //    var table = new DataTable();

        //    foreach (var property in properties)
        //    {
        //        table.Columns.Add(property.Name, property.PropertyType);
        //    }

        //    table.Rows.Add(properties.Select(p => p.GetValue(entity, null)).ToArray());
        //    return table;
        //}
    }
}
