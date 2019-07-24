using Citologija.Model;
using Citologija.Repository;
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
        }

        PacijentRepository pacijentRepo = new PacijentRepository();

       

        private void Izvestaji_Load(object sender, System.EventArgs e)
        {



            


        }

        public List<Pacijent> papaPoLekaruInalazu(string lekar,string nalaz)
        {
            var allPac = pacijentRepo.getAllFull();

            var pacijenti = pacijentRepo.getAllFull()
                .Where(p => p.pap.Any(l => l.lekar == lekar && l.nalaz_cito == nalaz));

            return pacijenti.ToList();
        }

        private void Button1_Click(object sender, System.EventArgs e)
        {
            dataGridView1.DataSource = papaPoLekaruInalazu(comboBox2.Text, comboBox3.Text);
        }
    }
}
