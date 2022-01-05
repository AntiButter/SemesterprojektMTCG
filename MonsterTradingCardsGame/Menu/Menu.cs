using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterTradingCardsGame.Users;
using MonsterTradingCardsGame.Fights;
using MonsterTradingCardsGame.DataBase;
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
                if (DataBaseConnection.getInstance().login(username, password))
                {
                    Console.Clear();
                    Console.WriteLine("logged in succesfully");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                    MenuLoop();
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
        }
        public void MenuLoop()
        {
            Console.Clear();
            Fighting fight = new Fighting();
            bool running = true;
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
    }
}
