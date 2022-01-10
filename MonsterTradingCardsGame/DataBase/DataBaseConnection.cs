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
        public List<cardBase> getPlayerstack(BaseUser user)
        {
            connect();
            using (var statement = new NpgsqlCommand("Select b.cardid,b.name,b.damage,b.type,b.element,b.race from basiccardset b join usercards u on b.cardid = u.cardid join users u2 on u2.userid = u.userid WHERE u.userid = @userid", database))
            {
                statement.Parameters.AddWithValue("userid", user.UserID);
                NpgsqlDataReader reader = statement.ExecuteReader();
                List<cardBase> tempList = new List<cardBase>();
                user.ClearCollection();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cardBase tempCard = new cardBase(reader["name"].ToString(), (int)reader["damage"], (ElementsEnum.elements)reader["element"], (CardTypeEnum.CardTypes)reader["type"],
                            (CardRaceEnum.Races)reader["race"], (int)reader["cardid"]);
                        tempList.Add(tempCard);
                    }

                }
                disconnect();
                return tempList;
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

        public BaseUser register(string username, string password)
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
            BaseUser tempUser = login(username, password);
            disconnect();
            return tempUser;
        }
        public BaseUser login(string username, string password)
        {
            connect();
            using (var statement = new NpgsqlCommand("SELECT userid,username,token,coins,elo FROM users WHERE username = (@user) AND password = (@pass)", database))
            {
                statement.Parameters.AddWithValue("user", username);
                statement.Parameters.AddWithValue("pass", password);

                NpgsqlDataReader reader = statement.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    BaseUser tempUser = new BaseUser((string)reader["username"], (int)reader["userid"], (int)reader["coins"], (int)reader["token"], (int)reader["elo"]);
                    disconnect();
                    List<cardBase> tempList = getPlayerstack(tempUser);
                    tempUser.SetCollection(tempList);
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
                if (reader.HasRows)
                {
                    while (reader.Read())
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
                statement.Parameters.AddWithValue("name", name);
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
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cardBase tempCard = new cardBase(reader["name"].ToString(), (int)reader["damage"], (ElementsEnum.elements)reader["element"], (CardTypeEnum.CardTypes)reader["type"],
                            (CardRaceEnum.Races)reader["race"], (int)reader["cardid"]);
                        addCardToUser(tempCard, user);
                    }
                }
            }

            disconnect();
        }
        public void PlayerDeckAdd(BaseUser user, cardBase card, int stackID)
        {
            connect();
            using (var statement = new NpgsqlCommand("INSERT INTO userdeck (userid, cardid,usercardsid) VALUES (@userid,@cardid,@usercardsid)", database))
            {
                statement.Parameters.AddWithValue("userid", user.UserID);
                statement.Parameters.AddWithValue("cardid", card.CardID);
                statement.Parameters.AddWithValue("usercardsid", stackID);
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
                if (reader.HasRows)
                {
                    int counter = 1;
                    Console.Clear();
                    while (reader.Read())
                    {
                        Console.WriteLine($"{counter}: {reader["username"]} elo: {reader["elo"]}");
                        counter++;
                    }
                }



            }
            disconnect();
        }

        public BaseUser GetEnemy(BaseUser user)
        {

            connect();
            bool oppenentFound = false;
            int Range = 200;
            while (!oppenentFound)
            {
                if (Range >= 10000)
                {
                    return null;
                }
                int eloRangeLimitTop = user.Elo + (Range / 2);
                int eloRangeLimitBot = user.Elo - (Range / 2);
                using (var statement = new NpgsqlCommand("Select * from users where elo >= @eloBot and elo <= @eloTop and userid != @userid order by random() limit 1", database))
                {
                    statement.Parameters.AddWithValue("userid", user.UserID);
                    statement.Parameters.AddWithValue("eloBot", eloRangeLimitBot);
                    statement.Parameters.AddWithValue("eloTop", eloRangeLimitTop);

                    NpgsqlDataReader reader = statement.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            
                            BaseUser tempUser = new BaseUser((string)reader["username"], (int)reader["userid"], (int)reader["coins"], (int)reader["token"], (int)reader["elo"]);
                            return tempUser;
                        }
                    }
                    else
                    {
                        Range *= 2;
                        continue;
                    }
                }

            }
            return null;
        }

        public List<cardBase> GetPlayerDeck(BaseUser user)
        {

            connect();
            using (var statement = new NpgsqlCommand("Select * from basiccardset b join userdeck u on b.cardid = u.cardid join users u2 on u2.userid = u.userid where u.userid = @userid", database))
            {
                List<cardBase> tempList = new List<cardBase>();
                statement.Parameters.AddWithValue("userid", user.UserID);
                NpgsqlDataReader reader = statement.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        cardBase tempCard = new cardBase(reader["name"].ToString(), (int)reader["damage"], (ElementsEnum.elements)reader["element"], (CardTypeEnum.CardTypes)reader["type"],
                            (CardRaceEnum.Races)reader["race"], (int)reader["cardid"]);
                        tempList.Add(tempCard);
                    }

                }
                disconnect();
                return tempList;
            }
        }

        public void RemoveCardFromPlayerCollection(BaseUser user, int cardid)
        {
            connect();
            using (var statement = new NpgsqlCommand("Select * from usercards where userid = @userid and cardid = @cardid order by random() limit 1", database))
            {
                statement.Parameters.AddWithValue("userid", user.UserID);
                statement.Parameters.AddWithValue("cardid", cardid);
                NpgsqlDataReader reader = statement.ExecuteReader();
                if (reader.HasRows && reader.Read())
                {
                    int usercardsid = (int)reader["usercardsid"];
                    reader.Close();
                    using (var statement2 = new NpgsqlCommand("Delete * from usercards where usercardsid = @id", database))
                    {
                        statement.Parameters.AddWithValue("id", usercardsid);
                        statement.ExecuteNonQuery();
                    }
                }
                disconnect();
            }
        }

        public void TradeEntry(BaseUser user, int cardid, string type, string race, string element, int min)
        {
            connect();
            using (var statement = new NpgsqlCommand("Insert into trades (userid, cardid, type, race, element, min_damage) values (@uid,@cid,@type,@race,@element,@min)",database))
            {
                statement.Parameters.AddWithValue("uid", user.UserID);
                statement.Parameters.AddWithValue("cid", cardid);
                statement.Parameters.AddWithValue("type", type);
                statement.Parameters.AddWithValue("race", race);
                statement.Parameters.AddWithValue("element", element);
                statement.Parameters.AddWithValue("min", min);
            }

        }

    }
}

