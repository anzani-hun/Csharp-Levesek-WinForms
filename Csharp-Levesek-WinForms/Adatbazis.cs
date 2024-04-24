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
        MySqlConnectionStringBuilder connStr = new MySqlConnectionStringBuilder()
        {
            Server = "localhost",
            Port = 3306,
            UserID = "root",
            Password = "",
            Database = "etelek"
        };
        MySqlConnection Connect { get => new MySqlConnection(connStr.ConnectionString); }
        // vagy MySqlConnection Connect() { return new MySqlConnection(connStr.ConnectionString); }
        MySqlCommand cmd = null;

        //lista létrehozása a levesek betöltésére
        public List<Leves> LevesLista()
        {
            MySqlConnection conn = Connect;
            List<Leves> Leves = new List<Leves>();
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Levesek;";

            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Leves leves = new Leves(reader.GetString("megnevezes"), reader.GetInt32("kaloria"), reader.GetDecimal("feherje"), reader.GetDecimal("zsir"), reader.GetDecimal("szenhidrat"), reader.GetDecimal("hamu"), reader.GetDecimal("rost"));
                Leves.Add(leves);
            }
            conn.Close();

            return Leves;
        }

        public int LevesHozzaad(Leves ujLevesHozzaad)
        {
            /// 
            MySqlConnection connection = Connect;
            MySqlCommand sql = connection.CreateCommand();

            connection.Open();
            sql.CommandText = $"INSERT INTO levesek (megnevezes, kaloria, feherje, zsir, szenhidrat, hamu, rost) VALUES ('{ujLevesHozzaad.Megnevezes}', {ujLevesHozzaad.Kaloria}, {ujLevesHozzaad.Feherje}, {ujLevesHozzaad.Zsir}, {ujLevesHozzaad.Szenhidrat}, {ujLevesHozzaad.Hamu}, {ujLevesHozzaad.Rost});";
            int ujsor = sql.ExecuteNonQuery();
            connection.Close();

            return ujsor;
        }
    } 
}