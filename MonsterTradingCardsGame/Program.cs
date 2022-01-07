using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterTradingCardsGame.Cards;
using MonsterTradingCardsGame.CardShop;
using MonsterTradingCardsGame.EnumsAreTheEnemy;
using MonsterTradingCardsGame.Fights;
using MonsterTradingCardsGame.Users;
using MonsterTradingCardsGame.Menu;
using MonsterTradingCardsGame.DataBase;
namespace MonsterCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            ElementsEnum elements = new ElementsEnum();
            CardTypeEnum types = new CardTypeEnum();
            CardRaceEnum races = new CardRaceEnum();
            menu.preMenu();
        }
    }
}