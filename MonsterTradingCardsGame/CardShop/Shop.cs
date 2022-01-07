using MonsterTradingCardsGame.Cards;
using System;
using System.Collections.Generic;
using System.Text;
using MonsterTradingCardsGame.Users;
using MonsterTradingCardsGame.DataBase;
namespace MonsterTradingCardsGame.CardShop
{
    class Shop : IShop
    {
        public void BuyPack(BaseUser user)
        {
            user.Currency -= 5;
            DataBaseConnection.getInstance().generatePack(user);
        }

    }
}
