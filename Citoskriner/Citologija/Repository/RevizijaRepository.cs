using Citologija.Model;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace Citologija.Repository
{
    internal class RevizijaRepository
    {
        public IEnumerable<Revizija> getRevizijaByPacijentId(int id)
        {
            string sql = "SELECT r.id, r.id_pacijent,r.datum_rev, n.nalaz AS nalaz, l.ImePrezime AS Lekar " +
                         "FROM revizija AS r " +
                         "INNER JOIN Lekar AS l ON r.id_lekar=l.id  " +
                         "INNER JOIN nalaz_cito AS n ON r.id_nalaz=n.id " +
                         "WHERE id_pacijent = @id " +
                         "AND r.aktivan=1;";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var revizijaList = db.Query<Revizija>(sql, new { id }).ToList();

                return revizijaList;
            }
        }

        public int addRevizija(int id_pacijent, string datum_rev, int idNalaz, int idLekar)
        {
            string sql = "INSERT INTO revizija(id_pacijent ,datum_rev,id_nalaz,id_lekar,aktivan) Values (@id_pacijent,@datum_rev,@idNalaz,@idLekar,'" + 1 + "');";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Execute(sql, new { id_pacijent, datum_rev, idNalaz, idLekar });
                return affectedRows;
            }
        }
    }
}