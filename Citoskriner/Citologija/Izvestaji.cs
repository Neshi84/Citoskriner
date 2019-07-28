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

        private void Button1_Click(object sender, System.EventArgs e)
        {
            dataGridView1.DataSource = papaPoLekaruInalazu(comboBox2.Text, comboBox3.Text);
        }
    }
}
