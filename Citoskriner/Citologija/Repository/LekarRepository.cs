using Citologija.Model;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace Citologija.Repository
{
    internal class LekarRepository
    {
        public IEnumerable<Lekar> ReadAll()
        {
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var lekar = db.Query<Lekar>("SELECT id,ImePrezime FROM Lekar");

                return lekar;
            }
        }

        public int addLekar(Lekar lekar)
        {
            string sql = "INSERT INTO podaci (ImePrezime) Values (@imePrezime); " +
                        " SELECT last_insert_rowid()";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Query<int>(sql, new { lekar.ImePrezime });
                return affectedRows.Single();
            }
        }
    }
}