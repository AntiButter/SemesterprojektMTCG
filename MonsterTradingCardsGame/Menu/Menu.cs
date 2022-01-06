using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterTradingCardsGame.Users;
using MonsterTradingCardsGame.Fights;
using MonsterTradingCardsGame.DataBase;
using MonsterTradingCardsGame.Cards;
namespace MonsterTradingCardsGame.Menu
{
    class Menu
    {
        public void preMenu()
        {
            Console.WriteLine("Login(1) or Register(2)");
            int input = Convert.ToInt32(Console.ReadLine());
            if(input == 1)
            {
                Console.WriteLine("Username: ");
                var username = Console.ReadLine();
                Console.WriteLine("Password: ");
                var password = Console.ReadLine();
                BaseUser User = DataBaseConnection.getInstance().login(username, password);
                if(User != null)
                {
                    Console.Clear();
                    Console.WriteLine("logged in succesfully");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    MenuLoop(User);
                }
            }
            else if(input == 2)
            {
                Console.WriteLine("Username: ");
                var username = Console.ReadLine();
                Console.WriteLine("Password: ");
                var password = Console.ReadLine();
                DataBaseConnection.getInstance().register(username, password);
            }
            else if(input == 3)
            {
                AdminMenu();
            }
        }
        public void MenuLoop(BaseUser user)
        {
            Console.Clear();
            Fighting fight = new Fighting();
            bool running = true;
            Set cardSet = DataBaseConnection.getInstance().getBasicCardSet();
            cardSet.PrintSet();
            user.ShowUserInformation();
            while(running)
            {
                Console.WriteLine("Menu has appeared");
                Console.WriteLine("Fight AI (fightai)\nFight other Player(fight)\nShowCollection(coll)\nStop(stop)");
                var input = Console.ReadLine();
                switch(input)
                {
                    case "fight":

                        break;
                    case "coll":
                        Console.Clear();
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
