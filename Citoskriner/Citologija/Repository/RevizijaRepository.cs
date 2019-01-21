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
    class RevizijaRepository
    {
        public IEnumerable<Revizija> getRevizijaByPacijentId(int id)
        {
            string sql = "SELECT id, id_pacijent,datum_rev, revizija FROM revizija WHERE id_pacijent = @id AND aktivan=1;";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var revizijaList = db.Query<Revizija>(sql, new { id }).ToList();

                return revizijaList;
            }
        }

        public int addRevizija(int id_pacijent, string datum_rev, string revizija)
        {
            string sql = "INSERT INTO revizija(id_pacijent ,datum_rev,revizija,aktivan) Values (@id_pacijent,@datum_rev,@revizija,'" + 1 + "');";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Execute(sql, new { id_pacijent, datum_rev, revizija });
                return affectedRows;
            }
        }
    }
}
