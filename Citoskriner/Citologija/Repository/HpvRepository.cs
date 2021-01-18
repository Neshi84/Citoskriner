using Citologija.Model;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace Citologija.Repository
{
    internal class HpvRepository
    {
        public int addHpv(int id_pacijent, string datum_hpv, int idNalaz, int idLekar)
        {
            string sql = "INSERT INTO hpv (id_pacijent, datum_hpv,id_nalaz,id_lekar,aktivan) Values (@id_pacijent,@datum_hpv,@idNalaz,@idLekar, '" + 1 + "');";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Execute(sql, new { id_pacijent, datum_hpv, idNalaz, idLekar });
                return affectedRows;
            }
        }

        public IEnumerable<Hpv> getHpvByPacijentId(int id)
        {
            string sql = "SELECT h.id, h.id_pacijent,h.datum_hpv,n.nalaz,h.id_lekar,l.ImePrezime AS Lekar FROM hpv AS h " +
                "INNER JOIN Lekar AS l ON h.id_lekar=l.id " +
                "INNER JOIN hpv_nalaz AS n ON h.id_nalaz=n.id " +
                "WHERE id_pacijent = @id AND h.aktivan=1;";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var hpvList = db.Query<Hpv>(sql, new { id }).ToList();

                return hpvList;
            }
        }
    }
}