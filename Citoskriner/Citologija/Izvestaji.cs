﻿using Citologija.Repository;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Citologija
{
    public partial class Izvestaji : Form
    {
        private PacijentRepository pacijentRepo = new PacijentRepository();
        private LekarRepository lekarRepo = new LekarRepository();
        private NalazRepository nalazRepo = new NalazRepository();

        public Izvestaji()
        {
            InitializeComponent();
            datumOdPicker.Format = DateTimePickerFormat.Custom;
            datumOdPicker.CustomFormat = "dd.MM.yyyy";
            datumDoPicker.Format = DateTimePickerFormat.Custom;
            datumDoPicker.CustomFormat = "dd.MM.yyyy";
            label7.Visible = false;

            comboBoxLekar.DataSource = lekarRepo.ReadAll();
            comboBoxLekar.DisplayMember = "imePrezime";
            comboBoxLekar.ValueMember = "id";

            comboBox3.DataSource = nalazRepo.ReadAllCito();
            comboBox3.DisplayMember = "nalaz";
            comboBox3.ValueMember = "id";

            comboBoxBio.DataSource = nalazRepo.ReadAllBio();
            comboBoxBio.DisplayMember = "nalaz";
            comboBoxBio.ValueMember = "id";

            comboBox1.DataSource = nalazRepo.ReadAllCito();
            comboBox1.DisplayMember = "nalaz";
            comboBox1.ValueMember = "id";

            comboBoxHPV.DataSource = nalazRepo.ReadAllHpv();
            comboBoxHPV.DisplayMember = "nalaz";
            comboBoxHPV.ValueMember = "id";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var datumOd = DateTime.Parse(datumOdPicker.Text).ToString("yyyy-MM-dd");
            var datumDo = DateTime.Parse(datumDoPicker.Text).ToString("yyyy-MM-dd");

            var pacijenti = pacijentRepo.getPacijentBiopsija(datumOd, datumDo, int.Parse(comboBoxLekar.SelectedValue.ToString()), int.Parse(comboBoxBio.SelectedValue.ToString())).ToList();
            dataGridView1.DataSource = pacijenti;
            label7.Visible = true;
            label7.Text = (pacijenti.Count).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var datumOd = DateTime.Parse(datumOdPicker.Text).ToString("yyyy-MM-dd");
            var datumDo = DateTime.Parse(datumDoPicker.Text).ToString("yyyy-MM-dd");

            var pacijenti = pacijentRepo.getPacijentHpv(datumOd, datumDo, int.Parse(comboBoxLekar.SelectedValue.ToString()), int.Parse(comboBoxHPV.SelectedValue.ToString())).ToList();
            dataGridView1.DataSource = pacijenti;
            label7.Visible = true;
            label7.Text = (pacijenti.Count).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var datumOd = DateTime.Parse(datumOdPicker.Text).ToString("yyyy-MM-dd");
            var datumDo = DateTime.Parse(datumDoPicker.Text).ToString("yyyy-MM-dd");

            var pacijenti = pacijentRepo.getPacijentPap(datumOd, datumDo, int.Parse(comboBoxLekar.SelectedValue.ToString()), int.Parse(comboBox3.SelectedValue.ToString())).ToList();
            dataGridView1.DataSource = pacijenti;
            label7.Visible = true;
            label7.Text = (pacijenti.Count).ToString();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var unos_podataka = new unosPodataka((int)(dataGridView1.CurrentRow.Cells["id"].Value));

                unos_podataka.Show();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var datumOd = DateTime.Parse(datumOdPicker.Text).ToString("yyyy-MM-dd");
            var datumDo = DateTime.Parse(datumDoPicker.Text).ToString("yyyy-MM-dd");

            var pacijenti = pacijentRepo.getPacijentRevizija(datumOd, datumDo, int.Parse(comboBoxLekar.SelectedValue.ToString()), int.Parse(comboBox1.SelectedValue.ToString())).ToList();
            dataGridView1.DataSource = pacijenti;
            label7.Visible = true;
            label7.Text = (pacijenti.Count).ToString();
        }
    }
}