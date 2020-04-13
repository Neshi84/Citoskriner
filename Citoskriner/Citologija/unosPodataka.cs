using Citologija.Model;
using Citologija.Repository;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Citologija
{
    
    public partial class unosPodataka : Form
    {
        private int _idPacijent;

        PacijentRepository pacijenti = new PacijentRepository();
        BiopsijaRepository biopsije = new BiopsijaRepository();
        PapRepository papRepo = new PapRepository();
        HpvRepository hpvRepo = new HpvRepository();
        HirIntervencijeRepository hirRepo = new HirIntervencijeRepository();
        RevizijaRepository revizije = new RevizijaRepository();
        LekarRepository lekarRepo = new LekarRepository();

        public unosPodataka(int idPacijent)
        {

            _idPacijent = idPacijent;

            InitializeComponent();
            
            dateTimePicker4.Format = DateTimePickerFormat.Custom;
            dateTimePicker4.CustomFormat = "dd.MM.yyyy";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd.MM.yyyy";
            datePickerBiopsija.Format = DateTimePickerFormat.Custom;
            datePickerBiopsija.CustomFormat = "dd.MM.yyyy";

            comboBox2.DataSource = lekarRepo.ReadAll();
            comboBox2.DisplayMember = "imePrezime";
            comboBox2.ValueMember = "id";

            comboBox4.DataSource = lekarRepo.ReadAll();
            comboBox4.DisplayMember = "imePrezime";
            comboBox4.ValueMember = "id";

            comboBox5.DataSource = lekarRepo.ReadAll();
            comboBox5.DisplayMember = "imePrezime";
            comboBox5.ValueMember = "id";

            comboBox8.DataSource = lekarRepo.ReadAll();
            comboBox8.DisplayMember = "imePrezime";
            comboBox8.ValueMember = "id";


            papGridView.AutoGenerateColumns = false;
            hpvGridView.AutoGenerateColumns = false;
            bioGridView.AutoGenerateColumns = false;
            hirGridView.AutoGenerateColumns = false;
            revGridView.AutoGenerateColumns = false;
            
        }
      

        private void UnosRev_FormClosing(object sender, FormClosingEventArgs e)
        {
            revGridView.DataSource = revizije.getRevizijaByPacijentId(_idPacijent);
        }

        private void UnosHpv_FormClosing(object sender, FormClosingEventArgs e)
        {
            var source = hpvRepo.getHpvByPacijentId(_idPacijent);
            hpvGridView.DataSource = source;
        }

        public void prikaziPacijenta()
        {
            Pacijent pacijent = pacijenti.getPacijentById(_idPacijent);
            textIme.Text = pacijent.ime;
            textPrezime.Text = pacijent.prezime;
            textJMBG.Text = pacijent.jmbg;
        }

        private void unosPodataka_Load(object sender, EventArgs e)
        {
            prikaziPacijenta();
            papGridView.DataSource = papRepo.getPapByPacijentId(_idPacijent);
            hpvGridView.DataSource = hpvRepo.getHpvByPacijentId(_idPacijent);
            bioGridView.DataSource = biopsije.getBiopsjaByPacientId(_idPacijent);
            hirGridView.DataSource = hirRepo.getHirByPacijentId(_idPacijent);
            revGridView.DataSource = revizije.getRevizijaByPacijentId(_idPacijent);
        }

        private void NovaRevizijaBtn_Click(object sender, EventArgs e)
        {
            var UnosRevizije = new UnosRevizija(_idPacijent);

            UnosRevizije.Show();
            UnosRevizije.FormClosing += UnosRev_FormClosing;
        }

        private void NovHPVBtn_Click(object sender, EventArgs e)
        {
            if (comboBox5.Text != "")
            {
                var temp = hpvRepo.addHpv(_idPacijent, dateTimePicker1.Value.ToString("yyyy-MM-dd"), comboBox6.Text, int.Parse(comboBox5.SelectedValue.ToString()));
                if (temp > 0)
                {
                    hpvGridView.DataSource = hpvRepo.getHpvByPacijentId(_idPacijent);
                    MessageBox.Show("Podaci uspešno sačuvani");
                }
                else
                {
                    MessageBox.Show("Došlo je do greške!");
                }
            }
            else
            {
                MessageBox.Show("Odaberite lekara!");
            }
        }

        private void NovaBiopsijaBtn_Click(object sender, EventArgs e)
        {
            var temp = biopsije.addBiopsija(_idPacijent, datePickerBiopsija.Value.ToString("yyyy-MM-dd"), comboBox3.Text);

            if (temp > 0)
            {
                MessageBox.Show("Podaci uspešno sačuvani");
            }
            else
            {
                MessageBox.Show("Došlo je do greške!");
            }
            bioGridView.DataSource =biopsije.getBiopsjaByPacientId(_idPacijent);
        }

        private void Sacuvaj_Click(object sender, EventArgs e)
        {
            var temp = papRepo.addPap(_idPacijent, dateTimePicker4.Value.ToString("yyyy-MM-dd"), comboBox1.Text,comboBox2.Text,ploctxt.Text);

            if (temp > 0)
            {
                MessageBox.Show("Podaci uspešno sačuvani");
            }
            else
            {
                MessageBox.Show("Došlo je do greške!");
            }
            papGridView.DataSource = papRepo.getPapByPacijentId(_idPacijent);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}