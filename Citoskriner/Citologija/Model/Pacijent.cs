using System.Collections.Generic;

namespace Citologija.Model
{
    internal class Pacijent
    {
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string jmbg { get; set; }
        public List<Biopsija> biopsija = new List<Biopsija>();
        public List<Hir_intervencije> hir_intervencije = new List<Hir_intervencije>();
        public List<Hpv> hpv = new List<Hpv>();
        public List<Pap> pap = new List<Pap>();
        public List<Revizija> revizija = new List<Revizija>();
        
    }
}