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
            DataBaseConnection.getInstance().register();
            Menu menu = new Menu();
            ElementsEnum elements = new ElementsEnum();
            CardTypeEnum types = new CardTypeEnum();
            Console.WriteLine("Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Password: ");
            string password = Console.ReadLine();
            BaseUser SetoKaiba = new BaseUser(password,username,1);
            BaseUser PikachuAI = new BaseUser("chuuu", "PikaAI", 2);
            //SetoKaiba.ShowUserInformation();
            //Pikachu.ShowUserInformation();
            cardBase Goblinbergh = new cardBase("Goblinbergh",10,ElementsEnum.elements.normal,CardTypeEnum.CardTypes.monster,1);
            cardBase WaterSpout = new cardBase("Water Spout", 50, ElementsEnum.elements.water, CardTypeEnum.CardTypes.spell,2);
            cardBase FireGoblin = new cardBase("Fire Goblin", 30, ElementsEnum.elements.fire, CardTypeEnum.CardTypes.monster, 3);
            cardBase Shadowstep = new cardBase("Shadowstep",40, ElementsEnum.elements.normal, CardTypeEnum.CardTypes.spell, 4);
            cardBase MegaRayquaza = new cardBase("Mega Rayquaza", 500000, ElementsEnum.elements.normal, CardTypeEnum.CardTypes.monster, 5);
            SetoKaiba.AddCardToUserCollection(Goblinbergh);
            SetoKaiba.AddCardToUserCollection(WaterSpout);
            SetoKaiba.AddCardToUserCollection(FireGoblin);
            SetoKaiba.AddCardToUserCollection(Shadowstep);
            PikachuAI.AddCardToUserCollection(Goblinbergh);
            PikachuAI.AddCardToUserCollection(WaterSpout);
            PikachuAI.AddCardToUserCollection(FireGoblin);
            PikachuAI.AddCardToUserCollection(Shadowstep);
            SetoKaiba.CreateDeck();
            PikachuAI.CreateDeck();
            menu.MenuLoop(SetoKaiba, PikachuAI);
        }
    }
}