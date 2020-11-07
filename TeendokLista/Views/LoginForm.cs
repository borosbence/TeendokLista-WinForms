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
    public partial class LoginForm : Form, ILoginView
    {
        private LoginPresenter presenter;
        public string ErrorMessage { set => errorProviderFNev.SetError(textBoxFelhasznaloNev, value); }
        public string UserName { get => textBoxFelhasznaloNev.Text; }
        public string Password { get => textBoxJelszo.Text; }

        public LoginForm()
        {
            InitializeComponent();
            presenter = new LoginPresenter(this);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            presenter.Authenticate();
            if (presenter.LoginSucces)
            {
                var MainWindow = new MainForm();
                Hide();
                MainWindow.ShowDialog();
                Close();
            }
        }

        private void textBoxJelszo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin.PerformClick();
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            presenter.CheckConnection();
        }
    }
}
