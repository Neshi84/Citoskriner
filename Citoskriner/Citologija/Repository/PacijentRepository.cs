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

        public IEnumerable <PacijentBiopsija> getPacijentBiopsija(string datumOd , string datumDo,string lekar,string nalaz)
        {
            string sql = "SELECT * FROM podaci " +
                         "INNER JOIN biopsija ON podaci.id = biopsija.id_pacijent " +
                         "INNER JOIN pap ON podaci.id=pap.id_pacijent " +
                         "WHERE pap.lekar =@lekar " +
                         "AND datum_bio BETWEEN date(@datumOd) AND date(@datumDo) " +
                         "AND biopsija.nalaz_bio =@nalaz " +
                         "AND podaci.aktivan=1 " +
                         "AND biopsija.aktivan = 1 " +
                         "AND pap.aktivan = 1; ";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var pacijentList = db.Query<PacijentBiopsija>(sql, new { datumOd,datumDo,lekar,nalaz });

                return pacijentList;
            }
        }


        public IEnumerable<PacijentHpv> getPacijentHpv(string datumOd, string datumDo, string lekar, string nalaz)
        {
            string sql = "SELECT * FROM podaci " +
                         "INNER JOIN hpv ON podaci.id = hpv.id_pacijent " +
                         "INNER JOIN pap ON podaci.id=pap.id_pacijent " +
                         "WHERE pap.lekar =@lekar " +
                         "AND datum_hpv BETWEEN date(@datumOd) AND date(@datumDo) " +
                         "AND hpv.nalaz_hpv = @nalaz " +
                         "AND podaci.aktivan=1 " +
                         "AND hpv.aktivan = 1 " +
                         "AND pap.aktivan = 1; ";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var pacijentList = db.Query<PacijentHpv>(sql, new { datumOd, datumDo, lekar, nalaz });

                return pacijentList;
            }
        }

        public IEnumerable<PacijentPap> getPacijentPap(string datumOd, string datumDo, string lekar, string nalaz)
        {
            string sql = "SELECT * FROM podaci " +                       
                         "INNER JOIN pap ON podaci.id=pap.id_pacijent " +
                         "WHERE pap.lekar =@lekar " +
                         "AND datum_pap BETWEEN date(@datumOd) AND date(@datumDo) " +
                         "AND pap.nalaz_cito = @nalaz " +
                         "AND podaci.aktivan=1 " +                        
                         "AND pap.aktivan = 1; ";

            using (IDbConnection db = new SQLiteConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Conn"].ConnectionString))
            {
                var pacijentList = db.Query<PacijentPap>(sql, new { datumOd, datumDo, lekar, nalaz });

                return pacijentList;
            }
        }
    }
}
