using Citologija.Model;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace Citologija.Repository
{
    internal class BiopsijaRepository
    {
        public int addBiopsija(int id_pacijent, string datum_bio, int idNalaz, int idLekar)
        {
            string sql = "INSERT INTO biopsija (id_pacijent, datum_bio,id_nalaz,id_lekar,aktivan) VALUES (@id_pacijent,@datum_bio,@idNalaz,@idLekar,'" + 1 + "');";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Execute(sql, new { id_pacijent, datum_bio, idNalaz, idLekar });
                return affectedRows;
            }
        }

        public IEnumerable<Biopsija> getBiopsjaByPacientId(int id)
        {
            string sql = "SELECT b.id, b.id_pacijent,b.datum_bio, n.nalaz, l.ImePrezime AS Lekar FROM biopsija AS b " +
                         "INNER JOIN Lekar as l ON b.id_lekar = l.id  " +
                         "INNER JOIN nalaz_bio as n ON b.id_nalaz = n.id  " +
                         "WHERE id_pacijent = @id AND aktivan=1;";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var biopsijaList = db.Query<Biopsija>(sql, new { id }).ToList();

                return biopsijaList;
            }
        }
    }
}