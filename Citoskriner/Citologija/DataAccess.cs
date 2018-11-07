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


        public static IEnumerable <Podaci> ReadAll()
        {
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var test = db.Query<Podaci>("SELECT id,ime ,prezime,jmbg FROM podaci WHERE aktivan = 1 ");

                return test;
            }
        }

        public static int UpisPacijenta(Podaci pacijent)
        {
            string sql = "INSERT INTO podaci (ime, prezime,jmbg,aktivan) Values (@ime,@prezime,@jmbg,'" + 1 + "'); " +
                        " SELECT last_insert_rowid()";
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var affectedRows = db.Query<int>(sql, new { pacijent.ime, pacijent.prezime, pacijent.jmbg });
                return affectedRows.Single();
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

        public static IEnumerable<Pacijenti> DatSelect(string OD, string DO, string cito)
        {
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                return db.Query<Pacijenti>
                ("SELECT * FROM pregled WHERE  datum_pap => @OD AND datum_pap =< @DO AND nalaz_cito = @cito ", new { OD, DO, cito }).ToList();
            }
        }

        public static IEnumerable<Pacijenti> IzvestaCito(string cito)
        {
            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                return db.Query<Pacijenti>
                ("SELECT * FROM pregled WHERE  nalaz_cito = @cito ", new { cito }).ToList();
            }
        }

        public static Podaci VratiPacijenta(int id)
        {
            string sql = "SELECT * FROM podaci WHERE id = @id AND aktivan=1;";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var pacijentList = db.Query<Podaci>(sql, new { id });

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