using Citologija.Model;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace Citologija.Repository
{
    public class NalazRepository
    {
        public IEnumerable<Nalaz> getHpvNalazById(int id)
        {
            string sql = "SELECT id, nalaz FROM hpv_nalaz WHERE id = @id AND aktivan = 1;";

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
                var test = db.Query<Nalaz>("SELECT id,nalaz FROM hpv_nalaz WHERE aktivan = 1");

                return test;
            }
        }

        public int addHpv(string nalaz)
        {
            string sql = "INSERT INTO hpv_nalaz(nalaz) Values (@nalaz);";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Execute(sql, new { nalaz });
                return affectedRows;
            }
        }

        public int updateHpv(Nalaz nalaz)
        {
            string sql = "UPDATE hpv_nalaz SET nalaz = @nalaz WHERE id=@id;";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Execute(sql, new { nalaz.nalaz, nalaz.id });
                return affectedRows;
            }
        }

        public int deleteHpv(int id)
        {
            string sql = "UPDATE hpv_nalaz SET aktivan = 0 WHERE id=@id;";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Execute(sql, new { id });
                return affectedRows;
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
                var test = db.Query<Nalaz>("SELECT id,nalaz FROM nalaz_bio WHERE aktivan = 1 ");

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
                var test = db.Query<Nalaz>("SELECT id,nalaz FROM nalaz_cito WHERE aktivan = 1 ");

                return test;
            }
        }

        public int addBiopsija(string nalaz)
        {
            string sql = "INSERT INTO nalaz_bio(nalaz) Values (@nalaz);";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Execute(sql, new { nalaz });
                return affectedRows;
            }
        }

        public int updateBiopsija(Nalaz nalaz)
        {
            string sql = "UPDATE nalaz_bio SET nalaz = @nalaz WHERE id=@id;";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Execute(sql, new { nalaz.nalaz, nalaz.id });
                return affectedRows;
            }
        }

        public int deleteBiopsija(int id)
        {
            string sql = "UPDATE nalaz_bio SET aktivan = 0  WHERE id=@id;";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Execute(sql, new { id });
                return affectedRows;
            }
        }

        public int addCito(string nalaz)
        {
            string sql = "INSERT INTO nalaz_cito(nalaz) Values (@nalaz);";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Execute(sql, new { nalaz });
                return affectedRows;
            }
        }

        public int updateCito(Nalaz nalaz)
        {
            string sql = "UPDATE nalaz_cito SET nalaz = @nalaz WHERE id=@id;";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Execute(sql, new { nalaz.nalaz, nalaz.id });
                return affectedRows;
            }
        }

        public int deleteCito(int id)
        {
            string sql = "UPDATE nalaz_cito SET aktivan = 0 WHERE id=@id;";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Execute(sql, new { id });
                return affectedRows;
            }
        }
    }
}