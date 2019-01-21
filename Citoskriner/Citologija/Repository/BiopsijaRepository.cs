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
    class BiopsijaRepository
    {
        public int addBiopsija(int id_pacijent, string datum_bio, string nalaz_bio)
        {
            string sql = "INSERT INTO biopsija (id_pacijent, datum_bio,nalaz_bio,aktivan) Values (@id_pacijent,@datum_bio,@nalaz_bio,'" + 1 + "');";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Execute(sql, new { id_pacijent, datum_bio, nalaz_bio });
                return affectedRows;
            }
        }

        public IEnumerable<Biopsija> getBiopsjaByPacientId(int id)
        {
            string sql = "SELECT id, id_pacijent,datum_bio, nalaz_bio FROM biopsija WHERE id_pacijent = @id AND aktivan=1;";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var biopsijaList = db.Query<Biopsija>(sql, new { id }).ToList();

                return biopsijaList;
            }
        }
    }
}
