using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterTradingCardsGame.Users;
using MonsterTradingCardsGame.Cards;
using MonsterTradingCardsGame.EnumsAreTheEnemy;
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
        public BaseUser getPlayerstack(BaseUser user)
        {
            connect();
            using (var statement = new NpgsqlCommand("Select b.cardid,b.name,b.damage,b.type,b.element,b.race from basiccardset b join usercards u on b.cardid = u.cardid join users u2 on u2.userid = u.userid WHERE u.userid = @userid", database))
            {
                statement.Parameters.AddWithValue("userid", user.UserID);
                NpgsqlDataReader reader = statement.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cardBase tempCard = new cardBase(reader["name"].ToString(), (int)reader["damage"], (ElementsEnum.elements)reader["element"], (CardTypeEnum.CardTypes)reader["type"],
                            (CardRaceEnum.Races)reader["race"], (int)reader["cardid"]);
                        user.AddCardToUserCollection(tempCard);
                    }
                    
                }
                disconnect();
                return user;
            }
        }
        public int GenerateToken(string name)
        {
            int token = 0;
            int i = 0;
            foreach (Char character in name)
            {
                token += (int)character * i;
                i++;
            }
            return token;
        }

        public void register(string username, string password)
        {
                connect();
                using (var statement = new NpgsqlCommand("INSERT INTO users (username, password, coins, elo, token) VALUES (@user, @pass, @co, @elo, @token)", database))
                {
                    statement.Parameters.AddWithValue("user", username);
                    statement.Parameters.AddWithValue("pass", password);
                    statement.Parameters.AddWithValue("co", 20);
                    statement.Parameters.AddWithValue("elo", 0);
                    statement.Parameters.AddWithValue("token", GenerateToken(username));
                    statement.ExecuteNonQuery();
                }
                login(username, password);
                disconnect();
            
        }
        public BaseUser login(string username, string password)
        {
            connect();
            using (var statement = new NpgsqlCommand("SELECT userid,username,token,coins,elo FROM users WHERE username = (@user) AND password = (@pass)", database))
            {
                statement.Parameters.AddWithValue("user", username);
                statement.Parameters.AddWithValue("pass", password);

                NpgsqlDataReader reader = statement.ExecuteReader();
                if(reader.HasRows)
                {
                    reader.Read();
                    BaseUser tempUser = new BaseUser((string)reader["username"], (int)reader["userid"], (int)reader["coins"], (int)reader["token"], (int)reader["elo"]);
                    disconnect();
                    getPlayerstack(tempUser);
                    return tempUser;
                }
                
                
            }
            disconnect();
            return null;
        }
        public Set getBasicCardSet()
        {
            connect();
            using (var statement = new NpgsqlCommand("SELECT * FROM basiccardset", database))
            {
                Set tempset = new Set();
                NpgsqlDataReader reader = statement.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    { 
                        cardBase tempCard = new cardBase(reader["name"].ToString(), (int)reader["damage"], (ElementsEnum.elements)reader["element"], (CardTypeEnum.CardTypes)reader["type"],
                            (CardRaceEnum.Races)reader["race"], (int)reader["cardid"]);
                        tempset.addCard(tempCard);
                    } 
                }
                
                disconnect();
                return tempset;
            }
        }
        public void addCardToSet(string name, int damage, int type, int element, int race)
        {
            connect();
            using (var statement = new NpgsqlCommand("INSERT INTO basiccardset (name, damage, type, element, race) VALUES (@name,@damage,@type,@element,@race)", database))
            {
                statement.Parameters.AddWithValue("name",name);
                statement.Parameters.AddWithValue("damage", damage);
                statement.Parameters.AddWithValue("type", type);
                statement.Parameters.AddWithValue("element", element);
                statement.Parameters.AddWithValue("race", race);
                statement.ExecuteNonQuery();
            }
            disconnect();   
        }
        public void addCardToUser(cardBase card, BaseUser user)
        {
            connect();
            using (var statement = new NpgsqlCommand("INSERT INTO usercards (userid, cardid) VALUES (@userid,@cardid)", database))
            {
                statement.Parameters.AddWithValue("userid", user.UserID);
                statement.Parameters.AddWithValue("cardid", card.CardID);
                statement.ExecuteNonQuery();
            }
            disconnect();
            card.ShowStats();
            user.AddCardToUserCollection(card);
        }
        public void generatePack(BaseUser user)
        {
            connect();
            using (var statement = new NpgsqlCommand("SELECT * FROM basiccardset ORDER BY random() LIMIT 4", database))
            {
                NpgsqlDataReader reader = statement.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        cardBase tempCard = new cardBase(reader["name"].ToString(), (int)reader["damage"], (ElementsEnum.elements)reader["element"], (CardTypeEnum.CardTypes)reader["type"],
                            (CardRaceEnum.Races)reader["race"], (int)reader["cardid"]);
                        addCardToUser(tempCard, user);
                    }
                }
            }

            disconnect();
        }
        public void PlayerDeckAdd(BaseUser user, cardBase card)
        {
            connect();
            using (var statement = new NpgsqlCommand("INSERT INTO userdeck (userid, cardid) VALUES (@userid,@cardid)", database))
            {
                statement.Parameters.AddWithValue("userid", user.UserID);
                statement.Parameters.AddWithValue("cardid", card.CardID);
                statement.ExecuteNonQuery();
            }
            disconnect();
        }
        public void ShowScoreboard()
        {
            connect();
            using (var statement = new NpgsqlCommand("Select * from users order by elo desc", database))
            {

                NpgsqlDataReader reader = statement.ExecuteReader();
                if(reader.HasRows)
                {
                    int counter = 1;
                    Console.Clear();
                    while(reader.Read())
                    {
                        Console.WriteLine($"{counter}: {reader["username"]} elo: {reader["elo"]}");
                        counter++;
                    }
                }
               


            }
            disconnect();
        }

    }
}
