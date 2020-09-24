using Citologija.Repository;
using System;
using System.Windows.Forms;

namespace Citologija
{
    public partial class PodesavanjaForm : Form
    {
        public NalazRepository repo = new NalazRepository();
        public PodesavanjaForm()
        {
            InitializeComponent();
            dataGridView1.DataSource = repo.ReadAllBio();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            repo.addBiopsija(textBox1.Text);
            dataGridView1.DataSource = repo.ReadAllBio();
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
                        MessageBox.Show("Obrisi");
                        break;

                    case "izmeni":

                        var id = senderGrid.Rows[senderGrid.CurrentCell.RowIndex].Cells["Id"].Value.ToString();
                        break;
                }
            }
        }
    }
}
