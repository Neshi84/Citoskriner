using System;

namespace Citologija.Model
{
    public class Pap
    {
        public int id { get; set; }
        public int id_pacijent { get; set; }
        public string lekar { get; set; }
        public string broj_prep { get; set; }
        private string datum_pap;

        public string Datum_pap
        {
            get
            {
                DateTime vreme = DateTime.Parse(datum_pap);

                datum_pap = vreme.ToString("dd.MM.yyyy");
                return datum_pap;
            }
            set { datum_pap = value; }
        }

        public string nalaz_cito { get; set; }
        
    }
}