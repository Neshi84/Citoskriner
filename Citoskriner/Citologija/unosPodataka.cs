using Citologija.Model;
using Citologija.Repository;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Citologija
{
    public partial class unosPodataka : Form
    {
        PacijentRepository pacijenti = new PacijentRepository();
        BiopsijaRepository biopsije = new BiopsijaRepository();
        PapRepository papRepo = new PapRepository();
        HpvRepository hpvRepo = new HpvRepository();
        HirIntervencijeRepository hirRepo = new HirIntervencijeRepository();
        RevizijaRepository revizije = new RevizijaRepository();

        public unosPodataka()
        {

            var pac= pacijenti.getAllFull();

           var temp = pac.Where(p => p.pap.Any(i => i.lekar == "Dr Kristina Ivković Šunjka"));

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
            revGridView.DataSource = revizije.getRevizijaByPacijentId(DataAccess.Id_pacijent);
        }

        private void UnosHpv_FormClosing(object sender, FormClosingEventArgs e)
        {
            var source = hpvRepo.getHpvByPacijentId(DataAccess.Id_pacijent);
            hpvGridView.DataSource = source;
        }

        public void prikaziPacijenta()
        {
            Pacijent pacijent = pacijenti.getPacijentById(DataAccess.Id_pacijent);
            textIme.Text = pacijent.ime;
            textPrezime.Text = pacijent.prezime;
            textJMBG.Text = pacijent.jmbg;
        }

        private void unosPodataka_Load(object sender, EventArgs e)
        {
            prikaziPacijenta();
            papGridView.DataSource = papRepo.getPapByPacijentId(DataAccess.Id_pacijent);
            hpvGridView.DataSource = hpvRepo.getHpvByPacijentId(DataAccess.Id_pacijent);
            bioGridView.DataSource = biopsije.getBiopsjaByPacientId(DataAccess.Id_pacijent);
            hirGridView.DataSource = hirRepo.getHirByPacijentId(DataAccess.Id_pacijent);
            revGridView.DataSource = revizije.getRevizijaByPacijentId(DataAccess.Id_pacijent);
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
            var temp = biopsije.addBiopsija(DataAccess.Id_pacijent, datePickerBiopsija.Value.ToString("yyyy-MM-dd"), comboBox3.Text);

            if (temp > 0)
            {
                MessageBox.Show("Podaci uspešno sačuvani");
            }
            else
            {
                MessageBox.Show("Došlo je do greške!");
            }
            bioGridView.DataSource =biopsije.getBiopsjaByPacientId(DataAccess.Id_pacijent);
        }

        private void Sacuvaj_Click(object sender, EventArgs e)
        {
            var temp = papRepo.addPap(DataAccess.Id_pacijent, dateTimePicker4.Value.ToString("yyyy-MM-dd"), comboBox1.Text,comboBox2.Text,ploctxt.Text);

            if (temp > 0)
            {
                MessageBox.Show("Podaci uspešno sačuvani");
            }
            else
            {
                MessageBox.Show("Došlo je do greške!");
            }
            papGridView.DataSource = papRepo.getPapByPacijentId(DataAccess.Id_pacijent);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}