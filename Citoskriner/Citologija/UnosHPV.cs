using Citologija.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Citologija
{
    public partial class UnosHPV : Form
    {
        HpvRepository hpvRepo = new HpvRepository();
        private int _idPacijent { get; set; }
        public UnosHPV(int idPacijent)
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var temp = hpvRepo.addHpv(_idPacijent, dateTimePicker1.Value.ToString("yyyy-MM-dd"), richTextBox1.Text);
            if (temp > 0)
            {
                MessageBox.Show("Podaci uspešno sačuvani");
            }
            else
            {
                MessageBox.Show("Došlo je do greške!");
            }
            this.Close();
        }
    }
}
