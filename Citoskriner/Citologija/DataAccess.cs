using Citologija.Model;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace Citologija
{
    internal static class DataAccess
    {
        public static int Id_pacijent { get; set; }


        public static IEnumerable <Pacijent> ReadAll()
        {
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var test = db.Query<Pacijent>("SELECT id,ime ,prezime,jmbg FROM podaci WHERE aktivan = 1 ");

                return test;
            }
        }

        public static int UpisPacijenta(Pacijent pacijent)
        {
            string sql = "INSERT INTO podaci (ime, prezime,jmbg,aktivan) Values (@ime,@prezime,@jmbg,'" + 1 + "'); " +
                        " SELECT last_insert_rowid()";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Query<int>(sql, new { pacijent.ime, pacijent.prezime, pacijent.jmbg });
                return affectedRows.Single();
            }
        }

        public static int deletePacijent(int id)
        {
            string sql = "UPDATE podaci SET aktivan = 0 WHERE id = @id;";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Execute(sql, new { id });
                return affectedRows;
            }

        }

        public static Pacijent getPacijentByJMBG(string jmbg)
        {
            string sql = "SELECT * FROM podaci WHERE jmbg=@jmbg ;";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var pacijentList = db.Query<Pacijent>(sql, new { jmbg });

                return pacijentList.FirstOrDefault();
            }
        }

        public static int UpisPap(int id_pacijent, string datum_pap, string nalaz_cito,string lekar,string br_prep)
        {
            string sql = "INSERT INTO pap (id_pacijent, datum_pap,nalaz_cito,lekar,broj_prep,aktivan) Values (@id_pacijent,@datum_pap,@nalaz_cito,@lekar,@br_prep,'" + 1 + "');";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Execute(sql, new { id_pacijent, datum_pap, nalaz_cito,lekar, br_prep });
                return affectedRows;
            }
        }

        public static int UpisHpv(int id_pacijent, string datum_hpv, string nalaz_hpv)
        {
            string sql = "INSERT INTO hpv (id_pacijent, datum_hpv,nalaz_hpv,aktivan) Values (@id_pacijent,@datum_hpv,@nalaz_hpv,'" + 1 + "');";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Execute(sql, new { id_pacijent, datum_hpv, nalaz_hpv });
                return affectedRows;
            }
        }

        public static int UpisBiopsija(int id_pacijent, string datum_bio, string nalaz_bio)
        {
            string sql = "INSERT INTO biopsija (id_pacijent, datum_bio,nalaz_bio,aktivan) Values (@id_pacijent,@datum_bio,@nalaz_bio,'" + 1 + "');";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Execute(sql, new { id_pacijent, datum_bio, nalaz_bio });
                return affectedRows;
            }
        }

        public static int UpisIntervencije(int id_pacijent, string intervencija)
        {
            string sql = "INSERT INTO hir_intervencije (id_pacijent ,intervencija,aktivan) Values (@id_pacijent,@intervencija,'" + 1 + "');";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Execute(sql, new { id_pacijent, intervencija });
                return affectedRows;
            }
        }

        public static int UpisRevizija(int id_pacijent, string datum_rev, string revizija)
        {
            string sql = "INSERT INTO revizija(id_pacijent ,datum_rev,revizija,aktivan) Values (@id_pacijent,@datum_rev,@revizija,'" + 1 + "');";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Execute(sql, new { id_pacijent, datum_rev, revizija });
                return affectedRows;
            }
        }

        public static string broj()
        {
            string sql = "SELECT COUNT(*) FROM pregled;";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var ukupno = db.ExecuteScalar(sql);
                return ukupno.ToString();
            }
        }

        public static string Broj()
        {
            string sql = "SELECT COUNT(*) FROM pregled;";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var ukupno = db.ExecuteScalar(sql);
                return ukupno.ToString();
            }
        }

        public static Pacijent VratiPacijenta(int id)
        {
            string sql = "SELECT * FROM podaci WHERE id = @id AND aktivan=1;";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var pacijentList = db.Query<Pacijent>(sql, new { id });

                return pacijentList.First();
            }
        }

        public static IEnumerable<Pap> VratiPap(int id)
        {
            string sql = "SELECT id,id_pacijent,broj_prep,datum_pap, nalaz_cito, lekar FROM pap WHERE id_pacijent = @id AND aktivan=1;";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var papList = db.Query<Pap>(sql, new { id }).ToList();

                return papList;
            }
        }
        public static IEnumerable<Hpv> VratiHpv(int id)
        {
            string sql = "SELECT id, id_pacijent,datum_hpv,nalaz_hpv FROM hpv WHERE id_pacijent = @id AND aktivan=1;";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var hpvList = db.Query<Hpv>(sql, new { id }).ToList();

                return hpvList;
            }
        }

        public static IEnumerable<Biopsija> VratiBiopsiju(int id)
        {
            string sql = "SELECT id, id_pacijent,datum_bio, nalaz_bio FROM biopsija WHERE id_pacijent = @id AND aktivan=1;";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var biopsijaList = db.Query<Biopsija>(sql, new { id }).ToList();

                return biopsijaList;
            }
        }
        public static IEnumerable<Revizija> VratiReviziju(int id)
        {
            string sql = "SELECT id, id_pacijent,datum_rev, revizija FROM revizija WHERE id_pacijent = @id AND aktivan=1;";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var revizijaList = db.Query<Revizija>(sql, new { id }).ToList();

                return revizijaList;
            }
        }
        public static IEnumerable<Hir_intervencije> VratiHir(int id)
        {
            string sql = "SELECT id, id_pacijent, intervencija FROM hir_intervencije WHERE id_pacijent = @id AND aktivan=1;";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var hirList = db.Query<Hir_intervencije>(sql, new { id }).ToList();

                return hirList;
            }
        }
    }
}