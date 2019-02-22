using Citologija.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace Citologija.Repository
{
    class PacijentRepository
    {
        BiopsijaRepository biopsije = new BiopsijaRepository();       
        PapRepository papRepo = new PapRepository();
        HpvRepository hpvRepo = new HpvRepository();
        HirIntervencijeRepository hirRepo = new HirIntervencijeRepository();
        RevizijaRepository revizije = new RevizijaRepository();

        public IEnumerable<Pacijent> getAllFull()
        {
          IEnumerable<Pacijent> pacijenti =ReadAll();

            foreach(Pacijent pacijent in pacijenti)
            {
                pacijent.biopsija = biopsije.getBiopsjaByPacientId(pacijent.id).ToList();
                pacijent.hpv = hpvRepo.getHpvByPacijentId(pacijent.id).ToList();
                pacijent.hir_intervencije = hirRepo.getHirByPacijentId(pacijent.id).ToList();
                pacijent.pap = papRepo.getPapByPacijentId(pacijent.id).ToList();
                pacijent.revizija = revizije.getRevizijaByPacijentId(pacijent.id).ToList();
            }

            return pacijenti;
        }

        public IEnumerable<Pacijent> ReadAll()
        {
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var test = db.Query<Pacijent>("SELECT id,ime ,prezime,jmbg FROM podaci WHERE aktivan = 1 ");

                return test;
            }
        }

        public int addPacijent(Pacijent pacijent)
        {
            string sql = "INSERT INTO podaci (ime, prezime,jmbg,aktivan) Values (@ime,@prezime,@jmbg,'" + 1 + "'); " +
                        " SELECT last_insert_rowid()";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Query<int>(sql, new { pacijent.ime, pacijent.prezime, pacijent.jmbg });
                return affectedRows.Single();
            }
        }

        public int deletePacijent(int id)
        {
            string sql = "UPDATE podaci SET aktivan = 0 WHERE id = @id;";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Execute(sql, new { id });
                return affectedRows;
            }

        }

        public Pacijent getPacijentByJMBG(string jmbg)
        {
            string sql = "SELECT * FROM podaci WHERE jmbg=@jmbg ;";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var pacijentList = db.Query<Pacijent>(sql, new { jmbg });

                
                return pacijentList.FirstOrDefault();
            }
        }

        public Pacijent getPacijentById(int id)
        {
            string sql = "SELECT * FROM podaci WHERE id = @id AND aktivan=1;";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var pacijentList = db.Query<Pacijent>(sql, new { id });

                return pacijentList.First();
            }
        }

    }
}
