using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeendokLista.Models;
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

        public void Authenticate(string username, string password)
        {
            if (username == "admin" && password == "admin")
            {
                var user = db.felhasznalo.SingleOrDefault(x => x.FelhasznaloNev.Equals(username) && x.Jelszo.Equals(password));
                if (user != null)
                {
                    LoginSucces = true;
                }
            }
            else
            {
                view.ErrorMessage = "Hibás felhasználónév vagy jelszó!";
            }
        }

    }
}
