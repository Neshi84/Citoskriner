using Citologija.Model;
using Citologija.Repository;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Citologija
{
    public partial class Form1 : Form
    {
        PacijentRepository pacijenti = new PacijentRepository();
        public Form1()
        {           
            InitializeComponent();         
            dataGridView1.AutoGenerateColumns = false;
        }

        private void updateGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = pacijenti.ReadAll().OrderBy(p=>p.id).ToList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateGridView();
        }

        private void unosPodataka_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateGridView();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            Pacijent pacijent = new Pacijent
            {
                ime = imeTxt.Text,
                prezime = prezimeTxt.Text,
                jmbg = jmbgTxt.Text,
            };

            Pacijent provera = pacijenti.getPacijentByJMBG(jmbgTxt.Text);

            if (provera!=null)
            {
                MessageBox.Show("Već postoji pacijent sa unetim JMBG\n "+provera.ime+" "+provera.prezime);
            }
            else
            {

                var temp = pacijenti.addPacijent(pacijent);
                if (temp > 0)
                {
                    updateGridView();
                    DataAccess.Id_pacijent = temp;
                    var unos_podataka = new unosPodataka();
                
                    unos_podataka.Show();
                    unos_podataka.FormClosing += unosPodataka_FormClosing;
                }
                else
                {
                    MessageBox.Show("Došlo je do greške!");
                }
            }
           
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataAccess.Id_pacijent =(int)(dataGridView1.CurrentRow.Cells[0].Value);
            var unos_podataka = new unosPodataka();
           
            unos_podataka.Show();
            unos_podataka.FormClosing += unosPodataka_FormClosing;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var id = (int)(dataGridView1.CurrentRow.Cells[0].Value);
                pacijenti.deletePacijent((int)(dataGridView1.CurrentRow.Cells[0].Value));
                updateGridView();
            }
        }

        private void izvestajiBtn_Click(object sender, EventArgs e)
        {
            var izvestaji = new Izvestaji();

            izvestaji.Show();
        }

        private void PretragaTxtBox_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = pacijenti.searchPacijent(PretragaTxtBox.Text);
        }
    }
}