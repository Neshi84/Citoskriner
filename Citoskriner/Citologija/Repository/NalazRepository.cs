using Citologija.Model;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace Citologija.Repository
{
    class NalazRepository
    {
        public IEnumerable<Nalaz> getHpvNalazById(int id)
        {
            string sql = "SELECT id, nalaz FROM hpv_nalaz WHERE id = @id;";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var hpvList = db.Query<Nalaz>(sql, new { id }).ToList();

                return hpvList;
            }
        }

        public IEnumerable<Nalaz> ReadAllHpv()
        {
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var test = db.Query<Nalaz>("SELECT id,nalaz FROM hpv_nalaz ");

                return test;
            }
        }


        public IEnumerable<Nalaz> getBioNalazById(int id)
        {
            string sql = "SELECT id, nalaz FROM nalaz_bio WHERE id = @id;";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var nalaz = db.Query<Nalaz>(sql, new { id }).ToList();

                return nalaz;
            }
        }

        public IEnumerable<Nalaz> ReadAllBio()
        {
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var test = db.Query<Nalaz>("SELECT id,nalaz FROM nalaz_bio ");

                return test;
            }
        }


        public IEnumerable<Nalaz> getCitoNalazById(int id)
        {
            string sql = "SELECT id, nalaz FROM nalaz_cito WHERE id = @id;";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var nalaz = db.Query<Nalaz>(sql, new { id }).ToList();

                return nalaz;
            }
        }

        public IEnumerable<Nalaz> ReadAllCito()
        {
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var test = db.Query<Nalaz>("SELECT id,nalaz FROM nalaz_cito ");

                return test;
            }
        }

    }
}
