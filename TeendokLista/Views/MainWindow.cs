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

        public List<feladat> feladatLista
        {
            get => (List<feladat>)checkedListBox1.DataSource;
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

        public feladat feladat {
            get
            {
                var id = int.Parse(labelSorszam.Text);
                return new feladat(textBox1.Text, richTextBox1.Text, Convert.ToDateTime(labelDatum.Text), checkBox1.Checked, id);
            }
            set
            {
                labelSorszam.Text = value.Id.ToString();
                textBox1.Text = value.Cim;
                richTextBox1.Text = value.Szoveg;
                labelDatum.Text = value.LetrehozasDatum.ToShortDateString();
                checkBox1.Checked = value.Teljesitve;
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            loading = false;
            labelDatum.Text = null;
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!loading)
            {
                bool allapot = e.NewValue == CheckState.Checked ? true : false;
                var feladat = (feladat)checkedListBox1.Items[e.Index];
                presenter.CheckFeladat(feladat.Id, allapot);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!loading)
            {
                if (checkedListBox1.SelectedItem != null)
                {
                    var id = int.Parse(checkedListBox1.SelectedValue.ToString());
                    presenter.GetFeladat(id);
                }
            }
        }

        private void toolStripButtonTorles_Click_1(object sender, EventArgs e)
        {
            var id = int.Parse(checkedListBox1.SelectedValue.ToString());
            presenter.DeleteFeladat(id);
        }

        private void feladatToolStripUjFeladat_Click(object sender, EventArgs e)
        {
            presenter.CreateFeladat();
            checkedListBox1.ClearSelected();
        }

        private void toolStripButtonMentes_Click(object sender, EventArgs e)
        {
            presenter.SaveFeladat();
        }
    }
}
