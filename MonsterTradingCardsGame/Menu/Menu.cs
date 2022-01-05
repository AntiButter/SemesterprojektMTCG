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
                var username = Console.ReadLine();
                var password = Console.ReadLine();
                DataBaseConnection.getInstance().login(username, password);
            }
            else if(input == 2)
            {
                var username = Console.ReadLine();
                var password = Console.ReadLine();
                DataBaseConnection.getInstance().register(username, password);
            }
        }
        public void MenuLoop(BaseUser User)
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
                        User.ShowUserCollection();
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
