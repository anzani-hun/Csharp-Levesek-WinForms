using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MySqlConnector;       //mysqldata nuget


namespace Csharp_Levesek_WinForms
{
    class Adatbazis
    {
        //adatbázis kapcsolat és adatbázis SELECT futtatása
        MySqlConnection connection = null;
        MySqlCommand sql = null;

        public Adatbazis()
        {
            string connectionString = "server=localhost;userid=root;password=;database=etelek";

            connection = new MySqlConnection(connectionString);
            connection.Open();

            sql = connection.CreateCommand();
            sql.CommandText = "SELECT * FROM levesek;";
        }

        //lista létrehozása a levesek betöltésére
        public List<Levesek> LevesLista()
        {
            List<Levesek> levesek = new List<Levesek>();
            MySqlDataReader reader = sql.ExecuteReader();

            while (reader.Read())
            {
                Levesek leves = new Levesek(reader.GetString("megnevezes"), reader.GetInt32("kaloria"), reader.GetDecimal("feherje"), reader.GetDecimal("zsir"), reader.GetDecimal("szenhidrat"), reader.GetDecimal("hamu"), reader.GetDecimal("rost"));
                levesek.Add(leves);
            }

            connection.Close();

            return levesek;
        }


        public int LevesLista(Levesek ujLevesHozzaad)
        {
            /// 
            MySqlConnection connection = null;
            MySqlCommand sql = null;


            connection = new MySqlConnection("server=localhost;userid=root;password=;database=etelek");
            connection.Open();
            
            //INSERT INTO `levesek`(`megnevezes`, `kaloria`, `feherje`, `zsir`, `szenhidrat`, `hamu`, `rost`) VALUES ('[value-1]','[value-2]','[value-3]','[value-4]','[value-5]','[value-6]','[value-7]')
            sql = new MySqlCommand("INSERT INTO `levesek`(`megnevezes`, `kaloria`, `feherje`, `zsir`, `szenhidrat`, `hamu`, `rost`) VALUES (@megnevezes, @kaloria, @feherje, @zsir, @szenhidrat, @hamu, @rost);", connection);
            sql.Parameters.AddWithValue("@megnevezes", ujLevesHozzaad.Megnevezes);
            sql.Parameters.AddWithValue("@kaloria", ujLevesHozzaad.Kaloria);
            sql.Parameters.AddWithValue("@feherje", ujLevesHozzaad.Feherje);
            sql.Parameters.AddWithValue("@zsir", ujLevesHozzaad.Zsir);
            sql.Parameters.AddWithValue("@szenhidrat", ujLevesHozzaad.Szenhidrat);
            sql.Parameters.AddWithValue("@hamu", ujLevesHozzaad.Hamu);
            sql.Parameters.AddWithValue("@rost", ujLevesHozzaad.Rost);

            int ujsor = sql.ExecuteNonQuery();

            connection.Close();

            return ujsor;
        }

    
    } 
}