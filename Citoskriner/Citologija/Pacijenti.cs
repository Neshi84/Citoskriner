using System;

namespace Citologija
{
    internal class Pacijenti
    {
        public int ID { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string jmbg { get; set; }
        public string lekar { get; set; }
        public string broj_prep { get; set; }
        private string datum_bio;

        public string Datum_bio
        {
            get
            {
                DateTime vreme = DateTime.Parse(datum_bio);

                datum_bio = vreme.ToString("dd.MM.yyyy");
                return datum_bio;
            }
            set { datum_bio = value; }
        }

        public string nalaz_bio { get; set; }
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
        public string hir_int { get; set; }
        public string revizija { get; set; }
        private string datum_rev;

        public string Datum_rev
        {
            get
            {
                DateTime vreme = DateTime.Parse(datum_rev);

                datum_rev = vreme.ToString("dd.MM.yyyy");
                return datum_rev;
            }
            set { datum_rev = value; }
        }

        public string aktivan { get; set; }
    }
}