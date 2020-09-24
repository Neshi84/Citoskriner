using Citologija.Model;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace Citologija.Repository
{
    class PacijentRepository
    {

        public IEnumerable<Pacijent> ReadAll()
        {
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var test = db.Query<Pacijent>("SELECT id,ime ,prezime,jmbg FROM podaci WHERE aktivan = 1 ");

                return test;
            }
        }

        public int addPacijent(Pacijent pacijent)
        {
            string sql = "INSERT INTO podaci (ime, prezime,jmbg,aktivan) Values (@ime,@prezime,@jmbg,'" + 1 + "'); " +
                        " SELECT last_insert_rowid()";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Query<int>(sql, new { pacijent.ime, pacijent.prezime, pacijent.jmbg });
                return affectedRows.Single();
            }
        }

        public int deletePacijent(int id)
        {
            string sql = "UPDATE podaci SET aktivan = 0 WHERE id = @id;";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Execute(sql, new { id });
                return affectedRows;
            }

        }

        public IEnumerable<Pacijent> searchPacijent(string kriterijum)
        {
            string sql = "SELECT * FROM podaci WHERE (jmbg LIKE  @kriterijum  OR ime LIKE  @kriterijum OR prezime LIKE  @kriterijum)  AND aktivan=1 ;";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var pacijentList = db.Query<Pacijent>(sql, new { kriterijum = "%" + kriterijum + "%" });


                return pacijentList;
            }
        }


        public Pacijent getPacijentByJMBG(string jmbg)
        {
            string sql = "SELECT * FROM podaci WHERE jmbg=@jmbg AND aktivan=1 ;";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var pacijentList = db.Query<Pacijent>(sql, new { jmbg });


                return pacijentList.FirstOrDefault();
            }
        }

        public Pacijent getPacijentById(int id)
        {
            string sql = "SELECT * FROM podaci WHERE id = @id AND aktivan=1;";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var pacijentList = db.Query<Pacijent>(sql, new { id });

                return pacijentList.First();
            }
        }

        public IEnumerable<PacijentBiopsija> getPacijentBiopsija(string datumOd, string datumDo, int idLekar, int idNalaz)
        {
            string sql = "SELECT p.id, p.ime,p.prezime,p.jmbg, l.ImePrezime AS Lekar,b.datum_bio AS Datum,n.nalaz AS nalaz FROM podaci AS p " +
                         "INNER JOIN biopsija AS b ON p.id = b.id_pacijent " +
                         "INNER JOIN nalaz_bio AS n ON b.id_nalaz = n.id " +
                         "INNER JOIN Lekar AS l ON b.id_lekar=l.id " +
                         "WHERE L.id =@idLekar " +
                         "AND datum_bio BETWEEN date(@datumOd) AND date(@datumDo) " +
                         "AND b.id_nalaz =@idNalaz " +
                         "AND p.aktivan= 1 " +
                         "AND b.aktivan = 1 ";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var pacijentList = db.Query<PacijentBiopsija>(sql, new { datumOd, datumDo, idLekar, idNalaz });

                return pacijentList;
            }
        }


        public IEnumerable<PacijentHpv> getPacijentHpv(string datumOd, string datumDo, int idLekar, int idNalaz)
        {
            string sql = "SELECT p.id, p.ime,p.prezime,p.jmbg,l.ImePrezime AS Lekar, h.datum_hpv AS Datum,n.nalaz AS nalaz FROM podaci AS p " +
                         "INNER JOIN hpv AS h ON p.id = h.id_pacijent " +
                         "INNER JOIN hpv_nalaz AS n ON h.id_nalaz = n.id " +
                         "INNER JOIN Lekar AS l ON h.id_lekar=l.id " +
                         "WHERE l.id =@idLekar " +
                         "AND datum_hpv BETWEEN date(@datumOd) AND date(@datumDo) " +
                         "AND h.id_nalaz = @idNalaz " +
                         "AND p.aktivan=1 " +
                         "AND h.aktivan = 1 ";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var pacijentList = db.Query<PacijentHpv>(sql, new { datumOd, datumDo, idLekar, idNalaz });

                return pacijentList;
            }
        }

        public IEnumerable<PacijentPap> getPacijentPap(string datumOd, string datumDo, int idLekar, int idNalaz)
        {
            string sql = "SELECT p.id, p.ime,p.prezime,p.jmbg,l.ImePrezime AS Lekar, pap.datum_pap AS Datum,n.nalaz AS nalaz FROM podaci AS p " +
                         "INNER JOIN pap ON p.id=pap.id_pacijent " +
                         "INNER JOIN nalaz_cito AS n ON pap.id_nalaz=n.id " +
                         "INNER JOIN Lekar AS l ON pap.id_lekar=l.id " +
                         "WHERE pap.id_lekar =@idLekar " +
                         "AND datum_pap BETWEEN date(@datumOd) AND date(@datumDo) " +
                         "AND pap.id_nalaz = @idNalaz " +
                         "AND p.aktivan=1 " +
                         "AND pap.aktivan = 1; ";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var pacijentList = db.Query<PacijentPap>(sql, new { datumOd, datumDo, idLekar, idNalaz });

                return pacijentList;
            }
        }
    }
}
