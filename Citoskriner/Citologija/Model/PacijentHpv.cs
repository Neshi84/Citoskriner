using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Citologija.Model
{
    class PacijentHpv:Pacijent
    {
               
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

        public string broj_prep { get; set; }

        public string lekar { get; set; }
    }
}
