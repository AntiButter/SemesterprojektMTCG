using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterTradingCardsGame.Users;
using MonsterTradingCardsGame.Fights;
namespace MonsterTradingCardsGame.Menu
{
    class Menu
    {
        public void MenuLoop(BaseUser User, BaseUser AI)
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
                    case "fightai":
                        fight.fightAI(User.GetDeck(), AI.GetDeck());
                        Console.WriteLine("Press any key to return to menu");
                        Console.ReadKey();
                        break;
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
