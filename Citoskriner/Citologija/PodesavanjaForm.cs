using Citologija.Model;
using Citologija.Repository;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Citologija
{
    public partial class PodesavanjaForm : Form
    {
        public NalazRepository repo = new NalazRepository();

        private int id;

        public PodesavanjaForm()
        {
            InitializeComponent();
            dataGridView1.DataSource = repo.ReadAllBio().Where(n => n.nalaz != "").ToList();
            dataGridHpv.DataSource = repo.ReadAllHpv().Where(n => n.nalaz != "").ToList();
            dataGridView2.DataSource = repo.ReadAllCito().Where(n => n.nalaz != "").ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (button1.Text)
            {
                case "Sacuvaj":
                    repo.addBiopsija(textBox1.Text);

                    break;

                case "Sacuvaj izmene":
                    var nalaz = new Nalaz()
                    {
                        id = id,
                        nalaz = textBox1.Text
                    };

                    var upd = repo.updateBiopsija(nalaz);
                    textBox1.Clear();
                    button1.Text = "Sacuvaj";

                    break;
            }

            dataGridView1.DataSource = repo.ReadAllBio().Where(n => n.nalaz != "").ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                switch (senderGrid.Columns[e.ColumnIndex].Name)
                {
                    case "Obrisi":
                        repo.deleteBiopsija(int.Parse(senderGrid.Rows[senderGrid.CurrentCell.RowIndex].Cells["Id"].Value.ToString()));
                        dataGridView1.DataSource = repo.ReadAllBio().Where(n => n.nalaz != "").ToList();
                        break;

                    case "izmeni":

                        id = int.Parse(senderGrid.Rows[senderGrid.CurrentCell.RowIndex].Cells["Id"].Value.ToString());
                        textBox1.Text = senderGrid.Rows[senderGrid.CurrentCell.RowIndex].Cells["Nalaz"].Value.ToString();
                        button1.Text = "Sacuvaj izmene";

                        break;
                }
            }
        }

        private void dataGridHpv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                switch (senderGrid.Columns[e.ColumnIndex].Name)
                {
                    case "obrisi_hpv":
                        repo.deleteHpv(int.Parse(senderGrid.Rows[senderGrid.CurrentCell.RowIndex].Cells["id_hpv"].Value.ToString()));
                        dataGridHpv.DataSource = repo.ReadAllHpv().Where(n => n.nalaz != "").ToList();
                        break;

                    case "izmeni_hpv":

                        id = int.Parse(senderGrid.Rows[senderGrid.CurrentCell.RowIndex].Cells["id_hpv"].Value.ToString());
                        textBoxHpv.Text = senderGrid.Rows[senderGrid.CurrentCell.RowIndex].Cells["nalaz_hpv"].Value.ToString();
                        buttonHpv.Text = "Sacuvaj izmene";

                        break;
                }
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                switch (senderGrid.Columns[e.ColumnIndex].Name)
                {
                    case "obrisi_cito":
                        repo.deleteCito(int.Parse(senderGrid.Rows[senderGrid.CurrentCell.RowIndex].Cells["id_cito"].Value.ToString()));
                        dataGridView2.DataSource = repo.ReadAllCito().Where(n => n.nalaz != "").ToList();
                        break;

                    case "izmeni_cito":

                        id = int.Parse(senderGrid.Rows[senderGrid.CurrentCell.RowIndex].Cells["id_cito"].Value.ToString());
                        textBoxCito.Text = senderGrid.Rows[senderGrid.CurrentCell.RowIndex].Cells["nalaz_cito"].Value.ToString();
                        buttonCito.Text = "Sacuvaj izmene";

                        break;
                }
            }
        }

        private void buttonHpv_Click(object sender, EventArgs e)
        {
            switch (buttonHpv.Text)
            {
                case "Sacuvaj":
                    repo.addHpv(textBoxHpv.Text);

                    break;

                case "Sacuvaj izmene":
                    var nalaz = new Nalaz()
                    {
                        id = id,
                        nalaz = textBoxHpv.Text
                    };

                    var upd = repo.updateHpv(nalaz);
                    textBoxHpv.Clear();
                    buttonHpv.Text = "Sacuvaj";

                    break;
            }

            dataGridHpv.DataSource = repo.ReadAllHpv().Where(n => n.nalaz != "").ToList();
        }

        private void buttonCito_Click(object sender, EventArgs e)
        {
            switch (buttonCito.Text)
            {
                case "Sacuvaj":
                    repo.addCito(textBoxCito.Text);

                    break;

                case "Sacuvaj izmene":
                    var nalaz = new Nalaz()
                    {
                        id = id,
                        nalaz = textBoxCito.Text
                    };

                    var upd = repo.updateCito(nalaz);
                    textBoxCito.Clear();
                    buttonCito.Text = "Sacuvaj";

                    break;
            }

            dataGridView2.DataSource = repo.ReadAllCito().Where(n => n.nalaz != "").ToList();
        }
    }
}