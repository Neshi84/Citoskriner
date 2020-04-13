using Citologija.Repository;
using System;
using System.Windows.Forms;

namespace Citologija
{
    public partial class UnosBiopsija : Form
    {
        BiopsijaRepository biopsije = new BiopsijaRepository();
        private int _idPacijent { get; set; }
        public UnosBiopsija(int idPacijent)
        {
            _idPacijent = idPacijent;
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var temp = biopsije.addBiopsija(_idPacijent, dateTimePicker1.Value.ToString("yyyy-MM-dd"), richTextBox1.Text);

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
