using System;

namespace Citologija.Model
{
    internal class PacijentBiopsija : Pacijent
    {
        private string datum;

        public string Datum
        {
            get
            {
                DateTime vreme = DateTime.Parse(datum);

                datum = vreme.ToString("dd.MM.yyyy");
                return datum;
            }
            set { datum = value; }
        }

        public string nalaz { get; set; }

        public string broj_prep { get; set; }

        public string Lekar { get; set; }
    }
}