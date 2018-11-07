using Citologija.Model;
using System;
using System.Windows.Forms;

namespace Citologija
{
    public partial class unosPodataka : Form
    {
       
        public unosPodataka()
        {
           
            InitializeComponent();
            
            dateTimePicker4.Format = DateTimePickerFormat.Custom;
            dateTimePicker4.CustomFormat = "dd.MM.yyyy";
            datePickerBiopsija.Format = DateTimePickerFormat.Custom;
            datePickerBiopsija.CustomFormat = "dd.MM.yyyy";
            

            papGridView.AutoGenerateColumns = false;
            hpvGridView.AutoGenerateColumns = false;
            bioGridView.AutoGenerateColumns = false;
            hirGridView.AutoGenerateColumns = false;
            revGridView.AutoGenerateColumns = false;
            
        }
      

        private void UnosRev_FormClosing(object sender, FormClosingEventArgs e)
        {
            revGridView.DataSource = DataAccess.VratiReviziju(DataAccess.Id_pacijent);
        }

        private void UnosHpv_FormClosing(object sender, FormClosingEventArgs e)
        {
            hpvGridView.DataSource = DataAccess.VratiHpv(DataAccess.Id_pacijent);
        }

        public void prikaziPacijenta()
        {
            Podaci pacijent = DataAccess.VratiPacijenta(DataAccess.Id_pacijent);
            textIme.Text = pacijent.ime;
            textPrezime.Text = pacijent.prezime;
            textJMBG.Text = pacijent.jmbg;
        }

        private void unosPodataka_Load(object sender, EventArgs e)
        {
            prikaziPacijenta();
            papGridView.DataSource = DataAccess.VratiPap(DataAccess.Id_pacijent);
            hpvGridView.DataSource = DataAccess.VratiHpv(DataAccess.Id_pacijent);
            bioGridView.DataSource = DataAccess.VratiBiopsiju(DataAccess.Id_pacijent);
            hirGridView.DataSource = DataAccess.VratiHir(DataAccess.Id_pacijent);
            revGridView.DataSource = DataAccess.VratiReviziju(DataAccess.Id_pacijent);
        }

        private void NovaRevizijaBtn_Click(object sender, EventArgs e)
        {
            var UnosRevizije = new UnosRevizija();

            UnosRevizije.Show();
            UnosRevizije.FormClosing += UnosRev_FormClosing;
        }

        private void NovHPVBtn_Click(object sender, EventArgs e)
        {
            var UnosHpv = new UnosHPV();
            
            UnosHpv.Show();
            UnosHpv.FormClosing += UnosHpv_FormClosing;
        }

        private void NovaBiopsijaBtn_Click(object sender, EventArgs e)
        {
            var temp = DataAccess.UpisBiopsija(DataAccess.Id_pacijent, datePickerBiopsija.Value.ToString("yyyy-MM-dd"), comboBox3.Text);

            if (temp > 0)
            {
                MessageBox.Show("Podaci uspešno sačuvani");
            }
            else
            {
                MessageBox.Show("Došlo je do greške!");
            }
            bioGridView.DataSource = DataAccess.VratiBiopsiju(DataAccess.Id_pacijent);
        }

        private void Sacuvaj_Click(object sender, EventArgs e)
        {
            var temp = DataAccess.UpisPap(DataAccess.Id_pacijent, dateTimePicker4.Value.ToString("yyyy-MM-dd"), comboBox1.Text,comboBox2.Text,ploctxt.Text);

            if (temp > 0)
            {
                MessageBox.Show("Podaci uspešno sačuvani");
            }
            else
            {
                MessageBox.Show("Došlo je do greške!");
            }
            papGridView.DataSource = DataAccess.VratiPap(DataAccess.Id_pacijent);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}