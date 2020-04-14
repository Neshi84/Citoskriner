using Citologija.Model;
using Citologija.Repository;
using System;
using System.Windows.Forms;

namespace Citologija
{

    public partial class unosPodataka : Form
    {
        private int _idPacijent { get; set; }
     

        PacijentRepository pacijenti = new PacijentRepository();
        BiopsijaRepository biopsije = new BiopsijaRepository();
        PapRepository papRepo = new PapRepository();
        HpvRepository hpvRepo = new HpvRepository();
        HirIntervencijeRepository hirRepo = new HirIntervencijeRepository();
        RevizijaRepository revizije = new RevizijaRepository();
        LekarRepository lekarRepo = new LekarRepository();
        NalazRepository nalazRepo = new NalazRepository();

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

            comboBox6.DataSource = nalazRepo.ReadAllHpv();
            comboBox6.DisplayMember = "nalaz";
            comboBox6.ValueMember = "id";

            comboBox1.DataSource = nalazRepo.ReadAllCito();
            comboBox1.DisplayMember = "nalaz";
            comboBox1.ValueMember = "id";

            comboBox7.DataSource = nalazRepo.ReadAllCito();
            comboBox7.DisplayMember = "nalaz";
            comboBox7.ValueMember = "id";

            comboBox3.DataSource = nalazRepo.ReadAllBio();
            comboBox3.DisplayMember = "nalaz";
            comboBox3.ValueMember = "id";


            papGridView.AutoGenerateColumns = false;
            hpvGridView.AutoGenerateColumns = false;
            bioGridView.AutoGenerateColumns = false;
            hirGridView.AutoGenerateColumns = false;
            revGridView.AutoGenerateColumns = false;

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

            if (comboBox8.Text == "")
            {
                MessageBox.Show("Odaberite lekara!");
            }
            else if (comboBox7.Text == "")
            {
                MessageBox.Show("Odaberite nalaz!");
            }
            else
            {
                var temp = revizije.addRevizija(_idPacijent, dateTimePicker1.Value.ToString("yyyy-MM-dd"), int.Parse(comboBox7.SelectedValue.ToString()), int.Parse(comboBox8.SelectedValue.ToString()));

                if (temp > 0)
                {
                    revGridView.DataSource = revizije.getRevizijaByPacijentId(_idPacijent);

                }
                else
                {
                    MessageBox.Show("Došlo je do greške!");
                }
            }


        }

        private void NovHPVBtn_Click(object sender, EventArgs e)
        {

            if (comboBox5.Text == "")
            {
                MessageBox.Show("Odaberite lekara!");
            }
            else if (comboBox6.Text == "")
            {
                MessageBox.Show("Odaberite nalaz!");
            }
            else
            {
                var temp = hpvRepo.addHpv(_idPacijent, dateTimePicker1.Value.ToString("yyyy-MM-dd"), int.Parse(comboBox6.SelectedValue.ToString()), int.Parse(comboBox5.SelectedValue.ToString()));

                if (temp > 0)
                {
                    hpvGridView.DataSource = hpvRepo.getHpvByPacijentId(_idPacijent);

                }
                else
                {
                    MessageBox.Show("Došlo je do greške!");
                }
            }


        }

        private void NovaBiopsijaBtn_Click(object sender, EventArgs e)
        {
            if (comboBox4.Text == "")
            {
                MessageBox.Show("Odaberite lekara!");
            }
            else if (comboBox3.Text == "")
            {
                MessageBox.Show("Odaberite nalaz!");
            }
            else
            {
                var temp = biopsije.addBiopsija(_idPacijent, datePickerBiopsija.Value.ToString("yyyy-MM-dd"), int.Parse(comboBox3.SelectedValue.ToString()), int.Parse(comboBox4.SelectedValue.ToString()));

                if (temp > 0)
                {
                    bioGridView.DataSource = biopsije.getBiopsjaByPacientId(_idPacijent);

                }
                else
                {
                    MessageBox.Show("Došlo je do greške!");
                }
            }


        }

        private void Sacuvaj_Click(object sender, EventArgs e)
        {

            if (comboBox2.Text == "")
            {
                MessageBox.Show("Odaberite lekara!");
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Odaberite nalaz!");
            }
            else
            {

                var temp = papRepo.addPap(_idPacijent, dateTimePicker4.Value.ToString("yyyy-MM-dd"), int.Parse(comboBox1.SelectedValue.ToString()), int.Parse(comboBox2.SelectedValue.ToString()), ploctxt.Text);

                if (temp > 0)
                {
                    papGridView.DataSource = papRepo.getPapByPacijentId(_idPacijent);

                }
                else
                {
                    MessageBox.Show("Došlo je do greške!");
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}