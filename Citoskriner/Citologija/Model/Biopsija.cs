using System;

namespace Citologija.Model
{
    internal class Biopsija
    {
        public int id { get; set; }
        public int id_pacijent { get; set; }
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
        
    }
}