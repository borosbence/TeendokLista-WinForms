using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TeendokLista.Models;
using TeendokLista.Presenters;
using TeendokLista.ViewInterfaces;

namespace TeendokLista.Views
{
    public partial class MainWindow : Form, ITeendokListaView
    {
        /* https://stackoverflow.com/questions/18126793/dynamic-binding-to-checkedlistbox-using-entity-model
         * https://docs.microsoft.com/en-us/ef/ef6/fundamentals/databinding/winforms
         * https://stackoverflow.com/questions/13205105/set-checked-items-in-checkedlistbox-from-list-or-dataset
         */

        private TeendokListaPresenter presenter;
        private bool loading = true;
        public MainWindow()
        {
            InitializeComponent();
            presenter = new TeendokListaPresenter(this);
        }

        public IList<Feladat> feladatLista
        {
            get => (List<Feladat>)checkedListBox1.DataSource;
            set
            {
                checkedListBox1.DataSource = value;
                checkedListBox1.DisplayMember = "Cim";
                checkedListBox1.ValueMember = "Id";
                for (int i = 0; i < value.Count; i++)
                {
                    if (value[i].Teljesitve)
                    {
                        checkedListBox1.SetItemChecked(i, true);
                    }
                }
            }
        }

        public Feladat feladat {
            get
            {
                return new Feladat(textBox1.Text, richTextBox1.Text, Convert.ToDateTime(labelDatum.Text), checkBox1.Checked);
            }
            set
            {
                textBox1.Text = value.Cim;
                richTextBox1.Text = value.Szoveg;
                labelDatum.Text = value.LetrehozasDatum.ToShortDateString();
                checkBox1.Checked = value.Teljesitve;
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            presenter.LoadData();
            loading = false;
            labelDatum.Text = null;
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!loading)
            {
                bool allapot = e.NewValue == CheckState.Checked ? true : false;
                var feladat = (Feladat)checkedListBox1.Items[e.Index];
                presenter.CheckFeladat(feladat, allapot);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = checkedListBox1.SelectedIndex;
            presenter.GetFeladat(index);
        }
    }
}
