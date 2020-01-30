using Citologija.Model;
using Citologija.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Citologija
{
    public partial class Izvestaji : Form
    {
        public Izvestaji()
        {
            InitializeComponent();
            datumOdPicker.Format = DateTimePickerFormat.Custom;
            datumOdPicker.CustomFormat = "dd.MM.yyyy";
            datumDoPicker.Format = DateTimePickerFormat.Custom;
            datumDoPicker.CustomFormat = "dd.MM.yyyy";
            label7.Visible = false;

        }

        PacijentRepository pacijentRepo = new PacijentRepository();



        private void Izvestaji_Load(object sender, System.EventArgs e)
        {

        }

        public List<Pacijent> papaPoLekaruInalazu(string lekar, string nalaz)
        {
            var datumOd = DateTime.Parse(datumOdPicker.Value.ToString());
            var datumDo = DateTime.Parse(datumDoPicker.Value.ToString());
           

            var allPac = pacijentRepo.getAllFull();

            var pacijenti = pacijentRepo.getAllFull()
                .Where(p => p.pap.Any(l => l.lekar == lekar && l.nalaz_cito == nalaz && (DateTime.Parse(l.Datum_pap) >= datumOd && DateTime.Parse(l.Datum_pap) <= datumDo)));


            return pacijenti.ToList();

            
        }


        public List<Pacijent> papaPoLekaruIHpv(string lekar, string nalaz)
        {
            var datumOd = DateTime.Parse(datumOdPicker.Value.ToString());
            var datumDo = DateTime.Parse(datumDoPicker.Value.ToString());


            var allPac = pacijentRepo.getAllFull().Where(p=>p.pap.Any(l=>l.lekar==lekar) && p.hpv.Any());

            var pacijenti = allPac.Where(p => p.hpv.Any(l=> l.nalaz_hpv == nalaz && (DateTime.Parse(l.Datum_hpv) >= datumOd && DateTime.Parse(l.Datum_hpv) <= datumDo)));


            return pacijenti.ToList();


        }

        public List<Pacijent> papaPoLekaruBiopsija(string lekar, string nalaz)
        {
            var datumOd = DateTime.Parse(datumOdPicker.Value.ToString());
            var datumDo = DateTime.Parse(datumDoPicker.Value.ToString());


            var allPac = pacijentRepo.getAllFull().Where(p => p.pap.Any(l => l.lekar == lekar) && p.biopsija.Any());

            var pacijenti = allPac.Where(p => p.biopsija.Any(l => l.nalaz_bio == nalaz && (DateTime.Parse(l.Datum_bio) >= datumOd && DateTime.Parse(l.Datum_bio) <= datumDo)));


            return pacijenti.ToList();


        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            var pacijenti = papaPoLekaruInalazu(comboBoxLekar.Text, comboBox3.Text);
            dataGridView1.DataSource = pacijenti;
            label7.Visible = true;
            label7.Text = (pacijenti.Count).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var pacijenti = papaPoLekaruIHpv(comboBoxLekar.Text, comboBoxHPV.Text);

            dataGridView1.DataSource = pacijenti;
            label7.Visible = true;
            label7.Text = (pacijenti.Count).ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var pacijenti = papaPoLekaruBiopsija(comboBoxLekar.Text, comboBoxBio.Text);

            dataGridView1.DataSource = pacijenti;
            label7.Visible = true;
            label7.Text = (pacijenti.Count).ToString();
        }
    }
}
