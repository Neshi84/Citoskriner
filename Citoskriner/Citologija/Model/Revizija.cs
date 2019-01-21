using System;

namespace Citologija.Model
{
    internal class Revizija
    {
        public int id { get; set; }
        public int id_pacijent { get; set; }
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

        
    }
}