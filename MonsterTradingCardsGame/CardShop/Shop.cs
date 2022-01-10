using MonsterTradingCardsGame.Cards;
using System;
using System.Collections.Generic;
using System.Text;
using MonsterTradingCardsGame.Users;
using MonsterTradingCardsGame.DataBase;
namespace MonsterTradingCardsGame.CardShop
{
    public class Shop : IShop
    {
        public void BuyPack(BaseUser user)
        {
            user.Currency -= 5;
            DataBaseConnection.getInstance().generatePack(user);
        }

        public void ShowTrades(BaseUser user)
        {
            DataBaseConnection.getInstance().showActiveTrades(user);
            Console.WriteLine("Press any key to return");
            Console.ReadKey();
        }
        public void TradesAvaliable(BaseUser user)
        {
            DataBaseConnection.getInstance().ShowAvaliableTrades(user);
            Console.WriteLine("Choose Trade via TradeID to take: ");
            int tradeid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Choose Card to give: ");
            user.ShowUserCollection();
            int card = Convert.ToInt32(Console.ReadLine());
            card -= 1;
            DataBaseConnection.getInstance().Trade(user, tradeid, card);
        }
    }
}
