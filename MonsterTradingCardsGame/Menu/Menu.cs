using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterTradingCardsGame.Users;
using MonsterTradingCardsGame.Fights;
using MonsterTradingCardsGame.DataBase;
using MonsterTradingCardsGame.Cards;
using MonsterTradingCardsGame.CardShop;
namespace MonsterTradingCardsGame.Menu
{
    public class Menu
    {
        public void preMenu()
        {
            
            bool loggedIn = false;
            while(!loggedIn)
            {
                Console.Clear();
                Console.WriteLine("Login(1) or Register(2) or Stop (3)");
                int input = Convert.ToInt32(Console.ReadLine());
                if (input == 1)
                {
                    Console.WriteLine("Username: ");
                    var username = Console.ReadLine();
                    Console.WriteLine("Password: ");
                    var password = Console.ReadLine();
                    BaseUser User = DataBaseConnection.getInstance().login(username, password);

                    if (User != null)
                    {
                        User.SetDeck(DataBaseConnection.getInstance().GetPlayerDeck(User));
                        Console.Clear();
                        Console.WriteLine("logged in succesfully");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        MenuLoop(User);
                    }
                }
                else if (input == 2)
                {
                    Console.WriteLine("Username: ");
                    var username = Console.ReadLine();
                    Console.WriteLine("Password: ");
                    var password = Console.ReadLine();
                    BaseUser User = DataBaseConnection.getInstance().register(username, password);
                }
                else if (input == 3)
                {
                    return;
                }
                else if(input == 4)
                {
                    AdminMenu();
                }
                else
                {
                    continue;
                }


            }
            
        }
        public void ShopLoop(BaseUser user)
        {
            Shop shop = new Shop();
            Console.Clear();
            bool running = true;
            while(running)
            {
                Console.WriteLine("Buy Card Pack (1)");
                Console.WriteLine("Show Active Trades (2)");
                Console.WriteLine("Show Avaliable Trades (3)");
                Console.WriteLine("Return (4)");
                var input = Convert.ToInt32(Console.ReadLine());
                if(input == 1)
                {
                    shop.BuyPack(user);
                }
                else if(input == 2)
                {
                    shop.ShowTrades(user);
                }
                else if(input == 3)
                {
                    shop.TradesAvaliable(user);
                    
                }
                else if(input == 4)
                {
                    return;
                }
            }
        }
        public void MenuLoop(BaseUser user)
        {
            Console.Clear();
            Fighting fight = new Fighting();
            bool running = true;
            Set cardSet = DataBaseConnection.getInstance().getBasicCardSet();
            user.ShowUserInformation();
            while(running)
            {
                Console.WriteLine("Menu has appeared");
                Console.WriteLine("Fight other Player(fight)\nShop (shop)\nShowCollection(coll)\nCreate a deck(create)\nShow Deck(show)\nShow Scoreboard(score)\nTrade(trade)\nStop(stop)");
                var input = Console.ReadLine();
                switch(input)
                {
                    case "create":
                        user.CreateDeck();
                        break;
                    case "show":
                        user.ShowDeck();
                        Console.WriteLine("Press any key to return to menu");
                        Console.ReadKey();
                        break;
                    case "trade":
                        user.Trade();
                        break;
                    case "fight":
                        if (user.CheckDeckSize())
                        {
                            BaseUser enemy = DataBaseConnection.getInstance().GetEnemy(user);
                            enemy.SetDeck(DataBaseConnection.getInstance().GetPlayerDeck(enemy));
                            if (!enemy.CheckDeckSize())
                            {
                                break;
                            }
                            int winner = fight.fight(user.GetDeck(), enemy.GetDeck());
                            if(winner == 1)
                            {
                                DataBaseConnection.getInstance().IncreaseElo(user);
                                DataBaseConnection.getInstance().DecreaseElo(enemy);
                                DataBaseConnection.getInstance().IncreaseGamesPLayed(user);
                                DataBaseConnection.getInstance().IncreaseGamesPLayed(enemy);
                            }
                            else if(winner == 2)
                            {
                                DataBaseConnection.getInstance().IncreaseElo(enemy);
                                DataBaseConnection.getInstance().DecreaseElo(user);
                                DataBaseConnection.getInstance().IncreaseGamesPLayed(enemy);
                                DataBaseConnection.getInstance().IncreaseGamesPLayed(user);
                            }
                            else if(winner == 0)
                            {
                                DataBaseConnection.getInstance().IncreaseGamesPLayed(enemy);
                                DataBaseConnection.getInstance().IncreaseGamesPLayed(user);
                            }
                        }
                        break;
                    case "coll":
                        Console.Clear();
                        user.ShowUserCollection();
                        Console.WriteLine("Press any key to return to menu");
                        Console.ReadKey();
                        break;
                    case "shop":
                        ShopLoop(user);
                        break;
                    case "score":
                        DataBaseConnection.getInstance().ShowScoreboard();
                        Console.WriteLine("Press any key to return to menu");
                        Console.ReadKey();
                        break;
                    case "stop":
                        return;
                }
                Console.Clear();
            }
        }
        public void AdminMenu()
        {
            while(true)
            {
                Console.WriteLine("Add card (1)");
                int input = Convert.ToInt32(Console.ReadLine());
                if(input == 1)
                {
                    Console.WriteLine("Name: ");
                    var name = Console.ReadLine();
                    Console.WriteLine("Damage: ");
                    var damage = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Type: ");
                    var type = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Element: ");
                    var element = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Race: ");
                    var race = Convert.ToInt32(Console.ReadLine());

                    DataBaseConnection.getInstance().addCardToSet(name, damage, type, element, race);
                }
            }
            
        }
    }
}
