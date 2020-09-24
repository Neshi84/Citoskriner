using Citologija.Model;
using Citologija.Repository;
using System;
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
            dataGridView1.DataSource = repo.ReadAllBio();
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
                    
                    break;
            }

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

                        id =int.Parse( senderGrid.Rows[senderGrid.CurrentCell.RowIndex].Cells["Id"].Value.ToString());
                        textBox1.Text = senderGrid.Rows[senderGrid.CurrentCell.RowIndex].Cells["Nalaz"].Value.ToString();
                        button1.Text = "Sacuvaj izmene";

                        break;
                }
            }
        }
    }
}
