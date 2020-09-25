using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace Citologija.Model
{
    internal class HirIntervencijeRepository
    {
        public IEnumerable<Hir_intervencije> getHirByPacijentId(int id)
        {
            string sql = "SELECT id, id_pacijent, intervencija FROM hir_intervencije WHERE id_pacijent = @id AND aktivan=1;";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var hirList = db.Query<Hir_intervencije>(sql, new { id }).ToList();

                return hirList;
            }
        }

        public int addHir(int id_pacijent, string intervencija)
        {
            string sql = "INSERT INTO hir_intervencije (id_pacijent ,intervencija,aktivan) Values (@id_pacijent,@intervencija,'" + 1 + "');";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Execute(sql, new { id_pacijent, intervencija });
                return affectedRows;
            }
        }
    }
}