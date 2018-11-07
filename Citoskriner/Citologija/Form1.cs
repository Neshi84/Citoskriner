using Citologija.Model;
using System;
using System.Windows.Forms;

namespace Citologija
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            datumOD.Format = DateTimePickerFormat.Custom;
            datumOD.CustomFormat = "dd.MM.yyyy";
            datumDO.Format = DateTimePickerFormat.Custom;
            datumDO.CustomFormat = "dd.MM.yyyy";
            dataGridView1.AutoGenerateColumns = false;
        }

        private void updateGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DataAccess.ReadAll();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateGridView();
        }

        private void unosPodataka_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateGridView();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DataAccess.IzvestaCito(comboBox1.Text);
            //dataGridView1.DataSource = data.DatSelect(datumOD.Value.ToString("yyyy-MM-dd"), datumDO.Value.ToString("yyyy-MM-dd"), comboBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Podaci pacijent = new Podaci
            {
                ime = imeTxt.Text,
                prezime = prezimeTxt.Text,
                jmbg = jmbgTxt.Text,
            };

            var temp = DataAccess.UpisPacijenta(pacijent);
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataAccess.Id_pacijent =(int)(dataGridView1.CurrentRow.Cells[0].Value);
            var unos_podataka = new unosPodataka();
           
            unos_podataka.Show();
            unos_podataka.FormClosing += unosPodataka_FormClosing;
        }
    }
}