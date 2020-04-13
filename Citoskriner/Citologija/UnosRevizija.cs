using Citologija.Repository;
using System;
using System.Windows.Forms;

namespace Citologija
{
    public partial class UnosRevizija : Form
    {
        RevizijaRepository revizije = new RevizijaRepository();
        private int _idPacijent { get; set; }
        public UnosRevizija(int idPacijent)
        {
            _idPacijent = idPacijent;
            InitializeComponent();

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var temp = revizije.addRevizija(_idPacijent, dateTimePicker1.Value.ToString("yyyy-MM-dd"), richTextBox1.Text);

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
