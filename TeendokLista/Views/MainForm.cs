using System;
using System.Collections.Generic;
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
    public partial class MainForm : Form, ITeendokListaView
    {
        private TeendokListaPresenter presenter;
        private bool loaded = false;
        public MainForm()
        {
            InitializeComponent();
            presenter = new TeendokListaPresenter(this);
            labelDatum.Text = DateTime.Now.ToString();
        }

        public List<feladat> feladatLista
        {
            set
            {
                checkedListBox1.DataSource = value;
                checkedListBox1.DisplayMember = "cim";
                checkedListBox1.ValueMember = "id";
                for (int i = 0; i < value.Count; i++)
                {
                    checkedListBox1.SetItemChecked(i, value[i].teljesitve);
                }
            }
        }

        public feladat feladat {
            get
            {
                var id = int.Parse(labelSorszam.Text);
                var datum = DateTime.Parse(labelDatum.Text);
                return new feladat(id, textBox1.Text, richTextBox1.Rtf, datum, checkBox1.Checked);
            }
            set
            {
                labelSorszam.Text = value.id.ToString();
                textBox1.Text = value.cim;
                richTextBox1.Rtf = value.szoveg;
                labelDatum.Text = value.letrehozas_datum.ToString();
                checkBox1.Checked = value.teljesitve;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            presenter.LoadData();
            loaded = true;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loaded)
            {
                if (checkedListBox1.SelectedItem != null)
                {
                    var id = int.Parse(checkedListBox1.SelectedValue.ToString());
                    presenter.GetFeladat(id);
                }
            }
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            bool allapot = e.NewValue == CheckState.Checked ? true : false;
            var feladat = (feladat)checkedListBox1.Items[e.Index];
            presenter.CheckFeladat(feladat.id, allapot);
        }

        private void UjmenuItem_Click(object sender, EventArgs e)
        {
            presenter.CreateFeladat();
            checkedListBox1.ClearSelected();
        }

        private void MentesmenuItem_Click(object sender, EventArgs e)
        {
            presenter.SaveFeladat();
        }

        private void TorlesmenuItem_Click(object sender, EventArgs e)
        {
            var id = int.Parse(checkedListBox1.SelectedValue.ToString());
            presenter.DeleteFeladat(id);
        }

        private void BtoolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Bold);
        }

        private void ItoolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Italic);
        }

        private void UtoolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Underline);
        }

        private void StoolStripButton_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(richTextBox1.Font, FontStyle.Strikeout);
        }
    }
}
