using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Citologija.Model
{
    class PacijentBiopsija: Pacijent
    {
       
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

        public string broj_prep { get; set; }

        public string lekar { get; set; }
    }
}
