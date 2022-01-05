using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MonsterTradingCardsGame.DataBase
{
    class DataBaseConnection
    {
        private static DataBaseConnection DB = new DataBaseConnection();
        const string databaseLogin = "Host=localhost;Username=postgres;Password=;Database=postgres";
        private NpgsqlConnection database;


        public static DataBaseConnection getInstance()
        {
            return DB;
        }
        

        public void connect()
        {
            database = new NpgsqlConnection(databaseLogin);
            database.Open();
        }

        public void disconnect()
        {
            database.Close();
        }

        public void register(string username, string password)
        {
                connect();
                using (var cmd = new NpgsqlCommand("INSERT INTO users (username, password, coins, elo) VALUES (@u, @p, @c, @e)", database))
                {
                    cmd.Parameters.AddWithValue("u", username);
                    cmd.Parameters.AddWithValue("p", 123);
                    cmd.Parameters.AddWithValue("c", 20);
                    cmd.Parameters.AddWithValue("e", 0);
                    cmd.ExecuteNonQuery();
                }
                disconnect();
            
        }
        public void login(string username, string password)
        {
            connect();
            using (var cmd = new NpgsqlCommand("INSERT INTO users (username, password, coins, elo) VALUES (@u, @p, @c, @e)", database))
            {
                cmd.Parameters.AddWithValue("u", username);
                cmd.Parameters.AddWithValue("p", 123);
                cmd.Parameters.AddWithValue("c", 20);
                cmd.Parameters.AddWithValue("e", 0);
                cmd.ExecuteNonQuery();
            }
            disconnect();

        }
    }
}
