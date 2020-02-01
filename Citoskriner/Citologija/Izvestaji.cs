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

        

        private void button3_Click(object sender, EventArgs e)
        {
            var datumOd = DateTime.Parse(datumOdPicker.Text).ToString("yyyy-MM-dd");
            var datumDo = DateTime.Parse(datumDoPicker.Text).ToString("yyyy-MM-dd");

            var pacijenti = pacijentRepo.getPacijentBiopsija(datumOd, datumDo, comboBoxLekar.Text, comboBoxBio.Text).ToList();
            dataGridView1.DataSource = pacijenti;
            label7.Visible = true;
            label7.Text = (pacijenti.Count).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var datumOd = DateTime.Parse(datumOdPicker.Text).ToString("yyyy-MM-dd");
            var datumDo = DateTime.Parse(datumDoPicker.Text).ToString("yyyy-MM-dd");

            var pacijenti = pacijentRepo.getPacijentHpv(datumOd, datumDo, comboBoxLekar.Text, comboBoxHPV.Text).ToList();
            dataGridView1.DataSource = pacijenti;
            label7.Visible = true;
            label7.Text = (pacijenti.Count).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var datumOd = DateTime.Parse(datumOdPicker.Text).ToString("yyyy-MM-dd");
            var datumDo = DateTime.Parse(datumDoPicker.Text).ToString("yyyy-MM-dd");

            var pacijenti = pacijentRepo.getPacijentPap(datumOd, datumDo, comboBoxLekar.Text, comboBox3.Text).ToList();
            dataGridView1.DataSource = pacijenti;
            label7.Visible = true;
            label7.Text = (pacijenti.Count).ToString();
        }
    }
}
