using Citologija.Model;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace Citologija.Repository
{
    class HpvRepository
    {
        public int addHpv(int id_pacijent, string datum_hpv, string nalaz_hpv, int idLekar)
        {
            string sql = "INSERT INTO hpv (id_pacijent, datum_hpv,nalaz_hpv,id_lekar,aktivan) Values (@id_pacijent,@datum_hpv,@nalaz_hpv,@idLekar, '" + 1 + "');";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Execute(sql, new { id_pacijent, datum_hpv, nalaz_hpv, idLekar });
                return affectedRows;
            }
        }

        public IEnumerable<Hpv> getHpvByPacijentId(int id)
        {
            string sql = "SELECT h.id, h.id_pacijent,h.datum_hpv,h.nalaz_hpv,h.id_lekar,l.ImePrezime AS Lekar FROM hpv AS h INNER JOIN Lekar AS l ON h.id_lekar=l.id WHERE id_pacijent = @id AND aktivan=1;";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var hpvList = db.Query<Hpv>(sql, new { id }).ToList();

                return hpvList;
            }
        }
    }
}
