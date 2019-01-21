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
    class PapRepository
    {
        public IEnumerable<Pap> getPapByPacijentId(int id)
        {
            string sql = "SELECT id,id_pacijent,broj_prep,datum_pap, nalaz_cito, lekar FROM pap WHERE id_pacijent = @id AND aktivan=1;";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var papList = db.Query<Pap>(sql, new { id }).ToList();

                return papList;
            }
        }

        public int addPap(int id_pacijent, string datum_pap, string nalaz_cito, string lekar, string br_prep)
        {
            string sql = "INSERT INTO pap (id_pacijent, datum_pap,nalaz_cito,lekar,broj_prep,aktivan) Values (@id_pacijent,@datum_pap,@nalaz_cito,@lekar,@br_prep,'" + 1 + "');";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Execute(sql, new { id_pacijent, datum_pap, nalaz_cito, lekar, br_prep });
                return affectedRows;
            }
        }
    }
}
