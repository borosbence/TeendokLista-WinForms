using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeendokLista.Models;
using TeendokLista.Properties;
using TeendokLista.ViewInterfaces;

namespace TeendokLista.Presenters
{
    class LoginPresenter
    {
        private TeendokContext db = new TeendokContext();
        private ILoginView view;
        public bool LoginSucces;

        public LoginPresenter(ILoginView param)
        {
            view = param;
        }

        private bool ConnectionExist()
        {
            return db.Database.Exists();
        }

        public void Authenticate()
        {
            if (!ConnectionExist())
            {
                view.ErrorMessage = Resources.KapcsolodasSikertelen;
            }

            var user = db.felhasznalo.SingleOrDefault(x => x.FelhasznaloNev.Equals(view.UserName) && x.Jelszo.Equals(view.Password));
            if (user != null)
            {
                LoginSucces = true;
                CurrentUser.Id = user.Id;
            }
            else
            {
                view.ErrorMessage = Resources.HibasLogin;
            }
        }
    }
}
