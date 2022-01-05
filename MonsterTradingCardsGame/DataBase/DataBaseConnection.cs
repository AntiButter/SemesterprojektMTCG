using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterTradingCardsGame.Users;
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
                using (var statement = new NpgsqlCommand("INSERT INTO users (username, password, coins, elo) VALUES (@user, @pass, @co, @elo)", database))
                {
                    statement.Parameters.AddWithValue("user", username);
                    statement.Parameters.AddWithValue("pass", password);
                    statement.Parameters.AddWithValue("co", 20);
                    statement.Parameters.AddWithValue("elo", 0);
                    statement.ExecuteNonQuery();
                }
                disconnect();
            
        }
        public bool login(string username, string password)
        {
            connect();
            using (var statement = new NpgsqlCommand("SELECT username, password FROM users WHERE username = (@user) AND password = (@pass)", database))
            {
                statement.Parameters.AddWithValue("user", username);
                statement.Parameters.AddWithValue("pass", password);

                NpgsqlDataReader reader = statement.ExecuteReader();
                if(reader.HasRows)
                {
                    disconnect();
                    return true;
                }
                
                
            }
            disconnect();
            return false;
        }
        
    }
}
