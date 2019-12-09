using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeendokLista.Models;
using TeendokLista.Properties;
using TeendokLista.Services;
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

        public void CheckConnection()
        {
            if (!ConnectionExist())
            {
                view.ErrorMessage = Resources.KapcsolodasSikertelen;
            }
        }

        public void Authenticate()
        {
            if (ConnectionExist())
            {
                // Ezzel a felhasználónévvel létezik e rekord
                var dbUser = db.felhasznalo.SingleOrDefault(x => x.FelhasznaloNev.Equals(view.UserName));
                if (dbUser != null)
                {
                    // Só lekérése titkosításhoz
                    var salt = dbUser.Id;
                    // Begépelt jelszó titkosítása
                    var password = Hash.Encrypt(view.Password + salt);

                    // Rekord keresése
                    var user = db.felhasznalo.SingleOrDefault(x => x.FelhasznaloNev.Equals(view.UserName) && x.Jelszo.Equals(password));
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
                else
                {
                    view.ErrorMessage = Resources.FelhasznaloNemLetezik;
                }
            }
        }
    }
}
