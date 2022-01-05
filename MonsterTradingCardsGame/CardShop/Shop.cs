using MonsterTradingCardsGame.Cards;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonsterTradingCardsGame.CardShop
{
    class Shop : IShop
    {
        List<cardBase> CardListClassicSet = new List<cardBase>();

        

        public void AddCard(cardBase newCard)
        {
            CardListClassicSet.Add(newCard);
        }

        public void ShowPacks()
        {
            throw new NotImplementedException();
        }

        public void PackPurchased()
        {
            throw new NotImplementedException();
        }
    }
}
