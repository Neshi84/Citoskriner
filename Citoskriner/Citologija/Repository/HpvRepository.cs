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
    class HpvRepository
    {
        public int addHpv(int id_pacijent, string datum_hpv, string nalaz_hpv)
        {
            string sql = "INSERT INTO hpv (id_pacijent, datum_hpv,nalaz_hpv,aktivan) Values (@id_pacijent,@datum_hpv,@nalaz_hpv,'" + 1 + "');";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Execute(sql, new { id_pacijent, datum_hpv, nalaz_hpv });
                return affectedRows;
            }
        }

        public IEnumerable<Hpv> getHpvByPacijentId(int id)
        {
            string sql = "SELECT id, id_pacijent,datum_hpv,nalaz_hpv FROM hpv WHERE id_pacijent = @id AND aktivan=1;";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var hpvList = db.Query<Hpv>(sql, new { id }).ToList();

                return hpvList;
            }
        }
    }
}
