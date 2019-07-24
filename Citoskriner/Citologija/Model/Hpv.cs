using System;

namespace Citologija.Model
{
    public class Hpv
    {
        public int id { get; set; }
        public int id_pacijent { get; set; }
        private string datum_hpv;

        public string Datum_hpv
        {
            get
            {
                DateTime vreme = DateTime.Parse(datum_hpv);

                datum_hpv = vreme.ToString("dd.MM.yyyy");
                return datum_hpv;
            }
            set { datum_hpv = value; }
        }

        public string nalaz_hpv { get; set; }
        public string aktivan { get; set; }
    }
}