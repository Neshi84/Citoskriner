using Citologija.Model;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace Citologija.Repository
{
    class PapRepository
    {
        public IEnumerable<Pap> getPapByPacijentId(int id)
        {
            string sql = "SELECT p.id,p.id_pacijent,p.broj_prep,p.datum_pap, n.nalaz, l.ImePrezime AS Lekar FROM pap AS p " +
                         "INNER JOIN Lekar AS l ON p.id_lekar= l.id " +
                         "INNER JOIN nalaz_cito AS n ON p.id_nalaz= n.id " +
                         "WHERE id_pacijent = @id AND aktivan=1;";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var papList = db.Query<Pap>(sql, new { id }).ToList();

                return papList;
            }
        }

        public int addPap(int id_pacijent, string datum_pap, int idNalaz, int idLekar, string br_prep)
        {
            string sql = "INSERT INTO pap (id_pacijent, datum_pap,id_nalaz,id_lekar,broj_prep,aktivan) Values (@id_pacijent,@datum_pap,@idNalaz,@idLekar,@br_prep,'" + 1 + "');";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Execute(sql, new { id_pacijent, datum_pap, idNalaz, idLekar, br_prep });
                return affectedRows;
            }
        }
    }
}
