using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeendokLista.Presenters;
using TeendokLista.ViewInterfaces;

namespace TeendokLista.Views
{
    public partial class Login : Form, ILoginView
    {
        private LoginPresenter presenter;
        public string ErrorMessage 
        {
            get => errorProviderFNev.GetError(textBoxFelhasznaloNev);
            set => errorProviderFNev.SetError(textBoxFelhasznaloNev, "Hibás belépés!");
        }

        public Login()
        {
            InitializeComponent();
            presenter = new LoginPresenter(this);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            presenter.Authenticate(textBoxFelhasznaloNev.Text, textBoxJelszo.Text );
            if (presenter.LoginSucces)
            {
                var MainWindow = new MainWindow();
                Hide();
                MainWindow.ShowDialog();
                Close();
            }
        }
    }
}
