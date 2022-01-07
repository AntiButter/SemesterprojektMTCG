using System;
using System.Collections.Generic;
using System.Text;
using MonsterTradingCardsGame.Cards;
using MonsterTradingCardsGame.Users;
namespace MonsterTradingCardsGame.CardShop
{
    interface IShop
    {

        public void BuyPack(BaseUser user);

    }
}
